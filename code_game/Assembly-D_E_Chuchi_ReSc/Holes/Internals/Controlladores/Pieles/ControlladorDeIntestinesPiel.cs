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
	// Token: 0x020001BE RID: 446
	public class ControlladorDeIntestinesPiel : CustomMonobehaviour
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0002FFC3 File Offset: 0x0002E1C3
		public ValorFlotanteDoble veinsScale3
		{
			get
			{
				return this.m_veinsScale3;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0002FFCB File Offset: 0x0002E1CB
		public ValorFlotante veinsVisibility3
		{
			get
			{
				return this.m_veinsVisibility3;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0002FFD3 File Offset: 0x0002E1D3
		public ValorFlotanteDoble veinsScale4
		{
			get
			{
				return this.m_veinsScale4;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0002FFDB File Offset: 0x0002E1DB
		public ValorFlotante veinsVisibility4
		{
			get
			{
				return this.m_veinsVisibility4;
			}
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0002FFE4 File Offset: 0x0002E1E4
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			MapaDeMaterialFields mapaDeMaterialFields = Singleton<MaterialesFieldsNombres>.instance.Obtener();
			this.m_fileds2.Load(mapaDeMaterialFields.layer2);
			this.m_fileds3.Load(mapaDeMaterialFields.layer3);
			this.m_fileds4.Load(mapaDeMaterialFields.layer4);
			this.m_controller = this.GetComponentEnRoot(false);
			base.SetYieldStart();
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00030048 File Offset: 0x0002E248
		protected override IEnumerator YieldStartUnityEvent()
		{
			Skin anusSkin;
			do
			{
				anusSkin = this.m_controller.internalsRenderer.GetComponent<Skin>();
				if (anusSkin == null)
				{
					yield return null;
				}
			}
			while (anusSkin == null);
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			ControlladorDeFemalePiel.LoadMaterial(this.anusInternalsInfo, componentEnRoot.bodyAnimator, this, ref this.m_anusInternalsMaterial, null, null);
			ValoresFlotantesMateriales.LoadDefaultFloat(this.m_anusInternalsMaterial, this.m_fileds3.secondaryNormalFuerza, this.m_veinsVisibility3, this);
			ValoresFlotantesMateriales.LoadDefaultFloat(this.m_anusInternalsMaterial, this.m_fileds4.secondaryNormalFuerza, this.m_veinsVisibility4, this);
			ValoresFlotantesMateriales.LoadDefaultTexxScale(this.m_anusInternalsMaterial, this.m_fileds3.detailTexture, this.m_veinsScale3, this);
			ValoresFlotantesMateriales.LoadDefaultTexxScale(this.m_anusInternalsMaterial, this.m_fileds4.detailTexture, this.m_veinsScale4, this);
			yield break;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00030057 File Offset: 0x0002E257
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_controller.updated += this.M_controller_updated;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00030076 File Offset: 0x0002E276
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_controller != null)
			{
				this.m_controller.updated -= this.M_controller_updated;
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x000300A4 File Offset: 0x0002E2A4
		private void M_controller_updated()
		{
			if (this.m_updateCoolDown.isOn)
			{
				return;
			}
			this.m_updateCoolDown.ApplyNext(1f.Random(0.1f));
			float num = this.m_controller.GetValorActual("AnusInternal.Shape1.In") / 100f;
			float num2 = this.m_controller.GetValorActual("AnusInternal.Shape2.In") / 100f;
			float num3 = this.m_controller.GetValorActual("AnusInternal.Shape3.In") / 100f;
			ValoresFlotantesMateriales.Set(this.m_anusInternalsMaterial, this.m_fileds2.normalFuerza, num, this);
			ValoresFlotantesMateriales.Set(this.m_anusInternalsMaterial, this.m_fileds3.normalFuerza, num2, this);
			ValoresFlotantesMateriales.Set(this.m_anusInternalsMaterial, this.m_fileds4.normalFuerza, num3, this);
			ValoresFlotantesMateriales.Set(this.m_anusInternalsMaterial, this.m_fileds3.secondaryNormalFuerza, this.m_veinsVisibility3.valorCalculado, this);
			ValoresFlotantesMateriales.Set(this.m_anusInternalsMaterial, this.m_fileds4.secondaryNormalFuerza, this.m_veinsVisibility4.valorCalculado, this);
			ValoresFlotantesMateriales.SetTexxScale(this.m_anusInternalsMaterial, this.m_fileds3.detailTexture, new Vector2(this.m_veinsScale3.valorCalculado, this.m_veinsScale3.valorCalculado2), this);
			ValoresFlotantesMateriales.SetTexxScale(this.m_anusInternalsMaterial, this.m_fileds4.detailTexture, new Vector2(this.m_veinsScale4.valorCalculado, this.m_veinsScale4.valorCalculado2), this);
		}

		// Token: 0x040008A7 RID: 2215
		public MapaDeMaterialesDeFemaleQueSonPiel.Par anusInternalsInfo = new MapaDeMaterialesDeFemaleQueSonPiel.Par();

		// Token: 0x040008A8 RID: 2216
		[ReadOnlyUI]
		[SerializeField]
		private Material m_anusInternalsMaterial;

		// Token: 0x040008A9 RID: 2217
		private ControlladorDeShapeDeAnusInternals m_controller;

		// Token: 0x040008AA RID: 2218
		[ReadOnlyUI]
		[SerializeField]
		private MaterialFieldsDeLayerIDs m_fileds2 = new MaterialFieldsDeLayerIDs();

		// Token: 0x040008AB RID: 2219
		[ReadOnlyUI]
		[SerializeField]
		private MaterialFieldsDeLayerIDs m_fileds3 = new MaterialFieldsDeLayerIDs();

		// Token: 0x040008AC RID: 2220
		[ReadOnlyUI]
		[SerializeField]
		private MaterialFieldsDeLayerIDs m_fileds4 = new MaterialFieldsDeLayerIDs();

		// Token: 0x040008AD RID: 2221
		[SerializeField]
		private ValorFlotanteDoble m_veinsScale3 = new ValorFlotanteDoble();

		// Token: 0x040008AE RID: 2222
		[SerializeField]
		private ValorFlotante m_veinsVisibility3 = new ValorFlotante();

		// Token: 0x040008AF RID: 2223
		[SerializeField]
		private ValorFlotanteDoble m_veinsScale4 = new ValorFlotanteDoble();

		// Token: 0x040008B0 RID: 2224
		[SerializeField]
		private ValorFlotante m_veinsVisibility4 = new ValorFlotante();

		// Token: 0x040008B1 RID: 2225
		private CoolDown m_updateCoolDown = new CoolDown();
	}
}
