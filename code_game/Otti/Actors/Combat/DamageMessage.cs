using System;
using com.ootii.Collections;
using com.ootii.Messages;

namespace com.ootii.Actors.Combat
{
	// Token: 0x020000BF RID: 191
	public class DamageMessage : Message
	{
		// Token: 0x06000A89 RID: 2697 RVA: 0x00033B93 File Offset: 0x00031D93
		public override void Clear()
		{
			this.Damage = 0f;
			this.DamageType = 0;
			this.ImpactType = 0;
			this.AnimationEnabled = true;
			base.Clear();
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00033BBB File Offset: 0x00031DBB
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				DamageMessage.sPool.Release(this);
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00033BE0 File Offset: 0x00031DE0
		public new static DamageMessage Allocate()
		{
			DamageMessage damageMessage = DamageMessage.sPool.Allocate();
			if (damageMessage == null)
			{
				damageMessage = new DamageMessage();
			}
			damageMessage.IsSent = false;
			damageMessage.IsHandled = false;
			return damageMessage;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00033C10 File Offset: 0x00031E10
		public static DamageMessage Allocate(DamageMessage rSource)
		{
			DamageMessage damageMessage = DamageMessage.sPool.Allocate();
			if (damageMessage == null)
			{
				damageMessage = new DamageMessage();
			}
			damageMessage.Damage = rSource.Damage;
			damageMessage.DamageType = rSource.DamageType;
			damageMessage.ImpactType = rSource.ImpactType;
			damageMessage.AnimationEnabled = rSource.AnimationEnabled;
			damageMessage.IsSent = false;
			damageMessage.IsHandled = false;
			return damageMessage;
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00033C70 File Offset: 0x00031E70
		public static void Release(DamageMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			DamageMessage.sPool.Release(rInstance);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00033C95 File Offset: 0x00031E95
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is DamageMessage)
			{
				DamageMessage.sPool.Release((DamageMessage)rInstance);
			}
		}

		// Token: 0x0400056D RID: 1389
		public float Damage;

		// Token: 0x0400056E RID: 1390
		public int DamageType;

		// Token: 0x0400056F RID: 1391
		public int ImpactType;

		// Token: 0x04000570 RID: 1392
		public bool AnimationEnabled = true;

		// Token: 0x04000571 RID: 1393
		private static ObjectPool<DamageMessage> sPool = new ObjectPool<DamageMessage>(10, 10);
	}
}
