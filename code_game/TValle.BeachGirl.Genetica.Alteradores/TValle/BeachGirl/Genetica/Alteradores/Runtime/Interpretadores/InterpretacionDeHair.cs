using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000038 RID: 56
	[AplicaAConjuntoDeFisico(para = "hair")]
	[Serializable]
	public struct InterpretacionDeHair
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00007A50 File Offset: 0x00005C50
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00007A58 File Offset: 0x00005C58
		[AplicaAConjuntoDeFisico(para = "hair", weigth = 100)]
		[LabelLocalizado("Length", "US")]
		public Interpretacion.Length length
		{
			get
			{
				return this.m_length;
			}
			set
			{
				this.m_length = value;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00007A61 File Offset: 0x00005C61
		// (set) Token: 0x060001FA RID: 506 RVA: 0x00007A69 File Offset: 0x00005C69
		[LabelLocalizado("Volume", "US")]
		public Interpretacion.Capacidad volume
		{
			get
			{
				return this.m_volume;
			}
			set
			{
				this.m_volume = value;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00007A72 File Offset: 0x00005C72
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00007A7A File Offset: 0x00005C7A
		[AplicaAConjuntoDeFisico(para = "hair", weigth = 10)]
		[LabelLocalizado("Curls", "US")]
		public Interpretacion.Capacidad curls
		{
			get
			{
				return this.m_curls;
			}
			set
			{
				this.m_curls = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00007A83 File Offset: 0x00005C83
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00007A8B File Offset: 0x00005C8B
		public int lengthValor
		{
			get
			{
				return (int)this.m_length;
			}
			set
			{
				this.m_length = (Interpretacion.Length)value;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00007A94 File Offset: 0x00005C94
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00007A9C File Offset: 0x00005C9C
		public int volumeValor
		{
			get
			{
				return (int)this.m_volume;
			}
			set
			{
				this.m_volume = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00007AA5 File Offset: 0x00005CA5
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00007AAD File Offset: 0x00005CAD
		public int curlsValor
		{
			get
			{
				return (int)this.m_curls;
			}
			set
			{
				this.m_curls = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x040000BD RID: 189
		[SerializeField]
		private Interpretacion.Length m_length;

		// Token: 0x040000BE RID: 190
		[SerializeField]
		private Interpretacion.Capacidad m_volume;

		// Token: 0x040000BF RID: 191
		[SerializeField]
		private Interpretacion.Capacidad m_curls;

		// Token: 0x040000C0 RID: 192
		[AplicaAConjuntoDeFisico(para = "hair", weigth = 30)]
		[LabelLocalizado("Color", "US")]
		public FreeColor color;
	}
}
