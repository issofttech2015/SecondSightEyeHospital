<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Reception.Master" AutoEventWireup="true" CodeBehind="Confirm_Register.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Confirm_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gv_Appoinment_List.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
        function getConfirmation(sender, title, message) {
            $("#spnTitle").text(title);
            $("#spnMsg").text(message);
            $('#modalPopUp').modal('show');
            $('#btnConfirm').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
        }
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
    <div class="row" style="margin: 65px">
        <div class="messagealert" id="alert_container"></div>
        <div class="form-group">
            <label>Appointment Type</label>
            <div class="col-sm-10">
                <div class="row">
                    <div class="col-md-8">

                        <asp:SqlDataSource ID="ds_Appointment_List" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY AppointmentId) AS SrNo, Appointment.AppointmentId, Appointment.Name, Appointment.Mobile, tblEmployee.FirstName + ' ' + tblEmployee.OtherName + ' ' + tblEmployee.LastName AS [Doctors Name], Appointment.Time FROM Appointment INNER JOIN tblEmployee ON Appointment.DoctorsId = tblEmployee.EmployeeId WHERE (Appointment.IsAttented = 0) AND (Appointment.IsConfirmed = 0) AND (Appointment.IsCanceled = 0)"></asp:SqlDataSource>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:GridView ID="gv_Appoinment_List" runat="server" AutoGenerateColumns="False" DataKeyNames="AppointmentId" DataSourceID="ds_Appointment_List" OnRowCommand="gv_Appoinment_List_RowCommand">
        <Columns>
            <asp:BoundField DataField="SrNo" HeaderText="Sl No" ReadOnly="True" SortExpression="SrNo" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            <asp:BoundField DataField="Doctors Name" HeaderText="Doctors Name" SortExpression="Doctors Name" ReadOnly="True" />
            <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
            <asp:TemplateField HeaderText="Confirm">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%#Eval("AppointmentId")%>' Text="Confirm" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cancel">
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandArgument='<%#Eval("AppointmentId")%>' CommandName="Cancel" Text="Cancel" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="modalPopUp" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">
                        <span id="spnTitle"></span>
                    </h4>
                </div>
                <div class="modal-body">
                    <p>
                        <span id="spnMsg"></span>.
                    </p>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" ID="btnConfirm" class="btn btn-danger" OnClick="btnConfirm_Click">Yes, please</asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
