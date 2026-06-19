using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003B9 RID: 953
	[Serializable]
	public sealed class r_AlwaysFalse : ReglaItem
	{
		// Token: 0x060014C6 RID: 5318 RVA: 0x00004252 File Offset: 0x00002452
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			return false;
		}
	}
}
