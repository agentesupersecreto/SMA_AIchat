using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200026E RID: 622
	public abstract class QuestLogWindow : MonoBehaviour
	{
		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x06001AE6 RID: 6886 RVA: 0x0002EAE8 File Offset: 0x0002CCE8
		// (set) Token: 0x06001AE7 RID: 6887 RVA: 0x0002EAF0 File Offset: 0x0002CCF0
		public bool IsOpen { get; protected set; }

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x06001AE8 RID: 6888 RVA: 0x0002EAFC File Offset: 0x0002CCFC
		// (set) Token: 0x06001AE9 RID: 6889 RVA: 0x0002EB04 File Offset: 0x0002CD04
		public QuestLogWindow.QuestInfo[] Quests { get; protected set; }

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x06001AEA RID: 6890 RVA: 0x0002EB10 File Offset: 0x0002CD10
		// (set) Token: 0x06001AEB RID: 6891 RVA: 0x0002EB18 File Offset: 0x0002CD18
		public string[] Groups { get; protected set; }

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x06001AEC RID: 6892 RVA: 0x0002EB24 File Offset: 0x0002CD24
		// (set) Token: 0x06001AED RID: 6893 RVA: 0x0002EB2C File Offset: 0x0002CD2C
		public string SelectedQuest { get; protected set; }

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x06001AEE RID: 6894 RVA: 0x0002EB38 File Offset: 0x0002CD38
		// (set) Token: 0x06001AEF RID: 6895 RVA: 0x0002EB40 File Offset: 0x0002CD40
		public string NoQuestsMessage { get; protected set; }

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x06001AF0 RID: 6896 RVA: 0x0002EB4C File Offset: 0x0002CD4C
		public bool IsShowingActiveQuests
		{
			get
			{
				return this.currentQuestStateMask == QuestState.Active;
			}
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x0002EB58 File Offset: 0x0002CD58
		public virtual void OpenWindow(Action openedWindowHandler)
		{
			openedWindowHandler();
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x0002EB60 File Offset: 0x0002CD60
		public virtual void CloseWindow(Action closedWindowHandler)
		{
			closedWindowHandler();
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x0002EB68 File Offset: 0x0002CD68
		public virtual void OnQuestListUpdated()
		{
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x0002EB6C File Offset: 0x0002CD6C
		public virtual void ConfirmAbandonQuest(string title, Action confirmedAbandonQuestHandler)
		{
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x0002EB70 File Offset: 0x0002CD70
		public virtual void Awake()
		{
			this.IsOpen = false;
			this.Quests = new QuestLogWindow.QuestInfo[0];
			this.Groups = new string[0];
			this.SelectedQuest = string.Empty;
			this.NoQuestsMessage = string.Empty;
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x0002EBB4 File Offset: 0x0002CDB4
		public virtual void Open()
		{
			this.PauseGameplay();
			this.OpenWindow(new Action(this.OnOpenedWindow));
		}

		// Token: 0x06001AF7 RID: 6903 RVA: 0x0002EBD0 File Offset: 0x0002CDD0
		protected virtual void OnOpenedWindow()
		{
			this.IsOpen = true;
			this.ShowQuests(QuestState.Active);
		}

		// Token: 0x06001AF8 RID: 6904 RVA: 0x0002EBE0 File Offset: 0x0002CDE0
		public virtual void Close()
		{
			this.SelectedQuest = string.Empty;
			this.CloseWindow(new Action(this.OnClosedWindow));
		}

		// Token: 0x06001AF9 RID: 6905 RVA: 0x0002EC00 File Offset: 0x0002CE00
		protected virtual void OnClosedWindow()
		{
			this.IsOpen = false;
			this.ResumeGameplay();
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x0002EC10 File Offset: 0x0002CE10
		protected virtual void PauseGameplay()
		{
			if (this.pauseWhileOpen)
			{
				this.previousTimeScale = Time.timeScale;
				Time.timeScale = 0f;
			}
			if (this.unlockCursorWhileOpen)
			{
				this.wasCursorActive = Tools.IsCursorActive();
				Tools.SetCursorActive(true);
			}
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x0002EC5C File Offset: 0x0002CE5C
		protected virtual void ResumeGameplay()
		{
			if (this.pauseWhileOpen)
			{
				Time.timeScale = this.previousTimeScale;
			}
			if (this.unlockCursorWhileOpen && !this.wasCursorActive)
			{
				Tools.SetCursorActive(false);
			}
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x0002EC9C File Offset: 0x0002CE9C
		protected virtual void ShowQuests(QuestState questStateMask)
		{
			this.currentQuestStateMask = questStateMask;
			this.NoQuestsMessage = this.GetNoQuestsMessage(questStateMask);
			List<QuestLogWindow.QuestInfo> list = new List<QuestLogWindow.QuestInfo>();
			if (this.useGroups)
			{
				QuestGroupRecord[] allGroupsAndQuests = QuestLog.GetAllGroupsAndQuests(questStateMask, true);
				foreach (QuestGroupRecord questGroupRecord in allGroupsAndQuests)
				{
					list.Add(this.GetQuestInfo(questGroupRecord.groupName, questGroupRecord.questTitle));
				}
			}
			else
			{
				string[] allQuests = QuestLog.GetAllQuests(questStateMask, true, null);
				foreach (string text in allQuests)
				{
					list.Add(this.GetQuestInfo(string.Empty, text));
				}
			}
			this.Quests = list.ToArray();
			this.OnQuestListUpdated();
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x0002ED68 File Offset: 0x0002CF68
		protected virtual QuestLogWindow.QuestInfo GetQuestInfo(string group, string title)
		{
			FormattedText formattedText = FormattedText.Parse(QuestLog.GetQuestDescription(title), DialogueManager.MasterDatabase.emphasisSettings);
			FormattedText formattedText2 = FormattedText.Parse(QuestLog.GetQuestTitle(title), DialogueManager.MasterDatabase.emphasisSettings);
			FormattedText formattedText3 = ((this.questHeadingSource != QuestLogWindow.QuestHeadingSource.Description) ? formattedText2 : formattedText);
			bool flag = QuestLog.IsQuestAbandonable(title) && this.IsShowingActiveQuests;
			bool flag2 = QuestLog.IsQuestTrackingAvailable(title) && this.IsShowingActiveQuests;
			bool flag3 = QuestLog.IsQuestTrackingEnabled(title);
			int questEntryCount = QuestLog.GetQuestEntryCount(title);
			FormattedText[] array = new FormattedText[questEntryCount];
			QuestState[] array2 = new QuestState[questEntryCount];
			for (int i = 0; i < questEntryCount; i++)
			{
				array[i] = FormattedText.Parse(QuestLog.GetQuestEntry(title, i + 1), DialogueManager.MasterDatabase.emphasisSettings);
				array2[i] = QuestLog.GetQuestEntryState(title, i + 1);
			}
			return new QuestLogWindow.QuestInfo(group, title, formattedText3, formattedText, array, array2, flag2, flag3, flag);
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x0002EE58 File Offset: 0x0002D058
		protected virtual string GetNoQuestsMessage(QuestState questStateMask)
		{
			return (questStateMask != QuestState.Active) ? this.GetLocalizedText("No Completed Quests") : this.GetLocalizedText("No Active Quests");
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x0002EE88 File Offset: 0x0002D088
		public virtual string GetLocalizedText(string fieldName)
		{
			if (this.localizedText != null && this.localizedText.ContainsField(fieldName))
			{
				return this.localizedText[fieldName];
			}
			return fieldName;
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x0002EEC8 File Offset: 0x0002D0C8
		public virtual bool IsSelectedQuest(QuestLogWindow.QuestInfo questInfo)
		{
			return string.Equals(questInfo.Title, this.SelectedQuest);
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x0002EEDC File Offset: 0x0002D0DC
		public void ClickClose(object data)
		{
			this.Close();
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x0002EEE4 File Offset: 0x0002D0E4
		public virtual void ClickShowActiveQuests(object data)
		{
			this.ShowQuests(QuestState.Active);
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x0002EEF0 File Offset: 0x0002D0F0
		public virtual void ClickShowCompletedQuests(object data)
		{
			this.ShowQuests(QuestState.Success | QuestState.Failure);
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x0002EEFC File Offset: 0x0002D0FC
		public virtual void ClickQuest(object data)
		{
			if (!this.IsString(data))
			{
				return;
			}
			string text = (string)data;
			this.SelectedQuest = ((!string.Equals(this.SelectedQuest, text)) ? text : string.Empty);
			this.OnQuestListUpdated();
		}

		// Token: 0x06001B05 RID: 6917 RVA: 0x0002EF48 File Offset: 0x0002D148
		public virtual void ClickAbandonQuest(object data)
		{
			if (string.IsNullOrEmpty(this.SelectedQuest))
			{
				return;
			}
			this.ConfirmAbandonQuest(this.SelectedQuest, new Action(this.OnConfirmAbandonQuest));
		}

		// Token: 0x06001B06 RID: 6918 RVA: 0x0002EF80 File Offset: 0x0002D180
		protected virtual void OnConfirmAbandonQuest()
		{
			QuestLog.SetQuestState(this.SelectedQuest, this.abandonQuestState);
			this.ShowQuests(this.currentQuestStateMask);
			DialogueManager.Instance.BroadcastMessage("OnQuestTrackingDisabled", this.SelectedQuest, SendMessageOptions.DontRequireReceiver);
			string questAbandonSequence = QuestLog.GetQuestAbandonSequence(this.SelectedQuest);
			if (!string.IsNullOrEmpty(questAbandonSequence))
			{
				DialogueManager.PlaySequence(questAbandonSequence);
			}
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x0002EFE0 File Offset: 0x0002D1E0
		public virtual void ClickTrackQuest(object data)
		{
			if (string.IsNullOrEmpty(this.SelectedQuest))
			{
				return;
			}
			bool flag = !QuestLog.IsQuestTrackingEnabled(this.SelectedQuest);
			QuestLog.SetQuestTracking(this.SelectedQuest, flag);
			DialogueManager.Instance.BroadcastMessage((!flag) ? "OnQuestTrackingDisabled" : "OnQuestTrackingEnabled", this.SelectedQuest, SendMessageOptions.DontRequireReceiver);
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x0002F040 File Offset: 0x0002D240
		private bool IsString(object data)
		{
			return data != null && data.GetType() == typeof(string);
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x0002F060 File Offset: 0x0002D260
		public virtual void ClickShowActiveQuestsButton()
		{
			this.ClickShowActiveQuests(null);
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x0002F06C File Offset: 0x0002D26C
		public void ClickShowCompletedQuestsButton()
		{
			this.ClickShowCompletedQuests(null);
		}

		// Token: 0x06001B0B RID: 6923 RVA: 0x0002F078 File Offset: 0x0002D278
		public void ClickCloseButton()
		{
			this.ClickClose(null);
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x0002F084 File Offset: 0x0002D284
		public void ClickAbandonQuestButton()
		{
			this.ClickAbandonQuest(null);
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x0002F090 File Offset: 0x0002D290
		public void ClickTrackQuestButton()
		{
			this.ClickTrackQuest(null);
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x0002F09C File Offset: 0x0002D29C
		public void UpdateTracker()
		{
			if (this.IsOpen)
			{
				this.ShowQuests(this.currentQuestStateMask);
			}
		}

		// Token: 0x04000F16 RID: 3862
		public LocalizedTextTable localizedText;

		// Token: 0x04000F17 RID: 3863
		public QuestLogWindow.QuestHeadingSource questHeadingSource;

		// Token: 0x04000F18 RID: 3864
		[QuestState]
		public QuestState abandonQuestState = QuestState.Unassigned;

		// Token: 0x04000F19 RID: 3865
		public bool pauseWhileOpen = true;

		// Token: 0x04000F1A RID: 3866
		public bool unlockCursorWhileOpen = true;

		// Token: 0x04000F1B RID: 3867
		public bool useGroups;

		// Token: 0x04000F1C RID: 3868
		private float previousTimeScale = 1f;

		// Token: 0x04000F1D RID: 3869
		protected QuestState currentQuestStateMask = QuestState.Active;

		// Token: 0x04000F1E RID: 3870
		private bool wasCursorActive;

		// Token: 0x0200026F RID: 623
		public enum QuestHeadingSource
		{
			// Token: 0x04000F25 RID: 3877
			Name,
			// Token: 0x04000F26 RID: 3878
			Description
		}

		// Token: 0x02000270 RID: 624
		[Serializable]
		public class QuestInfo
		{
			// Token: 0x06001B0F RID: 6927 RVA: 0x0002F0B8 File Offset: 0x0002D2B8
			public QuestInfo(string group, string title, FormattedText heading, FormattedText description, FormattedText[] entries, QuestState[] entryStates, bool trackable, bool track, bool abandonable)
			{
				this.Group = group;
				this.Title = title;
				this.Heading = heading;
				this.Description = description;
				this.Entries = entries;
				this.EntryStates = entryStates;
				this.Trackable = trackable;
				this.Track = track;
				this.Abandonable = abandonable;
			}

			// Token: 0x06001B10 RID: 6928 RVA: 0x0002F110 File Offset: 0x0002D310
			public QuestInfo(string title, FormattedText heading, FormattedText description, FormattedText[] entries, QuestState[] entryStates, bool trackable, bool track, bool abandonable)
			{
				this.Group = string.Empty;
				this.Title = title;
				this.Heading = heading;
				this.Description = description;
				this.Entries = entries;
				this.EntryStates = entryStates;
				this.Trackable = trackable;
				this.Track = track;
				this.Abandonable = abandonable;
			}

			// Token: 0x17000A66 RID: 2662
			// (get) Token: 0x06001B11 RID: 6929 RVA: 0x0002F16C File Offset: 0x0002D36C
			// (set) Token: 0x06001B12 RID: 6930 RVA: 0x0002F174 File Offset: 0x0002D374
			public string Group { get; set; }

			// Token: 0x17000A67 RID: 2663
			// (get) Token: 0x06001B13 RID: 6931 RVA: 0x0002F180 File Offset: 0x0002D380
			// (set) Token: 0x06001B14 RID: 6932 RVA: 0x0002F188 File Offset: 0x0002D388
			public string Title { get; set; }

			// Token: 0x17000A68 RID: 2664
			// (get) Token: 0x06001B15 RID: 6933 RVA: 0x0002F194 File Offset: 0x0002D394
			// (set) Token: 0x06001B16 RID: 6934 RVA: 0x0002F19C File Offset: 0x0002D39C
			public FormattedText Heading { get; set; }

			// Token: 0x17000A69 RID: 2665
			// (get) Token: 0x06001B17 RID: 6935 RVA: 0x0002F1A8 File Offset: 0x0002D3A8
			// (set) Token: 0x06001B18 RID: 6936 RVA: 0x0002F1B0 File Offset: 0x0002D3B0
			public FormattedText Description { get; set; }

			// Token: 0x17000A6A RID: 2666
			// (get) Token: 0x06001B19 RID: 6937 RVA: 0x0002F1BC File Offset: 0x0002D3BC
			// (set) Token: 0x06001B1A RID: 6938 RVA: 0x0002F1C4 File Offset: 0x0002D3C4
			public FormattedText[] Entries { get; set; }

			// Token: 0x17000A6B RID: 2667
			// (get) Token: 0x06001B1B RID: 6939 RVA: 0x0002F1D0 File Offset: 0x0002D3D0
			// (set) Token: 0x06001B1C RID: 6940 RVA: 0x0002F1D8 File Offset: 0x0002D3D8
			public QuestState[] EntryStates { get; set; }

			// Token: 0x17000A6C RID: 2668
			// (get) Token: 0x06001B1D RID: 6941 RVA: 0x0002F1E4 File Offset: 0x0002D3E4
			// (set) Token: 0x06001B1E RID: 6942 RVA: 0x0002F1EC File Offset: 0x0002D3EC
			public bool Trackable { get; set; }

			// Token: 0x17000A6D RID: 2669
			// (get) Token: 0x06001B1F RID: 6943 RVA: 0x0002F1F8 File Offset: 0x0002D3F8
			// (set) Token: 0x06001B20 RID: 6944 RVA: 0x0002F200 File Offset: 0x0002D400
			public bool Track { get; set; }

			// Token: 0x17000A6E RID: 2670
			// (get) Token: 0x06001B21 RID: 6945 RVA: 0x0002F20C File Offset: 0x0002D40C
			// (set) Token: 0x06001B22 RID: 6946 RVA: 0x0002F214 File Offset: 0x0002D414
			public bool Abandonable { get; set; }
		}
	}
}
