using System;
using Assets._ReusableScripts.CuchiCuchi.Ropa;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Ropa
{
	// Token: 0x0200024B RID: 587
	public sealed class ModificacionDeDesgastePorCambiosDeRopaAnus : ModificacionDeDesgastePorCambiosDeRopaBase
	{
		// Token: 0x06000D24 RID: 3364 RVA: 0x0003C660 File Offset: 0x0003A860
		protected override float ObtenerModificacionDeDesgaste(PiezaDeRopaBase pieza)
		{
			return pieza.dataDeRopa.anusConfig.modificadorDeDesgaste;
		}
	}
}
