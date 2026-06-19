using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000326 RID: 806
	[Obsolete]
	[Serializable]
	public class FrameCariciaEstimuloValue : FrameStimuloValue<CharTouchEnum>
	{
		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x0004AC18 File Offset: 0x00048E18
		public static FrameCariciaEstimuloValue nuevaInstancia
		{
			get
			{
				return new FrameCariciaEstimuloValue();
			}
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x0004AC20 File Offset: 0x00048E20
		private FrameCariciaEstimuloValue()
		{
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x0004ACB8 File Offset: 0x00048EB8
		public override void Clear()
		{
			try
			{
				this.anus.Clear();
				this.ass.Clear();
				this.boob.Clear();
				this.chest.Clear();
				this.facial.Clear();
				this.hand.Clear();
				this.head.Clear();
				this.hips.Clear();
				this.others.Clear();
				this.upperLegs.Clear();
				this.vag.Clear();
				this.waist.Clear();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x0004AD5C File Offset: 0x00048F5C
		public override void AcumularSession(Emocion.SessionDeEstimulo session)
		{
			base.AcumularSessionDeTipo(ref this.anus, session);
			base.AcumularSessionDeTipo(ref this.ass, session);
			base.AcumularSessionDeTipo(ref this.boob, session);
			base.AcumularSessionDeTipo(ref this.chest, session);
			base.AcumularSessionDeTipo(ref this.facial, session);
			base.AcumularSessionDeTipo(ref this.hand, session);
			base.AcumularSessionDeTipo(ref this.head, session);
			base.AcumularSessionDeTipo(ref this.hips, session);
			base.AcumularSessionDeTipo(ref this.others, session);
			base.AcumularSessionDeTipo(ref this.upperLegs, session);
			base.AcumularSessionDeTipo(ref this.vag, session);
			base.AcumularSessionDeTipo(ref this.waist, session);
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x0004AE08 File Offset: 0x00049008
		public override CharTouchEnum GetMaxEnum()
		{
			if (this.anus.estimulo > 0f)
			{
				return CharTouchEnum.anus;
			}
			if (this.vag.estimulo > 0f)
			{
				return CharTouchEnum.vag;
			}
			if (this.ass.estimulo > 0f)
			{
				return CharTouchEnum.ass;
			}
			if (this.boob.estimulo > 0f)
			{
				return CharTouchEnum.boob;
			}
			if (this.upperLegs.estimulo > 0f)
			{
				return CharTouchEnum.upperLegs;
			}
			if (this.hips.estimulo > 0f)
			{
				return CharTouchEnum.hips;
			}
			if (this.facial.estimulo > 0f)
			{
				return CharTouchEnum.facial;
			}
			if (this.waist.estimulo > 0f)
			{
				return CharTouchEnum.waist;
			}
			if (this.chest.estimulo > 0f)
			{
				return CharTouchEnum.chest;
			}
			if (this.hand.estimulo > 0f)
			{
				return CharTouchEnum.hand;
			}
			if (this.head.estimulo > 0f)
			{
				return CharTouchEnum.head;
			}
			if (this.others.estimulo > 0f)
			{
				return CharTouchEnum.others;
			}
			throw new InvalidOperationException("no se puede solicitar este procedimiento sin ningun estimulo");
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x0004AF14 File Offset: 0x00049114
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
			if (this.ass.estimulo > 0f)
			{
				return this.ass;
			}
			if (this.boob.estimulo > 0f)
			{
				return this.boob;
			}
			if (this.upperLegs.estimulo > 0f)
			{
				return this.upperLegs;
			}
			if (this.hips.estimulo > 0f)
			{
				return this.hips;
			}
			if (this.facial.estimulo > 0f)
			{
				return this.facial;
			}
			if (this.waist.estimulo > 0f)
			{
				return this.waist;
			}
			if (this.chest.estimulo > 0f)
			{
				return this.chest;
			}
			if (this.hand.estimulo > 0f)
			{
				return this.hand;
			}
			if (this.head.estimulo > 0f)
			{
				return this.head;
			}
			if (this.others.estimulo > 0f)
			{
				return this.others;
			}
			throw new InvalidOperationException("no se puede solicitar este procedimiento sin ningun estimulo");
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x0004B058 File Offset: 0x00049258
		protected override float total()
		{
			float num;
			try
			{
				num = this.anus.estimulo + this.ass.estimulo + this.boob.estimulo + this.chest.estimulo + this.facial.estimulo + this.hand.estimulo + this.head.estimulo + this.hips.estimulo + this.others.estimulo + this.upperLegs.estimulo + this.vag.estimulo + this.waist.estimulo;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return num;
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x0004B10C File Offset: 0x0004930C
		public override PartesHumanasParaAi GetMaxEstimuloParte()
		{
			return this.GetMaxEnum().Parse(this.GetMaxEstimuloData());
		}

		// Token: 0x04000DD3 RID: 3539
		public EstimuloTactilData anus = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD4 RID: 3540
		public EstimuloTactilData ass = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD5 RID: 3541
		public EstimuloTactilData boob = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD6 RID: 3542
		public EstimuloTactilData chest = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD7 RID: 3543
		public EstimuloTactilData facial = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD8 RID: 3544
		public EstimuloTactilData hand = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DD9 RID: 3545
		public EstimuloTactilData head = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DDA RID: 3546
		public EstimuloTactilData hips = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DDB RID: 3547
		public EstimuloTactilData others = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DDC RID: 3548
		public EstimuloTactilData upperLegs = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DDD RID: 3549
		public EstimuloTactilData vag = EstimuloTactilData.nuevaInstancia;

		// Token: 0x04000DDE RID: 3550
		public EstimuloTactilData waist = EstimuloTactilData.nuevaInstancia;
	}
}
