<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BackOfficeSubscriptions.aspx.vb" Inherits="BackOfficeSubscriptions" %>

<asp:Content ID="cbhHead" ContentPlaceHolderID="cbhHead" Runat="Server">
</asp:Content>
<asp:Content ID="cphMainContent" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <h1>Subscriptions</h1>

    <form id="form1" runat="server">
        <asp:GridView ID="gvSubs" runat="server"  CssClass="table table-hover table-striped grid" AutoGenerateColumns="False" DataKeyNames="SubscriptionsEmail" DataSourceID="Subscripers" AllowPaging="True" UseAccessibleHeader="true" >
            <Columns>
                 <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="SubscriptionsFullName" HeaderText="Name" SortExpression="SubscriptionsFullName" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="SubscriptionsAge" HeaderText="Age" SortExpression="SubscriptionsAge" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="SubscriptionsEmail" HeaderText="Email" ReadOnly="True" SortExpression="SubscriptionsEmail"  ItemStyle-HorizontalAlign="Center"/>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="Subscripers" runat="server" ConnectionString="<%$ ConnectionStrings:TechGuildsDatabaseConnectionString %>" SelectCommand="SELECT * FROM [Subscriptions]" DeleteCommand="DELETE FROM [Subscriptions] WHERE [SubscriptionsEmail] = @SubscriptionsEmail" InsertCommand="INSERT INTO [Subscriptions] ([SubscriptionsFullName], [SubscriptionsAge], [SubscriptionsEmail]) VALUES (@SubscriptionsFullName, @SubscriptionsAge, @SubscriptionsEmail)" UpdateCommand="UPDATE [Subscriptions] SET [SubscriptionsFullName] = @SubscriptionsFullName, [SubscriptionsAge] = @SubscriptionsAge WHERE [SubscriptionsEmail] = @SubscriptionsEmail">
            <DeleteParameters>
                <asp:Parameter Name="SubscriptionsEmail" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="SubscriptionsFullName" Type="String" />
                <asp:Parameter Name="SubscriptionsAge" Type="Int32" />
                <asp:Parameter Name="SubscriptionsEmail" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="SubscriptionsFullName" Type="String" />
                <asp:Parameter Name="SubscriptionsAge" Type="Int32" />
                <asp:Parameter Name="SubscriptionsEmail" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <br />
        <br />
    </form>
</asp:Content>

