<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Registration.aspx.vb" Inherits="Registration" %>

<asp:Content ID="cbhHead" ContentPlaceHolderID="cbhHead" Runat="Server">
</asp:Content>
<asp:Content ID="cphMainContent" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <form id="frmRegistration" class="form-horizontal" runat="server">
        <h1>Registration</h1>
        
        <h5>Enter your Information below to create an account on the website</h5>
        <br />
        <div class="form-group">
            <label for="txtUserName" class="col-sm-2 control-label">UserName</label> 
            <div class="col-sm-10">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>  
            </div>
            <div class="col-sm-12">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must enter a Username" ControlToValidate="txtUserName" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        </div>
        <br />
        <div class="form-group">
            <label for="txtPasswordRegistration" class="col-sm-2 control-label">Password</label>
            <div class="col-sm-10"> 
                <asp:TextBox ID="txtPasswordRegistration" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-12">
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Must enter a password" ControlToValidate="txtPasswordRegistration" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-group">
            <label for="txtConfirmPasswordRegistration" class="col-sm-2 control-label">Confirm Password</label> 
            <div class="col-sm-10"> 
                <asp:TextBox ID="txtConfirmPasswordRegistration" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-12">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Must enter a confirm password" ControlToValidate="txtConfirmPasswordRegistration" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-2 col-sm-offset-2 text-left"> 
                <asp:CheckBox ID="chkAdmin" runat="server" />
                <label for="chkAdmin" class="control-label">Admin</label> 
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Italic="True" CssClass="text-danger"></asp:Label>
        <br />
        <asp:Button ID="btnSubmitRegistration" runat="server" Text="Submit" CssClass="btn btn-default"/>
        <br />
        <br />
        
        </form>

</asp:Content>

