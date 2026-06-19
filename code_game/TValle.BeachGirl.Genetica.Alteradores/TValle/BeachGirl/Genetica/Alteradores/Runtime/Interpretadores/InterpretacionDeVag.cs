using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000041 RID: 65
	[AplicaAConjuntoDeFisico(para = "crotch")]
	[Serializable]
	public struct InterpretacionDeVag
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060002CF RID: 719 RVA: 0x0000817C File Offset: 0x0000637C
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x00008184 File Offset: 0x00006384
		[LabelLocalizado("Lips Opening", "US")]
		public Interpretacion.Opening lipsOpening
		{
			get
			{
				return this.m_lipsOpening;
			}
			set
			{
				this.m_lipsOpening = value;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000818D File Offset: 0x0000638D
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x00008195 File Offset: 0x00006395
		[LabelLocalizado("Outer Labia Thickness", "US")]
		public Interpretacion.Thickness outerLabiaThickness
		{
			get
			{
				return this.m_outerLabiaThickness;
			}
			set
			{
				this.m_outerLabiaThickness = value;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x0000819E File Offset: 0x0000639E
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x000081A6 File Offset: 0x000063A6
		[LabelLocalizado("Outer Labia Fat", "US")]
		public Interpretacion.Capacidad outerLabiaFat
		{
			get
			{
				return this.m_outerLabiaFat;
			}
			set
			{
				this.m_outerLabiaFat = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000081AF File Offset: 0x000063AF
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x000081B7 File Offset: 0x000063B7
		[LabelLocalizado("Clit Length", "US")]
		public Interpretacion.Length clitLength
		{
			get
			{
				return this.m_clitLength;
			}
			set
			{
				this.m_clitLength = value;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x000081C0 File Offset: 0x000063C0
		// (set) Token: 0x060002D8 RID: 728 RVA: 0x000081C8 File Offset: 0x000063C8
		[LabelLocalizado("Clit Extrude", "US")]
		public Interpretacion.CantidadNoContable clitExtrude
		{
			get
			{
				return this.m_clitExtrude;
			}
			set
			{
				this.m_clitExtrude = value;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x000081D1 File Offset: 0x000063D1
		// (set) Token: 0x060002DA RID: 730 RVA: 0x000081D9 File Offset: 0x000063D9
		[LabelLocalizado("Inner Labia Thickness", "US")]
		public Interpretacion.Thickness innerLabiaThickness
		{
			get
			{
				return this.m_innerLabiaThickness;
			}
			set
			{
				this.m_innerLabiaThickness = value;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060002DB RID: 731 RVA: 0x000081E2 File Offset: 0x000063E2
		// (set) Token: 0x060002DC RID: 732 RVA: 0x000081EA File Offset: 0x000063EA
		[AplicaAConjuntoDeFisico(para = "crotch", weigth = 5)]
		[LabelLocalizado("Depth", "US")]
		public Interpretacion.HoleDepth profundidad
		{
			get
			{
				return this.m_vaginalProfundidad;
			}
			set
			{
				this.m_vaginalProfundidad = value;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060002DD RID: 733 RVA: 0x000081F3 File Offset: 0x000063F3
		// (set) Token: 0x060002DE RID: 734 RVA: 0x000081FB File Offset: 0x000063FB
		[AplicaAConjuntoDeFisico(para = "crotch", weigth = 5)]
		[LabelLocalizado("Tightness", "US")]
		public Interpretacion.Tightness anchura
		{
			get
			{
				return this.m_vaginalAnchura;
			}
			set
			{
				this.m_vaginalAnchura = value;
			}
		}

		// Token: 0x04000119 RID: 281
		[SerializeField]
		private Interpretacion.Opening m_lipsOpening;

		// Token: 0x0400011A RID: 282
		[SerializeField]
		private Interpretacion.Thickness m_outerLabiaThickness;

		// Token: 0x0400011B RID: 283
		[SerializeField]
		private Interpretacion.Capacidad m_outerLabiaFat;

		// Token: 0x0400011C RID: 284
		[SerializeField]
		private Interpretacion.Length m_clitLength;

		// Token: 0x0400011D RID: 285
		[SerializeField]
		private Interpretacion.CantidadNoContable m_clitExtrude;

		// Token: 0x0400011E RID: 286
		[SerializeField]
		private Interpretacion.Thickness m_innerLabiaThickness;

		// Token: 0x0400011F RID: 287
		[SerializeField]
		private Interpretacion.HoleDepth m_vaginalProfundidad;

		// Token: 0x04000120 RID: 288
		[SerializeField]
		private Interpretacion.Tightness m_vaginalAnchura;

		// Token: 0x04000121 RID: 289
		[LabelLocalizado("Difficulty", "US")]
		public HoleDifficulty difficulty;
	}
}
