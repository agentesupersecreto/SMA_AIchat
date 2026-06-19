using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x0200013A RID: 314
	[Obsolete]
	public class RopaBraLoader : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000741 RID: 1857 RVA: 0x000224C1 File Offset: 0x000206C1
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x040005C0 RID: 1472
		[Tooltip("solo carga este gameobject")]
		public GameObject setPrefab;

		// Token: 0x040005C1 RID: 1473
		[ReadOnlyUI]
		public Skin añadido;
	}
}
