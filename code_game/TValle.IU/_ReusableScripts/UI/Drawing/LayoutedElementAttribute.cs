using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000046 RID: 70
	public abstract class LayoutedElementAttribute : DynamicUIElementAttribute, IElementLayoutAttribute, IBaseLayoutAttribute
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00006977 File Offset: 0x00004B77
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x00006984 File Offset: 0x00004B84
		public float scaleMod
		{
			get
			{
				return this.m_scaleMod.GetValueOrDefault();
			}
			set
			{
				this.m_scaleMod = new float?(value);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00006992 File Offset: 0x00004B92
		public bool scaleModByUser
		{
			get
			{
				return this.m_scaleMod != null;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000699F File Offset: 0x00004B9F
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x000069AC File Offset: 0x00004BAC
		public int height
		{
			get
			{
				return this.m_height.GetValueOrDefault();
			}
			set
			{
				this.m_height = new int?(value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x000069BA File Offset: 0x00004BBA
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x000069C7 File Offset: 0x00004BC7
		public int width
		{
			get
			{
				return this.m_width.GetValueOrDefault();
			}
			set
			{
				this.m_width = new int?(value);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x000069D5 File Offset: 0x00004BD5
		public bool heightByUser
		{
			get
			{
				return this.m_height != null;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x000069E2 File Offset: 0x00004BE2
		public bool widthByUser
		{
			get
			{
				return this.m_width != null;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000069EF File Offset: 0x00004BEF
		// (set) Token: 0x060001EA RID: 490 RVA: 0x000069FC File Offset: 0x00004BFC
		public float heightMod
		{
			get
			{
				return this.m_heightMod.GetValueOrDefault();
			}
			set
			{
				this.m_heightMod = new float?(value);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00006A0A File Offset: 0x00004C0A
		// (set) Token: 0x060001EC RID: 492 RVA: 0x00006A17 File Offset: 0x00004C17
		public float widthMod
		{
			get
			{
				return this.m_widthMod.GetValueOrDefault();
			}
			set
			{
				this.m_widthMod = new float?(value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00006A25 File Offset: 0x00004C25
		public bool heightModByUser
		{
			get
			{
				return this.m_heightMod != null;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00006A32 File Offset: 0x00004C32
		public bool widthModByUser
		{
			get
			{
				return this.m_widthMod != null;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00006A3F File Offset: 0x00004C3F
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00006A4C File Offset: 0x00004C4C
		public int leftPadding
		{
			get
			{
				return this.m_leftPadding.GetValueOrDefault();
			}
			set
			{
				this.m_leftPadding = new int?(value);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00006A5A File Offset: 0x00004C5A
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x00006A67 File Offset: 0x00004C67
		public int rightPadding
		{
			get
			{
				return this.m_rightPadding.GetValueOrDefault();
			}
			set
			{
				this.m_rightPadding = new int?(value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00006A75 File Offset: 0x00004C75
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00006A82 File Offset: 0x00004C82
		public int topPadding
		{
			get
			{
				return this.m_topPadding.GetValueOrDefault();
			}
			set
			{
				this.m_topPadding = new int?(value);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00006A90 File Offset: 0x00004C90
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x00006A9D File Offset: 0x00004C9D
		public int bottomPadding
		{
			get
			{
				return this.m_bottomPadding.GetValueOrDefault();
			}
			set
			{
				this.m_bottomPadding = new int?(value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00006AAB File Offset: 0x00004CAB
		public bool leftPaddingByUser
		{
			get
			{
				return this.m_leftPadding != null;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00006AB8 File Offset: 0x00004CB8
		public bool rightPaddingByUser
		{
			get
			{
				return this.m_rightPadding != null;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00006AC5 File Offset: 0x00004CC5
		public bool topPaddingByUser
		{
			get
			{
				return this.m_topPadding != null;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00006AD2 File Offset: 0x00004CD2
		public bool bottomPaddingByUser
		{
			get
			{
				return this.m_bottomPadding != null;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00006ADF File Offset: 0x00004CDF
		float? IElementLayoutAttribute.flexibleWidth
		{
			get
			{
				return this.m_flexibleWidth;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00006AE7 File Offset: 0x00004CE7
		float? IElementLayoutAttribute.flexibleHeight
		{
			get
			{
				return this.m_flexibleHeight;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00006AEF File Offset: 0x00004CEF
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00006AFC File Offset: 0x00004CFC
		public float flexibleWidth
		{
			get
			{
				return this.m_flexibleWidth.GetValueOrDefault();
			}
			set
			{
				this.m_flexibleWidth = new float?(value);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00006B0A File Offset: 0x00004D0A
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00006B17 File Offset: 0x00004D17
		public float flexibleHeight
		{
			get
			{
				return this.m_flexibleHeight.GetValueOrDefault();
			}
			set
			{
				this.m_flexibleHeight = new float?(value);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00006B25 File Offset: 0x00004D25
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00006B2D File Offset: 0x00004D2D
		public bool unlockFlexibleIfHeightWasSet { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00006B36 File Offset: 0x00004D36
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00006B3E File Offset: 0x00004D3E
		public bool unlockFlexibleIfWidthWasSet { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00006B47 File Offset: 0x00004D47
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00006B4F File Offset: 0x00004D4F
		public bool unlockParentFlexibleIfHeightWasSet { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00006B58 File Offset: 0x00004D58
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00006B60 File Offset: 0x00004D60
		public bool unlockParentFlexibleIfWidthWasSet { get; set; }

		// Token: 0x040000D8 RID: 216
		private float? m_scaleMod;

		// Token: 0x040000D9 RID: 217
		private int? m_height;

		// Token: 0x040000DA RID: 218
		private int? m_width;

		// Token: 0x040000DB RID: 219
		private float? m_heightMod;

		// Token: 0x040000DC RID: 220
		private float? m_widthMod;

		// Token: 0x040000DD RID: 221
		private int? m_leftPadding;

		// Token: 0x040000DE RID: 222
		private int? m_rightPadding;

		// Token: 0x040000DF RID: 223
		private int? m_topPadding;

		// Token: 0x040000E0 RID: 224
		private int? m_bottomPadding;

		// Token: 0x040000E1 RID: 225
		private float? m_flexibleWidth;

		// Token: 0x040000E2 RID: 226
		private float? m_flexibleHeight;
	}
}
