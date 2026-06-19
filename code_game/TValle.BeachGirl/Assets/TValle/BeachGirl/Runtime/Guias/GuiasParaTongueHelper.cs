using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Guias
{
	// Token: 0x020000A8 RID: 168
	public class GuiasParaTongueHelper : CustomMonobehaviour
	{
		// Token: 0x04000304 RID: 772
		public Transform tongue01;

		// Token: 0x04000305 RID: 773
		public Transform tongue02;

		// Token: 0x04000306 RID: 774
		public Transform tongue03;

		// Token: 0x04000307 RID: 775
		public GuiasParaTongueHelper.Guias guias = new GuiasParaTongueHelper.Guias();

		// Token: 0x02000197 RID: 407
		[Serializable]
		public class Guias
		{
			// Token: 0x04000928 RID: 2344
			public Transform middle;

			// Token: 0x04000929 RID: 2345
			public Transform middle001;

			// Token: 0x0400092A RID: 2346
			public Transform middle002;

			// Token: 0x0400092B RID: 2347
			public Transform l;

			// Token: 0x0400092C RID: 2348
			public Transform r;

			// Token: 0x0400092D RID: 2349
			public Transform l001;

			// Token: 0x0400092E RID: 2350
			public Transform r001;

			// Token: 0x0400092F RID: 2351
			public Transform l002;

			// Token: 0x04000930 RID: 2352
			public Transform r002;
		}
	}
}
