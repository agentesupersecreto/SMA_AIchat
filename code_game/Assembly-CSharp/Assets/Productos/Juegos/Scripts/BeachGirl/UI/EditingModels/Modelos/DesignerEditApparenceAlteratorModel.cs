using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x0200008A RID: 138
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[HeightDinamico(dinamicoMethodTarget = "GetHeight")]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo)]
	[Serializable]
	public class DesignerEditApparenceAlteratorModel
	{
		// Token: 0x0600029F RID: 671 RVA: 0x0000FA24 File Offset: 0x0000DC24
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000FA2C File Offset: 0x0000DC2C
		public int GetHeight()
		{
			return 50 + this.sliders.Count * 30 + 20;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000FA44 File Offset: 0x0000DC44
		[MemberValueChangedListener(member = "sliders")]
		protected void OnSlider(IUIElementoConValor elemento)
		{
			if (this.sliders.ContieneIndex(elemento.modelItemIndex) && this.valores.ContieneIndex(elemento.modelItemIndex))
			{
				MultipleValorElemento<string, float> multipleValorElemento = this.sliders[elemento.modelItemIndex];
				float num = Convert.ToSingle(elemento.GetValor());
				multipleValorElemento.item2 = num;
				this.sliders[elemento.modelItemIndex] = multipleValorElemento;
				this.valores[elemento.modelItemIndex] = num;
				this.currentAlterador.ModificarValores(this.valores);
				return;
			}
			string text = "No se pudo actualizar el valro de alterador: ";
			Alterador alterador = this.currentAlterador;
			Debug.LogError(text + ((alterador != null) ? alterador.nombre : null));
		}

		// Token: 0x0400011F RID: 287
		[Ignore]
		[NonSerialized]
		public string title = "Alterator";

		// Token: 0x04000120 RID: 288
		[Ignore]
		public Alterador currentAlterador;

		// Token: 0x04000121 RID: 289
		public List<float> valores;

		// Token: 0x04000122 RID: 290
		[DeslizableLabelCorto(wholeNumbers = true, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		public List<MultipleValorElemento<string, float>> sliders;
	}
}
