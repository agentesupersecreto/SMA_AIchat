using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002AA RID: 682
	public interface IReproductorDeSonidoDeToques : IReproductorDeSonidos
	{
		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06000F3D RID: 3901
		// (remove) Token: 0x06000F3E RID: 3902
		event RegistrandoDeToqueDeSonidoHandler registrandoToque;

		// Token: 0x06000F3F RID: 3903
		void Init(IEstimulablePorToques target);

		// Token: 0x06000F40 RID: 3904
		void Init(IReadOnlyList<IEstimulablePorToques> targets);
	}
}
