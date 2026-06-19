using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000039 RID: 57
	[AplicaAConjuntoDeFisico(para = "face")]
	[Serializable]
	public struct InterpretacionDeJaw
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00007AB6 File Offset: 0x00005CB6
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00007ABE File Offset: 0x00005CBE
		[AplicaAConjuntoDeFisico(para = "nose", weigth = 10)]
		[LabelLocalizado("Size", "US")]
		public Interpretacion.Size size
		{
			get
			{
				return this.m_jawSize;
			}
			set
			{
				this.m_jawSize = value;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00007AC7 File Offset: 0x00005CC7
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00007ACF File Offset: 0x00005CCF
		[AplicaAConjuntoDeFisico(para = "nose", weigth = 10)]
		[LabelLocalizado("Width", "US")]
		public Interpretacion.CantidadNoContable width
		{
			get
			{
				return this.m_width;
			}
			set
			{
				this.m_width = value;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00007AD8 File Offset: 0x00005CD8
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00007AE0 File Offset: 0x00005CE0
		[LabelLocalizado("Angle", "US")]
		public Interpretacion.AngleDirection angle
		{
			get
			{
				return this.m_angle;
			}
			set
			{
				this.m_angle = value;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00007AE9 File Offset: 0x00005CE9
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00007AF1 File Offset: 0x00005CF1
		[LabelLocalizado("Curve", "US")]
		public Interpretacion.CantidadNoContable curve
		{
			get
			{
				return this.m_curve;
			}
			set
			{
				this.m_curve = value;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00007AFA File Offset: 0x00005CFA
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00007B02 File Offset: 0x00005D02
		[AplicaAConjuntoDeFisico(para = "nose", weigth = 10)]
		[LabelLocalizado("Define", "US")]
		public Interpretacion.CantidadNoContable define
		{
			get
			{
				return this.m_define;
			}
			set
			{
				this.m_define = value;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00007B0B File Offset: 0x00005D0B
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00007B13 File Offset: 0x00005D13
		[LabelLocalizado("Line Depth", "US")]
		public Interpretacion.Capacidad lineDepth
		{
			get
			{
				return this.m_lineDepth;
			}
			set
			{
				this.m_lineDepth = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00007B1C File Offset: 0x00005D1C
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00007B24 File Offset: 0x00005D24
		[LabelLocalizado("Chin Cleft", "US")]
		public Interpretacion.Depth chinCleft
		{
			get
			{
				return this.m_chinCleft;
			}
			set
			{
				this.m_chinCleft = value;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00007B2D File Offset: 0x00005D2D
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00007B35 File Offset: 0x00005D35
		[LabelLocalizado("Chin Length", "US")]
		public Interpretacion.Length chinLength
		{
			get
			{
				return this.m_chinLength;
			}
			set
			{
				this.m_chinLength = value;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00007B3E File Offset: 0x00005D3E
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00007B46 File Offset: 0x00005D46
		[LabelLocalizado("Chin Depth", "US")]
		public Interpretacion.Depth chinDepth
		{
			get
			{
				return this.m_chinDepth;
			}
			set
			{
				this.m_chinDepth = value;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00007B4F File Offset: 0x00005D4F
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00007B57 File Offset: 0x00005D57
		[LabelLocalizado("Chin Recede", "US")]
		public Interpretacion.CantidadNoContable chinRecede
		{
			get
			{
				return this.m_chinRecede;
			}
			set
			{
				this.m_chinRecede = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00007B60 File Offset: 0x00005D60
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00007B68 File Offset: 0x00005D68
		[LabelLocalizado("Chin Square", "US")]
		public Interpretacion.CantidadNoContable chinSquare
		{
			get
			{
				return this.m_chinSquare;
			}
			set
			{
				this.m_chinSquare = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00007B71 File Offset: 0x00005D71
		// (set) Token: 0x0600021A RID: 538 RVA: 0x00007B79 File Offset: 0x00005D79
		[LabelLocalizado("Chin Width", "US")]
		public Interpretacion.Amplitude chinWidth
		{
			get
			{
				return this.m_chinWidth;
			}
			set
			{
				this.m_chinWidth = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00007B82 File Offset: 0x00005D82
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00007B8A File Offset: 0x00005D8A
		[LabelLocalizado("Chin Crease", "US")]
		public Interpretacion.CantidadNoContable chinCrease
		{
			get
			{
				return this.m_chinCrease;
			}
			set
			{
				this.m_chinCrease = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00007B93 File Offset: 0x00005D93
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00007B9B File Offset: 0x00005D9B
		public int sizeValor
		{
			get
			{
				return (int)this.m_jawSize;
			}
			set
			{
				this.m_jawSize = (Interpretacion.Size)value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00007BA4 File Offset: 0x00005DA4
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00007BAC File Offset: 0x00005DAC
		public int chinCleftValor
		{
			get
			{
				return (int)this.m_chinCleft;
			}
			set
			{
				this.m_chinCleft = (Interpretacion.Depth)value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00007BB5 File Offset: 0x00005DB5
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00007BBD File Offset: 0x00005DBD
		public int chinLengthValor
		{
			get
			{
				return (int)this.m_chinLength;
			}
			set
			{
				this.m_chinLength = (Interpretacion.Length)value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00007BC6 File Offset: 0x00005DC6
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00007BCE File Offset: 0x00005DCE
		public int chinDepthValor
		{
			get
			{
				return (int)this.m_chinDepth;
			}
			set
			{
				this.m_chinDepth = (Interpretacion.Depth)value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00007BD7 File Offset: 0x00005DD7
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00007BDF File Offset: 0x00005DDF
		public int chinWidthValor
		{
			get
			{
				return (int)this.m_chinWidth;
			}
			set
			{
				this.m_chinWidth = (Interpretacion.Amplitude)value;
			}
		}

		// Token: 0x040000C1 RID: 193
		[SerializeField]
		private Interpretacion.Size m_jawSize;

		// Token: 0x040000C2 RID: 194
		[SerializeField]
		private Interpretacion.CantidadNoContable m_width;

		// Token: 0x040000C3 RID: 195
		[SerializeField]
		private Interpretacion.AngleDirection m_angle;

		// Token: 0x040000C4 RID: 196
		[SerializeField]
		private Interpretacion.CantidadNoContable m_curve;

		// Token: 0x040000C5 RID: 197
		[SerializeField]
		private Interpretacion.CantidadNoContable m_define;

		// Token: 0x040000C6 RID: 198
		[SerializeField]
		private Interpretacion.Capacidad m_lineDepth;

		// Token: 0x040000C7 RID: 199
		[SerializeField]
		private Interpretacion.Depth m_chinCleft;

		// Token: 0x040000C8 RID: 200
		[SerializeField]
		private Interpretacion.Length m_chinLength;

		// Token: 0x040000C9 RID: 201
		[SerializeField]
		private Interpretacion.Depth m_chinDepth;

		// Token: 0x040000CA RID: 202
		[SerializeField]
		private Interpretacion.CantidadNoContable m_chinRecede;

		// Token: 0x040000CB RID: 203
		[SerializeField]
		private Interpretacion.CantidadNoContable m_chinSquare;

		// Token: 0x040000CC RID: 204
		[SerializeField]
		private Interpretacion.Amplitude m_chinWidth;

		// Token: 0x040000CD RID: 205
		[SerializeField]
		private Interpretacion.CantidadNoContable m_chinCrease;
	}
}
