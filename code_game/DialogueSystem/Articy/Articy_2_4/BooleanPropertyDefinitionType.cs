using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000126 RID: 294
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class BooleanPropertyDefinitionType
	{
		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x00015E0C File Offset: 0x0001400C
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x00015E14 File Offset: 0x00014014
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

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x00015E20 File Offset: 0x00014020
		// (set) Token: 0x06000C19 RID: 3097 RVA: 0x00015E28 File Offset: 0x00014028
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

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x00015E34 File Offset: 0x00014034
		// (set) Token: 0x06000C1B RID: 3099 RVA: 0x00015E3C File Offset: 0x0001403C
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

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x00015E48 File Offset: 0x00014048
		// (set) Token: 0x06000C1D RID: 3101 RVA: 0x00015E50 File Offset: 0x00014050
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

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x00015E5C File Offset: 0x0001405C
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x00015E64 File Offset: 0x00014064
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

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x00015E70 File Offset: 0x00014070
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x00015E78 File Offset: 0x00014078
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

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x00015E84 File Offset: 0x00014084
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x00015E8C File Offset: 0x0001408C
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

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x00015E98 File Offset: 0x00014098
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x00015EA0 File Offset: 0x000140A0
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

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00015EAC File Offset: 0x000140AC
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00015EB4 File Offset: 0x000140B4
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

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00015EC0 File Offset: 0x000140C0
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00015EC8 File Offset: 0x000140C8
		public int DefaultValue
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

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x00015ED4 File Offset: 0x000140D4
		// (set) Token: 0x06000C2B RID: 3115 RVA: 0x00015EDC File Offset: 0x000140DC
		[XmlIgnore]
		public bool DefaultValueSpecified
		{
			get
			{
				return this.defaultValueFieldSpecified;
			}
			set
			{
				this.defaultValueFieldSpecified = value;
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000C2C RID: 3116 RVA: 0x00015EE8 File Offset: 0x000140E8
		// (set) Token: 0x06000C2D RID: 3117 RVA: 0x00015EF0 File Offset: 0x000140F0
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

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000C2E RID: 3118 RVA: 0x00015EFC File Offset: 0x000140FC
		// (set) Token: 0x06000C2F RID: 3119 RVA: 0x00015F04 File Offset: 0x00014104
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

		// Token: 0x0400068E RID: 1678
		private LocalizableTextType displayNameField;

		// Token: 0x0400068F RID: 1679
		private string colorField;

		// Token: 0x04000690 RID: 1680
		private string technicalNameField;

		// Token: 0x04000691 RID: 1681
		private string tooltipTextField;

		// Token: 0x04000692 RID: 1682
		private int isMandatoryField;

		// Token: 0x04000693 RID: 1683
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000694 RID: 1684
		private int isLocalizedField;

		// Token: 0x04000695 RID: 1685
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000696 RID: 1686
		private string placeholderValueField;

		// Token: 0x04000697 RID: 1687
		private int defaultValueField;

		// Token: 0x04000698 RID: 1688
		private bool defaultValueFieldSpecified;

		// Token: 0x04000699 RID: 1689
		private string idField;

		// Token: 0x0400069A RID: 1690
		private string basedOnField;
	}
}
