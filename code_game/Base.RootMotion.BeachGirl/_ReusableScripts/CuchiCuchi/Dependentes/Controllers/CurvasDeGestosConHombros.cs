using System;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020000CD RID: 205
	public class CurvasDeGestosConHombros : Singleton<CurvasDeGestosConHombros>
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x000248A0 File Offset: 0x00022AA0
		protected override void InitData(bool esEditorTime)
		{
			this.m_data = new DiccionaryEnum<TipoDeGestoDeHombro, CurvasDeGestosConHombros.ConfigDeTipo>((TipoDeGestoDeHombro i) => (int)i);
			foreach (CurvasDeGestosConHombros.ConfigDeTipo configDeTipo in this.m_datos)
			{
				if (!this.m_data.ContainsKey(configDeTipo.tipo) && configDeTipo.EsValida())
				{
					this.m_data.Add(configDeTipo.tipo, configDeTipo);
				}
			}
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00024944 File Offset: 0x00022B44
		public CurvasDeGestosConHombros.ConfigDeTipo ObtenerDatosDeTipo(TipoDeGestoDeHombro tipo)
		{
			CurvasDeGestosConHombros.ConfigDeTipo configDeTipo;
			if (this.m_data.TryGetValue(tipo, out configDeTipo))
			{
				return configDeTipo;
			}
			return null;
		}

		// Token: 0x0400050F RID: 1295
		[CoolArrayItem(removable = false)]
		[SerializeField]
		private List<CurvasDeGestosConHombros.ConfigDeTipo> m_datos = new List<CurvasDeGestosConHombros.ConfigDeTipo>();

		// Token: 0x04000510 RID: 1296
		private DiccionaryEnum<TipoDeGestoDeHombro, CurvasDeGestosConHombros.ConfigDeTipo> m_data;

		// Token: 0x020001A9 RID: 425
		[Serializable]
		public class ConfigDeTipo
		{
			// Token: 0x06000C9D RID: 3229 RVA: 0x00038B94 File Offset: 0x00036D94
			public bool EsValida()
			{
				if (this.loops <= 0 || this.duracionPorCiclo <= 0f)
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", es incorrecta.");
					return false;
				}
				if (!this.x.EsValida())
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", en curvas: x, es incorrecta.");
					return false;
				}
				if (!this.y.EsValida())
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", en curvas: y, es incorrecta.");
					return false;
				}
				if (!this.z.EsValida())
				{
					Debug.LogError("Config De Gesto De tipo: " + this.tipo.ToString() + ", en curvas: z, es incorrecta.");
					return false;
				}
				return true;
			}

			// Token: 0x04000973 RID: 2419
			public TipoDeGestoDeHombro tipo;

			// Token: 0x04000974 RID: 2420
			public int loops = 1;

			// Token: 0x04000975 RID: 2421
			public float duracionPorCiclo = 1f;

			// Token: 0x04000976 RID: 2422
			[Range(0f, 1f)]
			public float middleToPause = 0.5f;

			// Token: 0x04000977 RID: 2423
			public CurvasDeGestosConHombros.CurvaParConfig x = new CurvasDeGestosConHombros.CurvaParConfig();

			// Token: 0x04000978 RID: 2424
			public CurvasDeGestosConHombros.CurvaParConfig y = new CurvasDeGestosConHombros.CurvaParConfig();

			// Token: 0x04000979 RID: 2425
			public CurvasDeGestosConHombros.CurvaParConfig z = new CurvasDeGestosConHombros.CurvaParConfig();
		}

		// Token: 0x020001AA RID: 426
		[Serializable]
		public class CurvaParConfig
		{
			// Token: 0x06000C9F RID: 3231 RVA: 0x00038CCD File Offset: 0x00036ECD
			public bool EsValida()
			{
				return this.r.EsValida() || this.l.EsValida();
			}

			// Token: 0x0400097A RID: 2426
			public bool puedeInvertirseLados;

			// Token: 0x0400097B RID: 2427
			public bool puedeInvertirseAmplitud;

			// Token: 0x0400097C RID: 2428
			public CurvasDeGestosConHombros.CurvaConfig r = new CurvasDeGestosConHombros.CurvaConfig();

			// Token: 0x0400097D RID: 2429
			public CurvasDeGestosConHombros.CurvaConfig l = new CurvasDeGestosConHombros.CurvaConfig();
		}

		// Token: 0x020001AB RID: 427
		[Serializable]
		public class CurvaConfig
		{
			// Token: 0x06000CA1 RID: 3233 RVA: 0x00038D08 File Offset: 0x00036F08
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

			// Token: 0x0400097E RID: 2430
			public float amplitudEnGrados;

			// Token: 0x0400097F RID: 2431
			public bool mirror;

			// Token: 0x04000980 RID: 2432
			public AnimationCurve curva;
		}
	}
}
