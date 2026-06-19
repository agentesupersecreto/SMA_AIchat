using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x0200039F RID: 927
	[Serializable]
	public class FacialSkinData : SkinRangesDataBase, IFacialSkinRangesParaInterpretadores, IRangesParaInterpretadores, IFacialSkinInterpretadorHelper, IEyesInterpretadorHelper, ICejasInterpretadorHelper
	{
		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06001749 RID: 5961 RVA: 0x0006EC31 File Offset: 0x0006CE31
		protected override IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccion
		{
			get
			{
				return ParteDelCuerpoHumanoHelper.partesDeInteraccionRostro;
			}
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0006EC38 File Offset: 0x0006CE38
		public override void Generate(HelperDeInterpretadorBase helper)
		{
			base.Generate(helper);
			MapaSingletonDeFemaleMakeUp.MakeUpItem currentMakeUp = helper.controlladorDeFemaleMakeUp.currentMakeUp;
			this.currentEyeShadowWeigth = ((currentMakeUp != null) ? new float?(currentMakeUp.eyeShadowWeigth) : null).GetValueOrDefault();
			this.currentCheeksMakeUpWeigth = ((currentMakeUp != null) ? new float?(currentMakeUp.cheeksWeigth) : null).GetValueOrDefault();
			this.lipstickColor = helper.controlladorDeFemalePiel.colorDeLabiosSinModificaciones;
			this.irisColorL = helper.controlladorDeEyeAdvanceColores.colorDeOjoL.colorCalculadoAlphaNormalizado;
			this.irisColorR = helper.controlladorDeEyeAdvanceColores.colorDeOjoR.colorCalculadoAlphaNormalizado;
			this.cejasColor = helper.ControlladorDeFemaleCejasApariencia.colorDeCejasSinModificaciones;
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x0600174B RID: 5963 RVA: 0x0006ECF4 File Offset: 0x0006CEF4
		float IFacialSkinInterpretadorHelper.currentEyeShadowWeigth
		{
			get
			{
				return this.currentEyeShadowWeigth;
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x0600174C RID: 5964 RVA: 0x0006ECFC File Offset: 0x0006CEFC
		float IFacialSkinInterpretadorHelper.currentCheeksMakeUpWeigth
		{
			get
			{
				return this.currentCheeksMakeUpWeigth;
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x0600174D RID: 5965 RVA: 0x0006ED04 File Offset: 0x0006CF04
		Color IFacialSkinInterpretadorHelper.lipstickColorSinModificaciones
		{
			get
			{
				return this.lipstickColor;
			}
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x0600174E RID: 5966 RVA: 0x0006ED0C File Offset: 0x0006CF0C
		Color IEyesInterpretadorHelper.irisColorLSinModificaciones
		{
			get
			{
				return this.irisColorL;
			}
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x0600174F RID: 5967 RVA: 0x0006ED14 File Offset: 0x0006CF14
		Color IEyesInterpretadorHelper.irisColorRSinModificaciones
		{
			get
			{
				return this.irisColorR;
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06001750 RID: 5968 RVA: 0x0006ED1C File Offset: 0x0006CF1C
		Color ICejasInterpretadorHelper.colorDeCejasSinModificaciones
		{
			get
			{
				return this.cejasColor;
			}
		}

		// Token: 0x04001102 RID: 4354
		public float currentEyeShadowWeigth;

		// Token: 0x04001103 RID: 4355
		public float currentCheeksMakeUpWeigth;

		// Token: 0x04001104 RID: 4356
		public Color lipstickColor;

		// Token: 0x04001105 RID: 4357
		public Color irisColorL;

		// Token: 0x04001106 RID: 4358
		public Color irisColorR;

		// Token: 0x04001107 RID: 4359
		public Color cejasColor;
	}
}
