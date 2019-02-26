<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" AutoEventWireup="true" CodeBehind="Generate_Bill.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Generate_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Content/bootstrap-combobox.css" />
    <script type="text/javascript" src="../Scripts/moment.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.datetimepicker.js"></script>
    <link rel="stylesheet" href="../Content/jquery.datetimepicker.css" />
    <script>
        function openpopup() {
            $("#modal_Appointment").modal('show');
        }
        $(document).ready(function () {
            <%--$('#<%=ddl_Patient.ClientID%>').combobox({
                // Bootstrap version
                bsVersion: '4',
                // default templates
                menu: '<ul class="typeahead typeahead-long dropdown-menu"></ul>',
                item: '<li><a href="#" class="dropdown-item"></a></li>',
                // Custom function with one item argument that compares the item to the input.
                matcher: null
            });--%>
            $('#<%=ddl_Patient.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true
            });
            $('#<%=ddl_Purpose.ClientID%>').chosen({
                allow_single_deselect: true,
                search_contains: true
            });
            $('#<%=txt_Dated.ClientID%>').datetimepicker({
                step: 5,
                format: 'd/m/Y',
                //formatTime: 'H:i A',
                timepicker: false,
                formatDate: 'd/m/Y'
            })
            $('#<%=txt_Concession_Amount.ClientID%>').blur(function () {
                var Concession_Amount = parseFloat($(this).val());
                if (isNaN(Concession_Amount)) {
                    Concession_Amount = 0;
                }
                var Sum_of_Rupes = parseFloat($('#<%=txt_Rupes.ClientID%>').val());
                if (isNaN(Sum_of_Rupes)) {
                    Sum_of_Rupes = 0;
                }
                if (Concession_Amount != 0) {
                    if (Concession_Amount < Sum_of_Rupes) {
                        Sum_of_Rupes = Sum_of_Rupes - Concession_Amount;
                        $('#<%=lbl_Pay_Amount.ClientID%>').text(Sum_of_Rupes.toFixed(2));
                        $('#<%=txt_Concession_Amount.ClientID%>').val(Concession_Amount.toFixed(2));
                    }
                    else {
                        var zero = 0;
                        $('#<%=txt_Concession_Amount.ClientID%>').val(zero.toFixed(2));
                        ShowMessage('Not a Valid Amount!!!', 'Warning');
                    }
                }
            });
            $('#<%=txt_Settlement.ClientID%>').blur(function () {
                var Settlement_Amount = parseFloat($(this).val());
                if (isNaN(Settlement_Amount)) {
                    Settlement_Amount = 0;
                }
                var Sum_of_Rupes = parseFloat($('#<%=txt_Rupes.ClientID%>').val());
                if (isNaN(Sum_of_Rupes)) {
                    Sum_of_Rupes = 0;
                }
                var Concession_Amount = parseFloat($('#<%=txt_Concession_Amount.ClientID%>').val());
                if (isNaN(Concession_Amount)) {
                    Concession_Amount = 0;
                }
                if (Settlement_Amount != 0 && Concession_Amount != 0) {
                    if ((Settlement_Amount + Concession_Amount) < Sum_of_Rupes) {
                        Sum_of_Rupes = Sum_of_Rupes - (Settlement_Amount + Concession_Amount);
                        $('#<%=lbl_Pay_Amount.ClientID%>').text(Settlement_Amount.toFixed(2));
                        $('#<%=txt_Settlement.ClientID%>').val(Settlement_Amount.toFixed(2));
                    }
                    else {
                        var zero = 0;
                        $('#<%=txt_Settlement.ClientID%>').val(zero.toFixed(2));
                        ShowMessage('Not a Valid Amount!!!', 'Warning');
                    }
                }
                else {
                    if (Settlement_Amount < Sum_of_Rupes) {
                        Sum_of_Rupes = Sum_of_Rupes - Settlement_Amount;
                        $('#<%=lbl_Pay_Amount.ClientID%>').text(Settlement_Amount.toFixed(2));
                        $('#<%=txt_Settlement.ClientID%>').val(Settlement_Amount.toFixed(2));
                    }
                    else {
                        var zero = 0;
                        $('#<%=txt_Settlement.ClientID%>').val(zero.toFixed(2));
                        ShowMessage('Not a Valid Amount!!!', 'Warning');
                    }
                }
            });
            $('#<%=txt_Settlement.ClientID%>').change(function () {
                $('#<%=lbl_Pay_Amount.ClientID%>').text($('#<%=txt_Settlement.ClientID%>').val());
            });

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
    <br />
    <div class="messagealert" id="alert_container">
    </div>
    <div class="row" style="margin: 65px">
        <div class="col-md-12">
            <div class="form-group">
                <label>Patient Code</label>
                <asp:DropDownList ID="ddl_Patient" runat="server" AutoPostBack="True" CssClass="form-control col-lg-3 chosen-select " OnSelectedIndexChanged="ddl_Patient_SelectedIndexChanged"></asp:DropDownList>
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
                <asp:TextBox ID="txt_Rupes" TextMode="Number" runat="server" CssClass="form-control" Enabled="false" required />
            </div>
            <div class="form-group">
                <label>Sum of Rupes in words</label>
                <asp:TextBox ID="txt_Rupes_Words" runat="server" CssClass="form-control" Enabled="false" required />
            </div>
            <div class="form-group">
                <label>Mode of Payment</label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="" RepeatDirection="Horizontal" required AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Cash</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                    <asp:ListItem>DD</asp:ListItem>
                    <asp:ListItem>Wallet</asp:ListItem>
                    <asp:ListItem>RSBY</asp:ListItem>
                    <asp:ListItem>EDC</asp:ListItem>
                    <asp:ListItem>Mediclaim</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div id="inputGroup" runat="server" visible="false">
                <div class="form-group">
                    <label>DD/Cheque No/Remarks</label>
                    <asp:TextBox ID="txt_Cheque_No" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label>Dated On</label>
                    <asp:TextBox ID="txt_Dated" runat="server" CssClass="form-control" required />
                </div>
                <div class="form-group">
                    <label>On account of</label>
                    <asp:TextBox ID="txt_Account_Of" runat="server" CssClass="form-control" required />
                </div>
            </div>
            <div class="form-group">
                <asp:CheckBoxList runat="server" ID="chk_Concession" CssClass="checkbox-inline" OnSelectedIndexChanged="chk_Concession_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="1" Selected="False">Concession</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="form-group">
                <asp:CheckBoxList runat="server" ID="chk_Settlement" CssClass="checkbox-inline" OnSelectedIndexChanged="chk_Settlement_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="1" Selected="False">Settlement</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="form-group">
                <asp:Label ID="lbl_Concession_Amount" Visible="false" runat="server" Text="Concession Amount" Font-Bold="true"></asp:Label>
                <asp:TextBox ID="txt_Concession_Amount" TextMode="Number" runat="server" Text="0.00" CssClass="form-control" required Visible="false" />
            </div>
            <div class="form-group">
                <asp:Label ID="lbl_Settlement" Visible="false" runat="server" Text="Settlement Amount" Font-Bold="true"></asp:Label>
                <asp:TextBox ID="txt_Settlement" TextMode="Number" runat="server" Text="0.00" CssClass="form-control" required Visible="false" />
            </div>

            <div class="form-group">
                <label>Pay Amount Rs. </label>
                <asp:Label ID="lbl_Pay_Amount" runat="server" Text="0.00" Font-Bold="true"></asp:Label>
            </div>
            <asp:Button runat="server" ID="btn_Submit_Bill" Text="Save" CssClass="btn btn-primary" OnClick="btn_Submit_Bill_Click" />

            <asp:Button runat="server" ID="btn_Generate_Operation_Bill" Visible="false" Text="Print Operation Bill" CssClass="btn btn-primary" OnClick="btn_Generate_Operation_Bill_Click" />

        </div>
    </div>
</asp:Content>
