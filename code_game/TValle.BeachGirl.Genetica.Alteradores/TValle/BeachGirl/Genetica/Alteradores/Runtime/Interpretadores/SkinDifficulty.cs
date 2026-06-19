using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000048 RID: 72
	[PanelLayout(alturaMinima = 290f, alturaPreferida = 290f)]
	[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
	[LayoutConfigUI(height = 20)]
	[Modelo]
	[NestedInterpretacion]
	[Serializable]
	public struct SkinDifficulty
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00008537 File Offset: 0x00006737
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0000853F File Offset: 0x0000673F
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

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00008548 File Offset: 0x00006748
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00008550 File Offset: 0x00006750
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

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00008559 File Offset: 0x00006759
		// (set) Token: 0x0600033D RID: 829 RVA: 0x00008561 File Offset: 0x00006761
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

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0000856A File Offset: 0x0000676A
		// (set) Token: 0x0600033F RID: 831 RVA: 0x00008572 File Offset: 0x00006772
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

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0000857B File Offset: 0x0000677B
		// (set) Token: 0x06000341 RID: 833 RVA: 0x00008583 File Offset: 0x00006783
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

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0000858C File Offset: 0x0000678C
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00008594 File Offset: 0x00006794
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

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000859D File Offset: 0x0000679D
		// (set) Token: 0x06000345 RID: 837 RVA: 0x000085A5 File Offset: 0x000067A5
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

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000346 RID: 838 RVA: 0x000085AE File Offset: 0x000067AE
		// (set) Token: 0x06000347 RID: 839 RVA: 0x000085B6 File Offset: 0x000067B6
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

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000348 RID: 840 RVA: 0x000085BF File Offset: 0x000067BF
		// (set) Token: 0x06000349 RID: 841 RVA: 0x000085C7 File Offset: 0x000067C7
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

		// Token: 0x0400013E RID: 318
		[SerializeField]
		private Interpretacion.Capacidad m_painSensitivity;

		// Token: 0x0400013F RID: 319
		[SerializeField]
		private Interpretacion.Capacidad m_pleasureSensitivity;

		// Token: 0x04000140 RID: 320
		[SerializeField]
		private Interpretacion.Capacidad m_painGain;

		// Token: 0x04000141 RID: 321
		[SerializeField]
		private Interpretacion.Capacidad m_pleasureGain;

		// Token: 0x04000142 RID: 322
		[SerializeField]
		private Interpretacion.Capacidad m_anoyanceGain;

		// Token: 0x04000143 RID: 323
		[SerializeField]
		private Interpretacion.Capacidad m_maxPleasure;

		// Token: 0x04000144 RID: 324
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementVisual;

		// Token: 0x04000145 RID: 325
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementTactile;

		// Token: 0x04000146 RID: 326
		[SerializeField]
		private Interpretacion.Capacidad m_favorabilityRequirementExposure;
	}
}
