using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x0200029C RID: 668
	[Obsolete]
	public interface IInteraccionEstimulante
	{
		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000EAE RID: 3758
		TipoDeEstimulo tipoDeEstimulo { get; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000EAF RID: 3759
		ParteDelCuerpoHumano partePrincipalEstimulada { get; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000EB0 RID: 3760
		List<ParteDelCuerpoHumano> todasLasPartesEstimuladas { get; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000EB1 RID: 3761
		Side side { get; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000EB2 RID: 3762
		MonoBehaviour estimulante { get; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000EB3 RID: 3763
		MonoBehaviour estimulado { get; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000EB4 RID: 3764
		Transform transformEstimulante { get; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000EB5 RID: 3765
		Transform transformEstimulado { get; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000EB6 RID: 3766
		Vector3? posicionGlobalDelEstimulo { get; }

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000EB7 RID: 3767
		Vector3? normalGlobalDelEstimulo { get; }
	}
}
