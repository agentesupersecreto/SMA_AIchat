using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000088 RID: 136
	public class BotonElement : BotonElementBase, IUIElementoConLabel, IUIElemento
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x00011332 File Offset: 0x0000F532
		public Button boton
		{
			get
			{
				return this.m_boton;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x0001133A File Offset: 0x0000F53A
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00011342 File Offset: 0x0000F542
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00011368 File Offset: 0x0000F568
		protected override void OnElementoClicked()
		{
			base.CallEvents();
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00011378 File Offset: 0x0000F578
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00011380 File Offset: 0x0000F580
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000158 RID: 344
		public TextMeshProUGUI label;
	}
}
