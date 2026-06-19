using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Graphics
{
	// Token: 0x0200003D RID: 61
	public class TextCharacter
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000FAEB File Offset: 0x0000DCEB
		public static int Length
		{
			get
			{
				return TextCharacter.sPool.Length;
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000FAF7 File Offset: 0x0000DCF7
		public static TextCharacter Allocate()
		{
			return TextCharacter.sPool.Allocate();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000FB03 File Offset: 0x0000DD03
		public static void Release(TextCharacter rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Character = '\0';
			rInstance.Pixels = null;
			rInstance.Width = 0;
			rInstance.Height = 0;
			TextCharacter.sPool.Release(rInstance);
		}

		// Token: 0x040001A4 RID: 420
		public char Character;

		// Token: 0x040001A5 RID: 421
		public Color[] Pixels;

		// Token: 0x040001A6 RID: 422
		public int Width;

		// Token: 0x040001A7 RID: 423
		public int Height;

		// Token: 0x040001A8 RID: 424
		public int MinX;

		// Token: 0x040001A9 RID: 425
		public int MinY;

		// Token: 0x040001AA RID: 426
		public int Advance;

		// Token: 0x040001AB RID: 427
		private static ObjectPool<TextCharacter> sPool = new ObjectPool<TextCharacter>(20, 5);
	}
}
