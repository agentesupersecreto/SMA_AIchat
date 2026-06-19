using System;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000013 RID: 19
	public class Cube
	{
		// Token: 0x06000139 RID: 313 RVA: 0x00008E68 File Offset: 0x00007068
		public Cube()
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

		// Token: 0x0600013A RID: 314 RVA: 0x00008EE0 File Offset: 0x000070E0
		private Vector3[] CreateVertices()
		{
			int num = 3;
			float[] array = new float[]
			{
				-0.5f, -0.5f, 0.5f, 0.5f, -0.5f, 0.5f, -0.5f, 0.5f, 0.5f, 0.5f,
				0.5f, 0.5f, -0.5f, 0.5f, -0.5f, 0.5f, 0.5f, -0.5f, -0.5f, -0.5f,
				-0.5f, 0.5f, -0.5f, -0.5f
			};
			Vector3[] array2 = new Vector3[array.Length / num];
			for (int i = 0; i < array.Length; i += num)
			{
				array2[i / num] = new Vector3(array[i], array[i + 1], array[i + 2]);
			}
			return array2;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00008F37 File Offset: 0x00007137
		private int[] CreateTriangles()
		{
			return new int[]
			{
				3, 2, 0, 3, 0, 1, 3, 5, 2, 2,
				5, 4, 7, 6, 4, 7, 4, 5, 1, 0,
				6, 1, 6, 7, 3, 1, 5, 1, 7, 5,
				2, 6, 0, 6, 2, 4
			};
		}

		// Token: 0x040000CA RID: 202
		public Vector3[] Vertices;

		// Token: 0x040000CB RID: 203
		public int[] Triangles;
	}
}
