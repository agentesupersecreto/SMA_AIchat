using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B4 RID: 180
	public class CurrentModelsInCampaingPortraitsGetter : CustomMonobehaviour, ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x0600068B RID: 1675 RVA: 0x00025ED0 File Offset: 0x000240D0
		List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>.ObtenerDisponibles()
		{
			this.m_disponibles.Clear();
			this.m_infoDeIndex.Clear();
			PiscinaDeCampaingActual instance = Singleton<PiscinaDeCampaingActual>.instance;
			if (!instance.CampaingExiste())
			{
				Debug.LogError("No se pueden cargar portraits de modelos en campaña que no existe", this);
				return this.m_disponibles;
			}
			MemoriaJson instance2 = GlobalSingletonV2<MemoriaJson>.instance;
			foreach (ISujetoIdentificableNpc sujetoIdentificableNpc in ((IEnumerable<ISujetoIdentificableNpc>)instance))
			{
				ISujetoCalificable sujetoCalificable = sujetoIdentificableNpc as ISujetoCalificable;
				if (sujetoCalificable != null && !sujetoCalificable.interviewed)
				{
					string text = sujetoIdentificableNpc.NpcID.ToString();
					string text2;
					string text3;
					string text4;
					MemoriaDeSMAModelosFemeninas.GetNombres(instance2, text, out text2, out text3, out text4);
					MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento = new MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>(text, text4, new SelectablePortraitCargarThumbnailHandler(CurrentModelsInCampaingPortraitsGetter.CargarThumbnail), false);
					this.m_disponibles.Add(multipleValorElemento);
				}
			}
			return this.m_disponibles;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00025FB4 File Offset: 0x000241B4
		private static void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			loadedTexture = MemoriaDeSMAModelosFemeninas.GetPortrait(GlobalSingletonV2<MemoriaJson>.instance, idDeProtrait);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00025FC4 File Offset: 0x000241C4
		public string GetToolTipOf(int index)
		{
			if (!this.m_disponibles.ContieneIndex(index))
			{
				return string.Empty;
			}
			string text;
			if (!this.m_infoDeIndex.TryGetValue(index, out text))
			{
				MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento = this.m_disponibles[index];
				string npcID = multipleValorElemento.item1;
				ISujetoIdentificableNpc sujetoIdentificableNpc = Singleton<PiscinaDeCampaingActual>.instance.FirstOrDefault((ISujetoIdentificableNpc npc) => npc.NpcID.ToString() == npcID);
				if (sujetoIdentificableNpc == null)
				{
					text = string.Empty;
				}
				else
				{
					string text2 = sujetoIdentificableNpc.dataContainer.FindData("height");
					string text3 = sujetoIdentificableNpc.dataContainer.FindData("chest");
					string text4 = sujetoIdentificableNpc.dataContainer.FindData("waist");
					string text5 = sujetoIdentificableNpc.dataContainer.FindData("hips");
					text = "<B><I>Height</I></B>: " + text2 + "\n";
					text = text + "<B><I>Chest</I></B>: " + text3 + "\n";
					text = text + "<B><I>Waist</I></B>: " + text4 + "\n";
					text = text + "<B><I>Hips</I></B>: " + text5;
				}
				this.m_infoDeIndex.Add(index, text);
			}
			return text;
		}

		// Token: 0x040003FE RID: 1022
		private Dictionary<int, string> m_infoDeIndex = new Dictionary<int, string>();

		// Token: 0x040003FF RID: 1023
		private List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> m_disponibles = new List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>();
	}
}
