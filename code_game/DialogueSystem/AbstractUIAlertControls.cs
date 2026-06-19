using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000263 RID: 611
	[Serializable]
	public abstract class AbstractUIAlertControls : AbstractUIControls
	{
		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x06001A79 RID: 6777
		public abstract bool IsVisible { get; }

		// Token: 0x06001A7A RID: 6778
		public abstract void SetMessage(string message, float duration);

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x06001A7B RID: 6779 RVA: 0x0002D52C File Offset: 0x0002B72C
		public virtual bool IsDone
		{
			get
			{
				return DialogueTime.time > this.alertDoneTime;
			}
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x0002D53C File Offset: 0x0002B73C
		public virtual void ShowMessage(string message, float duration)
		{
			if (!string.IsNullOrEmpty(message))
			{
				this.alertDoneTime = DialogueTime.time + duration;
				this.SetMessage(message, duration);
				base.Show();
			}
			else
			{
				base.Hide();
			}
		}

		// Token: 0x04000EFD RID: 3837
		protected float alertDoneTime;
	}
}
