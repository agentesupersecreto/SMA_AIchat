using System;
using Assets.Base.Plugins.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000044 RID: 68
	[PanelLayout(alturaMinima = 160f, alturaPreferida = 160f)]
	[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
	[LayoutConfigUI(height = 20)]
	[Modelo]
	[NestedInterpretacion]
	[Serializable]
	public struct FreeColorAlpha
	{
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060002EC RID: 748 RVA: 0x000082B1 File Offset: 0x000064B1
		// (set) Token: 0x060002ED RID: 749 RVA: 0x000082B9 File Offset: 0x000064B9
		[LabelLocalizado("Hue", "US")]
		public Hue hue
		{
			get
			{
				return this.m_hue;
			}
			set
			{
				this.m_hue = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060002EE RID: 750 RVA: 0x000082C2 File Offset: 0x000064C2
		// (set) Token: 0x060002EF RID: 751 RVA: 0x000082CA File Offset: 0x000064CA
		[LabelLocalizado("Saturation", "US")]
		public Interpretacion.Capacidad saturation
		{
			get
			{
				return this.m_saturation;
			}
			set
			{
				this.m_saturation = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000082D3 File Offset: 0x000064D3
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000082DB File Offset: 0x000064DB
		[LabelLocalizado("Brightness", "US")]
		public Interpretacion.Capacidad brightness
		{
			get
			{
				return this.m_brightness;
			}
			set
			{
				this.m_brightness = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000082E4 File Offset: 0x000064E4
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x000082EC File Offset: 0x000064EC
		[LabelLocalizado("Opacity", "US")]
		public Interpretacion.Capacidad opacity
		{
			get
			{
				return this.m_opacity;
			}
			set
			{
				this.m_opacity = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x000082F5 File Offset: 0x000064F5
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x000082FD File Offset: 0x000064FD
		public int hueValor
		{
			get
			{
				return (int)this.m_hue;
			}
			set
			{
				this.m_hue = (Hue)value;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00008306 File Offset: 0x00006506
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x0000830E File Offset: 0x0000650E
		public int saturationValor
		{
			get
			{
				return (int)this.m_saturation;
			}
			set
			{
				this.m_saturation = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00008317 File Offset: 0x00006517
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000831F File Offset: 0x0000651F
		public int brightnessValor
		{
			get
			{
				return (int)this.m_brightness;
			}
			set
			{
				this.m_brightness = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060002FA RID: 762 RVA: 0x00008328 File Offset: 0x00006528
		// (set) Token: 0x060002FB RID: 763 RVA: 0x00008330 File Offset: 0x00006530
		public int opacityValor
		{
			get
			{
				return (int)this.m_opacity;
			}
			set
			{
				this.m_opacity = (Interpretacion.Capacidad)value;
			}
		}

		// Token: 0x04000125 RID: 293
		[SerializeField]
		private Hue m_hue;

		// Token: 0x04000126 RID: 294
		[SerializeField]
		private Interpretacion.Capacidad m_saturation;

		// Token: 0x04000127 RID: 295
		[SerializeField]
		private Interpretacion.Capacidad m_brightness;

		// Token: 0x04000128 RID: 296
		[SerializeField]
		private Interpretacion.Capacidad m_opacity;
	}
}
