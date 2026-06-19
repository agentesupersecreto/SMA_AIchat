using System;
using System.Collections.Generic;

namespace Assets.TValle.Tools.Runtime.Clothing
{
	// Token: 0x0200003C RID: 60
	public interface ITVallePiecesOfClothing
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000151 RID: 337
		string ID { get; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000152 RID: 338
		IReadOnlyList<ITValleClothingMaterial> slotMaterial { get; }
	}
}
