using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x0200054C RID: 1356
	[Serializable]
	public class ParDePartesEstimulantes : BaseParInt<ParteQuePuedeEstimular>
	{
		// Token: 0x06002131 RID: 8497 RVA: 0x0007BD6F File Offset: 0x00079F6F
		public sealed override int GetInt()
		{
			return (int)this.flag;
		}
	}
}
