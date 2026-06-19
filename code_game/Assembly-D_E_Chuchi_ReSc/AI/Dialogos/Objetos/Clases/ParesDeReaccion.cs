using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x0200054A RID: 1354
	[Serializable]
	public class ParesDeReaccion : BaseParesInt<ParDeReaccion, ReaccionHumana>
	{
		// Token: 0x0600212D RID: 8493 RVA: 0x0000386D File Offset: 0x00001A6D
		public sealed override int GetInt(ReaccionHumana tag)
		{
			return (int)tag;
		}
	}
}
