using System;
using Assets.Productos.Juegos.Reception.Scripts.TimepoEventosDeJuego;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Scenes;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas
{
	// Token: 0x0200009D RID: 157
	[Obsolete("reemplazado por actividades", true)]
	public class EntrevistaLoader : CustomMonobehaviour
	{
		// Token: 0x06000321 RID: 801 RVA: 0x000110F4 File Offset: 0x0000F2F4
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			foreach (EventoDiarioHorario eventoDiarioHorario in Singleton<HorariosNormalesDeEntrevistas>.instance.eventosDeEntrevistas)
			{
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00011144 File Offset: 0x0000F344
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<HorariosNormalesDeEntrevistas>.IsInScene)
			{
				foreach (EventoDiarioHorario eventoDiarioHorario in Singleton<HorariosNormalesDeEntrevistas>.instance.eventosDeEntrevistas)
				{
				}
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0001119C File Offset: 0x0000F39C
		private void Item_ended(Evento obj)
		{
			if (!Singleton<SceneLoader>.IsInScene)
			{
				Debug.LogError("Cant change scene, SceneLoader is not in the scene");
				return;
			}
			Debug.LogError("ya esto deberia ser obsoleto");
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 5;
			@default.doLoadOrDoUnload = false;
			SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
			default2.scene.index = 4;
			default2.doLoadOrDoUnload = false;
			Singleton<SceneLoader>.instance.AddPedido(@default);
			Singleton<SceneLoader>.instance.AddPedido(default2);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00011210 File Offset: 0x0000F410
		private void Item_stared(Evento obj)
		{
			if (!Singleton<SceneLoader>.IsInScene)
			{
				Debug.LogError("Cant change scene, SceneLoader is not in the scene");
				return;
			}
			Debug.LogError("ya esto deberia ser obsoleto");
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 4;
			@default.doLoadOrDoUnload = true;
			Singleton<SceneLoader>.instance.AddPedido(@default);
		}
	}
}
