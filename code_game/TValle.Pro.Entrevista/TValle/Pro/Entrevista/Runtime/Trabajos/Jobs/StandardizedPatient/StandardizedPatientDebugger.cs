using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime.Nombres;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x0200006A RID: 106
	public class StandardizedPatientDebugger : CustomMonobehaviour
	{
		// Token: 0x040002A8 RID: 680
		public bool activado;

		// Token: 0x040002A9 RID: 681
		public bool forceDocMaxLvl;

		// Token: 0x040002AA RID: 682
		[Header("FastModeScene")]
		public bool loadFastModeScene;

		// Token: 0x040002AB RID: 683
		[Header("Dialogues")]
		public bool ignoreWelcomeDialogue;

		// Token: 0x040002AC RID: 684
		[Header("Lvl")]
		public bool forceLvl;

		// Token: 0x040002AD RID: 685
		public int lvl;

		// Token: 0x040002AE RID: 686
		[Header("Male Scale")]
		public bool forceMaleHeight;

		// Token: 0x040002AF RID: 687
		public float maleHeight = 50f;

		// Token: 0x040002B0 RID: 688
		[Header("Female Scale")]
		public bool forceFemaleHeight;

		// Token: 0x040002B1 RID: 689
		public float femaleHeight = 50f;

		// Token: 0x040002B2 RID: 690
		[Header("Male Penis")]
		public bool forceMalePenis;

		// Token: 0x040002B3 RID: 691
		public float penisSize = 50f;

		// Token: 0x040002B4 RID: 692
		public float penisThickness = 50f;

		// Token: 0x040002B5 RID: 693
		[Header("Sickness")]
		public bool forceExamen;

		// Token: 0x040002B6 RID: 694
		public StandardizedPatientJob.Examen examen;

		// Token: 0x040002B7 RID: 695
		[Tooltip("para q este enferma, se tiene q forzar q es modelo")]
		public bool forceIsModel;

		// Token: 0x040002B8 RID: 696
		[StringSelector(typeof(DiccionarioDeNombresDeAlteradoresFemeninosCondicionesMedicas), "nombres")]
		public List<string> forcedConditions = new List<string>();
	}
}
