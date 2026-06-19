using System;

namespace Assets
{
	// Token: 0x02000103 RID: 259
	public abstract class BaseFlotanteDobleLayerV2<T, T2> where T : BaseFlotanteSingleLayer where T2 : BaseFlotanteSingleLayer
	{
		// Token: 0x0400020B RID: 523
		public T layer1;

		// Token: 0x0400020C RID: 524
		public T2 layer2;
	}
}
