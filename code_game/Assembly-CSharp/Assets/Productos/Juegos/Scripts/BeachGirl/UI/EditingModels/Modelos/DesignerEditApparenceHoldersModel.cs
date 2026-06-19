using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos
{
	// Token: 0x02000088 RID: 136
	[Modelo]
	[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, width = 300)]
	[Serializable]
	public class DesignerEditApparenceHoldersModel
	{
		// Token: 0x06000297 RID: 663 RVA: 0x0000F804 File Offset: 0x0000DA04
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000298 RID: 664 RVA: 0x0000F80C File Offset: 0x0000DA0C
		// (remove) Token: 0x06000299 RID: 665 RVA: 0x0000F844 File Offset: 0x0000DA44
		public event Action<MultipleValorElemento<string, object>, int, HolderDeAlteradores> itemClicked;

		// Token: 0x0600029A RID: 666 RVA: 0x0000F87C File Offset: 0x0000DA7C
		public void LoadElements()
		{
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			if (current == null)
			{
				Debug.LogError("No se pudo obtener el personaje target");
				return;
			}
			Character character = current.character;
			AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina = ((character != null) ? character.GetComponentInChildren<AlteradoresDeAparienciaFemenina>() : null);
			if (alteradoresDeAparienciaFemenina == null)
			{
				string text = "No se pudo obtener appariencia fisica de personaje ";
				Character character2 = current.character;
				Debug.LogError(text + ((character2 != null) ? character2.nombreCompleto : null), current);
				return;
			}
			this.holders = (from h in alteradoresDeAparienciaFemenina.GetComponentsInChildren<HolderDeAlteradores>()
				select new MultipleValorElemento<string, object>(DibujadorDynamico.instance.GetCurrentLabelOrDefaul<LabelLocalizadoAttribute>(h.GetType()), new SerializableType(h.GetType()))).ToList<MultipleValorElemento<string, object>>();
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000F918 File Offset: 0x0000DB18
		[MemberBotonClickedListener(member = "holders")]
		protected void OnHolderClicked(IUIBoton elemento)
		{
			IUIElementoConValor iuielementoConValor = elemento as IUIElementoConValor;
			MultipleValorElemento<string, object> valueOrDefault = this.holders.GetValueOrDefault(elemento.modelItemIndex);
			SerializableType serializableType = null;
			if (iuielementoConValor != null)
			{
				serializableType = iuielementoConValor.GetValor() as SerializableType;
			}
			if (serializableType == null)
			{
				serializableType = valueOrDefault.item2 as SerializableType;
			}
			if (serializableType == null)
			{
				Debug.LogError("No se pudo obtener el typo de holder de alteradores de nombre " + valueOrDefault.item1);
				return;
			}
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			if (current == null)
			{
				Debug.LogError("No se pudo obtener el personaje target");
				return;
			}
			Character character = current.character;
			HolderDeAlteradores holderDeAlteradores = ((character != null) ? character.GetComponentInChildren(serializableType.type) : null) as HolderDeAlteradores;
			if (holderDeAlteradores == null)
			{
				string text = "No se pudo obtener holder de alteradores de apariencia de personaje ";
				Character character2 = current.character;
				Debug.LogError(text + ((character2 != null) ? character2.nombreCompleto : null), current);
				return;
			}
			Action<MultipleValorElemento<string, object>, int, HolderDeAlteradores> action = this.itemClicked;
			if (action == null)
			{
				return;
			}
			action(valueOrDefault, elemento.modelItemIndex, holderDeAlteradores);
		}

		// Token: 0x04000118 RID: 280
		[Ignore]
		[NonSerialized]
		public string title = "Groups";

		// Token: 0x0400011A RID: 282
		[ClickableLabelConValor]
		[FontProConfigUI(alignment = TextAlignmentOptions.MidlineLeft)]
		public List<MultipleValorElemento<string, object>> holders;
	}
}
