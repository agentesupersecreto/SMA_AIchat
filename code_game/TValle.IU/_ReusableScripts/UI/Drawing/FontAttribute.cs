using System;
using Assets.Base.Plugins.Runtime.UI;
using TMPro;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000055 RID: 85
	public abstract class FontAttribute : TextoLocalizadoAttribute, IFontAttribute, IBaseLayoutAttribute
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x000071BE File Offset: 0x000053BE
		public FontAttribute()
		{
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000071C6 File Offset: 0x000053C6
		public FontAttribute(string text)
			: base(text)
		{
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000071CF File Offset: 0x000053CF
		public FontAttribute(string text, string localizationID)
			: base(text, localizationID)
		{
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060002AC RID: 684 RVA: 0x000071D9 File Offset: 0x000053D9
		// (set) Token: 0x060002AD RID: 685 RVA: 0x000071E6 File Offset: 0x000053E6
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000071F4 File Offset: 0x000053F4
		public bool scaleModByUser
		{
			get
			{
				return this.m_scaleMod != null;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060002AF RID: 687 RVA: 0x00007201 File Offset: 0x00005401
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x0000720E File Offset: 0x0000540E
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

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000721C File Offset: 0x0000541C
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00007229 File Offset: 0x00005429
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

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00007237 File Offset: 0x00005437
		public bool heightByUser
		{
			get
			{
				return this.m_height != null;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00007244 File Offset: 0x00005444
		public bool widthByUser
		{
			get
			{
				return this.m_width != null;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00007251 File Offset: 0x00005451
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x0000725E File Offset: 0x0000545E
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

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000726C File Offset: 0x0000546C
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x00007279 File Offset: 0x00005479
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

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00007287 File Offset: 0x00005487
		public bool heightModByUser
		{
			get
			{
				return this.m_heightMod != null;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00007294 File Offset: 0x00005494
		public bool widthModByUser
		{
			get
			{
				return this.m_widthMod != null;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000072A1 File Offset: 0x000054A1
		// (set) Token: 0x060002BC RID: 700 RVA: 0x000072AE File Offset: 0x000054AE
		public int fontSize
		{
			get
			{
				return this.m_fontSize.GetValueOrDefault();
			}
			set
			{
				this.m_fontSize = new int?(value);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002BD RID: 701 RVA: 0x000072BC File Offset: 0x000054BC
		// (set) Token: 0x060002BE RID: 702 RVA: 0x000072C9 File Offset: 0x000054C9
		public FontStyles fontStyle
		{
			get
			{
				return this.m_fontStyle.GetValueOrDefault();
			}
			set
			{
				this.m_fontStyle = new FontStyles?(value);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000072D7 File Offset: 0x000054D7
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x000072E4 File Offset: 0x000054E4
		public float fontSizeMod
		{
			get
			{
				return this.m_fontSizeMod.GetValueOrDefault();
			}
			set
			{
				this.m_fontSizeMod = new float?(value);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x000072F2 File Offset: 0x000054F2
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x000072FF File Offset: 0x000054FF
		public TextAlignmentOptions alignment
		{
			get
			{
				return this.m_alignment.GetValueOrDefault();
			}
			set
			{
				this.m_alignment = new TextAlignmentOptions?(value);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000730D File Offset: 0x0000550D
		public bool fontSizeByUser
		{
			get
			{
				return this.m_fontSize != null;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000731A File Offset: 0x0000551A
		public bool fontStyleByUser
		{
			get
			{
				return this.m_fontStyle != null;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00007327 File Offset: 0x00005527
		public bool fontSizeModByUser
		{
			get
			{
				return this.m_fontSizeMod != null;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00007334 File Offset: 0x00005534
		public bool alignmentByUser
		{
			get
			{
				return this.m_alignment != null;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00007341 File Offset: 0x00005541
		public bool colorByUser
		{
			get
			{
				return this.m_color != null;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000734E File Offset: 0x0000554E
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0000735B File Offset: 0x0000555B
		public ColorEnum color
		{
			get
			{
				return this.m_color.GetValueOrDefault();
			}
			set
			{
				this.m_color = new ColorEnum?(value);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00007369 File Offset: 0x00005569
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00007376 File Offset: 0x00005576
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

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00007384 File Offset: 0x00005584
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00007391 File Offset: 0x00005591
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0000739F File Offset: 0x0000559F
		// (set) Token: 0x060002CF RID: 719 RVA: 0x000073AC File Offset: 0x000055AC
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

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x000073BA File Offset: 0x000055BA
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x000073C7 File Offset: 0x000055C7
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

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000073D5 File Offset: 0x000055D5
		public bool leftPaddingByUser
		{
			get
			{
				return this.m_leftPadding != null;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x000073E2 File Offset: 0x000055E2
		public bool rightPaddingByUser
		{
			get
			{
				return this.m_rightPadding != null;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000073EF File Offset: 0x000055EF
		public bool topPaddingByUser
		{
			get
			{
				return this.m_topPadding != null;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000073FC File Offset: 0x000055FC
		public bool bottomPaddingByUser
		{
			get
			{
				return this.m_bottomPadding != null;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x00007409 File Offset: 0x00005609
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x00007411 File Offset: 0x00005611
		public bool unlockFlexibleIfHeightWasSet { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000741A File Offset: 0x0000561A
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00007422 File Offset: 0x00005622
		public bool unlockFlexibleIfWidthWasSet { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000742B File Offset: 0x0000562B
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00007433 File Offset: 0x00005633
		public bool unlockParentFlexibleIfHeightWasSet { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000743C File Offset: 0x0000563C
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00007444 File Offset: 0x00005644
		public bool unlockParentFlexibleIfWidthWasSet { get; set; }

		// Token: 0x04000118 RID: 280
		private float? m_scaleMod;

		// Token: 0x04000119 RID: 281
		private int? m_height;

		// Token: 0x0400011A RID: 282
		private int? m_width;

		// Token: 0x0400011B RID: 283
		private float? m_heightMod;

		// Token: 0x0400011C RID: 284
		private float? m_widthMod;

		// Token: 0x0400011D RID: 285
		private int? m_fontSize;

		// Token: 0x0400011E RID: 286
		private FontStyles? m_fontStyle;

		// Token: 0x0400011F RID: 287
		private float? m_fontSizeMod;

		// Token: 0x04000120 RID: 288
		private TextAlignmentOptions? m_alignment;

		// Token: 0x04000121 RID: 289
		private ColorEnum? m_color;

		// Token: 0x04000122 RID: 290
		private int? m_leftPadding;

		// Token: 0x04000123 RID: 291
		private int? m_rightPadding;

		// Token: 0x04000124 RID: 292
		private int? m_topPadding;

		// Token: 0x04000125 RID: 293
		private int? m_bottomPadding;
	}
}
