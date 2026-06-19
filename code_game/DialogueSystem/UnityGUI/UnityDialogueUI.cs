using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D3 RID: 723
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Dialogue/Unity Dialogue UI (Legacy Unity GUI)")]
	public class UnityDialogueUI : AbstractDialogueUI
	{
		// Token: 0x17000A93 RID: 2707
		// (get) Token: 0x06001DAA RID: 7594 RVA: 0x0003A4A0 File Offset: 0x000386A0
		public override AbstractUIRoot UIRoot
		{
			get
			{
				return this.unityUIRoot;
			}
		}

		// Token: 0x17000A94 RID: 2708
		// (get) Token: 0x06001DAB RID: 7595 RVA: 0x0003A4A8 File Offset: 0x000386A8
		public override AbstractDialogueUIControls Dialogue
		{
			get
			{
				return this.dialogue;
			}
		}

		// Token: 0x17000A95 RID: 2709
		// (get) Token: 0x06001DAC RID: 7596 RVA: 0x0003A4B0 File Offset: 0x000386B0
		public override AbstractUIQTEControls QTEs
		{
			get
			{
				return this.unityQTEControls;
			}
		}

		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x06001DAD RID: 7597 RVA: 0x0003A4B8 File Offset: 0x000386B8
		public override AbstractUIAlertControls Alert
		{
			get
			{
				return this.alert;
			}
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x0003A4C0 File Offset: 0x000386C0
		public override void Awake()
		{
			base.Awake();
			this.FindControls();
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x0003A4D0 File Offset: 0x000386D0
		private void FindControls()
		{
			if (this.guiRoot == null)
			{
				this.guiRoot = base.GetComponentInChildren<GUIRoot>();
			}
			this.unityUIRoot = new UnityUIRoot(this.guiRoot);
			this.unityQTEControls = new UnityQTEControls(this.qteIndicators);
			this.SetupContinueButton(this.dialogue.npcSubtitle.continueButton);
			this.SetupContinueButton(this.dialogue.pcSubtitle.continueButton);
			this.SetupContinueButton(this.alert.continueButton);
			if (DialogueDebug.LogErrors)
			{
				if (this.guiRoot == null)
				{
					Debug.LogError(string.Format("{0}: UnityDialogueUI can't find GUIRoot and won't be able to display dialogue.", new object[] { "Dialogue System" }));
				}
				if (DialogueDebug.LogWarnings)
				{
					if (this.dialogue.npcSubtitle.line == null)
					{
						Debug.LogWarning(string.Format("{0}: UnityDialogueUI NPC Subtitle Line needs to be assigned.", new object[] { "Dialogue System" }));
					}
					if (this.dialogue.pcSubtitle.line == null)
					{
						Debug.LogWarning(string.Format("{0}: UnityDialogueUI PC Subtitle Line needs to be assigned.", new object[] { "Dialogue System" }));
					}
					if (this.dialogue.responseMenu.buttons.Length == 0)
					{
						Debug.LogWarning(string.Format("{0}: UnityDialogueUI Response buttons need to be assigned.", new object[] { "Dialogue System" }));
					}
					if (this.alert.line == null)
					{
						Debug.LogWarning(string.Format("{0}: UnityDialogueUI Alert Line needs to be assigned.", new object[] { "Dialogue System" }));
					}
				}
			}
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x0003A674 File Offset: 0x00038874
		private void SetupContinueButton(GUIButton continueButton)
		{
			if (continueButton != null)
			{
				if (string.IsNullOrEmpty(continueButton.message) || string.Equals(continueButton.message, "OnClick"))
				{
					continueButton.message = "OnContinue";
				}
				if (continueButton.target == null)
				{
					continueButton.target = base.transform;
				}
			}
		}

		// Token: 0x04001139 RID: 4409
		public GUIRoot guiRoot;

		// Token: 0x0400113A RID: 4410
		public UnityDialogueControls dialogue;

		// Token: 0x0400113B RID: 4411
		public GUIControl[] qteIndicators;

		// Token: 0x0400113C RID: 4412
		public UnityAlertControls alert;

		// Token: 0x0400113D RID: 4413
		private UnityUIRoot unityUIRoot;

		// Token: 0x0400113E RID: 4414
		private UnityQTEControls unityQTEControls;
	}
}
