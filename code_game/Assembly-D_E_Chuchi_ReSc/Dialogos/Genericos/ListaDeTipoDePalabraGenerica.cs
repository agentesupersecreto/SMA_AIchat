using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos
{
	// Token: 0x02000208 RID: 520
	[Serializable]
	public sealed class ListaDeTipoDePalabraGenerica : SerializableEnumHashSetList<TipoDePalabraGenerica>
	{
		// Token: 0x06000BEB RID: 3051 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override TipoDePalabraGenerica ToEnum(int value)
		{
			return (TipoDePalabraGenerica)value;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override int ToInt(TipoDePalabraGenerica e)
		{
			return (int)e;
		}
	}
}
