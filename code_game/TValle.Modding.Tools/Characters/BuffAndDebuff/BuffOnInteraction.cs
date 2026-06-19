using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200006D RID: 109
	[Serializable]
	public struct BuffOnInteraction : IIdentifiableBuff<ValueTuple<InterationReceivedType, TriggeringBodyPart, SensitiveBodyPart, Emotion, InteractionModifier, ProductOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnInteraction>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00007958 File Offset: 0x00005B58
		public bool isValid
		{
			get
			{
				return this.emotion != Emotion.None && this.interationReceivedType != InterationReceivedType.None && this.fromPart != TriggeringBodyPart.None && this.toPart != SensitiveBodyPart.None && this.modifier != InteractionModifier.None && this.operation != ProductOperation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002EB RID: 747 RVA: 0x000079AA File Offset: 0x00005BAA
		public bool isContextValid
		{
			get
			{
				return this.interationReceivedType.IsContextValid(this.emotion);
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000079C0 File Offset: 0x00005BC0
		public string DebugPrint()
		{
			string[] array = new string[13];
			array[0] = this.interationReceivedType.ToString();
			array[1] = "->";
			array[2] = this.fromPart.ToString();
			array[3] = "->";
			array[4] = this.toPart.ToString();
			array[5] = "->";
			array[6] = this.modifier.ToString();
			array[7] = "->";
			array[8] = this.operation.ToString();
			array[9] = " End:";
			int num = 10;
			string text = ((this.endHour < 0) ? "∞" : DateTime.MinValue.AddHours((double)this.endHour));
			array[num] = ((text != null) ? text.ToString() : null);
			array[11] = " By:";
			array[12] = this.value.ToString();
			return string.Concat(array);
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00007AB4 File Offset: 0x00005CB4
		public DisplayableBuffCategory category
		{
			get
			{
				return this.emotion.ParseToCategory();
			}
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00007AC4 File Offset: 0x00005CC4
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<TriggeringBodyPart>(this.fromPart, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<InterationReceivedType>(this.interationReceivedType, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SensitiveBodyPart>(this.toPart, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Emotion>(this.emotion, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<InteractionModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00007B61 File Offset: 0x00005D61
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Interaction " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00007B7B File Offset: 0x00005D7B
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00007B86 File Offset: 0x00005D86
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

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00007BA7 File Offset: 0x00005DA7
		public ValueTuple<InterationReceivedType, TriggeringBodyPart, SensitiveBodyPart, Emotion, InteractionModifier, ProductOperation, int> valueId
		{
			get
			{
				return new ValueTuple<InterationReceivedType, TriggeringBodyPart, SensitiveBodyPart, Emotion, InteractionModifier, ProductOperation, int>(this.interationReceivedType, this.fromPart, this.toPart, this.emotion, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x00007BD8 File Offset: 0x00005DD8
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00007BE8 File Offset: 0x00005DE8
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00007C09 File Offset: 0x00005E09
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00007C14 File Offset: 0x00005E14
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnInteraction))
			{
				return false;
			}
			BuffOnInteraction buffOnInteraction = (BuffOnInteraction)Other;
			return this.IsStackableWith(ref buffOnInteraction);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00007C3C File Offset: 0x00005E3C
		public bool IsStackableWith(ref BuffOnInteraction Other)
		{
			return Other.interationReceivedType == this.interationReceivedType && Other.fromPart == this.fromPart && Other.toPart == this.toPart && Other.emotion == this.emotion && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00007CB0 File Offset: 0x00005EB0
		public void StackToSelf(ref BuffOnInteraction Other)
		{
			if (!Other.ValueIsValid())
			{
				return;
			}
			ProductOperation productOperation = this.operation;
			if (productOperation == ProductOperation.None)
			{
				return;
			}
			if (productOperation == ProductOperation.mult)
			{
				this.value *= Other.value;
				return;
			}
			throw new ArgumentOutOfRangeException(this.operation.ToString());
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00007D0C File Offset: 0x00005F0C
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnInteraction))
			{
				return;
			}
			BuffOnInteraction buffOnInteraction = (BuffOnInteraction)Other;
			this.StackToSelf(ref buffOnInteraction);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00007D34 File Offset: 0x00005F34
		public void InverseValue()
		{
			if (this.value == 0f)
			{
				return;
			}
			ProductOperation productOperation = this.operation;
			if (productOperation == ProductOperation.None)
			{
				return;
			}
			if (productOperation == ProductOperation.mult)
			{
				this.value = 1f / this.value;
				return;
			}
			throw new ArgumentOutOfRangeException(this.operation.ToString());
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00007D87 File Offset: 0x00005F87
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnInteraction)obj);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00007D95 File Offset: 0x00005F95
		public bool Equals(BuffOnInteraction p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00007DA0 File Offset: 0x00005FA0
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00007DC4 File Offset: 0x00005FC4
		public bool ValueIsEmpty()
		{
			ProductOperation productOperation = this.operation;
			if (productOperation == ProductOperation.None)
			{
				return true;
			}
			if (productOperation != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			return Mathf.Approximately(this.value, 1f);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00007E0C File Offset: 0x0000600C
		public bool ValueIsDisplayable()
		{
			if (this.ValueIsEmpty())
			{
				return false;
			}
			ProductOperation productOperation = this.operation;
			if (productOperation == ProductOperation.None)
			{
				return false;
			}
			if (productOperation != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			return Mathf.Abs(this.value - 1f) > 0.001f;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00007E64 File Offset: 0x00006064
		public int ValuePriorty()
		{
			if (this.ValueIsEmpty())
			{
				return 0;
			}
			float num = (this.emotion.IsGood() ? 1f : (-1f));
			ProductOperation productOperation = this.operation;
			if (productOperation == ProductOperation.None)
			{
				return 0;
			}
			if (productOperation != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			switch (this.modifier)
			{
			case InteractionModifier.None:
				return 0;
			case InteractionModifier.damage:
				return this.CalcMultiplyValuePriority(-33f * num, 33f * num);
			case InteractionModifier.gainIntervalExpand:
				return this.CalcMultiplyValuePriority(-33f * num, 33f * num);
			case InteractionModifier.gainMinMaxIntervalPosition:
				return this.CalcMultiplyValuePriority(33f * num, -33f * num);
			case InteractionModifier.gainMinIntervalPosition:
				return this.CalcMultiplyValuePriority(33f * num, -33f * num);
			case InteractionModifier.gainMaxIntervalPosition:
				return this.CalcMultiplyValuePriority(33f * num, -33f * num);
			default:
				throw new ArgumentOutOfRangeException(this.modifier.ToString());
			}
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00007F9E File Offset: 0x0000619E
		public static bool operator ==(BuffOnInteraction lhs, BuffOnInteraction rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00007FA8 File Offset: 0x000061A8
		public static bool operator !=(BuffOnInteraction lhs, BuffOnInteraction rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000132 RID: 306
		public InterationReceivedType interationReceivedType;

		// Token: 0x04000133 RID: 307
		public TriggeringBodyPart fromPart;

		// Token: 0x04000134 RID: 308
		public SensitiveBodyPart toPart;

		// Token: 0x04000135 RID: 309
		public Emotion emotion;

		// Token: 0x04000136 RID: 310
		public InteractionModifier modifier;

		// Token: 0x04000137 RID: 311
		public ProductOperation operation;

		// Token: 0x04000138 RID: 312
		public int endHour;

		// Token: 0x04000139 RID: 313
		public float value;
	}
}
