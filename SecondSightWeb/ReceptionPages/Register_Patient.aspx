<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" AutoEventWireup="true" CodeBehind="Register_Patient.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Register_Patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=txt_Date_Of_Birth.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y',
                timepicker: false,
                changeMonth: true,
                changeYear: true,
                yearRange: '-100y:c+nn',
                maxDate: '-1d'

            })
            $('#<%=txt_Date_Of_Birth.ClientID%>').off('change').on('change', function () {
                dob = new Date($('#<%=txt_Date_Of_Birth.ClientID%>').val());
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#<%=txt_Age.ClientID%>').val(age);

            });
            $('#<%=txt_Contact.ClientID%>').blur(function () {
                var mobile = $(this).val();
                var txt_Mob = $(this);
                //alert(mobile.length);
                if (mobile.length != 10) {
                    ShowMessage('Enter a 10 digit mobile number', 'Warning');
                    //txt_Mob.setCustomValidity('Enter a 10 digit mobile number')
                }
            });
            $('#<%=txt_Guardaion_Contact.ClientID%>').blur(function () {
                var mobile = $(this).val();
                var txt_Mob = $(this);
                //alert(mobile.length);
                if (mobile.length != 10) {
                    ShowMessage('Enter a 10 digit mobile number', 'Warning');
                    //txt_Mob.setCustomValidity('Enter a 10 digit mobile number')
                }
            });

            $('#<%=txt_Month.ClientID%>').blur(function () {
                var month = $(this).val();
                if (month > 11) {
                    ShowMessage('Max value 11 Month', 'Warning');
                }
            });

        });

    </script>
    <script src='<%=ResolveUrl("~/Webcam_Plugin/jquery.webcam.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl("~/ReceptionPages/Register_Patient.aspx") %>';
        $(function () {
            jQuery("#webcam").webcam({
                width: 320,
                height: 240,
                mode: "save",
                swffile: '<%=ResolveUrl("~/Webcam_Plugin/jscam.swf") %>',
                debug: function (type, status) {
                    $('#camStatus').append(type + ": " + status + '<br /><br />');
                },
                onSave: function (data) {
                    $.ajax({
                        type: "POST",
                        url: pageUrl + "/GetCapturedImage",
                        data: '',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            $("[id*=imgCapture]").css("visibility", "visible");
                            $("[id*=imgCapture]").attr("src", r.d);
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                },
                onCapture: function () {
                    webcam.save(pageUrl);
                }
            });
        });
        function Capture() {
            webcam.capture();
            return false;
        }
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

        .control-label {
            font-weight: 700;
        }

        .form-group-margin {
            margin-bottom: 2%;
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
    <div class="row" style="margin-top: 65px;">
        <div class="messagealert" id="alert_container">
        </div>
        <div class="row">
            <div class="col-sm-4">
                <div id="webcam">
                </div>
            </div>
            <div class="col-sm-4">
                <asp:Image ID="imgCapture" runat="server" CssClass="img-responsive" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <asp:Button ID="btnCapture" Text="Capture" runat="server" OnClientClick="return Capture();" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Patient Identification</label>
            <div class="col-sm-10 form-group-margin">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="lbl_Pat_Code" runat="server" Text="" CssClass="control-label"></asp:Label>
                        <!-- /.input-group -->
                    </div>
                    <!-- /.col-md-6 -->
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txt_Adhar" class="form-control" placeholder="Adhar Card Number" autocomplete="off"></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <!-- /.col-md-6 -->
                </div>
                <!--/.row -->
            </div>
            <!--/.col-sm-10 -->
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Patient Name</label>
            <div class="col-sm-10  form-group-margin">
                <div class="row">
                    <div class="col-md-12">

                        <asp:TextBox runat="server" ID="txt_First_Name" class="form-control" placeholder="Full Name" autocomplete="off" required></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Guardain Details</label>
            <div class="col-sm-10 form-group-margin">
                <div class="row">
                    <div class="col-md-4">

                        <asp:TextBox runat="server" ID="txt_Guardaion_First_Name" class="form-control" placeholder="Guardaion First Name" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txt_Guardaion_Last_Name" class="form-control" placeholder="Guardaion Last Name" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txt_Guardaion_Contact" class="form-control" placeholder="Conatact Number" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Contact Information</label>
            <div class="col-sm-10 form-group-margin">
                <div class="row">
                    <div class="col-md-4">

                        <asp:TextBox runat="server" ID="txt_Nationality" class="form-control" Text="India" placeholder="Nationality" required></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <!-- /.col-md-6 -->
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txt_Contact" class="form-control" placeholder="Conatact Number" TextMode="Number" autocomplete="off" required></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txt_Email" class="form-control" placeholder="Email" TextMode="Email" autocomplete="off"></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <div class="col-md-12" style="margin-top: 15px">
                        <asp:TextBox runat="server" ID="txt_Address" class="form-control" placeholder="Address" AutoCompleteType="Disabled" required></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <!-- /.col-md-6 -->
                </div>
                <!--/.row -->
            </div>
            <!--/.col-sm-10 -->
        </div>
        <div class="form-group">
            <label class="col-sm-2 control-label">Personal Information</label>
            <div class="col-sm-10 form-group-margin">
                <div class="row">
                    <div class="col-md-3">

                        <asp:TextBox runat="server" ID="txt_Date_Of_Birth" class="form-control" placeholder="Date Of Birth" autocomplete="off"></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <!-- /.col-md-6 -->
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Age" class="form-control" placeholder="Age" autocomplete="off" required></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Month" class="form-control" placeholder="Month" autocomplete="off" MaxLength="2" required></asp:TextBox>
                        <!-- /.input-group -->
                    </div>
                    <div class="col-md-3">
                        <asp:RadioButtonList ID="rbt_Gender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                        <!-- /.input-group -->
                    </div>
                    <!-- /.col-md-6 -->
                </div>
                <!--/.row -->
            </div>
            <!--/.col-sm-10 -->
        </div>
        <div style="text-align: center">
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn btn-primary" CausesValidation="False" PostBackUrl="~/ReceptionPages/Register_Patient.aspx?AppointmnetId=hQdEbL9E+MN+mfUsXMd5EQ==&ConfirmDuplicateEntry=True" formnovalidate />
        </div>
    </div>
</asp:Content>
