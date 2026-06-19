using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200012F RID: 303
	public class SimpleLabelElement : UIElemento, IUIElementoConLabel, IUIElemento
	{
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x0001E060 File Offset: 0x0001C260
		public TextMeshProUGUI label
		{
			get
			{
				return this.text;
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001E068 File Offset: 0x0001C268
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.text == null)
			{
				throw new ArgumentNullException("text", "text null reference.");
			}
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001E096 File Offset: 0x0001C296
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0001E09E File Offset: 0x0001C29E
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400037B RID: 891
		public TextMeshProUGUI text;
	}
}
