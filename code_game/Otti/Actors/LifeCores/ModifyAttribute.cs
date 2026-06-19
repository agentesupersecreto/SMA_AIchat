using System;
using com.ootii.Actors.Attributes;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A2 RID: 162
	public class ModifyAttribute : ActorCoreEffect
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0002FE12 File Offset: 0x0002E012
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x0002FE1A File Offset: 0x0002E01A
		public bool ResetOnDeactivate
		{
			get
			{
				return this._ResetOnDeactivate;
			}
			set
			{
				this._ResetOnDeactivate = value;
			}
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0002FE23 File Offset: 0x0002E023
		public ModifyAttribute()
		{
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0002FE2B File Offset: 0x0002E02B
		public ModifyAttribute(ActorCore rActorCore)
			: base(rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0002FE3B File Offset: 0x0002E03B
		public void Activate(float rTriggerDelay, float rMaxAge, AttributeMessageOld rMessage)
		{
			this.mChange = 0f;
			this.mMessage = rMessage;
			base.Activate(rTriggerDelay, rMaxAge);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0002FE58 File Offset: 0x0002E058
		public override void Deactivate()
		{
			if (this.mMessage != null)
			{
				if (this.ResetOnDeactivate)
				{
					float attributeValue = this.mActorCore.AttributeSource.GetAttributeValue<float>(this.mMessage.AttributeID, 0f);
					this.mActorCore.AttributeSource.SetAttributeValue<float>(this.mMessage.AttributeID, attributeValue - this.mChange);
				}
				this.mMessage.Release();
				this.mMessage = null;
			}
			base.Deactivate();
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0002FED4 File Offset: 0x0002E0D4
		public override void TriggerEffect()
		{
			base.TriggerEffect();
			if (this.mActorCore != null && this.mActorCore.AttributeSource != null)
			{
				bool flag = false;
				try
				{
					flag = this.mActorCore.AttributeSource.AttributeExists(this.mMessage.AttributeID);
				}
				catch
				{
					flag = false;
				}
				if (flag)
				{
					float attributeValue = this.mActorCore.AttributeSource.GetAttributeValue<float>(this.mMessage.AttributeID, 0f);
					float num = attributeValue + this.mMessage.Value;
					if (this.mMessage.MinAttributeID.Length > 0)
					{
						float num2 = 0f;
						try
						{
							num2 = float.Parse(this.mMessage.MinAttributeID);
						}
						catch
						{
						}
						float attributeValue2 = this.mActorCore.AttributeSource.GetAttributeValue<float>(this.mMessage.MinAttributeID, num2);
						num = Mathf.Max(num, attributeValue2);
					}
					if (this.mMessage.MaxAttributeID.Length > 0)
					{
						float num3 = num;
						try
						{
							num3 = float.Parse(this.mMessage.MaxAttributeID);
						}
						catch
						{
						}
						float attributeValue3 = this.mActorCore.AttributeSource.GetAttributeValue<float>(this.mMessage.MaxAttributeID, num3);
						num = Mathf.Min(num, attributeValue3);
					}
					this.mChange += num - attributeValue;
					this.mActorCore.AttributeSource.SetAttributeValue<float>(this.mMessage.AttributeID, num);
				}
			}
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0003005C File Offset: 0x0002E25C
		public override void Release()
		{
			ModifyAttribute.Release(this);
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00030064 File Offset: 0x0002E264
		public static ModifyAttribute Allocate()
		{
			return ModifyAttribute.sPool.Allocate();
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00030070 File Offset: 0x0002E270
		public static void Release(ModifyAttribute rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			ModifyAttribute.sPool.Release(rInstance);
		}

		// Token: 0x040004A5 RID: 1189
		public bool _ResetOnDeactivate;

		// Token: 0x040004A6 RID: 1190
		protected AttributeMessageOld mMessage;

		// Token: 0x040004A7 RID: 1191
		protected float mChange;

		// Token: 0x040004A8 RID: 1192
		private static ObjectPool<ModifyAttribute> sPool = new ObjectPool<ModifyAttribute>(10, 10);
	}
}
