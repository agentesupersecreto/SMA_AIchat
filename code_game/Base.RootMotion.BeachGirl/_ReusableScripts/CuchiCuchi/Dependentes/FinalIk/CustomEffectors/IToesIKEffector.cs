using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C2 RID: 194
	public interface IToesIKEffector : IIKCustomEffector
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000723 RID: 1827
		IToeIKEffector derecho { get; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000724 RID: 1828
		IToeIKEffector izquierdo { get; }
	}
}
