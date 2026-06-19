using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000064 RID: 100
	[Serializable]
	public struct BuffOnEmotion : IIdentifiableBuff<ValueTuple<Emotion, EmotionModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnEmotion>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00004D8A File Offset: 0x00002F8A
		public bool isValid
		{
			get
			{
				return this.emotion != Emotion.None && this.modifier != EmotionModifier.None && this.operation != Operation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00004DB9 File Offset: 0x00002FB9
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00004DBC File Offset: 0x00002FBC
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

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00004E74 File Offset: 0x00003074
		public DisplayableBuffCategory category
		{
			get
			{
				return this.emotion.ParseToCategory();
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00004E84 File Offset: 0x00003084
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Emotion>(this.emotion, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<EmotionModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00004ED9 File Offset: 0x000030D9
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Feelings " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00004EF3 File Offset: 0x000030F3
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00004EFE File Offset: 0x000030FE
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

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00004F1F File Offset: 0x0000311F
		public ValueTuple<Emotion, EmotionModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<Emotion, EmotionModifier, Operation, int>(this.emotion, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00004F3E File Offset: 0x0000313E
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00004F4C File Offset: 0x0000314C
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00004F6D File Offset: 0x0000316D
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00004F78 File Offset: 0x00003178
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnEmotion))
			{
				return false;
			}
			BuffOnEmotion buffOnEmotion = (BuffOnEmotion)Other;
			return this.IsStackableWith(ref buffOnEmotion);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00004F9E File Offset: 0x0000319E
		public bool IsStackableWith(ref BuffOnEmotion Other)
		{
			return Other.emotion == this.emotion && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00004FDC File Offset: 0x000031DC
		public void StackToSelf(ref BuffOnEmotion Other)
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

		// Token: 0x06000218 RID: 536 RVA: 0x00005058 File Offset: 0x00003258
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnEmotion))
			{
				return;
			}
			BuffOnEmotion buffOnEmotion = (BuffOnEmotion)Other;
			this.StackToSelf(ref buffOnEmotion);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00005080 File Offset: 0x00003280
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

		// Token: 0x0600021A RID: 538 RVA: 0x000050EE File Offset: 0x000032EE
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnEmotion)obj);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000050FC File Offset: 0x000032FC
		public bool Equals(BuffOnEmotion p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00005108 File Offset: 0x00003308
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000512C File Offset: 0x0000332C
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

		// Token: 0x0600021E RID: 542 RVA: 0x00005190 File Offset: 0x00003390
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

		// Token: 0x0600021F RID: 543 RVA: 0x00005208 File Offset: 0x00003408
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

		// Token: 0x06000220 RID: 544 RVA: 0x000052F5 File Offset: 0x000034F5
		public static bool operator ==(BuffOnEmotion lhs, BuffOnEmotion rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000052FF File Offset: 0x000034FF
		public static bool operator !=(BuffOnEmotion lhs, BuffOnEmotion rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000104 RID: 260
		public Emotion emotion;

		// Token: 0x04000105 RID: 261
		public EmotionModifier modifier;

		// Token: 0x04000106 RID: 262
		public Operation operation;

		// Token: 0x04000107 RID: 263
		public int endHour;

		// Token: 0x04000108 RID: 264
		public float value;
	}
}
