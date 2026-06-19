using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x020000A9 RID: 169
	public static class __ICharacterPuedeHablar_EXT
	{
		// Token: 0x06000501 RID: 1281 RVA: 0x000161D0 File Offset: 0x000143D0
		public static bool PuedeIntentarHablar(this IReadOnlyList<ICharacterPuedeHablar> puedeHablarDelegados, out bool duracionEsIndefinida)
		{
			bool flag = true;
			duracionEsIndefinida = false;
			for (int i = 0; i < puedeHablarDelegados.Count; i++)
			{
				bool flag2;
				if (!puedeHablarDelegados[i].PuedeIntentarHablar(out flag2))
				{
					flag = false;
					duracionEsIndefinida = duracionEsIndefinida || flag2;
				}
			}
			return flag;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0001620C File Offset: 0x0001440C
		public static bool PuedeHablarConClaridad(this IReadOnlyList<ICharacterPuedeHablar> puedeHablarDelegados, out bool duracionEsIndefinida)
		{
			bool flag = true;
			duracionEsIndefinida = false;
			for (int i = 0; i < puedeHablarDelegados.Count; i++)
			{
				bool flag2;
				if (!puedeHablarDelegados[i].PuedeHablarConClaridad(out flag2))
				{
					flag = false;
					duracionEsIndefinida = duracionEsIndefinida || flag2;
				}
			}
			return flag;
		}
	}
}
