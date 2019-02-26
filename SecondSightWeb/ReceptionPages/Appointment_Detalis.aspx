<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" AutoEventWireup="true" CodeBehind="Appointment_Detalis.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Appointment_Detalis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=grd_Appontment_Details.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            $('.btn').on('click', function () {
                var $this = $(this);
                $this.button('loading');
                setTimeout(function () {
                    $this.button('reset');
                }, 8000);
            });
            $('#<%=txt_Date_Serach.ClientID%>').datetimepicker({
                step: 5,
                format: 'm/d/Y',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y',
                timepicker: false
            })
         });
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 65px">
        <div class="form-group">
            <label>Appointment Detalis</label>
        </div>
    </div>
    <div class="form-group">
        <label>Doctors Name</label>
        <asp:DropDownList ID="ddl_doctors_search"  CssClass="form-control" runat="server" DataSourceID="ds_Doctors" DataTextField="Doctor" DataValueField="EmployeeId">
        </asp:DropDownList>

        <asp:SqlDataSource ID="ds_Doctors" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ISNULL(tblEmployee.FirstName,'') + ' ' + ISNULL(tblEmployee.OtherName,'') + ' ' + ISNULL(tblEmployee.LastName,'') AS Doctor, tblEmployee.EmployeeId FROM tblEmployee INNER JOIN tblEmployeeLog ON tblEmployee.EmployeeId = tblEmployeeLog.EmployeeId WHERE (tblEmployeeLog.RoleId = 2)"></asp:SqlDataSource>
        <br />
        <asp:TextBox runat="server"  CssClass="form-control" ID="txt_Date_Serach"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btn_Search_Appointment" Text="Search Appointment" OnClick="btn_Search_Appointment_Click" CssClass="btn btn-primary" formnovalidate />
        <asp:Button runat="server" ID="btn_Print_Excell" Text="Export to Excell" OnClick="btn_Print_Excell_Click" CssClass="btn btn-primary" CausesValidation="False" />
    </div>
    <asp:GridView ID="grd_Appontment_Details" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataSourceID="ds_AppointmentList_WOF">
        <Columns>
            <asp:BoundField DataField="Doctors Name" HeaderText="Doctors Name" ReadOnly="True" SortExpression="Doctors Name" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
        </Columns>
    </asp:GridView>
    <div class="col-sm-10">
        <div class="row">
            <div class="col-md-8">
                <asp:SqlDataSource ID="ds_AppointmentList_WOF" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ISNULL(tblEmployee.FirstName,'')+ '  ' + ISNULL(tblEmployee.OtherName ,'')+ '  ' + ISNULL(tblEmployee.LastName,'') AS [Doctors Name], Appointment.Name, Appointment.Mobile, Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (CAST(Appointment.Time AS Date) )= CONVERT (date, SYSUTCDATETIME()) and Appointment.IsCanceled=0 order by Appointment.Time desc"></asp:SqlDataSource>
                <asp:SqlDataSource ID="ds_AppointmentList_WF_Doctor" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ISNULL(tblEmployee.FirstName,'') + '  ' + ISNULL(tblEmployee.OtherName,'') + '  ' + ISNULL(tblEmployee.LastName,'') AS [Doctors Name], Appointment.Name, Appointment.Mobile, Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (Appointment.DoctorsId = @DoctorsId) AND (Appointment.IsCanceled = 0)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddl_doctors_search" Name="DoctorsId" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="ds_AppointmentList_WF_Doctor_Time" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ISNULL(tblEmployee.FirstName,'')+ '  ' + ISNULL(tblEmployee.OtherName,'') + '  ' + ISNULL(tblEmployee.LastName,'') AS [Doctors Name], Appointment.Name, Appointment.Mobile, Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (Appointment.DoctorsId = @DoctorsId) AND (CAST(Appointment.Time AS Date) = @Date)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddl_doctors_search" Name="DoctorsId" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="txt_Date_Serach" Name="Date" PropertyName="Text" DbType="Date" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>

        </div>
    </div>
</asp:Content>
