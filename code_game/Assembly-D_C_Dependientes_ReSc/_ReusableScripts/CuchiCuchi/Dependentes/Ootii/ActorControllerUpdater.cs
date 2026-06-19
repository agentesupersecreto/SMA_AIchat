using System;
using com.ootii.Actors;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii
{
	// Token: 0x0200015F RID: 351
	[RequireComponent(typeof(ActorController))]
	public class ActorControllerUpdater : CustomUpdatedMonobehaviourBase, ITValleActorControllerUpdater
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x00026DE5 File Offset: 0x00024FE5
		public override int updateEvent1Index
		{
			get
			{
				return 36;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x00026DE9 File Offset: 0x00024FE9
		public override int updateEvent2Index
		{
			get
			{
				return 37;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x00026DED File Offset: 0x00024FED
		public override int updateEvent3Index
		{
			get
			{
				return 12;
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00026DF1 File Offset: 0x00024FF1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ActorController = base.GetComponent<ActorController>();
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00026E05 File Offset: 0x00025005
		public override void OnUpdateEvent1()
		{
			if (this.m_ActorController.enabled)
			{
				this.m_ActorController.UpdateActor();
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00026E1F File Offset: 0x0002501F
		public override void OnUpdateEvent2()
		{
			if (this.m_ActorController.enabled)
			{
				this.m_ActorController.LateUpdateActor();
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00026E39 File Offset: 0x00025039
		public override void OnUpdateEvent3()
		{
			if (this.m_ActorController.enabled)
			{
				this.m_ActorController.FixedUpdateActor();
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00023F85 File Offset: 0x00022185
		void ITValleActorControllerUpdater.Update()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00023F85 File Offset: 0x00022185
		void ITValleActorControllerUpdater.LateUpdate()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040005D1 RID: 1489
		private ActorController m_ActorController;
	}
}
