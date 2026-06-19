using System;
using RootMotion.FinalIK;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C0 RID: 192
	public interface IHombrosIKEffector : IIKCustomEffector
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000716 RID: 1814
		IHombroIKEffector derecho { get; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000717 RID: 1815
		IHombroIKEffector izquierdo { get; }

		// Token: 0x06000718 RID: 1816
		IHombroIKEffector Obtener(Side side);

		// Token: 0x06000719 RID: 1817
		IHombroIKEffector Obtener(FullBodyBipedEffector effector);
	}
}
