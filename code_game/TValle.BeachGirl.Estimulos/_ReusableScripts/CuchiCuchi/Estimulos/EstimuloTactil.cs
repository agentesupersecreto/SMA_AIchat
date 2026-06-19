using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class EstimuloTactil : InteracionEstimulanteBasica
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00003510 File Offset: 0x00001710
		public override void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			base.CopiarA(resultado, convinarPartesEstimuladas);
			EstimuloTactil estimuloTactil = resultado as EstimuloTactil;
			if (estimuloTactil == null)
			{
				return;
			}
			estimuloTactil.m_DataTactilBase = this.m_DataTactilBase;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000353C File Offset: 0x0000173C
		public override void Clear()
		{
			base.Clear();
			this.m_DataTactilBase = default(EstimuloTactil.DataTactilBase);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003550 File Offset: 0x00001750
		protected override bool ConvinableCon(InteracionEstimulanteBasica other)
		{
			EstimuloTactil estimuloTactil = other as EstimuloTactil;
			return estimuloTactil != null && estimuloTactil.m_DataTactilBase.tipoDeEstimuloTactil == this.m_DataTactilBase.tipoDeEstimuloTactil;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003581 File Offset: 0x00001781
		public TipoDeEstimuloTactil tipoDeEstimuloTactil
		{
			get
			{
				return this.m_DataTactilBase.tipoDeEstimuloTactil;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000358E File Offset: 0x0000178E
		public TipoDeEstimuloTactilInvertido tipoDeEstimuloTactilInvertido
		{
			get
			{
				return this.m_DataTactilBase.tipoDeEstimuloTactilInvertido;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000359B File Offset: 0x0000179B
		public void SetTipoDeEstimuloTactil(TipoDeEstimuloTactil tipo)
		{
			this.m_DataTactilBase.tipoDeEstimuloTactil = tipo;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000035A9 File Offset: 0x000017A9
		public void SetTipoDeEstimuloTactil(TipoDeEstimuloTactilInvertido tipoInvertido)
		{
			this.m_DataTactilBase.tipoDeEstimuloTactilInvertido = tipoInvertido;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000035B7 File Offset: 0x000017B7
		// (set) Token: 0x0600006E RID: 110 RVA: 0x000035C4 File Offset: 0x000017C4
		public int cantidadDeContanctos
		{
			get
			{
				return this.m_DataTactilBase.cantidadDeContanctos;
			}
			set
			{
				this.m_DataTactilBase.cantidadDeContanctos = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000035D2 File Offset: 0x000017D2
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000035DF File Offset: 0x000017DF
		public Vector3 velocidadEstimuladoEmulada
		{
			get
			{
				return this.m_DataTactilBase.velocidadEstimuladoEmulada;
			}
			set
			{
				this.m_DataTactilBase.velocidadEstimuladoEmulada = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000035ED File Offset: 0x000017ED
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000035FA File Offset: 0x000017FA
		public Vector3 velocidadEstimulanteEmulada
		{
			get
			{
				return this.m_DataTactilBase.velocidadEstimulanteEmulada;
			}
			set
			{
				this.m_DataTactilBase.velocidadEstimulanteEmulada = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00003608 File Offset: 0x00001808
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00003615 File Offset: 0x00001815
		public Vector3 velocidadRelativaEmulada
		{
			get
			{
				return this.m_DataTactilBase.velocidadRelativaEmulada;
			}
			set
			{
				this.m_DataTactilBase.velocidadRelativaEmulada = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003623 File Offset: 0x00001823
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00003630 File Offset: 0x00001830
		public float velocidadRelativaEmuladaMaxima
		{
			get
			{
				return this.m_DataTactilBase.velocidadRelativaEmuladaMaxima;
			}
			set
			{
				this.m_DataTactilBase.velocidadRelativaEmuladaMaxima = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000363E File Offset: 0x0000183E
		// (set) Token: 0x06000078 RID: 120 RVA: 0x0000364B File Offset: 0x0000184B
		public float velocidadRelativaEmuladaTotal
		{
			get
			{
				return this.m_DataTactilBase.velocidadRelativaEmuladaTotal;
			}
			set
			{
				this.m_DataTactilBase.velocidadRelativaEmuladaTotal = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003659 File Offset: 0x00001859
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00003666 File Offset: 0x00001866
		public bool esDePhysicsEngine
		{
			get
			{
				return this.m_DataTactilBase.esDePhysicsEngine;
			}
			set
			{
				this.m_DataTactilBase.esDePhysicsEngine = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00003674 File Offset: 0x00001874
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00003681 File Offset: 0x00001881
		public Vector3 velocidadRelativaPhysics
		{
			get
			{
				return this.m_DataTactilBase.velocidadRelativaPhysics;
			}
			set
			{
				this.m_DataTactilBase.velocidadRelativaPhysics = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000368F File Offset: 0x0000188F
		// (set) Token: 0x0600007E RID: 126 RVA: 0x0000369C File Offset: 0x0000189C
		public float velocidadRelativaPhysicsMagnitud
		{
			get
			{
				return this.m_DataTactilBase.velocidadRelativaPhysicsMagnitud;
			}
			set
			{
				this.m_DataTactilBase.velocidadRelativaPhysicsMagnitud = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000036AA File Offset: 0x000018AA
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000036B7 File Offset: 0x000018B7
		public Vector3 impulsoPhysics
		{
			get
			{
				return this.m_DataTactilBase.impulsoPhysics;
			}
			set
			{
				this.m_DataTactilBase.impulsoPhysics = value;
			}
		}

		// Token: 0x04000009 RID: 9
		[SerializeField]
		private EstimuloTactil.DataTactilBase m_DataTactilBase;

		// Token: 0x02000029 RID: 41
		[Serializable]
		private struct DataTactilBase
		{
			// Token: 0x04000093 RID: 147
			public TipoDeEstimuloTactil tipoDeEstimuloTactil;

			// Token: 0x04000094 RID: 148
			public TipoDeEstimuloTactilInvertido tipoDeEstimuloTactilInvertido;

			// Token: 0x04000095 RID: 149
			public int cantidadDeContanctos;

			// Token: 0x04000096 RID: 150
			public Vector3 velocidadEstimuladoEmulada;

			// Token: 0x04000097 RID: 151
			public Vector3 velocidadEstimulanteEmulada;

			// Token: 0x04000098 RID: 152
			public Vector3 velocidadRelativaEmulada;

			// Token: 0x04000099 RID: 153
			public float velocidadRelativaEmuladaMaxima;

			// Token: 0x0400009A RID: 154
			public float velocidadRelativaEmuladaTotal;

			// Token: 0x0400009B RID: 155
			public bool esDePhysicsEngine;

			// Token: 0x0400009C RID: 156
			public Vector3 velocidadRelativaPhysics;

			// Token: 0x0400009D RID: 157
			public float velocidadRelativaPhysicsMagnitud;

			// Token: 0x0400009E RID: 158
			public Vector3 impulsoPhysics;
		}
	}
}
