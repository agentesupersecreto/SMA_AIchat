using System;
using System.Collections.Generic;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000CE RID: 206
	public interface ICustomDePortraitsDisponibles<T>
	{
		// Token: 0x060005C7 RID: 1479
		List<T> ObtenerDisponibles();

		// Token: 0x060005C8 RID: 1480
		string GetToolTipOf(int index);
	}
}
