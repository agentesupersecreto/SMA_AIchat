using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A7 RID: 423
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ConditionType
	{
		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x0001AFC0 File Offset: 0x000191C0
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x0001AFC8 File Offset: 0x000191C8
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

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06001292 RID: 4754 RVA: 0x0001AFD4 File Offset: 0x000191D4
		// (set) Token: 0x06001293 RID: 4755 RVA: 0x0001AFDC File Offset: 0x000191DC
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

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x0001AFE8 File Offset: 0x000191E8
		// (set) Token: 0x06001295 RID: 4757 RVA: 0x0001AFF0 File Offset: 0x000191F0
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

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x0001AFFC File Offset: 0x000191FC
		// (set) Token: 0x06001297 RID: 4759 RVA: 0x0001B004 File Offset: 0x00019204
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

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06001298 RID: 4760 RVA: 0x0001B010 File Offset: 0x00019210
		// (set) Token: 0x06001299 RID: 4761 RVA: 0x0001B018 File Offset: 0x00019218
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

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x0001B024 File Offset: 0x00019224
		// (set) Token: 0x0600129B RID: 4763 RVA: 0x0001B02C File Offset: 0x0001922C
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

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x0001B038 File Offset: 0x00019238
		// (set) Token: 0x0600129D RID: 4765 RVA: 0x0001B040 File Offset: 0x00019240
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

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x0600129E RID: 4766 RVA: 0x0001B04C File Offset: 0x0001924C
		// (set) Token: 0x0600129F RID: 4767 RVA: 0x0001B054 File Offset: 0x00019254
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

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x060012A0 RID: 4768 RVA: 0x0001B060 File Offset: 0x00019260
		// (set) Token: 0x060012A1 RID: 4769 RVA: 0x0001B068 File Offset: 0x00019268
		public string Expression
		{
			get
			{
				return this.expressionField;
			}
			set
			{
				this.expressionField = value;
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x060012A2 RID: 4770 RVA: 0x0001B074 File Offset: 0x00019274
		// (set) Token: 0x060012A3 RID: 4771 RVA: 0x0001B07C File Offset: 0x0001927C
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

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x060012A4 RID: 4772 RVA: 0x0001B088 File Offset: 0x00019288
		// (set) Token: 0x060012A5 RID: 4773 RVA: 0x0001B090 File Offset: 0x00019290
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

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x060012A6 RID: 4774 RVA: 0x0001B09C File Offset: 0x0001929C
		// (set) Token: 0x060012A7 RID: 4775 RVA: 0x0001B0A4 File Offset: 0x000192A4
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

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x060012A8 RID: 4776 RVA: 0x0001B0B0 File Offset: 0x000192B0
		// (set) Token: 0x060012A9 RID: 4777 RVA: 0x0001B0B8 File Offset: 0x000192B8
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

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x0001B0C4 File Offset: 0x000192C4
		// (set) Token: 0x060012AB RID: 4779 RVA: 0x0001B0CC File Offset: 0x000192CC
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

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x0001B0D8 File Offset: 0x000192D8
		// (set) Token: 0x060012AD RID: 4781 RVA: 0x0001B0E0 File Offset: 0x000192E0
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

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x0001B0EC File Offset: 0x000192EC
		// (set) Token: 0x060012AF RID: 4783 RVA: 0x0001B0F4 File Offset: 0x000192F4
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

		// Token: 0x04000A2D RID: 2605
		private string displayNameField;

		// Token: 0x04000A2E RID: 2606
		private LocalizableTextType textField;

		// Token: 0x04000A2F RID: 2607
		private string colorField;

		// Token: 0x04000A30 RID: 2608
		private string technicalNameField;

		// Token: 0x04000A31 RID: 2609
		private string externalIdField;

		// Token: 0x04000A32 RID: 2610
		private string shortIdField;

		// Token: 0x04000A33 RID: 2611
		private string urlField;

		// Token: 0x04000A34 RID: 2612
		private FeaturesType featuresField;

		// Token: 0x04000A35 RID: 2613
		private string expressionField;

		// Token: 0x04000A36 RID: 2614
		private PinsType pinsField;

		// Token: 0x04000A37 RID: 2615
		private PointType positionField;

		// Token: 0x04000A38 RID: 2616
		private SizeType sizeField;

		// Token: 0x04000A39 RID: 2617
		private float zIndexField;

		// Token: 0x04000A3A RID: 2618
		private string idField;

		// Token: 0x04000A3B RID: 2619
		private string objectTemplateReferenceField;

		// Token: 0x04000A3C RID: 2620
		private string objectTemplateReferenceNameField;
	}
}
