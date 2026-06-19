using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000063 RID: 99
	[Serializable]
	public struct BuffOnDesires : IIdentifiableBuff<ValueTuple<Desires, EmotionModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnDesires>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000487F File Offset: 0x00002A7F
		public bool isValid
		{
			get
			{
				return this.desires != Desires.None && this.modifier != EmotionModifier.None && this.operation != Operation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x000048AE File Offset: 0x00002AAE
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000048B4 File Offset: 0x00002AB4
		public string DebugPrint()
		{
			string[] array = new string[9];
			array[0] = this.desires.ToString();
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

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x0000496C File Offset: 0x00002B6C
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.desires;
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00004970 File Offset: 0x00002B70
		public string RichPrint(Func<string, string> characterNameGetter, float UIValue, Language language)
		{
			return string.Concat(new string[]
			{
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<Desires>(this.desires, language),
				" ",
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<EmotionModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000049C5 File Offset: 0x00002BC5
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Desires " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000049DF File Offset: 0x00002BDF
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x000049EA File Offset: 0x00002BEA
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

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00004A0B File Offset: 0x00002C0B
		public ValueTuple<Desires, EmotionModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<Desires, EmotionModifier, Operation, int>(this.desires, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00004A2A File Offset: 0x00002C2A
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00004A38 File Offset: 0x00002C38
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00004A59 File Offset: 0x00002C59
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00004A64 File Offset: 0x00002C64
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnDesires))
			{
				return false;
			}
			BuffOnDesires buffOnDesires = (BuffOnDesires)Other;
			return this.IsStackableWith(ref buffOnDesires);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00004A8A File Offset: 0x00002C8A
		public bool IsStackableWith(ref BuffOnDesires Other)
		{
			return Other.desires == this.desires && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public void StackToSelf(ref BuffOnDesires Other)
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

		// Token: 0x060001FF RID: 511 RVA: 0x00004B44 File Offset: 0x00002D44
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnDesires))
			{
				return;
			}
			BuffOnDesires buffOnDesires = (BuffOnDesires)Other;
			this.StackToSelf(ref buffOnDesires);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00004B6C File Offset: 0x00002D6C
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

		// Token: 0x06000201 RID: 513 RVA: 0x00004BDA File Offset: 0x00002DDA
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnDesires)obj);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00004BE8 File Offset: 0x00002DE8
		public bool Equals(BuffOnDesires p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00004C18 File Offset: 0x00002E18
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

		// Token: 0x06000205 RID: 517 RVA: 0x00004C7C File Offset: 0x00002E7C
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

		// Token: 0x06000206 RID: 518 RVA: 0x00004CF4 File Offset: 0x00002EF4
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
				return this.CalcAddingValuePriority(-5f, 5f);
			case Operation.mult:
				return this.CalcMultiplyValuePriority(-50f, 50f);
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00004D74 File Offset: 0x00002F74
		public static bool operator ==(BuffOnDesires lhs, BuffOnDesires rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00004D7E File Offset: 0x00002F7E
		public static bool operator !=(BuffOnDesires lhs, BuffOnDesires rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x040000FF RID: 255
		public Desires desires;

		// Token: 0x04000100 RID: 256
		public EmotionModifier modifier;

		// Token: 0x04000101 RID: 257
		public Operation operation;

		// Token: 0x04000102 RID: 258
		public int endHour;

		// Token: 0x04000103 RID: 259
		public float value;
	}
}
