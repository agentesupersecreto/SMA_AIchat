using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x02000090 RID: 144
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, height = 170)]
	[UnTittle]
	[Serializable]
	public class DesignerEditOutfitEditMaterialModel
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060002D8 RID: 728 RVA: 0x0001052C File Offset: 0x0000E72C
		// (remove) Token: 0x060002D9 RID: 729 RVA: 0x00010564 File Offset: 0x0000E764
		public event Action<MaterialParaRopaData, DesignerEditOutfitEditMaterialModel> materialChanged;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060002DA RID: 730 RVA: 0x0001059C File Offset: 0x0000E79C
		// (remove) Token: 0x060002DB RID: 731 RVA: 0x000105D4 File Offset: 0x0000E7D4
		public event Action<Color, DesignerEditOutfitEditMaterialModel> colorChanged;

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00010609 File Offset: 0x0000E809
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00010611 File Offset: 0x0000E811
		[Ignore]
		[ModeloExtraData(para = "material")]
		public string[] materialesPosiblesDisplay { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0001061C File Offset: 0x0000E81C
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00010668 File Offset: 0x0000E868
		[Ignore]
		public Color color
		{
			get
			{
				Color color = Color.HSVToRGB(this.hue / 100f, this.saturation / 100f, this.value / 100f);
				color.a = this.alpha / 100f;
				return color;
			}
			set
			{
				float num;
				float num2;
				float num3;
				Color.RGBToHSV(value, out num, out num2, out num3);
				this.hue = num * 100f;
				this.saturation = num2 * 100f;
				this.value = num3 * 100f;
				this.alpha = value.a * 100f;
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000106BC File Offset: 0x0000E8BC
		[MemberValueChangedListener(member = "material")]
		protected void OnMaterialChanged(IUIElementoConValor elemento)
		{
			string text = elemento.GetValor() as string;
			if (string.IsNullOrWhiteSpace(text))
			{
				Debug.LogError("No se pudo actualizar material : " + text);
				return;
			}
			this.material = text;
			int num = this.materialesPosiblesDisplay.IndexOf(this.material);
			if (num < 0 || !this.materialsData.ContieneIndex(num))
			{
				Debug.LogError("No se pudo actualizar material : " + this.material);
				return;
			}
			Action<MaterialParaRopaData, DesignerEditOutfitEditMaterialModel> action = this.materialChanged;
			if (action == null)
			{
				return;
			}
			action(this.materialsData[num], this);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0001074C File Offset: 0x0000E94C
		private void OnColorChanged()
		{
			Action<Color, DesignerEditOutfitEditMaterialModel> action = this.colorChanged;
			if (action == null)
			{
				return;
			}
			action(this.color, this);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00010765 File Offset: 0x0000E965
		[MemberValueChangedListener(member = "hue")]
		protected void OnHueChanged(IUIElementoConValor elemento)
		{
			this.hue = Convert.ToSingle(elemento.GetValor());
			this.OnColorChanged();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0001077E File Offset: 0x0000E97E
		[MemberValueChangedListener(member = "saturation")]
		protected void OnSaturationChanged(IUIElementoConValor elemento)
		{
			this.saturation = Convert.ToSingle(elemento.GetValor());
			this.OnColorChanged();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00010797 File Offset: 0x0000E997
		[MemberValueChangedListener(member = "value")]
		protected void OnValueChanged(IUIElementoConValor elemento)
		{
			this.value = Convert.ToSingle(elemento.GetValor());
			this.OnColorChanged();
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000107B0 File Offset: 0x0000E9B0
		[MemberValueChangedListener(member = "alpha")]
		protected void OnAlphaChanged(IUIElementoConValor elemento)
		{
			this.alpha = Convert.ToSingle(elemento.GetValor());
			this.OnColorChanged();
		}

		// Token: 0x04000138 RID: 312
		public const int height = 170;

		// Token: 0x0400013B RID: 315
		public int materialIndex;

		// Token: 0x0400013D RID: 317
		[Ignore]
		public List<MaterialParaRopaData> materialsData;

		// Token: 0x0400013E RID: 318
		[Label("Material", "US")]
		[DescripcionLocalizado("Some materials do not allow color alteration; check for materials named 'Blanco'", "US")]
		[DesplegableLabelCorto]
		public string material;

		// Token: 0x0400013F RID: 319
		[Label("Hue", "US")]
		[DeslizableLabelCorto(wholeNumbers = false, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		public float hue;

		// Token: 0x04000140 RID: 320
		[Label("Saturation", "US")]
		[DeslizableLabelCorto(wholeNumbers = false, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		public float saturation;

		// Token: 0x04000141 RID: 321
		[Label("Value", "US")]
		[DeslizableLabelCorto(wholeNumbers = false, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		public float value;

		// Token: 0x04000142 RID: 322
		[Label("Alpha", "US")]
		[DescripcionLocalizado("Some materials are incompatible with transparency; look for the word 'transparente' in the name.", "US")]
		[DeslizableLabelCorto(wholeNumbers = false, decimalesDibujar = 0)]
		[Range(0f, 100f)]
		public float alpha;
	}
}
