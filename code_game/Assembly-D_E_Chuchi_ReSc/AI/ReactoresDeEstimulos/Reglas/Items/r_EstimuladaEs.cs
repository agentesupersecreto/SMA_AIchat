using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003BB RID: 955
	[Serializable]
	public sealed class r_EstimuladaEs : ReglaItem
	{
		// Token: 0x060014CA RID: 5322 RVA: 0x000590B0 File Offset: 0x000572B0
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor) == this.parte;
		}

		// Token: 0x040010F0 RID: 4336
		public PrioridadDeParteDelCuerpoHumanoContexto contexto;

		// Token: 0x040010F1 RID: 4337
		public ParteDelCuerpoHumano parte;
	}
}
