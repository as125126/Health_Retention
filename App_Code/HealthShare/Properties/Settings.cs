namespace HealthShare.Properties
{
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [SpecialSetting(SpecialSetting.ConnectionString), ApplicationScopedSetting, DebuggerNonUserCode, DefaultSettingValue(@"Data Source=.\SQLEXPRESS;Initial Catalog=Health;Integrated Security=True")]
        public string Health
        {
            get
            {
                return (string) this["Health"];
            }
        }

        [DefaultSettingValue("Data Source=.;Initial Catalog=SchoolGov560;Persist Security Info=True;User ID=sa"), ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString)]
        public string SchoolGov
        {
            get
            {
                return (string) this["SchoolGov"];
            }
        }

        [SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode, DefaultSettingValue("Data Source=.;Initial Catalog=SchoolGov560;Integrated Security=True"), ApplicationScopedSetting]
        public string SchoolGov560ConnectionString
        {
            get
            {
                return (string) this["SchoolGov560ConnectionString"];
            }
        }
    }
}

