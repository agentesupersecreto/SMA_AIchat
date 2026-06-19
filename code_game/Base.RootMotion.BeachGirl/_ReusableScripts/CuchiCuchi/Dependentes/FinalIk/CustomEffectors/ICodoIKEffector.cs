using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000BF RID: 191
	[Obsolete("", true)]
	public interface ICodoIKEffector
	{
		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000712 RID: 1810
		// (set) Token: 0x06000713 RID: 1811
		float weight { get; set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000714 RID: 1812
		// (set) Token: 0x06000715 RID: 1813
		Vector3 nodeDirection { get; set; }
	}
}
