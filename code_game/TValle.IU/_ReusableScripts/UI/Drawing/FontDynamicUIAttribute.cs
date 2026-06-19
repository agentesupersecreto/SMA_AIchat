using System;
using Assets.Base.Plugins.Runtime.UI;
using TMPro;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000045 RID: 69
	[Obsolete("TODO: no funciona")]
	public class FontDynamicUIAttribute : LayoutDynamicUIAttribute, IFontAttribute, IBaseLayoutAttribute
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x000068A7 File Offset: 0x00004AA7
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x000068B4 File Offset: 0x00004AB4
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x000068C2 File Offset: 0x00004AC2
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x000068CF File Offset: 0x00004ACF
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

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x000068DD File Offset: 0x00004ADD
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x000068EA File Offset: 0x00004AEA
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

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x000068F8 File Offset: 0x00004AF8
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00006905 File Offset: 0x00004B05
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

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00006913 File Offset: 0x00004B13
		public bool fontSizeByUser
		{
			get
			{
				return this.m_fontSize != null;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00006920 File Offset: 0x00004B20
		public bool fontStyleByUser
		{
			get
			{
				return this.m_fontStyle != null;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000692D File Offset: 0x00004B2D
		public bool fontSizeModByUser
		{
			get
			{
				return this.m_fontSizeMod != null;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001DB RID: 475 RVA: 0x0000693A File Offset: 0x00004B3A
		public bool alignmentByUser
		{
			get
			{
				return this.m_alignment != null;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00006947 File Offset: 0x00004B47
		public bool colorByUser
		{
			get
			{
				return this.m_color != null;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00006954 File Offset: 0x00004B54
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00006961 File Offset: 0x00004B61
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

		// Token: 0x040000D3 RID: 211
		private int? m_fontSize;

		// Token: 0x040000D4 RID: 212
		private FontStyles? m_fontStyle;

		// Token: 0x040000D5 RID: 213
		private float? m_fontSizeMod;

		// Token: 0x040000D6 RID: 214
		private TextAlignmentOptions? m_alignment;

		// Token: 0x040000D7 RID: 215
		private ColorEnum? m_color;
	}
}
