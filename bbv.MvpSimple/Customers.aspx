<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="bbv.MvpSimple.Customers" %>

<%@ Register Src="SearchCustomerControl.ascx" TagName="SearchCustomerControl" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers</title>
    <style type="text/css">
        .delete {
            color: red !important;
        }

        .details {
            color: blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Customers</h2>
        <div>
            <uc1:SearchCustomerControl ID="SearchCustomerControl1" runat="server" />
        </div>
        <div style="padding-top: 15px; clear: left">
            <asp:GridView runat="server" ID="gvCustomers" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvCustomers_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="<%# string.Format("{0}?id={1}", this.ResolveUrl("~/CustomerDetails.aspx") , Eval("Customer_ID")) %>" class="details">Details</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="Customer_ID" />
                    <asp:BoundField HeaderText="Company" DataField="Company_Name" />
                    <asp:BoundField HeaderText="Contact" DataField="Contact_Name" />
                    <asp:BoundField HeaderText="Country" DataField="Country" />
                    <asp:BoundField HeaderText="Phone" DataField="Phone" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server"
                                CausesValidation="False"
                                CommandArgument='<%# Eval("Customer_ID") %>'
                                CommandName="Delete"
                                CssClass="delete"
                                Text="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
