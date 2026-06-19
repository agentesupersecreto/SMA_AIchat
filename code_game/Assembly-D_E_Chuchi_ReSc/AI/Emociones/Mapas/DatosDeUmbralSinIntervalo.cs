using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000435 RID: 1077
	[CreateAssetMenu(fileName = "DatosDeUmbralSinIntervalo", menuName = "Objetos/Emociones/DatosDeUmbralSinIntervalo")]
	public class DatosDeUmbralSinIntervalo : AplicableScriptable, IDatosDeUmbral
	{
		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x06001812 RID: 6162 RVA: 0x0006081B File Offset: 0x0005EA1B
		// (set) Token: 0x06001813 RID: 6163 RVA: 0x00003B39 File Offset: 0x00001D39
		RangeValueV2 IDatosDeUmbral.intervaloDeGeneracion
		{
			get
			{
				return RangeValueV2.Default;
			}
			set
			{
			}
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06001814 RID: 6164 RVA: 0x00060822 File Offset: 0x0005EA22
		// (set) Token: 0x06001815 RID: 6165 RVA: 0x0006082A File Offset: 0x0005EA2A
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

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06001816 RID: 6166 RVA: 0x00060833 File Offset: 0x0005EA33
		// (set) Token: 0x06001817 RID: 6167 RVA: 0x0006083B File Offset: 0x0005EA3B
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

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06001818 RID: 6168 RVA: 0x00060844 File Offset: 0x0005EA44
		// (set) Token: 0x06001819 RID: 6169 RVA: 0x0006084C File Offset: 0x0005EA4C
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

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x0600181A RID: 6170 RVA: 0x00060855 File Offset: 0x0005EA55
		// (set) Token: 0x0600181B RID: 6171 RVA: 0x0006085D File Offset: 0x0005EA5D
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

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x0600181C RID: 6172 RVA: 0x00060866 File Offset: 0x0005EA66
		// (set) Token: 0x0600181D RID: 6173 RVA: 0x0006086E File Offset: 0x0005EA6E
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

		// Token: 0x0400123D RID: 4669
		[Tooltip("por cada segundo")]
		public ValorModificable estimulacionQueGenera;

		// Token: 0x0400123E RID: 4670
		public SpotBonuses spotBonuses = SpotBonuses.@default;

		// Token: 0x0400123F RID: 4671
		public float promedioMod = 0.5f;

		// Token: 0x04001240 RID: 4672
		public float modPorEncima;

		// Token: 0x04001241 RID: 4673
		public float modPorDebajo;
	}
}
