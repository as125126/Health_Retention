<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GradeSel.ascx.cs" Inherits="UserControls_GradeSel" %>

&nbsp;<asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True"
    DataTextField="YearsGrade" DataValueField="Years" DataSourceID="ods" OnSelectedIndexChanged="ddlGradeClass_SelectedIndexChanged" OnDataBound="ddlGrade_DataBound">
</asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGrade"
    ErrorMessage="請選擇一個年級" InitialValue="0,0" Display="Dynamic"></asp:RequiredFieldValidator>
&nbsp;<asp:DropDownList ID="ddlGradeGrad" runat="server" AutoPostBack="True" Visible="false"
    DataTextField="YearsGrade" DataValueField="Years" OnSelectedIndexChanged="ddlGradeGrad_SelectedIndexChanged" OnDataBound="ddlGradeGrad_DataBound">
</asp:DropDownList>&nbsp;
<br />
<asp:ObjectDataSource ID="ods" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="Get_InSchool" TypeName="HealthShare.dsSchoolTableAdapters.GradeTableAdapter"
    UpdateMethod="Update">
    <DeleteParameters>
        <asp:Parameter Name="Original_GradeID" Type="Int16" />
        <asp:Parameter Name="Original_Years" Type="Int16" />
        <asp:Parameter Name="Original_Grade" Type="String" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="GradeID" Type="Int16" />
        <asp:Parameter Name="Years" Type="Int16" />
        <asp:Parameter Name="Grade" Type="String" />
        <asp:Parameter Name="Original_GradeID" Type="Int16" />
        <asp:Parameter Name="Original_Years" Type="Int16" />
        <asp:Parameter Name="Original_Grade" Type="String" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="GradeID" Type="Int16" />
        <asp:Parameter Name="Years" Type="Int16" />
        <asp:Parameter Name="Grade" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource>
&nbsp;&nbsp;
