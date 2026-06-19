using System;
using Assets._ReusableScripts;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x02000048 RID: 72
	public interface IControladorDeGestosDeBoca : IControllerColaDePrioridad
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000144 RID: 324
		ModificableDeFloat modificableDeVelocidadDeEjeccion { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000145 RID: 325
		ModificableDeFloat modificableDeVelocidadDeDetencion { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000146 RID: 326
		ModificableDeBool modificableIgnorarOrdenes { get; }

		// Token: 0x06000147 RID: 327
		bool DetenerGesto(TiposDeGestosDeBoca tipoDeGesto);

		// Token: 0x06000148 RID: 328
		bool DetenerGestos();

		// Token: 0x06000149 RID: 329
		TiposDeGestosDeBoca Gestuandose();

		// Token: 0x0600014A RID: 330
		bool Gestuar(TiposDeGestosDeBoca tipoDeGesto, float weight, int prioridad, ControllerPrioridadConfig priConfig, float duracion, bool puedePonerEnCola, Func<bool> puedeContinuarEjecutandose = null, float InVelocityMod = 1f, float OutVelocityMod = 1f);
	}
}
