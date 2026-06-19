using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales.Updater;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200009C RID: 156
	public interface IInteraccion
	{
		// Token: 0x0600061B RID: 1563
		bool EjecutarConHandler();

		// Token: 0x0600061C RID: 1564
		void ForzarEjecucion(float duracion, float initialVelocidadInMod, float velocidadInMod, float velocidadOutMod, bool terminarDeInmediatoEjecutandosen, bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible);

		// Token: 0x0600061D RID: 1565
		bool EjecutarConEstadoActual();

		// Token: 0x0600061E RID: 1566
		bool EjecutarWhile<T_Args>(GlobalUpdater.UpdateType updateType, T_Args argumentos, Func<Interaccion, T_Args, bool> whileDelegate, float interval, int prioridad, float maxDuracion, ControllerPrioridadConfig priConfig, float velocidadMod = 1f);

		// Token: 0x0600061F RID: 1567
		bool Ejecutar(int prioridad, float duracion, ControllerPrioridadConfig priConfig, float velocidadInMod, float velocidadOutMod, bool usarTransicionEntreInteracionesEnMismoLayerSiDisponible);

		// Token: 0x06000620 RID: 1568
		bool PuedeEjecutarseSinObstaculos();

		// Token: 0x06000621 RID: 1569
		bool PuedeEjecutarse();

		// Token: 0x06000622 RID: 1570
		void Detener(bool force = false);

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000623 RID: 1571
		InteraccionEstado currentEstado { get; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000624 RID: 1572
		bool algunaEstaEjecutandose { get; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000625 RID: 1573
		bool ejecutandose { get; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000626 RID: 1574
		InteraccionInfo datosDeParesDeEfecctors { get; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000627 RID: 1575
		int interactionLayer { get; }
	}
}
