using System;

namespace Assets._ReusableScripts
{
	// Token: 0x02000006 RID: 6
	public interface IControllerColaDePrioridad
	{
		// Token: 0x06000026 RID: 38
		bool AlgunaOrndeEjecutandose();

		// Token: 0x06000027 RID: 39
		bool AlgunaOrndeDeteniendose();

		// Token: 0x06000028 RID: 40
		bool OrdenEstaTerminando(IOrdenDeController orden);
	}
}
