using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.ParaReactoresAEstimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x02000394 RID: 916
	public abstract class ReactorACalculoDeEstimuloConParaReactor<TCalculo> : ReactorACalculoDeEstimulo<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600140B RID: 5131 RVA: 0x00056CF5 File Offset: 0x00054EF5
		public IReadOnlyList<string> paraReactoresTags
		{
			get
			{
				return this.m_paraReactoresTags;
			}
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x00056CFD File Offset: 0x00054EFD
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_MainParaReactor = base.GetComponentInParent<MainParaReactor>();
			if (this.m_MainParaReactor == null)
			{
				throw new ArgumentNullException("m_MainParaReactor", "m_MainParaReactor null reference.");
			}
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x00056D30 File Offset: 0x00054F30
		protected sealed override bool ReaccionarCalculo(TCalculo calculo)
		{
			float num;
			bool flag = this.ReaccionarCalculoBlokeandoParaReactor(calculo, out num);
			if (flag)
			{
				this.m_MainParaReactor.FlagReaccionado(this.m_paraReactoresTags, num);
			}
			return flag;
		}

		// Token: 0x0600140E RID: 5134
		protected abstract bool ReaccionarCalculoBlokeandoParaReactor(TCalculo calculo, out float blokearTiempo);

		// Token: 0x04001085 RID: 4229
		[Header("Para Reactor Blocker")]
		[SerializeField]
		[StringSelector(typeof(ParaReactoresTags), "valoresEditor")]
		private string[] m_paraReactoresTags;

		// Token: 0x04001086 RID: 4230
		private MainParaReactor m_MainParaReactor;
	}
}
