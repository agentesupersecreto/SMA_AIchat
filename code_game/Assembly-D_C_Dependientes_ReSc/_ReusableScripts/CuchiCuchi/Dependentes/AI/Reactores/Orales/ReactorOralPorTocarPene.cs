using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt;
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
	// Token: 0x02000368 RID: 872
	public class ReactorOralPorTocarPene : ReactorACalculoDeEstimulo<ICalculoDeEstimuloTactil>
	{
		// Token: 0x060015C1 RID: 5569 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x00067310 File Offset: 0x00065510
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_OralAtController = this.GetComponentEnRoot(false);
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_reactorLookAt = this.GetComponentEnRoot(false);
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
			this.m_characterGestuable = this.GetComponentEnRoot(false);
			if (this.m_characterGestuable == null)
			{
				throw new ArgumentNullException("m_characterGestuable", "m_characterGestuable null reference.");
			}
			OralPosibilidadScore[] componentsInParent = base.GetComponentsInParent<OralPosibilidadScore>();
			this.m_paraPene = componentsInParent.First((OralPosibilidadScore c) => c.paraParte == ParteQuePuedeEstimular.pene);
			this.m_paraDedo = componentsInParent.First((OralPosibilidadScore c) => c.paraParte == ParteQuePuedeEstimular.dedo);
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x00067454 File Offset: 0x00065654
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida && !this.m_IBocaHole.isPenetrated && this.m_characterGestuable.estadoDeBocaPorUser != CharacterEstadoDeBoca.sellada && calculo.PartePrincipalEstimulada(false).EsFacial() && calculo.estimulanteParte.EsPenetrador() && calculo.estimuloBasico.estimulante is TocanteObjeto;
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x000674C4 File Offset: 0x000656C4
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloTactil calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			PenisPart penisPart;
			calculo.estimulo.estimulante.TryGetComponent<PenisPart>(out penisPart);
			Penetrador estimulante = ((penisPart != null) ? penisPart.penis : null);
			if (estimulante == null)
			{
				return false;
			}
			AutoSexPosibilidadScore.Resultados result;
			int num;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				this.m_paraPene.DoUpdate(estimulante, calculo, this.prioridadParaConstroller, out num);
				result = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				this.m_paraDedo.DoUpdate(estimulante, calculo, this.prioridadParaConstroller, out num);
				result = this.m_paraDedo.resultados;
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
			if (result.scoreV2 == 0f)
			{
				return false;
			}
			LookAtControllerV2.LookAtType lookAtType;
			if (result.anglesOffsets.y == 0f)
			{
				lookAtType = LookAtControllerV2.LookAtType.fijamente;
			}
			else if (result.anglesOffsets.y > 30f)
			{
				if (result.evadingEsPositivo)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirR;
				}
				else
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirL;
				}
			}
			else if (result.evadingEsPositivo)
			{
				lookAtType = LookAtControllerV2.LookAtType.evadirCercaR;
			}
			else
			{
				lookAtType = LookAtControllerV2.LookAtType.evadirCercaL;
			}
			float num2 = 1f;
			if (result.scoreV2 < 0f && this.m_ConsentForzado.EsCorrupted(calculo))
			{
				num2 = 0.1f;
			}
			if (this.m_OralAtController.BocaHacia(result.targetParte, result.targetLocalOffset, result.targetParte, result.targetLocalOffset, this.m_ICharacter.escala * 0.05f, result.weightV2 * num2, result.proyection, Vector3.zero, lookAtType, true, 1f, 1f, num, (this.baseConfig.coolDownGeneral * 8f).Random(0.15f), ControllerPrioridadConfig.prioridad, delegate(OralAtController.Orden o)
			{
				if (estimulante == null || !estimulante.isActiveAndEnabled)
				{
					return false;
				}
				float magnitude = (o.directionTarget.TransformPoint(result.targetLocalOffset) - this.m_IBocaHole.entrada.position).magnitude;
				float worldLength = estimulante.worldLength;
				return magnitude <= worldLength * 4f;
			}))
			{
				if (this.m_reactorLookAt != null)
				{
					this.m_reactorLookAt.flagOnlyUseEyes = true;
				}
				return true;
			}
			return false;
		}

		// Token: 0x04000F79 RID: 3961
		private OralAtController m_OralAtController;

		// Token: 0x04000F7A RID: 3962
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F7B RID: 3963
		public int prioridadParaConstroller = 100;

		// Token: 0x04000F7C RID: 3964
		private ICharacter m_ICharacter;

		// Token: 0x04000F7D RID: 3965
		private OralPosibilidadScore m_paraPene;

		// Token: 0x04000F7E RID: 3966
		private OralPosibilidadScore m_paraDedo;

		// Token: 0x04000F7F RID: 3967
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04000F80 RID: 3968
		private ICharacterGestuable m_characterGestuable;

		// Token: 0x04000F81 RID: 3969
		private ReactorGeneralLookAt m_reactorLookAt;
	}
}
