using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles
{
	// Token: 0x020000F7 RID: 247
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelDeInterpretationPortraits : PanelBaseSingleModel<InterpretationPortraitsModel>
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0001AA0F File Offset: 0x00018C0F
		public InterpretationPortraitsModel portraitsModel
		{
			get
			{
				return this.m_model;
			}
		}
	}
}
