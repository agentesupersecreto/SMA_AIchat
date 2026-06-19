using System;
using com.ootii.Collections;
using com.ootii.Messages;

namespace com.ootii.Actors.Attributes
{
	// Token: 0x020000C6 RID: 198
	public class AttributeMessageOld : Message
	{
		// Token: 0x06000AC9 RID: 2761 RVA: 0x00033F69 File Offset: 0x00032169
		public override void Clear()
		{
			this.AttributeID = "";
			this.MinAttributeID = "";
			this.MaxAttributeID = "";
			this.Value = 0f;
			base.Clear();
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00033F9D File Offset: 0x0003219D
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				AttributeMessageOld.sPool.Release(this);
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00033FC4 File Offset: 0x000321C4
		public new static AttributeMessageOld Allocate()
		{
			AttributeMessageOld attributeMessageOld = AttributeMessageOld.sPool.Allocate();
			if (attributeMessageOld == null)
			{
				attributeMessageOld = new AttributeMessageOld();
			}
			attributeMessageOld.IsSent = false;
			attributeMessageOld.IsHandled = false;
			return attributeMessageOld;
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00033FF4 File Offset: 0x000321F4
		public static AttributeMessageOld Allocate(AttributeMessageOld rSource)
		{
			AttributeMessageOld attributeMessageOld = AttributeMessageOld.sPool.Allocate();
			if (attributeMessageOld == null)
			{
				attributeMessageOld = new AttributeMessageOld();
			}
			attributeMessageOld.AttributeID = rSource.AttributeID;
			attributeMessageOld.MinAttributeID = rSource.MinAttributeID;
			attributeMessageOld.MaxAttributeID = rSource.MaxAttributeID;
			attributeMessageOld.Value = rSource.Value;
			attributeMessageOld.IsSent = false;
			attributeMessageOld.IsHandled = false;
			return attributeMessageOld;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00034054 File Offset: 0x00032254
		public static void Release(AttributeMessageOld rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			AttributeMessageOld.sPool.Release(rInstance);
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00034079 File Offset: 0x00032279
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is AttributeMessageOld)
			{
				AttributeMessageOld.sPool.Release((AttributeMessageOld)rInstance);
			}
		}

		// Token: 0x04000590 RID: 1424
		public string AttributeID = "";

		// Token: 0x04000591 RID: 1425
		public string MinAttributeID = "";

		// Token: 0x04000592 RID: 1426
		public string MaxAttributeID = "";

		// Token: 0x04000593 RID: 1427
		public float Value;

		// Token: 0x04000594 RID: 1428
		private static ObjectPool<AttributeMessageOld> sPool = new ObjectPool<AttributeMessageOld>(10, 10);
	}
}
