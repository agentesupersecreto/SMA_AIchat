using System;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Camaras
{
	// Token: 0x020000BB RID: 187
	[RequireComponent(typeof(CamaraAtable))]
	public class MainCameraRig : InstantiatedSingleton<MainCameraRig>
	{
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x00012543 File Offset: 0x00010743
		public CamaraAtable camaraAtable
		{
			get
			{
				return this.m_CamaraAtable;
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001254B File Offset: 0x0001074B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CamaraAtable = base.GetComponent<CamaraAtable>();
		}

		// Token: 0x040003BB RID: 955
		private CamaraAtable m_CamaraAtable;
	}
}
