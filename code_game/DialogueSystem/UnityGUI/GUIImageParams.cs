using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B4 RID: 692
	[Serializable]
	public class GUIImageParams
	{
		// Token: 0x06001CFE RID: 7422 RVA: 0x00036EDC File Offset: 0x000350DC
		public void Draw(Rect rect)
		{
			this.Draw(rect, false, 1f);
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x00036EEC File Offset: 0x000350EC
		public void Draw(Rect rect, bool hasAlpha, float alpha)
		{
			if (this.texture != null)
			{
				Color color = GUI.color;
				GUI.color = this.color;
				if (hasAlpha)
				{
					GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
				}
				Rect rect2 = new Rect(rect.x + this.pixelRect.x, rect.y + this.pixelRect.y, (!Tools.ApproximatelyZero(this.pixelRect.width)) ? this.pixelRect.width : rect.width, (!Tools.ApproximatelyZero(this.pixelRect.width)) ? this.pixelRect.height : rect.height);
				if (this.useTexCoords)
				{
					GUI.DrawTextureWithTexCoords(rect2, this.texture, this.texCoords, this.alphaBlend);
				}
				else
				{
					GUI.DrawTexture(rect2, this.texture, this.scaleMode, this.alphaBlend, this.aspect);
				}
				GUI.color = color;
			}
		}

		// Token: 0x04001081 RID: 4225
		public Rect pixelRect;

		// Token: 0x04001082 RID: 4226
		public Texture2D texture;

		// Token: 0x04001083 RID: 4227
		public bool useTexCoords;

		// Token: 0x04001084 RID: 4228
		public Rect texCoords = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x04001085 RID: 4229
		public ScaleMode scaleMode = ScaleMode.ScaleToFit;

		// Token: 0x04001086 RID: 4230
		public bool alphaBlend = true;

		// Token: 0x04001087 RID: 4231
		public Color color = Color.white;

		// Token: 0x04001088 RID: 4232
		public float aspect;
	}
}
