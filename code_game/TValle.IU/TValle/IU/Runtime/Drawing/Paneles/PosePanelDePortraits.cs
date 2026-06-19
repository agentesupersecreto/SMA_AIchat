using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000FA RID: 250
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PosePanelDePortraits : PanelBaseSingleModel<PosePortraitsModel>
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0001AACE File Offset: 0x00018CCE
		public PosePortraitsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001AAD6 File Offset: 0x00018CD6
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
