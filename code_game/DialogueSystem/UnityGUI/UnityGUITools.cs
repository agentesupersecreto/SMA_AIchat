using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D0 RID: 720
	public static class UnityGUITools
	{
		// Token: 0x06001D88 RID: 7560 RVA: 0x000397D4 File Offset: 0x000379D4
		public static void DrawText(Rect rect, string text, GUIStyle guiStyle, TextStyle textStyle = TextStyle.None)
		{
			if (textStyle == TextStyle.Outline || textStyle == TextStyle.Shadow)
			{
				Color textColor = guiStyle.normal.textColor;
				guiStyle.normal.textColor = new Color(0f, 0f, 0f, guiStyle.normal.textColor.a);
				GUI.Label(new Rect(rect.x + 1f, rect.y + 1f, rect.width, rect.height), text, guiStyle);
				if (textStyle == TextStyle.Outline)
				{
					GUI.Label(new Rect(rect.x + 1f, rect.y - 1f, rect.width, rect.height), text, guiStyle);
					GUI.Label(new Rect(rect.x - 1f, rect.y + 1f, rect.width, rect.height), text, guiStyle);
					GUI.Label(new Rect(rect.x - 1f, rect.y - 1f, rect.width, rect.height), text, guiStyle);
				}
				guiStyle.normal.textColor = textColor;
			}
			GUI.Label(rect, text, guiStyle);
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x00039918 File Offset: 0x00037B18
		public static void DrawText(Rect rect, string text, GUIStyle guiStyle, TextStyle textStyle, Color textStyleColor)
		{
			if (textStyle == TextStyle.Outline || textStyle == TextStyle.Shadow)
			{
				Color textColor = guiStyle.normal.textColor;
				guiStyle.normal.textColor = new Color(textStyleColor.r, textStyleColor.g, textStyleColor.b, guiStyle.normal.textColor.a);
				GUI.Label(new Rect(rect.x + 1f, rect.y + 1f, rect.width, rect.height), text, guiStyle);
				if (textStyle == TextStyle.Outline)
				{
					GUI.Label(new Rect(rect.x + 1f, rect.y - 1f, rect.width, rect.height), text, guiStyle);
					GUI.Label(new Rect(rect.x - 1f, rect.y + 1f, rect.width, rect.height), text, guiStyle);
					GUI.Label(new Rect(rect.x - 1f, rect.y - 1f, rect.width, rect.height), text, guiStyle);
				}
				guiStyle.normal.textColor = textColor;
			}
			GUI.Label(rect, text, guiStyle);
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x00039A64 File Offset: 0x00037C64
		public static GUISkin GetValidGUISkin(GUISkin guiSkin)
		{
			return (!(guiSkin != null)) ? UnityGUITools.GetDialogueManagerGUISkin() : guiSkin;
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x00039A80 File Offset: 0x00037C80
		public static GUISkin GetDialogueManagerGUISkin()
		{
			UnityDialogueUI unityDialogueUI = DialogueManager.DialogueUI as UnityDialogueUI;
			return (!(unityDialogueUI != null) || !(unityDialogueUI.guiRoot != null) || !(unityDialogueUI.guiRoot.guiSkin != null)) ? GUI.skin : unityDialogueUI.guiRoot.guiSkin;
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x00039AE0 File Offset: 0x00037CE0
		public static GUIStyle GetGUIStyle(string guiStyleName, GUIStyle defaultGUIStyle)
		{
			GUIStyle guistyle = ((!string.IsNullOrEmpty(guiStyleName)) ? GUI.skin.FindStyle(guiStyleName) : null);
			return new GUIStyle(guistyle ?? defaultGUIStyle);
		}

		// Token: 0x06001D8D RID: 7565 RVA: 0x00039B18 File Offset: 0x00037D18
		public static Color ColorWithAlpha(Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}

		// Token: 0x06001D8E RID: 7566 RVA: 0x00039B38 File Offset: 0x00037D38
		public static FontStyle ApplyBold(FontStyle fontStyle)
		{
			return (fontStyle != FontStyle.Italic) ? FontStyle.Bold : FontStyle.BoldAndItalic;
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x00039B48 File Offset: 0x00037D48
		public static FontStyle ApplyItalic(FontStyle fontStyle)
		{
			return (fontStyle != FontStyle.Bold) ? FontStyle.Italic : FontStyle.BoldAndItalic;
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x00039B58 File Offset: 0x00037D58
		public static GUIStyle ApplyFormatting(FormattedText formattingToApply, GUIStyle guiStyle)
		{
			if (guiStyle != null && formattingToApply != null)
			{
				if (formattingToApply.italic)
				{
					guiStyle.fontStyle = UnityGUITools.ApplyItalic(guiStyle.fontStyle);
				}
				if (formattingToApply.emphases != null && formattingToApply.emphases.Length > 0)
				{
					guiStyle.normal.textColor = formattingToApply.emphases[0].color;
					if (formattingToApply.emphases[0].bold)
					{
						guiStyle.fontStyle = UnityGUITools.ApplyBold(guiStyle.fontStyle);
					}
					if (formattingToApply.emphases[0].italic)
					{
						guiStyle.fontStyle = UnityGUITools.ApplyItalic(guiStyle.fontStyle);
					}
				}
			}
			return guiStyle;
		}
	}
}
