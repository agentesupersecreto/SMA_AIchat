using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x0200054D RID: 1357
	[Serializable]
	public class ParDePartesHumanas : BaseParInt<ParteDelCuerpoHumano>
	{
		// Token: 0x06002133 RID: 8499 RVA: 0x0007BD7F File Offset: 0x00079F7F
		public sealed override int GetInt()
		{
			return (int)this.flag;
		}
	}
}
