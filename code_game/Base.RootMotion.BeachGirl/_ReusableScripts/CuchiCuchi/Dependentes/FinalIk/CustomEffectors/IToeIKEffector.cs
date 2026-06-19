using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C3 RID: 195
	public interface IToeIKEffector
	{
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000725 RID: 1829
		// (set) Token: 0x06000726 RID: 1830
		float rotationWeight { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000727 RID: 1831
		// (set) Token: 0x06000728 RID: 1832
		Quaternion rotation { get; set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000729 RID: 1833
		// (set) Token: 0x0600072A RID: 1834
		Vector3 offsetRotation { get; set; }

		// Token: 0x0600072B RID: 1835
		void Solve();
	}
}
