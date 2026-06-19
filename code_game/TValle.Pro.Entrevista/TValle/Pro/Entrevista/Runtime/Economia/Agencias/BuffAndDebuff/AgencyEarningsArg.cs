using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff
{
	// Token: 0x020000DB RID: 219
	[Serializable]
	public sealed class AgencyEarningsArg : ArgumentoDeEfecto<AgencyEarningsArg>
	{
		// Token: 0x04000497 RID: 1175
		public float income;

		// Token: 0x04000498 RID: 1176
		[Range(1f, 10f)]
		public float bonusMod;

		// Token: 0x04000499 RID: 1177
		[Range(0.01f, 1f)]
		public float antiBonusMod;

		// Token: 0x0400049A RID: 1178
		public int bonuses;

		// Token: 0x0400049B RID: 1179
		public int antiBonuses;
	}
}
