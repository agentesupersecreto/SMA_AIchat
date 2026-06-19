using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000005 RID: 5
	public interface IContraccionesDeOrgasmo
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000018 RID: 24
		AnimationCurve contraccionCurva { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000019 RID: 25
		int currentContraccionesDeOrgasmo { get; }
	}
}
