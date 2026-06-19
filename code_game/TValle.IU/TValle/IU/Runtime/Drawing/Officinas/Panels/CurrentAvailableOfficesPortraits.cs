using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Officinas.Models;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Officinas.Panels
{
	// Token: 0x02000106 RID: 262
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class CurrentAvailableOfficesPortraits : PanelBaseSingleModel<CurrentAvailableOfficesModelo>
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x0001B830 File Offset: 0x00019A30
		public CurrentAvailableOfficesModelo portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0001B838 File Offset: 0x00019A38
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
