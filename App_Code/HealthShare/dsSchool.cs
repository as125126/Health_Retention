namespace HealthShare
{
    using HealthShare.dsSchoolTableAdapters;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using WillNs;

    [Serializable, DesignerCategory("code"), XmlRoot("dsSchool"), HelpKeyword("vs.data.DataSet"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema")]
    public class dsSchool : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private Class0DataTable tableClass0;
        private ClassSelDataTable tableClassSel;
        private GradeDataTable tableGrade;
        private Grade9DataTable tableGrade9;
        private SchoolRankDataTable tableSchoolRank;
        private SchYearsDataTable tableSchYears;
        private SchYearsMonthDataTable tableSchYearsMonth;
        private SemDataTable tableSem;
        private StCountDataTable tableStCount;
        private SystemSetDataTable tableSystemSet;
        private VocationDataTable tableVocation;
        private YearsDataTable tableYears;
        private YearsClassDataTable tableYearsClass;
        private ZIPDataTable tableZIP;

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public dsSchool()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected dsSchool(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["Grade"] != null)
                    {
                        base.Tables.Add(new GradeDataTable(dataSet.Tables["Grade"]));
                    }
                    if (dataSet.Tables["Grade9"] != null)
                    {
                        base.Tables.Add(new Grade9DataTable(dataSet.Tables["Grade9"]));
                    }
                    if (dataSet.Tables["StCount"] != null)
                    {
                        base.Tables.Add(new StCountDataTable(dataSet.Tables["StCount"]));
                    }
                    if (dataSet.Tables["ClassSel"] != null)
                    {
                        base.Tables.Add(new ClassSelDataTable(dataSet.Tables["ClassSel"]));
                    }
                    if (dataSet.Tables["SchYears"] != null)
                    {
                        base.Tables.Add(new SchYearsDataTable(dataSet.Tables["SchYears"]));
                    }
                    if (dataSet.Tables["Class0"] != null)
                    {
                        base.Tables.Add(new Class0DataTable(dataSet.Tables["Class0"]));
                    }
                    if (dataSet.Tables["Sem"] != null)
                    {
                        base.Tables.Add(new SemDataTable(dataSet.Tables["Sem"]));
                    }
                    if (dataSet.Tables["SystemSet"] != null)
                    {
                        base.Tables.Add(new SystemSetDataTable(dataSet.Tables["SystemSet"]));
                    }
                    if (dataSet.Tables["Years"] != null)
                    {
                        base.Tables.Add(new YearsDataTable(dataSet.Tables["Years"]));
                    }
                    if (dataSet.Tables["YearsClass"] != null)
                    {
                        base.Tables.Add(new YearsClassDataTable(dataSet.Tables["YearsClass"]));
                    }
                    if (dataSet.Tables["SchYearsMonth"] != null)
                    {
                        base.Tables.Add(new SchYearsMonthDataTable(dataSet.Tables["SchYearsMonth"]));
                    }
                    if (dataSet.Tables["ZIP"] != null)
                    {
                        base.Tables.Add(new ZIPDataTable(dataSet.Tables["ZIP"]));
                    }
                    if (dataSet.Tables["SchoolRank"] != null)
                    {
                        base.Tables.Add(new SchoolRankDataTable(dataSet.Tables["SchoolRank"]));
                    }
                    if (dataSet.Tables["Vocation"] != null)
                    {
                        base.Tables.Add(new VocationDataTable(dataSet.Tables["Vocation"]));
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override DataSet Clone()
        {
            dsSchool school = (dsSchool)base.Clone();
            school.InitVars();
            school.SchemaSerializationMode = this.SchemaSerializationMode;
            return school;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            dsSchool school = new dsSchool();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny
            {
                Namespace = school.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
            base.DataSetName = "dsSchool";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/dsSchool.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableGrade = new GradeDataTable();
            base.Tables.Add(this.tableGrade);
            this.tableGrade9 = new Grade9DataTable();
            base.Tables.Add(this.tableGrade9);
            this.tableStCount = new StCountDataTable();
            base.Tables.Add(this.tableStCount);
            this.tableClassSel = new ClassSelDataTable();
            base.Tables.Add(this.tableClassSel);
            this.tableSchYears = new SchYearsDataTable();
            base.Tables.Add(this.tableSchYears);
            this.tableClass0 = new Class0DataTable();
            base.Tables.Add(this.tableClass0);
            this.tableSem = new SemDataTable();
            base.Tables.Add(this.tableSem);
            this.tableSystemSet = new SystemSetDataTable();
            base.Tables.Add(this.tableSystemSet);
            this.tableYears = new YearsDataTable();
            base.Tables.Add(this.tableYears);
            this.tableYearsClass = new YearsClassDataTable();
            base.Tables.Add(this.tableYearsClass);
            this.tableSchYearsMonth = new SchYearsMonthDataTable();
            base.Tables.Add(this.tableSchYearsMonth);
            this.tableZIP = new ZIPDataTable();
            base.Tables.Add(this.tableZIP);
            this.tableSchoolRank = new SchoolRankDataTable();
            base.Tables.Add(this.tableSchoolRank);
            this.tableVocation = new VocationDataTable();
            base.Tables.Add(this.tableVocation);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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
            this.tableGrade = (GradeDataTable)base.Tables["Grade"];
            if (initTable && (this.tableGrade != null))
            {
                this.tableGrade.InitVars();
            }
            this.tableGrade9 = (Grade9DataTable)base.Tables["Grade9"];
            if (initTable && (this.tableGrade9 != null))
            {
                this.tableGrade9.InitVars();
            }
            this.tableStCount = (StCountDataTable)base.Tables["StCount"];
            if (initTable && (this.tableStCount != null))
            {
                this.tableStCount.InitVars();
            }
            this.tableClassSel = (ClassSelDataTable)base.Tables["ClassSel"];
            if (initTable && (this.tableClassSel != null))
            {
                this.tableClassSel.InitVars();
            }
            this.tableSchYears = (SchYearsDataTable)base.Tables["SchYears"];
            if (initTable && (this.tableSchYears != null))
            {
                this.tableSchYears.InitVars();
            }
            this.tableClass0 = (Class0DataTable)base.Tables["Class0"];
            if (initTable && (this.tableClass0 != null))
            {
                this.tableClass0.InitVars();
            }
            this.tableSem = (SemDataTable)base.Tables["Sem"];
            if (initTable && (this.tableSem != null))
            {
                this.tableSem.InitVars();
            }
            this.tableSystemSet = (SystemSetDataTable)base.Tables["SystemSet"];
            if (initTable && (this.tableSystemSet != null))
            {
                this.tableSystemSet.InitVars();
            }
            this.tableYears = (YearsDataTable)base.Tables["Years"];
            if (initTable && (this.tableYears != null))
            {
                this.tableYears.InitVars();
            }
            this.tableYearsClass = (YearsClassDataTable)base.Tables["YearsClass"];
            if (initTable && (this.tableYearsClass != null))
            {
                this.tableYearsClass.InitVars();
            }
            this.tableSchYearsMonth = (SchYearsMonthDataTable)base.Tables["SchYearsMonth"];
            if (initTable && (this.tableSchYearsMonth != null))
            {
                this.tableSchYearsMonth.InitVars();
            }
            this.tableZIP = (ZIPDataTable)base.Tables["ZIP"];
            if (initTable && (this.tableZIP != null))
            {
                this.tableZIP.InitVars();
            }
            this.tableSchoolRank = (SchoolRankDataTable)base.Tables["SchoolRank"];
            if (initTable && (this.tableSchoolRank != null))
            {
                this.tableSchoolRank.InitVars();
            }
            this.tableVocation = (VocationDataTable)base.Tables["Vocation"];
            if (initTable && (this.tableVocation != null))
            {
                this.tableVocation.InitVars();
            }
        }

        /*
        public static void InsertClasses(int iYears, int iClassCount, int iClassNameKind)
        {
            ArrayList classArray = HealthInfo.GetClassArray(iClassNameKind);
            string str = iYears.ToString();
            int num = 0;
            string format = "Select Max(ClassID) from YearsClass where Years=" + str;
            try
            {
                num = int.Parse(DM.ExecuteScalar(format).ToString());
            }
            catch (FormatException)
            {
                num = 0;
            }
            format = "Insert into YearsClass (Years, ClassID,Class, PW) values ({0},{1},'{2}','{3}')";
            for (int i = num + 1; i <= (num + iClassCount); i++)
            {
                string str4 = Util.RightStr(((iYears + i) * 0x377).ToString(), 4);
                DM.ExecuteNonQuery(string.Format(format, new object[] { str, i.ToString(), classArray[i], str4 }));
            }
        }
        */

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["Grade"] != null)
                {
                    base.Tables.Add(new GradeDataTable(dataSet.Tables["Grade"]));
                }
                if (dataSet.Tables["Grade9"] != null)
                {
                    base.Tables.Add(new Grade9DataTable(dataSet.Tables["Grade9"]));
                }
                if (dataSet.Tables["StCount"] != null)
                {
                    base.Tables.Add(new StCountDataTable(dataSet.Tables["StCount"]));
                }
                if (dataSet.Tables["ClassSel"] != null)
                {
                    base.Tables.Add(new ClassSelDataTable(dataSet.Tables["ClassSel"]));
                }
                if (dataSet.Tables["SchYears"] != null)
                {
                    base.Tables.Add(new SchYearsDataTable(dataSet.Tables["SchYears"]));
                }
                if (dataSet.Tables["Class0"] != null)
                {
                    base.Tables.Add(new Class0DataTable(dataSet.Tables["Class0"]));
                }
                if (dataSet.Tables["Sem"] != null)
                {
                    base.Tables.Add(new SemDataTable(dataSet.Tables["Sem"]));
                }
                if (dataSet.Tables["SystemSet"] != null)
                {
                    base.Tables.Add(new SystemSetDataTable(dataSet.Tables["SystemSet"]));
                }
                if (dataSet.Tables["Years"] != null)
                {
                    base.Tables.Add(new YearsDataTable(dataSet.Tables["Years"]));
                }
                if (dataSet.Tables["YearsClass"] != null)
                {
                    base.Tables.Add(new YearsClassDataTable(dataSet.Tables["YearsClass"]));
                }
                if (dataSet.Tables["SchYearsMonth"] != null)
                {
                    base.Tables.Add(new SchYearsMonthDataTable(dataSet.Tables["SchYearsMonth"]));
                }
                if (dataSet.Tables["ZIP"] != null)
                {
                    base.Tables.Add(new ZIPDataTable(dataSet.Tables["ZIP"]));
                }
                if (dataSet.Tables["SchoolRank"] != null)
                {
                    base.Tables.Add(new SchoolRankDataTable(dataSet.Tables["SchoolRank"]));
                }
                if (dataSet.Tables["Vocation"] != null)
                {
                    base.Tables.Add(new VocationDataTable(dataSet.Tables["Vocation"]));
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        /*
        public static SemRow SchYearsSemNow()
        {
            return (SemRow)new SemTableAdapter { Connection = { ConnectionString = Se.sMyConnStr } }.Get_Now().Rows[0];
        }
        */

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeClass0()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeClassSel()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeGrade()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeGrade9()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSchoolRank()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSchYears()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeSchYearsMonth()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeSem()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeStCount()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSystemSet()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeVocation()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeYears()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeYearsClass()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeZIP()
        {
            return false;
        }
        /*
        public static void SortClass()
        {
            YearsTableAdapter adapter = new YearsTableAdapter();
            Se.SetConn(adapter.Connection);
            YearsDataTable data = adapter.GetData();
            YearsClassTableAdapter adapter2 = new YearsClassTableAdapter();
            Se.SetConn(adapter2.Connection);
            foreach (YearsRow row in data.Rows)
            {
                short years = row.Years;
                YearsClassDataTable table2 = adapter2.Get_aYears(years);
                int count = table2.Rows.Count;
                int num3 = 0;
                for (int i = 1; i <= count; i++)
                {
                    YearsClassRow row2 = table2[i - 1];
                    short classID = row2.ClassID;
                    if (i != classID)
                    {
                        num3++;
                        int num6 = classID;
                        DM.ExecuteNonQuery(string.Format("Update YearsClass Set ClassID= {0} where Years={1} and classID= {2}", i, years, num6));
                        DM.ExecuteNonQuery(string.Format("Update St Set ClassID= {0} where Years={1} and classID= {2}", i, years, num6));
                    }
                }
            }
        }
        */

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Class0DataTable Class0
        {
            get
            {
                return this.tableClass0;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public ClassSelDataTable ClassSel
        {
            get
            {
                return this.tableClassSel;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public GradeDataTable Grade
        {
            get
            {
                return this.tableGrade;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public Grade9DataTable Grade9
        {
            get
            {
                return this.tableGrade9;
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SchoolRankDataTable SchoolRank
        {
            get
            {
                return this.tableSchoolRank;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public SchYearsDataTable SchYears
        {
            get
            {
                return this.tableSchYears;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public SchYearsMonthDataTable SchYearsMonth
        {
            get
            {
                return this.tableSchYearsMonth;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SemDataTable Sem
        {
            get
            {
                return this.tableSem;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public StCountDataTable StCount
        {
            get
            {
                return this.tableStCount;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SystemSetDataTable SystemSet
        {
            get
            {
                return this.tableSystemSet;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public VocationDataTable Vocation
        {
            get
            {
                return this.tableVocation;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public YearsDataTable Years
        {
            get
            {
                return this.tableYears;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public YearsClassDataTable YearsClass
        {
            get
            {
                return this.tableYearsClass;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ZIPDataTable ZIP
        {
            get
            {
                return this.tableZIP;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class Class0DataTable : TypedTableBase<dsSchool.Class0Row>
        {
            private DataColumn columnClass1;
            private DataColumn columnClass2;
            private DataColumn columnClass3;
            private DataColumn columnClassID;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Class0RowChangeEventHandler Class0RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Class0RowChangeEventHandler Class0RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Class0RowChangeEventHandler Class0RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Class0RowChangeEventHandler Class0RowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Class0DataTable()
            {
                base.TableName = "Class0";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal Class0DataTable(DataTable table)
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
            protected Class0DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddClass0Row(dsSchool.Class0Row row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.Class0Row AddClass0Row(short ClassID, string Class1, string Class2, string Class3)
            {
                dsSchool.Class0Row row = (dsSchool.Class0Row)base.NewRow();
                row.ItemArray = new object[] { ClassID, Class1, Class2, Class3 };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.Class0DataTable table = (dsSchool.Class0DataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.Class0DataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.Class0Row FindByClassID(short ClassID)
            {
                return (dsSchool.Class0Row)base.Rows.Find(new object[] { ClassID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.Class0Row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "Class0DataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass1 = new DataColumn("Class1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass1);
                this.columnClass2 = new DataColumn("Class2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass2);
                this.columnClass3 = new DataColumn("Class3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass3);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnClassID }, true));
                this.columnClassID.AllowDBNull = false;
                this.columnClassID.Unique = true;
                this.columnClass1.MaxLength = 1;
                this.columnClass2.MaxLength = 1;
                this.columnClass3.MaxLength = 1;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass1 = base.Columns["Class1"];
                this.columnClass2 = base.Columns["Class2"];
                this.columnClass3 = base.Columns["Class3"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.Class0Row NewClass0Row()
            {
                return (dsSchool.Class0Row)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.Class0Row(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Class0RowChanged != null)
                {
                    this.Class0RowChanged(this, new dsSchool.Class0RowChangeEvent((dsSchool.Class0Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Class0RowChanging != null)
                {
                    this.Class0RowChanging(this, new dsSchool.Class0RowChangeEvent((dsSchool.Class0Row)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Class0RowDeleted != null)
                {
                    this.Class0RowDeleted(this, new dsSchool.Class0RowChangeEvent((dsSchool.Class0Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Class0RowDeleting != null)
                {
                    this.Class0RowDeleting(this, new dsSchool.Class0RowChangeEvent((dsSchool.Class0Row)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveClass0Row(dsSchool.Class0Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Class1Column
            {
                get
                {
                    return this.columnClass1;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Class2Column
            {
                get
                {
                    return this.columnClass2;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Class3Column
            {
                get
                {
                    return this.columnClass3;
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
            public dsSchool.Class0Row this[int index]
            {
                get
                {
                    return (dsSchool.Class0Row)base.Rows[index];
                }
            }
        }

        public class Class0Row : DataRow
        {
            private dsSchool.Class0DataTable tableClass0;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal Class0Row(DataRowBuilder rb) : base(rb)
            {
                this.tableClass0 = (dsSchool.Class0DataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClass1Null()
            {
                return base.IsNull(this.tableClass0.Class1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClass2Null()
            {
                return base.IsNull(this.tableClass0.Class2Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClass3Null()
            {
                return base.IsNull(this.tableClass0.Class3Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClass1Null()
            {
                base[this.tableClass0.Class1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClass2Null()
            {
                base[this.tableClass0.Class2Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClass3Null()
            {
                base[this.tableClass0.Class3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class1
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableClass0.Class1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class1' in table 'Class0' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableClass0.Class1Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class2
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableClass0.Class2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class2' in table 'Class0' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableClass0.Class2Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class3
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableClass0.Class3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class3' in table 'Class0' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableClass0.Class3Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tableClass0.ClassIDColumn];
                }
                set
                {
                    base[this.tableClass0.ClassIDColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Class0RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.Class0Row eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Class0RowChangeEvent(dsSchool.Class0Row row, DataRowAction action)
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
            public dsSchool.Class0Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Class0RowChangeEventHandler(object sender, dsSchool.Class0RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class ClassSelDataTable : TypedTableBase<dsSchool.ClassSelRow>
        {
            private DataColumn columnClassID;
            private DataColumn columnYears;
            private DataColumn columnYearsClass;
            private DataColumn columnYearsGradeClass;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ClassSelRowChangeEventHandler ClassSelRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ClassSelRowChangeEventHandler ClassSelRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ClassSelRowChangeEventHandler ClassSelRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ClassSelRowChangeEventHandler ClassSelRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public ClassSelDataTable()
            {
                base.TableName = "ClassSel";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal ClassSelDataTable(DataTable table)
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
            protected ClassSelDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddClassSelRow(dsSchool.ClassSelRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.ClassSelRow AddClassSelRow(short Years, short ClassID, string YearsClass, string YearsGradeClass)
            {
                dsSchool.ClassSelRow row = (dsSchool.ClassSelRow)base.NewRow();
                row.ItemArray = new object[] { Years, ClassID, YearsClass, YearsGradeClass };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.ClassSelDataTable table = (dsSchool.ClassSelDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.ClassSelDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.ClassSelRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "ClassSelDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnYearsClass = new DataColumn("YearsClass", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsClass);
                this.columnYearsGradeClass = new DataColumn("YearsGradeClass", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsGradeClass);
                this.columnYears.ReadOnly = true;
                this.columnClassID.ReadOnly = true;
                this.columnYearsClass.ReadOnly = true;
                this.columnYearsClass.MaxLength = 7;
                this.columnYearsGradeClass.ReadOnly = true;
                this.columnYearsGradeClass.MaxLength = 0x15;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnYearsClass = base.Columns["YearsClass"];
                this.columnYearsGradeClass = base.Columns["YearsGradeClass"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.ClassSelRow NewClassSelRow()
            {
                return (dsSchool.ClassSelRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.ClassSelRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ClassSelRowChanged != null)
                {
                    this.ClassSelRowChanged(this, new dsSchool.ClassSelRowChangeEvent((dsSchool.ClassSelRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ClassSelRowChanging != null)
                {
                    this.ClassSelRowChanging(this, new dsSchool.ClassSelRowChangeEvent((dsSchool.ClassSelRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ClassSelRowDeleted != null)
                {
                    this.ClassSelRowDeleted(this, new dsSchool.ClassSelRowChangeEvent((dsSchool.ClassSelRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ClassSelRowDeleting != null)
                {
                    this.ClassSelRowDeleting(this, new dsSchool.ClassSelRowChangeEvent((dsSchool.ClassSelRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveClassSelRow(dsSchool.ClassSelRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
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
            public dsSchool.ClassSelRow this[int index]
            {
                get
                {
                    return (dsSchool.ClassSelRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsClassColumn
            {
                get
                {
                    return this.columnYearsClass;
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
            public DataColumn YearsGradeClassColumn
            {
                get
                {
                    return this.columnYearsGradeClass;
                }
            }
        }

        public class ClassSelRow : DataRow
        {
            private dsSchool.ClassSelDataTable tableClassSel;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal ClassSelRow(DataRowBuilder rb) : base(rb)
            {
                this.tableClassSel = (dsSchool.ClassSelDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassIDNull()
            {
                return base.IsNull(this.tableClassSel.ClassIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsYearsClassNull()
            {
                return base.IsNull(this.tableClassSel.YearsClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsYearsGradeClassNull()
            {
                return base.IsNull(this.tableClassSel.YearsGradeClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsYearsNull()
            {
                return base.IsNull(this.tableClassSel.YearsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassIDNull()
            {
                base[this.tableClassSel.ClassIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetYearsClassNull()
            {
                base[this.tableClassSel.YearsClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetYearsGradeClassNull()
            {
                base[this.tableClassSel.YearsGradeClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetYearsNull()
            {
                base[this.tableClassSel.YearsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableClassSel.ClassIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ClassID' in table 'ClassSel' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableClassSel.ClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Years
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableClassSel.YearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Years' in table 'ClassSel' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableClassSel.YearsColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string YearsClass
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableClassSel.YearsClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsClass' in table 'ClassSel' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableClassSel.YearsClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string YearsGradeClass
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableClassSel.YearsGradeClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsGradeClass' in table 'ClassSel' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableClassSel.YearsGradeClassColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class ClassSelRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.ClassSelRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public ClassSelRowChangeEvent(dsSchool.ClassSelRow row, DataRowAction action)
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
            public dsSchool.ClassSelRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void ClassSelRowChangeEventHandler(object sender, dsSchool.ClassSelRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class Grade9DataTable : TypedTableBase<dsSchool.Grade9Row>
        {
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Grade9RowChangeEventHandler Grade9RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Grade9RowChangeEventHandler Grade9RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Grade9RowChangeEventHandler Grade9RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.Grade9RowChangeEventHandler Grade9RowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Grade9DataTable()
            {
                base.TableName = "Grade9";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal Grade9DataTable(DataTable table)
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
            protected Grade9DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddGrade9Row(dsSchool.Grade9Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.Grade9Row AddGrade9Row(short GradeID, short Years, string Grade)
            {
                dsSchool.Grade9Row row = (dsSchool.Grade9Row)base.NewRow();
                row.ItemArray = new object[] { GradeID, Years, Grade };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSchool.Grade9DataTable table = (dsSchool.Grade9DataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.Grade9DataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.Grade9Row FindByGradeID(short GradeID)
            {
                return (dsSchool.Grade9Row)base.Rows.Find(new object[] { GradeID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.Grade9Row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "Grade9DataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnGradeID }, true));
                this.columnGradeID.AllowDBNull = false;
                this.columnGradeID.Unique = true;
                this.columnYears.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnGradeID = base.Columns["GradeID"];
                this.columnYears = base.Columns["Years"];
                this.columnGrade = base.Columns["Grade"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.Grade9Row NewGrade9Row()
            {
                return (dsSchool.Grade9Row)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.Grade9Row(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Grade9RowChanged != null)
                {
                    this.Grade9RowChanged(this, new dsSchool.Grade9RowChangeEvent((dsSchool.Grade9Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Grade9RowChanging != null)
                {
                    this.Grade9RowChanging(this, new dsSchool.Grade9RowChangeEvent((dsSchool.Grade9Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Grade9RowDeleted != null)
                {
                    this.Grade9RowDeleted(this, new dsSchool.Grade9RowChangeEvent((dsSchool.Grade9Row)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Grade9RowDeleting != null)
                {
                    this.Grade9RowDeleting(this, new dsSchool.Grade9RowChangeEvent((dsSchool.Grade9Row)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveGrade9Row(dsSchool.Grade9Row row)
            {
                base.Rows.Remove(row);
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
            public DataColumn GradeColumn
            {
                get
                {
                    return this.columnGrade;
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
            public dsSchool.Grade9Row this[int index]
            {
                get
                {
                    return (dsSchool.Grade9Row)base.Rows[index];
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

        public class Grade9Row : DataRow
        {
            private dsSchool.Grade9DataTable tableGrade9;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal Grade9Row(DataRowBuilder rb) : base(rb)
            {
                this.tableGrade9 = (dsSchool.Grade9DataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableGrade9.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tableGrade9.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Grade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableGrade9.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'Grade9' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableGrade9.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    return (short)base[this.tableGrade9.GradeIDColumn];
                }
                set
                {
                    base[this.tableGrade9.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableGrade9.YearsColumn];
                }
                set
                {
                    base[this.tableGrade9.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Grade9RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.Grade9Row eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Grade9RowChangeEvent(dsSchool.Grade9Row row, DataRowAction action)
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
            public dsSchool.Grade9Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Grade9RowChangeEventHandler(object sender, dsSchool.Grade9RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class GradeDataTable : TypedTableBase<dsSchool.GradeRow>
        {
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnYears;
            private DataColumn columnYearsGrade;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.GradeRowChangeEventHandler GradeRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.GradeRowChangeEventHandler GradeRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.GradeRowChangeEventHandler GradeRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.GradeRowChangeEventHandler GradeRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public GradeDataTable()
            {
                base.TableName = "Grade";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal GradeDataTable(DataTable table)
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
            protected GradeDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddGradeRow(dsSchool.GradeRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.GradeRow AddGradeRow(short Years, string Grade, string YearsGrade, short GradeID)
            {
                dsSchool.GradeRow row = (dsSchool.GradeRow)base.NewRow();
                row.ItemArray = new object[] { Years, Grade, YearsGrade, GradeID };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.GradeDataTable table = (dsSchool.GradeDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.GradeDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.GradeRow FindByYears(short Years)
            {
                return (dsSchool.GradeRow)base.Rows.Find(new object[] { Years });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.GradeRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "GradeDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnYearsGrade = new DataColumn("YearsGrade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnYearsGrade);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnYears }, true));
                this.columnYears.AllowDBNull = false;
                this.columnYears.Unique = true;
                this.columnGrade.MaxLength = 2;
                this.columnYearsGrade.ReadOnly = true;
                this.columnYearsGrade.MaxLength = 0x22;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnYears = base.Columns["Years"];
                this.columnGrade = base.Columns["Grade"];
                this.columnYearsGrade = base.Columns["YearsGrade"];
                this.columnGradeID = base.Columns["GradeID"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.GradeRow NewGradeRow()
            {
                return (dsSchool.GradeRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.GradeRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GradeRowChanged != null)
                {
                    this.GradeRowChanged(this, new dsSchool.GradeRowChangeEvent((dsSchool.GradeRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GradeRowChanging != null)
                {
                    this.GradeRowChanging(this, new dsSchool.GradeRowChangeEvent((dsSchool.GradeRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GradeRowDeleted != null)
                {
                    this.GradeRowDeleted(this, new dsSchool.GradeRowChangeEvent((dsSchool.GradeRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GradeRowDeleting != null)
                {
                    this.GradeRowDeleting(this, new dsSchool.GradeRowChangeEvent((dsSchool.GradeRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveGradeRow(dsSchool.GradeRow row)
            {
                base.Rows.Remove(row);
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.GradeRow this[int index]
            {
                get
                {
                    return (dsSchool.GradeRow)base.Rows[index];
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn YearsGradeColumn
            {
                get
                {
                    return this.columnYearsGrade;
                }
            }
        }

        public class GradeRow : DataRow
        {
            private dsSchool.GradeDataTable tableGrade;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal GradeRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGrade = (dsSchool.GradeDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tableGrade.GradeIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableGrade.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsYearsGradeNull()
            {
                return base.IsNull(this.tableGrade.YearsGradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeIDNull()
            {
                base[this.tableGrade.GradeIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tableGrade.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetYearsGradeNull()
            {
                base[this.tableGrade.YearsGradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Grade
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableGrade.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'Grade' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableGrade.GradeColumn] = value;
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
                        num = (short)base[this.tableGrade.GradeIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeID' in table 'Grade' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrade.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableGrade.YearsColumn];
                }
                set
                {
                    base[this.tableGrade.YearsColumn] = value;
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
                        str = (string)base[this.tableGrade.YearsGradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'YearsGrade' in table 'Grade' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableGrade.YearsGradeColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class GradeRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.GradeRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public GradeRowChangeEvent(dsSchool.GradeRow row, DataRowAction action)
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
            public dsSchool.GradeRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void GradeRowChangeEventHandler(object sender, dsSchool.GradeRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SchoolRankDataTable : TypedTableBase<dsSchool.SchoolRankRow>
        {
            private DataColumn columnRank;
            private DataColumn columnSchoolRank;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchoolRankRowChangeEventHandler SchoolRankRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchoolRankRowChangeEventHandler SchoolRankRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchoolRankRowChangeEventHandler SchoolRankRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchoolRankRowChangeEventHandler SchoolRankRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SchoolRankDataTable()
            {
                base.TableName = "SchoolRank";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SchoolRankDataTable(DataTable table)
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
            protected SchoolRankDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSchoolRankRow(dsSchool.SchoolRankRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SchoolRankRow AddSchoolRankRow(short Rank, string SchoolRank)
            {
                dsSchool.SchoolRankRow row = (dsSchool.SchoolRankRow)base.NewRow();
                row.ItemArray = new object[] { Rank, SchoolRank };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.SchoolRankDataTable table = (dsSchool.SchoolRankDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.SchoolRankDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SchoolRankRow FindByRank(short Rank)
            {
                return (dsSchool.SchoolRankRow)base.Rows.Find(new object[] { Rank });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.SchoolRankRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "SchoolRankDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnRank = new DataColumn("Rank", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnRank);
                this.columnSchoolRank = new DataColumn("SchoolRank", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSchoolRank);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnRank }, true));
                this.columnRank.AllowDBNull = false;
                this.columnRank.Unique = true;
                this.columnSchoolRank.MaxLength = 20;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnRank = base.Columns["Rank"];
                this.columnSchoolRank = base.Columns["SchoolRank"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.SchoolRankRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SchoolRankRow NewSchoolRankRow()
            {
                return (dsSchool.SchoolRankRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SchoolRankRowChanged != null)
                {
                    this.SchoolRankRowChanged(this, new dsSchool.SchoolRankRowChangeEvent((dsSchool.SchoolRankRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SchoolRankRowChanging != null)
                {
                    this.SchoolRankRowChanging(this, new dsSchool.SchoolRankRowChangeEvent((dsSchool.SchoolRankRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SchoolRankRowDeleted != null)
                {
                    this.SchoolRankRowDeleted(this, new dsSchool.SchoolRankRowChangeEvent((dsSchool.SchoolRankRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SchoolRankRowDeleting != null)
                {
                    this.SchoolRankRowDeleting(this, new dsSchool.SchoolRankRowChangeEvent((dsSchool.SchoolRankRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveSchoolRankRow(dsSchool.SchoolRankRow row)
            {
                base.Rows.Remove(row);
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
            public dsSchool.SchoolRankRow this[int index]
            {
                get
                {
                    return (dsSchool.SchoolRankRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn RankColumn
            {
                get
                {
                    return this.columnRank;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SchoolRankColumn
            {
                get
                {
                    return this.columnSchoolRank;
                }
            }
        }

        public class SchoolRankRow : DataRow
        {
            private dsSchool.SchoolRankDataTable tableSchoolRank;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SchoolRankRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSchoolRank = (dsSchool.SchoolRankDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSchoolRankNull()
            {
                return base.IsNull(this.tableSchoolRank.SchoolRankColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSchoolRankNull()
            {
                base[this.tableSchoolRank.SchoolRankColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Rank
            {
                get
                {
                    return (short)base[this.tableSchoolRank.RankColumn];
                }
                set
                {
                    base[this.tableSchoolRank.RankColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SchoolRank
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableSchoolRank.SchoolRankColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchoolRank' in table 'SchoolRank' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSchoolRank.SchoolRankColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SchoolRankRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.SchoolRankRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SchoolRankRowChangeEvent(dsSchool.SchoolRankRow row, DataRowAction action)
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
            public dsSchool.SchoolRankRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SchoolRankRowChangeEventHandler(object sender, dsSchool.SchoolRankRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SchYearsDataTable : TypedTableBase<dsSchool.SchYearsRow>
        {
            private DataColumn columnSchYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsRowChangeEventHandler SchYearsRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsRowChangeEventHandler SchYearsRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsRowChangeEventHandler SchYearsRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsRowChangeEventHandler SchYearsRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SchYearsDataTable()
            {
                base.TableName = "SchYears";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SchYearsDataTable(DataTable table)
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
            protected SchYearsDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddSchYearsRow(dsSchool.SchYearsRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SchYearsRow AddSchYearsRow(short SchYears)
            {
                dsSchool.SchYearsRow row = (dsSchool.SchYearsRow)base.NewRow();
                row.ItemArray = new object[] { SchYears };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.SchYearsDataTable table = (dsSchool.SchYearsDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.SchYearsDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SchYearsRow FindBySchYears(short SchYears)
            {
                return (dsSchool.SchYearsRow)base.Rows.Find(new object[] { SchYears });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.SchYearsRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "SchYearsDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnSchYears }, true));
                this.columnSchYears.AllowDBNull = false;
                this.columnSchYears.Unique = true;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnSchYears = base.Columns["SchYears"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.SchYearsRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SchYearsRow NewSchYearsRow()
            {
                return (dsSchool.SchYearsRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SchYearsRowChanged != null)
                {
                    this.SchYearsRowChanged(this, new dsSchool.SchYearsRowChangeEvent((dsSchool.SchYearsRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SchYearsRowChanging != null)
                {
                    this.SchYearsRowChanging(this, new dsSchool.SchYearsRowChangeEvent((dsSchool.SchYearsRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SchYearsRowDeleted != null)
                {
                    this.SchYearsRowDeleted(this, new dsSchool.SchYearsRowChangeEvent((dsSchool.SchYearsRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SchYearsRowDeleting != null)
                {
                    this.SchYearsRowDeleting(this, new dsSchool.SchYearsRowChangeEvent((dsSchool.SchYearsRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSchYearsRow(dsSchool.SchYearsRow row)
            {
                base.Rows.Remove(row);
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
            public dsSchool.SchYearsRow this[int index]
            {
                get
                {
                    return (dsSchool.SchYearsRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SchYearsColumn
            {
                get
                {
                    return this.columnSchYears;
                }
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SchYearsMonthDataTable : TypedTableBase<dsSchool.SchYearsMonthRow>
        {
            private DataColumn columnMonthOrder;
            private DataColumn columnMonths;
            private DataColumn columnSem;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsMonthRowChangeEventHandler SchYearsMonthRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsMonthRowChangeEventHandler SchYearsMonthRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsMonthRowChangeEventHandler SchYearsMonthRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SchYearsMonthRowChangeEventHandler SchYearsMonthRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SchYearsMonthDataTable()
            {
                base.TableName = "SchYearsMonth";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SchYearsMonthDataTable(DataTable table)
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
            protected SchYearsMonthDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSchYearsMonthRow(dsSchool.SchYearsMonthRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SchYearsMonthRow AddSchYearsMonthRow(short Sem, short MonthOrder, string Months)
            {
                dsSchool.SchYearsMonthRow row = (dsSchool.SchYearsMonthRow)base.NewRow();
                row.ItemArray = new object[] { Sem, MonthOrder, Months };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.SchYearsMonthDataTable table = (dsSchool.SchYearsMonthDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.SchYearsMonthDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SchYearsMonthRow FindBySemMonthOrder(short Sem, short MonthOrder)
            {
                return (dsSchool.SchYearsMonthRow)base.Rows.Find(new object[] { Sem, MonthOrder });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.SchYearsMonthRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "SchYearsMonthDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnMonthOrder = new DataColumn("MonthOrder", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnMonthOrder);
                this.columnMonths = new DataColumn("Months", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMonths);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnSem, this.columnMonthOrder }, true));
                this.columnSem.AllowDBNull = false;
                this.columnMonthOrder.AllowDBNull = false;
                this.columnMonths.AllowDBNull = false;
                this.columnMonths.MaxLength = 2;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSem = base.Columns["Sem"];
                this.columnMonthOrder = base.Columns["MonthOrder"];
                this.columnMonths = base.Columns["Months"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.SchYearsMonthRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SchYearsMonthRow NewSchYearsMonthRow()
            {
                return (dsSchool.SchYearsMonthRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SchYearsMonthRowChanged != null)
                {
                    this.SchYearsMonthRowChanged(this, new dsSchool.SchYearsMonthRowChangeEvent((dsSchool.SchYearsMonthRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SchYearsMonthRowChanging != null)
                {
                    this.SchYearsMonthRowChanging(this, new dsSchool.SchYearsMonthRowChangeEvent((dsSchool.SchYearsMonthRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SchYearsMonthRowDeleted != null)
                {
                    this.SchYearsMonthRowDeleted(this, new dsSchool.SchYearsMonthRowChangeEvent((dsSchool.SchYearsMonthRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SchYearsMonthRowDeleting != null)
                {
                    this.SchYearsMonthRowDeleting(this, new dsSchool.SchYearsMonthRowChangeEvent((dsSchool.SchYearsMonthRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveSchYearsMonthRow(dsSchool.SchYearsMonthRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SchYearsMonthRow this[int index]
            {
                get
                {
                    return (dsSchool.SchYearsMonthRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn MonthOrderColumn
            {
                get
                {
                    return this.columnMonthOrder;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn MonthsColumn
            {
                get
                {
                    return this.columnMonths;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
                }
            }
        }

        public class SchYearsMonthRow : DataRow
        {
            private dsSchool.SchYearsMonthDataTable tableSchYearsMonth;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SchYearsMonthRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSchYearsMonth = (dsSchool.SchYearsMonthDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short MonthOrder
            {
                get
                {
                    return (short)base[this.tableSchYearsMonth.MonthOrderColumn];
                }
                set
                {
                    base[this.tableSchYearsMonth.MonthOrderColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Months
            {
                get
                {
                    return (string)base[this.tableSchYearsMonth.MonthsColumn];
                }
                set
                {
                    base[this.tableSchYearsMonth.MonthsColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sem
            {
                get
                {
                    return (short)base[this.tableSchYearsMonth.SemColumn];
                }
                set
                {
                    base[this.tableSchYearsMonth.SemColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SchYearsMonthRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.SchYearsMonthRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SchYearsMonthRowChangeEvent(dsSchool.SchYearsMonthRow row, DataRowAction action)
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
            public dsSchool.SchYearsMonthRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SchYearsMonthRowChangeEventHandler(object sender, dsSchool.SchYearsMonthRowChangeEvent e);

        public class SchYearsRow : DataRow
        {
            private dsSchool.SchYearsDataTable tableSchYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SchYearsRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSchYears = (dsSchool.SchYearsDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchYears
            {
                get
                {
                    return (short)base[this.tableSchYears.SchYearsColumn];
                }
                set
                {
                    base[this.tableSchYears.SchYearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SchYearsRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.SchYearsRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SchYearsRowChangeEvent(dsSchool.SchYearsRow row, DataRowAction action)
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
            public dsSchool.SchYearsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SchYearsRowChangeEventHandler(object sender, dsSchool.SchYearsRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SemDataTable : TypedTableBase<dsSchool.SemRow>
        {
            private DataColumn columnFluorWeeks;
            private DataColumn columnSchYears;
            private DataColumn columnSchYearSemText;
            private DataColumn columnSchYearsSem;
            private DataColumn columnSem;
            private DataColumn columnWeeks;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SemRowChangeEventHandler SemRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SemRowChangeEventHandler SemRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SemRowChangeEventHandler SemRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SemRowChangeEventHandler SemRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SemDataTable()
            {
                base.TableName = "Sem";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SemDataTable(DataTable table)
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
            protected SemDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddSemRow(dsSchool.SemRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SemRow AddSemRow(short SchYears, short Sem, short Weeks, short FluorWeeks, string SchYearsSem, string SchYearSemText)
            {
                dsSchool.SemRow row = (dsSchool.SemRow)base.NewRow();
                row.ItemArray = new object[] { SchYears, Sem, Weeks, FluorWeeks, SchYearsSem, SchYearSemText };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.SemDataTable table = (dsSchool.SemDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.SemDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SemRow FindBySchYearsSem(short SchYears, short Sem)
            {
                return (dsSchool.SemRow)base.Rows.Find(new object[] { SchYears, Sem });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.SemRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "SemDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnWeeks = new DataColumn("Weeks", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnWeeks);
                this.columnFluorWeeks = new DataColumn("FluorWeeks", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnFluorWeeks);
                this.columnSchYearsSem = new DataColumn("SchYearsSem", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSchYearsSem);
                this.columnSchYearSemText = new DataColumn("SchYearSemText", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSchYearSemText);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnSchYears, this.columnSem }, true));
                this.columnSchYears.AllowDBNull = false;
                this.columnSem.AllowDBNull = false;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSchYears = base.Columns["SchYears"];
                this.columnSem = base.Columns["Sem"];
                this.columnWeeks = base.Columns["Weeks"];
                this.columnFluorWeeks = base.Columns["FluorWeeks"];
                this.columnSchYearsSem = base.Columns["SchYearsSem"];
                this.columnSchYearSemText = base.Columns["SchYearSemText"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.SemRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SemRow NewSemRow()
            {
                return (dsSchool.SemRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SemRowChanged != null)
                {
                    this.SemRowChanged(this, new dsSchool.SemRowChangeEvent((dsSchool.SemRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SemRowChanging != null)
                {
                    this.SemRowChanging(this, new dsSchool.SemRowChangeEvent((dsSchool.SemRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SemRowDeleted != null)
                {
                    this.SemRowDeleted(this, new dsSchool.SemRowChangeEvent((dsSchool.SemRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SemRowDeleting != null)
                {
                    this.SemRowDeleting(this, new dsSchool.SemRowChangeEvent((dsSchool.SemRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSemRow(dsSchool.SemRow row)
            {
                base.Rows.Remove(row);
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
            public DataColumn FluorWeeksColumn
            {
                get
                {
                    return this.columnFluorWeeks;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SemRow this[int index]
            {
                get
                {
                    return (dsSchool.SemRow)base.Rows[index];
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SchYearSemTextColumn
            {
                get
                {
                    return this.columnSchYearSemText;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SchYearsSemColumn
            {
                get
                {
                    return this.columnSchYearsSem;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn WeeksColumn
            {
                get
                {
                    return this.columnWeeks;
                }
            }
        }

        public class SemRow : DataRow
        {
            private dsSchool.SemDataTable tableSem;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SemRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSem = (dsSchool.SemDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFluorWeeksNull()
            {
                return base.IsNull(this.tableSem.FluorWeeksColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSchYearSemTextNull()
            {
                return base.IsNull(this.tableSem.SchYearSemTextColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSchYearsSemNull()
            {
                return base.IsNull(this.tableSem.SchYearsSemColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsWeeksNull()
            {
                return base.IsNull(this.tableSem.WeeksColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFluorWeeksNull()
            {
                base[this.tableSem.FluorWeeksColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchYearSemTextNull()
            {
                base[this.tableSem.SchYearSemTextColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSchYearsSemNull()
            {
                base[this.tableSem.SchYearsSemColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetWeeksNull()
            {
                base[this.tableSem.WeeksColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short FluorWeeks
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableSem.FluorWeeksColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'FluorWeeks' in table 'Sem' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSem.FluorWeeksColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchYears
            {
                get
                {
                    return (short)base[this.tableSem.SchYearsColumn];
                }
                set
                {
                    base[this.tableSem.SchYearsColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SchYearSemText
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableSem.SchYearSemTextColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYearSemText' in table 'Sem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSem.SchYearSemTextColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SchYearsSem
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableSem.SchYearsSemColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYearsSem' in table 'Sem' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSem.SchYearsSemColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sem
            {
                get
                {
                    return (short)base[this.tableSem.SemColumn];
                }
                set
                {
                    base[this.tableSem.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Weeks
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableSem.WeeksColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Weeks' in table 'Sem' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSem.WeeksColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SemRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.SemRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SemRowChangeEvent(dsSchool.SemRow row, DataRowAction action)
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
            public dsSchool.SemRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SemRowChangeEventHandler(object sender, dsSchool.SemRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class StCountDataTable : TypedTableBase<dsSchool.StCountRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnPID;
            private DataColumn columnSeat;
            private DataColumn columnSexID;
            private DataColumn columnYears;
            private DataColumn columnZip;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.StCountRowChangeEventHandler StCountRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.StCountRowChangeEventHandler StCountRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.StCountRowChangeEventHandler StCountRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.StCountRowChangeEventHandler StCountRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public StCountDataTable()
            {
                base.TableName = "StCount";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal StCountDataTable(DataTable table)
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
            protected StCountDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddStCountRow(dsSchool.StCountRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.StCountRow AddStCountRow(string PID, short SexID, short Years, short ClassID, short Seat, string Zip, short GradeID, string Grade, string Class, string cSex)
            {
                dsSchool.StCountRow row = (dsSchool.StCountRow)base.NewRow();
                row.ItemArray = new object[] { PID, SexID, Years, ClassID, Seat, Zip, GradeID, Grade, Class, cSex };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.StCountDataTable table = (dsSchool.StCountDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.StCountDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.StCountRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "StCountDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnZip = new DataColumn("Zip", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZip);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnZip.AllowDBNull = false;
                this.columnZip.MaxLength = 3;
                this.columnGradeID.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columncSex.MaxLength = 2;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnSeat = base.Columns["Seat"];
                this.columnZip = base.Columns["Zip"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columncSex = base.Columns["cSex"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.StCountRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.StCountRow NewStCountRow()
            {
                return (dsSchool.StCountRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.StCountRowChanged != null)
                {
                    this.StCountRowChanged(this, new dsSchool.StCountRowChangeEvent((dsSchool.StCountRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.StCountRowChanging != null)
                {
                    this.StCountRowChanging(this, new dsSchool.StCountRowChangeEvent((dsSchool.StCountRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.StCountRowDeleted != null)
                {
                    this.StCountRowDeleted(this, new dsSchool.StCountRowChangeEvent((dsSchool.StCountRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.StCountRowDeleting != null)
                {
                    this.StCountRowDeleting(this, new dsSchool.StCountRowChangeEvent((dsSchool.StCountRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveStCountRow(dsSchool.StCountRow row)
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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
            public dsSchool.StCountRow this[int index]
            {
                get
                {
                    return (dsSchool.StCountRow)base.Rows[index];
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ZipColumn
            {
                get
                {
                    return this.columnZip;
                }
            }
        }

        public class StCountRow : DataRow
        {
            private dsSchool.StCountDataTable tableStCount;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal StCountRow(DataRowBuilder rb) : base(rb)
            {
                this.tableStCount = (dsSchool.StCountDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableStCount.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tableStCount.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableStCount.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableStCount.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tableStCount.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tableStCount.cSexColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tableStCount.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tableStCount.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableStCount.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'StCount' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStCount.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tableStCount.ClassIDColumn];
                }
                set
                {
                    base[this.tableStCount.ClassIDColumn] = value;
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
                        str = (string)base[this.tableStCount.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'StCount' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStCount.cSexColumn] = value;
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
                        str = (string)base[this.tableStCount.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'StCount' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableStCount.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    return (short)base[this.tableStCount.GradeIDColumn];
                }
                set
                {
                    base[this.tableStCount.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string)base[this.tableStCount.PIDColumn];
                }
                set
                {
                    base[this.tableStCount.PIDColumn] = value;
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
                        num = (short)base[this.tableStCount.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'StCount' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableStCount.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short)base[this.tableStCount.SexIDColumn];
                }
                set
                {
                    base[this.tableStCount.SexIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Years
            {
                get
                {
                    return (short)base[this.tableStCount.YearsColumn];
                }
                set
                {
                    base[this.tableStCount.YearsColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Zip
            {
                get
                {
                    return (string)base[this.tableStCount.ZipColumn];
                }
                set
                {
                    base[this.tableStCount.ZipColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class StCountRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.StCountRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public StCountRowChangeEvent(dsSchool.StCountRow row, DataRowAction action)
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
            public dsSchool.StCountRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void StCountRowChangeEventHandler(object sender, dsSchool.StCountRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SystemSetDataTable : TypedTableBase<dsSchool.SystemSetRow>
        {
            private DataColumn columnItem;
            private DataColumn columnItemC;
            private DataColumn columnOrderID;
            private DataColumn columnSetting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SystemSetRowChangeEventHandler SystemSetRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SystemSetRowChangeEventHandler SystemSetRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SystemSetRowChangeEventHandler SystemSetRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.SystemSetRowChangeEventHandler SystemSetRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SystemSetDataTable()
            {
                base.TableName = "SystemSet";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SystemSetDataTable(DataTable table)
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
            protected SystemSetDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddSystemSetRow(dsSchool.SystemSetRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SystemSetRow AddSystemSetRow(string Item, string Setting, short OrderID, string ItemC)
            {
                dsSchool.SystemSetRow row = (dsSchool.SystemSetRow)base.NewRow();
                row.ItemArray = new object[] { Item, Setting, OrderID, ItemC };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.SystemSetDataTable table = (dsSchool.SystemSetDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.SystemSetDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.SystemSetRow FindByItem(string Item)
            {
                return (dsSchool.SystemSetRow)base.Rows.Find(new object[] { Item });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.SystemSetRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "SystemSetDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnItem = new DataColumn("Item", typeof(string), null, MappingType.Element);
                this.columnItem.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "Item");
                this.columnItem.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "ItemColumn");
                this.columnItem.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnItem");
                this.columnItem.ExtendedProperties.Add("Generator_UserColumnName", "Item");
                base.Columns.Add(this.columnItem);
                this.columnSetting = new DataColumn("Setting", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSetting);
                this.columnOrderID = new DataColumn("OrderID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnOrderID);
                this.columnItemC = new DataColumn("ItemC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnItemC);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnItem }, true));
                this.columnItem.AllowDBNull = false;
                this.columnItem.Unique = true;
                this.columnItem.MaxLength = 20;
                this.columnSetting.MaxLength = 40;
                this.columnItemC.MaxLength = 20;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnItem = base.Columns["Item"];
                this.columnSetting = base.Columns["Setting"];
                this.columnOrderID = base.Columns["OrderID"];
                this.columnItemC = base.Columns["ItemC"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.SystemSetRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.SystemSetRow NewSystemSetRow()
            {
                return (dsSchool.SystemSetRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SystemSetRowChanged != null)
                {
                    this.SystemSetRowChanged(this, new dsSchool.SystemSetRowChangeEvent((dsSchool.SystemSetRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SystemSetRowChanging != null)
                {
                    this.SystemSetRowChanging(this, new dsSchool.SystemSetRowChangeEvent((dsSchool.SystemSetRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SystemSetRowDeleted != null)
                {
                    this.SystemSetRowDeleted(this, new dsSchool.SystemSetRowChangeEvent((dsSchool.SystemSetRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SystemSetRowDeleting != null)
                {
                    this.SystemSetRowDeleting(this, new dsSchool.SystemSetRowChangeEvent((dsSchool.SystemSetRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSystemSetRow(dsSchool.SystemSetRow row)
            {
                base.Rows.Remove(row);
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
            public dsSchool.SystemSetRow this[int index]
            {
                get
                {
                    return (dsSchool.SystemSetRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ItemCColumn
            {
                get
                {
                    return this.columnItemC;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ItemColumn
            {
                get
                {
                    return this.columnItem;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn OrderIDColumn
            {
                get
                {
                    return this.columnOrderID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SettingColumn
            {
                get
                {
                    return this.columnSetting;
                }
            }
        }

        public class SystemSetRow : DataRow
        {
            private dsSchool.SystemSetDataTable tableSystemSet;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SystemSetRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSystemSet = (dsSchool.SystemSetDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsItemCNull()
            {
                return base.IsNull(this.tableSystemSet.ItemCColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsOrderIDNull()
            {
                return base.IsNull(this.tableSystemSet.OrderIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSettingNull()
            {
                return base.IsNull(this.tableSystemSet.SettingColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetItemCNull()
            {
                base[this.tableSystemSet.ItemCColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrderIDNull()
            {
                base[this.tableSystemSet.OrderIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSettingNull()
            {
                base[this.tableSystemSet.SettingColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Item
            {
                get
                {
                    return (string)base[this.tableSystemSet.ItemColumn];
                }
                set
                {
                    base[this.tableSystemSet.ItemColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ItemC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableSystemSet.ItemCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ItemC' in table 'SystemSet' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSystemSet.ItemCColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short OrderID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableSystemSet.OrderIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'OrderID' in table 'SystemSet' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSystemSet.OrderIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Setting
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableSystemSet.SettingColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Setting' in table 'SystemSet' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSystemSet.SettingColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SystemSetRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.SystemSetRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SystemSetRowChangeEvent(dsSchool.SystemSetRow row, DataRowAction action)
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
            public dsSchool.SystemSetRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SystemSetRowChangeEventHandler(object sender, dsSchool.SystemSetRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class VocationDataTable : TypedTableBase<dsSchool.VocationRow>
        {
            private DataColumn columnVocation;
            private DataColumn columnVocID;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.VocationRowChangeEventHandler VocationRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.VocationRowChangeEventHandler VocationRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.VocationRowChangeEventHandler VocationRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.VocationRowChangeEventHandler VocationRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public VocationDataTable()
            {
                base.TableName = "Vocation";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal VocationDataTable(DataTable table)
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
            protected VocationDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddVocationRow(dsSchool.VocationRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.VocationRow AddVocationRow(string VocID, string Vocation)
            {
                dsSchool.VocationRow row = (dsSchool.VocationRow)base.NewRow();
                row.ItemArray = new object[] { VocID, Vocation };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSchool.VocationDataTable table = (dsSchool.VocationDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.VocationDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.VocationRow FindByVocID(string VocID)
            {
                return (dsSchool.VocationRow)base.Rows.Find(new object[] { VocID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.VocationRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "VocationDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnVocID = new DataColumn("VocID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVocID);
                this.columnVocation = new DataColumn("Vocation", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVocation);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnVocID }, true));
                this.columnVocID.AllowDBNull = false;
                this.columnVocID.Unique = true;
                this.columnVocID.MaxLength = 1;
                this.columnVocation.MaxLength = 0x10;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnVocID = base.Columns["VocID"];
                this.columnVocation = base.Columns["Vocation"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.VocationRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.VocationRow NewVocationRow()
            {
                return (dsSchool.VocationRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VocationRowChanged != null)
                {
                    this.VocationRowChanged(this, new dsSchool.VocationRowChangeEvent((dsSchool.VocationRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VocationRowChanging != null)
                {
                    this.VocationRowChanging(this, new dsSchool.VocationRowChangeEvent((dsSchool.VocationRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VocationRowDeleted != null)
                {
                    this.VocationRowDeleted(this, new dsSchool.VocationRowChangeEvent((dsSchool.VocationRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VocationRowDeleting != null)
                {
                    this.VocationRowDeleting(this, new dsSchool.VocationRowChangeEvent((dsSchool.VocationRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveVocationRow(dsSchool.VocationRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.VocationRow this[int index]
            {
                get
                {
                    return (dsSchool.VocationRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VocationColumn
            {
                get
                {
                    return this.columnVocation;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VocIDColumn
            {
                get
                {
                    return this.columnVocID;
                }
            }
        }

        public class VocationRow : DataRow
        {
            private dsSchool.VocationDataTable tableVocation;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal VocationRow(DataRowBuilder rb) : base(rb)
            {
                this.tableVocation = (dsSchool.VocationDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVocationNull()
            {
                return base.IsNull(this.tableVocation.VocationColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVocationNull()
            {
                base[this.tableVocation.VocationColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Vocation
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableVocation.VocationColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Vocation' in table 'Vocation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableVocation.VocationColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string VocID
            {
                get
                {
                    return (string)base[this.tableVocation.VocIDColumn];
                }
                set
                {
                    base[this.tableVocation.VocIDColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class VocationRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.VocationRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public VocationRowChangeEvent(dsSchool.VocationRow row, DataRowAction action)
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
            public dsSchool.VocationRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void VocationRowChangeEventHandler(object sender, dsSchool.VocationRowChangeEvent e);

        private class YearsClass1DataTable
        {
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class YearsClassDataTable : TypedTableBase<dsSchool.YearsClassRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnisTee;
            private DataColumn columnPW;
            private DataColumn columnSeat;
            private DataColumn columnsight;
            private DataColumn columnStCount;
            private DataColumn columntee;
            private DataColumn columnVocID;
            private DataColumn columnwh;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsClassRowChangeEventHandler YearsClassRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsClassRowChangeEventHandler YearsClassRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsClassRowChangeEventHandler YearsClassRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsClassRowChangeEventHandler YearsClassRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public YearsClassDataTable()
            {
                base.TableName = "YearsClass";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal YearsClassDataTable(DataTable table)
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
            protected YearsClassDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddYearsClassRow(dsSchool.YearsClassRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.YearsClassRow AddYearsClassRow(short Years, short ClassID, string Class, string PW, bool wh, bool sight, bool tee, bool Seat, bool isTee, int StCount, short GradeID, string Grade, string VocID)
            {
                dsSchool.YearsClassRow row = (dsSchool.YearsClassRow)base.NewRow();
                row.ItemArray = new object[] { Years, ClassID, Class, PW, wh, sight, tee, Seat, isTee, StCount, GradeID, Grade, VocID };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.YearsClassDataTable table = (dsSchool.YearsClassDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.YearsClassDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.YearsClassRow FindByYearsClassID(short Years, short ClassID)
            {
                return (dsSchool.YearsClassRow)base.Rows.Find(new object[] { Years, ClassID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.YearsClassRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "YearsClassDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnPW = new DataColumn("PW", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPW);
                this.columnwh = new DataColumn("wh", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnwh);
                this.columnsight = new DataColumn("sight", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnsight);
                this.columntee = new DataColumn("tee", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columntee);
                this.columnSeat = new DataColumn("Seat", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnisTee = new DataColumn("isTee", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnisTee);
                this.columnStCount = new DataColumn("StCount", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStCount);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnVocID = new DataColumn("VocID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVocID);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnYears, this.columnClassID }, true));
                this.columnYears.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnClass.MaxLength = 10;
                this.columnPW.MaxLength = 10;
                this.columnStCount.DefaultValue = 0;
                this.columnGrade.MaxLength = 2;
                this.columnVocID.MaxLength = 1;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnYears = base.Columns["Years"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass = base.Columns["Class"];
                this.columnPW = base.Columns["PW"];
                this.columnwh = base.Columns["wh"];
                this.columnsight = base.Columns["sight"];
                this.columntee = base.Columns["tee"];
                this.columnSeat = base.Columns["Seat"];
                this.columnisTee = base.Columns["isTee"];
                this.columnStCount = base.Columns["StCount"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnVocID = base.Columns["VocID"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.YearsClassRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.YearsClassRow NewYearsClassRow()
            {
                return (dsSchool.YearsClassRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.YearsClassRowChanged != null)
                {
                    this.YearsClassRowChanged(this, new dsSchool.YearsClassRowChangeEvent((dsSchool.YearsClassRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.YearsClassRowChanging != null)
                {
                    this.YearsClassRowChanging(this, new dsSchool.YearsClassRowChangeEvent((dsSchool.YearsClassRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.YearsClassRowDeleted != null)
                {
                    this.YearsClassRowDeleted(this, new dsSchool.YearsClassRowChangeEvent((dsSchool.YearsClassRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.YearsClassRowDeleting != null)
                {
                    this.YearsClassRowDeleting(this, new dsSchool.YearsClassRowChangeEvent((dsSchool.YearsClassRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveYearsClassRow(dsSchool.YearsClassRow row)
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
            public DataColumn isTeeColumn
            {
                get
                {
                    return this.columnisTee;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.YearsClassRow this[int index]
            {
                get
                {
                    return (dsSchool.YearsClassRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PWColumn
            {
                get
                {
                    return this.columnPW;
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
            public DataColumn sightColumn
            {
                get
                {
                    return this.columnsight;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn StCountColumn
            {
                get
                {
                    return this.columnStCount;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn teeColumn
            {
                get
                {
                    return this.columntee;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VocIDColumn
            {
                get
                {
                    return this.columnVocID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn whColumn
            {
                get
                {
                    return this.columnwh;
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

        public class YearsClassRow : DataRow
        {
            private dsSchool.YearsClassDataTable tableYearsClass;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal YearsClassRow(DataRowBuilder rb) : base(rb)
            {
                this.tableYearsClass = (dsSchool.YearsClassDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableYearsClass.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tableYearsClass.GradeIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableYearsClass.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsisTeeNull()
            {
                return base.IsNull(this.tableYearsClass.isTeeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsPWNull()
            {
                return base.IsNull(this.tableYearsClass.PWColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableYearsClass.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IssightNull()
            {
                return base.IsNull(this.tableYearsClass.sightColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStCountNull()
            {
                return base.IsNull(this.tableYearsClass.StCountColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsteeNull()
            {
                return base.IsNull(this.tableYearsClass.teeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsVocIDNull()
            {
                return base.IsNull(this.tableYearsClass.VocIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IswhNull()
            {
                return base.IsNull(this.tableYearsClass.whColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tableYearsClass.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeIDNull()
            {
                base[this.tableYearsClass.GradeIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tableYearsClass.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetisTeeNull()
            {
                base[this.tableYearsClass.isTeeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPWNull()
            {
                base[this.tableYearsClass.PWColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tableYearsClass.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetsightNull()
            {
                base[this.tableYearsClass.sightColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetStCountNull()
            {
                base[this.tableYearsClass.StCountColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetteeNull()
            {
                base[this.tableYearsClass.teeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVocIDNull()
            {
                base[this.tableYearsClass.VocIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetwhNull()
            {
                base[this.tableYearsClass.whColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    if (this.IsClassNull())
                    {
                        return string.Empty;
                    }
                    return (string)base[this.tableYearsClass.ClassColumn];
                }
                set
                {
                    base[this.tableYearsClass.ClassColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short ClassID
            {
                get
                {
                    return (short)base[this.tableYearsClass.ClassIDColumn];
                }
                set
                {
                    base[this.tableYearsClass.ClassIDColumn] = value;
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
                        str = (string)base[this.tableYearsClass.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'YearsClass' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableYearsClass.GradeColumn] = value;
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
                        num = (short)base[this.tableYearsClass.GradeIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeID' in table 'YearsClass' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableYearsClass.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool isTee
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool)base[this.tableYearsClass.isTeeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'isTee' in table 'YearsClass' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tableYearsClass.isTeeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PW
            {
                get
                {
                    if (this.IsPWNull())
                    {
                        return string.Empty;
                    }
                    return (string)base[this.tableYearsClass.PWColumn];
                }
                set
                {
                    base[this.tableYearsClass.PWColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool Seat
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool)base[this.tableYearsClass.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'YearsClass' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tableYearsClass.SeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool sight
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool)base[this.tableYearsClass.sightColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'sight' in table 'YearsClass' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tableYearsClass.sightColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int StCount
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[this.tableYearsClass.StCountColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'StCount' in table 'YearsClass' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableYearsClass.StCountColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool tee
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool)base[this.tableYearsClass.teeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'tee' in table 'YearsClass' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tableYearsClass.teeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string VocID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableYearsClass.VocIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'VocID' in table 'YearsClass' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableYearsClass.VocIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool wh
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool)base[this.tableYearsClass.whColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'wh' in table 'YearsClass' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tableYearsClass.whColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableYearsClass.YearsColumn];
                }
                set
                {
                    base[this.tableYearsClass.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class YearsClassRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.YearsClassRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public YearsClassRowChangeEvent(dsSchool.YearsClassRow row, DataRowAction action)
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
            public dsSchool.YearsClassRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void YearsClassRowChangeEventHandler(object sender, dsSchool.YearsClassRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class YearsDataTable : TypedTableBase<dsSchool.YearsRow>
        {
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsRowChangeEventHandler YearsRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsRowChangeEventHandler YearsRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsRowChangeEventHandler YearsRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.YearsRowChangeEventHandler YearsRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public YearsDataTable()
            {
                base.TableName = "Years";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal YearsDataTable(DataTable table)
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
            protected YearsDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddYearsRow(dsSchool.YearsRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.YearsRow AddYearsRow(short Years)
            {
                dsSchool.YearsRow row = (dsSchool.YearsRow)base.NewRow();
                row.ItemArray = new object[] { Years };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSchool.YearsDataTable table = (dsSchool.YearsDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.YearsDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.YearsRow FindByYears(short Years)
            {
                return (dsSchool.YearsRow)base.Rows.Find(new object[] { Years });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.YearsRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "YearsDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnYears }, true));
                this.columnYears.AllowDBNull = false;
                this.columnYears.Unique = true;
                base.Locale = new CultureInfo("zh-TW");
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnYears = base.Columns["Years"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.YearsRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.YearsRow NewYearsRow()
            {
                return (dsSchool.YearsRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.YearsRowChanged != null)
                {
                    this.YearsRowChanged(this, new dsSchool.YearsRowChangeEvent((dsSchool.YearsRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.YearsRowChanging != null)
                {
                    this.YearsRowChanging(this, new dsSchool.YearsRowChangeEvent((dsSchool.YearsRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.YearsRowDeleted != null)
                {
                    this.YearsRowDeleted(this, new dsSchool.YearsRowChangeEvent((dsSchool.YearsRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.YearsRowDeleting != null)
                {
                    this.YearsRowDeleting(this, new dsSchool.YearsRowChangeEvent((dsSchool.YearsRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveYearsRow(dsSchool.YearsRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.YearsRow this[int index]
            {
                get
                {
                    return (dsSchool.YearsRow)base.Rows[index];
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

        public class YearsRow : DataRow
        {
            private dsSchool.YearsDataTable tableYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal YearsRow(DataRowBuilder rb) : base(rb)
            {
                this.tableYears = (dsSchool.YearsDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short)base[this.tableYears.YearsColumn];
                }
                set
                {
                    base[this.tableYears.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class YearsRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.YearsRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public YearsRowChangeEvent(dsSchool.YearsRow row, DataRowAction action)
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
            public dsSchool.YearsRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void YearsRowChangeEventHandler(object sender, dsSchool.YearsRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class ZIPDataTable : TypedTableBase<dsSchool.ZIPRow>
        {
            private DataColumn columnCounty;
            private DataColumn columnCountyID;
            private DataColumn columnTelExt;
            private DataColumn columnTown;
            private DataColumn columnZip;
            private DataColumn columnZipCountyTown;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ZIPRowChangeEventHandler ZIPRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ZIPRowChangeEventHandler ZIPRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ZIPRowChangeEventHandler ZIPRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSchool.ZIPRowChangeEventHandler ZIPRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public ZIPDataTable()
            {
                base.TableName = "ZIP";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal ZIPDataTable(DataTable table)
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
            protected ZIPDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddZIPRow(dsSchool.ZIPRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.ZIPRow AddZIPRow(string Zip, string County, string Town, string TelExt, short CountyID, string ZipCountyTown)
            {
                dsSchool.ZIPRow row = (dsSchool.ZIPRow)base.NewRow();
                row.ItemArray = new object[] { Zip, County, Town, TelExt, CountyID, ZipCountyTown };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSchool.ZIPDataTable table = (dsSchool.ZIPDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSchool.ZIPDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.ZIPRow FindByZip(string Zip)
            {
                return (dsSchool.ZIPRow)base.Rows.Find(new object[] { Zip });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSchool.ZIPRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSchool school = new dsSchool();
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
                    FixedValue = school.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "ZIPDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = school.GetSchemaSerializable();
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
                this.columnZip = new DataColumn("Zip", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZip);
                this.columnCounty = new DataColumn("County", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCounty);
                this.columnTown = new DataColumn("Town", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTown);
                this.columnTelExt = new DataColumn("TelExt", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTelExt);
                this.columnCountyID = new DataColumn("CountyID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnCountyID);
                this.columnZipCountyTown = new DataColumn("ZipCountyTown", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZipCountyTown);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnZip }, true));
                this.columnZip.AllowDBNull = false;
                this.columnZip.Unique = true;
                this.columnZip.MaxLength = 3;
                this.columnCounty.MaxLength = 8;
                this.columnTown.MaxLength = 10;
                this.columnTelExt.MaxLength = 4;
                this.columnZipCountyTown.ReadOnly = true;
                this.columnZipCountyTown.MaxLength = 0x15;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnZip = base.Columns["Zip"];
                this.columnCounty = base.Columns["County"];
                this.columnTown = base.Columns["Town"];
                this.columnTelExt = base.Columns["TelExt"];
                this.columnCountyID = base.Columns["CountyID"];
                this.columnZipCountyTown = base.Columns["ZipCountyTown"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSchool.ZIPRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSchool.ZIPRow NewZIPRow()
            {
                return (dsSchool.ZIPRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ZIPRowChanged != null)
                {
                    this.ZIPRowChanged(this, new dsSchool.ZIPRowChangeEvent((dsSchool.ZIPRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ZIPRowChanging != null)
                {
                    this.ZIPRowChanging(this, new dsSchool.ZIPRowChangeEvent((dsSchool.ZIPRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ZIPRowDeleted != null)
                {
                    this.ZIPRowDeleted(this, new dsSchool.ZIPRowChangeEvent((dsSchool.ZIPRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ZIPRowDeleting != null)
                {
                    this.ZIPRowDeleting(this, new dsSchool.ZIPRowChangeEvent((dsSchool.ZIPRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveZIPRow(dsSchool.ZIPRow row)
            {
                base.Rows.Remove(row);
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
            public DataColumn CountyColumn
            {
                get
                {
                    return this.columnCounty;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CountyIDColumn
            {
                get
                {
                    return this.columnCountyID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSchool.ZIPRow this[int index]
            {
                get
                {
                    return (dsSchool.ZIPRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn TelExtColumn
            {
                get
                {
                    return this.columnTelExt;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn TownColumn
            {
                get
                {
                    return this.columnTown;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ZipCountyTownColumn
            {
                get
                {
                    return this.columnZipCountyTown;
                }
            }
        }

        public class ZIPRow : DataRow
        {
            private dsSchool.ZIPDataTable tableZIP;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal ZIPRow(DataRowBuilder rb) : base(rb)
            {
                this.tableZIP = (dsSchool.ZIPDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCountyIDNull()
            {
                return base.IsNull(this.tableZIP.CountyIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCountyNull()
            {
                return base.IsNull(this.tableZIP.CountyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTelExtNull()
            {
                return base.IsNull(this.tableZIP.TelExtColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTownNull()
            {
                return base.IsNull(this.tableZIP.TownColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsZipCountyTownNull()
            {
                return base.IsNull(this.tableZIP.ZipCountyTownColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCountyIDNull()
            {
                base[this.tableZIP.CountyIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCountyNull()
            {
                base[this.tableZIP.CountyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTelExtNull()
            {
                base[this.tableZIP.TelExtColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTownNull()
            {
                base[this.tableZIP.TownColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetZipCountyTownNull()
            {
                base[this.tableZIP.ZipCountyTownColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string County
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableZIP.CountyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'County' in table 'ZIP' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableZIP.CountyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short CountyID
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableZIP.CountyIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'CountyID' in table 'ZIP' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableZIP.CountyIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string TelExt
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableZIP.TelExtColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'TelExt' in table 'ZIP' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableZIP.TelExtColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Town
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableZIP.TownColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Town' in table 'ZIP' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableZIP.TownColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Zip
            {
                get
                {
                    return (string)base[this.tableZIP.ZipColumn];
                }
                set
                {
                    base[this.tableZIP.ZipColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ZipCountyTown
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableZIP.ZipCountyTownColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ZipCountyTown' in table 'ZIP' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableZIP.ZipCountyTownColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class ZIPRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSchool.ZIPRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public ZIPRowChangeEvent(dsSchool.ZIPRow row, DataRowAction action)
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
            public dsSchool.ZIPRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void ZIPRowChangeEventHandler(object sender, dsSchool.ZIPRowChangeEvent e);
    }
}

