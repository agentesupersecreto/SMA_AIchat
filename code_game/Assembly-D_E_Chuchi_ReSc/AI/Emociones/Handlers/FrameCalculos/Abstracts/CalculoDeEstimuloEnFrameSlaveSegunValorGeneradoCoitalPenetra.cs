using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x02000531 RID: 1329
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalPenetracion<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante> : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalEspecifica<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TMaster : ICalculadorDeEstimuloOnCalculoCallbacksCoitalPenetracion<T_ICalculoDeEstimuloEntrante> where T_ICalculoDeEstimuloResultado : class, IClearable, ICalculoDeEstimuloCoitalHoleSimple, new() where T_ICalculoDeEstimuloEntrante : class, IClearable, ICalculoDeEstimuloCoitalHole, new()
	{
		// Token: 0x060020A3 RID: 8355 RVA: 0x0007A99C File Offset: 0x00078B9C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			TMaster tmaster = base.master;
			tmaster.calculadoDeEstimuloPorPenetracion += new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.Master_calculadoDeEstimuloPor);
			tmaster = base.master;
			tmaster.calculadoTotalDeFramePorPenetracion += this.Master_calculadoTotalDeFramePor;
		}

		// Token: 0x060020A4 RID: 8356 RVA: 0x0007A899 File Offset: 0x00078A99
		private void Master_calculadoTotalDeFramePor(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			base.Verificar(generadoNoLimitado);
		}

		// Token: 0x060020A5 RID: 8357 RVA: 0x0007A8A2 File Offset: 0x00078AA2
		private void Master_calculadoDeEstimuloPor(T_ICalculoDeEstimuloEntrante calculo, float generado, ICalculadorDeEstimulo sender)
		{
			base.Comparar(calculo, generado);
		}

		// Token: 0x060020A6 RID: 8358 RVA: 0x0007A9F0 File Offset: 0x00078BF0
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (base.master != null)
			{
				TMaster tmaster = base.master;
				tmaster.calculadoDeEstimuloPorPenetracion -= new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.Master_calculadoDeEstimuloPor);
				tmaster = base.master;
				tmaster.calculadoTotalDeFramePorPenetracion -= this.Master_calculadoTotalDeFramePor;
			}
		}

		// Token: 0x060020A8 RID: 8360 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x060020AA RID: 8362 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060020AB RID: 8363 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060020AD RID: 8365 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
