using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000315 RID: 789
	[Obsolete]
	public interface ITouchInformer
	{
		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06001112 RID: 4370
		CharTouchEnum @enum { get; }

		// Token: 0x06001113 RID: 4371
		bool IsTouchedByAnyChar(bool includePuppet = true);

		// Token: 0x06001114 RID: 4372
		bool IsTouchedByAnyChar(IList<EstimuloTactil> result, bool includePuppet = true);

		// Token: 0x06001115 RID: 4373
		bool IsTouchedBy(Character character, bool includePuppet = true);

		// Token: 0x06001116 RID: 4374
		EstimuloTactil Touched(Character character, bool includePuppet = true);

		// Token: 0x06001117 RID: 4375
		bool IsClutchByAnyChar(bool includePuppet = true);

		// Token: 0x06001118 RID: 4376
		bool IsClutchByAnyChar(IList<EstimuloTactil> result, bool includePuppet = true);

		// Token: 0x06001119 RID: 4377
		bool IsClutchBy(Character character, bool includePuppet = true);

		// Token: 0x0600111A RID: 4378
		EstimuloTactil Clutched(Character character, bool includePuppet = true);
	}
}
