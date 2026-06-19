using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B8 RID: 696
	[ExecuteInEditMode]
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Root")]
	public class GUIRoot : GUIControl
	{
		// Token: 0x06001D16 RID: 7446 RVA: 0x00037A00 File Offset: 0x00035C00
		public void OnGUI()
		{
			this.UseGUISkin();
			if (!Application.isPlaying)
			{
				this.ManualRefresh();
			}
			Vector2 vector = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
			base.Draw(vector);
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x00037A54 File Offset: 0x00035C54
		public void ManualRefresh()
		{
			this.Refresh(new Vector2((float)Screen.width, (float)Screen.height));
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x00037A70 File Offset: 0x00035C70
		private void UseGUISkin()
		{
			if (this.guiSkin != null)
			{
				GUI.skin = this.guiSkin;
			}
		}

		// Token: 0x0400109E RID: 4254
		public GUISkin guiSkin;
	}
}
