using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000549 RID: 1353
	[Serializable]
	public class ParesDireccionDeEstimulo : BaseParesInt<ParDeDirrecionDeEstimulo, DireccionDeEstimulo>
	{
		// Token: 0x0600212B RID: 8491 RVA: 0x0000386D File Offset: 0x00001A6D
		public sealed override int GetInt(DireccionDeEstimulo tag)
		{
			return (int)tag;
		}
	}
}
