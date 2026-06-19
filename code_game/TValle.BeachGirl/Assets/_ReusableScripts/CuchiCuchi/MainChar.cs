using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000CC RID: 204
	[RequireComponent(typeof(Character))]
	public class MainChar : AplicableBehaviour
	{
		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00015217 File Offset: 0x00013417
		public static Character current
		{
			get
			{
				if (!Singleton<CurrentMainChar>.IsInScene)
				{
					return null;
				}
				MainChar main = Singleton<CurrentMainChar>.instance.main;
				if (main == null)
				{
					return null;
				}
				return main.character;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00015237 File Offset: 0x00013437
		public static MainChar instance
		{
			get
			{
				if (!Singleton<CurrentMainChar>.IsInScene)
				{
					return null;
				}
				return Singleton<CurrentMainChar>.instance.main;
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x0001524C File Offset: 0x0001344C
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00015254 File Offset: 0x00013454
		public virtual float concentAura
		{
			get
			{
				return Singleton<ConfiguracionGeneral>.instance.femaleGamePlay.heroConcentAuraAdicional;
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00015265 File Offset: 0x00013465
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = base.GetComponent<Character>();
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00015279 File Offset: 0x00013479
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<CurrentMainChar>.instance.SetMain(this);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001528C File Offset: 0x0001348C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<CurrentMainChar>.IsInScene)
			{
				Singleton<CurrentMainChar>.instance.RemoveMain(this);
			}
		}

		// Token: 0x04000403 RID: 1027
		private Character m_Character;
	}
}
