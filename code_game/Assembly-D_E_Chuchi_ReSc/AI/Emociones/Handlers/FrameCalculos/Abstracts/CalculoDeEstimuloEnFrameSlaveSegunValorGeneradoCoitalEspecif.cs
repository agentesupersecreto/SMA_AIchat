using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Abstracts
{
	// Token: 0x02000530 RID: 1328
	public abstract class CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoCoitalEspecifica<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante> : CalculoDeEstimuloEnFrameSlaveSegunValorGeneradoBase<TMaster, T_ICalculoDeEstimuloResultado, T_ICalculoDeEstimuloEntrante>, ICalculadorDeEstimuloCoital, ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TMaster : ICalculadorDeEstimulo where T_ICalculoDeEstimuloResultado : class, IClearable, ICalculoDeEstimuloCoitalHoleSimple, new() where T_ICalculoDeEstimuloEntrante : class, IClearable, ICalculoDeEstimuloCoitalHole, new()
	{
		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x06002095 RID: 8341 RVA: 0x0003AB0E File Offset: 0x00038D0E
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.coital;
			}
		}

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x06002096 RID: 8342 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("", true)]
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.calculoMasFuerte
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002097 RID: 8343
		[Obsolete("", true)]
		public abstract ICalculoDeEstimuloCoital GetCalculos();

		// Token: 0x06002098 RID: 8344
		public abstract bool TryInstantiateCalculo(out ICalculoDeEstimuloCoitalHole calculo);

		// Token: 0x06002099 RID: 8345
		[Obsolete("", true)]
		public abstract void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloCoitalHole> resultado);

		// Token: 0x0600209A RID: 8346 RVA: 0x0007A8AC File Offset: 0x00078AAC
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return (ICalculoDeEstimuloCoitalHole)((object)base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index));
		}

		// Token: 0x0600209B RID: 8347 RVA: 0x0007A8BF File Offset: 0x00078ABF
		ICalculoDeEstimuloCoitalHole ICalculadorDeEstimulo<ICalculoDeEstimuloCoitalHole>.GetCalculoEnFrame(int index)
		{
			return (ICalculoDeEstimuloCoitalHole)((object)base.GetCalculoEnFrame(index));
		}

		// Token: 0x0600209D RID: 8349 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x0600209E RID: 8350 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x0600209F RID: 8351 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060020A0 RID: 8352 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x060020A1 RID: 8353 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060020A2 RID: 8354 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
