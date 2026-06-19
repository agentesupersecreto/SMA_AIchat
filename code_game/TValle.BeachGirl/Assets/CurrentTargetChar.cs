using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi;

namespace Assets
{
	// Token: 0x02000013 RID: 19
	public sealed class CurrentTargetChar : CurrentMainCharacter<CurrentTargetChar, TargetChar>
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00002578 File Offset: 0x00000778
		protected override void OnChanged(TargetChar nuevo, TargetChar viejo)
		{
			base.OnChanged(nuevo, viejo);
			if (viejo != null && viejo.character is IFemaleChar)
			{
				viejo.gameObject.tag = "FemaleCharacter";
			}
			if (nuevo != null && nuevo.character is IFemaleChar)
			{
				nuevo.gameObject.tag = "MainFemaleCharacter";
			}
		}
	}
}
