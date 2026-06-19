using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;

namespace Assets.TValle.Tools.Runtime.Characters.Intections
{
	// Token: 0x0200004E RID: 78
	[Serializable]
	public struct InteractionToDisk
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x00003E28 File Offset: 0x00002028
		public Interaction ToInter()
		{
			Interaction interaction = new Interaction
			{
				fromID = this.fID,
				toID = this.tID,
				fromPart = this.fP,
				toPart = this.tP,
				interationReceivedType = this.typ,
				emotion = this.emo,
				dateString = this.dS,
				startTime = this.sT,
				endTime = this.eT,
				startFrame = this.sF,
				endFrame = this.eF,
				stacks = this.ts,
				times = this.tss,
				damagePercentageDone = this.dmg,
				emotionAtMaxValueTimes = this.emoMxTs,
				triggerMaxValueTimes = this.tggMxTs,
				overshootOrUndershootTotal = this.off,
				damageScoreTotal = this.dmgS
			};
			if (interaction.times <= 0)
			{
				interaction.times = 1;
			}
			if (interaction.stacks <= 0)
			{
				interaction.stacks = 1;
			}
			return interaction;
		}

		// Token: 0x0400009D RID: 157
		public string fID;

		// Token: 0x0400009E RID: 158
		public string tID;

		// Token: 0x0400009F RID: 159
		public TriggeringBodyPart fP;

		// Token: 0x040000A0 RID: 160
		public SensitiveBodyPart tP;

		// Token: 0x040000A1 RID: 161
		public InterationReceivedType typ;

		// Token: 0x040000A2 RID: 162
		public Emotion emo;

		// Token: 0x040000A3 RID: 163
		public string dS;

		// Token: 0x040000A4 RID: 164
		public float sT;

		// Token: 0x040000A5 RID: 165
		public float eT;

		// Token: 0x040000A6 RID: 166
		public int sF;

		// Token: 0x040000A7 RID: 167
		public int eF;

		// Token: 0x040000A8 RID: 168
		public int ts;

		// Token: 0x040000A9 RID: 169
		public int tss;

		// Token: 0x040000AA RID: 170
		public float dmg;

		// Token: 0x040000AB RID: 171
		public int emoMxTs;

		// Token: 0x040000AC RID: 172
		public int tggMxTs;

		// Token: 0x040000AD RID: 173
		public float off;

		// Token: 0x040000AE RID: 174
		public float dmgS;
	}
}
