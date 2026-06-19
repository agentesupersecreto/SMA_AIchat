using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Graphics
{
	// Token: 0x0200003A RID: 58
	[ExecuteInEditMode]
	public class GraphicsManager : MonoBehaviour
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0000CBC8 File Offset: 0x0000ADC8
		private static float InternalTime
		{
			get
			{
				if (Application.isPlaying)
				{
					return Time.time;
				}
				return (float)GraphicsManager.mInternalTimer.ElapsedMilliseconds / 1000f;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x0000CBF0 File Offset: 0x0000ADF0
		public string DefaultShader
		{
			get
			{
				return this._DefaultShader;
			}
			set
			{
				this._DefaultShader = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000CBF9 File Offset: 0x0000ADF9
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x0000CC01 File Offset: 0x0000AE01
		public Font DefaultFont
		{
			get
			{
				return this._DefaultFont;
			}
			set
			{
				this._DefaultFont = value;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000CC0A File Offset: 0x0000AE0A
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x0000CC12 File Offset: 0x0000AE12
		public bool DrawToSceneView
		{
			get
			{
				return this._DrawToSceneView;
			}
			set
			{
				this._DrawToSceneView = value;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000CC1B File Offset: 0x0000AE1B
		// (set) Token: 0x060002B7 RID: 695 RVA: 0x0000CC23 File Offset: 0x0000AE23
		public bool DrawToGameView
		{
			get
			{
				return this._DrawToGameView;
			}
			set
			{
				this._DrawToGameView = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x0000CC2C File Offset: 0x0000AE2C
		public int LineCount
		{
			get
			{
				return GraphicsManager.mLines.Count;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000CC38 File Offset: 0x0000AE38
		public int TriangleCount
		{
			get
			{
				return GraphicsManager.mTriangles.Count;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public int TextCount
		{
			get
			{
				return GraphicsManager.mText.Count;
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000CC50 File Offset: 0x0000AE50
		private GraphicsManager()
		{
			GraphicsManager.mInternalTimer.Start();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000CC7B File Offset: 0x0000AE7B
		public IEnumerator Start()
		{
			GraphicsManager.CreateMaterials();
			GraphicsManager.mShader = this._DefaultShader;
			GraphicsManager.mFont = this._DefaultFont;
			GraphicsManager.AddFont(GraphicsManager.mFont);
			WaitForEndOfFrame lWait = new WaitForEndOfFrame();
			for (;;)
			{
				yield return lWait;
				if (this._DrawToGameView)
				{
					GraphicsManager.RenderText();
				}
				GraphicsManager.ClearGraphics();
				GraphicsManager.ClearText();
			}
			yield break;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000CC8A File Offset: 0x0000AE8A
		protected void OnPostRender()
		{
			if (this._DrawToGameView)
			{
				GraphicsManager.RenderLines();
				GraphicsManager.RenderTriangles();
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000CCA0 File Offset: 0x0000AEA0
		public static void ClearGraphics()
		{
			float internalTime = GraphicsManager.InternalTime;
			for (int i = GraphicsManager.mLines.Count - 1; i >= 0; i--)
			{
				if (GraphicsManager.mLines[i].ExpirationTime < internalTime)
				{
					Line.Release(GraphicsManager.mLines[i]);
					GraphicsManager.mLines.RemoveAt(i);
				}
			}
			for (int j = GraphicsManager.mTriangles.Count - 1; j >= 0; j--)
			{
				if (GraphicsManager.mTriangles[j].ExpirationTime < internalTime)
				{
					Triangle.Release(GraphicsManager.mTriangles[j]);
					GraphicsManager.mTriangles.RemoveAt(j);
				}
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000CD40 File Offset: 0x0000AF40
		public static void ClearText()
		{
			float internalTime = GraphicsManager.InternalTime;
			for (int i = GraphicsManager.mText.Count - 1; i >= 0; i--)
			{
				if (GraphicsManager.mText[i].ExpirationTime < internalTime)
				{
					Text.Release(GraphicsManager.mText[i]);
					GraphicsManager.mText.RemoveAt(i);
				}
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000CD98 File Offset: 0x0000AF98
		public static void DrawLine(Vector3 rStart, Vector3 rEnd, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			Line line = Line.Allocate();
			line.Transform = rTransform;
			line.Start = rStart;
			line.End = rEnd;
			line.Color = rColor;
			line.ExpirationTime = GraphicsManager.InternalTime + rDuration;
			GraphicsManager.mLines.Add(line);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000CDE0 File Offset: 0x0000AFE0
		public static void DrawLines(List<Vector3> rLines, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			for (int i = 1; i < rLines.Count; i++)
			{
				Line line = Line.Allocate();
				line.Transform = rTransform;
				line.Start = rLines[i - 1];
				line.End = rLines[i];
				line.Color = rColor;
				line.ExpirationTime = GraphicsManager.InternalTime + rDuration;
				GraphicsManager.mLines.Add(line);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000CE48 File Offset: 0x0000B048
		public static void DrawTriangle(Vector3 rPoint1, Vector3 rPoint2, Vector3 rPoint3, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			Triangle triangle = Triangle.Allocate();
			triangle.Transform = rTransform;
			triangle.Point1 = rPoint1;
			triangle.Point2 = rPoint2;
			triangle.Point3 = rPoint3;
			triangle.Color = rColor;
			triangle.ExpirationTime = GraphicsManager.InternalTime + rDuration;
			GraphicsManager.mTriangles.Add(triangle);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000CE98 File Offset: 0x0000B098
		public static void DrawBox(Vector3 rCenter, float rWidth, float rHeight, float rDepth, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			float num = rWidth * 0.5f;
			float num2 = rHeight * 0.5f;
			float num3 = rDepth * 0.5f;
			GraphicsManager.DrawLine(rCenter + new Vector3(num, num2, num3), rCenter + new Vector3(-num, num2, num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(num, num2, num3), rCenter + new Vector3(num, -num2, num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(num, num2, num3), rCenter + new Vector3(num, num2, -num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(-num, num2, num3), rCenter + new Vector3(-num, -num2, num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(-num, num2, num3), rCenter + new Vector3(-num, num2, -num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(-num, num2, -num3), rCenter + new Vector3(num, num2, -num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(-num, num2, -num3), rCenter + new Vector3(-num, -num2, -num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(-num, -num2, -num3), rCenter + new Vector3(-num, -num2, num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(-num, -num2, -num3), rCenter + new Vector3(num, -num2, -num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(num, -num2, -num3), rCenter + new Vector3(num, -num2, num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(num, -num2, -num3), rCenter + new Vector3(num, num2, -num3), rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(rCenter + new Vector3(num, -num2, num3), rCenter + new Vector3(-num, -num2, num3), rColor, rTransform, rDuration);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000D0B5 File Offset: 0x0000B2B5
		public static void DrawBox(Bounds rBounds, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			GraphicsManager.DrawBox(rBounds.center, rBounds.size.x, rBounds.size.y, rBounds.size.z, rColor, rTransform, rDuration);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000D0EC File Offset: 0x0000B2EC
		public static void DrawCollider(BoxCollider rColldier, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			if (rColldier == null)
			{
				return;
			}
			GraphicsManager.mVectors1.Clear();
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, 0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, 0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, 0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, 0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, -0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, -0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, -0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, -0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			for (int i = 0; i < GraphicsManager.mVectors1.Count; i++)
			{
				GraphicsManager.mVectors1[i] = rColldier.transform.TransformPoint(GraphicsManager.mVectors1[i]);
			}
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[1], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[2], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[2], GraphicsManager.mVectors1[3], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[3], GraphicsManager.mVectors1[0], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[4], GraphicsManager.mVectors1[5], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[5], GraphicsManager.mVectors1[6], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[7], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[7], GraphicsManager.mVectors1[4], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[4], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[5], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[2], GraphicsManager.mVectors1[6], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[3], GraphicsManager.mVectors1[7], rColor, rTransform, rDuration);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000D514 File Offset: 0x0000B714
		public static void DrawSolidCollider(BoxCollider rColldier, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			if (rColldier == null)
			{
				return;
			}
			GraphicsManager.mVectors1.Clear();
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, 0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, 0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, 0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, 0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, -0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, -0.5f * rColldier.size.y, 0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(-0.5f * rColldier.size.x, -0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			GraphicsManager.mVectors1.Add(new Vector3(0.5f * rColldier.size.x, -0.5f * rColldier.size.y, -0.5f * rColldier.size.z) + rColldier.center);
			for (int i = 0; i < GraphicsManager.mVectors1.Count; i++)
			{
				GraphicsManager.mVectors1[i] = rColldier.transform.TransformPoint(GraphicsManager.mVectors1[i]);
			}
			Color color = new Color(rColor.r, rColor.g, rColor.b, 0.1f);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[2], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[2], GraphicsManager.mVectors1[3], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[5], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[5], GraphicsManager.mVectors1[4], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[3], GraphicsManager.mVectors1[7], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[7], GraphicsManager.mVectors1[4], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[5], GraphicsManager.mVectors1[1], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[2], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[7], GraphicsManager.mVectors1[4], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[4], GraphicsManager.mVectors1[5], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[2], GraphicsManager.mVectors1[3], color, rTransform, rDuration);
			GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[3], GraphicsManager.mVectors1[7], color, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[1], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[2], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[2], GraphicsManager.mVectors1[3], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[3], GraphicsManager.mVectors1[0], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[4], GraphicsManager.mVectors1[5], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[5], GraphicsManager.mVectors1[6], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[6], GraphicsManager.mVectors1[7], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[7], GraphicsManager.mVectors1[4], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[0], GraphicsManager.mVectors1[4], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[1], GraphicsManager.mVectors1[5], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[2], GraphicsManager.mVectors1[6], rColor, rTransform, rDuration);
			GraphicsManager.DrawLine(GraphicsManager.mVectors1[3], GraphicsManager.mVectors1[7], rColor, rTransform, rDuration);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000DB45 File Offset: 0x0000BD45
		public static void DrawCircle(Vector3 rCenter, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			GraphicsManager.DrawCircle(rCenter, rRadius, rColor, Vector3.up, rTransform, rDuration);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000DB58 File Offset: 0x0000BD58
		public static void DrawCircle(Vector3 rCenter, float rRadius, Color rColor, Vector3 rNormal, Transform rTransform = null, float rDuration = 0f)
		{
			int num = 36;
			Vector3[] array = new Vector3[num];
			Quaternion quaternion = Quaternion.AngleAxis(360f / (float)(num - 1), rNormal);
			Vector3 vector = Quaternion.FromToRotation(Vector3.up, rNormal) * Vector3.forward * rRadius;
			for (int i = 0; i < num; i++)
			{
				array[i] = rCenter + vector;
				vector = quaternion * vector;
			}
			for (int j = 1; j < num; j++)
			{
				GraphicsManager.DrawLine(array[j - 1], array[j], rColor, rTransform, rDuration);
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000DBEF File Offset: 0x0000BDEF
		public static void DrawSolidCircle(Vector3 rCenter, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			GraphicsManager.DrawSolidCircle(rCenter, rRadius, rColor, Vector3.up, rTransform, rDuration);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000DC04 File Offset: 0x0000BE04
		public static void DrawSolidCircle(Vector3 rCenter, float rRadius, Color rColor, Vector3 rNormal, Transform rTransform = null, float rDuration = 0f)
		{
			int num = 36;
			GraphicsManager.mVectors1.Clear();
			Quaternion quaternion = Quaternion.AngleAxis(360f / (float)(num - 1), rNormal);
			Vector3 vector = Vector3.forward * rRadius;
			for (int i = 0; i < num; i++)
			{
				GraphicsManager.mVectors1.Add(rCenter + vector);
				vector = quaternion * vector;
			}
			Color color = new Color(rColor.r, rColor.g, rColor.b, 0.1f);
			for (int j = 1; j < num; j++)
			{
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[j - 1], GraphicsManager.mVectors1[j], rColor, rTransform, rDuration);
				GraphicsManager.DrawTriangle(rCenter, GraphicsManager.mVectors1[j - 1], GraphicsManager.mVectors1[j], color, rTransform, rDuration);
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000DCDC File Offset: 0x0000BEDC
		public static void DrawSolidCone(Vector3 rPosition, Vector3 rDirection, float rDistance, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			Vector3 vector = Vector3.Cross(rDirection, Vector3.up);
			Vector3 vector2 = rPosition + rDirection * rDistance;
			int num = 36;
			GraphicsManager.mVectors1.Clear();
			Quaternion quaternion = Quaternion.AngleAxis(360f / (float)(num - 1), rDirection);
			Vector3 vector3 = vector * rRadius;
			for (int i = 0; i < num; i++)
			{
				GraphicsManager.mVectors1.Add(vector2 + vector3);
				vector3 = quaternion * vector3;
			}
			Color color = new Color(rColor.r, rColor.g, rColor.b, 0.1f);
			for (int j = 1; j < num; j++)
			{
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[j - 1], GraphicsManager.mVectors1[j], rColor, rTransform, rDuration);
				GraphicsManager.DrawTriangle(vector2, GraphicsManager.mVectors1[j - 1], GraphicsManager.mVectors1[j], color, rTransform, rDuration);
				GraphicsManager.DrawTriangle(rPosition, GraphicsManager.mVectors1[j - 1], GraphicsManager.mVectors1[j], color, rTransform, rDuration);
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000DDF2 File Offset: 0x0000BFF2
		public static void DrawArc(Vector3 rCenter, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			GraphicsManager.DrawArc(rCenter, Vector3.up, rFrom, rAngle, rRadius, rColor, rTransform, rDuration);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000DE08 File Offset: 0x0000C008
		public static void DrawArc(Vector3 rCenter, Vector3 rNormal, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			int num = 36;
			Vector3[] array = new Vector3[num];
			Quaternion quaternion = Quaternion.AngleAxis(rAngle / (float)(num - 1), rNormal);
			Vector3 vector = rFrom.normalized * rRadius;
			for (int i = 0; i < num; i++)
			{
				array[i] = rCenter + vector;
				vector = quaternion * vector;
			}
			for (int j = 1; j < num; j++)
			{
				GraphicsManager.DrawLine(array[j - 1], array[j], rColor, rTransform, rDuration);
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000DE8F File Offset: 0x0000C08F
		public static void DrawSolidArc(Vector3 rCenter, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			GraphicsManager.DrawSolidArc(rCenter, Vector3.up, rFrom, rAngle, rRadius, rColor, rTransform, rDuration);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000DEA8 File Offset: 0x0000C0A8
		public static void DrawSolidArc(Vector3 rCenter, Vector3 rNormal, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			int num = 36;
			Vector3[] array = new Vector3[num];
			Quaternion quaternion = Quaternion.AngleAxis(rAngle / (float)(num - 1), rNormal);
			Vector3 vector = rFrom.normalized * rRadius;
			for (int i = 0; i < num; i++)
			{
				array[i] = rCenter + vector;
				vector = quaternion * vector;
			}
			for (int j = 1; j < num; j++)
			{
				GraphicsManager.DrawTriangle(rCenter, array[j - 1], array[j], rColor, rTransform, rDuration);
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000DF30 File Offset: 0x0000C130
		public static void DrawSolidCenteredArc(Vector3 rCenter, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			GraphicsManager.DrawSolidCenteredArc(rCenter, Vector3.up, rFrom, rAngle, rRadius, rColor, rTransform, rDuration);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000DF48 File Offset: 0x0000C148
		public static void DrawSolidCenteredArc(Vector3 rCenter, Vector3 rNormal, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			int num = 36;
			Vector3[] array = new Vector3[num];
			Quaternion quaternion = Quaternion.AngleAxis(rAngle / (float)(num - 1), rNormal);
			Vector3 vector = Quaternion.AngleAxis(-rAngle * 0.5f, rNormal) * (rFrom.normalized * rRadius);
			for (int i = 0; i < num; i++)
			{
				array[i] = rCenter + vector;
				vector = quaternion * vector;
			}
			for (int j = 1; j < num; j++)
			{
				GraphicsManager.DrawTriangle(rCenter, array[j - 1], array[j], rColor, rTransform, rDuration);
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000DFE4 File Offset: 0x0000C1E4
		public static void DrawArrow(Vector3 rStart, Vector3 rEnd, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			Line line = Line.Allocate();
			line.Transform = rTransform;
			line.Start = rStart;
			line.End = rEnd;
			line.Color = rColor;
			line.ExpirationTime = GraphicsManager.InternalTime + rDuration;
			GraphicsManager.mLines.Add(line);
			GraphicsManager.DrawPoint(rEnd, rColor, rTransform, rDuration);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000E038 File Offset: 0x0000C238
		public static void DrawFrustum(Vector3 rPosition, Quaternion rRotation, float rHAngle, float rVAngle, float rMinDistance, float rMaxDistance, Color rColor, bool rIsSpherical = true)
		{
			if (rHAngle == 0f || rVAngle == 0f || rMaxDistance == 0f)
			{
				return;
			}
			int num = 10;
			int num2 = num + 1;
			float num3 = rHAngle * 0.5f;
			float num4 = rVAngle * 0.5f;
			Vector3 zero = Vector3.zero;
			GraphicsManager.mVectors1.Clear();
			GraphicsManager.mVectors2.Clear();
			for (float num5 = -num4; num5 <= num4; num5 += rVAngle / (float)num)
			{
				float num6 = -(num5 * 0.017453292f);
				float num7 = Mathf.Sin(num6);
				for (float num8 = -num3; num8 <= num3; num8 += rHAngle / (float)num)
				{
					float num9 = -(num8 * 0.017453292f) + 1.57079f;
					float num10 = Mathf.Cos(num9) * (rIsSpherical ? Mathf.Cos(num6) : 1f);
					float num11 = Mathf.Sin(num9) * (rIsSpherical ? Mathf.Cos(num6) : 1f);
					zero.x = rMinDistance * num10;
					zero.y = rMinDistance * num7;
					zero.z = rMinDistance * num11;
					GraphicsManager.mVectors1.Add(rPosition + rRotation * zero);
					zero.x = rMaxDistance * num10;
					zero.y = rMaxDistance * num7;
					zero.z = rMaxDistance * num11;
					GraphicsManager.mVectors2.Add(rPosition + rRotation * zero);
				}
			}
			if (rVAngle < 360f)
			{
				for (int i = 0; i < num; i++)
				{
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[i], GraphicsManager.mVectors2[i + 1], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[num * num2 + i], GraphicsManager.mVectors2[num * num2 + i + 1], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[i], GraphicsManager.mVectors1[i + 1], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[num * num2 + i], GraphicsManager.mVectors1[num * num2 + i + 1], rColor, null, 0f);
				}
			}
			if (rHAngle < 360f)
			{
				for (int j = 0; j < num; j++)
				{
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[j * num2], GraphicsManager.mVectors2[(j + 1) * num2], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[j * num2 + num], GraphicsManager.mVectors2[(j + 1) * num2 + num], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[j * num2], GraphicsManager.mVectors1[(j + 1) * num2], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[j * num2 + num], GraphicsManager.mVectors1[(j + 1) * num2 + num], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[j * num2 + num / 2], GraphicsManager.mVectors1[(j + 1) * num2 + num / 2], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[j * num2 + num / 2], GraphicsManager.mVectors2[(j + 1) * num2 + num / 2], rColor, null, 0f);
				}
			}
			if (rHAngle < 360f && rVAngle < 360f)
			{
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[0], GraphicsManager.mVectors2[0], rColor, null, 0f);
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[num], GraphicsManager.mVectors2[num], rColor, null, 0f);
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[num * num2], GraphicsManager.mVectors2[num * num2], rColor, null, 0f);
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[num * num2 + num], GraphicsManager.mVectors2[num * num2 + num], rColor, null, 0f);
			}
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000E44C File Offset: 0x0000C64C
		public static void DrawSolidFrustum(Vector3 rPosition, Quaternion rRotation, float rHAngle, float rVAngle, float rMinDistance, float rMaxDistance, Color rColor, bool rIsSpherical = true)
		{
			if (rHAngle == 0f || rVAngle == 0f || rMaxDistance == 0f)
			{
				return;
			}
			int num = 10;
			int num2 = num + 1;
			float num3 = rHAngle * 0.5f;
			float num4 = rVAngle * 0.5f;
			Vector3 zero = Vector3.zero;
			GraphicsManager.mVectors1.Clear();
			GraphicsManager.mVectors2.Clear();
			for (float num5 = -num4; num5 <= num4; num5 += rVAngle / (float)num)
			{
				float num6 = -(num5 * 0.017453292f);
				float num7 = Mathf.Sin(num6);
				for (float num8 = -num3; num8 <= num3; num8 += rHAngle / (float)num)
				{
					float num9 = -(num8 * 0.017453292f) + 1.57079f;
					float num10 = Mathf.Cos(num9) * (rIsSpherical ? Mathf.Cos(num6) : 1f);
					float num11 = Mathf.Sin(num9) * (rIsSpherical ? Mathf.Cos(num6) : 1f);
					zero.x = rMinDistance * num10;
					zero.y = rMinDistance * num7;
					zero.z = rMinDistance * num11;
					GraphicsManager.mVectors1.Add(rPosition + rRotation * zero);
					zero.x = rMaxDistance * num10;
					zero.y = rMaxDistance * num7;
					zero.z = rMaxDistance * num11;
					GraphicsManager.mVectors2.Add(rPosition + rRotation * zero);
				}
			}
			Color color = new Color(rColor.r, rColor.g, rColor.b, 0.1f);
			if (rMinDistance > 0f)
			{
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < num; j++)
					{
						GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[(i + 1) * num2 + j], GraphicsManager.mVectors1[i * num2 + j], GraphicsManager.mVectors1[(i + 1) * num2 + j + 1], color, null, 0f);
						GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[i * num2 + j], GraphicsManager.mVectors1[i * num2 + j + 1], GraphicsManager.mVectors1[(i + 1) * num2 + j + 1], color, null, 0f);
					}
				}
			}
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num; l++)
				{
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[(k + 1) * num2 + l], GraphicsManager.mVectors2[k * num2 + l], GraphicsManager.mVectors2[(k + 1) * num2 + l + 1], color, null, 0f);
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[k * num2 + l], GraphicsManager.mVectors2[k * num2 + l + 1], GraphicsManager.mVectors2[(k + 1) * num2 + l + 1], color, null, 0f);
				}
			}
			if (rVAngle < 360f)
			{
				for (int m = 0; m < num; m++)
				{
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[m], GraphicsManager.mVectors1[m], GraphicsManager.mVectors2[m + 1], color, null, 0f);
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[m], GraphicsManager.mVectors1[m + 1], GraphicsManager.mVectors2[m + 1], color, null, 0f);
				}
				for (int n = 0; n < num; n++)
				{
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[num * num2 + n], GraphicsManager.mVectors1[num * num2 + n], GraphicsManager.mVectors2[num * num2 + n + 1], color, null, 0f);
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors1[num * num2 + n], GraphicsManager.mVectors1[num * num2 + n + 1], GraphicsManager.mVectors2[num * num2 + n + 1], color, null, 0f);
				}
			}
			if (rHAngle < 360f)
			{
				for (int num12 = 0; num12 < num; num12++)
				{
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[(num12 + 1) * num2], GraphicsManager.mVectors2[num12 * num2], GraphicsManager.mVectors1[(num12 + 1) * num2], color, null, 0f);
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[num12 * num2], GraphicsManager.mVectors1[num12 * num2], GraphicsManager.mVectors1[(num12 + 1) * num2], color, null, 0f);
				}
				for (int num13 = 0; num13 < num; num13++)
				{
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[(num13 + 1) * num2 + num], GraphicsManager.mVectors2[num13 * num2 + num], GraphicsManager.mVectors1[(num13 + 1) * num2 + num], color, null, 0f);
					GraphicsManager.DrawTriangle(GraphicsManager.mVectors2[num13 * num2 + num], GraphicsManager.mVectors1[num13 * num2 + num], GraphicsManager.mVectors1[(num13 + 1) * num2 + num], color, null, 0f);
				}
			}
			if (rVAngle < 360f)
			{
				for (int num14 = 0; num14 < num; num14++)
				{
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[num14], GraphicsManager.mVectors2[num14 + 1], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[num * num2 + num14], GraphicsManager.mVectors2[num * num2 + num14 + 1], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[num14], GraphicsManager.mVectors1[num14 + 1], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[num * num2 + num14], GraphicsManager.mVectors1[num * num2 + num14 + 1], rColor, null, 0f);
				}
			}
			if (rHAngle < 360f)
			{
				for (int num15 = 0; num15 < num; num15++)
				{
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[num15 * num2], GraphicsManager.mVectors2[(num15 + 1) * num2], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors2[num15 * num2 + num], GraphicsManager.mVectors2[(num15 + 1) * num2 + num], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[num15 * num2], GraphicsManager.mVectors1[(num15 + 1) * num2], rColor, null, 0f);
					GraphicsManager.DrawLine(GraphicsManager.mVectors1[num15 * num2 + num], GraphicsManager.mVectors1[(num15 + 1) * num2 + num], rColor, null, 0f);
				}
			}
			if (rHAngle < 360f && rVAngle < 360f)
			{
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[0], GraphicsManager.mVectors2[0], rColor, null, 0f);
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[num], GraphicsManager.mVectors2[num], rColor, null, 0f);
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[num * num2], GraphicsManager.mVectors2[num * num2], rColor, null, 0f);
				GraphicsManager.DrawLine(GraphicsManager.mVectors1[num * num2 + num], GraphicsManager.mVectors2[num * num2 + num], rColor, null, 0f);
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000EBD4 File Offset: 0x0000CDD4
		public static void DrawPoint(Vector3 rCenter, Color rColor, Transform rTransform = null, float rDuration = 0f)
		{
			if (GraphicsManager.mOctahedron == null)
			{
				GraphicsManager.mOctahedron = new GraphicsManager.Octahedron();
			}
			float num = 0.075f;
			for (int i = 0; i < GraphicsManager.mOctahedron.Triangles.Length; i += 3)
			{
				GraphicsManager.DrawTriangle(rCenter + GraphicsManager.mOctahedron.Vertices[GraphicsManager.mOctahedron.Triangles[i]] * num, rCenter + GraphicsManager.mOctahedron.Vertices[GraphicsManager.mOctahedron.Triangles[i + 1]] * num, rCenter + GraphicsManager.mOctahedron.Vertices[GraphicsManager.mOctahedron.Triangles[i + 2]] * num, rColor, rTransform, rDuration);
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000EC98 File Offset: 0x0000CE98
		public static void DrawQuaternion(Vector3 rCenter, Quaternion rRotation, float rScale = 1f, float rDuration = 0f)
		{
			GraphicsManager.DrawLine(rCenter, rCenter + rRotation.Forward() * rScale, Color.blue, null, rDuration);
			GraphicsManager.DrawLine(rCenter, rCenter + rRotation.Right() * rScale, Color.red, null, rDuration);
			GraphicsManager.DrawLine(rCenter, rCenter + rRotation.Up() * rScale, Color.green, null, rDuration);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000ED04 File Offset: 0x0000CF04
		public static void DrawCapsule(Vector3 rStart, Vector3 rEnd, float rRadius, Color rColor, float rDuration = 0f)
		{
			Vector3 normalized = (rEnd - rStart).normalized;
			Quaternion quaternion = ((normalized.sqrMagnitude == 0f) ? Quaternion.identity : Quaternion.LookRotation(normalized, Vector3.up));
			Vector3 vector = quaternion * Vector3.forward;
			Vector3 vector2 = quaternion * Vector3.right;
			Vector3 vector3 = quaternion * Vector3.up;
			GraphicsManager.DrawArc(rStart, vector, vector3, 360f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rStart, vector3, vector2, 180f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rStart, vector2, -vector3, 180f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rEnd, vector, vector3, 360f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rEnd, vector3, -vector2, 180f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rEnd, vector2, vector3, 180f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawLine(rStart + vector2 * rRadius, rEnd + vector2 * rRadius, rColor, null, rDuration);
			GraphicsManager.DrawLine(rStart + -vector2 * rRadius, rEnd + -vector2 * rRadius, rColor, null, rDuration);
			GraphicsManager.DrawLine(rStart + vector3 * rRadius, rEnd + vector3 * rRadius, rColor, null, rDuration);
			GraphicsManager.DrawLine(rStart + -vector3 * rRadius, rEnd + -vector3 * rRadius, rColor, null, rDuration);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000EE7C File Offset: 0x0000D07C
		public static void DrawSphere(Vector3 rCenter, float rRadius, Color rColor, float rDuration = 0f)
		{
			Vector3 forward = Vector3.forward;
			Vector3 right = Vector3.right;
			Vector3 up = Vector3.up;
			GraphicsManager.DrawArc(rCenter, forward, up, 360f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rCenter, up, right, 360f, rRadius, rColor, null, rDuration);
			GraphicsManager.DrawArc(rCenter, right, -up, 360f, rRadius, rColor, null, rDuration);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000EED4 File Offset: 0x0000D0D4
		public static void DrawTexture(Texture rTexture, Vector3 rPosition, float rWidth, float rHeight)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(rPosition);
			vector.x = Mathf.Floor(vector.x);
			vector.y = Mathf.Floor(vector.y);
			GUI.DrawTexture(new Rect(vector.x - rWidth * 0.5f, (float)Screen.height - vector.y - rHeight * 0.5f, rWidth, rHeight), rTexture);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000EF48 File Offset: 0x0000D148
		public static void DrawTexture(Texture rTexture, Vector2 rPosition, float rWidth, float rHeight)
		{
			rPosition.x *= (float)Screen.width;
			rPosition.y *= (float)Screen.height;
			GUI.DrawTexture(new Rect(rPosition.x - rWidth * 0.5f, (float)Screen.height - rPosition.y - rHeight * 0.5f, rWidth, rHeight), rTexture);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000EFAD File Offset: 0x0000D1AD
		public static void DrawText(string rText, Vector3 rPosition, Color rColor, float rDuration = 0f)
		{
			GraphicsManager.DrawText(rText, rPosition, rColor, GraphicsManager.mFont, rDuration);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		public static void DrawText(string rText, Vector3 rPosition, Color rColor, Font rFont, float rDuration = 0f)
		{
			if (!GraphicsManager.mFonts.ContainsKey(rFont) && !GraphicsManager.AddFont(rFont))
			{
				return;
			}
			TextFont textFont = GraphicsManager.mFonts[rFont];
			int num = Mathf.Abs(textFont.MinX);
			char[] array = rText.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				CharacterInfo characterInfo;
				rFont.GetCharacterInfo(array[i], out characterInfo);
				num += Mathf.Max(characterInfo.advance, characterInfo.glyphWidth);
			}
			int num2 = textFont.MaxY - textFont.MinY;
			Texture2D texture2D = new Texture2D(num, num2, TextureFormat.ARGB32, false, true);
			Color32[] array2 = new Color32[num * num2];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = new Color32(0, 0, 0, 0);
			}
			texture2D.SetPixels32(array2);
			int num3 = Mathf.Abs(textFont.MinX);
			int num4 = Mathf.Abs(textFont.MinY);
			for (int k = 0; k < array.Length; k++)
			{
				TextCharacter characterPixels = GraphicsManager.GetCharacterPixels(rFont, array[k]);
				if (characterPixels.Pixels != null)
				{
					for (int l = 0; l < characterPixels.Pixels.Length; l++)
					{
						rColor.a = characterPixels.Pixels[l].a;
						characterPixels.Pixels[l] = rColor;
					}
					texture2D.SetPixels(num3 + characterPixels.MinX, num4 + characterPixels.MinY, characterPixels.Width, characterPixels.Height, characterPixels.Pixels);
				}
				num3 += characterPixels.Advance;
			}
			texture2D.Apply();
			Text text = Text.Allocate();
			text.Position = rPosition;
			text.Texture = texture2D;
			text.ExpirationTime = GraphicsManager.InternalTime + rDuration;
			GraphicsManager.mText.Add(text);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000F18C File Offset: 0x0000D38C
		public static bool AddFont(Font rFont)
		{
			if (rFont == null)
			{
				return false;
			}
			if (GraphicsManager.mFonts.ContainsKey(rFont))
			{
				return true;
			}
			Texture2D texture2D = (Texture2D)rFont.material.mainTexture;
			byte[] rawTextureData = texture2D.GetRawTextureData();
			Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, texture2D.format, false);
			texture2D2.LoadRawTextureData(rawTextureData);
			texture2D2.Apply();
			TextFont textFont = TextFont.Allocate();
			textFont.Font = rFont;
			textFont.Texture = texture2D2;
			char[] array = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.,?:;~!@#$%^&*()_+-=".ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				CharacterInfo characterInfo;
				rFont.GetCharacterInfo(array[i], out characterInfo);
				if (characterInfo.minX < textFont.MinX)
				{
					textFont.MinX = characterInfo.minX;
				}
				if (characterInfo.maxX > textFont.MaxX)
				{
					textFont.MaxX = characterInfo.maxX;
				}
				if (characterInfo.minY < textFont.MinY)
				{
					textFont.MinY = characterInfo.minY;
				}
				if (characterInfo.maxY > textFont.MaxY)
				{
					textFont.MaxY = characterInfo.maxY;
				}
			}
			GraphicsManager.mFonts.Add(rFont, textFont);
			return true;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000F2B8 File Offset: 0x0000D4B8
		private static void RenderLines()
		{
			if (GraphicsManager.mSimpleMaterial == null)
			{
				GraphicsManager.CreateMaterials();
			}
			GraphicsManager.mSimpleMaterial.SetPass(0);
			for (int i = 0; i < GraphicsManager.mLines.Count; i++)
			{
				Line line = GraphicsManager.mLines[i];
				GL.PushMatrix();
				if (line.Transform == null)
				{
					GL.MultMatrix(Matrix4x4.identity);
				}
				else
				{
					GL.MultMatrix(line.Transform.localToWorldMatrix);
				}
				GL.Begin(1);
				GL.Color(line.Color);
				GL.Vertex3(line.Start.x, line.Start.y, line.Start.z);
				GL.Vertex3(line.End.x, line.End.y, line.End.z);
				GL.End();
				GL.PopMatrix();
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000F3A0 File Offset: 0x0000D5A0
		private static void RenderTriangles()
		{
			if (GraphicsManager.mSimpleMaterial == null)
			{
				GraphicsManager.CreateMaterials();
			}
			GraphicsManager.mSimpleMaterial.SetPass(0);
			for (int i = 0; i < GraphicsManager.mTriangles.Count; i++)
			{
				Triangle triangle = GraphicsManager.mTriangles[i];
				GL.PushMatrix();
				if (triangle.Transform == null)
				{
					GL.MultMatrix(Matrix4x4.identity);
				}
				else
				{
					GL.MultMatrix(triangle.Transform.localToWorldMatrix);
				}
				GL.Begin(4);
				GL.Color(triangle.Color);
				GL.Vertex3(triangle.Point1.x, triangle.Point1.y, triangle.Point1.z);
				GL.Vertex3(triangle.Point2.x, triangle.Point2.y, triangle.Point2.z);
				GL.Vertex3(triangle.Point3.x, triangle.Point3.y, triangle.Point3.z);
				GL.End();
				GL.PopMatrix();
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000F4B0 File Offset: 0x0000D6B0
		private static void RenderText()
		{
			for (int i = 0; i < GraphicsManager.mText.Count; i++)
			{
				Text text = GraphicsManager.mText[i];
				if (!(text.Texture == null) && text.Texture != null)
				{
					int width = text.Texture.width;
					int height = text.Texture.height;
					Vector2 vector = Camera.main.WorldToScreenPoint(text.Position);
					GUI.DrawTexture(new Rect(vector.x - (float)width * 0.5f, (float)Screen.height - vector.y - (float)height * 0.5f, (float)width, (float)height), text.Texture);
				}
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000F564 File Offset: 0x0000D764
		private static void CreateMaterials()
		{
			if (GraphicsManager.mSimpleMaterial != null)
			{
				return;
			}
			Shader shader = Shader.Find(GraphicsManager.mShader);
			if (shader == null)
			{
				shader = Shader.Find("Hidden/GraphicsManagerUI");
			}
			GraphicsManager.mSimpleMaterial = new Material(shader);
			GraphicsManager.mSimpleMaterial.hideFlags = HideFlags.HideAndDontSave;
			GraphicsManager.mSimpleMaterial.SetInt("_SrcBlend", 5);
			GraphicsManager.mSimpleMaterial.SetInt("_DstBlend", 10);
			GraphicsManager.mSimpleMaterial.SetInt("_Cull", 0);
			GraphicsManager.mSimpleMaterial.SetInt("_ZWrite", 0);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
		private static TextCharacter GetCharacterPixels(Font rFont, char rCharacter)
		{
			if (!GraphicsManager.mFonts.ContainsKey(rFont))
			{
				return null;
			}
			if (GraphicsManager.mFonts[rFont].Characters.ContainsKey(rCharacter))
			{
				return GraphicsManager.mFonts[rFont].Characters[rCharacter];
			}
			Texture2D texture = GraphicsManager.mFonts[rFont].Texture;
			Vector2 vector = Vector2.zero;
			Color[] array = null;
			CharacterInfo characterInfo;
			rFont.GetCharacterInfo(rCharacter, out characterInfo);
			if (characterInfo.uvBottomLeft.x == characterInfo.uvBottomRight.x)
			{
				if (characterInfo.uvBottomLeft.y > characterInfo.uvBottomRight.y)
				{
					vector = characterInfo.uvBottomRight;
				}
				else
				{
					vector = characterInfo.uvBottomLeft;
				}
			}
			else if (characterInfo.uvBottomLeft.y > characterInfo.uvTopLeft.y)
			{
				vector = characterInfo.uvTopLeft;
			}
			else
			{
				vector = characterInfo.uvBottomLeft;
			}
			int num = (int)((float)texture.width * vector.x);
			int num2 = (int)((float)texture.height * vector.y);
			int glyphWidth = characterInfo.glyphWidth;
			int glyphHeight = characterInfo.glyphHeight;
			if (characterInfo.uvBottomLeft.x == characterInfo.uvBottomRight.x && characterInfo.uvBottomLeft.y > characterInfo.uvBottomRight.y)
			{
				array = texture.GetPixels(num, num2, glyphHeight, glyphWidth);
				array = GraphicsManager.RotatePixelsLeft(array, glyphHeight, glyphWidth);
			}
			if (characterInfo.uvBottomLeft.y > characterInfo.uvTopLeft.y)
			{
				array = texture.GetPixels(num, num2, glyphWidth, glyphHeight);
				array = GraphicsManager.FlipPixelsVertically(array, glyphWidth, glyphHeight);
			}
			if (characterInfo.uvTopLeft.x > characterInfo.uvTopRight.x)
			{
				array = texture.GetPixels(num, num2, glyphWidth, glyphHeight);
				array = GraphicsManager.FlipPixelsHorizontally(array, glyphWidth, glyphHeight);
			}
			TextCharacter textCharacter = TextCharacter.Allocate();
			textCharacter.Character = rCharacter;
			textCharacter.Pixels = array;
			textCharacter.MinX = characterInfo.minX;
			textCharacter.MinY = characterInfo.minY;
			textCharacter.Width = glyphWidth;
			textCharacter.Height = glyphHeight;
			textCharacter.Advance = characterInfo.advance;
			GraphicsManager.mFonts[rFont].Characters.Add(rCharacter, textCharacter);
			return textCharacter;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000F834 File Offset: 0x0000DA34
		private static Color[] RotatePixelsLeft(Color[] rArray, int rWidth, int rHeight)
		{
			Color[] array = new Color[rArray.Length];
			for (int i = 0; i < rArray.Length; i++)
			{
				int num = i / rWidth;
				int num2 = i % rWidth;
				int num3 = rHeight - num - 1;
				int num4 = num2 * rHeight + num3;
				array[num4] = rArray[i];
			}
			return array;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000F87C File Offset: 0x0000DA7C
		private static Color[] FlipPixelsHorizontally(Color[] rArray, int rWidth, int rHeight)
		{
			Color[] array = new Color[rArray.Length];
			for (int i = 0; i < rHeight; i++)
			{
				for (int j = 0; j < rWidth; j++)
				{
					Color color = rArray[i * rWidth + j];
					array[(rWidth - 1 - j) * rHeight + i] = color;
				}
			}
			return array;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000F8C8 File Offset: 0x0000DAC8
		private static Color[] FlipPixelsVertically(Color[] rArray, int rWidth, int rHeight)
		{
			Color[] array = new Color[rArray.Length];
			int i = 0;
			while (i < rArray.Length)
			{
				int num = i / rWidth;
				int num2 = (rHeight - num - 1) * rWidth;
				int j = num2;
				while (j < num2 + rWidth)
				{
					array[j] = rArray[i];
					j++;
					i++;
				}
			}
			return array;
		}

		// Token: 0x04000188 RID: 392
		private static Material mSimpleMaterial = null;

		// Token: 0x04000189 RID: 393
		private static List<Vector3> mVectors1 = new List<Vector3>();

		// Token: 0x0400018A RID: 394
		private static List<Vector3> mVectors2 = new List<Vector3>();

		// Token: 0x0400018B RID: 395
		private static Stopwatch mInternalTimer = new Stopwatch();

		// Token: 0x0400018C RID: 396
		private static List<Line> mLines = new List<Line>();

		// Token: 0x0400018D RID: 397
		private static List<Triangle> mTriangles = new List<Triangle>();

		// Token: 0x0400018E RID: 398
		private static List<Text> mText = new List<Text>();

		// Token: 0x0400018F RID: 399
		private static string mShader = "Hidden/GraphicsManagerUI";

		// Token: 0x04000190 RID: 400
		private static Font mFont = null;

		// Token: 0x04000191 RID: 401
		private static Dictionary<Font, TextFont> mFonts = new Dictionary<Font, TextFont>();

		// Token: 0x04000192 RID: 402
		private static GraphicsManager.Octahedron mOctahedron = null;

		// Token: 0x04000193 RID: 403
		public string _DefaultShader = "Hidden/GraphicsManagerUI";

		// Token: 0x04000194 RID: 404
		public Font _DefaultFont;

		// Token: 0x04000195 RID: 405
		public bool _DrawToSceneView = true;

		// Token: 0x04000196 RID: 406
		public bool _DrawToGameView = true;

		// Token: 0x0200012D RID: 301
		public class Octahedron
		{
			// Token: 0x0600120C RID: 4620 RVA: 0x00064530 File Offset: 0x00062730
			public Octahedron()
			{
				this.Vertices = this.CreateVertices();
				this.Triangles = this.CreateTriangles();
				Vector3[] array = new Vector3[this.Triangles.Length];
				for (int i = 0; i < this.Triangles.Length; i++)
				{
					array[i] = this.Vertices[this.Triangles[i]];
					this.Triangles[i] = i;
				}
				this.Vertices = array;
			}

			// Token: 0x0600120D RID: 4621 RVA: 0x000645A8 File Offset: 0x000627A8
			private Vector3[] CreateVertices()
			{
				int num = 3;
				float[] array = new float[]
				{
					0f, 0.5f, 0f, 0.5f, 0f, 0f, 0f, 0f, -0.5f, -0.5f,
					0f, 0f, 0f, -0f, 0.5f, 0f, -0.5f, -0f
				};
				Vector3[] array2 = new Vector3[array.Length / num];
				for (int i = 0; i < array.Length; i += num)
				{
					array2[i / num] = new Vector3(array[i], array[i + 1], array[i + 2]);
				}
				return array2;
			}

			// Token: 0x0600120E RID: 4622 RVA: 0x000645FF File Offset: 0x000627FF
			private int[] CreateTriangles()
			{
				return new int[]
				{
					1, 2, 0, 2, 3, 0, 3, 4, 0, 0,
					4, 1, 5, 2, 1, 5, 3, 2, 5, 4,
					3, 5, 1, 4
				};
			}

			// Token: 0x04000DC6 RID: 3526
			public Vector3[] Vertices;

			// Token: 0x04000DC7 RID: 3527
			public int[] Triangles;
		}

		// Token: 0x0200012E RID: 302
		private class Icosahedron
		{
			// Token: 0x0600120F RID: 4623 RVA: 0x00064613 File Offset: 0x00062813
			public Icosahedron()
			{
				this.Vertices = this.CreateVertices();
				this.Triangles = this.CreateTriangles();
			}

			// Token: 0x06001210 RID: 4624 RVA: 0x00064634 File Offset: 0x00062834
			private Vector3[] CreateVertices()
			{
				Vector3[] array = new Vector3[12];
				float num = 0.5f;
				float num2 = (num + Mathf.Sqrt(5f)) / 2f;
				array[0] = new Vector3(num2, 0f, num);
				array[9] = new Vector3(-num2, 0f, num);
				array[11] = new Vector3(-num2, 0f, -num);
				array[1] = new Vector3(num2, 0f, -num);
				array[2] = new Vector3(num, num2, 0f);
				array[5] = new Vector3(num, -num2, 0f);
				array[10] = new Vector3(-num, -num2, 0f);
				array[8] = new Vector3(-num, num2, 0f);
				array[3] = new Vector3(0f, num, num2);
				array[7] = new Vector3(0f, num, -num2);
				array[6] = new Vector3(0f, -num, -num2);
				array[4] = new Vector3(0f, -num, num2);
				for (int i = 0; i < 12; i++)
				{
					array[i].Normalize();
				}
				return array;
			}

			// Token: 0x06001211 RID: 4625 RVA: 0x0006476F File Offset: 0x0006296F
			private int[] CreateTriangles()
			{
				return new int[]
				{
					1, 2, 0, 2, 3, 0, 3, 4, 0, 4,
					5, 0, 5, 1, 0, 6, 7, 1, 2, 1,
					7, 7, 8, 2, 2, 8, 3, 8, 9, 3,
					3, 9, 4, 9, 10, 4, 10, 5, 4, 10,
					6, 5, 6, 1, 5, 6, 11, 7, 7, 11,
					8, 8, 11, 9, 9, 11, 10, 10, 11, 6
				};
			}

			// Token: 0x04000DC8 RID: 3528
			public Vector3[] Vertices;

			// Token: 0x04000DC9 RID: 3529
			public int[] Triangles;
		}
	}
}
