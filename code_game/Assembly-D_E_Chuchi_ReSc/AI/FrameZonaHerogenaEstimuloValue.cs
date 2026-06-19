using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000327 RID: 807
	[Obsolete]
	[Serializable]
	public class FrameZonaHerogenaEstimuloValue : FrameStimuloValue<ZonaErogenaUbicacion>
	{
		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x0600116E RID: 4462 RVA: 0x0004B11F File Offset: 0x0004931F
		public static FrameZonaHerogenaEstimuloValue nuevaInstancia
		{
			get
			{
				return new FrameZonaHerogenaEstimuloValue();
			}
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x0004B128 File Offset: 0x00049328
		private FrameZonaHerogenaEstimuloValue()
		{
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x0004B188 File Offset: 0x00049388
		public override void Clear()
		{
			this.cabeza.Clear();
			this.pecho.Clear();
			this.cintura.Clear();
			this.cadera.Clear();
			this.entrepierna.Clear();
			this.brazos.Clear();
			this.piernas.Clear();
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x0004B1E4 File Offset: 0x000493E4
		public override void AcumularSession(Emocion.SessionDeEstimulo session)
		{
			base.AcumularSessionDeTipo(ref this.brazos, session);
			base.AcumularSessionDeTipo(ref this.cabeza, session);
			base.AcumularSessionDeTipo(ref this.cadera, session);
			base.AcumularSessionDeTipo(ref this.cintura, session);
			base.AcumularSessionDeTipo(ref this.entrepierna, session);
			base.AcumularSessionDeTipo(ref this.pecho, session);
			base.AcumularSessionDeTipo(ref this.piernas, session);
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x0004B24C File Offset: 0x0004944C
		public override ZonaErogenaUbicacion GetMaxEnum()
		{
			if (this.entrepierna.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.entrepierna;
			}
			if (this.piernas.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.piernas;
			}
			if (this.cadera.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.cadera;
			}
			if (this.pecho.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.pecho;
			}
			if (this.cintura.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.cintura;
			}
			if (this.cabeza.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.cabeza;
			}
			if (this.brazos.estimulo > 0f)
			{
				return ZonaErogenaUbicacion.brazos;
			}
			throw new InvalidOperationException("no se puede solicitar este procedimiento sin ningun estimulo");
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x0004B2F0 File Offset: 0x000494F0
		public override EstimuloTactilData GetMaxEstimuloData()
		{
			if (this.entrepierna.estimulo > 0f)
			{
				return this.entrepierna;
			}
			if (this.piernas.estimulo > 0f)
			{
				return this.piernas;
			}
			if (this.cadera.estimulo > 0f)
			{
				return this.cadera;
			}
			if (this.pecho.estimulo > 0f)
			{
				return this.pecho;
			}
			if (this.cintura.estimulo > 0f)
			{
				return this.cintura;
			}
			if (this.cabeza.estimulo > 0f)
			{
				return this.cabeza;
			}
			if (this.brazos.estimulo > 0f)
			{
				return this.brazos;
			}
			throw new InvalidOperationException("no se puede solicitar este procedimiento sin ningun estimulo");
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x0004B3B8 File Offset: 0x000495B8
		protected override float total()
		{
			return this.cabeza.estimulo + this.pecho.estimulo + this.cintura.estimulo + this.cadera.estimulo + this.entrepierna.estimulo + this.brazos.estimulo + this.piernas.estimulo;
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x0004B418 File Offset: 0x00049618
		public override PartesHumanasParaAi GetMaxEstimuloParte()
		{
			return this.GetMaxEnum().Parse();
		}

		// Token: 0x04000DDF RID: 3551
		public EstimuloTactilData brazos = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DE0 RID: 3552
		public EstimuloTactilData cabeza = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DE1 RID: 3553
		public EstimuloTactilData cadera = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DE2 RID: 3554
		public EstimuloTactilData cintura = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DE3 RID: 3555
		public EstimuloTactilData entrepierna = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DE4 RID: 3556
		public EstimuloTactilData pecho = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DE5 RID: 3557
		public EstimuloTactilData piernas = EstimuloTactilData.nuevaInstancia;
	}
}
