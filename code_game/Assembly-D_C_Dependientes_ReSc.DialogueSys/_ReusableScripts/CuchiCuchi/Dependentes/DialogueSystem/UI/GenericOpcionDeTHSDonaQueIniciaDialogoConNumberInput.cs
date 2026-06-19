using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI
{
	// Token: 0x0200002B RID: 43
	public class GenericOpcionDeTHSDonaQueIniciaDialogoConNumberInput : GenericOpcionDeTHSDona
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00006FB4 File Offset: 0x000051B4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			if (string.IsNullOrWhiteSpace(this.m_cantidadVariableName))
			{
				throw new ArgumentNullException("m_cantidadVariableName", "m_cantidadVariableName null reference.");
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00007010 File Offset: 0x00005210
		protected override void OnClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			base.OnClicked(currentUserData, dona, sender);
			if (!DialogueManager.IsConversationActive)
			{
				RequiereNumberInputEventArgs requiereNumberInputEventArgs = new RequiereNumberInputEventArgs();
				requiereNumberInputEventArgs.requerido = true;
				RequiereNumberInputEvent requiereNumberInputEvent = this.mostrarNumberHandlers;
				if (requiereNumberInputEvent != null)
				{
					requiereNumberInputEvent.Invoke(requiereNumberInputEventArgs);
				}
				if (!requiereNumberInputEventArgs.requerido)
				{
					this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
				}
				else
				{
					NumberInputDialog input = Singleton<ModalWindow>.instance.MostrarNumberInputDialog();
					if (!string.IsNullOrWhiteSpace(this.m_preguntaText))
					{
						input.pregunta.text = this.m_preguntaText;
					}
					input.decimalCount = 0;
					input.incremento = 10f;
					input.minValue = 10f;
					input.maxValue = 1000000f;
					input.maxCoolDown = 0.666f;
					input.minCoolDown = 0.05f;
					input.coolDownChange = 0.2f;
					input.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(input);
						float num = input.ObtenerValor();
						if (!DialogueManager.IsConversationActive)
						{
							DialogueLua.SetVariable(this.m_cantidadVariableName, num);
							this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
						}
					});
					input.cancelar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(input);
					});
				}
			}
			dona.StopDrawing();
		}

		// Token: 0x040000BC RID: 188
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000BD RID: 189
		[SerializeField]
		private string m_cantidadVariableName;

		// Token: 0x040000BE RID: 190
		[SerializeField]
		private string m_preguntaText;

		// Token: 0x040000BF RID: 191
		private Character m_owner;

		// Token: 0x040000C0 RID: 192
		public RequiereNumberInputEvent mostrarNumberHandlers = new RequiereNumberInputEvent();
	}
}
