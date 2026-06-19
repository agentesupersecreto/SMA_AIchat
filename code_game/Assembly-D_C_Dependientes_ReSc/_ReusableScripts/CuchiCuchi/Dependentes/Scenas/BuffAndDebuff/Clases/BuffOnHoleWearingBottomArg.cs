using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000DE RID: 222
	[Serializable]
	public class BuffOnHoleWearingBottomArg : ByInteraccionEnScenaArg<BuffOnHoleWearingBottomArg, BuffOnHoleWearingBottom>
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0001A675 File Offset: 0x00018875
		public bool permanent
		{
			get
			{
				return this.buffOn.infinite;
			}
		}
	}
}
