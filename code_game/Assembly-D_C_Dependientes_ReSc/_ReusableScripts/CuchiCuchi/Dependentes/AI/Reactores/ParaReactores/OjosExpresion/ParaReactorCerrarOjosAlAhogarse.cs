using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ParaReactores.OjosExpresion
{
	// Token: 0x02000301 RID: 769
	public sealed class ParaReactorCerrarOjosAlAhogarse : ParaReactor
	{
		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x0600137A RID: 4986 RVA: 0x0005B46C File Offset: 0x0005966C
		public float expresividadPower
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.expresividad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 3f;
				case HumanTraitScore.alto:
					return 4f;
				case HumanTraitScore.muyAlto:
					return 5f;
				case HumanTraitScore.bajo:
					return 2f;
				case HumanTraitScore.muyBajo:
					return 1f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x0005B4D3 File Offset: 0x000596D3
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.probabilidadPorSegundo = 100f;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x0005B4EC File Offset: 0x000596EC
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_RespiracionEngine = this.GetComponentEnCharacter(false);
			this.m_Controllador = this.GetComponentEnCharacter(false);
			this.m_Personalidad = this.GetComponentEnCharacter(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			if (this.m_Controllador == null)
			{
				throw new ArgumentNullException("m_Controllador", "m_Controllador null reference.");
			}
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x0005B580 File Offset: 0x00059780
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			float ahogadoWeight = this.m_RespiracionEngine.ahogadoWeight;
			if (ahogadoWeight <= 0f)
			{
				return false;
			}
			float num = Mathf.Lerp(0f, 75f, ahogadoWeight.OutPow(this.expresividadPower));
			bool flag = this.m_Controllador.Cambiar(OjosExpresionController.Tipo.cerrar, -1, this.m_duracion, ControllerPrioridadConfig.baja, num, this.tiempoModIn, this.tiempoModOut);
			if (flag)
			{
				this.baseConfig.coolDownGeneral = this.m_duracion * 0.05f;
			}
			return flag;
		}

		// Token: 0x04000E0E RID: 3598
		private OjosExpresionController m_Controllador;

		// Token: 0x04000E0F RID: 3599
		private Personalidad m_Personalidad;

		// Token: 0x04000E10 RID: 3600
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000E11 RID: 3601
		public float tiempoModIn = 5f;

		// Token: 0x04000E12 RID: 3602
		public float tiempoModOut = 5f;

		// Token: 0x04000E13 RID: 3603
		[SerializeField]
		private float m_duracion = 10f;
	}
}
