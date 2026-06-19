using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000048 RID: 72
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field)]
	public sealed class PanelAttribute : Attribute, IPanelLayoutAttribute, IElementLayoutAttribute, IBaseLayoutAttribute, IPanelAttribute
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00006D6B File Offset: 0x00004F6B
		// (set) Token: 0x06000235 RID: 565 RVA: 0x00006D73 File Offset: 0x00004F73
		public string panelLayoutDynamicMethodTarget { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00006D7C File Offset: 0x00004F7C
		// (set) Token: 0x06000237 RID: 567 RVA: 0x00006D89 File Offset: 0x00004F89
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

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00006D97 File Offset: 0x00004F97
		public bool scaleModByUser
		{
			get
			{
				return this.m_scaleMod != null;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00006DA4 File Offset: 0x00004FA4
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00006DAC File Offset: 0x00004FAC
		public TipoDePanel tipo { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00006DB5 File Offset: 0x00004FB5
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00006DC2 File Offset: 0x00004FC2
		public int height
		{
			get
			{
				return this.m_panelHeight.GetValueOrDefault();
			}
			set
			{
				this.m_panelHeight = new int?(value);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00006DD0 File Offset: 0x00004FD0
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00006DDD File Offset: 0x00004FDD
		public int width
		{
			get
			{
				return this.m_panelWidth.GetValueOrDefault();
			}
			set
			{
				this.m_panelWidth = new int?(value);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00006DEB File Offset: 0x00004FEB
		public bool heightByUser
		{
			get
			{
				return this.m_panelHeight != null;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000240 RID: 576 RVA: 0x00006DF8 File Offset: 0x00004FF8
		public bool widthByUser
		{
			get
			{
				return this.m_panelWidth != null;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00006E05 File Offset: 0x00005005
		// (set) Token: 0x06000242 RID: 578 RVA: 0x00006E12 File Offset: 0x00005012
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

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00006E20 File Offset: 0x00005020
		// (set) Token: 0x06000244 RID: 580 RVA: 0x00006E2D File Offset: 0x0000502D
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

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00006E3B File Offset: 0x0000503B
		public bool heightModByUser
		{
			get
			{
				return this.m_heightMod != null;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00006E48 File Offset: 0x00005048
		public bool widthModByUser
		{
			get
			{
				return this.m_widthMod != null;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00006E55 File Offset: 0x00005055
		// (set) Token: 0x06000248 RID: 584 RVA: 0x00006E62 File Offset: 0x00005062
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

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00006E70 File Offset: 0x00005070
		// (set) Token: 0x0600024A RID: 586 RVA: 0x00006E7D File Offset: 0x0000507D
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

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00006E8B File Offset: 0x0000508B
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00006E98 File Offset: 0x00005098
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

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00006EA6 File Offset: 0x000050A6
		// (set) Token: 0x0600024E RID: 590 RVA: 0x00006EB3 File Offset: 0x000050B3
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

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00006EC1 File Offset: 0x000050C1
		public bool leftPaddingByUser
		{
			get
			{
				return this.m_leftPadding != null;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000250 RID: 592 RVA: 0x00006ECE File Offset: 0x000050CE
		public bool rightPaddingByUser
		{
			get
			{
				return this.m_rightPadding != null;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00006EDB File Offset: 0x000050DB
		public bool topPaddingByUser
		{
			get
			{
				return this.m_topPadding != null;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00006EE8 File Offset: 0x000050E8
		public bool bottomPaddingByUser
		{
			get
			{
				return this.m_bottomPadding != null;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00006EF5 File Offset: 0x000050F5
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00006F02 File Offset: 0x00005102
		public bool controlChildWidth
		{
			get
			{
				return this.m_controlChildWidth.GetValueOrDefault();
			}
			set
			{
				this.m_controlChildWidth = new bool?(value);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00006F10 File Offset: 0x00005110
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00006F1D File Offset: 0x0000511D
		public bool controlChildHeight
		{
			get
			{
				return this.m_controlChildHeight.GetValueOrDefault();
			}
			set
			{
				this.m_controlChildHeight = new bool?(value);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00006F2B File Offset: 0x0000512B
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00006F38 File Offset: 0x00005138
		public bool childForceExpandWidth
		{
			get
			{
				return this.m_childForceExpandWidth.GetValueOrDefault();
			}
			set
			{
				this.m_childForceExpandWidth = new bool?(value);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00006F46 File Offset: 0x00005146
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00006F53 File Offset: 0x00005153
		public bool childForceExpandHeight
		{
			get
			{
				return this.m_childForceExpandHeight.GetValueOrDefault();
			}
			set
			{
				this.m_childForceExpandHeight = new bool?(value);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00006F61 File Offset: 0x00005161
		bool? IPanelLayoutAttribute.controlChildWidth
		{
			get
			{
				return this.m_controlChildWidth;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00006F69 File Offset: 0x00005169
		bool? IPanelLayoutAttribute.controlChildHeight
		{
			get
			{
				return this.m_controlChildHeight;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00006F71 File Offset: 0x00005171
		bool? IPanelLayoutAttribute.childForceExpandWidth
		{
			get
			{
				return this.m_childForceExpandWidth;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00006F79 File Offset: 0x00005179
		bool? IPanelLayoutAttribute.childForceExpandHeight
		{
			get
			{
				return this.m_childForceExpandHeight;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00006F81 File Offset: 0x00005181
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00006F8E File Offset: 0x0000518E
		public PanelBackgroundType backgroundType
		{
			get
			{
				return this.m_backgroundType.GetValueOrDefault();
			}
			set
			{
				this.m_backgroundType = new PanelBackgroundType?(value);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00006F9C File Offset: 0x0000519C
		public bool backgroundTypeByUser
		{
			get
			{
				return this.m_backgroundType != null;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00006FA9 File Offset: 0x000051A9
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00006FB6 File Offset: 0x000051B6
		public PanelBackgroundColor backgroundColor
		{
			get
			{
				return this.m_backgroundColor.GetValueOrDefault();
			}
			set
			{
				this.m_backgroundColor = new PanelBackgroundColor?(value);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00006FC4 File Offset: 0x000051C4
		public bool backgroundColorByUser
		{
			get
			{
				return this.m_backgroundColor != null;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00006FD1 File Offset: 0x000051D1
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00006FDE File Offset: 0x000051DE
		public float backgroundAlpha
		{
			get
			{
				return this.m_backgroundAlpha.GetValueOrDefault();
			}
			set
			{
				this.m_backgroundAlpha = new float?(value);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00006FEC File Offset: 0x000051EC
		public bool backgroundAlphaByUser
		{
			get
			{
				return this.m_backgroundAlpha != null;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00006FF9 File Offset: 0x000051F9
		// (set) Token: 0x06000269 RID: 617 RVA: 0x00007006 File Offset: 0x00005206
		public int posX
		{
			get
			{
				return this.m_panelPosX.GetValueOrDefault();
			}
			set
			{
				this.m_panelPosX = new int?(value);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00007014 File Offset: 0x00005214
		// (set) Token: 0x0600026B RID: 619 RVA: 0x00007021 File Offset: 0x00005221
		public int posY
		{
			get
			{
				return this.m_panelPosY.GetValueOrDefault();
			}
			set
			{
				this.m_panelPosY = new int?(value);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000702F File Offset: 0x0000522F
		public bool posXByUser
		{
			get
			{
				return this.m_panelPosX != null;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600026D RID: 621 RVA: 0x0000703C File Offset: 0x0000523C
		public bool posYByUser
		{
			get
			{
				return this.m_panelPosY != null;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600026E RID: 622 RVA: 0x00007049 File Offset: 0x00005249
		float? IElementLayoutAttribute.flexibleWidth
		{
			get
			{
				return this.m_flexibleWidth;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00007051 File Offset: 0x00005251
		float? IElementLayoutAttribute.flexibleHeight
		{
			get
			{
				return this.m_flexibleHeight;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000270 RID: 624 RVA: 0x00007059 File Offset: 0x00005259
		// (set) Token: 0x06000271 RID: 625 RVA: 0x00007066 File Offset: 0x00005266
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

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00007074 File Offset: 0x00005274
		// (set) Token: 0x06000273 RID: 627 RVA: 0x00007081 File Offset: 0x00005281
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

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0000708F File Offset: 0x0000528F
		// (set) Token: 0x06000275 RID: 629 RVA: 0x00007097 File Offset: 0x00005297
		public bool unlockFlexibleIfHeightWasSet { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000070A0 File Offset: 0x000052A0
		// (set) Token: 0x06000277 RID: 631 RVA: 0x000070A8 File Offset: 0x000052A8
		public bool unlockFlexibleIfWidthWasSet { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000070B1 File Offset: 0x000052B1
		// (set) Token: 0x06000279 RID: 633 RVA: 0x000070B9 File Offset: 0x000052B9
		public bool unlockParentFlexibleIfHeightWasSet { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600027A RID: 634 RVA: 0x000070C2 File Offset: 0x000052C2
		// (set) Token: 0x0600027B RID: 635 RVA: 0x000070CA File Offset: 0x000052CA
		public bool unlockParentFlexibleIfWidthWasSet { get; set; }

		// Token: 0x040000F7 RID: 247
		private float? m_scaleMod;

		// Token: 0x040000F9 RID: 249
		private int? m_panelHeight;

		// Token: 0x040000FA RID: 250
		private int? m_panelWidth;

		// Token: 0x040000FB RID: 251
		private float? m_heightMod;

		// Token: 0x040000FC RID: 252
		private float? m_widthMod;

		// Token: 0x040000FD RID: 253
		private int? m_leftPadding;

		// Token: 0x040000FE RID: 254
		private int? m_rightPadding;

		// Token: 0x040000FF RID: 255
		private int? m_topPadding;

		// Token: 0x04000100 RID: 256
		private int? m_bottomPadding;

		// Token: 0x04000101 RID: 257
		private bool? m_controlChildWidth;

		// Token: 0x04000102 RID: 258
		private bool? m_controlChildHeight;

		// Token: 0x04000103 RID: 259
		private bool? m_childForceExpandWidth;

		// Token: 0x04000104 RID: 260
		private bool? m_childForceExpandHeight;

		// Token: 0x04000105 RID: 261
		private PanelBackgroundType? m_backgroundType;

		// Token: 0x04000106 RID: 262
		private PanelBackgroundColor? m_backgroundColor;

		// Token: 0x04000107 RID: 263
		private float? m_backgroundAlpha;

		// Token: 0x04000108 RID: 264
		private int? m_panelPosX;

		// Token: 0x04000109 RID: 265
		private int? m_panelPosY;

		// Token: 0x0400010A RID: 266
		private float? m_flexibleWidth;

		// Token: 0x0400010B RID: 267
		private float? m_flexibleHeight;
	}
}
