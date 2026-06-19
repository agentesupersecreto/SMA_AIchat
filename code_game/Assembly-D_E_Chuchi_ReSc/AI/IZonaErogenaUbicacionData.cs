using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000319 RID: 793
	public interface IZonaErogenaUbicacionData<T> : IDataSet<T>
	{
		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06001123 RID: 4387
		T cabeza { get; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06001124 RID: 4388
		T pecho { get; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06001125 RID: 4389
		T cintura { get; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06001126 RID: 4390
		T cadera { get; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06001127 RID: 4391
		T entrepierna { get; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06001128 RID: 4392
		T brazos { get; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06001129 RID: 4393
		T piernas { get; }
	}
}
