using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000039 RID: 57
	public interface IPeneIntentadorDePenetracion : IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x06000123 RID: 291
		void DeclararIntentando(IHole to, int frameID);

		// Token: 0x06000124 RID: 292
		bool Closest(IHole to);
	}
}
