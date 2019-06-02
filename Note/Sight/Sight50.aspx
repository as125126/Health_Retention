<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sight50.aspx.cs" Inherits="Note_Sight_Sight50" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        更改學期後請按查詢
        <table>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="width: 47px">
                    <asp:Label ID="labMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlSem" runat="server">
            <asp:ListItem Value="0">學年</asp:ListItem>
            <asp:ListItem Value="1" Selected="True">學期</asp:ListItem>
        </asp:DropDownList>
        度數增加
        <asp:DropDownList ID="ddlLimit" runat="server">
            <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
            <asp:ListItem Value="100">100</asp:ListItem>
            <asp:ListItem Value="150">150</asp:ListItem>
            <asp:ListItem Value="200">200</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢" Width="111px" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="清單列印" Width="125px" />
        <asp:GridView ID="gvSt" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="PID" HeaderText="身分證字號" SortExpression="PID" />
                <asp:BoundField DataField="Guy" HeaderText="姓名" SortExpression="Guy" />
                <asp:BoundField DataField="Grade" HeaderText="年級" SortExpression="Grade" />
                <asp:BoundField DataField="Sem" HeaderText="學期" SortExpression="Sem" />
                <asp:BoundField DataField="Class" HeaderText="班級" SortExpression="Class" />
                <asp:BoundField DataField="Seat" HeaderText="座號" SortExpression="Seat" />
                <asp:BoundField DataField="cSex" HeaderText="性別" SortExpression="cSex" />
                <asp:CheckBoxField DataField="isDilated" HeaderText="散瞳治療"  /> 
                <asp:BoundField DataField="ENearR" HeaderText="近視右" SortExpression="ENearR" />
                <asp:BoundField DataField="ENearL" HeaderText="近視左" SortExpression="ENearL" />
                <asp:BoundField DataField="DiopR" HeaderText="屈光右" SortExpression="DiopR" />
                <asp:BoundField DataField="DiopL" HeaderText="屈光左" SortExpression="DiopL" />
                <asp:CheckBoxField DataField="isDilating" HeaderText="散瞳"  /> 
                <asp:BoundField DataField="GradePre" HeaderText="年級" SortExpression="GradePre" />
                <asp:BoundField DataField="SemPre" HeaderText="學期" SortExpression="Sem" />
                <asp:CheckBoxField DataField="isDilatedPre" HeaderText="散瞳治療"  /> 
                <asp:BoundField DataField="preENearR" HeaderText="近視右" SortExpression="preENearR" />
                <asp:BoundField DataField="preENearL" HeaderText="近視左" SortExpression="preENearL" />
                <asp:BoundField DataField="preDiopR" HeaderText="屈光右" SortExpression="preDiopR" />
                <asp:BoundField DataField="preDiopL" HeaderText="屈光左" SortExpression="preDiopL" />
                <asp:CheckBoxField DataField="isDilatingPre" HeaderText="散瞳"  /> 
                <asp:BoundField DataField="Differ" HeaderText="增加" ReadOnly="True" SortExpression="Differ" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" HorizontalAlign="Right" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:GridView ID="gvExcel" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Visible="false">
            <Columns>
                <asp:BoundField DataField="PID" HeaderText="身分證字號" SortExpression="PID" />
                <asp:BoundField DataField="Guy" HeaderText="姓名" SortExpression="Guy" />
                <asp:BoundField DataField="Grade" HeaderText="年級" SortExpression="Grade" />
                <asp:BoundField DataField="Sem" HeaderText="學期" SortExpression="Sem" />
                <asp:BoundField DataField="Class" HeaderText="班級" SortExpression="Class" />
                <asp:BoundField DataField="Seat" HeaderText="座號" SortExpression="Seat" />
                <asp:BoundField DataField="cSex" HeaderText="性別" SortExpression="cSex" />
                <asp:TemplateField HeaderText="散瞳治療">
                        <ItemTemplate>
                             <asp:Label ID="labDilated" runat="server" Text='<%#  DMHealth.YesNoBool(Eval("isDilated"))  %>' />
                         </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="ENearR" HeaderText="近視右" SortExpression="ENearR" />
                <asp:BoundField DataField="ENearL" HeaderText="近視左" SortExpression="ENearL" />
                <asp:BoundField DataField="DiopR" HeaderText="屈光右" SortExpression="DiopR" />
                <asp:BoundField DataField="DiopL" HeaderText="屈光左" SortExpression="DiopL" />
                <asp:TemplateField HeaderText="散瞳">
                        <ItemTemplate>
                             <asp:Label ID="labDilated" runat="server" Text='<%#  DMHealth.YesNoBool(Eval("isDilating"))  %>' />
                         </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="GradePre" HeaderText="年級" SortExpression="GradePre" />
                <asp:BoundField DataField="SemPre" HeaderText="學期" SortExpression="Sem" />
                <asp:TemplateField HeaderText="散瞳治療">
                        <ItemTemplate>
                             <asp:Label ID="labDilated" runat="server" Text='<%#  DMHealth.YesNoBool(Eval("isDilatedPre"))  %>' />
                         </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="preENearR" HeaderText="近視右" SortExpression="preENearR" />
                <asp:BoundField DataField="preENearL" HeaderText="近視左" SortExpression="preENearL" />
                <asp:BoundField DataField="preDiopR" HeaderText="屈光右" SortExpression="preDiopR" />
                <asp:BoundField DataField="preDiopL" HeaderText="屈光左" SortExpression="preDiopL" />
                <asp:TemplateField HeaderText="散瞳">
                        <ItemTemplate>
                             <asp:Label ID="labDilated" runat="server" Text='<%#  DMHealth.YesNoBool(Eval("isDilatingPre"))  %>' />
                         </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="Differ" HeaderText="增加" ReadOnly="True" SortExpression="Differ" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" HorizontalAlign="Right" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp;
        <br />
        &nbsp;
        &nbsp;
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="Get_Limit2"
            TypeName="HealthShare.dsSightTableAdapters.vSightNear50TableAdapter">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="SchYears" Type="Int16" />
                <asp:Parameter DefaultValue="" Name="SchYearsPre" Type="Int16" />
                <asp:Parameter DefaultValue="" Name="Sem" Type="Int16" />
                <asp:Parameter DefaultValue="" Name="SemPre" Type="Int16" />
                <asp:Parameter DefaultValue="" Name="Limit" Type="Int16" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>