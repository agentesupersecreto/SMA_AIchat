using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000328 RID: 808
	[Obsolete]
	[Serializable]
	public abstract class FrameStimuloValue
	{
		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06001176 RID: 4470 RVA: 0x0004B425 File Offset: 0x00049625
		public bool estimulado
		{
			get
			{
				return this.Total() > 0f;
			}
		}

		// Token: 0x06001177 RID: 4471
		protected abstract float total();

		// Token: 0x06001178 RID: 4472 RVA: 0x0004B434 File Offset: 0x00049634
		public float Total()
		{
			if (!this.activo)
			{
				return 0f;
			}
			return this.total();
		}

		// Token: 0x06001179 RID: 4473
		public abstract void Clear();

		// Token: 0x04000DE6 RID: 3558
		public bool activo = true;
	}
}
