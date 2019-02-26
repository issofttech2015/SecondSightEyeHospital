<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Doctor.Master" AutoEventWireup="true" CodeBehind="DischargePatient.aspx.cs" Inherits="SecondSightWeb.DoctorPages.DischargePatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script>
        $(document).ready(function () {
            $('#<%=ddl_Operation_List.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });
            $('#<%=txt_Discharge_Date.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y',
                timepicker: false
            });
            $('#<%=txt_Next_Visit_Date.ClientID%>').datetimepicker({
                 step: 5,
                format: 'd/m/Y',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y',
                timepicker: false
            });
            $('#<%=txt_Next_Visit_Time.ClientID%>').datetimepicker({
                step: 5,
                //format: 'd/m/Y H:i A',
                format: 'H:i A',
                formatTime: 'H:i A',
                //formatDate: 'm/d/Y',
                datepicker: false
            });
            $('#<%=txt_OT_Start_Date_time.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y H:i A',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y'
            });
            $('#<%=txt_OT_End_Date_time.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y H:i A',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y'
            });
            $("#<%=txt_Medicine_Name.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/DoctorPages/DischargePatient.aspx/GetMedicineName") %>',
                        data: "{ 'medicinename': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
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
            $('#<%=ddl_Doss.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true,
            });

            tinymce.init({
                selector: '#<%=txt_Addnl_Comments.ClientID%>',
                plugins: 'print preview fullpage powerpaste searchreplace autolink directionality advcode visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount tinymcespellchecker a11ychecker imagetools mediaembed  linkchecker contextmenu colorpicker textpattern help',
                toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat'
            });
        });

        function addRulesMedicine() {
            document.getElementById('<%=txt_Medicine_Name.ClientID%>').required = true;
            document.getElementById('<%=txt_For.ClientID%>').required = true;
            document.getElementById('<%=txt_Discharge_Date.ClientID%>').required = false;
            document.getElementById('<%=txt_Diagonosis.ClientID%>').required = false;
            document.getElementById('<%=txt_Next_Visit_Date.ClientID%>').required = false;
            document.getElementById('<%=txt_Next_Visit_Time.ClientID%>').required = false;
        }
        function removeRules() {
            document.getElementById('<%=txt_Medicine_Name.ClientID%>').required = false;
            document.getElementById('<%=txt_For.ClientID%>').required = false;
            document.getElementById('<%=txt_Discharge_Date.ClientID%>').required = true;
            document.getElementById('<%=txt_Diagonosis.ClientID%>').required = true;
            document.getElementById('<%=txt_Next_Visit_Date.ClientID%>').required = true;
            document.getElementById('<%=txt_Next_Visit_Time.ClientID%>').required = true;
        }
    </script>
    <style>
        .tabBgColor {
            background-color: black;
            color: wheat;
        }
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 65px;">
        <div class="messagealert" id="alert_container">
        </div>
        <div style="overflow-y: auto; height: 500px; overflow-x: hidden">
            <div class="row">
                <div class="col-md-4">
                    <label>Operation Type</label>
                    <asp:RadioButtonList ID="rbl_Is_Operation_Done" runat="server" OnSelectedIndexChanged="rbl_Is_Operation_Done_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Value="1">Approve Operated</asp:ListItem>
                        <asp:ListItem Value="2">Discharge Patient</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-md-4">
                    <label>Pat Code</label>
                    <asp:DropDownList ID="ddl_Pat_Code" runat="server" CssClass="form-control chosen-search col-lg-3" AutoPostBack="True" DataSourceID="ds_PatCode_Operated" DataTextField="PatCode" DataValueField="PatientId" OnSelectedIndexChanged="ddl_Pat_Code_SelectedIndexChanged"></asp:DropDownList>

                    <asp:SqlDataSource ID="ds_PatCode_Discharge" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetPatCode_For_Operated_Discharge" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="ds_PatCode_Operated" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetPatCode_For_Operated" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                </div>
                <div class="col-md-4">
                    <label>Operation List</label>
                    <asp:DropDownList ID="ddl_Operation_List" runat="server" CssClass="form-control chosen-search col-lg-3" AutoPostBack="True" DataSourceID="ds_Operation_List_Approved_Operated" DataTextField="OperationCode" DataValueField="OperationId" OnSelectedIndexChanged="ddl_Operation_List_SelectedIndexChanged"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_Operation_List_Approved_Operated" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetOperationCode" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_Pat_Code" Name="patientId" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="ds_Operation_List_Discharge_Patient" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="sp_GetOperationCode_Discharge" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_Pat_Code" Name="patientId" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>

            </div>
            <div class="row" id="OperationDetails1" runat="server">
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Reffered Doctor : </label>
                        <asp:Label ID="lbl_Reffered_Doctor" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Patient Name : </label>
                        <asp:Label ID="lbl_Patient_Name" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Eye : </label>
                        <asp:Label ID="lbl_Eye" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Suggested Doctor : </label>
                        <asp:Label ID="lbl_Suggested_Doctor" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row" id="OperationDetails2" runat="server">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Operation Name : </label>
                        <asp:Label ID="lbl_Operation_Name" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Operation Date : </label>
                        <asp:Label ID="lbl_Operation_Date" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Surgical Procedure : </label>
                        <asp:Label ID="lbl_Surgical_Procedure" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row" id="OperationDetails3" runat="server">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Operation Start Date time : </label>
                        <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" ID="txt_OT_Start_Date_time" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Operation End Date time : </label>
                        <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" ID="txt_OT_End_Date_time" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row" id="OperationDetails_Input" runat="server">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Button ID="Approved_Operated" runat="server" Text="Approve" CssClass="btn btn-primary" OnClick="Approved_Operated_Click" />
                    </div>
                </div>
            </div>

            <div class="row" id="Discharge_Patient_Input_Group1" runat="server">
                <div class="row" style="margin-left: 1px;">
                    <div class="col-md-3">
                        <label>Discharge Certificate Type</label>
                    </div>
                    <div class="col-md-9">
                        <asp:RadioButtonList ID="rb_Discharge_Type" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Day Care" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Night Care" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="row" style="margin-left: 1px;">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Discharge Date : </label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" ID="txt_Discharge_Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Diagonosis : </label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="txt_Diagonosis"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Next Visit Date : </label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" ID="txt_Next_Visit_Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Next Visit Time : </label>
                            <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" ID="txt_Next_Visit_Time"></asp:TextBox>
                        </div>

                    </div>
                </div>

            </div>
            <div class="row" id="Discharge_Patient_Input_Group2" runat="server">
                <div class="col-md-2">
                    <label>Medicine Name</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txt_Medicine_Name" runat="server" CssClass="form-control" placeholder="Medcine Name" />
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Doss" runat="server" DataSourceID="ds_Doss" DataTextField="ShortCodeDoss" DataValueField="DossName" CssClass="form-control chosen-search col-lg-3"></asp:DropDownList>
                    <asp:SqlDataSource ID="ds_Doss" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [DossName], [ShortCodeDoss] FROM [DossList]"></asp:SqlDataSource>
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
                    <div class="form-group">
                    </div>
                </div>
            </div>
            <div class="row" id="Discharge_Patient_Input_Group3" runat="server">
                <div class="col-md-12">
                    <asp:GridView ID="gv_MedicineDetails" runat="server" CssClass="table" HeaderStyle-CssClass="tabBgColor" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gv_MedicineDetails_RowDeleting" OnRowEditing="gv_MedicineDetails_RowEditing" OnRowCancelingEdit="gv_MedicineDetails_RowCancelingEdit">
                        <Columns>
                            <asp:BoundField DataField="SlNo" HeaderText="Sl No" ReadOnly="True" />
                            <asp:BoundField DataField="MedicineName" HeaderText="Medicine Name" ReadOnly="True" />
                            <asp:BoundField DataField="DossType" HeaderText="Doss" ReadOnly="True" />
                            <asp:BoundField DataField="DossDuration" HeaderText="Duration" ReadOnly="True" />
                            <asp:ButtonField HeaderText="Edit" Text="Edit" CommandName="Edit" />
                            <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="Delete" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row" id="Discharge_Patient_Input_Group5" runat="server">
                <div class="col-md-2">
                    <label>Additional Comments</label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txt_Addnl_Comments" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                    </div>
                </div>
            </div>
            <div class="row" id="Discharge_Patient_Input_Group4" runat="server">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <asp:Button ID="Save_Discharge_Patient_Details" runat="server" Text="Save Discharge Details" CssClass="btn btn-primary" OnClick="Save_Discharge_Patient_Details_Click" OnClientClick="return removeRules();" />
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-danger" PostBackUrl="~/DoctorPages/DischargePatient.aspx" formnovalidate />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
