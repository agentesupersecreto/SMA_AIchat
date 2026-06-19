using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000040 RID: 64
	[AplicaAConjuntoDeFisico(para = "breast")]
	[Serializable]
	public struct InterpretacionDeSenos
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00008116 File Offset: 0x00006316
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000811E File Offset: 0x0000631E
		[AplicaAConjuntoDeFisico(para = "breast", weigth = 50)]
		[LabelLocalizado("Size", "US")]
		public Interpretacion.Size size
		{
			get
			{
				return this.m_size;
			}
			set
			{
				this.m_size = value;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00008127 File Offset: 0x00006327
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x0000812F File Offset: 0x0000632F
		[LabelLocalizado("Distance", "US")]
		public Interpretacion.Distance distance
		{
			get
			{
				return this.m_distance;
			}
			set
			{
				this.m_distance = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00008138 File Offset: 0x00006338
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x00008140 File Offset: 0x00006340
		[LabelLocalizado("Projection", "US")]
		public Interpretacion.Capacidad projection
		{
			get
			{
				return this.m_projection;
			}
			set
			{
				this.m_projection = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00008149 File Offset: 0x00006349
		// (set) Token: 0x060002CA RID: 714 RVA: 0x00008151 File Offset: 0x00006351
		[LabelLocalizado("Sagginess", "US")]
		public Interpretacion.Capacidad sagginess
		{
			get
			{
				return this.m_sagginess;
			}
			set
			{
				this.m_sagginess = value;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000815A File Offset: 0x0000635A
		// (set) Token: 0x060002CC RID: 716 RVA: 0x00008162 File Offset: 0x00006362
		[LabelLocalizado("Nipple Size", "US")]
		public Interpretacion.Size nippleSize
		{
			get
			{
				return this.m_nippleSize;
			}
			set
			{
				this.m_nippleSize = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060002CD RID: 717 RVA: 0x0000816B File Offset: 0x0000636B
		// (set) Token: 0x060002CE RID: 718 RVA: 0x00008173 File Offset: 0x00006373
		[LabelLocalizado("Areola Size", "US")]
		public Interpretacion.Size areolaSize
		{
			get
			{
				return this.m_areolaSize;
			}
			set
			{
				this.m_areolaSize = value;
			}
		}

		// Token: 0x04000111 RID: 273
		[SerializeField]
		private Interpretacion.Size m_size;

		// Token: 0x04000112 RID: 274
		[SerializeField]
		private Interpretacion.Capacidad m_projection;

		// Token: 0x04000113 RID: 275
		[SerializeField]
		private Interpretacion.Distance m_distance;

		// Token: 0x04000114 RID: 276
		[SerializeField]
		private Interpretacion.Capacidad m_sagginess;

		// Token: 0x04000115 RID: 277
		[SerializeField]
		private Interpretacion.Size m_nippleSize;

		// Token: 0x04000116 RID: 278
		[SerializeField]
		private Interpretacion.Size m_areolaSize;

		// Token: 0x04000117 RID: 279
		[AplicaAConjuntoDeFisico(para = "breast", weigth = 3)]
		[LabelLocalizado("Nipple Color", "US")]
		public FreeColor nippleColor;

		// Token: 0x04000118 RID: 280
		[LabelLocalizado("Difficulty", "US")]
		public SkinDifficulty difficulty;
	}
}
