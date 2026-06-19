using System;
using com.ootii.Actors.Attributes;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A8 RID: 168
	public interface IActorCore : ILifeCore, IActorStateSource, IDamageable
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000972 RID: 2418
		Transform Transform { get; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000973 RID: 2419
		IAttributeSource AttributeSource { get; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000974 RID: 2420
		// (set) Token: 0x06000975 RID: 2421
		bool IsAlive { get; set; }

		// Token: 0x06000976 RID: 2422
		bool TestAffected(IMessage rMessage);

		// Token: 0x06000977 RID: 2423
		void SendMessage(IMessage rMessage);
	}
}
