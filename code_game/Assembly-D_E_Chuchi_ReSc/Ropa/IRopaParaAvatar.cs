using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000F7 RID: 247
	public interface IRopaParaAvatar
	{
		// Token: 0x06000617 RID: 1559
		MapaDeRopa.RopaData ObtenerData(string ropaId);

		// Token: 0x06000618 RID: 1560
		MapaDeRopa.RopaData SeleccionarFirstSubPrenda(string ropaId, Predicate<MapaDeRopa.RopaData> selector);

		// Token: 0x06000619 RID: 1561
		MapaDeRopa.RopaData SeleccionarBestSubPrenda(string ropaId, Predicate<MapaDeRopa.RopaData> selector);

		// Token: 0x0600061A RID: 1562
		void SeleccionarJerarquiaPadres(string padreRopaId, string hijoRopaId, IList<MapaDeRopa.RopaData> padres);
	}
}
