using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001C RID: 28
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Unity UI Dialogue UI")]
	public class UnityUIDialogueUI : AbstractDialogueUI
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000037BE File Offset: 0x000019BE
		public override AbstractUIRoot UIRoot
		{
			get
			{
				return this.unityUIRoot;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000077 RID: 119 RVA: 0x000037C6 File Offset: 0x000019C6
		public override AbstractDialogueUIControls Dialogue
		{
			get
			{
				return this.dialogue;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000037CE File Offset: 0x000019CE
		public override AbstractUIQTEControls QTEs
		{
			get
			{
				return this.qteControls;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000079 RID: 121 RVA: 0x000037D6 File Offset: 0x000019D6
		public override AbstractUIAlertControls Alert
		{
			get
			{
				return this.alert;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000037DE File Offset: 0x000019DE
		public override void Awake()
		{
			base.Awake();
			this.FindControls();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000037EC File Offset: 0x000019EC
		public virtual void OnEnable()
		{
			SceneManager.sceneLoaded -= this.OnSceneLoaded;
			SceneManager.sceneLoaded += this.OnSceneLoaded;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003810 File Offset: 0x00001A10
		public virtual void OnDisable()
		{
			SceneManager.sceneLoaded -= this.OnSceneLoaded;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003824 File Offset: 0x00001A24
		private void FindControls()
		{
			if (this.addEventSystemIfNeeded)
			{
				UITools.RequireEventSystem();
			}
			this.qteControls = new UnityUIQTEControls(this.qteIndicators);
			if (DialogueDebug.LogErrors && DialogueDebug.LogWarnings)
			{
				if (this.dialogue.npcSubtitle.line == null)
				{
					Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI NPC Subtitle Line needs to be assigned.", "Dialogue System"));
				}
				if (this.dialogue.pcSubtitle.line == null)
				{
					Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI PC Subtitle Line needs to be assigned.", "Dialogue System"));
				}
				if (this.dialogue.responseMenu.buttons.Length == 0 && this.dialogue.responseMenu.buttonTemplate == null)
				{
					Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI Response buttons need to be assigned.", "Dialogue System"));
				}
				if (this.alert.line == null)
				{
					Debug.LogWarning(string.Format("{0}: UnityUIDialogueUI Alert Line needs to be assigned.", "Dialogue System"));
				}
			}
			this.originalNPCSubtitle = this.dialogue.npcSubtitle;
			this.originalPCSubtitle = this.dialogue.pcSubtitle;
			this.originalResponseMenu = this.dialogue.responseMenu;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003954 File Offset: 0x00001B54
		protected OverrideUnityUIDialogueControls FindActorOverride(Transform actor)
		{
			if (actor == null)
			{
				return null;
			}
			if (!this.overrideCache.ContainsKey(actor))
			{
				this.overrideCache.Add(actor, (actor != null) ? actor.GetComponentInChildren<OverrideUnityUIDialogueControls>() : null);
			}
			return this.overrideCache[actor];
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000039A4 File Offset: 0x00001BA4
		public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			UITools.RequireEventSystem();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000039AB File Offset: 0x00001BAB
		public override void Open()
		{
			this.overrideCache.Clear();
			base.Open();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000039BE File Offset: 0x00001BBE
		public override void ShowAlert(string message, float duration)
		{
			if (this.alert.queueAlerts)
			{
				this.alertQueue.Enqueue(new UnityUIDialogueUI.QueuedAlert(message, duration));
				if (!this.alert.IsVisible)
				{
					this.ShowNextQueuedAlert();
					return;
				}
			}
			else
			{
				this.StartShowingAlert(message, duration);
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000039FB File Offset: 0x00001BFB
		public override void HideAlert()
		{
			base.HideAlert();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003A03 File Offset: 0x00001C03
		public override void OnContinue()
		{
			base.CancelInvoke("HideAlert");
			base.OnContinue();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003A18 File Offset: 0x00001C18
		private void ShowNextQueuedAlert()
		{
			if (this.alertQueue.Count > 0)
			{
				UnityUIDialogueUI.QueuedAlert queuedAlert = this.alertQueue.Dequeue();
				this.StartShowingAlert(queuedAlert.message, queuedAlert.duration);
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003A51 File Offset: 0x00001C51
		private void StartShowingAlert(string message, float duration)
		{
			base.ShowAlert(message, duration);
			if (this.autoFocus)
			{
				this.alert.AutoFocus(true);
			}
			base.CancelInvoke("HideAlert");
			base.Invoke("HideAlert", duration);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003A88 File Offset: 0x00001C88
		public override void ShowSubtitle(Subtitle subtitle)
		{
			this.SetIsShowingSubtitle(subtitle, true);
			if (this.findActorOverrides && subtitle != null)
			{
				OverrideUnityUIDialogueControls overrideUnityUIDialogueControls = ((subtitle.speakerInfo != null) ? this.FindActorOverride(subtitle.speakerInfo.transform) : null);
				if (overrideUnityUIDialogueControls != null)
				{
					overrideUnityUIDialogueControls.ApplyToDialogueUI(this);
				}
				if (subtitle.speakerInfo == null || subtitle.speakerInfo.characterType == CharacterType.NPC)
				{
					this.dialogue.npcSubtitle = ((overrideUnityUIDialogueControls != null) ? overrideUnityUIDialogueControls.subtitle : this.originalNPCSubtitle);
				}
				else
				{
					this.dialogue.pcSubtitle = ((overrideUnityUIDialogueControls != null) ? overrideUnityUIDialogueControls.subtitle : this.originalPCSubtitle);
				}
			}
			this.HideResponses();
			base.ShowSubtitle(subtitle);
			this.ClearSelection();
			this.CheckSubtitleAutoFocus(subtitle);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003B54 File Offset: 0x00001D54
		public void CheckSubtitleAutoFocus(Subtitle subtitle)
		{
			if (this.autoFocus)
			{
				if (subtitle.speakerInfo.IsPlayer)
				{
					this.dialogue.pcSubtitle.AutoFocus(this.allowStealFocus);
					return;
				}
				this.dialogue.npcSubtitle.AutoFocus(this.allowStealFocus);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003BA3 File Offset: 0x00001DA3
		protected void SetIsShowingSubtitle(Subtitle subtitle, bool value)
		{
			if (subtitle == null)
			{
				return;
			}
			if (subtitle.speakerInfo.IsNPC)
			{
				this.isShowingNpcSubtitle = value;
				return;
			}
			this.isShowingPcSubtitle = value;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003BC5 File Offset: 0x00001DC5
		public override void HideSubtitle(Subtitle subtitle)
		{
			this.SetIsShowingSubtitle(subtitle, false);
			base.HideSubtitle(subtitle);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003BD8 File Offset: 0x00001DD8
		public override void ShowResponses(Subtitle subtitle, Response[] responses, float timeout)
		{
			this.isShowingResponses = true;
			if (this.findActorOverrides)
			{
				OverrideUnityUIDialogueControls overrideUnityUIDialogueControls = ((subtitle != null && subtitle.speakerInfo != null) ? this.FindActorOverride(subtitle.speakerInfo.transform) : null);
				UnityUISubtitleControls unityUISubtitleControls = ((overrideUnityUIDialogueControls != null) ? overrideUnityUIDialogueControls.subtitleReminder : this.originalResponseMenu.subtitleReminder);
				if (overrideUnityUIDialogueControls != null && overrideUnityUIDialogueControls.responseMenu.panel != null)
				{
					this.dialogue.responseMenu = ((overrideUnityUIDialogueControls != null && overrideUnityUIDialogueControls.responseMenu.panel != null) ? overrideUnityUIDialogueControls.responseMenu : this.originalResponseMenu);
				}
				else
				{
					overrideUnityUIDialogueControls = ((subtitle != null && subtitle.listenerInfo != null) ? this.FindActorOverride(subtitle.listenerInfo.transform) : null);
					this.dialogue.responseMenu = ((overrideUnityUIDialogueControls != null && overrideUnityUIDialogueControls.responseMenu.panel != null) ? overrideUnityUIDialogueControls.responseMenu : this.originalResponseMenu);
				}
				this.dialogue.responseMenu.subtitleReminder = unityUISubtitleControls;
			}
			base.ShowResponses(subtitle, responses, timeout);
			this.ClearSelection();
			this.CheckResponseMenuAutoFocus();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003D02 File Offset: 0x00001F02
		public void CheckResponseMenuAutoFocus()
		{
			if (this.autoFocus)
			{
				this.dialogue.responseMenu.AutoFocus(this.lastSelection, this.allowStealFocus);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003D28 File Offset: 0x00001F28
		public override void HideResponses()
		{
			this.isShowingResponses = false;
			this.dialogue.responseMenu.DestroyInstantiatedButtons();
			base.HideResponses();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003D47 File Offset: 0x00001F47
		public void ClearSelection()
		{
			if (this.autoFocus)
			{
				if (EventSystem.current != null)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				this.lastSelection = null;
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003D70 File Offset: 0x00001F70
		public override void Update()
		{
			base.Update();
			if (this.alertQueue.Count > 0 && this.alert.queueAlerts && !this.alert.IsVisible && (!this.alert.waitForHideAnimation || !this.alert.IsHiding))
			{
				this.ShowNextQueuedAlert();
			}
			if (this.autoFocus && base.IsOpen)
			{
				EventSystem current = EventSystem.current;
				if (((current != null) ? current.currentSelectedGameObject : null) != null)
				{
					this.lastSelection = EventSystem.current.currentSelectedGameObject;
				}
				if (this.autoFocusCheckFrequency > 0.001f && Time.realtimeSinceStartup > this.nextAutoFocusCheckTime)
				{
					this.nextAutoFocusCheckTime = Time.realtimeSinceStartup + this.autoFocusCheckFrequency;
					if (this.isShowingResponses)
					{
						this.dialogue.responseMenu.AutoFocus(this.lastSelection, this.allowStealFocus);
						return;
					}
					if (this.isShowingPcSubtitle)
					{
						this.dialogue.pcSubtitle.AutoFocus(this.allowStealFocus);
						return;
					}
					if (this.isShowingNpcSubtitle)
					{
						this.dialogue.npcSubtitle.AutoFocus(this.allowStealFocus);
					}
				}
			}
		}

		// Token: 0x04000049 RID: 73
		[HideInInspector]
		public UnityUIRoot unityUIRoot;

		// Token: 0x0400004A RID: 74
		public UnityUIDialogueControls dialogue;

		// Token: 0x0400004B RID: 75
		public Graphic[] qteIndicators;

		// Token: 0x0400004C RID: 76
		public UnityUIAlertControls alert;

		// Token: 0x0400004D RID: 77
		[Tooltip("Always keep a control focused; useful for gamepads and keyboard.")]
		public bool autoFocus;

		// Token: 0x0400004E RID: 78
		[Tooltip("Allow the dialogue UI to steal focus if a non-dialogue UI panel has it.")]
		public bool allowStealFocus;

		// Token: 0x0400004F RID: 79
		[Tooltip("If auto focusing, check on this frequency in seconds that the control is focused.")]
		public float autoFocusCheckFrequency = 0.5f;

		// Token: 0x04000050 RID: 80
		[Tooltip("Look for OverrideUnityUIDialogueControls on actors.")]
		public bool findActorOverrides = true;

		// Token: 0x04000051 RID: 81
		[Tooltip("Add an EventSystem if one isn't in the scene.")]
		public bool addEventSystemIfNeeded = true;

		// Token: 0x04000052 RID: 82
		private UnityUIQTEControls qteControls;

		// Token: 0x04000053 RID: 83
		private float nextAutoFocusCheckTime;

		// Token: 0x04000054 RID: 84
		private GameObject lastSelection;

		// Token: 0x04000055 RID: 85
		private Queue<UnityUIDialogueUI.QueuedAlert> alertQueue = new Queue<UnityUIDialogueUI.QueuedAlert>();

		// Token: 0x04000056 RID: 86
		protected UnityUISubtitleControls originalNPCSubtitle;

		// Token: 0x04000057 RID: 87
		protected UnityUISubtitleControls originalPCSubtitle;

		// Token: 0x04000058 RID: 88
		protected UnityUIResponseMenuControls originalResponseMenu;

		// Token: 0x04000059 RID: 89
		private Dictionary<Transform, OverrideUnityUIDialogueControls> overrideCache = new Dictionary<Transform, OverrideUnityUIDialogueControls>();

		// Token: 0x0400005A RID: 90
		private bool isShowingNpcSubtitle;

		// Token: 0x0400005B RID: 91
		private bool isShowingPcSubtitle;

		// Token: 0x0400005C RID: 92
		private bool isShowingResponses;

		// Token: 0x02000060 RID: 96
		private class QueuedAlert
		{
			// Token: 0x06000292 RID: 658 RVA: 0x0000D8AB File Offset: 0x0000BAAB
			public QueuedAlert(string message, float duration)
			{
				this.message = message;
				this.duration = duration;
			}

			// Token: 0x04000229 RID: 553
			public string message;

			// Token: 0x0400022A RID: 554
			public float duration;
		}
	}
}
