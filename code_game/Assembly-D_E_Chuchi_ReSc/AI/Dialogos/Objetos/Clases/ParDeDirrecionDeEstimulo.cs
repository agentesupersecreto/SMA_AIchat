using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x0200054E RID: 1358
	[Serializable]
	public class ParDeDirrecionDeEstimulo : BaseParInt<DireccionDeEstimulo>
	{
		// Token: 0x06002135 RID: 8501 RVA: 0x0007BD8F File Offset: 0x00079F8F
		public sealed override int GetInt()
		{
			return (int)this.flag;
		}
	}
}
