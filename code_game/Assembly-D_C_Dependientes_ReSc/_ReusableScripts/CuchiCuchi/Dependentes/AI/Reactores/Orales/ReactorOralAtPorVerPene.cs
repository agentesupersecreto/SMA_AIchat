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
	// Token: 0x02000365 RID: 869
	public class ReactorOralAtPorVerPene : ReactorACalculoDeEstimulo<ICalculoDeEstimuloVisual>
	{
		// Token: 0x060015B4 RID: 5556 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x00066E48 File Offset: 0x00065048
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
				throw new ArgumentNullException("m_OralAtController", "m_OralAtController null reference.");
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

		// Token: 0x060015B6 RID: 5558 RVA: 0x00066F8C File Offset: 0x0006518C
		protected override bool CalculoEsValido(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.dada)
			{
				return false;
			}
			if (this.m_IBocaHole.isPenetrated || this.m_characterGestuable.estadoDeBocaPorUser == CharacterEstadoDeBoca.sellada)
			{
				return false;
			}
			if (!calculo.estimulanteParte.PuedePenetrar())
			{
				return false;
			}
			Component estimulante = calculo.estimulo.estimulante;
			if (!(estimulante is IPeneConPartes))
			{
				return false;
			}
			float num = ((IPeneConPartes)estimulante).worldLength;
			num *= num;
			return (calculo.estimulo.transformEstimulante.position - this.m_IBocaHole.entrada.position).sqrMagnitude <= num;
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x00067030 File Offset: 0x00065230
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloVisual calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			IPeneConPartes pene;
			AutoSexPosibilidadScore.Resultados result;
			int num;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				this.m_paraPene.DoUpdate(pene, calculo, this.prioridadParaConstroller, out num);
				result = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				this.m_paraDedo.DoUpdate(pene, calculo, this.prioridadParaConstroller, out num);
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
			if (result.distanceToTarget > pene.worldLength)
			{
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
			if (this.m_OralAtController.BocaHacia(result.targetParte, result.targetLocalOffset, result.targetParte, result.targetLocalOffset, this.m_ICharacter.escala * 0.05f, result.weightV2 * num2, result.proyection, Vector3.zero, lookAtType, true, 1f, 1f, num, (this.baseConfig.coolDownGeneral * 5f).Random(0.15f), ControllerPrioridadConfig.prioridad, delegate(OralAtController.Orden o)
			{
				if (pene == null || !pene.isActiveAndEnabled)
				{
					return false;
				}
				float magnitude = (o.directionTarget.TransformPoint(result.targetLocalOffset) - this.m_IBocaHole.entrada.position).magnitude;
				float worldLength = pene.worldLength;
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

		// Token: 0x04000F6A RID: 3946
		private OralAtController m_OralAtController;

		// Token: 0x04000F6B RID: 3947
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F6C RID: 3948
		public int prioridadParaConstroller = 100;

		// Token: 0x04000F6D RID: 3949
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04000F6E RID: 3950
		private ICharacter m_ICharacter;

		// Token: 0x04000F6F RID: 3951
		private OralPosibilidadScore m_paraPene;

		// Token: 0x04000F70 RID: 3952
		private OralPosibilidadScore m_paraDedo;

		// Token: 0x04000F71 RID: 3953
		private ICharacterGestuable m_characterGestuable;

		// Token: 0x04000F72 RID: 3954
		private ReactorGeneralLookAt m_reactorLookAt;
	}
}
