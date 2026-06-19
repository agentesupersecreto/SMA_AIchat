using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas
{
	// Token: 0x020003D1 RID: 977
	[CreateAssetMenu(fileName = "MapaDeDeseos", menuName = "Objetos/AI/MapaDeDeseos")]
	public class MapaDeDeseos : AplicableScriptable, ICloneable
	{
		// Token: 0x0600155D RID: 5469 RVA: 0x0005AA26 File Offset: 0x00058C26
		public object Clone()
		{
			return this.Clonar(true, false, false);
		}

		// Token: 0x0400112A RID: 4394
		public MapaDeDeseos.ValoresPorDefecto valoresIniciales = new MapaDeDeseos.ValoresPorDefecto();

		// Token: 0x0400112B RID: 4395
		public MapaDeDeseos.AumentosMod initialAumentoMods = new MapaDeDeseos.AumentosMod();

		// Token: 0x0400112C RID: 4396
		public MapaDeDeseos.SensibilidadesPorTiposDeInteraccion initialSensibilidades = new MapaDeDeseos.SensibilidadesPorTiposDeInteraccion();

		// Token: 0x0400112D RID: 4397
		public MapaDeDeseos.ValoresMaximosPorDefecto maximosIniciales = new MapaDeDeseos.ValoresMaximosPorDefecto();

		// Token: 0x020003D2 RID: 978
		[Serializable]
		public class SensibilidadesPorTiposDeInteraccion
		{
			// Token: 0x0400112E RID: 4398
			public float visuales = 1f;

			// Token: 0x0400112F RID: 4399
			public float verbales = 1.25f;

			// Token: 0x04001130 RID: 4400
			public float tactiles = 1.5f;

			// Token: 0x04001131 RID: 4401
			public float exposicion = 1.75f;

			// Token: 0x04001132 RID: 4402
			public float coitales = 2f;
		}

		// Token: 0x020003D3 RID: 979
		[Serializable]
		public class ValoresMaximosPorDefecto : MapaDeDeseos.ValoresFloat
		{
			// Token: 0x06001560 RID: 5472 RVA: 0x0005AAA4 File Offset: 0x00058CA4
			public ValoresMaximosPorDefecto()
			{
				this.entrepierna = 10f;
				this.trasero = 10f;
				this.senos = 10f;
				this.labios = 10f;
			}
		}

		// Token: 0x020003D4 RID: 980
		[Serializable]
		public class ValoresPorDefecto : MapaDeDeseos.ValoresFloat
		{
			// Token: 0x06001561 RID: 5473 RVA: 0x0005AAD8 File Offset: 0x00058CD8
			public ValoresPorDefecto()
			{
				this.entrepierna = 0f;
				this.trasero = 0f;
				this.senos = 0f;
				this.labios = 0f;
			}
		}

		// Token: 0x020003D5 RID: 981
		[Serializable]
		public class AumentosMod : MapaDeDeseos.ValoresFloat
		{
			// Token: 0x06001562 RID: 5474 RVA: 0x0005AB0C File Offset: 0x00058D0C
			public AumentosMod()
			{
				this.entrepierna = 1f;
				this.trasero = 1f;
				this.senos = 1f;
				this.labios = 1f;
			}
		}

		// Token: 0x020003D6 RID: 982
		[Serializable]
		public class ValoresFloat : MapaDeDeseos.Valores<float>
		{
			// Token: 0x06001563 RID: 5475 RVA: 0x0005AB40 File Offset: 0x00058D40
			public void ClampAll(float min, float max)
			{
				this.entrepierna = Mathf.Clamp(this.entrepierna, min, max);
				this.trasero = Mathf.Clamp(this.trasero, min, max);
				this.senos = Mathf.Clamp(this.senos, min, max);
				this.labios = Mathf.Clamp(this.labios, min, max);
			}
		}

		// Token: 0x020003D7 RID: 983
		[Serializable]
		public class Valores<T>
		{
			// Token: 0x04001133 RID: 4403
			public T entrepierna;

			// Token: 0x04001134 RID: 4404
			public T trasero;

			// Token: 0x04001135 RID: 4405
			public T senos;

			// Token: 0x04001136 RID: 4406
			public T labios;
		}
	}
}
