using System;
using Assets._ReusableScripts.CuchiCuchi.Ropa;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Ropa
{
	// Token: 0x0200024C RID: 588
	public sealed class ModificacionDeDesgastePorCambiosDeRopaVag : ModificacionDeDesgastePorCambiosDeRopaBase
	{
		// Token: 0x06000D26 RID: 3366 RVA: 0x0003C67A File Offset: 0x0003A87A
		protected override float ObtenerModificacionDeDesgaste(PiezaDeRopaBase pieza)
		{
			return pieza.dataDeRopa.vagConfig.modificadorDeDesgaste;
		}
	}
}
