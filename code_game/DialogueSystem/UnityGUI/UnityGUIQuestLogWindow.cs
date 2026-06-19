using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x02000272 RID: 626
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Quest/Unity GUI Quest Log Window (Legacy Unity GUI)")]
	public class UnityGUIQuestLogWindow : QuestLogWindow
	{
		// Token: 0x06001B24 RID: 6948 RVA: 0x0002F248 File Offset: 0x0002D448
		public override void Awake()
		{
			base.Awake();
			if (this.guiRoot == null)
			{
				this.guiRoot = base.GetComponentInChildren<GUIRoot>();
			}
			if (this.scrollView == null)
			{
				this.scrollView = base.GetComponentInChildren<GUIScrollView>();
			}
			if (this.scrollView != null)
			{
				this.scrollView.MeasureContentHandler += this.OnMeasureContent;
				this.scrollView.DrawContentHandler += this.OnDrawContent;
			}
			if (string.IsNullOrEmpty(this.groupHeadingGuiStyleName))
			{
				this.groupHeadingGuiStyleName = this.questHeadingGuiStyleName;
			}
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x0002F2F0 File Offset: 0x0002D4F0
		public void Start()
		{
			if (this.guiRoot != null)
			{
				this.guiRoot.gameObject.SetActive(false);
			}
		}

		// Token: 0x06001B26 RID: 6950 RVA: 0x0002F320 File Offset: 0x0002D520
		public override void OpenWindow(Action openedWindowHandler)
		{
			if (this.guiRoot != null)
			{
				this.guiRoot.gameObject.SetActive(true);
				if (this.abandonQuestPopup != null && this.abandonQuestPopup.panel != null)
				{
					this.abandonQuestPopup.panel.gameObject.SetActive(false);
				}
				this.guiRoot.ManualRefresh();
			}
			openedWindowHandler();
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x0002F398 File Offset: 0x0002D598
		public override void CloseWindow(Action closedWindowHandler)
		{
			if (this.guiRoot != null)
			{
				this.guiRoot.gameObject.SetActive(false);
			}
			closedWindowHandler();
		}

		// Token: 0x06001B28 RID: 6952 RVA: 0x0002F3D0 File Offset: 0x0002D5D0
		public override void ConfirmAbandonQuest(string title, Action confirmAbandonQuestHandler)
		{
			this.confirmAbandonQuestHandler = confirmAbandonQuestHandler;
			this.OpenAbandonQuestPopup(title);
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x0002F3E0 File Offset: 0x0002D5E0
		private void OpenAbandonQuestPopup(string title)
		{
			if (this.abandonQuestPopup.panel == null)
			{
				if (this.confirmAbandonQuestHandler != null)
				{
					this.confirmAbandonQuestHandler();
				}
			}
			else
			{
				if (this.abandonQuestPopup.questTitleLabel != null)
				{
					this.abandonQuestPopup.questTitleLabel.text = title;
				}
				this.abandonQuestPopup.panel.gameObject.SetActive(true);
			}
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x0002F45C File Offset: 0x0002D65C
		private void CloseAbandonQuestPopup()
		{
			if (this.abandonQuestPopup.panel != null)
			{
				this.abandonQuestPopup.panel.gameObject.SetActive(false);
			}
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x0002F498 File Offset: 0x0002D698
		public void ClickConfirmAbandonQuest(object data)
		{
			this.CloseAbandonQuestPopup();
			if (this.confirmAbandonQuestHandler != null)
			{
				this.confirmAbandonQuestHandler();
			}
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x0002F4B8 File Offset: 0x0002D6B8
		public void ClickCancelAbandonQuest(object data)
		{
			this.CloseAbandonQuestPopup();
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x0002F4C0 File Offset: 0x0002D6C0
		public void OnMeasureContent()
		{
			this.MeasureQuestContent();
		}

		// Token: 0x06001B2E RID: 6958 RVA: 0x0002F4C8 File Offset: 0x0002D6C8
		public void OnDrawContent()
		{
			this.DrawQuests();
		}

		// Token: 0x06001B2F RID: 6959 RVA: 0x0002F4D0 File Offset: 0x0002D6D0
		private void MeasureQuestContent()
		{
			float num = (float)this.padding;
			string text = null;
			bool flag = false;
			foreach (QuestLogWindow.QuestInfo questInfo in base.Quests)
			{
				if (!string.Equals(questInfo.Group, text))
				{
					text = questInfo.Group;
					if (!string.IsNullOrEmpty(text))
					{
						num += this.GroupHeadingHeight(text);
						flag = this.collapsedGroups.Contains(text);
					}
				}
				if (!flag)
				{
					num += this.QuestHeadingHeight(questInfo);
					if (this.IsSelectedQuest(questInfo))
					{
						num += this.QuestDescriptionHeight(questInfo);
						num += this.QuestEntriesHeight(questInfo);
						num += this.QuestButtonsHeight(questInfo);
					}
				}
			}
			num += (float)this.padding;
			if (this.scrollView != null)
			{
				this.scrollView.contentHeight = num;
			}
		}

		// Token: 0x06001B30 RID: 6960 RVA: 0x0002F5AC File Offset: 0x0002D7AC
		public override void OnQuestListUpdated()
		{
			if (this.activeButton != null)
			{
				this.activeButton.clickable = !base.IsShowingActiveQuests;
			}
			if (this.completedButton != null)
			{
				this.completedButton.clickable = base.IsShowingActiveQuests;
			}
		}

		// Token: 0x06001B31 RID: 6961 RVA: 0x0002F600 File Offset: 0x0002D800
		private GUIStyle UseGUIStyle(GUIStyle guiStyle, string guiStyleName, GUIStyle defaultStyle)
		{
			return (guiStyle == null) ? UnityGUITools.GetGUIStyle(guiStyleName, defaultStyle) : guiStyle;
		}

		// Token: 0x06001B32 RID: 6962 RVA: 0x0002F618 File Offset: 0x0002D818
		private GUIStyle GetGroupHeadingStyle()
		{
			return this.UseGUIStyle(this.groupHeadingStyle, this.groupHeadingGuiStyleName, GUI.skin.button);
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x0002F638 File Offset: 0x0002D838
		private GUIStyle GetQuestHeadingStyle(bool isSelectedQuest)
		{
			if (isSelectedQuest && !string.IsNullOrEmpty(this.questHeadingOpenGuiStyleName))
			{
				this.questHeadingOpenStyle = this.UseGUIStyle(this.questHeadingOpenStyle, this.questHeadingOpenGuiStyleName, GUI.skin.button);
				return this.questHeadingOpenStyle;
			}
			this.questHeadingStyle = this.UseGUIStyle(this.questHeadingStyle, this.questHeadingGuiStyleName, GUI.skin.button);
			return this.questHeadingStyle;
		}

		// Token: 0x06001B34 RID: 6964 RVA: 0x0002F6AC File Offset: 0x0002D8AC
		private GUIStyle GetQuestEntryStyle(QuestState entryState)
		{
			this.questEntryActiveStyle = this.UseGUIStyle(this.questEntryActiveStyle, this.questEntryActiveGuiStyleName, GUI.skin.label);
			this.questEntrySuccessStyle = this.UseGUIStyle(this.questEntrySuccessStyle, this.questEntrySuccessGuiStyleName, GUI.skin.label);
			this.questEntryFailureStyle = this.UseGUIStyle(this.questEntryFailureStyle, this.questEntryFailureGuiStyleName, GUI.skin.label);
			if (entryState == QuestState.Success)
			{
				return this.questEntrySuccessStyle;
			}
			if (entryState != QuestState.Failure)
			{
				return this.questEntryActiveStyle;
			}
			return this.questEntryFailureStyle;
		}

		// Token: 0x06001B35 RID: 6965 RVA: 0x0002F748 File Offset: 0x0002D948
		private float GroupHeadingHeight(string group)
		{
			return this.GetGroupHeadingStyle().CalcHeight(new GUIContent(group), this.scrollView.contentWidth - (float)(2 * this.padding));
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x0002F77C File Offset: 0x0002D97C
		private float QuestHeadingHeight(QuestLogWindow.QuestInfo questInfo)
		{
			return Mathf.Max(this.activeButton.rect.height, this.GetQuestHeadingStyle(this.IsSelectedQuest(questInfo)).CalcHeight(new GUIContent(questInfo.Heading.text), this.scrollView.contentWidth - (float)(2 * this.padding)));
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x0002F7D8 File Offset: 0x0002D9D8
		private float QuestDescriptionHeight(QuestLogWindow.QuestInfo questInfo)
		{
			this.questBodyStyle = this.UseGUIStyle(this.questBodyStyle, this.questBodyGuiStyleName, GUI.skin.label);
			if (this.questHeadingSource == QuestLogWindow.QuestHeadingSource.Name)
			{
				return this.questBodyStyle.CalcHeight(new GUIContent(questInfo.Description.text), this.scrollView.contentWidth - (float)(2 * this.padding));
			}
			return 0f;
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x0002F848 File Offset: 0x0002DA48
		private float QuestEntriesHeight(QuestLogWindow.QuestInfo questInfo)
		{
			float num = 0f;
			for (int i = 0; i < questInfo.Entries.Length; i++)
			{
				QuestState questState = questInfo.EntryStates[i];
				GUIStyle questEntryStyle = this.GetQuestEntryStyle(questState);
				if (questState != QuestState.Unassigned)
				{
					string text = questInfo.Entries[i].text;
					num += questEntryStyle.CalcHeight(new GUIContent(text), this.scrollView.contentWidth - (float)(2 * this.padding));
				}
			}
			return num;
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x0002F8C4 File Offset: 0x0002DAC4
		private float QuestButtonsHeight(QuestLogWindow.QuestInfo questInfo)
		{
			if (questInfo.Trackable || questInfo.Abandonable)
			{
				this.questButtonStyle = this.UseGUIStyle(this.questButtonStyle, this.questEntryButtonStyleName, GUI.skin.button);
				this.questButtonStyle.wordWrap = false;
				return this.questButtonStyle.CalcHeight(new GUIContent("Abandon"), this.scrollView.contentWidth - (float)(2 * this.padding));
			}
			return 0f;
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x0002F948 File Offset: 0x0002DB48
		private void DrawQuests()
		{
			if (this.scrollView != null)
			{
				float num = (float)this.padding;
				string text = null;
				bool flag = false;
				foreach (QuestLogWindow.QuestInfo questInfo in base.Quests)
				{
					if (!string.Equals(questInfo.Group, text))
					{
						text = questInfo.Group;
						if (!string.IsNullOrEmpty(text))
						{
							flag = this.collapsedGroups.Contains(text);
							float num2 = this.GroupHeadingHeight(text);
							if (GUI.Button(new Rect((float)this.padding, num, this.scrollView.contentWidth - (float)(2 * this.padding), num2), text, this.GetGroupHeadingStyle()))
							{
								this.ClickQuestGroup(text);
							}
							num += num2;
						}
					}
					if (!flag)
					{
						bool flag2 = this.IsSelectedQuest(questInfo);
						float num3 = this.QuestHeadingHeight(questInfo);
						if (GUI.Button(new Rect((float)this.padding, num, this.scrollView.contentWidth - (float)(2 * this.padding), num3), questInfo.Heading.text, this.GetQuestHeadingStyle(flag2)))
						{
							this.ClickQuest(questInfo.Title);
						}
						num += num3;
						if (flag2)
						{
							num = this.DrawQuestDescription(questInfo, num);
							num = this.DrawQuestEntries(questInfo, num);
							num = this.DrawQuestButtons(questInfo, num);
						}
					}
				}
				if (base.Quests.Length == 0)
				{
					GUIStyle guistyle = UnityGUITools.GetGUIStyle(this.noQuestsGuiStyleName, GUI.skin.label);
					float num4 = guistyle.CalcHeight(new GUIContent(base.NoQuestsMessage), this.scrollView.contentWidth - 4f);
					GUI.Label(new Rect(2f, num, this.scrollView.contentWidth, num4), base.NoQuestsMessage, guistyle);
					num += num4;
				}
			}
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x0002FB14 File Offset: 0x0002DD14
		private float DrawQuestDescription(QuestLogWindow.QuestInfo questInfo, float contentY)
		{
			if (this.questHeadingSource == QuestLogWindow.QuestHeadingSource.Name)
			{
				this.questBodyStyle = this.UseGUIStyle(this.questBodyStyle, this.questBodyGuiStyleName, GUI.skin.label);
				float num = this.questBodyStyle.CalcHeight(new GUIContent(questInfo.Description.text), this.scrollView.contentWidth - (float)(2 * this.padding));
				GUI.Label(new Rect((float)this.padding, contentY, this.scrollView.contentWidth, num), questInfo.Description.text, this.questBodyStyle);
				return contentY + num;
			}
			return contentY;
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x0002FBB4 File Offset: 0x0002DDB4
		private float DrawQuestEntries(QuestLogWindow.QuestInfo questInfo, float contentY)
		{
			float num = contentY;
			for (int i = 0; i < questInfo.Entries.Length; i++)
			{
				QuestState questState = questInfo.EntryStates[i];
				if (questState != QuestState.Unassigned)
				{
					string text = questInfo.Entries[i].text;
					GUIStyle questEntryStyle = this.GetQuestEntryStyle(questState);
					float num2 = questEntryStyle.CalcHeight(new GUIContent(text), this.scrollView.contentWidth - (float)(2 * this.padding));
					GUI.Label(new Rect((float)this.padding, num, this.scrollView.contentWidth, num2), text, questEntryStyle);
					num += num2;
				}
			}
			return num;
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x0002FC50 File Offset: 0x0002DE50
		private float DrawQuestButtons(QuestLogWindow.QuestInfo questInfo, float contentY)
		{
			float num = contentY;
			if (this.currentQuestStateMask == QuestState.Active && (questInfo.Trackable || questInfo.Abandonable))
			{
				this.questButtonStyle = this.UseGUIStyle(this.questButtonStyle, this.questEntryButtonStyleName, GUI.skin.button);
				this.questButtonStyle.wordWrap = false;
				string localizedText = this.GetLocalizedText("Track");
				Vector2 vector = this.questButtonStyle.CalcSize(new GUIContent(localizedText));
				float y = vector.y;
				float x = vector.x;
				string localizedText2 = this.GetLocalizedText("Abandon");
				float x2 = this.questButtonStyle.CalcSize(new GUIContent(localizedText2)).x;
				float num2 = this.scrollView.contentWidth - (float)(2 * this.padding);
				float num3 = num2 - x2;
				float num4 = ((!questInfo.Abandonable) ? num2 : (num3 - (float)this.padding));
				num4 -= x;
				if (questInfo.Trackable && GUI.Button(new Rect(num4, num, x, y), localizedText))
				{
					this.ClickTrackQuest(questInfo.Title);
				}
				if (questInfo.Abandonable && GUI.Button(new Rect(num3, num, x2, y), localizedText2))
				{
					this.ClickAbandonQuest(questInfo.Title);
				}
				num += this.questButtonStyle.CalcHeight(new GUIContent("Abandon"), this.scrollView.contentWidth - (float)(2 * this.padding));
			}
			return num;
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x0002FDD4 File Offset: 0x0002DFD4
		private void ClickQuestGroup(string group)
		{
			if (this.collapsedGroups.Contains(group))
			{
				this.collapsedGroups.Remove(group);
			}
			else
			{
				this.collapsedGroups.Add(group);
			}
		}

		// Token: 0x04000F36 RID: 3894
		public GUIRoot guiRoot;

		// Token: 0x04000F37 RID: 3895
		public GUIScrollView scrollView;

		// Token: 0x04000F38 RID: 3896
		public GUIButton activeButton;

		// Token: 0x04000F39 RID: 3897
		public GUIButton completedButton;

		// Token: 0x04000F3A RID: 3898
		public UnityGUIQuestLogWindow.AbandonControls abandonQuestPopup = new UnityGUIQuestLogWindow.AbandonControls();

		// Token: 0x04000F3B RID: 3899
		public string groupHeadingGuiStyleName;

		// Token: 0x04000F3C RID: 3900
		public string questHeadingGuiStyleName;

		// Token: 0x04000F3D RID: 3901
		public string questHeadingOpenGuiStyleName;

		// Token: 0x04000F3E RID: 3902
		public string questBodyGuiStyleName;

		// Token: 0x04000F3F RID: 3903
		public string questEntryActiveGuiStyleName;

		// Token: 0x04000F40 RID: 3904
		public string questEntrySuccessGuiStyleName;

		// Token: 0x04000F41 RID: 3905
		public string questEntryFailureGuiStyleName;

		// Token: 0x04000F42 RID: 3906
		public string questEntryButtonStyleName;

		// Token: 0x04000F43 RID: 3907
		public string noQuestsGuiStyleName;

		// Token: 0x04000F44 RID: 3908
		public int padding = 2;

		// Token: 0x04000F45 RID: 3909
		private GUIStyle groupHeadingStyle;

		// Token: 0x04000F46 RID: 3910
		private GUIStyle questHeadingStyle;

		// Token: 0x04000F47 RID: 3911
		private GUIStyle questHeadingOpenStyle;

		// Token: 0x04000F48 RID: 3912
		private GUIStyle questBodyStyle;

		// Token: 0x04000F49 RID: 3913
		private GUIStyle questEntryActiveStyle;

		// Token: 0x04000F4A RID: 3914
		private GUIStyle questEntrySuccessStyle;

		// Token: 0x04000F4B RID: 3915
		private GUIStyle questEntryFailureStyle;

		// Token: 0x04000F4C RID: 3916
		private GUIStyle questButtonStyle;

		// Token: 0x04000F4D RID: 3917
		private Action confirmAbandonQuestHandler;

		// Token: 0x04000F4E RID: 3918
		private List<string> collapsedGroups = new List<string>();

		// Token: 0x02000273 RID: 627
		[Serializable]
		public class AbandonControls
		{
			// Token: 0x04000F4F RID: 3919
			public GUIControl panel;

			// Token: 0x04000F50 RID: 3920
			public GUILabel questTitleLabel;

			// Token: 0x04000F51 RID: 3921
			public GUIButton ok;

			// Token: 0x04000F52 RID: 3922
			public GUIButton cancel;
		}
	}
}
