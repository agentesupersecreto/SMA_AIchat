using System;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x02000018 RID: 24
	public class Bone
	{
		// Token: 0x06000148 RID: 328 RVA: 0x00009314 File Offset: 0x00007514
		public Bone()
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

		// Token: 0x06000149 RID: 329 RVA: 0x0000938C File Offset: 0x0000758C
		private Vector3[] CreateVertices()
		{
			int num = 3;
			float[] array = new float[]
			{
				0f, 1f, 0f, 0.1f, 0.1f, 0f, 0f, 0.1f, -0.1f, -0.1f,
				0.1f, 0f, 0f, 0.1f, 0.1f, 0f, 0f, 0f
			};
			Vector3[] array2 = new Vector3[array.Length / num];
			for (int i = 0; i < array.Length; i += num)
			{
				array2[i / num] = new Vector3(array[i], array[i + 1], array[i + 2]);
			}
			return array2;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000093E3 File Offset: 0x000075E3
		private int[] CreateTriangles()
		{
			return new int[]
			{
				1, 2, 0, 2, 3, 0, 3, 4, 0, 0,
				4, 1, 5, 2, 1, 5, 3, 2, 5, 4,
				3, 5, 1, 4
			};
		}

		// Token: 0x040000D4 RID: 212
		public static Vector3[] BoneVertices = new Vector3[]
		{
			new Vector3(0f, 1f, 0f),
			new Vector3(0.1f, 0.1f, 0f),
			new Vector3(0f, 0.1f, -0.1f),
			new Vector3(-0.1f, 0.1f, 0f),
			new Vector3(0f, 0.1f, 0.1f),
			new Vector3(0f, 0f, 0f)
		};

		// Token: 0x040000D5 RID: 213
		public Vector3[] Vertices;

		// Token: 0x040000D6 RID: 214
		public int[] Triangles;
	}
}
