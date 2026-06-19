using System;
using com.ootii.Actors.Combat;
using com.ootii.Collections;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A0 RID: 160
	public class CauseDamage : ActorCoreEffect
	{
		// Token: 0x0600090F RID: 2319 RVA: 0x0002FB5B File Offset: 0x0002DD5B
		public CauseDamage()
		{
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0002FB63 File Offset: 0x0002DD63
		public CauseDamage(ActorCore rActorCore)
			: base(rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0002FB73 File Offset: 0x0002DD73
		public void Activate(float rTriggerDelay, float rMaxAge, DamageMessage rMessage)
		{
			this.mMessage = rMessage;
			base.Activate(rTriggerDelay, rMaxAge);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0002FB84 File Offset: 0x0002DD84
		public override void Deactivate()
		{
			if (this.mMessage != null)
			{
				this.mMessage.Release();
				this.mMessage = null;
			}
			base.Deactivate();
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x0002FBA8 File Offset: 0x0002DDA8
		public override void TriggerEffect()
		{
			base.TriggerEffect();
			if (this.mActorCore != null)
			{
				int id = this.mMessage.ID;
				bool isHandled = this.mMessage.IsHandled;
				this.mActorCore.SendMessage(this.mMessage);
				this.mMessage.ID = id;
				this.mMessage.IsHandled = isHandled;
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0002FC04 File Offset: 0x0002DE04
		public override void Release()
		{
			CauseDamage.Release(this);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0002FC0C File Offset: 0x0002DE0C
		public static CauseDamage Allocate()
		{
			return CauseDamage.sPool.Allocate();
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0002FC18 File Offset: 0x0002DE18
		public static void Release(CauseDamage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			CauseDamage.sPool.Release(rInstance);
		}

		// Token: 0x0400049D RID: 1181
		protected DamageMessage mMessage;

		// Token: 0x0400049E RID: 1182
		private static ObjectPool<CauseDamage> sPool = new ObjectPool<CauseDamage>(10, 10);
	}
}
