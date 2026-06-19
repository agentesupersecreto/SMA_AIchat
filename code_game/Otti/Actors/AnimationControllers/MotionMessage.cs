using System;
using com.ootii.Collections;
using com.ootii.Messages;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000EA RID: 234
	public class MotionMessage : Message
	{
		// Token: 0x06000C57 RID: 3159 RVA: 0x0003AEC8 File Offset: 0x000390C8
		public override void Clear()
		{
			this.Motion = null;
			this.Continue = false;
			base.Clear();
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0003AEDE File Offset: 0x000390DE
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				MotionMessage.sPool.Release(this);
			}
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x0003AF04 File Offset: 0x00039104
		public new static MotionMessage Allocate()
		{
			MotionMessage motionMessage = MotionMessage.sPool.Allocate();
			if (motionMessage == null)
			{
				motionMessage = new MotionMessage();
			}
			motionMessage.IsSent = false;
			motionMessage.IsHandled = false;
			return motionMessage;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x0003AF34 File Offset: 0x00039134
		public static MotionMessage Allocate(MotionMessage rSource)
		{
			MotionMessage motionMessage = MotionMessage.sPool.Allocate();
			if (motionMessage == null)
			{
				motionMessage = new MotionMessage();
			}
			motionMessage.ID = rSource.ID;
			motionMessage.Motion = rSource.Motion;
			motionMessage.Continue = rSource.Continue;
			motionMessage.IsSent = false;
			motionMessage.IsHandled = false;
			return motionMessage;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0003AF88 File Offset: 0x00039188
		public static void Release(MotionMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			MotionMessage.sPool.Release(rInstance);
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x0003AFAD File Offset: 0x000391AD
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is MotionMessage)
			{
				MotionMessage.sPool.Release((MotionMessage)rInstance);
			}
		}

		// Token: 0x04000675 RID: 1653
		public static int MSG_UNKNOWN = 100;

		// Token: 0x04000676 RID: 1654
		public static int MSG_MOTION_ACTIVATE = 101;

		// Token: 0x04000677 RID: 1655
		public static int MSG_MOTION_CONTINUE = 102;

		// Token: 0x04000678 RID: 1656
		public static int MSG_MOTION_DEACTIVATE = 103;

		// Token: 0x04000679 RID: 1657
		public static int MSG_MOTION_TEST = 104;

		// Token: 0x0400067A RID: 1658
		public static string[] Names = new string[] { "Unknown", "Motion Activate", "Motion Continue", "Motion Deactivate", "Motion Test" };

		// Token: 0x0400067B RID: 1659
		public MotionControllerMotion Motion;

		// Token: 0x0400067C RID: 1660
		public int Form = -1;

		// Token: 0x0400067D RID: 1661
		public bool Continue;

		// Token: 0x0400067E RID: 1662
		private static ObjectPool<MotionMessage> sPool = new ObjectPool<MotionMessage>(10, 10);
	}
}
