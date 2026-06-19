using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000068 RID: 104
	[Serializable]
	public struct BuffOnEyaculationTimes : IIdentifiableBuff<ValueTuple<SimpleModifier, ProductOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnEyaculationTimes>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00006274 File Offset: 0x00004474
		public bool isValid
		{
			get
			{
				return this.modifier != SimpleModifier.None && this.operation != ProductOperation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0000629B File Offset: 0x0000449B
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000062A0 File Offset: 0x000044A0
		public string DebugPrint()
		{
			string[] array = new string[7];
			array[0] = this.modifier.ToString();
			array[1] = "->";
			array[2] = this.operation.ToString();
			array[3] = " End:";
			int num = 4;
			string text = ((this.endHour < 0) ? "∞" : DateTime.MinValue.AddHours((double)this.endHour));
			array[num] = ((text != null) ? text.ToString() : null);
			array[5] = " By:";
			array[6] = this.value.ToString();
			return string.Concat(array);
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000633B File Offset: 0x0000453B
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.pleasure;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000633E File Offset: 0x0000453E
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language) + " " + this.operation.GetOperationSymbolAndValue(UIValue);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00006362 File Offset: 0x00004562
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Desires " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000273 RID: 627 RVA: 0x0000637C File Offset: 0x0000457C
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00006387 File Offset: 0x00004587
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

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000275 RID: 629 RVA: 0x000063A8 File Offset: 0x000045A8
		public ValueTuple<SimpleModifier, ProductOperation, int> valueId
		{
			get
			{
				return new ValueTuple<SimpleModifier, ProductOperation, int>(this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000276 RID: 630 RVA: 0x000063C1 File Offset: 0x000045C1
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000277 RID: 631 RVA: 0x000063D0 File Offset: 0x000045D0
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000278 RID: 632 RVA: 0x000063F1 File Offset: 0x000045F1
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000063FC File Offset: 0x000045FC
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnEyaculationTimes))
			{
				return false;
			}
			BuffOnEyaculationTimes buffOnEyaculationTimes = (BuffOnEyaculationTimes)Other;
			return this.IsStackableWith(ref buffOnEyaculationTimes);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00006422 File Offset: 0x00004622
		public bool IsStackableWith(ref BuffOnEyaculationTimes Other)
		{
			return Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00006450 File Offset: 0x00004650
		public void StackToSelf(ref BuffOnEyaculationTimes Other)
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

		// Token: 0x0600027C RID: 636 RVA: 0x000064AC File Offset: 0x000046AC
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnEyaculationTimes))
			{
				return;
			}
			BuffOnEyaculationTimes buffOnEyaculationTimes = (BuffOnEyaculationTimes)Other;
			this.StackToSelf(ref buffOnEyaculationTimes);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000064D4 File Offset: 0x000046D4
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

		// Token: 0x0600027E RID: 638 RVA: 0x00006527 File Offset: 0x00004727
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnEyaculationTimes)obj);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00006535 File Offset: 0x00004735
		public bool Equals(BuffOnEyaculationTimes p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00006540 File Offset: 0x00004740
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00006564 File Offset: 0x00004764
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

		// Token: 0x06000282 RID: 642 RVA: 0x000065AC File Offset: 0x000047AC
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

		// Token: 0x06000283 RID: 643 RVA: 0x00006604 File Offset: 0x00004804
		public int ValuePriorty()
		{
			if (this.ValueIsEmpty())
			{
				return 0;
			}
			ProductOperation productOperation = this.operation;
			if (productOperation == ProductOperation.None)
			{
				return 0;
			}
			if (productOperation != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			return this.CalcMultiplyValuePriority(-33f, 33f);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000665E File Offset: 0x0000485E
		public static bool operator ==(BuffOnEyaculationTimes lhs, BuffOnEyaculationTimes rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00006668 File Offset: 0x00004868
		public static bool operator !=(BuffOnEyaculationTimes lhs, BuffOnEyaculationTimes rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000118 RID: 280
		public SimpleModifier modifier;

		// Token: 0x04000119 RID: 281
		public ProductOperation operation;

		// Token: 0x0400011A RID: 282
		public int endHour;

		// Token: 0x0400011B RID: 283
		public float value;
	}
}
