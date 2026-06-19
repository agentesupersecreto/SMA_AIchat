using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.UnityGUI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000048 RID: 72
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_tracker_h_u_d.html")]
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Quest/Quest Tracker HUD (add to Dialogue Manager)")]
	public class QuestTracker : MonoBehaviour
	{
		// Token: 0x06000219 RID: 537 RVA: 0x0000B00B File Offset: 0x0000920B
		public void Start()
		{
			this.isVisible = PlayerPrefs.GetInt(this.playerPrefsToggleKey, 1) == 1;
			base.StartCoroutine(this.UpdateTrackerAfterOneFrame());
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000B02F File Offset: 0x0000922F
		private IEnumerator UpdateTrackerAfterOneFrame()
		{
			yield return null;
			this.UpdateTracker();
			yield break;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000B03E File Offset: 0x0000923E
		public void ShowTracker()
		{
			this.isVisible = true;
			PlayerPrefs.SetInt(this.playerPrefsToggleKey, 1);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000B053 File Offset: 0x00009253
		public void HideTracker()
		{
			this.isVisible = false;
			PlayerPrefs.SetInt(this.playerPrefsToggleKey, 0);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000B068 File Offset: 0x00009268
		public void ToggleTracker()
		{
			if (this.isVisible)
			{
				this.HideTracker();
				return;
			}
			this.ShowTracker();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000B07F File Offset: 0x0000927F
		public void OnQuestTrackingEnabled(string quest)
		{
			this.UpdateTracker();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000B087 File Offset: 0x00009287
		public void OnQuestTrackingDisabled(string quest)
		{
			this.UpdateTracker();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000B08F File Offset: 0x0000928F
		public void OnConversationEnd(Transform actor)
		{
			this.UpdateTracker();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000B098 File Offset: 0x00009298
		public void UpdateTracker()
		{
			this.screenRect = this.rect.GetPixelRect();
			this.lines.Clear();
			foreach (string text in QuestLog.GetAllQuests((this.showActiveQuests ? QuestState.Active : ((QuestState)0)) | (this.showCompletedQuests ? (QuestState.Success | QuestState.Failure) : ((QuestState)0))))
			{
				if (QuestLog.IsQuestTrackingEnabled(text))
				{
					this.AddQuestTitle(text);
					this.AddQuestEntries(text);
				}
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000B10C File Offset: 0x0000930C
		private void AddQuestTitle(string quest)
		{
			QuestTracker.QuestTrackerLine questTrackerLine = new QuestTracker.QuestTrackerLine();
			string text = ((this.questDescriptionSource == QuestTracker.QuestDescriptionSource.Title) ? QuestLog.GetQuestTitle(quest) : QuestLog.GetQuestDescription(quest));
			questTrackerLine.text = FormattedText.Parse(text, DialogueManager.MasterDatabase.emphasisSettings).text;
			questTrackerLine.guiStyleName = this.GetTitleStyleName(QuestLog.GetQuestState(quest));
			questTrackerLine.guiStyle = null;
			this.lines.Add(questTrackerLine);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000B178 File Offset: 0x00009378
		private void AddQuestEntries(string quest)
		{
			int questEntryCount = QuestLog.GetQuestEntryCount(quest);
			for (int i = 1; i <= questEntryCount; i++)
			{
				QuestState questEntryState = QuestLog.GetQuestEntryState(quest, i);
				if (questEntryState != QuestState.Unassigned && ((questEntryState != QuestState.Success && questEntryState != QuestState.Failure) || this.showCompletedEntryText))
				{
					QuestTracker.QuestTrackerLine questTrackerLine = new QuestTracker.QuestTrackerLine();
					string questEntryText = this.GetQuestEntryText(quest, i, questEntryState);
					questTrackerLine.text = FormattedText.Parse(questEntryText, DialogueManager.MasterDatabase.emphasisSettings).text;
					questTrackerLine.guiStyleName = this.GetEntryStyleName(questEntryState);
					questTrackerLine.guiStyle = null;
					this.lines.Add(questTrackerLine);
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000B204 File Offset: 0x00009404
		private string GetQuestEntryText(string quest, int entryNum, QuestState entryState)
		{
			if (entryState == QuestState.Unassigned || entryState == QuestState.Abandoned)
			{
				return string.Empty;
			}
			if (entryState == QuestState.Success && this.showCompletedEntryText)
			{
				string asString = DialogueLua.GetQuestField(quest, "Entry " + entryNum.ToString() + " Success").AsString;
				if (!string.IsNullOrEmpty(asString))
				{
					return asString;
				}
			}
			else if (entryState == QuestState.Failure && this.showCompletedEntryText)
			{
				string asString2 = DialogueLua.GetQuestField(quest, "Entry " + entryNum.ToString() + " Failure").AsString;
				if (!string.IsNullOrEmpty(asString2))
				{
					return asString2;
				}
			}
			return QuestLog.GetQuestEntry(quest, entryNum);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000B29D File Offset: 0x0000949D
		private string GetTitleStyleName(QuestState state)
		{
			if (state == QuestState.Active)
			{
				return this.TitleStyle;
			}
			if (state == QuestState.Success)
			{
				return this.SuccessTitleStyle;
			}
			if (state != QuestState.Failure)
			{
				return this.TitleStyle;
			}
			return this.FailureTitleStyle;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000B2C8 File Offset: 0x000094C8
		private string GetEntryStyleName(QuestState entryState)
		{
			if (entryState == QuestState.Active)
			{
				return this.ActiveEntryStyle;
			}
			if (entryState == QuestState.Success)
			{
				return this.SuccessEntryStyle;
			}
			if (entryState != QuestState.Failure)
			{
				return this.ActiveEntryStyle;
			}
			return this.FailureEntryStyle;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000B2F4 File Offset: 0x000094F4
		private void OnGUI()
		{
			if (!this.isVisible)
			{
				return;
			}
			if (this.guiSkin != null)
			{
				GUI.skin = this.guiSkin;
			}
			GUILayout.BeginArea(this.screenRect);
			foreach (QuestTracker.QuestTrackerLine questTrackerLine in this.lines)
			{
				if (questTrackerLine.guiStyle == null)
				{
					questTrackerLine.guiStyle = UnityGUITools.GetGUIStyle(questTrackerLine.guiStyleName, GUI.skin.label);
				}
				GUILayout.Label(questTrackerLine.text, questTrackerLine.guiStyle, Array.Empty<GUILayoutOption>());
			}
			GUILayout.EndArea();
		}

		// Token: 0x04000196 RID: 406
		[Tooltip("Record the quest tracker display toggle in this PlayerPrefs key.")]
		public string playerPrefsToggleKey = "QuestTracker";

		// Token: 0x04000197 RID: 407
		public ScaledRect rect = new ScaledRect(ScaledRectAlignment.TopRight, ScaledRectAlignment.TopRight, ScaledValue.FromPixelValue(0f), ScaledValue.FromPixelValue(0f), ScaledValue.FromNormalizedValue(0.25f), ScaledValue.FromNormalizedValue(1f), 64f, 32f);

		// Token: 0x04000198 RID: 408
		public GUISkin guiSkin;

		// Token: 0x04000199 RID: 409
		public string TitleStyle;

		// Token: 0x0400019A RID: 410
		public string SuccessTitleStyle;

		// Token: 0x0400019B RID: 411
		public string FailureTitleStyle;

		// Token: 0x0400019C RID: 412
		public string ActiveEntryStyle;

		// Token: 0x0400019D RID: 413
		public string SuccessEntryStyle;

		// Token: 0x0400019E RID: 414
		public string FailureEntryStyle;

		// Token: 0x0400019F RID: 415
		public bool showActiveQuests = true;

		// Token: 0x040001A0 RID: 416
		public bool showCompletedQuests;

		// Token: 0x040001A1 RID: 417
		public bool showCompletedEntryText;

		// Token: 0x040001A2 RID: 418
		public QuestTracker.QuestDescriptionSource questDescriptionSource;

		// Token: 0x040001A3 RID: 419
		private Rect screenRect;

		// Token: 0x040001A4 RID: 420
		private List<QuestTracker.QuestTrackerLine> lines = new List<QuestTracker.QuestTrackerLine>();

		// Token: 0x040001A5 RID: 421
		private bool isVisible = true;

		// Token: 0x0200008D RID: 141
		public enum QuestDescriptionSource
		{
			// Token: 0x040002D4 RID: 724
			Title,
			// Token: 0x040002D5 RID: 725
			Description
		}

		// Token: 0x0200008E RID: 142
		private class QuestTrackerLine
		{
			// Token: 0x040002D6 RID: 726
			public string guiStyleName;

			// Token: 0x040002D7 RID: 727
			public GUIStyle guiStyle;

			// Token: 0x040002D8 RID: 728
			public string text;
		}
	}
}
