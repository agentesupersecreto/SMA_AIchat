using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.DeMateriales
{
	// Token: 0x02000295 RID: 661
	[LabelLocalizado("<i>Materials:</i> Hair", "US")]
	public sealed class AlteracionesDeMateralesDeCabelloGeneral : HolderDualDeAlteradores<AlteradorGenericoDirectoTripleConInicial, AlteradorGenericoDirectoSingleConInicial>, IHolderDeAlteradoresDeColorDeCabello
	{
		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x0600112F RID: 4399 RVA: 0x0002956C File Offset: 0x0002776C
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate1;
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x00050DC8 File Offset: 0x0004EFC8
		protected override GlobalUpdater.UpdateType? updateTypeB
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06001131 RID: 4401 RVA: 0x00050DDE File Offset: 0x0004EFDE
		// (remove) Token: 0x06001132 RID: 4402 RVA: 0x00050DE7 File Offset: 0x0004EFE7
		event Action IHolderDeAlteradoresDeColorDeCabello.onAlteradorDeColorChanged
		{
			add
			{
				this.m_onAlteradorDeColorChanged += value;
			}
			remove
			{
				this.m_onAlteradorDeColorChanged -= value;
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06001133 RID: 4403 RVA: 0x00050DF0 File Offset: 0x0004EFF0
		// (remove) Token: 0x06001134 RID: 4404 RVA: 0x00050E28 File Offset: 0x0004F028
		private event Action m_onAlteradorDeColorChanged;

		// Token: 0x06001135 RID: 4405 RVA: 0x00050E5D File Offset: 0x0004F05D
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlladorDeCabelloGpu = this.GetComponentEnCharacter(false);
			if (this.m_ControlladorDeCabelloGpu == null)
			{
				throw new ArgumentNullException("m_ControlladorDeCabelloGpu", "m_ControlladorDeCabelloGpu null reference.");
			}
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x00050E90 File Offset: 0x0004F090
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Singleton<ConfiguracionGeneralDeGamePlay>.instance.changed += this.Instance_changed;
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x00050EAE File Offset: 0x0004F0AE
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat modificadorBrilloDeCabello = this.m_modificadorBrilloDeCabello;
			if (modificadorBrilloDeCabello != null)
			{
				modificadorBrilloDeCabello.TryRemoverDeOwner(true);
			}
			if (Singleton<ConfiguracionGeneralDeGamePlay>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeGamePlay>.instance.changed -= this.Instance_changed;
			}
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x00050EE7 File Offset: 0x0004F0E7
		private void Instance_changed(ConfiguracionGeneralDeGamePlay obj)
		{
			if (this.alteradorDeColorDeCabello != null)
			{
				this.alteradorDeColorDeCabello.flagForceUpdate = true;
			}
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x00050F00 File Offset: 0x0004F100
		protected override void InstanciarAlteradores(List<AlteradorGenericoDirectoTripleConInicial> resultado)
		{
			if (this.usarColoreadorDeCabello)
			{
				this.alteradorDeColorDeCabello = new AlteradorGenericoDirectoTripleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_StyloDeCabello, this, delegate(float a, float b, float c)
				{
					Color color = Color.HSVToRGB(a, b, c);
					color = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.hairHueConstraint.Apply(color);
					Color.RGBToHSV(color, out a, out b, out c);
					this.m_ControlladorDeCabelloGpu.colorDeGpuHair.hue.baseSetter = a;
					this.m_ControlladorDeCabelloGpu.colorDeGpuHair.saturation.baseSetter = b;
					this.m_ControlladorDeCabelloGpu.colorDeGpuHair.value.baseSetter = c;
					this.m_ControlladorDeCabelloGpu.ActualizarColorDeCabello();
					this.m_ControlladorDeCabelloGpu.ReDibujar();
					Action onAlteradorDeColorChanged = this.m_onAlteradorDeColorChanged;
					if (onAlteradorDeColorChanged == null)
					{
						return;
					}
					onAlteradorDeColorChanged();
				}, new AlteradorGenericoDirectoTripleConInicial.Getter(this.GetterColor), this.rangos.color.minHue / 360f, this.rangos.color.maxHue / 360f, this.rangos.color.minSaturation / 100f, this.rangos.color.maxSaturation / 100f, this.rangos.color.minBrightness / 100f, this.rangos.color.maxBrightness / 100f);
				resultado.Add(this.alteradorDeColorDeCabello);
			}
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x00050FD4 File Offset: 0x0004F1D4
		protected override void InstanciarAlteradoresB(List<AlteradorGenericoDirectoSingleConInicial> resultado)
		{
			this.m_modificadorBrilloDeCabello = this.m_ControlladorDeCabelloGpu.brillo.ObtenerModificadorNotNull(this);
			resultado.Add(new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Encojedor_CerdasDeCabello, this, delegate(float a)
			{
				this.m_ControlladorDeCabelloGpu.largo.SetBase(a);
				this.m_ControlladorDeCabelloGpu.ActualizarLargoDeCabello();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_ControlladorDeCabelloGpu.largo.@base, this.rangos.minLargoDeCerdas, 1f)
			{
				esSensible = true
			});
			resultado.Add(new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_BrilloDeCabello, this, delegate(float a)
			{
				this.m_modificadorBrilloDeCabello.valor.valor = a;
				this.m_ControlladorDeCabelloGpu.ActualizarBrilloDeCabello();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_modificadorBrilloDeCabello.valor.valor, this.rangos.minBrillo, this.rangos.maxBrillo)
			{
				esVolatil = true
			});
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x00051084 File Offset: 0x0004F284
		private void GetterColor(out float a, out float b, out float c)
		{
			a = this.m_ControlladorDeCabelloGpu.colorDeGpuHair.hue.@base;
			b = this.m_ControlladorDeCabelloGpu.colorDeGpuHair.saturation.@base;
			c = this.m_ControlladorDeCabelloGpu.colorDeGpuHair.value.@base;
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x000510D8 File Offset: 0x0004F2D8
		void IHolderDeAlteradoresDeColorDeCabello.GetValoresDeAlteradorDeColorDeCabello(out float a, out float b, out float c)
		{
			if (this.alteradorDeColorDeCabello == null)
			{
				a = 0f;
				b = 0f;
				c = 0f;
				return;
			}
			a = this.alteradorDeColorDeCabello.a;
			b = this.alteradorDeColorDeCabello.b;
			c = this.alteradorDeColorDeCabello.c;
		}

		// Token: 0x04000C94 RID: 3220
		public bool usarColoreadorDeCabello = true;

		// Token: 0x04000C95 RID: 3221
		public AlteracionesDeMateralesDeCabelloGeneral.Rangos rangos = new AlteracionesDeMateralesDeCabelloGeneral.Rangos();

		// Token: 0x04000C96 RID: 3222
		private ControlladorDeCabelloGpu m_ControlladorDeCabelloGpu;

		// Token: 0x04000C97 RID: 3223
		private ModificadorDeFloat m_modificadorBrilloDeCabello;

		// Token: 0x04000C98 RID: 3224
		[NonSerialized]
		private AlteradorGenericoDirectoTripleConInicial alteradorDeColorDeCabello;

		// Token: 0x02000296 RID: 662
		[Serializable]
		public class Rangos
		{
			// Token: 0x04000C9A RID: 3226
			[Range(0f, 1f)]
			public float minLargoDeCerdas = 0.333f;

			// Token: 0x04000C9B RID: 3227
			public float minBrillo = 0.333f;

			// Token: 0x04000C9C RID: 3228
			public float maxBrillo = 1.5f;

			// Token: 0x04000C9D RID: 3229
			public AlteracionesDeMateralesDeCabelloGeneral.Rangos.RangosDecolor color = new AlteracionesDeMateralesDeCabelloGeneral.Rangos.RangosDecolor();

			// Token: 0x02000297 RID: 663
			[Serializable]
			public class RangosDecolor
			{
				// Token: 0x04000C9E RID: 3230
				[Range(-360f, 360f)]
				public float minHue;

				// Token: 0x04000C9F RID: 3231
				[Range(-360f, 360f)]
				public float maxHue = 360f;

				// Token: 0x04000CA0 RID: 3232
				[Range(0f, 100f)]
				public float minSaturation;

				// Token: 0x04000CA1 RID: 3233
				[Range(0f, 100f)]
				public float maxSaturation = 100f;

				// Token: 0x04000CA2 RID: 3234
				[Range(0f, 100f)]
				public float minBrightness;

				// Token: 0x04000CA3 RID: 3235
				[Range(0f, 100f)]
				public float maxBrightness = 80f;

				// Token: 0x04000CA4 RID: 3236
				[Range(0f, 100f)]
				public float minAlpha;

				// Token: 0x04000CA5 RID: 3237
				[Range(0f, 100f)]
				public float maxAlpha = 100f;
			}
		}
	}
}
