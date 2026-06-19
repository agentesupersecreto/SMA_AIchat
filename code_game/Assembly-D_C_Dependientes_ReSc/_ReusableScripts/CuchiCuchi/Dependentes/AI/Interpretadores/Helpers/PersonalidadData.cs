using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x020003A5 RID: 933
	[Serializable]
	public class PersonalidadData : IPersonalidadInterpretadorHelper, ITraitsInterpretadorHelper
	{
		// Token: 0x060017BA RID: 6074 RVA: 0x0006FD18 File Offset: 0x0006DF18
		public void Generate(HelperDeInterpretadorBase helper)
		{
			Personalidad personalidad = helper.personalidad;
			this.perverted = personalidad.perverticidadPorPersonalidad;
			this.honest = personalidad.honestidadPorPersonalidad;
			this.exhibitionist = personalidad.exhibicionismoPorPersonalidad;
			this.extroverted = personalidad.extroversionPorPersonalidad;
			this.optimistic = personalidad.optimismoPorPersonalidad;
			this.respectful = personalidad.respetoPorPersonalidad;
			this.shy = personalidad.timidezPorPersonalidad;
			this.dominant = personalidad.dominanciaPorPersonalidad;
			this.masoquista = personalidad.masoquismoPorPersonalidad;
			this.submissive = personalidad.sumicionPorPersonalidad;
			this.hybristophilia = personalidad.hibristofiliaPorPersonalidad;
			this.deseoGainIndirectoValorPolarizado = personalidad.GetTraitScore(TraitHumano.deseoGananciaPrimario).GetValorPolarizadoDeScore(personalidad.GetTraitScore(TraitHumano.deseoGananciaSegundario), personalidad.GetTraitScore(TraitHumano.deseoGananciaTerciario));
			this.corruptionByDesiresValorPolarizado = personalidad.GetTraitScore(TraitHumano.deseoGananciaPorEstimulosNegativos).GetValorPolarizadoDeScore();
			this.deseosResilianceValorPolarizado = personalidad.GetTraitScore(TraitHumano.deseosResiliance).GetValorPolarizadoDeScore();
			this.dispuestaAChuparValorPolarizado = personalidad.GetTraitScore(TraitHumano.leGustaChupar).GetValorPolarizadoDeScore();
			this.dispuestaARidingValorPolarizado = personalidad.GetTraitScore(TraitHumano.leGustaHacerEjercicio).GetValorPolarizadoDeScore();
			this.dispuestaARidingAnalValorPolarizado = personalidad.GetTraitScore(TraitHumano.leGustaHacerEjercicioNoNatural).GetValorPolarizadoDeScore();
			this.gustoPorPervertidosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorPervertidos).GetValorPolarizadoDeScore();
			this.gustoPorTimidosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorTimidos).GetValorPolarizadoDeScore();
			this.gustoPorPatanesValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorPatanes).GetValorPolarizadoDeScore();
			this.gustoPorIntelectualesValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorIntelectuales).GetValorPolarizadoDeScore();
			this.gustoPorConfiadosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorConfiados).GetValorPolarizadoDeScore();
			this.gustoPorAutistasValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorAutistas).GetValorPolarizadoDeScore();
			this.gustoPorDineroValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetValorPolarizadoDeScore();
			this.gustoPorHumildadValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorHumildad).GetValorPolarizadoDeScore();
			this.gustoPorGordosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorGordos).GetValorPolarizadoDeScore();
			this.gustoPorViejosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorViejos).GetValorPolarizadoDeScore();
			this.gustoPorDelgadosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorDelgados).GetValorPolarizadoDeScore();
			this.gustoPorMusculososValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorMusculosos).GetValorPolarizadoDeScore();
			this.gustoPorJovenesValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorJovenes).GetValorPolarizadoDeScore();
			this.gustoPorAltosValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorAltos).GetValorPolarizadoDeScore();
			this.gustoPorBuenaPresenciaValorPolarizado = personalidad.GetTraitScore(TraitHumano.gustoPorBuenaPresencia).GetValorPolarizadoDeScore();
			this.patienceValorPolarizado = personalidad.GetTraitScore(TraitHumano.patience).GetValorPolarizadoDeScore(personalidad.GetTraitScore(TraitHumano.deceptionPatience), personalidad.GetTraitScore(TraitHumano.painPatience), personalidad.GetTraitScore(TraitHumano.ragePatience), personalidad.GetTraitScore(TraitHumano.fearPatience));
			this.estandaresAltosValorPolarizado = 0;
			this.responsivenessValorPolarizado = personalidad.GetTraitScore(TraitHumano.responcibidad).GetValorPolarizadoDeScore(personalidad.GetTraitScore(TraitHumano.responcibidadNatural), personalidad.GetTraitScore(TraitHumano.responcibidadNoNatural), personalidad.GetTraitScore(TraitHumano.responcibidadPrivada), personalidad.GetTraitScore(TraitHumano.responcibidadPublica));
			this.expressivenessValorPolarizado = personalidad.GetTraitScore(TraitHumano.expresividad).GetValorPolarizadoDeScore(personalidad.GetTraitScore(TraitHumano.muecas), personalidad.GetTraitScore(TraitHumano.mimicas));
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x060017BB RID: 6075 RVA: 0x0006FFDF File Offset: 0x0006E1DF
		float IPersonalidadInterpretadorHelper.dominant
		{
			get
			{
				return this.dominant;
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x0006FFE7 File Offset: 0x0006E1E7
		float IPersonalidadInterpretadorHelper.masoquista
		{
			get
			{
				return this.masoquista;
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x060017BD RID: 6077 RVA: 0x0006FFEF File Offset: 0x0006E1EF
		float IPersonalidadInterpretadorHelper.submissive
		{
			get
			{
				return this.submissive;
			}
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x0006FFF7 File Offset: 0x0006E1F7
		float IPersonalidadInterpretadorHelper.hybristophilia
		{
			get
			{
				return this.hybristophilia;
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x060017BF RID: 6079 RVA: 0x0006FFFF File Offset: 0x0006E1FF
		float IPersonalidadInterpretadorHelper.perverted
		{
			get
			{
				return this.perverted;
			}
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x00070007 File Offset: 0x0006E207
		float IPersonalidadInterpretadorHelper.honest
		{
			get
			{
				return this.honest;
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x060017C1 RID: 6081 RVA: 0x0007000F File Offset: 0x0006E20F
		float IPersonalidadInterpretadorHelper.exhibitionist
		{
			get
			{
				return this.exhibitionist;
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x060017C2 RID: 6082 RVA: 0x00070017 File Offset: 0x0006E217
		float IPersonalidadInterpretadorHelper.extroverted
		{
			get
			{
				return this.extroverted;
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x060017C3 RID: 6083 RVA: 0x0007001F File Offset: 0x0006E21F
		float IPersonalidadInterpretadorHelper.optimistic
		{
			get
			{
				return this.optimistic;
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x060017C4 RID: 6084 RVA: 0x00070027 File Offset: 0x0006E227
		float IPersonalidadInterpretadorHelper.respectful
		{
			get
			{
				return this.respectful;
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x060017C5 RID: 6085 RVA: 0x0007002F File Offset: 0x0006E22F
		float IPersonalidadInterpretadorHelper.shy
		{
			get
			{
				return this.shy;
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x060017C6 RID: 6086 RVA: 0x00070037 File Offset: 0x0006E237
		int ITraitsInterpretadorHelper.deseoGainIndirectoValorPolarizado
		{
			get
			{
				return this.deseoGainIndirectoValorPolarizado;
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x0007003F File Offset: 0x0006E23F
		int ITraitsInterpretadorHelper.corruptionByDesiresValorPolarizado
		{
			get
			{
				return this.corruptionByDesiresValorPolarizado;
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x060017C8 RID: 6088 RVA: 0x00070047 File Offset: 0x0006E247
		int ITraitsInterpretadorHelper.deseosResilianceValorPolarizado
		{
			get
			{
				return this.deseosResilianceValorPolarizado;
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x0007004F File Offset: 0x0006E24F
		int ITraitsInterpretadorHelper.dispuestaAChuparValorPolarizado
		{
			get
			{
				return this.dispuestaAChuparValorPolarizado;
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x00070057 File Offset: 0x0006E257
		int ITraitsInterpretadorHelper.dispuestaARidingValorPolarizado
		{
			get
			{
				return this.dispuestaARidingValorPolarizado;
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x060017CB RID: 6091 RVA: 0x0007005F File Offset: 0x0006E25F
		int ITraitsInterpretadorHelper.dispuestaARidingAnalValorPolarizado
		{
			get
			{
				return this.dispuestaARidingAnalValorPolarizado;
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x060017CC RID: 6092 RVA: 0x00070067 File Offset: 0x0006E267
		int ITraitsInterpretadorHelper.gustoPorPervertidosValorPolarizado
		{
			get
			{
				return this.gustoPorPervertidosValorPolarizado;
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x060017CD RID: 6093 RVA: 0x0007006F File Offset: 0x0006E26F
		int ITraitsInterpretadorHelper.gustoPorTimidosValorPolarizado
		{
			get
			{
				return this.gustoPorTimidosValorPolarizado;
			}
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x060017CE RID: 6094 RVA: 0x00070077 File Offset: 0x0006E277
		int ITraitsInterpretadorHelper.gustoPorPatanesValorPolarizado
		{
			get
			{
				return this.gustoPorPatanesValorPolarizado;
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x060017CF RID: 6095 RVA: 0x0007007F File Offset: 0x0006E27F
		int ITraitsInterpretadorHelper.gustoPorIntelectualesValorPolarizado
		{
			get
			{
				return this.gustoPorIntelectualesValorPolarizado;
			}
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x060017D0 RID: 6096 RVA: 0x00070087 File Offset: 0x0006E287
		int ITraitsInterpretadorHelper.gustoPorConfiadosValorPolarizado
		{
			get
			{
				return this.gustoPorConfiadosValorPolarizado;
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x060017D1 RID: 6097 RVA: 0x0007008F File Offset: 0x0006E28F
		int ITraitsInterpretadorHelper.gustoPorAutistasValorPolarizado
		{
			get
			{
				return this.gustoPorAutistasValorPolarizado;
			}
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x060017D2 RID: 6098 RVA: 0x00070097 File Offset: 0x0006E297
		int ITraitsInterpretadorHelper.gustoPorDineroValorPolarizado
		{
			get
			{
				return this.gustoPorDineroValorPolarizado;
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x060017D3 RID: 6099 RVA: 0x0007009F File Offset: 0x0006E29F
		int ITraitsInterpretadorHelper.gustoPorHumildadValorPolarizado
		{
			get
			{
				return this.gustoPorHumildadValorPolarizado;
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000700A7 File Offset: 0x0006E2A7
		int ITraitsInterpretadorHelper.gustoPorGordosValorPolarizado
		{
			get
			{
				return this.gustoPorGordosValorPolarizado;
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x000700AF File Offset: 0x0006E2AF
		int ITraitsInterpretadorHelper.gustoPorViejosValorPolarizado
		{
			get
			{
				return this.gustoPorViejosValorPolarizado;
			}
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x060017D6 RID: 6102 RVA: 0x000700B7 File Offset: 0x0006E2B7
		int ITraitsInterpretadorHelper.gustoPorDelgadosValorPolarizado
		{
			get
			{
				return this.gustoPorDelgadosValorPolarizado;
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x060017D7 RID: 6103 RVA: 0x000700BF File Offset: 0x0006E2BF
		int ITraitsInterpretadorHelper.gustoPorMusculososValorPolarizado
		{
			get
			{
				return this.gustoPorMusculososValorPolarizado;
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000700C7 File Offset: 0x0006E2C7
		int ITraitsInterpretadorHelper.gustoPorJovenesValorPolarizado
		{
			get
			{
				return this.gustoPorJovenesValorPolarizado;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x060017D9 RID: 6105 RVA: 0x000700CF File Offset: 0x0006E2CF
		int ITraitsInterpretadorHelper.gustoPorAltosValorPolarizado
		{
			get
			{
				return this.gustoPorAltosValorPolarizado;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x060017DA RID: 6106 RVA: 0x000700D7 File Offset: 0x0006E2D7
		int ITraitsInterpretadorHelper.gustoPorBuenaPresenciaValorPolarizado
		{
			get
			{
				return this.gustoPorBuenaPresenciaValorPolarizado;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x060017DB RID: 6107 RVA: 0x000700DF File Offset: 0x0006E2DF
		int ITraitsInterpretadorHelper.patienceValorPolarizado
		{
			get
			{
				return this.patienceValorPolarizado;
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x060017DC RID: 6108 RVA: 0x000700E7 File Offset: 0x0006E2E7
		int ITraitsInterpretadorHelper.estandaresAltosValorPolarizado
		{
			get
			{
				return this.estandaresAltosValorPolarizado;
			}
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x060017DD RID: 6109 RVA: 0x000700EF File Offset: 0x0006E2EF
		int ITraitsInterpretadorHelper.responsivenessValorPolarizado
		{
			get
			{
				return this.responsivenessValorPolarizado;
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x060017DE RID: 6110 RVA: 0x000700F7 File Offset: 0x0006E2F7
		int ITraitsInterpretadorHelper.expressivenessValorPolarizado
		{
			get
			{
				return this.expressivenessValorPolarizado;
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x060017DF RID: 6111 RVA: 0x000700FF File Offset: 0x0006E2FF
		float IPersonalidadInterpretadorHelper.middle
		{
			get
			{
				return 0.3333333f;
			}
		}

		// Token: 0x04001175 RID: 4469
		public float perverted;

		// Token: 0x04001176 RID: 4470
		public float honest;

		// Token: 0x04001177 RID: 4471
		public float exhibitionist;

		// Token: 0x04001178 RID: 4472
		public float extroverted;

		// Token: 0x04001179 RID: 4473
		public float optimistic;

		// Token: 0x0400117A RID: 4474
		public float respectful;

		// Token: 0x0400117B RID: 4475
		public float shy;

		// Token: 0x0400117C RID: 4476
		public float dominant;

		// Token: 0x0400117D RID: 4477
		public float masoquista;

		// Token: 0x0400117E RID: 4478
		public float submissive;

		// Token: 0x0400117F RID: 4479
		public float hybristophilia;

		// Token: 0x04001180 RID: 4480
		public int deseoGainIndirectoValorPolarizado;

		// Token: 0x04001181 RID: 4481
		public int corruptionByDesiresValorPolarizado;

		// Token: 0x04001182 RID: 4482
		public int deseosResilianceValorPolarizado;

		// Token: 0x04001183 RID: 4483
		public int dispuestaAChuparValorPolarizado;

		// Token: 0x04001184 RID: 4484
		public int dispuestaARidingValorPolarizado;

		// Token: 0x04001185 RID: 4485
		public int dispuestaARidingAnalValorPolarizado;

		// Token: 0x04001186 RID: 4486
		public int gustoPorPervertidosValorPolarizado;

		// Token: 0x04001187 RID: 4487
		public int gustoPorTimidosValorPolarizado;

		// Token: 0x04001188 RID: 4488
		public int gustoPorPatanesValorPolarizado;

		// Token: 0x04001189 RID: 4489
		public int gustoPorIntelectualesValorPolarizado;

		// Token: 0x0400118A RID: 4490
		public int gustoPorConfiadosValorPolarizado;

		// Token: 0x0400118B RID: 4491
		public int gustoPorAutistasValorPolarizado;

		// Token: 0x0400118C RID: 4492
		public int gustoPorDineroValorPolarizado;

		// Token: 0x0400118D RID: 4493
		public int gustoPorHumildadValorPolarizado;

		// Token: 0x0400118E RID: 4494
		public int gustoPorGordosValorPolarizado;

		// Token: 0x0400118F RID: 4495
		public int gustoPorViejosValorPolarizado;

		// Token: 0x04001190 RID: 4496
		public int gustoPorDelgadosValorPolarizado;

		// Token: 0x04001191 RID: 4497
		public int gustoPorMusculososValorPolarizado;

		// Token: 0x04001192 RID: 4498
		public int gustoPorJovenesValorPolarizado;

		// Token: 0x04001193 RID: 4499
		public int gustoPorAltosValorPolarizado;

		// Token: 0x04001194 RID: 4500
		public int gustoPorBuenaPresenciaValorPolarizado;

		// Token: 0x04001195 RID: 4501
		public int patienceValorPolarizado;

		// Token: 0x04001196 RID: 4502
		public int estandaresAltosValorPolarizado;

		// Token: 0x04001197 RID: 4503
		public int responsivenessValorPolarizado;

		// Token: 0x04001198 RID: 4504
		public int expressivenessValorPolarizado;
	}
}
