using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ParaReactores.OjosExpresion
{
	// Token: 0x02000302 RID: 770
	public sealed class ParaReactorCerrarOjosAlCoito : ParaReactor
	{
		// Token: 0x06001381 RID: 4993 RVA: 0x0005B266 File Offset: 0x00059466
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0005B624 File Offset: 0x00059824
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Controllador = this.GetComponentEnCharacter(false);
			this.m_Personalidad = this.GetComponentEnCharacter(false);
			this.m_ControladoresBasicosDeFemale = this.GetComponentEnCharacter(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			if (this.m_Controllador == null)
			{
				throw new ArgumentNullException("m_Controllador", "m_Controllador null reference.");
			}
			if (this.m_ControladoresBasicosDeFemale == null)
			{
				throw new ArgumentNullException("m_ControladoresBasicosDeFemale", "m_ControladoresBasicosDeFemale null reference.");
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06001383 RID: 4995 RVA: 0x0005B6B8 File Offset: 0x000598B8
		public float expresividadMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.expresividad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.5f;
				case HumanTraitScore.muyAlto:
					return 2f;
				case HumanTraitScore.bajo:
					return 0.6666667f;
				case HumanTraitScore.muyBajo:
					return 0.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x0005B71F File Offset: 0x0005991F
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return this.expresividadMod;
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x0005B728 File Offset: 0x00059928
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			if (!this.m_ControladoresBasicosDeFemale.bocaController.holeController.hole.isPenetrated && !this.m_ControladoresBasicosDeFemale.vagController.holeController.hole.isPenetrated && !this.m_ControladoresBasicosDeFemale.anusController.holeController.hole.isPenetrated)
			{
				return false;
			}
			Personalidad.Tipo tipo = this.m_Personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
			return tipo != Personalidad.Tipo.pervertido && tipo != Personalidad.Tipo.exhibicionista && this.m_Controllador.Cambiar(OjosExpresionController.Tipo.cerrar, -1, this.m_duracion, ControllerPrioridadConfig.baja, 100f, this.tiempoModIn, this.tiempoModOut);
		}

		// Token: 0x04000E14 RID: 3604
		private OjosExpresionController m_Controllador;

		// Token: 0x04000E15 RID: 3605
		private Personalidad m_Personalidad;

		// Token: 0x04000E16 RID: 3606
		private ControladoresBasicosDeFemale m_ControladoresBasicosDeFemale;

		// Token: 0x04000E17 RID: 3607
		[SerializeField]
		private float m_duracion = 5f;

		// Token: 0x04000E18 RID: 3608
		public float tiempoModIn = 1f;

		// Token: 0x04000E19 RID: 3609
		public float tiempoModOut = 1f;
	}
}
