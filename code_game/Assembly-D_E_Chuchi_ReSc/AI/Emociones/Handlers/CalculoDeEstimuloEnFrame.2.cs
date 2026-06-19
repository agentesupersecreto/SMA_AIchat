using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200047A RID: 1146
	public abstract class CalculoDeEstimuloEnFrame<TConfig> : CalculoDeEstimuloEnFrame where TConfig : new()
	{
		// Token: 0x0400131A RID: 4890
		public TConfig config = new TConfig();
	}
}
