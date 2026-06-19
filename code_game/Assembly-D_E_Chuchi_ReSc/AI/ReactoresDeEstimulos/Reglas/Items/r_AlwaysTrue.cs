using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003BA RID: 954
	[Serializable]
	public sealed class r_AlwaysTrue : ReglaItem
	{
		// Token: 0x060014C8 RID: 5320 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			return true;
		}
	}
}
