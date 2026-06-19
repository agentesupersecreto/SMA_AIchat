using System;
using NodeEditorFramework.Utilities;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000090 RID: 144
	public static class NodeEditorGUI
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x00012D8C File Offset: 0x00010F8C
		public static void DrawConnection(Vector2 startPos, Vector2 startDir, Vector2 endPos, Vector2 endDir, ConnectionDrawMethod drawMethod, Color col, float width, float dirFactor)
		{
			if (drawMethod == ConnectionDrawMethod.Bezier)
			{
				RTEditorGUI.DrawBezier(startPos, endPos, startPos + startDir * dirFactor, endPos + endDir * dirFactor, col * Color.gray, null, width);
				return;
			}
			if (drawMethod == ConnectionDrawMethod.StraightLine)
			{
				RTEditorGUI.DrawLine(startPos, endPos, col * Color.gray, null, width);
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00012DEC File Offset: 0x00010FEC
		public static bool Init(bool GUIFunction)
		{
			NodeEditorGUI.Background = ResourceManager.LoadTexture("Textures/background.png");
			NodeEditorGUI.AALineTex = ResourceManager.LoadTexture("Textures/AALine.png");
			NodeEditorGUI.GUIBox = ResourceManager.LoadTexture("Textures/NE_Box.png");
			NodeEditorGUI.GUIButton = ResourceManager.LoadTexture("Textures/NE_Button.png");
			NodeEditorGUI.GUIBoxSelection = ResourceManager.LoadTexture("Textures/BoxSelection.png");
			if (!NodeEditorGUI.Background || !NodeEditorGUI.AALineTex || !NodeEditorGUI.GUIBox || !NodeEditorGUI.GUIButton)
			{
				return false;
			}
			if (!GUIFunction)
			{
				return true;
			}
			NodeEditorGUI.nodeSkin = Object.Instantiate<GUISkin>(GUI.skin);
			NodeEditorGUI.nodeSkin.label.normal.textColor = NodeEditorGUI.NE_TextColor;
			NodeEditorGUI.nodeLabel = NodeEditorGUI.nodeSkin.label;
			NodeEditorGUI.nodeSkin.box.normal.textColor = NodeEditorGUI.NE_TextColor;
			NodeEditorGUI.nodeSkin.box.normal.background = NodeEditorGUI.GUIBox;
			NodeEditorGUI.nodeBox = NodeEditorGUI.nodeSkin.box;
			NodeEditorGUI.nodeSkin.button.normal.textColor = NodeEditorGUI.NE_TextColor;
			NodeEditorGUI.nodeSkin.button.normal.background = NodeEditorGUI.GUIButton;
			NodeEditorGUI.nodeSkin.textArea.normal.background = NodeEditorGUI.GUIBox;
			NodeEditorGUI.nodeSkin.textArea.active.background = NodeEditorGUI.GUIBox;
			NodeEditorGUI.nodeLabelBold = new GUIStyle(NodeEditorGUI.nodeLabel);
			NodeEditorGUI.nodeLabelBold.fontStyle = FontStyle.Bold;
			NodeEditorGUI.nodeLabelSelected = new GUIStyle(NodeEditorGUI.nodeLabel);
			NodeEditorGUI.nodeLabelSelected.normal.background = RTEditorGUI.ColorToTex(1, NodeEditorGUI.NE_LightColor);
			NodeEditorGUI.nodeBoxBold = new GUIStyle(NodeEditorGUI.nodeBox);
			NodeEditorGUI.nodeBoxBold.fontStyle = FontStyle.Bold;
			return true;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00012FB5 File Offset: 0x000111B5
		public static void StartNodeGUI()
		{
			NodeEditorGUI.defaultSkin = GUI.skin;
			if (NodeEditorGUI.nodeSkin == null)
			{
				NodeEditorGUI.Init(true);
			}
			GUI.skin = NodeEditorGUI.nodeSkin;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00012FDF File Offset: 0x000111DF
		public static void EndNodeGUI()
		{
			GUI.skin = NodeEditorGUI.defaultSkin;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00012FEC File Offset: 0x000111EC
		public static void DrawConnection(Vector2 startPos, Vector2 endPos, Color col)
		{
			Vector2 vector = ((startPos.x <= endPos.x) ? Vector2.right : Vector2.left);
			NodeEditorGUI.DrawConnection(startPos, vector, endPos, -vector, col);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00013023 File Offset: 0x00011223
		public static void DrawConnection(Vector2 startPos, Vector2 startDir, Vector2 endPos, Vector2 endDir, Color col)
		{
			NodeEditorGUI.DrawConnection(startPos, startDir, endPos, endDir, ConnectionDrawMethod.Bezier, col);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00013034 File Offset: 0x00011234
		public static void DrawConnection(Vector2 startPos, Vector2 startDir, Vector2 endPos, Vector2 endDir, ConnectionDrawMethod drawMethod, Color col)
		{
			if (drawMethod == ConnectionDrawMethod.Bezier)
			{
				float num = 80f;
				RTEditorGUI.DrawBezier(startPos, endPos, startPos + startDir * num, endPos + endDir * num, col * Color.gray, null, 3f);
				return;
			}
			if (drawMethod == ConnectionDrawMethod.StraightLine)
			{
				RTEditorGUI.DrawLine(startPos, endPos, col * Color.gray, null, 3f);
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000130A0 File Offset: 0x000112A0
		internal static Vector2 GetSecondConnectionVector(Vector2 startPos, Vector2 endPos, Vector2 firstVector)
		{
			if (firstVector.x != 0f && firstVector.y == 0f)
			{
				if (startPos.x > endPos.x)
				{
					return firstVector;
				}
				return -firstVector;
			}
			else
			{
				if (firstVector.y == 0f || firstVector.x != 0f)
				{
					return -firstVector;
				}
				if (startPos.y > endPos.y)
				{
					return firstVector;
				}
				return -firstVector;
			}
		}

		// Token: 0x040000FC RID: 252
		public static int knobSize = 16;

		// Token: 0x040000FD RID: 253
		public static Color NE_LightColor = new Color(0.4f, 0.4f, 0.4f);

		// Token: 0x040000FE RID: 254
		public static Color NE_TextColor = new Color(0.7f, 0.7f, 0.7f);

		// Token: 0x040000FF RID: 255
		public static Texture2D Background;

		// Token: 0x04000100 RID: 256
		public static Texture2D AALineTex;

		// Token: 0x04000101 RID: 257
		public static Texture2D GUIBox;

		// Token: 0x04000102 RID: 258
		public static Texture2D GUIButton;

		// Token: 0x04000103 RID: 259
		public static Texture2D GUIBoxSelection;

		// Token: 0x04000104 RID: 260
		public static GUISkin nodeSkin;

		// Token: 0x04000105 RID: 261
		public static GUISkin defaultSkin;

		// Token: 0x04000106 RID: 262
		public static GUIStyle nodeLabel;

		// Token: 0x04000107 RID: 263
		public static GUIStyle nodeLabelBold;

		// Token: 0x04000108 RID: 264
		public static GUIStyle nodeLabelSelected;

		// Token: 0x04000109 RID: 265
		public static GUIStyle nodeBox;

		// Token: 0x0400010A RID: 266
		public static GUIStyle nodeBoxBold;
	}
}
