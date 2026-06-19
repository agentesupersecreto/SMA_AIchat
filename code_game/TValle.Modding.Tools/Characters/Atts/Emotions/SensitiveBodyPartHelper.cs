using System;
using System.Collections.Generic;

namespace Assets.TValle.Tools.Runtime.Characters.Atts.Emotions
{
	// Token: 0x02000089 RID: 137
	public static class SensitiveBodyPartHelper
	{
		// Token: 0x06000358 RID: 856 RVA: 0x00008FE1 File Offset: 0x000071E1
		public static bool CanBePenetrated(this SensitiveBodyPart parte)
		{
			return parte - SensitiveBodyPart.throat <= 8;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00008FF0 File Offset: 0x000071F0
		public static bool TryInverse(this SensitiveBodyPart parte, out TriggeringBodyPart triggeringBodyPart)
		{
			triggeringBodyPart = TriggeringBodyPart.None;
			switch (parte)
			{
			case SensitiveBodyPart.All:
			case SensitiveBodyPart.None:
				return false;
			case SensitiveBodyPart.head:
			case SensitiveBodyPart.temples:
			case SensitiveBodyPart.forehead:
			case SensitiveBodyPart.nose:
			case SensitiveBodyPart.cheeks:
			case SensitiveBodyPart.eyebrows:
			case SensitiveBodyPart.ears:
			case SensitiveBodyPart.neck:
			case SensitiveBodyPart.shoulders:
			case SensitiveBodyPart.armpits:
			case SensitiveBodyPart.arms:
			case SensitiveBodyPart.chest:
			case SensitiveBodyPart.breasts:
			case SensitiveBodyPart.nipples:
			case SensitiveBodyPart.back:
			case SensitiveBodyPart.abdomen:
			case SensitiveBodyPart.waist:
			case SensitiveBodyPart.hips:
			case SensitiveBodyPart.belly:
			case SensitiveBodyPart.navel:
			case SensitiveBodyPart.coccyx:
			case SensitiveBodyPart.buttocks:
			case SensitiveBodyPart.crotch:
			case SensitiveBodyPart.perineum:
				triggeringBodyPart = TriggeringBodyPart.torso;
				break;
			case SensitiveBodyPart.eyes:
			case SensitiveBodyPart.eyeballs:
				triggeringBodyPart = TriggeringBodyPart.eyes;
				break;
			case SensitiveBodyPart.jaw:
			case SensitiveBodyPart.lips:
			case SensitiveBodyPart.throat:
			case SensitiveBodyPart.throatBottom:
			case SensitiveBodyPart.throatWalls:
				triggeringBodyPart = TriggeringBodyPart.mouth;
				break;
			case SensitiveBodyPart.tongue:
				triggeringBodyPart = TriggeringBodyPart.tongue;
				break;
			case SensitiveBodyPart.forearms:
			case SensitiveBodyPart.hands:
				triggeringBodyPart = TriggeringBodyPart.hand;
				break;
			case SensitiveBodyPart.vaginalLipsOrBalls:
			case SensitiveBodyPart.clitorisOrPenis:
				triggeringBodyPart = TriggeringBodyPart.penis;
				break;
			case SensitiveBodyPart.legs:
			case SensitiveBodyPart.knees:
			case SensitiveBodyPart.calf:
			case SensitiveBodyPart.feet:
				triggeringBodyPart = TriggeringBodyPart.leg;
				break;
			case SensitiveBodyPart.vag:
			case SensitiveBodyPart.vagBottom:
			case SensitiveBodyPart.vagWalls:
				triggeringBodyPart = TriggeringBodyPart.vagina;
				break;
			case SensitiveBodyPart.anus:
			case SensitiveBodyPart.anusBottom:
			case SensitiveBodyPart.anusWalls:
				triggeringBodyPart = TriggeringBodyPart.anus;
				break;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
			return true;
		}

		// Token: 0x04000235 RID: 565
		public static readonly IReadOnlyList<SensitiveBodyPart> facialParts = new List<SensitiveBodyPart>
		{
			SensitiveBodyPart.jaw,
			SensitiveBodyPart.nose,
			SensitiveBodyPart.cheeks,
			SensitiveBodyPart.eyebrows,
			SensitiveBodyPart.temples,
			SensitiveBodyPart.forehead,
			SensitiveBodyPart.ears,
			SensitiveBodyPart.lips,
			SensitiveBodyPart.tongue,
			SensitiveBodyPart.eyeballs,
			SensitiveBodyPart.eyes,
			SensitiveBodyPart.head,
			SensitiveBodyPart.throat,
			SensitiveBodyPart.throatBottom,
			SensitiveBodyPart.throatWalls
		};

		// Token: 0x04000236 RID: 566
		public static readonly IReadOnlyList<SensitiveBodyPart> assParts = new List<SensitiveBodyPart>
		{
			SensitiveBodyPart.coccyx,
			SensitiveBodyPart.buttocks,
			SensitiveBodyPart.perineum,
			SensitiveBodyPart.anus,
			SensitiveBodyPart.anusBottom,
			SensitiveBodyPart.anusWalls
		};

		// Token: 0x04000237 RID: 567
		public static readonly IReadOnlyList<SensitiveBodyPart> crotchParts = new List<SensitiveBodyPart>
		{
			SensitiveBodyPart.legs,
			SensitiveBodyPart.crotch,
			SensitiveBodyPart.clitorisOrPenis,
			SensitiveBodyPart.vaginalLipsOrBalls,
			SensitiveBodyPart.vag,
			SensitiveBodyPart.vagBottom,
			SensitiveBodyPart.vagWalls
		};

		// Token: 0x04000238 RID: 568
		public static readonly IReadOnlyList<SensitiveBodyPart> breastParts = new List<SensitiveBodyPart>
		{
			SensitiveBodyPart.breasts,
			SensitiveBodyPart.nipples
		};
	}
}
