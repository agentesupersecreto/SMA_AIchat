using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000330 RID: 816
	public enum TraitHumano
	{
		// Token: 0x04000E0F RID: 3599
		none,
		// Token: 0x04000E10 RID: 3600
		[Obsolete]
		bodyEndurance = 2,
		// Token: 0x04000E11 RID: 3601
		vagTightness,
		// Token: 0x04000E12 RID: 3602
		anusTightness,
		// Token: 0x04000E13 RID: 3603
		bocaTightness = 93,
		// Token: 0x04000E14 RID: 3604
		[Obsolete("reemplazado por personalidad.timides", true)]
		verguenza = 5,
		// Token: 0x04000E15 RID: 3605
		curiosidad,
		// Token: 0x04000E16 RID: 3606
		fijacion,
		// Token: 0x04000E17 RID: 3607
		abstraccion,
		// Token: 0x04000E18 RID: 3608
		responcibidad,
		// Token: 0x04000E19 RID: 3609
		responcibidadPublica,
		// Token: 0x04000E1A RID: 3610
		responcibidadPrivada,
		// Token: 0x04000E1B RID: 3611
		responcibidadNatural,
		// Token: 0x04000E1C RID: 3612
		responcibidadNoNatural,
		// Token: 0x04000E1D RID: 3613
		[Obsolete("reemplazado por personalidad.extroversion", true)]
		verbosidad,
		// Token: 0x04000E1E RID: 3614
		[Obsolete("reemplazado por personalidad.extroversion", true)]
		verbosidadPublica,
		// Token: 0x04000E1F RID: 3615
		[Obsolete("reemplazado por personalidad.extroversion vs exibicionismo", true)]
		verbosidadPrivada,
		// Token: 0x04000E20 RID: 3616
		[Obsolete("reemplazado por personalidad.extroversion vs pervercidad low", true)]
		verbosidadNatural,
		// Token: 0x04000E21 RID: 3617
		[Obsolete("reemplazado por personalidad.extroversion vs pervercidad hi", true)]
		verbosidadNoNatural,
		// Token: 0x04000E22 RID: 3618
		expresividad = 20,
		// Token: 0x04000E23 RID: 3619
		muecas = 19,
		// Token: 0x04000E24 RID: 3620
		mimicas = 97,
		// Token: 0x04000E25 RID: 3621
		gustoPorNormales = 21,
		// Token: 0x04000E26 RID: 3622
		gustoPorPervertidos = 26,
		// Token: 0x04000E27 RID: 3623
		gustoPorTimidos = 22,
		// Token: 0x04000E28 RID: 3624
		gustoPorPatanes = 24,
		// Token: 0x04000E29 RID: 3625
		gustoPorIntelectuales = 23,
		// Token: 0x04000E2A RID: 3626
		gustoPorConfiados = 25,
		// Token: 0x04000E2B RID: 3627
		gustoPorAutistas = 27,
		// Token: 0x04000E2C RID: 3628
		gustoPorDinero,
		// Token: 0x04000E2D RID: 3629
		gustoPorHumildad,
		// Token: 0x04000E2E RID: 3630
		[Obsolete("reemplazado por personalidad.timidez", true)]
		pudor,
		// Token: 0x04000E2F RID: 3631
		humedadFacial,
		// Token: 0x04000E30 RID: 3632
		humedadCorporal,
		// Token: 0x04000E31 RID: 3633
		humedadVaginal,
		// Token: 0x04000E32 RID: 3634
		humedadAnal,
		// Token: 0x04000E33 RID: 3635
		humedadVelocidad,
		// Token: 0x04000E34 RID: 3636
		humedadPower,
		// Token: 0x04000E35 RID: 3637
		[Obsolete("reemplazado por personalidad.extroversion vs amabilidad", true)]
		verbosidadPositiva,
		// Token: 0x04000E36 RID: 3638
		[Obsolete("reemplazado por personalidad.extroversion vs irespeto", true)]
		verbosidadNegativa,
		// Token: 0x04000E37 RID: 3639
		sudorGrasoso,
		// Token: 0x04000E38 RID: 3640
		mocosidad,
		// Token: 0x04000E39 RID: 3641
		[Obsolete("reemplazado por personalidad traits1", true)]
		facilidadParaDesHielar,
		// Token: 0x04000E3A RID: 3642
		gustoPorGordos,
		// Token: 0x04000E3B RID: 3643
		gustoPorViejos,
		// Token: 0x04000E3C RID: 3644
		gustoPorDelgados,
		// Token: 0x04000E3D RID: 3645
		gustoPorMusculosos,
		// Token: 0x04000E3E RID: 3646
		gustoPorJovenes,
		// Token: 0x04000E3F RID: 3647
		gustoPorAltos = 104,
		// Token: 0x04000E40 RID: 3648
		gustoPorBuenaPresencia,
		// Token: 0x04000E41 RID: 3649
		gustoPorMujeres,
		// Token: 0x04000E42 RID: 3650
		vagTightnessEndurance = 47,
		// Token: 0x04000E43 RID: 3651
		anusTightnessEndurance,
		// Token: 0x04000E44 RID: 3652
		bocaTightnessEndurance = 94,
		// Token: 0x04000E45 RID: 3653
		vagEndurance = 49,
		// Token: 0x04000E46 RID: 3654
		anusEndurance,
		// Token: 0x04000E47 RID: 3655
		bocaEndurance = 95,
		// Token: 0x04000E48 RID: 3656
		bodyHolesVirtualEndurance,
		// Token: 0x04000E49 RID: 3657
		estadoFisico = 51,
		// Token: 0x04000E4A RID: 3658
		estadoFisicoEmociones,
		// Token: 0x04000E4B RID: 3659
		[Obsolete("reemplazado por personalidad traits1", true)]
		erogenidad = 1,
		// Token: 0x04000E4C RID: 3660
		[Obsolete("reemplazado por personalidad traits1", true)]
		rabiosa = 54,
		// Token: 0x04000E4D RID: 3661
		[Obsolete("reemplazado por personalidad traits1", true)]
		sensibilidadV2,
		// Token: 0x04000E4E RID: 3662
		[Obsolete("reemplazado por personalidad traits1", true)]
		estandaresAltos,
		// Token: 0x04000E4F RID: 3663
		eyesResequedad,
		// Token: 0x04000E50 RID: 3664
		patience,
		// Token: 0x04000E51 RID: 3665
		ragePatience,
		// Token: 0x04000E52 RID: 3666
		painPatience,
		// Token: 0x04000E53 RID: 3667
		deceptionPatience,
		// Token: 0x04000E54 RID: 3668
		fearPatience = 110,
		// Token: 0x04000E55 RID: 3669
		maxEmocionValueEndurance = 62,
		// Token: 0x04000E56 RID: 3670
		maxRageValueEndurance,
		// Token: 0x04000E57 RID: 3671
		maxPainValueEndurance,
		// Token: 0x04000E58 RID: 3672
		maxDeceptionValueEndurance,
		// Token: 0x04000E59 RID: 3673
		maxPlacerValueEndurance,
		// Token: 0x04000E5A RID: 3674
		maxFearValueEndurance = 109,
		// Token: 0x04000E5B RID: 3675
		[Obsolete("reemplazado por personalidad.sumision", true)]
		sumisionVerval = 67,
		// Token: 0x04000E5C RID: 3676
		orgasmoDuracion,
		// Token: 0x04000E5D RID: 3677
		orgasmoContraciones,
		// Token: 0x04000E5E RID: 3678
		orgasmoReaccionDeAno,
		// Token: 0x04000E5F RID: 3679
		orgasmoReaccionDeVagina,
		// Token: 0x04000E60 RID: 3680
		orgasmoReaccionDeHips,
		// Token: 0x04000E61 RID: 3681
		[Obsolete("los orgasmos siempre usaran boca")]
		orgasmoReaccionDeGestoBoca,
		// Token: 0x04000E62 RID: 3682
		orgasmoReaccionDeGestoOjos,
		// Token: 0x04000E63 RID: 3683
		orgasmoReaccionDeGestoRostro,
		// Token: 0x04000E64 RID: 3684
		orgasmoReaccionDeGestoHombros = 78,
		// Token: 0x04000E65 RID: 3685
		orgasmoReaccionDeGestoCabeza,
		// Token: 0x04000E66 RID: 3686
		reaccionDeArousal = 77,
		// Token: 0x04000E67 RID: 3687
		[Obsolete("reemplazado por personalidad traits1", true)]
		orgasmoReaccionDeArousal = 76,
		// Token: 0x04000E68 RID: 3688
		orgasmoAumentoTempDeArousal = 80,
		// Token: 0x04000E69 RID: 3689
		orgasmoRecuperacionDeArousal,
		// Token: 0x04000E6A RID: 3690
		[LabelLocalizado("modeling", "US")]
		gustoPorModelaje,
		// Token: 0x04000E6B RID: 3691
		[LabelLocalizado("bikini Modeling", "US")]
		gustoPorModelajeUnderwear = 108,
		// Token: 0x04000E6C RID: 3692
		[LabelLocalizado("erotic Modeling", "US")]
		gustoPorModelajeHerotico = 83,
		// Token: 0x04000E6D RID: 3693
		[LabelLocalizado("companion Services (Non-Sexual)", "US")]
		gustoPorTratoDeClientes,
		// Token: 0x04000E6E RID: 3694
		[LabelLocalizado("girlfriend Services (Softcore)", "US")]
		gustoPorTratoEspecialDeClientes,
		// Token: 0x04000E6F RID: 3695
		[LabelLocalizado("escort Services (Explicit)", "US")]
		gustoPorTratoExplicitoDeClientes,
		// Token: 0x04000E70 RID: 3696
		deseoGananciaPrimario,
		// Token: 0x04000E71 RID: 3697
		deseoGananciaSegundario,
		// Token: 0x04000E72 RID: 3698
		deseoGananciaTerciario,
		// Token: 0x04000E73 RID: 3699
		deseoGananciaPorEstimulosPositivos,
		// Token: 0x04000E74 RID: 3700
		deseoGananciaPorEstimulosNegativos,
		// Token: 0x04000E75 RID: 3701
		deseosResiliance = 103,
		// Token: 0x04000E76 RID: 3702
		leGustaChupar = 92,
		// Token: 0x04000E77 RID: 3703
		leGustaHacerEjercicio = 101,
		// Token: 0x04000E78 RID: 3704
		leGustaHacerEjercicioNoNatural,
		// Token: 0x04000E79 RID: 3705
		aguanteAlDolorPorPenetracion = 98,
		// Token: 0x04000E7A RID: 3706
		chuparIntencidad,
		// Token: 0x04000E7B RID: 3707
		gaggingIntencidad,
		// Token: 0x04000E7C RID: 3708
		pobreza = 107,
		// Token: 0x04000E7D RID: 3709
		inteligencia = 111
	}
}
