using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Sexuales;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000370 RID: 880
	public class ReactorAutoSexPorPenetracion : ReactorACalculoDeEstimulo<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x060015E9 RID: 5609 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015EA RID: 5610 RVA: 0x00068368 File Offset: 0x00066568
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
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_paraPeneVag = base.GetComponentInParent<PeneVaginalSexScore>();
			this.m_paraDedoVag = base.GetComponentInParent<DedoVaginalSexScore>();
			this.m_paraPeneAnal = base.GetComponentInParent<PeneAnalSexScore>();
			this.m_paraDedoAnal = base.GetComponentInParent<DedoAnalSexScore>();
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x000684C8 File Offset: 0x000666C8
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			if (!this.m_IVagHole.isPenetrated && !this.m_IAnusHole.isPenetrated)
			{
				return false;
			}
			if (this.m_placer.valueAtMax)
			{
				return false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(false);
			if (parteDelCuerpoHumano != ParteDelCuerpoHumano.vag && parteDelCuerpoHumano != ParteDelCuerpoHumano.ano)
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

		// Token: 0x060015EC RID: 5612 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0006858C File Offset: 0x0006678C
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			bool isPenetrated = this.m_IVagHole.isPenetrated;
			ParteDelCuerpoHumano parteDelCuerpoHumano = (isPenetrated ? ParteDelCuerpoHumano.vag : ParteDelCuerpoHumano.ano);
			ParteQuePuedeEstimular parteQuePuedeEstimular;
			IPeneConPartes peneConPartes;
			AutoSexScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				parteQuePuedeEstimular = ParteQuePuedeEstimular.pene;
				peneConPartes = (IPeneConPartes)estimulante;
				if (isPenetrated)
				{
					this.m_paraPeneVag.DoUpdate(peneConPartes, calculo);
					resultados = this.m_paraPeneVag.resultados;
				}
				else
				{
					this.m_paraPeneAnal.DoUpdate(peneConPartes, calculo);
					resultados = this.m_paraPeneAnal.resultados;
				}
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				parteQuePuedeEstimular = ParteQuePuedeEstimular.dedo;
				peneConPartes = (IPeneConPartes)estimulante;
				if (isPenetrated)
				{
					this.m_paraDedoVag.DoUpdate((IPeneConPartes)estimulante, calculo);
					resultados = this.m_paraDedoVag.resultados;
				}
				else
				{
					this.m_paraDedoAnal.DoUpdate((IPeneConPartes)estimulante, calculo);
					resultados = this.m_paraDedoAnal.resultados;
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
			float num = Mathf.InverseLerp(resultados.thresholds.scoreMinParaAutoSex, resultados.thresholds.scoreMaxParaAutoSex, resultados.scoreV2);
			if (num <= 0f)
			{
				return false;
			}
			float num2 = Mathf.Lerp(this.maxIdleToActivate, this.minIdleToActivate, num.OutPow(2f));
			ICharacterIdleable characterIdleable = peneConPartes.GetRootOwner() as ICharacterIdleable;
			if (characterIdleable != null && characterIdleable.idlePor <= num2)
			{
				return false;
			}
			float num3 = this.duracion.Random(0.333f);
			return this.m_ControlladorDeAutoSexOral.DoAutoSex((ControlladorDeAutoSexV2.Orden o) => !this.m_placer.valueAtMax, num, parteDelCuerpoHumano, parteQuePuedeEstimular, this.prioridadParaController, ControllerPrioridadConfig.prioridad, num3);
		}

		// Token: 0x04000FB1 RID: 4017
		public int prioridadParaController = 100;

		// Token: 0x04000FB2 RID: 4018
		public float duracion = 20f;

		// Token: 0x04000FB3 RID: 4019
		public float minIdleToActivate = 1f;

		// Token: 0x04000FB4 RID: 4020
		public float maxIdleToActivate = 20f;

		// Token: 0x04000FB5 RID: 4021
		private ControlladorDeAutoSexV2 m_ControlladorDeAutoSexOral;

		// Token: 0x04000FB6 RID: 4022
		private IPuppetManipulable m_IPuppetManipulable;

		// Token: 0x04000FB7 RID: 4023
		private IVagHole m_IVagHole;

		// Token: 0x04000FB8 RID: 4024
		private IAnusHole m_IAnusHole;

		// Token: 0x04000FB9 RID: 4025
		private PeneVaginalSexScore m_paraPeneVag;

		// Token: 0x04000FBA RID: 4026
		private DedoVaginalSexScore m_paraDedoVag;

		// Token: 0x04000FBB RID: 4027
		private PeneAnalSexScore m_paraPeneAnal;

		// Token: 0x04000FBC RID: 4028
		private DedoAnalSexScore m_paraDedoAnal;

		// Token: 0x04000FBD RID: 4029
		private Personalidad m_Personalidad;

		// Token: 0x04000FBE RID: 4030
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000FBF RID: 4031
		private Placer m_placer;
	}
}
