using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x02000006 RID: 6
	public class PanelInfoOwnAgencia : PanelBaseSingleModel<InformacionDeAgenciaModelo>
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00003981 File Offset: 0x00001B81
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000398C File Offset: 0x00001B8C
		protected override void OnBinding()
		{
			base.OnBinding();
			this.LoadEmails();
			this.m_model.acount.transactions.items = new List<TransactionsModel.Item>();
			this.m_model.acount.balance.balance = 0.ToString("C2");
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			CharacterWallet characterWallet;
			if (current == null)
			{
				characterWallet = null;
			}
			else
			{
				Character character = current.character;
				characterWallet = ((character != null) ? character.GetComponentEnRoot<CharacterWallet>() : null);
			}
			CharacterWallet characterWallet2 = characterWallet;
			if (characterWallet2 != null)
			{
				this.m_model.acount.balance.balance = characterWallet2.Current("fiat").ToString("C2");
				for (int i = 0; i < characterWallet2.historial.Count; i++)
				{
					CharacterWallet.Transacion transacion = characterWallet2.historial[i];
					Color color;
					string text;
					if (transacion.value < 0f)
					{
						color = Color.Lerp(Color.red, PanelInfoOwnAgencia.colorCefault, 0.66f);
						text = "-";
					}
					else if (transacion.value > 0f)
					{
						color = Color.Lerp(Color.green, PanelInfoOwnAgencia.colorCefault, 0.66f);
						text = "+";
					}
					else
					{
						color = PanelInfoOwnAgencia.colorCefault;
						text = string.Empty;
					}
					this.m_model.acount.transactions.items.Add(new TransactionsModel.Item(i.ToString(), transacion.senderName, text + transacion.value.ToString("C2"), new Color?(color), transacion.date.ToString("dd/MM/yy")));
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003B34 File Offset: 0x00001D34
		private void LoadEmails()
		{
			this.m_model.emails.items = new List<EmailsModel.Item>();
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			EmailsInbox emailsInbox;
			if (current == null)
			{
				emailsInbox = null;
			}
			else
			{
				Character character = current.character;
				emailsInbox = ((character != null) ? character.GetComponentEnRoot<EmailsInbox>() : null);
			}
			EmailsInbox emailsInbox2 = emailsInbox;
			if (emailsInbox2 != null)
			{
				for (int i = emailsInbox2.acontiecionedo.eventos.Count - 1; i >= 0; i--)
				{
					EmailRecivedEvento emailRecivedEvento = emailsInbox2.acontiecionedo.eventos[i];
					Color color2;
					if (emailRecivedEvento is EmailModelResponseFromAgencyEvento)
					{
						EmailModelResponseFromAgencyEvento emailModelResponseFromAgencyEvento = (EmailModelResponseFromAgencyEvento)emailRecivedEvento;
						Color color;
						if (emailModelResponseFromAgencyEvento.bonusDesblokeados.Count > 0)
						{
							color = Color.green;
						}
						else
						{
							color = Color.Lerp(Color.yellow, Color.green, 0.75f);
						}
						if (!emailModelResponseFromAgencyEvento.acepted)
						{
							color2 = Color.Lerp(Color.red, PanelInfoOwnAgencia.colorCefault, 0.8f);
						}
						else
						{
							color2 = Color.Lerp(color, PanelInfoOwnAgencia.colorCefault, Mathf.Lerp(0.8f, 0.5f, Mathf.InverseLerp(0f, 3f, (float)(emailModelResponseFromAgencyEvento.agencyEarningsArg.bonuses - emailModelResponseFromAgencyEvento.agencyEarningsArg.antiBonuses))));
						}
					}
					else if (emailRecivedEvento is EmailModelLvlIncreased)
					{
						color2 = Color.Lerp(PanelInfoOwnAgencia.colorCefault, Color.green, 0.85f);
					}
					else
					{
						color2 = PanelInfoOwnAgencia.colorCefault;
					}
					this.m_model.emails.items.Add(new EmailsModel.Item(emailRecivedEvento.id, emailRecivedEvento.nombre, emailRecivedEvento.msg.Substring(0, 75) + "...", new Color?(color2), emailRecivedEvento.StartDateTime.ToString("dd/MM/yy")));
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003CDA File Offset: 0x00001EDA
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.emails.itemClicked += this.Emails_itemClicked;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003CFE File Offset: 0x00001EFE
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.emails.itemClicked -= this.Emails_itemClicked;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003D24 File Offset: 0x00001F24
		private void Emails_itemClicked(EmailsModel.Item arg1, int arg2, EmailsModel arg3)
		{
			PanelInfoOwnAgencia.<>c__DisplayClass6_0 CS$<>8__locals1 = new PanelInfoOwnAgencia.<>c__DisplayClass6_0();
			CS$<>8__locals1.arg1 = arg1;
			CS$<>8__locals1.<>4__this = this;
			PanelInfoOwnAgencia.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			EmailsInbox emailsInbox;
			if (current == null)
			{
				emailsInbox = null;
			}
			else
			{
				Character character = current.character;
				emailsInbox = ((character != null) ? character.GetComponentEnRoot<EmailsInbox>() : null);
			}
			CS$<>8__locals2.emailsFromAgencies = emailsInbox;
			if (CS$<>8__locals1.emailsFromAgencies == null)
			{
				return;
			}
			CS$<>8__locals1.evento = CS$<>8__locals1.emailsFromAgencies.eventos.eventos.FirstOrDefault((EmailRecivedEvento ev) => ev.id == CS$<>8__locals1.arg1.ID);
			if (CS$<>8__locals1.evento == null)
			{
				return;
			}
			UnityAction unityAction = delegate
			{
				if (Singleton<ModalWindow>.IsInScene)
				{
					Singleton<ModalWindow>.instance.ClearAll();
				}
				CS$<>8__locals1.emailsFromAgencies.eventos.Remover(CS$<>8__locals1.evento);
				CS$<>8__locals1.<>4__this.LoadEmails();
				IUIPanel iuipanel = null;
				string text = "emails";
				IUIElemento iuielemento;
				if (CS$<>8__locals1.<>4__this.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
				{
					iuipanel = iuielemento as IUIPanel;
				}
				CS$<>8__locals1.<>4__this.ReDrawSubModelo(CS$<>8__locals1.<>4__this.m_model.emails, text, ref iuipanel, CS$<>8__locals1.<>4__this.UIPanel, CS$<>8__locals1.<>4__this.UIPanel.GetParentPara(0));
			};
			try
			{
				InfoDialog infoDialog = Singleton<ModalWindow>.instance.MostrarBigInfoDialog();
				infoDialog.pregunta.text = string.Concat(new string[]
				{
					"<I>from</I>: <B><size=20>",
					CS$<>8__locals1.evento.nombre,
					"</size></B>\n\n\n<size=15>",
					CS$<>8__locals1.evento.msg,
					"</size>"
				});
				infoDialog.aceptar.onClick.AddListener(unityAction);
			}
			catch (Exception ex)
			{
				unityAction();
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0400003F RID: 63
		private static Color colorCefault = new Color(0.8901961f, 0.8901961f, 0.8901961f);
	}
}
