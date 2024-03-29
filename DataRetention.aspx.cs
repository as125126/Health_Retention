﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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
            selectGradeClass.DataSourceID = "GradeClass_ods";
            selectGradeClass.DataBind();
        }
        labMessage.Visible = false;
        gvSt.DataSource = ods;
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        if (userUI.ActiveViewIndex == 0 )
            gvSt.DataBind();
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

    #region 切換到資料保留區"回復學生介面"
    protected void gvSt_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeDataRetentionUI(false);//切換到資料保留區"回復學生介面"
    }
    #endregion

    #region 按鈕搜尋
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
                gvSt.DataSource = dt;
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

    #region 恢復
    protected void btnReCover_Click(object sender, EventArgs e)
    {
        String sPID = gvSt.SelectedDataKey[0].ToString();
        String[] reGradAndClass = selectGradeClass.SelectedValue.Split(',');
        String reSeat = txtSeatNum.Text.Trim();

        if (!checkRecoverField())
            return;
        if (DMHealth.isSameGradeClassSeatInTable("St", reGradAndClass[0], reGradAndClass[1], reSeat))
        {
            ladRecoverHintMassage.Text = selectGradeClass.SelectedItem.Text + reSeat + "號已經存在!!\n請確認後再做設定!!";
            return;
        }
        DMHealth.DelRetentionRestoreSt(sPID, reGradAndClass[0], reGradAndClass[1], reSeat);//回復資料
        //確認學生基本資料表是否真的有回復成功，有的話會有回復班級提醒，沒有的話跳出"回復失敗"
        this.ClientScript.RegisterStartupScript(this.GetType(), "DuplicateSeatAlert", "alert('已回復至" +
            selectGradeClass.SelectedItem.Text +
            reSeat +
            "號。')", true);
        //changeGvView(true);
        changeDataRetentionUI(true);
        gvSt.DataSource = ods;//可以改
        gvSt.DataBind();
    }
    #endregion

    #region 切換到資料保留區"搜尋介面"
    protected void btnCancelReCover_Click(object sender, EventArgs e)
    {
        changeDataRetentionUI(true);
    }
    #endregion

    #region 切換資料保留區"搜尋"或"回復"學生介面
    /*
     * 輸入參數[true,false]
     * false為切換到資料保留區"回復學生介面";
     * true為切換到資料保留區"搜尋介面";
     * 
    */
    private void changeDataRetentionUI(bool UICode)
    {
        changeGvView(UICode);
        txtSeatNum.Text = string.Empty;
        userUI.ActiveViewIndex = UICode? 0:1;//介面控制項切換
    
        if (UICode)
        {//設定選單是否保留gvSt鎖定的學生
            gvSt.SelectedIndex = -1;
            ladRecoverHintMassage.Text = string.Empty;
        }
        else
            selectGradeClass.SelectedIndex = 0;
    }
    #endregion

    #region 改換gv的欄位顯示 
    /* 輸入參數[true, false]
    * false 顯示只被回復的學生
    * true 顯示所有被查詢到的學生名單
   */
    private void changeGvView(bool UICode)
    {
        if (UICode)
        {
           gvSt.Width = 1000;
            for (int i = 0; i < gvSt.Columns.Count; i++)
            {
                gvSt.Columns[i].Visible = true;
            }
        }
        else
        {
            gvSt.Width = 0;
            for (int i = 0; i < gvSt.Columns.Count; i++)
            {
                if (i > 0 && i < 6)
                    gvSt.Columns[i].Visible = true;
                else
                    gvSt.Columns[i].Visible = false;
            }
        }
        for (int i = 0; i < gvSt.Rows.Count; i++)
            gvSt.Rows[i].Visible = (UICode | (i == gvSt.SelectedIndex) ? true : false);
    }
    #endregion

    #region 檢查回復欄位是否有空 
    /* 回傳值[true,false]
* true 回復欄位沒有問題
* false 欄位有空白或座號輸入錯誤
*/
    private bool checkRecoverField()
    {
        int i = 0;//給int.TryParse()參考數值型態用
        if (selectGradeClass.SelectedIndex == 0)
        {
            ladRecoverHintMassage.Text = "請選擇班級年級!!";
            return false;
        }
        if (txtSeatNum.Text.Equals(string.Empty))
        {
            ladRecoverHintMassage.Text = "請輸入座號!!";
            return false;
        }else if(!int.TryParse(txtSeatNum.Text,out i)){
            ladRecoverHintMassage.Text = "座號請輸入數字!!";
            return false;
        }
        return true;
    }
    #endregion
}
