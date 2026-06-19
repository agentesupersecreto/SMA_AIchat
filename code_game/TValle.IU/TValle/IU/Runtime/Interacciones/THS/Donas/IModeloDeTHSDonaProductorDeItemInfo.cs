using System;
using System.Collections.Generic;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000E2 RID: 226
	public interface IModeloDeTHSDonaProductorDeItemInfo
	{
		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060006B7 RID: 1719
		int count { get; }

		// Token: 0x060006B8 RID: 1720
		List<THSDonaController.RadialItemData> ObtenerModelos(out THSDonaController.OnEventoSimpleHandler onShowed, out THSDonaController.OnEventoSimpleHandler onClosed, out THSDonaController.OnEventoSimpleHandler onAceptar, out THSDonaController.OnEventoSimpleHandler onGoBack, LoaderDeTHSDona caller);
	}
}
