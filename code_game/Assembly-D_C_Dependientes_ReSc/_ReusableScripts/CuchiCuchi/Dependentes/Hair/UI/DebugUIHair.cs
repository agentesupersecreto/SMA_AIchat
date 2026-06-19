using System;
using GPUTools.Hair.Scripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair.UI
{
	// Token: 0x0200016E RID: 366
	[RequireComponent(typeof(HairSettings))]
	public class DebugUIHair : CustomMonobehaviour
	{
		// Token: 0x060007F7 RID: 2039 RVA: 0x0002952B File Offset: 0x0002772B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_HairSettings = base.GetComponent<HairSettings>();
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0002953F File Offset: 0x0002773F
		private void OnGUI()
		{
			if (this.m_HairSettings == null)
			{
				return;
			}
			if (GUILayout.Button("ReStartHair", Array.Empty<GUILayoutOption>()))
			{
				this.m_HairSettings.ReStart();
			}
		}

		// Token: 0x0400063A RID: 1594
		private HairSettings m_HairSettings;
	}
}
