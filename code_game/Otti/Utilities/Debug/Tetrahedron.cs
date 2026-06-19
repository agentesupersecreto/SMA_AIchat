using System;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000012 RID: 18
	public class Tetrahedron
	{
		// Token: 0x06000136 RID: 310 RVA: 0x00008D84 File Offset: 0x00006F84
		public Tetrahedron()
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

		// Token: 0x06000137 RID: 311 RVA: 0x00008DFC File Offset: 0x00006FFC
		private Vector3[] CreateVertices()
		{
			int num = 3;
			float[] array = new float[]
			{
				-0.3525f, -0.49851f, -0.610548f, -0.3525f, -0.49851f, 0.610548f, 0.705f, -0.49851f, -0f, 0f,
				0.49851f, 0f
			};
			Vector3[] array2 = new Vector3[array.Length / num];
			for (int i = 0; i < array.Length; i += num)
			{
				array2[i / num] = new Vector3(array[i], array[i + 1], array[i + 2]);
			}
			return array2;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00008E53 File Offset: 0x00007053
		private int[] CreateTriangles()
		{
			return new int[]
			{
				2, 1, 0, 2, 3, 1, 3, 2, 0, 1,
				3, 0
			};
		}

		// Token: 0x040000C8 RID: 200
		public Vector3[] Vertices;

		// Token: 0x040000C9 RID: 201
		public int[] Triangles;
	}
}
