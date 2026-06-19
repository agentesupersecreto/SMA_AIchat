using System;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Controlladores.Gestos;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Menus.UI
{
	// Token: 0x020000A8 RID: 168
	public sealed class OpcionesDeTHSDonaDeLoadCustomGesturesConDialogue : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x0600064A RID: 1610 RVA: 0x00025298 File Offset: 0x00023498
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			this.m_ControlladorDeGestosDeModelaje = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeGestosDeModelaje == null)
			{
				throw new ArgumentNullException("m_ControlladorDeGestosDeModelaje", "m_ControlladorDeGestosDeModelaje null reference.");
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00025301 File Offset: 0x00023501
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			resultado.Add(1);
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0002530B File Offset: 0x0002350B
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0002531C File Offset: 0x0002351C
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00025340 File Offset: 0x00023540
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

		// Token: 0x0600064F RID: 1615 RVA: 0x00025378 File Offset: 0x00023578
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.esDetener = false;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0002538C File Offset: 0x0002358C
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			GesturePortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarGesturePortraitsDialog();
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
							DialogueLua.SetVariable("SELECTED_GESTURE_TEXTO", this.selected.Last<THSDonaController.RadialItemData>().text);
							DialogueLua.SetVariable("SELECTED_CUSTOM_GESTURE_NAME", item);
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

		// Token: 0x06000651 RID: 1617 RVA: 0x0002540B File Offset: 0x0002360B
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0002540D File Offset: 0x0002360D
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0002540F File Offset: 0x0002360F
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x040003DA RID: 986
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;

		// Token: 0x040003DB RID: 987
		public bool esDetener;

		// Token: 0x040003DC RID: 988
		private Character m_owner;

		// Token: 0x040003DD RID: 989
		private ControlladorDeGestosDeModelaje m_ControlladorDeGestosDeModelaje;
	}
}
