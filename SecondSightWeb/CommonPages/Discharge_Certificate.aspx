<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Discharge_Certificate.aspx.cs" Inherits="SecondSightWeb.CommonPages.Discharge_Certificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Discharge Certificate</title>
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
    <style>
        .tabBgColor {
            background-color: black;
            color: wheat;
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

        .auto-style5 {
            text-align: center;
            font-size: medium;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Dhopagachi, Baruipur, 24 Parganas (South), Pin-743610</strong></td>
                    <td><strong>OPERATION ID</strong></td>
                    <td>
                        <asp:Label ID="lbl_OP_Id" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Phone : 033 2423 0541, 96740 82591, 9674701344</strong></td>
                    <td><strong>Date</strong></td>
                    <td>
                        <asp:Label runat="server" ID="lbl_Current_Date"></asp:Label></td>
                </tr>
            </table>
            <p style="align-content: center" class="auto-style5"><u><strong>Discharge Certificate for Day Care</strong></u></p>
            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3"><strong>Patient Id</strong></td>
                    <td class="auto-style2" colspan="4">
                        <asp:Label ID="lbl_PatCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Name</strong></td>
                    <td class="auto-style2" colspan="4">
                        <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"><strong>Age </strong></td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Age" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <strong>Gender</strong></td>
                    <td>
                        <asp:Label ID="lbl_Gender" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td class="auto-style3">Address</td>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lbl_Adderss" runat="server" Text=""></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td><strong>Doctors Name</strong></td>
                    <td colspan="3">
                        <asp:Label ID="lbl_Consultant" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
            </table>

            <br />
            <br />
            <table style="width:100%">
                <tr>
                    <td>

                        <strong>Date of Admission</strong></td>
                    <td>

                        <asp:Label ID="lbl_Date_Admission" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Date of Operation</strong></td>
                    <td>
                        <asp:Label ID="lbl_Date_Operation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Date of Discharge</strong></td>
                    <td>
                        <asp:Label ID="lbl_Date_Discharge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Diagonisis</strong></td>
                    <td>
                        <asp:Label ID="lbl_Diagonosis" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Name of the Surgery</strong></td>
                    <td>
                        <asp:Label ID="lbl_Surgery_Name" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Eye</strong></td>
                    <td>
                        <asp:Label ID="lbl_Eye" runat="server" style="font-weight: 700"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        <strong>Batch Number</strong></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Enabled="false" Height="33px" Width="290px"></asp:TextBox>
                       </td>
                </tr>
            </table>

            <br />
            <br />
            <table style="width:100%">
                <tr>
                    <td colspan="5"><strong>Instructions</strong></td>
                </tr>
                <tr>
                    <td>1</td>
                    <td colspan="4">Please do not remove the patch from your eye.</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>Please report to the Eye OPD at </td>
                    <td>
                        <asp:Label ID="lbl_Report_Time" runat="server"></asp:Label>
                    </td>
                    <td>on</td>
                    <td>
                        <asp:Label ID="lbl_Report_Date" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>3</td>
                    <td colspan="4">Tab Combiflam-1 to be taken after the food if there is pain.</td>
                </tr>
                <tr>
                    <td>4</td>
                    <td colspan="4">Tab Digene-1 along with combiflam.</td>
                </tr>
                <tr>
                    <td>5</td>
                    <td colspan="4">Additional Medicines</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gv_Discharge_Medicine" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ds_Discharge">
                            <Columns>
                                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                                <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" SortExpression="MedicineName" />
                                <asp:BoundField DataField="Doss" HeaderText="Doss" SortExpression="Doss" />
                                <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_Discharge" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY Medication.MedicationId DESC) AS[Sl No], Medication.MedicineName, Medication.Doss, Medication.Duration FROM OperarionDetails INNER JOIN Medication ON OperarionDetails.OperationId = Medication.OperationId WHERE Medication.OperationId=@OperationId">
                            <SelectParameters>
                                <asp:SessionParameter Name="OperationId" SessionField="Operation_Id" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>6</td>
                    <td colspan="2">Special Instruction</td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Addnl_Comments" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>7&nbsp;</td>
                    <td colspan="2">In case of emergency please contact </td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Emergency_Contact_Number" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="6">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="6">&nbsp;</td>

                </tr>
                <tr>
                    <td class="auto-style4" colspan="6" style="text-align: right">&nbsp;Generated By :&nbsp; <asp:Label ID="lbl_Gnrtd_By" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="6" style="text-align: right">Time Stamp : <asp:Label ID="lbl_Time_Stamp" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="6" style="text-align: right">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="6">&nbsp;</td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div class="auto-style1">
            <button id="btn_Print">Print</button>
            <asp:Button runat="server" ID="btn_Cancel" Text="Close" PostBackUrl="../OtManager/OtConfirmation/GeneratePreOperativeAdvice"/>
        </div>
    </form>
</body>
</html>

