using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002BA RID: 698
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Text Field")]
	public class GUITextField : GUIVisibleControl
	{
		// Token: 0x17000A82 RID: 2690
		// (get) Token: 0x06001D29 RID: 7465 RVA: 0x00037DF0 File Offset: 0x00035FF0
		protected override GUIStyle DefaultGUIStyle
		{
			get
			{
				return GUI.skin.textField;
			}
		}

		// Token: 0x06001D2A RID: 7466 RVA: 0x00037DFC File Offset: 0x00035FFC
		public void TakeFocus()
		{
			this.takeFocus = true;
		}

		// Token: 0x06001D2B RID: 7467 RVA: 0x00037E08 File Offset: 0x00036008
		public override void DrawSelf(Vector2 relativeMousePosition)
		{
			base.SetGUIStyle();
			if (this.takeFocus)
			{
				GUI.SetNextControlName(base.FullName);
			}
			if (this.text == null)
			{
				this.text = string.Empty;
			}
			if (this.maxLength == 0)
			{
				this.text = GUI.TextField(base.rect, this.text, base.GuiStyle);
			}
			else
			{
				this.text = GUI.TextField(base.rect, this.text, this.maxLength, base.GuiStyle);
			}
			if (this.takeFocus)
			{
				GUI.FocusControl(base.FullName);
				this.takeFocus = false;
			}
		}

		// Token: 0x040010A7 RID: 4263
		public int maxLength;

		// Token: 0x040010A8 RID: 4264
		private bool takeFocus;
	}
}
