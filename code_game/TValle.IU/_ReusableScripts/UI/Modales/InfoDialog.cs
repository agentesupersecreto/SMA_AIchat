using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000016 RID: 22
	public class InfoDialog : CustomMonobehaviour
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600006A RID: 106 RVA: 0x0000306F File Offset: 0x0000126F
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00003077 File Offset: 0x00001277
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003080 File Offset: 0x00001280
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

		// Token: 0x04000038 RID: 56
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x04000039 RID: 57
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x0400003A RID: 58
		public string accionName;
	}
}
