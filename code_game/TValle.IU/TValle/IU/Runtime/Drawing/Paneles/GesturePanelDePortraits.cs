using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F4 RID: 244
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class GesturePanelDePortraits : PanelBaseSingleModel<GesturePortraitsModel>
	{
		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x0001A9C7 File Offset: 0x00018BC7
		public GesturePortraitsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001A9CF File Offset: 0x00018BCF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
