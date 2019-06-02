using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public static class DMHealth
{
    public static string YesNoBool(object obj)
    {
        bool isYes = bool.Parse(obj.ToString());
        string rv = "是";
        if (!isYes)
            rv = "否";
        return rv;
    }

    public static string GradeClass(int iYears, int iClassID)
    {
        //string sSql = "SELECT DISTINCT '(' + CAST(YearsClass.Years AS varchar(3)) + ') ' + ISNULL(Grade.Grade, N'') AS YearsGrade, YearsClass.Class "+
        //        " FROM  YearsClass LEFT OUTER JOIN Grade ON YearsClass.Years = Grade.Years where (YearsClass.Years = " + iYears.ToString() + ")";
        string sSql = "SELECT DISTINCT  ISNULL(Grade.Grade, N'')+'(' + CAST(YearsClass.Years AS varchar(3)) + ')'  AS YearsGrade, YearsClass.Class  FROM  YearsClass LEFT OUTER JOIN Grade ON YearsClass.Years = Grade.Years where (YearsClass.Years = " + iYears.ToString() +
            " and ClassID= " + iClassID.ToString() + ")";

        DataTableReader dr = WillNs.DM.ExecuteReader(sSql);
        string sGradeClass = string.Empty;
        if (dr.Read())
        {
            string sGrade = dr["YearsGrade"].ToString();
            string sClass = dr["Class"].ToString();
            sGradeClass = sGrade + "年" + sClass + "班";
        }
        dr.Close();
        return sGradeClass;
    }

    public static int ColumnSet(DataControlFieldCollection myColumns)
    {
        HealthShare.OthersTableAdapters.ColumnSetTableAdapter adp = new HealthShare.OthersTableAdapters.ColumnSetTableAdapter();
        int i = 0;
        foreach (DataControlField myField in myColumns)
        {
            string sField = myField.ToString();
            string scField = adp.ColumnC(sField);
            if (!string.IsNullOrEmpty(scField))
                myField.HeaderText = scField;

            i++;
        }
        return i;
    }

    public static void RemoveToStDataRetention(string sPID)//名字取錯？
    {
        string sqlReplaceTemplate;
        string sqlReplace;

        DataTable dt = CheckStinDataRetention(sPID);//檢查DataRetention有無該位學生
        using (SqlConnection cnn = new SqlConnection(Se.sMyConnStr))
        {
            cnn.Open();
            if (dt == null)
            {
                sqlReplaceTemplate = "Insert into DataRetention SELECT PID,Guy,SexID,Years,ClassID,NULL Seat,Birthday,Dad,Mom,Guardian,Zip,Tel1,Address,EmergencyCall,NewClassID,NewSeat,Blood,GuyID,Aborigine,StMemos FROM[Health].[dbo].[St] where PID = '{0}' ";
                sqlReplace = string.Format(sqlReplaceTemplate, sPID);
                using (SqlCommand cmdReplace = new SqlCommand(sqlReplace, cnn))
                {
                    cmdReplace.ExecuteNonQuery();
                }
            }
            else
            {
                string sSql = @"Update DataRetention set Guy = @Guy, SexID = @SexID, Years = @Years, ClassID = @ClassID, Seat = NULL, Birthday = @Birthday,
                                Dad = @Dad, Mom = @Mom, Guardian = @Guardian, Zip = @Zip, Tel1 = @Tel1, Address = @Address, EmergencyCall = @EmergencyCall,
                                NewClassID = @NewClassID, NewSeat = @NewSeat, Blood = @Blood, GuyID = @GuyID, Aborigine = @Aborigine, StMemos = @StMemos 
                                where PID = @PID";

                using (SqlCommand cmdReplace = new SqlCommand(sSql, cnn))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmdReplace.Parameters.Clear();
                        cmdReplace.Parameters.Add(new SqlParameter("Guy", dt.Rows[i]["Guy"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("SexID", dt.Rows[i]["SexID"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Years", dt.Rows[i]["Years"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("ClassID", dt.Rows[i]["ClassID"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Birthday", dt.Rows[i]["Birthday"]));
                        cmdReplace.Parameters.Add(new SqlParameter("Dad", dt.Rows[i]["Dad"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Mom", dt.Rows[i]["Mom"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Guardian", dt.Rows[i]["Guardian"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Zip", dt.Rows[i]["Zip"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Tel1", dt.Rows[i]["Tel1"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Address", dt.Rows[i]["Address"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("EmergencyCall", dt.Rows[i]["EmergencyCall"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("NewClassID", dt.Rows[i]["NewClassID"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("NewSeat", dt.Rows[i]["NewSeat"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Blood", dt.Rows[i]["Blood"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("GuyID", dt.Rows[i]["GuyID"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("Aborigine", dt.Rows[i]["Aborigine"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("StMemos", dt.Rows[i]["StMemos"].ToString().Trim()));
                        cmdReplace.Parameters.Add(new SqlParameter("PID", sPID));
                        cmdReplace.ExecuteNonQuery();
                    }
                }
            }
        }
        DeleteStForDataRetention(sPID);
    }

    public static DataTable CheckStinDataRetention(string sPID)
    {
        string sqlReplaceTemplate = "select * from DataRetention where PID = '{0}' ";
        string sqlReplace = string.Format(sqlReplaceTemplate, sPID);

        using (SqlConnection cnn = new SqlConnection(Se.sMyConnStr))
        {
            cnn.Open();
            using (SqlCommand cmdReplace = new SqlCommand(sqlReplace, cnn))
            {
                if (cmdReplace.ExecuteScalar() != null)//ExecuteScalar回傳該指令第一行資料
                {
                    string sSql = "select * from St where PID = '{0}' ";
                    string sSql1 = string.Format(sSql, sPID);
                    using (SqlCommand cmd = new SqlCommand(sSql1, cnn))
                    {
                        SqlDataAdapter DataApater = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        DataApater.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        return dt;
                    }
                }
                else
                {
                    return null;
                };
            }
        }
    }

    public static void DeleteStForDataRetention(string sPID)
    {
        string sqlReplaceTemplate = "Delete St where PID = '{0}' ";
        string sqlReplace = string.Format(sqlReplaceTemplate, sPID);
        using (SqlConnection cnn = new SqlConnection(Se.sMyConnStr))
        {
            cnn.Open();
            using (SqlCommand cmdReplace = new SqlCommand(sqlReplace, cnn))
            {
                cmdReplace.ExecuteNonQuery();
            }
        }
        
    }

    public static void DelRetentionRestoreSt(string sPID)
    {
        DelRetentionRestoreSt(sPID, "0", "1", "1");
    }

    public static void DelRetentionRestoreSt(string sPID, string Years, string ClassID, string Seat)//後面三個參數？
    {
        string sqlReplaceTemplate;
        string sqlReplace;
        DataTable dt = CheckSt(sPID);
        SqlConnection cnn = new SqlConnection(Se.sMyConnStr);
        cnn.Open();
        if (dt == null)
        {
            sqlReplaceTemplate = @"Insert into St SELECT PID,Guy,SexID,Years,1 ClassID,1 Seat,Birthday,Dad,Mom,Guardian,Zip,
                                  Tel1,Address,EmergencyCall,NewClassID,NewSeat,Blood,GuyID,Aborigine,StMemos,0 Deled FROM DataRetention 
                                  where PID = '{0}'";
            sqlReplace = string.Format(sqlReplaceTemplate, sPID);
            SqlCommand cmdReplace = new SqlCommand(sqlReplace, cnn);
            cmdReplace.ExecuteNonQuery();
        }
        else
        {
            string sSql = @"Update St set Guy = @Guy, SexID = @SexID, Years = @Years, ClassID = 1, Seat = 1, Birthday = @Birthday,
                            Dad = @Dad, Mom = @Mom, Guardian = @Guardian, Zip = @Zip, Tel1 = @Tel1, Address = @Address, EmergencyCall = @EmergencyCall,
                            NewClassID = @NewClassID, NewSeat = @NewSeat, Blood = @Blood, GuyID = @GuyID, Aborigine = @Aborigine, StMemos = @StMemos, Deled = 0
                            where PID = @PID";
            SqlCommand cmdReplace = new SqlCommand(sSql, cnn);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmdReplace.Parameters.Clear();
                cmdReplace.Parameters.Add(new SqlParameter("Guy", dt.Rows[i]["Guy"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("SexID", dt.Rows[i]["SexID"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Years", dt.Rows[i]["Years"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Birthday", dt.Rows[i]["Birthday"]));
                cmdReplace.Parameters.Add(new SqlParameter("Dad", dt.Rows[i]["Dad"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Mom", dt.Rows[i]["Mom"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Guardian", dt.Rows[i]["Guardian"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Zip", dt.Rows[i]["Zip"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Tel1", dt.Rows[i]["Tel1"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Address", dt.Rows[i]["Address"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("EmergencyCall", dt.Rows[i]["EmergencyCall"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("NewClassID", dt.Rows[i]["NewClassID"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("NewSeat", dt.Rows[i]["NewSeat"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Blood", dt.Rows[i]["Blood"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("GuyID", dt.Rows[i]["GuyID"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("Aborigine", dt.Rows[i]["Aborigine"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("StMemos", dt.Rows[i]["StMemos"].ToString().Trim()));
                cmdReplace.Parameters.Add(new SqlParameter("PID", sPID));

                cmdReplace.ExecuteNonQuery();
            }
        }
        DelDataRetention(sPID);
    }

    public static DataTable CheckSt(string sPID)
    {
        string sqlReplaceTemplate = "select * from St where PID = '{0}' ";
        string sqlReplace = string.Format(sqlReplaceTemplate, sPID);

        SqlConnection cnn = new SqlConnection(Se.sMyConnStr);
        cnn.Open();
        SqlCommand cmdReplace = new SqlCommand(sqlReplace, cnn);

        if (cmdReplace.ExecuteScalar() != null)
        {
            string sSql = "select * from DataRetention where PID = '{0}' ";
            string sSql1 = string.Format(sSql, sPID);
            SqlCommand cmd = new SqlCommand(sSql1, cnn);
            SqlDataAdapter DataApater = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataApater.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        else
        {
            return null;
        };
    }

    public static void DelDataRetention(string sPID)
    {
        string sqlReplaceTemplate = "Delete DataRetention where  PID = '{0}'";
        string sqlReplace = string.Format(sqlReplaceTemplate, sPID);

        SqlConnection cnn = new SqlConnection(Se.sMyConnStr);
        cnn.Open();
        SqlCommand cmdReplace = new SqlCommand(sqlReplace, cnn);
        cmdReplace.ExecuteNonQuery();
    }
}