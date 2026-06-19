using System;

namespace Assets._ReusableScripts
{
	// Token: 0x02000007 RID: 7
	public interface IOrdenDeController
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000029 RID: 41
		bool permanente { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002A RID: 42
		bool stared { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002B RID: 43
		IOrdenDeController anterior { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002C RID: 44
		int tipoId { get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002D RID: 45
		int prioridad { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002E RID: 46
		ControllerPrioridadConfig priConfig { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47
		float duracion { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000030 RID: 48
		float startTime { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000031 RID: 49
		float currentTime { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000032 RID: 50
		float currentTimeMod { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000033 RID: 51
		float tiempoRestante { get; }

		// Token: 0x06000034 RID: 52
		bool Termino();

		// Token: 0x06000035 RID: 53
		bool TerminoTiempo();
	}
}
