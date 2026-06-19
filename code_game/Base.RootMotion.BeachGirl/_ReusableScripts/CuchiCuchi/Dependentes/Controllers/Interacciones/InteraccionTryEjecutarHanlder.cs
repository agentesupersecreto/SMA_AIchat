using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D6 RID: 214
	// (Invoke) Token: 0x060007B5 RID: 1973
	public delegate bool InteraccionTryEjecutarHanlder(Interaccion interaccion, out int prioridad, out float duracion, out ControllerPrioridadConfig priConfig, out float velocidadMod, out bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible);
}
