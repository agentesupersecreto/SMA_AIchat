using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x02000532 RID: 1330
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalProfunda<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante> : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalEspecifica<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TMaster : ICalculadorDeEstimuloOnCalculoCallbacksCoitalProfundidad<T_ICalculoDeEstimuloEntrante> where T_ICalculoDeEstimuloResultado : class, IClearable, ICalculoDeEstimuloCoitalHoleProfundaV2, new() where T_ICalculoDeEstimuloEntrante : class, IClearable, ICalculoDeEstimuloCoitalHole, new()
	{
		// Token: 0x060020AE RID: 8366 RVA: 0x0007AA54 File Offset: 0x00078C54
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			TMaster tmaster = base.master;
			tmaster.calculadoDeEstimuloPorProfundidad += new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.Master_calculadoDeEstimuloPorProfundidad);
			tmaster = base.master;
			tmaster.calculadoTotalDeFramePorProfundidad += this.Master_calculadoTotalDeFramePorProfundidad;
		}

		// Token: 0x060020AF RID: 8367 RVA: 0x0007A899 File Offset: 0x00078A99
		private void Master_calculadoTotalDeFramePorProfundidad(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			base.Verificar(generadoNoLimitado);
		}

		// Token: 0x060020B0 RID: 8368 RVA: 0x0007A8A2 File Offset: 0x00078AA2
		private void Master_calculadoDeEstimuloPorProfundidad(T_ICalculoDeEstimuloEntrante calculo, float generado, ICalculadorDeEstimulo sender)
		{
			base.Comparar(calculo, generado);
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x0007AAA8 File Offset: 0x00078CA8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (base.master != null)
			{
				TMaster tmaster = base.master;
				tmaster.calculadoDeEstimuloPorProfundidad -= new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.Master_calculadoDeEstimuloPorProfundidad);
				tmaster = base.master;
				tmaster.calculadoTotalDeFramePorProfundidad -= this.Master_calculadoTotalDeFramePorProfundidad;
			}
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060020B8 RID: 8376 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
