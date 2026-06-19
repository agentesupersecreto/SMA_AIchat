using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000245 RID: 581
	[AddComponentMenu("")]
	public class SequencerCommandTextInput : SequencerCommand
	{
		// Token: 0x060019E6 RID: 6630 RVA: 0x0002B1FC File Offset: 0x000293FC
		public void Start()
		{
			Transform subject = base.GetSubject(0, null);
			if (subject != null)
			{
				bool activeSelf = subject.gameObject.activeSelf;
				if (!activeSelf)
				{
					subject.gameObject.SetActive(true);
				}
				this.textFieldUI = subject.GetComponent(typeof(ITextFieldUI)) as ITextFieldUI;
				if (!activeSelf)
				{
					subject.gameObject.SetActive(false);
				}
			}
			string text = base.GetParameter(1, null);
			this.variableName = base.GetParameter(2, null);
			int parameterAsInt = base.GetParameterAsInt(3, 0);
			bool flag = string.Equals(base.GetParameter(4, null), "clear");
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: TextInput({1}, {2}, {3}, {4})", new object[]
				{
					"Dialogue System",
					Tools.GetObjectName(subject),
					text,
					this.variableName,
					parameterAsInt
				}));
			}
			if (this.textFieldUI != null)
			{
				if (text.StartsWith("var="))
				{
					text = DialogueLua.GetVariable(text.Substring(4)).AsString;
				}
				string text2 = ((!flag) ? DialogueLua.GetVariable(this.variableName).AsString : string.Empty);
				this.textFieldUI.StartTextInput(text, text2, parameterAsInt, new AcceptedTextDelegate(this.OnAcceptedText));
			}
			else
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.Log(string.Format("{0}: Sequencer: TextInput(): Text Field UI not found on a GameObject '{1}'. Did you specify the correct GameObject name?", new object[]
					{
						"Dialogue System",
						base.GetParameter(0, null)
					}));
				}
				base.Stop();
			}
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x0002B394 File Offset: 0x00029594
		public void OnAcceptedText(string text)
		{
			if (!this.acceptedText)
			{
				Variable variable = DialogueManager.MasterDatabase.GetVariable(this.variableName);
				if (variable != null && variable.Type == FieldType.Number)
				{
					float num = Tools.StringToFloat(text);
					DialogueLua.SetVariable(this.variableName, num);
				}
				else
				{
					DialogueLua.SetVariable(this.variableName, text);
				}
			}
			this.acceptedText = true;
			base.Stop();
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x0002B408 File Offset: 0x00029608
		public void OnDestroy()
		{
			if (!this.acceptedText && this.textFieldUI != null)
			{
				this.textFieldUI.CancelTextInput();
			}
		}

		// Token: 0x04000E7F RID: 3711
		private ITextFieldUI textFieldUI;

		// Token: 0x04000E80 RID: 3712
		private string variableName = string.Empty;

		// Token: 0x04000E81 RID: 3713
		private bool acceptedText;
	}
}
