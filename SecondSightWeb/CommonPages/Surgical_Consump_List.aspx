<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Surgical_Consump_List.aspx.cs" Inherits="SecondSightWeb.CommonPages.Surgical_Consump_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Surgery Consumption List</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
            <u><strong>Operation Consumption List</strong></u>
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
        <fieldset>
            <legend>Injectables</legend>
            <asp:GridView ID="gv_Injectables" Width="100%" AutoGenerateColumns="False" runat="server" DataSourceID="ds_Injectables">
                <Columns>
                    <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                    <asp:BoundField DataField="InjectableName" HeaderText="InjectableName" SortExpression="InjectableName" />
                    <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                </Columns>
            </asp:GridView>

        </fieldset>
        <fieldset>
            <legend>Disposables</legend>
            <asp:GridView ID="gv_Disposables" Width="100%" AutoGenerateColumns="False" runat="server" DataSourceID="ds_Disposables">
                <Columns>
                    <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                    <asp:BoundField DataField="DisposableName" HeaderText="DisposableName" SortExpression="DisposableName" />
                    <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                </Columns>
            </asp:GridView>

        </fieldset>
        <fieldset>
            <legend>Knives</legend>
            <asp:GridView ID="gv_Knives" Width="100%" AutoGenerateColumns="False" runat="server" DataSourceID="ds_Knives">
                <Columns>
                    <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                    <asp:BoundField DataField="KniveName" HeaderText="KniveName" SortExpression="KniveName" />
                    <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                </Columns>
            </asp:GridView>

        </fieldset>
        <fieldset>
            <legend>Miscellaneous</legend>
            <asp:GridView ID="gv_Miscellaneous" Width="100%" AutoGenerateColumns="False" runat="server" DataSourceID="ds_Miscellaneous">
                <Columns>
                    <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                    <asp:BoundField DataField="MiscellaneousName" HeaderText="MiscellaneousName" SortExpression="MiscellaneousName" />
                    <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                </Columns>
            </asp:GridView>

        </fieldset>
        <fieldset>
            <legend>Tablets</legend>
            <asp:GridView ID="gv_Tablets" Width="100%" AutoGenerateColumns="False" runat="server" DataSourceID="ds_Tablets">
                <Columns>
                    <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                    <asp:BoundField DataField="TabletName" HeaderText="TabletName" SortExpression="TabletName" />
                    <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                </Columns>
            </asp:GridView>

        </fieldset>
        <fieldset>
            <legend>Drops</legend>
            <asp:GridView ID="gv_Drops" Width="100%" AutoGenerateColumns="False" runat="server" DataSourceID="ds_Drops">
                <Columns>
                    <asp:BoundField DataField="Sl No" HeaderText="Sl No" ReadOnly="True" SortExpression="Sl No" />
                    <asp:BoundField DataField="DropsName" HeaderText="DropsName" SortExpression="DropsName" />
                    <asp:BoundField DataField="BatchNumber" HeaderText="BatchNumber" SortExpression="BatchNumber" />
                </Columns>
            </asp:GridView>

        </fieldset>



        <asp:SqlDataSource ID="ds_Injectables" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY SurgicalInjectableConsumptionList.SurgicalInjectableId) AS [Sl No], Injectables.InjectableName, SurgicalInjectableConsumptionList.BatchNumber FROM Injectables INNER JOIN SurgicalInjectableConsumptionList ON Injectables.InjectableId = SurgicalInjectableConsumptionList.InjectableId WHERE SurgicalInjectableConsumptionList.OperationId=@OperationId">
            <SelectParameters>
                <asp:SessionParameter Name="OperationId" SessionField="OperationId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_Disposables" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY SurgicalDisposablesConsumptionList.SurgicalDisposableId) AS [Sl No], Disposables.DisposableName, SurgicalDisposablesConsumptionList.BatchNumber FROM Disposables INNER JOIN SurgicalDisposablesConsumptionList ON Disposables.DisposableId = SurgicalDisposablesConsumptionList.DisposableId WHERE SurgicalDisposablesConsumptionList.OperationId=@OperationId">
            <SelectParameters>
                <asp:SessionParameter Name="OperationId" SessionField="OperationId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_Knives" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY SurgicalKnivesConsumptionList.SurgicalKniveId) AS [Sl No], Knives.KniveName, SurgicalKnivesConsumptionList.BatchNumber FROM Knives INNER JOIN SurgicalKnivesConsumptionList ON Knives.KniveId = SurgicalKnivesConsumptionList.KniveId WHERE SurgicalKnivesConsumptionList.OperationId = @OperationId">
            <SelectParameters>
                <asp:SessionParameter Name="OperationId" SessionField="OperationId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_Miscellaneous" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY SurgicalMiscellaneousConsumptionList.SurgicalMiscellaneousId) AS [Sl No], Miscellaneous.MiscellaneousName, SurgicalMiscellaneousConsumptionList.BatchNumber FROM Miscellaneous INNER JOIN SurgicalMiscellaneousConsumptionList ON Miscellaneous.MiscellaneousId = SurgicalMiscellaneousConsumptionList.MiscellaneousId WHERE SurgicalMiscellaneousConsumptionList.OperationId=@OperationId">
            <SelectParameters>
                <asp:SessionParameter Name="OperationId" SessionField="OperationId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_Tablets" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER(ORDER BY SurgicalTabletsConsumptionList.SurgicalTabletId) AS [Sl No], Tablets.TabletName, SurgicalTabletsConsumptionList.BatchNumber FROM Tablets INNER JOIN SurgicalTabletsConsumptionList ON Tablets.TabletId = SurgicalTabletsConsumptionList.TabletId WHERE (SurgicalTabletsConsumptionList.OperationId = @OperationId)">
            <SelectParameters>
                <asp:SessionParameter Name="OperationId" SessionField="OperationId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="ds_Drops" runat="server" ConnectionString="<%$ ConnectionStrings:SecondSightDbContext %>" SelectCommand="SELECT ROW_NUMBER() OVER (ORDER BY SurgicalDropsConsumptionList.SurgicalDropId) AS [Sl No],ExaminationDrops.DropsName, SurgicalDropsConsumptionList.BatchNumber FROM ExaminationDrops INNER JOIN SurgicalDropsConsumptionList ON SurgicalDropsConsumptionList.DropId = ExaminationDrops.Id WHERE (SurgicalDropsConsumptionList.OperationId = @OperationId)">
            <SelectParameters>
                <asp:SessionParameter Name="OperationId" SessionField="OperationId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <table style="width: 100%">
            <tr>
                <td class="auto-style4" colspan="6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="6" style="text-align: right">&nbsp;Generated By :&nbsp;
                    <asp:Label ID="lbl_Gnrtd_By" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="6" style="text-align: right">Time Stamp :
                    <asp:Label ID="lbl_Time_Stamp" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="6" style="text-align: right">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="6">&nbsp;</td>
            </tr>
        </table>
        <div class="auto-style1">
            <button id="btn_Print">Print</button>
            <asp:Button runat="server" ID="btn_Cancel" Text="Close" PostBackUrl="../OtManager/SurgicalConsumption"/>
        </div>
    </form>
</body>
</html>
