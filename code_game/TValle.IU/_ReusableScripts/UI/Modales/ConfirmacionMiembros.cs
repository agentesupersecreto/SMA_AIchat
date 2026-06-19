using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Modales
{
	// Token: 0x02000013 RID: 19
	public class ConfirmacionMiembros : CustomMonobehaviour
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002E5D File Offset: 0x0000105D
		public TextMeshProUGUI pregunta
		{
			get
			{
				return this.m_pregunta;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002E65 File Offset: 0x00001065
		public Button aceptar
		{
			get
			{
				return this.m_aceptar;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002E6D File Offset: 0x0000106D
		public Button cancelar
		{
			get
			{
				return this.m_cancelar;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002E75 File Offset: 0x00001075
		public Toggle noMostrarOtraVezToggle
		{
			get
			{
				return this.m_noMostrarOtraVez;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002E7D File Offset: 0x0000107D
		public void SetPreguntaText(string text)
		{
			this.m_pregunta.text = text;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002E8C File Offset: 0x0000108C
		public bool userNoQuiereVerNuevamente
		{
			get
			{
				Toggle noMostrarOtraVez = this.m_noMostrarOtraVez;
				return ((noMostrarOtraVez != null) ? new bool?(noMostrarOtraVez.isOn) : null).GetValueOrDefault();
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002EC0 File Offset: 0x000010C0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_noMostrarOtraVez == null)
			{
				throw new ArgumentNullException("m_noMostrarOtraVez", "m_noMostrarOtraVez null reference.");
			}
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
		}

		// Token: 0x0400002D RID: 45
		[SerializeField]
		private TextMeshProUGUI m_pregunta;

		// Token: 0x0400002E RID: 46
		[SerializeField]
		private Toggle m_noMostrarOtraVez;

		// Token: 0x0400002F RID: 47
		[SerializeField]
		private Button m_aceptar;

		// Token: 0x04000030 RID: 48
		[SerializeField]
		private Button m_cancelar;

		// Token: 0x04000031 RID: 49
		public string accionName;
	}
}
