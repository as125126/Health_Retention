namespace HealthShare.OthersTableAdapters
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

    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DesignerCategory("code"), ToolboxItem(true), DataObject(true), HelpKeyword("vs.data.TableAdapter")]
    public class ColumnSetTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public ColumnSetTableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual string ColumnC(string ColumnID)
        {
            object obj2;
            SqlCommand command = this.CommandCollection[1];
            if (ColumnID == null)
            {
                throw new ArgumentNullException("ColumnID");
            }
            command.Parameters[0].Value = ColumnID;
            ConnectionState state = command.Connection.State;
            if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                command.Connection.Open();
            }
            try
            {
                obj2 = command.ExecuteScalar();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    command.Connection.Close();
                }
            }
            if ((obj2 == null) || (obj2.GetType() == typeof(DBNull)))
            {
                return null;
            }
            return (string)obj2;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(Others.ColumnSetDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Fill, false), HelpKeyword("vs.data.TableAdapter")]
        public virtual int FillID(Others.ColumnSetDataTable dataTable, string ColumnID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (ColumnID == null)
            {
                throw new ArgumentNullException("ColumnID");
            }
            this.Adapter.SelectCommand.Parameters[0].Value = ColumnID;
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual Others.ColumnSetDataTable Get()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            Others.ColumnSetDataTable dataTable = new Others.ColumnSetDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual Others.ColumnSetDataTable GetID(string ColumnID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (ColumnID == null)
            {
                throw new ArgumentNullException("ColumnID");
            }
            this.Adapter.SelectCommand.Parameters[0].Value = ColumnID;
            Others.ColumnSetDataTable dataTable = new Others.ColumnSetDataTable();
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
                DataSetTable = "ColumnSet"
            };
            mapping.ColumnMappings.Add("ColumnID", "ColumnID");
            mapping.ColumnMappings.Add("ColumnC", "ColumnC");
            mapping.ColumnMappings.Add("ColWidth", "ColWidth");
            mapping.ColumnMappings.Add("ColType", "ColType");
            mapping.ColumnMappings.Add("ColState", "ColState");
            this._adapter.TableMappings.Add(mapping);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[3];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT          ColumnID, ColumnC, ColWidth, ColType, ColState\r\nFROM              ColumnSet";
            this._commandCollection[0].CommandType = CommandType.Text;
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "SELECT          ColumnC\r\nFROM              ColumnSet\r\nWHERE          (ColumnID = @ColumnID)";
            this._commandCollection[1].CommandType = CommandType.Text;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@ColumnID", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "ColumnID", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "SELECT          ColumnID, ColumnC, ColWidth, ColType, ColState\r\nFROM              ColumnSet where ColumnID=@ColumnID";
            this._commandCollection[2].CommandType = CommandType.Text;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@ColumnID", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "ColumnID", DataRowVersion.Current, false, null, "", "", ""));
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.Health;
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

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

