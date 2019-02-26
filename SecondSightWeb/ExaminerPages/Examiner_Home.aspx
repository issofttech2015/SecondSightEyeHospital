<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Examiner.Master" AutoEventWireup="true" CodeBehind="Examiner_Home.aspx.cs" Inherits="SecondSightWeb.ExaminerPages.Examiner_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .messagealert {
            width: 60%;
            position: fixed;
            top: 0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }

        .tabBgColor {
            background-color: black;
            color: wheat;
        }

        .control-label {
            font-weight: 700;
        }

        .form-group-margin {
            margin-bottom: 2%;
        }

        .chosen-container {
            width: 100% !important;
        }

        .lbl_Center {
            text-align: center;
        }

        .disabledTab {
            pointer-events: none;
        }
    </style>
    <script>
        $(document).ready(function () {
            $('#<%=ddl_Patient_Id.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            //$("input").prop('required', true);
            $('#<%=ddl_CheifComplain.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=ddl_Eye_CheifComplain.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=lb_Systematic_Diseases.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=lb_Allergy.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            tinymce.init({
                selector: '#<%=txt_Past_History.ClientID%>',
                plugins: 'print preview fullpage powerpaste searchreplace autolink directionality advcode visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount tinymcespellchecker a11ychecker imagetools mediaembed  linkchecker contextmenu colorpicker textpattern help',
                toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat'
            });
            tinymce.init({
                selector: '#<%=txt_Family_History.ClientID%>',
                plugins: 'print preview fullpage powerpaste searchreplace autolink directionality advcode visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount tinymcespellchecker a11ychecker imagetools mediaembed  linkchecker contextmenu colorpicker textpattern help',
                toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat'
            });
            tinymce.init({
                selector: '#<%=txt_Current_Treatment.ClientID%>',
                plugins: 'print preview fullpage powerpaste searchreplace autolink directionality advcode visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount tinymcespellchecker a11ychecker imagetools mediaembed  linkchecker contextmenu colorpicker textpattern help',
                toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat'
            });
            tinymce.init({
                selector: '#<%=txt_Current_Investigation.ClientID%>',
                plugins: 'print preview fullpage powerpaste searchreplace autolink directionality advcode visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount tinymcespellchecker a11ychecker imagetools mediaembed  linkchecker contextmenu colorpicker textpattern help',
                toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat'
            });

            $('#btn_Next_E2').click(function (e) {
                e.preventDefault();
                $('#examinationTab a[href="#examination3"]').tab('show');
            });
            $('#btn_Next_E3').click(function (e) {
                e.preventDefault();
                $('#examinationTab a[href="#examinationReport"]').tab('show');
            });
            $('#btn_Back_E3').click(function (e) {
                e.preventDefault();
                $('#examinationTab a[href="#examination2"]').tab('show');
            });
            var userRole = '<%=Session["Employee_Role"]%>'
            $('#btn_Back_R').click(function (e) {
                e.preventDefault();
                switch (userRole) {
                    case 'Examination1':
                        $('#examinationTab a[href="#examination1"]').tab('show');
                        break;
                    case 'Examination2':
                        $('#examinationTab a[href="#examination3"]').tab('show');
                        break;
                }
            });
            $('#a_Chife_Complain').click(function () {
                Assign_Modal('Add Chife Complain', 'Chife Complain', '1')
            });
            $('#a_Systematic_Diseases').click(function () {
                Assign_Modal('Add Systematic Diseases', 'Systematic Diseases', '2')
            });
            $('#a_Allergy').click(function () {
                Assign_Modal('Add Allergy', 'Allergy', '3')
            });
            switch (userRole) {
                case 'Examination1':
                    $('#li_examination2').addClass('disabled disabledTab');
                    $('#li_examination3').addClass('disabled disabledTab');
                    $('#li_examination2').removeAttr("data-toggle");
                    $('#li_examination3').removeAttr("data-toggle");
                    $('#li_examination2').removeClass('active');
                    $('#li_examination3').removeClass('active');
                    $('#examinationTab a[href="#examination1"]').tab('show');
                    break;
                case 'Examination2':
                    $('#li_examination1').addClass('disabled disabledTab');
                    $('#li_examination1').removeAttr("data-toggle");
                    $('#li_examination1').removeClass('active');
                    $('#examinationTab a[href="#examination2"]').tab('show');
                    break;
            }
        });
    </script>
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
        function Assign_Modal(title, name, type) {
            $('#mstr_title').html(title);
            $('#lbl_Master_Name').html(name);
            $('#<%=hdn_Distinguiser.ClientID%>').val(type);
            $('#<%=txt_Name_Master.ClientID%>').val('');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 65px;">
        <div class="messagealert" id="alert_container">
        </div>
        <div class="col-md-12">
            <div class="form-group">
                <label>Patient Id</label>
                <div class="input-group">
                    <asp:DropDownList ID="ddl_Patient_Id" runat="server" AutoPostBack="True" CssClass="form-control chosen-select col-lg-3" DataSourceID="ds_PatCode" DataTextField="PatCode" DataValueField="PatientId" OnSelectedIndexChanged="ddl_Patient_Id_SelectedIndexChanged"></asp:DropDownList>
                    <span class="input-group-addon">
                        <a href="#" data-toggle="modal" data-target="#modal_Patient" class="glyphicon glyphicon-search"></a>
                    </span>
                </div>
                <asp:SqlDataSource ID="ds_PatCode" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT DISTINCT tblPatient.PatientId, tblPatient.PatCode FROM tblPatient INNER JOIN Appointment ON tblPatient.PatCode = Appointment.PatCode WHERE (Appointment.IsConfirmed = 1) AND (Appointment.IsAttented = 0) UNION SELECT 0 AS PatientId, '--Select PatCode--' AS PatCode"></asp:SqlDataSource>
            </div>
        </div>
        <div class="col-md-12">
            <div class="form-group">
                <div class="col-md-2">
                    <label>Appointment Id</label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddl_Appointment" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_AppointmentId" DataTextField="appointmentcode" DataValueField="id" OnSelectedIndexChanged="ddl_Appointment_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label>Appointment Date and Time</label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lbl_Appointment_Date" runat="server"></asp:Label>
                </div>
            </div>
            <asp:SqlDataSource ID="ds_AppointmentId" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetAppoinmentID_For_Examination" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddl_Patient_Id" Name="PatCode" PropertyName="SelectedValue" Type="Int32" />
                    <asp:SessionParameter Name="ExaminerType" SessionField="Employee_RoleId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label>Examination Dates</label>
                <asp:DropDownList ID="ddl_ExaminaationCode" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_ExaminationDates" DataTextField="Date" DataValueField="ConsultantExaminationCombineId" OnSelectedIndexChanged="ddl_ExaminaationCode_SelectedIndexChanged"></asp:DropDownList>
                <asp:SqlDataSource ID="ds_ExaminationDates" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ' 0' AS ConsultantExaminationCombineId, '--Select--' AS Date UNION SELECT ConsultantExaminationCombineId, CONVERT (varchar, Date, 103) AS Date FROM ConsultantExaminationCombine WHERE (PatientId = @PatientID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddl_Patient_Id" Name="PatientID" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label>Previous Prescription</label>
                <asp:DropDownList ID="ddl_Prescription" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="ds_PrescriptionDates" DataTextField="Date" DataValueField="TreatmentId" OnSelectedIndexChanged="ddl_Prescription_SelectedIndexChanged"></asp:DropDownList>
                <asp:SqlDataSource ID="ds_PrescriptionDates" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT '' as TreatmentId,'--Select--' as Date
UNION
SELECT TreatmentId, CONVERT (varchar, TreatmentDate, 103) AS Date FROM Treatement WHERE (PatientId = @PatId)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddl_Patient_Id" Name="PatId" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="ds_Visual_Accuity_Master" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [Name] FROM [VisualAccuityMaster]"></asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <label>Patient Name</label>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lbl_PatName" runat="server"></asp:Label>
            </div>
            <div class="col-md-2">
                <label>Gender</label>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lbl_Gender" runat="server"></asp:Label>
            </div>
            <div class="col-md-2">
                <label>Age</label>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lbl_Age" runat="server"></asp:Label>
            </div>
        </div>
        <ul class="nav nav-tabs" role="tablist" id="examinationTab">
            <li class="active" id="li_examination1">
                <a data-toggle="tab" href="#examination1" id="aExamination1">Examination 1</a>
            </li>
            <li class="" id="li_examination2">
                <a data-toggle="tab" href="#examination2" id="aExamination2">Examination 2</a>
            </li>
            <li class="" id="li_examination3">
                <a data-toggle="tab" href="#examination3" id="aExamination3">Examination 3</a>
            </li>
            <li class="" id="li_examination4">
                <a data-toggle="tab" href="#examinationReport" id="aReport">Examination Report</a>
            </li>
        </ul>
        <div class="tab-content">
            <div id="examination1" class="tab-pane active lbl_Center">
                <div class="row">
                    <div class="col-md-8">
                        <label>AR</label>
                    </div>
                    <div class="col-md-4">
                        <label>NCT</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-8" style="border-right: 1px solid #333;">
                        <div class="row">
                            <div class="col-md-6">
                                <label>RIGHT EYE</label>
                            </div>
                            <div class="col-md-6">
                                <label>LEFT EYE</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>SPH</label>
                                    </div>
                                    <div class="col-md-4">
                                        <label>CYL</label>
                                    </div>
                                    <div class="col-md-4">
                                        <label>AXIS</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_RE"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_RE"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_RE"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>SPH</label>
                                    </div>
                                    <div class="col-md-4">
                                        <label>CYL</label>
                                    </div>
                                    <div class="col-md-4">
                                        <label>AXIS</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_LE"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_LE"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_LE"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-6">
                                <label>&nbsp;</label>
                            </div>
                            <div class="col-md-6">
                                <label>&nbsp;</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>OD</label>
                            </div>
                            <div class="col-md-6">
                                <label>OS</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_OD"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_OS"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="text-align: right; margin-top: 10px;">
                    <asp:Button runat="server" ID="btn_Consultant1_Save" Text="Save" CssClass="btn btn-info" OnClick="btn_Consultant1_Save_Click" />
                </div>
            </div>
            <div id="examination2" class="tab-pane">
                <div style="overflow-y: auto; height: 400px">
                    <div class="form-group">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Cheif Complain</label>
                            </div>
                        </div>
                        <div class="col-md-3">
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
                                <asp:SqlDataSource ID="ds_Eye" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [EyeCode], [EyeDisplayName] FROM [EyeDescription]"></asp:SqlDataSource>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_AddCheifComplain" runat="server" CssClass="btn btn-info" Text="Add Cheif Complain" OnClick="btn_AddCheifComplain_Click" />
                        </div>
                        <div class="col-md-1">
                            <a id="a_Chife_Complain" data-toggle="modal" data-target="#modal_Master_Submit" class="glyphicon glyphicon-plus"></a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_CheifComplainByExaminer" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_CheifComplainByExaminer_RowDeleting" OnRowEditing="gv_CheifComplainByExaminer_RowEditing" OnRowCancelingEdit="gv_CheifComplainByExaminer_RowCancelingEdit">
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
                    <div class="form-group">
                        <div class="col-md-2">
                            <label>Systematic Diseases</label>
                        </div>
                        <div class="col-md-7">
                            <asp:ListBox ID="lb_Systematic_Diseases" runat="server" DataSourceID="ds_Systematic_Diseases" DataTextField="DiseaseName" DataValueField="DiseaseId" CssClass="form-control chosen-select col-lg-3" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                        <div class="col-md-1">
                            <a id="a_Systematic_Diseases" data-toggle="modal" data-target="#modal_Master_Submit" class="glyphicon glyphicon-plus"></a>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txt_Duration_SD" runat="server" CssClass="form-control" placeholder="Duration"></asp:TextBox>
                        </div>
                        <asp:SqlDataSource ID="ds_Systematic_Diseases" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT DiseaseId, DiseaseName FROM SystemicDisease "></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2">
                            <label>Allergy</label>
                        </div>
                        <div class="col-md-7">
                            <asp:ListBox ID="lb_Allergy" runat="server" DataSourceID="ds_Allergy" DataTextField="AlergyName" DataValueField="Id" CssClass="form-control chosen-select col-lg-3" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                        <div class="col-md-1">
                            <a id="a_Allergy" data-toggle="modal" data-target="#modal_Master_Submit" class="glyphicon glyphicon-plus"></a>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txt_Duration_A" runat="server" CssClass="form-control" placeholder="Duration"></asp:TextBox>
                        </div>
                        <asp:SqlDataSource ID="ds_Allergy" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT Id, AlergyName FROM Alergy"></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1">
                            <label>Past History</label>
                        </div>
                        <div class="col-md-11">
                            <asp:TextBox ID="txt_Past_History" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1">
                            <label>Family History</label>
                        </div>
                        <div class="col-md-11">
                            <asp:TextBox ID="txt_Family_History" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1">
                            <label>Current Treatment</label>
                        </div>
                        <div class="col-md-11">
                            <asp:TextBox ID="txt_Current_Treatment" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1">
                            <label>Current Investigation</label>
                        </div>
                        <div class="col-md-11">
                            <asp:TextBox ID="txt_Current_Investigation" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="row" style="text-align: center">
                            <div class="col-md-12">
                                <label>Visual Accuity</label>
                            </div>
                        </div>
                        <div class="row" style="text-align: center">
                            <div class="col-md-2"></div>
                            <div class="col-md-5">
                                <label>OD</label>
                            </div>
                            <div class="col-md-5">
                                <label>OS</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>UNAIDED</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddl_UnAidedOD" CssClass="form-control" DataSourceID="ds_Visual_Accuity_Master" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txt_unaided_od" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddl_Unaided_OS" CssClass="form-control" DataSourceID="ds_Visual_Accuity_Master" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txt_unaided_os" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>AIDED</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddl_Aided_OD" CssClass="form-control" DataSourceID="ds_Visual_Accuity_Master" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txt_aided_od" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddl_Aided_OS" CssClass="form-control" DataSourceID="ds_Visual_Accuity_Master" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txt_aided_os" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>WITH PH</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddl_withph_od" CssClass="form-control" DataSourceID="ds_Visual_Accuity_Master" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txt_withph_od" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:DropDownList runat="server" ID="ddl_withph_os" CssClass="form-control" DataSourceID="ds_Visual_Accuity_Master" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txt_withph_os" runat="server" CssClass="form-control" placeholder="Remarks"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="text-align: right; margin-top: 10px;">
                    <asp:Button runat="server" ID="btn_save_examination2" Text="Save" CssClass="btn btn-info" OnClick="btn_save_examination2_Click" />
                    <button id="btn_Next_E2" class="btn btn-primary" onclick="">Next</button>
                </div>
            </div>
            <div id="examination3" class="tab-pane lbl_Center">
                <asp:SqlDataSource ID="ds_DropsName" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [DropsName] FROM [ExaminationDrops]"></asp:SqlDataSource>
                <div style="overflow-y: auto; height: 400px;">
                    <div class="row">
                        <div class="col-md-12">
                            <label>RETINOSCOPY</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1">
                            <label>Drops</label>
                        </div>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddl_DropsName" runat="server" DataSourceID="ds_DropsName" DataTextField="DropsName" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1">
                            <label>OD</label>
                        </div>
                        <div class="col-md-11">
                            <div class="col-md-2">
                                <label>HM</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OD_HM_value" runat="server" CssClass="form-control" placeholder="Value"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OD_HM_Degree" runat="server" CssClass="form-control" placeholder="Degree"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label>VM</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OD_VM_value" runat="server" CssClass="form-control" placeholder="Value"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OD_VM_Degree" runat="server" CssClass="form-control" placeholder="Degree"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1">
                            <label>OS</label>
                        </div>
                        <div class="col-md-11">
                            <div class="col-md-2">
                                <label>HM</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OS_HM_value" runat="server" CssClass="form-control" placeholder="Value"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OS_HM_Degree" runat="server" CssClass="form-control" placeholder="Degree"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label>VM</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OS_VM_value" runat="server" CssClass="form-control" placeholder="Value"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txt_OS_VM_Degree" runat="server" CssClass="form-control" placeholder="Degree"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>PREVIOUS GLASS POWER</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label>RIGHT EYE</label>
                                    </div>
                                    <div class="col-md-5">
                                        <label>LEFT EYE</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="row">
                                            <label>&nbsp;</label>
                                        </div>
                                        <div class="row">
                                            <label>DISTANCE</label>
                                        </div>
                                        <div class="row">
                                            <label>NEAR</label>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>SPH</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>CYL</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>AXIS</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>VA</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_RE_Distance_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_RE_Distance_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_RE_Distance_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_RE_Distance_PGP"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_RE_Near_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_RE_Near_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_RE_Near_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_RE_Near_PGP"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>SPH</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>CYL</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>AXIS</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>VA</label>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_LE_Distance_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_LE_Distance_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_LE_Distance_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_LE_Distance_PGP"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_LE_Near_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_LE_Near_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_LE_Near_PGP"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_LE_Near_PGP"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>ACCEPTANCE</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-5">
                                        <label>RIGHT EYE</label>
                                    </div>
                                    <div class="col-md-5">
                                        <label>LEFT EYE</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="row">
                                            <label>&nbsp;</label>
                                        </div>
                                        <div class="row">
                                            <label>DISTANCE</label>
                                        </div>
                                        <div class="row">
                                            <label>NEAR</label>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>SPH</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>CYL</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>AXIS</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>VA</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_RE_Distance"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_RE_Distance"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_RE_Distance"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_RE_Distance"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_RE_Near"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_RE_Near"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_RE_Near"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_RE_Near"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label>SPH</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>CYL</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>AXIS</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label>VA</label>
                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_LE_Distance"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_LE_Distance"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_LE_Distance"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_LE_Distance"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_SPH_LE_Near"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CYL_LE_Near"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_AXIS_LE_Near"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_VA_LE_Near"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row" align="center">
                        <div class="row">
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>COLOR VISION</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>PUPIL</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>RAPD</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>AMSLER GRID</label>
                                    </div>
                                    <div class="col-md-3">
                                        <label>SYRINGING</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1">
                                <label>OD</label>
                            </div>
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_color_od" placeholder="OD"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txt_pupil_OD" runat="server" CssClass="form-control" placeholder="Value"></asp:TextBox>
                                    </div>

                                    <div class="col-md-2">
                                        <asp:RadioButtonList ID="rbl_rapd_OD" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButtonList ID="rbl_amsler_OD" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="NORMAL" Value="NORMAL"></asp:ListItem>
                                            <asp:ListItem Text="ABNORM" Value="ABNORMAL"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RadioButtonList ID="rbl_sysinging_OD" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="NLD BLOCKED" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="CC BLOCKED" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="PATIENT" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1">
                                <label>OS</label>
                            </div>
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_color_os" placeholder="OS"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txt_pupil_OS" runat="server" CssClass="form-control" placeholder="Value"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButtonList ID="rbl_rapd_OS" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButtonList ID="rbl_amsler_OS" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="NORMAL" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="ABNORM" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RadioButtonList ID="rbl_sysinging_OS" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="NLD BLOCKED" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="CC BLOCKED" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="PATIENT" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="text-align: right; margin-top: 10px;">
                    <button id="btn_Back_E3" class="btn btn-primary" onclick="">Back</button>
                    <asp:Button ID="btn_Submit_E3" CssClass="btn btn-info" runat="server" Text="Save" OnClick="btn_Submit_E3_Click" />
                    <button id="btn_Next_E3" class="btn btn-primary" onclick="">Next</button>
                </div>
            </div>
            <div id="examinationReport" class="tab-pane">
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-4">
                            <label>Select from one</label>
                            <asp:RadioButtonList ID="rbl_Report" runat="server" CssClass="radio" Style="margin-left: 20px">
                                <asp:ListItem Value="Refer to Inside Doctors" Selected="True">Refer to Inside Doctors</asp:ListItem>
                                <asp:ListItem Value="Refer to Outside Doctors">Refer to Outside Doctors</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div style="text-align: right; margin-top: 10px;">
                    <button id="btn_Back_R" class="btn btn-primary" onclick="">Back</button>
                    <button id="btn_Submit" class="btn btn-primary" onclick="">Submit</button>
                </div>
            </div>
        </div>
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
    <div id="modal_Master_Submit" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 id="mstr_title" class="modal-title">Add </h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label id="lbl_Master_Name">Alergy Name</label>
                        <asp:TextBox ID="txt_Name_Master" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:HiddenField ID="hdn_Distinguiser" runat="server" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btn_Save_Master" runat="server" Text="Save" OnClick="btn_Save_Master_Click" CssClass="btn btn-primary" formnovalidate />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
