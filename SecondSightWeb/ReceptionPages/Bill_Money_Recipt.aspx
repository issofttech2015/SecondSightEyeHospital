<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bill_Money_Recipt.aspx.cs" Inherits="SecondSightWeb.ReceptionPages.Bill_Money_Recipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill</title>
    <style type="text/css">
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
            width: 184px;
        }
    </style>
    <script>
        function printdiv(printpage) {
            var headstr = "<html><head></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
        function CloseWindow() {
            window.close();
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
                    <td><strong>Bill No</strong></td>
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
            <p style="align-content: center" class="auto-style1"><u>MONEY RECEIPT</u></p>

            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3" colspan="2">Patient Id</td>
                    <td class="auto-style2" colspan="4">
                        <asp:Label ID="lbl_PatCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">Received with thanks from</td>
                    <td class="auto-style2" colspan="4">
                        <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">the sum of rupes</td>
                    <td colspan="4">
                        <asp:Label ID="lbl_sum_of_rs" runat="server" Text="" style="font-weight: 700"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">By Cash/Cheque/Draft No</td>
                    <td class="auto-style2" colspan="4">
                        <asp:Label ID="lbl_type" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Rs</b></td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                        <b>
                        <asp:Label ID="lbl_Bill_Amount" runat="server" Text=""></asp:Label>
                        </b>
                    </td>
                    <td>
                        <asp:Label ID="lbl_Concession_Amount_Title" runat="server" Text="Concession Amount" Visible="false" style="font-weight: 700"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lbl_Concession_Amount" runat="server" Visible="false" style="font-weight: 700"></asp:Label>
                    </td>
                    <td><strong>Total Amount</strong></td>
                    <td>
                        <asp:Label ID="lbl_Total_Amount" runat="server" Visible="true" style="font-weight: 700"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Paid Amount</strong></td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                        <asp:Label ID="lbl_PaidAmount" runat="server" Text="" style="font-weight: 700"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_DueAmount_Title" runat="server" Text="Due Amount" Visible="false" style="font-weight: 700"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lbl_DueAmount" runat="server" Visible="false" style="font-weight: 700"></asp:Label>
                    </td>
                    <td>
                        <strong>
                        <asp:Label ID="lbl_RefundAmount_Title" runat="server" Text="Refund Amount" Visible="false" style="font-weight: 700"></asp:Label>
                        </strong></td>
                    <td>
                        <asp:Label ID="lbl_Refund_Amount" runat="server" Visible="true" style="font-weight: 700"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="6">
                        <asp:GridView ID="gv_Procedure_Rate" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ds_ProcedureReate" ShowFooter="True" OnRowDataBound="gv_Procedure_Rate_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" FooterText="Total :" />
                                <asp:BoundField DataField="Column1" HeaderText="Rate" SortExpression="Column1" ReadOnly="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_ProcedureReate" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER ( ORDER BY BillDetailsId) AS [Sl No],ProcedureRate.ProcedureName AS [Type], CAST(BillDetails.Rate as Decimal(18,2)) FROM BillDetails INNER JOIN ProcedureRate ON BillDetails.ProcedureRateId = ProcedureRate.Id
where BillDetails.BillId=@BillId">
                            <SelectParameters>
                                <asp:SessionParameter Name="BillId" SessionField="Bill_Id" />
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
            <input name="b_print" type="button" id="b_print" onclick="printdiv('PrintCon');" value=" Print " />
            <asp:Button runat="server" ID="btn_Cancel" Text="Cancel" OnClick="btn_Cancel_Click" />
        </div>
    </form>
</body>
</html>
