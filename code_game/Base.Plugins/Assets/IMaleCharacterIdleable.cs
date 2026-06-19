using System;

namespace Assets
{
	// Token: 0x020000B3 RID: 179
	public interface IMaleCharacterIdleable : ICharacterIdleable
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000528 RID: 1320
		bool handEsIdle { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000529 RID: 1321
		bool pelvisEsIdle { get; }
	}
}
