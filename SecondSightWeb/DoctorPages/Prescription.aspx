<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prescription.aspx.cs" Inherits="SecondSightWeb.DoctorPages.Prescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prescription</title>
    <style type="text/css">
        .tabBgColor {
            background-color: black;
            color: wheat;
            text-align:left;
        }

        .auto-style1 {
            text-align: center;
        }

        .auto-style2 {
            height: 23px;
        }

        .auto-style3 {
            height: 23px;
            width: 183px;
        }

        .auto-style4 {
            text-align: left;
        }
    </style>
    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#btn_Close').click(function (e) {
                window.close();
            });
            $('#btn_Print').click(function (e) {
                window.print();
            });
        });

    </script>
</head>
<body style="background-image: url(../Images/Common_Images/SecondSightLogoBG.png); background-repeat: no-repeat; background-position: center;">

    <form id="form1" runat="server">
        <div id="PrintCon">

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
                    <td><strong>CIN : U85194WB2017PTC22014</strong>5</td>
                    <td><strong>Prescription No</strong></td>
                    <td>
                        <asp:Label ID="lbl_Prescription_No" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Dhopagachi, Baruipur, 24 Parganas (South), Pin-743610</strong></td>
                    <td><strong>DOA</strong></td>
                    <td>
                        <asp:Label ID="lbl_DOA" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Phone : 033 2423 0541, 96740 82591, 9674701344</strong></td>
                    <td><strong>DOP</strong></td>
                    <td>
                        <asp:Label ID="lbl_DOP" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <p style="align-content: center" class="auto-style1"><u><strong>Prescription</strong></u></p>

            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3"><strong>Patient ID</strong></td>
                    <td class="auto-style2" colspan="6">
                        <asp:Label ID="lbl_PatCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Name</strong></td>
                    <td class="auto-style2" colspan="6">
                        <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"><strong>Age </strong></td>
                    <td colspan="3">
                        <asp:Label ID="lbl_Age" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                        <strong>Gender&nbsp; </strong>
                        <asp:Label ID="lbl_Gender" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <%--<tr>
                    <td class="auto-style3">Address</td>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lbl_Adderss" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td><strong>Consultant</strong></td>
                    <td colspan="5">
                        <asp:Label ID="lbl_Consultant" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td><strong></strong></td>
                    <td colspan="5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong></strong></td>
                    <td colspan="5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Cheif Complain</strong></td>
                    <td colspan="2">
                        <asp:Label ID="lbl_CheifComplain" runat="server" Visible="false"></asp:Label></td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="lbl_CheifComplain_Eye" runat="server" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="gv_CheifComplain" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ds_CC_Doctor" GridLines="None" HeaderStyle-CssClass="tabBgColor" ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                                <asp:BoundField DataField="CompalainName" HeaderText="CompalainName" SortExpression="CompalainName" />
                                <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
                                <asp:BoundField DataField="Eye" HeaderText="Eye" SortExpression="Eye" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_CC_Doctor" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY CheifComplainByDoctor.CheifComplainByDoctorId) AS [Sl No],CheifComplainList.CompalainName, CheifComplainByDoctor.Duration, CheifComplainByDoctor.Eye FROM CheifComplainByDoctor INNER JOIN Treatement ON CheifComplainByDoctor.TreatmentId = Treatement.TreatmentId INNER JOIN CheifComplainList ON CheifComplainByDoctor.CheifComplainListId = CheifComplainList.Id WHERE (Treatement.TreatmentId = @TreatmentId)">
                            <SelectParameters>
                                <asp:SessionParameter Name="TreatmentId" SessionField="TreatmentId" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td><strong>Provitional Diagnosis</strong></td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Disease" runat="server" Visible="false"></asp:Label></td>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Disease_Eye" runat="server" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="gv_CheifComplain0" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ds_Disease_Doctor" GridLines="None" HeaderStyle-CssClass="tabBgColor" ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                                <asp:BoundField DataField="DiseasesName" HeaderText="DiseasesName" SortExpression="DiseasesName" />
                                <asp:BoundField DataField="Eye" HeaderText="Eye" SortExpression="Eye" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_Disease_Doctor" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY DiseasesByDoctor.DiseasesByDoctorId) AS [Sl No], Diseases.DiseasesName, DiseasesByDoctor.Eye FROM DiseasesByDoctor INNER JOIN Treatement ON DiseasesByDoctor.TreatmentId = Treatement.TreatmentId INNER JOIN Diseases ON DiseasesByDoctor.DiseasesId = Diseases.DiseasesId WHERE DiseasesByDoctor.TreatmentId=@TreatmentId">
                            <SelectParameters>
                                <asp:SessionParameter Name="TreatmentId" SessionField="TreatmentId" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        </td>
                </tr>
                <tr>
                    <td colspan="7"><strong>Investigation</strong></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:CheckBoxList ID="cbl_OtCheckList" runat="server" DataSourceID="ds_OtCheckList" DataTextField="CheckList" DataValueField="Id" OnDataBound="cbl_OtCheckList_DataBound" Enabled="false"></asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td><strong>Medicine List</strong></td>
                    <td colspan="5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">
                        <asp:GridView ID="gv_Procedure_Rate" runat="server" Width="100%" GridLines="None" HeaderStyle-CssClass="tabBgColor" AutoGenerateColumns="False" DataSourceID="ds_Medication" ShowFooter="True" OnRowDataBound="gv_Procedure_Rate_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Serial No" HeaderText="Serial No" ReadOnly="True" SortExpression="Serial No" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="Doss" HeaderText="Doss" SortExpression="Doss" />
                                <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" ReadOnly="True" />
                                <asp:BoundField DataField="Eye" HeaderText="Eye" ReadOnly="True" SortExpression="Eye" />
                            </Columns>

<HeaderStyle CssClass="tabBgColor"></HeaderStyle>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_Medication" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY MedicationId) AS [Serial No], MedicineName AS Name, Doss,'for '+ Duration as Duration, 'in '+Eye as Eye FROM Medication WHERE (TreatmentId = @TreatmentId)">
                            <SelectParameters>
                                <asp:SessionParameter Name="TreatmentId" SessionField="TreatmentId" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="ds_OtCheckList" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [CheckList] FROM [OtCheckList] WHERE ([IsDeleted] = @IsDeleted)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4"><strong>Advice</strong></td>

                    <td class="auto-style4" colspan="6">
                        <asp:Label ID="lbl_Advice" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <td class="auto-style4"><asp:Label ID="lbl_rfr_other_doc" runat="server" Text="Referred to Another Doctor" style="font-weight: 700"></asp:Label></td>

                    <td class="auto-style4" colspan="6">
                        <asp:Label ID="lbl_RfrDocName" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"><asp:Label ID="lbl_test_details" runat="server" Text="Test Details" style="font-weight: 700"></asp:Label></td>

                    <td class="auto-style4" colspan="5">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">
                        <asp:GridView ID="gv_TestDetails" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="ds_TestDetails">
                            <Columns>
                                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                                <asp:BoundField DataField="TestName" HeaderText="Name of The Test" SortExpression="TestName" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_TestDetails" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY SuggestedTests.SuggestedTestId) AS [Sl No], TestMaster.TestName FROM TestMaster INNER JOIN SuggestedTests ON TestMaster.Id = SuggestedTests.TestId WHERE TreatmentId=@TreatmentId">
                            <SelectParameters>
                                <asp:SessionParameter Name="TreatmentId" SessionField="TreatmentId" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="7" style="text-align: right">&nbsp;&nbsp;
                        <asp:Label ID="lbl_Gnrtd_By" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="7" style="text-align: right">Time Stamp :
                        <asp:Label ID="lbl_Time_Stamp" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="7" style="text-align: right">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="7">&nbsp;</td>
                </tr>
            </table>

        </div>
        <div class="auto-style1">
            <button id="btn_Print">Print</button>
            <button id="btn_Close">Close</button>
        </div>
    </form>
</body>
</html>
