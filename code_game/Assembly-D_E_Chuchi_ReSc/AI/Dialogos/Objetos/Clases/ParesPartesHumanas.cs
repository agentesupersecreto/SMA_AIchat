using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000547 RID: 1351
	[Serializable]
	public class ParesPartesHumanas : BaseParesInt<ParDePartesHumanas, ParteDelCuerpoHumano>
	{
		// Token: 0x06002127 RID: 8487 RVA: 0x0000386D File Offset: 0x00001A6D
		public sealed override int GetInt(ParteDelCuerpoHumano tag)
		{
			return (int)tag;
		}
	}
}
