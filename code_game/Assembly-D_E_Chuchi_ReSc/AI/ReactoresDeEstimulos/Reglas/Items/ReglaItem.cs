using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003B8 RID: 952
	[Serializable]
	public abstract class ReglaItem : ICheckeadorDeCalculo
	{
		// Token: 0x060014C4 RID: 5316
		public abstract bool Check(ICalculoDeEstimulo calculo);
	}
}
