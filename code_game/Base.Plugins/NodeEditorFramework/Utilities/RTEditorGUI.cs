using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace NodeEditorFramework.Utilities
{
	// Token: 0x0200009F RID: 159
	public static class RTEditorGUI
	{
		// Token: 0x060004CB RID: 1227 RVA: 0x000156B4 File Offset: 0x000138B4
		public static string TextField(GUIContent label, string text)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(label, new GUILayoutOption[] { (label != GUIContent.none) ? GUILayout.ExpandWidth(true) : GUILayout.ExpandWidth(false) });
			text = GUILayout.TextField(text, Array.Empty<GUILayoutOption>());
			GUILayout.EndHorizontal();
			return text;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00015703 File Offset: 0x00013903
		public static float Slider(float value, float minValue, float maxValue, params GUILayoutOption[] sliderOptions)
		{
			return RTEditorGUI.Slider(GUIContent.none, value, minValue, maxValue, sliderOptions);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00015714 File Offset: 0x00013914
		public static float Slider(GUIContent label, float value, float minValue, float maxValue, params GUILayoutOption[] sliderOptions)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			if (label != GUIContent.none)
			{
				GUILayout.Label(label, new GUILayoutOption[] { GUILayout.ExpandWidth(true) });
			}
			value = GUILayout.HorizontalSlider(value, minValue, maxValue, sliderOptions);
			value = Mathf.Min(maxValue, Mathf.Max(minValue, RTEditorGUI.FloatField(value, Array.Empty<GUILayoutOption>())));
			GUILayout.EndHorizontal();
			return value;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00015773 File Offset: 0x00013973
		public static int IntSlider(GUIContent label, int value, int minValue, int maxValue, params GUILayoutOption[] sliderOptions)
		{
			return (int)RTEditorGUI.Slider(label, (float)value, (float)minValue, (float)maxValue, sliderOptions);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00015784 File Offset: 0x00013984
		public static int IntSlider(int value, int minValue, int maxValue, params GUILayoutOption[] sliderOptions)
		{
			return (int)RTEditorGUI.Slider(GUIContent.none, (float)value, (float)minValue, (float)maxValue, sliderOptions);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00015798 File Offset: 0x00013998
		public static float FloatField(GUIContent label, float value, params GUILayoutOption[] fieldOptions)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			if (label != GUIContent.none)
			{
				GUILayout.Label(label, new GUILayoutOption[] { GUILayout.ExpandWidth(true) });
			}
			value = RTEditorGUI.FloatField(value, fieldOptions);
			GUILayout.EndHorizontal();
			return value;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000157D0 File Offset: 0x000139D0
		public static float FloatField(float value, params GUILayoutOption[] fieldOptions)
		{
			if (fieldOptions.Length == 0)
			{
				fieldOptions = new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(false),
					GUILayout.MinWidth(50f)
				};
			}
			Rect rect = GUILayoutUtility.GetRect(new GUIContent(value.ToString()), GUI.skin.label, fieldOptions);
			int num = GUIUtility.GetControlID("FloatField".GetHashCode(), FocusType.Keyboard, rect) + 1;
			if (num == 0)
			{
				return value;
			}
			bool flag = RTEditorGUI.activeFloatField == num;
			bool flag2 = num == GUIUtility.keyboardControl;
			if (flag2 && flag && RTEditorGUI.activeFloatFieldLastValue != value)
			{
				RTEditorGUI.activeFloatFieldLastValue = value;
				RTEditorGUI.activeFloatFieldString = value.ToString();
			}
			string text = (flag ? RTEditorGUI.activeFloatFieldString : value.ToString());
			string text2 = GUI.TextField(rect, text);
			if (flag)
			{
				RTEditorGUI.activeFloatFieldString = text2;
			}
			bool flag3 = true;
			if (text2 == "")
			{
				value = (RTEditorGUI.activeFloatFieldLastValue = 0f);
			}
			else if (text2 != value.ToString())
			{
				float num2;
				flag3 = float.TryParse(text2, out num2);
				if (flag3)
				{
					value = (RTEditorGUI.activeFloatFieldLastValue = num2);
				}
			}
			if (flag2 && !flag)
			{
				RTEditorGUI.activeFloatField = num;
				RTEditorGUI.activeFloatFieldString = text2;
				RTEditorGUI.activeFloatFieldLastValue = value;
			}
			else if (!flag2 && flag)
			{
				RTEditorGUI.activeFloatField = -1;
				if (!flag3)
				{
					value = text2.ForceParse();
				}
			}
			return value;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00015910 File Offset: 0x00013B10
		public static float ForceParse(this string str)
		{
			float num;
			if (float.TryParse(str, out num))
			{
				return num;
			}
			bool flag = false;
			List<char> list = new List<char>(str);
			for (int i = 0; i < list.Count; i++)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(str[i]) != UnicodeCategory.DecimalDigitNumber)
				{
					list.RemoveRange(i, list.Count - i);
					break;
				}
				if (str[i] == '.')
				{
					if (flag)
					{
						list.RemoveRange(i, list.Count - i);
						break;
					}
					flag = true;
				}
			}
			if (list.Count == 0)
			{
				return 0f;
			}
			str = new string(list.ToArray());
			if (!float.TryParse(str, out num))
			{
				Debug.LogError("Could not parse " + str);
			}
			return num;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000159BA File Offset: 0x00013BBA
		public static T ObjectField<T>(T obj, bool allowSceneObjects) where T : Object
		{
			return RTEditorGUI.ObjectField<T>(GUIContent.none, obj, allowSceneObjects);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x000159C8 File Offset: 0x00013BC8
		public static T ObjectField<T>(GUIContent label, T obj, bool allowSceneObjects) where T : Object
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x000159CF File Offset: 0x00013BCF
		public static Enum EnumPopup(GUIContent label, Enum selected)
		{
			label.text = label.text + ": " + selected.ToString();
			GUILayout.Label(label, Array.Empty<GUILayoutOption>());
			return selected;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000159F9 File Offset: 0x00013BF9
		public static Enum EnumPopup(string label, Enum selected)
		{
			GUILayout.Label(label + ": " + selected.ToString(), Array.Empty<GUILayoutOption>());
			return selected;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00015A17 File Offset: 0x00013C17
		public static Enum EnumPopup(Enum selected)
		{
			GUILayout.Label(selected.ToString(), Array.Empty<GUILayoutOption>());
			return selected;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00015A2A File Offset: 0x00013C2A
		public static int Popup(GUIContent label, int selected, string[] displayedOptions)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			label.text = label.text + ": " + selected.ToString();
			GUILayout.Label(label, Array.Empty<GUILayoutOption>());
			GUILayout.EndHorizontal();
			return selected;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00015A64 File Offset: 0x00013C64
		public static int Popup(string label, int selected, string[] displayedOptions)
		{
			GUILayout.Label(label + ": " + selected.ToString(), Array.Empty<GUILayoutOption>());
			return selected;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00015A83 File Offset: 0x00013C83
		public static int Popup(int selected, string[] displayedOptions)
		{
			GUILayout.Label(selected.ToString(), Array.Empty<GUILayoutOption>());
			return selected;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00015A97 File Offset: 0x00013C97
		public static void Seperator()
		{
			RTEditorGUI.setupSeperator();
			GUILayout.Box(GUIContent.none, RTEditorGUI.seperator, new GUILayoutOption[] { GUILayout.Height(1f) });
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00015AC0 File Offset: 0x00013CC0
		public static void Seperator(Rect rect)
		{
			RTEditorGUI.setupSeperator();
			GUI.Box(new Rect(rect.x, rect.y, rect.width, 1f), GUIContent.none, RTEditorGUI.seperator);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00015AF8 File Offset: 0x00013CF8
		private static void setupSeperator()
		{
			if (RTEditorGUI.seperator == null)
			{
				RTEditorGUI.seperator = new GUIStyle();
				RTEditorGUI.seperator.normal.background = RTEditorGUI.ColorToTex(1, new Color(0.6f, 0.6f, 0.6f));
				RTEditorGUI.seperator.stretchWidth = true;
				RTEditorGUI.seperator.margin = new RectOffset(0, 0, 7, 7);
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00015B60 File Offset: 0x00013D60
		private static void SetupLineMat(Texture tex, Color col)
		{
			if (RTEditorGUI.lineMaterial == null)
			{
				RTEditorGUI.lineMaterial = new Material(Shader.Find("Hidden/LineShader"));
			}
			if (tex == null)
			{
				tex = ((RTEditorGUI.lineTexture != null) ? RTEditorGUI.lineTexture : (RTEditorGUI.lineTexture = ResourceManager.LoadTexture("Textures/AALine.png")));
			}
			RTEditorGUI.lineMaterial.SetTexture("_LineTexture", tex);
			RTEditorGUI.lineMaterial.SetColor("_LineColor", col);
			RTEditorGUI.lineMaterial.SetPass(0);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00015BEC File Offset: 0x00013DEC
		public static void DrawBezier(Vector2 startPos, Vector2 endPos, Vector2 startTan, Vector2 endTan, Color col)
		{
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}
			bool isPlaying = Application.isPlaying;
			GL.Begin(1);
			GL.Color(col);
			int num = RTEditorGUI.CalculateBezierSegmentCount(startPos, endPos, startTan, endTan);
			Vector2 vector = startPos;
			for (int i = 1; i <= num; i++)
			{
				Vector2 bezierPoint = RTEditorGUI.GetBezierPoint((float)i / (float)num, startPos, endPos, startTan, endTan);
				GL.Vertex(vector);
				GL.Vertex(bezierPoint);
				vector = bezierPoint;
			}
			GL.Vertex(vector);
			GL.Vertex(endPos);
			GL.End();
			GL.Color(Color.white);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00015C7C File Offset: 0x00013E7C
		public static void DrawBezier(Vector2 startPos, Vector2 endPos, Vector2 startTan, Vector2 endTan, Color col, Texture2D tex, float width)
		{
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}
			bool isPlaying = Application.isPlaying;
			if (width == 1f)
			{
				RTEditorGUI.DrawBezier(startPos, endPos, startTan, endTan, col);
				return;
			}
			RTEditorGUI.SetupLineMat(tex, col);
			GL.Begin(5);
			GL.Color(Color.white);
			int num = RTEditorGUI.CalculateBezierSegmentCount(startPos, endPos, startTan, endTan);
			Vector2 vector = startPos;
			for (int i = 1; i <= num; i++)
			{
				Vector2 bezierPoint = RTEditorGUI.GetBezierPoint((float)i / (float)num, startPos, endPos, startTan, endTan);
				RTEditorGUI.DrawLineSegment(vector, new Vector2(bezierPoint.y - vector.y, vector.x - bezierPoint.x).normalized * width / 2f);
				vector = bezierPoint;
			}
			RTEditorGUI.DrawLineSegment(vector, new Vector2(endTan.y, -endTan.x).normalized * width / 2f);
			GL.End();
			GL.Color(Color.white);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00015D74 File Offset: 0x00013F74
		public static int CalculateBezierSegmentCount(Vector2 startPos, Vector2 endPos, Vector2 startTan, Vector2 endTan)
		{
			float num = Vector2.Angle(startTan - startPos, endPos - startPos) * Vector2.Angle(endTan - endPos, startPos - endPos) * (endTan.magnitude + startTan.magnitude);
			num = 2f + Mathf.Pow(num / 400f, 0.125f);
			float num2 = 1f + (startPos - endPos).magnitude;
			num2 = Mathf.Pow(num2, 0.25f);
			return 4 + (int)(num * num2);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00015DFC File Offset: 0x00013FFC
		public static Vector2 GetBezierPoint(float t, Vector2 startPos, Vector2 endPos, Vector2 startTan, Vector2 endTan)
		{
			return startPos * Mathf.Pow(1f - t, 3f) + startTan * 3f * Mathf.Pow(1f - t, 2f) * t + endTan * 3f * (1f - t) * Mathf.Pow(t, 2f) + endPos * Mathf.Pow(t, 3f);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00015E90 File Offset: 0x00014090
		private static void DrawLineSegment(Vector2 point, Vector2 perpendicular)
		{
			Vector2 vector = new Vector2(perpendicular.y, -perpendicular.x) * 2f;
			GL.TexCoord2(0f, 0f);
			GL.Vertex(point - vector - perpendicular);
			GL.TexCoord2(0f, 1f);
			GL.Vertex(point - vector + perpendicular);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00015F08 File Offset: 0x00014108
		public static void DrawLine(Vector2 startPos, Vector2 endPos, Color col, Texture2D tex, float width)
		{
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}
			if (width <= 1f)
			{
				GL.Begin(1);
				GL.Color(col);
				GL.Vertex(startPos);
				GL.Vertex(endPos);
				GL.End();
				GL.Color(Color.white);
				return;
			}
			RTEditorGUI.SetupLineMat(tex, col);
			GL.Begin(5);
			GL.Color(Color.white);
			Vector2 vector = new Vector2((endPos - startPos).y, -(endPos - startPos).x).normalized * width / 2f;
			RTEditorGUI.DrawLineSegment(startPos, vector);
			RTEditorGUI.DrawLineSegment(endPos, vector);
			GL.End();
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00015FC0 File Offset: 0x000141C0
		public static Texture2D ColorToTex(int pxSize, Color col)
		{
			Texture2D texture2D = new Texture2D(pxSize, pxSize);
			for (int i = 0; i < pxSize; i++)
			{
				for (int j = 0; j < pxSize; j++)
				{
					texture2D.SetPixel(i, j, col);
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00016000 File Offset: 0x00014200
		public static Texture2D Tint(Texture2D tex, Color color)
		{
			Texture2D texture2D = Object.Instantiate<Texture2D>(tex);
			for (int i = 0; i < tex.width; i++)
			{
				for (int j = 0; j < tex.height; j++)
				{
					texture2D.SetPixel(i, j, tex.GetPixel(i, j) * color);
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00016054 File Offset: 0x00014254
		public static Texture2D RotateTextureCCW(Texture2D tex, int quarterSteps)
		{
			if (tex == null)
			{
				return null;
			}
			tex = Object.Instantiate<Texture2D>(tex);
			int width = tex.width;
			int height = tex.height;
			Color[] pixels = tex.GetPixels();
			Color[] array = new Color[width * height];
			for (int i = 0; i < quarterSteps; i++)
			{
				for (int j = 0; j < width; j++)
				{
					for (int k = 0; k < height; k++)
					{
						array[j * width + k] = pixels[(width - k - 1) * width + j];
					}
				}
				array.CopyTo(pixels, 0);
			}
			tex.SetPixels(pixels);
			tex.Apply();
			return tex;
		}

		// Token: 0x04000148 RID: 328
		private static int activeFloatField = -1;

		// Token: 0x04000149 RID: 329
		private static float activeFloatFieldLastValue = 0f;

		// Token: 0x0400014A RID: 330
		private static string activeFloatFieldString = "";

		// Token: 0x0400014B RID: 331
		private static GUIStyle seperator;

		// Token: 0x0400014C RID: 332
		private static Material lineMaterial;

		// Token: 0x0400014D RID: 333
		private static Texture2D lineTexture;
	}
}
