using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F1 RID: 497
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceSlotPropertyDefinitionType
	{
		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x06001693 RID: 5779 RVA: 0x0001D790 File Offset: 0x0001B990
		// (set) Token: 0x06001694 RID: 5780 RVA: 0x0001D798 File Offset: 0x0001B998
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

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x06001695 RID: 5781 RVA: 0x0001D7A4 File Offset: 0x0001B9A4
		// (set) Token: 0x06001696 RID: 5782 RVA: 0x0001D7AC File Offset: 0x0001B9AC
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

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x06001697 RID: 5783 RVA: 0x0001D7B8 File Offset: 0x0001B9B8
		// (set) Token: 0x06001698 RID: 5784 RVA: 0x0001D7C0 File Offset: 0x0001B9C0
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

		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x06001699 RID: 5785 RVA: 0x0001D7CC File Offset: 0x0001B9CC
		// (set) Token: 0x0600169A RID: 5786 RVA: 0x0001D7D4 File Offset: 0x0001B9D4
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

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x0600169B RID: 5787 RVA: 0x0001D7E0 File Offset: 0x0001B9E0
		// (set) Token: 0x0600169C RID: 5788 RVA: 0x0001D7E8 File Offset: 0x0001B9E8
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

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x0600169D RID: 5789 RVA: 0x0001D7F4 File Offset: 0x0001B9F4
		// (set) Token: 0x0600169E RID: 5790 RVA: 0x0001D7FC File Offset: 0x0001B9FC
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

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x0600169F RID: 5791 RVA: 0x0001D808 File Offset: 0x0001BA08
		// (set) Token: 0x060016A0 RID: 5792 RVA: 0x0001D810 File Offset: 0x0001BA10
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

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x060016A1 RID: 5793 RVA: 0x0001D81C File Offset: 0x0001BA1C
		// (set) Token: 0x060016A2 RID: 5794 RVA: 0x0001D824 File Offset: 0x0001BA24
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

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x0001D830 File Offset: 0x0001BA30
		// (set) Token: 0x060016A4 RID: 5796 RVA: 0x0001D838 File Offset: 0x0001BA38
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

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x060016A5 RID: 5797 RVA: 0x0001D844 File Offset: 0x0001BA44
		// (set) Token: 0x060016A6 RID: 5798 RVA: 0x0001D84C File Offset: 0x0001BA4C
		public ReferenceType DefaultValue
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

		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x060016A7 RID: 5799 RVA: 0x0001D858 File Offset: 0x0001BA58
		// (set) Token: 0x060016A8 RID: 5800 RVA: 0x0001D860 File Offset: 0x0001BA60
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

		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x060016A9 RID: 5801 RVA: 0x0001D86C File Offset: 0x0001BA6C
		// (set) Token: 0x060016AA RID: 5802 RVA: 0x0001D874 File Offset: 0x0001BA74
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

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x060016AB RID: 5803 RVA: 0x0001D880 File Offset: 0x0001BA80
		// (set) Token: 0x060016AC RID: 5804 RVA: 0x0001D888 File Offset: 0x0001BA88
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

		// Token: 0x04000C6E RID: 3182
		private LocalizableTextType displayNameField;

		// Token: 0x04000C6F RID: 3183
		private string colorField;

		// Token: 0x04000C70 RID: 3184
		private string technicalNameField;

		// Token: 0x04000C71 RID: 3185
		private string tooltipTextField;

		// Token: 0x04000C72 RID: 3186
		private int isMandatoryField;

		// Token: 0x04000C73 RID: 3187
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000C74 RID: 3188
		private int isLocalizedField;

		// Token: 0x04000C75 RID: 3189
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000C76 RID: 3190
		private string placeholderValueField;

		// Token: 0x04000C77 RID: 3191
		private ReferenceType defaultValueField;

		// Token: 0x04000C78 RID: 3192
		private ObjectTypes objectTypesField;

		// Token: 0x04000C79 RID: 3193
		private string idField;

		// Token: 0x04000C7A RID: 3194
		private string basedOnField;
	}
}
