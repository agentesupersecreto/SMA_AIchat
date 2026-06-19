using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200002C RID: 44
	public interface IMaleSkins : IHitSkinnedCharacter, ISkinnedCharacter, IComponentStartable, IComponentAwakeable
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060000DA RID: 218
		ModificableDeBool enableHitSkinsOR { get; }

		// Token: 0x060000DB RID: 219
		void ReIgnoreConvexCollisionsAll(bool ignore);
	}
}
