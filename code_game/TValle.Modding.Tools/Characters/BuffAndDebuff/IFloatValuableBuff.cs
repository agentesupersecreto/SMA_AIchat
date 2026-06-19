using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000057 RID: 87
	public interface IFloatValuableBuff : IValuableBuff<float>
	{
		// Token: 0x060001D2 RID: 466
		void InverseValue();

		// Token: 0x060001D3 RID: 467
		bool ValueIsEmpty();

		// Token: 0x060001D4 RID: 468
		bool ValueIsDisplayable();

		// Token: 0x060001D5 RID: 469
		int ValuePriorty();
	}
}
