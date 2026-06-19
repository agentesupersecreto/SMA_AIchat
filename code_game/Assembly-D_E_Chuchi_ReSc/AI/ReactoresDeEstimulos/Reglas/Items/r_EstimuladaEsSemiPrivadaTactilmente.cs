using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003BE RID: 958
	[Serializable]
	public sealed class r_EstimuladaEsSemiPrivadaTactilmente : ReglaItem
	{
		// Token: 0x060014D0 RID: 5328 RVA: 0x00059138 File Offset: 0x00057338
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).EsSemiPrivadaSocialmenteTactil();
		}
	}
}
