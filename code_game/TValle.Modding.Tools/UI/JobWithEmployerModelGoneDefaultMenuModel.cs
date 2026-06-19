using System;

namespace Assets.TValle.Tools.Runtime.UI
{
	// Token: 0x02000014 RID: 20
	[Model]
	public class JobWithEmployerModelGoneDefaultMenuModel
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000056 RID: 86 RVA: 0x00002DC0 File Offset: 0x00000FC0
		// (remove) Token: 0x06000057 RID: 87 RVA: 0x00002DF8 File Offset: 0x00000FF8
		public event Action onShowEmployerInfo;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000058 RID: 88 RVA: 0x00002E30 File Offset: 0x00001030
		// (remove) Token: 0x06000059 RID: 89 RVA: 0x00002E68 File Offset: 0x00001068
		public event Action onEndSession;

		// Token: 0x0600005A RID: 90 RVA: 0x00002E9D File Offset: 0x0000109D
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

		// Token: 0x0600005B RID: 91 RVA: 0x00002EAF File Offset: 0x000010AF
		[Label("Conclude Assignment", Language.en)]
		[Description("-Concludes the assignment.", Language.en)]
		public void EndSession()
		{
			Action action = this.onEndSession;
			if (action == null)
			{
				return;
			}
			action();
		}
	}
}
