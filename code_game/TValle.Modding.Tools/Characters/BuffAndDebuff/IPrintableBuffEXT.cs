using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200005D RID: 93
	public static class IPrintableBuffEXT
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x00004654 File Offset: 0x00002854
		public static DisplayableBuffCategory ParseToCategory(this Emotion emo)
		{
			switch (emo)
			{
			case Emotion.enjoyment:
			case Emotion.relief:
			case Emotion.pleasure:
			case Emotion.arousal:
			case Emotion.disgust:
				return DisplayableBuffCategory.pleasure;
			case Emotion.favorability:
				return DisplayableBuffCategory.favorability;
			case Emotion.disappointment:
				return DisplayableBuffCategory.decep;
			case Emotion.rage:
				return DisplayableBuffCategory.rage;
			case Emotion.pain:
				return DisplayableBuffCategory.pain;
			case Emotion.fear:
				return DisplayableBuffCategory.fear;
			default:
				return DisplayableBuffCategory.None;
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x000046A0 File Offset: 0x000028A0
		public static string GetOperationSymbolAndValue(this Operation op, float value)
		{
			switch (op)
			{
			case Operation.None:
				return "error";
			case Operation.add:
				return ((value < 0f) ? string.Empty : "+") + value.ToString("0.00");
			case Operation.mult:
				return (value * 100f - 100f).ToString("0.00") + "%";
			default:
				throw new ArgumentOutOfRangeException(op.ToString());
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00004724 File Offset: 0x00002924
		public static string GetOperationSymbolAndValue(this AddOperation op, float value)
		{
			if (op == AddOperation.None)
			{
				return "error";
			}
			if (op != AddOperation.add)
			{
				throw new ArgumentOutOfRangeException(op.ToString());
			}
			return ((value < 0f) ? string.Empty : "+") + value.ToString("0.00");
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00004778 File Offset: 0x00002978
		public static string GetOperationSymbolAndValue(this ProductOperation op, float value)
		{
			if (op == ProductOperation.None)
			{
				return "error";
			}
			if (op != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(op.ToString());
			}
			return (value * 100f - 100f).ToString("0.00") + "%";
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000047CC File Offset: 0x000029CC
		public static string GetOperationSymbol(this Operation op, float value)
		{
			switch (op)
			{
			case Operation.None:
				return "error";
			case Operation.add:
				if (value >= 0f)
				{
					return "+";
				}
				return string.Empty;
			case Operation.mult:
				return "×";
			default:
				throw new ArgumentOutOfRangeException(op.ToString());
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000481F File Offset: 0x00002A1F
		public static string GetOperationSymbol(this AddOperation op, float value)
		{
			if (op == AddOperation.None)
			{
				return "error";
			}
			if (op != AddOperation.add)
			{
				throw new ArgumentOutOfRangeException(op.ToString());
			}
			if (value >= 0f)
			{
				return "+";
			}
			return string.Empty;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00004856 File Offset: 0x00002A56
		public static string GetOperationSymbol(this ProductOperation op, float value)
		{
			if (op == ProductOperation.None)
			{
				return "error";
			}
			if (op != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(op.ToString());
			}
			return "×";
		}
	}
}
