using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000034 RID: 52
	public abstract class PanelBaseDualModel<TModelA, TModelB> : PanelBase where TModelA : class, new() where TModelB : class, new()
	{
		// Token: 0x040000AF RID: 175
		[SerializeField]
		protected TModelA m_a = new TModelA();

		// Token: 0x040000B0 RID: 176
		[SerializeField]
		protected TModelB m_b = new TModelB();
	}
}
