using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000158 RID: 344
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocationSettingsType
	{
		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0001776C File Offset: 0x0001596C
		// (set) Token: 0x06000EA8 RID: 3752 RVA: 0x00017774 File Offset: 0x00015974
		public int ShowDisplayNameForZone
		{
			get
			{
				return this.showDisplayNameForZoneField;
			}
			set
			{
				this.showDisplayNameForZoneField = value;
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x00017780 File Offset: 0x00015980
		// (set) Token: 0x06000EAA RID: 3754 RVA: 0x00017788 File Offset: 0x00015988
		public int DropShadowForZone
		{
			get
			{
				return this.dropShadowForZoneField;
			}
			set
			{
				this.dropShadowForZoneField = value;
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00017794 File Offset: 0x00015994
		// (set) Token: 0x06000EAC RID: 3756 RVA: 0x0001779C File Offset: 0x0001599C
		public float DisplayNameSizeForZone
		{
			get
			{
				return this.displayNameSizeForZoneField;
			}
			set
			{
				this.displayNameSizeForZoneField = value;
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06000EAD RID: 3757 RVA: 0x000177A8 File Offset: 0x000159A8
		// (set) Token: 0x06000EAE RID: 3758 RVA: 0x000177B0 File Offset: 0x000159B0
		public string DisplayNameColorForZone
		{
			get
			{
				return this.displayNameColorForZoneField;
			}
			set
			{
				this.displayNameColorForZoneField = value;
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x000177BC File Offset: 0x000159BC
		// (set) Token: 0x06000EB0 RID: 3760 RVA: 0x000177C4 File Offset: 0x000159C4
		public int ShowDisplayNameForPath
		{
			get
			{
				return this.showDisplayNameForPathField;
			}
			set
			{
				this.showDisplayNameForPathField = value;
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x000177D0 File Offset: 0x000159D0
		// (set) Token: 0x06000EB2 RID: 3762 RVA: 0x000177D8 File Offset: 0x000159D8
		public int DropShadowForPath
		{
			get
			{
				return this.dropShadowForPathField;
			}
			set
			{
				this.dropShadowForPathField = value;
			}
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x000177E4 File Offset: 0x000159E4
		// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x000177EC File Offset: 0x000159EC
		public float DisplayNameSizeForPath
		{
			get
			{
				return this.displayNameSizeForPathField;
			}
			set
			{
				this.displayNameSizeForPathField = value;
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x000177F8 File Offset: 0x000159F8
		// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x00017800 File Offset: 0x00015A00
		public string DisplayNameColorForPath
		{
			get
			{
				return this.displayNameColorForPathField;
			}
			set
			{
				this.displayNameColorForPathField = value;
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0001780C File Offset: 0x00015A0C
		// (set) Token: 0x06000EB8 RID: 3768 RVA: 0x00017814 File Offset: 0x00015A14
		public int ShowDisplayNameForImage
		{
			get
			{
				return this.showDisplayNameForImageField;
			}
			set
			{
				this.showDisplayNameForImageField = value;
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x00017820 File Offset: 0x00015A20
		// (set) Token: 0x06000EBA RID: 3770 RVA: 0x00017828 File Offset: 0x00015A28
		public int DropShadowForImage
		{
			get
			{
				return this.dropShadowForImageField;
			}
			set
			{
				this.dropShadowForImageField = value;
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06000EBB RID: 3771 RVA: 0x00017834 File Offset: 0x00015A34
		// (set) Token: 0x06000EBC RID: 3772 RVA: 0x0001783C File Offset: 0x00015A3C
		public float DisplayNameSizeForImage
		{
			get
			{
				return this.displayNameSizeForImageField;
			}
			set
			{
				this.displayNameSizeForImageField = value;
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06000EBD RID: 3773 RVA: 0x00017848 File Offset: 0x00015A48
		// (set) Token: 0x06000EBE RID: 3774 RVA: 0x00017850 File Offset: 0x00015A50
		public string DisplayNameColorForImage
		{
			get
			{
				return this.displayNameColorForImageField;
			}
			set
			{
				this.displayNameColorForImageField = value;
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x0001785C File Offset: 0x00015A5C
		// (set) Token: 0x06000EC0 RID: 3776 RVA: 0x00017864 File Offset: 0x00015A64
		public int ShowDisplayNameForSpot
		{
			get
			{
				return this.showDisplayNameForSpotField;
			}
			set
			{
				this.showDisplayNameForSpotField = value;
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x00017870 File Offset: 0x00015A70
		// (set) Token: 0x06000EC2 RID: 3778 RVA: 0x00017878 File Offset: 0x00015A78
		public int DropShadowForSpot
		{
			get
			{
				return this.dropShadowForSpotField;
			}
			set
			{
				this.dropShadowForSpotField = value;
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00017884 File Offset: 0x00015A84
		// (set) Token: 0x06000EC4 RID: 3780 RVA: 0x0001788C File Offset: 0x00015A8C
		public string DisplayNameColorForSpot
		{
			get
			{
				return this.displayNameColorForSpotField;
			}
			set
			{
				this.displayNameColorForSpotField = value;
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x00017898 File Offset: 0x00015A98
		// (set) Token: 0x06000EC6 RID: 3782 RVA: 0x000178A0 File Offset: 0x00015AA0
		public SpotStyleKindType SpotStyleKind
		{
			get
			{
				return this.spotStyleKindField;
			}
			set
			{
				this.spotStyleKindField = value;
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x000178AC File Offset: 0x00015AAC
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x000178B4 File Offset: 0x00015AB4
		public SizeNamesType SpotStyleSize
		{
			get
			{
				return this.spotStyleSizeField;
			}
			set
			{
				this.spotStyleSizeField = value;
			}
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x000178C0 File Offset: 0x00015AC0
		// (set) Token: 0x06000ECA RID: 3786 RVA: 0x000178C8 File Offset: 0x00015AC8
		public int ShowDisplayNameForLink
		{
			get
			{
				return this.showDisplayNameForLinkField;
			}
			set
			{
				this.showDisplayNameForLinkField = value;
			}
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x000178D4 File Offset: 0x00015AD4
		// (set) Token: 0x06000ECC RID: 3788 RVA: 0x000178DC File Offset: 0x00015ADC
		public int DropShadowForLink
		{
			get
			{
				return this.dropShadowForLinkField;
			}
			set
			{
				this.dropShadowForLinkField = value;
			}
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06000ECD RID: 3789 RVA: 0x000178E8 File Offset: 0x00015AE8
		// (set) Token: 0x06000ECE RID: 3790 RVA: 0x000178F0 File Offset: 0x00015AF0
		public string DisplayNameColorForLink
		{
			get
			{
				return this.displayNameColorForLinkField;
			}
			set
			{
				this.displayNameColorForLinkField = value;
			}
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06000ECF RID: 3791 RVA: 0x000178FC File Offset: 0x00015AFC
		// (set) Token: 0x06000ED0 RID: 3792 RVA: 0x00017904 File Offset: 0x00015B04
		public LinkStyleKindType LinkStyleKind
		{
			get
			{
				return this.linkStyleKindField;
			}
			set
			{
				this.linkStyleKindField = value;
			}
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06000ED1 RID: 3793 RVA: 0x00017910 File Offset: 0x00015B10
		// (set) Token: 0x06000ED2 RID: 3794 RVA: 0x00017918 File Offset: 0x00015B18
		public SizeNamesType LinkStyleSize
		{
			get
			{
				return this.linkStyleSizeField;
			}
			set
			{
				this.linkStyleSizeField = value;
			}
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x00017924 File Offset: 0x00015B24
		// (set) Token: 0x06000ED4 RID: 3796 RVA: 0x0001792C File Offset: 0x00015B2C
		public int DropShadowForText
		{
			get
			{
				return this.dropShadowForTextField;
			}
			set
			{
				this.dropShadowForTextField = value;
			}
		}

		// Token: 0x04000802 RID: 2050
		private int showDisplayNameForZoneField;

		// Token: 0x04000803 RID: 2051
		private int dropShadowForZoneField;

		// Token: 0x04000804 RID: 2052
		private float displayNameSizeForZoneField;

		// Token: 0x04000805 RID: 2053
		private string displayNameColorForZoneField;

		// Token: 0x04000806 RID: 2054
		private int showDisplayNameForPathField;

		// Token: 0x04000807 RID: 2055
		private int dropShadowForPathField;

		// Token: 0x04000808 RID: 2056
		private float displayNameSizeForPathField;

		// Token: 0x04000809 RID: 2057
		private string displayNameColorForPathField;

		// Token: 0x0400080A RID: 2058
		private int showDisplayNameForImageField;

		// Token: 0x0400080B RID: 2059
		private int dropShadowForImageField;

		// Token: 0x0400080C RID: 2060
		private float displayNameSizeForImageField;

		// Token: 0x0400080D RID: 2061
		private string displayNameColorForImageField;

		// Token: 0x0400080E RID: 2062
		private int showDisplayNameForSpotField;

		// Token: 0x0400080F RID: 2063
		private int dropShadowForSpotField;

		// Token: 0x04000810 RID: 2064
		private string displayNameColorForSpotField;

		// Token: 0x04000811 RID: 2065
		private SpotStyleKindType spotStyleKindField;

		// Token: 0x04000812 RID: 2066
		private SizeNamesType spotStyleSizeField;

		// Token: 0x04000813 RID: 2067
		private int showDisplayNameForLinkField;

		// Token: 0x04000814 RID: 2068
		private int dropShadowForLinkField;

		// Token: 0x04000815 RID: 2069
		private string displayNameColorForLinkField;

		// Token: 0x04000816 RID: 2070
		private LinkStyleKindType linkStyleKindField;

		// Token: 0x04000817 RID: 2071
		private SizeNamesType linkStyleSizeField;

		// Token: 0x04000818 RID: 2072
		private int dropShadowForTextField;
	}
}
