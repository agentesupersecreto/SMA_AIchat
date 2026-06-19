using System;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles.UI
{
	// Token: 0x02000020 RID: 32
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class PanelEditorDeAutoRatingProfiles : PanelBaseSingleModel<AutoRatingProfileModel>
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00007249 File Offset: 0x00005449
		public override bool CanShow()
		{
			return base.CanShow() && (!Singleton<ModalWindow>.IsInScene || !Singleton<ModalWindow>.instance.isShowing);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000726B File Offset: 0x0000546B
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_currentPanel.portrait.texture = Singleton<AutoRatingProfilePreview>.instance.renderTexture;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000728D File Offset: 0x0000548D
		protected override void OnBinding()
		{
			base.OnBinding();
			this.ClearAll();
			Singleton<AutoRatingProfilePreview>.instance.Mostrar();
			this.ResetInterpretacion();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000072AC File Offset: 0x000054AC
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_currentPanel = (AutoRatingProfilesEditor)base.UIPanel;
			this.m_model.fieldsDeModo = this.GetModeloDeModo(this.m_model.modo);
			this.ReDrawInterpretacionPanel(this.m_model.fieldsDeModo);
			this.m_currentPanel.onSave += this.PanelEditor_onSave;
			this.m_currentPanel.onLoad += this.M_currentPanel_onLoad;
			this.m_currentPanel.onReset += this.M_currentPanel_onReset;
			this.m_currentPanel.onModeChanged += this.M_currentPanel_onModeChanged;
			this.m_model.onChanged += this.M_model_onChanged;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00007370 File Offset: 0x00005570
		protected override void OnHided()
		{
			base.OnHided();
			if (this.m_model != null)
			{
				this.m_model.onChanged += this.M_model_onChanged;
			}
			if (this.m_currentPanel != null)
			{
				this.m_currentPanel.onSave -= this.PanelEditor_onSave;
				this.m_currentPanel.onLoad -= this.M_currentPanel_onLoad;
				this.m_currentPanel.onReset -= this.M_currentPanel_onReset;
				this.m_currentPanel.onModeChanged -= this.M_currentPanel_onModeChanged;
			}
			this.ClearAll();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00007414 File Offset: 0x00005614
		private void ResetInterpretacion()
		{
			this.m_model.fieldsDeModo = null;
			this.m_Wraper.modo = (this.m_model.modo = 0);
			this.m_Wraper.completa = MapaSingleton<MapaSingletonDefaultInterpretacion>.instance.interpretacion;
			this.m_Wraper.simple = InterpretacionSimple.@default;
			this.m_Wraper.simple.ConvertirA(ref this.m_Wraper.completa);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00007488 File Offset: 0x00005688
		private void ClearAll()
		{
			this.ClearInterpretacionPanel();
			this.m_currentPanel = null;
			this.m_Wraper.simple = default(InterpretacionSimple);
			this.m_Wraper.completa = default(InterpretacionCompletaDeFemale);
			if (Singleton<AutoRatingProfilePreview>.IsInScene)
			{
				Singleton<AutoRatingProfilePreview>.instance.Ocultar();
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000074D8 File Offset: 0x000056D8
		private void ReDrawInterpretacionPanel(object subModel)
		{
			this.ClearInterpretacionPanel();
			if (subModel == null)
			{
				return;
			}
			Transform parentPara = base.UIPanel.GetParentPara(0);
			DibujadorDynamico.ExtraData extraData = null;
			IUIPanel iuipanel = DibujadorDynamico.instance.DibujarPanel(this.m_model.fieldsDeModo, parentPara, ref extraData, this.m_model.GetType().GetField("fieldsDeModo"), null, null);
			DibujadorDynamico.instance.SetValoresAPanel(this.m_currentPanel, this.m_model, true);
			DibujadorDynamico.instance.AddListinersToPanel(this.m_currentPanel, this.m_model, extraData.todosLosDibujados, null);
			DibujadorDynamico.instance.AddBotones(this.m_model.fieldsDeModo, iuipanel, ref extraData);
			DibujadorDynamico.instance.SetControlesAPanel(iuipanel, this.m_model.fieldsDeModo, extraData, new UnityAction(this.Clear), new UnityAction(this.Hide));
			DibujadorDynamico.instance.BindSubPanel(iuipanel, base.UIPanel, "fieldsDeModo");
			this.ActualizarPreview(this.m_currentPanel.currentMode);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000075DC File Offset: 0x000057DC
		private void ClearInterpretacionPanel()
		{
			AutoRatingProfilesEditor currentPanel = this.m_currentPanel;
			GameObject gameObject;
			if (currentPanel == null)
			{
				gameObject = null;
			}
			else
			{
				Transform parentPara = currentPanel.GetParentPara(0);
				if (parentPara == null)
				{
					gameObject = null;
				}
				else
				{
					IUIPanel componentInChildren = parentPara.GetComponentInChildren<IUIPanel>();
					if (componentInChildren == null)
					{
						gameObject = null;
					}
					else
					{
						Transform transform = componentInChildren.transform;
						gameObject = ((transform != null) ? transform.gameObject : null);
					}
				}
			}
			GameObject gameObject2 = gameObject;
			if (gameObject2 != null)
			{
				Object.Destroy(gameObject2);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00007630 File Offset: 0x00005830
		private void M_model_onChanged(IUIElementoConValor arg1, AutoRatingProfileModel arg2)
		{
			this.SavePanelValuesAModelo(this.m_currentPanel.currentMode);
			this.ActualizarPreview(this.m_currentPanel.currentMode);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00007654 File Offset: 0x00005854
		private void M_currentPanel_onModeChanged(int arg1, AutoRatingProfilesEditor arg2)
		{
			if (this.m_flagUserCanceloElCompletoToSimpleModeAccion)
			{
				this.m_flagUserCanceloElCompletoToSimpleModeAccion = false;
				return;
			}
			int num;
			if (arg1 != 0)
			{
				if (arg1 != 1)
				{
					throw new ArgumentOutOfRangeException(this.m_currentPanel.currentMode.ToString());
				}
				num = 0;
			}
			else
			{
				num = 1;
			}
			if (!this.m_flagUserIsLoading && num == 1 && arg1 == 0)
			{
				this.ConfirmarChangeModeCompleteToSimple(num, arg1);
				return;
			}
			this.m_flagUserIsLoading = false;
			this.changeMode(num, arg1);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000076C4 File Offset: 0x000058C4
		private void changeMode(int last, int arg1)
		{
			this.SavePanelValuesAModelo(last);
			this.m_model.fieldsDeModo = this.GetModeloDeModo(arg1);
			this.ActualizarPreview(arg1);
			this.SavePanelValuesAModelo(arg1);
			this.ReDrawInterpretacionPanel(this.m_model.fieldsDeModo);
			this.LoadPanelValuesDesdeModelo(arg1);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007710 File Offset: 0x00005910
		private void ConfirmarChangeModeCompleteToSimple(int last, int arg1)
		{
			ConfirmacionMiembros dialog = Singleton<ModalWindow>.instance.MostrarConfirmacion();
			dialog.pregunta.text = "<B>Warning</B>: switching from <B>Complete</B> to <B>Simple</B> mode will wipe out all changes made in <B>Complete</B> mode. Do you still want to go back to <B>Simple</B> mode?";
			dialog.aceptar.onClick.AddListener(delegate
			{
				Singleton<ModalWindow>.instance.Clear(dialog);
				this.changeMode(last, arg1);
			});
			dialog.cancelar.onClick.AddListener(delegate
			{
				this.m_flagUserCanceloElCompletoToSimpleModeAccion = true;
				Singleton<ModalWindow>.instance.Clear(dialog);
				this.m_currentPanel.currentMode = 1;
			});
			dialog.noMostrarOtraVezToggle.interactable = false;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000077B0 File Offset: 0x000059B0
		private void PanelEditor_onSave(string arg1, AutoRatingProfilesEditor arg2)
		{
			if (string.IsNullOrWhiteSpace(arg1))
			{
				ErrorDialog dialog = Singleton<ModalWindow>.instance.MostrarErrorDialog();
				dialog.pregunta.text = "Please set a valid File Name.";
				dialog.aceptar.onClick.AddListener(delegate
				{
					Singleton<ModalWindow>.instance.Clear(dialog);
				});
				return;
			}
			this.SavePanelValuesAModelo(this.m_model.modo);
			this.m_Wraper.modo = this.m_model.modo;
			RenderTexture renderTexture = Singleton<AutoRatingProfilePreview>.instance.renderTexture;
			bool flag = !GraphicsFormatUtility.IsSRGBFormat(renderTexture.graphicsFormat);
			Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, flag);
			try
			{
				RenderTexture.active = renderTexture;
				texture2D.ReadPixels(new Rect(0f, 0f, (float)renderTexture.width, (float)renderTexture.height), 0, 0);
				texture2D.Apply();
				string text = JsonUtility.ToJson(this.m_Wraper);
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				SaveLoadProfilePortraits.Guardar(arg1, texture2D, bytes);
			}
			finally
			{
				Object.Destroy(texture2D);
			}
			TemporalInfoDialog temporalInfoDialog = Singleton<ModalWindow>.instance.MostrarTemporalInfoDialog();
			temporalInfoDialog.duration = 0.5f;
			temporalInfoDialog.info.text = "Saved...";
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000078FC File Offset: 0x00005AFC
		private void M_currentPanel_onLoad(string arg1, AutoRatingProfilesEditor arg2)
		{
			InterpretationPortraitsDialog portraits = Singleton<ModalWindow>.instance.MostrarInterpretationProfilePortraitsDialog();
			portraits.panelDePortraits.portraitsModel.canceling += delegate(InterpretationPortraitsModel model)
			{
				Singleton<ModalWindow>.instance.Clear(portraits);
			};
			portraits.panelDePortraits.portraitsModel.staring += delegate(InterpretationPortraitsModel model)
			{
				Singleton<ModalWindow>.instance.Clear(portraits);
				if (model.disponibles.ContieneIndex(model.currentSelected))
				{
					this.LoadPortraitFromDisk(model);
				}
			};
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00007968 File Offset: 0x00005B68
		private void LoadPortraitFromDisk(InterpretationPortraitsModel model)
		{
			this.m_flagUserIsLoading = true;
			MultipleValorElemento<string, bool> multipleValorElemento = model.disponibles[model.currentSelected];
			this.LoadProfile(multipleValorElemento.item1);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000799C File Offset: 0x00005B9C
		public void LoadProfile(string profileName)
		{
			Texture2D texture2D;
			byte[] array;
			SaveLoadProfilePortraits.Cargar(profileName, out texture2D, out array);
			this.m_currentPanel.SetFileName(profileName);
			try
			{
				if (array == null || array.Length == 0)
				{
					ErrorDialog modal2 = Singleton<ModalWindow>.instance.MostrarErrorDialog();
					modal2.pregunta.text = "Invalid Portrait File";
					modal2.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(modal2);
					});
				}
				else
				{
					string @string = Encoding.UTF8.GetString(array);
					try
					{
						AutoRatingWraper autoRatingWraper = JsonUtility.FromJson<AutoRatingWraper>(@string);
						this.m_model.modo = (this.m_Wraper.modo = autoRatingWraper.modo);
						this.m_Wraper.simple = autoRatingWraper.simple;
						this.m_Wraper.completa = autoRatingWraper.completa;
						this.m_model.fieldsDeModo = this.GetModeloDeModo(this.m_Wraper.modo);
						if (this.m_currentPanel.currentMode != this.m_Wraper.modo)
						{
							this.m_currentPanel.currentMode = this.m_Wraper.modo;
						}
						else
						{
							this.ReDrawInterpretacionPanel(this.m_model.fieldsDeModo);
						}
					}
					catch (Exception ex)
					{
						ErrorDialog modal = Singleton<ModalWindow>.instance.MostrarErrorDialog();
						modal.pregunta.text = "Invalid Portrait File: " + ex.Message;
						modal.aceptar.onClick.AddListener(delegate
						{
							Singleton<ModalWindow>.instance.Clear(modal);
						});
					}
				}
			}
			finally
			{
				Object.Destroy(texture2D);
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007B6C File Offset: 0x00005D6C
		private void M_currentPanel_onReset(string arg1, AutoRatingProfilesEditor arg2)
		{
			this.ResetInterpretacion();
			this.m_model.fieldsDeModo = this.GetModeloDeModo(0);
			if (this.m_currentPanel != null)
			{
				if (this.m_currentPanel.currentMode != 0)
				{
					this.m_currentPanel.currentMode = 0;
				}
				else
				{
					this.ReDrawInterpretacionPanel(this.m_model.fieldsDeModo);
				}
			}
			this.m_currentPanel.SetFileName(string.Empty);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00007BDC File Offset: 0x00005DDC
		private void ActualizarPreview(int mode)
		{
			LoaderInterpretacionDeApariencia loaderInterpretacionDeApariencia = Singleton<AutoRatingProfilePreview>.instance.loaderInterpretacionDeApariencia;
			if (loaderInterpretacionDeApariencia == null)
			{
				return;
			}
			if (mode != 0)
			{
				if (mode != 1)
				{
					throw new ArgumentOutOfRangeException(this.m_currentPanel.currentMode.ToString());
				}
			}
			else
			{
				this.m_Wraper.simple.ConvertirA(ref this.m_Wraper.completa);
			}
			loaderInterpretacionDeApariencia.LoadInterpretacion(ref this.m_Wraper.completa);
			Singleton<AutoRatingProfilePreview>.instance.TakeFrame();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00007C58 File Offset: 0x00005E58
		private object GetModeloDeModo(int modo)
		{
			if (modo == 0)
			{
				return this.m_Wraper.simple;
			}
			if (modo != 1)
			{
				throw new ArgumentOutOfRangeException(this.m_currentPanel.currentMode.ToString());
			}
			return this.m_Wraper.completa;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00007CA8 File Offset: 0x00005EA8
		private void SavePanelValuesAModelo(int mode)
		{
			if (this.m_currentPanel == null)
			{
				return;
			}
			DibujadorDynamico.instance.SetValoresAModelo(this.m_model, this.m_currentPanel);
			this.m_model.modo = mode;
			if (mode != 0)
			{
				if (mode != 1)
				{
					throw new ArgumentOutOfRangeException(this.m_currentPanel.currentMode.ToString());
				}
				if (this.m_model.fieldsDeModo != null && this.m_model.fieldsDeModo is InterpretacionCompletaDeFemale)
				{
					this.m_Wraper.completa = (InterpretacionCompletaDeFemale)this.m_model.fieldsDeModo;
					return;
				}
			}
			else if (this.m_model.fieldsDeModo != null && this.m_model.fieldsDeModo is InterpretacionSimple)
			{
				this.m_Wraper.simple = (InterpretacionSimple)this.m_model.fieldsDeModo;
				return;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00007D84 File Offset: 0x00005F84
		private void LoadPanelValuesDesdeModelo(int mode)
		{
			if (this.m_currentPanel == null)
			{
				return;
			}
			if (mode != 0)
			{
				if (mode != 1)
				{
					throw new ArgumentOutOfRangeException(this.m_currentPanel.currentMode.ToString());
				}
				this.m_model.fieldsDeModo = this.m_Wraper.completa;
			}
			else
			{
				this.m_model.fieldsDeModo = this.m_Wraper.simple;
			}
			DibujadorDynamico.instance.SetValoresAPanel(this.m_currentPanel, this.m_model, true);
		}

		// Token: 0x040000C2 RID: 194
		[SerializeField]
		private AutoRatingWraper m_Wraper = new AutoRatingWraper();

		// Token: 0x040000C3 RID: 195
		private AutoRatingProfilesEditor m_currentPanel;

		// Token: 0x040000C4 RID: 196
		[Obsolete("", true)]
		private AutoRatingProfilePreview m_AutoRatingProfilePreview;

		// Token: 0x040000C5 RID: 197
		private bool m_flagUserCanceloElCompletoToSimpleModeAccion;

		// Token: 0x040000C6 RID: 198
		private bool m_flagUserIsLoading;
	}
}
