using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores
{
	// Token: 0x0200023C RID: 572
	public enum HandTipoDePose
	{
		// Token: 0x04000A52 RID: 2642
		None,
		// Token: 0x04000A53 RID: 2643
		massage,
		// Token: 0x04000A54 RID: 2644
		finger,
		// Token: 0x04000A55 RID: 2645
		phoneCam,
		// Token: 0x04000A56 RID: 2646
		camera,
		// Token: 0x04000A57 RID: 2647
		[Obsolete("ahora la mano pasa a mono pick desde massage", true)]
		pick,
		// Token: 0x04000A58 RID: 2648
		grab
	}
}
