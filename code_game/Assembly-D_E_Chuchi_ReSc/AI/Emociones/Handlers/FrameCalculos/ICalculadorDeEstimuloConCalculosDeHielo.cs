using System;
using System.Runtime.CompilerServices;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200050E RID: 1294
	public interface ICalculadorDeEstimuloConCalculosDeHielo : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x06001F56 RID: 8022
		float GetLastValue(ICalculoDeInteracionEstimulanteConEstado calculo, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] out ValueTuple<int, int, int, int> key);
	}
}
