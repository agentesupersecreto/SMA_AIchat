using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.Effector;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orgasmo.Effectors
{
	// Token: 0x02000304 RID: 772
	public class ReactorConEffectorAOrgasmo : ReactorConEffector<ICalculoDeEstimulo>
	{
		// Token: 0x0600138F RID: 5007 RVA: 0x0005B9A4 File Offset: 0x00059BA4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DuracionDeOrgasmo = this.GetComponentEnRoot(false);
			if (this.m_DuracionDeOrgasmo == null)
			{
				throw new ArgumentNullException("m_DuracionDeOrgasmo", "m_DuracionDeOrgasmo null reference.");
			}
			this.m_ContraccionesDeOrgasmo = this.GetComponentEnRoot(false);
			if (this.m_ContraccionesDeOrgasmo == null)
			{
				throw new ArgumentNullException("m_ContraccionesDeOrgasmo", "m_ContraccionesDeOrgasmo null reference.");
			}
			HolesControllersCollection componentEnRoot = this.GetComponentEnRoot(false);
			if (!componentEnRoot.isAwaken)
			{
				componentEnRoot.ManualAwake();
			}
			this.m_VagController = componentEnRoot.vagController;
			if (this.m_VagController == null)
			{
				throw new ArgumentNullException("m_VagController", "m_VagController null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x00006C93 File Offset: 0x00004E93
		protected override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.EsOrgasmo();
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x0005BA6C File Offset: 0x00059C6C
		private float ObtenerModPorPersonalidadDeDistancia()
		{
			switch (this.m_Personalidad.GetTraitScore(TraitHumano.orgasmoReaccionDeHips))
			{
			case HumanTraitScore.normal:
				return 1f;
			case HumanTraitScore.alto:
				return 2f;
			case HumanTraitScore.muyAlto:
				return 3f;
			case HumanTraitScore.bajo:
				return 0.5f;
			case HumanTraitScore.muyBajo:
				return 0.33333334f;
			default:
				throw new ArgumentOutOfRangeException(this.m_Personalidad.GetTraitScore(TraitHumano.orgasmoReaccionDeHips).ToString());
			}
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x0005BAE4 File Offset: 0x00059CE4
		protected override bool ReaccionarCalculo(ICalculoDeEstimulo calculo)
		{
			this.effectorConfig.effectorDefaultDuration = (this.effectorConfig.effectorsTipoCoolDownTime = (this.baseConfig.coolDownGeneral = this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo * 0.66f));
			this.effectorConfig.effectorDefaultLocalDistanceRandomRangeModV2 = (this.effectorConfig.effectorDefaultDurationRandomRangeModV2 = 0.1f);
			EffectorsController.Tipo tipo = EffectorsController.Tipo.rightThigh;
			EffectorsController.Tipo? tipo2 = new EffectorsController.Tipo?(EffectorsController.Tipo.leftThigh);
			bool flag;
			bool flag2;
			if (ReactorConEffector<ICalculoDeEstimulo>.TiposEstanAtados(ref tipo, ref tipo2, this.dependencias.interactionEffectorController, out flag, out flag2, this.debugLogEffector))
			{
				return false;
			}
			if (ReactorConEffector<ICalculoDeEstimulo>.TiposEstanEnCoolDown(ref tipo, ref tipo2, this.coolDownPorTipo, this.debugLogEffector))
			{
				return false;
			}
			int maxValue = int.MaxValue;
			if (!ReactorConEffector<ICalculoDeEstimulo>.ControlladorEstaLibre(ref tipo, ref tipo2, maxValue, this.dependencias.effectorsController, true, this.debugLogEffector))
			{
				return false;
			}
			float num = base.ObtenerDistanciaDeEffector() * this.ObtenerModPorPersonalidadDeDistancia() * base.ObtenerDistanciaModPorOxigeno(ReactorConEffector<ICalculoDeEstimulo>.TipoDeOxigeno.ahogamiento);
			num *= this.dependencias.character.escala;
			Vector3 vector = base.ObtenerNormalDelEstimulo(this.m_VagController.holeController.hole.worldOutHoleDirection, tipo, true, true, this.m_normalFixUpMod, this.m_normalFixRightMod).normalized;
			if (this.effectorConfig.invertirNormales)
			{
				vector *= -1f;
			}
			AnimationCurve animationCurve = Singleton<CollecionDeCurvasParaEmocionesReacciones>.instance.ObtenerCurvaMaxValue(calculo.emocion.reaccion);
			animationCurve = animationCurve.MoverHaciaAdelanteConInicialEnZero(0.25f, true, true);
			Keyframe[] array = new Keyframe[Mathf.CeilToInt((float)this.m_ContraccionesDeOrgasmo.currentContraccionesDeOrgasmo * 0.66f) * animationCurve.length];
			float num2 = animationCurve.Duracion();
			for (int i = 0; i < array.Length; i++)
			{
				int num3 = i % animationCurve.length;
				Keyframe keyframe = animationCurve[num3];
				int num4 = Mathf.FloorToInt((float)i / (float)animationCurve.length);
				keyframe.time += num2 * (float)num4;
				array[i] = keyframe;
			}
			float num5 = array.Duracion();
			array.SmoothOut(num5 * this.curvaSmoothOutConfig.startMod, this.curvaSmoothOutConfig.outPower);
			array.Normalizar();
			this.m_curvaUsando = new AnimationCurve(array);
			float num6 = base.ObtenerTiempoDeEffector();
			num6 *= base.ObtenerDuracionModPorOxigeno(ReactorConEffector<ICalculoDeEstimulo>.TipoDeOxigeno.ahogamiento);
			if (this.debugDraw)
			{
				this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo);
				if (tipo2 != null)
				{
					this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo2.Value);
				}
			}
			if (this.debugLogEffector)
			{
				MonoBehaviour.print("-enviando de tipo " + tipo.ToString() + ".");
				if (tipo2 != null)
				{
					MonoBehaviour.print("-enviando de tipo " + tipo2.Value.ToString() + ".");
				}
			}
			bool flag3 = this.dependencias.effectorsController.TryMove(tipo, vector.normalized * num, num6, maxValue, true, this.m_curvaUsando, true, tipo2);
			if (flag3)
			{
				this.coolDownPorTipo.Apply(tipo);
				if (tipo2 != null)
				{
					this.coolDownPorTipo.Apply(tipo2.Value);
				}
			}
			return flag3;
		}

		// Token: 0x04000E20 RID: 3616
		[SerializeField]
		private float m_normalFixUpMod = 0.9f;

		// Token: 0x04000E21 RID: 3617
		[SerializeField]
		private float m_normalFixRightMod = 0.66f;

		// Token: 0x04000E22 RID: 3618
		[SerializeField]
		private AnimationCurve m_curvaUsando;

		// Token: 0x04000E23 RID: 3619
		private Personalidad m_Personalidad;

		// Token: 0x04000E24 RID: 3620
		private VagController m_VagController;

		// Token: 0x04000E25 RID: 3621
		private IContraccionesDeOrgasmo m_ContraccionesDeOrgasmo;

		// Token: 0x04000E26 RID: 3622
		private IDuracionDeOrgasmo m_DuracionDeOrgasmo;

		// Token: 0x04000E27 RID: 3623
		public ReactorConEffectorAOrgasmo.CurvaSmoothOutConfig curvaSmoothOutConfig = new ReactorConEffectorAOrgasmo.CurvaSmoothOutConfig();

		// Token: 0x02000305 RID: 773
		[Serializable]
		public class CurvaSmoothOutConfig
		{
			// Token: 0x04000E28 RID: 3624
			public float outPower = 1f;

			// Token: 0x04000E29 RID: 3625
			public float startMod = 0.5f;
		}
	}
}
