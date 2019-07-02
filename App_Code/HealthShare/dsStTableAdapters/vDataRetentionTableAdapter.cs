namespace HealthShare.dsStTableAdapters
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

    [DataObject(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), ToolboxItem(true)]
    public class vDataRetentionTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public vDataRetentionTableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Delete, true)]
        public virtual int Delete(string Original_PID)
        {
            int num2;
            if (Original_PID == null)
            {
                throw new ArgumentNullException("Original_PID");
            }
            this.Adapter.DeleteCommand.Parameters[0].Value = Original_PID;
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

        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int DeleteAborigine(string PID)
        {
            int num;
            SqlCommand command = this.CommandCollection[1];
            if (PID == null)
            {
                throw new ArgumentNullException("PID");
            }
            command.Parameters[0].Value = PID;
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

        //[DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual dsSt.vStDataTable Get_Years(short Years)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            this.Adapter.SelectCommand.Parameters[0].Value = Years;
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual dsSt.vStDataTable Get_PIDEncrypt(string PIDEncrypt)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (PIDEncrypt == null)
            {
                throw new ArgumentNullException("PIDEncrypt");
            }
            this.Adapter.SelectCommand.Parameters[0].Value = PIDEncrypt;
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
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
                DataSetTable = "DataRetention"
            };
            //mapping.ColumnMappings.Add("UnDate", "UnDate");
            mapping.ColumnMappings.Add("PID", "PID");
            mapping.ColumnMappings.Add("Guy", "Guy");
            mapping.ColumnMappings.Add("GuyID", "GuyID");
            mapping.ColumnMappings.Add("SexID", "SexID");
            mapping.ColumnMappings.Add("Years", "Years");
            mapping.ColumnMappings.Add("ClassID", "ClassID");
            mapping.ColumnMappings.Add("Seat", "Seat");
            mapping.ColumnMappings.Add("Birthday", "Birthday");
            mapping.ColumnMappings.Add("Dad", "Dad");
            mapping.ColumnMappings.Add("Mom", "Mom");
            mapping.ColumnMappings.Add("Guardian", "Guardian");
            mapping.ColumnMappings.Add("Zip", "Zip");
            mapping.ColumnMappings.Add("Tel1", "Tel1");
            mapping.ColumnMappings.Add("Address", "Address");
            mapping.ColumnMappings.Add("EmergencyCall", "EmergencyCall");
            mapping.ColumnMappings.Add("NewClassID", "NewClassID");
            mapping.ColumnMappings.Add("NewSeat", "NewSeat");
            mapping.ColumnMappings.Add("Blood", "Blood");
            mapping.ColumnMappings.Add("cSex", "cSex");
            mapping.ColumnMappings.Add("GradeID", "GradeID");
            mapping.ColumnMappings.Add("Grade", "Grade");
            mapping.ColumnMappings.Add("Class", "Class");
            mapping.ColumnMappings.Add("YearsGrade", "YearsGrade");
            mapping.ColumnMappings.Add("RealAgeSt", "RealAgeSt");
            mapping.ColumnMappings.Add("SeatGuy", "SeatGuy");
            mapping.ColumnMappings.Add("Aborigine", "Aborigine");
            mapping.ColumnMappings.Add("GradeIDClassIDSeat", "GradeIDClassIDSeat");
            mapping.ColumnMappings.Add("StMemos", "StMemos");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [DataRetention] WHERE (([PID] = @Original_PID))";
            this._adapter.DeleteCommand.CommandType = CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            //this._adapter.InsertCommand.CommandText = "INSERT INTO DataRetention (UnDate,PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall,NewClassID, NewSeat, Blood, Aborigine, StMemos, InSch) VALUES  (@UnDate,@PID,@Guy,@GuyID,@SexID,@Years,@ClassID,@Seat,@Birthday,@Dad,@Mom,@Guardian,@Zip,@Tel1,@Address,@EmergencyCall,@NewClassID,@NewSeat,@Blood,@Aborigine,@StMemos,@InSch)";
            this._adapter.InsertCommand.CommandText = "INSERT INTO DataRetention (PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall,NewClassID, NewSeat, Blood, Aborigine, StMemos, InSch) VALUES  (@PID,@Guy,@GuyID,@SexID,@Years,@ClassID,@Seat,@Birthday,@Dad,@Mom,@Guardian,@Zip,@Tel1,@Address,@EmergencyCall,@NewClassID,@NewSeat,@Blood,@Aborigine,@StMemos,@InSch)";
            this._adapter.InsertCommand.CommandType = CommandType.Text;
            //this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UnDate", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "UnDate", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guy", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guy", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@GuyID", SqlDbType.VarChar, 10, ParameterDirection.Input, 0, 0, "GuyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SexID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "SexID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "ClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Seat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Seat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "Birthday", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Dad", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Dad", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mom", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Mom", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Zip", SqlDbType.NVarChar, 3, ParameterDirection.Input, 0, 0, "Zip", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tel1", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Tel1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 4000, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EmergencyCall", SqlDbType.NVarChar, 60, ParameterDirection.Input, 0, 0, "EmergencyCall", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NewClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NewSeat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewSeat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Blood", SqlDbType.VarChar, 2, ParameterDirection.Input, 0, 0, "Blood", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Aborigine", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Aborigine", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@StMemos", SqlDbType.NVarChar, 0xff, ParameterDirection.Input, 0, 0, "StMemos", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@InSch", SqlDbType.Char, 1, ParameterDirection.Input, 0, 0, "InSch", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            //this._adapter.UpdateCommand.CommandText = "UPDATE  DataRetention SET UnDate = @UnDate, PID = @PID, Guy = @Guy, GuyID = @GuyID, SexID = @SexID, Years = @Years, ClassID = @ClassID, Seat = @Seat,Birthday = @Birthday, Dad = @Dad, Mom = @Mom, Guardian = @Guardian, Zip = @Zip, Tel1 = @Tel1,Address = @Address, EmergencyCall = @EmergencyCall, NewClassID = @NewClassID, NewSeat = @NewSeat,Blood = @Blood, Aborigine = @Aborigine, StMemos = @StMemos, InSch = @InSch  WHERE (PID = @Original_PID)";
            this._adapter.UpdateCommand.CommandText = "UPDATE  DataRetention SET PID = @PID, Guy = @Guy, GuyID = @GuyID, SexID = @SexID, Years = @Years, ClassID = @ClassID, Seat = @Seat,Birthday = @Birthday, Dad = @Dad, Mom = @Mom, Guardian = @Guardian, Zip = @Zip, Tel1 = @Tel1,Address = @Address, EmergencyCall = @EmergencyCall, NewClassID = @NewClassID, NewSeat = @NewSeat,Blood = @Blood, Aborigine = @Aborigine, StMemos = @StMemos, InSch = @InSch  WHERE (PID = @Original_PID)";
            this._adapter.UpdateCommand.CommandType = CommandType.Text;
            //this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UnDate", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "UnDate", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guy", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guy", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GuyID", SqlDbType.VarChar, 10, ParameterDirection.Input, 0, 0, "GuyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SexID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "SexID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "ClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Seat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Seat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "Birthday", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Dad", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Dad", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mom", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Mom", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Zip", SqlDbType.NVarChar, 3, ParameterDirection.Input, 0, 0, "Zip", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Tel1", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Tel1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 4000, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EmergencyCall", SqlDbType.NVarChar, 60, ParameterDirection.Input, 0, 0, "EmergencyCall", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewSeat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewSeat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Blood", SqlDbType.VarChar, 2, ParameterDirection.Input, 0, 0, "Blood", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Aborigine", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Aborigine", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StMemos", SqlDbType.NVarChar, 0xff, ParameterDirection.Input, 0, 0, "StMemos", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@InSch", SqlDbType.Char, 1, ParameterDirection.Input, 0, 0, "InSch", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[2];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT * FROM  DataRetention  WHERE  (Years = @Years)  ORDER BY   ClassID, Seat ";
            this._commandCollection[0].CommandType = CommandType.Text;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "SELECT * FROM  DataRetention  WHERE  (dbo.encryptPID(PID) = @PIDEncrypt)";
            this._commandCollection[1].CommandType = CommandType.Text;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@PIDEncrypt", SqlDbType.VarChar, 0x400, ParameterDirection.Input, 0, 0, "", DataRowVersion.Current, false, null, "", "", ""));

        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.Health;
        }

        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short? Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short? NewClassID, short? NewSeat, string Blood, short? Aborigine, string StMemos, string InSch)
        {
            int num2;

            //this.Adapter.InsertCommand.Parameters[0].Value = UnMigrateDate;
            if (PID == null)
            {
                throw new ArgumentNullException("PID");
            }
            this.Adapter.InsertCommand.Parameters[0].Value = PID;
            if (Guy == null)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[1].Value = Guy;
            }
            if (GuyID == null)
            {
                this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = GuyID;
            }
            this.Adapter.InsertCommand.Parameters[3].Value = SexID;
            this.Adapter.InsertCommand.Parameters[4].Value = Years;
            this.Adapter.InsertCommand.Parameters[5].Value = ClassID;
            if (Seat.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[6].Value = Seat.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
            }
            this.Adapter.InsertCommand.Parameters[7].Value = Birthday;
            if (Dad == null)
            {
                this.Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[8].Value = Dad;
            }
            if (Mom == null)
            {
                this.Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[9].Value = Mom;
            }
            if (Guardian == null)
            {
                this.Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[10].Value = Guardian;
            }
            if (Zip == null)
            {
                throw new ArgumentNullException("Zip");
            }
            this.Adapter.InsertCommand.Parameters[11].Value = Zip;
            if (Tel1 == null)
            {
                this.Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[12].Value = Tel1;
            }
            if (Address == null)
            {
                this.Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[13].Value = Address;
            }
            if (EmergencyCall == null)
            {
                this.Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[14].Value = EmergencyCall;
            }
            if (NewClassID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[15].Value = NewClassID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
            }
            if (NewSeat.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[0x10].Value = NewSeat.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x10].Value = DBNull.Value;
            }
            if (Blood == null)
            {
                this.Adapter.InsertCommand.Parameters[0x11].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x11].Value = Blood;
            }
            if (Aborigine.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[0x12].Value = Aborigine.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x12].Value = DBNull.Value;
            }
            if (StMemos == null)
            {
                this.Adapter.InsertCommand.Parameters[0x13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x13].Value = StMemos;
            }
            if (InSch == null)
            {
                this.Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[20].Value = InSch;
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(dsSt dataSet)
        {
            return this.Adapter.Update(dataSet, "DataRetention");
        }

        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(dsSt.vStaDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }

        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Update, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(string Guy, string GuyID, short SexID, short Years, short ClassID, short? Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short? NewClassID, short? NewSeat, string Blood, short? Aborigine, string StMemos, string InSch, string Original_PID)
        {
            return this.Update(Original_PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall, NewClassID, NewSeat, Blood, Aborigine, StMemos, InSch, Original_PID);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Update, true)]
        public virtual int Update(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short? Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short? NewClassID, short? NewSeat, string Blood, short? Aborigine, string StMemos, string InSch, string Original_PID)
        {
            int num2;

            //this.Adapter.UpdateCommand.Parameters[0].Value = UnDate;
            if (PID == null)
            {
                throw new ArgumentNullException("PID");
            }
            this.Adapter.UpdateCommand.Parameters[0].Value = PID;
            if (Guy == null)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = Guy;
            }
            if (GuyID == null)
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = GuyID;
            }
            this.Adapter.UpdateCommand.Parameters[3].Value = SexID;
            this.Adapter.UpdateCommand.Parameters[4].Value = Years;
            this.Adapter.UpdateCommand.Parameters[5].Value = ClassID;
            if (Seat.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = Seat.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            this.Adapter.UpdateCommand.Parameters[7].Value = Birthday;
            if (Dad == null)
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = Dad;
            }
            if (Mom == null)
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = Mom;
            }
            if (Guardian == null)
            {
                this.Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[10].Value = Guardian;
            }
            if (Zip == null)
            {
                throw new ArgumentNullException("Zip");
            }
            this.Adapter.UpdateCommand.Parameters[11].Value = Zip;
            if (Tel1 == null)
            {
                this.Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[12].Value = Tel1;
            }
            if (Address == null)
            {
                this.Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[13].Value = Address;
            }
            if (EmergencyCall == null)
            {
                this.Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[14].Value = EmergencyCall;
            }
            if (NewClassID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[15].Value = NewClassID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
            }
            if (NewSeat.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[0x10].Value = NewSeat.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x10].Value = DBNull.Value;
            }
            if (Blood == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x11].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x11].Value = Blood;
            }
            if (Aborigine.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[0x12].Value = Aborigine.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x12].Value = DBNull.Value;
            }
            if (StMemos == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x13].Value = StMemos;
            }
            if (InSch == null)
            {
                this.Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[20].Value = InSch;
            }
            if (Original_PID == null)
            {
                throw new ArgumentNullException("Original_PID");
            }
            this.Adapter.UpdateCommand.Parameters[0x15].Value = Original_PID;
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

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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

