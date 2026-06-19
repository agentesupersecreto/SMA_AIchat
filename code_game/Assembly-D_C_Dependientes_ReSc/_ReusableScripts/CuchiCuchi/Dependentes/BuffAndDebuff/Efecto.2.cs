using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002B1 RID: 689
	[Serializable]
	public abstract class Efecto<T, TArg> : Efecto where T : Efecto<T, TArg>
	{
		// Token: 0x060011C2 RID: 4546 RVA: 0x0005412A File Offset: 0x0005232A
		public Efecto()
		{
			this.m_label = Efecto<T, TArg>.ID;
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x060011C3 RID: 4547 RVA: 0x0005413D File Offset: 0x0005233D
		public sealed override string id
		{
			get
			{
				return Efecto<T, TArg>.ID;
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x060011C4 RID: 4548 RVA: 0x00054144 File Offset: 0x00052344
		public sealed override string argumentoID
		{
			get
			{
				return Efecto<T, TArg>.ID_Arg;
			}
		}

		// Token: 0x04000D08 RID: 3336
		public static readonly string ID = typeof(T).Name;

		// Token: 0x04000D09 RID: 3337
		public static readonly string ID_Arg = typeof(TArg).Name;
	}
}
