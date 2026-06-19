using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200031A RID: 794
	public interface IZonaErogenaData<T> : IDataSet<T>
	{
		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x0600112A RID: 4394
		T normalSensibilidad { get; }

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x0600112B RID: 4395
		T altaSensibilidad { get; }

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x0600112C RID: 4396
		T muyAltaSensibilidad { get; }

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x0600112D RID: 4397
		T bajaSensibilidad { get; }

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x0600112E RID: 4398
		T muyBajaSensibilidad { get; }
	}
}
