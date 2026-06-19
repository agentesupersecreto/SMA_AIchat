using System;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000090 RID: 144
	[RequireComponent(typeof(ActorController))]
	public class DefaultActorControllerUpdater : MonoBehaviour, ITValleActorControllerUpdater
	{
		// Token: 0x0600082A RID: 2090 RVA: 0x0002BED0 File Offset: 0x0002A0D0
		private void Awake()
		{
			this.m_ActorController = base.GetComponent<ActorController>();
			if (this.m_ActorController == null)
			{
				throw new ArgumentNullException("m_ActorController", "m_ActorController null reference.");
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0002BEFC File Offset: 0x0002A0FC
		public void FixedUpdate()
		{
			if (this.m_ActorController.enabled)
			{
				this.m_ActorController.FixedUpdateActor();
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0002BF16 File Offset: 0x0002A116
		public void LateUpdate()
		{
			if (this.m_ActorController.enabled)
			{
				this.m_ActorController.LateUpdateActor();
			}
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0002BF30 File Offset: 0x0002A130
		public void Update()
		{
			if (this.m_ActorController.enabled)
			{
				this.m_ActorController.UpdateActor();
			}
		}

		// Token: 0x04000435 RID: 1077
		private ActorController m_ActorController;
	}
}
