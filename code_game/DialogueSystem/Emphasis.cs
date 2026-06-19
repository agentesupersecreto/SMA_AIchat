using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200021D RID: 541
	public struct Emphasis
	{
		// Token: 0x06001877 RID: 6263 RVA: 0x0002311C File Offset: 0x0002131C
		public Emphasis(int startIndex, int length, Color color, bool bold, bool italic, bool underline)
		{
			this.startIndex = startIndex;
			this.length = length;
			this.color = color;
			this.bold = bold;
			this.italic = italic;
			this.underline = underline;
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06001878 RID: 6264 RVA: 0x00023158 File Offset: 0x00021358
		// (set) Token: 0x06001879 RID: 6265 RVA: 0x00023160 File Offset: 0x00021360
		public int startIndex { get; set; }

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x0002316C File Offset: 0x0002136C
		// (set) Token: 0x0600187B RID: 6267 RVA: 0x00023174 File Offset: 0x00021374
		public int length { get; set; }

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x0600187C RID: 6268 RVA: 0x00023180 File Offset: 0x00021380
		// (set) Token: 0x0600187D RID: 6269 RVA: 0x00023188 File Offset: 0x00021388
		public Color color { get; set; }

		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x0600187E RID: 6270 RVA: 0x00023194 File Offset: 0x00021394
		// (set) Token: 0x0600187F RID: 6271 RVA: 0x0002319C File Offset: 0x0002139C
		public bool bold { get; set; }

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06001880 RID: 6272 RVA: 0x000231A8 File Offset: 0x000213A8
		// (set) Token: 0x06001881 RID: 6273 RVA: 0x000231B0 File Offset: 0x000213B0
		public bool italic { get; set; }

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06001882 RID: 6274 RVA: 0x000231BC File Offset: 0x000213BC
		// (set) Token: 0x06001883 RID: 6275 RVA: 0x000231C4 File Offset: 0x000213C4
		public bool underline { get; set; }
	}
}
