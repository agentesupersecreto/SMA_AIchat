using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos
{
	// Token: 0x020001DB RID: 475
	public abstract class EnvolturaCondicionalDeGrupoDeDialogos : ScriptableObject, IEnvolturaCondicionalDeHolders
	{
		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000B5D RID: 2909
		public abstract IReadOnlyList<IHolderDeCollecionDeDialogoInfo> grupos { get; }

		// Token: 0x06000B5E RID: 2910
		public abstract bool IsValid();
	}
}
