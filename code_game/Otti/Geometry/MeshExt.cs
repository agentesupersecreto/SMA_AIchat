using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x0200004C RID: 76
	public class MeshExt
	{
		// Token: 0x060003BF RID: 959 RVA: 0x0001570C File Offset: 0x0001390C
		public static Vector3 ClosestVertex(Vector3 rPoint, Transform rTransform, Mesh rMesh)
		{
			Vector3 vector = Vector3.zero;
			float num = float.MaxValue;
			Vector3 vector2 = rTransform.InverseTransformPoint(rPoint);
			for (int i = rMesh.vertices.Length - 1; i >= 0; i--)
			{
				Vector3 vector3 = rMesh.vertices[i];
				float sqrMagnitude = (vector2 - vector3).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					vector = vector3;
				}
			}
			return vector;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00015770 File Offset: 0x00013970
		public static Vector3 ClosestPoint(Vector3 rPoint, float rRadius, Transform rTransform, Mesh rMesh)
		{
			int instanceID = rMesh.GetInstanceID();
			if (MeshExt.MeshOctrees.ContainsKey(instanceID))
			{
				MeshOctree meshOctree = MeshExt.MeshOctrees[instanceID];
			}
			else
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				MeshOctree meshOctree = new MeshOctree(rMesh);
				stopwatch.Stop();
				MeshExt.MeshOctrees.Add(instanceID, meshOctree);
				MeshExt.MeshParseTime.Add(instanceID, (float)stopwatch.ElapsedTicks / 10000000f);
			}
			Vector3 vector = rTransform.InverseTransformPoint(rPoint);
			Vector3 vector2 = MeshExt.MeshOctrees[instanceID].ClosestPoint(vector, rRadius);
			if (vector2.x == 3.4028235E+38f)
			{
				vector2 = Vector3Ext.Null;
			}
			if (vector2 != Vector3Ext.Null)
			{
				vector2 = rTransform.TransformPoint(vector2);
			}
			return vector2;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00015828 File Offset: 0x00013A28
		public static void ClosestPointOnTriangle(ref Vector3 point, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 result)
		{
			Vector3 vector = vertex2 - vertex1;
			Vector3 vector2 = vertex3 - vertex1;
			Vector3 vector3 = point - vertex1;
			float num = Vector3.Dot(vector, vector3);
			float num2 = Vector3.Dot(vector2, vector3);
			if (num <= 0f && num2 <= 0f)
			{
				result = vertex1;
				return;
			}
			Vector3 vector4 = point - vertex2;
			float num3 = Vector3.Dot(vector, vector4);
			float num4 = Vector3.Dot(vector2, vector4);
			if (num3 >= 0f && num4 <= num3)
			{
				result = vertex2;
				return;
			}
			float num5 = num * num4 - num3 * num2;
			if (num5 <= 0f && num >= 0f && num3 <= 0f)
			{
				float num6 = num / (num - num3);
				result = vertex1 + num6 * vector;
				return;
			}
			Vector3 vector5 = point - vertex3;
			float num7 = Vector3.Dot(vector, vector5);
			float num8 = Vector3.Dot(vector2, vector5);
			if (num8 >= 0f && num7 <= num8)
			{
				result = vertex3;
				return;
			}
			float num9 = num7 * num2 - num * num8;
			if (num9 <= 0f && num2 >= 0f && num8 <= 0f)
			{
				float num10 = num2 / (num2 - num8);
				result = vertex1 + num10 * vector2;
				return;
			}
			float num11 = num3 * num8 - num7 * num4;
			if (num11 <= 0f && num4 - num3 >= 0f && num7 - num8 >= 0f)
			{
				float num12 = (num4 - num3) / (num4 - num3 + (num7 - num8));
				result = vertex2 + num12 * (vertex3 - vertex2);
				return;
			}
			float num13 = 1f / (num11 + num9 + num5);
			float num14 = num9 * num13;
			float num15 = num5 * num13;
			result = vertex1 + vector * num14 + vector2 * num15;
		}

		// Token: 0x04000204 RID: 516
		public static Dictionary<int, MeshOctree> MeshOctrees = new Dictionary<int, MeshOctree>();

		// Token: 0x04000205 RID: 517
		public static Dictionary<int, float> MeshParseTime = new Dictionary<int, float>();

		// Token: 0x04000206 RID: 518
		public static Transform DebugTransform = null;
	}
}
