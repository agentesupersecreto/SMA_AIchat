using System;
using com.ootii.Collections;

namespace com.ootii.Messages
{
	// Token: 0x02000022 RID: 34
	public class Message : IMessage
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000A762 File Offset: 0x00008962
		// (set) Token: 0x060001BF RID: 447 RVA: 0x0000A76A File Offset: 0x0000896A
		public string Type
		{
			get
			{
				return this.mType;
			}
			set
			{
				this.mType = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000A773 File Offset: 0x00008973
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000A77B File Offset: 0x0000897B
		public object Sender
		{
			get
			{
				return this.mSender;
			}
			set
			{
				this.mSender = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000A784 File Offset: 0x00008984
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000A78C File Offset: 0x0000898C
		public object Recipient
		{
			get
			{
				return this.mRecipient;
			}
			set
			{
				this.mRecipient = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000A795 File Offset: 0x00008995
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000A79D File Offset: 0x0000899D
		public float Delay
		{
			get
			{
				return this.mDelay;
			}
			set
			{
				this.mDelay = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000A7A6 File Offset: 0x000089A6
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x0000A7AE File Offset: 0x000089AE
		public int ID
		{
			get
			{
				return this.mID;
			}
			set
			{
				this.mID = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000A7B7 File Offset: 0x000089B7
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x0000A7BF File Offset: 0x000089BF
		public object Data
		{
			get
			{
				return this.mData;
			}
			set
			{
				this.mData = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001CA RID: 458 RVA: 0x0000A7C8 File Offset: 0x000089C8
		// (set) Token: 0x060001CB RID: 459 RVA: 0x0000A7D0 File Offset: 0x000089D0
		public bool IsSent
		{
			get
			{
				return this.mIsSent;
			}
			set
			{
				this.mIsSent = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001CC RID: 460 RVA: 0x0000A7D9 File Offset: 0x000089D9
		// (set) Token: 0x060001CD RID: 461 RVA: 0x0000A7E1 File Offset: 0x000089E1
		public bool IsHandled
		{
			get
			{
				return this.mIsHandled;
			}
			set
			{
				this.mIsHandled = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001CE RID: 462 RVA: 0x0000A7EA File Offset: 0x000089EA
		// (set) Token: 0x060001CF RID: 463 RVA: 0x0000A7F2 File Offset: 0x000089F2
		public int FrameIndex
		{
			get
			{
				return this.mFrameIndex;
			}
			set
			{
				this.mFrameIndex = value;
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000A7FC File Offset: 0x000089FC
		public virtual void Clear()
		{
			this.mType = "";
			this.mSender = null;
			this.mRecipient = null;
			this.mID = 0;
			this.mData = null;
			this.mIsSent = false;
			this.mIsHandled = false;
			this.mDelay = 0f;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000A849 File Offset: 0x00008A49
		public virtual void Release()
		{
			this.Clear();
			this.IsSent = true;
			this.IsHandled = true;
			if (this != null)
			{
				Message.sPool.Release(this);
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000A870 File Offset: 0x00008A70
		public static Message Allocate()
		{
			Message message = Message.sPool.Allocate();
			message.IsSent = false;
			message.IsHandled = false;
			if (message == null)
			{
				message = new Message();
			}
			return message;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		public static void Release(Message rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			Message.sPool.Release(rInstance);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000A8BF File Offset: 0x00008ABF
		public static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is Message)
			{
				Message.sPool.Release((Message)rInstance);
			}
		}

		// Token: 0x04000139 RID: 313
		protected string mType = "";

		// Token: 0x0400013A RID: 314
		protected object mSender;

		// Token: 0x0400013B RID: 315
		protected object mRecipient;

		// Token: 0x0400013C RID: 316
		protected float mDelay;

		// Token: 0x0400013D RID: 317
		protected int mID;

		// Token: 0x0400013E RID: 318
		protected object mData;

		// Token: 0x0400013F RID: 319
		protected bool mIsSent;

		// Token: 0x04000140 RID: 320
		protected bool mIsHandled;

		// Token: 0x04000141 RID: 321
		protected int mFrameIndex;

		// Token: 0x04000142 RID: 322
		private static ObjectPool<Message> sPool = new ObjectPool<Message>(40, 10);
	}
}
