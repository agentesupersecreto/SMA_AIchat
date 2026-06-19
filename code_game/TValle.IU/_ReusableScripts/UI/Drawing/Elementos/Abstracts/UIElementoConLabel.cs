using System;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000BC RID: 188
	[Obsolete("", true)]
	public abstract class UIElementoConLabel : UIElemento
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x00014ABF File Offset: 0x00012CBF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
		}

		// Token: 0x04000206 RID: 518
		public Text label;
	}
}
