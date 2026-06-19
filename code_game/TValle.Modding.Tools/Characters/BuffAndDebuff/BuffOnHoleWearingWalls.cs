using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public struct BuffOnHoleWearingWalls : IIdentifiableBuff<ValueTuple<SensitiveFemaleHoleWalls, SimpleModifier, AddOperation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnHoleWearingWalls>, IStackableBuff, IEquatable<BuffOnHoleWearingWalls>, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000074F4 File Offset: 0x000056F4
		public bool isValid
		{
			get
			{
				return this.toPart != SensitiveFemaleHoleWalls.None && this.modifier != SimpleModifier.None && this.operation != AddOperation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00007523 File Offset: 0x00005723
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00007528 File Offset: 0x00005728
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

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x000075E0 File Offset: 0x000057E0
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000075E4 File Offset: 0x000057E4
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SensitiveFemaleHoleWalls>(this.toPart, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00007639 File Offset: 0x00005839
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Stretched Open " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x00007653 File Offset: 0x00005853
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000765E File Offset: 0x0000585E
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

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000767F File Offset: 0x0000587F
		public ValueTuple<SensitiveFemaleHoleWalls, SimpleModifier, AddOperation, int> valueId
		{
			get
			{
				return new ValueTuple<SensitiveFemaleHoleWalls, SimpleModifier, AddOperation, int>(this.toPart, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000769E File Offset: 0x0000589E
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002DB RID: 731 RVA: 0x000076AC File Offset: 0x000058AC
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002DC RID: 732 RVA: 0x000076CD File Offset: 0x000058CD
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x000076D8 File Offset: 0x000058D8
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnHoleWearingWalls))
			{
				return false;
			}
			BuffOnHoleWearingWalls buffOnHoleWearingWalls = (BuffOnHoleWearingWalls)Other;
			return this.IsStackableWith(ref buffOnHoleWearingWalls);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x000076FE File Offset: 0x000058FE
		public bool IsStackableWith(ref BuffOnHoleWearingWalls Other)
		{
			return Other.toPart == this.toPart && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000773C File Offset: 0x0000593C
		public void StackToSelf(ref BuffOnHoleWearingWalls Other)
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

		// Token: 0x060002E0 RID: 736 RVA: 0x00007798 File Offset: 0x00005998
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnHoleWearingWalls))
			{
				return;
			}
			BuffOnHoleWearingWalls buffOnHoleWearingWalls = (BuffOnHoleWearingWalls)Other;
			this.StackToSelf(ref buffOnHoleWearingWalls);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000077C0 File Offset: 0x000059C0
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

		// Token: 0x060002E2 RID: 738 RVA: 0x0000780E File Offset: 0x00005A0E
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnHoleWearingWalls)obj);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000781C File Offset: 0x00005A1C
		public bool Equals(BuffOnHoleWearingWalls p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00007828 File Offset: 0x00005A28
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000784C File Offset: 0x00005A4C
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

		// Token: 0x060002E6 RID: 742 RVA: 0x00007894 File Offset: 0x00005A94
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

		// Token: 0x060002E7 RID: 743 RVA: 0x000078E8 File Offset: 0x00005AE8
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

		// Token: 0x060002E8 RID: 744 RVA: 0x00007942 File Offset: 0x00005B42
		public static bool operator ==(BuffOnHoleWearingWalls lhs, BuffOnHoleWearingWalls rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000794C File Offset: 0x00005B4C
		public static bool operator !=(BuffOnHoleWearingWalls lhs, BuffOnHoleWearingWalls rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400012D RID: 301
		public SensitiveFemaleHoleWalls toPart;

		// Token: 0x0400012E RID: 302
		public SimpleModifier modifier;

		// Token: 0x0400012F RID: 303
		public AddOperation operation;

		// Token: 0x04000130 RID: 304
		public int endHour;

		// Token: 0x04000131 RID: 305
		public float value;
	}
}
