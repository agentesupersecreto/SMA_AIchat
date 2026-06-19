using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002DA RID: 730
	public interface ICalculadorDeEstimulo<TCalculo> : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculo : ICalculoDeEstimulo, IClearable
	{
		// Token: 0x0600105C RID: 4188
		bool TryInstantiateCalculo(out TCalculo calculo);

		// Token: 0x0600105D RID: 4189
		TCalculo GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index);

		// Token: 0x0600105E RID: 4190
		TCalculo GetCalculoEnFrame(int index);

		// Token: 0x0600105F RID: 4191
		[Obsolete("", true)]
		void GetCalculosDelMasFuerteAlMasDebil(IList<TCalculo> resultado);

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06001060 RID: 4192
		[Obsolete("", true)]
		TCalculo calculoMasFuerte { get; }
	}
}
