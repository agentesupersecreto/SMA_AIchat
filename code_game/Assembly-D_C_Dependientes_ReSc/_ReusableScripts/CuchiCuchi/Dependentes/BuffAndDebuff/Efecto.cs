using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002B0 RID: 688
	[Serializable]
	public abstract class Efecto
	{
		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x060011BB RID: 4539
		public abstract string id { get; }

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x060011BC RID: 4540
		public abstract string argumentoID { get; }

		// Token: 0x060011BD RID: 4541
		public abstract void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster);

		// Token: 0x060011BE RID: 4542
		public abstract void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster);

		// Token: 0x060011BF RID: 4543
		public abstract void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster);

		// Token: 0x04000D07 RID: 3335
		[SerializeField]
		[HideInInspector]
		protected string m_label = string.Empty;
	}
}
