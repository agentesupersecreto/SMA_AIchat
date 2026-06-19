using System;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000016 RID: 22
	public class Icosahedron
	{
		// Token: 0x06000142 RID: 322 RVA: 0x00009114 File Offset: 0x00007314
		public Icosahedron()
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

		// Token: 0x06000143 RID: 323 RVA: 0x0000918C File Offset: 0x0000738C
		private Vector3[] CreateVertices()
		{
			int num = 3;
			float[] array = new float[]
			{
				0.500001f, 0f, -0.309017f, 0.500001f, -0f, 0.309017f, -0.500001f, -0f, 0.309017f, -0.500001f,
				0f, -0.309017f, 0f, -0.309017f, 0.500001f, 0f, 0.309017f, 0.500001f, 0f, 0.309017f,
				-0.500001f, 0f, -0.309017f, -0.500001f, -0.309017f, -0.500001f, -0f, 0.309017f, -0.500001f, -0f,
				0.309017f, 0.500001f, 0f, -0.309017f, 0.500001f, 0f
			};
			Vector3[] array2 = new Vector3[array.Length / num];
			for (int i = 0; i < array.Length; i += num)
			{
				array2[i / num] = new Vector3(array[i], array[i + 1], array[i + 2]);
			}
			return array2;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000091E3 File Offset: 0x000073E3
		private int[] CreateTriangles()
		{
			return new int[]
			{
				1, 9, 0, 0, 10, 1, 0, 7, 6, 0,
				6, 10, 0, 9, 7, 4, 1, 5, 9, 1,
				4, 1, 10, 5, 3, 8, 2, 2, 11, 3,
				4, 5, 2, 2, 8, 4, 5, 11, 2, 6,
				7, 3, 3, 11, 6, 3, 7, 8, 4, 8,
				9, 5, 10, 11, 6, 11, 10, 7, 9, 8
			};
		}

		// Token: 0x040000D0 RID: 208
		public Vector3[] Vertices;

		// Token: 0x040000D1 RID: 209
		public int[] Triangles;
	}
}
