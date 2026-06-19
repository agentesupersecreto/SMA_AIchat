using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000046 RID: 70
	[PanelLayout(alturaMinima = 300f, alturaPreferida = 300f)]
	[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
	[LayoutConfigUI(height = 20)]
	[Modelo]
	[NestedInterpretacion]
	[Serializable]
	public struct HoleDifficulty
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00008339 File Offset: 0x00006539
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00008341 File Offset: 0x00006541
		[AplicaAConjuntoDePersonalidad(para = "painTolerance")]
		[LabelLocalizado("Pain Sensitivity", "US")]
		public Interpretacion.Capacidad painSensitivity
		{
			get
			{
				return this.m_painSensitivity;
			}
			set
			{
				this.m_painSensitivity = value;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000834A File Offset: 0x0000654A
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00008352 File Offset: 0x00006552
		[AplicaAConjuntoDePersonalidad(para = "slutness")]
		[LabelLocalizado("Pleasure Sensitivity", "US")]
		public Interpretacion.Capacidad pleasureSensitivity
		{
			get
			{
				return this.m_pleasureSensitivity;
			}
			set
			{
				this.m_pleasureSensitivity = value;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000835B File Offset: 0x0000655B
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00008363 File Offset: 0x00006563
		[AplicaAConjuntoDePersonalidad(para = "painTolerance")]
		[LabelLocalizado("Pain Gain", "US")]
		public Interpretacion.Capacidad painGain
		{
			get
			{
				return this.m_painGain;
			}
			set
			{
				this.m_painGain = value;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000836C File Offset: 0x0000656C
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00008374 File Offset: 0x00006574
		[AplicaAConjuntoDePersonalidad(para = "slutness")]
		[LabelLocalizado("Pleasure Gain", "US")]
		public Interpretacion.Capacidad pleasureGain
		{
			get
			{
				return this.m_pleasureGain;
			}
			set
			{
				this.m_pleasureGain = value;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0000837D File Offset: 0x0000657D
		// (set) Token: 0x06000305 RID: 773 RVA: 0x00008385 File Offset: 0x00006585
		[AplicaAConjuntoDePersonalidad(para = "angerManagement")]
		[LabelLocalizado("Anoyance Gain", "US")]
		public Interpretacion.Capacidad anoyanceGain
		{
			get
			{
				return this.m_anoyanceGain;
			}
			set
			{
				this.m_anoyanceGain = value;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000306 RID: 774 RVA: 0x0000838E File Offset: 0x0000658E
		// (set) Token: 0x06000307 RID: 775 RVA: 0x00008396 File Offset: 0x00006596
		[AplicaAConjuntoDePersonalidad(para = "slutness")]
		[LabelLocalizado("Max Pleasure", "US")]
		public Interpretacion.Capacidad maxPleasure
		{
			get
			{
				return this.m_maxPleasure;
			}
			set
			{
				this.m_maxPleasure = value;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000308 RID: 776 RVA: 0x0000839F File Offset: 0x0000659F
		// (set) Token: 0x06000309 RID: 777 RVA: 0x000083A7 File Offset: 0x000065A7
		[AplicaAConjuntoDePersonalidad(para = "exhibitionism")]
		[LabelLocalizado("Favorability Requirement Visual", "US")]
		public Interpretacion.Capacidad favorabilityRequirementVisual
		{
			get
			{
				return this.m_favorabilityRequirementVisual;
			}
			set
			{
				this.m_favorabilityRequirementVisual = value;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000083B0 File Offset: 0x000065B0
		// (set) Token: 0x0600030B RID: 779 RVA: 0x000083B8 File Offset: 0x000065B8
		[AplicaAConjuntoDePersonalidad(para = "slutness")]
		[LabelLocalizado("Favorability Requirement Tactile", "US")]
		public Interpretacion.Capacidad favorabilityRequirementTactile
		{
			get
			{
				return this.m_favorabilityRequirementTactile;
			}
			set
			{
				this.m_favorabilityRequirementTactile = value;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600030C RID: 780 RVA: 0x000083C1 File Offset: 0x000065C1
		// (set) Token: 0x0600030D RID: 781 RVA: 0x000083C9 File Offset: 0x000065C9
		[AplicaAConjuntoDePersonalidad(para = "exhibitionism")]
		[LabelLocalizado("Favorability Requirement Exposure", "US")]
		public Interpretacion.Capacidad favorabilityRequirementExposure
		{
			get
			{
				return this.m_favorabilityRequirementExposure;
			}
			set
			{
				this.m_favorabilityRequirementExposure = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600030E RID: 782 RVA: 0x000083D2 File Offset: 0x000065D2
		// (set) Token: 0x0600030F RID: 783 RVA: 0x000083DA File Offset: 0x000065DA
		[AplicaAConjuntoDePersonalidad(para = "slutness")]
		[LabelLocalizado("Favorability Requirement Coital", "US")]
		public Interpretacion.Capacidad favorabilityRequirementCoital
		{
			get
			{
				return this.m_favorabilityRequirementCoital;
			}
			set
			{
				this.m_favorabilityRequirementCoital = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000310 RID: 784 RVA: 0x000083E3 File Offset: 0x000065E3
		// (set) Token: 0x06000311 RID: 785 RVA: 0x000083EB File Offset: 0x000065EB
		public int painSensitivityValor
		{
			get
			{
				return (int)this.m_painSensitivity;
			}
			set
			{
				this.m_painSensitivity = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000312 RID: 786 RVA: 0x000083F4 File Offset: 0x000065F4
		// (set) Token: 0x06000313 RID: 787 RVA: 0x000083FC File Offset: 0x000065FC
		public int pleasureSensitivityValor
		{
			get
			{
				return (int)this.m_pleasureSensitivity;
			}
			set
			{
				this.m_pleasureSensitivity = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00008405 File Offset: 0x00006605
		// (set) Token: 0x06000315 RID: 789 RVA: 0x0000840D File Offset: 0x0000660D
		public int painGainValor
		{
			get
			{
				return (int)this.m_painGain;
			}
			set
			{
				this.m_painGain = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00008416 File Offset: 0x00006616
		// (set) Token: 0x06000317 RID: 791 RVA: 0x0000841E File Offset: 0x0000661E
		public int pleasureGainValor
		{
			get
			{
				return (int)this.m_pleasureGain;
			}
			set
			{
				this.m_pleasureGain = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00008427 File Offset: 0x00006627
		// (set) Token: 0x06000319 RID: 793 RVA: 0x0000842F File Offset: 0x0000662F
		public int anoyanceGainValor
		{
			get
			{
				return (int)this.m_anoyanceGain;
			}
			set
			{
				this.m_anoyanceGain = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00008438 File Offset: 0x00006638
		// (set) Token: 0x0600031B RID: 795 RVA: 0x00008440 File Offset: 0x00006640
		public int favorabilityRequirementVisualValor
		{
			get
			{
				return (int)this.m_favorabilityRequirementVisual;
			}
			set
			{
				this.m_favorabilityRequirementVisual = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00008449 File Offset: 0x00006649
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00008451 File Offset: 0x00006651
		public int favorabilityRequirementTactileValor
		{
			get
			{
				return (int)this.m_favorabilityRequirementTactile;
			}
			set
			{
				this.m_favorabilityRequirementTactile = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000845A File Offset: 0x0000665A
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00008462 File Offset: 0x00006662
		public int favorabilityRequirementExposureValor
		{
			get
			{
				return (int)this.m_favorabilityRequirementExposure;
			}
			set
			{
				this.m_favorabilityRequirementExposure = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000320 RID: 800 RVA: 0x0000846B File Offset: 0x0000666B
		// (set) Token: 0x06000321 RID: 801 RVA: 0x00008473 File Offset: 0x00006673
		public int favorabilityRequirementCoitalValor
		{
			get
			{
				return (int)this.m_favorabilityRequirementCoital;
			}
			set
			{
				this.m_favorabilityRequirementCoital = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x04000129 RID: 297
		[SerializeField]
		private Interpretacion.Capacidad m_painSensitivity;

		// Token: 0x0400012A RID: 298
		[SerializeField]
		private Interpretacion.Capacidad m_pleasureSensitivity;

		// Token: 0x0400012B RID: 299
		[SerializeField]
		private Interpretacion.Capacidad m_painGain;

		// Token: 0x0400012C RID: 300
		[SerializeField]
		private Interpretacion.Capacidad m_pleasureGain;

		// Token: 0x0400012D RID: 301
		[SerializeField]
		private Interpretacion.Capacidad m_anoyanceGain;

		// Token: 0x0400012E RID: 302
		[SerializeField]
		private Interpretacion.Capacidad m_maxPleasure;

		// Token: 0x0400012F RID: 303
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementVisual;

		// Token: 0x04000130 RID: 304
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementTactile;

		// Token: 0x04000131 RID: 305
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementExposure;

		// Token: 0x04000132 RID: 306
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementCoital;
	}
}
