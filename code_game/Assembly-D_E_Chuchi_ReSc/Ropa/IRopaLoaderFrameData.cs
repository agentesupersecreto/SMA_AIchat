using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000D3 RID: 211
	public interface IRopaLoaderFrameData
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600051A RID: 1306
		IRopaManager manager { get; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600051B RID: 1307
		IReadOnlyList<SiendoDesvestidoFrameData> enRemoverFrame { get; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600051C RID: 1308
		[Obsolete("Se unificaron los mapas", true)]
		RopaTipoDeSingleton ropaTipoDeSingleton { get; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600051D RID: 1309
		Character character { get; }

		// Token: 0x0600051E RID: 1310
		void InyectData(ref SiendoDesvestidoFrameData data);
	}
}
