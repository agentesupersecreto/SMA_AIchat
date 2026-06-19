using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Jobs.Models;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Jobs.Paneles
{
	// Token: 0x0200010A RID: 266
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class CurrentAvailableJobsPortraits : PanelBaseSingleModel<CurrentAvailableJobsModelo>
	{
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0001BAA8 File Offset: 0x00019CA8
		public CurrentAvailableJobsModelo portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0001BAB0 File Offset: 0x00019CB0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
