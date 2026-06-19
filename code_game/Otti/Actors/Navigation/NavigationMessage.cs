using System;
using com.ootii.Collections;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.Navigation
{
	// Token: 0x0200009B RID: 155
	public class NavigationMessage : Message
	{
		// Token: 0x060008AE RID: 2222 RVA: 0x0002EBD3 File Offset: 0x0002CDD3
		public override void Clear()
		{
			this.Owner = null;
			base.Clear();
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0002EBE2 File Offset: 0x0002CDE2
		public new virtual void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				NavigationMessage.sPool.Release(this);
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0002EC08 File Offset: 0x0002CE08
		public new static NavigationMessage Allocate()
		{
			NavigationMessage navigationMessage = NavigationMessage.sPool.Allocate();
			navigationMessage.IsSent = false;
			navigationMessage.IsHandled = false;
			if (navigationMessage == null)
			{
				navigationMessage = new NavigationMessage();
			}
			return navigationMessage;
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0002EC38 File Offset: 0x0002CE38
		public static void Release(NavigationMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			NavigationMessage.sPool.Release(rInstance);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0002EC5D File Offset: 0x0002CE5D
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is NavigationMessage)
			{
				NavigationMessage.sPool.Release((NavigationMessage)rInstance);
			}
		}

		// Token: 0x0400046D RID: 1133
		public static int MSG_UNKNOWN = 0;

		// Token: 0x0400046E RID: 1134
		public static int MSG_NAVIGATE_ARRIVED = 1;

		// Token: 0x0400046F RID: 1135
		public static int MSG_NAVIGATE_SLOW_ENTERED = 2;

		// Token: 0x04000470 RID: 1136
		public static int MSG_NAVIGATE_WALK = 5;

		// Token: 0x04000471 RID: 1137
		public static int MSG_NAVIGATE_JUMP = 10;

		// Token: 0x04000472 RID: 1138
		public static int MSG_NAVIGATE_CLIMB = 15;

		// Token: 0x04000473 RID: 1139
		public static int MSG_NAVIGATE_PUSHED_BACK = 20;

		// Token: 0x04000474 RID: 1140
		public static int MSG_NAVIGATE_KNOCKED_DOWN = 25;

		// Token: 0x04000475 RID: 1141
		public GameObject Owner;

		// Token: 0x04000476 RID: 1142
		private static ObjectPool<NavigationMessage> sPool = new ObjectPool<NavigationMessage>(40, 10);
	}
}
