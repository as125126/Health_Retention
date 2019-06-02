using HealthShare;
using HealthShare.OthersTableAdapters;

public class HealthInfo
{
    #region asHealthTables_StFirst
    public static string[] asHealthTables_StFirst
    {
        get
        {
            Others.TableHealthDataTable data = new TableHealthTableAdapter { Connection = { ConnectionString = Se.sMyConnStr } }.GetData();
            string[] strArray = new string[data.Rows.Count + 1];
            strArray[0] = "St";
            int num2 = 1;
            foreach (Others.TableHealthRow row in data.Rows)
            {
                strArray[num2++] = row.TableName;
            }
            return strArray;
        }
    }
    #endregion
}