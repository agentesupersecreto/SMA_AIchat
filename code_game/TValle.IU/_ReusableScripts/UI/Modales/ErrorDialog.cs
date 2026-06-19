using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000015 RID: 21
	public class ErrorDialog : CustomMonobehaviour
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003007 File Offset: 0x00001207
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000300F File Offset: 0x0000120F
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003018 File Offset: 0x00001218
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
		}

		// Token: 0x04000036 RID: 54
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x04000037 RID: 55
		[SerializeField]
		private Button m_aceptar;
	}
}
