
<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="cbhHead" ContentPlaceHolderID="cbhHead" Runat="Server">
</asp:Content>
<asp:Content ID="cphMainContent" ContentPlaceHolderID="cphMainContent" Runat="Server">

     <form id="frmLogin" class="form-horizontal" runat="server">
        <h1>Login</h1>
        <br />
        <div class="form-group">
            <label for="txtUserNameLogin" class="col-sm-2 control-label">UserName</label> 
            <div class="col-sm-10">
                <asp:TextBox ID="txtUserNameLogin" runat="server" CssClass="form-control"></asp:TextBox> 
                 
            </div>
            <div class="col-sm-12">
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserNameLogin" ErrorMessage="Login Must not be Empty" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-group">
            <label for="txtPasswordLogin" class="col-sm-2 control-label">Password</label>
            <div class="col-sm-10"> 
                <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
            <div class="col-sm-12">
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPasswordLogin" ErrorMessage="Password Must not be Empty" CssClass="text-danger">Password Must not be Empty</asp:RequiredFieldValidator>            
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Italic="True" CssClass="text-danger"></asp:Label>
        <br />
        <asp:Button ID="btnSubmitLogin" runat="server" Text="Login" CssClass="btn btn-default"/>
        <br />
        <br />

    </form>
</asp:Content>

