using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000031 RID: 49
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questSystemTrackerHUD")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Quest/Quest Track Template")]
	public class UnityUIQuestTrackTemplate : MonoBehaviour
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00007BC8 File Offset: 0x00005DC8
		public bool ArePropertiesAssigned
		{
			get
			{
				return this.description != null && this.entryDescription != null;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00007BE8 File Offset: 0x00005DE8
		public void Initialize()
		{
			if (this.description != null)
			{
				this.description.gameObject.SetActive(false);
			}
			this.alternateDescriptions.SetActive(false);
			if (this.entryDescription != null)
			{
				this.entryDescription.gameObject.SetActive(false);
			}
			this.alternateEntryDescriptions.SetActive(false);
			if (this.entryContainer != null)
			{
				this.entryContainer.gameObject.SetActive(false);
				if (this.instances != null)
				{
					for (int i = 0; i < this.instances.Count; i++)
					{
						if (this.instances[i] != null)
						{
							Object.Destroy(this.instances[i].gameObject);
						}
					}
				}
				this.instances = new List<Text>();
			}
			this.numEntries = 0;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00007CC4 File Offset: 0x00005EC4
		public void SetDescription(string text, QuestState questState)
		{
			if (text == null)
			{
				return;
			}
			if (questState == QuestState.Active)
			{
				this.SetFirstValidTextElement(text, new Text[] { this.description });
				return;
			}
			if (questState == QuestState.Success)
			{
				this.SetFirstValidTextElement(text, new Text[]
				{
					this.alternateDescriptions.successDescription,
					this.description
				});
				return;
			}
			if (questState != QuestState.Failure)
			{
				return;
			}
			this.SetFirstValidTextElement(text, new Text[]
			{
				this.alternateDescriptions.failureDescription,
				this.description
			});
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00007D44 File Offset: 0x00005F44
		private void SetFirstValidTextElement(string text, params Text[] textElements)
		{
			for (int i = 0; i < textElements.Length; i++)
			{
				if (textElements[i] != null)
				{
					textElements[i].gameObject.SetActive(true);
					textElements[i].text = text;
					return;
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00007D84 File Offset: 0x00005F84
		public void AddEntryDescription(string text, QuestState entryState)
		{
			if (this.entryContainer == null)
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

		// Token: 0x06000154 RID: 340 RVA: 0x00007EDC File Offset: 0x000060DC
		private void InstantiateFirstValidTextElement(string text, Transform container, params Text[] textElements)
		{
			for (int i = 0; i < textElements.Length; i++)
			{
				if (textElements[i] != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(textElements[i].gameObject);
					gameObject.transform.SetParent(container.transform, false);
					gameObject.SetActive(true);
					Text component = gameObject.GetComponent<Text>();
					if (component != null)
					{
						component.text = text;
					}
					this.instances.Add(component);
					return;
				}
			}
		}

		// Token: 0x04000105 RID: 261
		[Header("Quest Heading")]
		[Tooltip("The heading - name or description depends on tracker setting")]
		public Text description;

		// Token: 0x04000106 RID: 262
		public UnityUIQuestTemplateAlternateDescriptions alternateDescriptions = new UnityUIQuestTemplateAlternateDescriptions();

		// Token: 0x04000107 RID: 263
		[Header("Quest Entries")]
		[Tooltip("(Optional) If set, holds instantiated quest entries")]
		public Transform entryContainer;

		// Token: 0x04000108 RID: 264
		[Tooltip("Used for quest entries")]
		public Text entryDescription;

		// Token: 0x04000109 RID: 265
		public UnityUIQuestTemplateAlternateDescriptions alternateEntryDescriptions = new UnityUIQuestTemplateAlternateDescriptions();

		// Token: 0x0400010A RID: 266
		private List<Text> instances;

		// Token: 0x0400010B RID: 267
		private int numEntries;
	}
}
