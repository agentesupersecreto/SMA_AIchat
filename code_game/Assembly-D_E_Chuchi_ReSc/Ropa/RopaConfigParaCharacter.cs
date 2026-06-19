using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x0200013B RID: 315
	public class RopaConfigParaCharacter : CustomUpdatedMonobehaviourBase, ICharacterSkinMeshConfig
	{
		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x000224C9 File Offset: 0x000206C9
		bool ICharacterSkinMeshConfig.arreglaNormalesMagnitud
		{
			get
			{
				return this.arreglaNormales;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x000224D1 File Offset: 0x000206D1
		bool ICharacterSkinMeshConfig.copiaShapeKeys
		{
			get
			{
				return this.copiaShapeKeys;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x000224D9 File Offset: 0x000206D9
		bool ICharacterSkinMeshConfig.recalculaNormales
		{
			get
			{
				return this.recalculaNormales;
			}
		}

		// Token: 0x040005C2 RID: 1474
		[Tooltip("No es requerido si se esta usando hdrp")]
		public bool arreglaNormales;

		// Token: 0x040005C3 RID: 1475
		public bool recalculaNormales;

		// Token: 0x040005C4 RID: 1476
		public bool copiaShapeKeys;
	}
}
