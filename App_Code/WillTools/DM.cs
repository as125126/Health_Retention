using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace WillNs
{
    public static class DM
    {
        //static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string ConnStrKey;

        public static System.Globalization.DateTimeFormatInfo ShortDatePattern
        {
            get
            {
                System.Globalization.DateTimeFormatInfo info = new System.Globalization.DateTimeFormatInfo();
                info.ShortDatePattern = "yyyy/MM/dd";

                return info;

            }

        }
        private static string GetConnStr()
        {
            //原本的
            //string ss = HttpContext.Current.Session[ConnStrKey].ToString();
            string ss = "Data Source=.\\SQLEXPRESS;Initial Catalog = Health; Integrated Security = True;";
            return ss;

        }


        public static string[] GetFieldNames(DataTable dt)
        {
            String[] rv = { };
            StringBuilder sb = new StringBuilder();

            if (dt != null)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.AppendFormat("{0},", dc.ColumnName);
                }
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    String ss = sb.ToString();
                    rv = ss.Split(',');
                }

            }
            return rv;
        }


        //public static int GroupResult(int iGroup, int[] iaGroup)
        //{
        //    //如果子項目全部都是 0或9 則主項目不更動
        //    //否則主項目依子項目的內容做變動

        //    int iRV = 0;

        //    int iCount = iaGroup.Length;
        //    bool isAll09 = true;
        //    for (int i = 0; i < iCount; i++)
        //    {
        //        if ((iaGroup[i] != 0) & (iaGroup[i] != 9))
        //            isAll09 = false;
        //    };
        //    if (isAll09)
        //        iRV = iGroup;
        //    else
        //        iRV = GroupResult123(iGroup, iaGroup);
        //    return iRV;
        //}
        //private static int GroupResult123(int iGroup, int[] iaGroup)
        //{
        //    int[] iArray = { 1, 2, 3, 0};
        //    for (int j=0; j< iArray.Length; j++)
        //        for (int i = 0; i < iaGroup.Length; i++)
        //            if (iaGroup[i] == iArray[j])
        //                return  iArray[j];

        //    return 9;

        //}


        //private static int GroupResult123(int iGroup, int[] iaGroup)
        //{
        //    int iResult = 0; int iRV;
        //    int iCount = iaGroup.Length;
        //    bool is3 = false;
        //    bool is2 = false;
        //    bool is1 = false;

        //    for (int i = 0; i < iCount; i++)
        //    {
        //        if (iaGroup[i] == 3)
        //            is3 = true;
        //    };

        //    if (!is3)
        //        for (int i = 0; i < iCount; i++)
        //        {
        //            if (iaGroup[i] == 2)
        //                is2 = true;
        //        };

        //    if (!is2)
        //        for (int i = 0; i < iCount; i++)
        //        {
        //            if (iaGroup[i] == 1)
        //                is1 = true;
        //        };
        //    if (is3)
        //        iResult = 3;
        //    else
        //        if (is2)
        //            iResult = 2;
        //        else
        //            if (is1)
        //                iResult = 1;

        //    if (iResult > 0)
        //        iRV = iResult;
        //    else
        //        iRV = iGroup;
        //    return iRV;
        //}

        public static int iReadAge(DateTime dtBirthDay, DateTime dtBase)
        {
            int y = dtBase.Year - dtBirthDay.Year;
            int m = dtBase.Month - dtBirthDay.Month;
            int d = dtBase.Day - dtBirthDay.Day;
            if (m > 0 && d > 0)
                return y;
            else
            {
                if (m < 0 || (m == 0 && d < 0))
                    return y - 1;
                else return y;
            }
        }

        public static bool cheakBirthFormat(ref string dtBirthDay)
        {
            try
            {
                DateTime dt = DateTime.Parse(dtBirthDay);
                dtBirthDay = dt.Year + "/" + dt.Month.ToString("00") + "/" + dt.Day.ToString("00");

                return true;
            }
            catch (Exception ex)
            {
                //logger.Info(ex.Message);
                return false;
            }
        }

        public static string FillNumber(int iNum, int iDig)
        {
            string sInt = iNum.ToString();
            int iDigOri = sInt.Length;
            if (iDigOri < iDig)
            {
                for (int i = 0; i <= (iDig - iDigOri); i++)
                {
                    sInt = '0' + sInt;
                }
            }
            return sInt;
        }



        //---------------Using Data Application Access Block2---------------------------------------
        //public static SqlDataReader GetSex()
        //{
        //    return ExecuteReader("Select SexID, Sex from Sex");
        //}
        //---------------Using Data Application Access Block2---------------------------------------

        //---------------Using Data Application Access Block2---------------------------------------
        public static string ColorGuy(object oName, object oSexID)
        {
            string sid = oSexID.ToString();
            string sName = oName.ToString();
            string rv;
            if (sid == "1")
                rv = "<Font Color=Blue>" + sName + "</Font>";
            else
                rv = "<Font Color=DarkRed>" + sName + "</Font>";

            return rv;
        }



        //---------------Using Data Application Access Block2---------------------------------------


        /*
    public static string SexC(object  St)
    {
        DataRowView mySt=(DataRowView)St;
        string sid=mySt["SexID"].ToString();
        string rv;
        rv=(sid=="1"?"男":"女");
        return rv;
}
*/

        public static bool TestConnection(string sConn)
        {
            bool isOK = true;
            using (SqlConnection connection = new SqlConnection(sConn))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    //logger.Info(ex.Message);
                    isOK = false;
                }
            }
            return isOK;
        }

        public static object ExecuteScalar(string sSql)
        {

            //return SqlHelper.ExecuteScalar(cnnStr, CommandType.Text, sSql);
            string cnnStr = GetConnStr();

            SqlConnection cnn = new SqlConnection(cnnStr);
            SqlCommand myCommand = new SqlCommand(sSql, cnn);
            cnn.Open();
            object ob = myCommand.ExecuteScalar();
            cnn.Close();
            return ob;


        }


        public static object ExecuteScalar(string sConn, string sSql)
        {

            SqlConnection cnn = new SqlConnection(sConn);
            SqlCommand myCommand = new SqlCommand(sSql, cnn);
            try
            {
                cnn.Open();
                object ob = myCommand.ExecuteScalar();
                cnn.Close();
                return ob;
            }
            catch (Exception ex)
            {
                //logger.Info(ex.Message);
                return null;
            }
        }

        public static int ExecuteNonQuery(string sSql)
        {
            string cnnStr = GetConnStr();

            return ExecuteNonQuery(sSql, cnnStr);

        }

        public static int ExecuteNonQuery(string sSql, string sCnn)
        {
            int iRV = 0;
            using (SqlConnection cnn = new SqlConnection(sCnn))
            {
                SqlCommand myCommand = new SqlCommand(sSql, cnn);
                myCommand.CommandTimeout = 1200;
                cnn.Open();
                iRV = myCommand.ExecuteNonQuery();


                cnn.Close();
            } // At this point the cnn object will be disposed
            return iRV;
        }



        public static string ExecuteNonQueryS(string sSql, string sCnn)
        {
            string sRV = "OK";
            try
            {

                using (SqlConnection cnn = new SqlConnection(sCnn))
                {
                    SqlCommand myCommand = new SqlCommand(sSql, cnn);
                    myCommand.CommandTimeout = 1200;
                    cnn.Open();
                    myCommand.ExecuteNonQuery();
                    cnn.Close();
                } // At this point the cnn object will be disposed
            }
            catch (Exception ex)
            {
                //logger.Info(ex.Message);
                sRV = ex.Message;
            }
            return sRV;


        }

        /*
                    public static SqlDataReader ExecuteReader(string sSql)
                    {
                        return SqlHelper.ExecuteReader(cnnStr, CommandType.Text, sSql);

            }
        */
        public static DataTableReader ExecuteReader(string sSql)
        {
            /*
            string cnnStr = GetConnStr();
            string sCnn = cnnStr;
			SqlConnection cnn = new SqlConnection(sCnn);
			SqlCommand myCommand = new SqlCommand(sSql, cnn);
            myCommand.CommandTimeout = 1200;
			cnn.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            cnn.Close();*/
            DataSet ds = new DataSet();
            string cnnStr = GetConnStr();

            using (SqlConnection cn = new SqlConnection(cnnStr))
            {
                //2.SqlCommand
                using (SqlCommand cmd = new SqlCommand(sSql, cn))
                {
                    //3.SqlDataAdapter
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }

            //SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            //cnn.Close();

            DataTableReader rd = ds.Tables[0].CreateDataReader();
            return rd;
        }


        public static DataSet ExecuteDataset(string sSp, params object[] myParams)
        {
            string cnnStr = GetConnStr();
            return SqlHelper.ExecuteDataset(cnnStr, sSp, myParams);



        }
        public static DataSet ExecuteDataset(string sCmd)

        {
            string cnnStr = GetConnStr();
            return SqlHelper.ExecuteDataset(cnnStr, CommandType.Text, sCmd);


        }


        public static DataView ExecuteView(string sCmd)
        {
            string cnnStr = GetConnStr();

            return SqlHelper.ExecuteDataset(cnnStr, CommandType.Text, sCmd).Tables[0].DefaultView;

        }

        public static DataView ExecuteView(string sCmd, SqlParameter myParam)
        {
            string cnnStr = GetConnStr();

            return SqlHelper.ExecuteDataset(cnnStr, CommandType.StoredProcedure, sCmd, myParam).Tables[0].DefaultView;

        }


        public static DataTable ExecuteDataTable(string sCmd)
        {
            string cnnStr = GetConnStr();
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataset(cnnStr, CommandType.Text, sCmd).Tables[0];
            return dt;

        }

        public static DataTable ExecuteDataTable(string sCmd, string sTableName)
        {
            string cnnStr = GetConnStr();
            DataTable dt = ExecuteDataTable(sCmd);
            dt.TableName = sTableName;
            return dt;
        }




        #region 不使用 Data Access Application Block 的方案
        /*
//-----------------------------------------------------------------------------

		public static  void cnnOpen()
		{
			cnn=new SqlConnection(cnnStr);
		
			cnn.Open();


		}

		public static void cnnClose()
		{
			cnn.Close();

		}


		
		public static void drClose()
		{
			dr.Close();
			cnn.Close();

		}

		
		public static  SqlDataReader drOpen(string sSql)
		{
			cnnOpen();
			SqlCommand cmd=new SqlCommand(sSql,cnn);
			dr= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			return dr;

		}


		public static DataView CreateDataView(string sCmd)
		{
			DataSet ds=new DataSet();	
			SqlDataAdapter da=new SqlDataAdapter(sCmd,cnn);
			da.Fill(ds,"temp");
			return ds.Tables["temp"].DefaultView;
			
		}

		public static DataSet CreateDataSet(string sCmd)
		{
			DataSet ds=new DataSet();	
			SqlDataAdapter da=new SqlDataAdapter(sCmd,cnn);
			da.Fill(ds,"temp");
			return ds;
			
		}

*/
        #endregion
    }

}