using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200002D RID: 45
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questLogWindowUnityUI")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Quest/Unity UI Quest Template")]
	public class UnityUIQuestTemplate : MonoBehaviour
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00007420 File Offset: 0x00005620
		public bool ArePropertiesAssigned
		{
			get
			{
				return this.heading != null && this.description != null && this.entryDescription != null && this.trackButton != null && this.abandonButton != null;
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00007474 File Offset: 0x00005674
		public virtual void Initialize()
		{
			if (this.description != null)
			{
				this.description.gameObject.SetActive(false);
			}
			if (this.entryDescription != null)
			{
				this.entryDescription.gameObject.SetActive(false);
			}
			this.alternateEntryDescriptions.SetActive(false);
			if (this.entryContainer != null)
			{
				this.entryContainer.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000074EC File Offset: 0x000056EC
		public virtual void ClearQuestDetails()
		{
			if (this.entryContainer == null)
			{
				if (this.entryDescription != null)
				{
					this.entryDescription.text = string.Empty;
				}
			}
			else
			{
				for (int i = 0; i < this.entryInstances.Count; i++)
				{
					Object.Destroy(this.entryInstances[i]);
				}
				this.entryInstances.Clear();
			}
			this.numEntries = 0;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00007560 File Offset: 0x00005760
		public virtual void AddEntryDescription(string text, QuestState entryState)
		{
			if (this.entryContainer == null)
			{
				if (entryState != QuestState.Unassigned)
				{
					this.alternateEntryDescriptions.SetActive(false);
					if (this.entryDescription != null)
					{
						if (this.numEntries == 0)
						{
							this.entryDescription.gameObject.SetActive(true);
							this.entryDescription.text = text;
						}
						else
						{
							Text text2 = this.entryDescription;
							text2.text = text2.text + "\n" + text;
						}
					}
				}
			}
			else
			{
				if (this.numEntries == 0)
				{
					this.entryContainer.gameObject.SetActive(true);
					if (this.entryDescription != null)
					{
						this.entryDescription.gameObject.SetActive(false);
					}
					this.alternateEntryDescriptions.SetActive(false);
				}
				if (entryState != QuestState.Active)
				{
					if (entryState != QuestState.Success)
					{
						if (entryState == QuestState.Failure)
						{
							this.InstantiateFirstValidTextElement(text, this.entryContainer, new Text[]
							{
								this.alternateEntryDescriptions.failureDescription,
								this.entryDescription
							});
						}
					}
					else
					{
						this.InstantiateFirstValidTextElement(text, this.entryContainer, new Text[]
						{
							this.alternateEntryDescriptions.successDescription,
							this.entryDescription
						});
					}
				}
				else
				{
					this.InstantiateFirstValidTextElement(text, this.entryContainer, new Text[] { this.entryDescription });
				}
			}
			this.numEntries++;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000076C0 File Offset: 0x000058C0
		protected void InstantiateFirstValidTextElement(string text, Transform container, params Text[] textElements)
		{
			for (int i = 0; i < textElements.Length; i++)
			{
				if (textElements[i] != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(textElements[i].gameObject);
					this.entryInstances.Add(gameObject);
					gameObject.transform.SetParent(container.transform, false);
					gameObject.SetActive(true);
					Text component = gameObject.GetComponent<Text>();
					if (component != null)
					{
						component.text = text;
					}
					return;
				}
			}
		}

		// Token: 0x040000EA RID: 234
		[Header("Quest Heading")]
		[Tooltip("The heading - name or description depends on window setting")]
		public Button heading;

		// Token: 0x040000EB RID: 235
		[Tooltip("Used for Description")]
		public Text description;

		// Token: 0x040000EC RID: 236
		public UnityUIQuestTemplateAlternateDescriptions alternateDescriptions = new UnityUIQuestTemplateAlternateDescriptions();

		// Token: 0x040000ED RID: 237
		[Header("Quest Entries")]
		[Tooltip("(Optional) If set, holds instantiated quest entries")]
		public Transform entryContainer;

		// Token: 0x040000EE RID: 238
		[Tooltip("Used for quest entries")]
		public Text entryDescription;

		// Token: 0x040000EF RID: 239
		public UnityUIQuestTemplateAlternateDescriptions alternateEntryDescriptions = new UnityUIQuestTemplateAlternateDescriptions();

		// Token: 0x040000F0 RID: 240
		[Header("Buttons")]
		[Tooltip("Used for Track button if quest is trackable")]
		public Button trackButton;

		// Token: 0x040000F1 RID: 241
		[Tooltip("Used for Abandon button if quest is abandonable")]
		public Button abandonButton;

		// Token: 0x040000F2 RID: 242
		protected List<GameObject> entryInstances = new List<GameObject>();

		// Token: 0x040000F3 RID: 243
		protected int numEntries;
	}
}
