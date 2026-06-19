using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.UI.Modales.Globales;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000D9 RID: 217
	public class TemporalInfoDialog : CustomMonobehaviour
	{
		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00017838 File Offset: 0x00015A38
		public TextMeshProUGUI info
		{
			get
			{
				return this.m_info;
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00017840 File Offset: 0x00015A40
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_info == null)
			{
				throw new ArgumentNullException("m_info", "m_info null reference.");
			}
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00017866 File Offset: 0x00015A66
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.Invoke("CloseThis", this.duration);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001787F File Offset: 0x00015A7F
		private void CloseThis()
		{
			if (Singleton<ModalWindow>.IsInScene)
			{
				Singleton<ModalWindow>.instance.Clear<TemporalInfoDialog>();
			}
		}

		// Token: 0x0400026D RID: 621
		[SerializeField]
		private TextMeshProUGUI m_info;

		// Token: 0x0400026E RID: 622
		public float duration;
	}
}
