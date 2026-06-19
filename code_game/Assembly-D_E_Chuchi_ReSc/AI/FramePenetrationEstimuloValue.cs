using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000325 RID: 805
	[Obsolete]
	[Serializable]
	public class FramePenetrationEstimuloValue : FrameStimuloValue<FemalePenetracionTipo>
	{
		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x0600115E RID: 4446 RVA: 0x0004AAB3 File Offset: 0x00048CB3
		public static FramePenetrationEstimuloValue nuevaInstancia
		{
			get
			{
				return new FramePenetrationEstimuloValue();
			}
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x0004AABA File Offset: 0x00048CBA
		private FramePenetrationEstimuloValue()
		{
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x0004AAE3 File Offset: 0x00048CE3
		public override void Clear()
		{
			this.anus.Clear();
			this.facial.Clear();
			this.vag.Clear();
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0004AB06 File Offset: 0x00048D06
		public override void AcumularSession(Emocion.SessionDeEstimulo session)
		{
			base.AcumularSessionDeTipo(ref this.anus, session);
			base.AcumularSessionDeTipo(ref this.facial, session);
			base.AcumularSessionDeTipo(ref this.vag, session);
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x0004AB30 File Offset: 0x00048D30
		public override FemalePenetracionTipo GetMaxEnum()
		{
			if (this.anus.estimulo > 0f)
			{
				return FemalePenetracionTipo.anus;
			}
			if (this.vag.estimulo > 0f)
			{
				return FemalePenetracionTipo.vag;
			}
			if (this.facial.estimulo > 0f)
			{
				return FemalePenetracionTipo.facial;
			}
			throw new InvalidOperationException("no se puede solicitar este procedimiento sin ningun estimulo");
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x0004AB84 File Offset: 0x00048D84
		public override EstimuloTactilData GetMaxEstimuloData()
		{
			if (this.anus.estimulo > 0f)
			{
				return this.anus;
			}
			if (this.vag.estimulo > 0f)
			{
				return this.vag;
			}
			if (this.facial.estimulo > 0f)
			{
				return this.facial;
			}
			throw new InvalidOperationException("no se puede solicitar este procedimiento sin ningun estimulo");
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0004ABE6 File Offset: 0x00048DE6
		protected override float total()
		{
			return this.anus.estimulo + this.facial.estimulo + this.vag.estimulo;
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x0004AC0B File Offset: 0x00048E0B
		public override PartesHumanasParaAi GetMaxEstimuloParte()
		{
			return this.GetMaxEnum().Parse();
		}

		// Token: 0x04000DD0 RID: 3536
		public EstimuloTactilData anus = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD1 RID: 3537
		public EstimuloTactilData facial = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD2 RID: 3538
		public EstimuloTactilData vag = EstimuloTactilData.nuevaInstancia;
	}
}
