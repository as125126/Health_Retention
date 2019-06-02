using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class UserControls_GradeSel : System.Web.UI.UserControl
{
    public delegate void _AfterGradeChange(object sender, EventArgs e);
    public event _AfterGradeChange AfterGradeChange;
    private string s0 = "請選擇";
    private bool isShowGrad = true;

    #region for 原住民身分設定(AborigineSet.aspx)
    public bool isAll
    {
        set
        {
            if (value == true)
                s0 = "全部";
            //else
            //    s0 = "請選擇";
        }
    }
    public bool isInSchool
    {
        set
        {
            if (value == true)
            {
                //ods.SelectMethod = "Get_InSchool";
                isShowGrad = false;
                if (!IsPostBack)
                {
                    Se.siYearsSel = 0;
                    Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
                }
            }
            //else
            //    ods.SelectMethod = "GetData";
        }
        get
        {
            return isShowGrad;
        }
    }
    #endregion

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlGrade.DataBind();
            //歷屆年級資料繫結
            ddlGradeGrad.DataSource = GradSqlDataAdapter();
            ddlGradeGrad.DataBind();
            if (Se.siYearsSel == 0)
            {
                ddlGrade.SelectedIndex = 0;
                ddlGradeGrad.SelectedIndex = 0;
                ddlGradeGrad.Visible = false;
            }
            else
            {
                string sSel = Se.siYearsSel.ToString();
                ListItem crItemGrad = ddlGradeGrad.Items.FindByValue(sSel);
                ListItem crItem = ddlGrade.Items.FindByValue(sSel);
                try
                {
                    if (crItem != null)
                    {
                        crItem.Selected = true;
                        ddlGradeGrad.Visible = false;
                    }
                    else
                    {
                        ddlGrade.SelectedIndex = ddlGrade.Items.Count - 1;
                        crItemGrad.Selected = true;
                        ddlGradeGrad.Visible = true;
                    }
                }
                catch
                {
                    ddlGrade.SelectedIndex = 0;
                    ddlGradeGrad.SelectedIndex = 0;
                    Se.siYearsSel = 0;
                    Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
                }
            }
        }
        //歷屆年級字顏色
        if (isShowGrad)
            ddlGrade.Items[ddlGrade.Items.Count - 1].Attributes.Add("style", "color:Blue");
    }
    #region 歷屆年級SQL
    private DataTable GradSqlDataAdapter()
    {
        string sqlGrad = "SELECT Grade, GradeID, GradeYear AS YearsGrade, Years FROM vGrade WHERE (GradeID IS NULL) ORDER BY Years DESC";
        try
        {
            using (SqlConnection conn = new SqlConnection(Se.sMyConnStr))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlGrad, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    #region 在學年級 DropDownList
    protected void ddlGradeClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lbGradeGrade_AfterClick();//HideDetail
        short iYears = short.Parse(ddlGrade.SelectedValue);
        if (iYears == 999) //選擇歷屆年級
        {
            Se.siYearsSel = 0;
            Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
            ddlGradeGrad.Visible = true;
            ddlGradeGrad.SelectedIndex = 0;
        }
        else
        {
            Se.siYearsSel = iYears;
            Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(iYears);
            ddlGradeGrad.Visible = false;
        }
        if (AfterGradeChange != null)
            AfterGradeChange(this, e);
    }
    protected void ddlGrade_DataBound(object sender, EventArgs e)
    {
        //第一個選項加入 s0 (請選擇或全部)
        ListItem crItem = new ListItem(s0, "0");
        ListItemCollection myItems = new ListItemCollection();
        ddlGrade.Items.Insert(0, crItem);
        //在最後加入 歷屆年級 選項
        if (isShowGrad)
            ddlGrade.Items.Add(new ListItem("歷屆年級", "999"));
    }
    #endregion
    #region 歷屆年級 DropDownList
    protected void ddlGradeGrad_SelectedIndexChanged(object sender, EventArgs e)
    {
        short iYears = short.Parse(ddlGradeGrad.SelectedValue);
        Se.siYearsSel = iYears;
        Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(iYears);
        if (AfterGradeChange != null)
            AfterGradeChange(this, e);
    }
    protected void ddlGradeGrad_DataBound(object sender, EventArgs e)
    {
        //第一個選項加入 請選擇
        ddlGradeGrad.Items.Insert(0, new ListItem("請選擇", "0"));
    }
    #endregion

    public void updateStatus()
    {
        if (Se.siYearsSel == 0)
        {
            ddlGrade.SelectedIndex = 0;
            ddlGradeGrad.SelectedIndex = 0;
            ddlGradeGrad.Visible = false;
        }
        else
        {
            string sSel = Se.siYearsSel.ToString();
            ListItem crItemGrad = ddlGradeGrad.Items.FindByValue(sSel);
            ListItem crItem = ddlGrade.Items.FindByValue(sSel);
            try
            {
                if (crItem != null)
                {
                    crItem.Selected = true;
                    ddlGradeGrad.Visible = false;
                }
                else
                {
                    ddlGrade.SelectedIndex = ddlGrade.Items.Count - 1;
                    crItemGrad.Selected = true;
                    ddlGradeGrad.Visible = true;
                }
            }
            catch
            {
                ddlGrade.SelectedIndex = 0;
                ddlGradeGrad.SelectedIndex = 0;
                Se.siYearsSel = 0;
                Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
            }
        }
    }
}

//protected void lbGradeClass_Click(object sender, EventArgs e)
//{
//  //  Se.siYears = 0;




//    /*
//    if (ddlGrade.DataSource == null)
//    {
//        ddlGrade.DataSource = sdsGrade;
//        ddlGrade.DataBind();
//        ddlGrade.SelectedIndex = ddlGrade.Items.Count - 1;

//    }
//     */ 

//    ddlGradeClass.Visible = true;



//    lbGradeClass.Visible = false;
//    //this.onClicked();
//    lbGradeGrade_AfterClick();
//    Se.sPIDSel = null;
//    Se.siYears = 0;
//    Se.siClassID = 0;
//}

//protected void ddlGradeClass_SelectedIndexChanged(object sender, EventArgs e)
//{

//}