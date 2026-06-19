using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI
{
	// Token: 0x02000037 RID: 55
	public class OpcionesDeTHSDonaDeLoadOutfitsConDialogo : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x0600018B RID: 395 RVA: 0x00007C8A File Offset: 0x00005E8A
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00007CC0 File Offset: 0x00005EC0
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00007CE1 File Offset: 0x00005EE1
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00007CEF File Offset: 0x00005EEF
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			resultado.Add(0);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00007CF9 File Offset: 0x00005EF9
		protected override string TextDeKey(int key)
		{
			return "Load";
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00007D00 File Offset: 0x00005F00
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			OutfitPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarOutfitPortraitsDialog();
			diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
			{
				if (model.protraitsDisponibles.ContieneIndex(model.currentSelected))
				{
					string item = model.protraitsDisponibles[model.currentSelected].item1;
					if (string.IsNullOrWhiteSpace(item))
					{
						if (Application.isEditor)
						{
							Debug.LogWarning("Nombre a cargar es invalido: " + item, this);
							return;
						}
						Debug.LogError("Nombre a cargar es invalido: " + item, this);
						return;
					}
					else
					{
						if (!DialogueManager.IsConversationActive)
						{
							string text = string.Empty;
							Texture2D texture2D;
							SaveLoadOutfit.Cargar(item, out texture2D, ref text);
							ConjuntoDeRopa conjuntoDeRopa;
							try
							{
								if (text.Length == 0)
								{
									Singleton<MainCanvas>.instance.MostrartMsg("Custom Outfit", "Invalid Outfit File", 3f, true, null, null, null);
									return;
								}
								conjuntoDeRopa = JsonUtility.FromJson<ConjuntoDeRopa>(text);
								if (conjuntoDeRopa.piezas.Count == 0)
								{
									Singleton<MainCanvas>.instance.MostrartMsg("Custom Outfit", "Invalid Outfit File", 3f, true, null, null, null);
									return;
								}
							}
							finally
							{
								Object.Destroy(texture2D);
							}
							List<MapaDeRopa.RopaData> list = new List<MapaDeRopa.RopaData>();
							if (!ConjuntoDeRopa.VerificarYCorregirIntegridadPiezasConMsg(conjuntoDeRopa, list))
							{
								if (conjuntoDeRopa.piezas.Count == 0)
								{
									return;
								}
								text = JsonUtility.ToJson(conjuntoDeRopa);
							}
							RopaCubre ropaCubre = RopaCubre.None;
							for (int i = 0; i < list.Count; i++)
							{
								ropaCubre |= list[i].cubreFlag;
							}
							DialogueLua.SetVariable(DiccMemOutfits.currentConjuntoCubreFlags, (int)ropaCubre);
							DialogueLua.SetVariable(DiccMemOutfits.currentConjuntoSerializedData, text);
							this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
						}
						Singleton<ModalWindow>.instance.Clear(diag);
					}
				}
			};
			diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
			{
				Singleton<ModalWindow>.instance.Clear(diag);
			};
			dona.StopDrawing();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00007D7F File Offset: 0x00005F7F
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00007D81 File Offset: 0x00005F81
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00007D83 File Offset: 0x00005F83
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040000CC RID: 204
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000CD RID: 205
		private Character m_owner;
	}
}
