namespace HealthShare
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using WillNs;
    [Serializable, HelpKeyword("vs.data.DataSet"), DesignerCategory("code"), XmlRoot("dsSt"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema")]
    public class dsSt : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private AborigineDataTable tableAborigine;
        private GuyIDDataTable tableGuyID;
        private MemosDataTable tableMemos;
        private MigrateDataTable tableMigrate;
        private StSeatSameDataTable tableStSeatSame;
        private vStDataTable tablevSt;
        private vStaDataTable tablevSta;
        private vStAllDataTable tablevStAll;

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public dsSt()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected dsSt(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
            else
            {
                string s = (string)info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["StSeatSame"] != null)
                    {
                        base.Tables.Add(new StSeatSameDataTable(dataSet.Tables["StSeatSame"]));
                    }
                    if (dataSet.Tables["GuyID"] != null)
                    {
                        base.Tables.Add(new GuyIDDataTable(dataSet.Tables["GuyID"]));
                    }
                    if (dataSet.Tables["vSt"] != null)
                    {
                        base.Tables.Add(new vStDataTable(dataSet.Tables["vSt"]));
                    }
                    if (dataSet.Tables["Migrate"] != null)
                    {
                        base.Tables.Add(new MigrateDataTable(dataSet.Tables["Migrate"]));
                    }
                    if (dataSet.Tables["Aborigine"] != null)
                    {
                        base.Tables.Add(new AborigineDataTable(dataSet.Tables["Aborigine"]));
                    }
                    if (dataSet.Tables["Memos"] != null)
                    {
                        base.Tables.Add(new MemosDataTable(dataSet.Tables["Memos"]));
                    }
                    if (dataSet.Tables["vSta"] != null)
                    {
                        base.Tables.Add(new vStaDataTable(dataSet.Tables["vSta"]));
                    }
                    if (dataSet.Tables["vStAll"] != null)
                    {
                        base.Tables.Add(new vStAllDataTable(dataSet.Tables["vStAll"]));
                    }
                    base.DataSetName = dataSet.DataSetName;
                    base.Prefix = dataSet.Prefix;
                    base.Namespace = dataSet.Namespace;
                    base.Locale = dataSet.Locale;
                    base.CaseSensitive = dataSet.CaseSensitive;
                    base.EnforceConstraints = dataSet.EnforceConstraints;
                    base.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
        }

        #region 新增「視力」、「口腔」、「身高體重」、「血液檢查」、「健康檢查」、「實驗室檢查」與「X光檢查」資料
        /// <summary>
        /// 新增「視力」、「口腔」、「身高體重」、「血液檢查」、「健康檢查」、「實驗室檢查」與「X光檢查」資料
        /// </summary>
        /// <param name="sPID">學生編號</param>
        /// <param name="iYears">學年</param>
        public void AddHealthData(string sPID, int iYears)
        {
            int ExceptionCount = 0;
            SqlConnection connection = new SqlConnection(Se.sMyConnStr);
            SqlCommand command = new SqlCommand();
            SqlCommand command2 = new SqlCommand();
            sPID = sPID.Trim();

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command2.Connection = connection;
            command2.CommandType = CommandType.Text;

            #region 將臨時證號紀錄於 Others 中
            if (Util.ROCIDSex(sPID) == 0)
            {
                try
                {
                    DM.ExecuteNonQuery(string.Format("Insert into Others (PID, KindID) values ('{0}','{1}') ", sPID, "NotPID"));
                }
                catch (Exception exception)
                {
                    
                }
            }
            #endregion

            #region 新增「視力」、「口腔」與「身高體重」資料
            DataTableReader reader = DM.ExecuteReader("Select TableName, SchoolDegree from TableHealth where TableType=1");//取得「視力」、「口腔」與「身高體重」資料表名稱

            while (reader.Read())
            {
                int Grade = 1;//年級
                int iMaxGradeIDApp = Se.iMaxGradeIDApp;//最高年級

                //設定資料表名稱
                command.CommandText = string.Format("Insert into {0} (PID, GradeID, Sem) values (@PID, @GradeID, @Sem)", reader["TableName"].ToString());
                command2.CommandText = string.Format("Select count(*) from {0} where PID= @PID and  GradeID= @GradeID and Sem= @Sem", reader["TableName"].ToString());

                //新增資料
                while (Grade <= iMaxGradeIDApp)//設定每學期資料
                {
                    for (int i = 1; i < 3; i++)//設定每學期資料
                    {
                        try
                        {
                            //以PID、GradeID 與 Sem 為參數查詢資料
                            command2.Parameters.Clear();
                            command2.Parameters.AddWithValue("PID", sPID);
                            command2.Parameters.AddWithValue("GradeID", Grade);
                            command2.Parameters.AddWithValue("Sem", i);
                            int num6 = (int)command2.ExecuteScalar();

                            //資料如不存在時新增資料
                            if (num6 == 0)
                            {
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("PID", sPID);
                                command.Parameters.AddWithValue("GradeID", Grade);
                                command.Parameters.AddWithValue("Sem", i);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (SqlException)
                        {
                            ExceptionCount++;
                        }
                    }
                    Grade++;
                }
            }
            reader.Close();
            #endregion

            #region 新增「血液檢查」、「健康檢查」、「實驗室檢查」與「X光檢查」資料
            reader = DM.ExecuteReader("Select TableName, SchoolDegree from TableHealth where TableType=2");//取得「血液檢查」、「健康檢查」、「實驗室檢查」與「X光檢查」資料表名稱

            while (reader.Read())
            {
                //int num7 = int.Parse(reader["SchoolDegree"].ToString());
                int iMaxGradeIDApp = Se.iMaxGradeIDApp == 13 ? 10 : Se.iMaxGradeIDApp;

                for (int Grade = 1; Grade <= iMaxGradeIDApp; Grade += 3)
                {
                    command.CommandText = string.Format("Insert into {0} (PID, GradeID) values (@PID, @GradeID)", reader["TableName"].ToString());//設定資料表名稱
                    try
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("PID", sPID);
                        command.Parameters.AddWithValue("GradeID", Grade);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        ExceptionCount++;
                    }
                }
            }
            reader.Close();
            #endregion

            connection.Close();

            /*
            //疫苗
            if (iYears >= 0x65)
            {
                new InjectRegularTableAdapter { Connection = { ConnectionString = Se.sMyConnStr } }.InsertInjectRegular(sPID, iYears, true, true);
            }
            else
            {
                new InjectTableAdapter { Connection = { ConnectionString = Se.sMyConnStr } }.InsertSt(sPID);
            }
            */
        }
        #endregion

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public override DataSet Clone()
        {
            dsSt st = (dsSt)base.Clone();
            st.InitVars();
            st.SchemaSerializationMode = this.SchemaSerializationMode;
            return st;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            dsSt st = new dsSt();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny
            {
                Namespace = st.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = st.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema)enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitClass()
        {
            base.DataSetName = "dsSt";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/dsSt.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableStSeatSame = new StSeatSameDataTable();
            base.Tables.Add(this.tableStSeatSame);
            this.tableGuyID = new GuyIDDataTable();
            base.Tables.Add(this.tableGuyID);
            this.tablevSt = new vStDataTable();
            base.Tables.Add(this.tablevSt);
            this.tableMigrate = new MigrateDataTable();
            base.Tables.Add(this.tableMigrate);
            this.tableAborigine = new AborigineDataTable();
            base.Tables.Add(this.tableAborigine);
            this.tableMemos = new MemosDataTable();
            base.Tables.Add(this.tableMemos);
            this.tablevSta = new vStaDataTable();
            base.Tables.Add(this.tablevSta);
            this.tablevStAll = new vStAllDataTable();
            base.Tables.Add(this.tablevStAll);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableStSeatSame = (StSeatSameDataTable)base.Tables["StSeatSame"];
            if (initTable && (this.tableStSeatSame != null))
            {
                this.tableStSeatSame.InitVars();
            }
            this.tableGuyID = (GuyIDDataTable)base.Tables["GuyID"];
            if (initTable && (this.tableGuyID != null))
            {
                this.tableGuyID.InitVars();
            }
            this.tablevSt = (vStDataTable)base.Tables["vSt"];
            if (initTable && (this.tablevSt != null))
            {
                this.tablevSt.InitVars();
            }
            this.tableMigrate = (MigrateDataTable)base.Tables["Migrate"];
            if (initTable && (this.tableMigrate != null))
            {
                this.tableMigrate.InitVars();
            }
            this.tableAborigine = (AborigineDataTable)base.Tables["Aborigine"];
            if (initTable && (this.tableAborigine != null))
            {
                this.tableAborigine.InitVars();
            }
            this.tableMemos = (MemosDataTable)base.Tables["Memos"];
            if (initTable && (this.tableMemos != null))
            {
                this.tableMemos.InitVars();
            }
            this.tablevSta = (vStaDataTable)base.Tables["vSta"];
            if (initTable && (this.tablevSta != null))
            {
                this.tablevSta.InitVars();
            }
            this.tablevStAll = (vStAllDataTable)base.Tables["vStAll"];
            if (initTable && (this.tablevStAll != null))
            {
                this.tablevStAll.InitVars();
            }
        }

        public DataSet MigrateDs(string sPID)
        {
            DataSet dataSet = new DataSet("dsHealth");
            foreach (string str in HealthInfo.asHealthTables_StFirst)
            {
                string format = "Select * from {0} where PID= '{1}'";
                new SqlDataAdapter(string.Format(format, str, sPID), Se.sMyConnStr).Fill(dataSet, str);
            }
            return dataSet;
        }

        public int Change_PID_in_db(string[] oPID, string[] aPID)
        {
            int successCount = 0;
            SqlConnection conn = new SqlConnection(Se.sMyConnStr);
            conn.Open();
            SqlCommand command = new SqlCommand();
            SqlTransaction transaction;
            //Start Transaction
            transaction = conn.BeginTransaction();
            command.Connection = conn;
            command.Transaction = transaction;
            try
            {
                for (int i = 0; i < aPID.Length; i++)
                {
                    foreach (string str in HealthInfo.asHealthTables_StFirst)
                    {
                        if (aPID[i] != "")
                        {
                            command.CommandText = string.Format("UPDATE {0} SET PID = '{1}' WHERE PID = '{2}'", str, aPID[i], (oPID[i].Split('('))[0]);
                            successCount += command.ExecuteNonQuery();
                        }
                    }
                }
                //Commit
                transaction.Commit();
            }
            catch (Exception ex)
            {
                
                //有問題即Rollback
                transaction.Rollback();
                successCount = -1;
            }
            command.Connection.Close();
            conn.Close();
            return successCount;
        }

        public int insert_PIDChangelog(string strcom, string[] oPID, string[] aPID)
        {
            int successCount = 0;
            SqlConnection conn = new SqlConnection(Se.sMyConnStr);
            conn.Open();
            SqlCommand command = new SqlCommand();
            SqlTransaction transaction;
            //Start Transaction
            transaction = conn.BeginTransaction();
            command.Connection = conn;
            command.Transaction = transaction;
            try
            {
                for (int i = 0; i < aPID.Length; i++)
                {
                    if (aPID[i] != "")
                    {
                        command.CommandText = string.Format(strcom, aPID[i], (oPID[i].Split('('))[0], "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1");
                        successCount += command.ExecuteNonQuery();
                    }
                }
                //Commit
                transaction.Commit();
            }
            catch (Exception ex)
            {
                
                //有問題即Rollback
                transaction.Rollback();
                successCount = -1;
            }
            command.Connection.Close();
            conn.Close();
            return successCount;
        }

        //修改單一筆身分證字號
        public int Change_PID_insingle_db(string oPID, string aPID)
        {
            int successCount = 0;
            int oSexID = WillNs.Util.ROCIDSex(oPID);
            int aSexID = WillNs.Util.ROCIDSex(aPID);

            SqlConnection conn = new SqlConnection(Se.sMyConnStr);
            conn.Open();
            SqlCommand command = new SqlCommand();
            SqlTransaction transaction;
            //Start Transaction
            transaction = conn.BeginTransaction();
            command.Connection = conn;
            command.Transaction = transaction;
            try
            {
                foreach (string str in HealthInfo.asHealthTables_StFirst)
                {
                    if ((str == "St" || str == "Acc") && (oSexID != aSexID))
                    {
                        command.CommandText = string.Format("UPDATE {0} SET PID = '{1}' , SexID = '{2}' WHERE PID = '{3}'", str, aPID, aSexID, oPID);
                    }
                    else
                    {
                        command.CommandText = string.Format("UPDATE {0} SET PID = '{1}' WHERE PID = '{2}'", str, aPID, oPID);
                    }
                    successCount += command.ExecuteNonQuery();

                }
                //Commit
                command.CommandText = string.Format("update Health.dbo.SuspectErrorStudentList set PID='{0}',EPID= Health.dbo.encryptPID('{0}') where PID='{1}' ", aPID, oPID);
                successCount += command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                
                //有問題即Rollback
                transaction.Rollback();
                successCount = -1;
            }
            command.Connection.Close();
            conn.Close();
            return successCount;
        }

        //新增單一筆身分證修改紀錄
        public int insert_insingle_PIDChangelog(string sSchoolID, string oPID, string aPID)
        {
            //校護端紀錄
            string sqlcomSSHIS = "INSERT INTO [Health].[dbo].[PIDChangeLog] ([schoolID],[oldPID],[newPID],[successCount],[updateTime],[Sync]) VALUES ('{0}','{1}','{2}','1','{3}','1')";

            int successCount = 0;
            SqlConnection conn = new SqlConnection(Se.sMyConnStr);
            conn.Open();
            SqlCommand command = new SqlCommand();
            SqlTransaction transaction;
            //Start Transaction
            transaction = conn.BeginTransaction();
            command.Connection = conn;
            command.Transaction = transaction;
            try
            {
                if (aPID != "")
                {
                    command.CommandText = string.Format(sqlcomSSHIS, sSchoolID, oPID, aPID, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    successCount += command.ExecuteNonQuery();
                }

                //Commit
                transaction.Commit();
            }
            catch (Exception ex)
            {
                
                //有問題即Rollback
                transaction.Rollback();
                successCount = -1;
            }
            command.Connection.Close();
            conn.Close();
            return successCount;
        }

        public int MigrateStDataPump(DataSet ds, out string sMsg)
        {
            sMsg = "ok";
            DataTable table = ds.Tables["St"];
            DataRow row = table.Rows[0];
            string sPID = row["PID"].ToString();
            int num = 0;
            SqlConnection connection = new SqlConnection(Se.sMyConnStr);
            connection.Open();
            SqlTransaction externalTransaction = connection.BeginTransaction();
            SqlBulkCopy copy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, externalTransaction);
            try
            {
                foreach (DataTable table2 in ds.Tables)
                {
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        if (!(table2.Rows[0]["PID"].ToString() == sPID))
                        {
                            throw new ArgumentNullException();
                        }
                        copy.DestinationTableName = table2.TableName;
                        copy.ColumnMappings.Clear();

                        foreach (DataColumn column in table2.Columns)
                        {
                            copy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                        }

                        //紀錄實際資料，當執行中發生例外可用於進一步的測試與處理
                        StringBuilder data = new StringBuilder(table2.TableName + " 資料：");
                        foreach (DataRow dr in table2.Rows)
                        {
                            foreach (DataColumn dc in table2.Columns)
                                data.AppendFormat("{0} = {1},", dc.ColumnName, Convert.ToString(dr[dc.ColumnName]));
                        }
                        copy.WriteToServer(table2);
                    }
                    num++;
                }
                externalTransaction.Commit();
                int iYears = Util.StrToInt(row["Years"].ToString());
                int siGradeMaxYears = Se.siGradeMaxYears;
                this.AddHealthData(sPID, iYears);
            }
            catch (Exception exception)
            {
                
                externalTransaction.Rollback();
                num = 0;
                sMsg = exception.Message;
                throw new Exception(sMsg);
            }
            connection.Close();
            return num;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["StSeatSame"] != null)
                {
                    base.Tables.Add(new StSeatSameDataTable(dataSet.Tables["StSeatSame"]));
                }
                if (dataSet.Tables["GuyID"] != null)
                {
                    base.Tables.Add(new GuyIDDataTable(dataSet.Tables["GuyID"]));
                }
                if (dataSet.Tables["vSt"] != null)
                {
                    base.Tables.Add(new vStDataTable(dataSet.Tables["vSt"]));
                }
                if (dataSet.Tables["Migrate"] != null)
                {
                    base.Tables.Add(new MigrateDataTable(dataSet.Tables["Migrate"]));
                }
                if (dataSet.Tables["Aborigine"] != null)
                {
                    base.Tables.Add(new AborigineDataTable(dataSet.Tables["Aborigine"]));
                }
                if (dataSet.Tables["Memos"] != null)
                {
                    base.Tables.Add(new MemosDataTable(dataSet.Tables["Memos"]));
                }
                if (dataSet.Tables["vSta"] != null)
                {
                    base.Tables.Add(new vStaDataTable(dataSet.Tables["vSta"]));
                }
                if (dataSet.Tables["vStAll"] != null)
                {
                    base.Tables.Add(new vStAllDataTable(dataSet.Tables["vStAll"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeAborigine()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeGuyID()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeMemos()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeMigrate()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeStSeatSame()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializevSt()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializevSta()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializevStAll()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DebuggerNonUserCode]
        public AborigineDataTable Aborigine
        {
            get
            {
                return this.tableAborigine;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public GuyIDDataTable GuyID
        {
            get
            {
                return this.tableGuyID;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public MemosDataTable Memos
        {
            get
            {
                return this.tableMemos;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public MigrateDataTable Migrate
        {
            get
            {
                return this.tableMigrate;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DebuggerNonUserCode, Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public StSeatSameDataTable StSeatSame
        {
            get
            {
                return this.tableStSeatSame;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public vStDataTable vSt
        {
            get
            {
                return this.tablevSt;
            }
        }

        [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public vStaDataTable vSta
        {
            get
            {
                return this.tablevSta;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public vStAllDataTable vStAll
        {
            get
            {
                return this.tablevStAll;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class AborigineDataTable : TypedTableBase<dsSt.AborigineRow>
        {
            private DataColumn columnClass;
            private DataColumn columncSex;
            private DataColumn columnGrade;
            private DataColumn columnGuy;
            private DataColumn columnGuyID;
            private DataColumn columnPID;
            private DataColumn columnSeat;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.AborigineRowChangeEventHandler AborigineRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.AborigineRowChangeEventHandler AborigineRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.AborigineRowChangeEventHandler AborigineRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.AborigineRowChangeEventHandler AborigineRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public AborigineDataTable()
            {
                base.TableName = "Aborigine";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal AborigineDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected AborigineDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddAborigineRow(dsSt.AborigineRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.AborigineRow AddAborigineRow(string PID, string Guy, short Years, short Seat, string GuyID, string cSex, string Grade, string Class)
            {
                dsSt.AborigineRow row = (dsSt.AborigineRow)base.NewRow();
                row.ItemArray = new object[] { PID, Guy, Years, Seat, GuyID, cSex, Grade, Class };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSt.AborigineDataTable table = (dsSt.AborigineDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSt.AborigineDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.AborigineRow FindByPID(string PID)
            {
                return (dsSt.AborigineRow)base.Rows.Find(new object[] { PID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSt.AborigineRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "AborigineDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnGuyID = new DataColumn("GuyID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuyID);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnYears.AllowDBNull = false;
                this.columnGuyID.MaxLength = 10;
                this.columncSex.MaxLength = 2;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnYears = base.Columns["Years"];
                this.columnSeat = base.Columns["Seat"];
                this.columnGuyID = base.Columns["GuyID"];
                this.columncSex = base.Columns["cSex"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.AborigineRow NewAborigineRow()
            {
                return (dsSt.AborigineRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.AborigineRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.AborigineRowChanged != null)
                {
                    this.AborigineRowChanged(this, new dsSt.AborigineRowChangeEvent((dsSt.AborigineRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.AborigineRowChanging != null)
                {
                    this.AborigineRowChanging(this, new dsSt.AborigineRowChangeEvent((dsSt.AborigineRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.AborigineRowDeleted != null)
                {
                    this.AborigineRowDeleted(this, new dsSt.AborigineRowChangeEvent((dsSt.AborigineRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.AborigineRowDeleting != null)
                {
                    this.AborigineRowDeleting(this, new dsSt.AborigineRowChangeEvent((dsSt.AborigineRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveAborigineRow(dsSt.AborigineRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassColumn
            {
                get
                {
                    return this.columnClass;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeColumn
            {
                get
                {
                    return this.columnGrade;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyIDColumn
            {
                get
                {
                    return this.columnGuyID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.AborigineRow this[int index]
            {
                get
                {
                    return (dsSt.AborigineRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }
        }

        public class AborigineRow : DataRow
        {
            private dsSt.AborigineDataTable tableAborigine;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal AborigineRow(DataRowBuilder rb) : base(rb)
            {
                this.tableAborigine = (dsSt.AborigineDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableAborigine.ClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IscSexNull()
            {
                return base.IsNull(this.tableAborigine.cSexColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableAborigine.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyIDNull()
            {
                return base.IsNull(this.tableAborigine.GuyIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tableAborigine.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableAborigine.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tableAborigine.ClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetcSexNull()
            {
                base[this.tableAborigine.cSexColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tableAborigine.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyIDNull()
            {
                base[this.tableAborigine.GuyIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tableAborigine.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tableAborigine.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableAborigine.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'Aborigine' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableAborigine.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string cSex
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableAborigine.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'Aborigine' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableAborigine.cSexColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Grade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableAborigine.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'Aborigine' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableAborigine.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableAborigine.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'Aborigine' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableAborigine.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GuyID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableAborigine.GuyIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GuyID' in table 'Aborigine' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableAborigine.GuyIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string)base[this.tableAborigine.PIDColumn];
                }
                set
                {
                    base[this.tableAborigine.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableAborigine.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'Aborigine' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableAborigine.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableAborigine.YearsColumn];
                }
                set
                {
                    base[this.tableAborigine.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class AborigineRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.AborigineRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public AborigineRowChangeEvent(dsSt.AborigineRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.AborigineRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void AborigineRowChangeEventHandler(object sender, dsSt.AborigineRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class GuyIDDataTable : TypedTableBase<dsSt.GuyIDRow>
        {
            private DataColumn columnBirthday;
            private DataColumn columnClassID;
            private DataColumn columnGuy;
            private DataColumn columnGuyID;
            private DataColumn columnPID;
            private DataColumn columnSeat;
            private DataColumn columnSexID;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.GuyIDRowChangeEventHandler GuyIDRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.GuyIDRowChangeEventHandler GuyIDRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.GuyIDRowChangeEventHandler GuyIDRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.GuyIDRowChangeEventHandler GuyIDRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public GuyIDDataTable()
            {
                base.TableName = "GuyID";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal GuyIDDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected GuyIDDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddGuyIDRow(dsSt.GuyIDRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.GuyIDRow AddGuyIDRow(string PID, string Guy, short SexID, short Seat, DateTime Birthday, short Years, short ClassID, string GuyID)
            {
                dsSt.GuyIDRow row = (dsSt.GuyIDRow)base.NewRow();
                row.ItemArray = new object[] { PID, Guy, SexID, Seat, Birthday, Years, ClassID, GuyID };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSt.GuyIDDataTable table = (dsSt.GuyIDDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSt.GuyIDDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.GuyIDRow FindByPID(string PID)
            {
                return (dsSt.GuyIDRow)base.Rows.Find(new object[] { PID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSt.GuyIDRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "GuyIDDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnBirthday = new DataColumn("Birthday", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnBirthday);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnGuyID = new DataColumn("GuyID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuyID);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnSexID.AllowDBNull = false;
                this.columnBirthday.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnGuyID.MaxLength = 10;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnSexID = base.Columns["SexID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnBirthday = base.Columns["Birthday"];
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnGuyID = base.Columns["GuyID"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.GuyIDRow NewGuyIDRow()
            {
                return (dsSt.GuyIDRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.GuyIDRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GuyIDRowChanged != null)
                {
                    this.GuyIDRowChanged(this, new dsSt.GuyIDRowChangeEvent((dsSt.GuyIDRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GuyIDRowChanging != null)
                {
                    this.GuyIDRowChanging(this, new dsSt.GuyIDRowChangeEvent((dsSt.GuyIDRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GuyIDRowDeleted != null)
                {
                    this.GuyIDRowDeleted(this, new dsSt.GuyIDRowChangeEvent((dsSt.GuyIDRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GuyIDRowDeleting != null)
                {
                    this.GuyIDRowDeleting(this, new dsSt.GuyIDRowChangeEvent((dsSt.GuyIDRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveGuyIDRow(dsSt.GuyIDRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BirthdayColumn
            {
                get
                {
                    return this.columnBirthday;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyIDColumn
            {
                get
                {
                    return this.columnGuyID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.GuyIDRow this[int index]
            {
                get
                {
                    return (dsSt.GuyIDRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }
        }

        public class GuyIDRow : DataRow
        {
            private dsSt.GuyIDDataTable tableGuyID;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal GuyIDRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGuyID = (dsSt.GuyIDDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyIDNull()
            {
                return base.IsNull(this.tableGuyID.GuyIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tableGuyID.GuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableGuyID.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyIDNull()
            {
                base[this.tableGuyID.GuyIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tableGuyID.GuyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tableGuyID.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime Birthday
            {
                get
                {
                    return (DateTime)base[this.tableGuyID.BirthdayColumn];
                }
                set
                {
                    base[this.tableGuyID.BirthdayColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tableGuyID.ClassIDColumn];
                }
                set
                {
                    base[this.tableGuyID.ClassIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableGuyID.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'GuyID' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableGuyID.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GuyID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableGuyID.GuyIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GuyID' in table 'GuyID' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableGuyID.GuyIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string)base[this.tableGuyID.PIDColumn];
                }
                set
                {
                    base[this.tableGuyID.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableGuyID.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'GuyID' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGuyID.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short)base[this.tableGuyID.SexIDColumn];
                }
                set
                {
                    base[this.tableGuyID.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableGuyID.YearsColumn];
                }
                set
                {
                    base[this.tableGuyID.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class GuyIDRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.GuyIDRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public GuyIDRowChangeEvent(dsSt.GuyIDRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.GuyIDRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void GuyIDRowChangeEventHandler(object sender, dsSt.GuyIDRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class MemosDataTable : TypedTableBase<dsSt.MemosRow>
        {
            private DataColumn columnPID;
            private DataColumn columnStMemos;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MemosRowChangeEventHandler MemosRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MemosRowChangeEventHandler MemosRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MemosRowChangeEventHandler MemosRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MemosRowChangeEventHandler MemosRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public MemosDataTable()
            {
                base.TableName = "Memos";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal MemosDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected MemosDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddMemosRow(dsSt.MemosRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.MemosRow AddMemosRow(string PID, string StMemos)
            {
                dsSt.MemosRow row = (dsSt.MemosRow)base.NewRow();
                row.ItemArray = new object[] { PID, StMemos };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSt.MemosDataTable table = (dsSt.MemosDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSt.MemosDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.MemosRow FindByPID(string PID)
            {
                return (dsSt.MemosRow)base.Rows.Find(new object[] { PID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSt.MemosRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "MemosDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnStMemos = new DataColumn("StMemos", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStMemos);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                // this.columnStMemos.MaxLength = 600;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnStMemos = base.Columns["StMemos"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.MemosRow NewMemosRow()
            {
                return (dsSt.MemosRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.MemosRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.MemosRowChanged != null)
                {
                    this.MemosRowChanged(this, new dsSt.MemosRowChangeEvent((dsSt.MemosRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.MemosRowChanging != null)
                {
                    this.MemosRowChanging(this, new dsSt.MemosRowChangeEvent((dsSt.MemosRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.MemosRowDeleted != null)
                {
                    this.MemosRowDeleted(this, new dsSt.MemosRowChangeEvent((dsSt.MemosRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.MemosRowDeleting != null)
                {
                    this.MemosRowDeleting(this, new dsSt.MemosRowChangeEvent((dsSt.MemosRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveMemosRow(dsSt.MemosRow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.MemosRow this[int index]
            {
                get
                {
                    return (dsSt.MemosRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn StMemosColumn
            {
                get
                {
                    return this.columnStMemos;
                }
            }
        }

        public class MemosRow : DataRow
        {
            private dsSt.MemosDataTable tableMemos;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal MemosRow(DataRowBuilder rb) : base(rb)
            {
                this.tableMemos = (dsSt.MemosDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStMemosNull()
            {
                return base.IsNull(this.tableMemos.StMemosColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetStMemosNull()
            {
                base[this.tableMemos.StMemosColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string)base[this.tableMemos.PIDColumn];
                }
                set
                {
                    base[this.tableMemos.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string StMemos
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableMemos.StMemosColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'StMemos' in table 'Memos' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableMemos.StMemosColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class MemosRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.MemosRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public MemosRowChangeEvent(dsSt.MemosRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.MemosRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void MemosRowChangeEventHandler(object sender, dsSt.MemosRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class MigrateDataTable : TypedTableBase<dsSt.MigrateRow>
        {
            private DataColumn columnBirthday;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnGuyID;
            private DataColumn columnPID;
            private DataColumn columnSchool_Dest;
            private DataColumn columnSchoolID_Dest;
            private DataColumn columnSchoolID_Source;
            private DataColumn columnSchYears;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MigrateRowChangeEventHandler MigrateRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MigrateRowChangeEventHandler MigrateRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MigrateRowChangeEventHandler MigrateRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.MigrateRowChangeEventHandler MigrateRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public MigrateDataTable()
            {
                base.TableName = "Migrate";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal MigrateDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected MigrateDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddMigrateRow(dsSt.MigrateRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.MigrateRow AddMigrateRow(string SchoolID_Source, string PID, string Guy, string GuyID, string cSex, short Years, short ClassID, short Seat, short SchYears, short Sem, short GradeID, string SchoolID_Dest, string School_Dest, DateTime Birthday)
            {
                dsSt.MigrateRow row = (dsSt.MigrateRow)base.NewRow();
                row.ItemArray = new object[] { SchoolID_Source, PID, Guy, GuyID, cSex, Years, ClassID, Seat, SchYears, Sem, GradeID, SchoolID_Dest, School_Dest, Birthday };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSt.MigrateDataTable table = (dsSt.MigrateDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSt.MigrateDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.MigrateRow FindByPID(string PID)
            {
                return (dsSt.MigrateRow)base.Rows.Find(new object[] { PID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSt.MigrateRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "MigrateDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnSchoolID_Source = new DataColumn("SchoolID_Source", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSchoolID_Source);
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnGuyID = new DataColumn("GuyID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuyID);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnSchoolID_Dest = new DataColumn("SchoolID_Dest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSchoolID_Dest);
                this.columnSchool_Dest = new DataColumn("School_Dest", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSchool_Dest);
                this.columnBirthday = new DataColumn("Birthday", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnBirthday);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnSchoolID_Source.AllowDBNull = false;
                this.columnSchoolID_Source.MaxLength = 10;
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnGuyID.MaxLength = 10;
                this.columncSex.AllowDBNull = false;
                this.columncSex.MaxLength = 2;
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnSchoolID_Dest.MaxLength = 10;
                this.columnSchool_Dest.MaxLength = 50;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSchoolID_Source = base.Columns["SchoolID_Source"];
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnGuyID = base.Columns["GuyID"];
                this.columncSex = base.Columns["cSex"];
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnSchYears = base.Columns["SchYears"];
                this.columnSem = base.Columns["Sem"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnSchoolID_Dest = base.Columns["SchoolID_Dest"];
                this.columnSchool_Dest = base.Columns["School_Dest"];
                this.columnBirthday = base.Columns["Birthday"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.MigrateRow NewMigrateRow()
            {
                return (dsSt.MigrateRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.MigrateRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.MigrateRowChanged != null)
                {
                    this.MigrateRowChanged(this, new dsSt.MigrateRowChangeEvent((dsSt.MigrateRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.MigrateRowChanging != null)
                {
                    this.MigrateRowChanging(this, new dsSt.MigrateRowChangeEvent((dsSt.MigrateRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.MigrateRowDeleted != null)
                {
                    this.MigrateRowDeleted(this, new dsSt.MigrateRowChangeEvent((dsSt.MigrateRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.MigrateRowDeleting != null)
                {
                    this.MigrateRowDeleting(this, new dsSt.MigrateRowChangeEvent((dsSt.MigrateRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveMigrateRow(dsSt.MigrateRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BirthdayColumn
            {
                get
                {
                    return this.columnBirthday;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GradeIDColumn
            {
                get
                {
                    return this.columnGradeID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuyIDColumn
            {
                get
                {
                    return this.columnGuyID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.MigrateRow this[int index]
            {
                get
                {
                    return (dsSt.MigrateRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn School_DestColumn
            {
                get
                {
                    return this.columnSchool_Dest;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SchoolID_DestColumn
            {
                get
                {
                    return this.columnSchoolID_Dest;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SchoolID_SourceColumn
            {
                get
                {
                    return this.columnSchoolID_Source;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SchYearsColumn
            {
                get
                {
                    return this.columnSchYears;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }
        }

        public class MigrateRow : DataRow
        {
            private dsSt.MigrateDataTable tableMigrate;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal MigrateRow(DataRowBuilder rb) : base(rb)
            {
                this.tableMigrate = (dsSt.MigrateDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBirthdayNull()
            {
                return base.IsNull(this.tableMigrate.BirthdayColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tableMigrate.GradeIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyIDNull()
            {
                return base.IsNull(this.tableMigrate.GuyIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tableMigrate.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchool_DestNull()
            {
                return base.IsNull(this.tableMigrate.School_DestColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchoolID_DestNull()
            {
                return base.IsNull(this.tableMigrate.SchoolID_DestColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tableMigrate.SchYearsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableMigrate.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSemNull()
            {
                return base.IsNull(this.tableMigrate.SemColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetBirthdayNull()
            {
                base[this.tableMigrate.BirthdayColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeIDNull()
            {
                base[this.tableMigrate.GradeIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuyIDNull()
            {
                base[this.tableMigrate.GuyIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tableMigrate.GuyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchool_DestNull()
            {
                base[this.tableMigrate.School_DestColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchoolID_DestNull()
            {
                base[this.tableMigrate.SchoolID_DestColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSchYearsNull()
            {
                base[this.tableMigrate.SchYearsColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tableMigrate.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSemNull()
            {
                base[this.tableMigrate.SemColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DateTime Birthday
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime)base[this.tableMigrate.BirthdayColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Birthday' in table 'Migrate' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tableMigrate.BirthdayColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tableMigrate.ClassIDColumn];
                }
                set
                {
                    base[this.tableMigrate.ClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string cSex
            {
                get
                {
                    return (string)base[this.tableMigrate.cSexColumn];
                }
                set
                {
                    base[this.tableMigrate.cSexColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableMigrate.GradeIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeID' in table 'Migrate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableMigrate.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableMigrate.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'Migrate' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableMigrate.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GuyID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableMigrate.GuyIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GuyID' in table 'Migrate' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableMigrate.GuyIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string)base[this.tableMigrate.PIDColumn];
                }
                set
                {
                    base[this.tableMigrate.PIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string School_Dest
            {
                get
                {
                    if (this.IsSchool_DestNull())
                    {
                        return null;
                    }
                    return (string)base[this.tableMigrate.School_DestColumn];
                }
                set
                {
                    base[this.tableMigrate.School_DestColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SchoolID_Dest
            {
                get
                {
                    if (this.IsSchoolID_DestNull())
                    {
                        return null;
                    }
                    return (string)base[this.tableMigrate.SchoolID_DestColumn];
                }
                set
                {
                    base[this.tableMigrate.SchoolID_DestColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SchoolID_Source
            {
                get
                {
                    return (string)base[this.tableMigrate.SchoolID_SourceColumn];
                }
                set
                {
                    base[this.tableMigrate.SchoolID_SourceColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SchYears
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableMigrate.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'Migrate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableMigrate.SchYearsColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableMigrate.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'Migrate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableMigrate.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sem
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableMigrate.SemColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sem' in table 'Migrate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableMigrate.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableMigrate.YearsColumn];
                }
                set
                {
                    base[this.tableMigrate.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class MigrateRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.MigrateRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public MigrateRowChangeEvent(dsSt.MigrateRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.MigrateRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void MigrateRowChangeEventHandler(object sender, dsSt.MigrateRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class StSeatSameDataTable : TypedTableBase<dsSt.StSeatSameRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnPID;
            private DataColumn columnRealAgeSt;
            private DataColumn columnSeat;
            private DataColumn columnSexID;
            private DataColumn columnYears;
            private DataColumn columnYearsGrade;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.StSeatSameRowChangeEventHandler StSeatSameRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.StSeatSameRowChangeEventHandler StSeatSameRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.StSeatSameRowChangeEventHandler StSeatSameRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.StSeatSameRowChangeEventHandler StSeatSameRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public StSeatSameDataTable()
            {
                base.TableName = "StSeatSame";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal StSeatSameDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected StSeatSameDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddStSeatSameRow(dsSt.StSeatSameRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.StSeatSameRow AddStSeatSameRow(string PID, short Seat, string Guy, short SexID, string cSex, short Years, short GradeID, string Grade, short ClassID, string Class, string YearsGrade, int RealAgeSt)
            {
                dsSt.StSeatSameRow row = (dsSt.StSeatSameRow)base.NewRow();
                row.ItemArray = new object[] { PID, Seat, Guy, SexID, cSex, Years, GradeID, Grade, ClassID, Class, YearsGrade, RealAgeSt };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSt.StSeatSameDataTable table = (dsSt.StSeatSameDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSt.StSeatSameDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSt.StSeatSameRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "StSeatSameDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnYearsGrade = new DataColumn("YearsGrade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsGrade);
                this.columnRealAgeSt = new DataColumn("RealAgeSt", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnRealAgeSt);
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnSexID.AllowDBNull = false;
                this.columncSex.MaxLength = 2;
                this.columnYears.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClassID.AllowDBNull = false;
                this.columnClass.MaxLength = 10;
                this.columnYearsGrade.ReadOnly = true;
                this.columnYearsGrade.MaxLength = 0x22;
                this.columnRealAgeSt.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnGuy = base.Columns["Guy"];
                this.columnSexID = base.Columns["SexID"];
                this.columncSex = base.Columns["cSex"];
                this.columnYears = base.Columns["Years"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass = base.Columns["Class"];
                this.columnYearsGrade = base.Columns["YearsGrade"];
                this.columnRealAgeSt = base.Columns["RealAgeSt"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.StSeatSameRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.StSeatSameRow NewStSeatSameRow()
            {
                return (dsSt.StSeatSameRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.StSeatSameRowChanged != null)
                {
                    this.StSeatSameRowChanged(this, new dsSt.StSeatSameRowChangeEvent((dsSt.StSeatSameRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.StSeatSameRowChanging != null)
                {
                    this.StSeatSameRowChanging(this, new dsSt.StSeatSameRowChangeEvent((dsSt.StSeatSameRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.StSeatSameRowDeleted != null)
                {
                    this.StSeatSameRowDeleted(this, new dsSt.StSeatSameRowChangeEvent((dsSt.StSeatSameRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.StSeatSameRowDeleting != null)
                {
                    this.StSeatSameRowDeleting(this, new dsSt.StSeatSameRowChangeEvent((dsSt.StSeatSameRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveStSeatSameRow(dsSt.StSeatSameRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassColumn
            {
                get
                {
                    return this.columnClass;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeColumn
            {
                get
                {
                    return this.columnGrade;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeIDColumn
            {
                get
                {
                    return this.columnGradeID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.StSeatSameRow this[int index]
            {
                get
                {
                    return (dsSt.StSeatSameRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn RealAgeStColumn
            {
                get
                {
                    return this.columnRealAgeSt;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsGradeColumn
            {
                get
                {
                    return this.columnYearsGrade;
                }
            }
        }

        public class StSeatSameRow : DataRow
        {
            private dsSt.StSeatSameDataTable tableStSeatSame;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal StSeatSameRow(DataRowBuilder rb) : base(rb)
            {
                this.tableStSeatSame = (dsSt.StSeatSameDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableStSeatSame.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tableStSeatSame.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tableStSeatSame.GradeIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableStSeatSame.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tableStSeatSame.GuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRealAgeStNull()
            {
                return base.IsNull(this.tableStSeatSame.RealAgeStColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableStSeatSame.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsYearsGradeNull()
            {
                return base.IsNull(this.tableStSeatSame.YearsGradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tableStSeatSame.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tableStSeatSame.cSexColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeIDNull()
            {
                base[this.tableStSeatSame.GradeIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tableStSeatSame.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuyNull()
            {
                base[this.tableStSeatSame.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetRealAgeStNull()
            {
                base[this.tableStSeatSame.RealAgeStColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tableStSeatSame.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetYearsGradeNull()
            {
                base[this.tableStSeatSame.YearsGradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableStSeatSame.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStSeatSame.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tableStSeatSame.ClassIDColumn];
                }
                set
                {
                    base[this.tableStSeatSame.ClassIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string cSex
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableStSeatSame.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStSeatSame.cSexColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Grade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableStSeatSame.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStSeatSame.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short GradeID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableStSeatSame.GradeIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeID' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableStSeatSame.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableStSeatSame.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStSeatSame.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string)base[this.tableStSeatSame.PIDColumn];
                }
                set
                {
                    base[this.tableStSeatSame.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int RealAgeSt
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[this.tableStSeatSame.RealAgeStColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'RealAgeSt' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableStSeatSame.RealAgeStColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableStSeatSame.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableStSeatSame.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short)base[this.tableStSeatSame.SexIDColumn];
                }
                set
                {
                    base[this.tableStSeatSame.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableStSeatSame.YearsColumn];
                }
                set
                {
                    base[this.tableStSeatSame.YearsColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string YearsGrade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableStSeatSame.YearsGradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsGrade' in table 'StSeatSame' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStSeatSame.YearsGradeColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class StSeatSameRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.StSeatSameRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public StSeatSameRowChangeEvent(dsSt.StSeatSameRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.StSeatSameRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void StSeatSameRowChangeEventHandler(object sender, dsSt.StSeatSameRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vStaDataTable : TypedTableBase<dsSt.vStaRow>
        {
            private DataColumn columnAborigine;
            private DataColumn columnAddress;
            private DataColumn columnBirthday;
            private DataColumn columnBlood;
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDad;
            private DataColumn columnEmergencyCall;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGradeIDClassIDSeat;
            private DataColumn columnGuardian;
            private DataColumn columnGuy;
            private DataColumn columnGuyID;
            private DataColumn columnMom;
            private DataColumn columnNewClassID;
            private DataColumn columnNewSeat;
            private DataColumn columnPID;
            private DataColumn columnRealAgeSt;
            private DataColumn columnSeat;
            private DataColumn columnSeatGuy;
            private DataColumn columnSexID;
            private DataColumn columnStMemos;
            private DataColumn columnTel1;
            private DataColumn columnYears;
            private DataColumn columnYearsGrade;
            private DataColumn columnZip;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStaRowChangeEventHandler vStaRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStaRowChangeEventHandler vStaRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStaRowChangeEventHandler vStaRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStaRowChangeEventHandler vStaRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vStaDataTable()
            {
                base.TableName = "vSta";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vStaDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected vStaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddvStaRow(dsSt.vStaRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.vStaRow AddvStaRow(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short NewClassID, short NewSeat, string Blood, string cSex, short GradeID, string Grade, string Class, string YearsGrade, int RealAgeSt, string SeatGuy, short Aborigine, string GradeIDClassIDSeat, string StMemos)
            {
                dsSt.vStaRow row = (dsSt.vStaRow)base.NewRow();
                row.ItemArray = new object[] {
                    PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall, NewClassID,
                    NewSeat, Blood, cSex, GradeID, Grade, Class, YearsGrade, RealAgeSt, SeatGuy, Aborigine, GradeIDClassIDSeat, StMemos
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSt.vStaDataTable table = (dsSt.vStaDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSt.vStaDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStaRow FindByPID(string PID)
            {
                return (dsSt.vStaRow)base.Rows.Find(new object[] { PID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSt.vStaRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "vStaDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnGuyID = new DataColumn("GuyID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuyID);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnBirthday = new DataColumn("Birthday", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnBirthday);
                this.columnDad = new DataColumn("Dad", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDad);
                this.columnMom = new DataColumn("Mom", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMom);
                this.columnGuardian = new DataColumn("Guardian", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuardian);
                this.columnZip = new DataColumn("Zip", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZip);
                this.columnTel1 = new DataColumn("Tel1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTel1);
                this.columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddress);
                this.columnEmergencyCall = new DataColumn("EmergencyCall", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEmergencyCall);
                this.columnNewClassID = new DataColumn("NewClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNewClassID);
                this.columnNewSeat = new DataColumn("NewSeat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNewSeat);
                this.columnBlood = new DataColumn("Blood", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBlood);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnYearsGrade = new DataColumn("YearsGrade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsGrade);
                this.columnRealAgeSt = new DataColumn("RealAgeSt", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnRealAgeSt);
                this.columnSeatGuy = new DataColumn("SeatGuy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSeatGuy);
                this.columnAborigine = new DataColumn("Aborigine", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnAborigine);
                this.columnGradeIDClassIDSeat = new DataColumn("GradeIDClassIDSeat", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGradeIDClassIDSeat);
                this.columnStMemos = new DataColumn("StMemos", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStMemos);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnGuyID.MaxLength = 10;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnBirthday.AllowDBNull = false;
                this.columnDad.MaxLength = 100;
                this.columnMom.MaxLength = 100;
                this.columnGuardian.MaxLength = 100;
                this.columnZip.AllowDBNull = false;
                this.columnZip.MaxLength = 3;
                this.columnTel1.MaxLength = 12;
                //this.columnAddress.MaxLength = 30;
                //this.columnEmergencyCall.MaxLength = 60;
                this.columnBlood.MaxLength = 2;
                this.columncSex.MaxLength = 2;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columnYearsGrade.ReadOnly = true;
                this.columnYearsGrade.MaxLength = 0x22;
                this.columnRealAgeSt.ReadOnly = true;
                this.columnSeatGuy.ReadOnly = true;
                this.columnSeatGuy.MaxLength = 100;
                this.columnGradeIDClassIDSeat.ReadOnly = true;
                this.columnGradeIDClassIDSeat.MaxLength = 0x2a;
                // this.columnStMemos.MaxLength = 0xff;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnGuyID = base.Columns["GuyID"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnBirthday = base.Columns["Birthday"];
                this.columnDad = base.Columns["Dad"];
                this.columnMom = base.Columns["Mom"];
                this.columnGuardian = base.Columns["Guardian"];
                this.columnZip = base.Columns["Zip"];
                this.columnTel1 = base.Columns["Tel1"];
                this.columnAddress = base.Columns["Address"];
                this.columnEmergencyCall = base.Columns["EmergencyCall"];
                this.columnNewClassID = base.Columns["NewClassID"];
                this.columnNewSeat = base.Columns["NewSeat"];
                this.columnBlood = base.Columns["Blood"];
                this.columncSex = base.Columns["cSex"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columnYearsGrade = base.Columns["YearsGrade"];
                this.columnRealAgeSt = base.Columns["RealAgeSt"];
                this.columnSeatGuy = base.Columns["SeatGuy"];
                this.columnAborigine = base.Columns["Aborigine"];
                this.columnGradeIDClassIDSeat = base.Columns["GradeIDClassIDSeat"];
                this.columnStMemos = base.Columns["StMemos"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.vStaRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.vStaRow NewvStaRow()
            {
                return (dsSt.vStaRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vStaRowChanged != null)
                {
                    this.vStaRowChanged(this, new dsSt.vStaRowChangeEvent((dsSt.vStaRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vStaRowChanging != null)
                {
                    this.vStaRowChanging(this, new dsSt.vStaRowChangeEvent((dsSt.vStaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vStaRowDeleted != null)
                {
                    this.vStaRowDeleted(this, new dsSt.vStaRowChangeEvent((dsSt.vStaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vStaRowDeleting != null)
                {
                    this.vStaRowDeleting(this, new dsSt.vStaRowChangeEvent((dsSt.vStaRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemovevStaRow(dsSt.vStaRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn AborigineColumn
            {
                get
                {
                    return this.columnAborigine;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AddressColumn
            {
                get
                {
                    return this.columnAddress;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BirthdayColumn
            {
                get
                {
                    return this.columnBirthday;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BloodColumn
            {
                get
                {
                    return this.columnBlood;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassColumn
            {
                get
                {
                    return this.columnClass;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DadColumn
            {
                get
                {
                    return this.columnDad;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EmergencyCallColumn
            {
                get
                {
                    return this.columnEmergencyCall;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeColumn
            {
                get
                {
                    return this.columnGrade;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeIDClassIDSeatColumn
            {
                get
                {
                    return this.columnGradeIDClassIDSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GradeIDColumn
            {
                get
                {
                    return this.columnGradeID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuardianColumn
            {
                get
                {
                    return this.columnGuardian;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyIDColumn
            {
                get
                {
                    return this.columnGuyID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStaRow this[int index]
            {
                get
                {
                    return (dsSt.vStaRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn MomColumn
            {
                get
                {
                    return this.columnMom;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NewClassIDColumn
            {
                get
                {
                    return this.columnNewClassID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NewSeatColumn
            {
                get
                {
                    return this.columnNewSeat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn RealAgeStColumn
            {
                get
                {
                    return this.columnRealAgeSt;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SeatGuyColumn
            {
                get
                {
                    return this.columnSeatGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn StMemosColumn
            {
                get
                {
                    return this.columnStMemos;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Tel1Column
            {
                get
                {
                    return this.columnTel1;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsGradeColumn
            {
                get
                {
                    return this.columnYearsGrade;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ZipColumn
            {
                get
                {
                    return this.columnZip;
                }
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vStAllDataTable : TypedTableBase<dsSt.vStAllRow>
        {
            private DataColumn columnAborigine;
            private DataColumn columnAddress;
            private DataColumn columnBirthday;
            private DataColumn columnBlood;
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDad;
            private DataColumn columnDeled;
            private DataColumn columnEmergencyCall;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGradeIDClassIDSeat;
            private DataColumn columnGuardian;
            private DataColumn columnGuy;
            private DataColumn columnGuyID;
            private DataColumn columnMom;
            private DataColumn columnNewClassID;
            private DataColumn columnNewSeat;
            private DataColumn columnPID;
            private DataColumn columnRealAgeSt;
            private DataColumn columnSeat;
            private DataColumn columnSeatGuy;
            private DataColumn columnSexID;
            private DataColumn columnStMemos;
            private DataColumn columnTel1;
            private DataColumn columnYears;
            private DataColumn columnYearsGrade;
            private DataColumn columnZip;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStAllRowChangeEventHandler vStAllRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStAllRowChangeEventHandler vStAllRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStAllRowChangeEventHandler vStAllRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStAllRowChangeEventHandler vStAllRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vStAllDataTable()
            {
                base.TableName = "vStAll";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vStAllDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected vStAllDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddvStAllRow(dsSt.vStAllRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStAllRow AddvStAllRow(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short NewClassID, short NewSeat, string Blood, string cSex, short GradeID, string Grade, string Class, string YearsGrade, int RealAgeSt, string SeatGuy, short Aborigine, string GradeIDClassIDSeat, string StMemos, short Deled)
            {
                dsSt.vStAllRow row = (dsSt.vStAllRow)base.NewRow();
                row.ItemArray = new object[] {
                    PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall, NewClassID,
                    NewSeat, Blood, cSex, GradeID, Grade, Class, YearsGrade, RealAgeSt, SeatGuy, Aborigine, GradeIDClassIDSeat, StMemos, Deled
                 };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSt.vStAllDataTable table = (dsSt.vStAllDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSt.vStAllDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStAllRow FindByPID(string PID)
            {
                return (dsSt.vStAllRow)base.Rows.Find(new object[] { PID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSt.vStAllRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "vStAllDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnGuyID = new DataColumn("GuyID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuyID);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnBirthday = new DataColumn("Birthday", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnBirthday);
                this.columnDad = new DataColumn("Dad", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDad);
                this.columnMom = new DataColumn("Mom", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMom);
                this.columnGuardian = new DataColumn("Guardian", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuardian);
                this.columnZip = new DataColumn("Zip", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZip);
                this.columnTel1 = new DataColumn("Tel1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTel1);
                this.columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddress);
                this.columnEmergencyCall = new DataColumn("EmergencyCall", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEmergencyCall);
                this.columnNewClassID = new DataColumn("NewClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNewClassID);
                this.columnNewSeat = new DataColumn("NewSeat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNewSeat);
                this.columnBlood = new DataColumn("Blood", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBlood);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnYearsGrade = new DataColumn("YearsGrade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsGrade);
                this.columnRealAgeSt = new DataColumn("RealAgeSt", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnRealAgeSt);
                this.columnSeatGuy = new DataColumn("SeatGuy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSeatGuy);
                this.columnAborigine = new DataColumn("Aborigine", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnAborigine);
                this.columnGradeIDClassIDSeat = new DataColumn("GradeIDClassIDSeat", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGradeIDClassIDSeat);
                this.columnStMemos = new DataColumn("StMemos", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStMemos);
                this.columnDeled = new DataColumn("Deled", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDeled);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnGuyID.MaxLength = 10;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnBirthday.AllowDBNull = false;
                this.columnDad.MaxLength = 100;
                this.columnMom.MaxLength = 100;
                this.columnGuardian.MaxLength = 100;
                this.columnZip.AllowDBNull = false;
                this.columnZip.MaxLength = 3;
                this.columnTel1.MaxLength = 12;
                //this.columnAddress.MaxLength = 30;
                //this.columnEmergencyCall.MaxLength = 60;
                this.columnBlood.MaxLength = 2;
                this.columncSex.MaxLength = 2;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columnYearsGrade.ReadOnly = true;
                this.columnYearsGrade.MaxLength = 0x22;
                this.columnRealAgeSt.ReadOnly = true;
                this.columnSeatGuy.ReadOnly = true;
                this.columnSeatGuy.MaxLength = 100;
                this.columnGradeIDClassIDSeat.ReadOnly = true;
                this.columnGradeIDClassIDSeat.MaxLength = 0x2a;
                // this.columnStMemos.MaxLength = 0xff;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnGuyID = base.Columns["GuyID"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnBirthday = base.Columns["Birthday"];
                this.columnDad = base.Columns["Dad"];
                this.columnMom = base.Columns["Mom"];
                this.columnGuardian = base.Columns["Guardian"];
                this.columnZip = base.Columns["Zip"];
                this.columnTel1 = base.Columns["Tel1"];
                this.columnAddress = base.Columns["Address"];
                this.columnEmergencyCall = base.Columns["EmergencyCall"];
                this.columnNewClassID = base.Columns["NewClassID"];
                this.columnNewSeat = base.Columns["NewSeat"];
                this.columnBlood = base.Columns["Blood"];
                this.columncSex = base.Columns["cSex"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columnYearsGrade = base.Columns["YearsGrade"];
                this.columnRealAgeSt = base.Columns["RealAgeSt"];
                this.columnSeatGuy = base.Columns["SeatGuy"];
                this.columnAborigine = base.Columns["Aborigine"];
                this.columnGradeIDClassIDSeat = base.Columns["GradeIDClassIDSeat"];
                this.columnStMemos = base.Columns["StMemos"];
                this.columnDeled = base.Columns["Deled"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.vStAllRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.vStAllRow NewvStAllRow()
            {
                return (dsSt.vStAllRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vStAllRowChanged != null)
                {
                    this.vStAllRowChanged(this, new dsSt.vStAllRowChangeEvent((dsSt.vStAllRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vStAllRowChanging != null)
                {
                    this.vStAllRowChanging(this, new dsSt.vStAllRowChangeEvent((dsSt.vStAllRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vStAllRowDeleted != null)
                {
                    this.vStAllRowDeleted(this, new dsSt.vStAllRowChangeEvent((dsSt.vStAllRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vStAllRowDeleting != null)
                {
                    this.vStAllRowDeleting(this, new dsSt.vStAllRowChangeEvent((dsSt.vStAllRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovevStAllRow(dsSt.vStAllRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AborigineColumn
            {
                get
                {
                    return this.columnAborigine;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AddressColumn
            {
                get
                {
                    return this.columnAddress;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BirthdayColumn
            {
                get
                {
                    return this.columnBirthday;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BloodColumn
            {
                get
                {
                    return this.columnBlood;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassColumn
            {
                get
                {
                    return this.columnClass;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DadColumn
            {
                get
                {
                    return this.columnDad;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DeledColumn
            {
                get
                {
                    return this.columnDeled;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn EmergencyCallColumn
            {
                get
                {
                    return this.columnEmergencyCall;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GradeColumn
            {
                get
                {
                    return this.columnGrade;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GradeIDClassIDSeatColumn
            {
                get
                {
                    return this.columnGradeIDClassIDSeat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeIDColumn
            {
                get
                {
                    return this.columnGradeID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuardianColumn
            {
                get
                {
                    return this.columnGuardian;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuyIDColumn
            {
                get
                {
                    return this.columnGuyID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStAllRow this[int index]
            {
                get
                {
                    return (dsSt.vStAllRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn MomColumn
            {
                get
                {
                    return this.columnMom;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn NewClassIDColumn
            {
                get
                {
                    return this.columnNewClassID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn NewSeatColumn
            {
                get
                {
                    return this.columnNewSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn RealAgeStColumn
            {
                get
                {
                    return this.columnRealAgeSt;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SeatGuyColumn
            {
                get
                {
                    return this.columnSeatGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn StMemosColumn
            {
                get
                {
                    return this.columnStMemos;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Tel1Column
            {
                get
                {
                    return this.columnTel1;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsGradeColumn
            {
                get
                {
                    return this.columnYearsGrade;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ZipColumn
            {
                get
                {
                    return this.columnZip;
                }
            }
        }

        public class vStAllRow : DataRow
        {
            private dsSt.vStAllDataTable tablevStAll;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vStAllRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevStAll = (dsSt.vStAllDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAborigineNull()
            {
                return base.IsNull(this.tablevStAll.AborigineColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAddressNull()
            {
                return base.IsNull(this.tablevStAll.AddressColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsBloodNull()
            {
                return base.IsNull(this.tablevStAll.BloodColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevStAll.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevStAll.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDadNull()
            {
                return base.IsNull(this.tablevStAll.DadColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDeledNull()
            {
                return base.IsNull(this.tablevStAll.DeledColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsEmergencyCallNull()
            {
                return base.IsNull(this.tablevStAll.EmergencyCallColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeIDClassIDSeatNull()
            {
                return base.IsNull(this.tablevStAll.GradeIDClassIDSeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tablevStAll.GradeIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevStAll.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuardianNull()
            {
                return base.IsNull(this.tablevStAll.GuardianColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyIDNull()
            {
                return base.IsNull(this.tablevStAll.GuyIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevStAll.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsMomNull()
            {
                return base.IsNull(this.tablevStAll.MomColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNewClassIDNull()
            {
                return base.IsNull(this.tablevStAll.NewClassIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNewSeatNull()
            {
                return base.IsNull(this.tablevStAll.NewSeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRealAgeStNull()
            {
                return base.IsNull(this.tablevStAll.RealAgeStColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatGuyNull()
            {
                return base.IsNull(this.tablevStAll.SeatGuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevStAll.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStMemosNull()
            {
                return base.IsNull(this.tablevStAll.StMemosColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTel1Null()
            {
                return base.IsNull(this.tablevStAll.Tel1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsYearsGradeNull()
            {
                return base.IsNull(this.tablevStAll.YearsGradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAborigineNull()
            {
                base[this.tablevStAll.AborigineColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAddressNull()
            {
                base[this.tablevStAll.AddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBloodNull()
            {
                base[this.tablevStAll.BloodColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tablevStAll.ClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetcSexNull()
            {
                base[this.tablevStAll.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDadNull()
            {
                base[this.tablevStAll.DadColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDeledNull()
            {
                base[this.tablevStAll.DeledColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetEmergencyCallNull()
            {
                base[this.tablevStAll.EmergencyCallColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeIDClassIDSeatNull()
            {
                base[this.tablevStAll.GradeIDClassIDSeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeIDNull()
            {
                base[this.tablevStAll.GradeIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tablevStAll.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuardianNull()
            {
                base[this.tablevStAll.GuardianColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyIDNull()
            {
                base[this.tablevStAll.GuyIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tablevStAll.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMomNull()
            {
                base[this.tablevStAll.MomColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNewClassIDNull()
            {
                base[this.tablevStAll.NewClassIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNewSeatNull()
            {
                base[this.tablevStAll.NewSeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRealAgeStNull()
            {
                base[this.tablevStAll.RealAgeStColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatGuyNull()
            {
                base[this.tablevStAll.SeatGuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tablevStAll.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetStMemosNull()
            {
                base[this.tablevStAll.StMemosColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTel1Null()
            {
                base[this.tablevStAll.Tel1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetYearsGradeNull()
            {
                base[this.tablevStAll.YearsGradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Aborigine
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevStAll.AborigineColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Aborigine' in table 'vStAll' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevStAll.AborigineColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Address
            {
                get
                {
                    if (this.IsAddressNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.AddressColumn];
                }
                set
                {
                    base[this.tablevStAll.AddressColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DateTime Birthday
            {
                get
                {
                    return (DateTime)base[this.tablevStAll.BirthdayColumn];
                }
                set
                {
                    base[this.tablevStAll.BirthdayColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Blood
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.BloodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Blood' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.BloodColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.ClassColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tablevStAll.ClassIDColumn];
                }
                set
                {
                    base[this.tablevStAll.ClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string cSex
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.cSexColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Dad
            {
                get
                {
                    if (this.IsDadNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.DadColumn];
                }
                set
                {
                    base[this.tablevStAll.DadColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Deled
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevStAll.DeledColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Deled' in table 'vStAll' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevStAll.DeledColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string EmergencyCall
            {
                get
                {
                    if (this.IsEmergencyCallNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.EmergencyCallColumn];
                }
                set
                {
                    base[this.tablevStAll.EmergencyCallColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Grade
            {
                get
                {
                    if (this.IsGradeNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.GradeColumn];
                }
                set
                {
                    base[this.tablevStAll.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    if (this.IsGradeIDNull())
                    {
                        return 0;
                    }
                    return (short)base[this.tablevStAll.GradeIDColumn];
                }
                set
                {
                    base[this.tablevStAll.GradeIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GradeIDClassIDSeat
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.GradeIDClassIDSeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeIDClassIDSeat' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.GradeIDClassIDSeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Guardian
            {
                get
                {
                    if (this.IsGuardianNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.GuardianColumn];
                }
                set
                {
                    base[this.tablevStAll.GuardianColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.GuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string GuyID
            {
                get
                {
                    if (this.IsGuyIDNull())
                    {
                        return string.Empty;
                    }
                    return (string)base[this.tablevStAll.GuyIDColumn];
                }
                set
                {
                    base[this.tablevStAll.GuyIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Mom
            {
                get
                {
                    if (this.IsMomNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.MomColumn];
                }
                set
                {
                    base[this.tablevStAll.MomColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short NewClassID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevStAll.NewClassIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NewClassID' in table 'vStAll' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevStAll.NewClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short NewSeat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevStAll.NewSeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NewSeat' in table 'vStAll' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevStAll.NewSeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string)base[this.tablevStAll.PIDColumn];
                }
                set
                {
                    base[this.tablevStAll.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int RealAgeSt
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[this.tablevStAll.RealAgeStColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'RealAgeSt' in table 'vStAll' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevStAll.RealAgeStColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevStAll.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vStAll' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevStAll.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SeatGuy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.SeatGuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SeatGuy' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.SeatGuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SexID
            {
                get
                {
                    return (short)base[this.tablevStAll.SexIDColumn];
                }
                set
                {
                    base[this.tablevStAll.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string StMemos
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.StMemosColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'StMemos' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.StMemosColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Tel1
            {
                get
                {
                    if (this.IsTel1Null())
                    {
                        return null;
                    }
                    return (string)base[this.tablevStAll.Tel1Column];
                }
                set
                {
                    base[this.tablevStAll.Tel1Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Years
            {
                get
                {
                    return (short)base[this.tablevStAll.YearsColumn];
                }
                set
                {
                    base[this.tablevStAll.YearsColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string YearsGrade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevStAll.YearsGradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsGrade' in table 'vStAll' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevStAll.YearsGradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Zip
            {
                get
                {
                    return (string)base[this.tablevStAll.ZipColumn];
                }
                set
                {
                    base[this.tablevStAll.ZipColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vStAllRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.vStAllRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public vStAllRowChangeEvent(dsSt.vStAllRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.vStAllRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vStAllRowChangeEventHandler(object sender, dsSt.vStAllRowChangeEvent e);

        public class vStaRow : DataRow
        {
            private dsSt.vStaDataTable tablevSta;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vStaRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevSta = (dsSt.vStaDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAborigineNull()
            {
                return base.IsNull(this.tablevSta.AborigineColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAddressNull()
            {
                return base.IsNull(this.tablevSta.AddressColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBloodNull()
            {
                return base.IsNull(this.tablevSta.BloodColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevSta.ClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevSta.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDadNull()
            {
                return base.IsNull(this.tablevSta.DadColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsEmergencyCallNull()
            {
                return base.IsNull(this.tablevSta.EmergencyCallColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeIDClassIDSeatNull()
            {
                return base.IsNull(this.tablevSta.GradeIDClassIDSeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tablevSta.GradeIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevSta.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuardianNull()
            {
                return base.IsNull(this.tablevSta.GuardianColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyIDNull()
            {
                return base.IsNull(this.tablevSta.GuyIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevSta.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsMomNull()
            {
                return base.IsNull(this.tablevSta.MomColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsNewClassIDNull()
            {
                return base.IsNull(this.tablevSta.NewClassIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsNewSeatNull()
            {
                return base.IsNull(this.tablevSta.NewSeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRealAgeStNull()
            {
                return base.IsNull(this.tablevSta.RealAgeStColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatGuyNull()
            {
                return base.IsNull(this.tablevSta.SeatGuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevSta.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsStMemosNull()
            {
                return base.IsNull(this.tablevSta.StMemosColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTel1Null()
            {
                return base.IsNull(this.tablevSta.Tel1Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsYearsGradeNull()
            {
                return base.IsNull(this.tablevSta.YearsGradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAborigineNull()
            {
                base[this.tablevSta.AborigineColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetAddressNull()
            {
                base[this.tablevSta.AddressColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetBloodNull()
            {
                base[this.tablevSta.BloodColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tablevSta.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tablevSta.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDadNull()
            {
                base[this.tablevSta.DadColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetEmergencyCallNull()
            {
                base[this.tablevSta.EmergencyCallColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeIDClassIDSeatNull()
            {
                base[this.tablevSta.GradeIDClassIDSeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeIDNull()
            {
                base[this.tablevSta.GradeIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tablevSta.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuardianNull()
            {
                base[this.tablevSta.GuardianColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyIDNull()
            {
                base[this.tablevSta.GuyIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuyNull()
            {
                base[this.tablevSta.GuyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMomNull()
            {
                base[this.tablevSta.MomColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNewClassIDNull()
            {
                base[this.tablevSta.NewClassIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNewSeatNull()
            {
                base[this.tablevSta.NewSeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetRealAgeStNull()
            {
                base[this.tablevSta.RealAgeStColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatGuyNull()
            {
                base[this.tablevSta.SeatGuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tablevSta.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetStMemosNull()
            {
                base[this.tablevSta.StMemosColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTel1Null()
            {
                base[this.tablevSta.Tel1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetYearsGradeNull()
            {
                base[this.tablevSta.YearsGradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Aborigine
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSta.AborigineColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Aborigine' in table 'vSta' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSta.AborigineColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Address
            {
                get
                {
                    if (this.IsAddressNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.AddressColumn];
                }
                set
                {
                    base[this.tablevSta.AddressColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DateTime Birthday
            {
                get
                {
                    return (DateTime)base[this.tablevSta.BirthdayColumn];
                }
                set
                {
                    base[this.tablevSta.BirthdayColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Blood
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.BloodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Blood' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.BloodColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tablevSta.ClassIDColumn];
                }
                set
                {
                    base[this.tablevSta.ClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string cSex
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.cSexColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Dad
            {
                get
                {
                    if (this.IsDadNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.DadColumn];
                }
                set
                {
                    base[this.tablevSta.DadColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string EmergencyCall
            {
                get
                {
                    if (this.IsEmergencyCallNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.EmergencyCallColumn];
                }
                set
                {
                    base[this.tablevSta.EmergencyCallColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Grade
            {
                get
                {
                    if (this.IsGradeNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.GradeColumn];
                }
                set
                {
                    base[this.tablevSta.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    if (this.IsGradeIDNull())
                    {
                        return 0;
                    }
                    return (short)base[this.tablevSta.GradeIDColumn];
                }
                set
                {
                    base[this.tablevSta.GradeIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GradeIDClassIDSeat
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.GradeIDClassIDSeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeIDClassIDSeat' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.GradeIDClassIDSeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Guardian
            {
                get
                {
                    if (this.IsGuardianNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.GuardianColumn];
                }
                set
                {
                    base[this.tablevSta.GuardianColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GuyID
            {
                get
                {
                    if (this.IsGuyIDNull())
                    {
                        return string.Empty;
                    }
                    return (string)base[this.tablevSta.GuyIDColumn];
                }
                set
                {
                    base[this.tablevSta.GuyIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Mom
            {
                get
                {
                    if (this.IsMomNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.MomColumn];
                }
                set
                {
                    base[this.tablevSta.MomColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short NewClassID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSta.NewClassIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NewClassID' in table 'vSta' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSta.NewClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short NewSeat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSta.NewSeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NewSeat' in table 'vSta' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSta.NewSeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string)base[this.tablevSta.PIDColumn];
                }
                set
                {
                    base[this.tablevSta.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int RealAgeSt
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[this.tablevSta.RealAgeStColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'RealAgeSt' in table 'vSta' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSta.RealAgeStColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSta.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vSta' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSta.SeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SeatGuy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.SeatGuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SeatGuy' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.SeatGuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short)base[this.tablevSta.SexIDColumn];
                }
                set
                {
                    base[this.tablevSta.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string StMemos
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.StMemosColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'StMemos' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.StMemosColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Tel1
            {
                get
                {
                    if (this.IsTel1Null())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSta.Tel1Column];
                }
                set
                {
                    base[this.tablevSta.Tel1Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tablevSta.YearsColumn];
                }
                set
                {
                    base[this.tablevSta.YearsColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string YearsGrade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSta.YearsGradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsGrade' in table 'vSta' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSta.YearsGradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Zip
            {
                get
                {
                    return (string)base[this.tablevSta.ZipColumn];
                }
                set
                {
                    base[this.tablevSta.ZipColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vStaRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.vStaRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vStaRowChangeEvent(dsSt.vStaRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vStaRowChangeEventHandler(object sender, dsSt.vStaRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vStDataTable : TypedTableBase<dsSt.vStRow>
        {
            private DataColumn columnAborigine;
            private DataColumn columnAddress;
            private DataColumn columnBirthday;
            private DataColumn columnBlood;
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDad;
            private DataColumn columnEmergencyCall;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGradeIDClassIDSeat;
            private DataColumn columnGuardian;
            private DataColumn columnGuy;
            private DataColumn columnGuyID;
            private DataColumn columnMom;
            private DataColumn columnNewClassID;
            private DataColumn columnNewSeat;
            private DataColumn columnPID;
            private DataColumn columnRealAgeSt;
            private DataColumn columnSeat;
            private DataColumn columnSeatGuy;
            private DataColumn columnSexID;
            private DataColumn columnStMemos;
            private DataColumn columnTel1;
            private DataColumn columnYears;
            private DataColumn columnYearsGrade;
            private DataColumn columnZip;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStRowChangeEventHandler vStRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStRowChangeEventHandler vStRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStRowChangeEventHandler vStRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSt.vStRowChangeEventHandler vStRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vStDataTable()
            {
                base.TableName = "vSt";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vStDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected vStDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddvStRow(dsSt.vStRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStRow AddvStRow(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short NewClassID, short NewSeat, string Blood, string cSex, short GradeID, string Grade, string Class, string YearsGrade, int RealAgeSt, string SeatGuy, short Aborigine, string GradeIDClassIDSeat, string StMemos)
            {
                dsSt.vStRow row = (dsSt.vStRow)base.NewRow();
                row.ItemArray = new object[] {
                    PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall, NewClassID,
                    NewSeat, Blood, cSex, GradeID, Grade, Class, YearsGrade, RealAgeSt, SeatGuy, Aborigine, GradeIDClassIDSeat, StMemos
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSt.vStDataTable table = (dsSt.vStDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSt.vStDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSt.vStRow FindByPID(string PID)
            {
                return (dsSt.vStRow)base.Rows.Find(new object[] { PID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSt.vStRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSt st = new dsSt();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = st.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "vStDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = st.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnGuyID = new DataColumn("GuyID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuyID);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnBirthday = new DataColumn("Birthday", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnBirthday);
                this.columnDad = new DataColumn("Dad", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDad);
                this.columnMom = new DataColumn("Mom", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMom);
                this.columnGuardian = new DataColumn("Guardian", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuardian);
                this.columnZip = new DataColumn("Zip", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZip);
                this.columnTel1 = new DataColumn("Tel1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTel1);
                this.columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddress);
                this.columnEmergencyCall = new DataColumn("EmergencyCall", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEmergencyCall);
                this.columnNewClassID = new DataColumn("NewClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNewClassID);
                this.columnNewSeat = new DataColumn("NewSeat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNewSeat);
                this.columnBlood = new DataColumn("Blood", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBlood);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnYearsGrade = new DataColumn("YearsGrade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsGrade);
                this.columnRealAgeSt = new DataColumn("RealAgeSt", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnRealAgeSt);
                this.columnSeatGuy = new DataColumn("SeatGuy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSeatGuy);
                this.columnAborigine = new DataColumn("Aborigine", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnAborigine);
                this.columnGradeIDClassIDSeat = new DataColumn("GradeIDClassIDSeat", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGradeIDClassIDSeat);
                this.columnStMemos = new DataColumn("StMemos", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnStMemos);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.Unique = true;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnGuyID.MaxLength = 10;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnBirthday.AllowDBNull = false;
                this.columnDad.MaxLength = 100;
                this.columnMom.MaxLength = 100;
                this.columnGuardian.MaxLength = 100;
                this.columnZip.AllowDBNull = false;
                this.columnZip.MaxLength = 3;
                this.columnTel1.MaxLength = 12;
                //this.columnAddress.MaxLength = 30;
                //this.columnEmergencyCall.MaxLength = 60;
                this.columnBlood.MaxLength = 2;
                this.columncSex.MaxLength = 2;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columnYearsGrade.ReadOnly = true;
                this.columnYearsGrade.MaxLength = 0x22;
                this.columnRealAgeSt.ReadOnly = true;
                this.columnSeatGuy.ReadOnly = true;
                this.columnSeatGuy.MaxLength = 100;
                this.columnGradeIDClassIDSeat.ReadOnly = true;
                this.columnGradeIDClassIDSeat.MaxLength = 0x2a;
                // this.columnStMemos.MaxLength = 0xff;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnGuyID = base.Columns["GuyID"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnBirthday = base.Columns["Birthday"];
                this.columnDad = base.Columns["Dad"];
                this.columnMom = base.Columns["Mom"];
                this.columnGuardian = base.Columns["Guardian"];
                this.columnZip = base.Columns["Zip"];
                this.columnTel1 = base.Columns["Tel1"];
                this.columnAddress = base.Columns["Address"];
                this.columnEmergencyCall = base.Columns["EmergencyCall"];
                this.columnNewClassID = base.Columns["NewClassID"];
                this.columnNewSeat = base.Columns["NewSeat"];
                this.columnBlood = base.Columns["Blood"];
                this.columncSex = base.Columns["cSex"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columnYearsGrade = base.Columns["YearsGrade"];
                this.columnRealAgeSt = base.Columns["RealAgeSt"];
                this.columnSeatGuy = base.Columns["SeatGuy"];
                this.columnAborigine = base.Columns["Aborigine"];
                this.columnGradeIDClassIDSeat = base.Columns["GradeIDClassIDSeat"];
                this.columnStMemos = base.Columns["StMemos"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSt.vStRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStRow NewvStRow()
            {
                return (dsSt.vStRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vStRowChanged != null)
                {
                    this.vStRowChanged(this, new dsSt.vStRowChangeEvent((dsSt.vStRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vStRowChanging != null)
                {
                    this.vStRowChanging(this, new dsSt.vStRowChangeEvent((dsSt.vStRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vStRowDeleted != null)
                {
                    this.vStRowDeleted(this, new dsSt.vStRowChangeEvent((dsSt.vStRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vStRowDeleting != null)
                {
                    this.vStRowDeleting(this, new dsSt.vStRowChangeEvent((dsSt.vStRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovevStRow(dsSt.vStRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn AborigineColumn
            {
                get
                {
                    return this.columnAborigine;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn AddressColumn
            {
                get
                {
                    return this.columnAddress;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BirthdayColumn
            {
                get
                {
                    return this.columnBirthday;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BloodColumn
            {
                get
                {
                    return this.columnBlood;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassColumn
            {
                get
                {
                    return this.columnClass;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DadColumn
            {
                get
                {
                    return this.columnDad;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn EmergencyCallColumn
            {
                get
                {
                    return this.columnEmergencyCall;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeColumn
            {
                get
                {
                    return this.columnGrade;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GradeIDClassIDSeatColumn
            {
                get
                {
                    return this.columnGradeIDClassIDSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GradeIDColumn
            {
                get
                {
                    return this.columnGradeID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuardianColumn
            {
                get
                {
                    return this.columnGuardian;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuyIDColumn
            {
                get
                {
                    return this.columnGuyID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStRow this[int index]
            {
                get
                {
                    return (dsSt.vStRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn MomColumn
            {
                get
                {
                    return this.columnMom;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NewClassIDColumn
            {
                get
                {
                    return this.columnNewClassID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NewSeatColumn
            {
                get
                {
                    return this.columnNewSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PIDColumn
            {
                get
                {
                    return this.columnPID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn RealAgeStColumn
            {
                get
                {
                    return this.columnRealAgeSt;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SeatGuyColumn
            {
                get
                {
                    return this.columnSeatGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn StMemosColumn
            {
                get
                {
                    return this.columnStMemos;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Tel1Column
            {
                get
                {
                    return this.columnTel1;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn YearsGradeColumn
            {
                get
                {
                    return this.columnYearsGrade;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ZipColumn
            {
                get
                {
                    return this.columnZip;
                }
            }
        }

        public class vStRow : DataRow
        {
            private dsSt.vStDataTable tablevSt;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vStRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevSt = (dsSt.vStDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAborigineNull()
            {
                return base.IsNull(this.tablevSt.AborigineColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAddressNull()
            {
                return base.IsNull(this.tablevSt.AddressColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsBloodNull()
            {
                return base.IsNull(this.tablevSt.BloodColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevSt.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevSt.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDadNull()
            {
                return base.IsNull(this.tablevSt.DadColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsEmergencyCallNull()
            {
                return base.IsNull(this.tablevSt.EmergencyCallColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeIDClassIDSeatNull()
            {
                return base.IsNull(this.tablevSt.GradeIDClassIDSeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tablevSt.GradeIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevSt.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuardianNull()
            {
                return base.IsNull(this.tablevSt.GuardianColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyIDNull()
            {
                return base.IsNull(this.tablevSt.GuyIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevSt.GuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMomNull()
            {
                return base.IsNull(this.tablevSt.MomColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNewClassIDNull()
            {
                return base.IsNull(this.tablevSt.NewClassIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNewSeatNull()
            {
                return base.IsNull(this.tablevSt.NewSeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRealAgeStNull()
            {
                return base.IsNull(this.tablevSt.RealAgeStColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatGuyNull()
            {
                return base.IsNull(this.tablevSt.SeatGuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevSt.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsStMemosNull()
            {
                return base.IsNull(this.tablevSt.StMemosColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTel1Null()
            {
                return base.IsNull(this.tablevSt.Tel1Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsYearsGradeNull()
            {
                return base.IsNull(this.tablevSt.YearsGradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAborigineNull()
            {
                base[this.tablevSt.AborigineColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAddressNull()
            {
                base[this.tablevSt.AddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBloodNull()
            {
                base[this.tablevSt.BloodColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tablevSt.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tablevSt.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDadNull()
            {
                base[this.tablevSt.DadColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetEmergencyCallNull()
            {
                base[this.tablevSt.EmergencyCallColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeIDClassIDSeatNull()
            {
                base[this.tablevSt.GradeIDClassIDSeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeIDNull()
            {
                base[this.tablevSt.GradeIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tablevSt.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuardianNull()
            {
                base[this.tablevSt.GuardianColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyIDNull()
            {
                base[this.tablevSt.GuyIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tablevSt.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMomNull()
            {
                base[this.tablevSt.MomColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNewClassIDNull()
            {
                base[this.tablevSt.NewClassIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNewSeatNull()
            {
                base[this.tablevSt.NewSeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetRealAgeStNull()
            {
                base[this.tablevSt.RealAgeStColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatGuyNull()
            {
                base[this.tablevSt.SeatGuyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tablevSt.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetStMemosNull()
            {
                base[this.tablevSt.StMemosColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTel1Null()
            {
                base[this.tablevSt.Tel1Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetYearsGradeNull()
            {
                base[this.tablevSt.YearsGradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Aborigine
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSt.AborigineColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Aborigine' in table 'vSt' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSt.AborigineColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Address
            {
                get
                {
                    if (this.IsAddressNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.AddressColumn];
                }
                set
                {
                    base[this.tablevSt.AddressColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DateTime Birthday
            {
                get
                {
                    return (DateTime)base[this.tablevSt.BirthdayColumn];
                }
                set
                {
                    base[this.tablevSt.BirthdayColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Blood
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.BloodColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Blood' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.BloodColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tablevSt.ClassIDColumn];
                }
                set
                {
                    base[this.tablevSt.ClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string cSex
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.cSexColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Dad
            {
                get
                {
                    if (this.IsDadNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.DadColumn];
                }
                set
                {
                    base[this.tablevSt.DadColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string EmergencyCall
            {
                get
                {
                    if (this.IsEmergencyCallNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.EmergencyCallColumn];
                }
                set
                {
                    base[this.tablevSt.EmergencyCallColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Grade
            {
                get
                {
                    if (this.IsGradeNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.GradeColumn];
                }
                set
                {
                    base[this.tablevSt.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    if (this.IsGradeIDNull())
                    {
                        return 0;
                    }
                    return (short)base[this.tablevSt.GradeIDColumn];
                }
                set
                {
                    base[this.tablevSt.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string GradeIDClassIDSeat
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.GradeIDClassIDSeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeIDClassIDSeat' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.GradeIDClassIDSeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Guardian
            {
                get
                {
                    if (this.IsGuardianNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.GuardianColumn];
                }
                set
                {
                    base[this.tablevSt.GuardianColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Guy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GuyID
            {
                get
                {
                    if (this.IsGuyIDNull())
                    {
                        return string.Empty;
                    }
                    return (string)base[this.tablevSt.GuyIDColumn];
                }
                set
                {
                    base[this.tablevSt.GuyIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Mom
            {
                get
                {
                    if (this.IsMomNull())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.MomColumn];
                }
                set
                {
                    base[this.tablevSt.MomColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short NewClassID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSt.NewClassIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NewClassID' in table 'vSt' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSt.NewClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short NewSeat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSt.NewSeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NewSeat' in table 'vSt' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSt.NewSeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string)base[this.tablevSt.PIDColumn];
                }
                set
                {
                    base[this.tablevSt.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int RealAgeSt
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[this.tablevSt.RealAgeStColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'RealAgeSt' in table 'vSt' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSt.RealAgeStColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Seat
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tablevSt.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vSt' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSt.SeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SeatGuy
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.SeatGuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SeatGuy' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.SeatGuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short)base[this.tablevSt.SexIDColumn];
                }
                set
                {
                    base[this.tablevSt.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string StMemos
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.StMemosColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'StMemos' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.StMemosColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Tel1
            {
                get
                {
                    if (this.IsTel1Null())
                    {
                        return null;
                    }
                    return (string)base[this.tablevSt.Tel1Column];
                }
                set
                {
                    base[this.tablevSt.Tel1Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Years
            {
                get
                {
                    return (short)base[this.tablevSt.YearsColumn];
                }
                set
                {
                    base[this.tablevSt.YearsColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string YearsGrade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tablevSt.YearsGradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsGrade' in table 'vSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSt.YearsGradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Zip
            {
                get
                {
                    return (string)base[this.tablevSt.ZipColumn];
                }
                set
                {
                    base[this.tablevSt.ZipColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vStRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSt.vStRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public vStRowChangeEvent(dsSt.vStRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSt.vStRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vStRowChangeEventHandler(object sender, dsSt.vStRowChangeEvent e);
    }
}

