using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.General.UI;
using Assets.TValle.Pro.Entrevista.Runtime.Oficinas;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Tiempo;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Eventos
{
	// Token: 0x020000C5 RID: 197
	public class PagoDeCuentasSabadoEvento : CustomMonobehaviour
	{
		// Token: 0x14000048 RID: 72
		// (add) Token: 0x06000773 RID: 1907 RVA: 0x0002A140 File Offset: 0x00028340
		// (remove) Token: 0x06000774 RID: 1908 RVA: 0x0002A178 File Offset: 0x00028378
		public event Action<PagoDeCuentasSabadoEvento> pagando;

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x06000775 RID: 1909 RVA: 0x0002A1B0 File Offset: 0x000283B0
		// (remove) Token: 0x06000776 RID: 1910 RVA: 0x0002A1E8 File Offset: 0x000283E8
		public event Action<PagoDeCuentasSabadoEvento> pagado;

		// Token: 0x06000777 RID: 1911 RVA: 0x0002A220 File Offset: 0x00028420
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Singleton<HorariosNormalesDeEntrevistas>.instance.eventosDeEntrevistas.FirstOrDefault((EventoDiarioHorario e) => e.id == "SaturdayMorning").stared += this.Evento_stared;
			this.m_playerInputEnabled = Singleton<PlayerInputProxy>.instance.activoModificableOverallAND.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0002A288 File Offset: 0x00028488
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool playerInputEnabled = this.m_playerInputEnabled;
			if (playerInputEnabled == null)
			{
				return;
			}
			playerInputEnabled.TryRemoverDeOwner(true);
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0002A2A4 File Offset: 0x000284A4
		private void Evento_stared(Evento obj)
		{
			Action<PagoDeCuentasSabadoEvento> action = this.pagando;
			if (action != null)
			{
				action(this);
			}
			if (!this.activado)
			{
				Debug.Log("****Saturday Event Not Activated", this);
				return;
			}
			if (this.m_PagarCorrutina != null && this.m_PagarCorrutina.alive)
			{
				throw new InvalidOperationException();
			}
			try
			{
				this.m_PagarCorrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.PagarRutine(), new ManualCorrutina.OnEndedHandler(this.OnPagarRutineEnded));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0002A32C File Offset: 0x0002852C
		private IEnumerator PagarRutine()
		{
			Debug.Log("****Saturday Event Stared", this);
			this.m_playerInputEnabled.valor.valor = false;
			PanelMakeWeeklyPayments panel = Singleton<PanelMakeWeeklyPaymentsGetter>.instance.panel;
			WeeklyFinancesModelo modelo = panel.modelo;
			int currentOfficeLvl = MemoriaDeSMAGamePlay.GetCurrentOfficeLvl();
			OficinaManager.OficinaScenes oficinaData = Singleton<OficinaManager>.instance.GetOficinaData(currentOfficeLvl);
			List<string> hired = new List<string>();
			float num = 0f;
			MemoriaDeSMAModelosFemeninas.HiredNPCs(GlobalSingletonV2<MemoriaJson>.instance, hired);
			for (int i = 0; i < hired.Count; i++)
			{
				float num2;
				float num3;
				MemoriaDeSMAModelosFemeninas.GetModeSalaryAndCommission(GlobalSingletonV2<MemoriaJson>.instance, hired[i], out num2, out num3);
				num += num2;
			}
			float totalToPay = oficinaData.weeklyRent + num;
			modelo.toPayLabel = new LabelData2(string.Empty, "Expense Obligations:", string.Empty, null);
			modelo.rentExpense = new LabelData2(string.Empty, "Rent Expense " + oficinaData.weeklyRent.ToString("C0"), string.Empty, new Color?(Color.red));
			modelo.talentSalaries = new LabelData2(string.Empty, "Talent Salaries " + num.ToString("C0"), string.Empty, new Color?(Color.red));
			modelo.totalLabel = new LabelData2(string.Empty, "Total: " + totalToPay.ToString("C0"), string.Empty, new Color?(Color.red));
			string mainCharID = Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid().ToString();
			DateTime aWeekAgo = Singleton<TiempoDeJuego>.instance.now.AddDays(-6.0);
			IReadOnlyList<CharacterWallet.Transacion> readOnlyList;
			CharacterWallet.GetHistorial(mainCharID, out readOnlyList);
			IEnumerable<CharacterWallet.Transacion> enumerable = readOnlyList.Where((CharacterWallet.Transacion x) => x.date >= aWeekAgo);
			List<CharacterWallet.Transacion> list = enumerable.Where((CharacterWallet.Transacion x) => x.value > 0f).ToList<CharacterWallet.Transacion>();
			List<CharacterWallet.Transacion> list2 = enumerable.Where((CharacterWallet.Transacion x) => x.value < 0f).ToList<CharacterWallet.Transacion>();
			modelo.incomeVsExpenses.income.title = "Earnings";
			modelo.incomeVsExpenses.income.items = list.Select((CharacterWallet.Transacion inc) => new LabelData2(string.Empty, string.Concat(new string[]
			{
				inc.senderName,
				" ",
				inc.value.ToString("C2"),
				" ",
				inc.date.ToString("dd/MM/yy")
			}), string.Empty, new Color?(Color.green))).ToList<LabelData2>();
			modelo.incomeVsExpenses.expenses.title = "Expenses";
			modelo.incomeVsExpenses.expenses.items = list2.Select((CharacterWallet.Transacion inc) => new LabelData2(string.Empty, string.Concat(new string[]
			{
				inc.senderName,
				" ",
				Mathf.Abs(inc.value).ToString("C2"),
				" ",
				inc.date.ToString("dd/MM/yy")
			}), string.Empty, new Color?(Color.red))).ToList<LabelData2>();
			bool payClicked = false;
			Action action = delegate
			{
				panel.ClearLeaveCallBacks();
				payClicked = true;
			};
			panel.onPayClicked += action;
			panel.onUpgradeOfficeClick += this.OnUpdradeOffice;
			panel.CrearYDibujar(null);
			while (!payClicked)
			{
				yield return null;
			}
			panel.Clear();
			CharacterWallet.Change(mainCharID, "fiat", -totalToPay, "Expense Obligations", Singleton<TiempoDeJuego>.instance.now);
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			if (current != null)
			{
				Character character = current.character;
				if (character != null)
				{
					CharacterWallet componentEnRoot = character.GetComponentEnRoot<CharacterWallet>();
					if (componentEnRoot != null)
					{
						componentEnRoot.LoadFromMemory();
					}
				}
			}
			for (int j = 0; j < hired.Count; j++)
			{
				float fatigue = MemoriaDeNpc.GetFatigue(GlobalSingletonV2<MemoriaJson>.instance, hired[j], 0f);
				float num4 = Random.value.InPow(6f);
				float num5 = Mathf.Lerp(0f, fatigue * 0.5f, num4);
				MemoriaDeNpc.SetFatigue(GlobalSingletonV2<MemoriaJson>.instance, hired[j], num5);
			}
			foreach (KeyValuePair<string, SMAJobMap> keyValuePair in AsyncSingleton<JobsGetter>.instance.jobsDisponibles)
			{
				float jobFatige = MemoriaDeSMAModelosFemeninas.GetJobFatige(keyValuePair.Key, 0f);
				float num6 = Random.value.InPow(6f);
				float num7 = Mathf.Lerp(0f, jobFatige, num6);
				MemoriaDeSMAModelosFemeninas.SetJobFatige(keyValuePair.Key, num7);
				for (int k = 0; k < hired.Count; k++)
				{
					string text = hired[k];
					float npcFatigeInJob = MemoriaDeSMAModelosFemeninas.GetNpcFatigeInJob(keyValuePair.Key, text, 0f);
					float num8 = Random.value.InPow(8f);
					float num9 = Mathf.Lerp(0f, npcFatigeInJob, num8);
					MemoriaDeSMAModelosFemeninas.SetNpcFatigeInJob(keyValuePair.Key, text, num9);
				}
			}
			Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
			Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, null, null, true);
			yield break;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0002A33C File Offset: 0x0002853C
		private void OnUpdradeOffice()
		{
			int num = MemoriaDeSMAGamePlay.GetCurrentOfficeLvl() + 1;
			if (Singleton<OficinaManager>.instance.GetOficinaData(num) == null)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("New Office", "There are no more offices available for rent.", 1f, true, null, null, null);
				return;
			}
			if (!DialogueManager.IsConversationActive)
			{
				CurrentAvailableOfficesPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarCurrentAvailableOfficesPortraitsDialog();
				diag.GetComponentNotNull<CurrentAvailableOfficesPortraitsGetter>();
				diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
				{
					if (!model.protraitsDisponibles.ContieneIndex(model.currentSelected))
					{
						Singleton<ModalWindow>.instance.Clear(diag);
						return;
					}
					int selectedOfficeLvl;
					if (!int.TryParse(model.protraitsDisponibles[model.currentSelected].item1, out selectedOfficeLvl))
					{
						Singleton<ModalWindow>.instance.Clear(diag);
						return;
					}
					Singleton<ModalWindow>.instance.Clear(diag);
					ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarConfirmacion();
					dialog.SetPreguntaText("Do you want to transfer operations to this new office space?");
					dialog.noMostrarOtraVezToggle.interactable = false;
					dialog.cancelar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
					});
					dialog.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(dialog);
						MemoriaDeSMAGamePlay.SetCurrentOfficeLvl(selectedOfficeLvl);
						string text = Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid().ToString();
						MaleCharRopaMemory.Borrar(text);
						MaleCharAparienciaMemory.BorrarBuildInOutfit(text);
						IConjuntoDeRopa conjunto = PanelNewGameMenu.GetConjunto((float)selectedOfficeLvl);
						MaleCharAparienciaMemory.RegistrarBuildInOutfit(text, selectedOfficeLvl);
						MaleCharRopaMemory.Registrar(text, conjunto);
						Singleton<ActividadesManager>.instance.FlagForceNoReciclarScenas();
						Singleton<MainCanvas>.instance.MostrartMsg("New Office", "You’ve successfully moved to your new office location.", 5f, true, null, null, null);
					});
				};
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0002A3F7 File Offset: 0x000285F7
		private void OnPagarRutineEnded(MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			this.m_playerInputEnabled.valor.valor = true;
			Action<PagoDeCuentasSabadoEvento> action = this.pagado;
			if (action != null)
			{
				action(this);
			}
			this.m_PagarCorrutina = null;
			Debug.Log("****Saturday Event Ended", this);
		}

		// Token: 0x04000443 RID: 1091
		public bool activado = true;

		// Token: 0x04000446 RID: 1094
		[SerializeField]
		private ModificadorDeBool m_playerInputEnabled;

		// Token: 0x04000447 RID: 1095
		private GlobalUpdater.Corrutina m_PagarCorrutina;
	}
}
