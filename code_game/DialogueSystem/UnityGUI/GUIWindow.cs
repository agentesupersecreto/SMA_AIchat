using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002BC RID: 700
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Window")]
	public class GUIWindow : GUIVisibleControl
	{
		// Token: 0x17000A87 RID: 2695
		// (get) Token: 0x06001D42 RID: 7490 RVA: 0x00038474 File Offset: 0x00036674
		protected override GUIStyle DefaultGUIStyle
		{
			get
			{
				return GUI.skin.window;
			}
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x00038480 File Offset: 0x00036680
		public override void DrawSelf(Vector2 relativeMousePosition)
		{
			base.SetGUIStyle();
			base.ApplyAlphaToGUIColor();
			this.currentChildMousePosition = new Vector2(relativeMousePosition.x - base.rect.x, relativeMousePosition.y - base.rect.y);
			Rect rect = GUI.Window(0, base.rect, new GUI.WindowFunction(this.WindowFunction), this.text, base.GuiStyle);
			base.RestoreGUIColor();
			base.rect = rect;
		}

		// Token: 0x06001D44 RID: 7492 RVA: 0x00038504 File Offset: 0x00036704
		public override void DrawChildren(Vector2 relativeMousePosition)
		{
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x00038508 File Offset: 0x00036708
		private void WindowFunction(int windowID)
		{
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
			foreach (GUIControl guicontrol in base.Children)
			{
				guicontrol.Draw(this.currentChildMousePosition);
			}
		}

		// Token: 0x040010B2 RID: 4274
		private Vector2 currentChildMousePosition;
	}
}
