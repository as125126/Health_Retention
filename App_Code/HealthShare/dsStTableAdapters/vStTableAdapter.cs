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

    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxItem(true), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), DataObject(true)]
    public class vStTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public vStTableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true), HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
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

        [DataObjectMethod(DataObjectMethodType.Fill, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill(dsSt.vStDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Fill, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill_Aborigne(dsSt.vStDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Fill, false)]
        public virtual int Fill_Class(dsSt.vStDataTable dataTable, short Years, short ClassID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[3];
            this.Adapter.SelectCommand.Parameters[0].Value = Years;
            this.Adapter.SelectCommand.Parameters[1].Value = ClassID;
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Fill, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill_Guy(dsSt.vStDataTable dataTable, string Guy)
        {
            this.Adapter.SelectCommand = this.CommandCollection[4];
            if (Guy == null)
            {
                this.Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[0].Value = Guy;
            }
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Fill, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Fill_PID(dsSt.vStDataTable dataTable, string PID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[5];
            if (PID == null)
            {
                throw new ArgumentNullException("PID");
            }
            this.Adapter.SelectCommand.Parameters[0].Value = PID;
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Fill, false), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill_Years(dsSt.vStDataTable dataTable, short Years)
        {
            this.Adapter.SelectCommand = this.CommandCollection[6];
            this.Adapter.SelectCommand.Parameters[0].Value = Years;
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual dsSt.vStDataTable Get_Aborigne()
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual dsSt.vStDataTable Get_Class(short Years, short ClassID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[3];
            this.Adapter.SelectCommand.Parameters[0].Value = Years;
            this.Adapter.SelectCommand.Parameters[1].Value = ClassID;
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode]
        public virtual dsSt.vStDataTable Get_Guy(string Guy)
        {
            this.Adapter.SelectCommand = this.CommandCollection[4];
            if (Guy == null)
            {
                this.Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[0].Value = Guy;
            }
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual dsSt.vStDataTable Get_PID(string PID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[5];
            if (PID == null)
            {
                throw new ArgumentNullException("PID");
            }
            this.Adapter.SelectCommand.Parameters[0].Value = PID;
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual dsSt.vStDataTable Get_Years(short Years)
        {
            this.Adapter.SelectCommand = this.CommandCollection[6];
            this.Adapter.SelectCommand.Parameters[0].Value = Years;
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual dsSt.vStDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            dsSt.vStDataTable dataTable = new dsSt.vStDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping
            {
                SourceTable = "Table",
                DataSetTable = "vSt"
            };
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
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [St] WHERE (([PID] = @Original_PID))";
            this._adapter.DeleteCommand.CommandType = CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO St\r\n                            (PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall, \r\n                            NewClassID, NewSeat, Blood, Aborigine)\r\nVALUES          (@PID,@Guy,@GuyID,@SexID,@Years,@ClassID,@Seat,@Birthday,@Dad,@Mom,@Guardian,@Zip,@Tel1,@Address,@EmergencyCall,@NewClassID,@NewSeat,@Blood,@Aborigine)";
            this._adapter.InsertCommand.CommandType = CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guy", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guy", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@GuyID", SqlDbType.VarChar, 10, ParameterDirection.Input, 0, 0, "GuyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SexID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "SexID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "ClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Seat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Seat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "Birthday", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Dad", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Dad", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mom", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Mom", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Zip", SqlDbType.NVarChar, 3, ParameterDirection.Input, 0, 0, "Zip", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tel1", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Tel1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 4000, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EmergencyCall", SqlDbType.NVarChar, 60, ParameterDirection.Input, 0, 0, "EmergencyCall", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NewClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NewSeat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewSeat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Blood", SqlDbType.VarChar, 2, ParameterDirection.Input, 0, 0, "Blood", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Aborigine", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Aborigine", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE          St\r\nSET                   PID = @PID, Guy = @Guy, GuyID = @GuyID, SexID = @SexID, Years = @Years, ClassID = @ClassID, Seat = @Seat, \r\n                            Birthday = @Birthday, Dad = @Dad, Mom = @Mom, Guardian = @Guardian, Zip = @Zip, Tel1 = @Tel1, \r\n                            Address = @Address, EmergencyCall = @EmergencyCall, NewClassID = @NewClassID, NewSeat = @NewSeat, \r\n                            Blood = @Blood, Aborigine = @Aborigine\r\nWHERE          (PID = @Original_PID)";
            this._adapter.UpdateCommand.CommandType = CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guy", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guy", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GuyID", SqlDbType.VarChar, 10, ParameterDirection.Input, 0, 0, "GuyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SexID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "SexID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "ClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Seat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Seat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime, 8, ParameterDirection.Input, 0, 0, "Birthday", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Dad", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Dad", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mom", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Mom", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Zip", SqlDbType.NVarChar, 3, ParameterDirection.Input, 0, 0, "Zip", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Tel1", SqlDbType.NVarChar, 12, ParameterDirection.Input, 0, 0, "Tel1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 4000, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EmergencyCall", SqlDbType.NVarChar, -1, ParameterDirection.Input, 0, 0, "EmergencyCall", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewSeat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewSeat", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Blood", SqlDbType.VarChar, 2, ParameterDirection.Input, 0, 0, "Blood", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Aborigine", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Aborigine", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[7];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT          PID, Guy, GuyID, SexID, cSex, Years, GradeID, Grade, ClassID, Class, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, \r\n                            Address, EmergencyCall, YearsGrade, RealAgeSt, NewClassID, NewSeat, Blood, SeatGuy, Aborigine, \r\n                            GradeIDClassIDSeat, StMemos\r\nFROM              vSt";
            this._commandCollection[0].CommandType = CommandType.Text;
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "UPDATE          St\r\nSET                   Aborigine = 0\r\nWHERE          (PID = @PID)";
            this._commandCollection[1].CommandType = CommandType.Text;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "SELECT          Aborigine, Address, Birthday, Blood, Class, ClassID, Dad, EmergencyCall, Grade, GradeID, GradeIDClassIDSeat, \r\n                            Guardian, Guy, GuyID, Mom, NewClassID, NewSeat, PID, RealAgeSt, Seat, SeatGuy, SexID, StMemos, Tel1, Years, \r\n                            YearsGrade, Zip, cSex\r\nFROM              vSt\r\nWHERE          (Aborigine <> 0) AND (Grade IS NOT NULL)\r\nORDER BY   GradeID, ClassID, Seat";
            this._commandCollection[2].CommandType = CommandType.Text;
            this._commandCollection[3] = new SqlCommand();
            this._commandCollection[3].Connection = this.Connection;
            this._commandCollection[3].CommandText =
                @"SELECT Aborigine, 
                        Address, 
                        Birthday, 
                        Blood, 
                        Class, 
                        ClassID, 
                        Dad, 
                        EmergencyCall, 
                        Grade, 
                        GradeID, 
                        GradeIDClassIDSeat, 
                        Guardian, 
                        Guy, 
                        GuyID, 
                        Mom, 
                        NewClassID, 
                        NewSeat, 
                        PID, 
                        RealAgeSt, 
                        Seat, 
                        SeatGuy, 
                        SexID, 
                        StMemos, 
                        Tel1, 
                        Years, 
                        YearsGrade, 
                        Zip, 
                        cSex 
                FROM vSt 
                WHERE (Years = @Years) AND (ClassID = @ClassID) 
                ORDER BY Seat";
            /*
            this._commandCollection[3].CommandText = "SELECT          Aborigine, Address, Birthday, Blood, Class, ClassID, Dad, EmergencyCall, Grade, GradeID, GradeIDClassIDSeat, \r\n                            Guardian, Guy, GuyID, Mom, NewClassID, NewSeat, PID, RealAgeSt, Seat, SeatGuy, SexID, StMemos, Tel1, Years, \r\n                            YearsGrade, Zip, cSex\r\nFROM              vSt\r\nWHERE          (Years = @Years) AND (ClassID = @ClassID)\r\nORDER BY   Seat";
            */
            this._commandCollection[3].CommandType = CommandType.Text;
            this._commandCollection[3].Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@ClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "ClassID", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4] = new SqlCommand();
            this._commandCollection[4].Connection = this.Connection;
            this._commandCollection[4].CommandText = "SELECT          Aborigine, Address, Birthday, Blood, Class, ClassID, Dad, EmergencyCall, Grade, GradeID, GradeIDClassIDSeat, \r\n                            Guardian, Guy, GuyID, Mom, NewClassID, NewSeat, PID, RealAgeSt, Seat, SeatGuy, SexID, StMemos, Tel1, Years, \r\n                            YearsGrade, Zip, cSex\r\nFROM              vSt\r\nWHERE          (Guy LIKE @Guy)\r\nORDER BY   Years, ClassID";
            this._commandCollection[4].CommandType = CommandType.Text;
            this._commandCollection[4].Parameters.Add(new SqlParameter("@Guy", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "Guy", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5] = new SqlCommand();
            this._commandCollection[5].Connection = this.Connection;
            this._commandCollection[5].CommandText = "SELECT          Aborigine, Address, Birthday, Blood, Class, ClassID, Dad, EmergencyCall, Grade, GradeID, GradeIDClassIDSeat, \r\n                            Guardian, Guy, GuyID, Mom, NewClassID, NewSeat, PID, RealAgeSt, Seat, SeatGuy, SexID, StMemos, Tel1, Years, \r\n                            YearsGrade, Zip, cSex\r\nFROM              vSt\r\nWHERE          (PID = @PID)";
            this._commandCollection[5].CommandType = CommandType.Text;
            this._commandCollection[5].Parameters.Add(new SqlParameter("@PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6] = new SqlCommand();
            this._commandCollection[6].Connection = this.Connection;
            this._commandCollection[6].CommandText = "SELECT Aborigine, Address, Birthday, Blood, Class, ClassID, Dad, EmergencyCall, Grade, GradeID, GradeIDClassIDSeat, Guardian, Guy, GuyID, Mom, NewClassID, NewSeat, PID, RealAgeSt, Seat, SeatGuy, SexID, StMemos, Tel1, Years, YearsGrade, Zip, cSex FROM vSt WHERE (Years = @Years) ORDER BY ClassID, Seat";
            this._commandCollection[6].CommandType = CommandType.Text;
            this._commandCollection[6].Parameters.Add(new SqlParameter("@Years", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Years", DataRowVersion.Current, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.Health;
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Insert(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short? Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short? NewClassID, short? NewSeat, string Blood, short? Aborigine)
        {
            int num2;
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

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(dsSt dataSet)
        {
            return this.Adapter.Update(dataSet, "vSt");
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(dsSt.vStDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }

        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }

        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Update, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(string Guy, string GuyID, short SexID, short Years, short ClassID, short? Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short? NewClassID, short? NewSeat, string Blood, short? Aborigine, string Original_PID)
        {
            return this.Update(Original_PID, Guy, GuyID, SexID, Years, ClassID, Seat, Birthday, Dad, Mom, Guardian, Zip, Tel1, Address, EmergencyCall, NewClassID, NewSeat, Blood, Aborigine, Original_PID);
        }

        [HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Update, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(string PID, string Guy, string GuyID, short SexID, short Years, short ClassID, short? Seat, DateTime Birthday, string Dad, string Mom, string Guardian, string Zip, string Tel1, string Address, string EmergencyCall, short? NewClassID, short? NewSeat, string Blood, short? Aborigine, string Original_PID)
        {
            int num2;
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
            if (Original_PID == null)
            {
                throw new ArgumentNullException("Original_PID");
            }
            this.Adapter.UpdateCommand.Parameters[0x13].Value = Original_PID;
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

        public virtual int UpdateGuardian()
        {
            int num2;
            this.Adapter.UpdateCommand.CommandText = "update St Set Guardian =Dad  where Guardian='' or Guardian is null and (  not (Dad ='' or (dad is null)));update St Set Guardian =mom  where Guardian='' or Guardian is null and (  not (mom ='' or (mom is null)))";
            this.Adapter.UpdateCommand.Parameters.Clear();
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

        [DataObjectMethod(DataObjectMethodType.Update, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int UpdateNewSeat(short? NewClassID, short? NewSeat, string Original_PID)
        {
            int num2;
            this.Adapter.UpdateCommand.CommandText = "UPDATE St SET NewClassID = @NewClassID, NewSeat = @NewSeat WHERE (PID = @Original_PID)";
            this.Adapter.UpdateCommand.Parameters.Clear();
            this.Adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewClassID", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewClassID", DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewSeat", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "NewSeat", DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PID", SqlDbType.VarChar, 12, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, false, null, "", "", ""));
            if (NewClassID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters["@NewClassID"].Value = NewClassID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters["@NewClassID"].Value = DBNull.Value;
            }
            if (NewSeat.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters["@NewSeat"].Value = NewSeat.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters["@NewSeat"].Value = DBNull.Value;
            }
            if (Original_PID == null)
            {
                throw new ArgumentNullException("Original_PID");
            }
            this.Adapter.UpdateCommand.Parameters["@Original_PID"].Value = Original_PID;
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

        public virtual int UpdateZip(string sZip)
        {
            int num2;
            string format = "update St Set Zip ='{0}'  where (Zip not in (Select Zip from Zip))";
            format = string.Format(format, sZip);
            this.Adapter.UpdateCommand.CommandText = format;
            this.Adapter.UpdateCommand.Parameters.Clear();
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

