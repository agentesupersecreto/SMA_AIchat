using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x0200008D RID: 141
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, width = 350)]
	[Serializable]
	public class DesignerEditOutfitTypeExistentesModel
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0000FDE7 File Offset: 0x0000DFE7
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060002BD RID: 701 RVA: 0x0000FDF0 File Offset: 0x0000DFF0
		// (remove) Token: 0x060002BE RID: 702 RVA: 0x0000FE28 File Offset: 0x0000E028
		public event Action<string> itemClicked;

		// Token: 0x060002BF RID: 703 RVA: 0x0000FE60 File Offset: 0x0000E060
		public void LoadElements(MapaDeRopa.TipoDePrenda tipo)
		{
			RopaParaAvatarUnificado singleton = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			this.piezas = (from d in singleton.prendasPorTipo[tipo]
				where singleton.PiezaEsMainPrenda(d.stringId) && d.paraSexo == Sexo.femenino
				select new MultipleValorElemento<string, object>(d.nombreCompleto, d.stringId)).ToList<MultipleValorElemento<string, object>>();
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000FED0 File Offset: 0x0000E0D0
		[MemberBotonClickedListener(member = "piezas")]
		protected void OnPiezaClicked(IUIBoton elemento)
		{
			MultipleValorElemento<string, object> valueOrDefault = this.piezas.GetValueOrDefault(elemento.modelItemIndex);
			IUIElementoConValor iuielementoConValor = elemento as IUIElementoConValor;
			string text = null;
			if (iuielementoConValor != null)
			{
				text = iuielementoConValor.GetValor() as string;
			}
			if (text == null)
			{
				text = valueOrDefault.item2 as string;
			}
			if (text == null)
			{
				Debug.LogError("No se pudo obtener el id de prenda seleccionada " + valueOrDefault.item1);
				return;
			}
			Action<string> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(text);
		}

		// Token: 0x0400012A RID: 298
		[Ignore]
		[NonSerialized]
		public string title = "Select an item to add";

		// Token: 0x0400012C RID: 300
		[ClickableLabelConValor]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		public List<MultipleValorElemento<string, object>> piezas;
	}
}
