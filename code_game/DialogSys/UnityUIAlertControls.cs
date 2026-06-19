using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000019 RID: 25
	[Serializable]
	public class UnityUIAlertControls : AbstractUIAlertControls
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003430 File Offset: 0x00001630
		public override bool IsVisible
		{
			get
			{
				return this.isVisible;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00003438 File Offset: 0x00001638
		public bool IsHiding
		{
			get
			{
				return this.isHiding;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003440 File Offset: 0x00001640
		public override void SetActive(bool value)
		{
			try
			{
				if (value)
				{
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

		// Token: 0x06000062 RID: 98 RVA: 0x00003478 File Offset: 0x00001678
		private void ShowPanel()
		{
			this.ShowControls();
			this.CheckShowHideController();
			this.showHideController.ClearTrigger(this.animationTransitions.hideTrigger);
			this.showHideController.Show(this.animationTransitions.showTrigger, false, null, true);
			this.isVisible = true;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000034C8 File Offset: 0x000016C8
		private void HidePanel()
		{
			this.CheckShowHideController();
			this.showHideController.ClearTrigger(this.animationTransitions.showTrigger);
			if (this.isVisible)
			{
				this.isHiding = true;
				this.showHideController.Hide(this.animationTransitions.hideTrigger, new Action(this.HideControls));
				return;
			}
			this.HideControls();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003529 File Offset: 0x00001729
		private void CheckShowHideController()
		{
			if (this.showHideController == null)
			{
				this.showHideController = new UIShowHideController(null, this.panel, this.animationTransitions.transitionMode);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003550 File Offset: 0x00001750
		private void ShowControls()
		{
			Tools.SetGameObjectActive(this.panel, true);
			Tools.SetGameObjectActive(this.line, true);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000356A File Offset: 0x0000176A
		private void HideControls()
		{
			this.isHiding = false;
			Tools.SetGameObjectActive(this.panel, false);
			Tools.SetGameObjectActive(this.line, false);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000358B File Offset: 0x0000178B
		public override void SetMessage(string message, float duration)
		{
			if (this.line != null)
			{
				this.line.text = FormattedText.Parse(message, DialogueManager.MasterDatabase.emphasisSettings).text;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000035BB File Offset: 0x000017BB
		public void AutoFocus(bool allowStealFocus = true)
		{
			UITools.Select(this.continueButton, allowStealFocus);
		}

		// Token: 0x04000039 RID: 57
		[Tooltip("Optional panel containing the alert line; can contain other doodads and effects, too")]
		public Graphic panel;

		// Token: 0x0400003A RID: 58
		[Tooltip("Shows the alert message text")]
		public Text line;

		// Token: 0x0400003B RID: 59
		[Tooltip("Optional continue button; configure OnClick to invoke dialogue UI's OnContinue method")]
		public Button continueButton;

		// Token: 0x0400003C RID: 60
		[Tooltip("Wait for previous alerts to finish before showing new alert; if unticked, new alerts replace old")]
		public bool queueAlerts;

		// Token: 0x0400003D RID: 61
		[Tooltip("Wait for the previous alert's Hide animation to finish before showing the next queued alert")]
		public bool waitForHideAnimation;

		// Token: 0x0400003E RID: 62
		[Tooltip("Optional animation transitions; panel should have an Animator")]
		public UnityUIAlertControls.AnimationTransitions animationTransitions = new UnityUIAlertControls.AnimationTransitions();

		// Token: 0x0400003F RID: 63
		private bool isVisible;

		// Token: 0x04000040 RID: 64
		private bool isHiding;

		// Token: 0x04000041 RID: 65
		private UIShowHideController showHideController;

		// Token: 0x0200005E RID: 94
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x04000223 RID: 547
			[Tooltip("To show the alert panel, play this state/trigger.")]
			public string showTrigger = "Show";

			// Token: 0x04000224 RID: 548
			[Tooltip("To hide the alert panel, play this state/trigger.")]
			public string hideTrigger = "Hide";

			// Token: 0x04000225 RID: 549
			[Tooltip("Specifies whether Show Trigger and Hide Trigger are animator states or trigger parameters.")]
			public UIShowHideController.TransitionMode transitionMode;
		}
	}
}
