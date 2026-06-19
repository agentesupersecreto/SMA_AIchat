using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ConAnimator
{
	// Token: 0x02000353 RID: 851
	public class ReactorDeActivarPoseIdleEmocionAlSerEstiualada : ReactorACalculoDeEstimulo<ICalculoDeInteracionEstimulante>
	{
		// Token: 0x06001555 RID: 5461 RVA: 0x00065748 File Offset: 0x00063948
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SimpleFemalePoseLoader = this.GetComponentEnRoot(false);
			if (this.m_SimpleFemalePoseLoader == null)
			{
				throw new ArgumentNullException("m_SimpleFemalePoseLoader", "m_SimpleFemalePoseLoader null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_corutina = new CoroutineCapsule(this.SetPoseIdleValorRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x000657D6 File Offset: 0x000639D6
		protected override bool CalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			return calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida;
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			return 1f;
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			return 1f;
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x000657E8 File Offset: 0x000639E8
		protected override bool ReaccionarCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			float weigthDeScore = this.m_Personalidad.GetTraitScore(TraitHumano.expresividad).GetWeigthDeScore();
			float num = Mathf.Lerp(0.6666f, 1.5f, weigthDeScore);
			float num2;
			float num3;
			switch (calculo.estimuloBasico.tipoDeEstimulo.GetTipoBasico())
			{
			case TipoDeEstimuloBasico.visual:
				num2 = 0.5f;
				num3 = 0.5f;
				goto IL_00B0;
			case TipoDeEstimuloBasico.verbal:
				num2 = 0.75f;
				num3 = 0.75f;
				goto IL_00B0;
			case TipoDeEstimuloBasico.tactil:
				num2 = 1f;
				num3 = 1f;
				goto IL_00B0;
			case TipoDeEstimuloBasico.coital:
				num2 = 1.5f;
				num3 = 1f;
				goto IL_00B0;
			}
			throw new ArgumentOutOfRangeException(calculo.estimuloBasico.tipoDeEstimulo.GetTipoBasico().ToString());
			IL_00B0:
			float num4 = this.duracion * num * num2;
			this.m_timeLeft = Mathf.Max(this.m_timeLeft, num4);
			this.m_targetWeight = num3;
			return true;
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x000658CC File Offset: 0x00063ACC
		private IEnumerator SetPoseIdleValorRutine()
		{
			for (;;)
			{
				yield return null;
				this.m_timeLeft -= Time.deltaTime;
				if (this.m_timeLeft <= 0f)
				{
					this.m_timeLeft = 0f;
					this.m_targetWeight = 0f;
				}
				if (this.m_currentWeight > this.m_targetWeight)
				{
					this.m_currentWeight = Mathf.SmoothDamp(this.m_currentWeight, this.m_targetWeight, ref this.m_vel, 1f);
				}
				else
				{
					this.m_currentWeight = Mathf.SmoothDamp(this.m_currentWeight, this.m_targetWeight, ref this.m_vel, 0.2f);
				}
				this.m_SimpleFemalePoseLoader.animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.PoseEstimuladaWeight, this.m_currentWeight);
			}
			yield break;
		}

		// Token: 0x04000F1C RID: 3868
		private CoroutineCapsule m_corutina;

		// Token: 0x04000F1D RID: 3869
		private SimpleFemalePoseLoader m_SimpleFemalePoseLoader;

		// Token: 0x04000F1E RID: 3870
		private Personalidad m_Personalidad;

		// Token: 0x04000F1F RID: 3871
		public float duracion = 10f;

		// Token: 0x04000F20 RID: 3872
		[SerializeField]
		[ReadOnlyUI]
		private float m_timeLeft;

		// Token: 0x04000F21 RID: 3873
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentWeight;

		// Token: 0x04000F22 RID: 3874
		[SerializeField]
		[ReadOnlyUI]
		private float m_targetWeight;

		// Token: 0x04000F23 RID: 3875
		[NonSerialized]
		private float m_vel;
	}
}
