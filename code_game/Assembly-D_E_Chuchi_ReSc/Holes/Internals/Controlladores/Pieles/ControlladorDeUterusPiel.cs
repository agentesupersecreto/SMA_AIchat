using System;
using System.Collections;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores.Pieles
{
	// Token: 0x020001C0 RID: 448
	public class ControlladorDeUterusPiel : CustomMonobehaviour
	{
		// Token: 0x06000A8F RID: 2703 RVA: 0x000303AC File Offset: 0x0002E5AC
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			MapaDeMaterialFields mapaDeMaterialFields = Singleton<MaterialesFieldsNombres>.instance.Obtener();
			this.m_fileds2.Load(mapaDeMaterialFields.layer2);
			this.m_fileds3.Load(mapaDeMaterialFields.layer3);
			this.m_controller = this.GetComponentEnRoot(false);
			base.SetYieldStart();
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x000303FF File Offset: 0x0002E5FF
		protected override IEnumerator YieldStartUnityEvent()
		{
			Skin vagSkin;
			do
			{
				vagSkin = this.m_controller.internalsRenderer.GetComponent<Skin>();
				if (vagSkin == null)
				{
					yield return null;
				}
			}
			while (vagSkin == null);
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			ControlladorDeFemalePiel.LoadMaterial(this.vagInternalsInfo, componentEnRoot.bodyAnimator, this, ref this.m_vagInternalsMaterial, null, null);
			yield break;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0003040E File Offset: 0x0002E60E
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_controller.updated += this.M_controller_updated;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0003042D File Offset: 0x0002E62D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_controller != null)
			{
				this.m_controller.updated -= this.M_controller_updated;
			}
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0003045C File Offset: 0x0002E65C
		private void M_controller_updated()
		{
			if (this.m_updateCoolDown.isOn)
			{
				return;
			}
			this.m_updateCoolDown.ApplyNext(1f.Random(0.1f));
			float num = this.m_controller.GetValorActual("PlieguesVerticales1") / 100f;
			float num2 = this.m_controller.GetValorActual("PlieguesVerticales2") / 100f;
			float num3 = this.m_controller.GetValorActual("PlieguesHorizontales1") / 100f;
			float num4 = this.m_controller.GetValorActual("PlieguesHorizontales2") / 100f;
			ValoresFlotantesMateriales.Set(this.m_vagInternalsMaterial, this.m_fileds2.normalFuerza, num * 1.5f, this);
			ValoresFlotantesMateriales.Set(this.m_vagInternalsMaterial, this.m_fileds2.secondaryNormalFuerza, num3 * 1.5f, this);
			ValoresFlotantesMateriales.Set(this.m_vagInternalsMaterial, this.m_fileds3.normalFuerza, num4 * 1.5f, this);
			ValoresFlotantesMateriales.Set(this.m_vagInternalsMaterial, this.m_fileds3.secondaryNormalFuerza, num2 * 1.5f, this);
		}

		// Token: 0x040008B6 RID: 2230
		public MapaDeMaterialesDeFemaleQueSonPiel.Par vagInternalsInfo = new MapaDeMaterialesDeFemaleQueSonPiel.Par();

		// Token: 0x040008B7 RID: 2231
		[ReadOnlyUI]
		[SerializeField]
		private Material m_vagInternalsMaterial;

		// Token: 0x040008B8 RID: 2232
		private ControlladorDeShapeDeVagInternals m_controller;

		// Token: 0x040008B9 RID: 2233
		[ReadOnlyUI]
		[SerializeField]
		private MaterialFieldsDeLayerIDs m_fileds2 = new MaterialFieldsDeLayerIDs();

		// Token: 0x040008BA RID: 2234
		[ReadOnlyUI]
		[SerializeField]
		private MaterialFieldsDeLayerIDs m_fileds3 = new MaterialFieldsDeLayerIDs();

		// Token: 0x040008BB RID: 2235
		private CoolDown m_updateCoolDown = new CoolDown();
	}
}
