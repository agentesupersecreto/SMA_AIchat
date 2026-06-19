using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F8 RID: 248
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelDeObjectives : PanelBaseSingleModel<GamePlayObjectivesModel>
	{
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x0600076D RID: 1901 RVA: 0x0001AA20 File Offset: 0x00018C20
		// (remove) Token: 0x0600076E RID: 1902 RVA: 0x0001AA58 File Offset: 0x00018C58
		public event Action<PanelDeObjectives> onBiding;

		// Token: 0x0600076F RID: 1903 RVA: 0x0001AA8D File Offset: 0x00018C8D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001AA95 File Offset: 0x00018C95
		protected override void OnBinding()
		{
			base.OnBinding();
			Action<PanelDeObjectives> action = this.onBiding;
			if (action == null)
			{
				return;
			}
			action(this);
		}
	}
}
