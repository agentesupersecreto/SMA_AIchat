using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001AF RID: 431
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class DialogueType
	{
		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x0001B2DC File Offset: 0x000194DC
		// (set) Token: 0x060012E2 RID: 4834 RVA: 0x0001B2E4 File Offset: 0x000194E4
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

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x0001B2F0 File Offset: 0x000194F0
		// (set) Token: 0x060012E4 RID: 4836 RVA: 0x0001B2F8 File Offset: 0x000194F8
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

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x0001B304 File Offset: 0x00019504
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x0001B30C File Offset: 0x0001950C
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

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x0001B318 File Offset: 0x00019518
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x0001B320 File Offset: 0x00019520
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

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x0001B32C File Offset: 0x0001952C
		// (set) Token: 0x060012EA RID: 4842 RVA: 0x0001B334 File Offset: 0x00019534
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

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x0001B340 File Offset: 0x00019540
		// (set) Token: 0x060012EC RID: 4844 RVA: 0x0001B348 File Offset: 0x00019548
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

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x0001B354 File Offset: 0x00019554
		// (set) Token: 0x060012EE RID: 4846 RVA: 0x0001B35C File Offset: 0x0001955C
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

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x0001B368 File Offset: 0x00019568
		// (set) Token: 0x060012F0 RID: 4848 RVA: 0x0001B370 File Offset: 0x00019570
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

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x0001B37C File Offset: 0x0001957C
		// (set) Token: 0x060012F2 RID: 4850 RVA: 0x0001B384 File Offset: 0x00019584
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

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x060012F3 RID: 4851 RVA: 0x0001B390 File Offset: 0x00019590
		// (set) Token: 0x060012F4 RID: 4852 RVA: 0x0001B398 File Offset: 0x00019598
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

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x060012F5 RID: 4853 RVA: 0x0001B3A4 File Offset: 0x000195A4
		// (set) Token: 0x060012F6 RID: 4854 RVA: 0x0001B3AC File Offset: 0x000195AC
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

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x060012F7 RID: 4855 RVA: 0x0001B3B8 File Offset: 0x000195B8
		// (set) Token: 0x060012F8 RID: 4856 RVA: 0x0001B3C0 File Offset: 0x000195C0
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

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x060012F9 RID: 4857 RVA: 0x0001B3CC File Offset: 0x000195CC
		// (set) Token: 0x060012FA RID: 4858 RVA: 0x0001B3D4 File Offset: 0x000195D4
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

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x060012FB RID: 4859 RVA: 0x0001B3E0 File Offset: 0x000195E0
		// (set) Token: 0x060012FC RID: 4860 RVA: 0x0001B3E8 File Offset: 0x000195E8
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

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x060012FD RID: 4861 RVA: 0x0001B3F4 File Offset: 0x000195F4
		// (set) Token: 0x060012FE RID: 4862 RVA: 0x0001B3FC File Offset: 0x000195FC
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

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x060012FF RID: 4863 RVA: 0x0001B408 File Offset: 0x00019608
		// (set) Token: 0x06001300 RID: 4864 RVA: 0x0001B410 File Offset: 0x00019610
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

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06001301 RID: 4865 RVA: 0x0001B41C File Offset: 0x0001961C
		// (set) Token: 0x06001302 RID: 4866 RVA: 0x0001B424 File Offset: 0x00019624
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

		// Token: 0x04000A55 RID: 2645
		private LocalizableTextType displayNameField;

		// Token: 0x04000A56 RID: 2646
		private LocalizableTextType textField;

		// Token: 0x04000A57 RID: 2647
		private string colorField;

		// Token: 0x04000A58 RID: 2648
		private string technicalNameField;

		// Token: 0x04000A59 RID: 2649
		private string externalIdField;

		// Token: 0x04000A5A RID: 2650
		private string shortIdField;

		// Token: 0x04000A5B RID: 2651
		private string urlField;

		// Token: 0x04000A5C RID: 2652
		private FeaturesType featuresField;

		// Token: 0x04000A5D RID: 2653
		private ReferencesType referencesField;

		// Token: 0x04000A5E RID: 2654
		private PreviewImageType previewImageField;

		// Token: 0x04000A5F RID: 2655
		private PinsType pinsField;

		// Token: 0x04000A60 RID: 2656
		private PointType positionField;

		// Token: 0x04000A61 RID: 2657
		private SizeType sizeField;

		// Token: 0x04000A62 RID: 2658
		private float zIndexField;

		// Token: 0x04000A63 RID: 2659
		private string idField;

		// Token: 0x04000A64 RID: 2660
		private string objectTemplateReferenceField;

		// Token: 0x04000A65 RID: 2661
		private string objectTemplateReferenceNameField;
	}
}
