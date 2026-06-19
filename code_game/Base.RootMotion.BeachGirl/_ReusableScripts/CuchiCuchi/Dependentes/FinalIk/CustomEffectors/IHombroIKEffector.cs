using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C1 RID: 193
	public interface IHombroIKEffector
	{
		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600071A RID: 1818
		FullBodyBipedChain chain { get; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600071B RID: 1819
		FullBodyBipedEffector effector { get; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600071C RID: 1820
		// (set) Token: 0x0600071D RID: 1821
		float rotationWeight { get; set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600071E RID: 1822
		// (set) Token: 0x0600071F RID: 1823
		Quaternion rotation { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000720 RID: 1824
		// (set) Token: 0x06000721 RID: 1825
		[Obsolete]
		Quaternion rotationOffset { get; set; }

		// Token: 0x06000722 RID: 1826
		void Solve();
	}
}
