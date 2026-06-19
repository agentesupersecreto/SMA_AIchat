using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x0200004E RID: 78
	public class MeshOctreeNode
	{
		// Token: 0x060003CB RID: 971 RVA: 0x00015D7A File Offset: 0x00013F7A
		public MeshOctreeNode()
		{
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00015DB0 File Offset: 0x00013FB0
		public MeshOctreeNode(Vector3 rCenter, Vector3 rSize)
		{
			this.Center = rCenter;
			this.Size = rSize;
			this.Min = this.Center - this.Size * 0.5f;
			this.Max = this.Center + this.Size * 0.5f;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00015E40 File Offset: 0x00014040
		public MeshOctreeNode(float rX, float rY, float rZ, Vector3 rSize)
		{
			this.Center = new Vector3(rX, rY, rZ);
			this.Size = rSize;
			this.Min = this.Center - this.Size * 0.5f;
			this.Max = this.Center + this.Size * 0.5f;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00015ED8 File Offset: 0x000140D8
		public MeshOctreeNode(float rX, float rY, float rZ, Vector3 rSize, Vector3[] rVertexArray, int[] rTriangleArray)
		{
			this.Center = new Vector3(rX, rY, rZ);
			this.Size = rSize;
			this.Min = this.Center - this.Size * 0.5f;
			this.Max = this.Center + this.Size * 0.5f;
			this.MeshVertices = rVertexArray;
			this.MeshTriangles = rTriangleArray;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00015F80 File Offset: 0x00014180
		public bool ContainsPoint(Vector3 rPoint)
		{
			return rPoint.x + 1E-05f >= this.Min.x && rPoint.x - 1E-05f <= this.Max.x && rPoint.y + 1E-05f >= this.Min.y && rPoint.y - 1E-05f <= this.Max.y && rPoint.z + 1E-05f >= this.Min.z && rPoint.z - 1E-05f <= this.Max.z;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00016030 File Offset: 0x00014230
		public bool ContainsPoint(Vector3 rPoint, float rRadius)
		{
			Vector3 vector = rPoint;
			vector.x = ((vector.x > this.Max.x) ? this.Max.x : vector.x);
			vector.x = ((vector.x < this.Min.x) ? this.Min.x : vector.x);
			vector.y = ((vector.y > this.Max.y) ? this.Max.y : vector.y);
			vector.y = ((vector.y < this.Min.y) ? this.Min.y : vector.y);
			vector.z = ((vector.z > this.Max.z) ? this.Max.z : vector.z);
			vector.z = ((vector.z < this.Min.z) ? this.Min.z : vector.z);
			return (vector - rPoint).sqrMagnitude <= rRadius * rRadius;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00016164 File Offset: 0x00014364
		public Vector3 ClosestPoint(Vector3 rPoint)
		{
			Vector3 vector = Vector3.zero;
			vector.x = float.MaxValue;
			if (rPoint.x + 1E-05f < this.Min.x)
			{
				return vector;
			}
			if (rPoint.x - 1E-05f > this.Max.x)
			{
				return vector;
			}
			if (rPoint.y + 1E-05f < this.Min.y)
			{
				return vector;
			}
			if (rPoint.y - 1E-05f > this.Max.y)
			{
				return vector;
			}
			if (rPoint.z + 1E-05f < this.Min.z)
			{
				return vector;
			}
			if (rPoint.z - 1E-05f > this.Max.z)
			{
				return vector;
			}
			if (this.Children == null)
			{
				if (this.TriangleIndexes != null)
				{
					for (int i = 0; i < this.TriangleIndexes.Count; i++)
					{
						int num = this.TriangleIndexes[i];
						Vector3 vector2 = this.MeshVertices[this.MeshTriangles[num]];
						Vector3 vector3 = this.MeshVertices[this.MeshTriangles[num + 1]];
						Vector3 vector4 = this.MeshVertices[this.MeshTriangles[num + 2]];
						Vector3 vector5;
						MeshExt.ClosestPointOnTriangle(ref rPoint, ref vector2, ref vector3, ref vector4, out vector5);
						if (vector5.x != 3.4028235E+38f && (vector.x == 3.4028235E+38f || Vector3.SqrMagnitude(vector5 - rPoint) < Vector3.SqrMagnitude(vector - rPoint)))
						{
							vector = vector5;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < 8; j++)
				{
					Vector3 vector5 = this.Children[j].ClosestPoint(rPoint);
					if (vector5.x != 3.4028235E+38f && (vector.x == 3.4028235E+38f || Vector3.SqrMagnitude(vector5 - rPoint) < Vector3.SqrMagnitude(vector - rPoint)))
					{
						vector = vector5;
					}
				}
			}
			return vector;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00016348 File Offset: 0x00014548
		public Vector3 ClosestPoint(Vector3 rPoint, float rRadius)
		{
			if (rRadius == 0f)
			{
				return this.ClosestPoint(rPoint);
			}
			Vector3 vector = Vector3.zero;
			vector.x = float.MaxValue;
			MeshOctreeNode.sClosestTrianglesIndexes.Clear();
			this.GetTriangles(rPoint, rRadius, MeshOctreeNode.sClosestTrianglesIndexes);
			for (int i = 0; i < MeshOctreeNode.sClosestTrianglesIndexes.Count; i++)
			{
				int num = MeshOctreeNode.sClosestTrianglesIndexes[i];
				Vector3 vector2 = this.MeshVertices[this.MeshTriangles[num]];
				Vector3 vector3 = this.MeshVertices[this.MeshTriangles[num + 1]];
				Vector3 vector4 = this.MeshVertices[this.MeshTriangles[num + 2]];
				Vector3 vector5;
				MeshExt.ClosestPointOnTriangle(ref rPoint, ref vector2, ref vector3, ref vector4, out vector5);
				if (vector5.x != 3.4028235E+38f && (vector.x == 3.4028235E+38f || Vector3.SqrMagnitude(vector5 - rPoint) < Vector3.SqrMagnitude(vector - rPoint)))
				{
					vector = vector5;
				}
			}
			return vector;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00016440 File Offset: 0x00014640
		public int ClosestTriangle(Vector3 rPoint)
		{
			int num = -1;
			if (rPoint.x + 1E-05f < this.Min.x)
			{
				return num;
			}
			if (rPoint.x - 1E-05f > this.Max.x)
			{
				return num;
			}
			if (rPoint.y + 1E-05f < this.Min.y)
			{
				return num;
			}
			if (rPoint.y - 1E-05f > this.Max.y)
			{
				return num;
			}
			if (rPoint.z + 1E-05f < this.Min.z)
			{
				return num;
			}
			if (rPoint.z - 1E-05f > this.Max.z)
			{
				return num;
			}
			Vector3 vector = Vector3.zero;
			vector.x = float.MaxValue;
			if (this.Children == null)
			{
				if (this.TriangleIndexes != null)
				{
					for (int i = 0; i < this.TriangleIndexes.Count; i++)
					{
						int num2 = this.TriangleIndexes[i];
						Vector3 vector2 = this.MeshVertices[this.MeshTriangles[num2]];
						Vector3 vector3 = this.MeshVertices[this.MeshTriangles[num2 + 1]];
						Vector3 vector4 = this.MeshVertices[this.MeshTriangles[num2 + 2]];
						Vector3 vector5;
						MeshExt.ClosestPointOnTriangle(ref rPoint, ref vector2, ref vector3, ref vector4, out vector5);
						if (vector5.x != 3.4028235E+38f && (vector.x == 3.4028235E+38f || Vector3.SqrMagnitude(vector5 - rPoint) < Vector3.SqrMagnitude(vector - rPoint)))
						{
							num = num2;
							vector = vector5;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < 8; j++)
				{
					int num3 = this.Children[j].ClosestTriangle(rPoint);
					if (num3 >= 0)
					{
						num = num3;
					}
				}
			}
			return num;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00016600 File Offset: 0x00014800
		public MeshOctreeNode ClosestNode(Vector3 rPoint)
		{
			MeshOctreeNode meshOctreeNode = null;
			if (rPoint.x + 1E-05f < this.Min.x)
			{
				return meshOctreeNode;
			}
			if (rPoint.x - 1E-05f > this.Max.x)
			{
				return meshOctreeNode;
			}
			if (rPoint.y + 1E-05f < this.Min.y)
			{
				return meshOctreeNode;
			}
			if (rPoint.y - 1E-05f > this.Max.y)
			{
				return meshOctreeNode;
			}
			if (rPoint.z + 1E-05f < this.Min.z)
			{
				return meshOctreeNode;
			}
			if (rPoint.z - 1E-05f > this.Max.z)
			{
				return meshOctreeNode;
			}
			if (this.Children == null)
			{
				meshOctreeNode = this;
			}
			else
			{
				for (int i = 0; i < 8; i++)
				{
					MeshOctreeNode meshOctreeNode2 = this.Children[i].ClosestNode(rPoint);
					if (meshOctreeNode2 != null && (meshOctreeNode == null || meshOctreeNode2.Size.sqrMagnitude < meshOctreeNode.Size.sqrMagnitude))
					{
						meshOctreeNode = meshOctreeNode2;
					}
				}
			}
			return meshOctreeNode;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x000166FC File Offset: 0x000148FC
		public void Insert(int rTriangleIndex)
		{
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			this.GetTriangleBounds(rTriangleIndex, out vector, out vector2, out vector3);
			this.Insert(rTriangleIndex, vector, vector2, vector3);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00016720 File Offset: 0x00014920
		public void Insert(int rTriangleIndex, Vector3 rTriangleCenter, float rTriangleRadius)
		{
			Vector3 vector = this.Center - rTriangleCenter;
			Vector3 vector2 = rTriangleCenter + vector.normalized * Mathf.Min(vector.magnitude, rTriangleRadius);
			if (vector2.x + 1E-05f < this.Min.x)
			{
				return;
			}
			if (vector2.x - 1E-05f > this.Max.x)
			{
				return;
			}
			if (vector2.y + 1E-05f < this.Min.y)
			{
				return;
			}
			if (vector2.y - 1E-05f > this.Max.y)
			{
				return;
			}
			if (vector2.z + 1E-05f < this.Min.z)
			{
				return;
			}
			if (vector2.z - 1E-05f > this.Max.z)
			{
				return;
			}
			if (this.Children == null)
			{
				if (this.TriangleIndexes == null)
				{
					this.TriangleIndexes = new List<int>();
				}
				if (this.TriangleIndexes.Count < 20 || this.Size.x <= 0.05f)
				{
					this.TriangleIndexes.Add(rTriangleIndex);
				}
				else
				{
					this.Split();
				}
			}
			if (this.Children != null)
			{
				for (int i = 0; i < 8; i++)
				{
					this.Children[i].Insert(rTriangleIndex, rTriangleCenter, rTriangleRadius);
				}
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001686C File Offset: 0x00014A6C
		public void Insert(int rTriangleIndex, Vector3 rTriangleCenter, Vector3 rTriangleMin, Vector3 rTriangleMax)
		{
			if (rTriangleMax.x + 1E-05f < this.Min.x)
			{
				return;
			}
			if (rTriangleMin.x - 1E-05f > this.Max.x)
			{
				return;
			}
			if (rTriangleMax.y + 1E-05f < this.Min.y)
			{
				return;
			}
			if (rTriangleMin.y - 1E-05f > this.Max.y)
			{
				return;
			}
			if (rTriangleMax.z + 1E-05f < this.Min.z)
			{
				return;
			}
			if (rTriangleMin.z - 1E-05f > this.Max.z)
			{
				return;
			}
			if (this.Children == null)
			{
				if (this.TriangleIndexes == null)
				{
					this.TriangleIndexes = new List<int>();
				}
				if (this.TriangleIndexes.Count < 20 || this.Size.x <= 0.05f)
				{
					this.TriangleIndexes.Add(rTriangleIndex);
				}
				else
				{
					this.Split();
				}
			}
			if (this.Children != null)
			{
				for (int i = 0; i < 8; i++)
				{
					this.Children[i].Insert(rTriangleIndex, rTriangleCenter, rTriangleMin, rTriangleMax);
				}
			}
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00016990 File Offset: 0x00014B90
		public virtual void Split()
		{
			Vector3 vector = this.Size * 0.5f;
			Vector3 vector2 = vector * 0.5f;
			this.Children = new MeshOctreeNode[8];
			this.Children[0] = new MeshOctreeNode(this.Center.x - vector2.x, this.Center.y - vector2.y, this.Center.z - vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[1] = new MeshOctreeNode(this.Center.x + vector2.x, this.Center.y - vector2.y, this.Center.z - vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[2] = new MeshOctreeNode(this.Center.x - vector2.x, this.Center.y + vector2.y, this.Center.z - vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[3] = new MeshOctreeNode(this.Center.x + vector2.x, this.Center.y + vector2.y, this.Center.z - vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[4] = new MeshOctreeNode(this.Center.x - vector2.x, this.Center.y - vector2.y, this.Center.z + vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[5] = new MeshOctreeNode(this.Center.x + vector2.x, this.Center.y - vector2.y, this.Center.z + vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[6] = new MeshOctreeNode(this.Center.x - vector2.x, this.Center.y + vector2.y, this.Center.z + vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			this.Children[7] = new MeshOctreeNode(this.Center.x + vector2.x, this.Center.y + vector2.y, this.Center.z + vector2.z, vector, this.MeshVertices, this.MeshTriangles);
			for (int i = 0; i < this.TriangleIndexes.Count; i++)
			{
				int num = this.TriangleIndexes[i];
				Vector3 vector3;
				Vector3 vector4;
				Vector3 vector5;
				this.GetTriangleBounds(num, out vector3, out vector4, out vector5);
				for (int j = 0; j < 8; j++)
				{
					this.Children[j].Insert(num, vector3, vector4, vector5);
				}
			}
			this.TriangleIndexes.Clear();
			this.TriangleIndexes = null;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00016CB0 File Offset: 0x00014EB0
		public void GetTriangles(Vector3 rPoint, float rRadius, List<int> rTriangles)
		{
			if (!this.ContainsPoint(rPoint, rRadius))
			{
				return;
			}
			if (this.Children == null)
			{
				if (this.TriangleIndexes != null)
				{
					for (int i = 0; i < this.TriangleIndexes.Count; i++)
					{
						int num = this.TriangleIndexes[i];
						if (!rTriangles.Contains(num))
						{
							rTriangles.Add(num);
						}
					}
					return;
				}
			}
			else
			{
				for (int j = 0; j < this.Children.Length; j++)
				{
					this.Children[j].GetTriangles(rPoint, rRadius, rTriangles);
				}
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00016D30 File Offset: 0x00014F30
		public void GetTriangleBounds(int rTriangleIndex, out Vector3 rTriangleCenter, out float rTriangleRadius)
		{
			Vector3 vector = this.MeshVertices[this.MeshTriangles[rTriangleIndex]];
			Vector3 vector2 = this.MeshVertices[this.MeshTriangles[rTriangleIndex + 1]];
			Vector3 vector3 = this.MeshVertices[this.MeshTriangles[rTriangleIndex + 2]];
			rTriangleCenter = (vector + vector2 + vector3) / 3f;
			float num = Vector3.SqrMagnitude(vector - rTriangleCenter);
			float num2 = Vector3.SqrMagnitude(vector2 - rTriangleCenter);
			float num3 = Vector3.SqrMagnitude(vector3 - rTriangleCenter);
			rTriangleRadius = Mathf.Sqrt(Mathf.Max(num, Mathf.Max(num2, num3)));
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00016DE8 File Offset: 0x00014FE8
		public void GetTriangleBounds(int rTriangleIndex, out Vector3 rTriangleCenter, out Vector3 rTriangleMin, out Vector3 rTriangleMax)
		{
			Vector3 vector = this.MeshVertices[this.MeshTriangles[rTriangleIndex]];
			Vector3 vector2 = this.MeshVertices[this.MeshTriangles[rTriangleIndex + 1]];
			Vector3 vector3 = this.MeshVertices[this.MeshTriangles[rTriangleIndex + 2]];
			rTriangleCenter = (vector + vector2 + vector3) / 3f;
			rTriangleMin = Vector3.zero;
			rTriangleMax = Vector3.zero;
			rTriangleMin.x = Mathf.Min(vector.x, Mathf.Min(vector2.x, vector3.x));
			rTriangleMax.x = Mathf.Max(vector.x, Mathf.Max(vector2.x, vector3.x));
			rTriangleMin.y = Mathf.Min(vector.y, Mathf.Min(vector2.y, vector3.y));
			rTriangleMax.y = Mathf.Max(vector.y, Mathf.Max(vector2.y, vector3.y));
			rTriangleMin.z = Mathf.Min(vector.z, Mathf.Min(vector2.z, vector3.z));
			rTriangleMax.z = Mathf.Max(vector.z, Mathf.Max(vector2.z, vector3.z));
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00016F38 File Offset: 0x00015138
		public void OnSceneGUI(Transform rTransform)
		{
		}

		// Token: 0x04000209 RID: 521
		public const int MAX_TRIANGLES = 20;

		// Token: 0x0400020A RID: 522
		public const float MIN_NODE_SIZE = 0.05f;

		// Token: 0x0400020B RID: 523
		public const float EPSILON = 1E-05f;

		// Token: 0x0400020C RID: 524
		private static List<int> sClosestTrianglesIndexes = new List<int>();

		// Token: 0x0400020D RID: 525
		public Vector3 Center = Vector3.zero;

		// Token: 0x0400020E RID: 526
		public Vector3 Size = Vector3.zero;

		// Token: 0x0400020F RID: 527
		public Vector3 Min = Vector3.zero;

		// Token: 0x04000210 RID: 528
		public Vector3 Max = Vector3.zero;

		// Token: 0x04000211 RID: 529
		public MeshOctreeNode[] Children;

		// Token: 0x04000212 RID: 530
		public List<int> TriangleIndexes;

		// Token: 0x04000213 RID: 531
		public Vector3[] MeshVertices;

		// Token: 0x04000214 RID: 532
		public int[] MeshTriangles;
	}
}
