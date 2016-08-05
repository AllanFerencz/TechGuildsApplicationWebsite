Imports System.Data, System.Data.SqlClient
Imports System.Security.Cryptography

Namespace DBL
    Public Class Connection
        Public Const ConnectionStringName As String = "TechGuildsDatabaseConnectionString"

        Public Shared Function GetConnectionString() As String
            Return System.Web.Configuration.WebConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString
        End Function

    End Class


    Public Class Tables

        Public Class Subscriptions


            Public Shared Function InsertSubscription(Name As String, Age As Integer, Email As String) As String

                Dim returnString As String

                Dim connection As New SqlConnection(DBL.Connection.GetConnectionString())

                Dim insertStr As String = "INSERT INTO Subscriptions(subscriptionsFullName, SubscriptionsAge, SubscriptionsEmail)"
                insertStr &= " VALUES (@SubscriptionsFullName, @SubscriptionsAge, @SubscriptionsEmail);"

                Dim cmdInsert As New SqlCommand(insertStr, connection)

                cmdInsert.Parameters.Add("@subscriptionsFullName", SqlDbType.VarChar).Value = Name
                cmdInsert.Parameters.Add("@SubscriptionsAge", SqlDbType.Int).Value = Age
                cmdInsert.Parameters.Add("@SubscriptionsEmail", SqlDbType.VarChar).Value = Email

                Try
                    connection.Open()
                    cmdInsert.ExecuteScalar()
                    connection.Close()

                    returnString = "subscription Successful!"

                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If

                    returnString = "Database Error: Contact database administrator"

                End Try

                Return returnString
            End Function

            Public Shared Function SelectSubscription(Email As String) As Boolean

                Dim returnResponse As Integer = True
                'Accessing Database
                Dim connection As New SqlConnection(DBL.Connection.GetConnectionString())

                Dim userTable As New DataTable

                Dim selectStr = "SELECT SubscriptionsEmail"
                selectStr &= " FROM Subscriptions WHERE SubscriptionsEmail = @SubscriptionsEmail"

                Dim Adapter As SqlDataAdapter = New SqlDataAdapter(selectStr, connection)

                Adapter.SelectCommand.Parameters.Add("@SubscriptionsEmail", SqlDbType.VarChar).Value = Email

                Try
                    connection.Open()
                    Adapter.Fill(userTable)
                    connection.Close()
                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try

                If userTable.Rows.Count > 0 Then
                    returnResponse = False
                End If

                Return returnResponse

            End Function
        End Class

        Public Class Users


            Public Shared Function InsertUser(Login As String, Password As String, Salt As String, IsAdmin As Integer) As String

                Dim returnString As String

                Dim connection As New SqlConnection(DBL.Connection.GetConnectionString())

                Dim insertStr As String = "INSERT INTO Users(UserLogin, UserPassword, UserSalt, UserIsAdmin)"
                insertStr &= " VALUES (@UserLogin, @UserPassword, @UserSalt, @UserIsAdmin);"

                Dim cmdInsert As New SqlCommand(insertStr, connection)


                cmdInsert.Parameters.Add("@UserLogin", SqlDbType.VarChar).Value = Login
                cmdInsert.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = Password
                cmdInsert.Parameters.Add("@UserSalt", SqlDbType.VarChar).Value = Salt
                cmdInsert.Parameters.Add("@UserIsAdmin", SqlDbType.Int).Value = IsAdmin

                Try
                    connection.Open()
                    cmdInsert.ExecuteScalar()
                    connection.Close()

                    returnString = "Registration Successful!"

                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If

                    returnString = "Database Error: Contact database administrator"

                End Try

                Return returnString
            End Function

            Public Shared Function SelectUniqueUser(Login As String) As Boolean

                Dim returnResponse As Integer = True
                'Accessing Database
                Dim connection As New SqlConnection(DBL.Connection.GetConnectionString())

                Dim userTable As New DataTable

                Dim selectStr = "SELECT UserLogin"
                selectStr &= " FROM Users WHERE UserLogin = @UserLogin"

                Dim Adapter As SqlDataAdapter = New SqlDataAdapter(selectStr, connection)

                Adapter.SelectCommand.Parameters.Add("@UserLogin", SqlDbType.VarChar).Value = Login

                Try
                    connection.Open()
                    Adapter.Fill(userTable)
                    connection.Close()


                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try

                If userTable.Rows.Count > 0 Then
                    returnResponse = False
                End If

                Return returnResponse

            End Function

            Public Shared Function SelectUser(Login As String, Password As String) As Integer

                Dim returnLevel As Integer = -1
                'Accessing Database
                Dim connection As New SqlConnection(DBL.Connection.GetConnectionString())

                Dim userTable As New DataTable

                Dim selectStr = "SELECT *"
                selectStr &= " FROM Users WHERE UserLogin = @UserLogin AND UserPassword = @UserPassword"

                Dim Adapter As SqlDataAdapter = New SqlDataAdapter(selectStr, connection)

                Adapter.SelectCommand.Parameters.Add("@UserLogin", SqlDbType.VarChar).Value = Login
                Adapter.SelectCommand.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = Password

                Try
                    connection.Open()
                    Adapter.Fill(userTable)
                    connection.Close()


                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try

                If userTable.Rows.Count > 0 Then
                    returnLevel = userTable.Rows(0).Item("UserIsAdmin")
                End If

                Return returnLevel

            End Function



            Public Shared Function getUserSalt(userLogin As String) As String

                Dim returnSalt As String = ""

                Dim connection As New SqlConnection(DBL.Connection.GetConnectionString())
                Dim SaltTable As New DataTable

                Dim selectStr = "SELECT UserSalt"
                selectStr &= " FROM Users"
                selectStr &= " WHERE UserLogin = @UserLogin;"

                Dim Adapter As SqlDataAdapter = New SqlDataAdapter(selectStr, connection)

                Adapter.SelectCommand.Parameters.Add("@UserLogin", SqlDbType.VarChar).Value = userLogin

                Try
                    connection.Open()
                    Adapter.Fill(SaltTable)
                    connection.Close()

                Catch ex As Exception
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If

                End Try

                If SaltTable.Rows.Count = 1 Then
                    returnSalt = SaltTable.Rows(0).Item("UserSalt")
                End If

                Return returnSalt

            End Function


            Public Shared Function createSalt() As String

                Dim returnSalt As String

                Dim SaltGenerator As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
                Dim Salt(128) As Byte

                SaltGenerator.GetBytes(Salt)

                returnSalt = Convert.ToBase64String(Salt)

                Return returnSalt

            End Function





            Public Shared Function hashPassword(ByVal Password As String, ByVal Salt As String) As String

                Dim returnPassword As String

                Dim saltPassword = String.Concat(Salt, Password)

                Dim bytedPassword() As Byte = Encoding.UTF8.GetBytes(saltPassword)
                Dim sha As New SHA1CryptoServiceProvider()
                Dim reslutingHash As Byte() = sha.ComputeHash(bytedPassword)

                returnPassword = Convert.ToBase64String(reslutingHash)

                Return returnPassword

            End Function

        End Class



    End Class

End Namespace
