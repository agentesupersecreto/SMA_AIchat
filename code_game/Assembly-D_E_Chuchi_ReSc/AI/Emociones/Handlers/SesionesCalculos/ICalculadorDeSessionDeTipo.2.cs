using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A5 RID: 1189
	public interface ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> : ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where T_TipoDeEstimuloEnumerable : struct where T_DireccionDeEstimuloEnumerable : struct
	{
		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06001C26 RID: 7206
		T_TipoDeEstimuloEnumerable tipoDeEstimuloEnumerableV2 { get; }

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06001C27 RID: 7207
		T_DireccionDeEstimuloEnumerable direccionDeEstimuloEnumerableV2 { get; }
	}
}
