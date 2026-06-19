using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A3 RID: 1187
	public interface ICalculadorDeSession : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06001C23 RID: 7203
		bool enSession { get; }

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x06001C24 RID: 7204
		float duracion { get; }
	}
}
