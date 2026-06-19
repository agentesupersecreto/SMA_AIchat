using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000CD RID: 205
	[RequireComponent(typeof(Character))]
	public class TargetChar : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x000152AF File Offset: 0x000134AF
		public static Character current
		{
			get
			{
				if (!Singleton<CurrentTargetChar>.IsInScene)
				{
					return null;
				}
				TargetChar main = Singleton<CurrentTargetChar>.instance.main;
				if (main == null)
				{
					return null;
				}
				return main.character;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x000152CF File Offset: 0x000134CF
		public static TargetChar instance
		{
			get
			{
				if (!Singleton<CurrentTargetChar>.IsInScene)
				{
					return null;
				}
				return Singleton<CurrentTargetChar>.instance.main;
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x000152E4 File Offset: 0x000134E4
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000152EC File Offset: 0x000134EC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = base.GetComponent<Character>();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00015300 File Offset: 0x00013500
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<CurrentTargetChar>.instance.SetMain(this);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00015313 File Offset: 0x00013513
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<CurrentTargetChar>.IsInScene)
			{
				Singleton<CurrentTargetChar>.instance.RemoveMain(this);
			}
		}

		// Token: 0x04000404 RID: 1028
		private Character m_Character;
	}
}
