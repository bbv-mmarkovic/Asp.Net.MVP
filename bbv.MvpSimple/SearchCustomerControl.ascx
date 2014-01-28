<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchCustomerControl.ascx.cs" Inherits="bbv.MvpSimple.SearchCustomerControl" %>
<style type="text/css">
    .search {
        margin-top: 5px;
    }

        .search div {
            float: left;
            margin-left: 5px;
        }
</style>

<div class="search">
    <div>
        Company
    </div>
    <div style="margin-left: 15px">
        <asp:TextBox runat="server" ID="txtSearchTerm" Width="200px" />
    </div>
    <div style="position: relative; top: -1px">
        <asp:Button runat="server" ID="btnSearchByCompany" Text="Search" OnClick="btnSearchByCompany_Click" />
    </div>
    <div style="position: relative; top: -1px">
        <asp:Button runat="server" ID="btnClearSearch" Text="Clear" Enabled="False" OnClick="btnClearSearch_Click" />
    </div>
</div>

