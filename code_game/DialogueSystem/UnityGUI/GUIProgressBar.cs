using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B6 RID: 694
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Progress Bar")]
	public class GUIProgressBar : GUIVisibleControl
	{
		// Token: 0x06001D14 RID: 7444 RVA: 0x000376C4 File Offset: 0x000358C4
		public override void DrawSelf(Vector2 relativeMousePosition)
		{
			if (this.emptyImage != null)
			{
				GUI.DrawTexture(base.rect, this.emptyImage);
			}
			float num = Mathf.Clamp(this.progress, 0f, 1f);
			Rect rect;
			Rect rect2;
			switch (this.origin)
			{
			case GUIProgressBar.Origin.Top:
			{
				float num2 = base.rect.height * num;
				rect = new Rect(base.rect.x, base.rect.y, base.rect.width, num2);
				rect2 = new Rect(0f, 1f - num, 1f, num);
				goto IL_0308;
			}
			case GUIProgressBar.Origin.Bottom:
			{
				float num3 = base.rect.height * num;
				rect = new Rect(base.rect.x, base.rect.yMax - num3, base.rect.width, num3);
				rect2 = new Rect(0f, 0f, 1f, num);
				goto IL_0308;
			}
			case GUIProgressBar.Origin.Right:
			{
				float num4 = base.rect.width * num;
				rect = new Rect(base.rect.xMax - num4, base.rect.y, num4, base.rect.height);
				rect2 = new Rect(1f - num, 0f, num, 1f);
				goto IL_0308;
			}
			case GUIProgressBar.Origin.HorizontalCenter:
			{
				float num5 = base.rect.width * num;
				rect = new Rect(base.rect.x + 0.5f * (base.rect.width - num5), base.rect.y, num5, base.rect.height);
				rect2 = new Rect(0.5f * (1f - num), 0f, num, 1f);
				goto IL_0308;
			}
			case GUIProgressBar.Origin.VerticalCenter:
			{
				float num6 = base.rect.height * num;
				rect = new Rect(base.rect.x, base.rect.y + 0.5f * (base.rect.height - num6), base.rect.width, num6);
				rect2 = new Rect(0f, 0.5f * (1f - num), 1f, num);
				goto IL_0308;
			}
			}
			rect = new Rect(base.rect.x, base.rect.y, base.rect.width * num, base.rect.height);
			rect2 = new Rect(0f, 0f, num, 1f);
			IL_0308:
			if (this.fullImage != null)
			{
				GUI.DrawTextureWithTexCoords(rect, this.fullImage, rect2);
			}
		}

		// Token: 0x04001093 RID: 4243
		public GUIProgressBar.Origin origin;

		// Token: 0x04001094 RID: 4244
		public Texture2D emptyImage;

		// Token: 0x04001095 RID: 4245
		public Texture2D fullImage;

		// Token: 0x04001096 RID: 4246
		public float progress;

		// Token: 0x020002B7 RID: 695
		public enum Origin
		{
			// Token: 0x04001098 RID: 4248
			Top,
			// Token: 0x04001099 RID: 4249
			Bottom,
			// Token: 0x0400109A RID: 4250
			Left,
			// Token: 0x0400109B RID: 4251
			Right,
			// Token: 0x0400109C RID: 4252
			HorizontalCenter,
			// Token: 0x0400109D RID: 4253
			VerticalCenter
		}
	}
}
