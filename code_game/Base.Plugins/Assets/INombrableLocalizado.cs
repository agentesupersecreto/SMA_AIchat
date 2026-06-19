using System;

namespace Assets
{
	// Token: 0x020000EA RID: 234
	public interface INombrableLocalizado : INombrable
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000683 RID: 1667
		bool esPlural { get; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000684 RID: 1668
		bool esFemenino { get; }

		// Token: 0x06000685 RID: 1669
		string ObtenerNombreDeCurrentLocalization(NombrableResult resultado);
	}
}
