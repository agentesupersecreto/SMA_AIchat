using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NodeEditorFramework.Utilities
{
	// Token: 0x0200009A RID: 154
	public static class GUIScaleUtility
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x00014340 File Offset: 0x00012540
		public static Rect getTopRect
		{
			get
			{
				return GUIScaleUtility.GetTopRectDelegate();
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0001434C File Offset: 0x0001254C
		public static Rect getTopRectScreenSpace
		{
			get
			{
				return GUIScaleUtility.topmostRectDelegate();
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x00014358 File Offset: 0x00012558
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x0001435F File Offset: 0x0001255F
		public static List<Rect> currentRectStack { get; private set; }

		// Token: 0x0600049A RID: 1178 RVA: 0x00014367 File Offset: 0x00012567
		public static void CheckInit()
		{
			if (!GUIScaleUtility.initiated)
			{
				GUIScaleUtility.Init();
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00014378 File Offset: 0x00012578
		public static void Init()
		{
			Type type = Assembly.GetAssembly(typeof(GUI)).GetType("UnityEngine.GUIClip", true);
			PropertyInfo property = type.GetProperty("topmostRect", BindingFlags.Static | BindingFlags.Public);
			MethodInfo method = type.GetMethod("GetTopRect", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo method2 = type.GetMethod("Clip", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder, new Type[] { typeof(Rect) }, new ParameterModifier[0]);
			if (type == null || property == null || method == null || method2 == null)
			{
				Debug.LogWarning("GUIScaleUtility cannot run on this system! Compability mode enabled. For you that means you're not able to use the Node Editor inside more than one group:( Please PM me (Seneral @UnityForums) so I can figure out what causes this! Thanks!");
				Debug.LogWarning(((type == null) ? "GUIClipType is Null, " : "") + ((property == null) ? "topmostRect is Null, " : "") + ((method == null) ? "GetTopRect is Null, " : "") + ((method2 == null) ? "ClipRect is Null, " : ""));
				GUIScaleUtility.compabilityMode = true;
				GUIScaleUtility.initiated = true;
				return;
			}
			GUIScaleUtility.GetTopRectDelegate = (Func<Rect>)Delegate.CreateDelegate(typeof(Func<Rect>), method);
			GUIScaleUtility.topmostRectDelegate = (Func<Rect>)Delegate.CreateDelegate(typeof(Func<Rect>), property.GetGetMethod());
			GUIScaleUtility.currentRectStack = new List<Rect>();
			GUIScaleUtility.rectStackGroups = new List<List<Rect>>();
			GUIScaleUtility.GUIMatrices = new List<Matrix4x4>();
			GUIScaleUtility.adjustedGUILayout = new List<bool>();
			try
			{
				GUIScaleUtility.topmostRectDelegate();
			}
			catch (Exception ex)
			{
				Debug.LogWarning("GUIScaleUtility cannot run on this system! Compability mode enabled. For you that means you're not able to use the Node Editor inside more than one group:( Please PM me (Seneral @UnityForums) so I can figure out what causes this! Thanks!");
				Debug.Log(ex.Message);
				GUIScaleUtility.compabilityMode = true;
			}
			GUIScaleUtility.initiated = true;
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x00014524 File Offset: 0x00012724
		public static Vector2 getCurrentScale
		{
			get
			{
				return new Vector2(1f / GUI.matrix.GetColumn(0).magnitude, 1f / GUI.matrix.GetColumn(1).magnitude);
			}
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00014570 File Offset: 0x00012770
		public static Vector2 BeginScale(ref Rect rect, Vector2 zoomPivot, float zoom, bool adjustGUILayout)
		{
			Rect rect2;
			if (GUIScaleUtility.compabilityMode)
			{
				GUI.EndGroup();
				rect2 = rect;
			}
			else
			{
				GUIScaleUtility.BeginNoClip();
				rect2 = GUIScaleUtility.InnerToScreenRect(rect);
			}
			rect = GUIScaleUtility.ScaleRect(rect2, rect2.position + zoomPivot, new Vector2(zoom, zoom));
			GUI.BeginGroup(rect);
			rect.position = Vector2.zero;
			Vector2 vector = rect.center - rect2.size / 2f + zoomPivot;
			GUIScaleUtility.adjustedGUILayout.Add(adjustGUILayout);
			if (adjustGUILayout)
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				GUILayout.Space(rect.center.x - rect2.size.x + zoomPivot.x);
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
				GUILayout.Space(rect.center.y - rect2.size.y + zoomPivot.y);
			}
			GUIScaleUtility.GUIMatrices.Add(GUI.matrix);
			GUIUtility.ScaleAroundPivot(new Vector2(1f / zoom, 1f / zoom), vector);
			return vector;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00014690 File Offset: 0x00012890
		public static void EndScale()
		{
			if (GUIScaleUtility.GUIMatrices.Count == 0 || GUIScaleUtility.adjustedGUILayout.Count == 0)
			{
				throw new UnityException("GUIScaleUtility: You are ending more scale regions than you are beginning!");
			}
			GUI.matrix = GUIScaleUtility.GUIMatrices[GUIScaleUtility.GUIMatrices.Count - 1];
			GUIScaleUtility.GUIMatrices.RemoveAt(GUIScaleUtility.GUIMatrices.Count - 1);
			if (GUIScaleUtility.adjustedGUILayout[GUIScaleUtility.adjustedGUILayout.Count - 1])
			{
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
			GUIScaleUtility.adjustedGUILayout.RemoveAt(GUIScaleUtility.adjustedGUILayout.Count - 1);
			GUI.EndGroup();
			if (!GUIScaleUtility.compabilityMode)
			{
				GUIScaleUtility.RestoreClips();
				return;
			}
			if (!Application.isPlaying)
			{
				GUI.BeginClip(new Rect(0f, 23f, (float)Screen.width, (float)(Screen.height - 23)));
				return;
			}
			GUI.BeginClip(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00014788 File Offset: 0x00012988
		public static void BeginNoClip()
		{
			List<Rect> list = new List<Rect>();
			Rect rect = GUIScaleUtility.getTopRect;
			while (rect != new Rect(-10000f, -10000f, 40000f, 40000f))
			{
				list.Add(rect);
				GUI.EndClip();
				rect = GUIScaleUtility.getTopRect;
			}
			list.Reverse();
			GUIScaleUtility.rectStackGroups.Add(list);
			GUIScaleUtility.currentRectStack.AddRange(list);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000147F4 File Offset: 0x000129F4
		public static void MoveClipsUp(int count)
		{
			List<Rect> list = new List<Rect>();
			Rect rect = GUIScaleUtility.getTopRect;
			while (rect != new Rect(-10000f, -10000f, 40000f, 40000f) && count > 0)
			{
				list.Add(rect);
				GUI.EndClip();
				rect = GUIScaleUtility.getTopRect;
				count--;
			}
			list.Reverse();
			GUIScaleUtility.rectStackGroups.Add(list);
			GUIScaleUtility.currentRectStack.AddRange(list);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00014868 File Offset: 0x00012A68
		public static void RestoreClips()
		{
			if (GUIScaleUtility.rectStackGroups.Count == 0)
			{
				Debug.LogError("GUIClipHierarchy: BeginNoClip/MoveClipsUp - RestoreClips count not balanced!");
				return;
			}
			List<Rect> list = GUIScaleUtility.rectStackGroups[GUIScaleUtility.rectStackGroups.Count - 1];
			for (int i = 0; i < list.Count; i++)
			{
				GUI.BeginClip(list[i]);
				GUIScaleUtility.currentRectStack.RemoveAt(GUIScaleUtility.currentRectStack.Count - 1);
			}
			GUIScaleUtility.rectStackGroups.RemoveAt(GUIScaleUtility.rectStackGroups.Count - 1);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x000148EC File Offset: 0x00012AEC
		public static void BeginNewLayout()
		{
			if (GUIScaleUtility.compabilityMode)
			{
				return;
			}
			Rect getTopRect = GUIScaleUtility.getTopRect;
			if (getTopRect != new Rect(-10000f, -10000f, 40000f, 40000f))
			{
				GUILayout.BeginArea(new Rect(0f, 0f, getTopRect.width, getTopRect.height));
				return;
			}
			GUILayout.BeginArea(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0001496B File Offset: 0x00012B6B
		public static void EndNewLayout()
		{
			if (!GUIScaleUtility.compabilityMode)
			{
				GUILayout.EndArea();
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00014979 File Offset: 0x00012B79
		public static void BeginIgnoreMatrix()
		{
			GUIScaleUtility.GUIMatrices.Add(GUI.matrix);
			GUI.matrix = Matrix4x4.identity;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00014994 File Offset: 0x00012B94
		public static void EndIgnoreMatrix()
		{
			if (GUIScaleUtility.GUIMatrices.Count == 0)
			{
				throw new UnityException("GUIScaleutility: You are ending more ignoreMatrices than you are beginning!");
			}
			GUI.matrix = GUIScaleUtility.GUIMatrices[GUIScaleUtility.GUIMatrices.Count - 1];
			GUIScaleUtility.GUIMatrices.RemoveAt(GUIScaleUtility.GUIMatrices.Count - 1);
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x000149E9 File Offset: 0x00012BE9
		public static Vector2 ScalePosition(Vector2 pos, Vector2 pivot, Vector2 scale)
		{
			return Vector2.Scale(pos - pivot, scale) + pivot;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000149FE File Offset: 0x00012BFE
		public static Rect ScaleRect(Rect rect, Vector2 pivot, Vector2 scale)
		{
			rect.position = Vector2.Scale(rect.position - pivot, scale) + pivot;
			rect.size = Vector2.Scale(rect.size, scale);
			return rect;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00014A38 File Offset: 0x00012C38
		public static Rect InnerToScreenRect(Rect innerRect)
		{
			if (GUIScaleUtility.rectStackGroups == null || GUIScaleUtility.rectStackGroups.Count == 0)
			{
				return innerRect;
			}
			List<Rect> list = GUIScaleUtility.rectStackGroups[GUIScaleUtility.rectStackGroups.Count - 1];
			for (int i = 0; i < list.Count; i++)
			{
				innerRect.position += list[i].position;
			}
			return innerRect;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00014AA4 File Offset: 0x00012CA4
		public static Rect GUIToScreenRect(Rect guiRect)
		{
			guiRect.position += GUIScaleUtility.getTopRectScreenSpace.position;
			return guiRect;
		}

		// Token: 0x04000130 RID: 304
		private static bool compabilityMode;

		// Token: 0x04000131 RID: 305
		private static bool initiated;

		// Token: 0x04000132 RID: 306
		private static Func<Rect> GetTopRectDelegate;

		// Token: 0x04000133 RID: 307
		private static Func<Rect> topmostRectDelegate;

		// Token: 0x04000135 RID: 309
		private static List<List<Rect>> rectStackGroups;

		// Token: 0x04000136 RID: 310
		private static List<Matrix4x4> GUIMatrices;

		// Token: 0x04000137 RID: 311
		private static List<bool> adjustedGUILayout;

		// Token: 0x04000138 RID: 312
		private static FieldInfo currentGUILayoutCache;

		// Token: 0x04000139 RID: 313
		private static FieldInfo currentTopLevelGroup;
	}
}
