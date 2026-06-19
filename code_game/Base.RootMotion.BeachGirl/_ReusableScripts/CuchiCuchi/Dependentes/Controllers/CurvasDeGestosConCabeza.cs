using System;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020000CC RID: 204
	public class CurvasDeGestosConCabeza : Singleton<CurvasDeGestosConCabeza>
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x000247C8 File Offset: 0x000229C8
		protected override void InitData(bool esEditorTime)
		{
			this.m_data = new DiccionaryEnum<TipoDeGestoDeCabeza, CurvasDeGestosConCabeza.ConfigDeTipo>((TipoDeGestoDeCabeza i) => (int)i);
			foreach (CurvasDeGestosConCabeza.ConfigDeTipo configDeTipo in this.m_datos)
			{
				if (!this.m_data.ContainsKey(configDeTipo.tipo) && configDeTipo.EsValida())
				{
					this.m_data.Add(configDeTipo.tipo, configDeTipo);
				}
			}
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0002486C File Offset: 0x00022A6C
		public CurvasDeGestosConCabeza.ConfigDeTipo ObtenerDatosDeTipo(TipoDeGestoDeCabeza tipo)
		{
			CurvasDeGestosConCabeza.ConfigDeTipo configDeTipo;
			if (this.m_data.TryGetValue(tipo, out configDeTipo))
			{
				return configDeTipo;
			}
			return null;
		}

		// Token: 0x0400050D RID: 1293
		[CoolArrayItem(removable = false)]
		[SerializeField]
		private List<CurvasDeGestosConCabeza.ConfigDeTipo> m_datos = new List<CurvasDeGestosConCabeza.ConfigDeTipo>();

		// Token: 0x0400050E RID: 1294
		private DiccionaryEnum<TipoDeGestoDeCabeza, CurvasDeGestosConCabeza.ConfigDeTipo> m_data;

		// Token: 0x020001A6 RID: 422
		[Serializable]
		public class ConfigDeTipo
		{
			// Token: 0x06000C96 RID: 3222 RVA: 0x000389B4 File Offset: 0x00036BB4
			public bool EsValida()
			{
				if (this.loops <= 0 || this.duracionPorCiclo <= 0f)
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", es incorrecta.");
					return false;
				}
				if (!this.x.EsValida())
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", en curva: x, es incorrecta.");
					return false;
				}
				if (!this.y.EsValida())
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", en curva: y, es incorrecta.");
					return false;
				}
				if (!this.z.EsValida())
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", en curva: z, es incorrecta.");
					return false;
				}
				return true;
			}

			// Token: 0x04000967 RID: 2407
			public TipoDeGestoDeCabeza tipo;

			// Token: 0x04000968 RID: 2408
			public int loops = 1;

			// Token: 0x04000969 RID: 2409
			public float duracionPorCiclo = 1f;

			// Token: 0x0400096A RID: 2410
			[Range(0f, 1f)]
			public float middleToPause = 0.5f;

			// Token: 0x0400096B RID: 2411
			public CurvasDeGestosConCabeza.CurvaConfig x = new CurvasDeGestosConCabeza.CurvaConfig();

			// Token: 0x0400096C RID: 2412
			public CurvasDeGestosConCabeza.CurvaConfig y = new CurvasDeGestosConCabeza.CurvaConfig();

			// Token: 0x0400096D RID: 2413
			public CurvasDeGestosConCabeza.CurvaConfig z = new CurvasDeGestosConCabeza.CurvaConfig();
		}

		// Token: 0x020001A7 RID: 423
		[Serializable]
		public class CurvaConfig
		{
			// Token: 0x06000C98 RID: 3224 RVA: 0x00038AF0 File Offset: 0x00036CF0
			public bool EsValida()
			{
				if (this.curva == null)
				{
					return false;
				}
				if (this.curva.length == 0)
				{
					return true;
				}
				if (this.curva.length == 1)
				{
					return false;
				}
				float num = this.curva.Duracion();
				if (!ExtendedMonoBehaviour.AlmostEqual(1f, num, 0.001f))
				{
					return false;
				}
				float num2 = this.curva.MaxAmplitudAbs();
				return ExtendedMonoBehaviour.AlmostEqual(1f, num2, 0.001f) && this.amplitudEnGrados > 0f;
			}

			// Token: 0x0400096E RID: 2414
			public float amplitudEnGrados;

			// Token: 0x0400096F RID: 2415
			public bool puedeInvertirse;

			// Token: 0x04000970 RID: 2416
			public AnimationCurve curva;
		}
	}
}
