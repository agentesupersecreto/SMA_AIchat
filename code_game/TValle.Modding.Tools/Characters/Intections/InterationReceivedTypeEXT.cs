using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;

namespace Assets.TValle.Tools.Runtime.Characters.Intections
{
	// Token: 0x02000054 RID: 84
	public static class InterationReceivedTypeEXT
	{
		// Token: 0x060001CD RID: 461 RVA: 0x00004515 File Offset: 0x00002715
		public static bool IsContextValid(this InterationReceivedType inter, Emotion emo)
		{
			if (emo == Emotion.pain)
			{
				if (inter - InterationReceivedType.lookAt > 2 && inter - InterationReceivedType.pouringOn > 1)
				{
					switch (inter)
					{
					case InterationReceivedType.askToExpose:
					case InterationReceivedType.askToPose:
					case InterationReceivedType.guideBody:
						return false;
					}
					return true;
				}
				return false;
			}
			return true;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000454C File Offset: 0x0000274C
		public static bool TryInverse(this InterationReceivedType inter, out InterationReceivedType interInversed)
		{
			interInversed = inter;
			if (inter - InterationReceivedType.All > 1)
			{
				if (inter == InterationReceivedType.handJob)
				{
					interInversed = InterationReceivedType.dryhump;
				}
				return true;
			}
			return false;
		}
	}
}
