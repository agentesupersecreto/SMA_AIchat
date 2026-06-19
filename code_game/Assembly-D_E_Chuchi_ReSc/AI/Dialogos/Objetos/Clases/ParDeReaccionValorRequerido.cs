using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000551 RID: 1361
	[Serializable]
	public class ParDeReaccionValorRequerido : BaseParIntMayorOMenor<ReaccionHumana>
	{
		// Token: 0x0600213B RID: 8507 RVA: 0x0007BDAF File Offset: 0x00079FAF
		public sealed override int GetInt()
		{
			return (int)this.flag;
		}
	}
}
