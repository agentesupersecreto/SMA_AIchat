using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002F0 RID: 752
	public class ReactorCambioDeDeseosPorEstimulos : ReactorACalculoDeEstimulo<ICalculoDeInteracionEstimulanteConEstado>
	{
		// Token: 0x060012F2 RID: 4850 RVA: 0x0005A514 File Offset: 0x00058714
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Deseos = this.GetComponentEnRoot(false);
			if (this.m_Deseos == null)
			{
				throw new ArgumentNullException("m_Deseos", "m_Deseos null reference.");
			}
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0005A548 File Offset: 0x00058748
		protected override bool CalculoEsValido(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			return calculo.emocion.reaccion == ReaccionHumana.rabia || calculo.emocion.reaccion == ReaccionHumana.placer || calculo.emocion.reaccion == ReaccionHumana.dolor || calculo.emocion.reaccion == ReaccionHumana.miedo;
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x0005A594 File Offset: 0x00058794
		protected override bool ReaccionarCalculo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			return this.m_Deseos.RegistrarEstimulo(calculo);
		}

		// Token: 0x04000DE5 RID: 3557
		private Deseos m_Deseos;
	}
}
