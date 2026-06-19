using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000178 RID: 376
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ReferenceStripPropertyDefinitionType
	{
		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001072 RID: 4210 RVA: 0x00018948 File Offset: 0x00016B48
		// (set) Token: 0x06001073 RID: 4211 RVA: 0x00018950 File Offset: 0x00016B50
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

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06001074 RID: 4212 RVA: 0x0001895C File Offset: 0x00016B5C
		// (set) Token: 0x06001075 RID: 4213 RVA: 0x00018964 File Offset: 0x00016B64
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

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06001076 RID: 4214 RVA: 0x00018970 File Offset: 0x00016B70
		// (set) Token: 0x06001077 RID: 4215 RVA: 0x00018978 File Offset: 0x00016B78
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

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x06001078 RID: 4216 RVA: 0x00018984 File Offset: 0x00016B84
		// (set) Token: 0x06001079 RID: 4217 RVA: 0x0001898C File Offset: 0x00016B8C
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

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x0600107A RID: 4218 RVA: 0x00018998 File Offset: 0x00016B98
		// (set) Token: 0x0600107B RID: 4219 RVA: 0x000189A0 File Offset: 0x00016BA0
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

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x0600107C RID: 4220 RVA: 0x000189AC File Offset: 0x00016BAC
		// (set) Token: 0x0600107D RID: 4221 RVA: 0x000189B4 File Offset: 0x00016BB4
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

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x0600107E RID: 4222 RVA: 0x000189C0 File Offset: 0x00016BC0
		// (set) Token: 0x0600107F RID: 4223 RVA: 0x000189C8 File Offset: 0x00016BC8
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

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06001080 RID: 4224 RVA: 0x000189D4 File Offset: 0x00016BD4
		// (set) Token: 0x06001081 RID: 4225 RVA: 0x000189DC File Offset: 0x00016BDC
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

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06001082 RID: 4226 RVA: 0x000189E8 File Offset: 0x00016BE8
		// (set) Token: 0x06001083 RID: 4227 RVA: 0x000189F0 File Offset: 0x00016BF0
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

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06001084 RID: 4228 RVA: 0x000189FC File Offset: 0x00016BFC
		// (set) Token: 0x06001085 RID: 4229 RVA: 0x00018A04 File Offset: 0x00016C04
		public int MaxReferenceCount
		{
			get
			{
				return this.maxReferenceCountField;
			}
			set
			{
				this.maxReferenceCountField = value;
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x06001086 RID: 4230 RVA: 0x00018A10 File Offset: 0x00016C10
		// (set) Token: 0x06001087 RID: 4231 RVA: 0x00018A18 File Offset: 0x00016C18
		[XmlIgnore]
		public bool MaxReferenceCountSpecified
		{
			get
			{
				return this.maxReferenceCountFieldSpecified;
			}
			set
			{
				this.maxReferenceCountFieldSpecified = value;
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x06001088 RID: 4232 RVA: 0x00018A24 File Offset: 0x00016C24
		// (set) Token: 0x06001089 RID: 4233 RVA: 0x00018A2C File Offset: 0x00016C2C
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

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x0600108A RID: 4234 RVA: 0x00018A38 File Offset: 0x00016C38
		// (set) Token: 0x0600108B RID: 4235 RVA: 0x00018A40 File Offset: 0x00016C40
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

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x0600108C RID: 4236 RVA: 0x00018A4C File Offset: 0x00016C4C
		// (set) Token: 0x0600108D RID: 4237 RVA: 0x00018A54 File Offset: 0x00016C54
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

		// Token: 0x040008FE RID: 2302
		private LocalizableTextType displayNameField;

		// Token: 0x040008FF RID: 2303
		private string colorField;

		// Token: 0x04000900 RID: 2304
		private string technicalNameField;

		// Token: 0x04000901 RID: 2305
		private string tooltipTextField;

		// Token: 0x04000902 RID: 2306
		private int isMandatoryField;

		// Token: 0x04000903 RID: 2307
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000904 RID: 2308
		private int isLocalizedField;

		// Token: 0x04000905 RID: 2309
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000906 RID: 2310
		private string placeholderValueField;

		// Token: 0x04000907 RID: 2311
		private int maxReferenceCountField;

		// Token: 0x04000908 RID: 2312
		private bool maxReferenceCountFieldSpecified;

		// Token: 0x04000909 RID: 2313
		private ObjectTypes objectTypesField;

		// Token: 0x0400090A RID: 2314
		private string idField;

		// Token: 0x0400090B RID: 2315
		private string basedOnField;
	}
}
