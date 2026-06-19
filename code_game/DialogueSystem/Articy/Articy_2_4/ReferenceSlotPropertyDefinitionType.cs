using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000172 RID: 370
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceSlotPropertyDefinitionType
	{
		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x0600103F RID: 4159 RVA: 0x00018754 File Offset: 0x00016954
		// (set) Token: 0x06001040 RID: 4160 RVA: 0x0001875C File Offset: 0x0001695C
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

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06001041 RID: 4161 RVA: 0x00018768 File Offset: 0x00016968
		// (set) Token: 0x06001042 RID: 4162 RVA: 0x00018770 File Offset: 0x00016970
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

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06001043 RID: 4163 RVA: 0x0001877C File Offset: 0x0001697C
		// (set) Token: 0x06001044 RID: 4164 RVA: 0x00018784 File Offset: 0x00016984
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

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06001045 RID: 4165 RVA: 0x00018790 File Offset: 0x00016990
		// (set) Token: 0x06001046 RID: 4166 RVA: 0x00018798 File Offset: 0x00016998
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

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06001047 RID: 4167 RVA: 0x000187A4 File Offset: 0x000169A4
		// (set) Token: 0x06001048 RID: 4168 RVA: 0x000187AC File Offset: 0x000169AC
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

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06001049 RID: 4169 RVA: 0x000187B8 File Offset: 0x000169B8
		// (set) Token: 0x0600104A RID: 4170 RVA: 0x000187C0 File Offset: 0x000169C0
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

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x0600104B RID: 4171 RVA: 0x000187CC File Offset: 0x000169CC
		// (set) Token: 0x0600104C RID: 4172 RVA: 0x000187D4 File Offset: 0x000169D4
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

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x0600104D RID: 4173 RVA: 0x000187E0 File Offset: 0x000169E0
		// (set) Token: 0x0600104E RID: 4174 RVA: 0x000187E8 File Offset: 0x000169E8
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

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x0600104F RID: 4175 RVA: 0x000187F4 File Offset: 0x000169F4
		// (set) Token: 0x06001050 RID: 4176 RVA: 0x000187FC File Offset: 0x000169FC
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

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x06001051 RID: 4177 RVA: 0x00018808 File Offset: 0x00016A08
		// (set) Token: 0x06001052 RID: 4178 RVA: 0x00018810 File Offset: 0x00016A10
		public ReferenceType DefaultValue
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

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06001053 RID: 4179 RVA: 0x0001881C File Offset: 0x00016A1C
		// (set) Token: 0x06001054 RID: 4180 RVA: 0x00018824 File Offset: 0x00016A24
		public ObjectTypes ObjectTypes
		{
			get
			{
				return this.objectTypesField;
			}
			set
			{
				this.objectTypesField = value;
			}
		}

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06001055 RID: 4181 RVA: 0x00018830 File Offset: 0x00016A30
		// (set) Token: 0x06001056 RID: 4182 RVA: 0x00018838 File Offset: 0x00016A38
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

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06001057 RID: 4183 RVA: 0x00018844 File Offset: 0x00016A44
		// (set) Token: 0x06001058 RID: 4184 RVA: 0x0001884C File Offset: 0x00016A4C
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

		// Token: 0x040008E1 RID: 2273
		private LocalizableTextType displayNameField;

		// Token: 0x040008E2 RID: 2274
		private string colorField;

		// Token: 0x040008E3 RID: 2275
		private string technicalNameField;

		// Token: 0x040008E4 RID: 2276
		private string tooltipTextField;

		// Token: 0x040008E5 RID: 2277
		private int isMandatoryField;

		// Token: 0x040008E6 RID: 2278
		private bool isMandatoryFieldSpecified;

		// Token: 0x040008E7 RID: 2279
		private int isLocalizedField;

		// Token: 0x040008E8 RID: 2280
		private bool isLocalizedFieldSpecified;

		// Token: 0x040008E9 RID: 2281
		private string placeholderValueField;

		// Token: 0x040008EA RID: 2282
		private ReferenceType defaultValueField;

		// Token: 0x040008EB RID: 2283
		private ObjectTypes objectTypesField;

		// Token: 0x040008EC RID: 2284
		private string idField;

		// Token: 0x040008ED RID: 2285
		private string basedOnField;
	}
}
