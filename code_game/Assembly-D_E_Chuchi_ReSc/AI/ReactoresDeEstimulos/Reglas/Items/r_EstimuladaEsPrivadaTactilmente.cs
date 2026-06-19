using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003BC RID: 956
	[Serializable]
	public sealed class r_EstimuladaEsPrivadaTactilmente : ReglaItem
	{
		// Token: 0x060014CC RID: 5324 RVA: 0x000590E0 File Offset: 0x000572E0
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).EsPrivadaSocialmenteTactil();
		}
	}
}
