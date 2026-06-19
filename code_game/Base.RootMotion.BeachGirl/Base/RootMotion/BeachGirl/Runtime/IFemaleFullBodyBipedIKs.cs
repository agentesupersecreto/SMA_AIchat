using System;
using System.Collections.Generic;
using RootMotion.FinalIK;

namespace Assets.Base.RootMotion.BeachGirl.Runtime
{
	// Token: 0x0200000E RID: 14
	public interface IFemaleFullBodyBipedIKs
	{
		// Token: 0x0600005F RID: 95
		[Obsolete("", true)]
		FullBodyBipedIK ObtenerFullBodyBipedIKDePasada(int index);

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000060 RID: 96
		[Obsolete("", true)]
		List<FullBodyBipedIK> fullBodyBipedIKs { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000061 RID: 97
		IReadOnlyList<FullBodyBipedIK> allFullBodyBipedIKs { get; }

		// Token: 0x06000062 RID: 98
		FullBodyBipedIK ObtenerCurrentFullBodyBipedIKDeLayer(int layer);

		// Token: 0x06000063 RID: 99
		FullBodyBipedIK ObtenerCurrentFullBodyBipedIKDeID(int id);

		// Token: 0x06000064 RID: 100
		IReadOnlyList<FullBodyBipedIK> ObtenerFullBodyBipedIKsDeLayer(int layer);

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000065 RID: 101
		IReadOnlyList<FullBodyBipedIK> primarios { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000066 RID: 102
		IReadOnlyList<FullBodyBipedIK> segundarios { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000067 RID: 103
		FullBodyBipedIK user { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000068 RID: 104
		int cantidadDeIKs { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000069 RID: 105
		int cantidadDeLayers { get; }

		// Token: 0x0600006A RID: 106
		int GetId(FullBodyBipedIK IK);

		// Token: 0x0600006B RID: 107
		int GetLayerDeIK(FullBodyBipedIK IK);

		// Token: 0x0600006C RID: 108
		int GetIndexInLayerDeIK(FullBodyBipedIK IK, out bool ultimoDeLayer);

		// Token: 0x0600006D RID: 109
		int CantidadDePasadasDeIK(FullBodyBipedIK IK);

		// Token: 0x0600006E RID: 110
		void SwitchPrimarios();

		// Token: 0x0600006F RID: 111
		void SwitchSegundarios();
	}
}
