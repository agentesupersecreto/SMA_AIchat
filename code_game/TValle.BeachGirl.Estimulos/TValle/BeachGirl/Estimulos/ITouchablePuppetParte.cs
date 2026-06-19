using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.TValle.BeachGirl.Estimulos
{
	// Token: 0x0200001A RID: 26
	public interface ITouchablePuppetParte : IPuppetParte, IComponentEnabable
	{
		// Token: 0x060000E5 RID: 229
		bool IsTouchedBy(ICharacter character, List<EstimuloTactil> toques);
	}
}
