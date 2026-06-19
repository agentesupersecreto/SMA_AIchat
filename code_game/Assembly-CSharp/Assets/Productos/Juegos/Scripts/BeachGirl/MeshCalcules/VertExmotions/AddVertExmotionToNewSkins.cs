using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Skins;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts.Updaters;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Kalagaan;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.MeshCalcules.VertExmotions
{
	// Token: 0x02000093 RID: 147
	public class AddVertExmotionToNewSkins : CustomMonobehaviour
	{
		// Token: 0x060002F6 RID: 758 RVA: 0x00010B0F File Offset: 0x0000ED0F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<ConfiguradorDeSkins>.instance.adding += this.Instance_adding;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00010B2D File Offset: 0x0000ED2D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<ConfiguradorDeSkins>.IsInScene)
			{
				Singleton<ConfiguradorDeSkins>.instance.adding -= this.Instance_adding;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00010B54 File Offset: 0x0000ED54
		private void Instance_adding(SkinnedMeshRenderer renderer, Animator source, SkinConfig config, ICharacterSkinMeshConfig charConfig = null, object extraData = null, Transform ownArmature = null)
		{
			if (config.usarVertExmotion)
			{
				VertExmotion.SetSensorsCount();
				VertExmotion componentNotNull = renderer.GetComponentNotNull<VertExmotion>();
				componentNotNull.m_params.usePaintDataFromMeshColors = true;
				componentNotNull.m_normalCorrection = 1f;
				componentNotNull.m_normalSmooth = 0.05f;
				componentNotNull.m_useVertexBufferMode = config.usarVertExmotionVB;
				renderer.GetComponentNotNull<VertExmotionUpdater>();
				LoadSensoresDeMainCharacter componentNotNull2 = renderer.GetComponentNotNull<LoadSensoresDeMainCharacter>();
				componentNotNull2.layer = this.GetLayerFromExtraData(extraData);
				componentNotNull2.loadFromMainCharacter = (componentNotNull2.loadFromSelfCharacter = true);
			}
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00010BCC File Offset: 0x0000EDCC
		private SensorConLayers.Layer GetLayerFromExtraData(object extraData)
		{
			MapaDeRopa.RopaData ropaData = extraData as MapaDeRopa.RopaData;
			if (ropaData == null)
			{
				return SensorConLayers.Layer.skin;
			}
			switch (ropaData.layer)
			{
			case RopaLayer.debajoDeRopaInterior:
			case RopaLayer.ropaInterior:
			case RopaLayer.debajoDeRopa:
				return SensorConLayers.Layer.ropaInterior;
			case RopaLayer.ropa:
			case RopaLayer.debajoDeAccesorios:
				return SensorConLayers.Layer.ropa;
			case RopaLayer.accesorios:
			case RopaLayer.debajoDeAbrigo:
			case RopaLayer.abrigo:
				return SensorConLayers.Layer.ropaExterior;
			default:
				throw new ArgumentOutOfRangeException(ropaData.layer.ToString());
			}
		}
	}
}
