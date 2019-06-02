<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StHome.aspx.cs" Inherits="StHome" %>

<%@ Register Src="~/UserControls/ClassSel.ascx" TagName="ClassSel" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/DataRetention.aspx">資料保留區</asp:HyperLink>
        </div>
        <br />
        <div>
            &nbsp;
            <uc1:ClassSel ID="ClassSel1" runat="server" />
            &nbsp;
            <asp:LinkButton ID="lbAdd" runat="server" OnClick="LinkButton1_Click" Visible="False">新增學生</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="gvSt" runat="server" DataSourceID="ods" DataKeyNames="PID"
                AutoGenerateColumns="False" BackColor="White" ForeColor="Black"
                BorderWidth="1px" GridLines="Vertical" CellPadding="4" BorderStyle="None"
                BorderColor="#DEDFDE" RowStyle-BackColor="#ffccff" CssClass="Normal"
                CaptionAlign="Top" OnSelectedIndexChanged="gvSt_SelectedIndexChanged"
                OnRowDeleting="gvSt_RowDeleting" Width="1000px">
                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE"></PagerStyle>
                <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#6B696B"></HeaderStyle>
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Images/edit.gif" Text="修改" />
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif" OnClientClick="return confirm('要將資料移除嗎(移除後可回復)?');" />
                        </ItemTemplate>
                        <EditItemTemplate></EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PID" SortExpression="PID">
                        <ItemTemplate>
                            <%# HealthShareUtil.AboriginePID(Eval("PID"), Eval("Aborigine"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="Guy" HeaderText="Guy">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("Guy") %>' ID="TextBox2"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# WillNs.DM.ColorGuy(Eval( "Guy"), Eval( "SexID"))%>
                        </ItemTemplate>
                        <ItemStyle Width="48px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="學號">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("GuyID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("GuyID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Seat" DataField="Seat" SortExpression="Seat"></asp:BoundField>
                    <asp:BoundField DataField="Birthday" DataFormatString="{0:d}" HeaderText="Birthday" HtmlEncode="False" />
                    <asp:BoundField DataField="Blood" HeaderText="血型" />
                    <asp:BoundField HeaderText="Dad" DataField="Dad" SortExpression="Dad">
                        <ItemStyle Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Mom" DataField="Mom" SortExpression="Mom">
                        <ItemStyle Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Guardian" DataField="guardian" SortExpression="guardian">
                        <ItemStyle Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="家中電話" DataField="Tel1" SortExpression="Tel1"></asp:BoundField>
                    <asp:BoundField HeaderText="Zip" DataField="Zip" SortExpression="Zip"></asp:BoundField>
                    <asp:BoundField HeaderText="Address" DataField="Address" SortExpression="Address"></asp:BoundField>
                    <asp:BoundField DataField="EmergencyCall" HeaderText="緊急聯絡電話" />
                </Columns>
                <SelectedRowStyle ForeColor="White" Font-Bold="True" BackColor="#CE5D5A"></SelectedRowStyle>
                <RowStyle BackColor="#F7F7DE"></RowStyle>
            </asp:GridView>
            <asp:ObjectDataSource ID="ods" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="Get_Class"
                TypeName="HealthShare.dsStTableAdapters.vStTableAdapter"
                UpdateMethod="UpdateNewSeat" DeleteMethod="Delete">
                <DeleteParameters>
                    <asp:Parameter Name="Original_PID" Type="String" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="NewClassID" Type="Int16" />
                    <asp:Parameter Name="NewSeat" Type="Int16" />
                    <asp:Parameter Name="Original_PID" Type="String" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="Years" SessionField="YearsSel" Type="Int16" />
                    <asp:SessionParameter Name="ClassID" SessionField="ClassIDSel" Type="Int16" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
