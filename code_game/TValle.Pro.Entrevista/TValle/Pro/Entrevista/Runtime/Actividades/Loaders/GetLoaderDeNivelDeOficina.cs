using System;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders
{
	// Token: 0x0200013C RID: 316
	public static class GetLoaderDeNivelDeOficina
	{
		// Token: 0x06000B2A RID: 2858 RVA: 0x0003A618 File Offset: 0x00038818
		public static Type Empty(int officeLVL)
		{
			switch (officeLVL)
			{
			case 0:
				return typeof(EntrevistaComenzarATrabajar_OfficeLvl0_Loader);
			case 1:
				return typeof(EntrevistaComenzarATrabajar_OfficeLvl1_Loader);
			case 2:
				return typeof(EntrevistaComenzarATrabajar_OfficeLvl2_Loader);
			case 3:
				return typeof(EntrevistaComenzarATrabajar_OfficeLvl3_Loader);
			case 4:
				return typeof(EntrevistaComenzarATrabajar_OfficeLvl4_Loader);
			default:
				throw new ArgumentOutOfRangeException(officeLVL.ToString());
			}
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0003A684 File Offset: 0x00038884
		public static Type Interviewing(int officeLVL)
		{
			switch (officeLVL)
			{
			case 0:
				return typeof(EntrevistaScoreFemaleFromPool_OfficeLvl0_Loader);
			case 1:
				return typeof(EntrevistaScoreFemaleFromPool_OfficeLvl1_Loader);
			case 2:
				return typeof(EntrevistaScoreFemaleFromPool_OfficeLvl2_Loader);
			case 3:
				return typeof(EntrevistaScoreFemaleFromPool_OfficeLvl3_Loader);
			case 4:
				return typeof(EntrevistaScoreFemaleFromPool_OfficeLvl4_Loader);
			default:
				throw new ArgumentOutOfRangeException(officeLVL.ToString());
			}
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0003A6F0 File Offset: 0x000388F0
		public static Type Meeting(int officeLVL)
		{
			switch (officeLVL)
			{
			case 0:
				return typeof(MeetingHiredFemaleModel_OfficeLvl0_Loader);
			case 1:
				return typeof(MeetingHiredFemaleModel_OfficeLvl1_Loader);
			case 2:
				return typeof(MeetingHiredFemaleModel_OfficeLvl2_Loader);
			case 3:
				return typeof(MeetingHiredFemaleModel_OfficeLvl3_Loader);
			case 4:
				return typeof(MeetingHiredFemaleModel_OfficeLvl4_Loader);
			default:
				throw new ArgumentOutOfRangeException(officeLVL.ToString());
			}
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0003A75C File Offset: 0x0003895C
		public static Type Designer(int officeLVL)
		{
			if (officeLVL == 1)
			{
				return typeof(DesignerFemaleModel_OfficeLvl1_Loader);
			}
			throw new ArgumentOutOfRangeException(officeLVL.ToString());
		}
	}
}
