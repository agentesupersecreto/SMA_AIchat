using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.General.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Scenes;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x020000A5 RID: 165
	public class PanelMainMenu : PanelBaseSingleModel<EntrevistaMainMenuModelo>
	{
		// Token: 0x0600035E RID: 862 RVA: 0x000126EC File Offset: 0x000108EC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PcOverScreen.SetActive(false);
			SaveLoadCharacters.defaultProtraitTexture = Singleton<SMAGameController>.instance.defaultFemaleProtraitTexture;
			this.m_model.continueClicked += this.M_model_continueClicked;
			this.m_model.startClicked += this.M_model_startClicked;
			this.m_model.singleClicked += this.M_model_singleClicked;
			this.m_model.designerClicked += this.M_model_designerClicked;
			PlayerPrefs.SetString("SingleModelSelected", string.Empty);
			PlayerPrefs.SetString("SelectedNPCFromCampaing", string.Empty);
			PlayerPrefs.SetInt("ModoDeJuego", 0);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000127A0 File Offset: 0x000109A0
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_PcOverScreen.SetActive(true);
			if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.Direct3D11 && SystemInfo.graphicsDeviceType != GraphicsDeviceType.Direct3D12 && SystemInfo.graphicsDeviceType != GraphicsDeviceType.Vulkan)
			{
				ErrorDialog errorDialog = Singleton<ModalWindow>.instance.MostrarErrorDialog();
				errorDialog.pregunta.text = "This game requires Direct3D11.";
				errorDialog.aceptar.onClick.AddListener(delegate
				{
					Application.Quit();
				});
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00012821 File Offset: 0x00010A21
		protected override void OnHided()
		{
			base.OnHided();
			this.m_PcOverScreen.SetActive(false);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00012835 File Offset: 0x00010A35
		private void M_model_singleClicked(EntrevistaMainMenuModelo obj)
		{
			this.m_flagStartSingle = true;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0001283E File Offset: 0x00010A3E
		private void M_model_designerClicked(EntrevistaMainMenuModelo obj)
		{
			this.m_flagStartDesinger = true;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00012847 File Offset: 0x00010A47
		private void M_model_startClicked(EntrevistaMainMenuModelo obj)
		{
			this.m_flagStart = true;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00012850 File Offset: 0x00010A50
		private void Update()
		{
			if (this.m_flagStart)
			{
				this.m_flagStart = false;
				this.m_PanelNewGameMenu.CrearYDibujar(null);
				return;
			}
			if (this.m_flagStartSingle)
			{
				this.m_flagStartSingle = false;
				PortraitsDialog diag2 = Singleton<ModalWindow>.instance.MostrarPortraitsDialog();
				diag2.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
				{
					if (model.protraitsDisponibles.ContieneIndex(model.currentSelected))
					{
						this.LoadSingle(diag2, model);
						return;
					}
					Singleton<ModalWindow>.instance.Clear(diag2);
				};
				diag2.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag2);
				};
				return;
			}
			if (this.m_flagStartDesinger)
			{
				this.m_flagStartDesinger = false;
				PortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarPortraitsDialog();
				diag.panelDePortraits.portraitsModel.bindig += delegate(BindableModel model)
				{
					((PortraitsModel)model).protraitsDisponibles.Insert(0, new MultipleValorElemento<string, bool>(string.Empty, false));
				};
				diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
				{
					if (model.protraitsDisponibles.ContieneIndex(model.currentSelected))
					{
						this.LoadDesinger(diag, model);
						return;
					}
					Singleton<ModalWindow>.instance.Clear(diag);
				};
				diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
				{
					Singleton<ModalWindow>.instance.Clear(diag);
				};
			}
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00012990 File Offset: 0x00010B90
		[Obsolete("", true)]
		private void LoadStart(NewGameInputDialog inputDialog)
		{
			this.UnloadMainLoadEmptyEntrevista(null, delegate
			{
				string text = inputDialog.inputField.text;
				int num = Mathf.Clamp(Mathf.RoundToInt(inputDialog.slider.value), 1, 10) - 1;
				Singleton<ModalWindow>.instance.ClearAll();
				if (string.IsNullOrWhiteSpace(text))
				{
					throw new InvalidOperationException("nombre de jugador invalido");
				}
				Singleton<ConfiguracionGeneralUsuario>.instance.playerName = text;
				GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("UserName", true).AddData("UserName", text, true);
				PiscinasDeEventosDeEntrevista.SetNivelInicial(num);
			});
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000129C0 File Offset: 0x00010BC0
		private void LoadSingle(PortraitsDialog dialog, PortraitsModelBase<MultipleValorElemento<string, bool>> model)
		{
			this.UnloadMainLoadSingleEntrevista(new Action(GlobalSingletonV2<MemoriaJson>.instance.LoadFromDiskMasReciente), delegate
			{
				string item = model.protraitsDisponibles[model.currentSelected].item1;
				Singleton<ModalWindow>.instance.ClearAll();
				if (string.IsNullOrWhiteSpace(item))
				{
					throw new InvalidOperationException("nombre de Modelo invalido");
				}
				PlayerPrefs.SetString("SingleModelSelected", item);
				PlayerPrefs.SetInt("ModoDeJuego", 1);
				try
				{
					Singleton<ConfiguracionGeneralUsuario>.instance.playerName = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("UserName", true).FindData("UserName", "Mr fag");
				}
				catch (Exception ex)
				{
					Debug.LogError("Error cargando nombre de hero del savegame mas reciente", this);
					Debug.LogException(ex, this);
				}
			});
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00012A04 File Offset: 0x00010C04
		private void LoadDesinger(PortraitsDialog dialog, PortraitsModelBase<MultipleValorElemento<string, bool>> model)
		{
			this.UnloadMainLoadDesigner(null, delegate
			{
				string item = model.protraitsDisponibles[model.currentSelected].item1;
				Singleton<ModalWindow>.instance.ClearAll();
				PlayerPrefs.SetString("SingleModelSelected", item);
				try
				{
					Singleton<ConfiguracionGeneralUsuario>.instance.playerName = "Mr Floting Orbe";
				}
				catch (Exception ex)
				{
					Debug.LogError("Error cargando nombre de hero del savegame mas reciente", this);
					Debug.LogException(ex, this);
				}
			});
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00012A38 File Offset: 0x00010C38
		private void UnloadMainLoadEmptyEntrevista(Action extraFunction, Action extraFunction2)
		{
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 2;
			@default.doLoadOrDoUnload = false;
			@default.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				Action extraFunction3 = extraFunction;
				if (extraFunction3 != null)
				{
					extraFunction3();
				}
				Action extraFunction4 = extraFunction2;
				if (extraFunction4 != null)
				{
					extraFunction4();
				}
				SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
				SceneLoader.Pedido default3 = SceneLoader.Pedido.@default;
				SceneLoader.Pedido default4 = SceneLoader.Pedido.@default;
				default2.scene.index = 10;
				default2.doLoadOrDoUnload = true;
				default3.scene.index = 3;
				default3.doLoadOrDoUnload = true;
				default4.scene.index = 4;
				default4.doLoadOrDoUnload = true;
				Singleton<SceneLoader>.instance.AddPedido(default2);
				Singleton<SceneLoader>.instance.AddPedido(default3);
				Singleton<SceneLoader>.instance.AddPedido(default4);
			};
			Singleton<SceneLoader>.instance.AddPedido(@default);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00012A90 File Offset: 0x00010C90
		private void UnloadMainLoadSingleEntrevista(Action extraFunction, Action extraFunction2)
		{
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 2;
			@default.doLoadOrDoUnload = false;
			@default.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				Action extraFunction3 = extraFunction;
				if (extraFunction3 != null)
				{
					extraFunction3();
				}
				Action extraFunction4 = extraFunction2;
				if (extraFunction4 != null)
				{
					extraFunction4();
				}
				SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
				SceneLoader.Pedido default3 = SceneLoader.Pedido.@default;
				SceneLoader.Pedido default4 = SceneLoader.Pedido.@default;
				default2.scene.index = 10;
				default2.doLoadOrDoUnload = true;
				default3.scene.index = 3;
				default3.doLoadOrDoUnload = true;
				default4.scene.index = 6;
				default4.doLoadOrDoUnload = true;
				Singleton<SceneLoader>.instance.AddPedido(default2);
				Singleton<SceneLoader>.instance.AddPedido(default3);
				Singleton<SceneLoader>.instance.AddPedido(default4);
			};
			Singleton<SceneLoader>.instance.AddPedido(@default);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00012AE8 File Offset: 0x00010CE8
		private void UnloadMainLoadDesigner(Action extraFunction, Action extraFunction2)
		{
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 2;
			@default.doLoadOrDoUnload = false;
			Singleton<SceneLoader>.instance.AddPedido(@default);
			SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
			default2.scene.index = 1;
			default2.doLoadOrDoUnload = false;
			default2.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				Action extraFunction3 = extraFunction;
				if (extraFunction3 != null)
				{
					extraFunction3();
				}
				Action extraFunction4 = extraFunction2;
				if (extraFunction4 != null)
				{
					extraFunction4();
				}
				Type type = GetLoaderDeNivelDeOficina.Designer(1);
				Singleton<ActividadesManager>.instance.StartActividad("Designer", type, null, null, true);
			};
			Singleton<SceneLoader>.instance.AddPedido(default2);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00012B64 File Offset: 0x00010D64
		private void UnloadMainLoadEmptyOfficeActivity(Action extraFunction, Action extraFunction2)
		{
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 2;
			@default.doLoadOrDoUnload = false;
			Singleton<SceneLoader>.instance.AddPedido(@default);
			SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
			default2.scene.index = 1;
			default2.doLoadOrDoUnload = false;
			default2.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				Action extraFunction3 = extraFunction;
				if (extraFunction3 != null)
				{
					extraFunction3();
				}
				Action extraFunction4 = extraFunction2;
				if (extraFunction4 != null)
				{
					extraFunction4();
				}
				Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
				Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, delegate(IActividadLoader loaderInstance)
				{
					((ITValleActividadEnNuevoHorarioLoader)loaderInstance).flagDontChangeTime = true;
				}, null, true);
			};
			Singleton<SceneLoader>.instance.AddPedido(default2);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00012BDF File Offset: 0x00010DDF
		private void M_model_continueClicked(EntrevistaMainMenuModelo obj)
		{
			this.UnloadMainLoadEmptyOfficeActivity(new Action(GlobalSingletonV2<MemoriaJson>.instance.LoadFromDiskDefaultFile), delegate
			{
				Singleton<ConfiguracionGeneralUsuario>.instance.playerName = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("UserName", true).FindData("UserName", "Mr fag");
			});
		}

		// Token: 0x04000174 RID: 372
		private bool m_flagStart;

		// Token: 0x04000175 RID: 373
		private bool m_flagStartSingle;

		// Token: 0x04000176 RID: 374
		private bool m_flagStartDesinger;

		// Token: 0x04000177 RID: 375
		[SerializeField]
		private GameObject m_PcOverScreen;

		// Token: 0x04000178 RID: 376
		[SerializeField]
		private PanelNewGameMenu m_PanelNewGameMenu;
	}
}
