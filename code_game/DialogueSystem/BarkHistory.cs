using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000012 RID: 18
	public class BarkHistory
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00005484 File Offset: 0x00003684
		public BarkHistory(BarkOrder order)
		{
			this.order = order;
			this.index = 0;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000549C File Offset: 0x0000369C
		public int GetNextIndex(int numEntries)
		{
			if (this.order == BarkOrder.Random)
			{
				return Random.Range(0, numEntries);
			}
			int num = this.index % numEntries;
			this.index = (this.index + 1) % numEntries;
			return num;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000054D8 File Offset: 0x000036D8
		public void Reset()
		{
			this.index = 0;
		}

		// Token: 0x0400005F RID: 95
		public BarkOrder order;

		// Token: 0x04000060 RID: 96
		public int index;
	}
}
