using System;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing
{
	// Token: 0x020000EC RID: 236
	[RequireComponent(typeof(PanelBase))]
	public class DibujarPanelAtKey : CustomMonobehaviour
	{
		// Token: 0x0600071D RID: 1821 RVA: 0x00019EDB File Offset: 0x000180DB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<PanelBase>();
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00019EEF File Offset: 0x000180EF
		private void Update()
		{
			if (Input.GetKeyUp(this.key) && !this.m_panel.dibujando)
			{
				this.m_panel.CrearYDibujar(null);
			}
		}

		// Token: 0x040002D8 RID: 728
		private PanelBase m_panel;

		// Token: 0x040002D9 RID: 729
		public KeyCode key = KeyCode.Escape;
	}
}
