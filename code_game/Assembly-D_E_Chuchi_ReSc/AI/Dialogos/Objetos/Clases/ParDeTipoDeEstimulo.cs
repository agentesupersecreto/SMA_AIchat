using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x0200054F RID: 1359
	[Serializable]
	public class ParDeTipoDeEstimulo : BaseParInt<TipoDeEstimulo>
	{
		// Token: 0x06002137 RID: 8503 RVA: 0x0007BD9F File Offset: 0x00079F9F
		public sealed override int GetInt()
		{
			return (int)this.flag;
		}
	}
}
