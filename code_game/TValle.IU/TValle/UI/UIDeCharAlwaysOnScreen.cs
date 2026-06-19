using System;
using UnityEngine;

namespace Assets.TValle.UI
{
	// Token: 0x020000C4 RID: 196
	[RequireComponent(typeof(Canvas))]
	public class UIDeCharAlwaysOnScreen : AlwaysOnScreenBase
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x000152AA File Offset: 0x000134AA
		protected override Vector3 curretnSorcePosition
		{
			get
			{
				return this.m_char.worldHeadPosition;
			}
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x000152B7 File Offset: 0x000134B7
		protected override void StartUnityEvent()
		{
			this.m_char = base.GetComponentInParent<ICharacter>();
			if (this.m_char == null)
			{
				throw new ArgumentNullException("m_char", "m_char null reference.");
			}
			base.StartUnityEvent();
		}

		// Token: 0x04000218 RID: 536
		private ICharacter m_char;
	}
}
