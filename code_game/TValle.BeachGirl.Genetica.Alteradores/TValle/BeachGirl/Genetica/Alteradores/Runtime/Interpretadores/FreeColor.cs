using System;
using Assets.Base.Plugins.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000043 RID: 67
	[PanelLayout(alturaMinima = 130f, alturaPreferida = 130f)]
	[FontProConfigUI(alignmentUnity = TextAnchor.MiddleLeft, fontSize = 15)]
	[LayoutConfigUI(height = 20)]
	[Modelo]
	[NestedInterpretacion]
	[Serializable]
	public struct FreeColor
	{
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060002DF RID: 735 RVA: 0x00008204 File Offset: 0x00006404
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000820C File Offset: 0x0000640C
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

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00008215 File Offset: 0x00006415
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000821D File Offset: 0x0000641D
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

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00008226 File Offset: 0x00006426
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x0000822E File Offset: 0x0000642E
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

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00008237 File Offset: 0x00006437
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x0000823F File Offset: 0x0000643F
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

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00008248 File Offset: 0x00006448
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x00008250 File Offset: 0x00006450
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

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00008259 File Offset: 0x00006459
		// (set) Token: 0x060002EA RID: 746 RVA: 0x00008261 File Offset: 0x00006461
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

		// Token: 0x060002EB RID: 747 RVA: 0x0000826C File Offset: 0x0000646C
		public FreeColorAlpha ConvertToAlpha()
		{
			return new FreeColorAlpha
			{
				hue = this.m_hue,
				saturation = this.m_saturation,
				brightness = this.m_brightness,
				opacity = Interpretacion.Capacidad.veryHigh
			};
		}

		// Token: 0x04000122 RID: 290
		[SerializeField]
		private Hue m_hue;

		// Token: 0x04000123 RID: 291
		[SerializeField]
		private Interpretacion.Capacidad m_saturation;

		// Token: 0x04000124 RID: 292
		[SerializeField]
		private Interpretacion.Capacidad m_brightness;
	}
}
