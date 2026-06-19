using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200002C RID: 44
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questLogWindowUnityUI")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Quest/Unity UI Quest Log Window")]
	public class UnityUIQuestLogWindow : QuestLogWindow
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600011B RID: 283 RVA: 0x000067A4 File Offset: 0x000049A4
		protected UIShowHideController showHideController
		{
			get
			{
				if (this.m_showHideController == null)
				{
					this.m_showHideController = new UIShowHideController(base.gameObject, this.mainPanel, UIShowHideController.TransitionMode.Trigger);
				}
				return this.m_showHideController;
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000067CC File Offset: 0x000049CC
		public virtual void Start()
		{
			UITools.RequireEventSystem();
			Tools.SetGameObjectActive(this.mainPanel, false);
			Tools.SetGameObjectActive(this.abandonPopup, false);
			Tools.SetGameObjectActive(this.questGroupTemplate, false);
			Tools.SetGameObjectActive(this.questTemplate, false);
			this.SetStateButtonListeners();
			this.SetStateToggleButtons();
			if (DialogueDebug.LogWarnings)
			{
				if (this.mainPanel == null)
				{
					Debug.LogWarning(string.Format("{0}: {1} Main Panel is unassigned", new object[] { "Dialogue System", base.name }));
				}
				if (this.questTable == null)
				{
					Debug.LogWarning(string.Format("{0}: {1} Quest Table is unassigned", new object[] { "Dialogue System", base.name }));
				}
				if (this.useGroups && (this.questTemplate == null || !this.questTemplate.ArePropertiesAssigned))
				{
					Debug.LogWarning(string.Format("{0}: {1} Quest Group Template or one of its properties is unassigned", new object[] { "Dialogue System", base.name }));
				}
				if (this.questTemplate == null || !this.questTemplate.ArePropertiesAssigned)
				{
					Debug.LogWarning(string.Format("{0}: {1} Quest Template or one of its properties is unassigned", new object[] { "Dialogue System", base.name }));
				}
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006918 File Offset: 0x00004B18
		public virtual void Update()
		{
			if (this.autoFocus && base.IsOpen && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == null && this.autoFocusCheckFrequency > 0.001f && Time.realtimeSinceStartup > this.nextAutoFocusCheckTime)
			{
				this.nextAutoFocusCheckTime = Time.realtimeSinceStartup + this.autoFocusCheckFrequency;
				this.AutoFocus();
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006986 File Offset: 0x00004B86
		public override void OpenWindow(Action openedWindowHandler)
		{
			this.showHideController.Show(this.animationTransitions.showTrigger, this.pauseWhileOpen, openedWindowHandler, false);
			base.IsOpen = true;
			this.AutoFocus();
			this.onOpen.Invoke();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000069BE File Offset: 0x00004BBE
		public void AutoFocus()
		{
			UITools.Select((this.completedQuestsButton.gameObject.activeSelf ? this.completedQuestsButton.gameObject : this.activeQuestsButton.gameObject).GetComponent<Selectable>(), true);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000069F5 File Offset: 0x00004BF5
		public override void CloseWindow(Action closedWindowHandler)
		{
			this.ResumeGameplay();
			this.showHideController.Hide(this.animationTransitions.hideTrigger, closedWindowHandler);
			base.IsOpen = false;
			this.onClose.Invoke();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006A28 File Offset: 0x00004C28
		public override void OnQuestListUpdated()
		{
			this.unusedGroupTemplateInstances.AddRange(this.groupTemplateInstances);
			this.unusedQuestTemplateInstances.AddRange(this.questTemplateInstances);
			this.groupTemplateInstances.Clear();
			this.questTemplateInstances.Clear();
			this.siblingIndexCounter = 0;
			if (base.Quests.Length == 0)
			{
				this.AddQuestToTable(new QuestLogWindow.QuestInfo(string.Empty, new FormattedText(base.NoQuestsMessage, null, false, -1, true, 0, 0, 0, null), FormattedText.empty, new FormattedText[0], new QuestState[0], false, false, false));
			}
			else
			{
				this.AddQuestsToTable();
			}
			for (int i = 0; i < this.unusedGroupTemplateInstances.Count; i++)
			{
				Object.Destroy(this.unusedGroupTemplateInstances[i].gameObject);
			}
			this.unusedGroupTemplateInstances.Clear();
			for (int j = 0; j < this.unusedQuestTemplateInstances.Count; j++)
			{
				Object.Destroy(this.unusedQuestTemplateInstances[j].gameObject);
			}
			this.unusedQuestTemplateInstances.Clear();
			this.SetStateToggleButtons();
			if (this.mainPanel != null)
			{
				LayoutRebuilder.MarkLayoutForRebuild(this.mainPanel.rectTransform);
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006B50 File Offset: 0x00004D50
		protected void SetStateButtonListeners()
		{
			if (this.activeQuestsButton != null)
			{
				this.activeQuestsButton.onClick.RemoveListener(delegate
				{
					this.ClickShowActiveQuestsButton();
				});
				this.activeQuestsButton.onClick.AddListener(delegate
				{
					this.ClickShowActiveQuestsButton();
				});
			}
			if (this.completedQuestsButton != null)
			{
				this.completedQuestsButton.onClick.RemoveListener(delegate
				{
					base.ClickShowCompletedQuestsButton();
				});
				this.completedQuestsButton.onClick.AddListener(delegate
				{
					base.ClickShowCompletedQuestsButton();
				});
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006BEC File Offset: 0x00004DEC
		protected void SetStateToggleButtons()
		{
			if (this.activeQuestsButton != null)
			{
				this.activeQuestsButton.interactable = !base.IsShowingActiveQuests;
			}
			if (this.completedQuestsButton != null)
			{
				this.completedQuestsButton.interactable = base.IsShowingActiveQuests;
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006C3C File Offset: 0x00004E3C
		protected virtual void ClearQuestTable()
		{
			if (this.questTable == null)
			{
				return;
			}
			foreach (object obj in this.questTable.transform)
			{
				Transform transform = (Transform)obj;
				if (transform.gameObject.activeSelf)
				{
					Object.Destroy(transform.gameObject);
				}
			}
			this.NotifyContentChanged();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006CC0 File Offset: 0x00004EC0
		protected virtual void AddQuestsToTable()
		{
			if (this.questTable == null)
			{
				return;
			}
			string text = null;
			bool flag = false;
			for (int i = 0; i < base.Quests.Length; i++)
			{
				if (!string.Equals(base.Quests[i].Group, text))
				{
					text = base.Quests[i].Group;
					this.AddQuestGroupToTable(text);
					flag = this.collapsedGroups.Contains(text);
				}
				if (!flag)
				{
					this.AddQuestToTable(base.Quests[i]);
				}
			}
			this.NotifyContentChanged();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006D44 File Offset: 0x00004F44
		protected virtual void AddQuestGroupToTable(string group)
		{
			if (string.IsNullOrEmpty(group) || this.questGroupTemplate == null || !this.questGroupTemplate.ArePropertiesAssigned)
			{
				return;
			}
			UnityUIQuestGroupTemplate unityUIQuestGroupTemplate = this.unusedGroupTemplateInstances.Find((UnityUIQuestGroupTemplate x) => string.Equals(x.heading.text, group));
			int num;
			if (unityUIQuestGroupTemplate != null)
			{
				this.unusedGroupTemplateInstances.Remove(unityUIQuestGroupTemplate);
				this.groupTemplateInstances.Add(unityUIQuestGroupTemplate);
				Transform transform = unityUIQuestGroupTemplate.transform;
				num = this.siblingIndexCounter;
				this.siblingIndexCounter = num + 1;
				transform.SetSiblingIndex(num);
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.questGroupTemplate.gameObject);
			if (gameObject == null)
			{
				Debug.LogError(string.Format("{0}: {1} couldn't instantiate quest group template", new object[] { "Dialogue System", base.name }));
				return;
			}
			gameObject.name = group;
			gameObject.transform.SetParent(this.questTable.transform, false);
			gameObject.SetActive(true);
			UnityUIQuestGroupTemplate component = gameObject.GetComponent<UnityUIQuestGroupTemplate>();
			if (component == null)
			{
				return;
			}
			this.groupTemplateInstances.Add(component);
			Transform transform2 = component.transform;
			num = this.siblingIndexCounter;
			this.siblingIndexCounter = num + 1;
			transform2.SetSiblingIndex(num);
			component.Initialize();
			component.heading.text = group;
			Button componentInChildren = gameObject.GetComponentInChildren<Button>();
			if (componentInChildren != null)
			{
				componentInChildren.onClick.AddListener(delegate
				{
					this.ClickQuestGroupFoldout(group);
				});
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00006ED0 File Offset: 0x000050D0
		protected virtual void AddQuestToTable(QuestLogWindow.QuestInfo questInfo)
		{
			if (this.questTable == null || this.questTemplate == null || !this.questTemplate.ArePropertiesAssigned)
			{
				return;
			}
			UnityUIQuestTemplate unityUIQuestTemplate = this.unusedQuestTemplateInstances.Find((UnityUIQuestTemplate x) => x.heading.GetComponentInChildren<Text>() != null && string.Equals(x.heading.GetComponentInChildren<Text>().text, questInfo.Heading.text));
			int num;
			if (unityUIQuestTemplate != null)
			{
				this.unusedQuestTemplateInstances.Remove(unityUIQuestTemplate);
				this.questTemplateInstances.Add(unityUIQuestTemplate);
				Transform transform = unityUIQuestTemplate.transform;
				num = this.siblingIndexCounter;
				this.siblingIndexCounter = num + 1;
				transform.SetSiblingIndex(num);
				unityUIQuestTemplate.description.text = questInfo.Description.text;
				unityUIQuestTemplate.ClearQuestDetails();
				this.SetQuestDetails(unityUIQuestTemplate, questInfo);
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.questTemplate.gameObject);
			if (gameObject == null)
			{
				Debug.LogError(string.Format("{0}: {1} couldn't instantiate quest template", new object[] { "Dialogue System", base.name }));
				return;
			}
			gameObject.name = questInfo.Heading.text;
			gameObject.transform.SetParent(this.questTable.transform, false);
			Transform transform2 = gameObject.transform;
			num = this.siblingIndexCounter;
			this.siblingIndexCounter = num + 1;
			transform2.SetSiblingIndex(num);
			gameObject.SetActive(true);
			UnityUIQuestTemplate component = gameObject.GetComponent<UnityUIQuestTemplate>();
			if (component == null)
			{
				return;
			}
			this.questTemplateInstances.Add(component);
			component.Initialize();
			Button heading = component.heading;
			Text componentInChildren = heading.GetComponentInChildren<Text>();
			if (componentInChildren != null)
			{
				componentInChildren.text = questInfo.Heading.text;
			}
			heading.onClick.AddListener(delegate
			{
				this.ClickQuestFoldout(questInfo.Title);
			});
			this.SetQuestDetails(component, questInfo);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000070AC File Offset: 0x000052AC
		protected virtual void SetQuestDetails(UnityUIQuestTemplate questControl, QuestLogWindow.QuestInfo questInfo)
		{
			if (this.IsSelectedQuest(questInfo))
			{
				if (this.questHeadingSource == QuestLogWindow.QuestHeadingSource.Name)
				{
					questControl.description.text = questInfo.Description.text;
					Tools.SetGameObjectActive(questControl.description, true);
				}
				if (questInfo.EntryStates.Length != 0)
				{
					for (int i = 0; i < questInfo.Entries.Length; i++)
					{
						questControl.AddEntryDescription(questInfo.Entries[i].text, questInfo.EntryStates[i]);
					}
				}
				if (questControl.trackButton != null)
				{
					questControl.trackButton.gameObject.AddComponent<UnityUIQuestTitle>().questTitle = questInfo.Title;
					questControl.trackButton.onClick.RemoveAllListeners();
					questControl.trackButton.onClick.AddListener(delegate
					{
						base.ClickTrackQuestButton();
					});
					Tools.SetGameObjectActive(questControl.trackButton, questInfo.Trackable);
				}
				if (questControl.abandonButton != null)
				{
					questControl.abandonButton.gameObject.AddComponent<UnityUIQuestTitle>().questTitle = questInfo.Title;
					questControl.abandonButton.onClick.RemoveAllListeners();
					questControl.abandonButton.onClick.AddListener(delegate
					{
						base.ClickAbandonQuestButton();
					});
					Tools.SetGameObjectActive(questControl.abandonButton, questInfo.Abandonable);
					return;
				}
			}
			else
			{
				Tools.SetGameObjectActive(questControl.description, false);
				Tools.SetGameObjectActive(questControl.entryDescription, false);
				Tools.SetGameObjectActive(questControl.trackButton, false);
				Tools.SetGameObjectActive(questControl.abandonButton, false);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007226 File Offset: 0x00005426
		public void NotifyContentChanged()
		{
			this.onContentChanged.Invoke();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007233 File Offset: 0x00005433
		public void ClickQuestFoldout(string questTitle)
		{
			this.ClickQuest(questTitle);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000723C File Offset: 0x0000543C
		public void ClickQuestGroupFoldout(string group)
		{
			if (this.collapsedGroups.Contains(group))
			{
				this.collapsedGroups.Remove(group);
			}
			else
			{
				this.collapsedGroups.Add(group);
			}
			this.OnQuestListUpdated();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000726D File Offset: 0x0000546D
		protected void OnTrackButtonClicked(GameObject button)
		{
			base.SelectedQuest = button.GetComponent<UnityUIQuestTitle>().questTitle;
			this.ClickTrackQuest(base.SelectedQuest);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000728C File Offset: 0x0000548C
		protected void OnAbandonButtonClicked(GameObject button)
		{
			base.SelectedQuest = button.GetComponent<UnityUIQuestTitle>().questTitle;
			this.ClickAbandonQuest(base.SelectedQuest);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000072AB File Offset: 0x000054AB
		public override void ConfirmAbandonQuest(string title, Action confirmAbandonQuestHandler)
		{
			this.confirmAbandonQuestHandler = confirmAbandonQuestHandler;
			this.OpenAbandonPopup(title);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000072BC File Offset: 0x000054BC
		protected void OpenAbandonPopup(string title)
		{
			if (this.abandonPopup != null)
			{
				Tools.SetGameObjectActive(this.abandonPopup, true);
				if (this.abandonQuestTitle != null)
				{
					this.abandonQuestTitle.text = title;
				}
				if (this.autoFocus && EventSystem.current != null)
				{
					Button componentInChildren = this.abandonPopup.GetComponentInChildren<Button>();
					if (componentInChildren != null)
					{
						EventSystem.current.SetSelectedGameObject(componentInChildren.gameObject);
						return;
					}
				}
				else
				{
					this.confirmAbandonQuestHandler();
				}
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007343 File Offset: 0x00005543
		protected void CloseAbandonPopup()
		{
			Tools.SetGameObjectActive(this.abandonPopup, false);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007351 File Offset: 0x00005551
		public void ClickConfirmAbandonQuestButton()
		{
			this.CloseAbandonPopup();
			this.confirmAbandonQuestHandler();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00007364 File Offset: 0x00005564
		public void ClickCancelAbandonQuestButton()
		{
			this.CloseAbandonPopup();
		}

		// Token: 0x040000D3 RID: 211
		public Graphic mainPanel;

		// Token: 0x040000D4 RID: 212
		public Button activeQuestsButton;

		// Token: 0x040000D5 RID: 213
		public Button completedQuestsButton;

		// Token: 0x040000D6 RID: 214
		public Graphic questTable;

		// Token: 0x040000D7 RID: 215
		public UnityUIQuestGroupTemplate questGroupTemplate;

		// Token: 0x040000D8 RID: 216
		public UnityUIQuestTemplate questTemplate;

		// Token: 0x040000D9 RID: 217
		public Graphic abandonPopup;

		// Token: 0x040000DA RID: 218
		public Text abandonQuestTitle;

		// Token: 0x040000DB RID: 219
		[Tooltip("Always keep a control focused; useful for gamepads and keyboard.")]
		public bool autoFocus;

		// Token: 0x040000DC RID: 220
		[Tooltip("If auto focusing, check on this frequency in seconds that the control is focused.")]
		public float autoFocusCheckFrequency = 0.5f;

		// Token: 0x040000DD RID: 221
		public UnityEvent onOpen = new UnityEvent();

		// Token: 0x040000DE RID: 222
		public UnityEvent onClose = new UnityEvent();

		// Token: 0x040000DF RID: 223
		public UnityEvent onContentChanged = new UnityEvent();

		// Token: 0x040000E0 RID: 224
		public UnityUIQuestLogWindow.AnimationTransitions animationTransitions = new UnityUIQuestLogWindow.AnimationTransitions();

		// Token: 0x040000E1 RID: 225
		protected Action confirmAbandonQuestHandler;

		// Token: 0x040000E2 RID: 226
		private UIShowHideController m_showHideController;

		// Token: 0x040000E3 RID: 227
		protected List<string> collapsedGroups = new List<string>();

		// Token: 0x040000E4 RID: 228
		protected List<UnityUIQuestGroupTemplate> groupTemplateInstances = new List<UnityUIQuestGroupTemplate>();

		// Token: 0x040000E5 RID: 229
		protected List<UnityUIQuestTemplate> questTemplateInstances = new List<UnityUIQuestTemplate>();

		// Token: 0x040000E6 RID: 230
		protected List<UnityUIQuestGroupTemplate> unusedGroupTemplateInstances = new List<UnityUIQuestGroupTemplate>();

		// Token: 0x040000E7 RID: 231
		protected List<UnityUIQuestTemplate> unusedQuestTemplateInstances = new List<UnityUIQuestTemplate>();

		// Token: 0x040000E8 RID: 232
		protected int siblingIndexCounter;

		// Token: 0x040000E9 RID: 233
		private float nextAutoFocusCheckTime;

		// Token: 0x0200006F RID: 111
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x0400026F RID: 623
			public string showTrigger = "Show";

			// Token: 0x04000270 RID: 624
			public string hideTrigger = "Hide";
		}
	}
}
