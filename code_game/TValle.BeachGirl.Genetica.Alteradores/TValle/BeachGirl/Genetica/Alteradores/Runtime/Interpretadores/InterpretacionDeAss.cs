using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000030 RID: 48
	[AplicaAConjuntoDeFisico(para = "buttocks")]
	[Serializable]
	public struct InterpretacionDeAss
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600012D RID: 301 RVA: 0x0000739B File Offset: 0x0000559B
		// (set) Token: 0x0600012E RID: 302 RVA: 0x000073A3 File Offset: 0x000055A3
		[AplicaAConjuntoDeFisico(para = "buttocks", weigth = 20)]
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

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600012F RID: 303 RVA: 0x000073AC File Offset: 0x000055AC
		// (set) Token: 0x06000130 RID: 304 RVA: 0x000073B4 File Offset: 0x000055B4
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

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000131 RID: 305 RVA: 0x000073BD File Offset: 0x000055BD
		// (set) Token: 0x06000132 RID: 306 RVA: 0x000073C5 File Offset: 0x000055C5
		[LabelLocalizado("Anus Gap", "US")]
		public Interpretacion.Size anusGap
		{
			get
			{
				return this.m_anusGap;
			}
			set
			{
				this.m_anusGap = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000133 RID: 307 RVA: 0x000073CE File Offset: 0x000055CE
		// (set) Token: 0x06000134 RID: 308 RVA: 0x000073D6 File Offset: 0x000055D6
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

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000073DF File Offset: 0x000055DF
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000073E7 File Offset: 0x000055E7
		public int sizeValor
		{
			get
			{
				return (int)this.m_size;
			}
			set
			{
				this.m_size = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000073F0 File Offset: 0x000055F0
		// (set) Token: 0x06000138 RID: 312 RVA: 0x000073F8 File Offset: 0x000055F8
		public int projectionValor
		{
			get
			{
				return (int)this.m_projection;
			}
			set
			{
				this.m_projection = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00007401 File Offset: 0x00005601
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00007409 File Offset: 0x00005609
		public int anusGapValor
		{
			get
			{
				return (int)this.m_anusGap;
			}
			set
			{
				this.m_anusGap = (Interpretacion.Size)value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00007412 File Offset: 0x00005612
		// (set) Token: 0x0600013C RID: 316 RVA: 0x0000741A File Offset: 0x0000561A
		public int sagginessValor
		{
			get
			{
				return (int)this.m_sagginess;
			}
			set
			{
				this.m_sagginess = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x0400005C RID: 92
		[SerializeField]
		private Interpretacion.Size m_size;

		// Token: 0x0400005D RID: 93
		[SerializeField]
		private Interpretacion.Capacidad m_projection;

		// Token: 0x0400005E RID: 94
		[SerializeField]
		private Interpretacion.Size m_anusGap;

		// Token: 0x0400005F RID: 95
		[SerializeField]
		private Interpretacion.Capacidad m_sagginess;

		// Token: 0x04000060 RID: 96
		[LabelLocalizado("Difficulty", "US")]
		public SkinDifficulty difficulty;
	}
}
