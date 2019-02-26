<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operation_Final_Bill.aspx.cs" Inherits="SecondSightWeb.CommonPages.Operation_Final_Bill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill</title>
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
            margin-left: 40px;
        }

        .demo {
        }

            .demo table, th, tr {
                border: 1px solid black;
                border-collapse: collapse;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style5">
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
            <p style="align-content: center" class="auto-style1"><u><strong>Bill</strong></u></p>
            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3"><strong>Patient Id</strong></td>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="lbl_PatCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><strong>Name</strong></td>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"><strong>Age </strong></td>
                    <td>
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
                    <td colspan="2">
                        <asp:Label ID="lbl_Consultant" runat="server" Text=""></asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td><strong>Operation Date</strong></td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Operation_Date" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Surgery Procedure</strong></td>
                    <td colspan="2">
                        <asp:Label ID="lbl_Surgery_Procedure" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />

            <strong>
                <asp:GridView ID="gv_Bill" runat="server" AutoGenerateColumns="False" DataSourceID="ds_Operation" Width="100%">

                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Invoice
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%" id="tbl_Bill" class="demo">
                                    <tr>
                                        <td>1</td>
                                        <td>Day Care Charge:</td>
                                        <td>
                                            <asp:Label ID="DayCareChargeLabel" runat="server" Text='<%# Eval("DayCareCharge") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Room Charge:
                                        </td>
                                        <td>
                                            <asp:Label ID="RoomChargeLabel" runat="server" Text='<%# Eval("RoomCharge") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>3
                                        </td>
                                        <td>OtCharges:
                                        </td>
                                        <td>
                                            <asp:Label ID="OtChargesLabel" runat="server" Text='<%# Eval("OtCharges") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>4</td>
                                        <td>Ot Equipment Charges:</td>
                                        <td>
                                            <asp:Label ID="OtEquipmentChargesLabel" runat="server" Text='<%# Eval("OtEquipmentCharges") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>Materials usedin Operation:
                                        </td>
                                        <td>
                                            <asp:Label ID="MaterialsusedinOperationLabel" runat="server" Text='<%# Eval("MaterialsusedinOperation") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>6</td>
                                        <td>Charges for Anaesthesia:</td>
                                        <td>
                                            <asp:Label ID="ChargesforAnaesthesiaLabel" runat="server" Text='<%# Eval("ChargesforAnaesthesia") %>' />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>7</td>
                                        <td>Charges for using Anaesthetic Machine:</td>
                                        <td>
                                            <asp:Label ID="ChargesforusingAnaestheticMachineLabel" runat="server" Text='<%# Eval("ChargesforusingAnaestheticMachine") %>' />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>8</td>
                                        <td>Charges of using Diathermy:</td>
                                        <td>
                                            <asp:Label ID="ChargesofusingDiathermyLabel" runat="server" Text='<%# Eval("ChargesofusingDiathermy") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>9</td>
                                        <td>Endolaser:</td>
                                        <td>
                                            <asp:Label ID="EndolaserLabel" runat="server" Text='<%# Eval("Endolaser") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>10</td>
                                        <td>ChargesforCardiacMonitor:</td>
                                        <td>
                                            <asp:Label ID="ChargesforCardiacMonitorLabel" runat="server" Text='<%# Eval("ChargesforCardiacMonitor") %>' />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>11</td>
                                        <td>Medicines Purchased viscoat:</td>
                                        <td>
                                            <asp:Label ID="MedicinesPurchasedviscoatLabel" runat="server" Text='<%# Eval("MedicinesPurchasedviscoat") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>12</td>
                                        <td>Doctor Fees:</td>
                                        <td>
                                            <asp:Label ID="DoctorFeesLabel" runat="server" Text='<%# Eval("DoctorFees") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>13</td>
                                        <td>Diet Charges:</td>
                                        <td>
                                            <asp:Label ID="DietChargesLabel" runat="server" Text='<%# Eval("DietCharges") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>14</td>
                                        <td>Aya Charges:</td>
                                        <td>
                                            <asp:Label ID="AyaChargesLabel" runat="server" Text='<%# Eval("AyaCharges") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>15</td>
                                        <td>IOL:</td>
                                        <td>
                                            <asp:Label ID="IOLLabel" runat="server" Text='<%# Eval("IOL") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>Total:</td>
                                        <td>
                                            <asp:Label ID="TotalLabel" runat="server" Text='<%# Eval("Total") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </strong>
            <asp:SqlDataSource ID="ds_Operation" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ISNULL(DayCareCharge,0) as DayCareCharge , 
ISNULL(RoomCharge,0) as RoomCharge, 
ISNULL(OtCharges,0) as OtCharges, 
ISNULL(OtEquipmentCharges,0) as OtEquipmentCharges, 
ISNULL(MaterialsusedinOperation,0) as MaterialsusedinOperation, 
ISNULL(ChargesforAnaesthesia,0) as ChargesforAnaesthesia, 
ISNULL(ChargesforusingAnaestheticMachine,0) as ChargesforusingAnaestheticMachine, 
ISNULL(ChargesofusingDiathermy,0) as ChargesofusingDiathermy, 
ISNULL(Endolaser,0) as Endolaser,
ISNULL(ChargesforCardiacMonitor,0) as ChargesforCardiacMonitor,
ISNULL(MedicinesPurchasedviscoat,0) as MedicinesPurchasedviscoat, 
ISNULL(DoctorFees,0) as DoctorFees, 
ISNULL(DietCharges,0) as DietCharges,
ISNULL(AyaCharges,0) as AyaCharges, 
ISNULL(IOL,0) as IOL,
Sum(
 ISNULL(O.DayCareCharge,0)
 +ISNULL(O.RoomCharge,0)
 +ISNULL(O.OtCharges,0)
 +ISNULL(O.OtEquipmentCharges,0)
 +ISNULL(O.MaterialsusedinOperation,0)
 +ISNULL(O.ChargesforAnaesthesia,0)
 +ISNULL(O.ChargesforusingAnaestheticMachine,0)
 +ISNULL(O.ChargesofusingDiathermy,0)
 +ISNULL(O.Endolaser,0)
 +ISNULL(O.ChargesforCardiacMonitor,0)
 +ISNULL(O.MedicinesPurchasedviscoat,0)
 +ISNULL(O.DoctorFees,0)
 +ISNULL(O.DietCharges,0)
 +ISNULL(O.IOL,0) 
) over() AS Total  
FROM OTCharges O 
WHERE OtChargeId = @OtChargeId">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="" Name="OtChargeId" SessionField="OperationId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
        <table style="width:100%">
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
    </form>
</body>
</html>

