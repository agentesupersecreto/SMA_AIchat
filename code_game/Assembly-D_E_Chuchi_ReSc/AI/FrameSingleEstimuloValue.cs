using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000324 RID: 804
	[Obsolete]
	[Serializable]
	public class FrameSingleEstimuloValue : FrameStimuloValue<EstimuloTipo>
	{
		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x0600114C RID: 4428 RVA: 0x0004A882 File Offset: 0x00048A82
		public static FrameSingleEstimuloValue nuevaInstancia
		{
			get
			{
				return new FrameSingleEstimuloValue();
			}
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x0004A889 File Offset: 0x00048A89
		private FrameSingleEstimuloValue()
		{
			this.m_dataInter = this.m_data;
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x0600114E RID: 4430 RVA: 0x0004A8A8 File Offset: 0x00048AA8
		private EstimuloDataEdicionDirecta data
		{
			get
			{
				if (this.m_dataInter == null)
				{
					this.m_dataInter = this.m_data;
				}
				return this.m_dataInter;
			}
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x0004A8C4 File Offset: 0x00048AC4
		public void DisminuirDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, float mod = 1f)
		{
			this.data.estimulo -= sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x0004A8E0 File Offset: 0x00048AE0
		public void AcumularDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, float mod = 1f)
		{
			this.maxPArt = sessionParaCargar.maximaParteEstimuladaAlFinalizar;
			this.data.estimulo += sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = sessionParaCargar.tipos;
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x0004A919 File Offset: 0x00048B19
		public void AcumularDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, EstimuloTipo estimuloTipo, float mod = 1f)
		{
			this.maxPArt = sessionParaCargar.maximaParteEstimuladaAlFinalizar;
			this.data.estimulo += sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = estimuloTipo;
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x0004A94D File Offset: 0x00048B4D
		public void AcumularDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, PartesHumanasParaAi parte, float mod = 1f)
		{
			this.maxPArt = parte;
			this.data.estimulo += sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = sessionParaCargar.tipos;
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x0004A981 File Offset: 0x00048B81
		public void AcumularDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, EstimuloTipo estimuloTipo, PartesHumanasParaAi parte, float mod = 1f)
		{
			this.maxPArt = parte;
			this.data.estimulo += sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = estimuloTipo;
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x0004A9B1 File Offset: 0x00048BB1
		public void CargarDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, float mod = 1f)
		{
			this.maxPArt = sessionParaCargar.maximaParteEstimuladaAlFinalizar;
			this.data.estimulo = sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = sessionParaCargar.tipos;
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x0004A9E3 File Offset: 0x00048BE3
		public void CargarDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, EstimuloTipo estimuloTipo, float mod = 1f)
		{
			this.maxPArt = sessionParaCargar.maximaParteEstimuladaAlFinalizar;
			this.data.estimulo = sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = estimuloTipo;
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x0004AA10 File Offset: 0x00048C10
		public void CargarDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, PartesHumanasParaAi parte, float mod = 1f)
		{
			this.maxPArt = parte;
			this.data.estimulo = sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = sessionParaCargar.tipos;
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x0004AA3D File Offset: 0x00048C3D
		public void CargarDesdeUnaSession(Emocion.SessionDeEstimulo sessionParaCargar, EstimuloTipo estimuloTipo, PartesHumanasParaAi parte, float mod = 1f)
		{
			this.maxPArt = parte;
			this.data.estimulo = sessionParaCargar.sumaDeTodosLosEstimulosEnFrames * mod;
			this.data.tipo = estimuloTipo;
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x0004AA66 File Offset: 0x00048C66
		public override void AcumularSession(Emocion.SessionDeEstimulo session)
		{
			base.AcumularSessionDeTipo(ref this.m_data, session);
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x0004AA75 File Offset: 0x00048C75
		public override void Clear()
		{
			this.maxPArt = PartesHumanasParaAi.cuerpo;
			this.m_data.Clear();
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0004AA89 File Offset: 0x00048C89
		public override EstimuloTipo GetMaxEnum()
		{
			return this.m_data.tipo;
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0004AA96 File Offset: 0x00048C96
		public override EstimuloTactilData GetMaxEstimuloData()
		{
			return this.m_data;
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x0004AA9E File Offset: 0x00048C9E
		public override PartesHumanasParaAi GetMaxEstimuloParte()
		{
			return this.maxPArt;
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x0004AAA6 File Offset: 0x00048CA6
		protected override float total()
		{
			return this.m_data.estimulo;
		}

		// Token: 0x04000DCD RID: 3533
		private EstimuloTactilData m_data = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DCE RID: 3534
		private EstimuloDataEdicionDirecta m_dataInter;

		// Token: 0x04000DCF RID: 3535
		private PartesHumanasParaAi maxPArt;
	}
}
