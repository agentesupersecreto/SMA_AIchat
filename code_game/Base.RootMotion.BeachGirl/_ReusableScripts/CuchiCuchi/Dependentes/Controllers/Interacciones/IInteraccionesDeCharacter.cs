using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000DA RID: 218
	public interface IInteraccionesDeCharacter : IComponentAwakeable
	{
		// Token: 0x14000072 RID: 114
		// (add) Token: 0x0600081B RID: 2075
		// (remove) Token: 0x0600081C RID: 2076
		event Action<InteraccionDeCharacter> comenzada;

		// Token: 0x14000073 RID: 115
		// (add) Token: 0x0600081D RID: 2077
		// (remove) Token: 0x0600081E RID: 2078
		event Action<InteraccionDeCharacter> terminada;

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600081F RID: 2079
		IReadOnlyList<InteraccionDeCharacter> interaccionesBases { get; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000820 RID: 2080
		IReadOnlyList<InteraccionDeCharacter> interaccionesPrimariasBases { get; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000821 RID: 2081
		IReadOnlyList<InteraccionDeCharacter> interaccionesSegundariasBases { get; }

		// Token: 0x06000822 RID: 2082
		[Obsolete("", true)]
		InteraccionDeCharacter ObtenerEjecutandosePrimaria();

		// Token: 0x06000823 RID: 2083
		void ObtenerEjecutandosePrimaria(IList<InteraccionDeCharacter> result);

		// Token: 0x06000824 RID: 2084
		InteraccionDeCharacter ObtenerFirstEjecutandosePrimaria();

		// Token: 0x06000825 RID: 2085
		Transform GetRootDeLayer(int layer);

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000826 RID: 2086
		ICharacter character { get; }

		// Token: 0x06000827 RID: 2087
		bool EstaEjecutandose(int id);

		// Token: 0x06000828 RID: 2088
		bool TryAddInteraction(int id, Interaccion interaccion);

		// Token: 0x06000829 RID: 2089
		bool TryRemoveInteraction(int id);

		// Token: 0x0600082A RID: 2090
		bool TryObtenerSiEsValida(int id, out Interaccion interaccion);

		// Token: 0x0600082B RID: 2091
		bool ContieneAndIsValido(int id);

		// Token: 0x0600082C RID: 2092
		bool Contiene(int id);

		// Token: 0x0600082D RID: 2093
		InteraccionDeCharacter ObtenerBase(int id);

		// Token: 0x0600082E RID: 2094
		bool EsValidaParaCurrentAnimControllerBase(InteraccionDeCharacter interaccionPar);

		// Token: 0x0600082F RID: 2095
		void GetEjecutandose(int layer, IList<InteraccionDeCharacter> ejecutandose);
	}
}
