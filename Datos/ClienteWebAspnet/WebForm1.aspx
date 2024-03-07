<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ClienteWebAspnet.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Cargar Todos" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cargar Descontinuados" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Cargar Stock Cero" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Cargar Por Caducarse" OnClick="Button4_Click" />
    </div>

    <div>   

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

    </div>

    <div>   

        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Generar Excel" />

    </div>
</asp:Content>
