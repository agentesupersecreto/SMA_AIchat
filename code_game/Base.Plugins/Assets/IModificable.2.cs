using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000F5 RID: 245
	public interface IModificable<T_Mod, T_Val> : IModificable where T_Mod : IValuable<T_Val> where T_Val : struct, IValorModificable<T_Val>
	{
		// Token: 0x060006CB RID: 1739
		bool TryAddModificador(T_Mod mod);

		// Token: 0x060006CC RID: 1740
		T_Mod AddModificador(string id);

		// Token: 0x060006CD RID: 1741
		T_Mod AddModificador(int id);

		// Token: 0x060006CE RID: 1742
		T_Mod ObtenerModificadorNotNull(string id);

		// Token: 0x060006CF RID: 1743
		T_Mod ObtenerModificadorNotNull(Object ObjID);

		// Token: 0x060006D0 RID: 1744
		void LoadModificador(ref T_Mod mod, Object ObjID);

		// Token: 0x060006D1 RID: 1745
		void RemoverModificador(string id);

		// Token: 0x060006D2 RID: 1746
		void RemoverModificador(Object ObjID);

		// Token: 0x060006D3 RID: 1747
		bool TryRemoverModificador(T_Mod mod);

		// Token: 0x060006D4 RID: 1748
		bool TryRemoverModificadorAndSetNull(ref T_Mod mod);

		// Token: 0x060006D5 RID: 1749
		void ModificarValor(ref T_Val valor);

		// Token: 0x060006D6 RID: 1750
		bool Contiene(T_Mod mod);

		// Token: 0x060006D7 RID: 1751
		T_Val? TryObtenerMaximoValor();

		// Token: 0x060006D8 RID: 1752
		T_Val? TryObtenerMinimoValor();

		// Token: 0x060006D9 RID: 1753
		T_Val? TryObtenerMaximoValorAbsoluto();

		// Token: 0x060006DA RID: 1754
		T_Val? TryObtenerModificador();

		// Token: 0x060006DB RID: 1755
		T_Val? TryObtenerPromedio();

		// Token: 0x060006DC RID: 1756
		void MaximoValorIncluyendo(ref T_Val valor);

		// Token: 0x060006DD RID: 1757
		void PromediarConValor(ref T_Val valor);

		// Token: 0x060006DE RID: 1758
		void MinimoValorIncluyendo(ref T_Val valor);

		// Token: 0x060006DF RID: 1759
		void MaximoValorAbsolutoIncluyendo(ref T_Val valor);
	}
}
