using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.Memoria
{
	// Token: 0x020000BC RID: 188
	[MemoriaFunctions]
	public static class MemoriaDeSMAGamePlay
	{
		// Token: 0x060006F8 RID: 1784 RVA: 0x00028055 File Offset: 0x00026255
		public static int GetCurrentOfficeLvl()
		{
			return MemoriaDeSMAGamePlay.GetCurrentOfficeLvl(GlobalSingletonV2<MemoriaJson>.instance);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00028061 File Offset: 0x00026261
		public static void SetCurrentOfficeLvl(int officeLvl)
		{
			MemoriaDeSMAGamePlay.SetCurrentOfficeLvl(GlobalSingletonV2<MemoriaJson>.instance, officeLvl);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0002806E File Offset: 0x0002626E
		public static int GetCurrentOfficeLvl(IMemoria memoria)
		{
			return memoria.root.FindDataInt("OfficeLvl", 0);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00028081 File Offset: 0x00026281
		public static void SetCurrentOfficeLvl(IMemoria memoria, int officeLvl)
		{
			memoria.root.AddData("OfficeLvl", officeLvl, true);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00028095 File Offset: 0x00026295
		public static void GetNombres(IMemoria memoria, string npcID, out string nombre, out string apellido, out string nombreCompleto)
		{
			MemoriaDeNpc.GetNombres(memoria, npcID, out nombre, out apellido, out nombreCompleto);
		}
	}
}
