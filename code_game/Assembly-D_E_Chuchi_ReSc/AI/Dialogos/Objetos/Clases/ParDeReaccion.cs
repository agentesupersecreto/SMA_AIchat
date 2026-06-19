using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000550 RID: 1360
	[Serializable]
	public class ParDeReaccion : BaseParInt<ReaccionHumana>
	{
		// Token: 0x06002139 RID: 8505 RVA: 0x0007BDAF File Offset: 0x00079FAF
		public sealed override int GetInt()
		{
			return (int)this.flag;
		}
	}
}
