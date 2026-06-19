using System;
using Assets.TValle.Tools.Runtime.UI;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200005C RID: 92
	public enum DisplayableBuffCategory
	{
		// Token: 0x040000F6 RID: 246
		None,
		// Token: 0x040000F7 RID: 247
		[Label("Relationship Growth", Language.en)]
		favorability,
		// Token: 0x040000F8 RID: 248
		[Label("Satisfaction Progress", Language.en)]
		pleasure,
		// Token: 0x040000F9 RID: 249
		[Label("Drive Development", Language.en)]
		desires,
		// Token: 0x040000FA RID: 250
		[Label("Anger Management Evolution", Language.en)]
		rage,
		// Token: 0x040000FB RID: 251
		[Label("Pain Endurance Building", Language.en)]
		pain,
		// Token: 0x040000FC RID: 252
		[Label("Trust Level Progress", Language.en)]
		fear,
		// Token: 0x040000FD RID: 253
		[Label("Motivation Progress", Language.en)]
		decep,
		// Token: 0x040000FE RID: 254
		[Label("Additional Development", Language.en)]
		other
	}
}
