using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001F RID: 31
	[Serializable]
	public class UnityUIResponseMenuControls : AbstractUIResponseMenuControls
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x000041FD File Offset: 0x000023FD
		public override void SetPCPortrait(Texture2D portraitTexture, string portraitName)
		{
			this.pcPortraitTexture = portraitTexture;
			this.pcPortraitName = portraitName;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004210 File Offset: 0x00002410
		public override void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			if (string.Equals(actorName, this.pcPortraitName))
			{
				Texture2D validPortraitTexture = AbstractDialogueUI.GetValidPortraitTexture(actorName, portraitTexture);
				this.pcPortraitTexture = validPortraitTexture;
				if (this.pcImage != null && DialogueManager.MasterDatabase.IsPlayer(actorName))
				{
					this.pcImage.sprite = UITools.CreateSprite(validPortraitTexture);
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00004266 File Offset: 0x00002466
		public override AbstractUISubtitleControls SubtitleReminder
		{
			get
			{
				return this.subtitleReminder;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004270 File Offset: 0x00002470
		public override void SetActive(bool value)
		{
			try
			{
				this.SubtitleReminder.SetActive(value && this.SubtitleReminder.HasText);
				Tools.SetGameObjectActive(this.buttonTemplate, false);
				foreach (UnityUIResponseButton unityUIResponseButton in this.buttons)
				{
					if (unityUIResponseButton != null)
					{
						Tools.SetGameObjectActive(unityUIResponseButton, value && unityUIResponseButton.visible);
					}
				}
				Tools.SetGameObjectActive(this.timer, false);
				Tools.SetGameObjectActive(this.pcName, value);
				Tools.SetGameObjectActive(this.pcImage, value);
				if (value)
				{
					if (this.pcImage != null && this.pcPortraitTexture != null)
					{
						this.pcImage.sprite = UITools.CreateSprite(this.pcPortraitTexture);
					}
					if (this.pcName != null && this.pcPortraitName != null)
					{
						this.pcName.text = this.pcPortraitName;
					}
					Tools.SetGameObjectActive(this.panel, true);
					if (!this.isVisible && this.CanTriggerAnimation(this.animationTransitions.showTrigger))
					{
						UIShowHideController.TransitionMode transitionMode = this.animationTransitions.transitionMode;
						if (transitionMode != UIShowHideController.TransitionMode.State)
						{
							if (transitionMode == UIShowHideController.TransitionMode.Trigger)
							{
								this.animator.SetTrigger(this.animationTransitions.showTrigger);
							}
						}
						else
						{
							this.animator.Play(this.animationTransitions.showTrigger);
						}
					}
					if (this.explicitNavigationForTemplateButtons)
					{
						this.SetupTemplateButtonNavigation();
					}
				}
				else if (this.isVisible && this.CanTriggerAnimation(this.animationTransitions.hideTrigger))
				{
					UIShowHideController.TransitionMode transitionMode = this.animationTransitions.transitionMode;
					if (transitionMode != UIShowHideController.TransitionMode.State)
					{
						if (transitionMode == UIShowHideController.TransitionMode.Trigger)
						{
							this.animator.SetTrigger(this.animationTransitions.hideTrigger);
						}
					}
					else
					{
						this.animator.Play(this.animationTransitions.hideTrigger);
					}
					DialogueManager.Instance.StartCoroutine(this.DisableAfterAnimation(this.panel));
				}
				else if (!this.isHiding && this.panel != null)
				{
					Tools.SetGameObjectActive(this.panel, false);
				}
			}
			finally
			{
				this.isVisible = value;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000449C File Offset: 0x0000269C
		protected override void ClearResponseButtons()
		{
			this.DestroyInstantiatedButtons();
			if (this.buttons != null)
			{
				for (int i = 0; i < this.buttons.Length; i++)
				{
					if (!(this.buttons[i] == null))
					{
						this.buttons[i].Reset();
						this.buttons[i].visible = this.showUnusedButtons;
					}
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000044FC File Offset: 0x000026FC
		protected override void SetResponseButtons(Response[] responses, Transform target)
		{
			this.DestroyInstantiatedButtons();
			if (this.buttons != null && responses != null)
			{
				int num = 0;
				for (int i = 0; i < responses.Length; i++)
				{
					if (responses[i].formattedText.position != -1)
					{
						int position = responses[i].formattedText.position;
						if (0 <= position && position < this.buttons.Length && this.buttons[position] != null)
						{
							this.SetResponseButton(this.buttons[position], responses[i], target, num++);
						}
						else
						{
							Debug.LogWarning("Dialogue System: Buttons list doesn't contain a button for position " + position.ToString());
						}
					}
				}
				if (this.buttonTemplate != null && this.buttonTemplateHolder != null)
				{
					if (this.buttonTemplateScrollbar != null)
					{
						this.buttonTemplateScrollbar.value = this.buttonTemplateScrollbarResetValue;
					}
					for (int j = 0; j < responses.Length; j++)
					{
						if (responses[j].formattedText.position == -1)
						{
							GameObject gameObject = Object.Instantiate<GameObject>(this.buttonTemplate.gameObject);
							if (gameObject == null)
							{
								Debug.LogError(string.Format("{0}: Couldn't instantiate response button template", "Dialogue System"));
							}
							else
							{
								this.instantiatedButtons.Add(gameObject);
								gameObject.transform.SetParent(this.buttonTemplateHolder.transform, false);
								gameObject.SetActive(true);
								UnityUIResponseButton component = gameObject.GetComponent<UnityUIResponseButton>();
								this.SetResponseButton(component, responses[j], target, num++);
								if (component != null)
								{
									gameObject.name = "Response: " + component.Text;
								}
							}
						}
					}
				}
				else if (this.buttonAlignment == ResponseButtonAlignment.ToFirst)
				{
					for (int k = 0; k < Mathf.Min(this.buttons.Length, responses.Length); k++)
					{
						if (responses[k].formattedText.position == -1)
						{
							int num2 = Mathf.Clamp(this.GetNextAvailableResponseButtonPosition(0, 1), 0, this.buttons.Length - 1);
							this.SetResponseButton(this.buttons[num2], responses[k], target, num++);
						}
					}
				}
				else
				{
					for (int l = Mathf.Min(this.buttons.Length, responses.Length) - 1; l >= 0; l--)
					{
						if (responses[l].formattedText.position == -1)
						{
							int num3 = Mathf.Clamp(this.GetNextAvailableResponseButtonPosition(this.buttons.Length - 1, -1), 0, this.buttons.Length - 1);
							this.SetResponseButton(this.buttons[num3], responses[l], target, num++);
						}
					}
				}
			}
			this.NotifyContentChanged();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004788 File Offset: 0x00002988
		private void SetResponseButton(UnityUIResponseButton button, Response response, Transform target, int buttonNumber)
		{
			if (button != null)
			{
				button.visible = true;
				button.clickable = response.enabled;
				button.target = target;
				if (response != null)
				{
					button.SetFormattedText(response.formattedText);
				}
				button.response = response;
				if (this.autonumber.enabled)
				{
					button.Text = string.Format(this.autonumber.format, buttonNumber + 1, button.Text);
					UIButtonKeyTrigger uibuttonKeyTrigger = button.GetComponent<UIButtonKeyTrigger>();
					if (uibuttonKeyTrigger == null)
					{
						uibuttonKeyTrigger = button.gameObject.AddComponent<UIButtonKeyTrigger>();
					}
					uibuttonKeyTrigger.key = KeyCode.Alpha1 + buttonNumber;
				}
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000482C File Offset: 0x00002A2C
		private int GetNextAvailableResponseButtonPosition(int start, int direction)
		{
			if (this.buttons != null)
			{
				int num = start;
				while (0 <= num && num < this.buttons.Length)
				{
					if (!this.buttons[num].visible || this.buttons[num].response == null)
					{
						return num;
					}
					num += direction;
				}
			}
			return 5;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000487C File Offset: 0x00002A7C
		private void SetupTemplateButtonNavigation()
		{
			for (int i = 0; i < this.instantiatedButtons.Count; i++)
			{
				Selectable button = this.instantiatedButtons[i].GetComponent<UnityUIResponseButton>().button;
				Button button2 = ((i == 0) ? null : this.instantiatedButtons[i - 1].GetComponent<UnityUIResponseButton>().button);
				Button button3 = ((i == this.instantiatedButtons.Count - 1) ? null : this.instantiatedButtons[i + 1].GetComponent<UnityUIResponseButton>().button);
				button.navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit,
					selectOnUp = button2,
					selectOnLeft = button2,
					selectOnDown = button3,
					selectOnRight = button3
				};
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000493C File Offset: 0x00002B3C
		public void DestroyInstantiatedButtons()
		{
			foreach (GameObject gameObject in this.instantiatedButtons)
			{
				Object.Destroy(gameObject);
			}
			this.instantiatedButtons.Clear();
			this.NotifyContentChanged();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000049A0 File Offset: 0x00002BA0
		public void NotifyContentChanged()
		{
			this.onContentChanged.Invoke();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000049B0 File Offset: 0x00002BB0
		public override void StartTimer(float timeout)
		{
			if (this.timer != null)
			{
				if (this.unityUITimer == null)
				{
					Tools.SetGameObjectActive(this.timer, true);
					this.unityUITimer = this.timer.GetComponent<UnityUITimer>();
					if (this.unityUITimer == null)
					{
						this.unityUITimer = this.timer.gameObject.AddComponent<UnityUITimer>();
					}
					Tools.SetGameObjectActive(this.timer, false);
				}
				if (this.unityUITimer != null)
				{
					Tools.SetGameObjectActive(this.timer, true);
					this.unityUITimer.StartCountdown(timeout, new Action(this.OnTimeout));
					return;
				}
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: No UnityUITimer component found on timer", "Dialogue System"));
				}
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004A78 File Offset: 0x00002C78
		public virtual void OnTimeout()
		{
			if (this.TimeoutHandler != null)
			{
				this.TimeoutHandler();
				return;
			}
			this.DefaultTimeoutHandler();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004A94 File Offset: 0x00002C94
		public void DefaultTimeoutHandler()
		{
			if (this.selectCurrentOnTimeout)
			{
				EventSystem current = EventSystem.current;
				UnityUIResponseButton unityUIResponseButton = ((current != null) ? current.currentSelectedGameObject.GetComponent<UnityUIResponseButton>() : null);
				if (unityUIResponseButton != null)
				{
					unityUIResponseButton.OnClick();
					return;
				}
			}
			DialogueManager.Instance.SendMessage("OnConversationTimeout");
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004AE0 File Offset: 0x00002CE0
		public void AutoFocus(GameObject lastSelection = null, bool allowStealFocus = true)
		{
			if (EventSystem.current == null)
			{
				return;
			}
			GameObject currentSelection = EventSystem.current.currentSelectedGameObject;
			if (currentSelection == null)
			{
				currentSelection = lastSelection;
				EventSystem.current.SetSelectedGameObject(lastSelection);
			}
			if (currentSelection != null && !allowStealFocus)
			{
				return;
			}
			if (this.instantiatedButtons.Find((GameObject x) => x.gameObject == currentSelection) != null)
			{
				return;
			}
			for (int i = 0; i < this.buttons.Length; i++)
			{
				if (this.buttons[i] != null && this.buttons[i].gameObject == currentSelection)
				{
					return;
				}
			}
			if (this.instantiatedButtons.Count > 0)
			{
				UITools.Select(this.instantiatedButtons[0].GetComponent<Button>(), allowStealFocus);
				return;
			}
			for (int j = 0; j < this.buttons.Length; j++)
			{
				if (this.buttons[j] != null && this.buttons[j].clickable)
				{
					UITools.Select(this.buttons[j].button, allowStealFocus);
					return;
				}
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004C0D File Offset: 0x00002E0D
		private bool CanTriggerAnimation(string triggerName)
		{
			return this.CanTriggerAnimations() && !string.IsNullOrEmpty(triggerName);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004C24 File Offset: 0x00002E24
		private bool CanTriggerAnimations()
		{
			if (this.animator == null && !this.lookedForAnimator)
			{
				this.lookedForAnimator = true;
				if (this.panel != null)
				{
					this.animator = this.panel.GetComponentInParent<Animator>();
				}
			}
			return this.animator != null && this.animationTransitions != null;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004C86 File Offset: 0x00002E86
		private IEnumerator DisableAfterAnimation(Graphic panel)
		{
			this.isHiding = true;
			if (this.animator != null)
			{
				float maxWaitDuration = UIShowHideController.maxWaitDuration;
				float timeout = Time.realtimeSinceStartup + maxWaitDuration;
				int oldHashId = UITools.GetAnimatorNameHash(this.animator.GetCurrentAnimatorStateInfo(0));
				while (UITools.GetAnimatorNameHash(this.animator.GetCurrentAnimatorStateInfo(0)) == oldHashId && Time.realtimeSinceStartup < timeout)
				{
					yield return null;
				}
				yield return DialogueManager.Instance.StartCoroutine(DialogueTime.WaitForSeconds(this.animator.GetCurrentAnimatorStateInfo(0).length));
			}
			this.isHiding = false;
			if (panel != null)
			{
				Tools.SetGameObjectActive(panel, false);
			}
			yield break;
		}

		// Token: 0x04000067 RID: 103
		[Tooltip("The panel containing the response menu controls. A panel is optional, but you may want one so you can include a background image, panel-wide effects, etc.")]
		public Graphic panel;

		// Token: 0x04000068 RID: 104
		[Tooltip("The PC portrait image to show during the response menu.")]
		public Image pcImage;

		// Token: 0x04000069 RID: 105
		[Tooltip("The label that will show the PC name.")]
		public Text pcName;

		// Token: 0x0400006A RID: 106
		[Tooltip("The reminder of the last subtitle.")]
		public UnityUISubtitleControls subtitleReminder;

		// Token: 0x0400006B RID: 107
		[Tooltip("The (optional) timer.")]
		public Slider timer;

		// Token: 0x0400006C RID: 108
		[Tooltip("Select the currently-focused response on timeout.")]
		public bool selectCurrentOnTimeout;

		// Token: 0x0400006D RID: 109
		[Tooltip("Design-time positioned response buttons")]
		public UnityUIResponseButton[] buttons;

		// Token: 0x0400006E RID: 110
		[Tooltip("Template from which to instantiate response buttons; optional to use instead of positioned buttons above")]
		public UnityUIResponseButton buttonTemplate;

		// Token: 0x0400006F RID: 111
		[Tooltip("If using Button Template, instantiated buttons are parented under this GameObject")]
		public Graphic buttonTemplateHolder;

		// Token: 0x04000070 RID: 112
		[Tooltip("Optional scrollbar if the instantiated button holder is in a scroll rect")]
		public Scrollbar buttonTemplateScrollbar;

		// Token: 0x04000071 RID: 113
		[Tooltip("Reset the scroll bar to this value when preparing the response menu")]
		public float buttonTemplateScrollbarResetValue = 1f;

		// Token: 0x04000072 RID: 114
		[Tooltip("Automatically set up explicit navigation for instantiated template buttons instead of using Automatic navigation")]
		public bool explicitNavigationForTemplateButtons = true;

		// Token: 0x04000073 RID: 115
		public UnityUIResponseMenuControls.AutonumberSettings autonumber = new UnityUIResponseMenuControls.AutonumberSettings();

		// Token: 0x04000074 RID: 116
		public UnityUIResponseMenuControls.AnimationTransitions animationTransitions = new UnityUIResponseMenuControls.AnimationTransitions();

		// Token: 0x04000075 RID: 117
		public UnityEvent onContentChanged = new UnityEvent();

		// Token: 0x04000076 RID: 118
		[HideInInspector]
		public List<GameObject> instantiatedButtons = new List<GameObject>();

		// Token: 0x04000077 RID: 119
		public Action TimeoutHandler;

		// Token: 0x04000078 RID: 120
		private UnityUITimer unityUITimer;

		// Token: 0x04000079 RID: 121
		private Texture2D pcPortraitTexture;

		// Token: 0x0400007A RID: 122
		private string pcPortraitName;

		// Token: 0x0400007B RID: 123
		private Animator animator;

		// Token: 0x0400007C RID: 124
		private bool lookedForAnimator;

		// Token: 0x0400007D RID: 125
		private bool isVisible;

		// Token: 0x0400007E RID: 126
		private bool isHiding;

		// Token: 0x02000061 RID: 97
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x0400022B RID: 555
			[Tooltip("To show the response menu panel, play this state/trigger.")]
			public string showTrigger = string.Empty;

			// Token: 0x0400022C RID: 556
			[Tooltip("To hide the response menu panel, play this state/trigger.")]
			public string hideTrigger = string.Empty;

			// Token: 0x0400022D RID: 557
			[Tooltip("Specifies whether Show Trigger and Hide Trigger are animator states or trigger parameters.")]
			public UIShowHideController.TransitionMode transitionMode;
		}

		// Token: 0x02000062 RID: 98
		[Serializable]
		public class AutonumberSettings
		{
			// Token: 0x0400022E RID: 558
			[Tooltip("Enable autonumbering of responses.")]
			public bool enabled;

			// Token: 0x0400022F RID: 559
			[Tooltip("Format for response button text, where {0} is the number and {1} is the menu text.")]
			public string format = "{0}. {1}";
		}
	}
}
