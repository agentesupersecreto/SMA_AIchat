using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Memoria;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B5 RID: 181
	public class CurrentModelsOnDiskNotInMemoryPortraitsGetter : CustomMonobehaviour, ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x000260F8 File Offset: 0x000242F8
		List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>.ObtenerDisponibles()
		{
			this.m_models.Clear();
			List<string> list;
			this.m_models = (from nom in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[]
				{
					GameFolders.Tipo.charactersV2,
					GameFolders.Tipo.characters
				})
				where CurrentModelsOnDiskNotInMemoryPortraitsGetter.SePuedeImportar(nom)
				select nom into e
				select new MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>(e, e, new SelectablePortraitCargarThumbnailHandler(CurrentModelsOnDiskNotInMemoryPortraitsGetter.CargarThumbnail), false)).ToList<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>();
			return this.m_models;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00026184 File Offset: 0x00024384
		private static bool SePuedeImportar(string nombreDeProtrait)
		{
			Texture2D texture2D;
			byte[] array;
			SaveLoadCharacters.Cargar(nombreDeProtrait, out texture2D, out array);
			string text = null;
			bool flag;
			try
			{
				if (array == null || array.Length == 0)
				{
					text = "Invalid Portrait File";
					flag = false;
				}
				else
				{
					string text2;
					if (SaveLoadCharacters.CustomDataIsZipped(array))
					{
						text2 = Zipiry.Unzip(array);
					}
					else
					{
						text2 = Encoding.UTF8.GetString(array);
					}
					MemoriaJsonGenerica<SavingFemaleCharacterJsonMemoryNode> memoriaJsonGenerica = new MemoriaJsonGenerica<SavingFemaleCharacterJsonMemoryNode>();
					SavingFemaleCharacterJsonMemoryNode savingFemaleCharacterJsonMemoryNode = (SavingFemaleCharacterJsonMemoryNode)memoriaJsonGenerica.root;
					memoriaJsonGenerica.root.Load(text2);
					string text3 = "root/NPC/";
					IJsonMemoryNode jsonMemoryNode = memoriaJsonGenerica.LeerDeep(text3, false);
					if (jsonMemoryNode == null)
					{
						text = "Invalid Save Data";
						flag = false;
					}
					else
					{
						IMemoryNode<string, string> memoryNode = jsonMemoryNode.children.FirstOrDefault<IMemoryNode<string, string>>();
						if (memoryNode == null)
						{
							text = "Invalid NPC Count";
							flag = false;
						}
						else
						{
							string nodeID = memoryNode.nodeID;
							flag = !MemoriaDeSujetosNpcFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, nodeID);
						}
					}
				}
			}
			finally
			{
				Object.Destroy(texture2D);
				if (!string.IsNullOrWhiteSpace(text))
				{
					ErrorDialog modal = Singleton<ModalWindow>.instance.MostrarErrorDialog();
					modal.pregunta.text = text;
					modal.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(modal);
					});
				}
			}
			return flag;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x000262B8 File Offset: 0x000244B8
		private static void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			SaveLoadCharacters.CargarThumbnail(nombreDeProtrait, ref loadedTexture, true);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x000262C2 File Offset: 0x000244C2
		public string GetToolTipOf(int index)
		{
			return string.Empty;
		}

		// Token: 0x04000400 RID: 1024
		private List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> m_models = new List<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>();
	}
}
