using System;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex
{
	// Token: 0x02000044 RID: 68
	public interface IAutoSexRangesGetter
	{
		// Token: 0x060002EE RID: 750
		bool EsConsentido(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante, out float offsetModTactil, out float offsetModPenetracion);

		// Token: 0x060002EF RID: 751
		bool EsMuyApretado(float anchoDePenetratorGlobal, FemalePenetracionTipo estimulado, ParteQuePuedeEstimular estimulante, out float offsetMod);

		// Token: 0x060002F0 RID: 752
		bool EsMuyApretado(float anchoDePenetratorGlobal, ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante, out float offsetMod);

		// Token: 0x060002F1 RID: 753
		RangeValueV2 GetRangeDeProfuncidadDeAutoSex(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante);

		// Token: 0x060002F2 RID: 754
		RangeValueV2 GetRangeDeVelocidadDeAutoSex(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante);
	}
}
