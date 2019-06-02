<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassSel.ascx.cs" Inherits="ClassSel_ascx" %>

&nbsp;
<asp:DropDownList ID="ddlGradeClass" runat="server" AutoPostBack="True" DataTextField="YearsGradeClass" DataValueField="YearsClass" 
    DataSourceID="ods" OnSelectedIndexChanged="ddlGradeClass_SelectedIndexChanged" OnDataBound="ddlGradeClass_DataBound">
</asp:DropDownList>
&nbsp;
<asp:DropDownList ID="ddlGradeClassGrad" runat="server" AutoPostBack="True" DataTextField="YearsGradeClass" DataValueField="YearsClass" 
    Visible="false" OnSelectedIndexChanged="ddlGradeClassGrad_SelectedIndexChanged">
</asp:DropDownList>
&nbsp;
<asp:RequiredFieldValidator ID="validSel" runat="server" ControlToValidate="ddlGradeClass"
    ErrorMessage="請選擇一個班級" InitialValue="0,0" Display="Dynamic" Enabled="False">
</asp:RequiredFieldValidator>
<asp:ObjectDataSource ID="ods" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="HealthShare.dsSchoolTableAdapters.ClassSelTableAdapter">
</asp:ObjectDataSource>
&nbsp;