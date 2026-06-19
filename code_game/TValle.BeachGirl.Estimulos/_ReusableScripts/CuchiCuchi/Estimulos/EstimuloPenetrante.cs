using System;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x02000006 RID: 6
	[Serializable]
	public class EstimuloPenetrante : InteracionEstimulanteBasica
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000315C File Offset: 0x0000135C
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00003169 File Offset: 0x00001369
		public TipoDeProp tipoDeProp
		{
			get
			{
				return this.m_DataPenetrante.tipoDeProp;
			}
			set
			{
				this.m_DataPenetrante.tipoDeProp = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00003178 File Offset: 0x00001378
		public TipoDeEstimuloCoitalConPenes tipoDeEstimuloCoitalConPenes
		{
			get
			{
				switch (this.m_DataPenetrante.tipoDeEstimuloCoital)
				{
				case TipoDeEstimuloCoital.None:
					return TipoDeEstimuloCoitalConPenes.None;
				case TipoDeEstimuloCoital.conPene:
					return TipoDeEstimuloCoitalConPenes.conPene;
				case TipoDeEstimuloCoital.conDedo:
					return TipoDeEstimuloCoitalConPenes.conDedo;
				case TipoDeEstimuloCoital.otros:
					switch (this.m_DataPenetrante.tipoDeProp)
					{
					case TipoDeProp.bulbEnema:
					case TipoDeProp.jeringa:
					case TipoDeProp.lubeTube:
						return TipoDeEstimuloCoitalConPenes.aplicar;
					case TipoDeProp.dildo:
						return TipoDeEstimuloCoitalConPenes.toyCogida;
					}
					return TipoDeEstimuloCoitalConPenes.explorar;
				default:
					throw new ArgumentOutOfRangeException(this.m_DataPenetrante.tipoDeEstimuloCoital.ToString());
				}
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00003206 File Offset: 0x00001406
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00003213 File Offset: 0x00001413
		public IPene penetradoPor
		{
			get
			{
				return this.m_DataPenetrante.penetradoPor;
			}
			set
			{
				this.m_DataPenetrante.penetradoPor = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00003221 File Offset: 0x00001421
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000322E File Offset: 0x0000142E
		public IHole holePenetrado
		{
			get
			{
				return this.m_DataPenetrante.holePenetrado;
			}
			set
			{
				this.m_DataPenetrante.holePenetrado = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000323C File Offset: 0x0000143C
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00003249 File Offset: 0x00001449
		public bool justPenetrated
		{
			get
			{
				return this.m_DataPenetrante.justPenetrated;
			}
			set
			{
				this.m_DataPenetrante.justPenetrated = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00003257 File Offset: 0x00001457
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00003264 File Offset: 0x00001464
		public Percentage desgasteVisualActualMotion
		{
			get
			{
				return this.m_DataPenetrante.desgasteVisualActualMotion;
			}
			set
			{
				this.m_DataPenetrante.desgasteVisualActualMotion = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00003272 File Offset: 0x00001472
		// (set) Token: 0x06000044 RID: 68 RVA: 0x0000327F File Offset: 0x0000147F
		public Percentage desgasteAIActualMotion
		{
			get
			{
				return this.m_DataPenetrante.desgasteAIActualMotion;
			}
			set
			{
				this.m_DataPenetrante.desgasteAIActualMotion = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000328D File Offset: 0x0000148D
		// (set) Token: 0x06000046 RID: 70 RVA: 0x0000329A File Offset: 0x0000149A
		public Percentage desgasteVisualActualProfundidad
		{
			get
			{
				return this.m_DataPenetrante.desgasteVisualActualProfundidad;
			}
			set
			{
				this.m_DataPenetrante.desgasteVisualActualProfundidad = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000032A8 File Offset: 0x000014A8
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000032B5 File Offset: 0x000014B5
		public Percentage desgasteAIActualProfundidad
		{
			get
			{
				return this.m_DataPenetrante.desgasteAIActualProfundidad;
			}
			set
			{
				this.m_DataPenetrante.desgasteAIActualProfundidad = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000032C3 File Offset: 0x000014C3
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000032D0 File Offset: 0x000014D0
		public Percentage desgasteVisualActualAnchura
		{
			get
			{
				return this.m_DataPenetrante.desgasteVisualActualAnchura;
			}
			set
			{
				this.m_DataPenetrante.desgasteVisualActualAnchura = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000032DE File Offset: 0x000014DE
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000032EB File Offset: 0x000014EB
		public Percentage desgasteAIActualAnchura
		{
			get
			{
				return this.m_DataPenetrante.desgasteAIActualAnchura;
			}
			set
			{
				this.m_DataPenetrante.desgasteAIActualAnchura = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000032F9 File Offset: 0x000014F9
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00003306 File Offset: 0x00001506
		public PenetrationInfoLocal estadoActual
		{
			get
			{
				return this.m_DataPenetrante.estadoActual;
			}
			set
			{
				this.m_DataPenetrante.estadoActual = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003314 File Offset: 0x00001514
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00003321 File Offset: 0x00001521
		public PenetrationInfoLocal cambiosEnElUltimoFrame
		{
			get
			{
				return this.m_DataPenetrante.cambiosEnElUltimoFrame;
			}
			set
			{
				this.m_DataPenetrante.cambiosEnElUltimoFrame = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000332F File Offset: 0x0000152F
		// (set) Token: 0x06000052 RID: 82 RVA: 0x0000333C File Offset: 0x0000153C
		public PenetrationInfoLocal velocidadDeCambios
		{
			get
			{
				return this.m_DataPenetrante.velocidadDeCambios;
			}
			set
			{
				this.m_DataPenetrante.velocidadDeCambios = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000334A File Offset: 0x0000154A
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00003357 File Offset: 0x00001557
		public TipoDeEstimuloCoital tipoDeEstimuloCoital
		{
			get
			{
				return this.m_DataPenetrante.tipoDeEstimuloCoital;
			}
			set
			{
				this.m_DataPenetrante.tipoDeEstimuloCoital = value;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003368 File Offset: 0x00001568
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			EstimuloPenetrante estimuloPenetrante = other as EstimuloPenetrante;
			return estimuloPenetrante != null && estimuloPenetrante.m_DataPenetrante.tipoDeEstimuloCoital == this.m_DataPenetrante.tipoDeEstimuloCoital;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003399 File Offset: 0x00001599
		public sealed override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			(resultado as EstimuloPenetrante).m_DataPenetrante = this.m_DataPenetrante;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000033B4 File Offset: 0x000015B4
		public sealed override void Clear()
		{
			base.Clear();
			this.m_DataPenetrante = default(EstimuloPenetrante.DataPenetrante);
		}

		// Token: 0x04000003 RID: 3
		[SerializeField]
		private EstimuloPenetrante.DataPenetrante m_DataPenetrante;

		// Token: 0x02000027 RID: 39
		[Serializable]
		private struct DataPenetrante
		{
			// Token: 0x04000082 RID: 130
			public TipoDeEstimuloCoital tipoDeEstimuloCoital;

			// Token: 0x04000083 RID: 131
			public TipoDeProp tipoDeProp;

			// Token: 0x04000084 RID: 132
			public IPene penetradoPor;

			// Token: 0x04000085 RID: 133
			public IHole holePenetrado;

			// Token: 0x04000086 RID: 134
			public bool justPenetrated;

			// Token: 0x04000087 RID: 135
			public Percentage desgasteVisualActualMotion;

			// Token: 0x04000088 RID: 136
			public Percentage desgasteAIActualMotion;

			// Token: 0x04000089 RID: 137
			public Percentage desgasteVisualActualProfundidad;

			// Token: 0x0400008A RID: 138
			public Percentage desgasteAIActualProfundidad;

			// Token: 0x0400008B RID: 139
			public Percentage desgasteVisualActualAnchura;

			// Token: 0x0400008C RID: 140
			public Percentage desgasteAIActualAnchura;

			// Token: 0x0400008D RID: 141
			public PenetrationInfoLocal estadoActual;

			// Token: 0x0400008E RID: 142
			public PenetrationInfoLocal cambiosEnElUltimoFrame;

			// Token: 0x0400008F RID: 143
			public PenetrationInfoLocal velocidadDeCambios;
		}
	}
}
