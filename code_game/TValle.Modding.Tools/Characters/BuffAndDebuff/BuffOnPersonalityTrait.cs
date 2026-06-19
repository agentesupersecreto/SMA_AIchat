using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public struct BuffOnPersonalityTrait : IIdentifiableBuff<ValueTuple<PersonalityTraits, SimpleModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnPersonalityTrait>, IStackableBuff, IEquatable<BuffOnPersonalityTrait>, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00008880 File Offset: 0x00006A80
		public bool isValid
		{
			get
			{
				return this.trait != PersonalityTraits.None && this.modifier != SimpleModifier.None && this.operation != Operation.None && this.endHour != 0;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000336 RID: 822 RVA: 0x000088A5 File Offset: 0x00006AA5
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000088A8 File Offset: 0x00006AA8
		public string DebugPrint()
		{
			string[] array = new string[9];
			array[0] = this.trait.ToString();
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

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00008960 File Offset: 0x00006B60
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00008964 File Offset: 0x00006B64
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<PersonalityTraits>(this.trait, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000089B9 File Offset: 0x00006BB9
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Personality Trait " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600033B RID: 827 RVA: 0x000089D3 File Offset: 0x00006BD3
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600033C RID: 828 RVA: 0x000089DE File Offset: 0x00006BDE
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

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600033D RID: 829 RVA: 0x000089FF File Offset: 0x00006BFF
		public ValueTuple<PersonalityTraits, SimpleModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<PersonalityTraits, SimpleModifier, Operation, int>(this.trait, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00008A1E File Offset: 0x00006C1E
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600033F RID: 831 RVA: 0x00008A2C File Offset: 0x00006C2C
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00008A4D File Offset: 0x00006C4D
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00008A58 File Offset: 0x00006C58
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnPersonalityTrait))
			{
				return false;
			}
			BuffOnPersonalityTrait buffOnPersonalityTrait = (BuffOnPersonalityTrait)Other;
			return this.IsStackableWith(ref buffOnPersonalityTrait);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00008A7E File Offset: 0x00006C7E
		public bool IsStackableWith(ref BuffOnPersonalityTrait Other)
		{
			return Other.trait == this.trait && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00008ABC File Offset: 0x00006CBC
		public void StackToSelf(ref BuffOnPersonalityTrait Other)
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

		// Token: 0x06000344 RID: 836 RVA: 0x00008B38 File Offset: 0x00006D38
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnPersonalityTrait))
			{
				return;
			}
			BuffOnPersonalityTrait buffOnPersonalityTrait = (BuffOnPersonalityTrait)Other;
			this.StackToSelf(ref buffOnPersonalityTrait);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00008B60 File Offset: 0x00006D60
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

		// Token: 0x06000346 RID: 838 RVA: 0x00008BCE File Offset: 0x00006DCE
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnPersonalityTrait)obj);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00008BDC File Offset: 0x00006DDC
		public bool Equals(BuffOnPersonalityTrait p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00008BE8 File Offset: 0x00006DE8
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00008C0C File Offset: 0x00006E0C
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

		// Token: 0x0600034A RID: 842 RVA: 0x00008C70 File Offset: 0x00006E70
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

		// Token: 0x0600034B RID: 843 RVA: 0x00008CE8 File Offset: 0x00006EE8
		public int ValuePriorty()
		{
			if (this.ValueIsEmpty())
			{
				return 0;
			}
			switch (this.operation)
			{
			case Operation.None:
				return 0;
			case Operation.add:
				return this.CalcAddingValuePriority(-10f, 10f);
			case Operation.mult:
				return this.CalcMultiplyValuePriority(-100f, 100f);
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00008D68 File Offset: 0x00006F68
		public static bool operator ==(BuffOnPersonalityTrait lhs, BuffOnPersonalityTrait rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00008D72 File Offset: 0x00006F72
		public static bool operator !=(BuffOnPersonalityTrait lhs, BuffOnPersonalityTrait rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000142 RID: 322
		public PersonalityTraits trait;

		// Token: 0x04000143 RID: 323
		public SimpleModifier modifier;

		// Token: 0x04000144 RID: 324
		public Operation operation;

		// Token: 0x04000145 RID: 325
		public int endHour;

		// Token: 0x04000146 RID: 326
		public float value;
	}
}
