using System;
using System.Linq;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x0200035E RID: 862
	public class ReactorDeseoOralBocaPosePorTocar : ReactorACalculoDeEstimulo<ICalculoDeEstimuloTactil>, ICharacterPuedeHablar
	{
		// Token: 0x0600158B RID: 5515 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x000660F4 File Offset: 0x000642F4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControladorDeGestosDeBoca = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosDeBoca == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosDeBoca", "m_ControladorDeGestosDeBoca null reference.");
			}
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
			this.m_characterGestuable = this.GetComponentEnRoot(false);
			if (this.m_characterGestuable == null)
			{
				throw new ArgumentNullException("m_characterGestuable", "m_characterGestuable null reference.");
			}
			this.m_hablador = this.GetComponentEnRoot(false);
			if (this.m_hablador == null)
			{
				throw new ArgumentNullException("m_hablador", "m_hablador null reference.");
			}
			this.NoEstaHalando = () => !this.m_hablador.estaHablando;
			OralPosibilidadScore[] componentsInParent = base.GetComponentsInParent<OralPosibilidadScore>();
			this.m_paraPene = componentsInParent.First((OralPosibilidadScore c) => c.paraParte == ParteQuePuedeEstimular.pene);
			this.m_paraDedo = componentsInParent.First((OralPosibilidadScore c) => c.paraParte == ParteQuePuedeEstimular.dedo);
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x00066260 File Offset: 0x00064460
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida && !this.m_IBocaHole.isPenetrated && this.m_characterGestuable.estadoDeBocaPorUser != CharacterEstadoDeBoca.sellada && calculo.PartePrincipalEstimulada(false).EsAproximadoOral() && calculo.estimulanteParte.EsPenetrador() && calculo.estimuloBasico.estimulante is TocanteObjeto;
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x000662D0 File Offset: 0x000644D0
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloTactil calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			PenisPart penisPart;
			calculo.estimulo.estimulante.TryGetComponent<PenisPart>(out penisPart);
			Penetrador penetrador = ((penisPart != null) ? penisPart.penis : null);
			if (penetrador == null)
			{
				return false;
			}
			IPeneConPartes peneConPartes;
			int num;
			AutoSexPosibilidadScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(penetrador))
			{
				peneConPartes = penetrador;
				this.m_paraPene.DoUpdate(peneConPartes, calculo, this.prioridadParaController, out num);
				resultados = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(penetrador))
			{
				peneConPartes = penetrador;
				this.m_paraDedo.DoUpdate(peneConPartes, calculo, this.prioridadParaController, out num);
				resultados = this.m_paraDedo.resultados;
			}
			else
			{
				if (maleChar.ObjetoEsProp(penetrador.transform))
				{
					Debug.LogException(new NotImplementedException(), this);
					return false;
				}
				return false;
			}
			bool flag = this.m_ConsentForzado.EsCorrupted(calculo);
			bool penetracionEsConsentida = resultados.penetracionEsConsentida;
			float num2 = ((flag && !penetracionEsConsentida) ? resultados.scoreByDesires : resultados.scoreV2);
			if (num2 < 0f)
			{
				return false;
			}
			if (!penetracionEsConsentida && !flag)
			{
				return false;
			}
			float worldTipPartWidth = peneConPartes.worldTipPartWidth;
			float num3 = Mathf.Lerp(0.75f, 1f, num2.OutPow(2f));
			float num4 = worldTipPartWidth / this.m_ICharacter.escala;
			TiposDeGestosDeBoca tiposDeGestosDeBoca;
			if (num4 < 0.016f)
			{
				tiposDeGestosDeBoca = TiposDeGestosDeBoca.deseoOralSmall;
			}
			else if (num4 < 0.034f)
			{
				tiposDeGestosDeBoca = TiposDeGestosDeBoca.deseoOralNormal;
			}
			else if (num4 < 0.044f)
			{
				tiposDeGestosDeBoca = TiposDeGestosDeBoca.deseoOralBig;
			}
			else
			{
				tiposDeGestosDeBoca = TiposDeGestosDeBoca.deseoOralMoster;
			}
			return this.m_ControladorDeGestosDeBoca.Gestuar(tiposDeGestosDeBoca, num3, num, ControllerPrioridadConfig.prioridad, (this.baseConfig.coolDownGeneral * 3.5f).Random(0.15f), false, this.NoEstaHalando, this.inVelocityMod, this.outVelocityMod);
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x00066480 File Offset: 0x00064680
		bool ICharacterPuedeHablar.PuedeIntentarHablar(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = false;
			ControladorDeGestosDeBoca controladorDeGestosDeBoca = this.m_ControladorDeGestosDeBoca;
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = ((controladorDeGestosDeBoca != null) ? new TiposDeGestosDeBoca?(controladorDeGestosDeBoca.Gestuandose()) : null);
			return !((tiposDeGestosDeBoca != null) ? new bool?(tiposDeGestosDeBoca.GetValueOrDefault().EsDeseoOral()) : null).GetValueOrDefault(false);
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x000664E4 File Offset: 0x000646E4
		bool ICharacterPuedeHablar.PuedeHablarConClaridad(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = false;
			ControladorDeGestosDeBoca controladorDeGestosDeBoca = this.m_ControladorDeGestosDeBoca;
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = ((controladorDeGestosDeBoca != null) ? new TiposDeGestosDeBoca?(controladorDeGestosDeBoca.Gestuandose()) : null);
			return !((tiposDeGestosDeBoca != null) ? new bool?(tiposDeGestosDeBoca.GetValueOrDefault().EsDeseoOral()) : null).GetValueOrDefault(false);
		}

		// Token: 0x04000F3C RID: 3900
		private ControladorDeGestosDeBoca m_ControladorDeGestosDeBoca;

		// Token: 0x04000F3D RID: 3901
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F3E RID: 3902
		public int prioridadParaController = 200;

		// Token: 0x04000F3F RID: 3903
		public float inVelocityMod = 0.33f;

		// Token: 0x04000F40 RID: 3904
		public float outVelocityMod = 0.5f;

		// Token: 0x04000F41 RID: 3905
		private ICharacter m_ICharacter;

		// Token: 0x04000F42 RID: 3906
		private OralPosibilidadScore m_paraPene;

		// Token: 0x04000F43 RID: 3907
		private OralPosibilidadScore m_paraDedo;

		// Token: 0x04000F44 RID: 3908
		private ICharacterHablador m_hablador;

		// Token: 0x04000F45 RID: 3909
		private Func<bool> NoEstaHalando;

		// Token: 0x04000F46 RID: 3910
		private ICharacterGestuable m_characterGestuable;

		// Token: 0x04000F47 RID: 3911
		private ConsentCorrupted m_ConsentForzado;
	}
}
