using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x0200008A RID: 138
	public class BotonIconElementConToolTip : BotonElementBase, IUIElementoConDescripcionSimple, IUIElemento
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00011402 File Offset: 0x0000F602
		public Button boton
		{
			get
			{
				return this.m_boton;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x0001140A File Offset: 0x0000F60A
		// (set) Token: 0x06000421 RID: 1057 RVA: 0x00011417 File Offset: 0x0000F617
		string IUIElementoConDescripcionSimple.descripcion
		{
			get
			{
				return this.tooltip.infoLeft;
			}
			set
			{
				this.tooltip.infoLeft = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00011425 File Offset: 0x0000F625
		// (set) Token: 0x06000423 RID: 1059 RVA: 0x00011432 File Offset: 0x0000F632
		float IUIElementoConDescripcionSimple.widthMod
		{
			get
			{
				return this.tooltip.widthMod;
			}
			set
			{
				this.tooltip.widthMod = value;
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00011440 File Offset: 0x0000F640
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.tooltip == null)
			{
				throw new ArgumentNullException("tooltip", "tooltip null reference.");
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00011466 File Offset: 0x0000F666
		protected override void OnElementoClicked()
		{
			base.CallEvents();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00011476 File Offset: 0x0000F676
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001147E File Offset: 0x0000F67E
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400015B RID: 347
		public SimpleTooltip tooltip;
	}
}
