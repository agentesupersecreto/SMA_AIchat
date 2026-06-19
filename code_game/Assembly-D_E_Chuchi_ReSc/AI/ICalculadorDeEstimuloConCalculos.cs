using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D0 RID: 720
	public interface ICalculadorDeEstimuloConCalculos : ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001033 RID: 4147
		[Obsolete("", true)]
		bool estimuloExisteEnFrame { get; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001034 RID: 4148
		[Obsolete("", true)]
		ICalculoDeEstimulo calculoMasFuerteBase { get; }

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001035 RID: 4149
		int cantidadDeCalculoConEstimulosEnFrameMasFuerteAMasDebil { get; }

		// Token: 0x06001036 RID: 4150
		ICalculoDeEstimulo GetCalculoConEstimulosEnFrameMasFuerteAMasDebilBase(int index);

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06001037 RID: 4151
		int cantidadDeCalculosEnFrame { get; }

		// Token: 0x06001038 RID: 4152
		ICalculoDeEstimulo GetCalculoEnFrameBase(int index);

		// Token: 0x06001039 RID: 4153
		bool TryInstantiateCalculoBase(out ICalculoDeEstimulo calculo);
	}
}
