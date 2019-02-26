<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Doctor.Master" AutoEventWireup="true" CodeBehind="Doctor_Home.aspx.cs" Inherits="SecondSightWeb.DoctorPages.Doctor_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <style>
        .tabBgColor {
            background-color: black;
            color: wheat;
        }

        .row {
            margin-right: 0px;
            margin-left: 0px;
        }

        .custom-center {
            text-align: center;
        }

        .ex-tab-contain {
            overflow-y: auto;
            max-height: 400px;
        }
    </style>
    <script>
        $(document).ready(function () {

            $('#<%=ddl_PatCode.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_CheifComplain.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Eye_CheifComplain.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_DiseasesByDoctor.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
             $('#<%=ddl_Eye_DiseasesByDoctor.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Doss.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Eye.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Eye_MainComplaints.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Eye_PastOcularHistory.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Eye_PastMedicalHistory.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Appointment.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=lb_Tset_Master.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_AppointmentDates.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });

            tinymce.init({
                selector: '#<%=txt_Advice.ClientID%>',
                plugins: 'print preview fullpage powerpaste searchreplace autolink directionality advcode visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount tinymcespellchecker a11ychecker imagetools mediaembed  linkchecker contextmenu colorpicker textpattern help',
                toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat'
            });
           <%--$('#<%=btn_Serach_Patient_Date.ClientID%>').click(function(e){
                if($('#<%=txt_Date_Search.ClientID%>').val() == "") {
                    ShowMessage('Please select a date', 'Warning');
                }
            });--%>
            $('#btn_Next_E1').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination1"]').tab('show');
            });
            $('#btn_Next_E2').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination2"]').tab('show');
            });
            $('#btn_Next_E3').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination3"]').tab('show');
            });
            $('#btn_Next_E4').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination4"]').tab('show');
            });
            $('#btn_Back_Prescription').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#prescription"]').tab('show');
            });
            $('#btn_Back_E1').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination1"]').tab('show');
            });
            $('#btn_Back_E2').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination2"]').tab('show');
            });
            $('#btn_Back_E3').click(function (e) {
                e.preventDefault();
                $('#prescriptionTab a[href="#examination3"]').tab('show');
            });


            $('#<%=txt_Date_Search.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y',
                timepicker: false
            });
            $('#<%=chk_Ot.ClientID%>').on('change', function (e) {
                if (e.target.checked) {
                    $('#myModal_Operation').modal();
                }
            });
            $("#<%=txt_Medicine_Name.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/Doctor_Home.aspx/GetMedicineName") %>',
                        data: "{ 'medicinename': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map([...new Set(data.d)], function (item) {
                                return item;
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                            alert('error');
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                            alert('fail');
                        }
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });
            $("#<%=txt_DoctorName_OT.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/Doctor_Home.aspx/GetDoctorName") %>',
                        data: "{ 'employeeName': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map([...new Set(data.d)], function (item) {
                                return item;
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                            alert('error');
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                            alert('fail');
                        }
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });
            $("#<%=txt_doc_name.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/Doctor_Home.aspx/GetDoctorName") %>',
                        data: "{ 'employeeName': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map([...new Set(data.d)], function (item) {
                                return item;
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                            alert('error');
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                            alert('fail');
                        }
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });

            $("#<%=txt_MainComplaints.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/Doctor_Home.aspx/GetMainComplaintList") %>',
                        data: "{ 'complaint': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map([...new Set(data.d)], function (item) {
                                return item;
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                            alert('error');
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                            alert('fail');
                        }
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });
            $("#<%=txt_PastOcularHistory.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/Doctor_Home.aspx/GetPastOcularHistoryList") %>',
                        data: "{ 'ocularHistory': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map([...new Set(data.d)], function (item) {
                                return item;
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                            alert('error');
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                            alert('fail');
                        }
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });
            $("#<%=txt_PastMedicalHistory.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/Doctor_Home.aspx/GetPastMedicalHistorList") %>',
                        data: "{ 'medicalHistory': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map([...new Set(data.d)], function (item) {
                                return item;
                            }))
                        },
                        error: function (response) {
                            // alert(response.responseText);
                            alert('error');
                        },
                        failure: function (response) {
                            //alert(response.responseText);
                            alert('fail');
                        }
                    });
                },
                select: function (e, i) {
                },
                minLength: 1
            });

        });

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
        function addRuleDateSearch() {
            document.getElementById('<%=txt_Date_Search.ClientID%>').required = true;
        }
        function addRulesMedicine() {
            document.getElementById('<%=txt_Medicine_Name.ClientID%>').required = true;
            document.getElementById('<%=txt_For.ClientID%>').required = true;
        }
        function removeRules() {
            document.getElementById('<%=txt_Medicine_Name.ClientID%>').required = false;
            document.getElementById('<%=txt_For.ClientID%>').required = false;
            document.getElementById('<%=txt_MainComplaints.ClientID%>').required = false;
            document.getElementById('<%=txt_PastOcularHistory.ClientID%>').required = false;
            document.getElementById('<%=txt_PastMedicalHistory.ClientID%>').required = false;
        }
        function addRulesMainComplaints() {
            document.getElementById('<%=txt_MainComplaints.ClientID%>').required = true;
            document.getElementById('<%=txt_PastOcularHistory.ClientID%>').required = false;
            document.getElementById('<%=txt_PastMedicalHistory.ClientID%>').required = false;
        }
        function addRulesPastOcularHistory() {
            document.getElementById('<%=txt_PastOcularHistory.ClientID%>').required = true;
            document.getElementById('<%=txt_MainComplaints.ClientID%>').required = false;
            document.getElementById('<%=txt_PastMedicalHistory.ClientID%>').required = false;
        }
        function addRulesPastMedicalHistory() {
            document.getElementById('<%=txt_PastMedicalHistory.ClientID%>').required = true;
            document.getElementById('<%=txt_PastOcularHistory.ClientID%>').required = false;
            document.getElementById('<%=txt_MainComplaints.ClientID%>').required = false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrp_Manager" runat="server"></asp:ScriptManager>
    <div class="row" style="margin-top: 65px;">
        <div class="messagealert" id="alert_container">
        </div>
        <div style="overflow-y: auto; height: 80%; overflow-x: hidden">
            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_PatCode" runat="server" CssClass="form-control chosen-search col-lg-3" AutoPostBack="True" DataSourceID="ds_PatCode" DataTextField="PatCode" DataValueField="PatientId" OnSelectedIndexChanged="ddl_PatCode_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_PatCode_Date" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT Appointment.PatCode, tblPatient.PatientId FROM tblPatient INNER JOIN Appointment ON Appointment.PatCode = tblPatient.PatCode WHERE (Appointment.IsConfirmed = 1) AND (Appointment.IsAttented = 0) AND (Appointment.DoctorsId = @DoctorsId)
 AND (CAST(Appointment.Time AS Date) = CAST(@DateTime AS Date)) UNION SELECT '--Select PatCode--' AS PatCode, 0 AS PatientId">
                        <SelectParameters>
                            <asp:SessionParameter Name="DoctorsId" SessionField="EmployeeId" />
                            <asp:ControlParameter ControlID="ddl_AppointmentDates" DbType="DateTime" Name="DateTime" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="ds_PatCode" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT Appointment.PatCode, tblPatient.PatientId FROM tblPatient INNER JOIN Appointment ON Appointment.PatCode = tblPatient.PatCode WHERE (Appointment.IsConfirmed = 1) AND (Appointment.IsAttented = 0) AND (Appointment.DoctorsId = @DoctorsId) AND (CAST(Appointment.Time as Date) = CAST(GETDATE() as Date)) UNION SELECT '--Select PatCode--' AS PatCode, 0 AS PatientId">
                        <SelectParameters>
                            <asp:SessionParameter Name="DoctorsId" SessionField="EmployeeId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txt_Date_Search" runat="server" placeholder="Enter a Date for Search" CssClass="form-control" AutoCompleteType="Disabled" Visible="false"></asp:TextBox>
                    <asp:DropDownList ID="ddl_AppointmentDates" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_AppointmentDates" DataTextField="AppointmentDate" DataValueField="Appointmentvalue" OnDataBound="ddl_AppointmentDates_DataBound" OnSelectedIndexChanged="ddl_AppointmentDates_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_AppointmentDate_WP" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="Select distinct CONVERT(varchar,Appointment.time,103) as AppointmentDate,CAST(Appointment.Time as Date) as Appointmentvalue from Appointment inner join tblPatient on tblPatient.PatCode=Appointment.PatCode where Appointment.DoctorsId=@DoctorId and IsConfirmed=1 and IsAttented=0 and tblPatient.PatientId=@PatientId">
                        <SelectParameters>
                            <asp:SessionParameter Name="DoctorId" SessionField="EmployeeId" />
                            <asp:ControlParameter ControlID="ddl_PatCode" Name="PatientId" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="ds_AppointmentDates" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="Select distinct CONVERT(varchar,Appointment.time,103) as AppointmentDate,CAST(Appointment.Time as Date) as Appointmentvalue from Appointment where Appointment.DoctorsId=@DoctorId and IsConfirmed=1 and IsAttented=0 order by Appointmentvalue desc
">
                        <SelectParameters>
                            <asp:SessionParameter Name="DoctorId" SessionField="EmployeeId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btn_Serach_Patient_Date" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_Serach_Patient_Date_Click" OnClientClick="return addRuleDateSearch();" />
                </div>
                <div class="col-md-2">
                    <label>Examination Dates</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_ExaminaationCode" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_ExaminationDates" DataTextField="Date" DataValueField="ConsultantExaminationCombineId" OnSelectedIndexChanged="ddl_ExaminaationCode_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_ExaminationDates" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ConsultantExaminationCombineId, CONVERT (varchar, Date, 103) AS Date FROM ConsultantExaminationCombine WHERE (PatientId = @PatientID) UNION SELECT 0 AS ConsultantExaminationCombineId, '--Select Date--' AS Date">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_PatCode" Name="PatientID" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <label>Appointment Id</label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddl_Appointment" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_AppointmentId_Dates" DataTextField="AppointmentCode" DataValueField="Id" OnSelectedIndexChanged="ddl_Appointment_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_AppointmentId_Dates" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetAppoinmentID_WithDate" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_PatCode" Name="PatCode" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddl_AppointmentDates" Name="Date" PropertyName="SelectedValue" Type="DateTime" />
                            <asp:SessionParameter Name="DoctorId" SessionField="EmployeeId" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="ds_AppointmentId" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetAppoinmentID" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_PatCode" Name="PatCode" PropertyName="SelectedValue" Type="String" />
                            <asp:SessionParameter Name="DoctorId" SessionField="EmployeeId" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-md-3">
                    <label>Appointment Date and Time</label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbl_Appointment_Date" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <label>Patient Name</label>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbl_PatName" runat="server"></asp:Label>
                </div>
                <div class="col-md-1">
                    <label>Gender</label>
                </div>
                <div class="col-md-1">
                    <asp:Label ID="lbl_Gender" runat="server"></asp:Label>
                </div>
                <div class="col-md-1">
                    <label>Age</label>
                </div>
                <div class="col-md-1">
                    <asp:Label ID="lbl_Age" runat="server"></asp:Label>
                </div>
                <div class="col-md-2">
                    <label>Previous Prescription</label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddl_Prescription" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_PrescriptionDates" DataTextField="Date" DataValueField="TreatmentId" OnSelectedIndexChanged="ddl_Prescription_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_PrescriptionDates" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT 0 as TreatmentId,'--Select Date--' as Date
UNION
SELECT TreatmentId, CONVERT (varchar, TreatmentDate, 103) AS Date FROM Treatement WHERE (PatientId = @PatId)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_PatCode" Name="PatId" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <ul class="nav nav-tabs" role="tablist" id="prescriptionTab">
                <li class="active" id="li_prescription">
                    <a data-toggle="tab" href="#prescription" id="aPrescription">Prescription</a>
                </li>
                <li class="" id="li_examination1">
                    <a data-toggle="tab" href="#examination1" id="aExamination1">Examination 1</a>
                </li>
                <li class="" id="li_examination2">
                    <a data-toggle="tab" href="#examination2" id="aExamination2">Examination 2</a>
                </li>
                <li class="" id="li_examination3">
                    <a data-toggle="tab" href="#examination3" id="aExamination3">Examination 3</a>
                </li>
                <li class="" id="li_examination4">
                    <a data-toggle="tab" href="#examination4" id="aExamination4">Examination 4</a>
                </li>
            </ul>
            <div class="tab-content">
                <div id="prescription" class="tab-pane active lbl_Center ex-tab-contain">
                    <%-- Cheif Complain By Doctor --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Cheif Complain</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_CheifComplain" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_CheifComplain" DataTextField="CompalainName" DataValueField="Id"></asp:DropDownList>
                                <asp:SqlDataSource ID="ds_CheifComplain" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [CompalainName] FROM [CheifComplainList]"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txt_Duration_CC" runat="server" CssClass="form-control" placeholder="Duration"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_Eye_CheifComplain" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_Eye" DataTextField="EyeCode" DataValueField="EyeDisplayName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_AddCheifComplain" runat="server" CssClass="btn btn-info" Text="Add Cheif Complain" OnClick="btn_AddCheifComplain_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_CheifComplainByDoctor" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_CheifComplainByDoctor_RowDeleting" OnRowEditing="gv_CheifComplainByDoctor_RowEditing" OnRowCancelingEdit="gv_CheifComplainByDoctor_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                                    <asp:BoundField DataField="CheifComplainID" HeaderText="Cheif Complain ID" ReadOnly="True" />
                                    <asp:BoundField DataField="CheifComplain" HeaderText="Cheif Complain" ReadOnly="True" />
                                    <asp:BoundField DataField="Duration" HeaderText="Duration" ReadOnly="True" />
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" />
                                    <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                                    <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                   <%-- <div class="row">
                        <div class="col-md-2">
                            <label>Diseases</label>
                        </div>
                        <div class="col-md-7">
                            <asp:ListBox ID="lb_Disease" runat="server" CssClass="form-control chosen-search col-lg-3" DataSourceID="ds_Disease" DataTextField="DiseasesName" DataValueField="DiseasesId" SelectionMode="Multiple"></asp:ListBox>
                            <asp:SqlDataSource ID="ds_Disease" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [DiseasesId], [DiseasesName] FROM [Diseases]"></asp:SqlDataSource>
                        </div>
                        <div class="col-md-3">
                            <asp:RadioButtonList ID="rbl_Dis" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Right Eye</asp:ListItem>
                                <asp:ListItem>Left Eye</asp:ListItem>
                                <asp:ListItem>Both Eyes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>--%>
                    <%-- Diseases By Doctor --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Provitional Diagnosis</label> 
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_DiseasesByDoctor" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_DiseasesByDoctor" DataTextField="DiseasesName" DataValueField="DiseasesId"></asp:DropDownList>
                                <asp:SqlDataSource ID="ds_DiseasesByDoctor" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [DiseasesId], [DiseasesName] FROM [Diseases]"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_Eye_DiseasesByDoctor" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_Eye" DataTextField="EyeCode" DataValueField="EyeDisplayName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_AddDiseasesByDoctor" runat="server" CssClass="btn btn-info" Text="Add Diseases" OnClick="btn_AddDiseasesByDoctor_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_DiseasesByDoctor" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_DiseasesByDoctor_RowDeleting" OnRowEditing="gv_DiseasesByDoctor_RowEditing" OnRowCancelingEdit="gv_DiseasesByDoctor_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                                    <asp:BoundField DataField="DiseasesID" HeaderText="Diseases ID" ReadOnly="True" />
                                    <asp:BoundField DataField="Diseases" HeaderText="Diseases" ReadOnly="True" />
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" />
                                    <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                                    <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            <label>External Tests</label>
                        </div>
                        <div class="col-md-10">
                            <asp:CheckBoxList ID="cbl_reffer_external_test" runat="server" DataSourceID="ds_OtCheckLists" DataTextField="CheckList" DataValueField="Id" Visible="true">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Medicine Name</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txt_Medicine_Name" runat="server" CssClass="form-control" placeholder="Medcine Name" />
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddl_Doss" runat="server" DataSourceID="ds_Doss" DataTextField="ShortCodeDoss" DataValueField="DossName" CssClass="form-control chosen-search col-lg-3"></asp:DropDownList>
                            <asp:SqlDataSource ID="ds_Doss" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [DossName], [ShortCodeDoss] FROM [DossList]"></asp:SqlDataSource>
                        </div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddl_Eye" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_Eye" DataTextField="EyeCode" DataValueField="EyeDisplayName">
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="ds_Eye" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [EyeCode], [EyeDisplayName] FROM [EyeDescription]"></asp:SqlDataSource>

                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txt_For" runat="server" CssClass="form-control" placeholder="Doss Duration"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="btn_AddMedicine" runat="server" CssClass="btn btn-info" Text="Add" OnClick="btn_AddMedicine_Click" OnClientClick="return addRulesMedicine();" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_MedicineDetails" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_MedicineDetails_RowDeleting" OnRowEditing="gv_MedicineDetails_RowEditing" OnRowCancelingEdit="gv_MedicineDetails_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                                    <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name" ReadOnly="True" />
                                    <asp:BoundField DataField="DossType" HeaderText="Doss" ReadOnly="True" />
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" />
                                    <asp:BoundField DataField="DossDuration" HeaderText="Duration" ReadOnly="True" HtmlEncode="false" />
                                    <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                                    <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Advice</label>
                        </div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txt_Advice" runat="server" CssClass="form-control" placeholder="Advice" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Refer To Other Doctor</label>
                        </div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txt_doc_name" runat="server" CssClass="form-control" placeholder="Doctors Name" TextMode="SingleLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Refer To Any Test</label>
                        </div>
                        <div class="col-md-10">
                            <asp:ListBox ID="lb_Tset_Master" runat="server" CssClass="form-control chosen-search col-lg-3" DataSourceID="ds_TestMaster" DataTextField="TestName" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
                            <asp:SqlDataSource ID="ds_TestMaster" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [TestName] FROM [TestMaster]"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Refer To OT</label>
                        </div>
                        <div class="col-md-10">
                            <asp:CheckBoxList ID="chk_Ot" runat="server">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <label>Tests to be done before OT</label>
                        </div>
                        <div class="col-md-10">
                            <asp:CheckBoxList ID="cbl_ot_Check_lists" runat="server" DataSourceID="ds_OtCheckLists" DataTextField="CheckList" DataValueField="Id" Visible="false">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="ds_OtCheckLists" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [CheckList] FROM [OtCheckList] WHERE ([IsDeleted] = @IsDeleted)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Main Complaints</label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:TextBox ID="txt_MainComplaints" runat="server" CssClass="form-control" placeholder="Main Complaints"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_Eye_MainComplaints" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_Eye" DataTextField="EyeCode" DataValueField="EyeDisplayName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_AddMainComplaints" runat="server" CssClass="btn btn-info" Text="Add Main Complaints" OnClick="btn_AddMainComplaints_Click" OnClientClick="return addRulesMainComplaints();" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_MainComplaints" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_MainComplaints_RowDeleting" OnRowEditing="gv_MainComplaints_RowEditing" OnRowCancelingEdit="gv_MainComplaints_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                                    <asp:BoundField DataField="MainComplaints" HeaderText="Main Complaints" ReadOnly="True" />
                                    <%--<asp:BoundField DataField="PastOcularHistory" HeaderText="Past Ocular History" ReadOnly="True" />
                                    <asp:BoundField DataField="PastMedicalHistor" HeaderText="Past Medical Histor" ReadOnly="True" />--%>
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" />
                                    <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                                    <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <%-- Past Ocular History --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Past Ocular History</label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:TextBox ID="txt_PastOcularHistory" runat="server" CssClass="form-control" placeholder="Past Ocular History"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_Eye_PastOcularHistory" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_Eye" DataTextField="EyeCode" DataValueField="EyeDisplayName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_AddPastOcularHistory" runat="server" CssClass="btn btn-info" Text="Add Ocular History" OnClick="btn_AddPastOcularHistory_Click" OnClientClick="return addRulesPastOcularHistory();" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_PastOcularHistory" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_PastOcularHistory_RowDeleting" OnRowEditing="gv_PastOcularHistory_RowEditing" OnRowCancelingEdit="gv_PastOcularHistory_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                                    <%--<asp:BoundField DataField="MainComplaints" HeaderText="Main Complaints" ReadOnly="True" />--%>
                                    <asp:BoundField DataField="PastOcularHistory" HeaderText="Past Ocular History" ReadOnly="True" />
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" />
                                    <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                                    <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <%-- Past Medical History --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Past Medical History</label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:TextBox ID="txt_PastMedicalHistory" runat="server" CssClass="form-control" placeholder="Past Medical History"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddl_Eye_PastMedicalHistory" runat="server" CssClass="form-control chosen-search" DataSourceID="ds_Eye" DataTextField="EyeCode" DataValueField="EyeDisplayName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_AddPastMedicalHistory" runat="server" CssClass="btn btn-info" Text="Add Medical History" OnClick="btn_AddPastMedicalHistory_Click" OnClientClick="return addRulesPastMedicalHistory();" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_PastMedicalHistory" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_PastMedicalHistory_RowDeleting" OnRowEditing="gv_PastMedicalHistory_RowEditing" OnRowCancelingEdit="gv_PastMedicalHistory_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                                    <asp:BoundField DataField="PastMedicalHistor" HeaderText="Past Medical Histor" ReadOnly="True" />
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" />
                                    <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                                    <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div style="text-align: right; margin-top: 10px;">
                        <button id="btn_Next_E1" class="btn btn-primary" onclick="">Next</button>
                    </div>
                </div>
                <div id="examination1" class="tab-pane ex-tab-contain">
                    <%-- Gonioscopy --%>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>&nbsp;</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Gonioscopy</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>RIGHT EYE</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Gonioscopy" runat="server" CssClass="form-control" placeholder="Gonioscopy"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>LEFT EYE</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Gonioscopy" runat="server" CssClass="form-control" placeholder="Gonioscopy"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- OcularAlignment --%>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Ocular Alignment</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_OcularAlignment" runat="server" CssClass="form-control" placeholder="Ocular Alignment"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4"></div>
                    </div>
                    <%-- OculerMovement --%>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Oculer Movement</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_OculerMovement" runat="server" CssClass="form-control" placeholder="Oculer Movement"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_OculerMovement" runat="server" CssClass="form-control" placeholder="Oculer Movement"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- PUPIL --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Pupil</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <%--<div class="form-group custom-center">
                                <label>Pupil</label>
                            </div>--%>
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Size</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Size" runat="server" CssClass="form-control" placeholder="Size"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Size" runat="server" CssClass="form-control" placeholder="Size"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Shape</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Shape" runat="server" CssClass="form-control" placeholder="Shape"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Shape" runat="server" CssClass="form-control" placeholder="Shape"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Reaction of Light</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_ReactionOfLight" runat="server" CssClass="form-control" placeholder="Reaction of Light"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_ReactionOfLight" runat="server" CssClass="form-control" placeholder="Reaction of Light"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Remarks</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Remarks" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Remarks" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Upper Lid Margin</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_UpperLidMargin" runat="server" CssClass="form-control" placeholder="Upper Lid Margin"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_UpperLidMargin" runat="server" CssClass="form-control" placeholder="Upper Lid Margin"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Lower Lid Margin</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_LowerLidMargin" runat="server" CssClass="form-control" placeholder="Lower Lid Margin"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_LowerLidMargin" runat="server" CssClass="form-control" placeholder="Lower Lid Margin"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Upper Lash</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_UpperLash" runat="server" CssClass="form-control" placeholder="Upper Lash"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_UpperLash" runat="server" CssClass="form-control" placeholder="Upper Lash"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Lower Lash</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_LowerLash" runat="server" CssClass="form-control" placeholder="Lower Lash"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_LowerLash" runat="server" CssClass="form-control" placeholder="Lower Lash"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Upper Punctum</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_UpperPunctum" runat="server" CssClass="form-control" placeholder="Upper Punctum"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_UpperPunctum" runat="server" CssClass="form-control" placeholder="Upper Punctum"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Lower Punctum</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_LowerPunctum" runat="server" CssClass="form-control" placeholder="Lower Punctum"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_LowerPunctum" runat="server" CssClass="form-control" placeholder="Lower Punctum"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Special Conditions</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_SpecialConditions_Pupil" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_SpecialConditions_Pupil" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div style="text-align: right; margin-top: 10px;">
                        <button id="btn_Back_Prescription" class="btn btn-primary" onclick="">Back</button>
                        <button id="btn_Next_E2" class="btn btn-primary" onclick="">Next</button>
                    </div>
                </div>
                <div id="examination2" class="tab-pane ex-tab-contain">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group custom-center">
                                <label>&nbsp;</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>RIGHT EYE</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>LEFT EYE</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- CONJUCTIVA --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Conjuctiva</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Upper Palperbal</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_UpperPalperbal" runat="server" CssClass="form-control" placeholder="Upper Palperbal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_UpperPalperbal" runat="server" CssClass="form-control" placeholder="Upper Palperbal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Lower Palperbal</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_LowerPalperbal" runat="server" CssClass="form-control" placeholder="Lower Palperbal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_LowerPalperbal" runat="server" CssClass="form-control" placeholder="Lower Palperbal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Bulbar Nasal</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_BulbarNasal" runat="server" CssClass="form-control" placeholder="Bulbar Nasal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_BulbarNasal" runat="server" CssClass="form-control" placeholder="Bulbar Nasal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Bulber Temporal</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_BulberTemporal" runat="server" CssClass="form-control" placeholder="Bulber Temporal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_BulberTemporal" runat="server" CssClass="form-control" placeholder="Bulber Temporal"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Limbus</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Limbus" runat="server" CssClass="form-control" placeholder="Limbus"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Limbus" runat="server" CssClass="form-control" placeholder="Limbus"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Fornix</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Fornix" runat="server" CssClass="form-control" placeholder="Fornix"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Fornix" runat="server" CssClass="form-control" placeholder="Fornix"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Special Conditions</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_SpecialConditions_Conjuctiva" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_SpecialConditions_Conjuctiva" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- Cornea --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Cornea</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Sclera</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Sclera" runat="server" CssClass="form-control" placeholder="Sclera"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Sclera" runat="server" CssClass="form-control" placeholder="Sclera"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Cornea</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Cornea" runat="server" CssClass="form-control" placeholder="Cornea"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Cornea" runat="server" CssClass="form-control" placeholder="Cornea"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Anterior Chamber Central depth</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_AnteriorChamberCentraldepth" runat="server" CssClass="form-control" placeholder="Anterior Chamber Central depth"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_AnteriorChamberCentraldepth" runat="server" CssClass="form-control" placeholder="Anterior Chamber Central depth"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Anterior Chamber Peripheral Depth</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_AnteriorChamberPeripheraldepth" runat="server" CssClass="form-control" placeholder="Anterior Chamber Peripheral Depth"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_AnteriorChamberPeripheraldepth" runat="server" CssClass="form-control" placeholder="Anterior Chamber Peripheral Depth"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Von Henrick’s Grading</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_VonHenricksGrading" runat="server" CssClass="form-control" placeholder="Von Henrick’s Grading"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_VonHenricksGrading" runat="server" CssClass="form-control" placeholder="Von Henrick’s Grading"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Special Conditions</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_SpecialConditions_Cornea" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_SpecialConditions_Cornea" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- IRIS --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Iris</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Iris Detail</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_IrisDetail" runat="server" CssClass="form-control" placeholder="Iris Detail"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_IrisDetail" runat="server" CssClass="form-control" placeholder="Iris Detail"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div style="text-align: right; margin-top: 10px;">
                        <button id="btn_Back_E1" class="btn btn-primary" onclick="">Back</button>
                        <button id="btn_Next_E3" class="btn btn-primary" onclick="">Next</button>
                    </div>
                </div>
                <div id="examination3" class="tab-pane ex-tab-contain">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group custom-center">
                                <label>&nbsp;</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>RIGHT EYE</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>LEFT EYE</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Lens --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Lens</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Lens Status</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_LensStatus" runat="server" CssClass="form-control" placeholder="Lens Status"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_LensStatus" runat="server" CssClass="form-control" placeholder="Lens Status"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Pigments on Anterior Len Capsule</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_PigmentsOnAnteriorLenCapsule" runat="server" CssClass="form-control" placeholder="Pigments On Anterior Len Capsule"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_PigmentsOnAnteriorLenCapsule" runat="server" CssClass="form-control" placeholder="Pigments On Anterior Len Capsule"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Special Conditions</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_SpecialConditions_Lens" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_SpecialConditions_Lens" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- Intra Ocular Pressure --%>
                    <div class="row">
                        <div class="form-group custom-center">
                            <label>Intra Ocular Pressure</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Method</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Applanation</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Actual Time</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group custom-center">
                                    <asp:TextBox ID="txt_ActualTime" runat="server" CssClass="form-control" placeholder="Actual Time"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Right Eye</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group custom-center">
                                    <asp:TextBox ID="txt_RE_Applanation" runat="server" CssClass="form-control" placeholder="Applanation"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Left Eye</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group custom-center">
                                    <asp:TextBox ID="txt_LE_Applanation" runat="server" CssClass="form-control" placeholder="Applanation"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="text-align: right; margin-top: 10px;">
                        <button id="btn_Back_E2" class="btn btn-primary" onclick="">Back</button>
                        <button id="btn_Next_E4" class="btn btn-primary" onclick="">Next</button>
                    </div>
                </div>
                <div id="examination4" class="tab-pane ex-tab-contain">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group custom-center">
                                <label>&nbsp;</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>RIGHT EYE</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>LEFT EYE</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Vitreous --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Vitreous</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Vitreous</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Vitreous" runat="server" CssClass="form-control" placeholder="Vitreous"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Vitreous" runat="server" CssClass="form-control" placeholder="Vitreous"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- Fundus --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Fundus Drawing</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Fundus</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_FundusUp" runat="server" CssClass="form-control" placeholder="Fundus Up"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_FundusUp" runat="server" CssClass="form-control" placeholder="Fundus Up"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="row">
                                &nbsp;
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_FundusDown" runat="server" CssClass="form-control" placeholder="Fundus Down"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_FundusDown" runat="server" CssClass="form-control" placeholder="Fundus Down"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">&nbsp;</div>
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Special Conditions</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_SpecialConditions_Fundus" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_SpecialConditions_Fundus" runat="server" CssClass="form-control" placeholder="Special Conditions"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- Diagnosis --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Diagnosis</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Description</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2"></div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Description" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-8">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Description" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                    </div>
                    <%-- Follow Up/ Action Plan --%>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group custom-center">
                                <label>Follow Up/ Action Plan</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Follow Up/ Action Plan</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <asp:TextBox ID="txt_FollowUp" runat="server" CssClass="form-control" placeholder="Follow Up"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Glass Prescription --%>
                    <%--<div class="row">
                        <div class="form-group custom-center">
                            <label>Glass Prescription</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>&nbsp;</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Eye</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Distance Vision</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <label>SPh</label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <label>Cyl</label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <label>Axis</label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <label>VA</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>ADD</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <label>SPh</label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <label>VA</label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <label>Distance</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Right Eye</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_DV_SPh" runat="server" CssClass="form-control" placeholder="Sph"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Cyl" runat="server" CssClass="form-control" placeholder="Cyl"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Axis" runat="server" CssClass="form-control" placeholder="Axis"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_DV_VA" runat="server" CssClass="form-control" placeholder="VA"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_ADD_SPh" runat="server" CssClass="form-control" placeholder="Sph"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_ADD_VA" runat="server" CssClass="form-control" placeholder="VA"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_RE_Distance" runat="server" CssClass="form-control" placeholder="Distance"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="row">
                                <div class="form-group custom-center">
                                    <label>Left Eye</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_DV_SPh" runat="server" CssClass="form-control" placeholder="Sph"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Cyl" runat="server" CssClass="form-control" placeholder="Cyl"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Axis" runat="server" CssClass="form-control" placeholder="Axis"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_DV_VA" runat="server" CssClass="form-control" placeholder="VA"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_ADD_SPh" runat="server" CssClass="form-control" placeholder="Sph"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_ADD_VA" runat="server" CssClass="form-control" placeholder="VA"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group custom-center">
                                        <asp:TextBox ID="txt_LE_Distance" runat="server" CssClass="form-control" placeholder="Distance"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <div style="text-align: right; margin-top: 10px;">
                        <asp:Button ID="btn_Submit" runat="server" Text="Save Prescription" CssClass="btn btn-success" OnClick="btn_Submit_Click" OnClientClick="return removeRules();" />
                        <button id="btn_Back_E3" class="btn btn-primary" onclick="">Back</button>
                    </div>
                </div>
            </div>
            <div class="row" style="text-align: center; padding-top: 6px;">
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-danger" PostBackUrl="~/DoctorPages/Doctor_Home.aspx" formnovalidate />
                <asp:SqlDataSource ID="ds_OT_Master" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT 0 as Id,'--Select--' as OtChargeCategory
UNION
SELECT [Id], [OtChargeCategory] FROM [OTChargeCategory]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="ds_Ot_Procedure" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT 0 AS OtChargeId, '--Select--' AS Name UNION SELECT OtChargeId, Name FROM OTCharges WHERE (OtCategoryId = @OtCategoryId)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddl_Operation_Type" Name="OtCategoryId" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="modal fade" id="myModal_Operation" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Suggest Operation</h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel ID="upd_otAdvice" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddl_Operation_Type" runat="server" DataSourceID="ds_OT_Master" DataTextField="OtChargeCategory" CssClass="form-control" DataValueField="Id" OnSelectedIndexChanged="ddl_Operation_Type_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:DropDownList ID="ddl_Operation_Procedure" runat="server" DataSourceID="ds_Ot_Procedure" DataTextField="Name" CssClass="form-control" DataValueField="OtChargeId"></asp:DropDownList>
                                    <asp:RadioButtonList ID="rbl_Eye" runat="server">
                                        <asp:ListItem Text="LEFT EYE" Value="LEFT EYE"></asp:ListItem>
                                        <asp:ListItem Text="RIGHT EYE" Value="RIGHT EYE"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:TextBox ID="txt_DoctorName_OT" runat="server" CssClass="form-control" placeholder="Search Doctor"></asp:TextBox>
                                    <input type="date" id="txt_Date" runat="server" class="form-control" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_Submit_Operation" runat="server" CssClass="btn btn-danger" Text="Save Changes" OnClick="btn_Submit_Operation_Click" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
