<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrderRecipt.aspx.cs" Inherits="SecondSightWeb.CommonPages.PurchaseOrderRecipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Purchase Order</title>
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
                    <td><strong>Purchase Order No</strong></td>
                    <td>
                        <asp:Label ID="lbl_Purchase_Order_No" runat="server"></asp:Label>
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
            <p style="align-content: center" class="auto-style1"><u>PURCHASE ORDER</u></p>

            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3">TO,</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lbl_VendorName" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <%--<tr>
                    <td class="auto-style3" colspan="2">Received with thanks from</td>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">the sum of rupes</td>
                    <td colspan="2">
                        <asp:Label ID="lbl_sum_of_rs" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">By Cash/Cheque/Draft No</td>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lbl_type" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Rs</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                        <asp:Label ID="lbl_Bill_Amount" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_Concession_Amount_Title" runat="server" Text="Concession Amount" Visible="false"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lbl_Concession_Amount" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Paid Amount</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                        <asp:Label ID="lbl_PaidAmount" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl_DueAmount_Title" runat="server" Text="Due Amount" Visible="false"></asp:Label>
                        &nbsp;
                        <asp:Label ID="lbl_DueAmount" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td class="auto-style4" colspan="4">
                        <asp:GridView ID="gv_Purchase_Order_Details" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ds_Purchase_Order_Details" ShowFooter="True" OnRowDataBound="gv_Purchase_Order_Details_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="Item" HeaderText="Item" SortExpression="Item" />
                                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                <asp:BoundField DataField="Required Qty" HeaderText="Required Qty" SortExpression="Required Qty" />
                                <asp:BoundField DataField="Unit Rate" HeaderText="Unit Rate" ReadOnly="True" SortExpression="Unit Rate" FooterText="Total :" />
                                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="ds_Purchase_Order_Details" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER ( ORDER BY POD.PODId) AS [Sl No], CM.CategoryName AS [Name],C.ItemName AS [Item],C.ItemDescription AS [Description],POD.Qty AS [Required Qty],(POD.Price/POD.Qty) AS [Unit Rate],POD.Price FROM PurchaseOrder AS PO INNER JOIN PurchaseOrderDetails AS POD ON PO.POID = POD.POID INNER JOIN tblCategoryMaster AS C ON POD.CategoryID = C.CategoryID INNER JOIN CategoryMaster AS CM ON C.CategoryMasterId = CM.CategoryMasterId WHERE PO.POID = @POID">
                            <SelectParameters>
                                <asp:SessionParameter Name="POID" SessionField="PO_Id" />
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

