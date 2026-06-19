using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000047 RID: 71
	public class ColliderDeEmulatedHitSkin : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000234 RID: 564 RVA: 0x000081F0 File Offset: 0x000063F0
		public EmulatedHitSkin owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000081F8 File Offset: 0x000063F8
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000820C File Offset: 0x0000640C
		public void Init(EmulatedHitSkin owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_owner = owner;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x04000114 RID: 276
		[ReadOnlyUI]
		[SerializeField]
		private EmulatedHitSkin m_owner;
	}
}
