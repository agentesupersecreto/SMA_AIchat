using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x02000148 RID: 328
	public class DrawOnTopGuiasDeProps : Singleton<DrawOnTopGuiasDeProps>
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x00023910 File Offset: 0x00021B10
		public ModificableDeBool drawOnTopOR
		{
			get
			{
				return this.m_DrawOnTopOR;
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00023918 File Offset: 0x00021B18
		private void Update()
		{
			bool activeSelf = this.m_DrawOnTopVolumes.activeSelf;
			bool flag = this.m_DrawOnTopOR.Or(false);
			if (activeSelf != flag)
			{
				this.m_DrawOnTopVolumes.SetActive(flag);
			}
		}

		// Token: 0x0400052E RID: 1326
		[SerializeField]
		private GameObject m_DrawOnTopVolumes;

		// Token: 0x0400052F RID: 1327
		[SerializeField]
		private ModificableDeBool m_DrawOnTopOR = new ModificableDeBool(false);
	}
}
