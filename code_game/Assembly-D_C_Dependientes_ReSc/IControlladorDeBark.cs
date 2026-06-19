using System;
using Assets._ReusableScripts;

namespace Assets
{
	// Token: 0x02000007 RID: 7
	public interface IControlladorDeBark
	{
		// Token: 0x06000013 RID: 19
		bool PuedeMostrarBark(int prioridad, ControllerPrioridadConfig priConfig, ref bool puedePonerEnCola);

		// Token: 0x06000014 RID: 20
		bool ClearBark();

		// Token: 0x06000015 RID: 21
		bool Bark(string dialogo, bool vocalizar, int prioridad, ControllerPrioridadConfig priConfig, float duracionModPorLetra = 1f, float duracionMod = 1f);

		// Token: 0x06000016 RID: 22
		bool DelayedBark<TData>(float delay, TData extradata, Action<TData, bool> callBack, string dialogo, int prioridad, ControllerPrioridadConfig priConfig, bool vocalizar, float duracionModPorLetra = 1f, float duracionMod = 1f);

		// Token: 0x06000017 RID: 23
		bool MuteClearing(float duracion);

		// Token: 0x06000018 RID: 24
		void FlagMinPrioridad(int MinPrioridad, float duracion);
	}
}
