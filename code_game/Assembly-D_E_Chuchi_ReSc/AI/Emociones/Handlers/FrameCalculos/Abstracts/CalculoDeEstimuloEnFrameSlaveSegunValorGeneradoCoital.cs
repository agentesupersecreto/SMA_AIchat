using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x0200052E RID: 1326
	[Obsolete("Hacer igual q profundidad", true)]
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoital<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante> : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoBase<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TMaster : ICalculadorDeEstimuloOnCalculoCallbacksCoitales<T_ICalculoDeEstimuloEntrante> where T_ICalculoDeEstimuloResultado : class, IClearable, ICalculoDeEstimuloCoitalHoleSimple, new() where T_ICalculoDeEstimuloEntrante : class, IClearable, ICalculoDeEstimuloCoitalHole, new()
	{
		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x06002077 RID: 8311 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.coital;
			}
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x06002078 RID: 8312 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.calculoMasFuerte
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002079 RID: 8313 RVA: 0x0007A7E4 File Offset: 0x000789E4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			TMaster tmaster = base.master;
			tmaster.calculadoDeEstimulo += new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.M_masterCalculador_calculadoDeEstimulo);
			tmaster = base.master;
			tmaster.generadoFrame += this.Master_calculadoTotalDeFrame;
		}

		// Token: 0x0600207A RID: 8314 RVA: 0x0007A838 File Offset: 0x00078A38
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (base.master != null)
			{
				TMaster tmaster = base.master;
				tmaster.calculadoDeEstimulo -= new CalculadorOnCalculadoCallbacksHandler<T_ICalculoDeEstimuloEntrante>(this.M_masterCalculador_calculadoDeEstimulo);
				tmaster = base.master;
				tmaster.generadoFrame -= this.Master_calculadoTotalDeFrame;
			}
		}

		// Token: 0x0600207B RID: 8315 RVA: 0x0007A899 File Offset: 0x00078A99
		private void Master_calculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			base.Verificar(generadoNoLimitado);
		}

		// Token: 0x0600207C RID: 8316 RVA: 0x0007A8A2 File Offset: 0x00078AA2
		private void M_masterCalculador_calculadoDeEstimulo(T_ICalculoDeEstimuloEntrante calculo, float generado, ICalculadorDeEstimulo sender)
		{
			base.Comparar(calculo, generado);
		}

		// Token: 0x0600207D RID: 8317 RVA: 0x0007A899 File Offset: 0x00078A99
		private void M_masterCalculador_calculadoTotalDeFrame(float generadoTotal, ICalculadorDeEstimulo sender)
		{
			base.Verificar(generadoTotal);
		}

		// Token: 0x0600207E RID: 8318
		[Obsolete("", true)]
		public abstract ICalculoDeEstimuloCoital GetCalculos();

		// Token: 0x0600207F RID: 8319
		public abstract bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHole calculo);

		// Token: 0x06002080 RID: 8320 RVA: 0x0007A8AC File Offset: 0x00078AAC
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return (ICalculoDeEstimuloCoitalHole)((object)base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index));
		}

		// Token: 0x06002081 RID: 8321 RVA: 0x0007A8BF File Offset: 0x00078ABF
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.GetCalculoEnFrame(int index)
		{
			return (ICalculoDeEstimuloCoitalHole)((object)base.GetCalculoEnFrame(index));
		}

		// Token: 0x06002082 RID: 8322
		[Obsolete("", true)]
		public abstract void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloCoitalHole> resultado);

		// Token: 0x06002084 RID: 8324 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06002085 RID: 8325 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06002086 RID: 8326 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06002087 RID: 8327 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06002088 RID: 8328 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06002089 RID: 8329 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
