using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000082 RID: 130
	[RequireComponent(typeof(HitSkinBasica))]
	public class VisualmenteTransparenteHitSkin : CustomMonobehaviour, ITransparentPhyscisObject
	{
		// Token: 0x06000339 RID: 825 RVA: 0x0000C520 File Offset: 0x0000A720
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_HitSkinBasica = base.GetComponent<HitSkinBasica>();
		}

		// Token: 0x0400023D RID: 573
		private HitSkinBasica m_HitSkinBasica;
	}
}
