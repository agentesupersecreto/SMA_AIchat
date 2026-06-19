using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000545 RID: 1349
	[Serializable]
	public class TipoDeCalculoYTipoDeCalculador
	{
		// Token: 0x04001585 RID: 5509
		public TipoDeCalculadorDeEstimulo calculador = (TipoDeCalculadorDeEstimulo)typeof(TipoDeCalculadorDeEstimulo).AllEnumFlagsValue();

		// Token: 0x04001586 RID: 5510
		public TipoDeCalculoDeEstimulo calculo = (TipoDeCalculoDeEstimulo)typeof(TipoDeCalculoDeEstimulo).AllEnumFlagsValue();
	}
}
