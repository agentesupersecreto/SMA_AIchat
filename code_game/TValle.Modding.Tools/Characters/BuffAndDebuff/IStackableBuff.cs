using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200005E RID: 94
	public interface IStackableBuff<T> : IStackableBuff
	{
		// Token: 0x060001E9 RID: 489
		bool IsStackableWith(ref T Other);

		// Token: 0x060001EA RID: 490
		void StackToSelf(ref T Other);
	}
}
