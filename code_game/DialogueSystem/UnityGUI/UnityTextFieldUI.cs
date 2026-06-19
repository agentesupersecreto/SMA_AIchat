using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002D4 RID: 724
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Dialogue/Unity Text Field UI (Legacy Unity GUI)")]
	public class UnityTextFieldUI : MonoBehaviour, ITextFieldUI
	{
		// Token: 0x06001DB2 RID: 7602 RVA: 0x0003A6EC File Offset: 0x000388EC
		public void Awake()
		{
			this.control = base.GetComponent<GUIControl>();
			if (this.control == null)
			{
				this.control = base.gameObject.AddComponent<GUIControl>();
			}
			this.control.visible = false;
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x0003A734 File Offset: 0x00038934
		public void StartTextInput(string labelText, string text, int maxLength, AcceptedTextDelegate acceptedText)
		{
			if (this.label != null)
			{
				this.label.text = labelText;
			}
			if (this.textField != null)
			{
				this.textField.text = text;
				this.textField.maxLength = maxLength;
				this.textField.TakeFocus();
				this.ignoreFirstAccept = this.acceptKey != KeyCode.None && Input.GetKeyDown(this.acceptKey);
				this.ignoreFirstCancel = this.cancelKey != KeyCode.None && Input.GetKeyDown(this.cancelKey);
			}
			this.acceptedText = acceptedText;
			this.Show();
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x0003A7E0 File Offset: 0x000389E0
		private void OnGUI()
		{
			if (this.control.visible)
			{
				if (this.textField != null)
				{
					this.textField.TakeFocus();
				}
				if (this.IsAcceptKey())
				{
					if (this.ignoreFirstAccept)
					{
						this.ignoreFirstAccept = false;
					}
					else
					{
						Event.current.Use();
						this.AcceptTextInput();
					}
				}
				else if (Event.current.isKey && this.cancelKey != KeyCode.None && Event.current.keyCode == this.cancelKey)
				{
					if (this.ignoreFirstCancel)
					{
						this.ignoreFirstCancel = false;
					}
					else
					{
						Event.current.Use();
						this.CancelTextInput();
					}
				}
			}
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x0003A8A8 File Offset: 0x00038AA8
		private bool IsAcceptKey()
		{
			if (this.IsKeyCodeReturn(this.acceptKey))
			{
				return Event.current.Equals(Event.KeyboardEvent("[enter]")) || Event.current.Equals(Event.KeyboardEvent("return")) || (Event.current.isKey && Event.current.keyCode == KeyCode.KeypadEnter) || (Event.current.isKey && Event.current.keyCode == KeyCode.Return) || (Event.current.type == EventType.KeyDown && Event.current.character == '\n');
			}
			return this.acceptKey != KeyCode.None && Event.current.keyCode == this.acceptKey;
		}

		// Token: 0x06001DB6 RID: 7606 RVA: 0x0003A980 File Offset: 0x00038B80
		private bool IsKeyCodeReturn(KeyCode keyCode)
		{
			return keyCode == KeyCode.KeypadEnter || keyCode == KeyCode.Return;
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x0003A998 File Offset: 0x00038B98
		public void CancelTextInput()
		{
			this.Hide();
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x0003A9A0 File Offset: 0x00038BA0
		private void AcceptTextInput()
		{
			this.Hide();
			if (this.acceptedText != null)
			{
				if (this.IsKeyCodeReturn(this.acceptKey))
				{
					this.textField.text = this.textField.text.Replace("\n", string.Empty);
				}
				if (this.textField != null)
				{
					this.acceptedText(this.textField.text);
				}
				this.acceptedText = null;
			}
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x0003AA24 File Offset: 0x00038C24
		public void OnAccept(object data)
		{
			this.AcceptTextInput();
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x0003AA2C File Offset: 0x00038C2C
		public void OnCancel(object data)
		{
			this.CancelTextInput();
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x0003AA34 File Offset: 0x00038C34
		private void Show()
		{
			this.SetControlsActive(true);
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0003AA40 File Offset: 0x00038C40
		private void Hide()
		{
			this.SetControlsActive(false);
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x0003AA4C File Offset: 0x00038C4C
		private void SetControlsActive(bool value)
		{
			this.control.visible = value;
			UnityDialogueUIControls.SetControlActive(this.label, value);
			UnityDialogueUIControls.SetControlActive(this.textField, value);
			UnityDialogueUIControls.SetControlActive(this.panel, value);
		}

		// Token: 0x0400113F RID: 4415
		public GUIControl panel;

		// Token: 0x04001140 RID: 4416
		public GUILabel label;

		// Token: 0x04001141 RID: 4417
		public GUITextField textField;

		// Token: 0x04001142 RID: 4418
		public KeyCode acceptKey = KeyCode.Return;

		// Token: 0x04001143 RID: 4419
		public KeyCode cancelKey;

		// Token: 0x04001144 RID: 4420
		private AcceptedTextDelegate acceptedText;

		// Token: 0x04001145 RID: 4421
		private GUIControl control;

		// Token: 0x04001146 RID: 4422
		private bool ignoreFirstAccept;

		// Token: 0x04001147 RID: 4423
		private bool ignoreFirstCancel;
	}
}
