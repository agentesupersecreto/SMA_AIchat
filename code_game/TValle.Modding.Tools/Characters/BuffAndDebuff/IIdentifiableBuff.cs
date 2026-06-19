using System;
using System.Runtime.CompilerServices;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000059 RID: 89
	public interface IIdentifiableBuff
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001DB RID: 475
		ITuple id { get; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001DC RID: 476
		string stringId { get; }
	}
}
