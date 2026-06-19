using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing
{
	// Token: 0x020000ED RID: 237
	public class GenericUserPanel : GenericUserPanelBase
	{
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00019F27 File Offset: 0x00018127
		public override Transform target
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00019F2F File Offset: 0x0001812F
		protected override void Binded()
		{
			this.target.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = 5;
			}, true);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00019F5C File Offset: 0x0001815C
		protected override void Binding()
		{
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00019F5E File Offset: 0x0001815E
		protected override void Cleared()
		{
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00019F60 File Offset: 0x00018160
		protected override void Clearing()
		{
		}
	}
}
