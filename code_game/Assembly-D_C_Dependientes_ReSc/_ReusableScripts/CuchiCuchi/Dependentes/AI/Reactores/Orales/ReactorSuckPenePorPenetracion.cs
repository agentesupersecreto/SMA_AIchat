using System;
using System.Linq;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x0200036D RID: 877
	public class ReactorSuckPenePorPenetracion : ReactorACalculoDeEstimulo<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x060015DC RID: 5596 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x00067F70 File Offset: 0x00066170
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_ICharacter", "m_ICharacter null reference.");
			}
			this.m_ControlladorDeSuckPose = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeSuckPose == null)
			{
				throw new ArgumentNullException("m_ControlladorDeSuckPose", "m_ControlladorDeSuckPose null reference.");
			}
			this.m_RespiracionEngine = this.GetComponentEnRoot(false);
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			OralSexScore[] componentsInParent = base.GetComponentsInParent<OralSexScore>();
			this.m_paraPene = componentsInParent.First((OralSexScore c) => c.paraParte == ParteQuePuedeEstimular.pene);
			this.m_paraDedo = componentsInParent.First((OralSexScore c) => c.paraParte == ParteQuePuedeEstimular.dedo);
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x000680D8 File Offset: 0x000662D8
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			TipoDeOralSex currentOralSexTipo = this.m_IBocaHole.currentOralSexTipo;
			return currentOralSexTipo != TipoDeOralSex.None && currentOralSexTipo != TipoDeOralSex.conGarganta && calculo.PartePrincipalEstimulada(false) == ParteDelCuerpoHumano.bocaInterno && calculo.estimuloBasico.estimulante is IPeneConPartes && this.m_RespiracionEngine.descanzado;
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x0006813C File Offset: 0x0006633C
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			int num = this.prioridadParaConstrollerV2;
			AutoSexScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				IPeneConPartes peneConPartes = (IPeneConPartes)estimulante;
				this.m_paraPene.DoUpdate(peneConPartes, calculo);
				resultados = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				IPeneConPartes peneConPartes = (IPeneConPartes)estimulante;
				this.m_paraDedo.DoUpdate((IPeneConPartes)estimulante, calculo);
				resultados = this.m_paraDedo.resultados;
			}
			else
			{
				if (maleChar.ObjetoEsProp(estimulante.transform))
				{
					Debug.LogException(new NotImplementedException(), this);
					return false;
				}
				return false;
			}
			bool flag = this.m_ConsentForzado.EsCorrupted(calculo);
			bool penetracionEsConsentida = resultados.penetracionEsConsentida;
			float num2 = ((flag && !penetracionEsConsentida) ? resultados.scoreByDesires : resultados.scoreV2);
			float num3 = Mathf.InverseLerp(resultados.thresholds.scoreParaAsistencia, resultados.thresholds.scoreParaConstantAsistencia, num2);
			if (num3 <= 0f)
			{
				return false;
			}
			float minSaturacion = Mathf.Lerp(94.5f, 90f, num3.InPow(2f));
			return this.m_RespiracionEngine.saturacionDeOxigeno >= minSaturacion && this.m_ControlladorDeSuckPose.Chupar(num3, num, ControllerPrioridadConfig.prioridad, 60f, this.inTimeV2, this.outTimeV2, () => !this.m_RespiracionEngine.canzado && this.m_RespiracionEngine.saturacionDeOxigeno >= minSaturacion && this.m_IBocaHole.isPenetrated && (this.m_IBocaHole.currentOralSexTipo == TipoDeOralSex.conBoca || this.m_IBocaHole.currentOralSexTipo == TipoDeOralSex.conEsofago), null, default(ControlladorDeSuccion.JointData));
		}

		// Token: 0x04000FA1 RID: 4001
		private ControlladorDeSuccion m_ControlladorDeSuckPose;

		// Token: 0x04000FA2 RID: 4002
		private IBocaHole m_IBocaHole;

		// Token: 0x04000FA3 RID: 4003
		public int prioridadParaConstrollerV2 = 1000;

		// Token: 0x04000FA4 RID: 4004
		public float inTimeV2 = 0.666f;

		// Token: 0x04000FA5 RID: 4005
		public float outTimeV2 = 0.5f;

		// Token: 0x04000FA6 RID: 4006
		private ICharacter m_ICharacter;

		// Token: 0x04000FA7 RID: 4007
		private OralSexScore m_paraPene;

		// Token: 0x04000FA8 RID: 4008
		private OralSexScore m_paraDedo;

		// Token: 0x04000FA9 RID: 4009
		private Personalidad m_Personalidad;

		// Token: 0x04000FAA RID: 4010
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000FAB RID: 4011
		private ConsentCorrupted m_ConsentForzado;
	}
}
