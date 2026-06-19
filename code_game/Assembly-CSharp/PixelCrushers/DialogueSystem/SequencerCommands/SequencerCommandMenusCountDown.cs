using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200003B RID: 59
	public class SequencerCommandMenusCountDown : SequencerCommand
	{
		// Token: 0x06000125 RID: 293 RVA: 0x0000ADCC File Offset: 0x00008FCC
		public void Start()
		{
			try
			{
				this.m_duration = base.GetParameterAsFloat(0, 5f);
				this.m_startTime = Time.time;
				this.m_originalText = Singleton<DialogueSystemCurrentLine>.instance.currentResponses.Select((Response r) => r.formattedText.text).ToArray<string>();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				base.Stop();
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000AE50 File Offset: 0x00009050
		public void Update()
		{
			try
			{
				IReadOnlyList<Response> currentResponses = Singleton<DialogueSystemCurrentLine>.instance.currentResponses;
				if (currentResponses == null)
				{
					base.Stop();
				}
				else
				{
					float num = Time.time - this.m_startTime;
					int num2 = Mathf.CeilToInt(this.m_duration - num);
					int num3 = Mathf.Min(this.m_originalText.Length, currentResponses.Count);
					for (int i = 0; i < num3; i++)
					{
						currentResponses[i].formattedText.text = this.m_originalText[i] + " (" + num2.ToString() + ")";
					}
					UnityUIDialogueUI unityUIDialogueUI = DialogueManager.DialogueUI as UnityUIDialogueUI;
					if (unityUIDialogueUI != null)
					{
						UnityUIResponseMenuControls responseMenu = unityUIDialogueUI.dialogue.responseMenu;
						for (int j = 0; j < currentResponses.Count; j++)
						{
							string text = this.m_originalText[j] + " (" + num2.ToString() + ")";
							currentResponses[j].formattedText.text = text;
							if (j < responseMenu.instantiatedButtons.Count)
							{
								GameObject gameObject = responseMenu.instantiatedButtons[j];
								if (gameObject != null)
								{
									UnityUIResponseButton component = gameObject.GetComponent<UnityUIResponseButton>();
									if (component != null && component.label != null)
									{
										component.label.text = text;
									}
								}
							}
						}
					}
					if (num > this.m_duration)
					{
						base.Stop();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				base.Stop();
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000AFF4 File Offset: 0x000091F4
		public void OnDestroy()
		{
		}

		// Token: 0x040000AA RID: 170
		private string[] m_originalText;

		// Token: 0x040000AB RID: 171
		private float m_startTime;

		// Token: 0x040000AC RID: 172
		private float m_duration;
	}
}
