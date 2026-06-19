using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000030 RID: 48
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questSystemTrackerHUD")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Quest/Unity UI Quest Tracker HUD (on Dialogue Manager or child)")]
	public class UnityUIQuestTracker : MonoBehaviour
	{
		// Token: 0x06000143 RID: 323 RVA: 0x000077AC File Offset: 0x000059AC
		public virtual void Start()
		{
			this.isVisible = PlayerPrefs.GetInt(this.playerPrefsToggleKey, this.visibleOnStart ? 1 : 0) == 1;
			if (this.container == null)
			{
				Debug.LogWarning(string.Format("{0}: {1} Container is unassigned", new object[] { "Dialogue System", base.name }));
			}
			if (this.questTrackTemplate == null)
			{
				Debug.LogWarning(string.Format("{0}: {1} Quest Track Template is unassigned", new object[] { "Dialogue System", base.name }));
			}
			else
			{
				this.questTrackTemplate.gameObject.SetActive(false);
			}
			if (this.isVisible)
			{
				base.Invoke("UpdateTracker", 0.5f);
				return;
			}
			this.HideTracker();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00007873 File Offset: 0x00005A73
		public virtual void ShowTracker()
		{
			this.isVisible = true;
			PlayerPrefs.SetInt(this.playerPrefsToggleKey, 1);
			if (this.container != null)
			{
				this.container.gameObject.SetActive(true);
			}
			this.UpdateTracker();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000078AD File Offset: 0x00005AAD
		public virtual void HideTracker()
		{
			this.isVisible = false;
			PlayerPrefs.SetInt(this.playerPrefsToggleKey, 0);
			if (this.container != null)
			{
				this.container.gameObject.SetActive(false);
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000078E1 File Offset: 0x00005AE1
		public virtual void ToggleTracker()
		{
			if (this.isVisible)
			{
				this.HideTracker();
				return;
			}
			this.ShowTracker();
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000078F8 File Offset: 0x00005AF8
		public virtual void OnQuestTrackingEnabled(string quest)
		{
			this.UpdateTracker();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00007900 File Offset: 0x00005B00
		public virtual void OnQuestTrackingDisabled(string quest)
		{
			this.UpdateTracker();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00007908 File Offset: 0x00005B08
		public void OnConversationEnd(Transform actor)
		{
			this.UpdateTracker();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007910 File Offset: 0x00005B10
		public virtual void UpdateTracker()
		{
			if (!this.isVisible)
			{
				return;
			}
			if (this.refreshCoroutine == null)
			{
				this.refreshCoroutine = base.StartCoroutine(this.RefreshAtEndOfFrame());
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007935 File Offset: 0x00005B35
		protected virtual IEnumerator RefreshAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			this.unusedInstances.AddRange(this.instantiatedItems);
			this.instantiatedItems.Clear();
			this.siblingIndexCounter = 0;
			int num = 0;
			foreach (string text in QuestLog.GetAllQuests((this.showActiveQuests ? QuestState.Active : ((QuestState)0)) | (this.showCompletedQuests ? (QuestState.Success | QuestState.Failure) : ((QuestState)0))))
			{
				if (QuestLog.IsQuestTrackingEnabled(text))
				{
					this.AddQuestTrack(text);
					num++;
				}
			}
			if (this.container != null)
			{
				this.container.gameObject.SetActive(this.showContainerIfEmpty || num > 0);
			}
			for (int j = 0; j < this.unusedInstances.Count; j++)
			{
				Object.Destroy(this.unusedInstances[j].gameObject);
			}
			this.unusedInstances.Clear();
			this.refreshCoroutine = null;
			yield break;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007944 File Offset: 0x00005B44
		protected virtual void AddQuestTrack(string quest)
		{
			if (this.container == null || this.questTrackTemplate == null)
			{
				return;
			}
			string text = FormattedText.Parse((this.questDescriptionSource == UnityUIQuestTracker.QuestDescriptionSource.Title) ? QuestLog.GetQuestTitle(quest) : QuestLog.GetQuestDescription(quest), DialogueManager.MasterDatabase.emphasisSettings).text;
			GameObject gameObject;
			if (this.unusedInstances.Count > 0)
			{
				gameObject = this.unusedInstances[0].gameObject;
				this.unusedInstances.RemoveAt(0);
			}
			else
			{
				gameObject = Object.Instantiate<GameObject>(this.questTrackTemplate.gameObject);
				if (gameObject == null)
				{
					Debug.LogError(string.Format("{0}: {1} couldn't instantiate quest track template", new object[] { "Dialogue System", base.name }));
					return;
				}
			}
			gameObject.name = text;
			gameObject.transform.SetParent(this.container.transform, false);
			gameObject.SetActive(true);
			UnityUIQuestTrackTemplate component = gameObject.GetComponent<UnityUIQuestTrackTemplate>();
			this.instantiatedItems.Add(component);
			if (component != null)
			{
				component.Initialize();
				QuestState questState = QuestLog.GetQuestState(quest);
				component.SetDescription(text, questState);
				int questEntryCount = QuestLog.GetQuestEntryCount(quest);
				for (int i = 1; i <= questEntryCount; i++)
				{
					QuestState questEntryState = QuestLog.GetQuestEntryState(quest, i);
					string text2 = FormattedText.Parse(this.GetQuestEntryText(quest, i, questEntryState), DialogueManager.MasterDatabase.emphasisSettings).text;
					if (!string.IsNullOrEmpty(text2))
					{
						component.AddEntryDescription(text2, questEntryState);
					}
				}
				Transform transform = component.transform;
				int num = this.siblingIndexCounter;
				this.siblingIndexCounter = num + 1;
				transform.SetSiblingIndex(num);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007AD8 File Offset: 0x00005CD8
		protected virtual string GetQuestEntryText(string quest, int entryNum, QuestState entryState)
		{
			if (entryState == QuestState.Unassigned || entryState == QuestState.Abandoned)
			{
				return string.Empty;
			}
			if ((entryState == QuestState.Success || entryState == QuestState.Failure) && !this.showCompletedEntryText)
			{
				return string.Empty;
			}
			if (entryState == QuestState.Success)
			{
				string asString = DialogueLua.GetQuestField(quest, "Entry " + entryNum.ToString() + " Success").AsString;
				if (!string.IsNullOrEmpty(asString))
				{
					return asString;
				}
			}
			else if (entryState == QuestState.Failure)
			{
				string asString2 = DialogueLua.GetQuestField(quest, "Entry " + entryNum.ToString() + " Failure").AsString;
				if (!string.IsNullOrEmpty(asString2))
				{
					return asString2;
				}
			}
			return QuestLog.GetQuestEntry(quest, entryNum);
		}

		// Token: 0x040000F7 RID: 247
		[Tooltip("Record the quest tracker display toggle in this PlayerPrefs key.")]
		public string playerPrefsToggleKey = "QuestTracker";

		// Token: 0x040000F8 RID: 248
		[Tooltip("UI container that will hold instances of quest track template.")]
		public Transform container;

		// Token: 0x040000F9 RID: 249
		[Tooltip("Show Container even if there's nothing to track.")]
		public bool showContainerIfEmpty = true;

		// Token: 0x040000FA RID: 250
		[Tooltip("Template to instantiate for each tracked quest.")]
		public UnityUIQuestTrackTemplate questTrackTemplate;

		// Token: 0x040000FB RID: 251
		[Tooltip("Show active quests.")]
		public bool showActiveQuests = true;

		// Token: 0x040000FC RID: 252
		[Tooltip("Show successful and failed quests.")]
		public bool showCompletedQuests;

		// Token: 0x040000FD RID: 253
		[Tooltip("Show Entry n Success or Entry n Failure text if quest entry is in success/failure state.")]
		public bool showCompletedEntryText;

		// Token: 0x040000FE RID: 254
		[Tooltip("Source for the quest tracker text.")]
		public UnityUIQuestTracker.QuestDescriptionSource questDescriptionSource;

		// Token: 0x040000FF RID: 255
		public bool visibleOnStart = true;

		// Token: 0x04000100 RID: 256
		protected List<UnityUIQuestTrackTemplate> instantiatedItems = new List<UnityUIQuestTrackTemplate>();

		// Token: 0x04000101 RID: 257
		private List<UnityUIQuestTrackTemplate> unusedInstances = new List<UnityUIQuestTrackTemplate>();

		// Token: 0x04000102 RID: 258
		private int siblingIndexCounter;

		// Token: 0x04000103 RID: 259
		protected bool isVisible = true;

		// Token: 0x04000104 RID: 260
		protected Coroutine refreshCoroutine;

		// Token: 0x02000072 RID: 114
		public enum QuestDescriptionSource
		{
			// Token: 0x04000276 RID: 630
			Title,
			// Token: 0x04000277 RID: 631
			Description
		}
	}
}
