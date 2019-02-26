<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Surgery_Advice.aspx.cs" Inherits="SecondSightWeb.CommonPages.Surgery_Advice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Surgery Advice</title>
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
                        <asp:Label ID="lbl_Current_Date" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <p class="auto-style1" style="align-content: center">
                <u><strong>Surgery Advice</strong></u>
            </p>
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
                    <td><strong>Gender</strong></td>
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
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Operation Category</strong></td>
                    <td>
                        <asp:Label ID="lbl_Ot_Category" runat="server"></asp:Label></td>
                    <td><strong>Surgical Procedure</strong></td>
                    <td>
                        <asp:Label ID="lbl_Ot_Procedure" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <table style="width: 100%">
                <tr>
                    <td><strong>Tests to done before obtaiining dates for the surgery</strong></td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="cbl_OtCheckList" runat="server" DataSourceID="ds_OtCheckList" DataTextField="CheckList" DataValueField="Id" OnDataBound="cbl_OtCheckList_DataBound" Enabled="false"></asp:CheckBoxList>
                        <asp:SqlDataSource ID="ds_OtCheckList" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT [Id], [CheckList] FROM [OtCheckList] WHERE ([IsDeleted] = @IsDeleted)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
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
        <div class="auto-style1">
            <button id="btn_Print">Print</button>
            <asp:Button runat="server" ID="btn_Cancel" Text="Close" PostBackUrl="../OtManager/OtConfirmation/GenerateSurgeryAdvice"/>
        </div>
    </form>
</body>
</html>
