using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002AF RID: 687
	public abstract class ArgumentoDeEfecto<T> : ArgumentoDeEfecto where T : ArgumentoDeEfecto<T>
	{
		// Token: 0x060011B9 RID: 4537 RVA: 0x000540DE File Offset: 0x000522DE
		public ArgumentoDeEfecto()
		{
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x060011BA RID: 4538 RVA: 0x000540E6 File Offset: 0x000522E6
		public sealed override string id
		{
			get
			{
				return ArgumentoDeEfecto<T>.ID;
			}
		}

		// Token: 0x04000D06 RID: 3334
		public static readonly string ID = typeof(T).Name;
	}
}
