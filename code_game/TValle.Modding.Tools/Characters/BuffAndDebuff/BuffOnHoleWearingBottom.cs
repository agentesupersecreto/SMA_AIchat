using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200006A RID: 106
	[Serializable]
	public struct BuffOnHoleWearingBottom : IIdentifiableBuff<ValueTuple<SensitiveFemaleHoleBottom, SimpleModifier, AddOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnHoleWearingBottom>, IStackableBuff, IEquatable<BuffOnHoleWearingBottom>, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00006C2E File Offset: 0x00004E2E
		public bool isValid
		{
			get
			{
				return this.toPart != SensitiveFemaleHoleBottom.None && this.modifier != SimpleModifier.None && this.operation != AddOperation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00006C5D File Offset: 0x00004E5D
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00006C60 File Offset: 0x00004E60
		public string DebugPrint()
		{
			string[] array = new string[9];
			array[0] = this.toPart.ToString();
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

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00006D18 File Offset: 0x00004F18
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00006D1C File Offset: 0x00004F1C
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SensitiveFemaleHoleBottom>(this.toPart, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00006D71 File Offset: 0x00004F71
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Deep-Stretched " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00006D8B File Offset: 0x00004F8B
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00006D96 File Offset: 0x00004F96
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

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00006DB7 File Offset: 0x00004FB7
		public ValueTuple<SensitiveFemaleHoleBottom, SimpleModifier, AddOperation, int> valueId
		{
			get
			{
				return new ValueTuple<SensitiveFemaleHoleBottom, SimpleModifier, AddOperation, int>(this.toPart, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00006DD6 File Offset: 0x00004FD6
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00006DE4 File Offset: 0x00004FE4
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00006E05 File Offset: 0x00005005
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00006E10 File Offset: 0x00005010
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnHoleWearingBottom))
			{
				return false;
			}
			BuffOnHoleWearingBottom buffOnHoleWearingBottom = (BuffOnHoleWearingBottom)Other;
			return this.IsStackableWith(ref buffOnHoleWearingBottom);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00006E36 File Offset: 0x00005036
		public bool IsStackableWith(ref BuffOnHoleWearingBottom Other)
		{
			return Other.toPart == this.toPart && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00006E74 File Offset: 0x00005074
		public void StackToSelf(ref BuffOnHoleWearingBottom Other)
		{
			if (!Other.ValueIsValid())
			{
				return;
			}
			AddOperation addOperation = this.operation;
			if (addOperation == AddOperation.None)
			{
				return;
			}
			if (addOperation == AddOperation.add)
			{
				this.value += Other.value;
				return;
			}
			throw new ArgumentOutOfRangeException(this.operation.ToString());
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00006ED0 File Offset: 0x000050D0
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnHoleWearingBottom))
			{
				return;
			}
			BuffOnHoleWearingBottom buffOnHoleWearingBottom = (BuffOnHoleWearingBottom)Other;
			this.StackToSelf(ref buffOnHoleWearingBottom);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00006EF8 File Offset: 0x000050F8
		public void InverseValue()
		{
			if (this.value == 0f)
			{
				return;
			}
			AddOperation addOperation = this.operation;
			if (addOperation == AddOperation.None)
			{
				return;
			}
			if (addOperation == AddOperation.add)
			{
				this.value = -this.value;
				return;
			}
			throw new ArgumentOutOfRangeException(this.operation.ToString());
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00006F46 File Offset: 0x00005146
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnHoleWearingBottom)obj);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00006F54 File Offset: 0x00005154
		public bool Equals(BuffOnHoleWearingBottom p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00006F60 File Offset: 0x00005160
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00006F84 File Offset: 0x00005184
		public bool ValueIsEmpty()
		{
			AddOperation addOperation = this.operation;
			if (addOperation == AddOperation.None)
			{
				return true;
			}
			if (addOperation != AddOperation.add)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			return Mathf.Approximately(this.value, 0f);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00006FCC File Offset: 0x000051CC
		public bool ValueIsDisplayable()
		{
			if (this.ValueIsEmpty())
			{
				return false;
			}
			AddOperation addOperation = this.operation;
			if (addOperation == AddOperation.None)
			{
				return false;
			}
			if (addOperation != AddOperation.add)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			return Mathf.Abs(this.value) > 0.01f;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00007020 File Offset: 0x00005220
		public int ValuePriorty()
		{
			if (this.ValueIsEmpty())
			{
				return 0;
			}
			AddOperation addOperation = this.operation;
			if (addOperation == AddOperation.None)
			{
				return 0;
			}
			if (addOperation != AddOperation.add)
			{
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
			return this.CalcAddingValuePriority(33f, -33f);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000707A File Offset: 0x0000527A
		public static bool operator ==(BuffOnHoleWearingBottom lhs, BuffOnHoleWearingBottom rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00007084 File Offset: 0x00005284
		public static bool operator !=(BuffOnHoleWearingBottom lhs, BuffOnHoleWearingBottom rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000123 RID: 291
		public SensitiveFemaleHoleBottom toPart;

		// Token: 0x04000124 RID: 292
		public SimpleModifier modifier;

		// Token: 0x04000125 RID: 293
		public AddOperation operation;

		// Token: 0x04000126 RID: 294
		public int endHour;

		// Token: 0x04000127 RID: 295
		public float value;
	}
}
