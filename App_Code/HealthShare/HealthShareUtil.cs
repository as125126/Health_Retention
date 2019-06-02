public class HealthShareUtil
{
    public static int YearsToGradeID(int iYears)
    {
        int siSchYearsNow = Se.siSchYearsNow;
        enSchoolRank eSchoolRank = Se.eSchoolRank;
        return YearsToGradeID(iYears, siSchYearsNow, eSchoolRank);
    }
    public static int YearsToGradeID(int iYears, int SchYearsNow, enSchoolRank enRank)
    {
        int num = (SchYearsNow - iYears) + 1;
        if (num > 13)
        {
            num = iYears;
        }
        if (num < 1)
        {
            num = 0;
        }
        return num;
    }
    public static string AboriginePID(object oPID, object oAborigine)
    {
        int num = 0;
        if ((oAborigine != null) && (oAborigine.ToString() == "1"))
        {
            num = 1;
        }
        string str2 = oPID.ToString();
        if (num != 0)
        {
            str2 = "*" + str2;
        }
        return str2;
    }
}