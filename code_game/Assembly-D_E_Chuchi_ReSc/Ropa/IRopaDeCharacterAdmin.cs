using System;
using System.Collections;
using Assets.Base.Plugins.Runtime;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000D2 RID: 210
	public interface IRopaDeCharacterAdmin
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000511 RID: 1297
		// (set) Token: 0x06000512 RID: 1298
		bool generar { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000513 RID: 1299
		bool estaGenerando { get; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000514 RID: 1300
		ICharacterRoot characterRoot { get; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000515 RID: 1301
		IRopaManager manager { get; }

		// Token: 0x06000516 RID: 1302
		IEnumerator Generar(ItemQuality lookingFor, float lookingForPrecisionPercentage, Action ended = null);

		// Token: 0x06000517 RID: 1303
		IEnumerator Generar(Action ended = null);

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000518 RID: 1304
		// (remove) Token: 0x06000519 RID: 1305
		event Action<IRopaDeCharacterAdmin> onGenerated;
	}
}
