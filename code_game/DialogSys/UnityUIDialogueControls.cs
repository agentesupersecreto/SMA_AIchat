using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class UnityUIDialogueControls : AbstractDialogueUIControls
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003634 File Offset: 0x00001834
		public override AbstractUISubtitleControls NPCSubtitle
		{
			get
			{
				return this.npcSubtitle;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000363C File Offset: 0x0000183C
		public override AbstractUISubtitleControls PCSubtitle
		{
			get
			{
				return this.pcSubtitle;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003644 File Offset: 0x00001844
		public override AbstractUIResponseMenuControls ResponseMenu
		{
			get
			{
				return this.responseMenu;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000364C File Offset: 0x0000184C
		public override void SetActive(bool value)
		{
			try
			{
				if (value)
				{
					base.SetActive(true);
					this.ShowPanel();
				}
				else
				{
					this.HidePanel();
				}
			}
			finally
			{
				this.isVisible = value;
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000368C File Offset: 0x0000188C
		public override void ShowPanel()
		{
			this.ShowControls();
			if (!this.isVisible)
			{
				this.isVisible = true;
				this.CheckShowHideController();
				this.showHideController.ClearTrigger(this.animationTransitions.hideTrigger);
				this.showHideController.Show(this.animationTransitions.showTrigger, false, null, true);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000036E4 File Offset: 0x000018E4
		private void HidePanel()
		{
			if (this.isVisible)
			{
				this.CheckShowHideController();
				this.showHideController.ClearTrigger(this.animationTransitions.showTrigger);
				this.showHideController.Hide(this.animationTransitions.hideTrigger, new Action(this.HideControls));
				return;
			}
			this.HideControls();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000373E File Offset: 0x0000193E
		private void CheckShowHideController()
		{
			if (this.showHideController == null)
			{
				this.showHideController = new UIShowHideController(null, this.panel, this.animationTransitions.transitionMode);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003765 File Offset: 0x00001965
		private void ShowControls()
		{
			if (this.panel != null)
			{
				Tools.SetGameObjectActive(this.panel, true);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003781 File Offset: 0x00001981
		private void HideControls()
		{
			if (this.panel != null)
			{
				Tools.SetGameObjectActive(this.panel, false);
			}
			base.SetActive(false);
			this.isVisible = false;
		}

		// Token: 0x04000042 RID: 66
		[Tooltip("Panel containing the entire conversation UI")]
		public Graphic panel;

		// Token: 0x04000043 RID: 67
		public UnityUISubtitleControls npcSubtitle;

		// Token: 0x04000044 RID: 68
		public UnityUISubtitleControls pcSubtitle;

		// Token: 0x04000045 RID: 69
		public UnityUIResponseMenuControls responseMenu;

		// Token: 0x04000046 RID: 70
		[Tooltip("Optional animation transitions; panel should have an Animator")]
		public UnityUIDialogueControls.AnimationTransitions animationTransitions = new UnityUIDialogueControls.AnimationTransitions();

		// Token: 0x04000047 RID: 71
		private bool isVisible;

		// Token: 0x04000048 RID: 72
		private UIShowHideController showHideController;

		// Token: 0x0200005F RID: 95
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x04000226 RID: 550
			[Tooltip("To show the dialogue panel, play this state/trigger.")]
			public string showTrigger = "Show";

			// Token: 0x04000227 RID: 551
			[Tooltip("To hide the dialogue panel, play this state/trigger.")]
			public string hideTrigger = "Hide";

			// Token: 0x04000228 RID: 552
			[Tooltip("Specifies whether Show Trigger and Hide Trigger are animator states or trigger parameters.")]
			public UIShowHideController.TransitionMode transitionMode;
		}
	}
}
