namespace HealthShare.dsSightTableAdapters
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

    [ToolboxItem(true), DataObject(true), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class vSightNear50TableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public vSightNear50TableAdapter()
        {
            this.ClearBeforeFill = true;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(dsSight.vSightNear50DataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Fill, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Fill_Limit(dsSight.vSightNear50DataTable dataTable, short? SchYears, short? SchYearsPre, short SemPre, short Sem, short Limit)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (SchYears.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[0].Value = SchYears.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            if (SchYearsPre.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = SchYearsPre.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            this.Adapter.SelectCommand.Parameters[2].Value = SemPre;
            this.Adapter.SelectCommand.Parameters[3].Value = Sem;
            this.Adapter.SelectCommand.Parameters[4].Value = Limit;
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual dsSight.vSightNear50DataTable Get()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            dsSight.vSightNear50DataTable dataTable = new dsSight.vSightNear50DataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual dsSight.vSightNear50DataTable Get_Limit(short? SchYears, short? SchYearsPre, short SemPre, short Sem, short Limit)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (SchYears.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[0].Value = SchYears.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            if (SchYearsPre.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = SchYearsPre.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            this.Adapter.SelectCommand.Parameters[2].Value = SemPre;
            this.Adapter.SelectCommand.Parameters[3].Value = Sem;
            this.Adapter.SelectCommand.Parameters[4].Value = Limit;
            dsSight.vSightNear50DataTable dataTable = new dsSight.vSightNear50DataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        public virtual dsSight.vSightNear50DataTable Get_Limit2(short? SchYears, short? SchYearsPre, short SemPre, short Sem, short Limit)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (SchYears.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[0].Value = SchYears.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            if (SchYearsPre.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = SchYearsPre.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            this.Adapter.SelectCommand.Parameters[2].Value = SemPre;
            this.Adapter.SelectCommand.Parameters[3].Value = Sem;
            this.Adapter.SelectCommand.Parameters[4].Value = Limit;
            dsSight.vSightNear50DataTable dataTable = new dsSight.vSightNear50DataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "vSightNear50"
            };
            mapping.ColumnMappings.Add("PID", "PID");
            mapping.ColumnMappings.Add("Guy", "Guy");
            mapping.ColumnMappings.Add("cSex", "cSex");
            mapping.ColumnMappings.Add("Grade", "Grade");
            mapping.ColumnMappings.Add("GradePre", "GradePre");
            mapping.ColumnMappings.Add("NearDiop", "NearDiop");
            mapping.ColumnMappings.Add("NearDiopPre", "NearDiopPre");
            mapping.ColumnMappings.Add("Differ", "Differ");
            mapping.ColumnMappings.Add("Class", "Class");
            mapping.ColumnMappings.Add("Seat", "Seat");
            mapping.ColumnMappings.Add("Sem", "Sem");
            mapping.ColumnMappings.Add("SemPre", "SemPre");
            this._adapter.TableMappings.Add(mapping);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[3];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "SELECT          vSightNear.PID, vSightNear.Guy, vSightNear.cSex, vSightNear.Grade, vSightNearpre.Grade AS GradePre, vSightNear.NearDiop, vSightNearpre.NearDiop AS NearDiopPre, \r\n                            vSightNear.NearDiop - vSightNearpre.NearDiop AS Differ, vSightNear.Class, vSightNear.Seat, vSightNear.Sem, vSightNearpre.Sem AS SemPre\r\nFROM              vSightNear INNER JOIN\r\n                            vSightNear AS vSightNearpre ON vSightNear.PID = vSightNearpre.PID AND vSightNear.SchYears = 102 AND \r\n                            vSightNearpre.SchYears = 101 AND vSightNearpre.Sem = 2 AND vSightNear.Sem = 2 AND \r\n                            vSightNear.NearDiop - vSightNearpre.NearDiop >= 50\r\nWHERE          (vSightNear.NearDiop > 0) AND (vSightNearpre.NearDiop > 0)\r\nORDER BY   vSightNear.GradeID DESC, vSightNearpre.ClassID, vSightNear.Seat";
            this._commandCollection[0].CommandType = CommandType.Text;
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            /*
            this._commandCollection[1].CommandText =
                @"SELECT vSightNear.PID, 
                        vSightNear.Guy, 
                        vSightNear.cSex, 
                        vSightNear.Grade, 
                        vSightNearpre.Grade AS GradePre, 
                        vSightNear.NearDiop, 
                        vSightNearpre.NearDiop AS NearDiopPre, 
                        vSightNear.NearDiop - vSightNearpre.NearDiop AS Differ, 
                        vSightNear.Class, 
                        vSightNear.Seat, 
                        vSightNear.Sem, 
                        vSightNearpre.Sem AS SemPre 
                FROM vSightNear 
                INNER JOIN vSightNear AS vSightNearpre ON vSightNear.PID = vSightNearpre.PID AND 
                            vSightNear.SchYears = @SchYears AND 
                            vSightNear.Sem = @Sem AND 
                            vSightNearpre.SchYears = @SchYearsPre AND 
                            vSightNearpre.Sem = @SemPre AND 
                            vSightNear.NearDiop - vSightNearpre.NearDiop >= @Limit 
                WHERE (vSightNear.NearDiop > 0) AND (vSightNearpre.NearDiop > 0) 
                ORDER BY vSightNear.GradeID DESC, vSightNearpre.ClassID, vSightNear.Seat";
            */
            this._commandCollection[1].CommandText =
                @"SELECT vSightNear.PID, 
                            vSightNear.Guy, 
                            vSightNear.cSex, 
                            vSightNear.Grade, 
                            vSightNearpre.Grade AS GradePre, 
                            vSightNear.NearDiop, 
                            vSightNearpre.NearDiop AS NearDiopPre, 
                (case when vSightNear.NearDiop>=vSightNearpre.MAXNear then vSightNear.NearDiop else vSightNear.MAXNear end) -
                (case when vSightNearpre.NearDiop>=vSightNearpre.MAXNear then vSightNearpre.NearDiop else vSightNearpre.MAXNear end) AS Differ, 
                            vSightNear.Class, 
                            vSightNear.Seat, 
                            vSightNear.Sem, 
                            vSightNearpre.Sem AS SemPre,
                            vSightNear.MAXNear as'NEWNear',
                            vSightNearpre.MAXNear as'NEWNearpre',
                            vSightNear.ENearL,
                            vSightNear.ENearR,
                            vSightNear.DiopL,
                            vSightNear.DiopR,
                            vSightNearpre.ENearL AS preENearL,
                            vSightNearpre.ENearR AS preENearR,
                            vSightNearpre.DiopL AS preDiopL,
                            vSightNearpre.DiopR AS preDiopR 
                FROM vSightNear 
                INNER JOIN vSightNear AS vSightNearpre ON vSightNear.PID = vSightNearpre.PID AND 
                            vSightNear.SchYears = @SchYears  AND 
                            vSightNear.Sem = @Sem AND 
                            vSightNearpre.SchYears = @SchYearsPre AND 
                            vSightNearpre.Sem = @SemPre 
                WHERE ((vSightNear.NearDiop > 0) AND (vSightNearpre.NearDiop > 0) or 
                        (vSightNear.MAXNear > 0) AND (vSightNearpre.NearDiop > 0)or 
                        (vSightNear.NearDiop > 0) AND (vSightNearpre.MAXNear > 0)or
                        (vSightNear.MAXNear > 0) AND (vSightNearpre.MAXNear > 0)) and 
                        (vSightNear.NearDiop - vSightNearpre.NearDiop >= @Limit or
                        vSightNear.MAXNear - vSightNearpre.NearDiop >= @Limit or
                        vSightNear.NearDiop - vSightNearpre.MAXNear >= @Limit or
                        vSightNear.MAXNear - vSightNearpre.MAXNear >= @Limit)
                ORDER BY vSightNear.GradeID DESC, vSightNearpre.ClassID, vSightNear.Seat";
            //NEWNear : 現在最大近視左右眼
            //NEWNearpre : 比較條件的最大左右眼
            this._commandCollection[1].CommandType = CommandType.Text;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@SchYears", SqlDbType.SmallInt, 4, ParameterDirection.Input, 0, 0, "SchYears", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@SchYearsPre", SqlDbType.SmallInt, 4, ParameterDirection.Input, 0, 0, "SchYears", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@SemPre", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "SemPre", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@Sem", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Sem", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@Limit", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText =
                @"WITH SightNear AS(SELECT PID, Guy, Years, Sem, SchYears, GradeID, ClassID, Grade, Class, Seat, SexID, cSex, ENear, EFar, DiopL, DiopR, 
                            dbo.NearDiop(DiopR, DiopL) AS NearDiop, dbo.SightMin(Sight0R, Sight0L) AS SightMin, ENearL, ENearR, 
                            (CASE WHEN ENearL >= ENearR THEN ENearL ELSE ENearR END) AS MAXNear,isDilated,isDilating
					FROM dbo.vSight)
                    SELECT SightNear.PID, 
                            SightNear.Guy, 
                            SightNear.cSex, 
                            SightNear.Grade, 
                            SightNearpre.Grade AS GradePre, 
                            SightNear.NearDiop, 
                            SightNearpre.NearDiop AS NearDiopPre, 
                (case when SightNear.NearDiop>=SightNear.MAXNear then SightNear.NearDiop else SightNear.MAXNear end) -
                (case when SightNearpre.NearDiop>=SightNearpre.MAXNear then SightNearpre.NearDiop else SightNearpre.MAXNear end) AS Differ, 
                            SightNear.Class, 
                            SightNear.Seat, 
                            SightNear.Sem, 
                            SightNearpre.Sem AS SemPre,
                            SightNear.MAXNear as'NEWNear',
                            SightNearpre.MAXNear as'NEWNearpre',
                            SightNear.ENearL,
                            SightNear.ENearR,
                            SightNear.DiopL,
                            SightNear.DiopR,
                            SightNearpre.ENearL AS preENearL,
                            SightNearpre.ENearR AS preENearR,
                            SightNearpre.DiopL AS preDiopL,
                            SightNearpre.DiopR AS preDiopR, 
                            SightNear.isDilated,
                            SightNear.isDilating,
                            SightNearpre.isDilated AS isDilatedPre,
	                        SightNearpre.isDilating AS isDilatingPre
                FROM SightNear 
                INNER JOIN SightNear AS SightNearpre ON SightNear.PID = SightNearpre.PID AND 
                            SightNear.SchYears = @SchYears  AND 
                            SightNear.Sem = @Sem AND 
                            SightNearpre.SchYears = @SchYearsPre AND 
                            SightNearpre.Sem = @SemPre 
                WHERE ((SightNear.NearDiop > 0) AND (SightNearpre.NearDiop > 0) or 
                        (SightNear.MAXNear > 0) AND (SightNearpre.NearDiop > 0)or 
                        (SightNear.NearDiop > 0) AND (SightNearpre.MAXNear > 0)or
                        (SightNear.MAXNear > 0) AND (SightNearpre.MAXNear > 0)) and 
                        (SightNear.NearDiop - SightNearpre.NearDiop >= @Limit or
                        SightNear.MAXNear - SightNearpre.NearDiop >= @Limit or
                        SightNear.NearDiop - SightNearpre.MAXNear >= @Limit or
                        SightNear.MAXNear - SightNearpre.MAXNear >= @Limit)
                ORDER BY SightNear.GradeID DESC, SightNearpre.ClassID, SightNear.Seat";
            //NEWNear : 現在最大近視左右眼
            //NEWNearpre : 比較條件的最大左右眼
            this._commandCollection[2].CommandType = CommandType.Text;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@SchYears", SqlDbType.SmallInt, 4, ParameterDirection.Input, 0, 0, "SchYears", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@SchYearsPre", SqlDbType.SmallInt, 4, ParameterDirection.Input, 0, 0, "SchYears", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@SemPre", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "SemPre", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@Sem", SqlDbType.SmallInt, 2, ParameterDirection.Input, 0, 0, "Sem", DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@Limit", SqlDbType.SmallInt, 0, ParameterDirection.Input, 0, 0, "", DataRowVersion.Current, false, null, "", "", ""));
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