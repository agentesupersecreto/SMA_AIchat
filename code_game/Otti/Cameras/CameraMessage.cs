using System;
using com.ootii.Collections;
using com.ootii.Messages;

namespace com.ootii.Cameras
{
	// Token: 0x02000071 RID: 113
	public class CameraMessage : Message
	{
		// Token: 0x06000541 RID: 1345 RVA: 0x0001E245 File Offset: 0x0001C445
		public override void Clear()
		{
			this.Motor = null;
			this.Continue = false;
			base.Clear();
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001E25B File Offset: 0x0001C45B
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				CameraMessage.sPool.Release(this);
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001E280 File Offset: 0x0001C480
		public new static CameraMessage Allocate()
		{
			CameraMessage cameraMessage = CameraMessage.sPool.Allocate();
			if (cameraMessage == null)
			{
				cameraMessage = new CameraMessage();
			}
			cameraMessage.IsSent = false;
			cameraMessage.IsHandled = false;
			return cameraMessage;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
		public static CameraMessage Allocate(CameraMessage rSource)
		{
			CameraMessage cameraMessage = CameraMessage.sPool.Allocate();
			if (cameraMessage == null)
			{
				cameraMessage = new CameraMessage();
			}
			cameraMessage.ID = rSource.ID;
			cameraMessage.Motor = rSource.Motor;
			cameraMessage.Continue = rSource.Continue;
			cameraMessage.IsSent = false;
			cameraMessage.IsHandled = false;
			return cameraMessage;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001E304 File Offset: 0x0001C504
		public static void Release(CameraMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			CameraMessage.sPool.Release(rInstance);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001E329 File Offset: 0x0001C529
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is CameraMessage)
			{
				CameraMessage.sPool.Release((CameraMessage)rInstance);
			}
		}

		// Token: 0x0400029B RID: 667
		public static int MSG_CAMERA_MOTOR_UNKNOWN = 200;

		// Token: 0x0400029C RID: 668
		public static int MSG_CAMERA_MOTOR_ACTIVATE = 201;

		// Token: 0x0400029D RID: 669
		public static int MSG_CAMERA_MOTOR_DEACTIVATE = 202;

		// Token: 0x0400029E RID: 670
		public static int MSG_CAMERA_MOTOR_TEST = 203;

		// Token: 0x0400029F RID: 671
		public static string[] Names = new string[] { "Unknown", "Motor Activate", "Motor Deactivate", "Motor Test" };

		// Token: 0x040002A0 RID: 672
		public CameraMotor Motor;

		// Token: 0x040002A1 RID: 673
		public bool Continue;

		// Token: 0x040002A2 RID: 674
		private static ObjectPool<CameraMessage> sPool = new ObjectPool<CameraMessage>(10, 10);
	}
}
