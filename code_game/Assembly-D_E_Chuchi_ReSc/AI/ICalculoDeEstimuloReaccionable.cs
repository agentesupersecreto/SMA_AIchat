using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E6 RID: 742
	public interface ICalculoDeEstimuloReaccionable : ICalculoDeEstimulo
	{
		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06001083 RID: 4227
		// (set) Token: 0x06001084 RID: 4228
		bool reaccionable { get; set; }

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06001085 RID: 4229
		// (set) Token: 0x06001086 RID: 4230
		bool ignorarCoolDown { get; set; }

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06001087 RID: 4231
		// (set) Token: 0x06001088 RID: 4232
		bool ignorarProbabilidad { get; set; }
	}
}
