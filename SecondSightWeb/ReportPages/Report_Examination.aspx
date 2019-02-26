<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_Examination.aspx.cs" Inherits="SecondSightWeb.ReportPages.Report_Examination" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Examination</title>
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <style>
        .auto-style1 {
            text-align: center;
        }
    </style>
    <script>
        $(document).ready(function () {
            $.ajax({
                url: '<%=ResolveUrl("~/ReportPages/Report_Examination.aspx/GetODOSVMHMAngle") %>',
                data: "",
                dataType: "json",
                type: "POST",
                async: true,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    let canvasHM_OD = document.getElementById('mycanvasOD_HM'),
                        canvasVM_OD = document.getElementById('mycanvasOD_VM'),
                        canvasHM_OS = document.getElementById('mycanvasOS_HM'),
                        canvasVM_OS = document.getElementById('mycanvasOS_VM');
                    draw(canvasHM_OD, data.d[0]);
                    draw(canvasHM_OS, data.d[1]);
                    draw(canvasVM_OD, data.d[2]);
                    draw(canvasVM_OS, data.d[3]);
                    $('#mycanvasOD_HM_value').text('  HM  Value : '+data.d[4]);
                    $('#mycanvasOS_HM_value').text('  HM  Value : ' +data.d[5]);
                    $('#mycanvasOD_VM_value').text('VM  Value : ' +data.d[6]);
                    $('#mycanvasOS_VM_value').text('VM  Value : ' +data.d[7]);
                    console.log(data);
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
            $('#btn_Close').click(function (e) {
                window.close();
            });
            $('#btn_Print').click(function (e) {
                window.print();
            });
        });
        function draw(canvas, angle) {
            var context = canvas.getContext('2d');
            context.clearRect(0, 0, canvas.width, canvas.height);
            var centerX = Math.floor(canvas.width / 2), centerY = Math.floor(canvas.height / 2), radius = Math.floor(canvas.width / 2);
            context.lineWidth = 1;
            context.strokeStyle = 'red';
            var begin = 0; interval = 90;
            var arcSize = degreesToRadians(interval);
            context.beginPath();
            context.moveTo(centerX, centerY);
            context.arc(centerX, centerY, radius, degreesToRadians(0), degreesToRadians((-1) * angle), false);
            context.closePath();
            context.stroke();
            context.strokeStyle = 'green';
            context.lineWidth = 2;
            context.beginPath();
            context.lineWidth = "3";
            context.strokeStyle = "black";
            context.moveTo(centerX - radius, centerY);
            context.lineTo(centerX + radius, centerY);
            context.moveTo(centerX, centerY - radius);
            context.lineTo(centerX, centerY + radius);
            context.stroke();
            context.beginPath();
            context.lineWidth = 3;
            context.strokeStyle = 'White';
            context.arc(centerX, centerY, radius, degreesToRadians(0), degreesToRadians((-1) * angle), false);
            context.stroke();
            context.beginPath();
            context.lineWidth = 2;
            context.strokeStyle = 'green';
            context.arc(centerX, centerY, radius, degreesToRadians(0), degreesToRadians((-1) * angle), true);
            context.stroke();
        }
        function degreesToRadians(degrees) {
            return (degrees * Math.PI) / 180;
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="PrintCon" style="background-image: url(../Images/Common_Images/SecondSightLogoBG.png); background-repeat: no-repeat; background-position: center;">
            <table style="width: 100%;">
                <tr>
                    <td colspan="3">
                        <asp:Image ID="Image1" runat="server" Height="52px" ImageUrl="~/Images/Common_Images/SecondSightLogo.png" Width="122px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3"><strong>Second Sight , Southend Eye Centre Pvt. Ltd</strong></td>
                </tr>
                <tr>
                    <td colspan="3"><strong>CIN : U85194WB2017PTC22014</strong>5</td>
                </tr>
                <tr>
                    <td><strong>Dhopagachi, Baruipur, 24 Parganas (South), Pin-743610</strong></td>
                    <td><strong>Examination ID</strong></td>
                    <td>
                        <asp:Label ID="lbl_Bill_No" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Phone : 033 2423 0541, 96740 82591, 9674701344</strong></td>
                    <td><strong>Date</strong></td>
                    <td>
                        <asp:Label ID="lbl_Date" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 100%;">
                <tr>
                    <td><strong>Pat Code</strong></td>
                    <td colspan="4">
                        <asp:Label ID="lbl_PatCode" runat="server" Text=""></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Patient Name</strong></td>
                    <td>
                        <asp:Label ID="lbl_PatientName" runat="server" Text=""></asp:Label></td>

                    <td><strong>Gender</strong></td>
                    <td>
                        <asp:Label ID="lbl_Gender" runat="server" Text=""></asp:Label>
                    </td>
                    <td><strong>Age</strong></td>
                    <td>
                        <asp:Label ID="lbl_Age" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Examined By</strong></td>
                    <td colspan="4">
                        <asp:Label ID="lbl_Examiner_Name" runat="server" Text=""></asp:Label>
                    </td>

                    <td>&nbsp;</td>
                </tr>
            </table>
            <fieldset>
                <legend>Examiantion&nbsp; 1</legend>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="5"><strong>AR</strong></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>RIGHT EYE</strong></td>
                        <td><strong>SPH</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_SPH_RE"></asp:Label></td>
                        <td><strong>CYL</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_CYL_RE"></asp:Label></td>
                        <td><strong>AXIS</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_AXIS_RE"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>LEFT EYE</strong></td>
                        <td><strong>SPH</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_SPH_LE"></asp:Label></td>
                        <td><strong>CYL</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_CYL_LE"></asp:Label></td>
                        <td><strong>AXIS</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_AXIS_LE"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>NCT</strong></td>
                        <td><strong>OD</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_NCT_OD"></asp:Label></td>
                        <td>&nbsp;</td>
                        <td>OS</td>
                        <td>
                            <asp:Label runat="server" ID="lbl_NCT_OS"></asp:Label></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Examination 2</legend>
                <table style="width: 100%;">
                    <tr>
                        <td><strong>Cheif Complain</strong></td>
                        <td>
                            <asp:Label ID="lbl_CC" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_CC_Duration" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="gv_CheifComplain" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ds_CC_Examiner">
                                <Columns>
                                    <asp:BoundField DataField="Sl NO" HeaderText="Sl NO" ReadOnly="True" SortExpression="Sl NO" />
                                    <asp:BoundField DataField="CompalainName" HeaderText="CompalainName" SortExpression="Compalain Name" />
                                    <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
                                    <asp:BoundField DataField="Eye" HeaderText="Eye" SortExpression="Eye" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="ds_CC_Examiner" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY CheifComplainByExamination.CheifComplainByExaminationId DESC) AS [Sl NO],CheifComplainList.CompalainName, CheifComplainByExamination.Duration, CheifComplainByExamination.Eye FROM CheifComplainByExamination INNER JOIN CheifComplainList ON CheifComplainByExamination.CheifComplainId = CheifComplainList.Id INNER JOIN ConsultantExaminationCombine ON ConsultantExaminationCombine.ConsultantExaminationId2 = CheifComplainByExamination.ExaminationId WHERE ConsultantExaminationCombine.ConsultantExaminationCombineId=@CombineId">
                                <SelectParameters>
                                    <asp:SessionParameter Name="CombineId" SessionField="CombineId" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>               
                    <tr>
                        <td><strong>Systematic Diseases</strong></td>
                        <td>
                            <asp:Label ID="lbl_SD" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_SD_Duration" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Alergy</strong></td>
                        <td>
                            <asp:Label ID="lbl_A" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_A_Duration" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Past History</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_PH" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Family History</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_FH" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Curremt Treatment</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_CT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Current Investigation</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_CI" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="8"><strong>Visual Accuty</strong></td>
                        <td><strong></strong></td>
                        <td><strong></strong></td>
                    </tr>
                    <tr>
                        <td><strong>OD</strong></td>
                        <td><strong>UNAIDE</strong></td>
                        <td>
                            <asp:Label ID="lbl_OD_Unaided" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_OD_Unaided_Remarks" runat="server"></asp:Label></td>
                        <td><strong>AIDED</strong></td>
                        <td>
                            <asp:Label ID="lbl_OD_Aided" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_OD_Aided_Remarks" runat="server"></asp:Label></td>
                        <td><strong>WITH PH</strong></td>
                        <td>
                            <asp:Label ID="lbl_OD_Withph" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_OD_Withph_Remarks" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>OS</strong></td>
                        <td><strong>UNAIDE</strong></td>
                        <td>
                            <asp:Label ID="lbl_OS_Unaided" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_OS_Unaided_Remarks" runat="server"></asp:Label></td>
                        <td><strong>AIDED</strong></td>
                        <td>
                            <asp:Label ID="lbl_OS_Aided" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_OS_Aided_Remarks" runat="server"></asp:Label></td>
                        <td><strong>WITH PH</strong></td>
                        <td>
                            <asp:Label ID="lbl_OS_Withph" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_OS_Withph_Remarks" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </fieldset>

            <fieldset>
                <legend>Examination  3</legend>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="16"><strong>PREVIOUS GLASS POWER</strong></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td rowspan="2" colspan="2"><strong>RIGHT EYE</strong></td>
                        <td colspan="2"><strong>DISTANCE</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_SPH_RE" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_CYL_RE" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_AXIS_RE" runat="server"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label ID="lbl_Distance_VA_RE" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>NEAR</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_SPH_RE" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_CYL_RE" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_AXIS_RE" runat="server"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label ID="lbl_Near_VA_RE" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td rowspan="2" colspan="2"><strong>LEFT EYE</strong></td>
                        <td colspan="2"><strong>DISTANCE</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_Distance_SPH_LE"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_Distance_CYL_LE"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_Distance_AXIS_LE"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_Distance_VA_LE"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>NEAR</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_Near_SPH_LE"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_Near_CYL_LE"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_Near_AXIS_LE"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_Near_VA_LE"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="16"><strong>ACCEPTANCE</strong></td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td rowspan="2" colspan="2"><strong>RIGHT EYE</strong></td>
                        <td colspan="2"><strong>DISTANCE</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_SPH_RE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_CYL_RE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_AXIS_RE_A" runat="server"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label ID="lbl_Distance_VA_RE_A" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>NEAR</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_SPH_RE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_CYL_RE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_AXIS_RE_A" runat="server"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label ID="lbl_Near_VA_RE_A" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td rowspan="2" colspan="2"><strong>LEFT EYE</strong></td>
                        <td colspan="2"><strong>DISTANCE</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_SPH_LE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_CYL_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Distance_AXIS_A" runat="server"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label ID="lbl_Distance_VA_A" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>NEAR</strong></td>
                        <td colspan="2"><strong>SPH</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_SPH_LE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>CYL</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_CYL_LE_A" runat="server"></asp:Label></td>
                        <td colspan="2"><strong>AXIS</strong></td>
                        <td colspan="2">
                            <asp:Label ID="lbl_Near_AXIS_LE_A" runat="server"></asp:Label></td>
                        <td><strong>VA</strong></td>
                        <td>
                            <asp:Label ID="lbl_Near_VA_LE_A" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>OD</strong></td>
                        <td colspan="2"><strong>COLOR VISION</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_CV_OD"></asp:Label></td>
                        <td colspan="2"><strong>PUPIL</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_PUPIL_OD"></asp:Label></td>
                        <td colspan="2"><strong>RAPD</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_RAPD_OD"></asp:Label></td>
                        <td colspan="2"><strong>AMSLER GRID</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_AG_OD"></asp:Label></td>
                        <td><strong>SYRINGING</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_SR_OD"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>OS</strong></td>
                        <td colspan="2"><strong>COLOR VISION</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_CV_OS"></asp:Label></td>
                        <td colspan="2"><strong>PUPIL</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_PUPIL_OS"></asp:Label></td>
                        <td colspan="2"><strong>RAPD</strong></td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="lbl_RAPD_OS"></asp:Label></td>
                        <td colspan="2"><strong>AMSLER GRID</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_AG_OS"></asp:Label></td>
                        <td><strong>SYRINGING</strong></td>
                        <td>
                            <asp:Label runat="server" ID="lbl_SR_OS"></asp:Label></td>
                    </tr>
                </table>
            </fieldset>
            <br />
            <br />
            <br />
            <br />
            <br />

            <fieldset>
                <legend>Examination 3 Continue</legend>
                <table style="width: 100%;">
                    <tr>
                        <td>OD
                            <label id="mycanvasOD_HM_value" ></label>
                            <br />
                            <canvas id="mycanvasOD_HM" width="300" height="300"></canvas>
                        </td>
                        <td>OS
                            <label id="mycanvasOS_HM_value"></label>
                            <br />
                            <canvas id="mycanvasOS_HM" width="300" height="300"></canvas>
                        </td>
                    </tr>
                    <tr>
                        <td>OD
                            <br />
                            <canvas id="mycanvasOD_VM" width="300" height="300"></canvas>
                            <label id="mycanvasOD_VM_value"></label>
                        </td>
                        <td>OS
                            <br />
                            <canvas id="mycanvasOS_VM" width="300" height="300"></canvas>
                            <label id="mycanvasOS_VM_value"></label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="auto-style1">
            <button id="btn_Print">Print</button> 
            <button id="btn_Close">Cancel</button>
        </div>
    </form>

</body>
</html>
