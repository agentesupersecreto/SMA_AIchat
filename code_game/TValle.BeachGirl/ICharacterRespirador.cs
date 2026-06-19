using System;
using Assets;

// Token: 0x02000003 RID: 3
public interface ICharacterRespirador
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000004 RID: 4
	bool currentCanBreath { get; }

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000005 RID: 5
	float currentBreathFreq { get; }

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000006 RID: 6
	CanzancioEstado cansancioEstado { get; }

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000007 RID: 7
	bool canzado { get; }

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000008 RID: 8
	bool ahogado { get; }

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000009 RID: 9
	bool descanzado { get; }

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600000A RID: 10
	float saturacionDeOxigeno { get; }

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x0600000B RID: 11
	float cansamientoWeight { get; }

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x0600000C RID: 12
	float ahogadoWeight { get; }

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600000D RID: 13
	float saturacionDeOxigenoWeigth { get; }

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600000E RID: 14
	ModificableDeFloat demandaDeOxigenoModificable { get; }

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600000F RID: 15
	ModificableDeFloat demandaDeOxigenoAntesDeCansanrseModificable { get; }

	// Token: 0x06000010 RID: 16
	void ChangeSaturacionNext(float chageValue);
}
