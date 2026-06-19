using System;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000014 RID: 20
	public class Octahedron
	{
		// Token: 0x0600013C RID: 316 RVA: 0x00008F4C File Offset: 0x0000714C
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

		// Token: 0x0600013D RID: 317 RVA: 0x00008FC4 File Offset: 0x000071C4
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

		// Token: 0x0600013E RID: 318 RVA: 0x0000901B File Offset: 0x0000721B
		private int[] CreateTriangles()
		{
			return new int[]
			{
				1, 2, 0, 2, 3, 0, 3, 4, 0, 0,
				4, 1, 5, 2, 1, 5, 3, 2, 5, 4,
				3, 5, 1, 4
			};
		}

		// Token: 0x040000CC RID: 204
		public Vector3[] Vertices;

		// Token: 0x040000CD RID: 205
		public int[] Triangles;
	}
}
