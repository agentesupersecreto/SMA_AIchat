using System;
using UnityEngine;

namespace Assets.TValle.UI
{
	// Token: 0x020000C3 RID: 195
	public class AlwaysOnScreenGeneric : AlwaysOnScreenBase
	{
		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0001526F File Offset: 0x0001346F
		protected override Vector3 curretnSorcePosition
		{
			get
			{
				return this.sorce.position;
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0001527C File Offset: 0x0001347C
		protected override void StartUnityEvent()
		{
			if (this.sorce == null)
			{
				throw new ArgumentNullException("sorce", "sorce null reference.");
			}
			base.StartUnityEvent();
		}

		// Token: 0x04000217 RID: 535
		public Transform sorce;
	}
}
