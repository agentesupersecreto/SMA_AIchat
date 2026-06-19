using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F8 RID: 504
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ScriptPropertyDefinitionType
	{
		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x060016E3 RID: 5859 RVA: 0x0001DAA4 File Offset: 0x0001BCA4
		// (set) Token: 0x060016E4 RID: 5860 RVA: 0x0001DAAC File Offset: 0x0001BCAC
		public LocalizableTextType DisplayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}

		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x060016E5 RID: 5861 RVA: 0x0001DAB8 File Offset: 0x0001BCB8
		// (set) Token: 0x060016E6 RID: 5862 RVA: 0x0001DAC0 File Offset: 0x0001BCC0
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x060016E7 RID: 5863 RVA: 0x0001DACC File Offset: 0x0001BCCC
		// (set) Token: 0x060016E8 RID: 5864 RVA: 0x0001DAD4 File Offset: 0x0001BCD4
		[XmlElement(DataType = "token")]
		public string TechnicalName
		{
			get
			{
				return this.technicalNameField;
			}
			set
			{
				this.technicalNameField = value;
			}
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x0001DAE0 File Offset: 0x0001BCE0
		// (set) Token: 0x060016EA RID: 5866 RVA: 0x0001DAE8 File Offset: 0x0001BCE8
		public string TooltipText
		{
			get
			{
				return this.tooltipTextField;
			}
			set
			{
				this.tooltipTextField = value;
			}
		}

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x060016EB RID: 5867 RVA: 0x0001DAF4 File Offset: 0x0001BCF4
		// (set) Token: 0x060016EC RID: 5868 RVA: 0x0001DAFC File Offset: 0x0001BCFC
		public int IsMandatory
		{
			get
			{
				return this.isMandatoryField;
			}
			set
			{
				this.isMandatoryField = value;
			}
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x060016ED RID: 5869 RVA: 0x0001DB08 File Offset: 0x0001BD08
		// (set) Token: 0x060016EE RID: 5870 RVA: 0x0001DB10 File Offset: 0x0001BD10
		[XmlIgnore]
		public bool IsMandatorySpecified
		{
			get
			{
				return this.isMandatoryFieldSpecified;
			}
			set
			{
				this.isMandatoryFieldSpecified = value;
			}
		}

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x060016EF RID: 5871 RVA: 0x0001DB1C File Offset: 0x0001BD1C
		// (set) Token: 0x060016F0 RID: 5872 RVA: 0x0001DB24 File Offset: 0x0001BD24
		public int IsLocalized
		{
			get
			{
				return this.isLocalizedField;
			}
			set
			{
				this.isLocalizedField = value;
			}
		}

		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x060016F1 RID: 5873 RVA: 0x0001DB30 File Offset: 0x0001BD30
		// (set) Token: 0x060016F2 RID: 5874 RVA: 0x0001DB38 File Offset: 0x0001BD38
		[XmlIgnore]
		public bool IsLocalizedSpecified
		{
			get
			{
				return this.isLocalizedFieldSpecified;
			}
			set
			{
				this.isLocalizedFieldSpecified = value;
			}
		}

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x060016F3 RID: 5875 RVA: 0x0001DB44 File Offset: 0x0001BD44
		// (set) Token: 0x060016F4 RID: 5876 RVA: 0x0001DB4C File Offset: 0x0001BD4C
		public string PlaceholderValue
		{
			get
			{
				return this.placeholderValueField;
			}
			set
			{
				this.placeholderValueField = value;
			}
		}

		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x060016F5 RID: 5877 RVA: 0x0001DB58 File Offset: 0x0001BD58
		// (set) Token: 0x060016F6 RID: 5878 RVA: 0x0001DB60 File Offset: 0x0001BD60
		public string DefaultValue
		{
			get
			{
				return this.defaultValueField;
			}
			set
			{
				this.defaultValueField = value;
			}
		}

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x060016F7 RID: 5879 RVA: 0x0001DB6C File Offset: 0x0001BD6C
		// (set) Token: 0x060016F8 RID: 5880 RVA: 0x0001DB74 File Offset: 0x0001BD74
		public ScriptTypeType ScriptType
		{
			get
			{
				return this.scriptTypeField;
			}
			set
			{
				this.scriptTypeField = value;
			}
		}

		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x060016F9 RID: 5881 RVA: 0x0001DB80 File Offset: 0x0001BD80
		// (set) Token: 0x060016FA RID: 5882 RVA: 0x0001DB88 File Offset: 0x0001BD88
		[XmlIgnore]
		public bool ScriptTypeSpecified
		{
			get
			{
				return this.scriptTypeFieldSpecified;
			}
			set
			{
				this.scriptTypeFieldSpecified = value;
			}
		}

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x060016FB RID: 5883 RVA: 0x0001DB94 File Offset: 0x0001BD94
		// (set) Token: 0x060016FC RID: 5884 RVA: 0x0001DB9C File Offset: 0x0001BD9C
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x0001DBA8 File Offset: 0x0001BDA8
		// (set) Token: 0x060016FE RID: 5886 RVA: 0x0001DBB0 File Offset: 0x0001BDB0
		[XmlAttribute]
		public string BasedOn
		{
			get
			{
				return this.basedOnField;
			}
			set
			{
				this.basedOnField = value;
			}
		}

		// Token: 0x04000C99 RID: 3225
		private LocalizableTextType displayNameField;

		// Token: 0x04000C9A RID: 3226
		private string colorField;

		// Token: 0x04000C9B RID: 3227
		private string technicalNameField;

		// Token: 0x04000C9C RID: 3228
		private string tooltipTextField;

		// Token: 0x04000C9D RID: 3229
		private int isMandatoryField;

		// Token: 0x04000C9E RID: 3230
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000C9F RID: 3231
		private int isLocalizedField;

		// Token: 0x04000CA0 RID: 3232
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000CA1 RID: 3233
		private string placeholderValueField;

		// Token: 0x04000CA2 RID: 3234
		private string defaultValueField;

		// Token: 0x04000CA3 RID: 3235
		private ScriptTypeType scriptTypeField;

		// Token: 0x04000CA4 RID: 3236
		private bool scriptTypeFieldSpecified;

		// Token: 0x04000CA5 RID: 3237
		private string idField;

		// Token: 0x04000CA6 RID: 3238
		private string basedOnField;
	}
}
