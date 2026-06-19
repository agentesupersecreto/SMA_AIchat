using System;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x02000013 RID: 19
	[Model]
	public class JobWithEmployerDefaultMenuModel
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600004C RID: 76 RVA: 0x00002C34 File Offset: 0x00000E34
		// (remove) Token: 0x0600004D RID: 77 RVA: 0x00002C6C File Offset: 0x00000E6C
		public event Action onShowModelInfo;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600004E RID: 78 RVA: 0x00002CA4 File Offset: 0x00000EA4
		// (remove) Token: 0x0600004F RID: 79 RVA: 0x00002CDC File Offset: 0x00000EDC
		public event Action onShowEmployerInfo;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000050 RID: 80 RVA: 0x00002D14 File Offset: 0x00000F14
		// (remove) Token: 0x06000051 RID: 81 RVA: 0x00002D4C File Offset: 0x00000F4C
		public event Action onModelDismissed;

		// Token: 0x06000052 RID: 82 RVA: 0x00002D81 File Offset: 0x00000F81
		[Label("Model Curriculum", Language.en)]
		[Description("-Click here to see the model's measurements, interests, and current job skill.", Language.en)]
		public void ShowModelInfo()
		{
			Action action = this.onShowModelInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002D93 File Offset: 0x00000F93
		[Label("Employer Info", Language.en)]
		[Description("-Click here to see some information about the current employer.", Language.en)]
		public void ShowClientInfo()
		{
			Action action = this.onShowEmployerInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002DA5 File Offset: 0x00000FA5
		[Label("Conclude Assignment", Language.en)]
		[Description("-Concludes the assignment.", Language.en)]
		public void DismissClient()
		{
			Action action = this.onModelDismissed;
			if (action == null)
			{
				return;
			}
			action();
		}
	}
}
