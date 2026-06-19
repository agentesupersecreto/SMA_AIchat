using System;

namespace Assets
{
	// Token: 0x020000B5 RID: 181
	public interface IBuscadorDeCharactersUnicosActivos
	{
		// Token: 0x06000541 RID: 1345
		ICharacterUnico TryFind(Guid ID_Unico);
	}
}
