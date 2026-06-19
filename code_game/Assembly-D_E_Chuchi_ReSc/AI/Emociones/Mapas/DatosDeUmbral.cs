using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000433 RID: 1075
	[CreateAssetMenu(fileName = "DatosDeUmbral", menuName = "Objetos/Emociones/DatosDeUmbral")]
	public class DatosDeUmbral : AplicableScriptable, IDatosDeUmbral
	{
		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x060017F9 RID: 6137 RVA: 0x00060797 File Offset: 0x0005E997
		// (set) Token: 0x060017FA RID: 6138 RVA: 0x0006079F File Offset: 0x0005E99F
		RangeValueV2 IDatosDeUmbral.intervaloDeGeneracion
		{
			get
			{
				return this.intervaloDeGeneracion;
			}
			set
			{
				this.intervaloDeGeneracion = value;
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x060017FB RID: 6139 RVA: 0x000607A8 File Offset: 0x0005E9A8
		// (set) Token: 0x060017FC RID: 6140 RVA: 0x000607B0 File Offset: 0x0005E9B0
		ValorModificable IDatosDeUmbral.estimulacionQueGenera
		{
			get
			{
				return this.estimulacionQueGenera;
			}
			set
			{
				this.estimulacionQueGenera = value;
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x060017FD RID: 6141 RVA: 0x000607B9 File Offset: 0x0005E9B9
		// (set) Token: 0x060017FE RID: 6142 RVA: 0x000607C1 File Offset: 0x0005E9C1
		SpotBonuses IDatosDeUmbral.spotBonuses
		{
			get
			{
				return this.spotBonuses;
			}
			set
			{
				this.spotBonuses = value;
			}
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x060017FF RID: 6143 RVA: 0x000607CA File Offset: 0x0005E9CA
		// (set) Token: 0x06001800 RID: 6144 RVA: 0x000607D2 File Offset: 0x0005E9D2
		float IDatosDeUmbral.promedioMod
		{
			get
			{
				return this.promedioMod;
			}
			set
			{
				this.promedioMod = value;
			}
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06001801 RID: 6145 RVA: 0x000607DB File Offset: 0x0005E9DB
		// (set) Token: 0x06001802 RID: 6146 RVA: 0x000607E3 File Offset: 0x0005E9E3
		float IDatosDeUmbral.modPorEncima
		{
			get
			{
				return this.modPorEncima;
			}
			set
			{
				this.modPorEncima = value;
			}
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06001803 RID: 6147 RVA: 0x000607EC File Offset: 0x0005E9EC
		// (set) Token: 0x06001804 RID: 6148 RVA: 0x000607F4 File Offset: 0x0005E9F4
		float IDatosDeUmbral.modPorDebajo
		{
			get
			{
				return this.modPorDebajo;
			}
			set
			{
				this.modPorDebajo = value;
			}
		}

		// Token: 0x04001237 RID: 4663
		public RangeValueV2 intervaloDeGeneracion;

		// Token: 0x04001238 RID: 4664
		[Tooltip("por cada segundo")]
		public ValorModificable estimulacionQueGenera;

		// Token: 0x04001239 RID: 4665
		public SpotBonuses spotBonuses = SpotBonuses.@default;

		// Token: 0x0400123A RID: 4666
		public float promedioMod = 0.5f;

		// Token: 0x0400123B RID: 4667
		public float modPorEncima;

		// Token: 0x0400123C RID: 4668
		public float modPorDebajo;
	}
}
