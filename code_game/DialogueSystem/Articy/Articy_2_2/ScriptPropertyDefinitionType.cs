using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F0 RID: 240
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ScriptPropertyDefinitionType
	{
		// Token: 0x170003AA RID: 938
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x00013624 File Offset: 0x00011824
		// (set) Token: 0x060009D3 RID: 2515 RVA: 0x0001362C File Offset: 0x0001182C
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

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x00013638 File Offset: 0x00011838
		// (set) Token: 0x060009D5 RID: 2517 RVA: 0x00013640 File Offset: 0x00011840
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

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x0001364C File Offset: 0x0001184C
		// (set) Token: 0x060009D7 RID: 2519 RVA: 0x00013654 File Offset: 0x00011854
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

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x00013660 File Offset: 0x00011860
		// (set) Token: 0x060009D9 RID: 2521 RVA: 0x00013668 File Offset: 0x00011868
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

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00013674 File Offset: 0x00011874
		// (set) Token: 0x060009DB RID: 2523 RVA: 0x0001367C File Offset: 0x0001187C
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

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x00013688 File Offset: 0x00011888
		// (set) Token: 0x060009DD RID: 2525 RVA: 0x00013690 File Offset: 0x00011890
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

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x0001369C File Offset: 0x0001189C
		// (set) Token: 0x060009DF RID: 2527 RVA: 0x000136A4 File Offset: 0x000118A4
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

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x000136B0 File Offset: 0x000118B0
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x000136B8 File Offset: 0x000118B8
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

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x000136C4 File Offset: 0x000118C4
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x000136CC File Offset: 0x000118CC
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

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x000136D8 File Offset: 0x000118D8
		// (set) Token: 0x060009E5 RID: 2533 RVA: 0x000136E0 File Offset: 0x000118E0
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

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x000136EC File Offset: 0x000118EC
		// (set) Token: 0x060009E7 RID: 2535 RVA: 0x000136F4 File Offset: 0x000118F4
		public ScriptTypeType ScriptType
		{
			get
			{
				return this.scriptTypeField;
			}
			set
			{
				this.scriptTypeField = value;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x00013700 File Offset: 0x00011900
		// (set) Token: 0x060009E9 RID: 2537 RVA: 0x00013708 File Offset: 0x00011908
		[XmlIgnore]
		public bool ScriptTypeSpecified
		{
			get
			{
				return this.scriptTypeFieldSpecified;
			}
			set
			{
				this.scriptTypeFieldSpecified = value;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x00013714 File Offset: 0x00011914
		// (set) Token: 0x060009EB RID: 2539 RVA: 0x0001371C File Offset: 0x0001191C
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

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x00013728 File Offset: 0x00011928
		// (set) Token: 0x060009ED RID: 2541 RVA: 0x00013730 File Offset: 0x00011930
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

		// Token: 0x0400054C RID: 1356
		private LocalizableTextType displayNameField;

		// Token: 0x0400054D RID: 1357
		private string colorField;

		// Token: 0x0400054E RID: 1358
		private string technicalNameField;

		// Token: 0x0400054F RID: 1359
		private string tooltipTextField;

		// Token: 0x04000550 RID: 1360
		private int isMandatoryField;

		// Token: 0x04000551 RID: 1361
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000552 RID: 1362
		private int isLocalizedField;

		// Token: 0x04000553 RID: 1363
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000554 RID: 1364
		private string placeholderValueField;

		// Token: 0x04000555 RID: 1365
		private string defaultValueField;

		// Token: 0x04000556 RID: 1366
		private ScriptTypeType scriptTypeField;

		// Token: 0x04000557 RID: 1367
		private bool scriptTypeFieldSpecified;

		// Token: 0x04000558 RID: 1368
		private string idField;

		// Token: 0x04000559 RID: 1369
		private string basedOnField;
	}
}
