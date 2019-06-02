using HealthShare;
using HealthShare.Properties;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web;
using WillNs;

public static class Se
{
    //static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public static string CloseWindow = "CloseWindow";
    public static string dsCSV = "dsCSV";
    public static bool isOneSchool;
    public static string sExportWarn = "※請善盡保護學生資料之責任，若無正式公文或依據，請勿將資料轉交給其他單位。";
    public static string sHome;
    public static string sInitSchoolPW = "health";
    public static string snurse = "nurse";
    public static string ssiGradeIDClassPre = "GradeIDClassPre";
    public static string sssSightNoteFilter = "SightNoteFilter";
    public static string sssWHNoteFilter = "WHNoteFilter";

    public static object GetAppKey(string sKey)
    {
        return HttpContext.Current.Application[sKey];
    }

    private static object GetSessionKey(string sKey)
    {
        try
        {
            return HttpContext.Current.Session[sKey];
        }
        catch (Exception exception)
        {
            //logger.Info(exception);
            return null;
        }
    }

    public static void InitMyConnStr()
    {
        if (isOneSchool)
        {
            sMyConnStr = ConfigurationManager.ConnectionStrings["School"].ToString();
        }
        else
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = ConfigurationManager.AppSettings["Instance"].ToString(),
                InitialCatalog = "Health" + sAd,
                IntegratedSecurity = true
            };
            sMyConnStr = builder.ConnectionString;
        }
        DM.ConnStrKey = "MyConnStr";
    }

    public static void InitSes()
    {
        InitMyConnStr();
        string str = "Select * from SystemSet";
        DataTableReader reader = DM.ExecuteReader(str);
        while (reader.Read())
        {
            string sKey = reader["Item"].ToString();
            string oValue = reader["Setting"].ToString();
            HttpContext.Current.Session[sKey] = oValue;
            if (sKey == "SchoolRank")
            {
                SetAppKey(sKey, oValue);
            }
        }
        reader.Close();
        SetMaxMinGradeID();
    }

    public static void SetAdapterConn(ref SqlDataAdapter myAdapter)
    {
        myAdapter.SelectCommand.Connection.ConnectionString = sMyConnStr;
    }

    public static void SetAppKey(string sKey, object oValue)
    {
        HttpContext.Current.Application[sKey] = oValue;
    }

    public static void SetConn(SqlConnection conn)
    {
        conn.ConnectionString = sMyConnStr;
    }

    private static void SetMaxMinGradeID()
    {
        switch (eSchoolRank)
        {
            case enSchoolRank.Primary:
                siMaxGradeID = 6;
                siMinGradeID = 1;
                siEnterYearsDiff = 0;
                break;

            case enSchoolRank.Junior:
                siMaxGradeID = 9;
                siMinGradeID = 7;
                siEnterYearsDiff = 6;
                break;

            case enSchoolRank.JuniorPrimary:
                siMaxGradeID = 9;
                siMinGradeID = 1;
                siEnterYearsDiff = 0;
                break;

            case enSchoolRank.Senior:
                siMaxGradeID = 12;
                siMinGradeID = 10;
                siEnterYearsDiff = 9;
                break;

            case enSchoolRank.Complete:
                siMaxGradeID = 12;
                siMinGradeID = 7;
                siEnterYearsDiff = 6;
                break;

            case enSchoolRank.Senior4:
                siMaxGradeID = 13;
                siMinGradeID = 10;
                siEnterYearsDiff = 9;
                break;
        }
    }

    public static string sArea()
    {
        string Area = "";
        string AreaNumber = sSchoolID.Substring(0, 2);
        switch (AreaNumber)
        {
            case "01":
                //臺北縣升格改制為新北市
                Area = "新北市";
                break;
            case "02":
                Area = "宜蘭縣";
                break;
            case "03":
                //桃園縣升格改制為桃園市
                Area = "桃園市";
                break;
            case "04":
                Area = "新竹縣";
                break;
            case "05":
                Area = "苗栗縣";
                break;
            case "06":
                //臺中縣市合併改制為臺中市
                Area = "台中市";
                break;
            case "07":
                Area = "彰化縣";
                break;
            case "08":
                Area = "南投縣";
                break;
            case "09":
                Area = "雲林縣";
                break;
            case "10":
                Area = "嘉義縣";
                break;
            case "11":
                //臺南縣市合併改制為臺南市
                Area = "台南市";
                break;
            case "12":
                //高雄縣市合併改制為高雄市
                Area = "高雄市";
                break;
            case "13":
                Area = "屏東縣";
                break;
            case "14":
                Area = "台東縣";
                break;
            case "15":
                Area = "花蓮縣";
                break;
            case "16":
                Area = "澎湖縣";
                break;
            case "17":
                Area = "基隆縣";
                break;
            case "18":
                Area = "新竹市";
                break;
            case "19":
                Area = "台中市";
                break;
            case "20":
                Area = "嘉義市";
                break;
            case "21":
                Area = "台南市";
                break;
            case "31":
                Area = "松山區";
                break;
            case "32":
                Area = "信義區";
                break;
            case "33":
                Area = "大安區";
                break;
            case "34":
                Area = "中山區";
                break;
            case "35":
                Area = "中正區";
                break;
            case "36":
                Area = "大同區";
                break;
            case "37":
                Area = "萬華區";
                break;
            case "38":
                Area = "文山區";
                break;
            case "39":
                Area = "南港區";
                break;
            case "40":
                Area = "內湖區";
                break;
            case "41":
                Area = "士林區";
                break;
            case "42":
                Area = "北投區";
                break;
            case "51":
                Area = "鹽埕區";
                break;
            case "52":
                Area = "鼓山區";
                break;
            case "53":
                Area = "左營區";
                break;
            case "54":
                Area = "楠梓區";
                break;
            case "55":
                Area = "三民區";
                break;
            case "56":
                Area = "新興區";
                break;
            case "57":
                Area = "前金區";
                break;
            case "58":
                Area = "苓雅區";
                break;
            case "59":
                Area = "前鎮區";
                break;
            case "60":
                Area = "旗津區";
                break;
            case "61":
                Area = "小港區";
                break;
            case "71":
                Area = "金門縣";
                break;
            case "72":
                Area = "連江縣";
                break;
            default:
                break;
        }
        return Area;
    }
    /*
    public static void SetSem()
    {
        short schYears = 0;
        short sem = 0;
        SemTableAdapter adapter = new SemTableAdapter
        {
            Connection = { ConnectionString = sMyConnStr }
        };
        if (adapter.GetData().Rows.Count == 0)
        {
            schYears = 100;
            sem = 1;
            adapter.Insert(schYears, sem, 0, 0);
        }
        else
        {
            dsSchool.SemRow row = (dsSchool.SemRow)adapter.Get_Now().Rows[0];
            schYears = row.SchYears;
            sem = row.Sem;
        }
        siSchYearsNow = schYears;
        siSemNow = sem;
        siSemClassNow = sem;
    }

    public static void SetSem_Test()
    {
        short schYears = 0;
        short sem = 0;
        SemTableAdapter adapter = new SemTableAdapter
        {
            Connection = { ConnectionString = sMyConnStr }
        };
        if (adapter.GetData().Rows.Count > 0)
        {
            dsSchool.SemRow row = (dsSchool.SemRow)adapter.Get_Now().Rows[0];
            schYears = row.SchYears;
            sem = row.Sem;
        }
        siSchYearsNow = schYears;
        siSemNow = sem;
    }
    */

    private static void SetSessionKey(string sKey, object oValue)
    {
        HttpContext.Current.Session[sKey] = oValue;
    }

    /*
    public static void UpdateKeyToDb(string sKey, object oValue)
    {
        int num = new SystemSetTableAdapter { Connection = { ConnectionString = sMyConnStr } }.Update(oValue.ToString(), sKey);
    }
    */

    public static bool bPrintSight
    {
        get
        {
            return ((GetSessionKey("PrintSight") != null) && ((bool)GetSessionKey("PrintSight")));
        }
        set
        {
            SetSessionKey("PrintSight", value);
        }
    }

    //身高體重視力通知單 - 視力正常列印回條單  
    public static bool bPrintReceipt
    {
        get
        {
            return ((GetSessionKey("PrintReceipt") != null) && ((bool)GetSessionKey("PrintReceipt")));
        }
        set
        {
            SetSessionKey("PrintReceipt", value);
        }
    }

    public static bool bPrintSightHistory
    {
        get
        {
            return ((GetSessionKey("PrintSightHistory") != null) && ((bool)GetSessionKey("PrintSightHistory")));
        }
        set
        {
            SetSessionKey("PrintSightHistory", value);
        }
    }

    public static bool bPrintSightNoteAll
    {
        get
        {
            return ((GetSessionKey("PrintSightNoteAll") != null) && ((bool)GetSessionKey("PrintSightNoteAll")));
        }
        set
        {
            SetSessionKey("PrintSightNoteAll", value);
        }
    }

    //裸視視力不良通知單(含戴鏡正常)
    public static int siPrint_Sight
    {
        get
        {
            if (GetSessionKey("Print_Sight") != null)
            {
                return int.Parse(GetSessionKey("Print_Sight").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("Print_Sight", value);
        }
    }

    public static bool bRecomHeight
    {
        get
        {
            return ((GetSessionKey("RecomHeight") != null) && ((bool)GetSessionKey("RecomHeight")));
        }
        set
        {
            SetSessionKey("RecomHeight", value);
        }
    }

    public static bool bRecomWeight
    {
        get
        {
            return ((GetSessionKey("RecomWeight") != null) && ((bool)GetSessionKey("RecomWeight")));
        }
        set
        {
            SetSessionKey("RecomWeight", value);
        }
    }

    public static DataSet dsWHClass
    {
        get
        {
            if (GetSessionKey("dsWHClass") != null)
            {
                return (DataSet)GetSessionKey("dsWHClass");
            }
            return null;
        }
        set
        {
            SetSessionKey("dsWHClass", value);
        }
    }

    public static enSchoolRank eSchoolRank
    {
        get
        {
            return (enSchoolRank)int.Parse(GetSessionKey("SchoolRank").ToString());
        }
        set
        {
            SetSessionKey("SchoolRank", (int)value);
            SetMaxMinGradeID();
        }
    }

    public static int iMaxGradeIDApp
    {
        get
        {
            string sKey = "MaxGradeIDApp";
            return Util.StrToInt(GetAppKey(sKey).ToString());
        }
    }

    public static bool mustChangeSchoolPW
    {
        get
        {
            return ((GetSessionKey("mustChangeSchoolPW") != null) && ((bool)GetSessionKey("mustChangeSchoolPW")));
        }
        set
        {
            SetSessionKey("mustChangeSchoolPW", value);
        }
    }

    public static TRedirectInfo RedirectInfo
    {
        get
        {
            return (TRedirectInfo)GetSessionKey("RedirectInfo");
        }
        set
        {
            SetSessionKey("RedirectInfo", value);
        }
    }

    public static string sAd
    {
        get
        {
            if (GetSessionKey("Ad") != null)
            {
                return GetSessionKey("Ad").ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("Ad", value);
        }
    }

    public static string sCenterMsg
    {
        get
        {
            string sKey = "CenterMsg";
            if (GetAppKey(sKey) != null)
            {
                return GetAppKey(sKey).ToString();
            }
            return string.Empty;
        }
        set
        {
            string sKey = "CenterMsg";
            SetAppKey(sKey, value);
        }
    }

    public static string sDatabaseVer
    {
        get
        {
            string sKey = "DatabaseVer";
            return GetSessionKey(sKey).ToString();
        }
    }
    /*
    public static TAppState seAppState
    {
        get
        {
            string str = "AppState";
            TAppState noSystemSet = TAppState.NoSystemSet;
            try
            {
                noSystemSet = (TAppState)int.Parse(HttpContext.Current.Session[str].ToString());
            }
            catch (Exception exception)
            {
                //logger.Info(exception);
            }
            return noSystemSet;
        }
        set
        {
            string sKey = "AppState";
            int num = (int)value;
            SetSessionKey(sKey, num.ToString());
            UpdateKeyToDb(sKey, num.ToString());
        }
    }
    */

    public static string sGovConnStr
    {
        get
        {
            if (GetSessionKey("GovConnStr") != null)
            {
                return GetSessionKey("MyConnStr").ToString();
            }
            return ConfigurationManager.ConnectionStrings["RawDataBase"].ToString();
        }
        set
        {
            SetSessionKey("GovConnStr", value);
        }
    }

    public static int siBeginYears
    {
        get
        {
            return int.Parse(GetSessionKey("BeginYears").ToString());
        }
        set
        {
            SetSessionKey("BeginYears", value);
        }
    }

    public static int siCheckGradeIDSel
    {
        get
        {
            if (GetSessionKey("CheckGradeIDSel") != null)
            {
                return int.Parse(GetSessionKey("CheckGradeIDSel").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("CheckGradeIDSel", value);
        }
    }

    public static int siClassIDSel
    {
        get
        {
            if (GetSessionKey("ClassIDSel") != null)
            {
                return int.Parse(GetSessionKey("ClassIDSel").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("ClassIDSel", value);
        }
    }

    public static int siEndYears
    {
        get
        {
            return int.Parse(GetSessionKey("EndYears").ToString());
        }
        set
        {
            SetSessionKey("EndYears", value);
        }
    }

    public static short siEnterYearsDiff
    {
        get
        {
            return short.Parse(GetSessionKey("EnterYearsDiff").ToString());
        }
        set
        {
            SetSessionKey("EnterYearsDiff", value);
        }
    }

    public static int siGradeIDSel
    {
        get
        {
            if (GetSessionKey("GradeIDSel") != null)
            {
                return int.Parse(GetSessionKey("GradeIDSel").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("GradeIDSel", value);
        }
    }

    public static int siGradeMaxYears
    {
        get
        {
            if (GetSessionKey("GradeMaxYears") != null)
            {
                return int.Parse(GetSessionKey("GradeMaxYears").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("GradeMaxYears", value);
        }
    }

    public static int siMaxGradeID
    {
        get
        {
            return int.Parse(GetSessionKey("MaxGradeID").ToString());
        }
        set
        {
            SetSessionKey("MaxGradeID", value);
        }
    }

    public static int siMinGradeID
    {
        get
        {
            return int.Parse(GetSessionKey("MinGradeID").ToString());
        }
        set
        {
            SetSessionKey("MinGradeID", value);
        }
    }

    public static string sInsuID
    {
        get
        {
            if (GetSessionKey("InsuID") != null)
            {
                return GetSessionKey("InsuID").ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("InsuID", value);
        }
    }

    public static string sInsuranceVendor
    {
        get
        {
            string sKey = "InsuranceVendor";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static int siSchYearClassPre
    {
        get
        {
            if (GetSessionKey("SchYearClassPre") != null)
            {
                return int.Parse(GetSessionKey("SchYearClassPre").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("SchYearClassPre", value);
        }
    }

    public static int siSchYearsNow
    {
        get
        {
            if (GetSessionKey("SchYearsNow") != null)
            {
                return int.Parse(GetSessionKey("SchYearsNow").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("SchYearsNow", value);
        }
    }

    public static int siSchYearsSel
    {
        get
        {
            int siSchYearsNow = Se.siSchYearsNow;
            string sKey = "SchYearsSel";
            object sessionKey = GetSessionKey(sKey);
            if (sessionKey == null)
            {
                siSchYearsSel = Se.siSchYearsNow;
                return siSchYearsNow;
            }
            return Util.StrToInt(sessionKey.ToString());
        }
        set
        {
            SetSessionKey("SchYearsSel", value);
            SetMaxMinGradeID();
            switch (eSchoolRank)
            {
                case enSchoolRank.Primary:
                    siGradeMaxYears = value - 5;
                    break;

                case enSchoolRank.Junior:
                    siGradeMaxYears = value - 8;
                    break;

                case enSchoolRank.JuniorPrimary:
                    siGradeMaxYears = value - 8;
                    break;

                default:
                    siGradeMaxYears = 0;
                    break;
            }
        }
    }

    public static int siSemClassNow
    {
        get
        {
            if (GetSessionKey("SemClassNow") != null)
            {
                return int.Parse(GetSessionKey("SemClassNow").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("SemClassNow", value);
            if (value == 1)
            {
                siSemClassPre = 2;
                siSchYearClassPre = siSchYearsNow - 1;
                int oValue = siGradeIDSel - 1;
                if (oValue < siMinGradeID)
                {
                    oValue = siMinGradeID;
                    siSemClassPre = 1;
                }
                SetSessionKey(ssiGradeIDClassPre, oValue);
            }
            else
            {
                siSemClassPre = 1;
                siSchYearClassPre = siSchYearsNow;
                SetSessionKey(ssiGradeIDClassPre, siGradeIDSel);
            }
        }
    }

    public static int siSemClassPre
    {
        get
        {
            if (GetSessionKey("SemClassPre") != null)
            {
                return int.Parse(GetSessionKey("SemClassPre").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("SemClassPre", value);
        }
    }

    public static int siSemNow
    {
        get
        {
            if (GetSessionKey("SemNow") != null)
            {
                return int.Parse(GetSessionKey("SemNow").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("SemNow", value);
        }
    }

    public static int siSemSel
    {
        get
        {
            int siSemNow = Se.siSemNow;
            string sKey = "SemSel";
            object sessionKey = GetSessionKey(sKey);
            if (sessionKey == null)
            {
                siSemSel = Se.siSemNow;
                return siSemNow;
            }
            return Util.StrToInt(sessionKey.ToString());
        }
        set
        {
            SetSessionKey("SemSel", value);
        }
    }

    public static short siYearsSel
    {
        get
        {
            if (GetSessionKey("YearsSel") != null)
            {
                return short.Parse(GetSessionKey("YearsSel").ToString());
            }
            return 0;
        }
        set
        {
            SetSessionKey("YearsSel", value);
        }
    }

    public static string sMyConnStr
    {
        get
        {
            if (GetSessionKey("MyConnStr") != null)
            {
                return GetSessionKey("MyConnStr").ToString();
            }
            return Settings.Default.Health.ToString();
        }
        set
        {
            SetSessionKey("MyConnStr", value);
        }
    }

    public static string sNurseEMail
    {
        get
        {
            string sKey = "NurseEMail";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sNurseName
    {
        get
        {
            string sKey = "NurseName";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sPIDSel
    {
        get
        {
            string sKey = "PIDSel";
            if (GetSessionKey(sKey) != null)
            {
                return GetSessionKey(sKey).ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("PIDSel", value);
        }
    }

    public static string sPreviousPage
    {
        get
        {
            if (GetSessionKey("PreviousPage") != null)
            {
                return GetSessionKey("PreviousPage").ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("PreviousPage", value);
        }
    }

    public static string sPWUpload
    {
        get
        {
            if (GetSessionKey("PWUpload") != null)
            {
                return GetSessionKey("PWUpload").ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("PWUpload", value);
        }
    }

    public static string ssAddress
    {
        get
        {
            string sKey = "Address";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sSchoolFax
    {
        get
        {
            string sKey = "DatabSchoolFaxaseVer";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sSchoolID
    {
        get
        {
            string sKey = "SchoolID";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sSchoolName
    {
        get
        {
            string sKey = "SchoolName";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sSchoolTel
    {
        get
        {
            string sKey = "SchoolTel";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sSchoolZip
    {
        get
        {
            string sKey = "SchoolZip";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static string sScriptXFooter
    {
        get
        {
            if (GetSessionKey("ScriptXFooter") != null)
            {
                return GetSessionKey("ScriptXFooter").ToString();
            }
            return "學生健康資訊系統!";
        }
        set
        {
            SetSessionKey("ScriptXFooter", value);
        }
    }

    public static string sScriptXHeader
    {
        get
        {
            if (GetSessionKey("ScriptXHeader") != null)
            {
                return GetSessionKey("ScriptXHeader").ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("ScriptXHeader", value);
        }
    }

    /*
    public static dsSt.vStAllRow sSt
    {
        get
        {
            if (HttpContext.Current.Session["sSt"] != null)
            {
                return (dsSt.vStAllRow)HttpContext.Current.Session["sSt"];
            }
            return null;
        }
        set
        {
            HttpContext.Current.Session["sSt"] = value;
        }
    }
    */

    public static string ssVocSel
    {
        get
        {
            string str = "0";
            string sKey = "VocSel";
            object sessionKey = GetSessionKey(sKey);
            if (sessionKey != null)
            {
                str = sessionKey.ToString();
            }
            return str;
        }
        set
        {
            SetSessionKey("VocSel", value);
        }
    }

    public static string sTeeString
    {
        get
        {
            if (GetSessionKey("TeeString") != null)
            {
                return GetSessionKey("TeeString").ToString();
            }
            return null;
        }
        set
        {
            SetSessionKey("TeeString", value);
        }
    }

    public static string sTelExt
    {
        get
        {
            string sKey = "TelExt";
            return GetSessionKey(sKey).ToString();
        }
    }

    public static Hashtable UpTables
    {
        get
        {
            if (HttpContext.Current.Application["UpTables"] == null)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("wh", "身高體重");
                hashtable.Add("sight", "視力");
                hashtable.Add("tee", "口腔");
                hashtable.Add("checks", "全身健檢");
                hashtable.Add("fluor", "含氟水漱口");
                hashtable.Add("disease", "個人疾病史");
                hashtable.Add("acc", "傷病");
                hashtable.Add("solid", "立體感異常");
                hashtable.Add("lab", "實驗室檢查");
                hashtable.Add("bloodcheck", "血液檢查");
                hashtable.Add("xray", "X光檢查");
                HttpContext.Current.Application["UpTables"] = hashtable;
            }
            return (Hashtable)HttpContext.Current.Application["UpTables"];
        }
    }

    public enum TAppState
    {
        DBVerError = 6,
        NoSystemSet = -1,
        OK = 0,
        TransStep1 = 1,
        TransStep2 = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TRedirectInfo
    {
        public string sMsg;
        public string sUrl;
        public string sMsg1;
        public string sUrl1;
    }
}