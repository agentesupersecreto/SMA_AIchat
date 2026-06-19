using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000015 RID: 21
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_bark_u_i.html")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Bark/Unity UI Bark UI")]
	public class UnityUIBarkUI : MonoBehaviour, IBarkUI
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002D6A File Offset: 0x00000F6A
		public bool IsPlaying
		{
			get
			{
				return this.canvas != null && this.canvas.enabled && DialogueTime.time < this.doneTime;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002D98 File Offset: 0x00000F98
		public void Awake()
		{
			this.canvas = base.GetComponentInChildren<Canvas>();
			this.animator = base.GetComponentInChildren<Animator>();
			if (this.animator == null && this.canvasGroup != null)
			{
				this.animator = this.canvasGroup.GetComponentInChildren<Animator>();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002DEC File Offset: 0x00000FEC
		public void Start()
		{
			if (this.canvas != null)
			{
				if (this.waitForContinueButton && this.canvas.worldCamera == null)
				{
					this.canvas.worldCamera = Camera.main;
				}
				this.canvas.enabled = false;
			}
			if (this.nameText != null)
			{
				this.nameText.gameObject.SetActive(this.includeName);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002E64 File Offset: 0x00001064
		public bool ShouldShowText(Subtitle subtitle)
		{
			bool flag = this.textDisplaySetting == BarkSubtitleSetting.Show || (this.textDisplaySetting == BarkSubtitleSetting.SameAsDialogueManager && DialogueManager.DisplaySettings.subtitleSettings.showNPCSubtitlesDuringLine);
			bool flag2 = subtitle != null && !string.IsNullOrEmpty(subtitle.formattedText.text);
			return flag && flag2;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002EB4 File Offset: 0x000010B4
		public void Bark(Subtitle subtitle)
		{
			if (this.ShouldShowText(subtitle))
			{
				this.SetUIElementsActive(false);
				string text = subtitle.formattedText.text;
				if (this.includeName)
				{
					if (this.nameText != null)
					{
						this.nameText.text = subtitle.speakerInfo.Name;
					}
					else
					{
						text = string.Format("{0}: {1}", text, subtitle.formattedText.text);
					}
				}
				if (this.barkText != null)
				{
					this.barkText.text = text;
				}
				this.SetUIElementsActive(true);
				if (this.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.showTrigger))
				{
					this.animator.SetTrigger(this.animationTransitions.showTrigger);
				}
				base.CancelInvoke("Hide");
				float num = (Mathf.Approximately(0f, this.duration) ? DialogueManager.GetBarkDuration(text) : this.duration);
				if (!this.waitUntilSequenceEnds && !this.waitForContinueButton)
				{
					base.Invoke("Hide", num);
				}
				this.doneTime = DialogueTime.time + num;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002FCC File Offset: 0x000011CC
		protected void SetUIElementsActive(bool value)
		{
			if (this.nameText != null && this.nameText.gameObject != base.gameObject)
			{
				this.nameText.gameObject.SetActive(value);
			}
			if (this.barkText != null && this.barkText.gameObject != base.gameObject)
			{
				this.barkText.gameObject.SetActive(value);
			}
			if (this.canvas != null && this.canvas.gameObject != base.gameObject)
			{
				this.canvas.gameObject.SetActive(value);
			}
			if (value && this.canvas != null)
			{
				this.canvas.enabled = true;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000309B File Offset: 0x0000129B
		public void OnBarkEnd(Transform actor)
		{
			if (this.waitUntilSequenceEnds && !this.waitForContinueButton)
			{
				this.Hide();
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000030B3 File Offset: 0x000012B3
		public void OnContinue()
		{
			this.Hide();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000030BC File Offset: 0x000012BC
		public void Hide()
		{
			if (this.canvas.enabled && this.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.hideTrigger))
			{
				if (!string.IsNullOrEmpty(this.animationTransitions.hideTrigger))
				{
					this.animator.ResetTrigger(this.animationTransitions.showTrigger);
				}
				this.animator.SetTrigger(this.animationTransitions.hideTrigger);
			}
			else if (this.canvas != null)
			{
				this.canvas.enabled = false;
			}
			this.doneTime = 0f;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003155 File Offset: 0x00001355
		protected bool CanTriggerAnimations()
		{
			return this.animator != null && this.animationTransitions != null;
		}

		// Token: 0x04000022 RID: 34
		[Tooltip("Optional canvas group, for example to play fade animations.")]
		public CanvasGroup canvasGroup;

		// Token: 0x04000023 RID: 35
		[Tooltip("UI text control for the bark text.")]
		public Text barkText;

		// Token: 0x04000024 RID: 36
		[Tooltip("Optional UI text control for the actor's name if Include Name is ticked. If unassigned and Include Name is ticked, the name is prepended to the Bark Text.")]
		public Text nameText;

		// Token: 0x04000025 RID: 37
		[Tooltip("Show the barker's name.")]
		public bool includeName;

		// Token: 0x04000026 RID: 38
		[HideInInspector]
		public float doneTime;

		// Token: 0x04000027 RID: 39
		public UnityUIBarkUI.AnimationTransitions animationTransitions = new UnityUIBarkUI.AnimationTransitions();

		// Token: 0x04000028 RID: 40
		[Tooltip("The duration in seconds to show the bark text before fading it out. If zero, use the Dialogue Manager's Bark Settings.")]
		public float duration = 4f;

		// Token: 0x04000029 RID: 41
		[Tooltip("Keep the bark text onscreen until the sequence ends.")]
		public bool waitUntilSequenceEnds;

		// Token: 0x0400002A RID: 42
		public bool waitForContinueButton;

		// Token: 0x0400002B RID: 43
		public BarkSubtitleSetting textDisplaySetting;

		// Token: 0x0400002C RID: 44
		private Canvas canvas;

		// Token: 0x0400002D RID: 45
		protected Animator animator;

		// Token: 0x0200005C RID: 92
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x0400021D RID: 541
			public string showTrigger = "Show";

			// Token: 0x0400021E RID: 542
			public string hideTrigger = "Hide";
		}
	}
}
