using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C7 RID: 199
	public class BuffOnOxygenGainArg : DisplayableArgumentoDeEfecto<BuffOnOxygenGainArg>
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00014284 File Offset: 0x00012484
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00016EA0 File Offset: 0x000150A0
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return "Decreased Endurance " + (this.gainMod * 100f - 100f).ToString("0.0") + "%";
		}

		// Token: 0x04000387 RID: 903
		public float gainMod;

		// Token: 0x04000388 RID: 904
		public bool justForCansamiento;
	}
}
