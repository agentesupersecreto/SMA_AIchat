using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000019 RID: 25
	public class TextInputDialog : CustomMonobehaviour
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000368F File Offset: 0x0000188F
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00003697 File Offset: 0x00001897
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0000369F File Offset: 0x0000189F
		public Button cancelar
		{
			get
			{
				return this.m_cancelar;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000036A7 File Offset: 0x000018A7
		public TMP_InputField inputField
		{
			get
			{
				return this.m_InputField;
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000036B0 File Offset: 0x000018B0
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
			this.m_InputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.m_InputField.onEndEdit.AddListener(new UnityAction<string>(this.OnEndEdit));
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003773 File Offset: 0x00001973
		private void OnValueChanged(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000377C File Offset: 0x0000197C
		private void OnEndEdit(string value)
		{
			this.Check(value);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003785 File Offset: 0x00001985
		private void Check(string value)
		{
			this.aceptar.interactable = !string.IsNullOrWhiteSpace(value);
		}

		// Token: 0x04000053 RID: 83
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x04000054 RID: 84
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x04000055 RID: 85
		[SerializeField]
		private Button m_cancelar;

		// Token: 0x04000056 RID: 86
		[SerializeField]
		private TMP_InputField m_InputField;
	}
}
