using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Sexuales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000375 RID: 885
	public sealed class ReactorSexAtPorVerPene : ReactorACalculoDeEstimulo<ICalculoDeEstimuloVisual>
	{
		// Token: 0x06001603 RID: 5635 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x00069144 File Offset: 0x00067344
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SexoAtController = this.GetComponentEnRoot(false);
			if (this.m_SexoAtController == null)
			{
				throw new ArgumentNullException("m_SexoAtController", "m_SexoAtController null reference.");
			}
			this.m_IVagHole = this.GetComponentEnRoot(false);
			if (this.m_IVagHole == null)
			{
				throw new ArgumentNullException("m_IVagHole", "m_IVagHole null reference.");
			}
			this.m_IAnusHole = this.GetComponentEnRoot(false);
			if (this.m_IAnusHole == null)
			{
				throw new ArgumentNullException("m_IAnusHole", "m_IAnusHole null reference.");
			}
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_ICharacter", "m_ICharacter null reference.");
			}
			this.m_paraPeneVag = base.GetComponentInParent<PeneVaginalPosibilidadScore>();
			this.m_paraDedoVag = base.GetComponentInParent<DedoVaginalPosibilidadScore>();
			this.m_paraPeneAnal = base.GetComponentInParent<PeneAnalPosibilidadScore>();
			this.m_paraDedoAnal = base.GetComponentInParent<DedoAnalPosibilidadScore>();
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x00069224 File Offset: 0x00067424
		protected override bool CalculoEsValido(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.dada)
			{
				return false;
			}
			if (this.m_IVagHole.isPenetrated || this.m_IAnusHole.isPenetrated)
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
			return (calculo.estimulo.transformEstimulante.position - this.m_IVagHole.entrada.position).sqrMagnitude <= num || (calculo.estimulo.transformEstimulante.position - this.m_IAnusHole.entrada.position).sqrMagnitude <= num;
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x000692F8 File Offset: 0x000674F8
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloVisual calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			Vector3 vector = calculo.estimulo.transformEstimulante.position - this.m_IVagHole.entrada.position;
			Vector3 vector2 = calculo.estimulo.transformEstimulante.position - this.m_IAnusHole.entrada.position;
			bool flag = vector.sqrMagnitude <= vector2.sqrMagnitude;
			FemalePenetracionTipo femalePenetracionTipo = (flag ? FemalePenetracionTipo.vag : FemalePenetracionTipo.anus);
			IPeneConPartes pene;
			AutoSexPosibilidadScore.Resultados result;
			int num;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				if (flag)
				{
					this.m_paraPeneVag.DoUpdate(pene, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraPeneVag.resultados;
				}
				else
				{
					this.m_paraPeneAnal.DoUpdate(pene, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraPeneAnal.resultados;
				}
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				if (flag)
				{
					this.m_paraDedoVag.DoUpdate(pene, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraDedoVag.resultados;
				}
				else
				{
					this.m_paraDedoAnal.DoUpdate(pene, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraDedoAnal.resultados;
				}
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
			return result.distanceToTarget <= pene.worldLength && result.scoreV2 > 0f && this.m_SexoAtController.HoleHacia(result.targetParte, result.targetLocalOffset, result.targetParte, result.targetLocalOffset, femalePenetracionTipo, result.weightV2, result.proyection, result.anglesOffsets, LookAtControllerV2.LookAtType.fijamente, true, 1f, 1f, num, (this.baseConfig.coolDownGeneral * 20f).Random(0.15f), ControllerPrioridadConfig.prioridad, delegate(SexoAtController.Orden o)
			{
				if (pene == null || !pene.isActiveAndEnabled)
				{
					return false;
				}
				Vector3 vector3 = o.directionTarget.TransformPoint(result.targetLocalOffset);
				float magnitude = (vector3 - this.m_IVagHole.entrada.position).magnitude;
				float magnitude2 = (vector3 - this.m_IAnusHole.entrada.position).magnitude;
				float worldLength = pene.worldLength;
				return magnitude <= worldLength * 2f || magnitude2 <= worldLength * 2f;
			});
		}

		// Token: 0x04000FDC RID: 4060
		private SexoAtController m_SexoAtController;

		// Token: 0x04000FDD RID: 4061
		private IVagHole m_IVagHole;

		// Token: 0x04000FDE RID: 4062
		private IAnusHole m_IAnusHole;

		// Token: 0x04000FDF RID: 4063
		public int prioridadParaConstroller = 10;

		// Token: 0x04000FE0 RID: 4064
		private ICharacter m_ICharacter;

		// Token: 0x04000FE1 RID: 4065
		private PeneVaginalPosibilidadScore m_paraPeneVag;

		// Token: 0x04000FE2 RID: 4066
		private DedoVaginalPosibilidadScore m_paraDedoVag;

		// Token: 0x04000FE3 RID: 4067
		private PeneAnalPosibilidadScore m_paraPeneAnal;

		// Token: 0x04000FE4 RID: 4068
		private DedoAnalPosibilidadScore m_paraDedoAnal;
	}
}
