using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F5 RID: 245
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class QueryReferenceStripPropertyDefinitionType
	{
		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x000138D8 File Offset: 0x00011AD8
		// (set) Token: 0x06000A19 RID: 2585 RVA: 0x000138E0 File Offset: 0x00011AE0
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

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x000138EC File Offset: 0x00011AEC
		// (set) Token: 0x06000A1B RID: 2587 RVA: 0x000138F4 File Offset: 0x00011AF4
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

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x00013900 File Offset: 0x00011B00
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x00013908 File Offset: 0x00011B08
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

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x00013914 File Offset: 0x00011B14
		// (set) Token: 0x06000A1F RID: 2591 RVA: 0x0001391C File Offset: 0x00011B1C
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

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x00013928 File Offset: 0x00011B28
		// (set) Token: 0x06000A21 RID: 2593 RVA: 0x00013930 File Offset: 0x00011B30
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

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x0001393C File Offset: 0x00011B3C
		// (set) Token: 0x06000A23 RID: 2595 RVA: 0x00013944 File Offset: 0x00011B44
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

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00013950 File Offset: 0x00011B50
		// (set) Token: 0x06000A25 RID: 2597 RVA: 0x00013958 File Offset: 0x00011B58
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

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x00013964 File Offset: 0x00011B64
		// (set) Token: 0x06000A27 RID: 2599 RVA: 0x0001396C File Offset: 0x00011B6C
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

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000A28 RID: 2600 RVA: 0x00013978 File Offset: 0x00011B78
		// (set) Token: 0x06000A29 RID: 2601 RVA: 0x00013980 File Offset: 0x00011B80
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

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000A2A RID: 2602 RVA: 0x0001398C File Offset: 0x00011B8C
		// (set) Token: 0x06000A2B RID: 2603 RVA: 0x00013994 File Offset: 0x00011B94
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

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000A2C RID: 2604 RVA: 0x000139A0 File Offset: 0x00011BA0
		// (set) Token: 0x06000A2D RID: 2605 RVA: 0x000139A8 File Offset: 0x00011BA8
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

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x000139B4 File Offset: 0x00011BB4
		// (set) Token: 0x06000A2F RID: 2607 RVA: 0x000139BC File Offset: 0x00011BBC
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

		// Token: 0x04000571 RID: 1393
		private LocalizableTextType displayNameField;

		// Token: 0x04000572 RID: 1394
		private string colorField;

		// Token: 0x04000573 RID: 1395
		private string technicalNameField;

		// Token: 0x04000574 RID: 1396
		private string tooltipTextField;

		// Token: 0x04000575 RID: 1397
		private int isMandatoryField;

		// Token: 0x04000576 RID: 1398
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000577 RID: 1399
		private int isLocalizedField;

		// Token: 0x04000578 RID: 1400
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000579 RID: 1401
		private string placeholderValueField;

		// Token: 0x0400057A RID: 1402
		private string defaultValueField;

		// Token: 0x0400057B RID: 1403
		private string idField;

		// Token: 0x0400057C RID: 1404
		private string basedOnField;
	}
}
