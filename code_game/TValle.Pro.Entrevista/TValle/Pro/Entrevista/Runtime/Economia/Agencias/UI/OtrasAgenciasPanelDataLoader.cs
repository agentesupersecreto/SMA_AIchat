using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets.TValle.IU.Runtime.Drawing.ItemsYDetallesDeItems.Modelos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets.TValle.UI.Runtime.Drawing.ItemsYDetallesDeItems.Paneles;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.UI
{
	// Token: 0x020000D3 RID: 211
	[RequireComponent(typeof(PanelDeItemsYDetallesDeItems))]
	public class OtrasAgenciasPanelDataLoader : CustomMonobehaviour
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0002C7DB File Offset: 0x0002A9DB
		public PanelDeItemsYDetallesDeItems panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0002C7E4 File Offset: 0x0002A9E4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<PanelDeItemsYDetallesDeItems>();
			this.m_panel.loading += this.M_panel_loading;
			this.m_panel.loadingItems += this.M_panel_loadingItems;
			this.m_panel.loadingDetalles += this.M_panel_loadingDetalles;
			this.m_panel.itemsFavoriteStateChanged += this.M_panel_itemsFavoriteStateChanged;
			this.m_panel.itemsClicked += this.M_panel_itemsClicked;
			this.m_panel.accion1Clicked += this.M_panel_accion1Clicked;
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0002C890 File Offset: 0x0002AA90
		private void M_panel_loading(ref InformacionDetalladaDeItemsModelo modelo, PanelDeItemsYDetallesDeItems sender)
		{
			modelo.detalles = new DetallesDeItemModelo();
			modelo.detalles.accion1Label = "Dispatch her";
			modelo.detalles.accion1ConfirmacionPregunta = "Are you sure you want to dispatch her to this other agency?";
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias", true);
			modelo.agenciasListaModelo.soloFavoritos = jsonMemoryNode.FindDataBool("soloFavoritos", false);
			jsonMemoryNode.TryFindDataArrayEmpty("m_historialSeleccionados", out this.m_historialSeleccionados);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0002C908 File Offset: 0x0002AB08
		private void M_panel_loadingItems(bool soloFavoritos, string buscando, ref InformacionDetalladaDeItemsModelo modelo, PanelDeItemsYDetallesDeItems sender)
		{
			IReadOnlyList<Agencia> agencias = Singleton<OtrasAgencias>.instance.agencias;
			IEnumerable<Agencia> enumerable = (from a in this.m_historialSeleccionados.Select((string id) => agencias.FirstOrDefault((Agencia a) => a.ID == id)).Distinct<Agencia>()
				where a != null
				select a).Concat(agencias).Distinct<Agencia>();
			IJsonMemoryNode memAgencias = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias", true);
			memAgencias.AddData("soloFavoritos", soloFavoritos, true);
			IEnumerable<Agencia> enumerable2 = enumerable.Where(delegate(Agencia ag)
			{
				IJsonMemoryNode jsonMemoryNode = memAgencias.FindChildNotNull<IJsonMemoryNode>(ag.ID);
				bool flag = jsonMemoryNode.FindDataBool("EsFav", false);
				return (!soloFavoritos || flag) && !ag.nombre.Filtrado(buscando) && (!ag.blockeada || jsonMemoryNode.FindDataBool("EsUnlocked", false));
			});
			enumerable2 = enumerable2.Where((Agencia ag) => !memAgencias.FindChildNotNull<IJsonMemoryNode>(ag.ID).FindDataBool("Used", false)).Concat(enumerable2).Distinct<Agencia>();
			IEnumerable<ItemsListaModelo.Item> enumerable3 = enumerable2.Select(delegate(Agencia ag)
			{
				IJsonMemoryNode jsonMemoryNode2 = memAgencias.FindChildNotNull<IJsonMemoryNode>(ag.ID);
				return new ItemsListaModelo.Item(ag.ID, ag.nombre, jsonMemoryNode2.FindDataBool("EsFav", false), new Color?(this.CalcularColorReward(ag.incomeConfig.incomePercentage)), (!jsonMemoryNode2.FindDataBool("Used", false)) ? "New!" : null);
			});
			modelo.agenciasListaModelo.items.Clear();
			modelo.agenciasListaModelo.items.AddRange(enumerable3);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0002CA24 File Offset: 0x0002AC24
		private void M_panel_loadingDetalles(ItemsListaModelo.Item item, int index, ref DetallesDeItemModelo modelo, PanelDeItemsYDetallesDeItems sender)
		{
			Agencia agencia = Singleton<OtrasAgencias>.instance.ObtenerAgencia(item.ID);
			modelo.nombre = agencia.nombre;
			float num = 1f;
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			ModificadorDeIngresosDeAgenciasDeCharacter modificadorDeIngresosDeAgenciasDeCharacter;
			if (current == null)
			{
				modificadorDeIngresosDeAgenciasDeCharacter = null;
			}
			else
			{
				Character character = current.character;
				modificadorDeIngresosDeAgenciasDeCharacter = ((character != null) ? character.GetComponentEnRoot<ModificadorDeIngresosDeAgenciasDeCharacter>() : null);
			}
			ModificadorDeIngresosDeAgenciasDeCharacter modificadorDeIngresosDeAgenciasDeCharacter2 = modificadorDeIngresosDeAgenciasDeCharacter;
			if (modificadorDeIngresosDeAgenciasDeCharacter2 != null && !string.IsNullOrWhiteSpace((agencia != null) ? agencia.ID : null))
			{
				ModificableDeFloat modifiacableDeAgencia = modificadorDeIngresosDeAgenciasDeCharacter2.GetModifiacableDeAgencia(agencia.ID);
				num = ((modifiacableDeAgencia != null) ? new float?(modifiacableDeAgencia.ModificarValor(1f)) : null).GetValueOrDefault(1f);
			}
			float num2 = num * 100f - 100f;
			if (num > 1f)
			{
				modelo.subTitle = string.Format("Default Payment: {0} Relationship Bonuses: <color=#{1}>{2}</color>", agencia.incomeConfig.defaultIncome.ToString("C2"), ColorUtility.ToHtmlStringRGB(Color.Lerp(Color.green, Color.white, 0.2f)), "+" + num2.ToString() + " %");
			}
			else if (num < 1f)
			{
				modelo.subTitle = string.Format("Default Payment: {0} Relationship Bonuses: <color=#{1}>{2}</color>", agencia.incomeConfig.defaultIncome.ToString("C2"), ColorUtility.ToHtmlStringRGB(Color.Lerp(Color.red, Color.white, 0.2f)), "-" + Mathf.Abs(num2).ToString() + " %");
			}
			else
			{
				modelo.subTitle = string.Format("Default Payment: {0} Relationship Bonuses: <color=#{1}>{2}</color>", agencia.incomeConfig.defaultIncome.ToString("C2"), ColorUtility.ToHtmlStringRGB(Color.white), num2.ToString() + " %");
			}
			modelo.descripcion = agencia.descripcion;
			modelo.subDetallesDeItemModelo.nombre = "Requirements";
			modelo.subDetallesDeItemModelo.subDetallesIzq.nombre = "Beneficial";
			modelo.subDetallesDeItemModelo.subDetallesDer.nombre = "Unproductive";
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias/" + item.ID, true);
			modelo.subDetallesDeItemModelo.subDetallesIzq.subDetalles.Clear();
			foreach (Agencia.Requerimiento requerimiento in agencia.requerimientos)
			{
				listaDeSubDetallesDeItemModelo.Par par = this.ProducirParV2(requerimiento, "Make sure she has these qualities before sending her to this agency.", true);
				modelo.subDetallesDeItemModelo.subDetallesIzq.subDetalles.Add(par);
			}
			foreach (Agencia.Bonus bonus in agencia.bonuses)
			{
				bool flag = jsonMemoryNode.FindChildNotNull<IJsonMemoryNode>(bonus.rutaV2).FindDataBool("EsUnlocked", false);
				listaDeSubDetallesDeItemModelo.Par par2 = this.ProducirParV2(bonus, "Bonus <color=green>++</color>", flag);
				par2.label1 = "<color=green>" + par2.label1 + "</color>";
				par2.label2 = "<size=12>" + par2.label2 + "</size>";
				modelo.subDetallesDeItemModelo.subDetallesIzq.subDetalles.Add(par2);
			}
			modelo.subDetallesDeItemModelo.subDetallesDer.subDetalles.Clear();
			foreach (Agencia.AntiRequerimiento antiRequerimiento in agencia.antiRequerimientos)
			{
				listaDeSubDetallesDeItemModelo.Par par3 = this.ProducirParV2(antiRequerimiento, "Ensure that she does not have these flaws at all.", true);
				modelo.subDetallesDeItemModelo.subDetallesDer.subDetalles.Add(par3);
			}
			foreach (Agencia.Bonus bonus2 in agencia.antiBonuses)
			{
				bool flag2 = jsonMemoryNode.FindChildNotNull<IJsonMemoryNode>(bonus2.rutaV2).FindDataBool("EsUnlocked", false);
				listaDeSubDetallesDeItemModelo.Par par4 = this.ProducirParV2(bonus2, "Bonus <color=red>--</color>", flag2);
				par4.label1 = "<color=red>" + par4.label1 + "</color>";
				par4.label2 = "<size=12>" + par4.label2 + "</size>";
				modelo.subDetallesDeItemModelo.subDetallesDer.subDetalles.Add(par4);
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0002CED0 File Offset: 0x0002B0D0
		private void M_panel_itemsFavoriteStateChanged(bool newValue, ItemsListaModelo.Item item, PanelDeItemsYDetallesDeItems sender)
		{
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias/" + item.ID, true).AddData("EsFav", newValue, true);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0002CEF9 File Offset: 0x0002B0F9
		private void M_panel_itemsClicked(ItemsListaModelo.Item item, PanelDeItemsYDetallesDeItems sender)
		{
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0002CEFC File Offset: 0x0002B0FC
		private void M_panel_accion1Clicked(string itemID, DetallesDeItemModelo detalles, PanelDeItemsYDetallesDeItems sender)
		{
			for (int i = this.m_historialSeleccionados.Count - 1; i >= 0; i--)
			{
				if (this.m_historialSeleccionados[i] == itemID)
				{
					this.m_historialSeleccionados.RemoveAt(i);
				}
			}
			this.m_historialSeleccionados.Insert(0, itemID);
			try
			{
				while (this.m_historialSeleccionados.Count > 3)
				{
					this.m_historialSeleccionados.RemoveAt(3);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias", true).AddData("m_historialSeleccionados", this.m_historialSeleccionados, true);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0002CFA8 File Offset: 0x0002B1A8
		private listaDeSubDetallesDeItemModelo.Par ProducirParV2(Agencia.RequerimientoBase req, string label3, bool unlocked)
		{
			if (!unlocked)
			{
				return new listaDeSubDetallesDeItemModelo.Par("??????????", "????", label3);
			}
			StringBuilder stringBuilder;
			StringBuilder stringBuilder2;
			OtrasAgencias.GetMsgDeRequerimientoV2(req, out stringBuilder, out stringBuilder2);
			return new listaDeSubDetallesDeItemModelo.Par(stringBuilder.ToString(), stringBuilder2.ToString(), label3);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0002CFE8 File Offset: 0x0002B1E8
		[Obsolete]
		private listaDeSubDetallesDeItemModelo.Par ProducirPar(Agencia.RequerimientoBase req, string label3, bool unlocked)
		{
			listaDeSubDetallesDeItemModelo.Par par;
			try
			{
				if (!unlocked)
				{
					par = new listaDeSubDetallesDeItemModelo.Par("????", "????", label3);
				}
				else
				{
					PropertyInfo memberNestedOptimizado = typeof(InterpretacionCompletaDeFemale).GetMemberNestedOptimizado(BindingFlags.Instance | BindingFlags.Public, req.rutaSeparada, OtrasAgenciasPanelDataLoader.acendenciaTemp);
					Enum @enum = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, req.valorPrimario);
					Enum enum2 = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, req.valorSegundario);
					Enum enum3 = (Enum)Enum.ToObject(memberNestedOptimizado.PropertyType, req.valorTerciario);
					string text = (Attribute.GetCustomAttribute(memberNestedOptimizado, typeof(LabelLocalizadoAttribute)) as LabelLocalizadoAttribute).text;
					for (int i = OtrasAgenciasPanelDataLoader.acendenciaTemp.Count - 1; i >= 0; i--)
					{
						string text2 = (Attribute.GetCustomAttribute(OtrasAgenciasPanelDataLoader.acendenciaTemp[i], typeof(LabelLocalizadoAttribute)) as LabelLocalizadoAttribute).text;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text = text2 + "->" + text;
						}
					}
					string text3 = TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, @enum, "US").FirstLetterToUpperCaseOthersToLower();
					if (req.usarValorSegundario)
					{
						text3 = text3 + ", " + TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, enum2, "US").FirstLetterToUpperCaseOthersToLower();
					}
					if (req.usarValorTerciario)
					{
						text3 = text3 + ", " + TextoLocalizadoAttribute.Localizado(memberNestedOptimizado.PropertyType, enum3, "US").FirstLetterToUpperCaseOthersToLower();
					}
					par = new listaDeSubDetallesDeItemModelo.Par(text, text3, label3);
				}
			}
			finally
			{
				OtrasAgenciasPanelDataLoader.acendenciaTemp.Clear();
			}
			return par;
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0002D190 File Offset: 0x0002B390
		private Color CalcularColorReward(float percentage)
		{
			percentage = Mathf.Clamp(percentage, 0f, 100f);
			float num = Mathf.InverseLerp(0f, 100f, percentage).OutPow(6f);
			if (num < 0.3333f)
			{
				return Color.Lerp(OtrasAgenciasPanelDataLoader.tier1, OtrasAgenciasPanelDataLoader.tier2, Mathf.InverseLerp(0f, 0.3333f, num));
			}
			if (num < 0.66666f)
			{
				return Color.Lerp(OtrasAgenciasPanelDataLoader.tier2, OtrasAgenciasPanelDataLoader.tier3, Mathf.InverseLerp(0.3333f, 0.66666f, num));
			}
			return Color.Lerp(OtrasAgenciasPanelDataLoader.tier3, OtrasAgenciasPanelDataLoader.tier4, Mathf.InverseLerp(0.66666f, 1f, num));
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0002D239 File Offset: 0x0002B439
		private string CalcularHtmlColorRisk(Interpretacion.Capacidad risk)
		{
			return ColorUtility.ToHtmlStringRGB(this.CalcularColorRisk(risk));
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0002D248 File Offset: 0x0002B448
		private Color CalcularColorRisk(Interpretacion.Capacidad risk)
		{
			switch (risk)
			{
			case Interpretacion.Capacidad.veryLow:
				return Color.green;
			case Interpretacion.Capacidad.low:
				return Color.green * 0.5f + Color.white * 0.5f;
			case Interpretacion.Capacidad.medium:
				return Color.white;
			case Interpretacion.Capacidad.high:
				return Color.red * 0.5f + Color.white * 0.5f;
			case Interpretacion.Capacidad.veryHigh:
				return Color.red;
			default:
				throw new ArgumentOutOfRangeException(risk.ToString());
			}
		}

		// Token: 0x0400046F RID: 1135
		private PanelDeItemsYDetallesDeItems m_panel;

		// Token: 0x04000470 RID: 1136
		[SerializeField]
		private List<string> m_historialSeleccionados = new List<string>();

		// Token: 0x04000471 RID: 1137
		[Obsolete]
		private static List<MemberInfo> acendenciaTemp = new List<MemberInfo>();

		// Token: 0x04000472 RID: 1138
		private static readonly Color tier1 = Color.Lerp(Color.black, Color.white, 0.2f);

		// Token: 0x04000473 RID: 1139
		private static readonly Color tier2 = Color.Lerp(Color.black, Color.green, 0.2f);

		// Token: 0x04000474 RID: 1140
		private static readonly Color tier3 = Color.Lerp(Color.black, Color.magenta, 0.2f);

		// Token: 0x04000475 RID: 1141
		private static readonly Color tier4 = Color.Lerp(Color.black, Color.Lerp(Color.red, Color.yellow, 0.5f), 0.2f);
	}
}
