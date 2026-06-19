using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200030D RID: 781
	public interface IPenetrationInformer
	{
		// Token: 0x060010FA RID: 4346
		bool CargarPenetracionAEstimulo(ICharacter penetrando, EstimuloPenetrante resultado);

		// Token: 0x060010FB RID: 4347
		bool CargarPenetracionAEstimuloInvertido(ICharacter penetrando, EstimuloPenetrante resultado, EstimuloPenetrante original, ParteQuePuedeEstimular estimulanteParteOriginal);

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x060010FC RID: 4348
		FemalePenetracionTipo @enum { get; }

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x060010FD RID: 4349
		bool isPenetrated { get; }

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x060010FE RID: 4350
		Penetrador penetradoPor { get; }

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x060010FF RID: 4351
		BoneStretchedChain hole { get; }

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06001100 RID: 4352
		PenetrationInfoLocal estadoActual { get; }

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06001101 RID: 4353
		PenetrationInfoLocal cambiosEnElUltimoFrame { get; }
	}
}
