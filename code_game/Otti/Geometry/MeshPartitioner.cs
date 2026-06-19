using System;
using System.Diagnostics;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x0200004F RID: 79
	[AddComponentMenu("ootii/Mesh Partitioner")]
	public class MeshPartitioner : MonoBehaviour
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00016F48 File Offset: 0x00015148
		public void Start()
		{
			if (this.ParseOnStart)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				Mesh mesh = this.ExtractMesh();
				if (mesh != null)
				{
					int instanceID = mesh.GetInstanceID();
					if (mesh.isReadable && !MeshExt.MeshOctrees.ContainsKey(instanceID))
					{
						MeshOctree meshOctree = new MeshOctree(mesh);
						MeshExt.MeshOctrees.Add(instanceID, meshOctree);
						MeshExt.MeshParseTime.Add(instanceID, 0f);
					}
				}
				stopwatch.Stop();
				this.ParseTime = (float)stopwatch.ElapsedTicks / 10000000f;
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00016FD4 File Offset: 0x000151D4
		public Mesh ExtractMesh()
		{
			Mesh mesh = null;
			MeshCollider meshCollider = base.gameObject.GetComponent<MeshCollider>();
			if (meshCollider != null)
			{
				mesh = meshCollider.sharedMesh;
			}
			meshCollider = base.gameObject.GetComponentInChildren<MeshCollider>();
			if (meshCollider != null)
			{
				mesh = meshCollider.sharedMesh;
			}
			if (mesh == null)
			{
				mesh = base.gameObject.GetComponent<MeshFilter>().sharedMesh;
			}
			if (mesh != null && !mesh.isReadable)
			{
				mesh = null;
			}
			return mesh;
		}

		// Token: 0x04000215 RID: 533
		public MeshOctree MeshOctree;

		// Token: 0x04000216 RID: 534
		public bool ParseOnStart;

		// Token: 0x04000217 RID: 535
		public float ParseTime;

		// Token: 0x04000218 RID: 536
		public int ParseVertexCount;

		// Token: 0x04000219 RID: 537
		public bool RenderOctree;

		// Token: 0x0400021A RID: 538
		public bool RenderMesh;

		// Token: 0x0400021B RID: 539
		public bool RenderTestNode;

		// Token: 0x0400021C RID: 540
		public bool RenderTestTriangle;

		// Token: 0x0400021D RID: 541
		public Vector3 TestPosition = Vector3.zero;

		// Token: 0x0400021E RID: 542
		public Transform TestTransform;

		// Token: 0x0400021F RID: 543
		public bool ShowDebug;
	}
}
