using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos
{
	// Token: 0x020000D2 RID: 210
	[Serializable]
	public sealed class EmailAgencyUnlockedEvento : EmailFromAgenciesRecivedEvento
	{
		// Token: 0x060007C1 RID: 1985 RVA: 0x0002C7A4 File Offset: 0x0002A9A4
		protected override void NoVolatilStared()
		{
			base.NoVolatilStared();
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias", true).FindChildNotNull<IJsonMemoryNode>(this.agencyID).AddData("EsUnlocked", true, true);
		}
	}
}
