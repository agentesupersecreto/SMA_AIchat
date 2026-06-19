using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Graphics
{
	// Token: 0x0200003C RID: 60
	public class Text
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0000FA2B File Offset: 0x0000DC2B
		public static int Length
		{
			get
			{
				return Text.sPool.Length;
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000FA37 File Offset: 0x0000DC37
		public static Text Allocate()
		{
			return Text.sPool.Allocate();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000FA44 File Offset: 0x0000DC44
		public static void Release(Text rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			if (rInstance.Texture != null)
			{
				Object.Destroy(rInstance.Texture);
				rInstance.Texture = null;
			}
			rInstance.Transform = null;
			rInstance.Value = "";
			rInstance.Position = Vector3.zero;
			rInstance.Color = Color.white;
			rInstance.ExpirationTime = 0f;
			Text.sPool.Release(rInstance);
		}

		// Token: 0x0400019D RID: 413
		public Transform Transform;

		// Token: 0x0400019E RID: 414
		public string Value = "";

		// Token: 0x0400019F RID: 415
		public Vector3 Position = Vector3.zero;

		// Token: 0x040001A0 RID: 416
		public Color Color = Color.white;

		// Token: 0x040001A1 RID: 417
		public Texture2D Texture;

		// Token: 0x040001A2 RID: 418
		public float ExpirationTime;

		// Token: 0x040001A3 RID: 419
		private static ObjectPool<Text> sPool = new ObjectPool<Text>(20, 5);
	}
}
