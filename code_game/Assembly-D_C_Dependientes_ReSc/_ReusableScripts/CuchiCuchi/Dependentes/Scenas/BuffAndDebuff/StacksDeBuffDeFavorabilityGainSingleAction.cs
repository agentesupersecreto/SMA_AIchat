using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x02000090 RID: 144
	[ProveedorDeStacksTipoIds("ids")]
	public class StacksDeBuffDeFavorabilityGainSingleAction
	{
		// Token: 0x0400030B RID: 779
		public static readonly string nonStackableBuff = "nonStackableBuff";

		// Token: 0x0400030C RID: 780
		public static readonly string unlimitStacksBuff = "unlimitStacksBuff";

		// Token: 0x0400030D RID: 781
		public static readonly string[] ids = new string[]
		{
			StacksDeBuffDeFavorabilityGainSingleAction.nonStackableBuff,
			StacksDeBuffDeFavorabilityGainSingleAction.unlimitStacksBuff
		};
	}
}
