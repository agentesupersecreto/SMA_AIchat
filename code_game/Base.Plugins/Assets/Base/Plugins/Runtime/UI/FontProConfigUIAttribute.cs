using System;
using TMPro;
using UnityEngine;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000193 RID: 403
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class FontProConfigUIAttribute : Attribute, IFontAttribute
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x00026024 File Offset: 0x00024224
		// (set) Token: 0x06000BAC RID: 2988 RVA: 0x00026031 File Offset: 0x00024231
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

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x0002603F File Offset: 0x0002423F
		// (set) Token: 0x06000BAE RID: 2990 RVA: 0x0002604C File Offset: 0x0002424C
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

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x0002605A File Offset: 0x0002425A
		// (set) Token: 0x06000BB0 RID: 2992 RVA: 0x00026067 File Offset: 0x00024267
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

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x00026075 File Offset: 0x00024275
		// (set) Token: 0x06000BB2 RID: 2994 RVA: 0x00026082 File Offset: 0x00024282
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

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x00026090 File Offset: 0x00024290
		// (set) Token: 0x06000BB4 RID: 2996 RVA: 0x000260A2 File Offset: 0x000242A2
		public TextAnchor alignmentUnity
		{
			get
			{
				return FontProConfigUIAttribute.ParseToAnchor(this.m_alignment.GetValueOrDefault());
			}
			set
			{
				this.m_alignment = new TextAlignmentOptions?(FontProConfigUIAttribute.ParseToAlignment(value));
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x000260B5 File Offset: 0x000242B5
		public bool fontSizeByUser
		{
			get
			{
				return this.m_fontSize != null;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x000260C2 File Offset: 0x000242C2
		public bool fontStyleByUser
		{
			get
			{
				return this.m_fontStyle != null;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x000260CF File Offset: 0x000242CF
		public bool fontSizeModByUser
		{
			get
			{
				return this.m_fontSizeMod != null;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x000260DC File Offset: 0x000242DC
		public bool alignmentByUser
		{
			get
			{
				return this.m_alignment != null;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x000260E9 File Offset: 0x000242E9
		public bool colorByUser
		{
			get
			{
				return this.m_color != null;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x000260F6 File Offset: 0x000242F6
		// (set) Token: 0x06000BBB RID: 3003 RVA: 0x00026103 File Offset: 0x00024303
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

		// Token: 0x06000BBC RID: 3004 RVA: 0x00026114 File Offset: 0x00024314
		public static TextAlignmentOptions ParseToAlignment(TextAnchor an)
		{
			switch (an)
			{
			case TextAnchor.UpperLeft:
				return TextAlignmentOptions.TopLeft;
			case TextAnchor.UpperCenter:
				return TextAlignmentOptions.Top;
			case TextAnchor.UpperRight:
				return TextAlignmentOptions.TopRight;
			case TextAnchor.MiddleLeft:
				return TextAlignmentOptions.MidlineLeft;
			case TextAnchor.MiddleCenter:
				return TextAlignmentOptions.Midline;
			case TextAnchor.MiddleRight:
				return TextAlignmentOptions.MidlineRight;
			case TextAnchor.LowerLeft:
				return TextAlignmentOptions.BottomLeft;
			case TextAnchor.LowerCenter:
				return TextAlignmentOptions.Bottom;
			case TextAnchor.LowerRight:
				return TextAlignmentOptions.BottomRight;
			default:
				throw new ArgumentOutOfRangeException(an.ToString());
			}
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x00026198 File Offset: 0x00024398
		public static TextAnchor ParseToAnchor(TextAlignmentOptions al)
		{
			if (al <= TextAlignmentOptions.Baseline)
			{
				if (al > TextAlignmentOptions.Justified)
				{
					if (al <= TextAlignmentOptions.BottomRight)
					{
						if (al == TextAlignmentOptions.Flush || al == TextAlignmentOptions.CenterGeoAligned)
						{
							goto IL_01CC;
						}
						switch (al)
						{
						case TextAlignmentOptions.BottomLeft:
							return TextAnchor.LowerLeft;
						case TextAlignmentOptions.Bottom:
							break;
						case (TextAlignmentOptions)1027:
							goto IL_01E6;
						case TextAlignmentOptions.BottomRight:
							return TextAnchor.LowerRight;
						default:
							goto IL_01E6;
						}
					}
					else if (al <= TextAlignmentOptions.BottomFlush)
					{
						if (al != TextAlignmentOptions.BottomJustified)
						{
							if (al != TextAlignmentOptions.BottomFlush)
							{
								goto IL_01E6;
							}
							goto IL_01CC;
						}
					}
					else
					{
						if (al != TextAlignmentOptions.BottomGeoAligned && al - TextAlignmentOptions.BaselineLeft > 1)
						{
							goto IL_01E6;
						}
						goto IL_01CC;
					}
					return TextAnchor.LowerCenter;
				}
				if (al <= TextAlignmentOptions.TopFlush)
				{
					switch (al)
					{
					case TextAlignmentOptions.TopLeft:
						return TextAnchor.UpperLeft;
					case TextAlignmentOptions.Top:
						return TextAnchor.UpperCenter;
					case (TextAlignmentOptions)259:
						goto IL_01E6;
					case TextAlignmentOptions.TopRight:
						return TextAnchor.UpperRight;
					default:
						if (al == TextAlignmentOptions.TopJustified)
						{
							return TextAnchor.UpperRight;
						}
						if (al != TextAlignmentOptions.TopFlush)
						{
							goto IL_01E6;
						}
						break;
					}
				}
				else if (al != TextAlignmentOptions.TopGeoAligned)
				{
					switch (al)
					{
					case TextAlignmentOptions.Left:
						return TextAnchor.MiddleLeft;
					case TextAlignmentOptions.Center:
						return TextAnchor.MiddleCenter;
					case (TextAlignmentOptions)515:
						goto IL_01E6;
					case TextAlignmentOptions.Right:
						return TextAnchor.MiddleRight;
					default:
						if (al != TextAlignmentOptions.Justified)
						{
							goto IL_01E6;
						}
						return TextAnchor.MiddleCenter;
					}
				}
			}
			else if (al <= TextAlignmentOptions.MidlineFlush)
			{
				if (al <= TextAlignmentOptions.BaselineFlush)
				{
					if (al != TextAlignmentOptions.BaselineRight && al != TextAlignmentOptions.BaselineJustified && al != TextAlignmentOptions.BaselineFlush)
					{
						goto IL_01E6;
					}
				}
				else if (al <= TextAlignmentOptions.MidlineRight)
				{
					if (al != TextAlignmentOptions.BaselineGeoAligned)
					{
						switch (al)
						{
						case TextAlignmentOptions.MidlineLeft:
							return TextAnchor.MiddleLeft;
						case TextAlignmentOptions.Midline:
							return TextAnchor.MiddleCenter;
						case (TextAlignmentOptions)4099:
							goto IL_01E6;
						case TextAlignmentOptions.MidlineRight:
							return TextAnchor.MiddleRight;
						default:
							goto IL_01E6;
						}
					}
				}
				else
				{
					if (al == TextAlignmentOptions.MidlineJustified)
					{
						return TextAnchor.MiddleCenter;
					}
					if (al != TextAlignmentOptions.MidlineFlush)
					{
						goto IL_01E6;
					}
				}
			}
			else if (al <= TextAlignmentOptions.CaplineRight)
			{
				if (al != TextAlignmentOptions.MidlineGeoAligned && al - TextAlignmentOptions.CaplineLeft > 1 && al != TextAlignmentOptions.CaplineRight)
				{
					goto IL_01E6;
				}
			}
			else if (al <= TextAlignmentOptions.CaplineFlush)
			{
				if (al != TextAlignmentOptions.CaplineJustified && al != TextAlignmentOptions.CaplineFlush)
				{
					goto IL_01E6;
				}
			}
			else if (al != TextAlignmentOptions.CaplineGeoAligned && al != TextAlignmentOptions.Converted)
			{
				goto IL_01E6;
			}
			IL_01CC:
			throw new NotImplementedException();
			IL_01E6:
			throw new ArgumentOutOfRangeException(al.ToString());
		}

		// Token: 0x040003CD RID: 973
		private int? m_fontSize;

		// Token: 0x040003CE RID: 974
		private FontStyles? m_fontStyle;

		// Token: 0x040003CF RID: 975
		private float? m_fontSizeMod;

		// Token: 0x040003D0 RID: 976
		private TextAlignmentOptions? m_alignment;

		// Token: 0x040003D1 RID: 977
		private ColorEnum? m_color;
	}
}
