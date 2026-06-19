using System;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Menus.UI
{
	// Token: 0x020000A9 RID: 169
	public sealed class OpcionesDeTHSDonaDeLoadCustomMakeoverConDialogue : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x06000655 RID: 1621 RVA: 0x00025419 File Offset: 0x00023619
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0002544C File Offset: 0x0002364C
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			resultado.Add(1);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00025456 File Offset: 0x00023656
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00025464 File Offset: 0x00023664
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00025488 File Offset: 0x00023688
		protected override string TextDeKey(int key)
		{
			string text;
			try
			{
				text = "Do This";
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x000254C0 File Offset: 0x000236C0
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.esDetener = false;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x000254D4 File Offset: 0x000236D4
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			MakeoverPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarMakeoverPortraitsDialog();
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
							DialogueLua.SetVariable("SELECTED_MAKEOVER_TEXTO", this.selected.Last<THSDonaController.RadialItemData>().text);
							DialogueLua.SetVariable("SELECTED_CUSTOM_MAKEOVER_NAME", item);
							this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationEjecutar);
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

		// Token: 0x0600065C RID: 1628 RVA: 0x00025553 File Offset: 0x00023753
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x00025555 File Offset: 0x00023755
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00025557 File Offset: 0x00023757
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040003DE RID: 990
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;

		// Token: 0x040003DF RID: 991
		public bool esDetener;

		// Token: 0x040003E0 RID: 992
		private Character m_owner;
	}
}
