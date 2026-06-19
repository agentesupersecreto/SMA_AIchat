using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000112 RID: 274
	public sealed class CoroutineCapsuleMonoGeneric : BaseCoroutineCapsule<MonoBehaviour>
	{
		// Token: 0x060007B6 RID: 1974 RVA: 0x0001AEFE File Offset: 0x000190FE
		public CoroutineCapsuleMonoGeneric(MonoBehaviour mono)
			: base(mono)
		{
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001AF07 File Offset: 0x00019107
		protected override void OnConstruct()
		{
		}
	}
}
