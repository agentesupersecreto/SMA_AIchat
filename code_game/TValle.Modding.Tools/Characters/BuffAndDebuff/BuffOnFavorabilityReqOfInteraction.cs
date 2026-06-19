using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000069 RID: 105
	[Serializable]
	public struct BuffOnFavorabilityReqOfInteraction : IIdentifiableBuff<ValueTuple<InterationReceivedType, TriggeringBodyPart, SensitiveBodyPart, SimpleModifier, Operation, int>>, IIdentifiableBuff, IStackableBuff<BuffOnFavorabilityReqOfInteraction>, IStackableBuff, IFloatValuableBuff, IValuableBuff<float>, IEndableOnDateBuff, IPrintableBuff, IValidableBuff, IContextValidableBuff
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000286 RID: 646 RVA: 0x00006674 File Offset: 0x00004874
		public bool isValid
		{
			get
			{
				return this.interationReceivedType != InterationReceivedType.None && this.fromPart != TriggeringBodyPart.None && this.toPart != SensitiveBodyPart.None && this.modifier != SimpleModifier.None && this.operation != Operation.None && this.endHour != 0 && float.IsFinite(this.value);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000287 RID: 647 RVA: 0x000066B3 File Offset: 0x000048B3
		public bool isContextValid
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000066B8 File Offset: 0x000048B8
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000289 RID: 649 RVA: 0x000067AC File Offset: 0x000049AC
		public DisplayableBuffCategory category
		{
			get
			{
				return DisplayableBuffCategory.favorability;
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000067B0 File Offset: 0x000049B0
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
				TValleUILocalTextAttribute.LocalizadoFirstCharToUpper<SimpleModifier>(this.modifier, language),
				" ",
				this.operation.GetOperationSymbolAndValue(UIValue)
			});
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00006834 File Offset: 0x00004A34
		public string RichPrintStandAlone(Func<string, string> characterNameGetter, Language language)
		{
			return "Favorability Req. " + this.RichPrint(characterNameGetter, this.value, language);
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600028C RID: 652 RVA: 0x0000684E File Offset: 0x00004A4E
		public bool infinite
		{
			get
			{
				return this.endHour < 0;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00006859 File Offset: 0x00004A59
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

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000687A File Offset: 0x00004A7A
		public ValueTuple<InterationReceivedType, TriggeringBodyPart, SensitiveBodyPart, SimpleModifier, Operation, int> valueId
		{
			get
			{
				return new ValueTuple<InterationReceivedType, TriggeringBodyPart, SensitiveBodyPart, SimpleModifier, Operation, int>(this.interationReceivedType, this.fromPart, this.toPart, this.modifier, this.operation, this.endHour);
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600028F RID: 655 RVA: 0x000068A5 File Offset: 0x00004AA5
		public ITuple id
		{
			get
			{
				return this.valueId;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000290 RID: 656 RVA: 0x000068B4 File Offset: 0x00004AB4
		public string stringId
		{
			get
			{
				return this.valueId.ToString();
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000291 RID: 657 RVA: 0x000068D5 File Offset: 0x00004AD5
		public float buffValue
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000068E0 File Offset: 0x00004AE0
		public bool IsStackableWith(object Other)
		{
			if (!(Other is BuffOnFavorabilityReqOfInteraction))
			{
				return false;
			}
			BuffOnFavorabilityReqOfInteraction buffOnFavorabilityReqOfInteraction = (BuffOnFavorabilityReqOfInteraction)Other;
			return this.IsStackableWith(ref buffOnFavorabilityReqOfInteraction);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00006908 File Offset: 0x00004B08
		public bool IsStackableWith(ref BuffOnFavorabilityReqOfInteraction Other)
		{
			return Other.interationReceivedType == this.interationReceivedType && Other.fromPart == this.fromPart && Other.toPart == this.toPart && Other.modifier == this.modifier && Other.operation == this.operation && Other.endHour == this.endHour;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000696C File Offset: 0x00004B6C
		public void StackToSelf(ref BuffOnFavorabilityReqOfInteraction Other)
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

		// Token: 0x06000295 RID: 661 RVA: 0x000069E8 File Offset: 0x00004BE8
		public void StackToSelf(object Other)
		{
			if (!(Other is BuffOnFavorabilityReqOfInteraction))
			{
				return;
			}
			BuffOnFavorabilityReqOfInteraction buffOnFavorabilityReqOfInteraction = (BuffOnFavorabilityReqOfInteraction)Other;
			this.StackToSelf(ref buffOnFavorabilityReqOfInteraction);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00006A10 File Offset: 0x00004C10
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

		// Token: 0x06000297 RID: 663 RVA: 0x00006A7E File Offset: 0x00004C7E
		public override bool Equals(object obj)
		{
			return this.Equals((BuffOnFavorabilityReqOfInteraction)obj);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00006A8C File Offset: 0x00004C8C
		public bool Equals(BuffOnFavorabilityReqOfInteraction p)
		{
			return this.IsStackableWith(ref p);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00006A98 File Offset: 0x00004C98
		public override int GetHashCode()
		{
			return this.valueId.GetHashCode();
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00006ABC File Offset: 0x00004CBC
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

		// Token: 0x0600029B RID: 667 RVA: 0x00006B20 File Offset: 0x00004D20
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

		// Token: 0x0600029C RID: 668 RVA: 0x00006B98 File Offset: 0x00004D98
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
				return this.CalcAddingValuePriority(2f, -2f);
			case Operation.mult:
				return this.CalcMultiplyValuePriority(5f, -5f);
			default:
				throw new ArgumentOutOfRangeException(this.operation.ToString());
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00006C18 File Offset: 0x00004E18
		public static bool operator ==(BuffOnFavorabilityReqOfInteraction lhs, BuffOnFavorabilityReqOfInteraction rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00006C22 File Offset: 0x00004E22
		public static bool operator !=(BuffOnFavorabilityReqOfInteraction lhs, BuffOnFavorabilityReqOfInteraction rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400011C RID: 284
		public InterationReceivedType interationReceivedType;

		// Token: 0x0400011D RID: 285
		public TriggeringBodyPart fromPart;

		// Token: 0x0400011E RID: 286
		public SensitiveBodyPart toPart;

		// Token: 0x0400011F RID: 287
		public SimpleModifier modifier;

		// Token: 0x04000120 RID: 288
		public Operation operation;

		// Token: 0x04000121 RID: 289
		public int endHour;

		// Token: 0x04000122 RID: 290
		public float value;
	}
}
