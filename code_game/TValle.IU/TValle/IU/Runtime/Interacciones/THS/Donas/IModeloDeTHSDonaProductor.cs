using System;

namespace Assets.TValle.IU.Runtime.Interacciones.THS.Donas
{
	// Token: 0x020000E1 RID: 225
	public interface IModeloDeTHSDonaProductor
	{
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060006B4 RID: 1716
		IModeloDeTHSDonaProductor previus { get; }

		// Token: 0x060006B5 RID: 1717
		bool Draw(IModeloDeTHSDonaProductor previus);

		// Token: 0x060006B6 RID: 1718
		THSDonaController.CurrentUserData ObtenerModelo();
	}
}
