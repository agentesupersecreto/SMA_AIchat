using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000FC RID: 252
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ReferenceSlotPropertyDefinitionType
	{
		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000A66 RID: 2662 RVA: 0x00013BD8 File Offset: 0x00011DD8
		// (set) Token: 0x06000A67 RID: 2663 RVA: 0x00013BE0 File Offset: 0x00011DE0
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

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x00013BEC File Offset: 0x00011DEC
		// (set) Token: 0x06000A69 RID: 2665 RVA: 0x00013BF4 File Offset: 0x00011DF4
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

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x00013C00 File Offset: 0x00011E00
		// (set) Token: 0x06000A6B RID: 2667 RVA: 0x00013C08 File Offset: 0x00011E08
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

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00013C14 File Offset: 0x00011E14
		// (set) Token: 0x06000A6D RID: 2669 RVA: 0x00013C1C File Offset: 0x00011E1C
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

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x00013C28 File Offset: 0x00011E28
		// (set) Token: 0x06000A6F RID: 2671 RVA: 0x00013C30 File Offset: 0x00011E30
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

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x00013C3C File Offset: 0x00011E3C
		// (set) Token: 0x06000A71 RID: 2673 RVA: 0x00013C44 File Offset: 0x00011E44
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

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x00013C50 File Offset: 0x00011E50
		// (set) Token: 0x06000A73 RID: 2675 RVA: 0x00013C58 File Offset: 0x00011E58
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

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00013C64 File Offset: 0x00011E64
		// (set) Token: 0x06000A75 RID: 2677 RVA: 0x00013C6C File Offset: 0x00011E6C
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

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00013C78 File Offset: 0x00011E78
		// (set) Token: 0x06000A77 RID: 2679 RVA: 0x00013C80 File Offset: 0x00011E80
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

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000A78 RID: 2680 RVA: 0x00013C8C File Offset: 0x00011E8C
		// (set) Token: 0x06000A79 RID: 2681 RVA: 0x00013C94 File Offset: 0x00011E94
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

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000A7A RID: 2682 RVA: 0x00013CA0 File Offset: 0x00011EA0
		// (set) Token: 0x06000A7B RID: 2683 RVA: 0x00013CA8 File Offset: 0x00011EA8
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

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000A7C RID: 2684 RVA: 0x00013CB4 File Offset: 0x00011EB4
		// (set) Token: 0x06000A7D RID: 2685 RVA: 0x00013CBC File Offset: 0x00011EBC
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

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000A7E RID: 2686 RVA: 0x00013CC8 File Offset: 0x00011EC8
		// (set) Token: 0x06000A7F RID: 2687 RVA: 0x00013CD0 File Offset: 0x00011ED0
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

		// Token: 0x0400059B RID: 1435
		private LocalizableTextType displayNameField;

		// Token: 0x0400059C RID: 1436
		private string colorField;

		// Token: 0x0400059D RID: 1437
		private string technicalNameField;

		// Token: 0x0400059E RID: 1438
		private string tooltipTextField;

		// Token: 0x0400059F RID: 1439
		private int isMandatoryField;

		// Token: 0x040005A0 RID: 1440
		private bool isMandatoryFieldSpecified;

		// Token: 0x040005A1 RID: 1441
		private int isLocalizedField;

		// Token: 0x040005A2 RID: 1442
		private bool isLocalizedFieldSpecified;

		// Token: 0x040005A3 RID: 1443
		private string placeholderValueField;

		// Token: 0x040005A4 RID: 1444
		private ReferenceType defaultValueField;

		// Token: 0x040005A5 RID: 1445
		private ObjectTypes objectTypesField;

		// Token: 0x040005A6 RID: 1446
		private string idField;

		// Token: 0x040005A7 RID: 1447
		private string basedOnField;
	}
}
