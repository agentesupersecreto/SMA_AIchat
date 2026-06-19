using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public struct BuffOnEmotionAura : IIdentifiableBuff<ValueTuple<Emotion, SimpleEmotionModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnEmotionAura>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000530B File Offset: 0x0000350B
		public bool isValid
		{
			get
			{
				return this.emotion != Emotion.None && this.modifier != SimpleEmotionModifier.None && this.operation != Operation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000533A File Offset: 0x0000353A
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00005340 File Offset: 0x00003540
		public string DebugPrint()
		{
			string[] array = new string[9];
			array[0] = this.emotion.ToString();
			array[1] = "->";
			array[2] = this.modifier.ToString();
			array[3] = "->";
			array[4] = this.operation.ToString();
			array[5] = " End:";
			int num = 6;
			string text = ((this.endHour < 0) ? "∞" : DateTime.MinValue.AddHours((double)this.endHour));
			array[num] = ((text != null) ? text.ToString() : null);
			array[7] = " By:";
			array[8] = this.value.ToString();
			return string.Concat(array);
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000225 RID: 549 RVA: 0x000053F8 File Offset: 0x000035F8
		public DisplayableBuffCategory category
		{
			get
			{
				return this.emotion.ParseToCategory();
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00005408 File Offset: 0x00003608
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Emotion>(this.emotion, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleEmotionModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000545D File Offset: 0x0000365D
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Aura " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00005477 File Offset: 0x00003677
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00005482 File Offset: 0x00003682
		public DateTime endTime
		{
			get
			{
				if (!this.infinite)
				{
					return DateTime.MinValue.AddHours((double)this.endHour);
				}
				return DateTime.MaxValue;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600022A RID: 554 RVA: 0x000054A3 File Offset: 0x000036A3
		public ValueTuple<Emotion, SimpleEmotionModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<Emotion, SimpleEmotionModifier, Operation, int>(this.emotion, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600022B RID: 555 RVA: 0x000054C2 File Offset: 0x000036C2
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600022C RID: 556 RVA: 0x000054D0 File Offset: 0x000036D0
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600022D RID: 557 RVA: 0x000054F1 File Offset: 0x000036F1
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000054FC File Offset: 0x000036FC
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnEmotionAura))
			{
				return false;
			}
			BuffOnEmotionAura buffOnEmotionAura = (BuffOnEmotionAura)Other;
			return this.IsStackableWith(ref buffOnEmotionAura);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00005522 File Offset: 0x00003722
		public bool IsStackableWith(ref BuffOnEmotionAura Other)
		{
			return Other.emotion == this.emotion && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00005560 File Offset: 0x00003760
		public void StackToSelf(ref BuffOnEmotionAura Other)
		{
			if (!Other.ValueIsValid())
			{
				return;
			}
			switch (this.operation)
			{
			case Operation.None:
				return;
			case Operation.add:
				this.value += Other.value;
				return;
			case Operation.mult:
				this.value *= Other.value;
				return;
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000055DC File Offset: 0x000037DC
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnEmotionAura))
			{
				return;
			}
			BuffOnEmotionAura buffOnEmotionAura = (BuffOnEmotionAura)Other;
			this.StackToSelf(ref buffOnEmotionAura);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00005604 File Offset: 0x00003804
		public void InverseValue()
		{
			if (this.value == 0f)
			{
				return;
			}
			switch (this.operation)
			{
			case Operation.None:
				return;
			case Operation.add:
				this.value = -this.value;
				return;
			case Operation.mult:
				this.value = 1f / this.value;
				return;
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00005672 File Offset: 0x00003872
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnEmotionAura)obj);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00005680 File Offset: 0x00003880
		public bool Equals(BuffOnEmotionAura p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000568C File Offset: 0x0000388C
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000056B0 File Offset: 0x000038B0
		public bool ValueIsEmpty()
		{
			switch (this.operation)
			{
			case Operation.None:
				return true;
			case Operation.add:
				return Mathf.Approximately(this.value, 0f);
			case Operation.mult:
				return Mathf.Approximately(this.value, 1f);
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00005714 File Offset: 0x00003914
		public bool ValueIsDisplayable()
		{
			if (this.ValueIsEmpty())
			{
				return false;
			}
			switch (this.operation)
			{
			case Operation.None:
				return false;
			case Operation.add:
				return Mathf.Abs(this.value) > 0.01f;
			case Operation.mult:
				return Mathf.Abs(this.value - 1f) > 0.001f;
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000578C File Offset: 0x0000398C
		public int ValuePriorty()
		{
			if (this.ValueIsEmpty())
			{
				return 0;
			}
			float num = (this.emotion.IsGood() ? 1f : (-1f));
			switch (this.operation)
			{
			case Operation.None:
				return 0;
			case Operation.add:
				if (this.emotion != Emotion.arousal)
				{
					return this.CalcAddingValuePriority(-10f * num, 10f * num);
				}
				return this.CalcAddingValuePriority(-3f, 3f);
			case Operation.mult:
				if (this.emotion != Emotion.arousal)
				{
					return this.CalcMultiplyValuePriority(-50f * num, 50f * num);
				}
				return this.CalcAddingValuePriority(-20f, 20f);
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00005879 File Offset: 0x00003A79
		public static bool operator ==(BuffOnEmotionAura lhs, BuffOnEmotionAura rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00005883 File Offset: 0x00003A83
		public static bool operator !=(BuffOnEmotionAura lhs, BuffOnEmotionAura rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000109 RID: 265
		public Emotion emotion;

		// Token: 0x0400010A RID: 266
		public SimpleEmotionModifier modifier;

		// Token: 0x0400010B RID: 267
		public Operation operation;

		// Token: 0x0400010C RID: 268
		public int endHour;

		// Token: 0x0400010D RID: 269
		public float value;
	}
}
