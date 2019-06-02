﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class DataRetention : System.Web.UI.Page
{
    private bool isNeedReBind = false;//是否每次載入實都要重新DataBind()

    protected void Page_Init(object sender, EventArgs e)
    {
        Se.eSchoolRank = enSchoolRank.Primary;//自己設定
    }

    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Se.siYearsSel = 0;//初始選單設定
            //ClassSel1.updateStatus();//初始選單設定
            //GradeSel1.updateStatus();//初始選單設定
            DMHealth.ColumnSet(gvSt.Columns);
        }
        labMessage.Visible = false;
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        if (txtSeatNum.Visible)//"回復學生介面"狀態下不需要做下面的判斷處理
            return;
        if (!IsPostBack)//第一次載入時設定(班級年級)下拉式選單##隱藏掉"歷屆班級"選項
            ((DropDownList)ClassSel1.FindControl("ddlGradeClass")).Items[((DropDownList)ClassSel1.FindControl("ddlGradeClass")).Items.Count - 1].Enabled = false;
        if (!string.IsNullOrEmpty(txtSearch.Text))//如果輸入查詢時，突然又想要變成選單查詢。(txtSearch的處理)
            txtSearch.Text = string.Empty;
        if (!isNeedReBind)
        {
            gvSt.DataSource = ods;//可以改
            gvSt.DataBind();
        }
        isNeedReBind = false;
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
        changeGvView(false);
        changeDataRetentionUI(false);//切換到資料保留區"回復學生介面"
        //this.ClientScript.RegisterStartupScript(this.GetType(), "", "", true);
    }
    #endregion

    #region 搜尋
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        isNeedReBind = true;

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

    #region 恢復
    protected void btnReCover_Click(object sender, EventArgs e)
    {
        String sPID = gvSt.SelectedDataKey[0].ToString();
        DropDownList ddlGradeClass = ((DropDownList)ClassSel1.FindControl("ddlGradeClass"));
        String[] reGradAndClass = ddlGradeClass.SelectedValue.Split(',');
        String reSeat = txtSeatNum.Text.Trim();

        if (!DMHealth.isSameGradeClassSeatInTable("St", reGradAndClass[0], reGradAndClass[1], reSeat))//檢查學生
        {
            DMHealth.DelRetentionRestoreSt(sPID, reGradAndClass[0], reGradAndClass[1], reSeat);//回復資料
            //確認學生基本資料表是否真的有回復成功，有的話會有回復班級提醒，沒有的話跳出"回復失敗"
            this.ClientScript.RegisterStartupScript(this.GetType(), "DuplicateSeatAlert", "alert('已回復至" +
                ddlGradeClass.SelectedItem.Text +
                reSeat +
                "號。')", true);

            changeGvView(true);
            gvSt.DataSource = ods;//可以改
            gvSt.DataBind();
            changeDataRetentionUI(true);
            //切換介面
        }
        else//告視窗 ex: "X年X班X號已存在!! 請確認後再做設定!!"
            this.ClientScript.RegisterStartupScript(this.GetType(), "DuplicateSeatAlert", "alert('" +
                ddlGradeClass.SelectedItem.Text + reSeat +
                "號已經存在!!\\n" +
                "請確認後再做設定!!')", true);
    }
    #endregion

    #region 切換到資料保留區"搜尋介面"
    protected void btnCancelReCover_Click(object sender, EventArgs e)
    {
        changeGvView(true);
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
        isNeedReBind = true;
        labReGradeClass.Visible = !labReGradeClass.Visible;
        txtSeatNum.Visible = !txtSeatNum.Visible;
        labReSeat.Visible = !labReSeat.Visible;
        txtSearch.Visible = !txtSearch.Visible;
        btnSearch.Visible = !btnSearch.Visible;
        GradeSel1.Visible = !GradeSel1.Visible;
        ClassSel1.Visible = !ClassSel1.Visible;
        btnReCover.Visible = !btnReCover.Visible;
        txtSeatNum.Text = string.Empty;
        btnCancelReCover.Visible = !btnCancelReCover.Visible;
        labReCoverHint.Visible = !labReCoverHint.Visible;

        if (UICode)//設定選單是否保留gvSt鎖定的學生
            gvSt.SelectedIndex = -1;
        //Se.siYearsSel = 0;//初始選單設定
        //ClassSel1.updateStatus();//初始選單設定

        // GradeSel1.updateStatus();//初始選單設定
        //gvSt.Rows[gvSt.SelectedIndex].FindControl("btnRecover").Visible = !(gvSt.Rows[gvSt.SelectedIndex].FindControl("btnRecover").Visible);
        //if (UICode)
        //    gvSt.Width = 1000;
        //else
        //    gvSt.Width = 0;

    }
    #endregion
    #region 改換gv的欄位顯示    /*
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
}
