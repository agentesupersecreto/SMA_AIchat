using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200006B RID: 107
	[Serializable]
	public struct BuffOnHoleWearingMotion : IIdentifiableBuff<ValueTuple<SensitiveFemaleHole, SimpleModifier, AddOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnHoleWearingMotion>, IStackableBuff, IEquatable<BuffOnHoleWearingMotion>, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00007090 File Offset: 0x00005290
		public bool isValid
		{
			get
			{
				return this.toPart != SensitiveFemaleHole.None && this.modifier != SimpleModifier.None && this.operation != AddOperation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x000070BF File Offset: 0x000052BF
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x000070C4 File Offset: 0x000052C4
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

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000717C File Offset: 0x0000537C
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00007180 File Offset: 0x00005380
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SensitiveFemaleHole>(this.toPart, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000071D5 File Offset: 0x000053D5
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Loose-Stroked " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002BE RID: 702 RVA: 0x000071EF File Offset: 0x000053EF
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000071FA File Offset: 0x000053FA
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

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x0000721B File Offset: 0x0000541B
		public ValueTuple<SensitiveFemaleHole, SimpleModifier, AddOperation, int> valueId
		{
			get
			{
				return new ValueTuple<SensitiveFemaleHole, SimpleModifier, AddOperation, int>(this.toPart, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x0000723A File Offset: 0x0000543A
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00007248 File Offset: 0x00005448
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00007269 File Offset: 0x00005469
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00007274 File Offset: 0x00005474
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnHoleWearingMotion))
			{
				return false;
			}
			BuffOnHoleWearingMotion buffOnHoleWearingMotion = (BuffOnHoleWearingMotion)Other;
			return this.IsStackableWith(ref buffOnHoleWearingMotion);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000729A File Offset: 0x0000549A
		public bool IsStackableWith(ref BuffOnHoleWearingMotion Other)
		{
			return Other.toPart == this.toPart && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000072D8 File Offset: 0x000054D8
		public void StackToSelf(ref BuffOnHoleWearingMotion Other)
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

		// Token: 0x060002C7 RID: 711 RVA: 0x00007334 File Offset: 0x00005534
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnHoleWearingMotion))
			{
				return;
			}
			BuffOnHoleWearingMotion buffOnHoleWearingMotion = (BuffOnHoleWearingMotion)Other;
			this.StackToSelf(ref buffOnHoleWearingMotion);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000735C File Offset: 0x0000555C
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

		// Token: 0x060002C9 RID: 713 RVA: 0x000073AA File Offset: 0x000055AA
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnHoleWearingMotion)obj);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x000073B8 File Offset: 0x000055B8
		public bool Equals(BuffOnHoleWearingMotion p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000073C4 File Offset: 0x000055C4
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000073E8 File Offset: 0x000055E8
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

		// Token: 0x060002CD RID: 717 RVA: 0x00007430 File Offset: 0x00005630
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

		// Token: 0x060002CE RID: 718 RVA: 0x00007484 File Offset: 0x00005684
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

		// Token: 0x060002CF RID: 719 RVA: 0x000074DE File Offset: 0x000056DE
		public static bool operator ==(BuffOnHoleWearingMotion lhs, BuffOnHoleWearingMotion rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000074E8 File Offset: 0x000056E8
		public static bool operator !=(BuffOnHoleWearingMotion lhs, BuffOnHoleWearingMotion rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x04000128 RID: 296
		public SensitiveFemaleHole toPart;

		// Token: 0x04000129 RID: 297
		public SimpleModifier modifier;

		// Token: 0x0400012A RID: 298
		public AddOperation operation;

		// Token: 0x0400012B RID: 299
		public int endHour;

		// Token: 0x0400012C RID: 300
		public float value;
	}
}
