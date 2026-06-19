using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000179 RID: 377
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ScriptPropertyDefinitionType
	{
		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x00018A68 File Offset: 0x00016C68
		// (set) Token: 0x06001090 RID: 4240 RVA: 0x00018A70 File Offset: 0x00016C70
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

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06001091 RID: 4241 RVA: 0x00018A7C File Offset: 0x00016C7C
		// (set) Token: 0x06001092 RID: 4242 RVA: 0x00018A84 File Offset: 0x00016C84
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

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x06001093 RID: 4243 RVA: 0x00018A90 File Offset: 0x00016C90
		// (set) Token: 0x06001094 RID: 4244 RVA: 0x00018A98 File Offset: 0x00016C98
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

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x00018AA4 File Offset: 0x00016CA4
		// (set) Token: 0x06001096 RID: 4246 RVA: 0x00018AAC File Offset: 0x00016CAC
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

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x06001097 RID: 4247 RVA: 0x00018AB8 File Offset: 0x00016CB8
		// (set) Token: 0x06001098 RID: 4248 RVA: 0x00018AC0 File Offset: 0x00016CC0
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

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06001099 RID: 4249 RVA: 0x00018ACC File Offset: 0x00016CCC
		// (set) Token: 0x0600109A RID: 4250 RVA: 0x00018AD4 File Offset: 0x00016CD4
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

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x0600109B RID: 4251 RVA: 0x00018AE0 File Offset: 0x00016CE0
		// (set) Token: 0x0600109C RID: 4252 RVA: 0x00018AE8 File Offset: 0x00016CE8
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

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x0600109D RID: 4253 RVA: 0x00018AF4 File Offset: 0x00016CF4
		// (set) Token: 0x0600109E RID: 4254 RVA: 0x00018AFC File Offset: 0x00016CFC
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

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x0600109F RID: 4255 RVA: 0x00018B08 File Offset: 0x00016D08
		// (set) Token: 0x060010A0 RID: 4256 RVA: 0x00018B10 File Offset: 0x00016D10
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

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x00018B1C File Offset: 0x00016D1C
		// (set) Token: 0x060010A2 RID: 4258 RVA: 0x00018B24 File Offset: 0x00016D24
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

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x060010A3 RID: 4259 RVA: 0x00018B30 File Offset: 0x00016D30
		// (set) Token: 0x060010A4 RID: 4260 RVA: 0x00018B38 File Offset: 0x00016D38
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

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x060010A5 RID: 4261 RVA: 0x00018B44 File Offset: 0x00016D44
		// (set) Token: 0x060010A6 RID: 4262 RVA: 0x00018B4C File Offset: 0x00016D4C
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

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x060010A7 RID: 4263 RVA: 0x00018B58 File Offset: 0x00016D58
		// (set) Token: 0x060010A8 RID: 4264 RVA: 0x00018B60 File Offset: 0x00016D60
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

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x060010A9 RID: 4265 RVA: 0x00018B6C File Offset: 0x00016D6C
		// (set) Token: 0x060010AA RID: 4266 RVA: 0x00018B74 File Offset: 0x00016D74
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

		// Token: 0x0400090C RID: 2316
		private LocalizableTextType displayNameField;

		// Token: 0x0400090D RID: 2317
		private string colorField;

		// Token: 0x0400090E RID: 2318
		private string technicalNameField;

		// Token: 0x0400090F RID: 2319
		private string tooltipTextField;

		// Token: 0x04000910 RID: 2320
		private int isMandatoryField;

		// Token: 0x04000911 RID: 2321
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000912 RID: 2322
		private int isLocalizedField;

		// Token: 0x04000913 RID: 2323
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000914 RID: 2324
		private string placeholderValueField;

		// Token: 0x04000915 RID: 2325
		private string defaultValueField;

		// Token: 0x04000916 RID: 2326
		private ScriptTypeType scriptTypeField;

		// Token: 0x04000917 RID: 2327
		private bool scriptTypeFieldSpecified;

		// Token: 0x04000918 RID: 2328
		private string idField;

		// Token: 0x04000919 RID: 2329
		private string basedOnField;
	}
}
