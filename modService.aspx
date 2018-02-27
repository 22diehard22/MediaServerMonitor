<%@ Page Title="Modify Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="modService.aspx.cs" Inherits="modService" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Justify">
            Name:
            <asp:TextBox ID="tbName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            URL:
            <asp:TextBox ID="tbURL" runat="server"></asp:TextBox>
            <br />
            API key:
            <asp:TextBox ID="tbApiKey" runat="server"></asp:TextBox>
        </asp:Panel>

        </asp:Content>