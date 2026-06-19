using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F7 RID: 503
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ReferenceStripPropertyDefinitionType
	{
		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x060016C6 RID: 5830 RVA: 0x0001D984 File Offset: 0x0001BB84
		// (set) Token: 0x060016C7 RID: 5831 RVA: 0x0001D98C File Offset: 0x0001BB8C
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

		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x060016C8 RID: 5832 RVA: 0x0001D998 File Offset: 0x0001BB98
		// (set) Token: 0x060016C9 RID: 5833 RVA: 0x0001D9A0 File Offset: 0x0001BBA0
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

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x060016CA RID: 5834 RVA: 0x0001D9AC File Offset: 0x0001BBAC
		// (set) Token: 0x060016CB RID: 5835 RVA: 0x0001D9B4 File Offset: 0x0001BBB4
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

		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x060016CC RID: 5836 RVA: 0x0001D9C0 File Offset: 0x0001BBC0
		// (set) Token: 0x060016CD RID: 5837 RVA: 0x0001D9C8 File Offset: 0x0001BBC8
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

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x060016CE RID: 5838 RVA: 0x0001D9D4 File Offset: 0x0001BBD4
		// (set) Token: 0x060016CF RID: 5839 RVA: 0x0001D9DC File Offset: 0x0001BBDC
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

		// Token: 0x17000999 RID: 2457
		// (get) Token: 0x060016D0 RID: 5840 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
		// (set) Token: 0x060016D1 RID: 5841 RVA: 0x0001D9F0 File Offset: 0x0001BBF0
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

		// Token: 0x1700099A RID: 2458
		// (get) Token: 0x060016D2 RID: 5842 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		// (set) Token: 0x060016D3 RID: 5843 RVA: 0x0001DA04 File Offset: 0x0001BC04
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

		// Token: 0x1700099B RID: 2459
		// (get) Token: 0x060016D4 RID: 5844 RVA: 0x0001DA10 File Offset: 0x0001BC10
		// (set) Token: 0x060016D5 RID: 5845 RVA: 0x0001DA18 File Offset: 0x0001BC18
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

		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x060016D6 RID: 5846 RVA: 0x0001DA24 File Offset: 0x0001BC24
		// (set) Token: 0x060016D7 RID: 5847 RVA: 0x0001DA2C File Offset: 0x0001BC2C
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

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x060016D8 RID: 5848 RVA: 0x0001DA38 File Offset: 0x0001BC38
		// (set) Token: 0x060016D9 RID: 5849 RVA: 0x0001DA40 File Offset: 0x0001BC40
		public int MaxReferenceCount
		{
			get
			{
				return this.maxReferenceCountField;
			}
			set
			{
				this.maxReferenceCountField = value;
			}
		}

		// Token: 0x1700099E RID: 2462
		// (get) Token: 0x060016DA RID: 5850 RVA: 0x0001DA4C File Offset: 0x0001BC4C
		// (set) Token: 0x060016DB RID: 5851 RVA: 0x0001DA54 File Offset: 0x0001BC54
		[XmlIgnore]
		public bool MaxReferenceCountSpecified
		{
			get
			{
				return this.maxReferenceCountFieldSpecified;
			}
			set
			{
				this.maxReferenceCountFieldSpecified = value;
			}
		}

		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x060016DC RID: 5852 RVA: 0x0001DA60 File Offset: 0x0001BC60
		// (set) Token: 0x060016DD RID: 5853 RVA: 0x0001DA68 File Offset: 0x0001BC68
		public ObjectTypes ObjectTypes
		{
			get
			{
				return this.objectTypesField;
			}
			set
			{
				this.objectTypesField = value;
			}
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x060016DE RID: 5854 RVA: 0x0001DA74 File Offset: 0x0001BC74
		// (set) Token: 0x060016DF RID: 5855 RVA: 0x0001DA7C File Offset: 0x0001BC7C
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

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x060016E0 RID: 5856 RVA: 0x0001DA88 File Offset: 0x0001BC88
		// (set) Token: 0x060016E1 RID: 5857 RVA: 0x0001DA90 File Offset: 0x0001BC90
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

		// Token: 0x04000C8B RID: 3211
		private LocalizableTextType displayNameField;

		// Token: 0x04000C8C RID: 3212
		private string colorField;

		// Token: 0x04000C8D RID: 3213
		private string technicalNameField;

		// Token: 0x04000C8E RID: 3214
		private string tooltipTextField;

		// Token: 0x04000C8F RID: 3215
		private int isMandatoryField;

		// Token: 0x04000C90 RID: 3216
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000C91 RID: 3217
		private int isLocalizedField;

		// Token: 0x04000C92 RID: 3218
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000C93 RID: 3219
		private string placeholderValueField;

		// Token: 0x04000C94 RID: 3220
		private int maxReferenceCountField;

		// Token: 0x04000C95 RID: 3221
		private bool maxReferenceCountFieldSpecified;

		// Token: 0x04000C96 RID: 3222
		private ObjectTypes objectTypesField;

		// Token: 0x04000C97 RID: 3223
		private string idField;

		// Token: 0x04000C98 RID: 3224
		private string basedOnField;
	}
}
