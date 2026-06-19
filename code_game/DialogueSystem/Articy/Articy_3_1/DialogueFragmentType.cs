using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B0 RID: 432
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class DialogueFragmentType
	{
		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06001304 RID: 4868 RVA: 0x0001B438 File Offset: 0x00019638
		// (set) Token: 0x06001305 RID: 4869 RVA: 0x0001B440 File Offset: 0x00019640
		public string DisplayName
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

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06001306 RID: 4870 RVA: 0x0001B44C File Offset: 0x0001964C
		// (set) Token: 0x06001307 RID: 4871 RVA: 0x0001B454 File Offset: 0x00019654
		public LocalizableTextType Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06001308 RID: 4872 RVA: 0x0001B460 File Offset: 0x00019660
		// (set) Token: 0x06001309 RID: 4873 RVA: 0x0001B468 File Offset: 0x00019668
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

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x0600130A RID: 4874 RVA: 0x0001B474 File Offset: 0x00019674
		// (set) Token: 0x0600130B RID: 4875 RVA: 0x0001B47C File Offset: 0x0001967C
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

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x0600130C RID: 4876 RVA: 0x0001B488 File Offset: 0x00019688
		// (set) Token: 0x0600130D RID: 4877 RVA: 0x0001B490 File Offset: 0x00019690
		public string ExternalId
		{
			get
			{
				return this.externalIdField;
			}
			set
			{
				this.externalIdField = value;
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x0600130E RID: 4878 RVA: 0x0001B49C File Offset: 0x0001969C
		// (set) Token: 0x0600130F RID: 4879 RVA: 0x0001B4A4 File Offset: 0x000196A4
		public string ShortId
		{
			get
			{
				return this.shortIdField;
			}
			set
			{
				this.shortIdField = value;
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06001310 RID: 4880 RVA: 0x0001B4B0 File Offset: 0x000196B0
		// (set) Token: 0x06001311 RID: 4881 RVA: 0x0001B4B8 File Offset: 0x000196B8
		public string Url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x0001B4C4 File Offset: 0x000196C4
		// (set) Token: 0x06001313 RID: 4883 RVA: 0x0001B4CC File Offset: 0x000196CC
		public FeaturesType Features
		{
			get
			{
				return this.featuresField;
			}
			set
			{
				this.featuresField = value;
			}
		}

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x0001B4D8 File Offset: 0x000196D8
		// (set) Token: 0x06001315 RID: 4885 RVA: 0x0001B4E0 File Offset: 0x000196E0
		public PinsType Pins
		{
			get
			{
				return this.pinsField;
			}
			set
			{
				this.pinsField = value;
			}
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x0001B4EC File Offset: 0x000196EC
		// (set) Token: 0x06001317 RID: 4887 RVA: 0x0001B4F4 File Offset: 0x000196F4
		public PointType Position
		{
			get
			{
				return this.positionField;
			}
			set
			{
				this.positionField = value;
			}
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06001318 RID: 4888 RVA: 0x0001B500 File Offset: 0x00019700
		// (set) Token: 0x06001319 RID: 4889 RVA: 0x0001B508 File Offset: 0x00019708
		public SizeType Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x0600131A RID: 4890 RVA: 0x0001B514 File Offset: 0x00019714
		// (set) Token: 0x0600131B RID: 4891 RVA: 0x0001B51C File Offset: 0x0001971C
		public float ZIndex
		{
			get
			{
				return this.zIndexField;
			}
			set
			{
				this.zIndexField = value;
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x0600131C RID: 4892 RVA: 0x0001B528 File Offset: 0x00019728
		// (set) Token: 0x0600131D RID: 4893 RVA: 0x0001B530 File Offset: 0x00019730
		public ReferenceType Speaker
		{
			get
			{
				return this.speakerField;
			}
			set
			{
				this.speakerField = value;
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x0600131E RID: 4894 RVA: 0x0001B53C File Offset: 0x0001973C
		// (set) Token: 0x0600131F RID: 4895 RVA: 0x0001B544 File Offset: 0x00019744
		public LocalizableTextType StageDirections
		{
			get
			{
				return this.stageDirectionsField;
			}
			set
			{
				this.stageDirectionsField = value;
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06001320 RID: 4896 RVA: 0x0001B550 File Offset: 0x00019750
		// (set) Token: 0x06001321 RID: 4897 RVA: 0x0001B558 File Offset: 0x00019758
		public LocalizableTextType MenuText
		{
			get
			{
				return this.menuTextField;
			}
			set
			{
				this.menuTextField = value;
			}
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06001322 RID: 4898 RVA: 0x0001B564 File Offset: 0x00019764
		// (set) Token: 0x06001323 RID: 4899 RVA: 0x0001B56C File Offset: 0x0001976C
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

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x0001B578 File Offset: 0x00019778
		// (set) Token: 0x06001325 RID: 4901 RVA: 0x0001B580 File Offset: 0x00019780
		[XmlAttribute]
		public string ObjectTemplateReference
		{
			get
			{
				return this.objectTemplateReferenceField;
			}
			set
			{
				this.objectTemplateReferenceField = value;
			}
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06001326 RID: 4902 RVA: 0x0001B58C File Offset: 0x0001978C
		// (set) Token: 0x06001327 RID: 4903 RVA: 0x0001B594 File Offset: 0x00019794
		[XmlAttribute]
		public string ObjectTemplateReferenceName
		{
			get
			{
				return this.objectTemplateReferenceNameField;
			}
			set
			{
				this.objectTemplateReferenceNameField = value;
			}
		}

		// Token: 0x04000A66 RID: 2662
		private string displayNameField;

		// Token: 0x04000A67 RID: 2663
		private LocalizableTextType textField;

		// Token: 0x04000A68 RID: 2664
		private string colorField;

		// Token: 0x04000A69 RID: 2665
		private string technicalNameField;

		// Token: 0x04000A6A RID: 2666
		private string externalIdField;

		// Token: 0x04000A6B RID: 2667
		private string shortIdField;

		// Token: 0x04000A6C RID: 2668
		private string urlField;

		// Token: 0x04000A6D RID: 2669
		private FeaturesType featuresField;

		// Token: 0x04000A6E RID: 2670
		private PinsType pinsField;

		// Token: 0x04000A6F RID: 2671
		private PointType positionField;

		// Token: 0x04000A70 RID: 2672
		private SizeType sizeField;

		// Token: 0x04000A71 RID: 2673
		private float zIndexField;

		// Token: 0x04000A72 RID: 2674
		private ReferenceType speakerField;

		// Token: 0x04000A73 RID: 2675
		private LocalizableTextType stageDirectionsField;

		// Token: 0x04000A74 RID: 2676
		private LocalizableTextType menuTextField;

		// Token: 0x04000A75 RID: 2677
		private string idField;

		// Token: 0x04000A76 RID: 2678
		private string objectTemplateReferenceField;

		// Token: 0x04000A77 RID: 2679
		private string objectTemplateReferenceNameField;
	}
}
