using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001CE RID: 462
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class JumpType
	{
		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x06001476 RID: 5238 RVA: 0x0001C280 File Offset: 0x0001A480
		// (set) Token: 0x06001477 RID: 5239 RVA: 0x0001C288 File Offset: 0x0001A488
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

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06001478 RID: 5240 RVA: 0x0001C294 File Offset: 0x0001A494
		// (set) Token: 0x06001479 RID: 5241 RVA: 0x0001C29C File Offset: 0x0001A49C
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

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x0600147A RID: 5242 RVA: 0x0001C2A8 File Offset: 0x0001A4A8
		// (set) Token: 0x0600147B RID: 5243 RVA: 0x0001C2B0 File Offset: 0x0001A4B0
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

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x0600147C RID: 5244 RVA: 0x0001C2BC File Offset: 0x0001A4BC
		// (set) Token: 0x0600147D RID: 5245 RVA: 0x0001C2C4 File Offset: 0x0001A4C4
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

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x0600147E RID: 5246 RVA: 0x0001C2D0 File Offset: 0x0001A4D0
		// (set) Token: 0x0600147F RID: 5247 RVA: 0x0001C2D8 File Offset: 0x0001A4D8
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

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x06001480 RID: 5248 RVA: 0x0001C2E4 File Offset: 0x0001A4E4
		// (set) Token: 0x06001481 RID: 5249 RVA: 0x0001C2EC File Offset: 0x0001A4EC
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

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x06001482 RID: 5250 RVA: 0x0001C2F8 File Offset: 0x0001A4F8
		// (set) Token: 0x06001483 RID: 5251 RVA: 0x0001C300 File Offset: 0x0001A500
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

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x0001C30C File Offset: 0x0001A50C
		// (set) Token: 0x06001485 RID: 5253 RVA: 0x0001C314 File Offset: 0x0001A514
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

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x0001C320 File Offset: 0x0001A520
		// (set) Token: 0x06001487 RID: 5255 RVA: 0x0001C328 File Offset: 0x0001A528
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

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06001488 RID: 5256 RVA: 0x0001C334 File Offset: 0x0001A534
		// (set) Token: 0x06001489 RID: 5257 RVA: 0x0001C33C File Offset: 0x0001A53C
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

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x0600148A RID: 5258 RVA: 0x0001C348 File Offset: 0x0001A548
		// (set) Token: 0x0600148B RID: 5259 RVA: 0x0001C350 File Offset: 0x0001A550
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

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x0600148C RID: 5260 RVA: 0x0001C35C File Offset: 0x0001A55C
		// (set) Token: 0x0600148D RID: 5261 RVA: 0x0001C364 File Offset: 0x0001A564
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

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x0600148E RID: 5262 RVA: 0x0001C370 File Offset: 0x0001A570
		// (set) Token: 0x0600148F RID: 5263 RVA: 0x0001C378 File Offset: 0x0001A578
		public ConnectionRefType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06001490 RID: 5264 RVA: 0x0001C384 File Offset: 0x0001A584
		// (set) Token: 0x06001491 RID: 5265 RVA: 0x0001C38C File Offset: 0x0001A58C
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

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x0001C398 File Offset: 0x0001A598
		// (set) Token: 0x06001493 RID: 5267 RVA: 0x0001C3A0 File Offset: 0x0001A5A0
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

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x0001C3AC File Offset: 0x0001A5AC
		// (set) Token: 0x06001495 RID: 5269 RVA: 0x0001C3B4 File Offset: 0x0001A5B4
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

		// Token: 0x04000B3F RID: 2879
		private string displayNameField;

		// Token: 0x04000B40 RID: 2880
		private LocalizableTextType textField;

		// Token: 0x04000B41 RID: 2881
		private string colorField;

		// Token: 0x04000B42 RID: 2882
		private string technicalNameField;

		// Token: 0x04000B43 RID: 2883
		private string externalIdField;

		// Token: 0x04000B44 RID: 2884
		private string shortIdField;

		// Token: 0x04000B45 RID: 2885
		private string urlField;

		// Token: 0x04000B46 RID: 2886
		private FeaturesType featuresField;

		// Token: 0x04000B47 RID: 2887
		private PinsType pinsField;

		// Token: 0x04000B48 RID: 2888
		private PointType positionField;

		// Token: 0x04000B49 RID: 2889
		private SizeType sizeField;

		// Token: 0x04000B4A RID: 2890
		private float zIndexField;

		// Token: 0x04000B4B RID: 2891
		private ConnectionRefType targetField;

		// Token: 0x04000B4C RID: 2892
		private string idField;

		// Token: 0x04000B4D RID: 2893
		private string objectTemplateReferenceField;

		// Token: 0x04000B4E RID: 2894
		private string objectTemplateReferenceNameField;
	}
}
