using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000066 RID: 102
	[Serializable]
	public struct BuffOnEmotionTowardCharacter : IIdentifiableBuff<ValueTuple<string, Emotion, EmotionModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnEmotionTowardCharacter>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000588F File Offset: 0x00003A8F
		public bool isValid
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.towardID) && this.emotion != Emotion.None && this.modifier != EmotionModifier.None && this.operation != Operation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000058CB File Offset: 0x00003ACB
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000058D0 File Offset: 0x00003AD0
		public string DebugPrint()
		{
			string[] array = new string[11];
			array[0] = this.towardID.ToString();
			array[1] = "->";
			array[2] = this.emotion.ToString();
			array[3] = "->";
			array[4] = this.modifier.ToString();
			array[5] = "->";
			array[6] = this.operation.ToString();
			array[7] = " End:";
			int num = 8;
			string text = ((this.endHour < 0) ? "∞" : DateTime.MinValue.AddHours((double)this.endHour));
			array[num] = ((text != null) ? text.ToString() : null);
			array[9] = " By:";
			array[10] = this.value.ToString();
			return string.Concat(array);
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000059A0 File Offset: 0x00003BA0
		public DisplayableBuffCategory category
		{
			get
			{
				return this.emotion.ParseToCategory();
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x000059B0 File Offset: 0x00003BB0
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				characterNameGetter(this.towardID),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Emotion>(this.emotion, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<EmotionModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00005A1C File Offset: 0x00003C1C
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Feelings Towards " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000241 RID: 577 RVA: 0x00005A36 File Offset: 0x00003C36
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00005A41 File Offset: 0x00003C41
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

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00005A62 File Offset: 0x00003C62
		public ValueTuple<string, Emotion, EmotionModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<string, Emotion, EmotionModifier, Operation, int>(this.towardID, this.emotion, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00005A87 File Offset: 0x00003C87
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00005A94 File Offset: 0x00003C94
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00005AB5 File Offset: 0x00003CB5
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00005AC0 File Offset: 0x00003CC0
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnEmotionTowardCharacter))
			{
				return false;
			}
			BuffOnEmotionTowardCharacter buffOnEmotionTowardCharacter = (BuffOnEmotionTowardCharacter)Other;
			return this.IsStackableWith(ref buffOnEmotionTowardCharacter);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00005AE8 File Offset: 0x00003CE8
		public bool IsStackableWith(ref BuffOnEmotionTowardCharacter Other)
		{
			return Other.towardID == this.towardID && Other.emotion == this.emotion && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00005B44 File Offset: 0x00003D44
		public void StackToSelf(ref BuffOnEmotionTowardCharacter Other)
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

		// Token: 0x0600024A RID: 586 RVA: 0x00005BC0 File Offset: 0x00003DC0
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnEmotionTowardCharacter))
			{
				return;
			}
			BuffOnEmotionTowardCharacter buffOnEmotionTowardCharacter = (BuffOnEmotionTowardCharacter)Other;
			this.StackToSelf(ref buffOnEmotionTowardCharacter);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00005BE8 File Offset: 0x00003DE8
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

		// Token: 0x0600024C RID: 588 RVA: 0x00005C56 File Offset: 0x00003E56
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnEmotionTowardCharacter)obj);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00005C64 File Offset: 0x00003E64
		public bool Equals(BuffOnEmotionTowardCharacter p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00005C70 File Offset: 0x00003E70
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00005C94 File Offset: 0x00003E94
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

		// Token: 0x06000250 RID: 592 RVA: 0x00005CF8 File Offset: 0x00003EF8
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

		// Token: 0x06000251 RID: 593 RVA: 0x00005D70 File Offset: 0x00003F70
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

		// Token: 0x06000252 RID: 594 RVA: 0x00005E5D File Offset: 0x0000405D
		public static bool operator ==(BuffOnEmotionTowardCharacter lhs, BuffOnEmotionTowardCharacter rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00005E67 File Offset: 0x00004067
		public static bool operator !=(BuffOnEmotionTowardCharacter lhs, BuffOnEmotionTowardCharacter rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400010E RID: 270
		public string towardID;

		// Token: 0x0400010F RID: 271
		public Emotion emotion;

		// Token: 0x04000110 RID: 272
		public EmotionModifier modifier;

		// Token: 0x04000111 RID: 273
		public Operation operation;

		// Token: 0x04000112 RID: 274
		public int endHour;

		// Token: 0x04000113 RID: 275
		public float value;
	}
}
