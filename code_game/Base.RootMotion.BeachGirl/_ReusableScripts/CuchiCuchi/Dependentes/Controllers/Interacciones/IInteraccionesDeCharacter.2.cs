using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000DB RID: 219
	public interface IInteraccionesDeCharacter<T_InteraccionPar> : IInteraccionesDeCharacter, IComponentAwakeable where T_InteraccionPar : InteraccionDeCharacter
	{
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000830 RID: 2096
		IReadOnlyList<T_InteraccionPar> interacciones { get; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000831 RID: 2097
		IReadOnlyList<T_InteraccionPar> interaccionesPrimarias { get; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000832 RID: 2098
		IReadOnlyList<T_InteraccionPar> interaccionesSegundarias { get; }

		// Token: 0x06000833 RID: 2099
		bool EsValidaParaCurrentAnimController(T_InteraccionPar interaccionPar);

		// Token: 0x06000834 RID: 2100
		bool TryObtenerSiEsValida(int id, out T_InteraccionPar interaccionDeCharacter);

		// Token: 0x06000835 RID: 2101
		T_InteraccionPar Obtener(int id);
	}
}
