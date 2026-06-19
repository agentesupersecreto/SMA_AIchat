using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ConExpresiones
{
	// Token: 0x0200034F RID: 847
	public abstract class ReactorExpresionBase<TCalculo> : ReactorACalculoDeEstimuloConParaReactor<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x0600153D RID: 5437 RVA: 0x000640C8 File Offset: 0x000622C8
		public float GetPropUsoBocaPorMuecas(float mod)
		{
			HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.muecas);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return 0.5f * mod;
			case HumanTraitScore.alto:
				return 0.725f * mod;
			case HumanTraitScore.muyAlto:
				return 0.95f * mod;
			case HumanTraitScore.bajo:
				return 0.275f * mod;
			case HumanTraitScore.muyBajo:
				return 0.05f * mod;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0006413C File Offset: 0x0006233C
		public float GetPropUsoBodyPorMimicas(float mod)
		{
			HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.mimicas);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return 0.5f * mod;
			case HumanTraitScore.alto:
				return 0.725f * mod;
			case HumanTraitScore.muyAlto:
				return 0.95f * mod;
			case HumanTraitScore.bajo:
				return 0.275f * mod;
			case HumanTraitScore.muyBajo:
				return 0.05f * mod;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x000641B0 File Offset: 0x000623B0
		public float GetModPorExpresividad(float normalValue = 1f, float mod = 1f, float initialDistance = 0.1f)
		{
			HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.expresividad);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return normalValue * mod;
			case HumanTraitScore.alto:
				return (normalValue + initialDistance) * mod;
			case HumanTraitScore.muyAlto:
				return (normalValue + initialDistance * 2f) * mod;
			case HumanTraitScore.bajo:
				return 1f / (normalValue + initialDistance) * mod;
			case HumanTraitScore.muyBajo:
				return 1f / (normalValue + initialDistance * 2f) * mod;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06001540 RID: 5440 RVA: 0x00064230 File Offset: 0x00062430
		public float probabilidadPorExpresividad
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.expresividad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.05f;
				case HumanTraitScore.muyAlto:
					return 1.1f;
				case HumanTraitScore.bajo:
					return 0.952381f;
				case HumanTraitScore.muyBajo:
					return 0.9090909f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x00064298 File Offset: 0x00062498
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_OjosExpresionController = this.GetComponentEnCharacter(false);
			if (this.m_OjosExpresionController == null)
			{
				throw new ArgumentNullException("m_OjosExpresionController", "m_OjosExpresionController null reference.");
			}
			this.m_ControladorDeGestosDeBoca = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosDeBoca == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosDeBoca", "m_ControladorDeGestosDeBoca null reference.");
			}
			this.m_ControladorDeGestosConHombros = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosConHombros == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosConHombros", "m_ControladorDeGestosConHombros null reference.");
			}
			this.m_ControladorDeGestosConCabeza = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosConCabeza == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosConCabeza", "m_ControladorDeGestosConCabeza null reference.");
			}
			this.m_ControlladorDeGestosFaciales = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeGestosFaciales == null)
			{
				throw new ArgumentNullException("m_ControlladorDeGestosFaciales", "m_ControlladorDeGestosFaciales null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_FemaleCharacterIdleable = this.GetComponentEnRoot(false);
			if (this.m_FemaleCharacterIdleable == null)
			{
				throw new ArgumentNullException("m_FemaleCharacterIdleable", "m_FemaleCharacterIdleable null reference.");
			}
			this.m_hablador = this.GetComponentEnRoot(false);
			if (this.m_hablador == null)
			{
				throw new ArgumentNullException("m_hablador", "m_hablador null reference.");
			}
			this.NoEstaHalando = () => !this.m_hablador.estaHablando;
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x00064409 File Offset: 0x00062609
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(TCalculo calculo)
		{
			return this.probabilidadPorExpresividad;
		}

		// Token: 0x04000EF8 RID: 3832
		public int prioridadParaController = 1;

		// Token: 0x04000EF9 RID: 3833
		public float duracion = 1f;

		// Token: 0x04000EFA RID: 3834
		public float ojosInTiempoMod = 1.75f;

		// Token: 0x04000EFB RID: 3835
		public float ojosOutTiempoMod = 2f;

		// Token: 0x04000EFC RID: 3836
		public float bocaInVelocityMod = 0.1f;

		// Token: 0x04000EFD RID: 3837
		public float bocaOutVelocityMod = 0.2f;

		// Token: 0x04000EFE RID: 3838
		protected Personalidad m_Personalidad;

		// Token: 0x04000EFF RID: 3839
		protected ICharacterHablador m_hablador;

		// Token: 0x04000F00 RID: 3840
		protected Func<bool> NoEstaHalando;

		// Token: 0x04000F01 RID: 3841
		protected IFemaleCharacterIdleable m_FemaleCharacterIdleable;

		// Token: 0x04000F02 RID: 3842
		protected ControladorDeGestosDeBoca m_ControladorDeGestosDeBoca;

		// Token: 0x04000F03 RID: 3843
		protected OjosExpresionController m_OjosExpresionController;

		// Token: 0x04000F04 RID: 3844
		protected ControladorDeGestosConHombros m_ControladorDeGestosConHombros;

		// Token: 0x04000F05 RID: 3845
		protected ControladorDeGestosConCabeza m_ControladorDeGestosConCabeza;

		// Token: 0x04000F06 RID: 3846
		protected ControlladorDeGestosFacialesEmocionales m_ControlladorDeGestosFaciales;
	}
}
