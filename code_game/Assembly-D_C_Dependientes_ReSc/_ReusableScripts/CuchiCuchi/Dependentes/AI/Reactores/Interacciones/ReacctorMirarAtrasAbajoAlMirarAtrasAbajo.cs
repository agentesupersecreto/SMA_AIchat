using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000317 RID: 791
	public class ReacctorMirarAtrasAbajoAlMirarAtrasAbajo : ReacctorDeInteracciones<ICalculoDeInteracionEstimulante>
	{
		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06001415 RID: 5141 RVA: 0x0005DF6C File Offset: 0x0005C16C
		public float porFijacionMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.fijacion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.25f;
				case HumanTraitScore.muyAlto:
					return 1.5f;
				case HumanTraitScore.bajo:
					return 0.8f;
				case HumanTraitScore.muyBajo:
					return 0.6666667f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x0005DFD4 File Offset: 0x0005C1D4
		public float porCuriosidadMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.curiosidad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.1f;
				case HumanTraitScore.muyAlto:
					return 1.2f;
				case HumanTraitScore.bajo:
					return 0.9090909f;
				case HumanTraitScore.muyBajo:
					return 0.8333333f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x0005E03C File Offset: 0x0005C23C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_whileDelegate = new Func<Interaccion, Vector3, bool>(this.WhileDelegate);
			this.m_AnimatorCharacter = base.GetComponentInParent<AnimatorCharacter>();
			if (this.m_AnimatorCharacter == null)
			{
				throw new ArgumentNullException("m_AnimatorCharacter", "m_AnimatorCharacter null reference.");
			}
			this.m_Personalidad = this.m_AnimatorCharacter.GetComponentInChildren<Personalidad>();
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_ILookAt = this.m_AnimatorCharacter.GetComponentInChildren<ILookAtIK>();
			if (this.m_ILookAt == null)
			{
				throw new ArgumentNullException("m_ILookAt", "m_ILookAt null reference.");
			}
			this.m_ILookAt.onCambioDeOrientacionHorizontal += this.M_ILookAt_onCambioDeOrientacionHorizontal;
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x0005E0FA File Offset: 0x0005C2FA
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_cambioDeLado = false;
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x0005E109 File Offset: 0x0005C309
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_cambioDeLado = true;
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x0005E119 File Offset: 0x0005C319
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_ILookAt != null)
			{
				this.m_ILookAt.onCambioDeOrientacionHorizontal -= this.M_ILookAt_onCambioDeOrientacionHorizontal;
			}
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x0005E141 File Offset: 0x0005C341
		protected override bool CalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			return base.CalculoEsValido(calculo) && this.m_ILookAt.estaMirando && calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida;
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x0005E16D File Offset: 0x0005C36D
		protected override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			return 1f / this.porCuriosidadMod;
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x0005E17C File Offset: 0x0005C37C
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			float num = 1f;
			if (calculo.estimuloBasico.tipoDeEstimulo.EsIntercambioCoital())
			{
				num = this.modProbPorCoito;
			}
			else if (calculo.estimuloBasico.tipoDeEstimulo.EsIntercambioFisico())
			{
				num = this.modProbPorToque;
			}
			return this.porCuriosidadMod * this.porFijacionMod * num;
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x0005E1D2 File Offset: 0x0005C3D2
		private bool WhileDelegate(Interaccion interaccion, Vector3 posicionGlobalDelEstimulo)
		{
			if (!this.m_ILookAt.estaMirando)
			{
				return false;
			}
			this.UpdateScoreV2(this.m_ILookAt.mirandoWorldPosition, 1.1f);
			return this.ScoreEsValido() && !this.CambioDeLado();
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x0005E210 File Offset: 0x0005C410
		private void UpdateScoreV2(Vector3 puntoObservadoPorHeroina, float scoreMods)
		{
			Vector3 vector = Vector3.Lerp(this.m_AnimatorCharacter.bones.chest.posicionFinal, this.m_AnimatorCharacter.bones.neck.posicionFinal, 0.666f);
			Vector3 vector2 = vector - puntoObservadoPorHeroina;
			Quaternion currentWorldRotation = this.m_AnimatorCharacter.bones.chest.currentWorldRotation;
			if (this.m_PorDetrasAbajoScore.debugDrawHorizontal || this.m_PorDetrasAbajoScore.debugDrawVertical)
			{
				this.m_PorDetrasAbajoScore.SetDebugDrawData(0.333f, vector);
			}
			this.m_PorDetrasAbajoScore.Update(currentWorldRotation, vector2, scoreMods);
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x0005E2A9 File Offset: 0x0005C4A9
		private bool ScoreEsValido()
		{
			return this.m_PorDetrasAbajoScore.esScoreRange && this.m_PorDetrasAbajoScore.esPorDetras && this.m_PorDetrasAbajoScore.esPorAbajo;
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0005E2D2 File Offset: 0x0005C4D2
		private bool CambioDeLado()
		{
			return this.m_cambioDeLado;
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x0005E2DA File Offset: 0x0005C4DA
		private void M_ILookAt_onCambioDeOrientacionHorizontal(ILookAtIK sender)
		{
			if (this.m_InteractuandoIzquierda != sender.estaMirandoIzquierda)
			{
				this.m_cambioDeLado = true;
			}
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x0005E2F4 File Offset: 0x0005C4F4
		protected override bool ReaccionarCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			GlobalUpdater.UpdateType? currentEvent = GlobalUpdater.instancia.currentEvent;
			if (currentEvent == null)
			{
				throw new NotSupportedException();
			}
			this.UpdateScoreV2(this.m_ILookAt.mirandoWorldPosition, 1f);
			if (!this.ScoreEsValido())
			{
				return false;
			}
			this.m_InteractuandoIzquierda = this.m_ILookAt.estaMirandoIzquierda;
			InteraccionSegundariaName interaccionSegundariaName;
			if (this.m_InteractuandoIzquierda)
			{
				interaccionSegundariaName = InteraccionSegundariaName.mirarAtrasAbajoIzquierda;
			}
			else
			{
				interaccionSegundariaName = InteraccionSegundariaName.mirarAtrasAbajoDerecha;
			}
			this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(interaccionSegundariaName, out this.m_Interacting);
			if (this.m_Interacting == null)
			{
				return false;
			}
			int num = ReactorSegundario.PrioridadParcer(calculo, 1.0);
			return this.m_Interacting.EjecutarWhile<Vector3>(currentEvent.Value, Vector3.zero, this.m_whileDelegate, 0.333f, num, this.duracion.Random(0.1f) * this.porFijacionMod, ControllerPrioridadConfig.prioridad, 1f);
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x0005E3D4 File Offset: 0x0005C5D4
		protected override void Reaccionado(bool resultado)
		{
			base.Reaccionado(resultado);
			if (resultado)
			{
				this.m_cambioDeLado = false;
				return;
			}
			this.m_Interacting = null;
		}

		// Token: 0x04000E6C RID: 3692
		private AnimatorCharacter m_AnimatorCharacter;

		// Token: 0x04000E6D RID: 3693
		private Personalidad m_Personalidad;

		// Token: 0x04000E6E RID: 3694
		public float modProbPorToque = 3f;

		// Token: 0x04000E6F RID: 3695
		public float modProbPorCoito = 4f;

		// Token: 0x04000E70 RID: 3696
		public float duracion = 10f;

		// Token: 0x04000E71 RID: 3697
		[Obsolete]
		[Range(0f, 1f)]
		public float scoreParCambiarDeLado = 0.2f;

		// Token: 0x04000E72 RID: 3698
		[Obsolete]
		private bool m_puedeElegirLadoLibremente = true;

		// Token: 0x04000E73 RID: 3699
		[ReadOnlyUI]
		[SerializeField]
		private bool m_InteractuandoIzquierda;

		// Token: 0x04000E74 RID: 3700
		[ReadOnlyUI]
		[SerializeField]
		private bool m_cambioDeLado;

		// Token: 0x04000E75 RID: 3701
		[ReadOnlyUI]
		[SerializeField]
		private Interaccion m_Interacting;

		// Token: 0x04000E76 RID: 3702
		[SerializeField]
		private VisionScore m_PorDetrasAbajoScore = new VisionScore();

		// Token: 0x04000E77 RID: 3703
		private Func<Interaccion, Vector3, bool> m_whileDelegate;

		// Token: 0x04000E78 RID: 3704
		private ILookAtIK m_ILookAt;
	}
}
