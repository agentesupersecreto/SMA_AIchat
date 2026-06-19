using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x0200052C RID: 1324
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGenerado<TMaster, T_ICalculoDeEstimulo> : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoBase<TMaster, T_ICalculoDeEstimulo, T_ICalculoDeEstimulo> where TMaster : ICalculadorDeEstimuloOnCalculoCallbacks<T_ICalculoDeEstimulo> where T_ICalculoDeEstimulo : class, IClearable, ICalculoDeEstimuloConEstado, new()
	{
		// Token: 0x0600204D RID: 8269 RVA: 0x0007A400 File Offset: 0x00078600
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			TMaster tmaster = base.master;
			tmaster.preCalculadoDeEstimulo += new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo>(this.M_masterCalculador_preCalculadoDeEstimulo);
			tmaster = base.master;
			tmaster.postCalculadoDeEstimulo += new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo>(this.M_masterCalculador_postCalculadoDeEstimulo);
			tmaster = base.master;
			tmaster.generadoFrame += this.Master_calculadoTotalDeFrame;
		}

		// Token: 0x0600204E RID: 8270 RVA: 0x0007A474 File Offset: 0x00078674
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (base.master != null)
			{
				TMaster tmaster = base.master;
				tmaster.preCalculadoDeEstimulo -= new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo>(this.M_masterCalculador_preCalculadoDeEstimulo);
				tmaster = base.master;
				tmaster.postCalculadoDeEstimulo -= new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimulo>(this.M_masterCalculador_postCalculadoDeEstimulo);
				tmaster = base.master;
				tmaster.generadoFrame -= this.Master_calculadoTotalDeFrame;
			}
		}

		// Token: 0x0600204F RID: 8271 RVA: 0x0007A4F5 File Offset: 0x000786F5
		private void M_masterCalculador_preCalculadoDeEstimulo(T_ICalculoDeEstimulo calculo, float generado, ICalculadorDeEstimulo sender)
		{
			if (this.procesarPreCalculados)
			{
				base.Comparar(calculo, generado);
			}
		}

		// Token: 0x06002050 RID: 8272 RVA: 0x0007A507 File Offset: 0x00078707
		private void M_masterCalculador_postCalculadoDeEstimulo(T_ICalculoDeEstimulo calculo, float generado, ICalculadorDeEstimulo sender)
		{
			if (this.procesarPostCalculados)
			{
				base.Comparar(calculo, generado);
			}
		}

		// Token: 0x06002051 RID: 8273 RVA: 0x0007A519 File Offset: 0x00078719
		private void Master_calculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			base.Verificar(generadoNoLimitado);
		}

		// Token: 0x0400154D RID: 5453
		public bool procesarPreCalculados = true;

		// Token: 0x0400154E RID: 5454
		public bool procesarPostCalculados = true;
	}
}
