using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000035 RID: 53
	public abstract class PanelBaseTrialModel<TModelA, TModelB, TModelC> : PanelBase where TModelA : class, new() where TModelB : class, new() where TModelC : class, new()
	{
		// Token: 0x040000B1 RID: 177
		[SerializeField]
		protected TModelA m_a = new TModelA();

		// Token: 0x040000B2 RID: 178
		[SerializeField]
		protected TModelB m_b = new TModelB();

		// Token: 0x040000B3 RID: 179
		[SerializeField]
		protected TModelC m_c = new TModelC();
	}
}
