using System;
using System.Collections;
using System.Web.UI;

namespace WillNs
{
    public class Util
    {
        public static short StrToShort(string sResult)
        {
            return ((short)StrToInt(sResult));
        }
        public static int StrToInt(string sResult)
        {
            int rv = 0;
            if ((sResult != null) && (sResult != string.Empty))
            {
                try
                {
                    rv = int.Parse(sResult);
                }
                catch (Exception ex)
                {
                    //logger.Info(ex.Message);
                    rv = 0;
                }
            }
            if (sResult.ToLower() == "true")
                rv = 1;

            return rv;
        }
        public static int ROCIDSex(string ID)
        {
            /*
		     * 0 錯誤 
		     * 1男
		     * 2女
             *
		    */

            /*
一、統一證號編列規則：
共計十碼，第一碼為區域碼(同國民身分證)、第二碼為性別碼(入出境管理局使用ＡＢ；警察局外事科/課使用ＣＤ)、第三至九碼為流水號、第十碼為檢查號碼。
二、檢查號碼計算規則：
第一碼英文字母轉換為二位數字碼(轉換之數字與國民身分證同)，分別乘以特定數；第二碼英文字母轉換成二位數字後，只取尾數乘以特定數；餘第三～九碼，亦分別乘以特定數。檢查號碼＝10－相乘後個位數相加總和之尾數。惟若相乘後個位數相加總和尾數為0，則逕以「0」為檢查號碼。
舉例：FA12345689
(Ｆ：轉換為15，Ａ轉換為10─＞取尾數「0」)
【第一碼區域及第二碼性別之英文碼，先依據下列數字表換算，惟性別轉換後之二位數字碼，只取尾數。】

A B C D E F G H J K L M N P
10 11 12 13 14 15 16 17 18 19 20 21 22 23
Q R S T U V X Y W Z I O 
24 25 26 27 28 29 30 31 32 33 34 35 

1501234568(統 號)
×1987654321(特定數)
1507256528(不進位)

1＋5＋0＋7＋2＋5＋6＋5＋2＋8
＝41(將相乘後個位數相加)
「41」(取尾數1───若尾數為0，則逕以「0」為檢查號碼)
檢查號碼＝10－1＝9
三、基資登錄標準：
依據機器可判讀護照(Machine Readable Passport，簡稱ＭＲＰ護照)之編列規則登錄個人基本資料(先姓後名，姓名及護照號碼均不准登錄標點符號)。
四、新舊居留證號轉碼方式：
例：舊號：A123456 ──>新號：AC01234567
說明：第一碼維持不變；第二碼依實際性別轉換為C或D；第三碼補０；第四至九碼帶入舊號之六位數流水號碼；第十碼依據前述檢查號碼計算規則計算得出。
統一證號編碼規則雖非機密資料，但仍請限目的內使用。
from:警政署外事組
             
            */
            int iSexID = 0;

            int iCheck; //0正確
                        // 注意 並不完全有規則
            int[] y = new int[26] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };


            ArrayList IDLetters = new ArrayList();
            for (char i = 'A'; i <= 'Z'; i++)
                IDLetters.Add(i);
            if ((ID == "") | (ID == null))
                return iSexID;

            char FirstChar = ID[0];
            char SecChar = ID[1];
            if ((ID.Length == 10) && (IDLetters.Contains(FirstChar)))
            {
                if ((SecChar == '1') | (SecChar == '2') | (SecChar == 'A') | (SecChar == 'B') | (SecChar == 'C') | (SecChar == 'D'))
                {
                    int nValue = FirstChar - 'A' + 1;//error 字母和數字的對照並不按照規則
                    nValue = y[nValue - 1];
                    int x1 = (nValue / 10) * 1;
                    int x2 = (nValue % 10) * 9;


                    string sNum = ID.Substring(2, 8);
                    if (Util.IsInteger(sNum))
                    {

                        int d1 = 0;
                        if ((SecChar == 'C') | (SecChar == 'D') | (SecChar == 'A') | (SecChar == 'B'))
                        {

                            int nValue2 = SecChar - 'A' + 1;//error 字母和數字的對照並不按照規則
                            nValue2 = y[nValue2 - 1];
                            d1 = (nValue2 % 10) * 8;

                        }
                        else
                        {
                            d1 = (int.Parse(ID[1].ToString())) * 8;


                        }

                        int d2 = (int.Parse(ID[2].ToString())) * 7;

                        int d3 = (int.Parse(ID[3].ToString())) * 6;
                        int d4 = (int.Parse(ID[4].ToString())) * 5;
                        int d5 = (int.Parse(ID[5].ToString())) * 4;
                        int d6 = (int.Parse(ID[6].ToString())) * 3;
                        int d7 = (int.Parse(ID[7].ToString())) * 2;
                        int d8 = (int.Parse(ID[8].ToString())) * 1;
                        int d9 = (int.Parse(ID[9].ToString())) * 1;
                        iCheck = (x1 + x2 + d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9);
                        //MessageBox.Show (x1.ToString()+" "+ x2.ToString()+" "+ d1.ToString()+" "+ d2.ToString()+" "
                        //	+ d3.ToString()+" "+ d4.ToString()+" "+ d5.ToString()+" "+ d6.ToString()+" "+ d7.ToString()+" "+ d8.ToString()+" "+ d9.ToString());
                        iCheck = iCheck % 10;
                        if (iCheck == 0)
                        {
                            if ((SecChar == 'A') | (SecChar == 'C')) SecChar = '1';
                            if ((SecChar == 'B') | (SecChar == 'D')) SecChar = '2';

                            iSexID = int.Parse(SecChar.ToString());

                        }
                    }


                }
            }
            return iSexID;
        }
        public static bool IsInteger(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (s[i] < '0' || s[i] > '9')
                    return false;
            return true;
        }

        public static void alert(Page myPage, string sMsg)
        {
            //SetFocus
            string myScritpt;
            myScritpt = "<script> window.alert('" + sMsg + "');</script>";

            myPage.RegisterStartupScript("", myScritpt);
        }
    }
}