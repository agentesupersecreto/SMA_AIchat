using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.UI.Runtime.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x0200009E RID: 158
	[RequireComponent(typeof(PanelGameOptions))]
	public class GoBackToMainMenuHandler : CustomMonobehaviour
	{
		// Token: 0x06000326 RID: 806 RVA: 0x00011265 File Offset: 0x0000F465
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PanelGameOptions = base.GetComponent<PanelGameOptions>();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00011279 File Offset: 0x0000F479
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_PanelGameOptions.onGoingBackToMainMenu += this.M_PanelGameOptions_onGoingBackToMainMenu;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00011298 File Offset: 0x0000F498
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PanelGameOptions)
			{
				this.m_PanelGameOptions.onGoingBackToMainMenu -= this.M_PanelGameOptions_onGoingBackToMainMenu;
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000112C8 File Offset: 0x0000F4C8
		private void M_PanelGameOptions_onGoingBackToMainMenu(PanelGameOptions obj)
		{
			this.m_PanelGameOptions.Clear();
			int sceneCount = SceneManager.sceneCount;
			Scene[] array = new Scene[sceneCount];
			for (int i = 0; i < sceneCount; i++)
			{
				array[i] = SceneManager.GetSceneAt(i);
			}
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 8;
			@default.doLoadOrDoUnload = true;
			Singleton<SceneLoader>.instance.AddPedido(@default);
			for (int j = sceneCount - 1; j >= 0; j--)
			{
				Scene scene = array[j];
				SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
				default2.scene.scene = scene;
				default2.doLoadOrDoUnload = false;
				if (j == 0)
				{
					default2.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
					{
						GlobalSingletonV2<MemoriaJson>.instance.ResetLoadedMemoria();
					};
				}
				Singleton<SceneLoader>.instance.AddPedido(default2);
			}
			SceneLoader.Pedido default3 = SceneLoader.Pedido.@default;
			default3.scene.index = 0;
			default3.doLoadOrDoUnload = true;
			Singleton<SceneLoader>.instance.AddPedido(default3);
			SceneLoader.Pedido default4 = SceneLoader.Pedido.@default;
			default4.scene.index = 8;
			default4.doLoadOrDoUnload = false;
			Singleton<SceneLoader>.instance.AddPedido(default4);
			SceneLoader.Pedido default5 = SceneLoader.Pedido.@default;
			default5.scene.index = 1;
			default5.doLoadOrDoUnload = true;
			Singleton<SceneLoader>.instance.AddPedido(default5);
			SceneLoader.Pedido default6 = SceneLoader.Pedido.@default;
			default6.scene.index = 2;
			default6.doLoadOrDoUnload = true;
			Singleton<SceneLoader>.instance.AddPedido(default6);
		}

		// Token: 0x04000166 RID: 358
		private PanelGameOptions m_PanelGameOptions;
	}
}
