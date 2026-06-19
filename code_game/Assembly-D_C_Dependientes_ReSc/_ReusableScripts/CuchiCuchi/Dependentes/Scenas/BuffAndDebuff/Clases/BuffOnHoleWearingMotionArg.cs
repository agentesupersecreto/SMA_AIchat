using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000E0 RID: 224
	[Serializable]
	public class BuffOnHoleWearingMotionArg : ByInteraccionEnScenaArg<BuffOnHoleWearingMotionArg, BuffOnHoleWearingMotion>
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x0001A956 File Offset: 0x00018B56
		public bool permanent
		{
			get
			{
				return this.buffOn.infinite;
			}
		}
	}
}
