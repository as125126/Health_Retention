using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ClassSel_ascx : System.Web.UI.UserControl
{
    public delegate void _AfterClassChange(object sender, EventArgs e);
    public event _AfterClassChange AfterClassChange;

    private bool isShowAll = true;
    private bool isValid = true;

    public string sGradeClassSel
    {
        get
        {
            if (ViewState["sGradeClassSel"] != null)
                return ViewState["sGradeClassSel"].ToString();
            else
                return null;
        }
        set { ViewState["sGradeClassSel"] = value; }
    }
    public string sYearsGradeClass
    {
        get
        {
            if (Session["sYearsGradeClass"] != null)
                return Session["sYearsGradeClass"].ToString();
            else
                return null;
        }
        set { Session["sYearsGradeClass"] = value; }
    }
    public bool ShowAll
    {
        get
        {
            return isShowAll;
        }
        set
        {
            isShowAll = value;
            if (!IsPostBack)
            {
                Se.siYearsSel = 0;
                Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
                Se.siClassIDSel = 0;
            }
        }
    }
    public bool EnableValid
    {
        set { isValid = value; }
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlGradeClass.DataBind();//年級班級
            ddlGradeClassGrad.DataSource = GradSqlDataAdapter();//歷屆學級班級
            ddlGradeClassGrad.DataBind();

            #region 設定選取項目
            if (Se.siYearsSel == 0)
            {
                //選擇「請選擇」項目
                ddlGradeClass.SelectedIndex = 0;
                ddlGradeClassGrad.SelectedIndex = 0;
            }
            else
            {
                try
                {
                    SetItemSelected();//設定選取項目
                }
                catch
                {
                    ddlGradeClass.SelectedIndex = 0;
                    ddlGradeClassGrad.SelectedIndex = 0;
                }
            }
            #endregion

            //「請選擇一個班級」提醒
            if (!isValid)
                validSel.Enabled = false;
        }

        //歷屆班級字顏色
        if (isShowAll)
            ddlGradeClass.Items[ddlGradeClass.Items.Count - 1].Attributes.Add("style", "color:Blue");
    }

    #region 設定選取項目
    public void SetItemSelected()
    {
        string sSel = Se.siYearsSel.ToString() + ',' + Se.siClassIDSel.ToString();

        //查詢下拉選單內是否有指定資料
        ListItem crItem = ddlGradeClass.Items.FindByValue(sSel);//年級班級
        ListItem crItemGrad = ddlGradeClassGrad.Items.FindByValue(sSel);//歷屆學級班級

        if (crItem != null)
        {
            crItem.Selected = true;//選取指定「年級班級」資料
            ddlGradeClassGrad.Visible = false;//隱藏「歷屆學級班級」
        }
        else
        {
            crItemGrad.Selected = true;//選取指定「歷屆學級班級」
            ddlGradeClassGrad.Visible = true;//顯示「歷屆學級班級」
            ddlGradeClass.SelectedIndex = ddlGradeClass.Items.Count - 1;//「年級班級」選擇「歷屆班級」項目
        }
    }
    #endregion

    #region 歷屆學級班級
    private DataTable GradSqlDataAdapter()
    {
        string sqlGrad =
            @"
            SELECT DISTINCT Years, ClassID, 
                CAST(Years AS varchar(3)) + ',' + CAST(ClassID AS varchar(3)) AS YearsClass,
                GradeClass AS YearsGradeClass
            FROM vClass 
            WHERE (Grade IS NULL)
            UNION
                SELECT '999' AS Years, '0' AS ClassID, '0,0' AS YearsClass, '請選擇' AS YearsGradeClass
                ORDER BY Years DESC, ClassID";
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

    #region 加入「歷屆班級」選項 ddlGradeClass_DataBound
    protected void ddlGradeClass_DataBound(object sender, EventArgs e)
    {
        //在最後加入 歷屆班級 選項
        if (isShowAll)
            ddlGradeClass.Items.Add(new ListItem("歷屆班級", "999,999"));
    }
    #endregion

    #region 年級班級 SelectedIndexChanged 事件
    protected void ddlGradeClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] asYearsClassID = ddlGradeClass.SelectedValue.Split(',');
        short iYears = short.Parse(asYearsClassID[0]);
        int iClassID = int.Parse(asYearsClassID[1]);
        if (iYears == 999)
        { //是否為歷屆班級
            Se.siYearsSel = 0;
            Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
            Se.siClassIDSel = 0;
            ddlGradeClassGrad.Visible = true;
            ddlGradeClassGrad.SelectedIndex = 0;
        }
        else
        {
            Se.siYearsSel = iYears;
            Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(iYears);
            Se.siClassIDSel = (short)iClassID;
            ddlGradeClassGrad.Visible = false;
        }

        sYearsGradeClass = ddlGradeClass.SelectedItem.ToString();
        sGradeClassSel = DMHealth.GradeClass(Se.siYearsSel, Se.siClassIDSel);

        if (AfterClassChange != null)//AfterClassChange 事件
            AfterClassChange(this, e);
    }
    #endregion

    #region 歷屆班級 SelectedIndexChanged 事件
    protected void ddlGradeClassGrad_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] asYearsClassID = ddlGradeClassGrad.SelectedValue.Split(',');
        short iYears = short.Parse(asYearsClassID[0]);
        int iClassID = int.Parse(asYearsClassID[1]);

        Se.siYearsSel = iYears;
        Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(iYears);
        Se.siClassIDSel = (short)iClassID;

        sYearsGradeClass = ddlGradeClassGrad.SelectedItem.ToString();//年級班級
        sGradeClassSel = DMHealth.GradeClass(Se.siYearsSel, Se.siClassIDSel);//年級（小一入學學年度）班級

        //AfterClassChange 事件
        if (AfterClassChange != null)
            AfterClassChange(this, e);
    }
    #endregion
    public void updateStatus()
    {
        if (Se.siYearsSel == 0)
        {
            ddlGradeClass.SelectedIndex = 0;
            ddlGradeClassGrad.SelectedIndex = 0;
            ddlGradeClassGrad.Visible = false;
        }
        else
        {
            string sSel = Se.siYearsSel.ToString();
            ListItem crItemGrad = ddlGradeClassGrad.Items.FindByValue(sSel);
            ListItem crItem = ddlGradeClass.Items.FindByValue(sSel);
            try
            {
                if (crItem != null)
                {
                    crItem.Selected = true;
                    ddlGradeClassGrad.Visible = false;
                }
                else
                {
                    ddlGradeClass.SelectedIndex = ddlGradeClass.Items.Count - 1;
                    crItemGrad.Selected = true;
                    ddlGradeClassGrad.Visible = true;
                }
            }
            catch
            {
                ddlGradeClass.SelectedIndex = 0;
                ddlGradeClassGrad.SelectedIndex = 0;
                Se.siYearsSel = 0;
                Se.siGradeIDSel = HealthShareUtil.YearsToGradeID(0);
            }
        }
    }
}