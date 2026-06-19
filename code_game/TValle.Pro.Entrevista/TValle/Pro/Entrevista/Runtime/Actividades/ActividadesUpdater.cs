using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000120 RID: 288
	[RequireComponent(typeof(ActividadesManager))]
	public sealed class ActividadesUpdater : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00039A5B File Offset: 0x00037C5B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.updateAfterPupetMaster);
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x00039A64 File Offset: 0x00037C64
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterDynamicColliders);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00039A6D File Offset: 0x00037C6D
		public override GlobalUpdater.UpdateType? updateEvent3
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforeFixedUpdates3);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x00039A76 File Offset: 0x00037C76
		public override GlobalUpdater.UpdateType? updateEvent4
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterPhyscisConstraints);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x00039A7F File Offset: 0x00037C7F
		public override GlobalUpdater.UpdateType? updateEvent5
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.meshVertexGroupModsUpdate1);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000A46 RID: 2630 RVA: 0x00039A88 File Offset: 0x00037C88
		public override GlobalUpdater.UpdateType? updateEvent6
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.meshUpdate3);
			}
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00039A91 File Offset: 0x00037C91
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_instance = base.GetComponent<ActividadesManager>();
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00039AA5 File Offset: 0x00037CA5
		public override void OnUpdateEvent1()
		{
			Actividad current = this.m_instance.current;
			if (current == null)
			{
				return;
			}
			current.BeforeAnimationsUpdate();
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00039ABC File Offset: 0x00037CBC
		public override void OnUpdateEvent2()
		{
			Actividad current = this.m_instance.current;
			if (current == null)
			{
				return;
			}
			current.AfterAnimationsUpdate();
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00039AD3 File Offset: 0x00037CD3
		public override void OnUpdateEvent3()
		{
			Actividad current = this.m_instance.current;
			if (current == null)
			{
				return;
			}
			current.BeforePhysicsUpdate();
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00039AEA File Offset: 0x00037CEA
		public override void OnUpdateEvent4()
		{
			Actividad current = this.m_instance.current;
			if (current == null)
			{
				return;
			}
			current.AfterPhysicsUpdate();
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00039B01 File Offset: 0x00037D01
		public override void OnUpdateEvent5()
		{
			Actividad current = this.m_instance.current;
			if (current == null)
			{
				return;
			}
			current.BeforeAIUpdate();
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00039B18 File Offset: 0x00037D18
		public override void OnUpdateEvent6()
		{
			Actividad current = this.m_instance.current;
			if (current == null)
			{
				return;
			}
			current.AfterAIUpdate();
		}

		// Token: 0x0400055C RID: 1372
		private ActividadesManager m_instance;
	}
}
