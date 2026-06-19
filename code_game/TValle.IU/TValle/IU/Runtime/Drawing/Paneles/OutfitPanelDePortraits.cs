using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F6 RID: 246
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class OutfitPanelDePortraits : PanelBaseSingleModel<OutfitPortraitsModel>
	{
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x0001A9F7 File Offset: 0x00018BF7
		public OutfitPortraitsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0001A9FF File Offset: 0x00018BFF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
