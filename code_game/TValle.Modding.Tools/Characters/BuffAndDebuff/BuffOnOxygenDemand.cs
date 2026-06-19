using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200006F RID: 111
	[Serializable]
	public struct BuffOnOxygenDemand : IIdentifiableBuff<ValueTuple<SimpleModifier, ProductOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnOxygenDemand>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000846E File Offset: 0x0000666E
		public bool isValid
		{
			get
			{
				return this.modifier != SimpleModifier.None && this.operation != ProductOperation.None && this.endHour != 0;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000848B File Offset: 0x0000668B
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00008490 File Offset: 0x00006690
		public string DebugPrint()
		{
			string[] array = new string[9];
			array[0] = this.modifier.ToString();
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00008548 File Offset: 0x00006748
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000854B File Offset: 0x0000674B
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language) + " " + this.operation.GetOperationSymbolAndValue(UIValue);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000856F File Offset: 0x0000676F
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Fatigability " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00008589 File Offset: 0x00006789
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00008594 File Offset: 0x00006794
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000324 RID: 804 RVA: 0x000085B5 File Offset: 0x000067B5
		public ValueTuple<SimpleModifier, ProductOperation, int> valueId
		{
			get
			{
				return new ValueTuple<SimpleModifier, ProductOperation, int>(this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000325 RID: 805 RVA: 0x000085CE File Offset: 0x000067CE
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000085DC File Offset: 0x000067DC
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000327 RID: 807 RVA: 0x000085FD File Offset: 0x000067FD
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00008608 File Offset: 0x00006808
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnOxygenDemand))
			{
				return false;
			}
			BuffOnOxygenDemand buffOnOxygenDemand = (BuffOnOxygenDemand)Other;
			return this.IsStackableWith(ref buffOnOxygenDemand);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000862E File Offset: 0x0000682E
		public bool IsStackableWith(ref BuffOnOxygenDemand Other)
		{
			return Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000865C File Offset: 0x0000685C
		public void StackToSelf(ref BuffOnOxygenDemand Other)
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

		// Token: 0x0600032B RID: 811 RVA: 0x000086B8 File Offset: 0x000068B8
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnOxygenDemand))
			{
				return;
			}
			BuffOnOxygenDemand buffOnOxygenDemand = (BuffOnOxygenDemand)Other;
			this.StackToSelf(ref buffOnOxygenDemand);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x000086E0 File Offset: 0x000068E0
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

		// Token: 0x0600032D RID: 813 RVA: 0x00008733 File Offset: 0x00006933
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnOxygenDemand)obj);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00008741 File Offset: 0x00006941
		public bool Equals(BuffOnOxygenDemand p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000874C File Offset: 0x0000694C
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00008770 File Offset: 0x00006970
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

		// Token: 0x06000331 RID: 817 RVA: 0x000087B8 File Offset: 0x000069B8
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

		// Token: 0x06000332 RID: 818 RVA: 0x00008810 File Offset: 0x00006A10
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

		// Token: 0x06000333 RID: 819 RVA: 0x0000886A File Offset: 0x00006A6A
		public static bool operator ==(BuffOnOxygenDemand lhs, BuffOnOxygenDemand rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00008874 File Offset: 0x00006A74
		public static bool operator !=(BuffOnOxygenDemand lhs, BuffOnOxygenDemand rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400013E RID: 318
		public SimpleModifier modifier;

		// Token: 0x0400013F RID: 319
		public ProductOperation operation;

		// Token: 0x04000140 RID: 320
		public int endHour;

		// Token: 0x04000141 RID: 321
		public float value;
	}
}
