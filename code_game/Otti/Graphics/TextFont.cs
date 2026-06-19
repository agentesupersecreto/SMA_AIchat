using System;
using System.Collections.Generic;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Graphics
{
	// Token: 0x0200003E RID: 62
	public class TextFont
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000FB47 File Offset: 0x0000DD47
		public static int Length
		{
			get
			{
				return TextFont.sPool.Length;
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000FB53 File Offset: 0x0000DD53
		public static TextFont Allocate()
		{
			return TextFont.sPool.Allocate();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000FB60 File Offset: 0x0000DD60
		public static void Release(TextFont rInstance)
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
			foreach (TextCharacter textCharacter in rInstance.Characters.Values)
			{
				TextCharacter.Release(textCharacter);
			}
			rInstance.Font = null;
			rInstance.Characters.Clear();
			rInstance.MinX = 0;
			rInstance.MaxX = 0;
			rInstance.MinY = 0;
			rInstance.MaxY = 0;
			TextFont.sPool.Release(rInstance);
		}

		// Token: 0x040001AC RID: 428
		public Font Font;

		// Token: 0x040001AD RID: 429
		public Texture2D Texture;

		// Token: 0x040001AE RID: 430
		public int MinX;

		// Token: 0x040001AF RID: 431
		public int MaxX;

		// Token: 0x040001B0 RID: 432
		public int MinY;

		// Token: 0x040001B1 RID: 433
		public int MaxY;

		// Token: 0x040001B2 RID: 434
		public Dictionary<char, TextCharacter> Characters = new Dictionary<char, TextCharacter>();

		// Token: 0x040001B3 RID: 435
		private static ObjectPool<TextFont> sPool = new ObjectPool<TextFont>(20, 5);
	}
}
