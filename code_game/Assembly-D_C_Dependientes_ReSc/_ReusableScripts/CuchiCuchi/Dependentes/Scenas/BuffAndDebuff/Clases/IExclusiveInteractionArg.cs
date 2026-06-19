using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x0200009F RID: 159
	public interface IExclusiveInteractionArg : IInteractionArg
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000355 RID: 853
		IReadOnlyList<IDataExlusiveOfInteractionArg> dataExcluir { get; }

		// Token: 0x06000356 RID: 854
		void InyectExclusiveData(IReadOnlyList<IDataExlusiveOfInteractionArg> inyected);

		// Token: 0x06000357 RID: 855
		IDataExlusiveOfInteractionArg GetNewInteractionDataExclusiveInstance();
	}
}
