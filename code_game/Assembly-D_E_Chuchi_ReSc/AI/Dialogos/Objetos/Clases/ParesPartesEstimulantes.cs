using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000546 RID: 1350
	[Serializable]
	public class ParesPartesEstimulantes : BaseParesInt<ParDePartesEstimulantes, ParteQuePuedeEstimular>
	{
		// Token: 0x06002125 RID: 8485 RVA: 0x0000386D File Offset: 0x00001A6D
		public override int GetInt(ParteQuePuedeEstimular tag)
		{
			return (int)tag;
		}
	}
}
