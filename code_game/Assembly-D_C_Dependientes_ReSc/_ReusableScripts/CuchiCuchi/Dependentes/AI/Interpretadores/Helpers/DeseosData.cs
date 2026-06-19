using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x0200039E RID: 926
	[Serializable]
	public class DeseosData : IDeseosInterpretadorHelper
	{
		// Token: 0x0600173C RID: 5948 RVA: 0x0006EB00 File Offset: 0x0006CD00
		public void Generate(HelperDeInterpretadorBase helper)
		{
			MapaDeDeseos deseos = helper.personalidad.currentPersonalidad.deseos;
			this.facialInitial = deseos.valoresIniciales.labios;
			this.crotchInitial = deseos.valoresIniciales.entrepierna;
			this.assInitial = deseos.valoresIniciales.trasero;
			this.facialGain = helper.deseos.GetGainDeLabios();
			this.crotchGain = helper.deseos.GetGainDeEntrepierna();
			this.assGain = helper.deseos.GetGainDeNalgas();
			this.deseoByVisual = deseos.initialSensibilidades.visuales;
			this.deseoByVerbal = deseos.initialSensibilidades.verbales;
			this.deseoByTouch = deseos.initialSensibilidades.tactiles;
			this.deseoByExposure = deseos.initialSensibilidades.exposicion;
			this.deseoByCoital = deseos.initialSensibilidades.coitales;
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x0006EBD9 File Offset: 0x0006CDD9
		float IDeseosInterpretadorHelper.facialInitial
		{
			get
			{
				return this.facialInitial;
			}
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x0006EBE1 File Offset: 0x0006CDE1
		float IDeseosInterpretadorHelper.crotchInitial
		{
			get
			{
				return this.crotchInitial;
			}
		}

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x0600173F RID: 5951 RVA: 0x0006EBE9 File Offset: 0x0006CDE9
		float IDeseosInterpretadorHelper.assInitial
		{
			get
			{
				return this.assInitial;
			}
		}

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06001740 RID: 5952 RVA: 0x0006EBF1 File Offset: 0x0006CDF1
		float IDeseosInterpretadorHelper.facialGain
		{
			get
			{
				return this.facialGain;
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06001741 RID: 5953 RVA: 0x0006EBF9 File Offset: 0x0006CDF9
		float IDeseosInterpretadorHelper.crotchGain
		{
			get
			{
				return this.crotchGain;
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06001742 RID: 5954 RVA: 0x0006EC01 File Offset: 0x0006CE01
		float IDeseosInterpretadorHelper.assGain
		{
			get
			{
				return this.assGain;
			}
		}

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06001743 RID: 5955 RVA: 0x0006EC09 File Offset: 0x0006CE09
		float IDeseosInterpretadorHelper.deseoByVisual
		{
			get
			{
				return this.deseoByVisual;
			}
		}

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06001744 RID: 5956 RVA: 0x0006EC11 File Offset: 0x0006CE11
		float IDeseosInterpretadorHelper.deseoByVerbal
		{
			get
			{
				return this.deseoByVerbal;
			}
		}

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06001745 RID: 5957 RVA: 0x0006EC19 File Offset: 0x0006CE19
		float IDeseosInterpretadorHelper.deseoByTouch
		{
			get
			{
				return this.deseoByTouch;
			}
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x0006EC21 File Offset: 0x0006CE21
		float IDeseosInterpretadorHelper.deseoByExposure
		{
			get
			{
				return this.deseoByExposure;
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06001747 RID: 5959 RVA: 0x0006EC29 File Offset: 0x0006CE29
		float IDeseosInterpretadorHelper.deseoByCoital
		{
			get
			{
				return this.deseoByCoital;
			}
		}

		// Token: 0x040010F7 RID: 4343
		public float facialInitial;

		// Token: 0x040010F8 RID: 4344
		public float crotchInitial;

		// Token: 0x040010F9 RID: 4345
		public float assInitial;

		// Token: 0x040010FA RID: 4346
		public float facialGain;

		// Token: 0x040010FB RID: 4347
		public float crotchGain;

		// Token: 0x040010FC RID: 4348
		public float assGain;

		// Token: 0x040010FD RID: 4349
		public float deseoByVisual;

		// Token: 0x040010FE RID: 4350
		public float deseoByVerbal;

		// Token: 0x040010FF RID: 4351
		public float deseoByTouch;

		// Token: 0x04001100 RID: 4352
		public float deseoByExposure;

		// Token: 0x04001101 RID: 4353
		public float deseoByCoital;
	}
}
