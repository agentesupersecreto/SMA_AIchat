using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x0200052F RID: 1327
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalAnchura<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante> : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalEspecifica<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TMaster : ICalculadorDeEstimuloOnCalculoCallbacksCoitalAnchura<T_ICalculoDeEstimuloEntrante> where T_ICalculoDeEstimuloResultado : class, IClearable, ICalculoDeEstimuloCoitalHoleSimple, new() where T_ICalculoDeEstimuloEntrante : class, IClearable, ICalculoDeEstimuloCoitalHole, new()
	{
		// Token: 0x0600208A RID: 8330 RVA: 0x0007A8DC File Offset: 0x00078ADC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			TMaster tmaster = base.master;
			tmaster.calculadoDeEstimuloPorAnchura += new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.Master_calculadoDeEstimuloPor);
			tmaster = base.master;
			tmaster.calculadoTotalDeFramePorAnchura += this.Master_calculadoTotalDeFramePor;
		}

		// Token: 0x0600208B RID: 8331 RVA: 0x0007A899 File Offset: 0x00078A99
		private void Master_calculadoTotalDeFramePor(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			base.Verificar(generadoNoLimitado);
		}

		// Token: 0x0600208C RID: 8332 RVA: 0x0007A8A2 File Offset: 0x00078AA2
		private void Master_calculadoDeEstimuloPor(T_ICalculoDeEstimuloEntrante calculo, float generado, ICalculadorDeEstimulo sender)
		{
			base.Comparar(calculo, generado);
		}

		// Token: 0x0600208D RID: 8333 RVA: 0x0007A930 File Offset: 0x00078B30
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (base.master != null)
			{
				TMaster tmaster = base.master;
				tmaster.calculadoDeEstimuloPorAnchura -= new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.Master_calculadoDeEstimuloPor);
				tmaster = base.master;
				tmaster.calculadoTotalDeFramePorAnchura -= this.Master_calculadoTotalDeFramePor;
			}
		}

		// Token: 0x0600208F RID: 8335 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06002090 RID: 8336 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06002091 RID: 8337 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06002092 RID: 8338 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06002093 RID: 8339 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06002094 RID: 8340 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
