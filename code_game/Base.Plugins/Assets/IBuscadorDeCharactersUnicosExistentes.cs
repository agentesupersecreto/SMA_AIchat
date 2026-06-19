using System;

namespace Assets
{
	// Token: 0x020000B6 RID: 182
	public interface IBuscadorDeCharactersUnicosExistentes
	{
		// Token: 0x06000542 RID: 1346
		ICharacterUnico TryFind(Guid ID_Unico);
	}
}
