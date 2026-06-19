using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200003F RID: 63
	[AplicaAConjuntoDeFisico(para = "face")]
	[Serializable]
	public struct InterpretacionDeRostro
	{
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x0000808E File Offset: 0x0000628E
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x00008096 File Offset: 0x00006296
		[LabelLocalizado("Collapse", "US")]
		public Interpretacion.Capacidad collapse
		{
			get
			{
				return this.m_facialCollapse;
			}
			set
			{
				this.m_facialCollapse = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x0000809F File Offset: 0x0000629F
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x000080A7 File Offset: 0x000062A7
		[AplicaAConjuntoDeFisico(para = "face", weigth = 10)]
		[LabelLocalizado("Aging", "US")]
		public Interpretacion.Capacidad aging
		{
			get
			{
				return this.m_facialAging;
			}
			set
			{
				this.m_facialAging = value;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x000080B0 File Offset: 0x000062B0
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x000080B8 File Offset: 0x000062B8
		[AplicaAConjuntoDeFisico(para = "face", weigth = 50)]
		[LabelLocalizado("Thickness", "US")]
		public Interpretacion.Thickness thickness
		{
			get
			{
				return this.m_faceThickness;
			}
			set
			{
				this.m_faceThickness = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x000080C1 File Offset: 0x000062C1
		// (set) Token: 0x060002BA RID: 698 RVA: 0x000080C9 File Offset: 0x000062C9
		[AplicaAConjuntoDeFisico(para = "face", weigth = 50)]
		[LabelLocalizado("Square Shape", "US")]
		public Interpretacion.Capacidad square
		{
			get
			{
				return this.m_square;
			}
			set
			{
				this.m_square = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000080D2 File Offset: 0x000062D2
		// (set) Token: 0x060002BC RID: 700 RVA: 0x000080DA File Offset: 0x000062DA
		[AplicaAConjuntoDeFisico(para = "face", weigth = 50)]
		[LabelLocalizado("Heart Shape", "US")]
		public Interpretacion.Capacidad heart
		{
			get
			{
				return this.m_heart;
			}
			set
			{
				this.m_heart = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060002BD RID: 701 RVA: 0x000080E3 File Offset: 0x000062E3
		// (set) Token: 0x060002BE RID: 702 RVA: 0x000080EB File Offset: 0x000062EB
		[AplicaAConjuntoDeFisico(para = "face", weigth = 50)]
		[LabelLocalizado("Round Shape", "US")]
		public Interpretacion.Capacidad round
		{
			get
			{
				return this.m_round;
			}
			set
			{
				this.m_round = value;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000080F4 File Offset: 0x000062F4
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x000080FC File Offset: 0x000062FC
		[AplicaAConjuntoDeFisico(para = "head")]
		[LabelLocalizado("Forehead Size", "US")]
		public Interpretacion.CantidadNoContable foreHeadWidth
		{
			get
			{
				return this.m_foreHeadWidth;
			}
			set
			{
				this.m_foreHeadWidth = value;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00008105 File Offset: 0x00006305
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x0000810D File Offset: 0x0000630D
		[AplicaAConjuntoDeFisico(para = "head")]
		[LabelLocalizado("Forehead Size", "US")]
		public Interpretacion.CantidadNoContable foreHeadProjection
		{
			get
			{
				return this.m_foreHeadProjection;
			}
			set
			{
				this.m_foreHeadProjection = value;
			}
		}

		// Token: 0x04000109 RID: 265
		[SerializeField]
		private Interpretacion.Capacidad m_facialCollapse;

		// Token: 0x0400010A RID: 266
		[SerializeField]
		private Interpretacion.Capacidad m_facialAging;

		// Token: 0x0400010B RID: 267
		[SerializeField]
		private Interpretacion.Thickness m_faceThickness;

		// Token: 0x0400010C RID: 268
		[SerializeField]
		private Interpretacion.Capacidad m_square;

		// Token: 0x0400010D RID: 269
		[SerializeField]
		private Interpretacion.Capacidad m_heart;

		// Token: 0x0400010E RID: 270
		[SerializeField]
		private Interpretacion.Capacidad m_round;

		// Token: 0x0400010F RID: 271
		[SerializeField]
		private Interpretacion.CantidadNoContable m_foreHeadWidth;

		// Token: 0x04000110 RID: 272
		[SerializeField]
		private Interpretacion.CantidadNoContable m_foreHeadProjection;
	}
}
