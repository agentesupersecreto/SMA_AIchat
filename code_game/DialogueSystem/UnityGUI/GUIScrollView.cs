using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B9 RID: 697
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Scroll View")]
	public class GUIScrollView : GUIControl
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06001D1A RID: 7450 RVA: 0x00037AB4 File Offset: 0x00035CB4
		// (remove) Token: 0x06001D1B RID: 7451 RVA: 0x00037AD0 File Offset: 0x00035CD0
		public event Action MeasureContentHandler;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06001D1C RID: 7452 RVA: 0x00037AEC File Offset: 0x00035CEC
		// (remove) Token: 0x06001D1D RID: 7453 RVA: 0x00037B08 File Offset: 0x00035D08
		public event Action DrawContentHandler;

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06001D1E RID: 7454 RVA: 0x00037B24 File Offset: 0x00035D24
		// (set) Token: 0x06001D1F RID: 7455 RVA: 0x00037B2C File Offset: 0x00035D2C
		public float contentWidth { get; set; }

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06001D20 RID: 7456 RVA: 0x00037B38 File Offset: 0x00035D38
		// (set) Token: 0x06001D21 RID: 7457 RVA: 0x00037B40 File Offset: 0x00035D40
		public float contentHeight { get; set; }

		// Token: 0x06001D22 RID: 7458 RVA: 0x00037B4C File Offset: 0x00035D4C
		public void ResetScrollPosition()
		{
			this.scrollViewVector = Vector2.zero;
		}

		// Token: 0x06001D23 RID: 7459 RVA: 0x00037B5C File Offset: 0x00035D5C
		public override void DrawChildren(Vector2 relativeMousePosition)
		{
			this.clipChildren = false;
			Rect scrollContentRect = this.GetScrollContentRect();
			GUIStyle guistyle = ((!this.showHorizontalScrollbar) ? GUIStyle.none : GUI.skin.horizontalScrollbar);
			GUIStyle guistyle2 = ((!this.showVerticalScrollbar) ? GUIStyle.none : GUI.skin.verticalScrollbar);
			this.scrollViewVector = GUI.BeginScrollView(base.rect, this.scrollViewVector, scrollContentRect, guistyle, guistyle2);
			try
			{
				if (this.DrawContentHandler != null)
				{
					this.DrawContentHandler();
				}
				base.DrawChildren(relativeMousePosition);
			}
			finally
			{
				GUI.EndScrollView();
			}
		}

		// Token: 0x06001D24 RID: 7460 RVA: 0x00037C18 File Offset: 0x00035E18
		private Rect GetScrollContentRect()
		{
			float num = ((!(GUI.skin.verticalSlider.normal.background != null)) ? 16f : ((float)GUI.skin.verticalSlider.normal.background.width));
			this.contentWidth = base.rect.width - num;
			this.MeasureChildrenAsContent();
			if (this.MeasureContentHandler != null)
			{
				this.MeasureContentHandler();
			}
			return new Rect(0f, 0f, this.contentWidth, this.contentHeight);
		}

		// Token: 0x06001D25 RID: 7461 RVA: 0x00037CB8 File Offset: 0x00035EB8
		private void MeasureChildrenAsContent()
		{
			if (base.Children != null)
			{
				foreach (GUIControl guicontrol in base.Children)
				{
					this.contentWidth = Mathf.Max(this.contentWidth, this.GetChildXMax(guicontrol));
					this.contentHeight = Mathf.Max(this.contentHeight, this.GetChildYMax(guicontrol));
				}
			}
		}

		// Token: 0x06001D26 RID: 7462 RVA: 0x00037D54 File Offset: 0x00035F54
		private float GetChildXMax(GUIControl child)
		{
			return child.rect.xMax;
		}

		// Token: 0x06001D27 RID: 7463 RVA: 0x00037D70 File Offset: 0x00035F70
		private float GetChildYMax(GUIControl child)
		{
			if (child is GUILabel)
			{
				GUILabel guilabel = child as GUILabel;
				if (guilabel.autoSize != null && guilabel.autoSize.autoSizeHeight)
				{
					guilabel.Refresh(new Vector2(base.rect.width, base.rect.height));
					guilabel.UpdateLayout();
				}
			}
			return child.rect.yMax;
		}

		// Token: 0x0400109F RID: 4255
		public bool showVerticalScrollbar = true;

		// Token: 0x040010A0 RID: 4256
		public bool showHorizontalScrollbar;

		// Token: 0x040010A1 RID: 4257
		public int padding = 2;

		// Token: 0x040010A2 RID: 4258
		private Vector2 scrollViewVector = Vector2.zero;
	}
}
