using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002BB RID: 699
	public class GUIVisibleControl : GUIControl
	{
		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x06001D2D RID: 7469 RVA: 0x00037EE0 File Offset: 0x000360E0
		// (set) Token: 0x06001D2E RID: 7470 RVA: 0x00037EE8 File Offset: 0x000360E8
		public float Alpha
		{
			get
			{
				return this.alpha;
			}
			set
			{
				this.alpha = value;
			}
		}

		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x06001D2F RID: 7471 RVA: 0x00037EF4 File Offset: 0x000360F4
		public bool HasAlpha
		{
			get
			{
				return this.Alpha < 0.999f && Application.isPlaying;
			}
		}

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x06001D30 RID: 7472 RVA: 0x00037F10 File Offset: 0x00036110
		protected virtual GUIStyle DefaultGUIStyle
		{
			get
			{
				return GUI.skin.label;
			}
		}

		// Token: 0x17000A86 RID: 2694
		// (get) Token: 0x06001D31 RID: 7473 RVA: 0x00037F1C File Offset: 0x0003611C
		// (set) Token: 0x06001D32 RID: 7474 RVA: 0x00037F24 File Offset: 0x00036124
		protected GUIStyle GuiStyle
		{
			get
			{
				return this.guiStyle;
			}
			set
			{
				this.guiStyle = value;
			}
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x00037F30 File Offset: 0x00036130
		public override void Awake()
		{
			base.Awake();
			this.originalTextValue = this.text;
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x00037F44 File Offset: 0x00036144
		public virtual void Start()
		{
			if (this.localizedText != null)
			{
				this.UseLocalizedText(this.localizedText);
			}
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x00037F64 File Offset: 0x00036164
		public void UseLocalizedText(LocalizedTextTable localizedText)
		{
			this.localizedText = localizedText;
			if (localizedText != null && localizedText.ContainsField(this.originalTextValue))
			{
				this.text = localizedText[this.originalTextValue];
			}
		}

		// Token: 0x06001D36 RID: 7478 RVA: 0x00037FA8 File Offset: 0x000361A8
		public void ApplyAlphaToGUIColor()
		{
			if (this.HasAlpha)
			{
				this.originalGUIColor = GUI.color;
				GUI.color = UnityGUITools.ColorWithAlpha(GUI.color, this.Alpha);
			}
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x00037FE0 File Offset: 0x000361E0
		public void RestoreGUIColor()
		{
			if (this.HasAlpha)
			{
				GUI.color = this.originalGUIColor;
			}
		}

		// Token: 0x06001D38 RID: 7480 RVA: 0x00037FF8 File Offset: 0x000361F8
		public virtual void SetFormattedText(FormattedText formattedText)
		{
			this.text = formattedText.text;
			this.formattingToApply = formattedText;
			this.isFormattingApplied = false;
			this.GuiStyle = null;
			base.NeedToUpdateLayout = true;
		}

		// Token: 0x06001D39 RID: 7481 RVA: 0x00038030 File Offset: 0x00036230
		public void SetUnformattedText(string text)
		{
			this.text = text;
			this.formattingToApply = null;
			this.guiStyle = null;
			base.NeedToUpdateLayout = true;
		}

		// Token: 0x06001D3A RID: 7482 RVA: 0x00038050 File Offset: 0x00036250
		public override void UpdateLayoutSelf()
		{
			this.guiStyle = null;
			this.isFormattingApplied = false;
			this.ApplyFormatting();
			base.UpdateLayoutSelf();
		}

		// Token: 0x06001D3B RID: 7483 RVA: 0x0003806C File Offset: 0x0003626C
		protected void SetGUIStyle()
		{
			if (this.guiStyle == null)
			{
				this.guiStyle = UnityGUITools.GetGUIStyle(this.guiStyleName, this.DefaultGUIStyle);
			}
		}

		// Token: 0x06001D3C RID: 7484 RVA: 0x0003809C File Offset: 0x0003629C
		protected void ApplyFormatting()
		{
			this.SetGUIStyle();
			if (!this.isFormattingApplied && this.formattingToApply != null)
			{
				this.text = this.formattingToApply.text;
				this.guiStyle = UnityGUITools.ApplyFormatting(this.formattingToApply, this.guiStyle);
				this.isFormattingApplied = true;
			}
		}

		// Token: 0x06001D3D RID: 7485 RVA: 0x000380F4 File Offset: 0x000362F4
		public override void AutoSizeSelf()
		{
			this.ApplyFormatting();
			if (this.autoSize.autoSizeWidth)
			{
				float num = new GUIStyle(this.guiStyle)
				{
					padding = new RectOffset(0, 0, 0, 0)
				}.CalcSize(new GUIContent(this.text)).x + (float)this.guiStyle.padding.left + (float)this.guiStyle.padding.right;
				num = Mathf.Clamp(num, this.scaledRect.minPixelWidth, this.autoSize.maxWidth.GetPixelValue(base.WindowSize.x));
				num += (float)(this.autoSize.padding.left + this.autoSize.padding.right);
				base.rect = new Rect(this.GetAutoSizeX(num), base.rect.y, num, base.rect.height);
			}
			if (this.autoSize.autoSizeHeight)
			{
				float num2 = this.guiStyle.CalcHeight(new GUIContent(this.text), base.rect.width);
				num2 = Mathf.Clamp(num2, this.scaledRect.minPixelHeight, this.autoSize.maxHeight.GetPixelValue(base.WindowSize.y));
				num2 += (float)(this.autoSize.padding.top + this.autoSize.padding.bottom);
				base.rect = new Rect(base.rect.x, this.GetAutoSizeY(num2), base.rect.width, num2);
			}
		}

		// Token: 0x06001D3E RID: 7486 RVA: 0x000382B4 File Offset: 0x000364B4
		private float GetAutoSizeX(float width)
		{
			switch (this.scaledRect.alignment)
			{
			case ScaledRectAlignment.TopLeft:
			case ScaledRectAlignment.MiddleLeft:
			case ScaledRectAlignment.BottomLeft:
				return base.rect.x;
			case ScaledRectAlignment.TopCenter:
			case ScaledRectAlignment.MiddleCenter:
			case ScaledRectAlignment.BottomCenter:
				return base.rect.x + 0.5f * (base.rect.width - width);
			case ScaledRectAlignment.TopRight:
			case ScaledRectAlignment.MiddleRight:
			case ScaledRectAlignment.BottomRight:
				return base.rect.x + (base.rect.width - width);
			default:
				return base.rect.x;
			}
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x00038364 File Offset: 0x00036564
		private float GetAutoSizeY(float height)
		{
			switch (this.scaledRect.alignment)
			{
			case ScaledRectAlignment.TopLeft:
			case ScaledRectAlignment.TopCenter:
			case ScaledRectAlignment.TopRight:
				return base.rect.y;
			case ScaledRectAlignment.MiddleLeft:
			case ScaledRectAlignment.MiddleCenter:
			case ScaledRectAlignment.MiddleRight:
				return base.rect.y + 0.5f * (base.rect.height - height);
			case ScaledRectAlignment.BottomLeft:
			case ScaledRectAlignment.BottomCenter:
			case ScaledRectAlignment.BottomRight:
				return base.rect.y + (base.rect.height - height);
			default:
				return base.rect.y;
			}
		}

		// Token: 0x06001D40 RID: 7488 RVA: 0x00038414 File Offset: 0x00036614
		public void PlaySound(AudioClip audioClip)
		{
			if (audioClip != null && Camera.main != null)
			{
				AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
				if (audioSource == null)
				{
					audioSource = Camera.main.gameObject.AddComponent<AudioSource>();
				}
				audioSource.PlayOneShot(audioClip);
			}
		}

		// Token: 0x040010A9 RID: 4265
		public LocalizedTextTable localizedText;

		// Token: 0x040010AA RID: 4266
		public string text;

		// Token: 0x040010AB RID: 4267
		public string guiStyleName;

		// Token: 0x040010AC RID: 4268
		private FormattedText formattingToApply;

		// Token: 0x040010AD RID: 4269
		private bool isFormattingApplied;

		// Token: 0x040010AE RID: 4270
		private GUIStyle guiStyle;

		// Token: 0x040010AF RID: 4271
		private Color originalGUIColor = Color.white;

		// Token: 0x040010B0 RID: 4272
		private float alpha = 1f;

		// Token: 0x040010B1 RID: 4273
		private string originalTextValue = string.Empty;
	}
}
