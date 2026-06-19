using System;
using com.ootii.Collections;
using com.ootii.Messages;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000C5 RID: 197
	public class AttributeMessage : Message
	{
		// Token: 0x06000AC1 RID: 2753 RVA: 0x00033E3C File Offset: 0x0003203C
		public override void Clear()
		{
			this.Attribute = null;
			this.Value = null;
			base.Clear();
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00033E52 File Offset: 0x00032052
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				AttributeMessage.sPool.Release(this);
			}
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00033E78 File Offset: 0x00032078
		public new static AttributeMessage Allocate()
		{
			AttributeMessage attributeMessage = AttributeMessage.sPool.Allocate();
			if (attributeMessage == null)
			{
				attributeMessage = new AttributeMessage();
			}
			attributeMessage.IsSent = false;
			attributeMessage.IsHandled = false;
			return attributeMessage;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00033EA8 File Offset: 0x000320A8
		public static AttributeMessage Allocate(AttributeMessage rSource)
		{
			AttributeMessage attributeMessage = AttributeMessage.sPool.Allocate();
			if (attributeMessage == null)
			{
				attributeMessage = new AttributeMessage();
			}
			attributeMessage.Attribute = rSource.Attribute;
			attributeMessage.Value = rSource.Value;
			attributeMessage.IsSent = false;
			attributeMessage.IsHandled = false;
			return attributeMessage;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00033EF0 File Offset: 0x000320F0
		public static void Release(AttributeMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			AttributeMessage.sPool.Release(rInstance);
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00033F15 File Offset: 0x00032115
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is AttributeMessage)
			{
				AttributeMessage.sPool.Release((AttributeMessage)rInstance);
			}
		}

		// Token: 0x0400058C RID: 1420
		public static int MSG_VALUE_CHANGED = 5200;

		// Token: 0x0400058D RID: 1421
		public BasicAttribute Attribute;

		// Token: 0x0400058E RID: 1422
		public object Value;

		// Token: 0x0400058F RID: 1423
		private static ObjectPool<AttributeMessage> sPool = new ObjectPool<AttributeMessage>(10, 10);
	}
}
