using System;
using System.Collections.Generic;

namespace Assets.TValle.Tools.Runtime.Clothing
{
	// Token: 0x0200003B RID: 59
	public interface ITValleOutfit
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014F RID: 335
		string name { get; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000150 RID: 336
		IReadOnlyList<ITVallePiecesOfClothing> pieces { get; }
	}
}
