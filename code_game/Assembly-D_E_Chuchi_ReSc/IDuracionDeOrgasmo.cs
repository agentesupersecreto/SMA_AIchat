using System;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000006 RID: 6
	public interface IDuracionDeOrgasmo
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001A RID: 26
		float currentDuracionTotalDeOrgasmo { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001B RID: 27
		ExpresionVerbalData nextOrgasmSound { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001C RID: 28
		bool nextOrgasmApretaraBoca { get; }

		// Token: 0x0600001D RID: 29
		void FlagSonidoDeOrgasmoUsado(ExpresionVerbalData usado);
	}
}
