using System;
using RootMotion.FinalIK;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000061 RID: 97
	public interface IEffectorIsLooked
	{
		// Token: 0x0600040B RID: 1035
		bool PuedeTrasladarse(FullBodyBipedEffector fullBodyBipedEffector);

		// Token: 0x0600040C RID: 1036
		bool IsFijaPorAnimacion(FullBodyBipedEffector fullBodyBipedEffector, bool OApoyando = true);
	}
}
