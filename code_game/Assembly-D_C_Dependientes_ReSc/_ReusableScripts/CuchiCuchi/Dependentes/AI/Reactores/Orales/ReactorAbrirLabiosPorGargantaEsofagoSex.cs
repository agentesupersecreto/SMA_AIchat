using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x0200035B RID: 859
	public class ReactorAbrirLabiosPorGargantaEsofagoSex : ReactorACalculoDeEstimulo<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x06001578 RID: 5496 RVA: 0x00065BA4 File Offset: 0x00063DA4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControladorDeGestosDeBoca = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosDeBoca == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosDeBoca", "m_ControladorDeGestosDeBoca null reference.");
			}
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_puedeContinuarEjecutandose = new Func<bool>(this.PuedeContinuarEjecutandose);
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x00065C1C File Offset: 0x00063E1C
		private bool PuedeContinuarEjecutandose()
		{
			TipoDeOralSex currentOralSexTipo = this.m_IBocaHole.currentOralSexTipo;
			return currentOralSexTipo == TipoDeOralSex.conGarganta || currentOralSexTipo == TipoDeOralSex.conEsofago;
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x00065C40 File Offset: 0x00063E40
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			TipoDeOralSex currentOralSexTipo = this.m_IBocaHole.currentOralSexTipo;
			return currentOralSexTipo != TipoDeOralSex.None && currentOralSexTipo != TipoDeOralSex.conBoca;
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x00065C74 File Offset: 0x00063E74
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return this.m_ControladorDeGestosDeBoca.Gestuar(TiposDeGestosDeBoca.abrirLabios, 1f, this.prioridadParaController, ControllerPrioridadConfig.prioridad, (this.baseConfig.coolDownGeneral * 1.5f).Random(0.15f), false, this.m_puedeContinuarEjecutandose, this.inVelocityMod, this.outVelocityMod);
		}

		// Token: 0x04000F28 RID: 3880
		private ControladorDeGestosDeBoca m_ControladorDeGestosDeBoca;

		// Token: 0x04000F29 RID: 3881
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F2A RID: 3882
		public int prioridadParaController = 10000;

		// Token: 0x04000F2B RID: 3883
		public float inVelocityMod = 0.33f;

		// Token: 0x04000F2C RID: 3884
		public float outVelocityMod = 0.5f;

		// Token: 0x04000F2D RID: 3885
		private Func<bool> m_puedeContinuarEjecutandose;
	}
}
