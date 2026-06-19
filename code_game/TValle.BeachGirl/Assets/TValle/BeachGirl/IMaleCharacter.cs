using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200002B RID: 43
	public interface IMaleCharacter : ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060000D8 RID: 216
		IPene peneDeCharacter { get; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060000D9 RID: 217
		IPene dedoPeneDeCharacter { get; }
	}
}
