using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000132 RID: 306
	public class ToggleElement : ToggleElementSinDescripcion, IUIElementoConDescripcion, IUIElemento
	{
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x0001E29B File Offset: 0x0001C49B
		TextMeshProUGUI IUIElementoConDescripcion.descripcion
		{
			get
			{
				return this.descripcion;
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0001E2A3 File Offset: 0x0001C4A3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.descripcion == null)
			{
				throw new ArgumentNullException("descripcion", "descripcion null reference.");
			}
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0001E2D1 File Offset: 0x0001C4D1
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0001E2D9 File Offset: 0x0001C4D9
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400038D RID: 909
		public TextMeshProUGUI descripcion;
	}
}
