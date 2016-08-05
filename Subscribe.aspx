<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Subscribe.aspx.vb" Inherits="Subscribe" %>

<asp:Content ID="cbhHead" ContentPlaceHolderID="cbhHead" Runat="Server">
</asp:Content>
<asp:Content ID= "cphMainContent" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <form id="frmSubscription" class="form-horizontal" runat="server">

        <h1>Subscribe</h1>
        <h5>Enter your Information below to Subscribe to the website</h5>
        <br />
        <div class="form-group">
            <label for="txtName" class="col-sm-2 control-label">Name</label> 
            <div class="col-sm-10">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>           
            </div>
            <div class="col-sm-12">
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Must enter a name" ControlToValidate="txtName" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-group">
            <label for="txtAge" class="col-sm-2 control-label">Age</label>
            <div class="col-sm-10"> 
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>        
            </div>
            <div class="col-sm-12">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must enter an age" ControlToValidate="txtAge" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="form-group">
            <label for="txtEmail" class="col-sm-2 control-label">Email</label> 
            <div class="col-sm-10"> 
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-12">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Must enter an email" ControlToValidate="txtEmail" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Italic="True" CssClass="text-danger"></asp:Label>
        <br />
        <asp:Button ID="btnSubmitSubscribe" runat="server" Text="Submit" CssClass="btn btn-default"/>
        <br />
        <br />
        </form>

</asp:Content>

