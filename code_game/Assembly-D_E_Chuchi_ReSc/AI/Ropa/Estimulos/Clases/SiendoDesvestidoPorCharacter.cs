using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos.Clases
{
	// Token: 0x0200038D RID: 909
	public sealed class SiendoDesvestidoPorCharacter : SiendoDesvestido<ConjuntoDeRopaLoader>
	{
		// Token: 0x060013D9 RID: 5081 RVA: 0x0005642F File Offset: 0x0005462F
		public SiendoDesvestidoPorCharacter(ConjuntoDeRopaLoader estimulado, IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado)
			: base(estimulado, PrioridadesDeObjetoEstimulado)
		{
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x0004408B File Offset: 0x0004228B
		protected override TipoDeEstimulo ObtenerEstimulo(Character estimulante)
		{
			return TipoDeEstimulo.desvestidura;
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x00056439 File Offset: 0x00054639
		protected override Transform ObtenerTransformEstimulante(Character estimulante)
		{
			return estimulante.trasnformParaManipular;
		}
	}
}
