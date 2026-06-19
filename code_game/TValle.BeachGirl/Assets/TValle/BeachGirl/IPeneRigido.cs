using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200002F RID: 47
	public interface IPeneRigido : IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060000E0 RID: 224
		// (set) Token: 0x060000E1 RID: 225
		float rigidez { get; set; }
	}
}
