using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A4 RID: 1188
	[Obsolete("", true)]
	public interface ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable> : ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where T_TipoDeEstimuloEnumerable : struct
	{
		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x06001C25 RID: 7205
		T_TipoDeEstimuloEnumerable tipoDeEstimuloEnumerable { get; }
	}
}
