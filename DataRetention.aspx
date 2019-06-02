<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataRetention.aspx.cs" Inherits="DataRetention" %>

<%@ Register Src="UserControls/GradeSel.ascx" TagName="GradeSel" TagPrefix="uc2" %>

<!DOCTYPE html>

<style type="text/css">
    .btn {
        color: white;
        background: #458989;
        border: none;
        padding: 5px;
        margin: 5px 0;
    }

        .btn:hover {
            color: white;
            background: #20aaaa;
        }

    .txt {
        height: 20px;
        width: 130px;
        padding-left: 5px;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StHome.aspx">學生基本資料</asp:HyperLink>
        </div>
        <br />
        <div>
            <asp:TextBox ID="txtSearch" runat="server" placeholder="身分證、學號、姓名" class="txt"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜尋" class="btn" />
            <asp:Label ID="labMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <uc2:GradeSel ID="GradeSel1" runat="server" />
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            <asp:GridView ID="gvSt" runat="server" DataSourceID="ods" DataKeyNames="PID"
                AutoGenerateColumns="False" BackColor="White" ForeColor="Black"
                BorderWidth="1px" GridLines="Vertical" CellPadding="4" BorderStyle="None"
                BorderColor="#DEDFDE" RowStyle-BackColor="#ffccff" CssClass="Normal"
                CaptionAlign="Top" Width="1000px"
                OnSelectedIndexChanged="gvSt_SelectedIndexChanged">
                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE"></PagerStyle>
                <HeaderStyle ForeColor="White" Font-Bold="True" BackColor="#6B696B"></HeaderStyle>
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRecover" runat="server" CommandName="Select" ImageUrl="~/Images/recover.png"
                                OnClientClick="return confirm('您確定要回復嗎?');" />
                        </ItemTemplate>
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
                OldValuesParameterFormatString="original_{0}" SelectMethod="Get_Years"
                TypeName="HealthShare.dsStTableAdapters.vDataRetentionTableAdapter"
                DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_PID" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PID" Type="String" />
                    <asp:Parameter Name="Guy" Type="String" />
                    <asp:Parameter Name="GuyID" Type="String" />
                    <asp:Parameter Name="SexID" Type="Int16" />
                    <asp:Parameter Name="Years" Type="Int16" />
                    <asp:Parameter Name="ClassID" Type="Int16" />
                    <asp:Parameter Name="Seat" Type="Int16" />
                    <asp:Parameter Name="Birthday" Type="DateTime" />
                    <asp:Parameter Name="Dad" Type="String" />
                    <asp:Parameter Name="Mom" Type="String" />
                    <asp:Parameter Name="Guardian" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="Tel1" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="EmergencyCall" Type="String" />
                    <asp:Parameter Name="NewClassID" Type="Int16" />
                    <asp:Parameter Name="NewSeat" Type="Int16" />
                    <asp:Parameter Name="Blood" Type="String" />
                    <asp:Parameter Name="Aborigine" Type="Int16" />
                    <asp:Parameter Name="StMemos" Type="String" />
                    <asp:Parameter Name="InSch" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="Years" SessionField="YearsSel" Type="Int16" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Guy" Type="String" />
                    <asp:Parameter Name="GuyID" Type="String" />
                    <asp:Parameter Name="SexID" Type="Int16" />
                    <asp:Parameter Name="Years" Type="Int16" />
                    <asp:Parameter Name="ClassID" Type="Int16" />
                    <asp:Parameter Name="Seat" Type="Int16" />
                    <asp:Parameter Name="Birthday" Type="DateTime" />
                    <asp:Parameter Name="Dad" Type="String" />
                    <asp:Parameter Name="Mom" Type="String" />
                    <asp:Parameter Name="Guardian" Type="String" />
                    <asp:Parameter Name="Zip" Type="String" />
                    <asp:Parameter Name="Tel1" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="EmergencyCall" Type="String" />
                    <asp:Parameter Name="NewClassID" Type="Int16" />
                    <asp:Parameter Name="NewSeat" Type="Int16" />
                    <asp:Parameter Name="Blood" Type="String" />
                    <asp:Parameter Name="Aborigine" Type="Int16" />
                    <asp:Parameter Name="StMemos" Type="String" />
                    <asp:Parameter Name="InSch" Type="String" />
                    <asp:Parameter Name="Original_PID" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
