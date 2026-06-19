using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000243 RID: 579
	[AddComponentMenu("")]
	public class SequencerCommandQTE : SequencerCommand
	{
		// Token: 0x060019DF RID: 6623 RVA: 0x0002AF0C File Offset: 0x0002910C
		public void Start()
		{
			this.index = base.GetParameterAsInt(0, 0);
			DialogueManager.DialogueUI.ShowQTEIndicator(this.index);
			this.button = ((this.index >= DialogueManager.DisplaySettings.inputSettings.qteButtons.Length) ? null : DialogueManager.DisplaySettings.inputSettings.qteButtons[this.index]);
			float parameterAsFloat = base.GetParameterAsFloat(1, 0f);
			this.stopTime = DialogueTime.time + parameterAsFloat;
			this.variableName = base.GetParameter(2, null);
			this.variableQTEValue = base.GetParameter(3, null);
			this.variableType = this.GetVariableType();
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: QTE(index={1}, {2}sec, {3}, {4})", new object[] { "Dialogue System", this.index, parameterAsFloat, this.variableName, this.variableQTEValue }));
			}
			Lua.Run(string.Format("Variable[\"{0}\"] = \"\"", new object[] { this.variableName }), DialogueDebug.LogInfo);
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x0002B02C File Offset: 0x0002922C
		private FieldType GetVariableType()
		{
			if (string.Compare(this.variableQTEValue, "true", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(this.variableQTEValue, "false", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return FieldType.Boolean;
			}
			float num;
			if (float.TryParse(this.variableQTEValue, out num))
			{
				return FieldType.Number;
			}
			return FieldType.Text;
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x0002B07C File Offset: 0x0002927C
		public void Update()
		{
			if (!string.IsNullOrEmpty(this.button) && DialogueManager.GetInputButtonDown(this.button))
			{
				Lua.Run(string.Format("Variable[\"{0}\"] = {1}", new object[]
				{
					this.variableName,
					DialogueLua.ValueAsString(this.variableType, this.variableQTEValue)
				}), DialogueDebug.LogInfo);
				DialogueManager.Instance.SendMessage("OnConversationContinueAll", SendMessageOptions.DontRequireReceiver);
				base.Stop();
			}
			else if (DialogueTime.time >= this.stopTime)
			{
				base.Stop();
			}
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x0002B118 File Offset: 0x00029318
		public void OnDestroy()
		{
			DialogueManager.DialogueUI.HideQTEIndicator(this.index);
		}

		// Token: 0x04000E79 RID: 3705
		private int index;

		// Token: 0x04000E7A RID: 3706
		private float stopTime;

		// Token: 0x04000E7B RID: 3707
		private string button;

		// Token: 0x04000E7C RID: 3708
		private string variableName;

		// Token: 0x04000E7D RID: 3709
		private string variableQTEValue;

		// Token: 0x04000E7E RID: 3710
		private FieldType variableType;
	}
}
