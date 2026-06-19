using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Materiales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Apariencia;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.EyeAdvance.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.DeMateriales
{
	// Token: 0x02000298 RID: 664
	[LabelLocalizado("<i>Materials:</i> Eyes", "US")]
	public sealed class AlteracionesDeMateralesDeOjos : HolderDualDeAlteradores<AlteradorDeTexturaAddressable, AlteradorGenericoDirectoTripleConInicial>
	{
		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06001145 RID: 4421 RVA: 0x0002956C File Offset: 0x0002776C
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate1;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06001146 RID: 4422 RVA: 0x000512C4 File Offset: 0x0004F4C4
		protected override GlobalUpdater.UpdateType? updateTypeB
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x000512DC File Offset: 0x0004F4DC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_anim = this.GetComponentEnCharacter(false);
			if (this.m_anim == null)
			{
				throw new ArgumentNullException("m_anim", "m_anim null reference.");
			}
			this.m_eyeL = this.m_anim.GetBoneTransform(HumanBodyBones.LeftEye);
			this.m_eyeR = this.m_anim.GetBoneTransform(HumanBodyBones.RightEye);
			if (this.m_eyeL == null || this.m_eyeR == null)
			{
				this.m_tieneEyeAdvance = false;
				return;
			}
			this.m_eyeLRenderer = this.m_eyeL.GetComponentInChildren<Renderer>();
			this.m_eyeRRenderer = this.m_eyeR.GetComponentInChildren<Renderer>();
			if (this.m_eyeLRenderer == null || this.m_eyeRRenderer == null)
			{
				this.m_tieneEyeAdvance = false;
				return;
			}
			this.m_tieneEyeAdvance = true;
			this.m_Controllador = this.GetComponentEnCharacter(false);
			if (this.m_Controllador == null)
			{
				throw new ArgumentNullException("m_Controllador", "m_Controllador null reference.");
			}
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x000513DC File Offset: 0x0004F5DC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Singleton<ConfiguracionGeneralDeGamePlay>.instance.changed += this.Instance_changed;
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x000513FA File Offset: 0x0004F5FA
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (Singleton<ConfiguracionGeneralDeGamePlay>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeGamePlay>.instance.changed -= this.Instance_changed;
			}
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x00051420 File Offset: 0x0004F620
		private void Instance_changed(ConfiguracionGeneralDeGamePlay obj)
		{
			if (this.m_alteradorDeColorDeOjosL != null)
			{
				this.m_alteradorDeColorDeOjosL.flagForceUpdate = true;
			}
			if (this.m_alteradorDeColorDeOjosR != null)
			{
				this.m_alteradorDeColorDeOjosR.flagForceUpdate = true;
			}
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x0005144A File Offset: 0x0004F64A
		private IReadOnlyList<AssetReference> TextureIrisGetter()
		{
			return MapaSingleton<MapaSingletonDeTexturasDeIris_EyeAdvance>.instance.addresses;
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x00051458 File Offset: 0x0004F658
		protected override void InstanciarAlteradores(List<AlteradorDeTexturaAddressable> resultado)
		{
			if (!this.m_tieneEyeAdvance)
			{
				return;
			}
			Func<IReadOnlyList<AssetReference>> func = new Func<IReadOnlyList<AssetReference>>(this.TextureIrisGetter);
			AlteradorDeTexturaAddressable alteradorDeTexturaAddressable = new AlteradorDeTexturaAddressable(this.m_eyeRRenderer, "_IrisColorTex", 0, func, DiccionarioDeNombresDeAlteradoresFemeninos.Textureador_Iris_R, this);
			AlteradorDeTexturaAddressable alteradorDeTexturaAddressable2 = new AlteradorDeTexturaAddressable(this.m_eyeLRenderer, "_IrisColorTex", 0, func, DiccionarioDeNombresDeAlteradoresFemeninos.Textureador_Iris_L, this);
			resultado.Add(alteradorDeTexturaAddressable);
			resultado.Add(alteradorDeTexturaAddressable2);
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x000514BC File Offset: 0x0004F6BC
		protected override void InstanciarAlteradoresB(List<AlteradorGenericoDirectoTripleConInicial> resultado)
		{
			if (!this.m_tieneEyeAdvance)
			{
				return;
			}
			AlteradorGenericoDirectoTripleConInicial alteradorGenericoDirectoTripleConInicial = new AlteradorGenericoDirectoTripleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_Sclera_R, this, delegate(float a, float b, float c)
			{
				this.m_Controllador.colorDeScleraR.hue.baseSetter = a;
				this.m_Controllador.colorDeScleraR.saturation.baseSetter = b;
				this.m_Controllador.colorDeScleraR.value.baseSetter = c;
				this.m_Controllador.ActualizarOjoR();
			}, new AlteradorGenericoDirectoTripleConInicial.Getter(this.GetterColorScleraR), this.rangos.scleraColor.minHue / 360f, this.rangos.scleraColor.maxHue / 360f, this.rangos.scleraColor.minSaturation / 100f, this.rangos.scleraColor.maxSaturation / 100f, this.rangos.scleraColor.minBrightness / 100f, this.rangos.scleraColor.maxBrightness / 100f);
			resultado.Add(alteradorGenericoDirectoTripleConInicial);
			AlteradorGenericoDirectoTripleConInicial alteradorGenericoDirectoTripleConInicial2 = new AlteradorGenericoDirectoTripleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_Sclera_L, this, delegate(float a, float b, float c)
			{
				this.m_Controllador.colorDeScleraL.hue.baseSetter = a;
				this.m_Controllador.colorDeScleraL.saturation.baseSetter = b;
				this.m_Controllador.colorDeScleraL.value.baseSetter = c;
				this.m_Controllador.ActualizarOjoL();
			}, new AlteradorGenericoDirectoTripleConInicial.Getter(this.GetterColorScleraL), this.rangos.scleraColor.minHue / 360f, this.rangos.scleraColor.maxHue / 360f, this.rangos.scleraColor.minSaturation / 100f, this.rangos.scleraColor.maxSaturation / 100f, this.rangos.scleraColor.minBrightness / 100f, this.rangos.scleraColor.maxBrightness / 100f);
			resultado.Add(alteradorGenericoDirectoTripleConInicial2);
			if (this.usarColoreadorDeIris)
			{
				this.m_alteradorDeColorDeOjosR = new AlteradorGenericoDirectoTripleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_Iris_R, this, delegate(float a, float b, float c)
				{
					Color color = Color.HSVToRGB(a, b, c);
					color = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.eyeHueConstraint.Apply(color);
					Color.RGBToHSV(color, out a, out b, out c);
					this.m_Controllador.colorDeOjoR.hue.baseSetter = a;
					this.m_Controllador.colorDeOjoR.saturation.baseSetter = b;
					this.m_Controllador.colorDeOjoR.value.baseSetter = c;
					this.m_Controllador.ActualizarOjoR();
				}, new AlteradorGenericoDirectoTripleConInicial.Getter(this.GetterColorOjoR), this.rangos.ojoColor.minHue / 360f, this.rangos.ojoColor.maxHue / 360f, this.rangos.ojoColor.minSaturation / 100f, this.rangos.ojoColor.maxSaturation / 100f, this.rangos.ojoColor.minBrightness / 100f, this.rangos.ojoColor.maxBrightness / 100f);
				resultado.Add(this.m_alteradorDeColorDeOjosR);
				this.m_alteradorDeColorDeOjosL = new AlteradorGenericoDirectoTripleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_Iris_L, this, delegate(float a, float b, float c)
				{
					Color color2 = Color.HSVToRGB(a, b, c);
					color2 = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.eyeHueConstraint.Apply(color2);
					Color.RGBToHSV(color2, out a, out b, out c);
					this.m_Controllador.colorDeOjoL.hue.baseSetter = a;
					this.m_Controllador.colorDeOjoL.saturation.baseSetter = b;
					this.m_Controllador.colorDeOjoL.value.baseSetter = c;
					this.m_Controllador.ActualizarOjoL();
				}, new AlteradorGenericoDirectoTripleConInicial.Getter(this.GetterColorOjoL), this.rangos.ojoColor.minHue / 360f, this.rangos.ojoColor.maxHue / 360f, this.rangos.ojoColor.minSaturation / 100f, this.rangos.ojoColor.maxSaturation / 100f, this.rangos.ojoColor.minBrightness / 100f, this.rangos.ojoColor.maxBrightness / 100f);
				resultado.Add(this.m_alteradorDeColorDeOjosL);
			}
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x000517B0 File Offset: 0x0004F9B0
		private void GetterColorScleraR(out float a, out float b, out float c)
		{
			a = this.m_Controllador.colorDeScleraR.hue.@base;
			b = this.m_Controllador.colorDeScleraR.saturation.@base;
			c = this.m_Controllador.colorDeScleraR.value.@base;
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x00051804 File Offset: 0x0004FA04
		private void GetterColorScleraL(out float a, out float b, out float c)
		{
			a = this.m_Controllador.colorDeScleraL.hue.@base;
			b = this.m_Controllador.colorDeScleraL.saturation.@base;
			c = this.m_Controllador.colorDeScleraL.value.@base;
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x00051858 File Offset: 0x0004FA58
		private void GetterColorOjoR(out float a, out float b, out float c)
		{
			a = this.m_Controllador.colorDeOjoR.hue.@base;
			b = this.m_Controllador.colorDeOjoR.saturation.@base;
			c = this.m_Controllador.colorDeOjoR.value.@base;
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x000518AC File Offset: 0x0004FAAC
		private void GetterColorOjoL(out float a, out float b, out float c)
		{
			a = this.m_Controllador.colorDeOjoL.hue.@base;
			b = this.m_Controllador.colorDeOjoL.saturation.@base;
			c = this.m_Controllador.colorDeOjoL.value.@base;
		}

		// Token: 0x04000CA6 RID: 3238
		public bool usarColoreadorDeIris = true;

		// Token: 0x04000CA7 RID: 3239
		private bool m_tieneEyeAdvance;

		// Token: 0x04000CA8 RID: 3240
		private Transform m_eyeL;

		// Token: 0x04000CA9 RID: 3241
		private Transform m_eyeR;

		// Token: 0x04000CAA RID: 3242
		private Renderer m_eyeLRenderer;

		// Token: 0x04000CAB RID: 3243
		private Renderer m_eyeRRenderer;

		// Token: 0x04000CAC RID: 3244
		private Animator m_anim;

		// Token: 0x04000CAD RID: 3245
		public AlteracionesDeMateralesDeOjos.Rangos rangos = new AlteracionesDeMateralesDeOjos.Rangos();

		// Token: 0x04000CAE RID: 3246
		private ControlladorDeEyeAdvanceColores m_Controllador;

		// Token: 0x04000CAF RID: 3247
		[NonSerialized]
		private AlteradorGenericoDirectoTripleConInicial m_alteradorDeColorDeOjosL;

		// Token: 0x04000CB0 RID: 3248
		[NonSerialized]
		private AlteradorGenericoDirectoTripleConInicial m_alteradorDeColorDeOjosR;

		// Token: 0x02000299 RID: 665
		[Serializable]
		public class Rangos
		{
			// Token: 0x04000CB1 RID: 3249
			public AlteracionesDeMateralesDeOjos.Rangos.RangosDecolor scleraColor = new AlteracionesDeMateralesDeOjos.Rangos.RangosDecolor
			{
				minHue = -10f,
				maxHue = 40f,
				minSaturation = 0f,
				maxSaturation = 10f,
				minBrightness = 90f,
				maxBrightness = 100f
			};

			// Token: 0x04000CB2 RID: 3250
			public AlteracionesDeMateralesDeOjos.Rangos.RangosDecolor ojoColor = new AlteracionesDeMateralesDeOjos.Rangos.RangosDecolor
			{
				minBrightness = 33f,
				maxBrightness = 100f,
				minSaturation = 15f
			};

			// Token: 0x0200029A RID: 666
			[Serializable]
			public class RangosDecolor
			{
				// Token: 0x04000CB3 RID: 3251
				[Range(-360f, 360f)]
				public float minHue;

				// Token: 0x04000CB4 RID: 3252
				[Range(-360f, 360f)]
				public float maxHue = 360f;

				// Token: 0x04000CB5 RID: 3253
				[Range(0f, 100f)]
				public float minSaturation;

				// Token: 0x04000CB6 RID: 3254
				[Range(0f, 100f)]
				public float maxSaturation = 100f;

				// Token: 0x04000CB7 RID: 3255
				[Range(0f, 100f)]
				public float minBrightness;

				// Token: 0x04000CB8 RID: 3256
				[Range(0f, 100f)]
				public float maxBrightness = 100f;

				// Token: 0x04000CB9 RID: 3257
				[Range(0f, 100f)]
				public float minAlpha;

				// Token: 0x04000CBA RID: 3258
				[Range(0f, 100f)]
				public float maxAlpha = 100f;
			}
		}
	}
}
