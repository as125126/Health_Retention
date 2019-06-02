namespace HealthShare.dsSchoolTableAdapters
{
    using HealthShare;
    using HealthShare.Properties;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Web.UI.WebControls;
    using WillNs;

    [ToolboxItem(true), DesignerCategory("code"), DataObject(true), HelpKeyword("vs.data.TableAdapter"), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class GradeTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public GradeTableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        public ListItemCollection CheckGrade(enSchoolRank Rank)
        {
            ListItemCollection items = new ListItemCollection();
            switch (Rank)
            {
                case enSchoolRank.Primary:
                    items.Add(new ListItem("一", "1"));
                    items.Add(new ListItem("四", "4"));
                    return items;

                case enSchoolRank.Junior:
                    items.Add(new ListItem("七", "7"));
                    return items;

                case enSchoolRank.JuniorPrimary:
                    items.Add(new ListItem("一", "1"));
                    items.Add(new ListItem("四", "4"));
                    items.Add(new ListItem("七", "7"));
                    return items;

                case enSchoolRank.Senior:
                case enSchoolRank.Senior4:
                    items.Add(new ListItem("高一", "10"));
                    return items;

                case enSchoolRank.Complete:
                    items.Add(new ListItem("七", "7"));
                    items.Add(new ListItem("高一", "10"));
                    return items;
            }
            return items;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Delete, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Del_All()
        {
            int num;
            SqlCommand command = this.CommandCollection[1];
            ConnectionState state = command.Connection.State;
            if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                command.Connection.Open();
            }
            try
            {
                num = command.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    command.Connection.Close();
                }
            }
            return num;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Delete, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Delete(short Original_GradeID, short Original_Years, string Original_Grade)
        {
            int num2;
            this.Adapter.DeleteCommand.Parameters[0].Value = Original_GradeID;
            this.Adapter.DeleteCommand.Parameters[1].Value = Original_Years;
            if (Original_Grade == null)
            {
                this.Adapter.DeleteCommand.Parameters[2].Value = 1;
                this.Adapter.DeleteCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.DeleteCommand.Parameters[2].Value = 0;
                this.Adapter.DeleteCommand.Parameters[3].Value = Original_Grade;
            }
            ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
            if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.DeleteCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.DeleteCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.DeleteCommand.Connection.Close();
                }
            }
            return num2;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(dsSchool.GradeDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Fill, false)]
        public virtual int Fill_InSchool(dsSchool.GradeDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual dsSchool.GradeDataTable Get_InSchool()
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            dsSchool.GradeDataTable dataTable = new dsSchool.GradeDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual dsSchool.GradeDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            dsSchool.GradeDataTable dataTable = new dsSchool.GradeDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        public void IncreseGrade()
        {
            string str = "Update Grade set Years= Years+1; Update Grade9 set Years= Years+1";
            DM.ExecuteNonQuery(str);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping
            {
                SourceTable = "Table",
                DataSetTable = "Grade"
            };
            mapping.ColumnMappings.Add("Years", "Years");
            mapping.ColumnMappings.Add("Grade", "Grade");
            mapping.ColumnMappings.Add("YearsGrade", "YearsGrade");
            mapping.ColumnMappings.Add("GradeID", "GradeID");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [Grade] WHERE (([GradeID] = @Original_GradeID) AND ([Years] = @Original_Years) AND ((@IsNull_Grade = 1 AND [Grade] IS NULL) OR ([Grade] = @Original_Grade)))";
            this._adapter.DeleteCommand.CommandType = CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GradeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "GradeID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Years", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Grade", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [Grade] ([GradeID], [Years], [Grade]) VALUES (@GradeID, @Years, @Grade);\r\nSELECT GradeID, Years, Grade FROM Grade WHERE (GradeID = @GradeID)";
            this._adapter.InsertCommand.CommandType = CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@GradeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "GradeID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [Grade] SET [GradeID] = @GradeID, [Years] = @Years, [Grade] = @Grade WHERE (([GradeID] = @Original_GradeID) AND ([Years] = @Original_Years) AND ((@IsNull_Grade = 1 AND [Grade] IS NULL) OR ([Grade] = @Original_Grade)));\r\nSELECT GradeID, Years, Grade FROM Grade WHERE (GradeID = @GradeID)";
            this._adapter.UpdateCommand.CommandType = CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GradeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "GradeID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GradeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "GradeID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Years", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Grade", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[3];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT          Years, Grade, GradeYear AS YearsGrade, GradeID\r\nFROM              vGrade\r\nORDER BY   Years DESC";
            this._commandCollection[0].CommandType = CommandType.Text;
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "DELETE FROM [Grade]";
            this._commandCollection[1].CommandType = CommandType.Text;
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "SELECT          Grade, GradeID, GradeYear AS YearsGrade, Years\r\nFROM              vGrade\r\nWHERE          (GradeID IS NOT NULL)\r\nORDER BY   GradeID";
            this._commandCollection[2].CommandType = CommandType.Text;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.Health;
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Insert(short GradeID, short Years, string Grade)
        {
            int num2;
            this.Adapter.InsertCommand.Parameters[0].Value = GradeID;
            this.Adapter.InsertCommand.Parameters[1].Value = Years;
            if (Grade == null)
            {
                this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = Grade;
            }
            ConnectionState state = this.Adapter.InsertCommand.Connection.State;
            if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.InsertCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
            return num2;
        }

        /*
        public virtual void MakeGrades(int iRank)
        {
            int schYears = dsSchool.SchYearsSemNow().SchYears;//取得當前學年
            int Max = 9;//最高年級
            short Min = 1;//最低年級

            #region 設定最低與最高年級
            switch (iRank)
            {
                case 1:
                    Max = 6;
                    break;
                case 2:
                    Max = 9;
                    Min = 7;
                    break;
                case 3:
                    Max = 9;
                    break;
                case 4:
                    Max = 12;
                    Min = 10;
                    break;
                case 5:
                    Max = 12;
                    Min = 7;
                    break;
                case 6:
                    Max = 13;
                    Min = 10;
                    break;
            }
            #endregion

            #region 設定 Grade 資料
            this.Del_All();

            for (short i = Min; i <= Max; i = (short)(i + 1))
            {
                short gradeID = i;//年級
                short years = (short)((schYears - i) + 1);//學年
                string grade = Util.CGrade(i);//年級（中文）

                //新增資料
                this.Insert(gradeID, years, grade);
            }
            #endregion

            #region 設定 Grade9 資料
            Grade9TableAdapter adapter = new Grade9TableAdapter
            {
                Connection = { ConnectionString = Se.sMyConnStr }
            };
            adapter.Dell_All();

            for (short i = 1; i <= 13; i = (short)(i + 1))
            {
                adapter.Insert(i, (short)((schYears - i) + 1), Util.CGrade(i));
            }
            #endregion
        }
        */

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(dsSchool dataSet)
        {
            return this.Adapter.Update(dataSet, "Grade");
        }

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(dsSchool.GradeDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(short GradeID, string Grade, short Original_GradeID, short Original_Years, string Original_Grade)
        {
            return this.Update(GradeID, Original_Years, Grade, Original_GradeID, Original_Years, Original_Grade);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Update, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(short GradeID, short Years, string Grade, short Original_GradeID, short Original_Years, string Original_Grade)
        {
            int num2;
            this.Adapter.UpdateCommand.Parameters[0].Value = GradeID;
            this.Adapter.UpdateCommand.Parameters[1].Value = Years;
            if (Grade == null)
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = Grade;
            }
            this.Adapter.UpdateCommand.Parameters[3].Value = Original_GradeID;
            this.Adapter.UpdateCommand.Parameters[4].Value = Original_Years;
            if (Original_Grade == null)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = 1;
                this.Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = 0;
                this.Adapter.UpdateCommand.Parameters[6].Value = Original_Grade;
            }
            ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
            if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.UpdateCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.UpdateCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.UpdateCommand.Connection.Close();
                }
            }
            return num2;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private SqlDataAdapter Adapter
        {
            get
            {
                if (this._adapter == null)
                {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public bool ClearBeforeFill
        {
            get
            {
                return this._clearBeforeFill;
            }
            set
            {
                this._clearBeforeFill = value;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected SqlCommand[] CommandCollection
        {
            get
            {
                if (this._commandCollection == null)
                {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public SqlConnection Connection
        {
            get
            {
                if (this._connection == null)
                {
                    this.InitConnection();
                }
                return this._connection;
            }
            set
            {
                this._connection = value;
                if (this.Adapter.InsertCommand != null)
                {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if (this.Adapter.DeleteCommand != null)
                {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if (this.Adapter.UpdateCommand != null)
                {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    if (this.CommandCollection[i] != null)
                    {
                        this.CommandCollection[i].Connection = value;
                    }
                }
            }
        }
    }
}

