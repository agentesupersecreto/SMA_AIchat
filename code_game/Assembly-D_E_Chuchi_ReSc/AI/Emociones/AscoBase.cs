using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000400 RID: 1024
	public abstract class AscoBase : Emocion
	{
		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x0600165E RID: 5726 RVA: 0x0005CD98 File Offset: 0x0005AF98
		public sealed override float prioridad
		{
			get
			{
				return 0.1f;
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x0600165F RID: 5727 RVA: 0x0005CD9F File Offset: 0x0005AF9F
		public sealed override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.asco;
			}
		}
	}
}
