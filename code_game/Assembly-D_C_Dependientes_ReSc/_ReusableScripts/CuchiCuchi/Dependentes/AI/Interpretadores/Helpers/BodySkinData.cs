using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x0200039D RID: 925
	[Serializable]
	public class BodySkinData : SkinRangesDataBase, IBodySkinRangesParaInterpretadores, IRangesParaInterpretadores, IBodySkinInterpretadorHelper
	{
		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06001735 RID: 5941 RVA: 0x0006E9D3 File Offset: 0x0006CBD3
		protected override IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccion
		{
			get
			{
				return ParteDelCuerpoHumanoHelper.partesDeInteraccionCuerpoFemenino;
			}
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x0006E9DC File Offset: 0x0006CBDC
		public override void Generate(HelperDeInterpretadorBase helper)
		{
			base.Generate(helper);
			MapaDeConjuntosDeMaterialesDePielFemeninos.Conjunto currentConjunto = helper.controlladorDeFemalePiel.currentConjunto;
			this.currentSkinTanWeigth = ((currentConjunto != null) ? new float?(currentConjunto.tanWeigth) : null).GetValueOrDefault() * 0.8f + ((currentConjunto != null) ? new float?(currentConjunto.varWeigth) : null).GetValueOrDefault() * 0.2f;
			this.currentSkinUniformity = 1f - (((currentConjunto != null) ? new float?(currentConjunto.qualityWeigth) : null).GetValueOrDefault() * 0.75f + ((currentConjunto != null) ? new float?(currentConjunto.varWeigth) : null).GetValueOrDefault() * 0.25f);
			this.fingerNails = helper.controlladorDeFemalePiel.colorDeFingerNails.colorCalculadoAlphaNormalizado;
			this.toeNails = helper.controlladorDeFemalePiel.colorDeToeNails.colorCalculadoAlphaNormalizado;
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06001737 RID: 5943 RVA: 0x0006EAD8 File Offset: 0x0006CCD8
		float IBodySkinInterpretadorHelper.currentSkinTanWeigth
		{
			get
			{
				return this.currentSkinTanWeigth;
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06001738 RID: 5944 RVA: 0x0006EAE0 File Offset: 0x0006CCE0
		float IBodySkinInterpretadorHelper.currentSkinUniformity
		{
			get
			{
				return this.currentSkinUniformity;
			}
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06001739 RID: 5945 RVA: 0x0006EAE8 File Offset: 0x0006CCE8
		Color IBodySkinInterpretadorHelper.fingerNailsSinModificaciones
		{
			get
			{
				return this.fingerNails;
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x0600173A RID: 5946 RVA: 0x0006EAF0 File Offset: 0x0006CCF0
		Color IBodySkinInterpretadorHelper.toeNailsSinModificaciones
		{
			get
			{
				return this.toeNails;
			}
		}

		// Token: 0x040010F3 RID: 4339
		[Header("Body Skin")]
		public float currentSkinTanWeigth;

		// Token: 0x040010F4 RID: 4340
		public float currentSkinUniformity;

		// Token: 0x040010F5 RID: 4341
		public Color fingerNails;

		// Token: 0x040010F6 RID: 4342
		public Color toeNails;
	}
}
