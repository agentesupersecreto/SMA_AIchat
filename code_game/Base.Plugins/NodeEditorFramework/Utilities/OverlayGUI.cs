using System;
using UnityEngine;

namespace NodeEditorFramework.Utilities
{
	// Token: 0x0200009B RID: 155
	public static class OverlayGUI
	{
		// Token: 0x060004AA RID: 1194 RVA: 0x00014AD1 File Offset: 0x00012CD1
		public static bool HasPopupControl()
		{
			return OverlayGUI.currentPopup != null;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00014ADB File Offset: 0x00012CDB
		public static void StartOverlayGUI()
		{
			if (OverlayGUI.currentPopup != null && Event.current.type != EventType.Layout && Event.current.type != EventType.Repaint)
			{
				OverlayGUI.currentPopup.Draw();
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00014B08 File Offset: 0x00012D08
		public static void EndOverlayGUI()
		{
			if (OverlayGUI.currentPopup != null && (Event.current.type == EventType.Layout || Event.current.type == EventType.Repaint))
			{
				OverlayGUI.currentPopup.Draw();
			}
		}

		// Token: 0x0400013A RID: 314
		public static PopupMenu currentPopup;
	}
}
