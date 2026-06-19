using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000067 RID: 103
	[Serializable]
	public struct BuffOnEyaculationAmount : IIdentifiableBuff<ValueTuple<SimpleModifier, ProductOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnEyaculationAmount>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00005E73 File Offset: 0x00004073
		public bool isValid
		{
			get
			{
				return this.modifier != SimpleModifier.None && this.operation != ProductOperation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00005E9A File Offset: 0x0000409A
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00005EA0 File Offset: 0x000040A0
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

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00005F3B File Offset: 0x0000413B
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.pleasure;
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00005F3E File Offset: 0x0000413E
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language) + " " + this.operation.GetOperationSymbolAndValue(UIValue);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00005F62 File Offset: 0x00004162
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Desires " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00005F7C File Offset: 0x0000417C
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00005F87 File Offset: 0x00004187
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

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00005FA8 File Offset: 0x000041A8
		public ValueTuple<SimpleModifier, ProductOperation, int> valueId
		{
			get
			{
				return new ValueTuple<SimpleModifier, ProductOperation, int>(this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00005FC1 File Offset: 0x000041C1
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00005FD0 File Offset: 0x000041D0
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00005FF1 File Offset: 0x000041F1
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00005FFC File Offset: 0x000041FC
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnEyaculationAmount))
			{
				return false;
			}
			BuffOnEyaculationAmount buffOnEyaculationAmount = (BuffOnEyaculationAmount)Other;
			return this.IsStackableWith(ref buffOnEyaculationAmount);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00006022 File Offset: 0x00004222
		public bool IsStackableWith(ref BuffOnEyaculationAmount Other)
		{
			return Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00006050 File Offset: 0x00004250
		public void StackToSelf(ref BuffOnEyaculationAmount Other)
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

		// Token: 0x06000263 RID: 611 RVA: 0x000060AC File Offset: 0x000042AC
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnEyaculationAmount))
			{
				return;
			}
			BuffOnEyaculationAmount buffOnEyaculationAmount = (BuffOnEyaculationAmount)Other;
			this.StackToSelf(ref buffOnEyaculationAmount);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000060D4 File Offset: 0x000042D4
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

		// Token: 0x06000265 RID: 613 RVA: 0x00006127 File Offset: 0x00004327
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnEyaculationAmount)obj);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00006135 File Offset: 0x00004335
		public bool Equals(BuffOnEyaculationAmount p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00006140 File Offset: 0x00004340
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00006164 File Offset: 0x00004364
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

		// Token: 0x06000269 RID: 617 RVA: 0x000061AC File Offset: 0x000043AC
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

		// Token: 0x0600026A RID: 618 RVA: 0x00006204 File Offset: 0x00004404
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

		// Token: 0x0600026B RID: 619 RVA: 0x0000625E File Offset: 0x0000445E
		public static bool operator ==(BuffOnEyaculationAmount lhs, BuffOnEyaculationAmount rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00006268 File Offset: 0x00004468
		public static bool operator !=(BuffOnEyaculationAmount lhs, BuffOnEyaculationAmount rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000114 RID: 276
		public SimpleModifier modifier;

		// Token: 0x04000115 RID: 277
		public ProductOperation operation;

		// Token: 0x04000116 RID: 278
		public int endHour;

		// Token: 0x04000117 RID: 279
		public float value;
	}
}
