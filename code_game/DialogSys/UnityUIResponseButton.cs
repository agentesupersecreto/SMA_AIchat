using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200001E RID: 30
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Unity UI Response Button")]
	public class UnityUIResponseButton : MonoBehaviour
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003FB3 File Offset: 0x000021B3
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00003FD4 File Offset: 0x000021D4
		public string Text
		{
			get
			{
				if (!(this.label != null))
				{
					return string.Empty;
				}
				return this.label.text;
			}
			set
			{
				if (this.label != null)
				{
					this.label.text = UnityUITypewriterEffect.StripRPGMakerCodes(value);
					UITools.SendTextChangeMessage(this.label);
					return;
				}
				if (DialogueDebug.LogErrors)
				{
					Debug.LogError(string.Format("{0}: No Text UI element is unassigned on {1}", new object[] { "Dialogue System", base.name }));
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00004039 File Offset: 0x00002239
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00004056 File Offset: 0x00002256
		public bool clickable
		{
			get
			{
				return this.button != null && this.button.interactable;
			}
			set
			{
				if (this.button != null)
				{
					this.button.interactable = value;
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00004072 File Offset: 0x00002272
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000407A File Offset: 0x0000227A
		public bool visible { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00004083 File Offset: 0x00002283
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000408B File Offset: 0x0000228B
		public Response response { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00004094 File Offset: 0x00002294
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000409C File Offset: 0x0000229C
		public Transform target { get; set; }

		// Token: 0x060000A1 RID: 161 RVA: 0x000040A5 File Offset: 0x000022A5
		public void Reset()
		{
			this.Text = string.Empty;
			this.clickable = false;
			this.visible = false;
			this.response = null;
			this.SetColor(this.defaultColor);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000040D3 File Offset: 0x000022D3
		public void SetFormattedText(FormattedText formattedText)
		{
			if (formattedText != null)
			{
				this.Text = UITools.GetUIFormattedText(formattedText);
				this.SetColor((formattedText.emphases.Length != 0) ? formattedText.emphases[0].color : this.defaultColor);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000410C File Offset: 0x0000230C
		public void SetUnformattedText(string unformattedText)
		{
			this.Text = unformattedText;
			this.SetColor(this.defaultColor);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004124 File Offset: 0x00002324
		protected virtual void SetColor(Color currentColor)
		{
			if (!(this.button != null) && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: No Button is assigned to {1}", new object[] { "Dialogue System", base.name }));
			}
			if (this.label != null)
			{
				if (this.setLabelColor)
				{
					this.label.color = currentColor;
					return;
				}
			}
			else if (DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: No Text is assigned to {1}", new object[] { "Dialogue System", base.name }));
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000041BC File Offset: 0x000023BC
		public void OnClick()
		{
			if (this.target != null)
			{
				this.target.SendMessage("OnClick", this.response, SendMessageOptions.RequireReceiver);
			}
		}

		// Token: 0x0400005F RID: 95
		public Button button;

		// Token: 0x04000060 RID: 96
		public Text label;

		// Token: 0x04000061 RID: 97
		[Tooltip("Set the button's text to this color by default")]
		public Color defaultColor = Color.white;

		// Token: 0x04000062 RID: 98
		[Tooltip("Apply emphasis tag colors to the button background")]
		public bool setButtonColor;

		// Token: 0x04000063 RID: 99
		[Tooltip("Apply emphasis tag colors to the button text")]
		public bool setLabelColor = true;
	}
}
