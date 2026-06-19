using System;

namespace Assets
{
	// Token: 0x020000A8 RID: 168
	public interface ICharacterPuedeHablar
	{
		// Token: 0x060004FF RID: 1279
		bool PuedeIntentarHablar(out bool duracionEsIndefinida);

		// Token: 0x06000500 RID: 1280
		bool PuedeHablarConClaridad(out bool duracionEsIndefinida);
	}
}
