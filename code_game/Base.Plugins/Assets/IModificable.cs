using System;

namespace Assets
{
	// Token: 0x020000F4 RID: 244
	public interface IModificable
	{
		// Token: 0x060006C8 RID: 1736
		bool TryLoadModificador(object mod);

		// Token: 0x060006C9 RID: 1737
		bool TryRemoverModificador(object mod);

		// Token: 0x060006CA RID: 1738
		bool Contiene(object mod);
	}
}
