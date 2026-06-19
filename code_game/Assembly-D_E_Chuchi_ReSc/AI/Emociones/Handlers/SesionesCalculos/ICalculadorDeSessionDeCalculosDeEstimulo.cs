using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A6 RID: 1190
	public interface ICalculadorDeSessionDeCalculosDeEstimulo<TEstimulo> : ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TEstimulo : InteracionEstimulanteBasica
	{
		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06001C28 RID: 7208
		ICalculoDeEstimulo<TEstimulo> calculoDeEstimulo { get; }
	}
}
