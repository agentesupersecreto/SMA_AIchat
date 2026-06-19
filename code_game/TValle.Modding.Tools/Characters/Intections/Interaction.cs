using System;
using System.Globalization;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.Intections
{
	// Token: 0x0200004F RID: 79
	[Serializable]
	public struct Interaction
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x00003F4C File Offset: 0x0000214C
		public static void AddFromDifferentRecordings(ref Interaction mutable, ref Interaction inmutable)
		{
			float duration = mutable.duration;
			float duration2 = inmutable.duration;
			int frames = mutable.frames;
			int frames2 = inmutable.frames;
			Interaction.StackFromSameRecording(ref mutable, ref inmutable, false, false);
			mutable.startTime = 0f;
			mutable.startFrame = 0;
			mutable.endTime = duration + duration2;
			mutable.endFrame = frames + frames2;
			mutable.times += inmutable.times;
			DateTime date = mutable.date;
			DateTime date2 = inmutable.date;
			mutable.date = ((date < date2) ? date : date2);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00003FDC File Offset: 0x000021DC
		public static void AddFromSameRecording(ref Interaction toReport, ref Interaction newInteraccion)
		{
			Interaction.StackFromSameRecording(ref toReport, ref newInteraccion, false, true);
			toReport.times += newInteraccion.times;
			DateTime date = toReport.date;
			DateTime date2 = newInteraccion.date;
			toReport.date = ((date < date2) ? date : date2);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00004028 File Offset: 0x00002228
		public static void StackFromSameRecording(ref Interaction toReport, ref Interaction newInteraccion, bool addTimes, bool fixStartTime)
		{
			if (addTimes)
			{
				toReport.times++;
			}
			toReport.stacks++;
			if (fixStartTime)
			{
				float num = newInteraccion.startTime - toReport.endTime;
				int num2 = newInteraccion.startFrame - toReport.endFrame;
				if (num > 0f)
				{
					toReport.startTime += num;
				}
				if (num2 > 0)
				{
					toReport.startFrame += num2;
				}
			}
			toReport.endTime = Mathf.Max(newInteraccion.endTime, toReport.endTime);
			toReport.endFrame = Mathf.Max(newInteraccion.endFrame, toReport.endFrame);
			toReport.emotionAtMaxValueTimes = (toReport.emotionAtMaxValue ? Mathf.Clamp(toReport.emotionAtMaxValueTimes + newInteraccion.emotionAtMaxValueTimes, 1, int.MaxValue) : 0);
			toReport.triggerMaxValueTimes = (toReport.triggerMaxValue ? Mathf.Clamp(toReport.triggerMaxValueTimes + newInteraccion.triggerMaxValueTimes, 1, int.MaxValue) : 0);
			toReport.damagePercentageDone += newInteraccion.damagePercentageDone;
			toReport.overshootOrUndershootTotal += newInteraccion.overshootOrUndershoot;
			toReport.damageScoreTotal += newInteraccion.damageScore;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000414C File Offset: 0x0000234C
		public static void UnStack(ref Interaction toReport, ref Interaction oldInteraccion, bool removeTimes)
		{
			if (removeTimes)
			{
				toReport.times--;
			}
			toReport.stacks -= oldInteraccion.stacks;
			toReport.emotionAtMaxValueTimes = (toReport.emotionAtMaxValue ? Mathf.Clamp(toReport.emotionAtMaxValueTimes - oldInteraccion.emotionAtMaxValueTimes, 1, int.MaxValue) : 0);
			toReport.triggerMaxValueTimes = (toReport.triggerMaxValue ? Mathf.Clamp(toReport.triggerMaxValueTimes - oldInteraccion.triggerMaxValueTimes, 1, int.MaxValue) : 0);
			toReport.damagePercentageDone -= oldInteraccion.damagePercentageDone;
			toReport.overshootOrUndershootTotal -= oldInteraccion.overshootOrUndershoot;
			toReport.damageScoreTotal -= oldInteraccion.damageScore;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000041FF File Offset: 0x000023FF
		public ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> GetKey()
		{
			return new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.fromPart, this.toPart, this.interationReceivedType, this.emotion, this.triggerMaxValue);
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00004224 File Offset: 0x00002424
		public float overshootOrUndershoot
		{
			get
			{
				if (this.stacks > 0)
				{
					return this.overshootOrUndershootTotal / (float)this.stacks;
				}
				return 0f;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00004243 File Offset: 0x00002443
		public float damageScore
		{
			get
			{
				if (this.stacks > 0)
				{
					return this.damageScoreTotal / (float)this.stacks;
				}
				return 0f;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00004262 File Offset: 0x00002462
		public float scoredDamagePercentageDone
		{
			get
			{
				return this.damagePercentageDone * this.damageScore * 2f;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00004277 File Offset: 0x00002477
		public float GetScoredDamagePercentageDone(float mod, float defaultMod = 2f)
		{
			return this.damagePercentageDone * this.damageScore * mod * defaultMod;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000428A File Offset: 0x0000248A
		public float GetScoredAndAddedDamagePercentageDone(float mod, float add, float defaultMod = 2f)
		{
			return this.damagePercentageDone * this.damageScore * mod * defaultMod + add;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000429F File Offset: 0x0000249F
		public float damagePercentagePerSecond
		{
			get
			{
				if (this.duration != 0f)
				{
					return this.damagePercentageDone / this.duration;
				}
				return 0f;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000042C1 File Offset: 0x000024C1
		public bool emotionAtMaxValue
		{
			get
			{
				return this.emotionAtMaxValueTimes > 0;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x000042CC File Offset: 0x000024CC
		public bool triggerMaxValue
		{
			get
			{
				return this.triggerMaxValueTimes > 0;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x000042D7 File Offset: 0x000024D7
		public float duration
		{
			get
			{
				return this.endTime - this.startTime;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x000042E6 File Offset: 0x000024E6
		public int frames
		{
			get
			{
				return this.endFrame - this.startFrame;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x000042F5 File Offset: 0x000024F5
		public bool isValid
		{
			get
			{
				return this.toID != null && this.toPart != SensitiveBodyPart.None && this.fromPart != TriggeringBodyPart.None && this.interationReceivedType != InterationReceivedType.None && this.emotion != Emotion.None && this.times > 0 && this.stacks > 0;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00004334 File Offset: 0x00002534
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x0000438E File Offset: 0x0000258E
		public DateTime date
		{
			get
			{
				if (this.m_date == null)
				{
					if (string.IsNullOrWhiteSpace(this.dateString))
					{
						this.m_date = new DateTime?(DateTime.MinValue);
					}
					else
					{
						this.m_date = new DateTime?(Interaction.Deserialize(this.dateString));
					}
				}
				return this.m_date.Value;
			}
			set
			{
				this.m_date = new DateTime?(value);
				this.dateString = Interaction.Serialize(value);
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000043A8 File Offset: 0x000025A8
		public InteractionToDisk ToDiskInter()
		{
			return new InteractionToDisk
			{
				fID = this.fromID,
				tID = this.toID,
				fP = this.fromPart,
				tP = this.toPart,
				typ = this.interationReceivedType,
				emo = this.emotion,
				dS = this.dateString,
				sT = this.startTime,
				eT = this.endTime,
				sF = this.startFrame,
				eF = this.endFrame,
				ts = this.stacks,
				tss = this.times,
				dmg = this.damagePercentageDone,
				emoMxTs = this.emotionAtMaxValueTimes,
				tggMxTs = this.triggerMaxValueTimes,
				off = this.overshootOrUndershootTotal,
				dmgS = this.damageScoreTotal
			};
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000044A8 File Offset: 0x000026A8
		public static string Serialize(DateTime dateTime)
		{
			return dateTime.ToString("o", CultureInfo.InvariantCulture);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000044BC File Offset: 0x000026BC
		public static DateTime Deserialize(string date)
		{
			if (string.IsNullOrWhiteSpace(date))
			{
				return DateTime.MinValue;
			}
			DateTime dateTime;
			if (DateTime.TryParseExact(date, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateTime))
			{
				return dateTime;
			}
			if (DateTime.TryParse(date, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
			{
				return dateTime;
			}
			if (DateTime.TryParse(date, out dateTime))
			{
				return dateTime;
			}
			return DateTime.MinValue;
		}

		// Token: 0x040000AF RID: 175
		[NonSerialized]
		private DateTime? m_date;

		// Token: 0x040000B0 RID: 176
		public string fromID;

		// Token: 0x040000B1 RID: 177
		public string toID;

		// Token: 0x040000B2 RID: 178
		public TriggeringBodyPart fromPart;

		// Token: 0x040000B3 RID: 179
		public SensitiveBodyPart toPart;

		// Token: 0x040000B4 RID: 180
		public InterationReceivedType interationReceivedType;

		// Token: 0x040000B5 RID: 181
		public Emotion emotion;

		// Token: 0x040000B6 RID: 182
		public string dateString;

		// Token: 0x040000B7 RID: 183
		public float startTime;

		// Token: 0x040000B8 RID: 184
		public float endTime;

		// Token: 0x040000B9 RID: 185
		public int startFrame;

		// Token: 0x040000BA RID: 186
		public int endFrame;

		// Token: 0x040000BB RID: 187
		public int times;

		// Token: 0x040000BC RID: 188
		public int stacks;

		// Token: 0x040000BD RID: 189
		public float damagePercentageDone;

		// Token: 0x040000BE RID: 190
		public int emotionAtMaxValueTimes;

		// Token: 0x040000BF RID: 191
		public int triggerMaxValueTimes;

		// Token: 0x040000C0 RID: 192
		public float overshootOrUndershootTotal;

		// Token: 0x040000C1 RID: 193
		public float damageScoreTotal;
	}
}
