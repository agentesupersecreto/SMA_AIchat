using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000032 RID: 50
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_selector_display.html")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Selection/Unity UI Selector Display")]
	public class UnityUISelectorDisplay : MonoBehaviour
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00007F69 File Offset: 0x00006169
		protected float CurrentDistance
		{
			get
			{
				if (!(this.selector != null))
				{
					return 0f;
				}
				return this.selector.CurrentDistance;
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007F8A File Offset: 0x0000618A
		public void Start()
		{
			this.started = true;
			this.FindUIElements();
			this.ConnectDelegates();
			this.DeactivateControls();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00007FA8 File Offset: 0x000061A8
		public void FindUIElements()
		{
			UnityUISelectorElements unityUISelectorElements = UnityUISelectorElements.instance;
			if (unityUISelectorElements == null)
			{
				unityUISelectorElements = this.SearchForElements(DialogueManager.Instance.transform);
			}
			if (unityUISelectorElements != null)
			{
				UnityUISelectorElements.instance = unityUISelectorElements;
			}
			if (this.mainGraphic == null && this.nameText == null && this.reticleInRange == null)
			{
				if (unityUISelectorElements == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning("Dialogue System: UnityUISelectorDisplay can't find UI elements", this);
					}
				}
				else
				{
					if (this.mainGraphic == null)
					{
						this.mainGraphic = unityUISelectorElements.mainGraphic;
					}
					if (this.nameText == null)
					{
						this.nameText = unityUISelectorElements.nameText;
					}
					if (this.useMessageText == null)
					{
						this.useMessageText = unityUISelectorElements.useMessageText;
					}
					this.inRangeColor = unityUISelectorElements.inRangeColor;
					this.outOfRangeColor = unityUISelectorElements.outOfRangeColor;
					if (this.reticleInRange == null)
					{
						this.reticleInRange = unityUISelectorElements.reticleInRange;
					}
					if (this.reticleOutOfRange == null)
					{
						this.reticleOutOfRange = unityUISelectorElements.reticleOutOfRange;
					}
					this.animationTransitions = unityUISelectorElements.animationTransitions;
				}
			}
			if (this.mainGraphic != null)
			{
				this.animator = base.GetComponentInChildren<Animator>();
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000080FC File Offset: 0x000062FC
		private UnityUISelectorElements SearchForElements(Transform t)
		{
			if (t == null)
			{
				return null;
			}
			UnityUISelectorElements unityUISelectorElements = t.GetComponent<UnityUISelectorElements>();
			if (unityUISelectorElements != null)
			{
				return unityUISelectorElements;
			}
			foreach (object obj in t)
			{
				Transform transform = (Transform)obj;
				unityUISelectorElements = this.SearchForElements(transform);
				if (unityUISelectorElements != null)
				{
					return unityUISelectorElements;
				}
			}
			return null;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00008184 File Offset: 0x00006384
		public void OnEnable()
		{
			if (this.started)
			{
				this.ConnectDelegates();
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00008194 File Offset: 0x00006394
		public void OnDisable()
		{
			this.DisconnectDelegates();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000819C File Offset: 0x0000639C
		private void ConnectDelegates()
		{
			this.DisconnectDelegates();
			this.selector = base.GetComponent<Selector>();
			if (this.selector != null)
			{
				this.selector.useDefaultGUI = false;
				this.selector.SelectedUsableObject += this.OnSelectedUsable;
				this.selector.DeselectedUsableObject += this.OnDeselectedUsable;
				this.defaultUseMessage = this.selector.defaultUseMessage;
			}
			this.proximitySelector = base.GetComponent<ProximitySelector>();
			if (this.proximitySelector != null)
			{
				this.proximitySelector.useDefaultGUI = false;
				this.proximitySelector.SelectedUsableObject += this.OnSelectedUsable;
				this.proximitySelector.DeselectedUsableObject += this.OnDeselectedUsable;
				if (string.IsNullOrEmpty(this.defaultUseMessage))
				{
					this.defaultUseMessage = this.proximitySelector.defaultUseMessage;
				}
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00008288 File Offset: 0x00006488
		private void DisconnectDelegates()
		{
			this.selector = base.GetComponent<Selector>();
			if (this.selector != null)
			{
				this.selector.useDefaultGUI = true;
				this.selector.SelectedUsableObject -= this.OnSelectedUsable;
				this.selector.DeselectedUsableObject -= this.OnDeselectedUsable;
			}
			this.proximitySelector = base.GetComponent<ProximitySelector>();
			if (this.proximitySelector != null)
			{
				this.proximitySelector.useDefaultGUI = true;
				this.proximitySelector.SelectedUsableObject -= this.OnSelectedUsable;
				this.proximitySelector.DeselectedUsableObject -= this.OnDeselectedUsable;
			}
			this.HideControls();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00008344 File Offset: 0x00006544
		private void OnSelectedUsable(Usable usable)
		{
			this.usable = usable;
			this.usableUnityUI = ((usable != null) ? usable.GetComponentInChildren<UsableUnityUI>() : null);
			if (this.usableUnityUI != null)
			{
				this.usableUnityUI.Show(this.GetUseMessage());
			}
			else
			{
				this.ShowControls();
			}
			this.lastInRange = !this.IsUsableInRange();
			this.UpdateDisplay(!this.lastInRange);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000083B5 File Offset: 0x000065B5
		private void OnDeselectedUsable(Usable usable)
		{
			if (this.usableUnityUI != null)
			{
				this.usableUnityUI.Hide();
				this.usableUnityUI = null;
			}
			else
			{
				this.HideControls();
			}
			this.usable = null;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000083E6 File Offset: 0x000065E6
		private string GetUseMessage()
		{
			if (!string.IsNullOrEmpty(this.usable.overrideUseMessage))
			{
				return this.usable.overrideUseMessage;
			}
			return this.defaultUseMessage;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000840C File Offset: 0x0000660C
		private void ShowControls()
		{
			if (this.usable == null)
			{
				return;
			}
			Tools.SetGameObjectActive(this.mainGraphic, true);
			Tools.SetGameObjectActive(this.nameText, true);
			Tools.SetGameObjectActive(this.useMessageText, true);
			if (this.nameText != null)
			{
				this.nameText.text = this.usable.GetName();
			}
			if (this.useMessageText != null)
			{
				this.useMessageText.text = this.GetUseMessage();
			}
			if (this.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.showTrigger))
			{
				this.animator.SetTrigger(this.animationTransitions.showTrigger);
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000084BF File Offset: 0x000066BF
		private void HideControls()
		{
			if (this.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.hideTrigger))
			{
				this.animator.SetTrigger(this.animationTransitions.hideTrigger);
				return;
			}
			this.DeactivateControls();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000084F8 File Offset: 0x000066F8
		private void DeactivateControls()
		{
			Tools.SetGameObjectActive(this.nameText, false);
			Tools.SetGameObjectActive(this.useMessageText, false);
			Tools.SetGameObjectActive(this.reticleInRange, false);
			Tools.SetGameObjectActive(this.reticleOutOfRange, false);
			Tools.SetGameObjectActive(this.mainGraphic, false);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00008536 File Offset: 0x00006736
		private bool IsUsableInRange()
		{
			return this.usable != null && this.CurrentDistance <= this.usable.maxUseDistance;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000855E File Offset: 0x0000675E
		public void Update()
		{
			if (this.usable != null)
			{
				this.UpdateDisplay(this.IsUsableInRange());
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000857A File Offset: 0x0000677A
		public void OnConversationStart(Transform actor)
		{
			this.HideControls();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00008582 File Offset: 0x00006782
		public void OnConversationEnd(Transform actor)
		{
			this.ShowControls();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000858C File Offset: 0x0000678C
		private void UpdateDisplay(bool inRange)
		{
			if (this.usable != null && inRange != this.lastInRange)
			{
				this.lastInRange = inRange;
				if (this.usableUnityUI != null)
				{
					this.usableUnityUI.UpdateDisplay(inRange);
					return;
				}
				this.UpdateText(inRange);
				this.UpdateReticle(inRange);
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000085E0 File Offset: 0x000067E0
		private void UpdateText(bool inRange)
		{
			Color color = (inRange ? this.inRangeColor : this.outOfRangeColor);
			if (this.nameText != null)
			{
				this.nameText.color = color;
			}
			if (this.useMessageText != null)
			{
				this.useMessageText.color = color;
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00008633 File Offset: 0x00006833
		private void UpdateReticle(bool inRange)
		{
			Tools.SetGameObjectActive(this.reticleInRange, inRange);
			Tools.SetGameObjectActive(this.reticleOutOfRange, !inRange);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00008650 File Offset: 0x00006850
		private bool CanTriggerAnimations()
		{
			return this.animator != null && this.animationTransitions != null;
		}

		// Token: 0x0400010C RID: 268
		public Graphic mainGraphic;

		// Token: 0x0400010D RID: 269
		public Text nameText;

		// Token: 0x0400010E RID: 270
		public Text useMessageText;

		// Token: 0x0400010F RID: 271
		public Color inRangeColor = Color.yellow;

		// Token: 0x04000110 RID: 272
		public Color outOfRangeColor = Color.gray;

		// Token: 0x04000111 RID: 273
		public Graphic reticleInRange;

		// Token: 0x04000112 RID: 274
		public Graphic reticleOutOfRange;

		// Token: 0x04000113 RID: 275
		public UnityUISelectorDisplay.AnimationTransitions animationTransitions = new UnityUISelectorDisplay.AnimationTransitions();

		// Token: 0x04000114 RID: 276
		private Selector selector;

		// Token: 0x04000115 RID: 277
		private ProximitySelector proximitySelector;

		// Token: 0x04000116 RID: 278
		private string defaultUseMessage = string.Empty;

		// Token: 0x04000117 RID: 279
		private Usable usable;

		// Token: 0x04000118 RID: 280
		private bool lastInRange;

		// Token: 0x04000119 RID: 281
		private UsableUnityUI usableUnityUI;

		// Token: 0x0400011A RID: 282
		private Animator animator;

		// Token: 0x0400011B RID: 283
		private bool started;

		// Token: 0x02000074 RID: 116
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x0400027B RID: 635
			public string showTrigger = "Show";

			// Token: 0x0400027C RID: 636
			public string hideTrigger = "Hide";
		}
	}
}
