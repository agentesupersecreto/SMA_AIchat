using System;
using UnityEngine;

namespace Assets._ReusableScripts.TavoBehaviours
{
	// Token: 0x02000008 RID: 8
	[RequireComponent(typeof(Canvas))]
	public class SetCanvasCameraToUICamera : MonoBehaviour
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002AE8 File Offset: 0x00000CE8
		private void Start()
		{
			Canvas component = base.GetComponent<Canvas>();
			Camera main = Camera.main;
			if (main == null)
			{
				throw new ArgumentNullException("mainCamera", "mainCamera null reference.");
			}
			component.worldCamera = main;
		}

		// Token: 0x04000023 RID: 35
		public const string UiCameraTag = "UICamera";
	}
}
