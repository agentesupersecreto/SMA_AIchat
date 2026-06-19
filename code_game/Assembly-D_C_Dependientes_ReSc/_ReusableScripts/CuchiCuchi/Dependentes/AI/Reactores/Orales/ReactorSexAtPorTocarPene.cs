using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Sexuales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000373 RID: 883
	public class ReactorSexAtPorTocarPene : ReactorACalculoDeEstimulo<ICalculoDeEstimuloTactil>
	{
		// Token: 0x060015FA RID: 5626 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x00068BD4 File Offset: 0x00066DD4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
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

		// Token: 0x060015FC RID: 5628 RVA: 0x00068CDC File Offset: 0x00066EDC
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			if (this.m_IVagHole.isPenetrated || this.m_IAnusHole.isPenetrated)
			{
				if (this.m_IVagHole.isPenetrated && this.m_IAnusHole.isPenetrated)
				{
					this.m_LastFemalePenetracionTipo = null;
				}
				else if (this.m_IVagHole.isPenetrated)
				{
					this.m_LastFemalePenetracionTipo = new FemalePenetracionTipo?(FemalePenetracionTipo.vag);
				}
				else if (this.m_IAnusHole.isPenetrated)
				{
					this.m_LastFemalePenetracionTipo = new FemalePenetracionTipo?(FemalePenetracionTipo.anus);
				}
				return false;
			}
			if (!calculo.estimulanteParte.EsPenetrador())
			{
				return false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(false);
			if (calculo.estimulanteParte.EsPenetradorConfiable())
			{
				if (parteDelCuerpoHumano != ParteDelCuerpoHumano.vag && parteDelCuerpoHumano != ParteDelCuerpoHumano.ano)
				{
					return false;
				}
			}
			else if (!parteDelCuerpoHumano.EsEntrepierna() && !parteDelCuerpoHumano.EsTrasero())
			{
				return false;
			}
			return calculo.estimuloBasico.estimulante is TocanteObjeto;
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x00068DCC File Offset: 0x00066FCC
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
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(false);
			if (this.m_LastFemalePenetracionTipo == null)
			{
				if (this.m_paraPeneVag.deseos.valores.traseroPercentage > this.m_paraPeneVag.deseos.valores.entrepiernaPercentage)
				{
					this.m_LastFemalePenetracionTipo = new FemalePenetracionTipo?(FemalePenetracionTipo.anus);
				}
				else
				{
					this.m_LastFemalePenetracionTipo = new FemalePenetracionTipo?(FemalePenetracionTipo.vag);
				}
			}
			if (parteDelCuerpoHumano.EsCoitoVaginal())
			{
				this.m_LastFemalePenetracionTipo = new FemalePenetracionTipo?(FemalePenetracionTipo.vag);
			}
			if (parteDelCuerpoHumano.EsCoitoAnal())
			{
				this.m_LastFemalePenetracionTipo = new FemalePenetracionTipo?(FemalePenetracionTipo.anus);
			}
			FemalePenetracionTipo value = this.m_LastFemalePenetracionTipo.Value;
			bool flag = value == FemalePenetracionTipo.vag;
			AutoSexPosibilidadScore.Resultados result;
			int num;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				if (flag)
				{
					this.m_paraPeneVag.DoUpdate(estimulante, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraPeneVag.resultados;
				}
				else
				{
					this.m_paraPeneAnal.DoUpdate(estimulante, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraPeneAnal.resultados;
				}
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				if (flag)
				{
					this.m_paraDedoVag.DoUpdate(estimulante, calculo, this.prioridadParaConstroller, out num);
					result = this.m_paraDedoVag.resultados;
				}
				else
				{
					this.m_paraDedoAnal.DoUpdate(estimulante, calculo, this.prioridadParaConstroller, out num);
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
			if (result.scoreV2 == 0f)
			{
				return false;
			}
			float num2 = 1f;
			if (this.m_ConsentForzado.EsCorrupted(calculo))
			{
				num2 = 0.2f;
			}
			return this.m_SexoAtController.HoleHacia(result.targetParte, result.targetLocalOffset, result.targetParte, result.targetLocalOffset, value, result.weightV2 * num2, result.proyection, result.anglesOffsets, LookAtControllerV2.LookAtType.fijamente, true, 1f, 1f, num, (this.baseConfig.coolDownGeneral * 60f).Random(0.15f), ControllerPrioridadConfig.prioridad, delegate(SexoAtController.Orden o)
			{
				if (estimulante == null || !estimulante.isActiveAndEnabled)
				{
					return false;
				}
				Vector3 vector = o.directionTarget.TransformPoint(result.targetLocalOffset);
				float magnitude = (vector - this.m_IVagHole.entrada.position).magnitude;
				float magnitude2 = (vector - this.m_IAnusHole.entrada.position).magnitude;
				float worldLength = estimulante.worldLength;
				return magnitude <= worldLength * 2f || magnitude2 <= worldLength * 2f;
			});
		}

		// Token: 0x04000FCE RID: 4046
		private SexoAtController m_SexoAtController;

		// Token: 0x04000FCF RID: 4047
		private IVagHole m_IVagHole;

		// Token: 0x04000FD0 RID: 4048
		private IAnusHole m_IAnusHole;

		// Token: 0x04000FD1 RID: 4049
		public int prioridadParaConstroller = 20;

		// Token: 0x04000FD2 RID: 4050
		private ICharacter m_ICharacter;

		// Token: 0x04000FD3 RID: 4051
		private PeneVaginalPosibilidadScore m_paraPeneVag;

		// Token: 0x04000FD4 RID: 4052
		private DedoVaginalPosibilidadScore m_paraDedoVag;

		// Token: 0x04000FD5 RID: 4053
		private PeneAnalPosibilidadScore m_paraPeneAnal;

		// Token: 0x04000FD6 RID: 4054
		private DedoAnalPosibilidadScore m_paraDedoAnal;

		// Token: 0x04000FD7 RID: 4055
		private FemalePenetracionTipo? m_LastFemalePenetracionTipo;

		// Token: 0x04000FD8 RID: 4056
		private ConsentCorrupted m_ConsentForzado;
	}
}
