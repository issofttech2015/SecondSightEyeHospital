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
            width: 183px;
        }
    </style>
    <script language="javascript">
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
        <div id="PrintCon">

            <table style="width:100%;">
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
            <p style="align-content:center" class="auto-style1"><u>MONEY RECEIPT</u></p>

            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">Received with thanks from</td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">for</td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_For" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">the sum of rupes</td>
                    <td>
                        <asp:Label ID="lbl_sum_of_rs" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">By Cash/Cheque/Draft No</td>
                    <td class="auto-style2">
                        <asp:Label ID="lbl_type" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">On account of</td>
                    <td>
                        <asp:Label ID="lbl_Account_of" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Rs</td>
                    <td>
                        <asp:Label ID="lbl_Bill_Amount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
        <div class="auto-style1">
            <input name="b_print" type="button" id="b_print" onClick="printdiv('PrintCon');" value=" Print ">
            <asp:Button runat="server" ID="btn_Cancel" Text="Cancel" PostBackUrl="~/ReceptionPages/Generate_Bill.aspx"/>
        </div>
    </form>
</body>
</html>
