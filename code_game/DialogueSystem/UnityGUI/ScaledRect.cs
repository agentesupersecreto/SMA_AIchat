using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C7 RID: 711
	[Serializable]
	public class ScaledRect
	{
		// Token: 0x06001D61 RID: 7521 RVA: 0x00038A0C File Offset: 0x00036C0C
		public ScaledRect(ScaledRectAlignment origin, ScaledRectAlignment alignment, ScaledValue x, ScaledValue y, ScaledValue width, ScaledValue height, float minPixelWidth = 0f, float minPixelHeight = 0f)
		{
			this.origin = origin;
			this.alignment = alignment;
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			this.minPixelWidth = minPixelWidth;
			this.minPixelHeight = minPixelHeight;
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x00038A5C File Offset: 0x00036C5C
		public ScaledRect(ScaledRect source)
		{
			if (source != null)
			{
				this.origin = source.origin;
				this.alignment = source.alignment;
				this.x = new ScaledValue(source.x);
				this.y = new ScaledValue(source.y);
				this.width = new ScaledValue(source.width);
				this.height = new ScaledValue(source.height);
				this.minPixelWidth = source.minPixelWidth;
				this.minPixelHeight = source.minPixelHeight;
			}
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x00038AEC File Offset: 0x00036CEC
		public ScaledRect()
		{
		}

		// Token: 0x06001D65 RID: 7525 RVA: 0x00038B58 File Offset: 0x00036D58
		public static ScaledRect FromOrigin(ScaledRectAlignment origin, ScaledValue width, ScaledValue height, float minPixelWidth = 0f, float minPixelHeight = 0f)
		{
			return new ScaledRect(origin, origin, ScaledValue.zero, ScaledValue.zero, width, height, minPixelWidth, minPixelHeight);
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x00038B7C File Offset: 0x00036D7C
		public Rect GetPixelRect()
		{
			return this.GetPixelRect(new Vector2((float)Screen.width, (float)Screen.height), Vector2.zero);
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x00038B9C File Offset: 0x00036D9C
		public Rect GetPixelRect(Vector2 windowSize)
		{
			return this.GetPixelRect(windowSize, Vector2.zero);
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x00038BAC File Offset: 0x00036DAC
		public Rect GetPixelRect(Vector2 windowSize, Vector2 defaultSize)
		{
			float num = Mathf.Max(this.width.GetPixelValue(windowSize.x), this.minPixelWidth);
			float num2 = Mathf.Max(this.height.GetPixelValue(windowSize.y), this.minPixelHeight);
			Vector2 pixelOrigin = this.GetPixelOrigin(windowSize);
			Vector2 alignmentFactor = this.GetAlignmentFactor();
			float num3 = pixelOrigin.x + num * alignmentFactor.x + this.x.GetPixelValue(windowSize.x);
			float num4 = pixelOrigin.y + num2 * alignmentFactor.y + this.y.GetPixelValue(windowSize.y);
			return new Rect(num3, num4, num, num2);
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x00038C5C File Offset: 0x00036E5C
		private Vector2 GetPixelOrigin(Vector2 windowSize)
		{
			switch (this.origin)
			{
			case ScaledRectAlignment.TopLeft:
				return Vector2.zero;
			case ScaledRectAlignment.TopCenter:
				return new Vector2(0.5f * windowSize.x, 0f);
			case ScaledRectAlignment.TopRight:
				return new Vector2(windowSize.x, 0f);
			case ScaledRectAlignment.MiddleLeft:
				return new Vector2(0f, 0.5f * windowSize.y);
			case ScaledRectAlignment.MiddleCenter:
				return new Vector2(0.5f * windowSize.x, 0.5f * windowSize.y);
			case ScaledRectAlignment.MiddleRight:
				return new Vector2(windowSize.x, 0.5f * windowSize.y);
			case ScaledRectAlignment.BottomLeft:
				return new Vector2(0f, windowSize.y);
			case ScaledRectAlignment.BottomCenter:
				return new Vector2(0.5f * windowSize.x, windowSize.y);
			case ScaledRectAlignment.BottomRight:
				return windowSize;
			default:
				return Vector2.zero;
			}
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x00038D54 File Offset: 0x00036F54
		private Vector2 GetAlignmentFactor()
		{
			switch (this.alignment)
			{
			case ScaledRectAlignment.TopLeft:
				return Vector2.zero;
			case ScaledRectAlignment.TopCenter:
				return new Vector2(-0.5f, 0f);
			case ScaledRectAlignment.TopRight:
				return new Vector2(-1f, 0f);
			case ScaledRectAlignment.MiddleLeft:
				return new Vector2(0f, -0.5f);
			case ScaledRectAlignment.MiddleCenter:
				return new Vector2(-0.5f, -0.5f);
			case ScaledRectAlignment.MiddleRight:
				return new Vector2(-1f, -0.5f);
			case ScaledRectAlignment.BottomLeft:
				return new Vector2(0f, -1f);
			case ScaledRectAlignment.BottomCenter:
				return new Vector2(-0.5f, -1f);
			case ScaledRectAlignment.BottomRight:
				return new Vector2(-1f, -1f);
			default:
				return Vector2.zero;
			}
		}

		// Token: 0x040010D3 RID: 4307
		public static readonly ScaledRect empty = new ScaledRect(ScaledRectAlignment.TopLeft, ScaledRectAlignment.TopLeft, ScaledValue.zero, ScaledValue.zero, ScaledValue.zero, ScaledValue.zero, 0f, 0f);

		// Token: 0x040010D4 RID: 4308
		public static readonly ScaledRect wholeScreen = new ScaledRect(ScaledRectAlignment.TopLeft, ScaledRectAlignment.TopLeft, ScaledValue.zero, ScaledValue.zero, ScaledValue.max, ScaledValue.max, 0f, 0f);

		// Token: 0x040010D5 RID: 4309
		public ScaledRectAlignment origin;

		// Token: 0x040010D6 RID: 4310
		public ScaledRectAlignment alignment;

		// Token: 0x040010D7 RID: 4311
		public ScaledValue x;

		// Token: 0x040010D8 RID: 4312
		public ScaledValue y;

		// Token: 0x040010D9 RID: 4313
		public ScaledValue width;

		// Token: 0x040010DA RID: 4314
		public ScaledValue height;

		// Token: 0x040010DB RID: 4315
		public float minPixelWidth;

		// Token: 0x040010DC RID: 4316
		public float minPixelHeight;
	}
}
