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

    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DesignerCategory("code"), ToolboxItem(true), HelpKeyword("vs.data.TableAdapter"), DataObject(true)]
    public class ClassSelTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public ClassSelTableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        [DataObjectMethod(DataObjectMethodType.Fill, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Fill(dsSchool.ClassSelDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Fill, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int FillAll(dsSchool.ClassSelDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual dsSchool.ClassSelDataTable GetAll()
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            dsSchool.ClassSelDataTable dataTable = new dsSchool.ClassSelDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual dsSchool.ClassSelDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            dsSchool.ClassSelDataTable dataTable = new dsSchool.ClassSelDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping
            {
                SourceTable = "Table",
                DataSetTable = "ClassSel"
            };
            mapping.ColumnMappings.Add("Years", "Years");
            mapping.ColumnMappings.Add("ClassID", "ClassID");
            mapping.ColumnMappings.Add("YearsClass", "YearsClass");
            mapping.ColumnMappings.Add("YearsGradeClass", "YearsGradeClass");
            this._adapter.TableMappings.Add(mapping);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[2];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT DISTINCT \r\n                            Years, ClassID, CAST(Years AS varchar(3)) + ',' + CAST(ClassID AS varchar(3)) AS YearsClass, \r\n                            GradeClass AS YearsGradeClass\r\nFROM              vClass\r\nWHERE          (Grade IS NOT NULL)\r\nUNION\r\nSELECT          '999' AS Years, '0' AS ClassID, '0,0' AS YearsClass, '請選擇' AS YearsGradeClass\r\nORDER BY   Years DESC, ClassID";
            this._commandCollection[0].CommandType = CommandType.Text;
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            /*
            this._commandCollection[1].CommandText = "SELECT DISTINCT \r\n                            Years, ClassID, CAST(Years AS varchar(3)) + ',' + CAST(ClassID AS varchar(3)) AS YearsClass, \r\n                            GradeClass AS YearsGradeClass\r\nFROM              vClass\r\nUNION\r\nSELECT          '999' AS Years, '0' AS ClassID, '0,0' AS YearsClass, '請選擇' AS YearsGradeClass\r\nORDER BY   Years DESC, ClassID";
            */
            this._commandCollection[1].CommandText =
                @"SELECT DISTINCT Years, 
                            ClassID, 
                            CAST(Years AS varchar(3)) + ',' + CAST(ClassID AS varchar(3)) AS YearsClass, 
                            GradeClass AS YearsGradeClass 
                FROM vClass 
                UNION  
                SELECT '999' AS Years, 
                        '0' AS ClassID, 
                        '0,0' AS YearsClass, 
                        '請選擇' AS YearsGradeClass 
                ORDER BY Years DESC, ClassID";
            this._commandCollection[1].CommandType = CommandType.Text;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.Health;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

