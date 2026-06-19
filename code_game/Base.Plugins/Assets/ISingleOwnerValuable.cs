using System;

namespace Assets
{
	// Token: 0x020000F6 RID: 246
	public interface ISingleOwnerValuable<T_Val> : IValuable<T_Val> where T_Val : struct
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060006E0 RID: 1760
		IModificable owner { get; }

		// Token: 0x060006E1 RID: 1761
		bool TryRemoverDeOwner(bool limpiarOwner);

		// Token: 0x060006E2 RID: 1762
		bool Removido();
	}
}
