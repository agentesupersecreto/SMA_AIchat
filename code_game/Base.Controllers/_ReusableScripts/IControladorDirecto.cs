using System;
using Assets._ReusableScripts.Controllers;

namespace Assets._ReusableScripts
{
	// Token: 0x0200000B RID: 11
	public interface IControladorDirecto : IComponentStartable
	{
		// Token: 0x0600006D RID: 109
		int IndexDeKey(string key);

		// Token: 0x0600006E RID: 110
		ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ObtenerOrdenesDeID(string id, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden tipo);

		// Token: 0x0600006F RID: 111
		ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ObtenerOrdenesDeID(int index, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden tipo);

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000070 RID: 112
		// (remove) Token: 0x06000071 RID: 113
		event Action<ControllerMultipleDirectoModificableDeUnSoloFloat> updating;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000072 RID: 114
		// (remove) Token: 0x06000073 RID: 115
		event Action<ControllerMultipleDirectoModificableDeUnSoloFloat> updated;

		// Token: 0x06000074 RID: 116
		ControllerMultipleDirectoModificableDeUnSoloFloat.Valor ObtenerValorActual(string id);

		// Token: 0x06000075 RID: 117
		ControllerMultipleDirectoModificableDeUnSoloFloat.Valor ObtenerValorActual(int index);
	}
}
