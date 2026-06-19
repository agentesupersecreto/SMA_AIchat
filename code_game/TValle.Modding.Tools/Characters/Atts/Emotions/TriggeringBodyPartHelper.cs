using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.TValle.Tools.Runtime.Characters.Atts.Emotions
{
	// Token: 0x0200008C RID: 140
	public static class TriggeringBodyPartHelper
	{
		// Token: 0x0600035B RID: 859 RVA: 0x000091E8 File Offset: 0x000073E8
		public static bool TryInverse(this TriggeringBodyPart parte, out SensitiveBodyPart sensitiveBodyPart)
		{
			sensitiveBodyPart = SensitiveBodyPart.None;
			switch (parte)
			{
			case TriggeringBodyPart.All:
			case TriggeringBodyPart.None:
			case TriggeringBodyPart.notSpecified:
			case TriggeringBodyPart.toy:
			case TriggeringBodyPart.semen:
			case TriggeringBodyPart.water:
			case TriggeringBodyPart.lubricant:
			case TriggeringBodyPart.orine:
			case TriggeringBodyPart.toyApplicator:
			case TriggeringBodyPart.tool:
				return false;
			case TriggeringBodyPart.eyes:
				sensitiveBodyPart = SensitiveBodyPart.eyes;
				break;
			case TriggeringBodyPart.mouth:
				sensitiveBodyPart = SensitiveBodyPart.throat;
				break;
			case TriggeringBodyPart.torso:
				sensitiveBodyPart = SensitiveBodyPart.chest;
				break;
			case TriggeringBodyPart.hand:
				sensitiveBodyPart = SensitiveBodyPart.hands;
				break;
			case TriggeringBodyPart.finger:
				sensitiveBodyPart = SensitiveBodyPart.hands;
				break;
			case TriggeringBodyPart.leg:
				sensitiveBodyPart = SensitiveBodyPart.legs;
				break;
			case TriggeringBodyPart.tongue:
				sensitiveBodyPart = SensitiveBodyPart.tongue;
				break;
			case TriggeringBodyPart.penis:
				sensitiveBodyPart = SensitiveBodyPart.clitorisOrPenis;
				break;
			case TriggeringBodyPart.vagina:
				sensitiveBodyPart = SensitiveBodyPart.vag;
				break;
			case TriggeringBodyPart.anus:
				sensitiveBodyPart = SensitiveBodyPart.anus;
				break;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
			return true;
		}

		// Token: 0x04000256 RID: 598
		public static readonly IReadOnlyList<TriggeringBodyPart> canPenetrateParts = new List<TriggeringBodyPart>
		{
			TriggeringBodyPart.penis,
			TriggeringBodyPart.finger,
			TriggeringBodyPart.toy,
			TriggeringBodyPart.toyApplicator,
			TriggeringBodyPart.tongue,
			TriggeringBodyPart.tool
		}.ToHashSet<TriggeringBodyPart>().ToArray<TriggeringBodyPart>();

		// Token: 0x04000257 RID: 599
		public static readonly IReadOnlyList<TriggeringBodyPart> canTouchParts = new List<TriggeringBodyPart>
		{
			TriggeringBodyPart.penis,
			TriggeringBodyPart.finger,
			TriggeringBodyPart.toy,
			TriggeringBodyPart.toyApplicator,
			TriggeringBodyPart.tongue,
			TriggeringBodyPart.tool,
			TriggeringBodyPart.torso,
			TriggeringBodyPart.hand,
			TriggeringBodyPart.leg,
			TriggeringBodyPart.semen,
			TriggeringBodyPart.vagina,
			TriggeringBodyPart.anus,
			TriggeringBodyPart.water,
			TriggeringBodyPart.lubricant,
			TriggeringBodyPart.orine
		}.ToHashSet<TriggeringBodyPart>().ToArray<TriggeringBodyPart>();
	}
}
