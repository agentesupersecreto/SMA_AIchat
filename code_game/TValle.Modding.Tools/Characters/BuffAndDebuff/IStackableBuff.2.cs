using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200005F RID: 95
	public interface IStackableBuff
	{
		// Token: 0x060001EB RID: 491
		bool IsStackableWith(object Other);

		// Token: 0x060001EC RID: 492
		void StackToSelf(object Other);
	}
}
