using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002E6 RID: 742
	public abstract class AutoSexPosibilidadScore : CustomMonobehaviour
	{
		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x060012C8 RID: 4808
		public abstract ParteQuePuedeEstimular paraParte { get; }

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x060012C9 RID: 4809
		public abstract IHole paraHole { get; }

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x060012CA RID: 4810 RVA: 0x00059BEE File Offset: 0x00057DEE
		public AutoSexPosibilidadScore.Resultados resultados
		{
			get
			{
				return this.m_Resultados;
			}
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x00059BF6 File Offset: 0x00057DF6
		public static float GetScore(float scorePorDeseo, float scorePorEmocion, float scorePorPersonalidad)
		{
			return (scorePorDeseo * 6f + scorePorEmocion + scorePorPersonalidad) / 8f;
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x00059C09 File Offset: 0x00057E09
		[Obsolete("", true)]
		public static float GetScorePorDeseo(float deseo, float deseoParaScorePositvo)
		{
			return MathfExtension.InverseLerpPolarizado(0f, deseoParaScorePositvo, 1f, deseo);
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x00059C1C File Offset: 0x00057E1C
		public static float GetScorePorDeseoPercentage(float deseo, float deseoParaScorePositvo, float deseoParaScoreNegativo)
		{
			if (deseo <= -100f)
			{
				return -1f;
			}
			if (deseo >= 100f)
			{
				return 1f;
			}
			if (deseo > deseoParaScoreNegativo && deseo < deseoParaScorePositvo)
			{
				return 0f;
			}
			if (deseo <= deseoParaScoreNegativo)
			{
				return Mathf.Lerp(-1f, 0f, Mathf.InverseLerp(-100f, deseoParaScoreNegativo, deseo));
			}
			if (deseo >= deseoParaScorePositvo)
			{
				return Mathf.Lerp(0f, 1f, Mathf.InverseLerp(deseoParaScorePositvo, 100f, deseo));
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x00059C98 File Offset: 0x00057E98
		public static float GetScorePorEmocion(ReaccionHumana reaccion)
		{
			return (float)(reaccion.EsPositiva() ? 1 : (-1));
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x00059CA8 File Offset: 0x00057EA8
		public static float GetScorePorPersonalidad(Personalidad m_Personalidad)
		{
			float num;
			switch (m_Personalidad.GetTraitScore(TraitHumano.fijacion))
			{
			case HumanTraitScore.normal:
				num = 1f;
				break;
			case HumanTraitScore.alto:
				num = 1.5f;
				break;
			case HumanTraitScore.muyAlto:
				num = 2f;
				break;
			case HumanTraitScore.bajo:
				num = 0.5f;
				break;
			case HumanTraitScore.muyBajo:
				num = 0f;
				break;
			default:
				throw new ArgumentOutOfRangeException("Score Not found");
			}
			float num2;
			switch (m_Personalidad.GetTraitScore(TraitHumano.curiosidad))
			{
			case HumanTraitScore.normal:
				num2 = 1f;
				break;
			case HumanTraitScore.alto:
				num2 = 1.5f;
				break;
			case HumanTraitScore.muyAlto:
				num2 = 2f;
				break;
			case HumanTraitScore.bajo:
				num2 = 0.5f;
				break;
			case HumanTraitScore.muyBajo:
				num2 = 0f;
				break;
			default:
				throw new ArgumentOutOfRangeException("Score Not found");
			}
			float num3 = MathfExtension.LerpConMedio(0f, -1f, -3f, m_Personalidad.timidez);
			return Mathf.Clamp(num + num2 + num3, -1f, 1f);
		}

		// Token: 0x04000D9D RID: 3485
		[SerializeField]
		protected AutoSexPosibilidadScore.Resultados m_Resultados = new AutoSexPosibilidadScore.Resultados();

		// Token: 0x04000D9E RID: 3486
		[SerializeField]
		protected AutoSexPosibilidadScore.Config m_Config = new AutoSexPosibilidadScore.Config();

		// Token: 0x020002E7 RID: 743
		[Serializable]
		public class Config
		{
			// Token: 0x04000D9F RID: 3487
			[Obsolete("", true)]
			public bool tipPuedeSerTarget;

			// Token: 0x04000DA0 RID: 3488
			public float minWeight = 0.75f;

			// Token: 0x04000DA1 RID: 3489
			[Range(-1f, -0.333f)]
			public float maxScoreAtNoConsent = -0.333f;

			// Token: 0x04000DA2 RID: 3490
			[Obsolete("", true)]
			[NonSerialized]
			public float maxScoreAtMuyEstrecho = -0.333f;

			// Token: 0x04000DA3 RID: 3491
			[Tooltip("Mientras mas flacido, mas intenta mirar la base del pene")]
			public float elegirTargetSegunEreccionPower = 2f;

			// Token: 0x04000DA4 RID: 3492
			[Obsolete]
			[NonSerialized]
			public float anguloHorizontalParaCambiarDeLado = 50f;

			// Token: 0x04000DA5 RID: 3493
			[Range(0f, 1f)]
			public float minProyection = 0.333f;

			// Token: 0x04000DA6 RID: 3494
			[Range(0f, 1f)]
			public float maxProyection = 1f;

			// Token: 0x04000DA7 RID: 3495
			public float proyectionOutPower = 2f;

			// Token: 0x04000DA8 RID: 3496
			[Obsolete]
			[NonSerialized]
			public float anguloVerticalDeEvacion;

			// Token: 0x04000DA9 RID: 3497
			[Obsolete]
			[NonSerialized]
			public float anguloHorizontalDeEvacion = 60f;

			// Token: 0x04000DAA RID: 3498
			public float evacionOutPowerV2 = 3f;
		}

		// Token: 0x020002E8 RID: 744
		[Serializable]
		public class Resultados
		{
			// Token: 0x04000DAB RID: 3499
			public AutoSexPosibilidadScore.Thresholds thresholds;

			// Token: 0x04000DAC RID: 3500
			public bool penetracionEsConsentida;

			// Token: 0x04000DAD RID: 3501
			public bool muyEstrecho;

			// Token: 0x04000DAE RID: 3502
			public float muyEstrechoOffsetMod;

			// Token: 0x04000DAF RID: 3503
			[Range(-1f, 1f)]
			public float scoreByDesires;

			// Token: 0x04000DB0 RID: 3504
			[Range(-1f, 1f)]
			public float scoreV2;

			// Token: 0x04000DB1 RID: 3505
			[Range(0f, 1f)]
			public float weightV2;

			// Token: 0x04000DB2 RID: 3506
			public float weightModV2;

			// Token: 0x04000DB3 RID: 3507
			[Obsolete("", true)]
			[NonSerialized]
			public float score;

			// Token: 0x04000DB4 RID: 3508
			[Obsolete("", true)]
			[NonSerialized]
			public float scorePorDeseo;

			// Token: 0x04000DB5 RID: 3509
			[Obsolete("", true)]
			[NonSerialized]
			public float scorePorEmocion;

			// Token: 0x04000DB6 RID: 3510
			[Obsolete("", true)]
			[NonSerialized]
			public float scorePorPersonalidad;

			// Token: 0x04000DB7 RID: 3511
			public Transform targetParte;

			// Token: 0x04000DB8 RID: 3512
			public Vector3 targetLocalOffset;

			// Token: 0x04000DB9 RID: 3513
			public int indexDeParte;

			// Token: 0x04000DBA RID: 3514
			public float distanceToTarget;

			// Token: 0x04000DBB RID: 3515
			public float distanceToBase;

			// Token: 0x04000DBC RID: 3516
			public bool algunaParteEnElPlano;

			// Token: 0x04000DBD RID: 3517
			public float proyection;

			// Token: 0x04000DBE RID: 3518
			public bool evadingEsPositivo;

			// Token: 0x04000DBF RID: 3519
			public Vector3 anglesOffsets;
		}

		// Token: 0x020002E9 RID: 745
		[Serializable]
		public struct Thresholds
		{
			// Token: 0x060012D3 RID: 4819 RVA: 0x00059E34 File Offset: 0x00058034
			public static AutoSexPosibilidadScore.Thresholds Producir(HumanTraitScore trait)
			{
				switch (trait)
				{
				case HumanTraitScore.normal:
					return AutoSexPosibilidadScore.Thresholds.normal;
				case HumanTraitScore.alto:
					return AutoSexPosibilidadScore.Thresholds.alto;
				case HumanTraitScore.muyAlto:
					return AutoSexPosibilidadScore.Thresholds.muyAlto;
				case HumanTraitScore.bajo:
					return AutoSexPosibilidadScore.Thresholds.bajo;
				case HumanTraitScore.muyBajo:
					return AutoSexPosibilidadScore.Thresholds.muyBajo;
				default:
					throw new ArgumentOutOfRangeException(trait.ToString());
				}
			}

			// Token: 0x04000DC0 RID: 3520
			private static AutoSexPosibilidadScore.Thresholds muyAlto = new AutoSexPosibilidadScore.Thresholds
			{
				scoreParaAsistencia = 0.15f,
				scoreParaConstantAsistencia = 0.4f,
				scoreMinParaAutoSex = 0.33f,
				scoreMaxParaAutoSex = 0.425f
			};

			// Token: 0x04000DC1 RID: 3521
			private static AutoSexPosibilidadScore.Thresholds alto = new AutoSexPosibilidadScore.Thresholds
			{
				scoreParaAsistencia = 0.22500001f,
				scoreParaConstantAsistencia = 0.6f,
				scoreMinParaAutoSex = 0.495f,
				scoreMaxParaAutoSex = 0.63750005f
			};

			// Token: 0x04000DC2 RID: 3522
			private static AutoSexPosibilidadScore.Thresholds normal = new AutoSexPosibilidadScore.Thresholds
			{
				scoreParaAsistencia = 0.3f,
				scoreParaConstantAsistencia = 0.8f,
				scoreMinParaAutoSex = 0.66f,
				scoreMaxParaAutoSex = 0.85f
			};

			// Token: 0x04000DC3 RID: 3523
			private static AutoSexPosibilidadScore.Thresholds bajo = new AutoSexPosibilidadScore.Thresholds
			{
				scoreParaAsistencia = 0.33f,
				scoreParaConstantAsistencia = 0.88000005f,
				scoreMinParaAutoSex = 0.7260001f,
				scoreMaxParaAutoSex = 0.93500006f
			};

			// Token: 0x04000DC4 RID: 3524
			private static AutoSexPosibilidadScore.Thresholds muyBajo = new AutoSexPosibilidadScore.Thresholds
			{
				scoreParaAsistencia = 0.36f,
				scoreParaConstantAsistencia = 1f,
				scoreMinParaAutoSex = 0.79200006f,
				scoreMaxParaAutoSex = 1f
			};

			// Token: 0x04000DC5 RID: 3525
			public float scoreParaAsistencia;

			// Token: 0x04000DC6 RID: 3526
			public float scoreParaConstantAsistencia;

			// Token: 0x04000DC7 RID: 3527
			public float scoreMinParaAutoSex;

			// Token: 0x04000DC8 RID: 3528
			public float scoreMaxParaAutoSex;
		}
	}
}
