using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B9 RID: 441
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class FlowFragmentType
	{
		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x0600139F RID: 5023 RVA: 0x0001BA34 File Offset: 0x00019C34
		// (set) Token: 0x060013A0 RID: 5024 RVA: 0x0001BA3C File Offset: 0x00019C3C
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

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x060013A1 RID: 5025 RVA: 0x0001BA48 File Offset: 0x00019C48
		// (set) Token: 0x060013A2 RID: 5026 RVA: 0x0001BA50 File Offset: 0x00019C50
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

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x0001BA5C File Offset: 0x00019C5C
		// (set) Token: 0x060013A4 RID: 5028 RVA: 0x0001BA64 File Offset: 0x00019C64
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

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x060013A5 RID: 5029 RVA: 0x0001BA70 File Offset: 0x00019C70
		// (set) Token: 0x060013A6 RID: 5030 RVA: 0x0001BA78 File Offset: 0x00019C78
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

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x060013A7 RID: 5031 RVA: 0x0001BA84 File Offset: 0x00019C84
		// (set) Token: 0x060013A8 RID: 5032 RVA: 0x0001BA8C File Offset: 0x00019C8C
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

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x060013A9 RID: 5033 RVA: 0x0001BA98 File Offset: 0x00019C98
		// (set) Token: 0x060013AA RID: 5034 RVA: 0x0001BAA0 File Offset: 0x00019CA0
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

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x060013AB RID: 5035 RVA: 0x0001BAAC File Offset: 0x00019CAC
		// (set) Token: 0x060013AC RID: 5036 RVA: 0x0001BAB4 File Offset: 0x00019CB4
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

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x060013AD RID: 5037 RVA: 0x0001BAC0 File Offset: 0x00019CC0
		// (set) Token: 0x060013AE RID: 5038 RVA: 0x0001BAC8 File Offset: 0x00019CC8
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

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x060013AF RID: 5039 RVA: 0x0001BAD4 File Offset: 0x00019CD4
		// (set) Token: 0x060013B0 RID: 5040 RVA: 0x0001BADC File Offset: 0x00019CDC
		public ReferencesType References
		{
			get
			{
				return this.referencesField;
			}
			set
			{
				this.referencesField = value;
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x060013B1 RID: 5041 RVA: 0x0001BAE8 File Offset: 0x00019CE8
		// (set) Token: 0x060013B2 RID: 5042 RVA: 0x0001BAF0 File Offset: 0x00019CF0
		public PreviewImageType PreviewImage
		{
			get
			{
				return this.previewImageField;
			}
			set
			{
				this.previewImageField = value;
			}
		}

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x060013B3 RID: 5043 RVA: 0x0001BAFC File Offset: 0x00019CFC
		// (set) Token: 0x060013B4 RID: 5044 RVA: 0x0001BB04 File Offset: 0x00019D04
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

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x060013B5 RID: 5045 RVA: 0x0001BB10 File Offset: 0x00019D10
		// (set) Token: 0x060013B6 RID: 5046 RVA: 0x0001BB18 File Offset: 0x00019D18
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

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x060013B7 RID: 5047 RVA: 0x0001BB24 File Offset: 0x00019D24
		// (set) Token: 0x060013B8 RID: 5048 RVA: 0x0001BB2C File Offset: 0x00019D2C
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

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x0001BB38 File Offset: 0x00019D38
		// (set) Token: 0x060013BA RID: 5050 RVA: 0x0001BB40 File Offset: 0x00019D40
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

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x060013BB RID: 5051 RVA: 0x0001BB4C File Offset: 0x00019D4C
		// (set) Token: 0x060013BC RID: 5052 RVA: 0x0001BB54 File Offset: 0x00019D54
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

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x060013BD RID: 5053 RVA: 0x0001BB60 File Offset: 0x00019D60
		// (set) Token: 0x060013BE RID: 5054 RVA: 0x0001BB68 File Offset: 0x00019D68
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

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x060013BF RID: 5055 RVA: 0x0001BB74 File Offset: 0x00019D74
		// (set) Token: 0x060013C0 RID: 5056 RVA: 0x0001BB7C File Offset: 0x00019D7C
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

		// Token: 0x04000AAF RID: 2735
		private LocalizableTextType displayNameField;

		// Token: 0x04000AB0 RID: 2736
		private LocalizableTextType textField;

		// Token: 0x04000AB1 RID: 2737
		private string colorField;

		// Token: 0x04000AB2 RID: 2738
		private string technicalNameField;

		// Token: 0x04000AB3 RID: 2739
		private string externalIdField;

		// Token: 0x04000AB4 RID: 2740
		private string shortIdField;

		// Token: 0x04000AB5 RID: 2741
		private string urlField;

		// Token: 0x04000AB6 RID: 2742
		private FeaturesType featuresField;

		// Token: 0x04000AB7 RID: 2743
		private ReferencesType referencesField;

		// Token: 0x04000AB8 RID: 2744
		private PreviewImageType previewImageField;

		// Token: 0x04000AB9 RID: 2745
		private PinsType pinsField;

		// Token: 0x04000ABA RID: 2746
		private PointType positionField;

		// Token: 0x04000ABB RID: 2747
		private SizeType sizeField;

		// Token: 0x04000ABC RID: 2748
		private float zIndexField;

		// Token: 0x04000ABD RID: 2749
		private string idField;

		// Token: 0x04000ABE RID: 2750
		private string objectTemplateReferenceField;

		// Token: 0x04000ABF RID: 2751
		private string objectTemplateReferenceNameField;
	}
}
