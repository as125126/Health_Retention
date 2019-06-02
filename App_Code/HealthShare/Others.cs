namespace HealthShare
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("Others"), ToolboxItem(true), DesignerCategory("code"), HelpKeyword("vs.data.DataSet")]
    public class Others : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private BloodDataTable tableBlood;
        private ColumnSetDataTable tableColumnSet;
        private ColumnStDataTable tableColumnSt;
        private InsuranceDataTable tableInsurance;
        private TableHealthDataTable tableTableHealth;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Others()
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
        protected Others(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["TableHealth"] != null)
                    {
                        base.Tables.Add(new TableHealthDataTable(dataSet.Tables["TableHealth"]));
                    }
                    if (dataSet.Tables["Blood"] != null)
                    {
                        base.Tables.Add(new BloodDataTable(dataSet.Tables["Blood"]));
                    }
                    if (dataSet.Tables["Insurance"] != null)
                    {
                        base.Tables.Add(new InsuranceDataTable(dataSet.Tables["Insurance"]));
                    }
                    if (dataSet.Tables["ColumnSet"] != null)
                    {
                        base.Tables.Add(new ColumnSetDataTable(dataSet.Tables["ColumnSet"]));
                    }
                    if (dataSet.Tables["ColumnSt"] != null)
                    {
                        base.Tables.Add(new ColumnStDataTable(dataSet.Tables["ColumnSt"]));
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

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public override DataSet Clone()
        {
            Others others = (Others)base.Clone();
            others.InitVars();
            others.SchemaSerializationMode = this.SchemaSerializationMode;
            return others;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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
            Others others = new Others();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny
            {
                Namespace = others.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = others.GetSchemaSerializable();
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
            base.DataSetName = "Others";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Others.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableTableHealth = new TableHealthDataTable();
            base.Tables.Add(this.tableTableHealth);
            this.tableBlood = new BloodDataTable();
            base.Tables.Add(this.tableBlood);
            this.tableInsurance = new InsuranceDataTable();
            base.Tables.Add(this.tableInsurance);
            this.tableColumnSet = new ColumnSetDataTable();
            base.Tables.Add(this.tableColumnSet);
            this.tableColumnSt = new ColumnStDataTable();
            base.Tables.Add(this.tableColumnSt);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableTableHealth = (TableHealthDataTable)base.Tables["TableHealth"];
            if (initTable && (this.tableTableHealth != null))
            {
                this.tableTableHealth.InitVars();
            }
            this.tableBlood = (BloodDataTable)base.Tables["Blood"];
            if (initTable && (this.tableBlood != null))
            {
                this.tableBlood.InitVars();
            }
            this.tableInsurance = (InsuranceDataTable)base.Tables["Insurance"];
            if (initTable && (this.tableInsurance != null))
            {
                this.tableInsurance.InitVars();
            }
            this.tableColumnSet = (ColumnSetDataTable)base.Tables["ColumnSet"];
            if (initTable && (this.tableColumnSet != null))
            {
                this.tableColumnSet.InitVars();
            }
            this.tableColumnSt = (ColumnStDataTable)base.Tables["ColumnSt"];
            if (initTable && (this.tableColumnSt != null))
            {
                this.tableColumnSt.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["TableHealth"] != null)
                {
                    base.Tables.Add(new TableHealthDataTable(dataSet.Tables["TableHealth"]));
                }
                if (dataSet.Tables["Blood"] != null)
                {
                    base.Tables.Add(new BloodDataTable(dataSet.Tables["Blood"]));
                }
                if (dataSet.Tables["Insurance"] != null)
                {
                    base.Tables.Add(new InsuranceDataTable(dataSet.Tables["Insurance"]));
                }
                if (dataSet.Tables["ColumnSet"] != null)
                {
                    base.Tables.Add(new ColumnSetDataTable(dataSet.Tables["ColumnSet"]));
                }
                if (dataSet.Tables["ColumnSt"] != null)
                {
                    base.Tables.Add(new ColumnStDataTable(dataSet.Tables["ColumnSt"]));
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeBlood()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeColumnSet()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeColumnSt()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeInsurance()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeTableHealth()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
        public BloodDataTable Blood
        {
            get
            {
                return this.tableBlood;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public ColumnSetDataTable ColumnSet
        {
            get
            {
                return this.tableColumnSet;
            }
        }

        [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColumnStDataTable ColumnSt
        {
            get
            {
                return this.tableColumnSt;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public InsuranceDataTable Insurance
        {
            get
            {
                return this.tableInsurance;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DebuggerNonUserCode, Browsable(true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public TableHealthDataTable TableHealth
        {
            get
            {
                return this.tableTableHealth;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class BloodDataTable : TypedTableBase<Others.BloodRow>
        {
            private DataColumn columnTypes;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.BloodRowChangeEventHandler BloodRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.BloodRowChangeEventHandler BloodRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.BloodRowChangeEventHandler BloodRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.BloodRowChangeEventHandler BloodRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public BloodDataTable()
            {
                base.TableName = "Blood";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal BloodDataTable(DataTable table)
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
            protected BloodDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddBloodRow(Others.BloodRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Others.BloodRow AddBloodRow(string Types)
            {
                Others.BloodRow row = (Others.BloodRow)base.NewRow();
                row.ItemArray = new object[] { Types };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Others.BloodDataTable table = (Others.BloodDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Others.BloodDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Others.BloodRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Others others = new Others();
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
                    FixedValue = others.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "BloodDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = others.GetSchemaSerializable();
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
                this.columnTypes = new DataColumn("Types", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTypes);
                this.columnTypes.AllowDBNull = false;
                this.columnTypes.MaxLength = 2;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnTypes = base.Columns["Types"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Others.BloodRow NewBloodRow()
            {
                return (Others.BloodRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Others.BloodRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.BloodRowChanged != null)
                {
                    this.BloodRowChanged(this, new Others.BloodRowChangeEvent((Others.BloodRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.BloodRowChanging != null)
                {
                    this.BloodRowChanging(this, new Others.BloodRowChangeEvent((Others.BloodRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.BloodRowDeleted != null)
                {
                    this.BloodRowDeleted(this, new Others.BloodRowChangeEvent((Others.BloodRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.BloodRowDeleting != null)
                {
                    this.BloodRowDeleting(this, new Others.BloodRowChangeEvent((Others.BloodRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveBloodRow(Others.BloodRow row)
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
            public Others.BloodRow this[int index]
            {
                get
                {
                    return (Others.BloodRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn TypesColumn
            {
                get
                {
                    return this.columnTypes;
                }
            }
        }

        public class BloodRow : DataRow
        {
            private Others.BloodDataTable tableBlood;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal BloodRow(DataRowBuilder rb) : base(rb)
            {
                this.tableBlood = (Others.BloodDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Types
            {
                get
                {
                    return (string)base[this.tableBlood.TypesColumn];
                }
                set
                {
                    base[this.tableBlood.TypesColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class BloodRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Others.BloodRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public BloodRowChangeEvent(Others.BloodRow row, DataRowAction action)
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
            public Others.BloodRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void BloodRowChangeEventHandler(object sender, Others.BloodRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class ColumnSetDataTable : TypedTableBase<Others.ColumnSetRow>
        {
            private DataColumn columnColState;
            private DataColumn columnColType;
            private DataColumn columnColumnC;
            private DataColumn columnColumnID;
            private DataColumn columnColWidth;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnSetRowChangeEventHandler ColumnSetRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnSetRowChangeEventHandler ColumnSetRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnSetRowChangeEventHandler ColumnSetRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnSetRowChangeEventHandler ColumnSetRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public ColumnSetDataTable()
            {
                base.TableName = "ColumnSet";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal ColumnSetDataTable(DataTable table)
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
            protected ColumnSetDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddColumnSetRow(Others.ColumnSetRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.ColumnSetRow AddColumnSetRow(string ColumnID, string ColumnC, short ColWidth, string ColType, string ColState)
            {
                Others.ColumnSetRow row = (Others.ColumnSetRow)base.NewRow();
                row.ItemArray = new object[] { ColumnID, ColumnC, ColWidth, ColType, ColState };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Others.ColumnSetDataTable table = (Others.ColumnSetDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Others.ColumnSetDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Others.ColumnSetRow FindByColumnID(string ColumnID)
            {
                return (Others.ColumnSetRow)base.Rows.Find(new object[] { ColumnID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Others.ColumnSetRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Others others = new Others();
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
                    FixedValue = others.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "ColumnSetDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = others.GetSchemaSerializable();
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
                this.columnColumnID = new DataColumn("ColumnID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumnID);
                this.columnColumnC = new DataColumn("ColumnC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumnC);
                this.columnColWidth = new DataColumn("ColWidth", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnColWidth);
                this.columnColType = new DataColumn("ColType", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColType);
                this.columnColState = new DataColumn("ColState", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColState);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnColumnID }, true));
                this.columnColumnID.AllowDBNull = false;
                this.columnColumnID.Unique = true;
                this.columnColumnID.MaxLength = 15;
                this.columnColumnC.MaxLength = 50;
                this.columnColType.MaxLength = 1;
                this.columnColState.MaxLength = 50;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnColumnID = base.Columns["ColumnID"];
                this.columnColumnC = base.Columns["ColumnC"];
                this.columnColWidth = base.Columns["ColWidth"];
                this.columnColType = base.Columns["ColType"];
                this.columnColState = base.Columns["ColState"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.ColumnSetRow NewColumnSetRow()
            {
                return (Others.ColumnSetRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Others.ColumnSetRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ColumnSetRowChanged != null)
                {
                    this.ColumnSetRowChanged(this, new Others.ColumnSetRowChangeEvent((Others.ColumnSetRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ColumnSetRowChanging != null)
                {
                    this.ColumnSetRowChanging(this, new Others.ColumnSetRowChangeEvent((Others.ColumnSetRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ColumnSetRowDeleted != null)
                {
                    this.ColumnSetRowDeleted(this, new Others.ColumnSetRowChangeEvent((Others.ColumnSetRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ColumnSetRowDeleting != null)
                {
                    this.ColumnSetRowDeleting(this, new Others.ColumnSetRowChangeEvent((Others.ColumnSetRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveColumnSetRow(Others.ColumnSetRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ColStateColumn
            {
                get
                {
                    return this.columnColState;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ColTypeColumn
            {
                get
                {
                    return this.columnColType;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ColumnCColumn
            {
                get
                {
                    return this.columnColumnC;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ColumnIDColumn
            {
                get
                {
                    return this.columnColumnID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ColWidthColumn
            {
                get
                {
                    return this.columnColWidth;
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
            public Others.ColumnSetRow this[int index]
            {
                get
                {
                    return (Others.ColumnSetRow)base.Rows[index];
                }
            }
        }

        public class ColumnSetRow : DataRow
        {
            private Others.ColumnSetDataTable tableColumnSet;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal ColumnSetRow(DataRowBuilder rb) : base(rb)
            {
                this.tableColumnSet = (Others.ColumnSetDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsColStateNull()
            {
                return base.IsNull(this.tableColumnSet.ColStateColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsColTypeNull()
            {
                return base.IsNull(this.tableColumnSet.ColTypeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsColumnCNull()
            {
                return base.IsNull(this.tableColumnSet.ColumnCColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsColWidthNull()
            {
                return base.IsNull(this.tableColumnSet.ColWidthColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetColStateNull()
            {
                base[this.tableColumnSet.ColStateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetColTypeNull()
            {
                base[this.tableColumnSet.ColTypeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetColumnCNull()
            {
                base[this.tableColumnSet.ColumnCColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetColWidthNull()
            {
                base[this.tableColumnSet.ColWidthColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ColState
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableColumnSet.ColStateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ColState' in table 'ColumnSet' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableColumnSet.ColStateColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ColType
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableColumnSet.ColTypeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ColType' in table 'ColumnSet' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableColumnSet.ColTypeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ColumnC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableColumnSet.ColumnCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ColumnC' in table 'ColumnSet' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableColumnSet.ColumnCColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ColumnID
            {
                get
                {
                    return (string)base[this.tableColumnSet.ColumnIDColumn];
                }
                set
                {
                    base[this.tableColumnSet.ColumnIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short ColWidth
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableColumnSet.ColWidthColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ColWidth' in table 'ColumnSet' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableColumnSet.ColWidthColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class ColumnSetRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Others.ColumnSetRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public ColumnSetRowChangeEvent(Others.ColumnSetRow row, DataRowAction action)
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
            public Others.ColumnSetRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void ColumnSetRowChangeEventHandler(object sender, Others.ColumnSetRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class ColumnStDataTable : TypedTableBase<Others.ColumnStRow>
        {
            private DataColumn columnColExpress;
            private DataColumn columnColumnC;
            private DataColumn columnColumnID;
            private DataColumn columnWidth;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnStRowChangeEventHandler ColumnStRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnStRowChangeEventHandler ColumnStRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnStRowChangeEventHandler ColumnStRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.ColumnStRowChangeEventHandler ColumnStRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public ColumnStDataTable()
            {
                base.TableName = "ColumnSt";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal ColumnStDataTable(DataTable table)
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
            protected ColumnStDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddColumnStRow(Others.ColumnStRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.ColumnStRow AddColumnStRow(string ColumnID, string ColumnC, string ColExpress, short Width)
            {
                Others.ColumnStRow row = (Others.ColumnStRow)base.NewRow();
                row.ItemArray = new object[] { ColumnID, ColumnC, ColExpress, Width };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                Others.ColumnStDataTable table = (Others.ColumnStDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new Others.ColumnStDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.ColumnStRow FindByColumnID(string ColumnID)
            {
                return (Others.ColumnStRow)base.Rows.Find(new object[] { ColumnID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(Others.ColumnStRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Others others = new Others();
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
                    FixedValue = others.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "ColumnStDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = others.GetSchemaSerializable();
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
                this.columnColumnID = new DataColumn("ColumnID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumnID);
                this.columnColumnC = new DataColumn("ColumnC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumnC);
                this.columnColExpress = new DataColumn("ColExpress", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColExpress);
                this.columnWidth = new DataColumn("Width", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnWidth);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnColumnID }, true));
                this.columnColumnID.AllowDBNull = false;
                this.columnColumnID.Unique = true;
                this.columnColumnID.MaxLength = 20;
                this.columnColumnC.MaxLength = 50;
                this.columnColExpress.ReadOnly = true;
                this.columnColExpress.MaxLength = 0x41;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnColumnID = base.Columns["ColumnID"];
                this.columnColumnC = base.Columns["ColumnC"];
                this.columnColExpress = base.Columns["ColExpress"];
                this.columnWidth = base.Columns["Width"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.ColumnStRow NewColumnStRow()
            {
                return (Others.ColumnStRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Others.ColumnStRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ColumnStRowChanged != null)
                {
                    this.ColumnStRowChanged(this, new Others.ColumnStRowChangeEvent((Others.ColumnStRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ColumnStRowChanging != null)
                {
                    this.ColumnStRowChanging(this, new Others.ColumnStRowChangeEvent((Others.ColumnStRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ColumnStRowDeleted != null)
                {
                    this.ColumnStRowDeleted(this, new Others.ColumnStRowChangeEvent((Others.ColumnStRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ColumnStRowDeleting != null)
                {
                    this.ColumnStRowDeleting(this, new Others.ColumnStRowChangeEvent((Others.ColumnStRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveColumnStRow(Others.ColumnStRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ColExpressColumn
            {
                get
                {
                    return this.columnColExpress;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ColumnCColumn
            {
                get
                {
                    return this.columnColumnC;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ColumnIDColumn
            {
                get
                {
                    return this.columnColumnID;
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
            public Others.ColumnStRow this[int index]
            {
                get
                {
                    return (Others.ColumnStRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn WidthColumn
            {
                get
                {
                    return this.columnWidth;
                }
            }
        }

        public class ColumnStRow : DataRow
        {
            private Others.ColumnStDataTable tableColumnSt;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal ColumnStRow(DataRowBuilder rb) : base(rb)
            {
                this.tableColumnSt = (Others.ColumnStDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsColExpressNull()
            {
                return base.IsNull(this.tableColumnSt.ColExpressColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsColumnCNull()
            {
                return base.IsNull(this.tableColumnSt.ColumnCColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsWidthNull()
            {
                return base.IsNull(this.tableColumnSt.WidthColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetColExpressNull()
            {
                base[this.tableColumnSt.ColExpressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetColumnCNull()
            {
                base[this.tableColumnSt.ColumnCColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetWidthNull()
            {
                base[this.tableColumnSt.WidthColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ColExpress
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableColumnSt.ColExpressColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ColExpress' in table 'ColumnSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableColumnSt.ColExpressColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ColumnC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableColumnSt.ColumnCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ColumnC' in table 'ColumnSt' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableColumnSt.ColumnCColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ColumnID
            {
                get
                {
                    return (string)base[this.tableColumnSt.ColumnIDColumn];
                }
                set
                {
                    base[this.tableColumnSt.ColumnIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Width
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableColumnSt.WidthColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Width' in table 'ColumnSt' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableColumnSt.WidthColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class ColumnStRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Others.ColumnStRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public ColumnStRowChangeEvent(Others.ColumnStRow row, DataRowAction action)
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
            public Others.ColumnStRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void ColumnStRowChangeEventHandler(object sender, Others.ColumnStRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class InsuranceDataTable : TypedTableBase<Others.InsuranceRow>
        {
            private DataColumn columnClass;
            private DataColumn columncSex;
            private DataColumn columnGrade;
            private DataColumn columnGuy;
            private DataColumn columnInsuranceID;
            private DataColumn columnPID;
            private DataColumn columnSeat;
            private DataColumn columnState;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.InsuranceRowChangeEventHandler InsuranceRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.InsuranceRowChangeEventHandler InsuranceRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.InsuranceRowChangeEventHandler InsuranceRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.InsuranceRowChangeEventHandler InsuranceRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public InsuranceDataTable()
            {
                base.TableName = "Insurance";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal InsuranceDataTable(DataTable table)
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
            protected InsuranceDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddInsuranceRow(Others.InsuranceRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.InsuranceRow AddInsuranceRow(string PID, short InsuranceID, string State, string Grade, string Class, short Seat, string Guy, string cSex)
            {
                Others.InsuranceRow row = (Others.InsuranceRow)base.NewRow();
                row.ItemArray = new object[] { PID, InsuranceID, State, Grade, Class, Seat, Guy, cSex };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Others.InsuranceDataTable table = (Others.InsuranceDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Others.InsuranceDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Others.InsuranceRow FindByPIDInsuranceID(string PID, short InsuranceID)
            {
                return (Others.InsuranceRow)base.Rows.Find(new object[] { PID, InsuranceID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Others.InsuranceRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Others others = new Others();
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
                    FixedValue = others.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "InsuranceDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = others.GetSchemaSerializable();
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
                this.columnInsuranceID = new DataColumn("InsuranceID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnInsuranceID);
                this.columnState = new DataColumn("State", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnState);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnPID, this.columnInsuranceID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnInsuranceID.AllowDBNull = false;
                this.columnState.MaxLength = 50;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columnGuy.MaxLength = 100;
                this.columncSex.MaxLength = 2;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnInsuranceID = base.Columns["InsuranceID"];
                this.columnState = base.Columns["State"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columnSeat = base.Columns["Seat"];
                this.columnGuy = base.Columns["Guy"];
                this.columncSex = base.Columns["cSex"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.InsuranceRow NewInsuranceRow()
            {
                return (Others.InsuranceRow)base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Others.InsuranceRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.InsuranceRowChanged != null)
                {
                    this.InsuranceRowChanged(this, new Others.InsuranceRowChangeEvent((Others.InsuranceRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.InsuranceRowChanging != null)
                {
                    this.InsuranceRowChanging(this, new Others.InsuranceRowChangeEvent((Others.InsuranceRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.InsuranceRowDeleted != null)
                {
                    this.InsuranceRowDeleted(this, new Others.InsuranceRowChangeEvent((Others.InsuranceRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.InsuranceRowDeleting != null)
                {
                    this.InsuranceRowDeleting(this, new Others.InsuranceRowChangeEvent((Others.InsuranceRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveInsuranceRow(Others.InsuranceRow row)
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

            [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn InsuranceIDColumn
            {
                get
                {
                    return this.columnInsuranceID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.InsuranceRow this[int index]
            {
                get
                {
                    return (Others.InsuranceRow)base.Rows[index];
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn StateColumn
            {
                get
                {
                    return this.columnState;
                }
            }
        }

        public class InsuranceRow : DataRow
        {
            private Others.InsuranceDataTable tableInsurance;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal InsuranceRow(DataRowBuilder rb) : base(rb)
            {
                this.tableInsurance = (Others.InsuranceDataTable)base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableInsurance.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tableInsurance.cSexColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableInsurance.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tableInsurance.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableInsurance.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsStateNull()
            {
                return base.IsNull(this.tableInsurance.StateColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tableInsurance.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tableInsurance.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tableInsurance.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuyNull()
            {
                base[this.tableInsurance.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tableInsurance.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetStateNull()
            {
                base[this.tableInsurance.StateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableInsurance.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'Insurance' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableInsurance.ClassColumn] = value;
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
                        str = (string)base[this.tableInsurance.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'Insurance' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableInsurance.cSexColumn] = value;
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
                        str = (string)base[this.tableInsurance.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'Insurance' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableInsurance.GradeColumn] = value;
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
                        str = (string)base[this.tableInsurance.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'Insurance' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableInsurance.GuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short InsuranceID
            {
                get
                {
                    return (short)base[this.tableInsurance.InsuranceIDColumn];
                }
                set
                {
                    base[this.tableInsurance.InsuranceIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string)base[this.tableInsurance.PIDColumn];
                }
                set
                {
                    base[this.tableInsurance.PIDColumn] = value;
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
                        num = (short)base[this.tableInsurance.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'Insurance' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableInsurance.SeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string State
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableInsurance.StateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'State' in table 'Insurance' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableInsurance.StateColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class InsuranceRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Others.InsuranceRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public InsuranceRowChangeEvent(Others.InsuranceRow row, DataRowAction action)
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
            public Others.InsuranceRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void InsuranceRowChangeEventHandler(object sender, Others.InsuranceRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class TableHealthDataTable : TypedTableBase<Others.TableHealthRow>
        {
            private DataColumn columnSchoolDegree;
            private DataColumn columnTableName;
            private DataColumn columnTableNameC;
            private DataColumn columnTableType;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.TableHealthRowChangeEventHandler TableHealthRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.TableHealthRowChangeEventHandler TableHealthRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.TableHealthRowChangeEventHandler TableHealthRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Others.TableHealthRowChangeEventHandler TableHealthRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public TableHealthDataTable()
            {
                base.TableName = "TableHealth";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal TableHealthDataTable(DataTable table)
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
            protected TableHealthDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddTableHealthRow(Others.TableHealthRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.TableHealthRow AddTableHealthRow(string TableName, string TableNameC, short TableType, short SchoolDegree)
            {
                Others.TableHealthRow row = (Others.TableHealthRow)base.NewRow();
                row.ItemArray = new object[] { TableName, TableNameC, TableType, SchoolDegree };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                Others.TableHealthDataTable table = (Others.TableHealthDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new Others.TableHealthDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public Others.TableHealthRow FindByTableName(string TableName)
            {
                return (Others.TableHealthRow)base.Rows.Find(new object[] { TableName });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Others.TableHealthRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                Others others = new Others();
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
                    FixedValue = others.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "TableHealthDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = others.GetSchemaSerializable();
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
                this.columnTableName = new DataColumn("TableName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTableName);
                this.columnTableNameC = new DataColumn("TableNameC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTableNameC);
                this.columnTableType = new DataColumn("TableType", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnTableType);
                this.columnSchoolDegree = new DataColumn("SchoolDegree", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchoolDegree);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnTableName }, true));
                this.columnTableName.AllowDBNull = false;
                this.columnTableName.Unique = true;
                this.columnTableName.MaxLength = 20;
                this.columnTableNameC.MaxLength = 30;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnTableName = base.Columns["TableName"];
                this.columnTableNameC = base.Columns["TableNameC"];
                this.columnTableType = base.Columns["TableType"];
                this.columnSchoolDegree = base.Columns["SchoolDegree"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Others.TableHealthRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Others.TableHealthRow NewTableHealthRow()
            {
                return (Others.TableHealthRow)base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TableHealthRowChanged != null)
                {
                    this.TableHealthRowChanged(this, new Others.TableHealthRowChangeEvent((Others.TableHealthRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TableHealthRowChanging != null)
                {
                    this.TableHealthRowChanging(this, new Others.TableHealthRowChangeEvent((Others.TableHealthRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TableHealthRowDeleted != null)
                {
                    this.TableHealthRowDeleted(this, new Others.TableHealthRowChangeEvent((Others.TableHealthRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TableHealthRowDeleting != null)
                {
                    this.TableHealthRowDeleting(this, new Others.TableHealthRowChangeEvent((Others.TableHealthRow)e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveTableHealthRow(Others.TableHealthRow row)
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
            public Others.TableHealthRow this[int index]
            {
                get
                {
                    return (Others.TableHealthRow)base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SchoolDegreeColumn
            {
                get
                {
                    return this.columnSchoolDegree;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn TableNameCColumn
            {
                get
                {
                    return this.columnTableNameC;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TableNameColumn
            {
                get
                {
                    return this.columnTableName;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TableTypeColumn
            {
                get
                {
                    return this.columnTableType;
                }
            }
        }

        public class TableHealthRow : DataRow
        {
            private Others.TableHealthDataTable tableTableHealth;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal TableHealthRow(DataRowBuilder rb) : base(rb)
            {
                this.tableTableHealth = (Others.TableHealthDataTable)base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchoolDegreeNull()
            {
                return base.IsNull(this.tableTableHealth.SchoolDegreeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTableNameCNull()
            {
                return base.IsNull(this.tableTableHealth.TableNameCColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsTableTypeNull()
            {
                return base.IsNull(this.tableTableHealth.TableTypeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSchoolDegreeNull()
            {
                base[this.tableTableHealth.SchoolDegreeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTableNameCNull()
            {
                base[this.tableTableHealth.TableNameCColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTableTypeNull()
            {
                base[this.tableTableHealth.TableTypeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchoolDegree
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableTableHealth.SchoolDegreeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchoolDegree' in table 'TableHealth' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableTableHealth.SchoolDegreeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string TableName
            {
                get
                {
                    return (string)base[this.tableTableHealth.TableNameColumn];
                }
                set
                {
                    base[this.tableTableHealth.TableNameColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TableNameC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[this.tableTableHealth.TableNameCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'TableNameC' in table 'TableHealth' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableTableHealth.TableNameCColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short TableType
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short)base[this.tableTableHealth.TableTypeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'TableType' in table 'TableHealth' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableTableHealth.TableTypeColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class TableHealthRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private Others.TableHealthRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public TableHealthRowChangeEvent(Others.TableHealthRow row, DataRowAction action)
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
            public Others.TableHealthRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void TableHealthRowChangeEventHandler(object sender, Others.TableHealthRowChangeEvent e);
    }
}

