<%@ Page Title="Add Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="addService.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add a service to your environment</h3>
    <p>We need a little information about your device:</p>
    <p>What type of service is it?
        <asp:DropDownList ID="dropServiceType" runat="server">
        </asp:DropDownList>
    </p>
    <p>URL:<asp:TextBox ID="tbUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnTestConnection" runat="server" Text="Test Connection" OnClick="btnTestConnection_Click" />
    </p>
    <p>API key:
        <asp:TextBox ID="tbApiKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnTestAPI" runat="server" OnClick="btnTestAPI_Click" Text="Test API" />
    </p>
    <p>
        <asp:Label ID="testJson" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="downloadQueue" runat="server" Text="Label"></asp:Label>
    </p>
<p>
        <asp:Button ID="btnAddService" runat="server" OnClick="btnAddService_Click" Text="Add Service" />
    </p>
<p>
        <asp:Label ID="dbTestLbl" runat="server" Text="Label"></asp:Label>
    </p>
    </asp:Content>
