using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D2 RID: 466
	public interface IMovidoEnBonesRegistrador : IMovidoEnBonesEnFrameDataCollector
	{
		// Token: 0x06000AF6 RID: 2806
		void RegistrarManipulacion(Character por, bool fueConsentido, bool forzandoMovimientoDeBone);
	}
}
