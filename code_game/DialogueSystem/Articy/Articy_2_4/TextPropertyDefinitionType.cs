using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200017E RID: 382
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class TextPropertyDefinitionType
	{
		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x060010F5 RID: 4341 RVA: 0x00018E5C File Offset: 0x0001705C
		// (set) Token: 0x060010F6 RID: 4342 RVA: 0x00018E64 File Offset: 0x00017064
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

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x060010F7 RID: 4343 RVA: 0x00018E70 File Offset: 0x00017070
		// (set) Token: 0x060010F8 RID: 4344 RVA: 0x00018E78 File Offset: 0x00017078
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

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x060010F9 RID: 4345 RVA: 0x00018E84 File Offset: 0x00017084
		// (set) Token: 0x060010FA RID: 4346 RVA: 0x00018E8C File Offset: 0x0001708C
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

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x060010FB RID: 4347 RVA: 0x00018E98 File Offset: 0x00017098
		// (set) Token: 0x060010FC RID: 4348 RVA: 0x00018EA0 File Offset: 0x000170A0
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

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x060010FD RID: 4349 RVA: 0x00018EAC File Offset: 0x000170AC
		// (set) Token: 0x060010FE RID: 4350 RVA: 0x00018EB4 File Offset: 0x000170B4
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

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x060010FF RID: 4351 RVA: 0x00018EC0 File Offset: 0x000170C0
		// (set) Token: 0x06001100 RID: 4352 RVA: 0x00018EC8 File Offset: 0x000170C8
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

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001101 RID: 4353 RVA: 0x00018ED4 File Offset: 0x000170D4
		// (set) Token: 0x06001102 RID: 4354 RVA: 0x00018EDC File Offset: 0x000170DC
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

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001103 RID: 4355 RVA: 0x00018EE8 File Offset: 0x000170E8
		// (set) Token: 0x06001104 RID: 4356 RVA: 0x00018EF0 File Offset: 0x000170F0
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

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06001105 RID: 4357 RVA: 0x00018EFC File Offset: 0x000170FC
		// (set) Token: 0x06001106 RID: 4358 RVA: 0x00018F04 File Offset: 0x00017104
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

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x00018F10 File Offset: 0x00017110
		// (set) Token: 0x06001108 RID: 4360 RVA: 0x00018F18 File Offset: 0x00017118
		public TextPropertyDefinitionValueType DefaultValue
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

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001109 RID: 4361 RVA: 0x00018F24 File Offset: 0x00017124
		// (set) Token: 0x0600110A RID: 4362 RVA: 0x00018F2C File Offset: 0x0001712C
		public decimal DisallowedChars
		{
			get
			{
				return this.disallowedCharsField;
			}
			set
			{
				this.disallowedCharsField = value;
			}
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x0600110B RID: 4363 RVA: 0x00018F38 File Offset: 0x00017138
		// (set) Token: 0x0600110C RID: 4364 RVA: 0x00018F40 File Offset: 0x00017140
		[XmlIgnore]
		public bool DisallowedCharsSpecified
		{
			get
			{
				return this.disallowedCharsFieldSpecified;
			}
			set
			{
				this.disallowedCharsFieldSpecified = value;
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x0600110D RID: 4365 RVA: 0x00018F4C File Offset: 0x0001714C
		// (set) Token: 0x0600110E RID: 4366 RVA: 0x00018F54 File Offset: 0x00017154
		public int MaxLength
		{
			get
			{
				return this.maxLengthField;
			}
			set
			{
				this.maxLengthField = value;
			}
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x0600110F RID: 4367 RVA: 0x00018F60 File Offset: 0x00017160
		// (set) Token: 0x06001110 RID: 4368 RVA: 0x00018F68 File Offset: 0x00017168
		[XmlIgnore]
		public bool MaxLengthSpecified
		{
			get
			{
				return this.maxLengthFieldSpecified;
			}
			set
			{
				this.maxLengthFieldSpecified = value;
			}
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x06001111 RID: 4369 RVA: 0x00018F74 File Offset: 0x00017174
		// (set) Token: 0x06001112 RID: 4370 RVA: 0x00018F7C File Offset: 0x0001717C
		public int AllowsLinebreaks
		{
			get
			{
				return this.allowsLinebreaksField;
			}
			set
			{
				this.allowsLinebreaksField = value;
			}
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06001113 RID: 4371 RVA: 0x00018F88 File Offset: 0x00017188
		// (set) Token: 0x06001114 RID: 4372 RVA: 0x00018F90 File Offset: 0x00017190
		[XmlIgnore]
		public bool AllowsLinebreaksSpecified
		{
			get
			{
				return this.allowsLinebreaksFieldSpecified;
			}
			set
			{
				this.allowsLinebreaksFieldSpecified = value;
			}
		}

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06001115 RID: 4373 RVA: 0x00018F9C File Offset: 0x0001719C
		// (set) Token: 0x06001116 RID: 4374 RVA: 0x00018FA4 File Offset: 0x000171A4
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

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06001117 RID: 4375 RVA: 0x00018FB0 File Offset: 0x000171B0
		// (set) Token: 0x06001118 RID: 4376 RVA: 0x00018FB8 File Offset: 0x000171B8
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

		// Token: 0x04000941 RID: 2369
		private LocalizableTextType displayNameField;

		// Token: 0x04000942 RID: 2370
		private string colorField;

		// Token: 0x04000943 RID: 2371
		private string technicalNameField;

		// Token: 0x04000944 RID: 2372
		private string tooltipTextField;

		// Token: 0x04000945 RID: 2373
		private int isMandatoryField;

		// Token: 0x04000946 RID: 2374
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000947 RID: 2375
		private int isLocalizedField;

		// Token: 0x04000948 RID: 2376
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000949 RID: 2377
		private string placeholderValueField;

		// Token: 0x0400094A RID: 2378
		private TextPropertyDefinitionValueType defaultValueField;

		// Token: 0x0400094B RID: 2379
		private decimal disallowedCharsField;

		// Token: 0x0400094C RID: 2380
		private bool disallowedCharsFieldSpecified;

		// Token: 0x0400094D RID: 2381
		private int maxLengthField;

		// Token: 0x0400094E RID: 2382
		private bool maxLengthFieldSpecified;

		// Token: 0x0400094F RID: 2383
		private int allowsLinebreaksField;

		// Token: 0x04000950 RID: 2384
		private bool allowsLinebreaksFieldSpecified;

		// Token: 0x04000951 RID: 2385
		private string idField;

		// Token: 0x04000952 RID: 2386
		private string basedOnField;
	}
}
