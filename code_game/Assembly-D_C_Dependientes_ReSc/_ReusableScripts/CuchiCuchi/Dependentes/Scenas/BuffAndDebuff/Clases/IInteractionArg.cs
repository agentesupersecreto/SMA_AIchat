using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x0200009E RID: 158
	public interface IInteractionArg
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000352 RID: 850
		IReadOnlyList<IDataOfInteractionArg> data { get; }

		// Token: 0x06000353 RID: 851
		void InyectData(IReadOnlyList<IDataOfInteractionArg> inyected);

		// Token: 0x06000354 RID: 852
		IDataOfInteractionArg GetNewInteractionDataInstance();
	}
}
