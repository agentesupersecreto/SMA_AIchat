using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000022 RID: 34
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUIDialogueUITextFieldUI")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Unity UI Text Field UI")]
	public class UnityUITextFieldUI : MonoBehaviour, ITextFieldUI
	{
		// Token: 0x060000CD RID: 205 RVA: 0x000050F4 File Offset: 0x000032F4
		private void Start()
		{
			if (DialogueDebug.LogWarnings && this.textField == null)
			{
				Debug.LogWarning(string.Format("{0}: No InputField is assigned to the text field UI {1}. TextInput() sequencer commands or [var?=] won't work.", new object[] { "Dialogue System", base.name }));
			}
			this.Hide();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005144 File Offset: 0x00003344
		public void StartTextInput(string labelText, string text, int maxLength, AcceptedTextDelegate acceptedText)
		{
			if (this.label != null)
			{
				this.label.text = labelText;
			}
			if (this.textField != null)
			{
				this.textField.text = text;
				this.textField.characterLimit = maxLength;
			}
			this.acceptedText = acceptedText;
			this.Show();
			this.isAwaitingInput = true;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000051A6 File Offset: 0x000033A6
		public void Update()
		{
			if (this.isAwaitingInput && !DialogueManager.IsDialogueSystemInputDisabled())
			{
				if (Input.GetKeyDown(this.acceptKey))
				{
					this.AcceptTextInput();
					return;
				}
				if (Input.GetKeyDown(this.cancelKey))
				{
					this.CancelTextInput();
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000051DE File Offset: 0x000033DE
		public void CancelTextInput()
		{
			this.isAwaitingInput = false;
			this.Hide();
			this.onCancel.Invoke();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000051F8 File Offset: 0x000033F8
		public void AcceptTextInput()
		{
			this.isAwaitingInput = false;
			if (this.acceptedText != null)
			{
				if (this.textField != null)
				{
					this.acceptedText(this.textField.text);
				}
				this.acceptedText = null;
			}
			this.Hide();
			this.onAccept.Invoke();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005250 File Offset: 0x00003450
		private void Show()
		{
			this.SetActive(true);
			if (this.textField != null)
			{
				if (this.showTouchScreenKeyboard)
				{
					this.touchScreenKeyboard = TouchScreenKeyboard.Open(this.textField.text);
				}
				this.textField.ActivateInputField();
				if (EventSystem.current != null)
				{
					EventSystem.current.SetSelectedGameObject(this.textField.gameObject, null);
				}
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000052BE File Offset: 0x000034BE
		private void Hide()
		{
			this.SetActive(false);
			if (this.touchScreenKeyboard != null)
			{
				this.touchScreenKeyboard.active = false;
				this.touchScreenKeyboard = null;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000052E4 File Offset: 0x000034E4
		private void SetActive(bool value)
		{
			if (this.textField != null)
			{
				this.textField.enabled = value;
			}
			if (this.panel != null)
			{
				Tools.SetGameObjectActive(this.panel, value);
				return;
			}
			Tools.SetGameObjectActive(this.label, value);
			Tools.SetGameObjectActive(this.textField, value);
		}

		// Token: 0x0400008A RID: 138
		[Tooltip("Optional panel containing the UI elements")]
		public Graphic panel;

		// Token: 0x0400008B RID: 139
		[Tooltip("Optional text element for prompt")]
		public Text label;

		// Token: 0x0400008C RID: 140
		public InputField textField;

		// Token: 0x0400008D RID: 141
		[Tooltip("Optional key code that accepts the input")]
		public KeyCode acceptKey = KeyCode.Return;

		// Token: 0x0400008E RID: 142
		[Tooltip("Optional key code that cancels the input")]
		public KeyCode cancelKey = KeyCode.Escape;

		// Token: 0x0400008F RID: 143
		[Tooltip("Automatically open touchscreen keyboard")]
		public bool showTouchScreenKeyboard;

		// Token: 0x04000090 RID: 144
		public UnityEvent onAccept = new UnityEvent();

		// Token: 0x04000091 RID: 145
		public UnityEvent onCancel = new UnityEvent();

		// Token: 0x04000092 RID: 146
		private AcceptedTextDelegate acceptedText;

		// Token: 0x04000093 RID: 147
		private bool isAwaitingInput;

		// Token: 0x04000094 RID: 148
		private TouchScreenKeyboard touchScreenKeyboard;
	}
}
