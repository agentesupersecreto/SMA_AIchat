using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000034 RID: 52
	public interface IPenetrableProp : IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000112 RID: 274
		TipoDeProp tipoDeProp { get; }
	}
}
