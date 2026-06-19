using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000BE RID: 190
	[Obsolete("", true)]
	public interface ICodosIKEffector : IIKCustomEffector
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000710 RID: 1808
		ICodoIKEffector derecho { get; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000711 RID: 1809
		ICodoIKEffector izquierdo { get; }
	}
}
