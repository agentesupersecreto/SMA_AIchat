using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000047 RID: 71
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
	public class LayoutDynamicUIAttribute : Attribute, IElementLayoutAttribute, IBaseLayoutAttribute
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00006B71 File Offset: 0x00004D71
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00006B7E File Offset: 0x00004D7E
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

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00006B8C File Offset: 0x00004D8C
		public bool scaleModByUser
		{
			get
			{
				return this.m_scaleMod != null;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00006B99 File Offset: 0x00004D99
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00006BA6 File Offset: 0x00004DA6
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

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00006BB4 File Offset: 0x00004DB4
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00006BC1 File Offset: 0x00004DC1
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

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00006BCF File Offset: 0x00004DCF
		public bool heightByUser
		{
			get
			{
				return this.m_height != null;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00006BDC File Offset: 0x00004DDC
		public bool widthByUser
		{
			get
			{
				return this.m_width != null;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00006BE9 File Offset: 0x00004DE9
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00006BF6 File Offset: 0x00004DF6
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

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00006C04 File Offset: 0x00004E04
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00006C11 File Offset: 0x00004E11
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

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00006C1F File Offset: 0x00004E1F
		public bool heightModByUser
		{
			get
			{
				return this.m_heightMod != null;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00006C2C File Offset: 0x00004E2C
		public bool widthModByUser
		{
			get
			{
				return this.m_widthMod != null;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00006C39 File Offset: 0x00004E39
		// (set) Token: 0x0600021A RID: 538 RVA: 0x00006C46 File Offset: 0x00004E46
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

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00006C54 File Offset: 0x00004E54
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00006C61 File Offset: 0x00004E61
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

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00006C6F File Offset: 0x00004E6F
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00006C7C File Offset: 0x00004E7C
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

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00006C8A File Offset: 0x00004E8A
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00006C97 File Offset: 0x00004E97
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

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00006CA5 File Offset: 0x00004EA5
		public bool leftPaddingByUser
		{
			get
			{
				return this.m_leftPadding != null;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000222 RID: 546 RVA: 0x00006CB2 File Offset: 0x00004EB2
		public bool rightPaddingByUser
		{
			get
			{
				return this.m_rightPadding != null;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00006CBF File Offset: 0x00004EBF
		public bool topPaddingByUser
		{
			get
			{
				return this.m_topPadding != null;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00006CCC File Offset: 0x00004ECC
		public bool bottomPaddingByUser
		{
			get
			{
				return this.m_bottomPadding != null;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00006CD9 File Offset: 0x00004ED9
		float? IElementLayoutAttribute.flexibleWidth
		{
			get
			{
				return this.m_flexibleWidth;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00006CE1 File Offset: 0x00004EE1
		float? IElementLayoutAttribute.flexibleHeight
		{
			get
			{
				return this.m_flexibleHeight;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00006CE9 File Offset: 0x00004EE9
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00006CF6 File Offset: 0x00004EF6
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

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00006D04 File Offset: 0x00004F04
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00006D11 File Offset: 0x00004F11
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00006D1F File Offset: 0x00004F1F
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00006D27 File Offset: 0x00004F27
		public bool unlockFlexibleIfHeightWasSet { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00006D30 File Offset: 0x00004F30
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00006D38 File Offset: 0x00004F38
		public bool unlockFlexibleIfWidthWasSet { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600022F RID: 559 RVA: 0x00006D41 File Offset: 0x00004F41
		// (set) Token: 0x06000230 RID: 560 RVA: 0x00006D49 File Offset: 0x00004F49
		public bool unlockParentFlexibleIfHeightWasSet { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00006D52 File Offset: 0x00004F52
		// (set) Token: 0x06000232 RID: 562 RVA: 0x00006D5A File Offset: 0x00004F5A
		public bool unlockParentFlexibleIfWidthWasSet { get; set; }

		// Token: 0x040000E7 RID: 231
		private float? m_scaleMod;

		// Token: 0x040000E8 RID: 232
		private int? m_height;

		// Token: 0x040000E9 RID: 233
		private int? m_width;

		// Token: 0x040000EA RID: 234
		private float? m_heightMod;

		// Token: 0x040000EB RID: 235
		private float? m_widthMod;

		// Token: 0x040000EC RID: 236
		private int? m_leftPadding;

		// Token: 0x040000ED RID: 237
		private int? m_rightPadding;

		// Token: 0x040000EE RID: 238
		private int? m_topPadding;

		// Token: 0x040000EF RID: 239
		private int? m_bottomPadding;

		// Token: 0x040000F0 RID: 240
		private float? m_flexibleWidth;

		// Token: 0x040000F1 RID: 241
		private float? m_flexibleHeight;
	}
}
