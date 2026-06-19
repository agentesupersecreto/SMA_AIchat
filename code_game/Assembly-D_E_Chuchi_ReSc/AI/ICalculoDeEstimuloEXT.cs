using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E3 RID: 739
	public static class ICalculoDeEstimuloEXT
	{
		// Token: 0x06001073 RID: 4211 RVA: 0x00049924 File Offset: 0x00047B24
		public static bool EsOrgasmo(this ICalculoDeEstimulo calculo)
		{
			return calculo != null && calculo.tipo == TipoDeCalculoDeEstimulo.frame && calculo.emocion.reaccion == ReaccionHumana.placer && (calculo.emocion.currentFrameIsValueAtMax || calculo.causoMaxValue);
		}
	}
}
