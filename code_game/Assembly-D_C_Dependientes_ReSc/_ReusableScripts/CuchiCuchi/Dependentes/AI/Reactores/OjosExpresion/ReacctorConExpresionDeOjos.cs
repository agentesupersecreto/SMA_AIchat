using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.OjosExpresion
{
	// Token: 0x02000309 RID: 777
	public abstract class ReacctorConExpresionDeOjos<TCalculo> : ReactorACalculoDeEstimuloConParaReactor<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x060013A9 RID: 5033 RVA: 0x0005C2A9 File Offset: 0x0005A4A9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_OjosExpresionController = this.GetComponentEnCharacter(false);
			if (this.m_OjosExpresionController == null)
			{
				throw new ArgumentNullException("m_OjosExpresionController", "m_OjosExpresionController null reference.");
			}
		}

		// Token: 0x04000E39 RID: 3641
		protected OjosExpresionController m_OjosExpresionController;
	}
}
