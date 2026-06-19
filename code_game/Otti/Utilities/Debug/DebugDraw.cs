using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000011 RID: 17
	public class DebugDraw
	{
		// Token: 0x06000113 RID: 275 RVA: 0x000073FC File Offset: 0x000055FC
		public static void Initialize()
		{
			DebugDraw.sDisk = DebugDraw.CreateDisk();
			DebugDraw.sTetrahedron = DebugDraw.CreateTetrahedron();
			DebugDraw.sCube = DebugDraw.CreateCube();
			DebugDraw.sOctahedron = DebugDraw.CreateOctahedron();
			DebugDraw.sDodecahedron = DebugDraw.CreateDodecahedron();
			DebugDraw.sIcosahedron = DebugDraw.CreateIcosahedron();
			DebugDraw.sSphere = DebugDraw.CreateSphere();
			DebugDraw.sBone = DebugDraw.CreateBone();
			for (int i = 0; i < DebugDraw.sLineVertices.Length; i++)
			{
				DebugDraw.sLineVertices[i] = Vector3.zero;
			}
			int[] array = new int[]
			{
				3, 2, 0, 3, 0, 1, 3, 5, 2, 2,
				5, 4, 7, 6, 4, 7, 4, 5, 1, 0,
				6, 1, 6, 7, 3, 1, 5, 1, 7, 5,
				2, 6, 0, 6, 2, 4
			};
			DebugDraw.sLine = new Mesh();
			DebugDraw.sLine.vertices = DebugDraw.sLineVertices;
			DebugDraw.sLine.triangles = array;
			DebugDraw.sOverlayMaterial = new Material(Shader.Find("Standard"));
			DebugDraw.sMaterial = new Material(Shader.Find("Standard"));
			DebugDraw.sMaterialBlock = new MaterialPropertyBlock();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000074E4 File Offset: 0x000056E4
		public static void Invalidate()
		{
			DebugDraw.sMaterial = null;
			DebugDraw.sOverlayMaterial = null;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000074F4 File Offset: 0x000056F4
		public static void DrawCube(Vector3 rCenter, Vector3 rSize, Color rColor, bool rWireframe)
		{
			Vector3 vector = rSize * 0.5f;
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, -vector.y, -vector.z), rCenter + new Vector3(vector.x, -vector.y, -vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, -vector.y, -vector.z), rCenter + new Vector3(-vector.x, -vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(vector.x, -vector.y, -vector.z), rCenter + new Vector3(vector.x, -vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, -vector.y, vector.z), rCenter + new Vector3(vector.x, -vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, vector.y, -vector.z), rCenter + new Vector3(vector.x, vector.y, -vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, vector.y, -vector.z), rCenter + new Vector3(-vector.x, vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(vector.x, vector.y, -vector.z), rCenter + new Vector3(vector.x, vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, vector.y, vector.z), rCenter + new Vector3(vector.x, vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, -vector.y, -vector.z), rCenter + new Vector3(-vector.x, vector.y, -vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(-vector.x, -vector.y, vector.z), rCenter + new Vector3(-vector.x, vector.y, vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(vector.x, -vector.y, -vector.z), rCenter + new Vector3(vector.x, vector.y, -vector.z), rColor);
			DebugDraw.DrawLine(rCenter + new Vector3(vector.x, -vector.y, vector.z), rCenter + new Vector3(vector.x, vector.y, vector.z), rColor);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00007833 File Offset: 0x00005A33
		public static void DrawCircle(Vector3 rCenter, float rRadius, Color rColor)
		{
			DebugDraw.DrawArc(rCenter, Quaternion.identity, 0f, 360f, rRadius, rColor);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000784C File Offset: 0x00005A4C
		public static void DrawWireSphere(Vector3 rCenter, float rRadius, Color rColor)
		{
			DebugDraw.DrawArc(rCenter, Quaternion.identity, 0f, 360f, rRadius, rColor);
			DebugDraw.DrawArc(rCenter, Quaternion.AngleAxis(90f, Vector3.right), 0f, 360f, rRadius, rColor);
			DebugDraw.DrawArc(rCenter, Quaternion.AngleAxis(90f, Vector3.forward), 0f, 360f, rRadius, rColor);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000078B4 File Offset: 0x00005AB4
		public static void DrawArc(Vector3 rCenter, Quaternion rRotation, float rMinAngle, float rMaxAngle, float rRadius, Color rColor)
		{
			DebugDraw.sLines.Clear();
			float num = 10f;
			Vector3 zero = Vector3.zero;
			for (float num2 = rMinAngle; num2 <= rMaxAngle; num2 += num)
			{
				float num3 = -(num2 * 0.017453292f) + 1.57079f;
				zero.x = rRadius * Mathf.Cos(num3);
				zero.y = 0f;
				zero.z = rRadius * Mathf.Sin(num3);
				DebugDraw.sLines.Add(zero);
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rCenter, rRotation, Vector3.one);
			for (int i = 0; i < DebugDraw.sLines.Count; i++)
			{
				DebugDraw.sLines[i] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[i]);
			}
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007980 File Offset: 0x00005B80
		public static void DrawFrustumArc(Vector3 rPosition, Quaternion rRotation, float rHAngle, float rVAngle, float rDistance, Color rColor)
		{
			float num = 10f;
			Vector3 zero = Vector3.zero;
			float num2 = rHAngle * 0.5f;
			float num3 = rVAngle * 0.5f;
			List<Vector3> list = new List<Vector3>(2)
			{
				Vector3.zero,
				Vector3.zero
			};
			List<Vector3> list2 = new List<Vector3>(5)
			{
				Vector3.zero,
				Vector3.zero,
				Vector3.zero,
				Vector3.zero,
				Vector3.zero
			};
			List<Vector3> list3 = new List<Vector3>(5)
			{
				Vector3.zero,
				Vector3.zero,
				Vector3.zero,
				Vector3.zero,
				Vector3.zero
			};
			DebugDraw.sLines.Clear();
			for (float num4 = -num2; num4 <= num2; num4 += num)
			{
				float num5 = -(num4 * 0.017453292f) + 1.57079f;
				zero.x = 1f * Mathf.Cos(num5);
				zero.y = 0f;
				zero.z = 1f * Mathf.Sin(num5);
				DebugDraw.sLines.Add(zero);
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation * Quaternion.AngleAxis(num3, Vector3.right), Vector3.one);
			for (int i = 0; i < DebugDraw.sLines.Count; i++)
			{
				DebugDraw.sLines[i] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[i]);
			}
			list2[1] = DebugDraw.sLines[0];
			list3[1] = DebugDraw.sLines[DebugDraw.sLines.Count - 1];
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
			DebugDraw.sLines.Clear();
			for (float num6 = -num2; num6 <= num2; num6 += num)
			{
				float num7 = -(num6 * 0.017453292f) + 1.57079f;
				zero.x = rDistance * Mathf.Cos(num7);
				zero.y = 0f;
				zero.z = rDistance * Mathf.Sin(num7);
				DebugDraw.sLines.Add(zero);
			}
			matrix4x = Matrix4x4.TRS(rPosition, rRotation * Quaternion.AngleAxis(num3, Vector3.right), Vector3.one);
			for (int j = 0; j < DebugDraw.sLines.Count; j++)
			{
				DebugDraw.sLines[j] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[j]);
			}
			list2[0] = DebugDraw.sLines[0];
			list2[4] = DebugDraw.sLines[0];
			list3[0] = DebugDraw.sLines[DebugDraw.sLines.Count - 1];
			list3[4] = DebugDraw.sLines[DebugDraw.sLines.Count - 1];
			list[0] = DebugDraw.sLines[DebugDraw.sLines.Count / 2];
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
			DebugDraw.sLines.Clear();
			for (float num8 = -num2; num8 <= num2; num8 += num)
			{
				float num9 = -(num8 * 0.017453292f) + 1.57079f;
				zero.x = 1f * Mathf.Cos(num9);
				zero.y = 0f;
				zero.z = 1f * Mathf.Sin(num9);
				DebugDraw.sLines.Add(zero);
			}
			matrix4x = Matrix4x4.TRS(rPosition, rRotation * Quaternion.AngleAxis(-num3, Vector3.right), Vector3.one);
			for (int k = 0; k < DebugDraw.sLines.Count; k++)
			{
				DebugDraw.sLines[k] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[k]);
			}
			list2[2] = DebugDraw.sLines[0];
			list3[2] = DebugDraw.sLines[DebugDraw.sLines.Count - 1];
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
			DebugDraw.sLines.Clear();
			for (float num10 = -num2; num10 <= num2; num10 += num)
			{
				float num11 = -(num10 * 0.017453292f) + 1.57079f;
				zero.x = rDistance * Mathf.Cos(num11);
				zero.y = 0f;
				zero.z = rDistance * Mathf.Sin(num11);
				DebugDraw.sLines.Add(zero);
			}
			matrix4x = Matrix4x4.TRS(rPosition, rRotation * Quaternion.AngleAxis(-num3, Vector3.right), Vector3.one);
			for (int l = 0; l < DebugDraw.sLines.Count; l++)
			{
				DebugDraw.sLines[l] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[l]);
			}
			list2[3] = DebugDraw.sLines[0];
			list3[3] = DebugDraw.sLines[DebugDraw.sLines.Count - 1];
			list[1] = DebugDraw.sLines[DebugDraw.sLines.Count / 2];
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
			DebugDraw.sLines.Clear();
			for (float num12 = -num3; num12 <= num3; num12 += num)
			{
				float num13 = -(num12 * 0.017453292f) + 1.57079f;
				zero.x = 0f;
				zero.y = 1f * Mathf.Cos(num13);
				zero.z = 1f * Mathf.Sin(num13);
				DebugDraw.sLines.Add(zero);
			}
			matrix4x = Matrix4x4.TRS(rPosition, rRotation, Vector3.one);
			for (int m = 0; m < DebugDraw.sLines.Count; m++)
			{
				DebugDraw.sLines[m] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[m]);
			}
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
			DebugDraw.sLines.Clear();
			for (float num14 = -num3; num14 <= num3; num14 += num)
			{
				float num15 = -(num14 * 0.017453292f) + 1.57079f;
				zero.x = 0f;
				zero.y = rDistance * Mathf.Cos(num15);
				zero.z = rDistance * Mathf.Sin(num15);
				DebugDraw.sLines.Add(zero);
			}
			matrix4x = Matrix4x4.TRS(rPosition, rRotation, Vector3.one);
			for (int n = 0; n < DebugDraw.sLines.Count; n++)
			{
				DebugDraw.sLines[n] = matrix4x.MultiplyPoint3x4(DebugDraw.sLines[n]);
			}
			DebugDraw.DrawLines(DebugDraw.sLines, rColor);
			DebugDraw.DrawLines(list2, rColor);
			DebugDraw.DrawLines(list3, rColor);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00008028 File Offset: 0x00006228
		public static void DrawLines(List<Vector3> rLines, Color rColor)
		{
			for (int i = 1; i < rLines.Count; i++)
			{
				Debug.DrawLine(rLines[i - 1], rLines[i], rColor);
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000805C File Offset: 0x0000625C
		public static void DrawLine(Vector3 rFrom, Vector3 rTo, Color rColor)
		{
			Debug.DrawLine(rFrom, rTo, rColor);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00008068 File Offset: 0x00006268
		public static void DrawLine(Vector3 rFrom, Vector3 rTo, float rThickness, Color rColor, float rAlpha)
		{
			if (DebugDraw.sCube == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Vector3 vector = new Vector3(rFrom.x + (rTo.x - rFrom.x) / 2f, rFrom.y + (rTo.y - rFrom.y) / 2f, rFrom.z + (rTo.z - rFrom.z) / 2f);
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.right, (rTo - rFrom).normalized);
			Vector3 vector2 = new Vector3(Vector3.Distance(rFrom, rTo), rThickness, rThickness);
			Matrix4x4 matrix4x = Matrix4x4.TRS(vector, quaternion, vector2);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sCube, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00008180 File Offset: 0x00006380
		public static void DrawLineOverlay(Vector3 rFrom, Vector3 rTo, float rThickness, Color rColor, float rAlpha)
		{
			if (DebugDraw.sCube == null || DebugDraw.sOverlayMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Vector3 vector = new Vector3(rFrom.x + (rTo.x - rFrom.x) / 2f, rFrom.y + (rTo.y - rFrom.y) / 2f, rFrom.z + (rTo.z - rFrom.z) / 2f);
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.right, (rTo - rFrom).normalized);
			Vector3 vector2 = new Vector3(Vector3.Distance(rFrom, rTo), rThickness, rThickness);
			Matrix4x4 matrix4x = Matrix4x4.TRS(vector, quaternion, vector2);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sCube, matrix4x, DebugDraw.sOverlayMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00008298 File Offset: 0x00006498
		public static void DrawTetrahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
			if (DebugDraw.sTetrahedron == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rSize * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sTetrahedron, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000833C File Offset: 0x0000653C
		public static void DrawCubeMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
			if (DebugDraw.sCube == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rSize * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sCube, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000083E0 File Offset: 0x000065E0
		public static void DrawOctahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
			if (DebugDraw.sOctahedron == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rSize * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sOctahedron, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00008484 File Offset: 0x00006684
		public static void DrawOctahedronOverlay(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
			if (DebugDraw.sOctahedron == null || DebugDraw.sOverlayMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rSize * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sOctahedron, matrix4x, DebugDraw.sOverlayMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00008528 File Offset: 0x00006728
		public static void DrawDodecahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
			if (DebugDraw.sDodecahedron == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rSize * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sDodecahedron, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000085CC File Offset: 0x000067CC
		public static void DrawIcosahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
			if (DebugDraw.sIcosahedron == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rSize * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sIcosahedron, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00008670 File Offset: 0x00006870
		public static void DrawSphereMesh(Vector3 rPosition, float rRadius, Color rColor, float rAlpha)
		{
			if (DebugDraw.sSphere == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, Quaternion.identity, rRadius * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sSphere, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00008714 File Offset: 0x00006914
		public static void DrawSphereOverlay(Vector3 rPosition, float rRadius, Color rColor, float rAlpha)
		{
			if (DebugDraw.sSphere == null || DebugDraw.sOverlayMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, Quaternion.identity, rRadius * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sSphere, matrix4x, DebugDraw.sOverlayMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000087B8 File Offset: 0x000069B8
		public static void DrawDiskMesh(Vector3 rPosition, Quaternion rRotation, float rRadius, Color rColor, float rAlpha)
		{
			if (DebugDraw.sDisk == null || DebugDraw.sMaterial == null)
			{
				DebugDraw.Initialize();
			}
			Matrix4x4 matrix4x = Matrix4x4.TRS(rPosition, rRotation, rRadius * 2f * Vector3.one);
			Color color = rColor;
			color.a = rAlpha;
			Color color2 = rColor * 0.5f;
			color2.a = rAlpha;
			DebugDraw.sMaterialBlock.Clear();
			DebugDraw.sMaterialBlock.SetColor("_Color", color);
			DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
			Graphics.DrawMesh(DebugDraw.sDisk, matrix4x, DebugDraw.sMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00008860 File Offset: 0x00006A60
		public static void DrawBoneMesh(Transform rBoneTransform, Color rColor, float rAlpha)
		{
			if (rBoneTransform == null)
			{
				return;
			}
			if (DebugDraw.sBone == null || DebugDraw.sOverlayMaterial == null)
			{
				DebugDraw.Initialize();
			}
			float num = 0.02f;
			int num2 = Mathf.Max(rBoneTransform.childCount, 1);
			for (int i = 0; i < num2; i++)
			{
				Quaternion quaternion = rBoneTransform.rotation;
				if (rBoneTransform.childCount > i)
				{
					Transform child = rBoneTransform.GetChild(i);
					num = Vector3.Distance(rBoneTransform.position, child.position);
					quaternion = Quaternion.FromToRotation(Vector3.up, child.position - rBoneTransform.position);
				}
				Matrix4x4 matrix4x = Matrix4x4.TRS(rBoneTransform.position, quaternion, num * Vector3.one);
				Color color = rColor;
				color.a = rAlpha;
				Color color2 = rColor * 0.5f;
				color2.a = rAlpha;
				DebugDraw.sMaterialBlock.Clear();
				DebugDraw.sMaterialBlock.SetColor("_Color", color);
				DebugDraw.sMaterialBlock.SetColor("_Emission", color2);
				Graphics.DrawMesh(DebugDraw.sBone, matrix4x, DebugDraw.sOverlayMaterial, 0, null, 0, DebugDraw.sMaterialBlock);
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00008984 File Offset: 0x00006B84
		public static void DrawSkeleton(Transform rRootTransform, Color rColor, float rAlpha)
		{
			if (rRootTransform == null)
			{
				return;
			}
			DebugDraw.DrawBoneMesh(rRootTransform, rColor, rAlpha);
			for (int i = 0; i < rRootTransform.childCount; i++)
			{
				DebugDraw.DrawSkeleton(rRootTransform.GetChild(i), rColor, rAlpha);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000089C4 File Offset: 0x00006BC4
		public static void DrawSkeleton(Transform rRootTransform, Color rColor, float rAlpha, bool rDrawAxis, List<Transform> rSelectedBones, Color rSelectedColor)
		{
			if (rRootTransform == null)
			{
				return;
			}
			if (rSelectedBones != null && rSelectedBones.IndexOf(rRootTransform) >= 0)
			{
				DebugDraw.DrawBoneMesh(rRootTransform, rSelectedColor, 1f);
			}
			else
			{
				DebugDraw.DrawBoneMesh(rRootTransform, rColor, rAlpha);
			}
			for (int i = 0; i < rRootTransform.childCount; i++)
			{
				DebugDraw.DrawSkeleton(rRootTransform.GetChild(i), rColor, rAlpha, rDrawAxis, rSelectedBones, rSelectedColor);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00008A28 File Offset: 0x00006C28
		public static void DrawHumanoidSkeleton(GameObject rObject, Color rColor, float rAlpha)
		{
			Animator component = rObject.GetComponent<Animator>();
			if (component == null)
			{
				return;
			}
			string[] names = Enum.GetNames(typeof(HumanBodyBones));
			for (int i = 0; i < names.Length; i++)
			{
				Transform boneTransform = component.GetBoneTransform((HumanBodyBones)i);
				if (boneTransform != null)
				{
					DebugDraw.DrawBoneMesh(boneTransform, rColor, rAlpha);
				}
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00008A80 File Offset: 0x00006C80
		public static void DrawTransform(Transform rTransform, float rSize)
		{
			Vector3 position = rTransform.position;
			Quaternion rotation = rTransform.rotation;
			DebugDraw.DrawLineOverlay(position, position + rotation * Vector3.right * rSize, 0.002f, Color.red, 1f);
			DebugDraw.DrawLineOverlay(position, position + rotation * Vector3.up * rSize, 0.002f, Color.green, 1f);
			DebugDraw.DrawLineOverlay(position, position + rotation * Vector3.forward * rSize, 0.002f, Color.blue, 1f);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00008B20 File Offset: 0x00006D20
		public static void DrawTransform(Vector3 rPosition, Quaternion rRotation, float rSize)
		{
			DebugDraw.DrawLineOverlay(rPosition, rPosition + rRotation * Vector3.right * rSize, 0.002f, Color.red, 1f);
			DebugDraw.DrawLineOverlay(rPosition, rPosition + rRotation * Vector3.up * rSize, 0.002f, Color.green, 1f);
			DebugDraw.DrawLineOverlay(rPosition, rPosition + rRotation * Vector3.forward * rSize, 0.002f, Color.blue, 1f);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00008BB4 File Offset: 0x00006DB4
		public static Mesh CreateTetrahedron()
		{
			Tetrahedron tetrahedron = new Tetrahedron();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = tetrahedron.Vertices;
			mesh.triangles = tetrahedron.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008BF4 File Offset: 0x00006DF4
		public static Mesh CreateCube()
		{
			Cube cube = new Cube();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = cube.Vertices;
			mesh.triangles = cube.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008C34 File Offset: 0x00006E34
		public static Mesh CreateOctahedron()
		{
			Octahedron octahedron = new Octahedron();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = octahedron.Vertices;
			mesh.triangles = octahedron.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00008C74 File Offset: 0x00006E74
		public static Mesh CreateDodecahedron()
		{
			Dodecahedron dodecahedron = new Dodecahedron();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = dodecahedron.Vertices;
			mesh.triangles = dodecahedron.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008CB4 File Offset: 0x00006EB4
		public static Mesh CreateIcosahedron()
		{
			Icosahedron icosahedron = new Icosahedron();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = icosahedron.Vertices;
			mesh.triangles = icosahedron.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00008CF2 File Offset: 0x00006EF2
		public static Mesh CreateSphere()
		{
			return IcoSphere.CreateSphere(4);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00008CFC File Offset: 0x00006EFC
		public static Mesh CreateDisk()
		{
			Disk disk = new Disk();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = disk.Vertices;
			mesh.triangles = disk.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00008D3C File Offset: 0x00006F3C
		public static Mesh CreateBone()
		{
			Bone bone = new Bone();
			Mesh mesh = new Mesh();
			mesh.hideFlags = HideFlags.HideAndDontSave;
			mesh.vertices = bone.Vertices;
			mesh.triangles = bone.Triangles;
			mesh.RecalculateNormals();
			return mesh;
		}

		// Token: 0x040000BA RID: 186
		private static Material sMaterial;

		// Token: 0x040000BB RID: 187
		private static Material sOverlayMaterial;

		// Token: 0x040000BC RID: 188
		private static MaterialPropertyBlock sMaterialBlock;

		// Token: 0x040000BD RID: 189
		private static List<Vector3> sLines = new List<Vector3>();

		// Token: 0x040000BE RID: 190
		private static Vector3[] sLineVertices = new Vector3[8];

		// Token: 0x040000BF RID: 191
		private static Mesh sLine;

		// Token: 0x040000C0 RID: 192
		private static Mesh sDisk;

		// Token: 0x040000C1 RID: 193
		private static Mesh sTetrahedron;

		// Token: 0x040000C2 RID: 194
		private static Mesh sCube;

		// Token: 0x040000C3 RID: 195
		private static Mesh sOctahedron;

		// Token: 0x040000C4 RID: 196
		private static Mesh sDodecahedron;

		// Token: 0x040000C5 RID: 197
		private static Mesh sIcosahedron;

		// Token: 0x040000C6 RID: 198
		private static Mesh sSphere;

		// Token: 0x040000C7 RID: 199
		private static Mesh sBone;
	}
}
