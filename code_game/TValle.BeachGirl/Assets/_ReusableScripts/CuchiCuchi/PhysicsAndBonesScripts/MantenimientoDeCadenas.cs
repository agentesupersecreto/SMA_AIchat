using System;
using System.Collections;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000FA RID: 250
	[RequireComponent(typeof(ILinearChain))]
	public sealed class MantenimientoDeCadenas : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000AB1 RID: 2737 RVA: 0x00022F45 File Offset: 0x00021145
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_chain = base.GetComponent<ILinearChain>();
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00022F5C File Offset: 0x0002115C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_rutinaKillForces = new CoroutineCapsule(this, new CoroutineCapsuleConfig
			{
				autoRestart = true
			});
			this.m_rutinaKillForces.Start(this.KillForces(), null, null);
			this.m_rutinaFixPoints = new CoroutineCapsule(this, new CoroutineCapsuleConfig
			{
				autoRestart = true
			});
			this.m_rutinaFixPoints.Start(this.FixPoints(), null, null);
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00022FD7 File Offset: 0x000211D7
		private IEnumerator FixPoints()
		{
			WaitForSeconds w = new WaitForSeconds(this.coolDownFixPoints.Random(0.1f));
			for (;;)
			{
				if (this.fixPoints && this.m_chain.estado == EstadoDeCadena.activa)
				{
					this.m_chain.FixEnOrdenAsc();
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00022FE6 File Offset: 0x000211E6
		private IEnumerator KillForces()
		{
			WaitForSeconds w = new WaitForSeconds(this.coolDownKillForces.Random(0.1f));
			for (;;)
			{
				if (this.killForces && this.m_chain.estado == EstadoDeCadena.activa)
				{
					this.m_chain.KillForces();
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x040005B0 RID: 1456
		public bool killForces = true;

		// Token: 0x040005B1 RID: 1457
		public bool fixPoints;

		// Token: 0x040005B2 RID: 1458
		public float coolDownKillForces = 60f;

		// Token: 0x040005B3 RID: 1459
		public float coolDownFixPoints = 300f;

		// Token: 0x040005B4 RID: 1460
		private ILinearChain m_chain;

		// Token: 0x040005B5 RID: 1461
		private CoroutineCapsule m_rutinaKillForces;

		// Token: 0x040005B6 RID: 1462
		private CoroutineCapsule m_rutinaFixPoints;
	}
}
