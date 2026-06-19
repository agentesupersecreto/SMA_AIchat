using System;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000E4 RID: 228
	public interface IClickableSelectableTHSDonaItem
	{
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060006BA RID: 1722
		OnClickItemOpcionDeTHSDonaEvent onOpcionClicked { get; }

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060006BB RID: 1723
		OnClickItemOpcionDeTHSDonaEvent onOpcionSelectionChanged { get; }
	}
}
