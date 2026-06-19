using System;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000007 RID: 7
	public interface IDiscursosDePersonalidad
	{
		// Token: 0x0600001E RID: 30
		string ObtenerValorMaximo(ReaccionHumana reacc);

		// Token: 0x0600001F RID: 31
		string ObtenerCercaDelValorMaximo(ReaccionHumana reacc);

		// Token: 0x06000020 RID: 32
		string Obtener(ReaccionHumana reacc, float nivel);

		// Token: 0x06000021 RID: 33
		[Obsolete]
		string Obtener(ReaccionHumana reacc, EstimuloTipo tipo1, EstimuloTipo2 tipo2, PartesHumanasParaAi parte);

		// Token: 0x06000022 RID: 34
		string ObtenerEnSpot(ReaccionHumana reacc, float nivel);

		// Token: 0x06000023 RID: 35
		[Obsolete]
		bool Contiene(ReaccionHumana reacc, EstimuloTipo tipo1, EstimuloTipo2 tipo2, PartesHumanasParaAi parte);
	}
}
