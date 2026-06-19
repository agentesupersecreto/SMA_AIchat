using System;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x02000012 RID: 18
	[Model]
	public class JobWithClientDefaultMenuModel
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000042 RID: 66 RVA: 0x00002AA4 File Offset: 0x00000CA4
		// (remove) Token: 0x06000043 RID: 67 RVA: 0x00002ADC File Offset: 0x00000CDC
		public event Action<JobWithClientDefaultMenuModel> onShowModelInfo;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000044 RID: 68 RVA: 0x00002B14 File Offset: 0x00000D14
		// (remove) Token: 0x06000045 RID: 69 RVA: 0x00002B4C File Offset: 0x00000D4C
		public event Action<JobWithClientDefaultMenuModel> onShowClientInfo;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000046 RID: 70 RVA: 0x00002B84 File Offset: 0x00000D84
		// (remove) Token: 0x06000047 RID: 71 RVA: 0x00002BBC File Offset: 0x00000DBC
		public event Action<JobWithClientDefaultMenuModel> onLeave;

		// Token: 0x06000048 RID: 72 RVA: 0x00002BF1 File Offset: 0x00000DF1
		[Label("Model Curriculum", Language.en)]
		[Description("-Click here to see the model's measurements, interests, and current job skill.", Language.en)]
		public void ShowModelInfo()
		{
			Action<JobWithClientDefaultMenuModel> action = this.onShowModelInfo;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C04 File Offset: 0x00000E04
		[Label("Client Info", Language.en)]
		[Description("-Click here to see some information about the current client.", Language.en)]
		public void ShowClientInfo()
		{
			Action<JobWithClientDefaultMenuModel> action = this.onShowClientInfo;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002C17 File Offset: 0x00000E17
		[Label("Leave", Language.en)]
		[Description("-Exit the room and continue on with the rest of the day.", Language.en)]
		public void Leave()
		{
			Action<JobWithClientDefaultMenuModel> action = this.onLeave;
			if (action == null)
			{
				return;
			}
			action(this);
		}
	}
}
