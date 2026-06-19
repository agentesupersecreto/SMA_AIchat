using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000548 RID: 1352
	[Serializable]
	public class ParesTipoDeEstimulo : BaseParesInt<ParDeTipoDeEstimulo, TipoDeEstimulo>
	{
		// Token: 0x06002129 RID: 8489 RVA: 0x0000386D File Offset: 0x00001A6D
		public sealed override int GetInt(TipoDeEstimulo tag)
		{
			return (int)tag;
		}
	}
}
