using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B6 RID: 182
	public class CurrentWorkingModelsPortraitsGetter : CustomMonobehaviour, ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x06000694 RID: 1684 RVA: 0x000262DC File Offset: 0x000244DC
		List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>.ObtenerDisponibles()
		{
			MemoriaJson instance = GlobalSingletonV2<MemoriaJson>.instance;
			IJsonMemoryNode jsonMemoryNode = instance.LeerDeep("root/Hired/", false);
			this.m_hired.Clear();
			if (jsonMemoryNode == null)
			{
				return this.m_hired;
			}
			foreach (IMemoryNode<string, string> memoryNode in jsonMemoryNode.children)
			{
				string text;
				string text2;
				string text3;
				MemoriaDeSMAModelosFemeninas.GetNombres(instance, memoryNode.nodeID, out text, out text2, out text3);
				MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento = new MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>(memoryNode.nodeID, text3, new SelectablePortraitCargarThumbnailHandler(CurrentWorkingModelsPortraitsGetter.CargarThumbnail), false);
				this.m_hired.Add(multipleValorElemento);
			}
			return this.m_hired;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0002638C File Offset: 0x0002458C
		private static void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			loadedTexture = MemoriaDeSMAModelosFemeninas.GetPortrait(GlobalSingletonV2<MemoriaJson>.instance, idDeProtrait);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0002639C File Offset: 0x0002459C
		public string GetToolTipOf(int index)
		{
			if (!this.m_hired.ContieneIndex(index))
			{
				return string.Empty;
			}
			string text;
			if (!this.m_infoDeIndex.TryGetValue(index, out text))
			{
				string item = this.m_hired[index].item1;
				string text2 = (MemoriaDeNpc.GetFatigue(GlobalSingletonV2<MemoriaJson>.instance, item, 0f) / 100f).ToString("P0");
				text = "<B><I>Fatigue</I></B>: " + text2;
				this.m_infoDeIndex.Add(index, text);
			}
			return text;
		}

		// Token: 0x04000401 RID: 1025
		private Dictionary<int, string> m_infoDeIndex = new Dictionary<int, string>();

		// Token: 0x04000402 RID: 1026
		private List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> m_hired = new List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>();
	}
}
