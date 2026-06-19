using System;

namespace Assets
{
	// Token: 0x020000B0 RID: 176
	public interface ICharacterUnico : ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600051A RID: 1306
		Guid ID_Unico { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600051B RID: 1307
		string ID_UnicoString { get; }
	}
}
