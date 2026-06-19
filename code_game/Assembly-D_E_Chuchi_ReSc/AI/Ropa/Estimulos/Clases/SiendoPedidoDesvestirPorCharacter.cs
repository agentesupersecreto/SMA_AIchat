using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos.Clases
{
	// Token: 0x0200038E RID: 910
	public sealed class SiendoPedidoDesvestirPorCharacter : SiendoDesvestido<EstimulosPorQuitarPrendasDeRopa>
	{
		// Token: 0x060013DC RID: 5084 RVA: 0x00056441 File Offset: 0x00054641
		public SiendoPedidoDesvestirPorCharacter(EstimulosPorQuitarPrendasDeRopa estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x0005644B File Offset: 0x0005464B
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.peticionDesvestidura;
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x0005644F File Offset: 0x0005464F
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaComunicarse;
		}
	}
}
