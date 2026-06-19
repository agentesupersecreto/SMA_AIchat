using System;
using System.Runtime.CompilerServices;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x0200005A RID: 90
	public interface IIdentifiableBuff<T_ID> : IIdentifiableBuff where T_ID : struct, ITuple
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001DD RID: 477
		T_ID valueId { get; }
	}
}
