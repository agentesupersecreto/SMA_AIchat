using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.IU.Runtime.Modales.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Modales.Globales
{
	// Token: 0x0200001A RID: 26
	[RequireComponent(typeof(Canvas))]
	public class ModalWindow : Singleton<ModalWindow>, IModalWindow
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000037A3 File Offset: 0x000019A3
		public Canvas canvas
		{
			get
			{
				return this.m_Canvas;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000037AB File Offset: 0x000019AB
		public bool isShowing
		{
			get
			{
				return this.m_modalesUsando.Count > 0;
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000095 RID: 149 RVA: 0x000037BC File Offset: 0x000019BC
		// (remove) Token: 0x06000096 RID: 150 RVA: 0x000037F4 File Offset: 0x000019F4
		public event Action<IModalWindow> showingStateChanged;

		// Token: 0x06000097 RID: 151 RVA: 0x00003829 File Offset: 0x00001A29
		protected override void InitData(bool esEditorTime)
		{
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000382C File Offset: 0x00001A2C
		protected override void DoAwake()
		{
			base.DoAwake();
			if (this.m_confirmacion == null)
			{
				throw new ArgumentNullException("m_confirmacion", "m_confirmacion null reference.");
			}
			if (this.m_bigConfirmacion == null)
			{
				throw new ArgumentNullException("m_bigConfirmacion", "m_bigConfirmacion null reference.");
			}
			if (this.m_confirmacionResolution == null)
			{
				throw new ArgumentNullException("m_confirmacionResolution", "m_confirmacionResolution null reference.");
			}
			if (this.m_nameInput == null)
			{
				throw new ArgumentNullException("m_nameInput", "m_nameInput null reference.");
			}
			if (this.m_errorDialog == null)
			{
				throw new ArgumentNullException("m_errorDialog", "m_errorDialog null reference.");
			}
			if (this.m_bigInfo == null)
			{
				throw new ArgumentNullException("m_bigInfo", "m_bigInfo null reference.");
			}
			if (this.m_SavingPortraitDialog == null)
			{
				throw new ArgumentNullException("m_SavingPortraitDialog", "m_SavingPortraitDialog null reference.");
			}
			if (this.m_SavingPortraitDialogWide == null)
			{
				throw new ArgumentNullException("m_SavingPortraitDialogWide", "m_SavingPortraitDialogWide null reference.");
			}
			if (this.m_SavingJobPortraitDialog == null)
			{
				throw new ArgumentNullException("m_SavingJobPortraitDialog", "m_SavingJobPortraitDialog null reference.");
			}
			if (this.m_TemporalInfoDialog == null)
			{
				throw new ArgumentNullException("m_TemporalInfoDialog", "m_TemporalInfoDialog null reference.");
			}
			if (this.m_PortraitsDialog == null)
			{
				throw new ArgumentNullException("m_PortraitsDialog", "m_PortraitsDialog null reference.");
			}
			if (this.m_PosePortraitsDialog == null)
			{
				throw new ArgumentNullException("m_PosePortraitsDialog", "m_PosePortraitsDialog null reference.");
			}
			if (this.m_GesturePortraitsDialog == null)
			{
				throw new ArgumentNullException("m_GesturePortraitsDialog", "m_GesturePortraitsDialog null reference.");
			}
			if (this.m_MakeoverPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_MakeoverPortraitsDialog", "m_MakeoverPortraitsDialog null reference.");
			}
			if (this.m_OutfitPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_OutfitPortraitsDialog", "m_OutfitPortraitsDialog null reference.");
			}
			if (this.m_CurrentWorkingModelsPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_CurrentWorkingModelsPortraitsDialog", "m_CurrentWorkingModelsPortraitsDialog null reference.");
			}
			if (this.m_CurrentModelsInCampaingPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_CurrentModelsInCampaingPortraitsDialog", "m_CurrentModelsInCampaingPortraitsDialog null reference.");
			}
			if (this.m_CurrentAvailableJobsPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_CurrentAvailableJobsPortraitsDialog", "m_CurrentAvailableJobsPortraitsDialog null reference.");
			}
			if (this.m_CurrentAvailableOfficesPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_CurrentAvailableOfficesPortraitsDialog", "m_CurrentAvailableOfficesPortraitsDialog null reference.");
			}
			if (this.m_InterpretationPortraitsDialog == null)
			{
				throw new ArgumentNullException("m_InterpretationPortraitsDialog", "m_InterpretationPortraitsDialog null reference.");
			}
			if (this.m_NewGameInputDialog == null)
			{
				throw new ArgumentNullException("m_NewGameInputDialog", "m_NewGameInputDialog null reference.");
			}
			if (this.m_NumberInputDialog == null)
			{
				throw new ArgumentNullException("m_NumberInputDialog", "m_NumberInputDialog null reference.");
			}
			this.m_Canvas = base.GetComponent<Canvas>();
			this.m_Canvas.enabled = false;
			this.m_hideCursor = Singleton<ConfiguracionGeneralDeMouse>.instance.canHideCursorModificableAnd.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003B01 File Offset: 0x00001D01
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			this.ClearAll();
			ModificadorDeBool hideCursor = this.m_hideCursor;
			if (hideCursor == null)
			{
				return;
			}
			hideCursor.TryRemoverDeOwner(true);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003B24 File Offset: 0x00001D24
		private void Update()
		{
			if (!string.IsNullOrWhiteSpace(this.m_errorAcumulado) && !this.isShowing)
			{
				InfoDialog error = this.MostrarBigInfoDialog();
				error.pregunta.text = "Error: " + this.m_errorAcumulado;
				error.aceptar.onClick.AddListener(delegate
				{
					this.Clear(error);
				});
				this.m_errorAcumulado = string.Empty;
			}
			if (!this.isShowing && this.m_mostrarAlDesocuparse.Count > 0)
			{
				Action action = this.m_mostrarAlDesocuparse.Dequeue();
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003BD8 File Offset: 0x00001DD8
		public void ClearAll()
		{
			if (this.m_Canvas != null)
			{
				this.m_Canvas.enabled = false;
			}
			foreach (GameObject gameObject in this.m_modalesUsando)
			{
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
			this.m_modalesUsando.Clear();
			this.m_hideCursor.valor.valor = true;
			Action<IModalWindow> action = this.showingStateChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003C7C File Offset: 0x00001E7C
		public void Clear(MonoBehaviour modal)
		{
			if (modal == null)
			{
				return;
			}
			for (int i = this.m_modalesUsando.Count - 1; i >= 0; i--)
			{
				GameObject gameObject = this.m_modalesUsando[i];
				if (gameObject == modal.gameObject)
				{
					this.m_modalesUsando.RemoveAt(i);
					Object.Destroy(gameObject);
				}
			}
			if (this.m_Canvas != null && this.m_modalesUsando.Count == 0)
			{
				this.m_Canvas.enabled = false;
				this.m_modalesUsando.Clear();
				this.m_hideCursor.valor.valor = true;
			}
			Action<IModalWindow> action = this.showingStateChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003D2C File Offset: 0x00001F2C
		public void Clear<T>()
		{
			for (int i = this.m_modalesUsando.Count - 1; i >= 0; i--)
			{
				GameObject gameObject = this.m_modalesUsando[i];
				T t;
				if (gameObject.TryGetComponent<T>(out t))
				{
					this.m_modalesUsando.RemoveAt(i);
					Object.Destroy(gameObject);
				}
			}
			if (this.m_Canvas != null && this.m_modalesUsando.Count == 0)
			{
				this.m_Canvas.enabled = false;
				this.m_modalesUsando.Clear();
				this.m_hideCursor.valor.valor = true;
			}
			Action<IModalWindow> action = this.showingStateChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003DD0 File Offset: 0x00001FD0
		private void OnShowing(RectTransform showing)
		{
			if (showing == null)
			{
				throw new ArgumentNullException("showing", "showing null reference.");
			}
			showing.anchorMin = Vector2.zero;
			showing.anchorMax = Vector2.one;
			showing.position = Vector2.zero;
			showing.offsetMin = Vector2.zero;
			showing.offsetMax = Vector2.zero;
			this.m_Canvas.enabled = true;
			this.m_modalesUsando.Add(showing.gameObject);
			this.m_hideCursor.valor.valor = false;
			Action<IModalWindow> action = this.showingStateChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003E71 File Offset: 0x00002071
		public bool EstaIgnorandoConfirmacion(string accionID)
		{
			return !string.IsNullOrWhiteSpace(accionID) && this.m_confirmacionesIgnorando.Contains(accionID);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003E89 File Offset: 0x00002089
		public void IgnorandoConfirmacion(string accionID)
		{
			if (string.IsNullOrWhiteSpace(accionID))
			{
				return;
			}
			this.m_confirmacionesIgnorando.Add(accionID);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003EA1 File Offset: 0x000020A1
		public void MostrarBajaPrioridad(Action accion)
		{
			this.m_mostrarAlDesocuparse.Enqueue(accion);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003EB0 File Offset: 0x000020B0
		public ConfirmacionMiembros MostrarConfirmacion()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			ConfirmacionMiembros confirmacionMiembros = Object.Instantiate<ConfirmacionMiembros>(this.m_confirmacion, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(confirmacionMiembros.GetComponent<RectTransform>());
			return confirmacionMiembros;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003EFC File Offset: 0x000020FC
		public ConfirmacionMiembros MostrarBigConfirmacion()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			ConfirmacionMiembros confirmacionMiembros = Object.Instantiate<ConfirmacionMiembros>(this.m_bigConfirmacion, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(confirmacionMiembros.GetComponent<RectTransform>());
			return confirmacionMiembros;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003F48 File Offset: 0x00002148
		public ConfirmacionResolutionMiembros MostrarConfirmacionResoulution()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			ConfirmacionResolutionMiembros confirmacionResolutionMiembros = Object.Instantiate<ConfirmacionResolutionMiembros>(this.m_confirmacionResolution, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(confirmacionResolutionMiembros.GetComponent<RectTransform>());
			return confirmacionResolutionMiembros;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003F94 File Offset: 0x00002194
		public TextInputDialog MostrarTextInputDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			TextInputDialog textInputDialog = Object.Instantiate<TextInputDialog>(this.m_nameInput, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(textInputDialog.GetComponent<RectTransform>());
			return textInputDialog;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003FE0 File Offset: 0x000021E0
		public ErrorDialog MostrarErrorDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			ErrorDialog errorDialog = Object.Instantiate<ErrorDialog>(this.m_errorDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(errorDialog.GetComponent<RectTransform>());
			return errorDialog;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000402C File Offset: 0x0000222C
		public InfoDialog MostrarBigInfoDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			InfoDialog infoDialog = Object.Instantiate<InfoDialog>(this.m_bigInfo, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(infoDialog.GetComponent<RectTransform>());
			return infoDialog;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004078 File Offset: 0x00002278
		public void MostrarTextInputDialog(TextInputDialog instancia)
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			this.OnShowing(instancia.GetComponent<RectTransform>());
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000040A4 File Offset: 0x000022A4
		public SavingPortraitDialog MostrarSavingPortraitDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			SavingPortraitDialog savingPortraitDialog = Object.Instantiate<SavingPortraitDialog>(this.m_SavingPortraitDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(savingPortraitDialog.GetComponent<RectTransform>());
			return savingPortraitDialog;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000040F0 File Offset: 0x000022F0
		public SavingPortraitDialog MostrarSavingPortraitDialogWide()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			SavingPortraitDialog savingPortraitDialog = Object.Instantiate<SavingPortraitDialog>(this.m_SavingPortraitDialogWide, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(savingPortraitDialog.GetComponent<RectTransform>());
			return savingPortraitDialog;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000413C File Offset: 0x0000233C
		public SavingPortraitDialog MostrarSavingJobPortraitDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			SavingPortraitDialog savingPortraitDialog = Object.Instantiate<SavingPortraitDialog>(this.m_SavingJobPortraitDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(savingPortraitDialog.GetComponent<RectTransform>());
			return savingPortraitDialog;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004188 File Offset: 0x00002388
		public TemporalInfoDialog MostrarTemporalInfoDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			TemporalInfoDialog temporalInfoDialog = Object.Instantiate<TemporalInfoDialog>(this.m_TemporalInfoDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(temporalInfoDialog.GetComponent<RectTransform>());
			return temporalInfoDialog;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000041D4 File Offset: 0x000023D4
		public PortraitsDialog MostrarPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			PortraitsDialog portraitsDialog = Object.Instantiate<PortraitsDialog>(this.m_PortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(portraitsDialog.GetComponent<RectTransform>());
			return portraitsDialog;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004220 File Offset: 0x00002420
		public PosePortraitsDialog MostrarPosePortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			PosePortraitsDialog posePortraitsDialog = Object.Instantiate<PosePortraitsDialog>(this.m_PosePortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(posePortraitsDialog.GetComponent<RectTransform>());
			return posePortraitsDialog;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000426C File Offset: 0x0000246C
		public GesturePortraitsDialog MostrarGesturePortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			GesturePortraitsDialog gesturePortraitsDialog = Object.Instantiate<GesturePortraitsDialog>(this.m_GesturePortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(gesturePortraitsDialog.GetComponent<RectTransform>());
			return gesturePortraitsDialog;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000042B8 File Offset: 0x000024B8
		public MakeoverPortraitsDialog MostrarMakeoverPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			MakeoverPortraitsDialog makeoverPortraitsDialog = Object.Instantiate<MakeoverPortraitsDialog>(this.m_MakeoverPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(makeoverPortraitsDialog.GetComponent<RectTransform>());
			return makeoverPortraitsDialog;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004304 File Offset: 0x00002504
		public OutfitPortraitsDialog MostrarOutfitPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			OutfitPortraitsDialog outfitPortraitsDialog = Object.Instantiate<OutfitPortraitsDialog>(this.m_OutfitPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(outfitPortraitsDialog.GetComponent<RectTransform>());
			return outfitPortraitsDialog;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004350 File Offset: 0x00002550
		public CurrentWorkingModelsPortraitsDialog MostrarCurrentWorkingModelsPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			CurrentWorkingModelsPortraitsDialog currentWorkingModelsPortraitsDialog = Object.Instantiate<CurrentWorkingModelsPortraitsDialog>(this.m_CurrentWorkingModelsPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(currentWorkingModelsPortraitsDialog.GetComponent<RectTransform>());
			return currentWorkingModelsPortraitsDialog;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000439C File Offset: 0x0000259C
		public CurrentWorkingModelsPortraitsDialog MostrarCurrentModelsInCampaingPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			CurrentWorkingModelsPortraitsDialog currentWorkingModelsPortraitsDialog = Object.Instantiate<CurrentWorkingModelsPortraitsDialog>(this.m_CurrentModelsInCampaingPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(currentWorkingModelsPortraitsDialog.GetComponent<RectTransform>());
			return currentWorkingModelsPortraitsDialog;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000043E8 File Offset: 0x000025E8
		public CurrentAvailableJobsPortraitsDialog MostrarCurrentAvailableJobsPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			CurrentAvailableJobsPortraitsDialog currentAvailableJobsPortraitsDialog = Object.Instantiate<CurrentAvailableJobsPortraitsDialog>(this.m_CurrentAvailableJobsPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(currentAvailableJobsPortraitsDialog.GetComponent<RectTransform>());
			return currentAvailableJobsPortraitsDialog;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004434 File Offset: 0x00002634
		public CurrentAvailableOfficesPortraitsDialog MostrarCurrentAvailableOfficesPortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			CurrentAvailableOfficesPortraitsDialog currentAvailableOfficesPortraitsDialog = Object.Instantiate<CurrentAvailableOfficesPortraitsDialog>(this.m_CurrentAvailableOfficesPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(currentAvailableOfficesPortraitsDialog.GetComponent<RectTransform>());
			return currentAvailableOfficesPortraitsDialog;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004480 File Offset: 0x00002680
		public InterpretationPortraitsDialog MostrarInterpretationProfilePortraitsDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			InterpretationPortraitsDialog interpretationPortraitsDialog = Object.Instantiate<InterpretationPortraitsDialog>(this.m_InterpretationPortraitsDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(interpretationPortraitsDialog.GetComponent<RectTransform>());
			return interpretationPortraitsDialog;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000044CC File Offset: 0x000026CC
		public NewGameInputDialog MostrarNewGameInputDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			NewGameInputDialog newGameInputDialog = Object.Instantiate<NewGameInputDialog>(this.m_NewGameInputDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(newGameInputDialog.GetComponent<RectTransform>());
			return newGameInputDialog;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004518 File Offset: 0x00002718
		public NumberInputDialog MostrarNumberInputDialog()
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			NumberInputDialog numberInputDialog = Object.Instantiate<NumberInputDialog>(this.m_NumberInputDialog, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(numberInputDialog.GetComponent<RectTransform>());
			return numberInputDialog;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004564 File Offset: 0x00002764
		public T MostrarGeneric<T>(T prefab) where T : Component
		{
			if (this.isShowing)
			{
				throw new InvalidOperationException();
			}
			T t = Object.Instantiate<T>(prefab, Vector3.zero, Quaternion.identity, this.m_Canvas.transform);
			this.OnShowing(t.GetComponent<RectTransform>());
			return t;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000045AD File Offset: 0x000027AD
		public void AcumularErrores(Exception error, Object contexto = null)
		{
			this.AcumularErrores(error.Message, contexto);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000045BC File Offset: 0x000027BC
		public void AcumularErrores(string error, Object contexto = null)
		{
			Debug.LogError(error, contexto);
			this.m_errorAcumulado = this.m_errorAcumulado + "\n - " + error;
			if (contexto != null)
			{
				this.m_errorAcumulado = this.m_errorAcumulado + " on " + contexto.name;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000460C File Offset: 0x0000280C
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "MostrarConfirmacion",
				editorTimeVisible = false
			};
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004625 File Offset: 0x00002825
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.MostrarConfirmacion();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004634 File Offset: 0x00002834
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				text = "Mostrar Pose Portraits",
				editorTimeVisible = false
			};
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000464D File Offset: 0x0000284D
		public override void Aplicar2()
		{
			this.MostrarPosePortraitsDialog();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004656 File Offset: 0x00002856
		public override SingletonEditorBotones Boton3()
		{
			return new SingletonEditorBotones
			{
				text = "MostrarTextInputDialog",
				editorTimeVisible = false
			};
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000466F File Offset: 0x0000286F
		public override void Aplicar3()
		{
			base.Aplicar3();
			this.MostrarTextInputDialog();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000467E File Offset: 0x0000287E
		public override SingletonEditorBotones Boton4()
		{
			return new SingletonEditorBotones
			{
				text = "MostrarErrorDialog",
				editorTimeVisible = false
			};
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004697 File Offset: 0x00002897
		public override void Aplicar4()
		{
			base.Aplicar4();
			this.MostrarErrorDialog();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000046A6 File Offset: 0x000028A6
		public override SingletonEditorBotones Boton5()
		{
			return new SingletonEditorBotones
			{
				text = "Mostrar interpretation Portraits",
				editorTimeVisible = false
			};
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000046BF File Offset: 0x000028BF
		public override void Aplicar5()
		{
			base.Aplicar5();
			this.MostrarInterpretationProfilePortraitsDialog();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000046CE File Offset: 0x000028CE
		public override SingletonEditorBotones Boton6()
		{
			return new SingletonEditorBotones
			{
				text = "Mostrar Number Input",
				editorTimeVisible = false
			};
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000046E7 File Offset: 0x000028E7
		public override void Aplicar6()
		{
			this.MostrarNumberInputDialog();
		}

		// Token: 0x04000057 RID: 87
		[SerializeField]
		private ConfirmacionMiembros m_confirmacion;

		// Token: 0x04000058 RID: 88
		[SerializeField]
		private ConfirmacionMiembros m_bigConfirmacion;

		// Token: 0x04000059 RID: 89
		[SerializeField]
		private ConfirmacionResolutionMiembros m_confirmacionResolution;

		// Token: 0x0400005A RID: 90
		[SerializeField]
		private TextInputDialog m_nameInput;

		// Token: 0x0400005B RID: 91
		[SerializeField]
		private ErrorDialog m_errorDialog;

		// Token: 0x0400005C RID: 92
		[SerializeField]
		private InfoDialog m_bigInfo;

		// Token: 0x0400005D RID: 93
		[SerializeField]
		private SavingPortraitDialog m_SavingPortraitDialog;

		// Token: 0x0400005E RID: 94
		[SerializeField]
		private SavingPortraitDialog m_SavingPortraitDialogWide;

		// Token: 0x0400005F RID: 95
		[SerializeField]
		private SavingPortraitDialog m_SavingJobPortraitDialog;

		// Token: 0x04000060 RID: 96
		[SerializeField]
		private TemporalInfoDialog m_TemporalInfoDialog;

		// Token: 0x04000061 RID: 97
		[SerializeField]
		private PortraitsDialog m_PortraitsDialog;

		// Token: 0x04000062 RID: 98
		[SerializeField]
		private PosePortraitsDialog m_PosePortraitsDialog;

		// Token: 0x04000063 RID: 99
		[SerializeField]
		private GesturePortraitsDialog m_GesturePortraitsDialog;

		// Token: 0x04000064 RID: 100
		[SerializeField]
		private MakeoverPortraitsDialog m_MakeoverPortraitsDialog;

		// Token: 0x04000065 RID: 101
		[SerializeField]
		private OutfitPortraitsDialog m_OutfitPortraitsDialog;

		// Token: 0x04000066 RID: 102
		[SerializeField]
		private InterpretationPortraitsDialog m_InterpretationPortraitsDialog;

		// Token: 0x04000067 RID: 103
		[SerializeField]
		private NewGameInputDialog m_NewGameInputDialog;

		// Token: 0x04000068 RID: 104
		[SerializeField]
		private NumberInputDialog m_NumberInputDialog;

		// Token: 0x04000069 RID: 105
		[SerializeField]
		private CurrentWorkingModelsPortraitsDialog m_CurrentWorkingModelsPortraitsDialog;

		// Token: 0x0400006A RID: 106
		[SerializeField]
		private CurrentWorkingModelsPortraitsDialog m_CurrentModelsInCampaingPortraitsDialog;

		// Token: 0x0400006B RID: 107
		[SerializeField]
		private CurrentAvailableJobsPortraitsDialog m_CurrentAvailableJobsPortraitsDialog;

		// Token: 0x0400006C RID: 108
		[SerializeField]
		private CurrentAvailableOfficesPortraitsDialog m_CurrentAvailableOfficesPortraitsDialog;

		// Token: 0x0400006D RID: 109
		private Canvas m_Canvas;

		// Token: 0x0400006E RID: 110
		[ReadOnlyUI]
		[SerializeField]
		private List<GameObject> m_modalesUsando = new List<GameObject>();

		// Token: 0x0400006F RID: 111
		private HashSet<string> m_confirmacionesIgnorando = new HashSet<string>();

		// Token: 0x04000070 RID: 112
		[Obsolete("", true)]
		private ModificadorDeBool m_inputMod;

		// Token: 0x04000072 RID: 114
		[SerializeField]
		private ModificadorDeBool m_hideCursor;

		// Token: 0x04000073 RID: 115
		[SerializeField]
		private string m_errorAcumulado;

		// Token: 0x04000074 RID: 116
		private Queue<Action> m_mostrarAlDesocuparse = new Queue<Action>();

		// Token: 0x04000075 RID: 117
		[SerializeField]
		private Component m_mostrarNextEditor;
	}
}
