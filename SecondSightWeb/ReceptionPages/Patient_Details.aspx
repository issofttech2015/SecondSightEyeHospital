<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="Patient_Details.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Patient_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gv_Patient_List.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin: 65px">
        <asp:Button runat="server" ID="btn_Print_Excell" Text="Export to Excell" OnClick="btn_Print_Excell_Click" CssClass="btn btn-primary" CausesValidation="False" />
        <asp:GridView ID="gv_Patient_List" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataSourceID="ds_Patient_List" >
            <Columns>
                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                <asp:BoundField DataField="PatCode" HeaderText="PatCode" SortExpression="PatCode" />
                <asp:BoundField DataField="Patient Name" HeaderText="Patient Name" ReadOnly="True" SortExpression="Patient Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Contact Number" HeaderText="Contact Number" SortExpression="Contact Number" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Guardain Name" HeaderText="Guardain Name" ReadOnly="True" SortExpression="Guardain Name" />
                <asp:BoundField DataField="Guardain Contact Number" HeaderText="Guardain Contact Number" SortExpression="Guardain Contact Number" />
                <asp:BoundField DataField="Adhar" HeaderText="Adhar" SortExpression="Adhar" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ds_Patient_List" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY PatientId) AS [Sl No], PatCode,FirstName +' ' +MiddleName+' '+LastName as [Patient Name], Gender, Age, Contact as [Contact Number], ResidanceAddress as Address, GuardianFirstName+' '+GuardianLastName as [Guardain Name], GuardianContact as [Guardain Contact Number], Adhar FROM tblPatient"></asp:SqlDataSource>
    </div>
</asp:Content>
