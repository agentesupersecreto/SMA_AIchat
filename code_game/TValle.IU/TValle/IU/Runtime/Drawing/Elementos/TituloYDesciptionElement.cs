using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000130 RID: 304
	public class TituloYDesciptionElement : UIElemento, IUIElementoConLabel, IUIElemento, IUIElementoConDescripcion
	{
		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x0001E0A6 File Offset: 0x0001C2A6
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0001E0AE File Offset: 0x0001C2AE
		TextMeshProUGUI IUIElementoConDescripcion.descripcion
		{
			get
			{
				return this.descripcion;
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0001E0B8 File Offset: 0x0001C2B8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.descripcion == null)
			{
				throw new ArgumentNullException("descripcion", "descripcion null reference.");
			}
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0001E10F File Offset: 0x0001C30F
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0001E117 File Offset: 0x0001C317
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400037C RID: 892
		public TextMeshProUGUI label;

		// Token: 0x0400037D RID: 893
		public TextMeshProUGUI descripcion;
	}
}
