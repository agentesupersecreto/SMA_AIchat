using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200016F RID: 367
	public class FixedFrameCounter : MonoBehaviour
	{
		// Token: 0x06000AED RID: 2797 RVA: 0x00025164 File Offset: 0x00023364
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			FixedFrameCounter.m_instance = null;
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x0002516C File Offset: 0x0002336C
		public static int frameCount
		{
			get
			{
				if (FixedFrameCounter.m_init)
				{
					return FixedFrameCounter.m_instance.count;
				}
				return -1;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000AEF RID: 2799 RVA: 0x00025181 File Offset: 0x00023381
		public static FixedFrameCounter instance
		{
			get
			{
				return FixedFrameCounter.m_instance;
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00025188 File Offset: 0x00023388
		private void Awake()
		{
			if (FixedFrameCounter.m_instance != null)
			{
				this.destroyingCopy = true;
				base.enabled = false;
				Object.Destroy(this);
				return;
			}
			FixedFrameCounter.m_instance = this;
			FixedFrameCounter.m_init = true;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x000251B8 File Offset: 0x000233B8
		private void OnDestroy()
		{
			if (this.destroyingCopy)
			{
				return;
			}
			FixedFrameCounter.m_instance = null;
			FixedFrameCounter.m_init = false;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x000251CF File Offset: 0x000233CF
		private void FixedUpdate()
		{
			if (this.puedeContar)
			{
				this.count++;
			}
		}

		// Token: 0x04000369 RID: 873
		private static bool m_init;

		// Token: 0x0400036A RID: 874
		private static FixedFrameCounter m_instance;

		// Token: 0x0400036B RID: 875
		[ReadOnlyUI]
		public bool puedeContar = true;

		// Token: 0x0400036C RID: 876
		[ReadOnlyUI]
		public int count = -1;

		// Token: 0x0400036D RID: 877
		private bool destroyingCopy;
	}
}
