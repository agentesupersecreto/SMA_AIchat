using System;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002A9 RID: 681
	public interface IReproductorDeBlendingSonidoDeToques : IReproductorDeSonidoDeToques, IReproductorDeSonidos, IReproductorDeBlendingSonidos
	{
		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06000F3B RID: 3899
		// (remove) Token: 0x06000F3C RID: 3900
		event ModificarExtraDataDeBlendingSonidos registrandoToqueExtraData;
	}
}
