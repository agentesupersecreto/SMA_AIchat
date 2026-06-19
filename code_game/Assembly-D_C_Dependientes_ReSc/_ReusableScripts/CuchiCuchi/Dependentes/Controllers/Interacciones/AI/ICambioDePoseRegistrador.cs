using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001CA RID: 458
	public interface ICambioDePoseRegistrador : ICambioDePoseEnFrameDataCollector
	{
		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000AE3 RID: 2787
		// (set) Token: 0x06000AE4 RID: 2788
		int IDFlag { get; set; }

		// Token: 0x06000AE5 RID: 2789
		void RegistrarToggle(Character por, bool unaSolaVez, ParteQuePuedeEstimular estimulante, bool fueConsentido, bool ejecutarAnimacionForzando, float? VelocidadDeCambio, bool CambiaPoseActual = true, bool tryUsarTransicion = false);
	}
}
