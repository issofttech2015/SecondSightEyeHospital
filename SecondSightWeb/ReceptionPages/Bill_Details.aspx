<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="Bill_Details.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Bill_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gv_BillDeatils.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin: 65px">
        <asp:Button runat="server" ID="btn_Print_Excell" Text="Export to Excell" OnClick="btn_Print_Excell_Click" CssClass="btn btn-primary" CausesValidation="False" />
        <asp:GridView ID="gv_BillDeatils" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="BillId" DataSourceID="ds_BillDetailsWOF" Width="100%" OnRowCommand="gv_BillDeatils_RowCommand" OnRowDataBound="gv_BillDeatils_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                <asp:BoundField DataField="Bill Id" HeaderText="Bill Id" SortExpression="Bill Id" />
                <asp:BoundField DataField="Patient Id" HeaderText="Patient Id" SortExpression="Patient Id" />
                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" ReadOnly="True" SortExpression="Patient Name" />
                <asp:BoundField DataField="Contact" HeaderText="Contact" SortExpression="Contact" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
                <asp:CheckBoxField DataField="IsPaid" HeaderText="IsPaid" SortExpression="IsPaid" />
                 <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%#Eval("BillId")%>' Text="Details" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Re- Print">
                    <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandArgument='<%#Eval("BillId")%>' CommandName="Cancel" Text="Re-Print" />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ds_BillDetailsWOF" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY Bill.BillId) AS [Sl No],Bill.BillCode AS [Bill Id], tblPatient.PatCode AS[Patient Id], tblPatient.FirstName + ' ' + tblPatient.MiddleName + ' ' + tblPatient.LastName AS [Patient Name],tblPatient.Contact, Bill.Date, CAST(Bill.BillAmount AS Decimal(18, 2)) AS Amount, Bill.IsPaid, Bill.BillId FROM Bill INNER JOIN tblPatient ON Bill.PatientId = tblPatient.PatientId WHERE (Bill.BillCode IS NOT NULL)"></asp:SqlDataSource>
    </div>
</asp:Content>
