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
	// Token: 0x02000360 RID: 864
	public class ReactorDeseoOralBocaPosePorVer : ReactorACalculoDeEstimulo<ICalculoDeEstimuloVisual>, ICharacterPuedeHablar
	{
		// Token: 0x06001599 RID: 5529 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x000665A4 File Offset: 0x000647A4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
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

		// Token: 0x0600159B RID: 5531 RVA: 0x00066710 File Offset: 0x00064910
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
			if (!(calculo.estimuloBasico.estimulante is IPeneConPartes))
			{
				return false;
			}
			float num = this.minDistanceToReacc * this.m_ICharacter.escala;
			num *= num;
			return (calculo.estimulo.transformEstimulante.position - this.m_IBocaHole.entrada.position).sqrMagnitude <= num;
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloVisual calculo)
		{
			return 1f;
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x000667B8 File Offset: 0x000649B8
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloVisual calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			IPeneConPartes peneConPartes;
			int num;
			AutoSexPosibilidadScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				peneConPartes = (IPeneConPartes)estimulante;
				this.m_paraPene.DoUpdate(peneConPartes, calculo, this.prioridadParaController, out num);
				resultados = this.m_paraPene.resultados;
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				peneConPartes = (IPeneConPartes)estimulante;
				this.m_paraDedo.DoUpdate(peneConPartes, calculo, this.prioridadParaController, out num);
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
			if (((flag && !penetracionEsConsentida) ? resultados.scoreByDesires : resultados.scoreV2) < 0f)
			{
				return false;
			}
			if (!penetracionEsConsentida && !flag)
			{
				return false;
			}
			float worldTipPartLength = peneConPartes.worldTipPartLength;
			float worldTipPartWidth = peneConPartes.worldTipPartWidth;
			float num2 = Mathf.Max(worldTipPartLength, worldTipPartWidth);
			if (resultados.distanceToTarget > num2 * 2f)
			{
				return false;
			}
			float num3 = Mathf.Lerp(0.75f, 1f, resultados.scoreV2.OutPow(2f));
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

		// Token: 0x0600159F RID: 5535 RVA: 0x00066978 File Offset: 0x00064B78
		bool ICharacterPuedeHablar.PuedeIntentarHablar(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = false;
			ControladorDeGestosDeBoca controladorDeGestosDeBoca = this.m_ControladorDeGestosDeBoca;
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = ((controladorDeGestosDeBoca != null) ? new TiposDeGestosDeBoca?(controladorDeGestosDeBoca.Gestuandose()) : null);
			return !((tiposDeGestosDeBoca != null) ? new bool?(tiposDeGestosDeBoca.GetValueOrDefault().EsDeseoOral()) : null).GetValueOrDefault(false);
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x000669DC File Offset: 0x00064BDC
		bool ICharacterPuedeHablar.PuedeHablarConClaridad(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = false;
			ControladorDeGestosDeBoca controladorDeGestosDeBoca = this.m_ControladorDeGestosDeBoca;
			TiposDeGestosDeBoca? tiposDeGestosDeBoca = ((controladorDeGestosDeBoca != null) ? new TiposDeGestosDeBoca?(controladorDeGestosDeBoca.Gestuandose()) : null);
			return !((tiposDeGestosDeBoca != null) ? new bool?(tiposDeGestosDeBoca.GetValueOrDefault().EsDeseoOral()) : null).GetValueOrDefault(false);
		}

		// Token: 0x04000F4B RID: 3915
		private ControladorDeGestosDeBoca m_ControladorDeGestosDeBoca;

		// Token: 0x04000F4C RID: 3916
		private IBocaHole m_IBocaHole;

		// Token: 0x04000F4D RID: 3917
		public float minDistanceToReacc = 0.2f;

		// Token: 0x04000F4E RID: 3918
		public int prioridadParaController = 100;

		// Token: 0x04000F4F RID: 3919
		public float inVelocityMod = 0.33f;

		// Token: 0x04000F50 RID: 3920
		public float outVelocityMod = 0.5f;

		// Token: 0x04000F51 RID: 3921
		private ICharacter m_ICharacter;

		// Token: 0x04000F52 RID: 3922
		private OralPosibilidadScore m_paraPene;

		// Token: 0x04000F53 RID: 3923
		private OralPosibilidadScore m_paraDedo;

		// Token: 0x04000F54 RID: 3924
		private ICharacterHablador m_hablador;

		// Token: 0x04000F55 RID: 3925
		private Func<bool> NoEstaHalando;

		// Token: 0x04000F56 RID: 3926
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04000F57 RID: 3927
		private ICharacterGestuable m_characterGestuable;

		// Token: 0x04000F58 RID: 3928
		[SerializeField]
		[ReadOnlyUI]
		private float m_endTimeDeseo;
	}
}
