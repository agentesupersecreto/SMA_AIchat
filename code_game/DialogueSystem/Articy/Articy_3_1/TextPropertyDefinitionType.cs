using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001FD RID: 509
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class TextPropertyDefinitionType
	{
		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06001749 RID: 5961 RVA: 0x0001DE98 File Offset: 0x0001C098
		// (set) Token: 0x0600174A RID: 5962 RVA: 0x0001DEA0 File Offset: 0x0001C0A0
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

		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x0600174B RID: 5963 RVA: 0x0001DEAC File Offset: 0x0001C0AC
		// (set) Token: 0x0600174C RID: 5964 RVA: 0x0001DEB4 File Offset: 0x0001C0B4
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

		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x0600174D RID: 5965 RVA: 0x0001DEC0 File Offset: 0x0001C0C0
		// (set) Token: 0x0600174E RID: 5966 RVA: 0x0001DEC8 File Offset: 0x0001C0C8
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

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x0600174F RID: 5967 RVA: 0x0001DED4 File Offset: 0x0001C0D4
		// (set) Token: 0x06001750 RID: 5968 RVA: 0x0001DEDC File Offset: 0x0001C0DC
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

		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06001751 RID: 5969 RVA: 0x0001DEE8 File Offset: 0x0001C0E8
		// (set) Token: 0x06001752 RID: 5970 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
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

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06001753 RID: 5971 RVA: 0x0001DEFC File Offset: 0x0001C0FC
		// (set) Token: 0x06001754 RID: 5972 RVA: 0x0001DF04 File Offset: 0x0001C104
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

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06001755 RID: 5973 RVA: 0x0001DF10 File Offset: 0x0001C110
		// (set) Token: 0x06001756 RID: 5974 RVA: 0x0001DF18 File Offset: 0x0001C118
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

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06001757 RID: 5975 RVA: 0x0001DF24 File Offset: 0x0001C124
		// (set) Token: 0x06001758 RID: 5976 RVA: 0x0001DF2C File Offset: 0x0001C12C
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

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06001759 RID: 5977 RVA: 0x0001DF38 File Offset: 0x0001C138
		// (set) Token: 0x0600175A RID: 5978 RVA: 0x0001DF40 File Offset: 0x0001C140
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

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x0001DF4C File Offset: 0x0001C14C
		// (set) Token: 0x0600175C RID: 5980 RVA: 0x0001DF54 File Offset: 0x0001C154
		public TextPropertyDefinitionValueType DefaultValue
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

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x0001DF60 File Offset: 0x0001C160
		// (set) Token: 0x0600175E RID: 5982 RVA: 0x0001DF68 File Offset: 0x0001C168
		public string DisallowedChars
		{
			get
			{
				return this.disallowedCharsField;
			}
			set
			{
				this.disallowedCharsField = value;
			}
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x0001DF74 File Offset: 0x0001C174
		// (set) Token: 0x06001760 RID: 5984 RVA: 0x0001DF7C File Offset: 0x0001C17C
		public int MaxLength
		{
			get
			{
				return this.maxLengthField;
			}
			set
			{
				this.maxLengthField = value;
			}
		}

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06001761 RID: 5985 RVA: 0x0001DF88 File Offset: 0x0001C188
		// (set) Token: 0x06001762 RID: 5986 RVA: 0x0001DF90 File Offset: 0x0001C190
		[XmlIgnore]
		public bool MaxLengthSpecified
		{
			get
			{
				return this.maxLengthFieldSpecified;
			}
			set
			{
				this.maxLengthFieldSpecified = value;
			}
		}

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x06001763 RID: 5987 RVA: 0x0001DF9C File Offset: 0x0001C19C
		// (set) Token: 0x06001764 RID: 5988 RVA: 0x0001DFA4 File Offset: 0x0001C1A4
		public int AllowsLinebreaks
		{
			get
			{
				return this.allowsLinebreaksField;
			}
			set
			{
				this.allowsLinebreaksField = value;
			}
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06001765 RID: 5989 RVA: 0x0001DFB0 File Offset: 0x0001C1B0
		// (set) Token: 0x06001766 RID: 5990 RVA: 0x0001DFB8 File Offset: 0x0001C1B8
		[XmlIgnore]
		public bool AllowsLinebreaksSpecified
		{
			get
			{
				return this.allowsLinebreaksFieldSpecified;
			}
			set
			{
				this.allowsLinebreaksFieldSpecified = value;
			}
		}

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06001767 RID: 5991 RVA: 0x0001DFC4 File Offset: 0x0001C1C4
		// (set) Token: 0x06001768 RID: 5992 RVA: 0x0001DFCC File Offset: 0x0001C1CC
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

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x0001DFD8 File Offset: 0x0001C1D8
		// (set) Token: 0x0600176A RID: 5994 RVA: 0x0001DFE0 File Offset: 0x0001C1E0
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

		// Token: 0x04000CCE RID: 3278
		private LocalizableTextType displayNameField;

		// Token: 0x04000CCF RID: 3279
		private string colorField;

		// Token: 0x04000CD0 RID: 3280
		private string technicalNameField;

		// Token: 0x04000CD1 RID: 3281
		private string tooltipTextField;

		// Token: 0x04000CD2 RID: 3282
		private int isMandatoryField;

		// Token: 0x04000CD3 RID: 3283
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000CD4 RID: 3284
		private int isLocalizedField;

		// Token: 0x04000CD5 RID: 3285
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000CD6 RID: 3286
		private string placeholderValueField;

		// Token: 0x04000CD7 RID: 3287
		private TextPropertyDefinitionValueType defaultValueField;

		// Token: 0x04000CD8 RID: 3288
		private string disallowedCharsField;

		// Token: 0x04000CD9 RID: 3289
		private int maxLengthField;

		// Token: 0x04000CDA RID: 3290
		private bool maxLengthFieldSpecified;

		// Token: 0x04000CDB RID: 3291
		private int allowsLinebreaksField;

		// Token: 0x04000CDC RID: 3292
		private bool allowsLinebreaksFieldSpecified;

		// Token: 0x04000CDD RID: 3293
		private string idField;

		// Token: 0x04000CDE RID: 3294
		private string basedOnField;
	}
}
