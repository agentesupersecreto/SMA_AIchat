using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000111 RID: 273
	public sealed class CoroutineCapsuleGeneric<TMono> : BaseCoroutineCapsule<TMono, CoroutineCapsuleConfig> where TMono : MonoBehaviour, IComponentEnabable, IComponentStartable
	{
		// Token: 0x060007B4 RID: 1972 RVA: 0x0001AEE6 File Offset: 0x000190E6
		public CoroutineCapsuleGeneric(TMono mono)
			: base(mono, new CoroutineCapsuleConfig())
		{
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0001AEF4 File Offset: 0x000190F4
		public CoroutineCapsuleGeneric(TMono mono, CoroutineCapsuleConfig config)
			: base(mono, config)
		{
		}
	}
}
