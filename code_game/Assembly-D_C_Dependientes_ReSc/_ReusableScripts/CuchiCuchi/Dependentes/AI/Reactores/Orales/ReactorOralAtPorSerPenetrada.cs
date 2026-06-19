using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.LookAt;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000362 RID: 866
	public class ReactorOralAtPorSerPenetrada : ReactorACalculoDeEstimulo<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x060015A7 RID: 5543 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x00066A8C File Offset: 0x00064C8C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_reactorLookAt = this.GetComponentEnRoot(false);
			this.m_OralAtController = this.GetComponentEnRoot(false);
			if (this.m_OralAtController == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosDeBoca", "m_ControladorDeGestosDeBoca null reference.");
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
			OralSexScore[] componentsInParent = base.GetComponentsInParent<OralSexScore>();
			this.m_paraPene = componentsInParent.First((OralSexScore c) => c.paraParte == ParteQuePuedeEstimular.pene);
			this.m_paraDedo = componentsInParent.First((OralSexScore c) => c.paraParte == ParteQuePuedeEstimular.dedo);
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00066BAC File Offset: 0x00064DAC
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			return calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida && this.m_IBocaHole.isPenetrated && calculo.PartePrincipalEstimulada(false) == ParteDelCuerpoHumano.bocaInterno && calculo.estimuloBasico.estimulante is IPeneConPartes;
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x00066BFC File Offset: 0x00064DFC
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			int num = this.prioridadParaConstroller;
			IPeneConPartes pene;
			AutoSexScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				this.m_paraPene.DoUpdate((IPeneConPartes)estimulante, calculo);
				resultados = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
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
			float num2 = (flag ? 1f : resultados.scoreV2);
			if (num2 == 0f)
			{
				return false;
			}
			if (resultados.scoreV2 < 0f && resultados.penetracionEsConsentida)
			{
				return false;
			}
			float num3 = 1f;
			LookAtControllerV2.LookAtType lookAtType;
			if (num2 > 0f)
			{
				lookAtType = LookAtControllerV2.LookAtType.fijamente;
			}
			else
			{
				float value = Random.value;
				if (value < 0.16666f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirL;
				}
				else if (value < 0.3333f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirR;
				}
				else if (value < 0.5f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirRDown;
				}
				else if (value < 0.6666f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirLDown;
				}
				else if (value < 0.83326f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirLUp;
				}
				else
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirRUp;
				}
			}
			if (this.m_OralAtController.BocaHacia(resultados.targetTransform, Vector3.zero, null, Vector3.zero, 0f, resultados.weightTeasing * num3, resultados.proyection, Vector3.zero, lookAtType, true, this.m_smoothTargetVelocityMod, 0.1f, num, (this.baseConfig.coolDownGeneral * 4f).Random(0.15f), ControllerPrioridadConfig.prioridad, (OralAtController.Orden o) => pene != null && pene.isActiveAndEnabled && this.m_IBocaHole != null))
			{
				if (this.m_reactorLookAt != null)
				{
					this.m_reactorLookAt.flagOnlyUseEyes = true;
				}
				return true;
			}
			return false;
		}

		// Token: 0x04000F5C RID: 3932
		private OralAtController m_OralAtController;

		// Token: 0x04000F5D RID: 3933
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F5E RID: 3934
		public int prioridadParaConstroller = 100;

		// Token: 0x04000F5F RID: 3935
		private ICharacter m_ICharacter;

		// Token: 0x04000F60 RID: 3936
		private OralSexScore m_paraPene;

		// Token: 0x04000F61 RID: 3937
		private OralSexScore m_paraDedo;

		// Token: 0x04000F62 RID: 3938
		[SerializeField]
		private float m_smoothTargetVelocityMod = 0.85f;

		// Token: 0x04000F63 RID: 3939
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04000F64 RID: 3940
		private ReactorGeneralLookAt m_reactorLookAt;
	}
}
