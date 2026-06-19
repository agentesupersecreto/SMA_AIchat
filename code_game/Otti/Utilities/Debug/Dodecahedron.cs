using System;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000015 RID: 21
	public class Dodecahedron
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00009030 File Offset: 0x00007230
		public Dodecahedron()
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

		// Token: 0x06000140 RID: 320 RVA: 0x000090A8 File Offset: 0x000072A8
		private Vector3[] CreateVertices()
		{
			int num = 3;
			float[] array = new float[]
			{
				0.351283f, -0.499921f, -0f, 0.595112f, -0.13843f, 0f, 0.180745f, -0.121914f, -0.570779f, 0.489714f,
				0.095191f, -0.352761f, 0.095191f, -0.489714f, -0.352761f, 0.180745f, -0.121914f, 0.570779f, 0.095191f, -0.489714f,
				0.352761f, 0.489714f, 0.095191f, 0.352761f, -0.595112f, 0.13843f, -0f, -0.351283f, 0.499921f, 0f,
				-0.180745f, 0.121914f, 0.570779f, -0.489714f, -0.095191f, 0.352761f, -0.095191f, 0.489714f, 0.352761f, -0.180745f,
				0.121914f, -0.570779f, -0.095191f, 0.489714f, -0.352761f, -0.489714f, -0.095191f, -0.352761f, -0.319176f, -0.473197f,
				0.218018f, 0.319176f, 0.473197f, 0.218018f, 0.319176f, 0.473197f, -0.218018f, -0.319176f, -0.473197f, -0.218018f
			};
			Vector3[] array2 = new Vector3[array.Length / num];
			for (int i = 0; i < array.Length; i += num)
			{
				array2[i / num] = new Vector3(array[i], array[i + 1], array[i + 2]);
			}
			return array2;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000090FF File Offset: 0x000072FF
		private int[] CreateTriangles()
		{
			return new int[]
			{
				2, 1, 4, 1, 2, 3, 4, 1, 0, 1,
				5, 6, 1, 6, 0, 5, 1, 7, 0, 16,
				19, 16, 0, 6, 0, 19, 4, 16, 10, 11,
				10, 16, 5, 5, 16, 6, 8, 19, 16, 19,
				8, 15, 16, 11, 8, 19, 2, 4, 2, 19,
				13, 13, 19, 15, 13, 18, 2, 18, 13, 14,
				18, 3, 2, 18, 1, 3, 1, 17, 7, 17,
				1, 18, 10, 17, 12, 17, 5, 7, 5, 17,
				10, 12, 8, 10, 8, 12, 9, 8, 11, 10,
				9, 17, 18, 17, 9, 12, 9, 18, 14, 13,
				8, 14, 8, 13, 15, 14, 8, 9
			};
		}

		// Token: 0x040000CE RID: 206
		public Vector3[] Vertices;

		// Token: 0x040000CF RID: 207
		public int[] Triangles;
	}
}
