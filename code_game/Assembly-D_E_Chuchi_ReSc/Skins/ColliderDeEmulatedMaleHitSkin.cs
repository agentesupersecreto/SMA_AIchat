using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000048 RID: 72
	public class ColliderDeEmulatedMaleHitSkin : CustomMonobehaviour
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00008242 File Offset: 0x00006442
		public EmulatedMaleHitSkin owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000081F8 File Offset: 0x000063F8
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000824A File Offset: 0x0000644A
		public void Init(EmulatedMaleHitSkin owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_owner = owner;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x04000115 RID: 277
		[ReadOnlyUI]
		[SerializeField]
		private EmulatedMaleHitSkin m_owner;
	}
}
