using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D2 RID: 722
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Bark/Unity Bark UI (Legacy Unity GUI OnGUI)")]
	public class UnityBarkUIOnGUI : MonoBehaviour
	{
		// Token: 0x17000A91 RID: 2705
		// (get) Token: 0x06001D9E RID: 7582 RVA: 0x0003A010 File Offset: 0x00038210
		public bool IsPlaying
		{
			get
			{
				return base.enabled;
			}
		}

		// Token: 0x17000A92 RID: 2706
		// (get) Token: 0x06001D9F RID: 7583 RVA: 0x0003A018 File Offset: 0x00038218
		// (set) Token: 0x06001DA0 RID: 7584 RVA: 0x0003A020 File Offset: 0x00038220
		public Vector3 BarkPosition { get; private set; }

		// Token: 0x06001DA1 RID: 7585 RVA: 0x0003A02C File Offset: 0x0003822C
		public virtual void Awake()
		{
			this.myTransform = base.transform;
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x0003A03C File Offset: 0x0003823C
		public virtual void Start()
		{
			this.ComputeOffsetToHead();
			base.enabled = false;
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x0003A04C File Offset: 0x0003824C
		protected void ComputeOffsetToHead()
		{
			CharacterController component = base.GetComponent<CharacterController>();
			if (component != null)
			{
				this.offsetToHead = new Vector3(0f, component.height, 0f);
			}
			else
			{
				CapsuleCollider component2 = base.GetComponent<CapsuleCollider>();
				if (component2 != null)
				{
					this.offsetToHead = new Vector3(0f, component2.height, 0f);
				}
				else
				{
					BoxCollider component3 = base.GetComponent<BoxCollider>();
					if (component3 != null)
					{
						this.offsetToHead = new Vector3(0f, component3.center.y + component3.size.y, 0f);
					}
					else
					{
						SphereCollider component4 = base.GetComponent<SphereCollider>();
						if (component4 != null)
						{
							this.offsetToHead = new Vector3(0f, component4.center.y + component4.radius, 0f);
						}
						else
						{
							this.offsetToHead = Vector3.zero;
						}
					}
				}
			}
			this.offsetToHead += this.offset;
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x0003A170 File Offset: 0x00038370
		public virtual void Show(Subtitle subtitle, float duration, GUISkin guiSkin, string guiStyleName, TextStyle textStyle, bool includeName, Transform textPosition)
		{
			this.Show(subtitle, duration, guiSkin, guiStyleName, textStyle, Color.black, includeName, textPosition);
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x0003A194 File Offset: 0x00038394
		public virtual void Show(Subtitle subtitle, float duration, GUISkin guiSkin, string guiStyleName, TextStyle textStyle, Color textStyleColor, bool includeName, Transform textPosition)
		{
			this.message = ((!includeName) ? subtitle.formattedText.text : string.Format("{0}: {1}", new object[]
			{
				subtitle.speakerInfo.Name,
				subtitle.formattedText.text
			}));
			this.formattingToApply = subtitle.formattedText;
			this.guiSkin = guiSkin;
			this.guiStyleName = guiStyleName;
			this.guiStyle = null;
			this.textStyle = textStyle;
			this.textStyleColor = textStyleColor;
			this.alpha = 1f;
			this.absolutePosition = textPosition;
			this.UpdateBarkPosition();
			base.enabled = true;
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x0003A23C File Offset: 0x0003843C
		public IEnumerator FadeOut(float fadeDuration)
		{
			float startTime = Time.time;
			float endTime = startTime + fadeDuration;
			while (Time.time < endTime)
			{
				float elapsed = Time.time - startTime;
				this.alpha = 1f - Mathf.Clamp(elapsed / fadeDuration, 0f, 1f);
				yield return null;
			}
			base.enabled = false;
			yield break;
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x0003A268 File Offset: 0x00038468
		public virtual void OnGUI()
		{
			GUI.skin = UnityGUITools.GetValidGUISkin(this.guiSkin);
			if (this.guiStyle == null)
			{
				this.guiStyle = UnityGUITools.ApplyFormatting(this.formattingToApply, new GUIStyle(UnityGUITools.GetGUIStyle(this.guiStyleName, GUI.skin.label)));
				this.guiStyle.alignment = TextAnchor.UpperCenter;
				this.size = this.guiStyle.CalcSize(new GUIContent(this.message));
				if (this.maxWidth >= 1f && this.size.x > this.maxWidth)
				{
					this.size = new Vector2(this.maxWidth, this.guiStyle.CalcHeight(new GUIContent(this.message), this.maxWidth));
				}
			}
			this.UpdateBarkPosition();
			this.guiStyle.normal.textColor = UnityGUITools.ColorWithAlpha(this.guiStyle.normal.textColor, this.alpha);
			if (this.screenPos.z < 0f)
			{
				return;
			}
			Rect rect = new Rect(this.screenPos.x - this.size.x / 2f, (float)Screen.height - this.screenPos.y - this.size.y / 2f, this.size.x, this.size.y);
			UnityGUITools.DrawText(rect, this.message, this.guiStyle, this.textStyle, this.textStyleColor);
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x0003A3FC File Offset: 0x000385FC
		protected void UpdateBarkPosition()
		{
			if (Camera.main == null)
			{
				return;
			}
			if (this.myTransform == null)
			{
				this.myTransform = base.transform;
			}
			this.BarkPosition = ((!(this.absolutePosition != null)) ? (this.myTransform.position + this.offsetToHead) : (this.absolutePosition.position + this.offset));
			this.screenPos = Camera.main.WorldToScreenPoint(this.BarkPosition);
		}

		// Token: 0x04001129 RID: 4393
		public Vector3 offset = Vector3.zero;

		// Token: 0x0400112A RID: 4394
		public float maxWidth;

		// Token: 0x0400112B RID: 4395
		protected GUISkin guiSkin;

		// Token: 0x0400112C RID: 4396
		protected string guiStyleName;

		// Token: 0x0400112D RID: 4397
		protected GUIStyle guiStyle;

		// Token: 0x0400112E RID: 4398
		protected FormattedText formattingToApply;

		// Token: 0x0400112F RID: 4399
		protected TextStyle textStyle;

		// Token: 0x04001130 RID: 4400
		protected Color textStyleColor = Color.black;

		// Token: 0x04001131 RID: 4401
		protected Vector2 size;

		// Token: 0x04001132 RID: 4402
		protected string message;

		// Token: 0x04001133 RID: 4403
		protected float alpha = 1f;

		// Token: 0x04001134 RID: 4404
		protected Transform myTransform;

		// Token: 0x04001135 RID: 4405
		protected Transform absolutePosition;

		// Token: 0x04001136 RID: 4406
		protected Vector3 offsetToHead = Vector3.zero;

		// Token: 0x04001137 RID: 4407
		protected Vector3 screenPos = Vector3.zero;
	}
}
