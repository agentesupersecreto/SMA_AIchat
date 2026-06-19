using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002CB RID: 715
	[Serializable]
	public class AutoSize
	{
		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x06001D73 RID: 7539 RVA: 0x00038F10 File Offset: 0x00037110
		public bool IsEnabled
		{
			get
			{
				return this.autoSizeWidth || this.autoSizeHeight;
			}
		}

		// Token: 0x040010EE RID: 4334
		public bool autoSizeWidth;

		// Token: 0x040010EF RID: 4335
		public bool autoSizeHeight;

		// Token: 0x040010F0 RID: 4336
		public ScaledValue maxWidth = new ScaledValue(ScaledValue.max);

		// Token: 0x040010F1 RID: 4337
		public ScaledValue maxHeight = new ScaledValue(ScaledValue.max);

		// Token: 0x040010F2 RID: 4338
		public RectOffset padding;
	}
}
