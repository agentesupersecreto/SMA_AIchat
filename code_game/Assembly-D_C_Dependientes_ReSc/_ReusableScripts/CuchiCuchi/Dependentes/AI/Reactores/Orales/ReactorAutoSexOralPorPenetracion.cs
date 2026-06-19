using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x0200035C RID: 860
	public class ReactorAutoSexOralPorPenetracion : ReactorACalculoDeEstimulo<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x0600157F RID: 5503 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x00065D0C File Offset: 0x00063F0C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IPuppetManipulable = this.GetComponentEnRoot(false);
			if (this.m_IPuppetManipulable == null)
			{
				throw new ArgumentNullException("m_IPuppetManipulable", "m_IPuppetManipulable null reference.");
			}
			this.m_ControlladorDeAutoSexOral = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeAutoSexOral == null)
			{
				throw new ArgumentNullException("m_ControlladorDeAutoSexOral", "m_ControlladorDeAutoSexOral null reference.");
			}
			this.m_placer = this.GetComponentEnRoot(false);
			if (this.m_placer == null)
			{
				throw new ArgumentNullException("m_placer", "m_placer null reference.");
			}
			this.m_RespiracionEngine = this.GetComponentEnRoot(false);
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
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

		// Token: 0x06001581 RID: 5505 RVA: 0x00065E74 File Offset: 0x00064074
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			if (!this.m_IBocaHole.isPenetrated)
			{
				return false;
			}
			if (this.m_placer.valueAtMax)
			{
				return false;
			}
			if (calculo.PartePrincipalEstimulada(false) != ParteDelCuerpoHumano.bocaInterno)
			{
				return false;
			}
			IPeneConPartes peneConPartes = calculo.estimuloBasico.estimulante as IPeneConPartes;
			if (peneConPartes == null)
			{
				return false;
			}
			ICharacterIdleable characterIdleable = peneConPartes.GetRootOwner() as ICharacterIdleable;
			return (characterIdleable == null || characterIdleable.idlePor > this.minIdleToActivate) && this.m_RespiracionEngine.ahogadoEstado != AhogadoEstado.ahogado && this.m_RespiracionEngine.ahogadoEstado != AhogadoEstado.estaDesahogandose && !this.m_IPuppetManipulable.siendoManipulado;
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x00065F20 File Offset: 0x00064120
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			int num = 1;
			ParteQuePuedeEstimular parteQuePuedeEstimular;
			IPeneConPartes peneConPartes;
			float num2;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				parteQuePuedeEstimular = ParteQuePuedeEstimular.pene;
				peneConPartes = (IPeneConPartes)estimulante;
				this.m_paraPene.DoUpdate(peneConPartes, calculo);
				AutoSexScore.Resultados resultados = this.m_paraPene.resultados;
				num2 = Mathf.InverseLerp(resultados.thresholds.scoreMinParaAutoSex, resultados.thresholds.scoreMaxParaAutoSex, resultados.scoreV2);
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				parteQuePuedeEstimular = ParteQuePuedeEstimular.dedo;
				peneConPartes = (IPeneConPartes)estimulante;
				this.m_paraDedo.DoUpdate((IPeneConPartes)estimulante, calculo);
				AutoSexScore.Resultados resultados = this.m_paraDedo.resultados;
				num2 = Mathf.InverseLerp(resultados.thresholds.scoreMinParaAutoSex, resultados.thresholds.scoreMaxParaAutoSex, resultados.scoreV2);
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
			if (num2 <= 0f)
			{
				return false;
			}
			float num3 = Mathf.Lerp(this.maxIdleToActivate, this.minIdleToActivate, num2.OutPow(2f));
			ICharacterIdleable characterIdleable = peneConPartes.GetRootOwner() as ICharacterIdleable;
			if (characterIdleable != null && characterIdleable.idlePor <= num3)
			{
				return false;
			}
			float num4 = this.duracion.Random(0.333f);
			return this.m_ControlladorDeAutoSexOral.DoAutoSex((ControlladorDeAutoSexV2.Orden o) => !this.m_placer.valueAtMax, num2, ParteDelCuerpoHumano.bocaInterno, parteQuePuedeEstimular, num, ControllerPrioridadConfig.prioridad, num4);
		}

		// Token: 0x04000F2E RID: 3886
		public float duracion = 20f;

		// Token: 0x04000F2F RID: 3887
		public float minIdleToActivate = 1f;

		// Token: 0x04000F30 RID: 3888
		public float maxIdleToActivate = 20f;

		// Token: 0x04000F31 RID: 3889
		private ControlladorDeAutoSexV2 m_ControlladorDeAutoSexOral;

		// Token: 0x04000F32 RID: 3890
		private IPuppetManipulable m_IPuppetManipulable;

		// Token: 0x04000F33 RID: 3891
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F34 RID: 3892
		private OralSexScore m_paraPene;

		// Token: 0x04000F35 RID: 3893
		private OralSexScore m_paraDedo;

		// Token: 0x04000F36 RID: 3894
		private Personalidad m_Personalidad;

		// Token: 0x04000F37 RID: 3895
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000F38 RID: 3896
		private Placer m_placer;
	}
}
