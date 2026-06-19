using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003BD RID: 957
	[Serializable]
	public sealed class r_EstimuladaEsPrivadaVisualmente : ReglaItem
	{
		// Token: 0x060014CE RID: 5326 RVA: 0x0005910C File Offset: 0x0005730C
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor).EsPrivadaSocialmenteVisual();
		}
	}
}
