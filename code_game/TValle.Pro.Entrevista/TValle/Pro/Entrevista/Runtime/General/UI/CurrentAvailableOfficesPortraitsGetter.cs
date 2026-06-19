using System;
using System.Collections.Generic;
using System.Globalization;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Oficinas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B3 RID: 179
	public class CurrentAvailableOfficesPortraitsGetter : CustomMonobehaviour, ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x06000687 RID: 1671 RVA: 0x00025D9C File Offset: 0x00023F9C
		List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>.ObtenerDisponibles()
		{
			this.m_availables.Clear();
			IEnumerable<OficinaManager.OficinaScenes> oficinas = Singleton<OficinaManager>.instance.oficinas;
			int currentOfficeLvl = MemoriaDeSMAGamePlay.GetCurrentOfficeLvl();
			foreach (OficinaManager.OficinaScenes oficinaScenes in oficinas)
			{
				if (oficinaScenes.oficinaLvl > currentOfficeLvl)
				{
					MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento = new MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>(oficinaScenes.oficinaLvl.ToString(CultureInfo.InvariantCulture), oficinaScenes.inGameName, new SelectablePortraitCargarThumbnailHandler(CurrentAvailableOfficesPortraitsGetter.CargarThumbnail), false);
					this.m_availables.Add(multipleValorElemento);
				}
			}
			return this.m_availables;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00025E3C File Offset: 0x0002403C
		private static void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			OficinaManager.OficinaScenes oficinaData = Singleton<OficinaManager>.instance.GetOficinaData(Convert.ToInt32(idDeProtrait, CultureInfo.InvariantCulture));
			loadedTexture = oficinaData.thumbnail;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00025E68 File Offset: 0x00024068
		public string GetToolTipOf(int index)
		{
			int num = Convert.ToInt32(this.m_availables[index].item1, CultureInfo.InvariantCulture);
			OficinaManager.OficinaScenes oficinaData = Singleton<OficinaManager>.instance.GetOficinaData(num);
			return "You'll have to pay " + oficinaData.weeklyRent.ToString("C0") + " per week.";
		}

		// Token: 0x040003FD RID: 1021
		private List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> m_availables = new List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>();
	}
}
