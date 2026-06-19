using System;
using com.ootii.Graphics.UI;

namespace com.ootii.Game
{
	// Token: 0x0200005E RID: 94
	public class TargetingReticle : Reticle
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001A187 File Offset: 0x00018387
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x0001A18E File Offset: 0x0001838E
		public new static IReticle Instance
		{
			get
			{
				return Reticle.Instance;
			}
			set
			{
				Reticle.Instance = value;
			}
		}
	}
}
