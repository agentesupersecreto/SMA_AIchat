using System;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000C8 RID: 200
	public class CharacteresActivos : CharacteresEnScena<CharacteresActivos>, IBuscadorDeCharactersUnicosActivos
	{
		// Token: 0x06000704 RID: 1796 RVA: 0x000147AD File Offset: 0x000129AD
		ICharacterUnico IBuscadorDeCharactersUnicosActivos.TryFind(Guid ID_Unico)
		{
			return base.Obtener(ID_Unico);
		}
	}
}
