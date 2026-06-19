using System;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x0200004C RID: 76
	public interface IPhonemeDelegado
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000151 RID: 337
		Phoneme phoneme { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000152 RID: 338
		// (set) Token: 0x06000153 RID: 339
		float weight { get; set; }
	}
}
