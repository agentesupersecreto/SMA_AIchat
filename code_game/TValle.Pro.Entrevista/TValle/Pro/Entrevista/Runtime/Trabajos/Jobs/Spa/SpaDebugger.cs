using System;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.Spa
{
	// Token: 0x02000071 RID: 113
	public class SpaDebugger : CustomMonobehaviour
	{
		// Token: 0x040002DE RID: 734
		public bool activado;

		// Token: 0x040002DF RID: 735
		[Header("Timer")]
		public bool flagToPhaseTimeUp;

		// Token: 0x040002E0 RID: 736
		[Header("Dialogues")]
		public bool ignoreWelcomeDialogue;

		// Token: 0x040002E1 RID: 737
		[Header("AI")]
		public SpaDebugger.ForceServicing forceServicing;

		// Token: 0x040002E2 RID: 738
		[Header("Duration")]
		public float massageDuration = 30f;

		// Token: 0x040002E3 RID: 739
		public float happyDuration = 60f;

		// Token: 0x040002E4 RID: 740
		public float oralDuration = 90f;

		// Token: 0x040002E5 RID: 741
		public float sexDuration = 90f;

		// Token: 0x040002E6 RID: 742
		[Header("Debug")]
		public SpaDebugger.StartWithEnding startWithEnding;

		// Token: 0x040002E7 RID: 743
		public int overrideToGoClients = -1;

		// Token: 0x040002E8 RID: 744
		[Header("Male Scale")]
		public bool forceMaleHeight;

		// Token: 0x040002E9 RID: 745
		public float maleHeight = 50f;

		// Token: 0x040002EA RID: 746
		[Header("Female Scale")]
		public bool forceFemaleHeight;

		// Token: 0x040002EB RID: 747
		public float femaleHeight = 50f;

		// Token: 0x040002EC RID: 748
		[Header("Male Penis")]
		public bool forceMalePenis;

		// Token: 0x040002ED RID: 749
		public float penisSize = 50f;

		// Token: 0x040002EE RID: 750
		public float penisThickness = 50f;

		// Token: 0x02000207 RID: 519
		public enum ForceServicing
		{
			// Token: 0x040009D5 RID: 2517
			Default,
			// Token: 0x040009D6 RID: 2518
			ForceHate,
			// Token: 0x040009D7 RID: 2519
			ForceOK,
			// Token: 0x040009D8 RID: 2520
			ForceHandJob,
			// Token: 0x040009D9 RID: 2521
			ForceOral,
			// Token: 0x040009DA RID: 2522
			ForceSexVaginal,
			// Token: 0x040009DB RID: 2523
			ForceSexAnal
		}

		// Token: 0x02000208 RID: 520
		public enum StartWithEnding
		{
			// Token: 0x040009DD RID: 2525
			Default,
			// Token: 0x040009DE RID: 2526
			MassageEnding,
			// Token: 0x040009DF RID: 2527
			HappyEnding,
			// Token: 0x040009E0 RID: 2528
			OralEnding,
			// Token: 0x040009E1 RID: 2529
			SexVaginalEnding,
			// Token: 0x040009E2 RID: 2530
			SexAnalEnding
		}
	}
}
