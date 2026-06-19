using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000017 RID: 23
	public class NewGameInputDialog : CustomMonobehaviour
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000030D7 File Offset: 0x000012D7
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000030DF File Offset: 0x000012DF
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000030E7 File Offset: 0x000012E7
		public Button cancelar
		{
			get
			{
				return this.m_cancelar;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000030EF File Offset: 0x000012EF
		public TMP_InputField inputField
		{
			get
			{
				return this.m_InputField;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000030F7 File Offset: 0x000012F7
		public Slider slider
		{
			get
			{
				return this.m_Slider;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003100 File Offset: 0x00001300
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_pregunta == null)
			{
				throw new ArgumentNullException("m_pregunta", "m_pregunta null reference.");
			}
			if (this.aceptar == null)
			{
				throw new ArgumentNullException("aceptar", "aceptar null reference.");
			}
			if (this.cancelar == null)
			{
				throw new ArgumentNullException("cancelar", "cancelar null reference.");
			}
			if (this.inputField == null)
			{
				throw new ArgumentNullException("inputField", "inputField null reference.");
			}
			if (this.m_Slider == null)
			{
				throw new ArgumentNullException("m_Slider", "m_Slider null reference.");
			}
			this.m_InputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.m_InputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000031E1 File Offset: 0x000013E1
		private void OnValueChanged(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000031EA File Offset: 0x000013EA
		private void OnEndEdit(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000031F3 File Offset: 0x000013F3
		private void Check(string value)
		{
			this.aceptar.interactable = !string.IsNullOrWhiteSpace(value);
		}

		// Token: 0x0400003B RID: 59
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x0400003C RID: 60
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x0400003D RID: 61
		[SerializeField]
		private Button m_cancelar;

		// Token: 0x0400003E RID: 62
		[SerializeField]
		private TMP_InputField m_InputField;

		// Token: 0x0400003F RID: 63
		[SerializeField]
		private Slider m_Slider;
	}
}
