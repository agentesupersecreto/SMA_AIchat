using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200011B RID: 283
	public class ClickableLabel : BotonElementBase, IUIElementoConLabel, IUIElemento
	{
		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x0001D416 File Offset: 0x0001B616
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0001D41E File Offset: 0x0001B61E
		protected override void OnElementoClicked()
		{
			base.CallEvents();
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x0001D42E File Offset: 0x0001B62E
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0001D436 File Offset: 0x0001B636
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400035C RID: 860
		public TextMeshProUGUI label;
	}
}
