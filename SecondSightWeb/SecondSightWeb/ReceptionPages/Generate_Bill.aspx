<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" AutoEventWireup="true" CodeBehind="Generate_Bill.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Generate_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            $('#<%=ddl_Patient.ClientID%>').combobox()
            $('#<%=ddl_Purpose.ClientID%>').combobox()
           $('#<%=txt_Dated.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y H:i A',
                formatTime: 'H:i A',
                formatDate: 'd/m/Y'
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="messagealert" id="alert_container">
    </div>
    <div class="row" style="margin: 20px">
        <div class="col-md-4">
            <div class="form-group">
                <label>Patient Code</label>
                <asp:DropDownList ID="ddl_Patient" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddl_Patient_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Patient Name</label>
                <asp:TextBox ID="txt_Pat_Name" runat="server" CssClass="form-control" required />
            </div>
            <div class="form-group">
                <label>For</label>
                <asp:DropDownList runat="server" ID="ddl_Purpose" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddl_Purpose_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Sum of Rupes</label>
                <asp:TextBox ID="txt_Rupes" TextMode="Number" runat="server" CssClass="form-control" required/>
            </div>
            <div class="form-group">
                <label>Sum of Rupes in words</label>
                <asp:TextBox ID="txt_Rupes_Words" runat="server" CssClass="form-control" required/>
            </div>
            <div class="form-group">
                <label>Mode of Payment</label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="form-control" RepeatDirection="Horizontal" required>
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                    <asp:ListItem>DD</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label>DD/Cheque No</label>
                <asp:TextBox ID="txt_Cheque_No" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Dated On</label>
                <asp:TextBox ID="txt_Dated" runat="server" CssClass="form-control" required/>
            </div>
            <div class="form-group">
                <label>On account of</label>
                <asp:TextBox ID="txt_Account_Of" runat="server" CssClass="form-control" required/>
            </div>
            <asp:Button runat="server" ID="btn_Submit_Bill" Text="Save" CssClass="btn btn-primary" OnClick="btn_Submit_Bill_Click" />

        </div>
    </div>
</asp:Content>
