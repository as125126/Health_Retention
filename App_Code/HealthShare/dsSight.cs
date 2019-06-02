namespace HealthShare
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, DesignerCategory("code"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), HelpKeyword("vs.data.DataSet"), XmlRoot("dsSight")]
    public class dsSight : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        public string sInputeMethod1;
        public string sInputeMethod2;
        public static string sSightUnavailable = "-9 無法表達或在家自學 -8 戴隱形眼鏡 -7 角膜塑型 -6雷射治療";
        private S0StateDataTable tableS0State;
        private SightBelowSdDataTable tableSightBelowSd;
        private SightClassDataTable tableSightClass;
        private SightManageDataTable tableSightManage;
        private SightMatrixDataTable tableSightMatrix;
        private SightPieDataTable tableSightPie;
        private SightReturnRateDataTable tableSightReturnRate;
        private vS0CannotCheckDataTable tablevS0CannotCheck;
        private vSightDataTable tablevSight;
        private vSightDiagResultDataTable tablevSightDiagResult;
        private vSightNearDataTable tablevSightNear;
        private vSightNear50DataTable tablevSightNear50;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public dsSight()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.sInputeMethod1 = "視力請直接輸入整數, 例如0.8輸入8視力值＜0.1請輸入-1<br> 「散瞳治療」是指點長效型散瞳眼藥治療，「散瞳」是指檢驗屈光度數前的短效散瞳。 ";
            this.sInputeMethod2 = "無法測量: " + sSightUnavailable;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected dsSight(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.sInputeMethod1 = "視力請直接輸入整數, 例如0.8輸入8視力值＜0.1請輸入-1<br> 「散瞳治療」是指點長效型散瞳眼藥治療，「散瞳」是指檢驗屈光度數前的短效散瞳。 ";
            this.sInputeMethod2 = "無法測量: " + sSightUnavailable;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
            else
            {
                string s = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["SightMatrix"] != null)
                    {
                        base.Tables.Add(new SightMatrixDataTable(dataSet.Tables["SightMatrix"]));
                    }
                    if (dataSet.Tables["SightPie"] != null)
                    {
                        base.Tables.Add(new SightPieDataTable(dataSet.Tables["SightPie"]));
                    }
                    if (dataSet.Tables["vSight"] != null)
                    {
                        base.Tables.Add(new vSightDataTable(dataSet.Tables["vSight"]));
                    }
                    if (dataSet.Tables["SightBelowSd"] != null)
                    {
                        base.Tables.Add(new SightBelowSdDataTable(dataSet.Tables["SightBelowSd"]));
                    }
                    if (dataSet.Tables["SightManage"] != null)
                    {
                        base.Tables.Add(new SightManageDataTable(dataSet.Tables["SightManage"]));
                    }
                    if (dataSet.Tables["SightClass"] != null)
                    {
                        base.Tables.Add(new SightClassDataTable(dataSet.Tables["SightClass"]));
                    }
                    if (dataSet.Tables["vSightDiagResult"] != null)
                    {
                        base.Tables.Add(new vSightDiagResultDataTable(dataSet.Tables["vSightDiagResult"]));
                    }
                    if (dataSet.Tables["SightReturnRate"] != null)
                    {
                        base.Tables.Add(new SightReturnRateDataTable(dataSet.Tables["SightReturnRate"]));
                    }
                    if (dataSet.Tables["vSightNear50"] != null)
                    {
                        base.Tables.Add(new vSightNear50DataTable(dataSet.Tables["vSightNear50"]));
                    }
                    if (dataSet.Tables["vSightNear"] != null)
                    {
                        base.Tables.Add(new vSightNearDataTable(dataSet.Tables["vSightNear"]));
                    }
                    if (dataSet.Tables["vS0CannotCheck"] != null)
                    {
                        base.Tables.Add(new vS0CannotCheckDataTable(dataSet.Tables["vS0CannotCheck"]));
                    }
                    if (dataSet.Tables["S0State"] != null)
                    {
                        base.Tables.Add(new S0StateDataTable(dataSet.Tables["S0State"]));
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
            dsSight sight = (dsSight) base.Clone();
            sight.InitVars();
            sight.SchemaSerializationMode = this.SchemaSerializationMode;
            return sight;
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
            dsSight sight = new dsSight();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = sight.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                        current = (XmlSchema) enumerator.Current;
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
            base.DataSetName = "dsSight";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/dsSight.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableSightMatrix = new SightMatrixDataTable();
            base.Tables.Add(this.tableSightMatrix);
            this.tableSightPie = new SightPieDataTable();
            base.Tables.Add(this.tableSightPie);
            this.tablevSight = new vSightDataTable();
            base.Tables.Add(this.tablevSight);
            this.tableSightBelowSd = new SightBelowSdDataTable();
            base.Tables.Add(this.tableSightBelowSd);
            this.tableSightManage = new SightManageDataTable();
            base.Tables.Add(this.tableSightManage);
            this.tableSightClass = new SightClassDataTable();
            base.Tables.Add(this.tableSightClass);
            this.tablevSightDiagResult = new vSightDiagResultDataTable();
            base.Tables.Add(this.tablevSightDiagResult);
            this.tableSightReturnRate = new SightReturnRateDataTable();
            base.Tables.Add(this.tableSightReturnRate);
            this.tablevSightNear50 = new vSightNear50DataTable();
            base.Tables.Add(this.tablevSightNear50);
            this.tablevSightNear = new vSightNearDataTable();
            base.Tables.Add(this.tablevSightNear);
            this.tablevS0CannotCheck = new vS0CannotCheckDataTable();
            base.Tables.Add(this.tablevS0CannotCheck);
            this.tableS0State = new S0StateDataTable();
            base.Tables.Add(this.tableS0State);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars(bool initTable)
        {
            this.tableSightMatrix = (SightMatrixDataTable) base.Tables["SightMatrix"];
            if (initTable && (this.tableSightMatrix != null))
            {
                this.tableSightMatrix.InitVars();
            }
            this.tableSightPie = (SightPieDataTable) base.Tables["SightPie"];
            if (initTable && (this.tableSightPie != null))
            {
                this.tableSightPie.InitVars();
            }
            this.tablevSight = (vSightDataTable) base.Tables["vSight"];
            if (initTable && (this.tablevSight != null))
            {
                this.tablevSight.InitVars();
            }
            this.tableSightBelowSd = (SightBelowSdDataTable) base.Tables["SightBelowSd"];
            if (initTable && (this.tableSightBelowSd != null))
            {
                this.tableSightBelowSd.InitVars();
            }
            this.tableSightManage = (SightManageDataTable) base.Tables["SightManage"];
            if (initTable && (this.tableSightManage != null))
            {
                this.tableSightManage.InitVars();
            }
            this.tableSightClass = (SightClassDataTable) base.Tables["SightClass"];
            if (initTable && (this.tableSightClass != null))
            {
                this.tableSightClass.InitVars();
            }
            this.tablevSightDiagResult = (vSightDiagResultDataTable) base.Tables["vSightDiagResult"];
            if (initTable && (this.tablevSightDiagResult != null))
            {
                this.tablevSightDiagResult.InitVars();
            }
            this.tableSightReturnRate = (SightReturnRateDataTable) base.Tables["SightReturnRate"];
            if (initTable && (this.tableSightReturnRate != null))
            {
                this.tableSightReturnRate.InitVars();
            }
            this.tablevSightNear50 = (vSightNear50DataTable) base.Tables["vSightNear50"];
            if (initTable && (this.tablevSightNear50 != null))
            {
                this.tablevSightNear50.InitVars();
            }
            this.tablevSightNear = (vSightNearDataTable) base.Tables["vSightNear"];
            if (initTable && (this.tablevSightNear != null))
            {
                this.tablevSightNear.InitVars();
            }
            this.tablevS0CannotCheck = (vS0CannotCheckDataTable) base.Tables["vS0CannotCheck"];
            if (initTable && (this.tablevS0CannotCheck != null))
            {
                this.tablevS0CannotCheck.InitVars();
            }
            this.tableS0State = (S0StateDataTable) base.Tables["S0State"];
            if (initTable && (this.tableS0State != null))
            {
                this.tableS0State.InitVars();
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
                if (dataSet.Tables["SightMatrix"] != null)
                {
                    base.Tables.Add(new SightMatrixDataTable(dataSet.Tables["SightMatrix"]));
                }
                if (dataSet.Tables["SightPie"] != null)
                {
                    base.Tables.Add(new SightPieDataTable(dataSet.Tables["SightPie"]));
                }
                if (dataSet.Tables["vSight"] != null)
                {
                    base.Tables.Add(new vSightDataTable(dataSet.Tables["vSight"]));
                }
                if (dataSet.Tables["SightBelowSd"] != null)
                {
                    base.Tables.Add(new SightBelowSdDataTable(dataSet.Tables["SightBelowSd"]));
                }
                if (dataSet.Tables["SightManage"] != null)
                {
                    base.Tables.Add(new SightManageDataTable(dataSet.Tables["SightManage"]));
                }
                if (dataSet.Tables["SightClass"] != null)
                {
                    base.Tables.Add(new SightClassDataTable(dataSet.Tables["SightClass"]));
                }
                if (dataSet.Tables["vSightDiagResult"] != null)
                {
                    base.Tables.Add(new vSightDiagResultDataTable(dataSet.Tables["vSightDiagResult"]));
                }
                if (dataSet.Tables["SightReturnRate"] != null)
                {
                    base.Tables.Add(new SightReturnRateDataTable(dataSet.Tables["SightReturnRate"]));
                }
                if (dataSet.Tables["vSightNear50"] != null)
                {
                    base.Tables.Add(new vSightNear50DataTable(dataSet.Tables["vSightNear50"]));
                }
                if (dataSet.Tables["vSightNear"] != null)
                {
                    base.Tables.Add(new vSightNearDataTable(dataSet.Tables["vSightNear"]));
                }
                if (dataSet.Tables["vS0CannotCheck"] != null)
                {
                    base.Tables.Add(new vS0CannotCheckDataTable(dataSet.Tables["vS0CannotCheck"]));
                }
                if (dataSet.Tables["S0State"] != null)
                {
                    base.Tables.Add(new S0StateDataTable(dataSet.Tables["S0State"]));
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

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeS0State()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSightBelowSd()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeSightClass()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSightManage()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeSightMatrix()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSightPie()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeSightReturnRate()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializevS0CannotCheck()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializevSight()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializevSightDiagResult()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializevSightNear()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializevSightNear50()
        {
            return false;
        }

        public Dictionary<int, string> dicS0Unavailable
        {
            get
            {
                Dictionary<int, string> dictionary = new Dictionary<int, string>();
                dictionary.Add(-6, "雷射治療");
                dictionary.Add(-7, "角膜塑型");
                dictionary.Add(-8, "戴隱形眼鏡");
                dictionary.Add(-9, "無法測量");
                return dictionary;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public S0StateDataTable S0State
        {
            get
            {
                return this.tableS0State;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public SightBelowSdDataTable SightBelowSd
        {
            get
            {
                return this.tableSightBelowSd;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode]
        public SightClassDataTable SightClass
        {
            get
            {
                return this.tableSightClass;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, Browsable(false)]
        public SightManageDataTable SightManage
        {
            get
            {
                return this.tableSightManage;
            }
        }

        [Browsable(false), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public SightMatrixDataTable SightMatrix
        {
            get
            {
                return this.tableSightMatrix;
            }
        }

        [Browsable(false), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public SightPieDataTable SightPie
        {
            get
            {
                return this.tableSightPie;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public SightReturnRateDataTable SightReturnRate
        {
            get
            {
                return this.tableSightReturnRate;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public vS0CannotCheckDataTable vS0CannotCheck
        {
            get
            {
                return this.tablevS0CannotCheck;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public vSightDataTable vSight
        {
            get
            {
                return this.tablevSight;
            }
        }

        [DebuggerNonUserCode, Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public vSightDiagResultDataTable vSightDiagResult
        {
            get
            {
                return this.tablevSightDiagResult;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public vSightNearDataTable vSightNear
        {
            get
            {
                return this.tablevSightNear;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public vSightNear50DataTable vSightNear50
        {
            get
            {
                return this.tablevSightNear50;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class S0StateDataTable : TypedTableBase<dsSight.S0StateRow>
        {
            private DataColumn columnS0ID;
            private DataColumn columnState;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.S0StateRowChangeEventHandler S0StateRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.S0StateRowChangeEventHandler S0StateRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.S0StateRowChangeEventHandler S0StateRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.S0StateRowChangeEventHandler S0StateRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public S0StateDataTable()
            {
                base.TableName = "S0State";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal S0StateDataTable(DataTable table)
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
            protected S0StateDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddS0StateRow(dsSight.S0StateRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.S0StateRow AddS0StateRow(string S0ID, string State)
            {
                dsSight.S0StateRow row = (dsSight.S0StateRow) base.NewRow();
                row.ItemArray = new object[] { S0ID, State };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSight.S0StateDataTable table = (dsSight.S0StateDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.S0StateDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.S0StateRow FindByS0ID(string S0ID)
            {
                return (dsSight.S0StateRow) base.Rows.Find(new object[] { S0ID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.S0StateRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "S0StateDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnS0ID = new DataColumn("S0ID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnS0ID);
                this.columnState = new DataColumn("State", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnState);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnS0ID }, true));
                this.columnS0ID.AllowDBNull = false;
                this.columnS0ID.Unique = true;
                this.columnS0ID.MaxLength = 1;
                this.columnState.MaxLength = 12;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnS0ID = base.Columns["S0ID"];
                this.columnState = base.Columns["State"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.S0StateRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.S0StateRow NewS0StateRow()
            {
                return (dsSight.S0StateRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.S0StateRowChanged != null)
                {
                    this.S0StateRowChanged(this, new dsSight.S0StateRowChangeEvent((dsSight.S0StateRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.S0StateRowChanging != null)
                {
                    this.S0StateRowChanging(this, new dsSight.S0StateRowChangeEvent((dsSight.S0StateRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.S0StateRowDeleted != null)
                {
                    this.S0StateRowDeleted(this, new dsSight.S0StateRowChangeEvent((dsSight.S0StateRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.S0StateRowDeleting != null)
                {
                    this.S0StateRowDeleting(this, new dsSight.S0StateRowChangeEvent((dsSight.S0StateRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveS0StateRow(dsSight.S0StateRow row)
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
            public dsSight.S0StateRow this[int index]
            {
                get
                {
                    return (dsSight.S0StateRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn S0IDColumn
            {
                get
                {
                    return this.columnS0ID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn StateColumn
            {
                get
                {
                    return this.columnState;
                }
            }
        }

        public class S0StateRow : DataRow
        {
            private dsSight.S0StateDataTable tableS0State;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal S0StateRow(DataRowBuilder rb) : base(rb)
            {
                this.tableS0State = (dsSight.S0StateDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStateNull()
            {
                return base.IsNull(this.tableS0State.StateColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetStateNull()
            {
                base[this.tableS0State.StateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string S0ID
            {
                get
                {
                    return (string) base[this.tableS0State.S0IDColumn];
                }
                set
                {
                    base[this.tableS0State.S0IDColumn] = value;
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
                        str = (string) base[this.tableS0State.StateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'State' in table 'S0State' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableS0State.StateColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class S0StateRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.S0StateRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public S0StateRowChangeEvent(dsSight.S0StateRow row, DataRowAction action)
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
            public dsSight.S0StateRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void S0StateRowChangeEventHandler(object sender, dsSight.S0StateRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SightBelowSdDataTable : TypedTableBase<dsSight.SightBelowSdRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDiag;
            private DataColumn columnEFar;
            private DataColumn columnENear;
            private DataColumn columnESan;
            private DataColumn columnESight99;
            private DataColumn columnESight99State;
            private DataColumn columnEWeak;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnManage;
            private DataColumn columnManageID;
            private DataColumn columnPID;
            private DataColumn columnS0ID;
            private DataColumn columnS0SexID;
            private DataColumn columnSchYears;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnSexID;
            private DataColumn columnSID;
            private DataColumn columnSight0L;
            private DataColumn columnSight0R;
            private DataColumn columnSightDiag;
            private DataColumn columnSightL;
            private DataColumn columnSightMeasureResult;
            private DataColumn columnSightR;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightBelowSdRowChangeEventHandler SightBelowSdRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightBelowSdRowChangeEventHandler SightBelowSdRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightBelowSdRowChangeEventHandler SightBelowSdRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightBelowSdRowChangeEventHandler SightBelowSdRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightBelowSdDataTable()
            {
                base.TableName = "SightBelowSd";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightBelowSdDataTable(DataTable table)
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
            protected SightBelowSdDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSightBelowSdRow(dsSight.SightBelowSdRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightBelowSdRow AddSightBelowSdRow(string PID, string Guy, short SexID, short Years, short Sem, short SchYears, short GradeID, string Grade, short ClassID, string Class, short Sight0L, short Sight0R, short SightL, short SightR, string S0ID, string SID, bool ENear, bool EFar, bool ESan, bool EWeak, bool ESight99, string ESight99State, string ManageID, string Manage, string SightMeasureResult, short Seat, string cSex, string S0SexID, string Diag, string SightDiag)
            {
                dsSight.SightBelowSdRow row = (dsSight.SightBelowSdRow) base.NewRow();
                row.ItemArray = new object[] { 
                    PID, Guy, SexID, Years, Sem, SchYears, GradeID, Grade, ClassID, Class, Sight0L, Sight0R, SightL, SightR, S0ID, SID, 
                    ENear, EFar, ESan, EWeak, ESight99, ESight99State, ManageID, Manage, SightMeasureResult, Seat, cSex, S0SexID, Diag, SightDiag
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSight.SightBelowSdDataTable table = (dsSight.SightBelowSdDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.SightBelowSdDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.SightBelowSdRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SightBelowSdDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnSight0L = new DataColumn("Sight0L", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSight0L);
                this.columnSight0R = new DataColumn("Sight0R", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSight0R);
                this.columnSightL = new DataColumn("SightL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightL);
                this.columnSightR = new DataColumn("SightR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightR);
                this.columnS0ID = new DataColumn("S0ID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnS0ID);
                this.columnSID = new DataColumn("SID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSID);
                this.columnENear = new DataColumn("ENear", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnENear);
                this.columnEFar = new DataColumn("EFar", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEFar);
                this.columnESan = new DataColumn("ESan", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESan);
                this.columnEWeak = new DataColumn("EWeak", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEWeak);
                this.columnESight99 = new DataColumn("ESight99", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESight99);
                this.columnESight99State = new DataColumn("ESight99State", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnESight99State);
                this.columnManageID = new DataColumn("ManageID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManageID);
                this.columnManage = new DataColumn("Manage", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManage);
                this.columnSightMeasureResult = new DataColumn("SightMeasureResult", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSightMeasureResult);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnS0SexID = new DataColumn("S0SexID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnS0SexID);
                this.columnDiag = new DataColumn("Diag", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDiag);
                this.columnSightDiag = new DataColumn("SightDiag", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSightDiag);
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnSem.AllowDBNull = false;
                this.columnSchYears.ReadOnly = true;
                this.columnGradeID.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClassID.AllowDBNull = false;
                this.columnClass.MaxLength = 10;
                this.columnS0ID.ReadOnly = true;
                this.columnS0ID.MaxLength = 1;
                this.columnSID.ReadOnly = true;
                this.columnSID.MaxLength = 1;
                this.columnENear.AllowDBNull = false;
                this.columnEFar.AllowDBNull = false;
                this.columnESan.AllowDBNull = false;
                this.columnEWeak.AllowDBNull = false;
                this.columnESight99.AllowDBNull = false;
                this.columnESight99State.MaxLength = 0xff;
                this.columnManageID.MaxLength = 30;
                this.columnManage.MaxLength = 0xff;
                this.columnSightMeasureResult.ReadOnly = true;
                this.columnSightMeasureResult.MaxLength = 1;
                this.columncSex.MaxLength = 2;
                this.columnS0SexID.ReadOnly = true;
                this.columnS0SexID.MaxLength = 60;
                this.columnDiag.ReadOnly = true;
                this.columnDiag.MaxLength = 10;
                this.columnSightDiag.ReadOnly = true;
                this.columnSightDiag.MaxLength = 10;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnSem = base.Columns["Sem"];
                this.columnSchYears = base.Columns["SchYears"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass = base.Columns["Class"];
                this.columnSight0L = base.Columns["Sight0L"];
                this.columnSight0R = base.Columns["Sight0R"];
                this.columnSightL = base.Columns["SightL"];
                this.columnSightR = base.Columns["SightR"];
                this.columnS0ID = base.Columns["S0ID"];
                this.columnSID = base.Columns["SID"];
                this.columnENear = base.Columns["ENear"];
                this.columnEFar = base.Columns["EFar"];
                this.columnESan = base.Columns["ESan"];
                this.columnEWeak = base.Columns["EWeak"];
                this.columnESight99 = base.Columns["ESight99"];
                this.columnESight99State = base.Columns["ESight99State"];
                this.columnManageID = base.Columns["ManageID"];
                this.columnManage = base.Columns["Manage"];
                this.columnSightMeasureResult = base.Columns["SightMeasureResult"];
                this.columnSeat = base.Columns["Seat"];
                this.columncSex = base.Columns["cSex"];
                this.columnS0SexID = base.Columns["S0SexID"];
                this.columnDiag = base.Columns["Diag"];
                this.columnSightDiag = base.Columns["SightDiag"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.SightBelowSdRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightBelowSdRow NewSightBelowSdRow()
            {
                return (dsSight.SightBelowSdRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SightBelowSdRowChanged != null)
                {
                    this.SightBelowSdRowChanged(this, new dsSight.SightBelowSdRowChangeEvent((dsSight.SightBelowSdRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SightBelowSdRowChanging != null)
                {
                    this.SightBelowSdRowChanging(this, new dsSight.SightBelowSdRowChangeEvent((dsSight.SightBelowSdRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SightBelowSdRowDeleted != null)
                {
                    this.SightBelowSdRowDeleted(this, new dsSight.SightBelowSdRowChangeEvent((dsSight.SightBelowSdRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SightBelowSdRowDeleting != null)
                {
                    this.SightBelowSdRowDeleting(this, new dsSight.SightBelowSdRowChangeEvent((dsSight.SightBelowSdRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSightBelowSdRow(dsSight.SightBelowSdRow row)
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DiagColumn
            {
                get
                {
                    return this.columnDiag;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn EFarColumn
            {
                get
                {
                    return this.columnEFar;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ENearColumn
            {
                get
                {
                    return this.columnENear;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESanColumn
            {
                get
                {
                    return this.columnESan;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ESight99Column
            {
                get
                {
                    return this.columnESight99;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESight99StateColumn
            {
                get
                {
                    return this.columnESight99State;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EWeakColumn
            {
                get
                {
                    return this.columnEWeak;
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
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightBelowSdRow this[int index]
            {
                get
                {
                    return (dsSight.SightBelowSdRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ManageColumn
            {
                get
                {
                    return this.columnManage;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ManageIDColumn
            {
                get
                {
                    return this.columnManageID;
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
            public DataColumn S0IDColumn
            {
                get
                {
                    return this.columnS0ID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn S0SexIDColumn
            {
                get
                {
                    return this.columnS0SexID;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SIDColumn
            {
                get
                {
                    return this.columnSID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sight0LColumn
            {
                get
                {
                    return this.columnSight0L;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Sight0RColumn
            {
                get
                {
                    return this.columnSight0R;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightDiagColumn
            {
                get
                {
                    return this.columnSightDiag;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightLColumn
            {
                get
                {
                    return this.columnSightL;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightMeasureResultColumn
            {
                get
                {
                    return this.columnSightMeasureResult;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightRColumn
            {
                get
                {
                    return this.columnSightR;
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

        public class SightBelowSdRow : DataRow
        {
            private dsSight.SightBelowSdDataTable tableSightBelowSd;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SightBelowSdRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSightBelowSd = (dsSight.SightBelowSdDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableSightBelowSd.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tableSightBelowSd.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDiagNull()
            {
                return base.IsNull(this.tableSightBelowSd.DiagColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsESight99StateNull()
            {
                return base.IsNull(this.tableSightBelowSd.ESight99StateColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableSightBelowSd.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tableSightBelowSd.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsManageIDNull()
            {
                return base.IsNull(this.tableSightBelowSd.ManageIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsManageNull()
            {
                return base.IsNull(this.tableSightBelowSd.ManageColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsS0IDNull()
            {
                return base.IsNull(this.tableSightBelowSd.S0IDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsS0SexIDNull()
            {
                return base.IsNull(this.tableSightBelowSd.S0SexIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tableSightBelowSd.SchYearsColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tableSightBelowSd.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSIDNull()
            {
                return base.IsNull(this.tableSightBelowSd.SIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSight0LNull()
            {
                return base.IsNull(this.tableSightBelowSd.Sight0LColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSight0RNull()
            {
                return base.IsNull(this.tableSightBelowSd.Sight0RColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightDiagNull()
            {
                return base.IsNull(this.tableSightBelowSd.SightDiagColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightLNull()
            {
                return base.IsNull(this.tableSightBelowSd.SightLColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSightMeasureResultNull()
            {
                return base.IsNull(this.tableSightBelowSd.SightMeasureResultColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightRNull()
            {
                return base.IsNull(this.tableSightBelowSd.SightRColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tableSightBelowSd.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tableSightBelowSd.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDiagNull()
            {
                base[this.tableSightBelowSd.DiagColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetESight99StateNull()
            {
                base[this.tableSightBelowSd.ESight99StateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tableSightBelowSd.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuyNull()
            {
                base[this.tableSightBelowSd.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetManageIDNull()
            {
                base[this.tableSightBelowSd.ManageIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetManageNull()
            {
                base[this.tableSightBelowSd.ManageColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetS0IDNull()
            {
                base[this.tableSightBelowSd.S0IDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetS0SexIDNull()
            {
                base[this.tableSightBelowSd.S0SexIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchYearsNull()
            {
                base[this.tableSightBelowSd.SchYearsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tableSightBelowSd.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSIDNull()
            {
                base[this.tableSightBelowSd.SIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSight0LNull()
            {
                base[this.tableSightBelowSd.Sight0LColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSight0RNull()
            {
                base[this.tableSightBelowSd.Sight0RColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightDiagNull()
            {
                base[this.tableSightBelowSd.SightDiagColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightLNull()
            {
                base[this.tableSightBelowSd.SightLColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSightMeasureResultNull()
            {
                base[this.tableSightBelowSd.SightMeasureResultColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSightRNull()
            {
                base[this.tableSightBelowSd.SightRColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.ClassColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tableSightBelowSd.ClassIDColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.ClassIDColumn] = value;
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
                        str = (string) base[this.tableSightBelowSd.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.cSexColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Diag
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.DiagColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Diag' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.DiagColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool EFar
            {
                get
                {
                    return (bool) base[this.tableSightBelowSd.EFarColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.EFarColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool ENear
            {
                get
                {
                    return (bool) base[this.tableSightBelowSd.ENearColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.ENearColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ESan
            {
                get
                {
                    return (bool) base[this.tableSightBelowSd.ESanColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.ESanColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool ESight99
            {
                get
                {
                    return (bool) base[this.tableSightBelowSd.ESight99Column];
                }
                set
                {
                    base[this.tableSightBelowSd.ESight99Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ESight99State
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.ESight99StateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ESight99State' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.ESight99StateColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool EWeak
            {
                get
                {
                    return (bool) base[this.tableSightBelowSd.EWeakColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.EWeakColumn] = value;
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
                        str = (string) base[this.tableSightBelowSd.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tableSightBelowSd.GradeIDColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.GradeIDColumn] = value;
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
                        str = (string) base[this.tableSightBelowSd.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.GuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Manage
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.ManageColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Manage' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.ManageColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ManageID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.ManageIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ManageID' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.ManageIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string) base[this.tableSightBelowSd.PIDColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.PIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string S0ID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.S0IDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'S0ID' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.S0IDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string S0SexID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.S0SexIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'S0SexID' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.S0SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchYears
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tableSightBelowSd.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightBelowSd.SchYearsColumn] = value;
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
                        num = (short) base[this.tableSightBelowSd.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightBelowSd.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sem
            {
                get
                {
                    return (short) base[this.tableSightBelowSd.SemColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short) base[this.tableSightBelowSd.SexIDColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.SexIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.SIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SID' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.SIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sight0L
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tableSightBelowSd.Sight0LColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sight0L' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightBelowSd.Sight0LColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sight0R
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tableSightBelowSd.Sight0RColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sight0R' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightBelowSd.Sight0RColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SightDiag
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.SightDiagColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightDiag' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.SightDiagColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SightL
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tableSightBelowSd.SightLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightL' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightBelowSd.SightLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SightMeasureResult
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightBelowSd.SightMeasureResultColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightMeasureResult' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightBelowSd.SightMeasureResultColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SightR
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tableSightBelowSd.SightRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightR' in table 'SightBelowSd' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightBelowSd.SightRColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short) base[this.tableSightBelowSd.YearsColumn];
                }
                set
                {
                    base[this.tableSightBelowSd.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SightBelowSdRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.SightBelowSdRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightBelowSdRowChangeEvent(dsSight.SightBelowSdRow row, DataRowAction action)
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
            public dsSight.SightBelowSdRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SightBelowSdRowChangeEventHandler(object sender, dsSight.SightBelowSdRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SightClassDataTable : TypedTableBase<dsSight.SightClassRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightClassRowChangeEventHandler SightClassRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightClassRowChangeEventHandler SightClassRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightClassRowChangeEventHandler SightClassRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightClassRowChangeEventHandler SightClassRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightClassDataTable()
            {
                base.TableName = "SightClass";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightClassDataTable(DataTable table)
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
            protected SightClassDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddSightClassRow(dsSight.SightClassRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightClassRow AddSightClassRow(short GradeID, string Grade, short ClassID, string Class)
            {
                dsSight.SightClassRow row = (dsSight.SightClassRow) base.NewRow();
                row.ItemArray = new object[] { GradeID, Grade, ClassID, Class };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSight.SightClassDataTable table = (dsSight.SightClassDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.SightClassDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightClassRow FindByClassIDGradeID(short ClassID, short GradeID)
            {
                return (dsSight.SightClassRow) base.Rows.Find(new object[] { ClassID, GradeID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSight.SightClassRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SightClassDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnClassID, this.columnGradeID }, true));
                this.columnGradeID.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClassID.AllowDBNull = false;
                this.columnClass.MaxLength = 10;
                base.Locale = new CultureInfo("zh-HK");
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass = base.Columns["Class"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.SightClassRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightClassRow NewSightClassRow()
            {
                return (dsSight.SightClassRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SightClassRowChanged != null)
                {
                    this.SightClassRowChanged(this, new dsSight.SightClassRowChangeEvent((dsSight.SightClassRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SightClassRowChanging != null)
                {
                    this.SightClassRowChanging(this, new dsSight.SightClassRowChangeEvent((dsSight.SightClassRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SightClassRowDeleted != null)
                {
                    this.SightClassRowDeleted(this, new dsSight.SightClassRowChangeEvent((dsSight.SightClassRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SightClassRowDeleting != null)
                {
                    this.SightClassRowDeleting(this, new dsSight.SightClassRowChangeEvent((dsSight.SightClassRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveSightClassRow(dsSight.SightClassRow row)
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
            }

            [DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightClassRow this[int index]
            {
                get
                {
                    return (dsSight.SightClassRow) base.Rows[index];
                }
            }
        }

        public class SightClassRow : DataRow
        {
            private dsSight.SightClassDataTable tableSightClass;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightClassRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSightClass = (dsSight.SightClassDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableSightClass.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableSightClass.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tableSightClass.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tableSightClass.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightClass.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'SightClass' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightClass.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tableSightClass.ClassIDColumn];
                }
                set
                {
                    base[this.tableSightClass.ClassIDColumn] = value;
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
                        str = (string) base[this.tableSightClass.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'SightClass' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightClass.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tableSightClass.GradeIDColumn];
                }
                set
                {
                    base[this.tableSightClass.GradeIDColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SightClassRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.SightClassRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightClassRowChangeEvent(dsSight.SightClassRow row, DataRowAction action)
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
            public dsSight.SightClassRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SightClassRowChangeEventHandler(object sender, dsSight.SightClassRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SightManageDataTable : TypedTableBase<dsSight.SightManageRow>
        {
            private DataColumn columnManage;
            private DataColumn columnManageID;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightManageRowChangeEventHandler SightManageRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightManageRowChangeEventHandler SightManageRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightManageRowChangeEventHandler SightManageRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightManageRowChangeEventHandler SightManageRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightManageDataTable()
            {
                base.TableName = "SightManage";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SightManageDataTable(DataTable table)
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
            protected SightManageDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSightManageRow(dsSight.SightManageRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightManageRow AddSightManageRow(string ManageID, string Manage)
            {
                dsSight.SightManageRow row = (dsSight.SightManageRow) base.NewRow();
                row.ItemArray = new object[] { ManageID, Manage };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSight.SightManageDataTable table = (dsSight.SightManageDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSight.SightManageDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightManageRow FindByManageID(string ManageID)
            {
                return (dsSight.SightManageRow) base.Rows.Find(new object[] { ManageID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.SightManageRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SightManageDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnManageID = new DataColumn("ManageID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManageID);
                this.columnManage = new DataColumn("Manage", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManage);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnManageID }, true));
                this.columnManageID.AllowDBNull = false;
                this.columnManageID.Unique = true;
                this.columnManageID.MaxLength = 30;
                this.columnManage.MaxLength = 12;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnManageID = base.Columns["ManageID"];
                this.columnManage = base.Columns["Manage"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.SightManageRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightManageRow NewSightManageRow()
            {
                return (dsSight.SightManageRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SightManageRowChanged != null)
                {
                    this.SightManageRowChanged(this, new dsSight.SightManageRowChangeEvent((dsSight.SightManageRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SightManageRowChanging != null)
                {
                    this.SightManageRowChanging(this, new dsSight.SightManageRowChangeEvent((dsSight.SightManageRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SightManageRowDeleted != null)
                {
                    this.SightManageRowDeleted(this, new dsSight.SightManageRowChangeEvent((dsSight.SightManageRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SightManageRowDeleting != null)
                {
                    this.SightManageRowDeleting(this, new dsSight.SightManageRowChangeEvent((dsSight.SightManageRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSightManageRow(dsSight.SightManageRow row)
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
            public dsSight.SightManageRow this[int index]
            {
                get
                {
                    return (dsSight.SightManageRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ManageColumn
            {
                get
                {
                    return this.columnManage;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ManageIDColumn
            {
                get
                {
                    return this.columnManageID;
                }
            }
        }

        public class SightManageRow : DataRow
        {
            private dsSight.SightManageDataTable tableSightManage;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightManageRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSightManage = (dsSight.SightManageDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsManageNull()
            {
                return base.IsNull(this.tableSightManage.ManageColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetManageNull()
            {
                base[this.tableSightManage.ManageColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Manage
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableSightManage.ManageColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Manage' in table 'SightManage' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightManage.ManageColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ManageID
            {
                get
                {
                    return (string) base[this.tableSightManage.ManageIDColumn];
                }
                set
                {
                    base[this.tableSightManage.ManageIDColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SightManageRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.SightManageRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SightManageRowChangeEvent(dsSight.SightManageRow row, DataRowAction action)
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
            public dsSight.SightManageRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SightManageRowChangeEventHandler(object sender, dsSight.SightManageRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SightMatrixDataTable : TypedTableBase<dsSight.SightMatrixRow>
        {
            private DataColumn columnAllSum0;
            private DataColumn columnAllSum01;
            private DataColumn columnAllSum1;
            private DataColumn columnFemale10;
            private DataColumn columnFemale11;
            private DataColumn columnFemale20;
            private DataColumn columnFemale21;
            private DataColumn columnFemale30;
            private DataColumn columnFemale31;
            private DataColumn columnFemale40;
            private DataColumn columnFemaleSum0;
            private DataColumn columnFemaleSum01;
            private DataColumn columnFemaleSum1;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnMale10;
            private DataColumn columnMale11;
            private DataColumn columnMale20;
            private DataColumn columnMale21;
            private DataColumn columnMale30;
            private DataColumn columnMale31;
            private DataColumn columnMale40;
            private DataColumn columnMaleSum0;
            private DataColumn columnMaleSum01;
            private DataColumn columnMaleSum1;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightMatrixRowChangeEventHandler SightMatrixRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightMatrixRowChangeEventHandler SightMatrixRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightMatrixRowChangeEventHandler SightMatrixRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightMatrixRowChangeEventHandler SightMatrixRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightMatrixDataTable()
            {
                base.TableName = "SightMatrix";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightMatrixDataTable(DataTable table)
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
            protected SightMatrixDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSightMatrixRow(dsSight.SightMatrixRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightMatrixRow AddSightMatrixRow(int GradeID, int AllSum0, int MaleSum0, int FemaleSum0, int Male10, int Female10, int Male20, int Female20, int Male30, int Female30, int Male40, int Female40, int AllSum01, int MaleSum01, int FemaleSum01, int AllSum1, int MaleSum1, int FemaleSum1, int Male11, int Female11, int Male21, int Female21, int Male31, int Female31, string Grade)
            {
                dsSight.SightMatrixRow row = (dsSight.SightMatrixRow) base.NewRow();
                row.ItemArray = new object[] { 
                    GradeID, AllSum0, MaleSum0, FemaleSum0, Male10, Female10, Male20, Female20, Male30, Female30, Male40, Female40, AllSum01, MaleSum01, FemaleSum01, AllSum1, 
                    MaleSum1, FemaleSum1, Male11, Female11, Male21, Female21, Male31, Female31, Grade
                 };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSight.SightMatrixDataTable table = (dsSight.SightMatrixDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSight.SightMatrixDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.SightMatrixRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SightMatrixDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnGradeID = new DataColumn("GradeID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnAllSum0 = new DataColumn("AllSum0", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnAllSum0);
                this.columnMaleSum0 = new DataColumn("MaleSum0", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMaleSum0);
                this.columnFemaleSum0 = new DataColumn("FemaleSum0", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemaleSum0);
                this.columnMale10 = new DataColumn("Male10", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale10);
                this.columnFemale10 = new DataColumn("Female10", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale10);
                this.columnMale20 = new DataColumn("Male20", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale20);
                this.columnFemale20 = new DataColumn("Female20", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale20);
                this.columnMale30 = new DataColumn("Male30", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale30);
                this.columnFemale30 = new DataColumn("Female30", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale30);
                this.columnMale40 = new DataColumn("Male40", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale40);
                this.columnFemale40 = new DataColumn("Female40", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale40);
                this.columnAllSum01 = new DataColumn("AllSum01", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnAllSum01);
                this.columnMaleSum01 = new DataColumn("MaleSum01", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMaleSum01);
                this.columnFemaleSum01 = new DataColumn("FemaleSum01", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemaleSum01);
                this.columnAllSum1 = new DataColumn("AllSum1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnAllSum1);
                this.columnMaleSum1 = new DataColumn("MaleSum1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMaleSum1);
                this.columnFemaleSum1 = new DataColumn("FemaleSum1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemaleSum1);
                this.columnMale11 = new DataColumn("Male11", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale11);
                this.columnFemale11 = new DataColumn("Female11", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale11);
                this.columnMale21 = new DataColumn("Male21", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale21);
                this.columnFemale21 = new DataColumn("Female21", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale21);
                this.columnMale31 = new DataColumn("Male31", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMale31);
                this.columnFemale31 = new DataColumn("Female31", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnFemale31);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnGradeID.ReadOnly = true;
                this.columnAllSum0.ReadOnly = true;
                this.columnMaleSum0.ReadOnly = true;
                this.columnFemaleSum0.ReadOnly = true;
                this.columnMale10.ReadOnly = true;
                this.columnFemale10.ReadOnly = true;
                this.columnMale20.ReadOnly = true;
                this.columnFemale20.ReadOnly = true;
                this.columnMale30.ReadOnly = true;
                this.columnFemale30.ReadOnly = true;
                this.columnMale40.ReadOnly = true;
                this.columnFemale40.ReadOnly = true;
                this.columnAllSum01.ReadOnly = true;
                this.columnMaleSum01.ReadOnly = true;
                this.columnFemaleSum01.ReadOnly = true;
                this.columnAllSum1.ReadOnly = true;
                this.columnMaleSum1.ReadOnly = true;
                this.columnFemaleSum1.ReadOnly = true;
                this.columnMale11.ReadOnly = true;
                this.columnFemale11.ReadOnly = true;
                this.columnMale21.ReadOnly = true;
                this.columnFemale21.ReadOnly = true;
                this.columnMale31.ReadOnly = true;
                this.columnFemale31.ReadOnly = true;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnGradeID = base.Columns["GradeID"];
                this.columnAllSum0 = base.Columns["AllSum0"];
                this.columnMaleSum0 = base.Columns["MaleSum0"];
                this.columnFemaleSum0 = base.Columns["FemaleSum0"];
                this.columnMale10 = base.Columns["Male10"];
                this.columnFemale10 = base.Columns["Female10"];
                this.columnMale20 = base.Columns["Male20"];
                this.columnFemale20 = base.Columns["Female20"];
                this.columnMale30 = base.Columns["Male30"];
                this.columnFemale30 = base.Columns["Female30"];
                this.columnMale40 = base.Columns["Male40"];
                this.columnFemale40 = base.Columns["Female40"];
                this.columnAllSum01 = base.Columns["AllSum01"];
                this.columnMaleSum01 = base.Columns["MaleSum01"];
                this.columnFemaleSum01 = base.Columns["FemaleSum01"];
                this.columnAllSum1 = base.Columns["AllSum1"];
                this.columnMaleSum1 = base.Columns["MaleSum1"];
                this.columnFemaleSum1 = base.Columns["FemaleSum1"];
                this.columnMale11 = base.Columns["Male11"];
                this.columnFemale11 = base.Columns["Female11"];
                this.columnMale21 = base.Columns["Male21"];
                this.columnFemale21 = base.Columns["Female21"];
                this.columnMale31 = base.Columns["Male31"];
                this.columnFemale31 = base.Columns["Female31"];
                this.columnGrade = base.Columns["Grade"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.SightMatrixRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightMatrixRow NewSightMatrixRow()
            {
                return (dsSight.SightMatrixRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SightMatrixRowChanged != null)
                {
                    this.SightMatrixRowChanged(this, new dsSight.SightMatrixRowChangeEvent((dsSight.SightMatrixRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SightMatrixRowChanging != null)
                {
                    this.SightMatrixRowChanging(this, new dsSight.SightMatrixRowChangeEvent((dsSight.SightMatrixRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SightMatrixRowDeleted != null)
                {
                    this.SightMatrixRowDeleted(this, new dsSight.SightMatrixRowChangeEvent((dsSight.SightMatrixRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SightMatrixRowDeleting != null)
                {
                    this.SightMatrixRowDeleting(this, new dsSight.SightMatrixRowChangeEvent((dsSight.SightMatrixRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSightMatrixRow(dsSight.SightMatrixRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AllSum01Column
            {
                get
                {
                    return this.columnAllSum01;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn AllSum0Column
            {
                get
                {
                    return this.columnAllSum0;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AllSum1Column
            {
                get
                {
                    return this.columnAllSum1;
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
            public DataColumn Female10Column
            {
                get
                {
                    return this.columnFemale10;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Female11Column
            {
                get
                {
                    return this.columnFemale11;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Female20Column
            {
                get
                {
                    return this.columnFemale20;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Female21Column
            {
                get
                {
                    return this.columnFemale21;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Female30Column
            {
                get
                {
                    return this.columnFemale30;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Female31Column
            {
                get
                {
                    return this.columnFemale31;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Female40Column
            {
                get
                {
                    return this.columnFemale40;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn FemaleSum01Column
            {
                get
                {
                    return this.columnFemaleSum01;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn FemaleSum0Column
            {
                get
                {
                    return this.columnFemaleSum0;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn FemaleSum1Column
            {
                get
                {
                    return this.columnFemaleSum1;
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
            public dsSight.SightMatrixRow this[int index]
            {
                get
                {
                    return (dsSight.SightMatrixRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Male10Column
            {
                get
                {
                    return this.columnMale10;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Male11Column
            {
                get
                {
                    return this.columnMale11;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Male20Column
            {
                get
                {
                    return this.columnMale20;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Male21Column
            {
                get
                {
                    return this.columnMale21;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Male30Column
            {
                get
                {
                    return this.columnMale30;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Male31Column
            {
                get
                {
                    return this.columnMale31;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Male40Column
            {
                get
                {
                    return this.columnMale40;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn MaleSum01Column
            {
                get
                {
                    return this.columnMaleSum01;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn MaleSum0Column
            {
                get
                {
                    return this.columnMaleSum0;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn MaleSum1Column
            {
                get
                {
                    return this.columnMaleSum1;
                }
            }
        }

        public class SightMatrixRow : DataRow
        {
            private dsSight.SightMatrixDataTable tableSightMatrix;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightMatrixRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSightMatrix = (dsSight.SightMatrixDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAllSum01Null()
            {
                return base.IsNull(this.tableSightMatrix.AllSum01Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAllSum0Null()
            {
                return base.IsNull(this.tableSightMatrix.AllSum0Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAllSum1Null()
            {
                return base.IsNull(this.tableSightMatrix.AllSum1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemale10Null()
            {
                return base.IsNull(this.tableSightMatrix.Female10Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFemale11Null()
            {
                return base.IsNull(this.tableSightMatrix.Female11Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemale20Null()
            {
                return base.IsNull(this.tableSightMatrix.Female20Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemale21Null()
            {
                return base.IsNull(this.tableSightMatrix.Female21Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemale30Null()
            {
                return base.IsNull(this.tableSightMatrix.Female30Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemale31Null()
            {
                return base.IsNull(this.tableSightMatrix.Female31Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemale40Null()
            {
                return base.IsNull(this.tableSightMatrix.Female40Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsFemaleSum01Null()
            {
                return base.IsNull(this.tableSightMatrix.FemaleSum01Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFemaleSum0Null()
            {
                return base.IsNull(this.tableSightMatrix.FemaleSum0Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFemaleSum1Null()
            {
                return base.IsNull(this.tableSightMatrix.FemaleSum1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeIDNull()
            {
                return base.IsNull(this.tableSightMatrix.GradeIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableSightMatrix.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsMale10Null()
            {
                return base.IsNull(this.tableSightMatrix.Male10Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMale11Null()
            {
                return base.IsNull(this.tableSightMatrix.Male11Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMale20Null()
            {
                return base.IsNull(this.tableSightMatrix.Male20Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMale21Null()
            {
                return base.IsNull(this.tableSightMatrix.Male21Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMale30Null()
            {
                return base.IsNull(this.tableSightMatrix.Male30Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsMale31Null()
            {
                return base.IsNull(this.tableSightMatrix.Male31Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMale40Null()
            {
                return base.IsNull(this.tableSightMatrix.Male40Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMaleSum01Null()
            {
                return base.IsNull(this.tableSightMatrix.MaleSum01Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMaleSum0Null()
            {
                return base.IsNull(this.tableSightMatrix.MaleSum0Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsMaleSum1Null()
            {
                return base.IsNull(this.tableSightMatrix.MaleSum1Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAllSum01Null()
            {
                base[this.tableSightMatrix.AllSum01Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetAllSum0Null()
            {
                base[this.tableSightMatrix.AllSum0Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAllSum1Null()
            {
                base[this.tableSightMatrix.AllSum1Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetFemale10Null()
            {
                base[this.tableSightMatrix.Female10Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetFemale11Null()
            {
                base[this.tableSightMatrix.Female11Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetFemale20Null()
            {
                base[this.tableSightMatrix.Female20Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetFemale21Null()
            {
                base[this.tableSightMatrix.Female21Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFemale30Null()
            {
                base[this.tableSightMatrix.Female30Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetFemale31Null()
            {
                base[this.tableSightMatrix.Female31Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFemale40Null()
            {
                base[this.tableSightMatrix.Female40Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFemaleSum01Null()
            {
                base[this.tableSightMatrix.FemaleSum01Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFemaleSum0Null()
            {
                base[this.tableSightMatrix.FemaleSum0Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetFemaleSum1Null()
            {
                base[this.tableSightMatrix.FemaleSum1Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeIDNull()
            {
                base[this.tableSightMatrix.GradeIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tableSightMatrix.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMale10Null()
            {
                base[this.tableSightMatrix.Male10Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMale11Null()
            {
                base[this.tableSightMatrix.Male11Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMale20Null()
            {
                base[this.tableSightMatrix.Male20Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMale21Null()
            {
                base[this.tableSightMatrix.Male21Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMale30Null()
            {
                base[this.tableSightMatrix.Male30Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMale31Null()
            {
                base[this.tableSightMatrix.Male31Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMale40Null()
            {
                base[this.tableSightMatrix.Male40Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMaleSum01Null()
            {
                base[this.tableSightMatrix.MaleSum01Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetMaleSum0Null()
            {
                base[this.tableSightMatrix.MaleSum0Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMaleSum1Null()
            {
                base[this.tableSightMatrix.MaleSum1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int AllSum0
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.AllSum0Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'AllSum0' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.AllSum0Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int AllSum01
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.AllSum01Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'AllSum01' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.AllSum01Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int AllSum1
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.AllSum1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'AllSum1' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.AllSum1Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Female10
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female10Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female10' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female10Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Female11
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female11Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female11' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female11Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Female20
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female20Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female20' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female20Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Female21
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female21Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female21' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female21Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Female30
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female30Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female30' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female30Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Female31
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female31Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female31' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female31Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Female40
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Female40Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Female40' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Female40Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int FemaleSum0
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.FemaleSum0Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'FemaleSum0' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.FemaleSum0Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int FemaleSum01
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.FemaleSum01Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'FemaleSum01' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.FemaleSum01Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int FemaleSum1
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.FemaleSum1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'FemaleSum1' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.FemaleSum1Column] = value;
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
                        str = (string) base[this.tableSightMatrix.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableSightMatrix.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int GradeID
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.GradeIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradeID' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Male10
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male10Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male10' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male10Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Male11
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male11Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male11' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male11Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Male20
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male20Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male20' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male20Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Male21
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male21Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male21' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male21Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Male30
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male30Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male30' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male30Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Male31
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male31Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male31' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male31Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Male40
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.Male40Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Male40' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.Male40Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int MaleSum0
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.MaleSum0Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'MaleSum0' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.MaleSum0Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int MaleSum01
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.MaleSum01Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'MaleSum01' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.MaleSum01Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int MaleSum1
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightMatrix.MaleSum1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'MaleSum1' in table 'SightMatrix' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightMatrix.MaleSum1Column] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SightMatrixRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.SightMatrixRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SightMatrixRowChangeEvent(dsSight.SightMatrixRow row, DataRowAction action)
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
            public dsSight.SightMatrixRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SightMatrixRowChangeEventHandler(object sender, dsSight.SightMatrixRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SightPieDataTable : TypedTableBase<dsSight.SightPieRow>
        {
            private DataColumn columnA1;
            private DataColumn columnA2;
            private DataColumn columnA3;
            private DataColumn columnA4;
            private DataColumn columnA6;
            private DataColumn columnB1;
            private DataColumn columnB2;
            private DataColumn columnB3;
            private DataColumn columnSchYears;
            private DataColumn columnSem;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightPieRowChangeEventHandler SightPieRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightPieRowChangeEventHandler SightPieRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightPieRowChangeEventHandler SightPieRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightPieRowChangeEventHandler SightPieRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SightPieDataTable()
            {
                base.TableName = "SightPie";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightPieDataTable(DataTable table)
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
            protected SightPieDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSightPieRow(dsSight.SightPieRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightPieRow AddSightPieRow(short Sem, int A1, int A2, int A3, int A4, int B1, int B2, int B3, int A6, short SchYears)
            {
                dsSight.SightPieRow row = (dsSight.SightPieRow) base.NewRow();
                row.ItemArray = new object[] { Sem, A1, A2, A3, A4, B1, B2, B3, A6, SchYears };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSight.SightPieDataTable table = (dsSight.SightPieDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.SightPieDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.SightPieRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SightPieDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnA1 = new DataColumn("A1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnA1);
                this.columnA2 = new DataColumn("A2", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnA2);
                this.columnA3 = new DataColumn("A3", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnA3);
                this.columnA4 = new DataColumn("A4", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnA4);
                this.columnB1 = new DataColumn("B1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnB1);
                this.columnB2 = new DataColumn("B2", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnB2);
                this.columnB3 = new DataColumn("B3", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnB3);
                this.columnA6 = new DataColumn("A6", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnA6);
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnSem.AllowDBNull = false;
                this.columnA1.ReadOnly = true;
                this.columnA2.ReadOnly = true;
                this.columnA3.ReadOnly = true;
                this.columnA4.ReadOnly = true;
                this.columnB1.ReadOnly = true;
                this.columnB2.ReadOnly = true;
                this.columnB3.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSem = base.Columns["Sem"];
                this.columnA1 = base.Columns["A1"];
                this.columnA2 = base.Columns["A2"];
                this.columnA3 = base.Columns["A3"];
                this.columnA4 = base.Columns["A4"];
                this.columnB1 = base.Columns["B1"];
                this.columnB2 = base.Columns["B2"];
                this.columnB3 = base.Columns["B3"];
                this.columnA6 = base.Columns["A6"];
                this.columnSchYears = base.Columns["SchYears"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.SightPieRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightPieRow NewSightPieRow()
            {
                return (dsSight.SightPieRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SightPieRowChanged != null)
                {
                    this.SightPieRowChanged(this, new dsSight.SightPieRowChangeEvent((dsSight.SightPieRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SightPieRowChanging != null)
                {
                    this.SightPieRowChanging(this, new dsSight.SightPieRowChangeEvent((dsSight.SightPieRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SightPieRowDeleted != null)
                {
                    this.SightPieRowDeleted(this, new dsSight.SightPieRowChangeEvent((dsSight.SightPieRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SightPieRowDeleting != null)
                {
                    this.SightPieRowDeleting(this, new dsSight.SightPieRowChangeEvent((dsSight.SightPieRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSightPieRow(dsSight.SightPieRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn A1Column
            {
                get
                {
                    return this.columnA1;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn A2Column
            {
                get
                {
                    return this.columnA2;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn A3Column
            {
                get
                {
                    return this.columnA3;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn A4Column
            {
                get
                {
                    return this.columnA4;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn A6Column
            {
                get
                {
                    return this.columnA6;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn B1Column
            {
                get
                {
                    return this.columnB1;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn B2Column
            {
                get
                {
                    return this.columnB2;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn B3Column
            {
                get
                {
                    return this.columnB3;
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
            public dsSight.SightPieRow this[int index]
            {
                get
                {
                    return (dsSight.SightPieRow) base.Rows[index];
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
                }
            }
        }

        public class SightPieRow : DataRow
        {
            private dsSight.SightPieDataTable tableSightPie;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightPieRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSightPie = (dsSight.SightPieDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsA1Null()
            {
                return base.IsNull(this.tableSightPie.A1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsA2Null()
            {
                return base.IsNull(this.tableSightPie.A2Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsA3Null()
            {
                return base.IsNull(this.tableSightPie.A3Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsA4Null()
            {
                return base.IsNull(this.tableSightPie.A4Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsA6Null()
            {
                return base.IsNull(this.tableSightPie.A6Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsB1Null()
            {
                return base.IsNull(this.tableSightPie.B1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsB2Null()
            {
                return base.IsNull(this.tableSightPie.B2Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsB3Null()
            {
                return base.IsNull(this.tableSightPie.B3Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tableSightPie.SchYearsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetA1Null()
            {
                base[this.tableSightPie.A1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetA2Null()
            {
                base[this.tableSightPie.A2Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetA3Null()
            {
                base[this.tableSightPie.A3Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetA4Null()
            {
                base[this.tableSightPie.A4Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetA6Null()
            {
                base[this.tableSightPie.A6Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetB1Null()
            {
                base[this.tableSightPie.B1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetB2Null()
            {
                base[this.tableSightPie.B2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetB3Null()
            {
                base[this.tableSightPie.B3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchYearsNull()
            {
                base[this.tableSightPie.SchYearsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int A1
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.A1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'A1' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.A1Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int A2
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.A2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'A2' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.A2Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int A3
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.A3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'A3' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.A3Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int A4
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.A4Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'A4' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.A4Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int A6
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.A6Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'A6' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.A6Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int B1
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.B1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'B1' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.B1Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int B2
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.B2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'B2' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.B2Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int B3
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightPie.B3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'B3' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.B3Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchYears
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tableSightPie.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'SightPie' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightPie.SchYearsColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sem
            {
                get
                {
                    return (short) base[this.tableSightPie.SemColumn];
                }
                set
                {
                    base[this.tableSightPie.SemColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SightPieRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.SightPieRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightPieRowChangeEvent(dsSight.SightPieRow row, DataRowAction action)
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
            public dsSight.SightPieRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SightPieRowChangeEventHandler(object sender, dsSight.SightPieRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class SightReturnRateDataTable : TypedTableBase<dsSight.SightReturnRateRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columnCountD;
            private DataColumn columnCountN;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnReturnRate;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightReturnRateRowChangeEventHandler SightReturnRateRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightReturnRateRowChangeEventHandler SightReturnRateRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightReturnRateRowChangeEventHandler SightReturnRateRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.SightReturnRateRowChangeEventHandler SightReturnRateRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SightReturnRateDataTable()
            {
                base.TableName = "SightReturnRate";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal SightReturnRateDataTable(DataTable table)
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
            protected SightReturnRateDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddSightReturnRateRow(dsSight.SightReturnRateRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightReturnRateRow AddSightReturnRateRow(string Grade, string Class, short GradeID, short ClassID, int CountD, int CountN, double ReturnRate)
            {
                dsSight.SightReturnRateRow row = (dsSight.SightReturnRateRow) base.NewRow();
                row.ItemArray = new object[] { Grade, Class, GradeID, ClassID, CountD, CountN, ReturnRate };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSight.SightReturnRateDataTable table = (dsSight.SightReturnRateDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dsSight.SightReturnRateDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightReturnRateRow FindByGradeIDClassID(short GradeID, short ClassID)
            {
                return (dsSight.SightReturnRateRow) base.Rows.Find(new object[] { GradeID, ClassID });
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.SightReturnRateRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "SightReturnRateDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnCountD = new DataColumn("CountD", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCountD);
                this.columnCountN = new DataColumn("CountN", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCountN);
                this.columnReturnRate = new DataColumn("ReturnRate", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnReturnRate);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnGradeID, this.columnClassID }, true));
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columnGradeID.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnCountD.ReadOnly = true;
                this.columnCountN.ReadOnly = true;
                this.columnReturnRate.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnCountD = base.Columns["CountD"];
                this.columnCountN = base.Columns["CountN"];
                this.columnReturnRate = base.Columns["ReturnRate"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.SightReturnRateRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.SightReturnRateRow NewSightReturnRateRow()
            {
                return (dsSight.SightReturnRateRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SightReturnRateRowChanged != null)
                {
                    this.SightReturnRateRowChanged(this, new dsSight.SightReturnRateRowChangeEvent((dsSight.SightReturnRateRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SightReturnRateRowChanging != null)
                {
                    this.SightReturnRateRowChanging(this, new dsSight.SightReturnRateRowChangeEvent((dsSight.SightReturnRateRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SightReturnRateRowDeleted != null)
                {
                    this.SightReturnRateRowDeleted(this, new dsSight.SightReturnRateRowChangeEvent((dsSight.SightReturnRateRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SightReturnRateRowDeleting != null)
                {
                    this.SightReturnRateRowDeleting(this, new dsSight.SightReturnRateRowChangeEvent((dsSight.SightReturnRateRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveSightReturnRateRow(dsSight.SightReturnRateRow row)
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

            [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn CountDColumn
            {
                get
                {
                    return this.columnCountD;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CountNColumn
            {
                get
                {
                    return this.columnCountN;
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
            public DataColumn GradeIDColumn
            {
                get
                {
                    return this.columnGradeID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.SightReturnRateRow this[int index]
            {
                get
                {
                    return (dsSight.SightReturnRateRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ReturnRateColumn
            {
                get
                {
                    return this.columnReturnRate;
                }
            }
        }

        public class SightReturnRateRow : DataRow
        {
            private dsSight.SightReturnRateDataTable tableSightReturnRate;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SightReturnRateRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSightReturnRate = (dsSight.SightReturnRateDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tableSightReturnRate.ClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsCountDNull()
            {
                return base.IsNull(this.tableSightReturnRate.CountDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCountNNull()
            {
                return base.IsNull(this.tableSightReturnRate.CountNColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tableSightReturnRate.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsReturnRateNull()
            {
                return base.IsNull(this.tableSightReturnRate.ReturnRateColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tableSightReturnRate.ClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCountDNull()
            {
                base[this.tableSightReturnRate.CountDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCountNNull()
            {
                base[this.tableSightReturnRate.CountNColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tableSightReturnRate.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetReturnRateNull()
            {
                base[this.tableSightReturnRate.ReturnRateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    if (this.IsClassNull())
                    {
                        return string.Empty;
                    }
                    return (string) base[this.tableSightReturnRate.ClassColumn];
                }
                set
                {
                    base[this.tableSightReturnRate.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tableSightReturnRate.ClassIDColumn];
                }
                set
                {
                    base[this.tableSightReturnRate.ClassIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int CountD
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightReturnRate.CountDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'CountD' in table 'SightReturnRate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightReturnRate.CountDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CountN
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableSightReturnRate.CountNColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'CountN' in table 'SightReturnRate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightReturnRate.CountNColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Grade
            {
                get
                {
                    if (this.IsGradeNull())
                    {
                        return string.Empty;
                    }
                    return (string) base[this.tableSightReturnRate.GradeColumn];
                }
                set
                {
                    base[this.tableSightReturnRate.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tableSightReturnRate.GradeIDColumn];
                }
                set
                {
                    base[this.tableSightReturnRate.GradeIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public double ReturnRate
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableSightReturnRate.ReturnRateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ReturnRate' in table 'SightReturnRate' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableSightReturnRate.ReturnRateColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SightReturnRateRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.SightReturnRateRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public SightReturnRateRowChangeEvent(dsSight.SightReturnRateRow row, DataRowAction action)
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
            public dsSight.SightReturnRateRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SightReturnRateRowChangeEventHandler(object sender, dsSight.SightReturnRateRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vS0CannotCheckDataTable : TypedTableBase<dsSight.vS0CannotCheckRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columnDiopL;
            private DataColumn columnDiopR;
            private DataColumn columnEFar;
            private DataColumn columnENear;
            private DataColumn columnESan;
            private DataColumn columnESight99;
            private DataColumn columnESight99State;
            private DataColumn columnEWeak;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnManage;
            private DataColumn columnManageID;
            private DataColumn columnPID;
            private DataColumn columnS0ID;
            private DataColumn columnSchYears;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnSexID;
            private DataColumn columnSID;
            private DataColumn columnSight0L;
            private DataColumn columnSight0R;
            private DataColumn columnSightL;
            private DataColumn columnSightMeasureResult;
            private DataColumn columnSightR;
            private DataColumn columnState;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vS0CannotCheckRowChangeEventHandler vS0CannotCheckRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vS0CannotCheckRowChangeEventHandler vS0CannotCheckRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vS0CannotCheckRowChangeEventHandler vS0CannotCheckRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vS0CannotCheckRowChangeEventHandler vS0CannotCheckRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vS0CannotCheckDataTable()
            {
                base.TableName = "vS0CannotCheck";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vS0CannotCheckDataTable(DataTable table)
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
            protected vS0CannotCheckDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddvS0CannotCheckRow(dsSight.vS0CannotCheckRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vS0CannotCheckRow AddvS0CannotCheckRow(string Class, short DiopR, bool EFar, bool ENear, bool ESan, bool ESight99, string ESight99State, bool EWeak, string Grade, short GradeID, string Guy, string Manage, string ManageID, string PID, string S0ID, string SID, int SchYears, short Seat, short Sem, short SexID, short Sight0L, short Sight0R, short SightL, string SightMeasureResult, short SightR, short Years, string State, short ClassID, short DiopL)
            {
                dsSight.vS0CannotCheckRow row = (dsSight.vS0CannotCheckRow) base.NewRow();
                row.ItemArray = new object[] { 
                    Class, DiopR, EFar, ENear, ESan, ESight99, ESight99State, EWeak, Grade, GradeID, Guy, Manage, ManageID, PID, S0ID, SID, 
                    SchYears, Seat, Sem, SexID, Sight0L, Sight0R, SightL, SightMeasureResult, SightR, Years, State, ClassID, DiopL
                 };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSight.vS0CannotCheckDataTable table = (dsSight.vS0CannotCheckDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.vS0CannotCheckDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSight.vS0CannotCheckRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "vS0CannotCheckDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnDiopR = new DataColumn("DiopR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiopR);
                this.columnEFar = new DataColumn("EFar", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEFar);
                this.columnENear = new DataColumn("ENear", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnENear);
                this.columnESan = new DataColumn("ESan", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESan);
                this.columnESight99 = new DataColumn("ESight99", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESight99);
                this.columnESight99State = new DataColumn("ESight99State", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnESight99State);
                this.columnEWeak = new DataColumn("EWeak", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEWeak);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnManage = new DataColumn("Manage", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManage);
                this.columnManageID = new DataColumn("ManageID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManageID);
                this.columnPID = new DataColumn("PID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPID);
                this.columnS0ID = new DataColumn("S0ID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnS0ID);
                this.columnSID = new DataColumn("SID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSID);
                this.columnSchYears = new DataColumn("SchYears", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnSight0L = new DataColumn("Sight0L", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSight0L);
                this.columnSight0R = new DataColumn("Sight0R", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSight0R);
                this.columnSightL = new DataColumn("SightL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightL);
                this.columnSightMeasureResult = new DataColumn("SightMeasureResult", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSightMeasureResult);
                this.columnSightR = new DataColumn("SightR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightR);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnState = new DataColumn("State", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnState);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnDiopL = new DataColumn("DiopL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiopL);
                this.columnClass.MaxLength = 10;
                this.columnEFar.AllowDBNull = false;
                this.columnENear.AllowDBNull = false;
                this.columnESan.AllowDBNull = false;
                this.columnESight99.AllowDBNull = false;
                this.columnESight99State.MaxLength = 0xff;
                this.columnEWeak.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnGradeID.AllowDBNull = false;
                this.columnGuy.MaxLength = 100;
                this.columnManage.MaxLength = 0xff;
                this.columnManageID.MaxLength = 30;
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnS0ID.ReadOnly = true;
                this.columnS0ID.MaxLength = 1;
                this.columnSID.ReadOnly = true;
                this.columnSID.MaxLength = 1;
                this.columnSchYears.ReadOnly = true;
                this.columnSem.AllowDBNull = false;
                this.columnSexID.AllowDBNull = false;
                this.columnSightMeasureResult.ReadOnly = true;
                this.columnSightMeasureResult.MaxLength = 1;
                this.columnYears.AllowDBNull = false;
                this.columnState.MaxLength = 12;
                this.columnClassID.AllowDBNull = false;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnClass = base.Columns["Class"];
                this.columnDiopR = base.Columns["DiopR"];
                this.columnEFar = base.Columns["EFar"];
                this.columnENear = base.Columns["ENear"];
                this.columnESan = base.Columns["ESan"];
                this.columnESight99 = base.Columns["ESight99"];
                this.columnESight99State = base.Columns["ESight99State"];
                this.columnEWeak = base.Columns["EWeak"];
                this.columnGrade = base.Columns["Grade"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnManage = base.Columns["Manage"];
                this.columnManageID = base.Columns["ManageID"];
                this.columnPID = base.Columns["PID"];
                this.columnS0ID = base.Columns["S0ID"];
                this.columnSID = base.Columns["SID"];
                this.columnSchYears = base.Columns["SchYears"];
                this.columnSeat = base.Columns["Seat"];
                this.columnSem = base.Columns["Sem"];
                this.columnSexID = base.Columns["SexID"];
                this.columnSight0L = base.Columns["Sight0L"];
                this.columnSight0R = base.Columns["Sight0R"];
                this.columnSightL = base.Columns["SightL"];
                this.columnSightMeasureResult = base.Columns["SightMeasureResult"];
                this.columnSightR = base.Columns["SightR"];
                this.columnYears = base.Columns["Years"];
                this.columnState = base.Columns["State"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnDiopL = base.Columns["DiopL"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.vS0CannotCheckRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vS0CannotCheckRow NewvS0CannotCheckRow()
            {
                return (dsSight.vS0CannotCheckRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vS0CannotCheckRowChanged != null)
                {
                    this.vS0CannotCheckRowChanged(this, new dsSight.vS0CannotCheckRowChangeEvent((dsSight.vS0CannotCheckRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vS0CannotCheckRowChanging != null)
                {
                    this.vS0CannotCheckRowChanging(this, new dsSight.vS0CannotCheckRowChangeEvent((dsSight.vS0CannotCheckRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vS0CannotCheckRowDeleted != null)
                {
                    this.vS0CannotCheckRowDeleted(this, new dsSight.vS0CannotCheckRowChangeEvent((dsSight.vS0CannotCheckRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vS0CannotCheckRowDeleting != null)
                {
                    this.vS0CannotCheckRowDeleting(this, new dsSight.vS0CannotCheckRowChangeEvent((dsSight.vS0CannotCheckRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemovevS0CannotCheckRow(dsSight.vS0CannotCheckRow row)
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClassIDColumn
            {
                get
                {
                    return this.columnClassID;
                }
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
            public DataColumn DiopLColumn
            {
                get
                {
                    return this.columnDiopL;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DiopRColumn
            {
                get
                {
                    return this.columnDiopR;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EFarColumn
            {
                get
                {
                    return this.columnEFar;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ENearColumn
            {
                get
                {
                    return this.columnENear;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESanColumn
            {
                get
                {
                    return this.columnESan;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESight99Column
            {
                get
                {
                    return this.columnESight99;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ESight99StateColumn
            {
                get
                {
                    return this.columnESight99State;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EWeakColumn
            {
                get
                {
                    return this.columnEWeak;
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
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vS0CannotCheckRow this[int index]
            {
                get
                {
                    return (dsSight.vS0CannotCheckRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ManageColumn
            {
                get
                {
                    return this.columnManage;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ManageIDColumn
            {
                get
                {
                    return this.columnManageID;
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
            public DataColumn S0IDColumn
            {
                get
                {
                    return this.columnS0ID;
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
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SIDColumn
            {
                get
                {
                    return this.columnSID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Sight0LColumn
            {
                get
                {
                    return this.columnSight0L;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sight0RColumn
            {
                get
                {
                    return this.columnSight0R;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SightLColumn
            {
                get
                {
                    return this.columnSightL;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SightMeasureResultColumn
            {
                get
                {
                    return this.columnSightMeasureResult;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightRColumn
            {
                get
                {
                    return this.columnSightR;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }
        }

        public class vS0CannotCheckRow : DataRow
        {
            private dsSight.vS0CannotCheckDataTable tablevS0CannotCheck;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vS0CannotCheckRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevS0CannotCheck = (dsSight.vS0CannotCheckDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDiopLNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.DiopLColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDiopRNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.DiopRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsESight99StateNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.ESight99StateColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsManageIDNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.ManageIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsManageNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.ManageColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsS0IDNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.S0IDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.SchYearsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSIDNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.SIDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSight0LNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.Sight0LColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSight0RNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.Sight0RColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSightLNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.SightLColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightMeasureResultNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.SightMeasureResultColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSightRNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.SightRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStateNull()
            {
                return base.IsNull(this.tablevS0CannotCheck.StateColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tablevS0CannotCheck.ClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDiopLNull()
            {
                base[this.tablevS0CannotCheck.DiopLColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDiopRNull()
            {
                base[this.tablevS0CannotCheck.DiopRColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetESight99StateNull()
            {
                base[this.tablevS0CannotCheck.ESight99StateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tablevS0CannotCheck.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tablevS0CannotCheck.GuyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetManageIDNull()
            {
                base[this.tablevS0CannotCheck.ManageIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetManageNull()
            {
                base[this.tablevS0CannotCheck.ManageColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetS0IDNull()
            {
                base[this.tablevS0CannotCheck.S0IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchYearsNull()
            {
                base[this.tablevS0CannotCheck.SchYearsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tablevS0CannotCheck.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSIDNull()
            {
                base[this.tablevS0CannotCheck.SIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSight0LNull()
            {
                base[this.tablevS0CannotCheck.Sight0LColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSight0RNull()
            {
                base[this.tablevS0CannotCheck.Sight0RColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightLNull()
            {
                base[this.tablevS0CannotCheck.SightLColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightMeasureResultNull()
            {
                base[this.tablevS0CannotCheck.SightMeasureResultColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightRNull()
            {
                base[this.tablevS0CannotCheck.SightRColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetStateNull()
            {
                base[this.tablevS0CannotCheck.StateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.ClassColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tablevS0CannotCheck.ClassIDColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.ClassIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short DiopL
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevS0CannotCheck.DiopLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'DiopL' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.DiopLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short DiopR
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevS0CannotCheck.DiopRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'DiopR' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.DiopRColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool EFar
            {
                get
                {
                    return (bool) base[this.tablevS0CannotCheck.EFarColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.EFarColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ENear
            {
                get
                {
                    return (bool) base[this.tablevS0CannotCheck.ENearColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.ENearColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ESan
            {
                get
                {
                    return (bool) base[this.tablevS0CannotCheck.ESanColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.ESanColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ESight99
            {
                get
                {
                    return (bool) base[this.tablevS0CannotCheck.ESight99Column];
                }
                set
                {
                    base[this.tablevS0CannotCheck.ESight99Column] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ESight99State
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.ESight99StateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ESight99State' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.ESight99StateColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool EWeak
            {
                get
                {
                    return (bool) base[this.tablevS0CannotCheck.EWeakColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.EWeakColumn] = value;
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
                        str = (string) base[this.tablevS0CannotCheck.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.GradeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tablevS0CannotCheck.GradeIDColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.GradeIDColumn] = value;
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
                        str = (string) base[this.tablevS0CannotCheck.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.GuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Manage
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.ManageColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Manage' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.ManageColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ManageID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.ManageIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ManageID' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.ManageIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string) base[this.tablevS0CannotCheck.PIDColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.PIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string S0ID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.S0IDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'S0ID' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.S0IDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int SchYears
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablevS0CannotCheck.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.SchYearsColumn] = value;
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
                        num = (short) base[this.tablevS0CannotCheck.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.SeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sem
            {
                get
                {
                    return (short) base[this.tablevS0CannotCheck.SemColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short) base[this.tablevS0CannotCheck.SexIDColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.SIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SID' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.SIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sight0L
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevS0CannotCheck.Sight0LColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sight0L' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.Sight0LColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sight0R
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevS0CannotCheck.Sight0RColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sight0R' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.Sight0RColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SightL
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevS0CannotCheck.SightLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightL' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.SightLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SightMeasureResult
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevS0CannotCheck.SightMeasureResultColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightMeasureResult' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.SightMeasureResultColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SightR
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevS0CannotCheck.SightRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightR' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevS0CannotCheck.SightRColumn] = value;
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
                        str = (string) base[this.tablevS0CannotCheck.StateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'State' in table 'vS0CannotCheck' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevS0CannotCheck.StateColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short) base[this.tablevS0CannotCheck.YearsColumn];
                }
                set
                {
                    base[this.tablevS0CannotCheck.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vS0CannotCheckRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.vS0CannotCheckRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public vS0CannotCheckRowChangeEvent(dsSight.vS0CannotCheckRow row, DataRowAction action)
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
            public dsSight.vS0CannotCheckRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vS0CannotCheckRowChangeEventHandler(object sender, dsSight.vS0CannotCheckRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vSightDataTable : TypedTableBase<dsSight.vSightRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDiag;
            private DataColumn columnDiopL;
            private DataColumn columnDiopR;
            private DataColumn columnEFar;
            private DataColumn columnENear;
            private DataColumn columnESan;
            private DataColumn columnESight99;
            private DataColumn columnESight99State;
            private DataColumn columnEWeak;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnisDilated;
            private DataColumn columnisDilating;
            private DataColumn columnManage;
            private DataColumn columnManageID;
            private DataColumn columnNoProblem;
            private DataColumn columnPID;
            private DataColumn columnS0ID;
            private DataColumn columnS0IDSimple;
            private DataColumn columnSchYears;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnSexID;
            private DataColumn columnSID;
            private DataColumn columnSight0L;
            private DataColumn columnSight0R;
            private DataColumn columnSightDiagResult;
            private DataColumn columnSightL;
            private DataColumn columnSightMeasureResult;
            private DataColumn columnSightR;
            private DataColumn columnVocID;
            private DataColumn columnYears;
            private DataColumn columnEFarR;
            private DataColumn columnEFarL;
            private DataColumn columnENearR;
            private DataColumn columnENearL;
            private DataColumn columnESanR;
            private DataColumn columnESanL;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightRowChangeEventHandler vSightRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightRowChangeEventHandler vSightRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightRowChangeEventHandler vSightRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightRowChangeEventHandler vSightRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vSightDataTable()
            {
                base.TableName = "vSight";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vSightDataTable(DataTable table)
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
            protected vSightDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddvSightRow(dsSight.vSightRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightRow AddvSightRow(string PID, string Guy, short SexID, short Years, short Sem, short GradeID, string Grade, short ClassID, string Class, short Sight0L, short Sight0R, short SightL, short SightR, string S0ID, string SID, bool ENear, bool EFar, bool ESan, bool EWeak, bool ESight99, string ESight99State, string ManageID, string Manage, string SightMeasureResult, short Seat, string cSex, short DiopL, short DiopR, short SightDiagResult, bool NoProblem, string VocID, string S0IDSimple, string Diag, short SchYears, bool isDilated, bool isDilating)
            {
                dsSight.vSightRow row = (dsSight.vSightRow) base.NewRow();
                row.ItemArray = new object[] { 
                    PID, Guy, SexID, Years, Sem, GradeID, Grade, ClassID, Class, Sight0L, Sight0R, SightL, SightR, S0ID, SID, ENear, 
                    EFar, ESan, EWeak, ESight99, ESight99State, ManageID, Manage, SightMeasureResult, Seat, cSex, DiopL, DiopR, SightDiagResult, NoProblem, VocID, S0IDSimple, 
                    Diag, SchYears, isDilated, isDilating
                 };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                dsSight.vSightDataTable table = (dsSight.vSightDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.vSightDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vSightRow FindByGradeIDSemPID(short GradeID, short Sem, string PID)
            {
                return (dsSight.vSightRow) base.Rows.Find(new object[] { GradeID, Sem, PID });
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSight.vSightRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "vSightDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnSight0L = new DataColumn("Sight0L", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSight0L);
                this.columnSight0R = new DataColumn("Sight0R", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSight0R);
                this.columnSightL = new DataColumn("SightL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightL);
                this.columnSightR = new DataColumn("SightR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightR);
                this.columnS0ID = new DataColumn("S0ID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnS0ID);
                this.columnSID = new DataColumn("SID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSID);
                this.columnENear = new DataColumn("ENear", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnENear);
                this.columnEFar = new DataColumn("EFar", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEFar);
                this.columnESan = new DataColumn("ESan", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESan);
                this.columnEWeak = new DataColumn("EWeak", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEWeak);
                this.columnESight99 = new DataColumn("ESight99", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESight99);
                this.columnESight99State = new DataColumn("ESight99State", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnESight99State);
                this.columnManageID = new DataColumn("ManageID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManageID);
                this.columnManage = new DataColumn("Manage", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnManage);
                this.columnSightMeasureResult = new DataColumn("SightMeasureResult", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSightMeasureResult);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnDiopL = new DataColumn("DiopL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiopL);
                this.columnDiopR = new DataColumn("DiopR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiopR);
                this.columnSightDiagResult = new DataColumn("SightDiagResult", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightDiagResult);
                this.columnNoProblem = new DataColumn("NoProblem", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnNoProblem);
                this.columnVocID = new DataColumn("VocID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVocID);
                this.columnS0IDSimple = new DataColumn("S0IDSimple", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnS0IDSimple);
                this.columnDiag = new DataColumn("Diag", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDiag);
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnisDilated = new DataColumn("isDilated", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnisDilated);
                this.columnisDilating = new DataColumn("isDilating", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnisDilating);
                this.columnEFarR = new DataColumn("EFarR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnEFarR);
                this.columnEFarL = new DataColumn("EFarL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnEFarL);
                this.columnENearR = new DataColumn("ENearR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnENearR);
                this.columnENearL = new DataColumn("ENearL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnENearL);
                this.columnESanR = new DataColumn("ESanR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnESanR);
                this.columnESanL = new DataColumn("ESanL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnESanL);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnGradeID, this.columnSem, this.columnPID }, true));
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnSem.AllowDBNull = false;
                this.columnGradeID.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClassID.AllowDBNull = false;
                this.columnClass.MaxLength = 10;
                this.columnS0ID.ReadOnly = true;
                this.columnS0ID.MaxLength = 1;
                this.columnSID.ReadOnly = true;
                this.columnSID.MaxLength = 1;
                this.columnENear.AllowDBNull = false;
                this.columnEFar.AllowDBNull = false;
                this.columnESan.AllowDBNull = false;
                this.columnEWeak.AllowDBNull = false;
                this.columnESight99.AllowDBNull = false;
                this.columnESight99State.MaxLength = 0xff;
                this.columnManageID.MaxLength = 30;
                this.columnManage.MaxLength = 0xff;
                this.columnSightMeasureResult.ReadOnly = true;
                this.columnSightMeasureResult.MaxLength = 1;
                this.columncSex.MaxLength = 2;
                this.columnSightDiagResult.ReadOnly = true;
                this.columnNoProblem.AllowDBNull = false;
                this.columnVocID.MaxLength = 1;
                this.columnS0IDSimple.ReadOnly = true;
                this.columnS0IDSimple.MaxLength = 1;
                this.columnDiag.ReadOnly = true;
                this.columnDiag.MaxLength = 10;
                this.columnSchYears.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnSem = base.Columns["Sem"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass = base.Columns["Class"];
                this.columnSight0L = base.Columns["Sight0L"];
                this.columnSight0R = base.Columns["Sight0R"];
                this.columnSightL = base.Columns["SightL"];
                this.columnSightR = base.Columns["SightR"];
                this.columnS0ID = base.Columns["S0ID"];
                this.columnSID = base.Columns["SID"];
                this.columnENear = base.Columns["ENear"];
                this.columnEFar = base.Columns["EFar"];
                this.columnESan = base.Columns["ESan"];
                this.columnEWeak = base.Columns["EWeak"];
                this.columnESight99 = base.Columns["ESight99"];
                this.columnESight99State = base.Columns["ESight99State"];
                this.columnManageID = base.Columns["ManageID"];
                this.columnManage = base.Columns["Manage"];
                this.columnSightMeasureResult = base.Columns["SightMeasureResult"];
                this.columnSeat = base.Columns["Seat"];
                this.columncSex = base.Columns["cSex"];
                this.columnDiopL = base.Columns["DiopL"];
                this.columnDiopR = base.Columns["DiopR"];
                this.columnSightDiagResult = base.Columns["SightDiagResult"];
                this.columnNoProblem = base.Columns["NoProblem"];
                this.columnVocID = base.Columns["VocID"];
                this.columnS0IDSimple = base.Columns["S0IDSimple"];
                this.columnDiag = base.Columns["Diag"];
                this.columnSchYears = base.Columns["SchYears"];
                this.columnisDilated = base.Columns["isDilated"];
                this.columnisDilating = base.Columns["isDilating"];
                this.columnEFarR = base.Columns["EFarR"];
                this.columnEFarL = base.Columns["EFarL"];
                this.columnENearR = base.Columns["ENearR"];
                this.columnENearL = base.Columns["ENearL"];
                this.columnESanR = base.Columns["ESanR"];
                this.columnESanL = base.Columns["ESanL"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.vSightRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vSightRow NewvSightRow()
            {
                return (dsSight.vSightRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vSightRowChanged != null)
                {
                    this.vSightRowChanged(this, new dsSight.vSightRowChangeEvent((dsSight.vSightRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vSightRowChanging != null)
                {
                    this.vSightRowChanging(this, new dsSight.vSightRowChangeEvent((dsSight.vSightRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vSightRowDeleted != null)
                {
                    this.vSightRowDeleted(this, new dsSight.vSightRowChangeEvent((dsSight.vSightRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vSightRowDeleting != null)
                {
                    this.vSightRowDeleting(this, new dsSight.vSightRowChangeEvent((dsSight.vSightRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemovevSightRow(dsSight.vSightRow row)
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
            public DataColumn DiagColumn
            {
                get
                {
                    return this.columnDiag;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DiopLColumn
            {
                get
                {
                    return this.columnDiopL;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DiopRColumn
            {
                get
                {
                    return this.columnDiopR;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EFarColumn
            {
                get
                {
                    return this.columnEFar;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ENearColumn
            {
                get
                {
                    return this.columnENear;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ESanColumn
            {
                get
                {
                    return this.columnESan;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ESight99Column
            {
                get
                {
                    return this.columnESight99;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESight99StateColumn
            {
                get
                {
                    return this.columnESight99State;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EWeakColumn
            {
                get
                {
                    return this.columnEWeak;
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
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn isDilatedColumn
            {
                get
                {
                    return this.columnisDilated;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn isDilatingColumn
            {
                get
                {
                    return this.columnisDilating;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightRow this[int index]
            {
                get
                {
                    return (dsSight.vSightRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ManageColumn
            {
                get
                {
                    return this.columnManage;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ManageIDColumn
            {
                get
                {
                    return this.columnManageID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn NoProblemColumn
            {
                get
                {
                    return this.columnNoProblem;
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
            public DataColumn S0IDColumn
            {
                get
                {
                    return this.columnS0ID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn S0IDSimpleColumn
            {
                get
                {
                    return this.columnS0IDSimple;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SeatColumn
            {
                get
                {
                    return this.columnSeat;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SexIDColumn
            {
                get
                {
                    return this.columnSexID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SIDColumn
            {
                get
                {
                    return this.columnSID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Sight0LColumn
            {
                get
                {
                    return this.columnSight0L;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Sight0RColumn
            {
                get
                {
                    return this.columnSight0R;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightDiagResultColumn
            {
                get
                {
                    return this.columnSightDiagResult;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightLColumn
            {
                get
                {
                    return this.columnSightL;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightMeasureResultColumn
            {
                get
                {
                    return this.columnSightMeasureResult;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SightRColumn
            {
                get
                {
                    return this.columnSightR;
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
            public DataColumn YearsColumn
            {
                get
                {
                    return this.columnYears;
                }
            }
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EFarRColumn
            {
                get
                {
                    return this.columnEFarR;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EFarLColumn
            {
                get
                {
                    return this.columnEFarL;
                }
            }
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ENearRColumn
            {
                get
                {
                    return this.columnENearR;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ENearLColumn
            {
                get
                {
                    return this.columnENearL;
                }
            }
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESanRColumn
            {
                get
                {
                    return this.columnESanR;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ESanLColumn
            {
                get
                {
                    return this.columnESanL;
                }
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vSightDiagResultDataTable : TypedTableBase<dsSight.vSightDiagResultRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDiag;
            private DataColumn columnEFar;
            private DataColumn columnENear;
            private DataColumn columnESan;
            private DataColumn columnESight99;
            private DataColumn columnEWeak;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnPID;
            private DataColumn columnSchYears;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnSexID;
            private DataColumn columnSightDiagResult;
            private DataColumn columnSightMeasureResult;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightDiagResultRowChangeEventHandler vSightDiagResultRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightDiagResultRowChangeEventHandler vSightDiagResultRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightDiagResultRowChangeEventHandler vSightDiagResultRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightDiagResultRowChangeEventHandler vSightDiagResultRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vSightDiagResultDataTable()
            {
                base.TableName = "vSightDiagResult";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vSightDiagResultDataTable(DataTable table)
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
            protected vSightDiagResultDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddvSightDiagResultRow(dsSight.vSightDiagResultRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightDiagResultRow AddvSightDiagResultRow(string PID, short SexID, short Years, short Sem, short SchYears, short GradeID, string Grade, short ClassID, string Class, short Seat, bool ENear, bool EFar, bool ESan, bool EWeak, bool ESight99, string SightMeasureResult, string Diag, string cSex, short SightDiagResult, string Guy)
            {
                dsSight.vSightDiagResultRow row = (dsSight.vSightDiagResultRow) base.NewRow();
                row.ItemArray = new object[] { 
                    PID, SexID, Years, Sem, SchYears, GradeID, Grade, ClassID, Class, Seat, ENear, EFar, ESan, EWeak, ESight99, SightMeasureResult, 
                    Diag, cSex, SightDiagResult, Guy
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSight.vSightDiagResultDataTable table = (dsSight.vSightDiagResultDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.vSightDiagResultDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dsSight.vSightDiagResultRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "vSightDiagResultDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columnYears = new DataColumn("Years", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnYears);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnSchYears = new DataColumn("SchYears", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnENear = new DataColumn("ENear", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnENear);
                this.columnEFar = new DataColumn("EFar", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEFar);
                this.columnESan = new DataColumn("ESan", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESan);
                this.columnEWeak = new DataColumn("EWeak", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEWeak);
                this.columnESight99 = new DataColumn("ESight99", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnESight99);
                this.columnSightMeasureResult = new DataColumn("SightMeasureResult", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSightMeasureResult);
                this.columnDiag = new DataColumn("Diag", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDiag);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnSightDiagResult = new DataColumn("SightDiagResult", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightDiagResult);
                this.columnGuy = new DataColumn("Guy", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGuy);
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnSexID.AllowDBNull = false;
                this.columnYears.AllowDBNull = false;
                this.columnSem.AllowDBNull = false;
                this.columnSchYears.ReadOnly = true;
                this.columnGradeID.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClassID.AllowDBNull = false;
                this.columnClass.MaxLength = 10;
                this.columnENear.AllowDBNull = false;
                this.columnEFar.AllowDBNull = false;
                this.columnESan.AllowDBNull = false;
                this.columnEWeak.AllowDBNull = false;
                this.columnESight99.AllowDBNull = false;
                this.columnSightMeasureResult.ReadOnly = true;
                this.columnSightMeasureResult.MaxLength = 1;
                this.columnDiag.ReadOnly = true;
                this.columnDiag.MaxLength = 10;
                this.columncSex.MaxLength = 2;
                this.columnSightDiagResult.ReadOnly = true;
                this.columnGuy.MaxLength = 100;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnSexID = base.Columns["SexID"];
                this.columnYears = base.Columns["Years"];
                this.columnSem = base.Columns["Sem"];
                this.columnSchYears = base.Columns["SchYears"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnClass = base.Columns["Class"];
                this.columnSeat = base.Columns["Seat"];
                this.columnENear = base.Columns["ENear"];
                this.columnEFar = base.Columns["EFar"];
                this.columnESan = base.Columns["ESan"];
                this.columnEWeak = base.Columns["EWeak"];
                this.columnESight99 = base.Columns["ESight99"];
                this.columnSightMeasureResult = base.Columns["SightMeasureResult"];
                this.columnDiag = base.Columns["Diag"];
                this.columncSex = base.Columns["cSex"];
                this.columnSightDiagResult = base.Columns["SightDiagResult"];
                this.columnGuy = base.Columns["Guy"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.vSightDiagResultRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vSightDiagResultRow NewvSightDiagResultRow()
            {
                return (dsSight.vSightDiagResultRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vSightDiagResultRowChanged != null)
                {
                    this.vSightDiagResultRowChanged(this, new dsSight.vSightDiagResultRowChangeEvent((dsSight.vSightDiagResultRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vSightDiagResultRowChanging != null)
                {
                    this.vSightDiagResultRowChanging(this, new dsSight.vSightDiagResultRowChangeEvent((dsSight.vSightDiagResultRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vSightDiagResultRowDeleted != null)
                {
                    this.vSightDiagResultRowDeleted(this, new dsSight.vSightDiagResultRowChangeEvent((dsSight.vSightDiagResultRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vSightDiagResultRowDeleting != null)
                {
                    this.vSightDiagResultRowDeleting(this, new dsSight.vSightDiagResultRowChangeEvent((dsSight.vSightDiagResultRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemovevSightDiagResultRow(dsSight.vSightDiagResultRow row)
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DiagColumn
            {
                get
                {
                    return this.columnDiag;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EFarColumn
            {
                get
                {
                    return this.columnEFar;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ENearColumn
            {
                get
                {
                    return this.columnENear;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ESanColumn
            {
                get
                {
                    return this.columnESan;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ESight99Column
            {
                get
                {
                    return this.columnESight99;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EWeakColumn
            {
                get
                {
                    return this.columnEWeak;
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightDiagResultRow this[int index]
            {
                get
                {
                    return (dsSight.vSightDiagResultRow) base.Rows[index];
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
            public DataColumn SchYearsColumn
            {
                get
                {
                    return this.columnSchYears;
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
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SightDiagResultColumn
            {
                get
                {
                    return this.columnSightDiagResult;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SightMeasureResultColumn
            {
                get
                {
                    return this.columnSightMeasureResult;
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

        public class vSightDiagResultRow : DataRow
        {
            private dsSight.vSightDiagResultDataTable tablevSightDiagResult;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vSightDiagResultRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevSightDiagResult = (dsSight.vSightDiagResultDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevSightDiagResult.ClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevSightDiagResult.cSexColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDiagNull()
            {
                return base.IsNull(this.tablevSightDiagResult.DiagColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevSightDiagResult.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevSightDiagResult.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tablevSightDiagResult.SchYearsColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevSightDiagResult.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightDiagResultNull()
            {
                return base.IsNull(this.tablevSightDiagResult.SightDiagResultColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightMeasureResultNull()
            {
                return base.IsNull(this.tablevSightDiagResult.SightMeasureResultColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tablevSightDiagResult.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tablevSightDiagResult.cSexColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDiagNull()
            {
                base[this.tablevSightDiagResult.DiagColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tablevSightDiagResult.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGuyNull()
            {
                base[this.tablevSightDiagResult.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSchYearsNull()
            {
                base[this.tablevSightDiagResult.SchYearsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tablevSightDiagResult.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSightDiagResultNull()
            {
                base[this.tablevSightDiagResult.SightDiagResultColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSightMeasureResultNull()
            {
                base[this.tablevSightDiagResult.SightMeasureResultColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSightDiagResult.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightDiagResult.ClassColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tablevSightDiagResult.ClassIDColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.ClassIDColumn] = value;
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
                        str = (string) base[this.tablevSightDiagResult.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightDiagResult.cSexColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Diag
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSightDiagResult.DiagColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Diag' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightDiagResult.DiagColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool EFar
            {
                get
                {
                    return (bool) base[this.tablevSightDiagResult.EFarColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.EFarColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool ENear
            {
                get
                {
                    return (bool) base[this.tablevSightDiagResult.ENearColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.ENearColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool ESan
            {
                get
                {
                    return (bool) base[this.tablevSightDiagResult.ESanColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.ESanColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ESight99
            {
                get
                {
                    return (bool) base[this.tablevSightDiagResult.ESight99Column];
                }
                set
                {
                    base[this.tablevSightDiagResult.ESight99Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool EWeak
            {
                get
                {
                    return (bool) base[this.tablevSightDiagResult.EWeakColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.EWeakColumn] = value;
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
                        str = (string) base[this.tablevSightDiagResult.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightDiagResult.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tablevSightDiagResult.GradeIDColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.GradeIDColumn] = value;
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
                        str = (string) base[this.tablevSightDiagResult.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightDiagResult.GuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string) base[this.tablevSightDiagResult.PIDColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchYears
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightDiagResult.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightDiagResult.SchYearsColumn] = value;
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
                        num = (short) base[this.tablevSightDiagResult.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightDiagResult.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sem
            {
                get
                {
                    return (short) base[this.tablevSightDiagResult.SemColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.SemColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SexID
            {
                get
                {
                    return (short) base[this.tablevSightDiagResult.SexIDColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SightDiagResult
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightDiagResult.SightDiagResultColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightDiagResult' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightDiagResult.SightDiagResultColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SightMeasureResult
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSightDiagResult.SightMeasureResultColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightMeasureResult' in table 'vSightDiagResult' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightDiagResult.SightMeasureResultColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short) base[this.tablevSightDiagResult.YearsColumn];
                }
                set
                {
                    base[this.tablevSightDiagResult.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vSightDiagResultRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.vSightDiagResultRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vSightDiagResultRowChangeEvent(dsSight.vSightDiagResultRow row, DataRowAction action)
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
            public dsSight.vSightDiagResultRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vSightDiagResultRowChangeEventHandler(object sender, dsSight.vSightDiagResultRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vSightNear50DataTable : TypedTableBase<dsSight.vSightNear50Row>
        {
            private DataColumn columnClass;
            private DataColumn columncSex;
            private DataColumn columnDiffer;
            private DataColumn columnGrade;
            private DataColumn columnGradePre;
            private DataColumn columnGuy;
            private DataColumn columnNearDiop;
            private DataColumn columnNearDiopPre;
            private DataColumn columnPID;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnSemPre;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNear50RowChangeEventHandler vSightNear50RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNear50RowChangeEventHandler vSightNear50RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNear50RowChangeEventHandler vSightNear50RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNear50RowChangeEventHandler vSightNear50RowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vSightNear50DataTable()
            {
                base.TableName = "vSightNear50";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vSightNear50DataTable(DataTable table)
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
            protected vSightNear50DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddvSightNear50Row(dsSight.vSightNear50Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vSightNear50Row AddvSightNear50Row(string PID, string Guy, string cSex, string Grade, string GradePre, short NearDiop, short NearDiopPre, short Differ, string Class, short Seat, short Sem, short SemPre)
            {
                dsSight.vSightNear50Row row = (dsSight.vSightNear50Row) base.NewRow();
                row.ItemArray = new object[] { PID, Guy, cSex, Grade, GradePre, NearDiop, NearDiopPre, Differ, Class, Seat, Sem, SemPre };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSight.vSightNear50DataTable table = (dsSight.vSightNear50DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.vSightNear50DataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.vSightNear50Row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "vSightNear50DataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnGradePre = new DataColumn("GradePre", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGradePre);
                this.columnNearDiop = new DataColumn("NearDiop", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNearDiop);
                this.columnNearDiopPre = new DataColumn("NearDiopPre", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNearDiopPre);
                this.columnDiffer = new DataColumn("Differ", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiffer);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnSemPre = new DataColumn("SemPre", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSemPre);
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columncSex.MaxLength = 2;
                this.columnGrade.MaxLength = 2;
                this.columnGradePre.MaxLength = 2;
                this.columnDiffer.ReadOnly = true;
                this.columnClass.MaxLength = 10;
                this.columnSem.AllowDBNull = false;
                this.columnSemPre.AllowDBNull = false;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columncSex = base.Columns["cSex"];
                this.columnGrade = base.Columns["Grade"];
                this.columnGradePre = base.Columns["GradePre"];
                this.columnNearDiop = base.Columns["NearDiop"];
                this.columnNearDiopPre = base.Columns["NearDiopPre"];
                this.columnDiffer = base.Columns["Differ"];
                this.columnClass = base.Columns["Class"];
                this.columnSeat = base.Columns["Seat"];
                this.columnSem = base.Columns["Sem"];
                this.columnSemPre = base.Columns["SemPre"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.vSightNear50Row(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dsSight.vSightNear50Row NewvSightNear50Row()
            {
                return (dsSight.vSightNear50Row) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vSightNear50RowChanged != null)
                {
                    this.vSightNear50RowChanged(this, new dsSight.vSightNear50RowChangeEvent((dsSight.vSightNear50Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vSightNear50RowChanging != null)
                {
                    this.vSightNear50RowChanging(this, new dsSight.vSightNear50RowChangeEvent((dsSight.vSightNear50Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vSightNear50RowDeleted != null)
                {
                    this.vSightNear50RowDeleted(this, new dsSight.vSightNear50RowChangeEvent((dsSight.vSightNear50Row) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vSightNear50RowDeleting != null)
                {
                    this.vSightNear50RowDeleting(this, new dsSight.vSightNear50RowChangeEvent((dsSight.vSightNear50Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovevSightNear50Row(dsSight.vSightNear50Row row)
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

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
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

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DifferColumn
            {
                get
                {
                    return this.columnDiffer;
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
            public DataColumn GradePreColumn
            {
                get
                {
                    return this.columnGradePre;
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
            public dsSight.vSightNear50Row this[int index]
            {
                get
                {
                    return (dsSight.vSightNear50Row) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn NearDiopColumn
            {
                get
                {
                    return this.columnNearDiop;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NearDiopPreColumn
            {
                get
                {
                    return this.columnNearDiopPre;
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
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SemPreColumn
            {
                get
                {
                    return this.columnSemPre;
                }
            }
        }

        public class vSightNear50Row : DataRow
        {
            private dsSight.vSightNear50DataTable tablevSightNear50;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal vSightNear50Row(DataRowBuilder rb) : base(rb)
            {
                this.tablevSightNear50 = (dsSight.vSightNear50DataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevSightNear50.ClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevSightNear50.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDifferNull()
            {
                return base.IsNull(this.tablevSightNear50.DifferColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevSightNear50.GradeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradePreNull()
            {
                return base.IsNull(this.tablevSightNear50.GradePreColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevSightNear50.GuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNearDiopNull()
            {
                return base.IsNull(this.tablevSightNear50.NearDiopColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNearDiopPreNull()
            {
                return base.IsNull(this.tablevSightNear50.NearDiopPreColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevSightNear50.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tablevSightNear50.ClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetcSexNull()
            {
                base[this.tablevSightNear50.cSexColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDifferNull()
            {
                base[this.tablevSightNear50.DifferColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tablevSightNear50.GradeColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradePreNull()
            {
                base[this.tablevSightNear50.GradePreColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tablevSightNear50.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNearDiopNull()
            {
                base[this.tablevSightNear50.NearDiopColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNearDiopPreNull()
            {
                base[this.tablevSightNear50.NearDiopPreColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tablevSightNear50.SeatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSightNear50.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear50.ClassColumn] = value;
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
                        str = (string) base[this.tablevSightNear50.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear50.cSexColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Differ
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear50.DifferColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Differ' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear50.DifferColumn] = value;
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
                        str = (string) base[this.tablevSightNear50.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear50.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GradePre
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSightNear50.GradePreColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'GradePre' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear50.GradePreColumn] = value;
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
                        str = (string) base[this.tablevSightNear50.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear50.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short NearDiop
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear50.NearDiopColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NearDiop' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear50.NearDiopColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short NearDiopPre
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear50.NearDiopPreColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NearDiopPre' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear50.NearDiopPreColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PID
            {
                get
                {
                    return (string) base[this.tablevSightNear50.PIDColumn];
                }
                set
                {
                    base[this.tablevSightNear50.PIDColumn] = value;
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
                        num = (short) base[this.tablevSightNear50.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vSightNear50' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear50.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sem
            {
                get
                {
                    return (short) base[this.tablevSightNear50.SemColumn];
                }
                set
                {
                    base[this.tablevSightNear50.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SemPre
            {
                get
                {
                    return (short) base[this.tablevSightNear50.SemPreColumn];
                }
                set
                {
                    base[this.tablevSightNear50.SemPreColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vSightNear50RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.vSightNear50Row eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vSightNear50RowChangeEvent(dsSight.vSightNear50Row row, DataRowAction action)
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
            public dsSight.vSightNear50Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vSightNear50RowChangeEventHandler(object sender, dsSight.vSightNear50RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class vSightNearDataTable : TypedTableBase<dsSight.vSightNearRow>
        {
            private DataColumn columnClass;
            private DataColumn columnClassID;
            private DataColumn columncSex;
            private DataColumn columnDiopL;
            private DataColumn columnDiopR;
            private DataColumn columnEFar;
            private DataColumn columnENear;
            private DataColumn columnExpr1;
            private DataColumn columnGrade;
            private DataColumn columnGradeID;
            private DataColumn columnGuy;
            private DataColumn columnNearDiop;
            private DataColumn columnPID;
            private DataColumn columnSchYears;
            private DataColumn columnSeat;
            private DataColumn columnSem;
            private DataColumn columnSexID;
            private DataColumn columnSightMin;
            private DataColumn columnYears;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNearRowChangeEventHandler vSightNearRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNearRowChangeEventHandler vSightNearRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNearRowChangeEventHandler vSightNearRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event dsSight.vSightNearRowChangeEventHandler vSightNearRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public vSightNearDataTable()
            {
                base.TableName = "vSightNear";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vSightNearDataTable(DataTable table)
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
            protected vSightNearDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddvSightNearRow(dsSight.vSightNearRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightNearRow AddvSightNearRow(string PID, string Guy, short Years, short Sem, int SchYears, short GradeID, short ClassID, string Grade, string Class, short Seat, short SexID, string cSex, bool ENear, bool EFar, short DiopL, short DiopR, short NearDiop, short SightMin, short Expr1)
            {
                dsSight.vSightNearRow row = (dsSight.vSightNearRow) base.NewRow();
                row.ItemArray = new object[] { 
                    PID, Guy, Years, Sem, SchYears, GradeID, ClassID, Grade, Class, Seat, SexID, cSex, ENear, EFar, DiopL, DiopR, 
                    NearDiop, SightMin, Expr1
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dsSight.vSightNearDataTable table = (dsSight.vSightNearDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new dsSight.vSightNearDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(dsSight.vSightNearRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dsSight sight = new dsSight();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = sight.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "vSightNearDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = sight.GetSchemaSerializable();
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
                            current = (XmlSchema) enumerator.Current;
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
                this.columnSem = new DataColumn("Sem", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSem);
                this.columnSchYears = new DataColumn("SchYears", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSchYears);
                this.columnGradeID = new DataColumn("GradeID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnGradeID);
                this.columnClassID = new DataColumn("ClassID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnClassID);
                this.columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGrade);
                this.columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnClass);
                this.columnSeat = new DataColumn("Seat", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSeat);
                this.columnSexID = new DataColumn("SexID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSexID);
                this.columncSex = new DataColumn("cSex", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncSex);
                this.columnENear = new DataColumn("ENear", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnENear);
                this.columnEFar = new DataColumn("EFar", typeof(bool), null, MappingType.Element);
                base.Columns.Add(this.columnEFar);
                this.columnDiopL = new DataColumn("DiopL", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiopL);
                this.columnDiopR = new DataColumn("DiopR", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnDiopR);
                this.columnNearDiop = new DataColumn("NearDiop", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnNearDiop);
                this.columnSightMin = new DataColumn("SightMin", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSightMin);
                this.columnExpr1 = new DataColumn("Expr1", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnExpr1);
                this.columnPID.AllowDBNull = false;
                this.columnPID.MaxLength = 12;
                this.columnGuy.MaxLength = 100;
                this.columnYears.AllowDBNull = false;
                this.columnSem.AllowDBNull = false;
                this.columnSchYears.ReadOnly = true;
                this.columnGradeID.AllowDBNull = false;
                this.columnClassID.AllowDBNull = false;
                this.columnGrade.MaxLength = 2;
                this.columnClass.MaxLength = 10;
                this.columnSexID.AllowDBNull = false;
                this.columncSex.MaxLength = 2;
                this.columnENear.AllowDBNull = false;
                this.columnEFar.AllowDBNull = false;
                this.columnNearDiop.ReadOnly = true;
                this.columnSightMin.ReadOnly = true;
                this.columnExpr1.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnPID = base.Columns["PID"];
                this.columnGuy = base.Columns["Guy"];
                this.columnYears = base.Columns["Years"];
                this.columnSem = base.Columns["Sem"];
                this.columnSchYears = base.Columns["SchYears"];
                this.columnGradeID = base.Columns["GradeID"];
                this.columnClassID = base.Columns["ClassID"];
                this.columnGrade = base.Columns["Grade"];
                this.columnClass = base.Columns["Class"];
                this.columnSeat = base.Columns["Seat"];
                this.columnSexID = base.Columns["SexID"];
                this.columncSex = base.Columns["cSex"];
                this.columnENear = base.Columns["ENear"];
                this.columnEFar = base.Columns["EFar"];
                this.columnDiopL = base.Columns["DiopL"];
                this.columnDiopR = base.Columns["DiopR"];
                this.columnNearDiop = base.Columns["NearDiop"];
                this.columnSightMin = base.Columns["SightMin"];
                this.columnExpr1 = base.Columns["Expr1"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsSight.vSightNearRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightNearRow NewvSightNearRow()
            {
                return (dsSight.vSightNearRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.vSightNearRowChanged != null)
                {
                    this.vSightNearRowChanged(this, new dsSight.vSightNearRowChangeEvent((dsSight.vSightNearRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.vSightNearRowChanging != null)
                {
                    this.vSightNearRowChanging(this, new dsSight.vSightNearRowChangeEvent((dsSight.vSightNearRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.vSightNearRowDeleted != null)
                {
                    this.vSightNearRowDeleted(this, new dsSight.vSightNearRowChangeEvent((dsSight.vSightNearRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.vSightNearRowDeleting != null)
                {
                    this.vSightNearRowDeleting(this, new dsSight.vSightNearRowChangeEvent((dsSight.vSightNearRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemovevSightNearRow(dsSight.vSightNearRow row)
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
            public DataColumn cSexColumn
            {
                get
                {
                    return this.columncSex;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DiopLColumn
            {
                get
                {
                    return this.columnDiopL;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DiopRColumn
            {
                get
                {
                    return this.columnDiopR;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn EFarColumn
            {
                get
                {
                    return this.columnEFar;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ENearColumn
            {
                get
                {
                    return this.columnENear;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Expr1Column
            {
                get
                {
                    return this.columnExpr1;
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
            public DataColumn GuyColumn
            {
                get
                {
                    return this.columnGuy;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public dsSight.vSightNearRow this[int index]
            {
                get
                {
                    return (dsSight.vSightNearRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NearDiopColumn
            {
                get
                {
                    return this.columnNearDiop;
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
            public DataColumn SchYearsColumn
            {
                get
                {
                    return this.columnSchYears;
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
            public DataColumn SemColumn
            {
                get
                {
                    return this.columnSem;
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
            public DataColumn SightMinColumn
            {
                get
                {
                    return this.columnSightMin;
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

        public class vSightNearRow : DataRow
        {
            private dsSight.vSightNearDataTable tablevSightNear;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vSightNearRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevSightNear = (dsSight.vSightNearDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevSightNear.ClassColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevSightNear.cSexColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDiopLNull()
            {
                return base.IsNull(this.tablevSightNear.DiopLColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDiopRNull()
            {
                return base.IsNull(this.tablevSightNear.DiopRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsExpr1Null()
            {
                return base.IsNull(this.tablevSightNear.Expr1Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevSightNear.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevSightNear.GuyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNearDiopNull()
            {
                return base.IsNull(this.tablevSightNear.NearDiopColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tablevSightNear.SchYearsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevSightNear.SeatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSightMinNull()
            {
                return base.IsNull(this.tablevSightNear.SightMinColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetClassNull()
            {
                base[this.tablevSightNear.ClassColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetcSexNull()
            {
                base[this.tablevSightNear.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDiopLNull()
            {
                base[this.tablevSightNear.DiopLColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDiopRNull()
            {
                base[this.tablevSightNear.DiopRColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetExpr1Null()
            {
                base[this.tablevSightNear.Expr1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGradeNull()
            {
                base[this.tablevSightNear.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tablevSightNear.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNearDiopNull()
            {
                base[this.tablevSightNear.NearDiopColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSchYearsNull()
            {
                base[this.tablevSightNear.SchYearsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSeatNull()
            {
                base[this.tablevSightNear.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightMinNull()
            {
                base[this.tablevSightNear.SightMinColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSightNear.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vSightNear' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tablevSightNear.ClassIDColumn];
                }
                set
                {
                    base[this.tablevSightNear.ClassIDColumn] = value;
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
                        str = (string) base[this.tablevSightNear.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vSightNear' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear.cSexColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short DiopL
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear.DiopLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'DiopL' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.DiopLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short DiopR
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear.DiopRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'DiopR' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.DiopRColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool EFar
            {
                get
                {
                    return (bool) base[this.tablevSightNear.EFarColumn];
                }
                set
                {
                    base[this.tablevSightNear.EFarColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ENear
            {
                get
                {
                    return (bool) base[this.tablevSightNear.ENearColumn];
                }
                set
                {
                    base[this.tablevSightNear.ENearColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Expr1
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear.Expr1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Expr1' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.Expr1Column] = value;
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
                        str = (string) base[this.tablevSightNear.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'vSightNear' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tablevSightNear.GradeIDColumn];
                }
                set
                {
                    base[this.tablevSightNear.GradeIDColumn] = value;
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
                        str = (string) base[this.tablevSightNear.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vSightNear' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSightNear.GuyColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short NearDiop
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear.NearDiopColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'NearDiop' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.NearDiopColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string) base[this.tablevSightNear.PIDColumn];
                }
                set
                {
                    base[this.tablevSightNear.PIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int SchYears
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablevSightNear.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.SchYearsColumn] = value;
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
                        num = (short) base[this.tablevSightNear.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.SeatColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Sem
            {
                get
                {
                    return (short) base[this.tablevSightNear.SemColumn];
                }
                set
                {
                    base[this.tablevSightNear.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short) base[this.tablevSightNear.SexIDColumn];
                }
                set
                {
                    base[this.tablevSightNear.SexIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SightMin
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSightNear.SightMinColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightMin' in table 'vSightNear' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSightNear.SightMinColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Years
            {
                get
                {
                    return (short) base[this.tablevSightNear.YearsColumn];
                }
                set
                {
                    base[this.tablevSightNear.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vSightNearRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.vSightNearRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public vSightNearRowChangeEvent(dsSight.vSightNearRow row, DataRowAction action)
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
            public dsSight.vSightNearRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vSightNearRowChangeEventHandler(object sender, dsSight.vSightNearRowChangeEvent e);

        public class vSightRow : DataRow
        {
            private dsSight.vSightDataTable tablevSight;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal vSightRow(DataRowBuilder rb) : base(rb)
            {
                this.tablevSight = (dsSight.vSightDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClassNull()
            {
                return base.IsNull(this.tablevSight.ClassColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IscSexNull()
            {
                return base.IsNull(this.tablevSight.cSexColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDiagNull()
            {
                return base.IsNull(this.tablevSight.DiagColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDiopLNull()
            {
                return base.IsNull(this.tablevSight.DiopLColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDiopRNull()
            {
                return base.IsNull(this.tablevSight.DiopRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsESight99StateNull()
            {
                return base.IsNull(this.tablevSight.ESight99StateColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGradeNull()
            {
                return base.IsNull(this.tablevSight.GradeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGuyNull()
            {
                return base.IsNull(this.tablevSight.GuyColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsisDilatedNull()
            {
                return base.IsNull(this.tablevSight.isDilatedColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsisDilatingNull()
            {
                return base.IsNull(this.tablevSight.isDilatingColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsManageIDNull()
            {
                return base.IsNull(this.tablevSight.ManageIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsManageNull()
            {
                return base.IsNull(this.tablevSight.ManageColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsS0IDNull()
            {
                return base.IsNull(this.tablevSight.S0IDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsS0IDSimpleNull()
            {
                return base.IsNull(this.tablevSight.S0IDSimpleColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSchYearsNull()
            {
                return base.IsNull(this.tablevSight.SchYearsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSeatNull()
            {
                return base.IsNull(this.tablevSight.SeatColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSIDNull()
            {
                return base.IsNull(this.tablevSight.SIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSight0LNull()
            {
                return base.IsNull(this.tablevSight.Sight0LColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSight0RNull()
            {
                return base.IsNull(this.tablevSight.Sight0RColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightDiagResultNull()
            {
                return base.IsNull(this.tablevSight.SightDiagResultColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightLNull()
            {
                return base.IsNull(this.tablevSight.SightLColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightMeasureResultNull()
            {
                return base.IsNull(this.tablevSight.SightMeasureResultColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSightRNull()
            {
                return base.IsNull(this.tablevSight.SightRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVocIDNull()
            {
                return base.IsNull(this.tablevSight.VocIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClassNull()
            {
                base[this.tablevSight.ClassColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetcSexNull()
            {
                base[this.tablevSight.cSexColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDiagNull()
            {
                base[this.tablevSight.DiagColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDiopLNull()
            {
                base[this.tablevSight.DiopLColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDiopRNull()
            {
                base[this.tablevSight.DiopRColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetESight99StateNull()
            {
                base[this.tablevSight.ESight99StateColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGradeNull()
            {
                base[this.tablevSight.GradeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGuyNull()
            {
                base[this.tablevSight.GuyColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetisDilatedNull()
            {
                base[this.tablevSight.isDilatedColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetisDilatingNull()
            {
                base[this.tablevSight.isDilatingColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetManageIDNull()
            {
                base[this.tablevSight.ManageIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetManageNull()
            {
                base[this.tablevSight.ManageColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetS0IDNull()
            {
                base[this.tablevSight.S0IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetS0IDSimpleNull()
            {
                base[this.tablevSight.S0IDSimpleColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSchYearsNull()
            {
                base[this.tablevSight.SchYearsColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSeatNull()
            {
                base[this.tablevSight.SeatColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSIDNull()
            {
                base[this.tablevSight.SIDColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSight0LNull()
            {
                base[this.tablevSight.Sight0LColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSight0RNull()
            {
                base[this.tablevSight.Sight0RColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSightDiagResultNull()
            {
                base[this.tablevSight.SightDiagResultColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightLNull()
            {
                base[this.tablevSight.SightLColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightMeasureResultNull()
            {
                base[this.tablevSight.SightMeasureResultColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSightRNull()
            {
                base[this.tablevSight.SightRColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetVocIDNull()
            {
                base[this.tablevSight.VocIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Class
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.ClassColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Class' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.ClassColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short ClassID
            {
                get
                {
                    return (short) base[this.tablevSight.ClassIDColumn];
                }
                set
                {
                    base[this.tablevSight.ClassIDColumn] = value;
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
                        str = (string) base[this.tablevSight.cSexColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'cSex' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.cSexColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Diag
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.DiagColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Diag' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.DiagColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short DiopL
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.DiopLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'DiopL' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.DiopLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short DiopR
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.DiopRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'DiopR' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.DiopRColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool EFar
            {
                get
                {
                    return (bool) base[this.tablevSight.EFarColumn];
                }
                set
                {
                    base[this.tablevSight.EFarColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool ENear
            {
                get
                {
                    return (bool) base[this.tablevSight.ENearColumn];
                }
                set
                {
                    base[this.tablevSight.ENearColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ESan
            {
                get
                {
                    return (bool) base[this.tablevSight.ESanColumn];
                }
                set
                {
                    base[this.tablevSight.ESanColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool ESight99
            {
                get
                {
                    return (bool) base[this.tablevSight.ESight99Column];
                }
                set
                {
                    base[this.tablevSight.ESight99Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ESight99State
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.ESight99StateColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ESight99State' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.ESight99StateColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool EWeak
            {
                get
                {
                    return (bool) base[this.tablevSight.EWeakColumn];
                }
                set
                {
                    base[this.tablevSight.EWeakColumn] = value;
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
                        str = (string) base[this.tablevSight.GradeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Grade' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.GradeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short GradeID
            {
                get
                {
                    return (short) base[this.tablevSight.GradeIDColumn];
                }
                set
                {
                    base[this.tablevSight.GradeIDColumn] = value;
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
                        str = (string) base[this.tablevSight.GuyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Guy' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.GuyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool isDilated
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool) base[this.tablevSight.isDilatedColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'isDilated' in table 'vSight' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tablevSight.isDilatedColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool isDilating
            {
                get
                {
                    bool flag;
                    try
                    {
                        flag = (bool) base[this.tablevSight.isDilatingColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'isDilating' in table 'vSight' is DBNull.", exception);
                    }
                    return flag;
                }
                set
                {
                    base[this.tablevSight.isDilatingColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Manage
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.ManageColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Manage' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.ManageColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ManageID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.ManageIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'ManageID' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.ManageIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool NoProblem
            {
                get
                {
                    return (bool) base[this.tablevSight.NoProblemColumn];
                }
                set
                {
                    base[this.tablevSight.NoProblemColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PID
            {
                get
                {
                    return (string) base[this.tablevSight.PIDColumn];
                }
                set
                {
                    base[this.tablevSight.PIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string S0ID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.S0IDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'S0ID' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.S0IDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string S0IDSimple
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.S0IDSimpleColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'S0IDSimple' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.S0IDSimpleColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SchYears
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.SchYearsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SchYears' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.SchYearsColumn] = value;
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
                        num = (short) base[this.tablevSight.SeatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Seat' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.SeatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sem
            {
                get
                {
                    return (short) base[this.tablevSight.SemColumn];
                }
                set
                {
                    base[this.tablevSight.SemColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short SexID
            {
                get
                {
                    return (short) base[this.tablevSight.SexIDColumn];
                }
                set
                {
                    base[this.tablevSight.SexIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.SIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SID' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.SIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sight0L
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.Sight0LColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sight0L' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.Sight0LColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sight0R
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.Sight0RColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'Sight0R' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.Sight0RColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SightDiagResult
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.SightDiagResultColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightDiagResult' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.SightDiagResultColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SightL
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.SightLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightL' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.SightLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SightMeasureResult
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.SightMeasureResultColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightMeasureResult' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.SightMeasureResultColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short SightR
            {
                get
                {
                    short num;
                    try
                    {
                        num = (short) base[this.tablevSight.SightRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'SightR' in table 'vSight' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablevSight.SightRColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string VocID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablevSight.VocIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        
                        throw new StrongTypingException("The value for column 'VocID' in table 'vSight' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablevSight.VocIDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public short Years
            {
                get
                {
                    return (short) base[this.tablevSight.YearsColumn];
                }
                set
                {
                    base[this.tablevSight.YearsColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class vSightRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsSight.vSightRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public vSightRowChangeEvent(dsSight.vSightRow row, DataRowAction action)
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
            public dsSight.vSightRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void vSightRowChangeEventHandler(object sender, dsSight.vSightRowChangeEvent e);
    }
}