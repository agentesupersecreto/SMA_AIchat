using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000DE RID: 222
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class LocationGroupType
	{
		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600089D RID: 2205 RVA: 0x00012A34 File Offset: 0x00010C34
		// (set) Token: 0x0600089E RID: 2206 RVA: 0x00012A3C File Offset: 0x00010C3C
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

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x00012A48 File Offset: 0x00010C48
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x00012A50 File Offset: 0x00010C50
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

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x00012A5C File Offset: 0x00010C5C
		// (set) Token: 0x060008A2 RID: 2210 RVA: 0x00012A64 File Offset: 0x00010C64
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

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x00012A70 File Offset: 0x00010C70
		// (set) Token: 0x060008A4 RID: 2212 RVA: 0x00012A78 File Offset: 0x00010C78
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

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x00012A84 File Offset: 0x00010C84
		// (set) Token: 0x060008A6 RID: 2214 RVA: 0x00012A8C File Offset: 0x00010C8C
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

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00012A98 File Offset: 0x00010C98
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x00012AA0 File Offset: 0x00010CA0
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

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x00012AAC File Offset: 0x00010CAC
		// (set) Token: 0x060008AA RID: 2218 RVA: 0x00012AB4 File Offset: 0x00010CB4
		public VisibilityType Visibility
		{
			get
			{
				return this.visibilityField;
			}
			set
			{
				this.visibilityField = value;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x00012AC0 File Offset: 0x00010CC0
		// (set) Token: 0x060008AC RID: 2220 RVA: 0x00012AC8 File Offset: 0x00010CC8
		public SelectabilityType Selectability
		{
			get
			{
				return this.selectabilityField;
			}
			set
			{
				this.selectabilityField = value;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x00012AD4 File Offset: 0x00010CD4
		// (set) Token: 0x060008AE RID: 2222 RVA: 0x00012ADC File Offset: 0x00010CDC
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

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x00012AE8 File Offset: 0x00010CE8
		// (set) Token: 0x060008B0 RID: 2224 RVA: 0x00012AF0 File Offset: 0x00010CF0
		[XmlAttribute]
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

		// Token: 0x040004B7 RID: 1207
		private LocalizableTextType displayNameField;

		// Token: 0x040004B8 RID: 1208
		private LocalizableTextType textField;

		// Token: 0x040004B9 RID: 1209
		private string colorField;

		// Token: 0x040004BA RID: 1210
		private string technicalNameField;

		// Token: 0x040004BB RID: 1211
		private string externalIdField;

		// Token: 0x040004BC RID: 1212
		private string shortIdField;

		// Token: 0x040004BD RID: 1213
		private VisibilityType visibilityField;

		// Token: 0x040004BE RID: 1214
		private SelectabilityType selectabilityField;

		// Token: 0x040004BF RID: 1215
		private string idField;

		// Token: 0x040004C0 RID: 1216
		private float zIndexField;
	}
}
