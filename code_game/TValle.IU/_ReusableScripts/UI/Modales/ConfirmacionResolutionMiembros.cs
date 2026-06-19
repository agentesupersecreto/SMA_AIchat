using System;
using Assets.TValle.IU.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000014 RID: 20
	public class ConfirmacionResolutionMiembros : CustomMonobehaviour
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002F53 File Offset: 0x00001153
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002F5B File Offset: 0x0000115B
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002F63 File Offset: 0x00001163
		public Button cancelar
		{
			get
			{
				return this.m_cancelar;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002F6B File Offset: 0x0000116B
		public TextCountDown textCountDown
		{
			get
			{
				return this.m_TextCountDown;
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002F74 File Offset: 0x00001174
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
			if (this.m_TextCountDown == null)
			{
				throw new ArgumentNullException("m_TextCountDown", "m_TextCountDown null reference.");
			}
		}

		// Token: 0x04000032 RID: 50
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x04000033 RID: 51
		[SerializeField]
		private TextCountDown m_TextCountDown;

		// Token: 0x04000034 RID: 52
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x04000035 RID: 53
		[SerializeField]
		private Button m_cancelar;
	}
}
