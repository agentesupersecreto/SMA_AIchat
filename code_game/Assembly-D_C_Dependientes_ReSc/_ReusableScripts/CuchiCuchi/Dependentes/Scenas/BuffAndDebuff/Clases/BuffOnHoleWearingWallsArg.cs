using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000E2 RID: 226
	[Serializable]
	public class BuffOnHoleWearingWallsArg : ByInteraccionEnScenaArg<BuffOnHoleWearingWallsArg, BuffOnHoleWearingWalls>
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0001AC30 File Offset: 0x00018E30
		public bool permanent
		{
			get
			{
				return this.buffOn.infinite;
			}
		}
	}
}
