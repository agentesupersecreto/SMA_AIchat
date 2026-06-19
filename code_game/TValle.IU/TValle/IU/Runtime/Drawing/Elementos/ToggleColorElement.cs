using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000131 RID: 305
	public class ToggleColorElement : ToggleElementSinDescripcion, IUIElementoConExtraData, IUIElemento
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x0001E11F File Offset: 0x0001C31F
		// (set) Token: 0x060008E8 RID: 2280 RVA: 0x0001E127 File Offset: 0x0001C327
		public IReadOnlyList<Func<object>> extradata
		{
			get
			{
				return this.m_extradata;
			}
			set
			{
				this.m_extradata = (List<Func<object>>)value;
			}
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001E135 File Offset: 0x0001C335
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.m_Hue = (Hue)this.m_extradata[0]();
			this.SetColor();
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001E162 File Offset: 0x0001C362
		public override void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, initialValue, isListItem);
			this.m_Hue = (Hue)this.m_extradata[0]();
			this.SetColor();
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0001E191 File Offset: 0x0001C391
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!base.isBinded)
			{
				this.SetColor();
			}
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0001E1A8 File Offset: 0x0001C3A8
		private void SetColor()
		{
			Sprite sprite;
			switch (this.m_Hue)
			{
			case Hue.rojo:
				sprite = this.m_Red;
				break;
			case Hue.naranja:
				sprite = this.m_Orange;
				break;
			case Hue.amarillo:
				sprite = this.m_Yellow;
				break;
			case Hue.chartreuse:
				sprite = this.m_Chartreuse;
				break;
			case Hue.verde:
				sprite = this.m_Green;
				break;
			case Hue.acuamarino:
				sprite = this.m_Aquamarine;
				break;
			case Hue.aquaBlue:
				sprite = this.m_AquaBlue;
				break;
			case Hue.cobalt:
				sprite = this.m_Cobalt;
				break;
			case Hue.azul:
				sprite = this.m_Blue;
				break;
			case Hue.violeta:
				sprite = this.m_Violet;
				break;
			case Hue.morado:
				sprite = this.m_Purple;
				break;
			case Hue.magenta:
				sprite = this.m_Magenta;
				break;
			default:
				throw new ArgumentOutOfRangeException(this.m_Hue.ToString());
			}
			this.m_ColorImage.sprite = sprite;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001E28B File Offset: 0x0001C48B
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0001E293 File Offset: 0x0001C493
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400037E RID: 894
		private List<Func<object>> m_extradata;

		// Token: 0x0400037F RID: 895
		[SerializeField]
		private Hue m_Hue;

		// Token: 0x04000380 RID: 896
		[SerializeField]
		private Image m_ColorImage;

		// Token: 0x04000381 RID: 897
		[SerializeField]
		private Sprite m_Red;

		// Token: 0x04000382 RID: 898
		[SerializeField]
		private Sprite m_Orange;

		// Token: 0x04000383 RID: 899
		[SerializeField]
		private Sprite m_Yellow;

		// Token: 0x04000384 RID: 900
		[SerializeField]
		private Sprite m_Chartreuse;

		// Token: 0x04000385 RID: 901
		[SerializeField]
		private Sprite m_Green;

		// Token: 0x04000386 RID: 902
		[SerializeField]
		private Sprite m_Aquamarine;

		// Token: 0x04000387 RID: 903
		[SerializeField]
		private Sprite m_AquaBlue;

		// Token: 0x04000388 RID: 904
		[SerializeField]
		private Sprite m_Cobalt;

		// Token: 0x04000389 RID: 905
		[SerializeField]
		private Sprite m_Blue;

		// Token: 0x0400038A RID: 906
		[SerializeField]
		private Sprite m_Violet;

		// Token: 0x0400038B RID: 907
		[SerializeField]
		private Sprite m_Purple;

		// Token: 0x0400038C RID: 908
		[SerializeField]
		private Sprite m_Magenta;
	}
}
