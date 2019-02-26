<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pre_Operative_Advice.aspx.cs" Inherits="SecondSightWeb.CommonPages.Pre_Operative_Advice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pre Operative Advice</title>
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
            height: 23px;
            width: 266px;
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
            <p style="align-content: center" class="auto-style1"><u><strong>Pre Operative Advice</strong></u></p>
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

            <table style="width: 100%;">
                <tr>
                    <td class="auto-style5"><strong>Your surgey is scheduled on</strong></td>
                    <td class="auto-style2" colspan="7">
                        <asp:Label ID="lbl_SurgeryScheduled" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>You are requested to report at reception by</strong></td>
                    <td class="auto-style2" colspan="7">
                        <asp:Label ID="lbl_SurgeryScheduled_Time" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>Your surgical planned procedure is</strong></td>
                    <td class="auto-style2" colspan="7">
                        <asp:Label ID="lbl_SurgeryScheduled_Procedure" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>expected duration for hospital stay is </strong></td>
                    <td class="auto-style2" colspan="7">
                        <asp:Label ID="lbl_Duration" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>The estimated expense for your surgery is</strong></td>
                    <td class="auto-style2" colspan="7">
                        <asp:Label ID="lbl_Expense" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"><strong>Please use</strong></td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_Drop" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <strong>eye drop four times day in</strong></td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_Eye" runat="server"></asp:Label></td>
                    <td class="auto-style2">
                        <strong>from</strong></td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_from_date" runat="server"></asp:Label></td>
                    <td class="auto-style2">
                        <strong>to</strong></td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_to_date" runat="server"></asp:Label></td>
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
