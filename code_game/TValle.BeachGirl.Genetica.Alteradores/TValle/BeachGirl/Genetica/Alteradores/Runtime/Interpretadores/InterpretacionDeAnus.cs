using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200002F RID: 47
	[AplicaAConjuntoDeFisico(para = "buttocks")]
	[Serializable]
	public struct InterpretacionDeAnus
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00007313 File Offset: 0x00005513
		// (set) Token: 0x0600011E RID: 286 RVA: 0x0000731B File Offset: 0x0000551B
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

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00007324 File Offset: 0x00005524
		// (set) Token: 0x06000120 RID: 288 RVA: 0x0000732C File Offset: 0x0000552C
		[LabelLocalizado("Opening", "US")]
		public Interpretacion.Opening opening
		{
			get
			{
				return this.m_opening;
			}
			set
			{
				this.m_opening = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00007335 File Offset: 0x00005535
		// (set) Token: 0x06000122 RID: 290 RVA: 0x0000733D File Offset: 0x0000553D
		[AplicaAConjuntoDeFisico(para = "crotch", weigth = 3)]
		[LabelLocalizado("Depth", "US")]
		public Interpretacion.HoleDepth profundidad
		{
			get
			{
				return this.m_analProfundidad;
			}
			set
			{
				this.m_analProfundidad = value;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00007346 File Offset: 0x00005546
		// (set) Token: 0x06000124 RID: 292 RVA: 0x0000734E File Offset: 0x0000554E
		[AplicaAConjuntoDeFisico(para = "crotch", weigth = 3)]
		[LabelLocalizado("Tightness", "US")]
		public Interpretacion.Tightness anchura
		{
			get
			{
				return this.m_analAnchura;
			}
			set
			{
				this.m_analAnchura = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00007357 File Offset: 0x00005557
		// (set) Token: 0x06000126 RID: 294 RVA: 0x0000735F File Offset: 0x0000555F
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

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00007368 File Offset: 0x00005568
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00007370 File Offset: 0x00005570
		public int openingValor
		{
			get
			{
				return (int)this.m_opening;
			}
			set
			{
				this.m_opening = (Interpretacion.Opening)value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00007379 File Offset: 0x00005579
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00007381 File Offset: 0x00005581
		public int profundidadValor
		{
			get
			{
				return (int)this.m_analProfundidad;
			}
			set
			{
				this.m_analProfundidad = (Interpretacion.HoleDepth)value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600012B RID: 299 RVA: 0x0000738A File Offset: 0x0000558A
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00007392 File Offset: 0x00005592
		public int anchuraValor
		{
			get
			{
				return (int)this.m_analAnchura;
			}
			set
			{
				this.m_analAnchura = (Interpretacion.Tightness)value;
			}
		}

		// Token: 0x04000057 RID: 87
		[SerializeField]
		private Interpretacion.Size m_size;

		// Token: 0x04000058 RID: 88
		[SerializeField]
		private Interpretacion.Opening m_opening;

		// Token: 0x04000059 RID: 89
		[SerializeField]
		private Interpretacion.HoleDepth m_analProfundidad;

		// Token: 0x0400005A RID: 90
		[SerializeField]
		private Interpretacion.Tightness m_analAnchura;

		// Token: 0x0400005B RID: 91
		[LabelLocalizado("Difficulty", "US")]
		public HoleDifficulty difficulty;
	}
}
