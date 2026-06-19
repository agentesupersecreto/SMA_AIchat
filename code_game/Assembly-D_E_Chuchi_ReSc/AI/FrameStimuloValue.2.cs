using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000329 RID: 809
	[Obsolete]
	[Serializable]
	public abstract class FrameStimuloValue<TmaxEnum> : FrameStimuloValue<TmaxEnum, EstimuloTactilData>
	{
		// Token: 0x0600117B RID: 4475
		public abstract TmaxEnum GetMaxEnum();

		// Token: 0x0600117C RID: 4476
		public abstract void AcumularSession(Emocion.SessionDeEstimulo session);

		// Token: 0x0600117D RID: 4477 RVA: 0x0004B45C File Offset: 0x0004965C
		protected void AcumularSessionDeTipo(ref EstimuloTactilData estimulo, Emocion.SessionDeEstimulo session)
		{
			if (estimulo.estimulo > 0f && ((int)session.tipos).HasFlag((int)estimulo.tipo))
			{
				PartesHumanasParaAi maxEstimuloParte = this.GetMaxEstimuloParte();
				session.Acumular(estimulo.estimulo, maxEstimuloParte);
			}
		}

		// Token: 0x0600117E RID: 4478
		public abstract PartesHumanasParaAi GetMaxEstimuloParte();
	}
}
