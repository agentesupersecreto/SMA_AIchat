using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F6 RID: 246
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ReferenceStripPropertyDefinitionType
	{
		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000A31 RID: 2609 RVA: 0x000139D0 File Offset: 0x00011BD0
		// (set) Token: 0x06000A32 RID: 2610 RVA: 0x000139D8 File Offset: 0x00011BD8
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

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x000139E4 File Offset: 0x00011BE4
		// (set) Token: 0x06000A34 RID: 2612 RVA: 0x000139EC File Offset: 0x00011BEC
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

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000A35 RID: 2613 RVA: 0x000139F8 File Offset: 0x00011BF8
		// (set) Token: 0x06000A36 RID: 2614 RVA: 0x00013A00 File Offset: 0x00011C00
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

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000A37 RID: 2615 RVA: 0x00013A0C File Offset: 0x00011C0C
		// (set) Token: 0x06000A38 RID: 2616 RVA: 0x00013A14 File Offset: 0x00011C14
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

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00013A20 File Offset: 0x00011C20
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x00013A28 File Offset: 0x00011C28
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

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x00013A34 File Offset: 0x00011C34
		// (set) Token: 0x06000A3C RID: 2620 RVA: 0x00013A3C File Offset: 0x00011C3C
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

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000A3D RID: 2621 RVA: 0x00013A48 File Offset: 0x00011C48
		// (set) Token: 0x06000A3E RID: 2622 RVA: 0x00013A50 File Offset: 0x00011C50
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

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x00013A5C File Offset: 0x00011C5C
		// (set) Token: 0x06000A40 RID: 2624 RVA: 0x00013A64 File Offset: 0x00011C64
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

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00013A70 File Offset: 0x00011C70
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x00013A78 File Offset: 0x00011C78
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

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00013A84 File Offset: 0x00011C84
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x00013A8C File Offset: 0x00011C8C
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

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x00013A98 File Offset: 0x00011C98
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x00013AA0 File Offset: 0x00011CA0
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

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x00013AAC File Offset: 0x00011CAC
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x00013AB4 File Offset: 0x00011CB4
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

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00013AC0 File Offset: 0x00011CC0
		// (set) Token: 0x06000A4A RID: 2634 RVA: 0x00013AC8 File Offset: 0x00011CC8
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

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00013AD4 File Offset: 0x00011CD4
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x00013ADC File Offset: 0x00011CDC
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

		// Token: 0x0400057D RID: 1405
		private LocalizableTextType displayNameField;

		// Token: 0x0400057E RID: 1406
		private string colorField;

		// Token: 0x0400057F RID: 1407
		private string technicalNameField;

		// Token: 0x04000580 RID: 1408
		private string tooltipTextField;

		// Token: 0x04000581 RID: 1409
		private int isMandatoryField;

		// Token: 0x04000582 RID: 1410
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000583 RID: 1411
		private int isLocalizedField;

		// Token: 0x04000584 RID: 1412
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000585 RID: 1413
		private string placeholderValueField;

		// Token: 0x04000586 RID: 1414
		private int maxReferenceCountField;

		// Token: 0x04000587 RID: 1415
		private bool maxReferenceCountFieldSpecified;

		// Token: 0x04000588 RID: 1416
		private ObjectTypes objectTypesField;

		// Token: 0x04000589 RID: 1417
		private string idField;

		// Token: 0x0400058A RID: 1418
		private string basedOnField;
	}
}
