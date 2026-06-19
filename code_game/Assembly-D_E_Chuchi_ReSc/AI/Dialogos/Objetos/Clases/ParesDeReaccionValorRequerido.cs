using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x0200054B RID: 1355
	[Serializable]
	public class ParesDeReaccionValorRequerido : BaseParesInt<ParDeReaccionValorRequerido, ReaccionHumana>
	{
		// Token: 0x0600212F RID: 8495 RVA: 0x0000386D File Offset: 0x00001A6D
		public sealed override int GetInt(ReaccionHumana tag)
		{
			return (int)tag;
		}
	}
}
