using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200008F RID: 143
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ObjectTemplateDefinitionType
	{
		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0000FE78 File Offset: 0x0000E078
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0000FE80 File Offset: 0x0000E080
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

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0000FE8C File Offset: 0x0000E08C
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x0000FE94 File Offset: 0x0000E094
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

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0000FEA0 File Offset: 0x0000E0A0
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0000FEA8 File Offset: 0x0000E0A8
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

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0000FEB4 File Offset: 0x0000E0B4
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x0000FEBC File Offset: 0x0000E0BC
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

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0000FEC8 File Offset: 0x0000E0C8
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0000FED0 File Offset: 0x0000E0D0
		public FeatureDefinitionsType FeatureDefinitions
		{
			get
			{
				return this.featureDefinitionsField;
			}
			set
			{
				this.featureDefinitionsField = value;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0000FEDC File Offset: 0x0000E0DC
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x0000FEE4 File Offset: 0x0000E0E4
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

		// Token: 0x040002D9 RID: 729
		private LocalizableTextType displayNameField;

		// Token: 0x040002DA RID: 730
		private string colorField;

		// Token: 0x040002DB RID: 731
		private string externalIdField;

		// Token: 0x040002DC RID: 732
		private string shortIdField;

		// Token: 0x040002DD RID: 733
		private FeatureDefinitionsType featureDefinitionsField;

		// Token: 0x040002DE RID: 734
		private string guidField;
	}
}
