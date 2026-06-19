using System;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts
{
	// Token: 0x020000BD RID: 189
	[Obsolete("", true)]
	public abstract class UIElementoConLabelYDescripcion : UIElementoConLabel
	{
		// Token: 0x0600054E RID: 1358 RVA: 0x00014AED File Offset: 0x00012CED
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.descripcion == null)
			{
				throw new ArgumentNullException("descripcion", "descripcion null reference.");
			}
		}

		// Token: 0x04000207 RID: 519
		public Text descripcion;
	}
}
