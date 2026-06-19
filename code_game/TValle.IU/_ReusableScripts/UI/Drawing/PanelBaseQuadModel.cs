using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000036 RID: 54
	public abstract class PanelBaseQuadModel<TModelA, TModelB, TModelC, TModelD> : PanelBase where TModelA : class, new() where TModelB : class, new() where TModelC : class, new() where TModelD : class, new()
	{
		// Token: 0x040000B4 RID: 180
		[SerializeField]
		protected TModelA m_a = new TModelA();

		// Token: 0x040000B5 RID: 181
		[SerializeField]
		protected TModelB m_b = new TModelB();

		// Token: 0x040000B6 RID: 182
		[SerializeField]
		protected TModelC m_c = new TModelC();

		// Token: 0x040000B7 RID: 183
		[SerializeField]
		protected TModelD m_d = new TModelD();
	}
}
