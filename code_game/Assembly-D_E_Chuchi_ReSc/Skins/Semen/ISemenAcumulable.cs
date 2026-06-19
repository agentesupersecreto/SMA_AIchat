using System;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Semen
{
	// Token: 0x02000083 RID: 131
	public interface ISemenAcumulable
	{
		// Token: 0x0600033B RID: 827
		void Acumular(IPene from, TipoDeSemen tipo, int cantidad, float particleVolumeInMililiters, Vector3 velocity);

		// Token: 0x0600033C RID: 828
		void AcumularParticleToDestroy(GameObject go, Transform bone1, Transform bone2);

		// Token: 0x0600033D RID: 829
		float? GetParticleVolumenAproxMililiters(TipoDeSemen tipo);

		// Token: 0x0600033E RID: 830
		float MililitrosAcumulados(TipoDeSemen tipo, out float maxMililitros, out float weight);

		// Token: 0x0600033F RID: 831
		float MililitrosAcumuladosTotal(out float maxMililitros, out float weight);
	}
}
