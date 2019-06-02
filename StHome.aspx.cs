using System;
using System.Web.UI.WebControls;

public partial class StHome : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Se.eSchoolRank = enSchoolRank.Primary;//自己設定
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Se.siYearsSel = 0;//初始選單設定
            //ClassSel1.updateStatus();//初始選單設定
            DMHealth.ColumnSet(gvSt.Columns);
        }
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        string YearGradeClass = "";
        if (ClassSel1.sYearsGradeClass != null)
            YearGradeClass = ClassSel1.sYearsGradeClass;
        //V910R01 畢業班級不顯示 新增學生 功能
        if (Se.siYearsSel == 0 || YearGradeClass.Contains("級"))
            lbAdd.Visible = false;
        else
            lbAdd.Visible = true;
    }

    public void HideDetail()
    {
        gvSt.Visible = false;
        lbAdd.Visible = false;
    }
    public void ShowDetail()
    {
        // gvSt.DataSourceID = null;
        gvSt.Visible = true;
        lbAdd.Visible = true;
    }
    protected void AddSt()
    {
        string sUrl = "~/EditStHome.aspx?PID=" + gvSt.SelectedValue.ToString() + "&Mode=Add";
        Response.Redirect(sUrl);
    }

    #region 新增學生
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        /*
        string sUrl = "~/PIDVerify.aspx";
        Response.Redirect(sUrl);
        */
    }
    #endregion

    #region 選取
    protected void gvSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
        string sUrl = "~/EditStHome.aspx?PID=" + gvSt.SelectedValue.ToString() + "&Mode=Edit&ReturnPage=~/StHome.aspx";
        string sPID = gvSt.SelectedValue.ToString();
        //Se.sPIDSel = gvSt.SelectedValue.ToString();
        DMHealth.SetSeSt(sPID);
        Response.Redirect(sUrl);
        */
    }
    #endregion

    #region 刪除
    protected void gvSt_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sPID = e.Keys["PID"].ToString();
        DMHealth.RemoveToStDataRetention(sPID);
        e.Cancel = true;
        gvSt.DataBind();
        e.Cancel = true;
    }
    #endregion
}