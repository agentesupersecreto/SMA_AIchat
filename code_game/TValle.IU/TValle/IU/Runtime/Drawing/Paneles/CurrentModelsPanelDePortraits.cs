using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F2 RID: 242
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class CurrentModelsPanelDePortraits : PanelBaseSingleModel<CurrentWorkingModelsModel>
	{
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x0001A9A7 File Offset: 0x00018BA7
		public CurrentWorkingModelsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001A9AF File Offset: 0x00018BAF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}
	}
}
