using System;

namespace Assets
{
	// Token: 0x020000AD RID: 173
	public interface ICharacterGestuable
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000510 RID: 1296
		ModificableDeBool bocaSelladaOverrideOR { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000511 RID: 1297
		ModificableDeBool bocaAbiertaOverrideOR { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000512 RID: 1298
		CharacterEstadoDeBoca estadoDeBocaPorUser { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000513 RID: 1299
		CharacterEstadoDeBoca estadoDeBocaReal { get; }
	}
}
