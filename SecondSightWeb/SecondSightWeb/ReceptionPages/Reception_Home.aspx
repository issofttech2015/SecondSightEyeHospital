<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" AutoEventWireup="true" CodeBehind="Reception_Home.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Reception_Home" EnableEventValidation="true" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Content/bootstrap-combobox.css" />
    <script type="text/javascript" src="../Scripts/moment.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-combobox.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery.datetimepicker.js"></script>
    <link rel="stylesheet" href="../Content/jquery.datetimepicker.css" />
    <script>
        function openpopup() {
            $("#modal_Appointment").modal('show');
        }
        $(document).ready(function () {
            $('#<%=ddl_Doctors.ClientID%>').combobox()
            $('#<%=ddl_doctors_search.ClientID%>').combobox()
            $('#<%=txt_Appointment_Date.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y H:i A',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y'
            })
            $('#<%=txt_Date_Serach.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y',
                timepicker: false
            })
        });
    </script>
    <style type="text/css">
        .messagealert {
            width: 60%;
            position: fixed;
            top: 0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>

    <div class="row" style="margin: 65px">

        <div class="col-md-4">
            <div class="messagealert" id="alert_container">
            </div>
            <div class="form-group">
                <label>Appointment Type</label>
                <asp:RadioButtonList ID="rbtAppointmentType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">By Phone</asp:ListItem>
                    <asp:ListItem>By Manual</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label>Patient ID</label>
                <div class="input-group">
                    <asp:TextBox ID="txt_PatCode_Ins" runat="server" CssClass="form-control" requred ReadOnly="true"></asp:TextBox>
                    <span class="input-group-addon">
                        <a href="#" data-toggle="modal" data-target="#modal_Patient" class="glyphicon glyphicon-search"></a>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <label>Patient Name</label>
                <asp:TextBox ID="txt_PatName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Patient Address</label>
                <asp:TextBox ID="txt_Address" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Patient Mobile</label>
                <div class="input-group">
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" required></asp:TextBox>
                    <span class="input-group-addon">
                        <a href="#" data-toggle="modal" data-target="#modal_Patient" class="glyphicon glyphicon-search"></a>
                    </span>
                </div>
            </div>
            
            <div class="form-group">
                <label>Doctors Name</label>
                <asp:DropDownList ID="ddl_Doctors" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddl_Doctors_SelectedIndexChanged" AutoPostBack="True" DataSourceID="ds_Doctors" DataTextField="Doctor" DataValueField="EmployeeId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_Doctors" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT tblEmployee.FirstName + ' ' + tblEmployee.OtherName + ' ' + tblEmployee.LastName AS Doctor, tblEmployee.EmployeeId FROM tblEmployee INNER JOIN tblEmployeeLog ON tblEmployee.EmployeeId = tblEmployeeLog.EmployeeId WHERE (tblEmployeeLog.RoleId = 2)"></asp:SqlDataSource>
            </div>
            <div class="form-group">
                <label>Date</label>
                <div class="input-group">
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" ID="txt_Appointment_Date" reqired></asp:TextBox>
                    <span class="input-group-addon">
                        <a href="#" data-toggle="modal" data-target="#modal_Appointment" class="glyphicon glyphicon-search"></a>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <asp:CheckBoxList runat="server" ID="chk_IsNew" CssClass="checkbox-inline" OnSelectedIndexChanged="chk_IsNew_SelectedIndexChanged">
                    <asp:ListItem Value="1" Selected="True">New Patient</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
        </div>
        <%--<div class="form-group">
            <label>Appointment Date and Time</label>
            <asp:TextBox runat="server" ID="txt_Appnt_Date"></asp:TextBox>
        </div>--%>
    </div>
    <div id="modal_Patient" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Search Patient</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Patient ID</label>
                        <asp:TextBox ID="txt_PatCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Mobile No</label>
                        <asp:TextBox ID="txt_MobileNumber_Search" TextMode="Number" CssClass="form-control" MinLength="10" MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="btn_Serach" runat="server" Text="Search" OnClick="btn_Serach_Click" CssClass="btn btn-primary" formnovalidate />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="modal_Appointment" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Search Apponiment</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group col-xs-6">
                        <label>Doctors Name</label>
                        <asp:DropDownList ID="ddl_doctors_search" CssClass="form-control" runat="server" DataSourceID="ds_Doctors" DataTextField="Doctor" DataValueField="EmployeeId">
                        </asp:DropDownList>
                        <br />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_Date_Serach"></asp:TextBox>
                        <br />
                        <asp:Button runat="server" ID="btn_Search_Appointment" Text="Search Appointment" OnClick="btn_Search_Appointment_Click" CssClass="btn btn-primary" formnovalidate />
                    </div>
                    <div class="form-group">
                        <label>Appontments</label>
                        <asp:GridView ID="grd_Appontment_Details" runat="server" AutoGenerateColumns="False" DataSourceID="ds_AppointmentList_WOF">
                            <HeaderStyle BackColor="#337ab7" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Doctors Name" HeaderText="Doctors Name" ReadOnly="True" SortExpression="Doctors Name" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
                                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="ds_AppointmentList_WOF" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT tblEmployee.FirstName + '  ' + tblEmployee.OtherName + '  ' + tblEmployee.LastName AS [Doctors Name], Appointment.Name, Appointment.Mobile, Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (CAST(Appointment.Time AS Date) = CAST(GETDATE() AS Date)) and Appointment.IsCanceled=0"></asp:SqlDataSource>
    <asp:SqlDataSource ID="ds_AppointmentList_WF_Doctor" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT tblEmployee.FirstName + '  ' + tblEmployee.OtherName + '  ' + tblEmployee.LastName AS [Doctors Name], Appointment.Name, Appointment.Mobile, Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (Appointment.DoctorsId = @DoctorsId) AND (Appointment.IsCanceled = 0)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddl_doctors_search" Name="DoctorsId" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ds_AppointmentList_WF_Doctor_Time" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT tblEmployee.FirstName + '  ' + tblEmployee.OtherName + '  ' + tblEmployee.LastName AS [Doctors Name], Appointment.Name, Appointment.Mobile, Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (Appointment.DoctorsId = @DoctorsId) AND (CAST(Appointment.Time AS Date) = @Date)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddl_doctors_search" Name="DoctorsId" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="txt_Date_Serach" Name="Date" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label runat="server" ID="lbl_PatientId" Visible="false"></asp:Label>
</asp:Content>
