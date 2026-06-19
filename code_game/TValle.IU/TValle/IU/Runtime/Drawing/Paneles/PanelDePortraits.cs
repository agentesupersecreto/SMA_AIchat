using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F9 RID: 249
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelDePortraits : PanelBaseSingleModel<PortraitsModel>
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0001AAB6 File Offset: 0x00018CB6
		public PortraitsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0001AABE File Offset: 0x00018CBE
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
