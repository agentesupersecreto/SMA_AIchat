using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B3 RID: 691
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Image")]
	public class GUIImage : GUIVisibleControl
	{
		// Token: 0x06001CFB RID: 7419 RVA: 0x00036DEC File Offset: 0x00034FEC
		public override void DrawSelf(Vector2 relativeMousePosition)
		{
			if (this.image != null)
			{
				if (this.imageAnimation.animate)
				{
					this.imageAnimation.DrawAnimation(base.rect, this.image.texture);
				}
				else
				{
					this.image.Draw(base.rect, base.HasAlpha, base.Alpha);
				}
			}
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x00036E54 File Offset: 0x00035054
		public override void Refresh()
		{
			base.Refresh();
			if (this.imageAnimation.animate)
			{
				this.imageAnimation.RefreshAnimation(this.image.texture);
			}
		}

		// Token: 0x0400107F RID: 4223
		public GUIImageParams image = new GUIImageParams();

		// Token: 0x04001080 RID: 4224
		public ImageAnimation imageAnimation = new ImageAnimation();
	}
}
