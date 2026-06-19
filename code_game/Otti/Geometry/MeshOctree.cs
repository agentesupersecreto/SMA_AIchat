using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x0200004D RID: 77
	public class MeshOctree
	{
		// Token: 0x060003C4 RID: 964 RVA: 0x00015A8D File Offset: 0x00013C8D
		public MeshOctree()
		{
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00015AA0 File Offset: 0x00013CA0
		public MeshOctree(Mesh rMesh)
		{
			this.Initialize(rMesh);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00015ABC File Offset: 0x00013CBC
		public void Initialize(Mesh rMesh)
		{
			if (rMesh == null)
			{
				return;
			}
			this.Name = rMesh.name;
			float num = Mathf.Max(rMesh.bounds.size.x, Mathf.Max(rMesh.bounds.size.y, rMesh.bounds.size.z));
			this.Root = new MeshOctreeNode(rMesh.bounds.center, new Vector3(num, num, num));
			this.Root.MeshVertices = rMesh.vertices;
			this.Root.MeshTriangles = rMesh.triangles;
			int num2 = this.Root.MeshTriangles.Length / 3;
			for (int i = 0; i < num2; i++)
			{
				this.Root.Insert(i * 3);
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00015B90 File Offset: 0x00013D90
		public bool ContainsPoint(Vector3 rPoint)
		{
			return this.Root != null && this.Root.ContainsPoint(rPoint);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00015BA8 File Offset: 0x00013DA8
		public Vector3 ClosestPoint(Vector3 rPoint)
		{
			if (this.Root == null)
			{
				return Vector3.zero;
			}
			Vector3 min = this.Root.Min;
			Vector3 max = this.Root.Max;
			if (rPoint.x < min.x)
			{
				rPoint.x = min.x;
			}
			else if (rPoint.x > max.x)
			{
				rPoint.x = max.x;
			}
			if (rPoint.y < min.y)
			{
				rPoint.y = min.y;
			}
			else if (rPoint.y > max.y)
			{
				rPoint.y = max.y;
			}
			if (rPoint.z < min.z)
			{
				rPoint.z = min.z;
			}
			else if (rPoint.z > max.z)
			{
				rPoint.z = max.z;
			}
			return this.Root.ClosestPoint(rPoint);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00015C90 File Offset: 0x00013E90
		public Vector3 ClosestPoint(Vector3 rPoint, float rRadius)
		{
			if (this.Root == null)
			{
				return Vector3.zero;
			}
			Vector3 min = this.Root.Min;
			Vector3 max = this.Root.Max;
			if (rPoint.x < min.x)
			{
				rPoint.x = min.x;
			}
			else if (rPoint.x > max.x)
			{
				rPoint.x = max.x;
			}
			if (rPoint.y < min.y)
			{
				rPoint.y = min.y;
			}
			else if (rPoint.y > max.y)
			{
				rPoint.y = max.y;
			}
			if (rPoint.z < min.z)
			{
				rPoint.z = min.z;
			}
			else if (rPoint.z > max.z)
			{
				rPoint.z = max.z;
			}
			return this.Root.ClosestPoint(rPoint, rRadius);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00015D78 File Offset: 0x00013F78
		public void OnSceneGUI(Transform rTransform)
		{
		}

		// Token: 0x04000207 RID: 519
		public string Name = "";

		// Token: 0x04000208 RID: 520
		public MeshOctreeNode Root;
	}
}
