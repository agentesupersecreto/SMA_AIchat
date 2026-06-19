using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200011E RID: 286
	public class ImagenFieldElement : UIElemento, IUIElementoConDescripcionSimple, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura
	{
		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x0001D88F File Offset: 0x0001BA8F
		// (set) Token: 0x06000892 RID: 2194 RVA: 0x0001D89C File Offset: 0x0001BA9C
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

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x0001D8AA File Offset: 0x0001BAAA
		// (set) Token: 0x06000894 RID: 2196 RVA: 0x0001D8B7 File Offset: 0x0001BAB7
		public string descripcion
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

		// Token: 0x06000895 RID: 2197 RVA: 0x0001D8C5 File Offset: 0x0001BAC5
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.imagen.texture = initialValue as Texture;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0001D8E2 File Offset: 0x0001BAE2
		public object GetValor()
		{
			return this.imagen.texture;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0001D8EF File Offset: 0x0001BAEF
		public void SetValor(object valor, bool silenced)
		{
			this.imagen.texture = valor as Texture;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0001D90A File Offset: 0x0001BB0A
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0001D912 File Offset: 0x0001BB12
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400036C RID: 876
		public SimpleTooltip tooltip;

		// Token: 0x0400036D RID: 877
		public RawImage imagen;
	}
}
