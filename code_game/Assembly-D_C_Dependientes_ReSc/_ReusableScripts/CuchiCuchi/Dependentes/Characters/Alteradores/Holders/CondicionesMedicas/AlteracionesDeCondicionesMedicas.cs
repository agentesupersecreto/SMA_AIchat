using System;
using System.Collections.Generic;
using Assets.Base.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores.Pieles;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.CondicionesMedicas
{
	// Token: 0x0200029D RID: 669
	public class AlteracionesDeCondicionesMedicas : HolderPentaDeAlteradores<AlteradorGenericoDirectoDual, AlteradorGenericoDirectoQuadruple, AlteradorGenericoDirectoQuintuple, AlteradorGenericoDirectoSextuple, AlteradorGenericoDirectoSeptuple>
	{
		// Token: 0x06001161 RID: 4449 RVA: 0x00051CA6 File Offset: 0x0004FEA6
		public static float GetSickessLvl(float sickesWeight)
		{
			return Mathf.InverseLerp(0.75f, 1f, sickesWeight).OutPow(6f);
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06001162 RID: 4450 RVA: 0x00050212 File Offset: 0x0004E412
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.onAI3;
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06001163 RID: 4451 RVA: 0x00051CC2 File Offset: 0x0004FEC2
		protected override GlobalUpdater.UpdateType? updateTypeB
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.updateType);
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06001164 RID: 4452 RVA: 0x00051CC2 File Offset: 0x0004FEC2
		protected override GlobalUpdater.UpdateType? updateTypeC
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.updateType);
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06001165 RID: 4453 RVA: 0x00051CC2 File Offset: 0x0004FEC2
		protected override GlobalUpdater.UpdateType? updateTypeE
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.updateType);
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x00051CC2 File Offset: 0x0004FEC2
		protected override GlobalUpdater.UpdateType? updateTypeD
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.updateType);
			}
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x00051CD0 File Offset: 0x0004FED0
		protected override void InstanciarAlteradores(List<AlteradorGenericoDirectoDual> resultado)
		{
			TemperaturaCorporal componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter != null)
			{
				AlteracionesDeCondicionesMedicas.<>c__DisplayClass13_0 CS$<>8__locals1 = new AlteracionesDeCondicionesMedicas.<>c__DisplayClass13_0();
				CS$<>8__locals1.fiebreAdding = componentEnCharacter.fiebreWeightModificable.ObtenerModificadorNotNull(this);
				AlteradorGenericoDirectoDual alteradorGenericoDirectoDual = new AlteradorGenericoDirectoDual(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Fiebre, this, new AlteradorGenericoDirectoDual.Setter(CS$<>8__locals1.<InstanciarAlteradores>g__Setter|0), 0f, 1f, 0f, 1f);
				resultado.Add(alteradorGenericoDirectoDual);
			}
			ControlladorDeIntestinesPiel componentEnCharacter2 = this.GetComponentEnCharacter(false);
			if (componentEnCharacter != null)
			{
				AlteracionesDeCondicionesMedicas.<>c__DisplayClass13_1 CS$<>8__locals2 = new AlteracionesDeCondicionesMedicas.<>c__DisplayClass13_1();
				CS$<>8__locals2.n3 = componentEnCharacter2.veinsVisibility3.ObtenerModificadorNotNull(this);
				CS$<>8__locals2.n4 = componentEnCharacter2.veinsVisibility4.ObtenerModificadorNotNull(this);
				CS$<>8__locals2.s3 = componentEnCharacter2.veinsScale3.ObtenerModificadorNotNull(this);
				CS$<>8__locals2.s4 = componentEnCharacter2.veinsScale4.ObtenerModificadorNotNull(this);
				AlteradorGenericoDirectoDual alteradorGenericoDirectoDual2 = new AlteradorGenericoDirectoDual(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_MucosalVascularProminence, this, new AlteradorGenericoDirectoDual.Setter(CS$<>8__locals2.<InstanciarAlteradores>g__Setter|1), 0f, 1f, 0f, 1f);
				resultado.Add(alteradorGenericoDirectoDual2);
			}
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x00051DD8 File Offset: 0x0004FFD8
		protected override void InstanciarAlteradoresB(List<AlteradorGenericoDirectoQuadruple> resultado)
		{
			ControlladorDeShapeDeAmigdalas componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Amigdalitis, componentEnCharacter, this, resultado, new string[] { "FACE_AmigInflaA", "FACE_AmigInflaB", "FACE_AmigInflaC" });
			}
			ControlladorDeShapeDeInternalOrgans componentEnCharacter2 = this.GetComponentEnCharacter(false);
			if (componentEnCharacter2 != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Constripacion, componentEnCharacter2, this, resultado, new string[] { "BODY_ConstipationA", "BODY_ConstipationB", "BODY_ConstipationC" });
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_ColonIrritable, componentEnCharacter2, this, resultado, new string[] { "BODY_ColonIrritadoA", "BODY_ColonIrritadoB", "BODY_ColonIrritadoC" });
			}
			ControlladorDeShapeDeAnusInternals componentEnCharacter3 = this.GetComponentEnCharacter(false);
			if (componentEnCharacter3 != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Hemorroides, componentEnCharacter3, this, resultado, new string[] { "Hemo1", "Hemo2", "Hemo3" });
			}
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x00051EC4 File Offset: 0x000500C4
		protected override void InstanciarAlteradoresC(List<AlteradorGenericoDirectoQuintuple> resultado)
		{
			ControlladorDeShapeDeInternalOrgans componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_FibrocysticBreast, componentEnCharacter, this, resultado, new string[] { "BODY_BreastQuisteA", "BODY_BreastQuisteB", "BODY_BreastQuisteC", "BODY_BreastQuisteD" });
			}
			ControlladorDeShapeDeVagInternals componentEnCharacter2 = this.GetComponentEnCharacter(false);
			if (componentEnCharacter2 != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_FornixSwelling, componentEnCharacter2, this, resultado, new string[] { "FornixSwelling1", "FornixSwelling2", "FornixSwelling3", "FornixSwelling4" });
			}
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x00051F5C File Offset: 0x0005015C
		protected override void InstanciarAlteradoresD(List<AlteradorGenericoDirectoSextuple> resultado)
		{
			ControlladorDeShapeDeVagInternals componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_VaginalCyst, componentEnCharacter, this, resultado, new string[] { "Swelling1", "Swelling2", "Swelling3", "Swelling4", "Swelling5" });
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_NabothianCysts, componentEnCharacter, this, resultado, new string[] { "Nabothian1", "Nabothian2", "Nabothian3", "Nabothian4", "Nabothian5" });
			}
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x00051FF0 File Offset: 0x000501F0
		protected override void InstanciarAlteradoresE(List<AlteradorGenericoDirectoSeptuple> resultado)
		{
			ControlladorDeShapeDeAnusInternals componentEnCharacter = this.GetComponentEnCharacter(false);
			if (componentEnCharacter != null)
			{
				AlteracionesDeCondicionesMedicas.AddInternalsModsToResutlado(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_MucosalIrregularity, componentEnCharacter, this, resultado, new string[] { "Irregular1", "Irregular2", "Irregular3", "Irregular4", "Irregular5", "Irregular6" });
			}
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x00052054 File Offset: 0x00050254
		private static void AddInternalsModsToResutlado(string alterName, ControllerGenericoDeShapesKey controller, HolderDeAlteradores holder, List<AlteradorGenericoDirectoQuadruple> resultado, params string[] shapes)
		{
			AlteracionesDeCondicionesMedicas.<>c__DisplayClass18_0 CS$<>8__locals1 = new AlteracionesDeCondicionesMedicas.<>c__DisplayClass18_0();
			CS$<>8__locals1.bS = controller.GetModificablesDeShape(shapes[0]);
			CS$<>8__locals1.cS = controller.GetModificablesDeShape(shapes[1]);
			CS$<>8__locals1.dS = controller.GetModificablesDeShape(shapes[2]);
			AlteradorGenericoDirectoQuadruple alteradorGenericoDirectoQuadruple = new AlteradorGenericoDirectoQuadruple(alterName, holder, new AlteradorGenericoDirectoQuadruple.Setter(CS$<>8__locals1.<AddInternalsModsToResutlado>g__Setter|0), 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f);
			resultado.Add(alteradorGenericoDirectoQuadruple);
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x000520DC File Offset: 0x000502DC
		private static void AddInternalsModsToResutlado(string alterName, ControllerGenericoDeShapesKey controller, HolderDeAlteradores holder, List<AlteradorGenericoDirectoQuintuple> resultado, params string[] shapes)
		{
			AlteracionesDeCondicionesMedicas.<>c__DisplayClass19_0 CS$<>8__locals1 = new AlteracionesDeCondicionesMedicas.<>c__DisplayClass19_0();
			CS$<>8__locals1.bS = controller.GetModificablesDeShape(shapes[0]);
			CS$<>8__locals1.cS = controller.GetModificablesDeShape(shapes[1]);
			CS$<>8__locals1.dS = controller.GetModificablesDeShape(shapes[2]);
			CS$<>8__locals1.eS = controller.GetModificablesDeShape(shapes[3]);
			AlteradorGenericoDirectoQuintuple alteradorGenericoDirectoQuintuple = new AlteradorGenericoDirectoQuintuple(alterName, holder, new AlteradorGenericoDirectoQuintuple.Setter(CS$<>8__locals1.<AddInternalsModsToResutlado>g__Setter|0), 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f);
			resultado.Add(alteradorGenericoDirectoQuintuple);
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x0005217C File Offset: 0x0005037C
		private static void AddInternalsModsToResutlado(string alterName, ControllerGenericoDeShapesKey controller, HolderDeAlteradores holder, List<AlteradorGenericoDirectoSextuple> resultado, params string[] shapes)
		{
			AlteracionesDeCondicionesMedicas.<>c__DisplayClass20_0 CS$<>8__locals1 = new AlteracionesDeCondicionesMedicas.<>c__DisplayClass20_0();
			CS$<>8__locals1.bS = controller.GetModificablesDeShape(shapes[0]);
			CS$<>8__locals1.cS = controller.GetModificablesDeShape(shapes[1]);
			CS$<>8__locals1.dS = controller.GetModificablesDeShape(shapes[2]);
			CS$<>8__locals1.eS = controller.GetModificablesDeShape(shapes[3]);
			CS$<>8__locals1.fS = controller.GetModificablesDeShape(shapes[4]);
			AlteradorGenericoDirectoSextuple alteradorGenericoDirectoSextuple = new AlteradorGenericoDirectoSextuple(alterName, holder, new AlteradorGenericoDirectoSextuple.Setter(CS$<>8__locals1.<AddInternalsModsToResutlado>g__Setter|0), 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f);
			resultado.Add(alteradorGenericoDirectoSextuple);
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x00052238 File Offset: 0x00050438
		private static void AddInternalsModsToResutlado(string alterName, ControllerGenericoDeShapesKey controller, HolderDeAlteradores holder, List<AlteradorGenericoDirectoSeptuple> resultado, params string[] shapes)
		{
			AlteracionesDeCondicionesMedicas.<>c__DisplayClass21_0 CS$<>8__locals1 = new AlteracionesDeCondicionesMedicas.<>c__DisplayClass21_0();
			CS$<>8__locals1.bS = controller.GetModificablesDeShape(shapes[0]);
			CS$<>8__locals1.cS = controller.GetModificablesDeShape(shapes[1]);
			CS$<>8__locals1.dS = controller.GetModificablesDeShape(shapes[2]);
			CS$<>8__locals1.eS = controller.GetModificablesDeShape(shapes[3]);
			CS$<>8__locals1.fS = controller.GetModificablesDeShape(shapes[4]);
			CS$<>8__locals1.gS = controller.GetModificablesDeShape(shapes[5]);
			AlteradorGenericoDirectoSeptuple alteradorGenericoDirectoSeptuple = new AlteradorGenericoDirectoSeptuple(alterName, holder, new AlteradorGenericoDirectoSeptuple.Setter(CS$<>8__locals1.<AddInternalsModsToResutlado>g__Setter|0), 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f, 0f, 100f);
			resultado.Add(alteradorGenericoDirectoSeptuple);
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x0005230C File Offset: 0x0005050C
		public override void OnMissingInMap(IReadOnlyDictionary<string, Alterador> missing)
		{
			base.OnMissingInMap(missing);
			Alterador alterador;
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Amigdalitis, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Constripacion, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_ColonIrritable, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_FibrocysticBreast, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Fiebre, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.25f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_MucosalVascularProminence, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_VaginalCyst, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.05f, 1f, 0.1f),
					new ValueTuple<float, float, float>(0.05f, 1f, 0.1f),
					new ValueTuple<float, float, float>(0.05f, 1f, 0.1f),
					new ValueTuple<float, float, float>(0.05f, 1f, 0.1f),
					new ValueTuple<float, float, float>(0.05f, 1f, 0.1f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_Hemorroides, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_NabothianCysts, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_MucosalIrregularity, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
			if (missing.TryGetValue(DiccionarioDeNombresDeAlteradoresFemeninos.Sick_FornixSwelling, out alterador))
			{
				alterador.SetRandomValue(new ValueTuple<float, float, float>[]
				{
					new ValueTuple<float, float, float>(0f, 1f, 1f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f),
					new ValueTuple<float, float, float>(0.1f, 1f, 0.5f)
				});
			}
		}

		// Token: 0x04000CC0 RID: 3264
		public const float cutOff = 0.75f;

		// Token: 0x04000CC1 RID: 3265
		public const float cutOffOutPower = 6f;
	}
}
