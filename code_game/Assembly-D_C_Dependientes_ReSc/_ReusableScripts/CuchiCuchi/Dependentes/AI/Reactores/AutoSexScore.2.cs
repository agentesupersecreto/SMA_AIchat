using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores
{
	// Token: 0x020002EB RID: 747
	public abstract class AutoSexScore : CustomMonobehaviour
	{
		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x060012DF RID: 4831
		public abstract ParteQuePuedeEstimular paraParte { get; }

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x060012E0 RID: 4832
		public abstract IHole paraHole { get; }

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x0005A340 File Offset: 0x00058540
		public AutoSexScore.Resultados resultados
		{
			get
			{
				return this.m_Resultados;
			}
		}

		// Token: 0x04000DCF RID: 3535
		[SerializeField]
		protected AutoSexScore.Resultados m_Resultados = new AutoSexScore.Resultados();

		// Token: 0x04000DD0 RID: 3536
		[SerializeField]
		protected AutoSexScore.Config m_Config = new AutoSexScore.Config();

		// Token: 0x020002EC RID: 748
		[Serializable]
		public class Config
		{
			// Token: 0x04000DD1 RID: 3537
			[Range(-1f, -0.333f)]
			public float maxScoreAtNoConsent = -0.333f;

			// Token: 0x04000DD2 RID: 3538
			[Obsolete("", true)]
			[NonSerialized]
			public float maxScoreAtMuyEstrecho = -0.333f;

			// Token: 0x04000DD3 RID: 3539
			[Range(0f, 1f)]
			public float minProyection;

			// Token: 0x04000DD4 RID: 3540
			[Range(0f, 1f)]
			public float maxProyection = 0.6f;

			// Token: 0x04000DD5 RID: 3541
			public float proyectionOutPower = 2f;
		}

		// Token: 0x020002ED RID: 749
		[Serializable]
		public class Resultados
		{
			// Token: 0x04000DD6 RID: 3542
			public AutoSexPosibilidadScore.Thresholds thresholds;

			// Token: 0x04000DD7 RID: 3543
			public bool penetracionEsConsentida;

			// Token: 0x04000DD8 RID: 3544
			public bool muyEstrecho;

			// Token: 0x04000DD9 RID: 3545
			public float muyEstrechoOffsetMod;

			// Token: 0x04000DDA RID: 3546
			[Range(-1f, 1f)]
			public float scoreByDesires;

			// Token: 0x04000DDB RID: 3547
			[Range(-1f, 1f)]
			public float scoreV2;

			// Token: 0x04000DDC RID: 3548
			[Range(0f, 1f)]
			public float weightTeasing;

			// Token: 0x04000DDD RID: 3549
			[Obsolete("", true)]
			[NonSerialized]
			public float score;

			// Token: 0x04000DDE RID: 3550
			[Obsolete("", true)]
			[NonSerialized]
			public float scorePorDeseo;

			// Token: 0x04000DDF RID: 3551
			[Obsolete("", true)]
			[NonSerialized]
			public float scorePorEmocion;

			// Token: 0x04000DE0 RID: 3552
			[Obsolete("", true)]
			[NonSerialized]
			public float scorePorPersonalidad;

			// Token: 0x04000DE1 RID: 3553
			public Transform targetTransform;

			// Token: 0x04000DE2 RID: 3554
			public float distanceToTarget;

			// Token: 0x04000DE3 RID: 3555
			public float proyection;
		}
	}
}
