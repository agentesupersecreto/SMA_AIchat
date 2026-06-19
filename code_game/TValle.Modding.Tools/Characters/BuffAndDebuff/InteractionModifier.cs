using System;
using Assets.TValle.Tools.Runtime.UI;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000074 RID: 116
	public enum InteractionModifier
	{
		// Token: 0x04000155 RID: 341
		None,
		// Token: 0x04000156 RID: 342
		damage,
		// Token: 0x04000157 RID: 343
		[Label("gain Interval Expand", Language.en)]
		gainIntervalExpand,
		// Token: 0x04000158 RID: 344
		[Label("gain Interval Position", Language.en)]
		gainMinMaxIntervalPosition,
		// Token: 0x04000159 RID: 345
		[Label("gain Min Interval Position", Language.en)]
		gainMinIntervalPosition,
		// Token: 0x0400015A RID: 346
		[Label("gain Max Interval Position", Language.en)]
		gainMaxIntervalPosition
	}
}
