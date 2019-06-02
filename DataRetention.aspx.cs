using System;
using System.Data;
using System.Data.SqlClient;

public partial class DataRetention : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Se.eSchoolRank = enSchoolRank.Primary;//自己設定
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DMHealth.ColumnSet(gvSt.Columns);
        }
        gvSt.DataSourceID = "ods";//幹嘛又重新指定？
        labMessage.Visible = false;
    }

    #region 顯示隱藏
    public void HideDetail()
    {
        gvSt.Visible = false;
    }

    public void ShowDetail()
    {
        gvSt.Visible = true;
    }
    #endregion

    #region 恢復
    protected void gvSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        String sPID = gvSt.SelectedDataKey[0].ToString();
        //DateTime unDate = (DateTime)gvSt.SelectedDataKey[1];
        //DMHealth.DelRestoreSt(sPID, 0);
        DMHealth.DelRetentionRestoreSt(sPID); //將保留區學生資料(轉出日期、PID)轉移置基本資料區並刪除資料保留區資料

        #region 回復年級班級的提醒
        try
        {
            #region 查詢學生姓名、年級班級、座號 語法
            string sqlSt = @"SELECT Guy, GradeClass, Seat
                              FROM St INNER JOIN vClass ON St.Years = vClass.Years AND St.ClassID = vClass.ClassID
                              WHERE PID = @PID";
            #endregion
            DataTable dt = new DataTable();

            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@PID", sPID)
            };

            dt = SqlAccess.SqlDataAdapterToDataTable(sqlSt, parameter);

            string sGuy = string.Empty;
            string sGradeClass = string.Empty;
            string sSeat = string.Empty;
            //取得姓名、年級班級、座號
            if (dt.Rows.Count > 0)
            {
                sGuy = dt.Rows[0]["Guy"].ToString();
                sGradeClass = dt.Rows[0]["GradeClass"].ToString();
                sSeat = dt.Rows[0]["Seat"].ToString();
            }
            // 彈跳視窗
            if (!string.IsNullOrEmpty(sGuy) && !string.IsNullOrEmpty(sGradeClass) && !string.IsNullOrEmpty(sSeat))
                WillNs.Util.alert(this, sGuy + " 已回復至 " + sGradeClass + sSeat + "號");
        }
        catch (Exception)
        {
            throw;
        }
        #endregion

        gvSt.SelectedIndex = -1;
        gvSt.DataBind();
    }
    #endregion

    #region 搜尋
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearch.Text.Trim();
        if (!string.IsNullOrEmpty(strSearch))
        {
            Se.siYearsSel = 0;
            GradeSel1.updateStatus();

            string sqlSearch =
                @"
                SELECT * 
                FROM  DataRetention 
                WHERE PID = @condition OR GuyID LIKE '%' + @condition + '%' OR Guy LIKE '%' + @condition + '%'  
                ORDER BY Years, ClassID, Seat ";

            SqlParameter[] parameter = new SqlParameter[]{
                new SqlParameter("@condition", strSearch)
            };

            DataTable dt = new DataTable();
            dt = SqlAccess.SqlDataAdapterToDataTable(sqlSearch, parameter);

            if (dt.Rows.Count > 0)
            {
                gvSt.DataSourceID = null;
                gvSt.DataSource = dt;
                gvSt.DataBind();
            }
            else
            {
                labMessage.Text = "查無資料";
                labMessage.Visible = true;
            }
            txtSearch.Text = string.Empty;
        }
        else
        {
            labMessage.Text = "請輸入搜尋條件";
            labMessage.Visible = true;
        }
    }
    #endregion
}
