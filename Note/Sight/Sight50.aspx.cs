using System;
using System.Web;
using System.Web.UI;

public partial class Note_Sight_Sight50 : System.Web.UI.Page
{
    #region 清單列印
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + HttpUtility.UrlEncode(gvExcel.Caption.Replace(" ", string.Empty), System.Text.Encoding.UTF8) + ".xls\"");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvExcel.Visible = true;
        this.gvExcel.RenderControl(htmlWrite);
        string sSign = "<br>承辦人:　　　　組長:　　　　　主任:　　　　　　　校長:　　　　　　　　";
        Response.Write(stringWrite.ToString() + sSign);
        Response.End();
        gvExcel.Visible = false;
    }
    #endregion

    #region 查詢
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string sLimit = ddlLimit.SelectedValue;//度數增加
        int iSemSchYear = ddlSem.SelectedIndex;//選擇項目（學期 OR 學年）

        int siSchYearsNow = 107;//現在學年
        int siSemNow = 2;//現在學期

        //上學年同學期
        string sSem = "學年";
        int iSchYearsPre = siSchYearsNow - 1;
        int iSemPre = siSemNow;

        //上學期
        if (iSemSchYear == 1)
        {
            sSem = "學期";
            iSchYearsPre = siSchYearsNow;
            iSemPre = siSemNow - 1;

            //第二學期處理
            if (iSemPre == 0)
            {
                iSemPre = 2;
                iSchYearsPre = siSchYearsNow - 1;
            }
        }

        //標題
        string sTitleT = "{0}{1}學年第{2}學期 {4}度數增加超過{3}度名單";
        string sTitle = string.Format
            (
                sTitleT, 
                "南華國小",
                siSchYearsNow,
                siSemNow, 
                sLimit, 
                sSem
            );
        gvSt.Caption = sTitle;
        gvExcel.Caption = sTitle;

        //參數
        ObjectDataSource1.SelectParameters["SchYearsPre"].DefaultValue = iSchYearsPre.ToString();
        ObjectDataSource1.SelectParameters["SemPre"].DefaultValue = iSemPre.ToString();
        ObjectDataSource1.SelectParameters["SchYears"].DefaultValue = siSchYearsNow.ToString();
        ObjectDataSource1.SelectParameters["Sem"].DefaultValue = siSemNow.ToString();
        ObjectDataSource1.SelectParameters["Limit"].DefaultValue = ddlLimit.SelectedValue.ToString();

        //重新綁定
        gvSt.DataSource = ObjectDataSource1;
        gvSt.DataBind();
        gvExcel.DataSource = ObjectDataSource1;
        gvExcel.DataBind();
    }
    #endregion

    public override void VerifyRenderingInServerForm(Control control)
    {
        //'XX'型別 必須置於有 runat=server 的表單標記之中
    }
}