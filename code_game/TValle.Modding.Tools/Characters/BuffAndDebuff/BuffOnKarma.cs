using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200006E RID: 110
	[Serializable]
	public struct BuffOnKarma : IIdentifiableBuff<ValueTuple<SimpleModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnKarma>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00007FB4 File Offset: 0x000061B4
		public bool isValid
		{
			get
			{
				return this.modifier != SimpleModifier.None && this.operation != Operation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00007FDB File Offset: 0x000061DB
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00007FE0 File Offset: 0x000061E0
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

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000306 RID: 774 RVA: 0x00008098 File Offset: 0x00006298
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000809B File Offset: 0x0000629B
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language) + " " + this.operation.GetOperationSymbolAndValue(UIValue);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000080BF File Offset: 0x000062BF
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Karma " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000309 RID: 777 RVA: 0x000080D9 File Offset: 0x000062D9
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600030A RID: 778 RVA: 0x000080E4 File Offset: 0x000062E4
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

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00008105 File Offset: 0x00006305
		public ValueTuple<SimpleModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<SimpleModifier, Operation, int>(this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000811E File Offset: 0x0000631E
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600030D RID: 781 RVA: 0x0000812C File Offset: 0x0000632C
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000814D File Offset: 0x0000634D
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00008158 File Offset: 0x00006358
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnKarma))
			{
				return false;
			}
			BuffOnKarma buffOnKarma = (BuffOnKarma)Other;
			return this.IsStackableWith(ref buffOnKarma);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000817E File Offset: 0x0000637E
		public bool IsStackableWith(ref BuffOnKarma Other)
		{
			return Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000081AC File Offset: 0x000063AC
		public void StackToSelf(ref BuffOnKarma Other)
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

		// Token: 0x06000312 RID: 786 RVA: 0x00008228 File Offset: 0x00006428
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnKarma))
			{
				return;
			}
			BuffOnKarma buffOnKarma = (BuffOnKarma)Other;
			this.StackToSelf(ref buffOnKarma);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00008250 File Offset: 0x00006450
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

		// Token: 0x06000314 RID: 788 RVA: 0x000082BE File Offset: 0x000064BE
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnKarma)obj);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000082CC File Offset: 0x000064CC
		public bool Equals(BuffOnKarma p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000082D8 File Offset: 0x000064D8
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000082FC File Offset: 0x000064FC
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

		// Token: 0x06000318 RID: 792 RVA: 0x00008360 File Offset: 0x00006560
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

		// Token: 0x06000319 RID: 793 RVA: 0x000083D8 File Offset: 0x000065D8
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

		// Token: 0x0600031A RID: 794 RVA: 0x00008458 File Offset: 0x00006658
		public static bool operator ==(BuffOnKarma lhs, BuffOnKarma rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00008462 File Offset: 0x00006662
		public static bool operator !=(BuffOnKarma lhs, BuffOnKarma rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400013A RID: 314
		public SimpleModifier modifier;

		// Token: 0x0400013B RID: 315
		public Operation operation;

		// Token: 0x0400013C RID: 316
		public int endHour;

		// Token: 0x0400013D RID: 317
		public float value;
	}
}
