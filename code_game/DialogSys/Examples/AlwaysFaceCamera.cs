using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.Examples
{
	// Token: 0x02000051 RID: 81
	[AddComponentMenu("Dialogue System/Actor/Always Face Camera")]
	public class AlwaysFaceCamera : MonoBehaviour
	{
		// Token: 0x0600025D RID: 605 RVA: 0x0000CD3D File Offset: 0x0000AF3D
		private void Awake()
		{
			this.myTransform = base.transform;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000CD4C File Offset: 0x0000AF4C
		private void Update()
		{
			if (this.myTransform != null && Camera.main != null)
			{
				if (this.yAxisOnly)
				{
					this.myTransform.LookAt(new Vector3(Camera.main.transform.position.x, this.myTransform.position.y, Camera.main.transform.position.z));
					return;
				}
				this.myTransform.LookAt(Camera.main.transform);
			}
		}

		// Token: 0x040001FB RID: 507
		public bool yAxisOnly;

		// Token: 0x040001FC RID: 508
		private Transform myTransform;
	}
}
