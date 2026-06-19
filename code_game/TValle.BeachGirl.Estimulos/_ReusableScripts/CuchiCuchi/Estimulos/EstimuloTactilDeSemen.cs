using System;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public class EstimuloTactilDeSemen : EstimuloTactilDeParticulaBase
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000033D0 File Offset: 0x000015D0
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000033DD File Offset: 0x000015DD
		public IPeneSimple pene
		{
			get
			{
				return this.m_DataSemenBase.pene;
			}
			set
			{
				this.m_DataSemenBase.pene = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000033EB File Offset: 0x000015EB
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000033F8 File Offset: 0x000015F8
		public ParteDelCuerpoHumano? penetrando
		{
			get
			{
				return this.m_DataSemenBase.penetrando;
			}
			set
			{
				this.m_DataSemenBase.penetrando = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00003406 File Offset: 0x00001606
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00003413 File Offset: 0x00001613
		public TipoDeSemen tipoDeSemen
		{
			get
			{
				return this.m_DataSemenBase.tipoDeSemen;
			}
			set
			{
				this.m_DataSemenBase.tipoDeSemen = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003424 File Offset: 0x00001624
		public TipoDeEstimuloTactilDerramante tipoDeEstimuloTactilDerramante
		{
			get
			{
				bool flag = this.m_DataSemenBase.penetrando != null;
				switch (this.m_DataSemenBase.tipoDeSemen)
				{
				case TipoDeSemen.semen:
					if (!flag)
					{
						return TipoDeEstimuloTactilDerramante.cumOn;
					}
					return TipoDeEstimuloTactilDerramante.cumIn;
				case TipoDeSemen.water:
					if (!flag)
					{
						return TipoDeEstimuloTactilDerramante.spillOn;
					}
					return TipoDeEstimuloTactilDerramante.flushIn;
				case TipoDeSemen.lubricante:
					if (!flag)
					{
						return TipoDeEstimuloTactilDerramante.applyOn;
					}
					return TipoDeEstimuloTactilDerramante.applyIn;
				case TipoDeSemen.orine:
					if (!flag)
					{
						return TipoDeEstimuloTactilDerramante.pissOn;
					}
					return TipoDeEstimuloTactilDerramante.pissIn;
				default:
					throw new ArgumentOutOfRangeException(this.m_DataSemenBase.tipoDeSemen.ToString());
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000034A3 File Offset: 0x000016A3
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			return base.ConvinableCon(other) && other is EstimuloTactilDeSemen;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000034BB File Offset: 0x000016BB
		public override void Clear()
		{
			base.Clear();
			this.m_DataSemenBase = default(EstimuloTactilDeSemen.DataSemenBase);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000034D0 File Offset: 0x000016D0
		public override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			EstimuloTactilDeSemen estimuloTactilDeSemen = resultado as EstimuloTactilDeSemen;
			if (estimuloTactilDeSemen == null)
			{
				return;
			}
			estimuloTactilDeSemen.m_DataSemenBase = this.m_DataSemenBase;
		}

		// Token: 0x04000008 RID: 8
		[SerializeField]
		private EstimuloTactilDeSemen.DataSemenBase m_DataSemenBase;

		// Token: 0x02000028 RID: 40
		[Serializable]
		private struct DataSemenBase
		{
			// Token: 0x04000090 RID: 144
			public IPeneSimple pene;

			// Token: 0x04000091 RID: 145
			public ParteDelCuerpoHumano? penetrando;

			// Token: 0x04000092 RID: 146
			public TipoDeSemen tipoDeSemen;
		}
	}
}
