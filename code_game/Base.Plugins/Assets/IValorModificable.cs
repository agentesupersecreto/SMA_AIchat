using System;

namespace Assets
{
	// Token: 0x020000F8 RID: 248
	public interface IValorModificable<T_Val>
	{
		// Token: 0x060006E7 RID: 1767
		void Modificar(ref T_Val other);

		// Token: 0x060006E8 RID: 1768
		void Adicionar(ref T_Val other);

		// Token: 0x060006E9 RID: 1769
		void DividorPor(ref T_Val dividendo);

		// Token: 0x060006EA RID: 1770
		void DividorPor(float dividendo);

		// Token: 0x060006EB RID: 1771
		void Max(ref T_Val other);

		// Token: 0x060006EC RID: 1772
		void Min(ref T_Val other);

		// Token: 0x060006ED RID: 1773
		void MaxAbs(ref T_Val other);
	}
}
