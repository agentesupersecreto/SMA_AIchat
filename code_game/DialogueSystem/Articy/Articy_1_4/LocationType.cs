using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000081 RID: 129
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocationType
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000F5C8 File Offset: 0x0000D7C8
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
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

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000F5DC File Offset: 0x0000D7DC
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x0000F5E4 File Offset: 0x0000D7E4
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

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000F5F0 File Offset: 0x0000D7F0
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
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

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000F604 File Offset: 0x0000D804
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x0000F60C File Offset: 0x0000D80C
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

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000F618 File Offset: 0x0000D818
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x0000F620 File Offset: 0x0000D820
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

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0000F62C File Offset: 0x0000D82C
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x0000F634 File Offset: 0x0000D834
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

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x0000F640 File Offset: 0x0000D840
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x0000F648 File Offset: 0x0000D848
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

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0000F654 File Offset: 0x0000D854
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x0000F65C File Offset: 0x0000D85C
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

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000F668 File Offset: 0x0000D868
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x0000F670 File Offset: 0x0000D870
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

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000F67C File Offset: 0x0000D87C
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x0000F684 File Offset: 0x0000D884
		public ReferenceType BackgroundImage
		{
			get
			{
				return this.backgroundImageField;
			}
			set
			{
				this.backgroundImageField = value;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000F690 File Offset: 0x0000D890
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x0000F698 File Offset: 0x0000D898
		public short BackgroundWidth
		{
			get
			{
				return this.backgroundWidthField;
			}
			set
			{
				this.backgroundWidthField = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000F6A4 File Offset: 0x0000D8A4
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x0000F6AC File Offset: 0x0000D8AC
		[XmlIgnore]
		public bool BackgroundWidthSpecified
		{
			get
			{
				return this.backgroundWidthFieldSpecified;
			}
			set
			{
				this.backgroundWidthFieldSpecified = value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x0000F6C0 File Offset: 0x0000D8C0
		public short BackgroundHeight
		{
			get
			{
				return this.backgroundHeightField;
			}
			set
			{
				this.backgroundHeightField = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000F6CC File Offset: 0x0000D8CC
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x0000F6D4 File Offset: 0x0000D8D4
		[XmlIgnore]
		public bool BackgroundHeightSpecified
		{
			get
			{
				return this.backgroundHeightFieldSpecified;
			}
			set
			{
				this.backgroundHeightFieldSpecified = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000F6E0 File Offset: 0x0000D8E0
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000F6E8 File Offset: 0x0000D8E8
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000F6FC File Offset: 0x0000D8FC
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

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000F708 File Offset: 0x0000D908
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0000F710 File Offset: 0x0000D910
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

		// Token: 0x0400026C RID: 620
		private LocalizableTextType displayNameField;

		// Token: 0x0400026D RID: 621
		private LocalizableTextType textField;

		// Token: 0x0400026E RID: 622
		private string colorField;

		// Token: 0x0400026F RID: 623
		private string technicalNameField;

		// Token: 0x04000270 RID: 624
		private string externalIdField;

		// Token: 0x04000271 RID: 625
		private string shortIdField;

		// Token: 0x04000272 RID: 626
		private FeaturesType featuresField;

		// Token: 0x04000273 RID: 627
		private ReferencesType referencesField;

		// Token: 0x04000274 RID: 628
		private PreviewImageType previewImageField;

		// Token: 0x04000275 RID: 629
		private ReferenceType backgroundImageField;

		// Token: 0x04000276 RID: 630
		private short backgroundWidthField;

		// Token: 0x04000277 RID: 631
		private bool backgroundWidthFieldSpecified;

		// Token: 0x04000278 RID: 632
		private short backgroundHeightField;

		// Token: 0x04000279 RID: 633
		private bool backgroundHeightFieldSpecified;

		// Token: 0x0400027A RID: 634
		private string guidField;

		// Token: 0x0400027B RID: 635
		private string objectTemplateReferenceField;

		// Token: 0x0400027C RID: 636
		private string objectTemplateReferenceNameField;
	}
}
