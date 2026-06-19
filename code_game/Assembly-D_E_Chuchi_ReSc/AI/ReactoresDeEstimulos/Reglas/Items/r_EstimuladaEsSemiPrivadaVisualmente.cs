using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003BF RID: 959
	[Serializable]
	public sealed class r_EstimuladaEsSemiPrivadaVisualmente : ReglaItem
	{
		// Token: 0x060014D2 RID: 5330 RVA: 0x00059164 File Offset: 0x00057364
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).EsSemiPrivadaSocialmenteVisual();
		}
	}
}
