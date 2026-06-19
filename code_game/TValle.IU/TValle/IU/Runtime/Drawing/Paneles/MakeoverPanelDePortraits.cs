using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F5 RID: 245
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class MakeoverPanelDePortraits : PanelBaseSingleModel<MakeoverPortraitsModel>
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x0001A9DF File Offset: 0x00018BDF
		public MakeoverPortraitsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0001A9E7 File Offset: 0x00018BE7
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
