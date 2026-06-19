using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B5 RID: 693
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Label")]
	public class GUILabel : GUIVisibleControl
	{
		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06001D01 RID: 7425 RVA: 0x00037068 File Offset: 0x00035268
		// (set) Token: 0x06001D02 RID: 7426 RVA: 0x00037070 File Offset: 0x00035270
		public int currentLength
		{
			get
			{
				return this.substringLength;
			}
			set
			{
				this.substringLength = value;
				this.useSubstring = !string.IsNullOrEmpty(this.text) && this.substringLength < this.text.Length;
			}
		}

		// Token: 0x06001D03 RID: 7427 RVA: 0x000370A8 File Offset: 0x000352A8
		public override void Awake()
		{
			base.Awake();
			this.ResetClosureTags();
		}

		// Token: 0x06001D04 RID: 7428 RVA: 0x000370B8 File Offset: 0x000352B8
		public void ResetClosureTags()
		{
			this.closureTags.Clear();
		}

		// Token: 0x06001D05 RID: 7429 RVA: 0x000370C8 File Offset: 0x000352C8
		public void PushClosureTag(string tag)
		{
			this.closureTags.Add(tag);
		}

		// Token: 0x06001D06 RID: 7430 RVA: 0x000370D8 File Offset: 0x000352D8
		public void PopClosureTag()
		{
			if (this.closureTags.Count > 0)
			{
				this.closureTags.RemoveAt(this.closureTags.Count - 1);
			}
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x00037104 File Offset: 0x00035304
		public override void SetFormattedText(FormattedText formattedText)
		{
			base.SetFormattedText(formattedText);
			this.ResetClosureTags();
		}

		// Token: 0x06001D08 RID: 7432 RVA: 0x00037114 File Offset: 0x00035314
		public override void DrawSelf(Vector2 relativeMousePosition)
		{
			base.ApplyAlphaToGUIColor();
			if (this.image != null)
			{
				this.DrawImage();
			}
			if (!string.IsNullOrEmpty(this.text))
			{
				if (this.useSubstring)
				{
					this.DrawSubstring();
				}
				else
				{
					UnityGUITools.DrawText(base.rect, this.text, base.GuiStyle, this.textStyle, this.textStyleColor);
				}
			}
			base.RestoreGUIColor();
		}

		// Token: 0x06001D09 RID: 7433 RVA: 0x00037190 File Offset: 0x00035390
		private void DrawSubstring()
		{
			if (this.IsLeftAligned(base.GuiStyle.alignment))
			{
				this.DrawSubstringLeftAligned();
			}
			else
			{
				this.DrawSubstringNotLeftAligned();
			}
		}

		// Token: 0x06001D0A RID: 7434 RVA: 0x000371C4 File Offset: 0x000353C4
		private bool IsLeftAligned(TextAnchor textAnchor)
		{
			return textAnchor == TextAnchor.LowerLeft || textAnchor == TextAnchor.MiddleLeft || textAnchor == TextAnchor.UpperLeft;
		}

		// Token: 0x06001D0B RID: 7435 RVA: 0x000371DC File Offset: 0x000353DC
		private bool IsCenterAligned(TextAnchor textAnchor)
		{
			return textAnchor == TextAnchor.LowerCenter || textAnchor == TextAnchor.MiddleCenter || textAnchor == TextAnchor.UpperCenter;
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x000371F4 File Offset: 0x000353F4
		private TextAnchor GetLeftAlignedVersion(TextAnchor textAnchor)
		{
			switch (textAnchor)
			{
			case TextAnchor.UpperCenter:
			case TextAnchor.UpperRight:
				return TextAnchor.UpperLeft;
			case TextAnchor.MiddleCenter:
			case TextAnchor.MiddleRight:
				return TextAnchor.MiddleLeft;
			case TextAnchor.LowerCenter:
			case TextAnchor.LowerRight:
				return TextAnchor.LowerLeft;
			}
			return textAnchor;
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x00037238 File Offset: 0x00035438
		private void DrawSubstringLeftAligned()
		{
			string text = string.Empty;
			int num = 0;
			int i = this.substringLength;
			while (i > 0)
			{
				string nextLine = this.GetNextLine(this.text, num);
				string text2 = nextLine.Substring(0, Mathf.Min(nextLine.Length, i));
				num += nextLine.Length;
				i -= nextLine.Length;
				if (string.IsNullOrEmpty(text))
				{
					text = text2;
				}
				else
				{
					text = text + "\n" + text2;
				}
			}
			UnityGUITools.DrawText(base.rect, this.GetRichTextClosedText(text), base.GuiStyle, this.textStyle, this.textStyleColor);
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x000372DC File Offset: 0x000354DC
		private void DrawSubstringNotLeftAligned()
		{
			TextAnchor alignment = base.GuiStyle.alignment;
			bool wordWrap = base.GuiStyle.wordWrap;
			base.GuiStyle.alignment = this.GetLeftAlignedVersion(base.GuiStyle.alignment);
			base.GuiStyle.wordWrap = false;
			float y = base.GuiStyle.CalcSize(new GUIContent(this.text)).y;
			float num = base.rect.y;
			int num2 = 0;
			int i = this.substringLength;
			while (i > 0)
			{
				string nextLine = this.GetNextLine(this.text, num2);
				string text = nextLine.Substring(0, Mathf.Min(nextLine.Length, i));
				num2 += nextLine.Length;
				i -= nextLine.Length;
				float x = base.GuiStyle.CalcSize(new GUIContent(nextLine.Trim())).x;
				float num3 = ((!this.IsCenterAligned(alignment)) ? (base.rect.x + base.rect.width - x) : (Mathf.Ceil(base.rect.x + 0.5f * base.rect.width - 0.5f * x) + 0.5f));
				UnityGUITools.DrawText(new Rect(num3, num, base.rect.width, y), this.GetRichTextClosedText(text.Trim()), base.GuiStyle, this.textStyle, this.textStyleColor);
				num += base.GuiStyle.lineHeight;
			}
			base.GuiStyle.alignment = alignment;
			base.GuiStyle.wordWrap = wordWrap;
		}

		// Token: 0x06001D0F RID: 7439 RVA: 0x000374A4 File Offset: 0x000356A4
		private string GetNextLine(string text, int start)
		{
			string text2 = text.Substring(start);
			int num = 0;
			if (base.GuiStyle.CalcSize(new GUIContent(text2.Trim())).x > base.rect.width)
			{
				int num2 = 1;
				while (start + num2 < text.Length)
				{
					string text3 = text.Substring(start, num2 + 1);
					if (text[start + num2] == ' ')
					{
						num = num2;
					}
					float x = base.GuiStyle.CalcSize(new GUIContent(text3.Trim())).x;
					if (x < base.rect.width)
					{
						num2++;
					}
					else
					{
						int length = text2.Length;
						if (num > 0)
						{
							return text.Substring(start, Mathf.Max(1, Mathf.Min(num, length)));
						}
						return text.Substring(start, Mathf.Max(1, Mathf.Min(num2 - 1, length)));
					}
				}
			}
			return text2;
		}

		// Token: 0x06001D10 RID: 7440 RVA: 0x000375A0 File Offset: 0x000357A0
		private string GetRichTextClosedText(string s)
		{
			if (this.closureTags.Count == 0)
			{
				return s;
			}
			if (this.substringLength != this.substringLengthLastGetRichTextClosedString)
			{
				this.substringLengthLastGetRichTextClosedString = this.substringLength;
				StringBuilder stringBuilder = new StringBuilder(s);
				for (int i = this.closureTags.Count - 1; i >= 0; i--)
				{
					stringBuilder.Append(this.closureTags[i]);
				}
				this.richTextClosedString = stringBuilder.ToString();
			}
			return this.richTextClosedString;
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x00037628 File Offset: 0x00035828
		private void DrawImage()
		{
			Color color = GUI.color;
			GUI.color = this.imageColor;
			if (this.imageAnimation.animate)
			{
				this.imageAnimation.DrawAnimation(base.rect, this.image);
			}
			else
			{
				GUI.Label(base.rect, this.image, base.GuiStyle);
			}
			GUI.color = color;
		}

		// Token: 0x06001D12 RID: 7442 RVA: 0x00037690 File Offset: 0x00035890
		public override void Refresh()
		{
			base.Refresh();
			if (this.imageAnimation.animate)
			{
				this.imageAnimation.RefreshAnimation(this.image);
			}
		}

		// Token: 0x04001089 RID: 4233
		public TextStyle textStyle;

		// Token: 0x0400108A RID: 4234
		public Color textStyleColor = Color.black;

		// Token: 0x0400108B RID: 4235
		public Color imageColor = Color.white;

		// Token: 0x0400108C RID: 4236
		public Texture2D image;

		// Token: 0x0400108D RID: 4237
		public ImageAnimation imageAnimation = new ImageAnimation();

		// Token: 0x0400108E RID: 4238
		private List<string> closureTags = new List<string>();

		// Token: 0x0400108F RID: 4239
		private bool useSubstring;

		// Token: 0x04001090 RID: 4240
		private int substringLength;

		// Token: 0x04001091 RID: 4241
		private int substringLengthLastGetRichTextClosedString;

		// Token: 0x04001092 RID: 4242
		private string richTextClosedString = string.Empty;
	}
}
