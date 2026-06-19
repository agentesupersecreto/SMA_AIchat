using System;

namespace Assets
{
	// Token: 0x020000FE RID: 254
	[Serializable]
	public class ModificableDeBool : MultipleModificable<ModificadorDeBool, ModificadorDeBool.Data>
	{
		// Token: 0x0600072D RID: 1837 RVA: 0x000198FF File Offset: 0x00017AFF
		public ModificableDeBool(bool DefaultValueDeModificadorAlInstanciar)
		{
			this.defaultValueDeModificadorAlInstanciar = DefaultValueDeModificadorAlInstanciar;
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0001990E File Offset: 0x00017B0E
		protected override ModificadorDeBool InstanciarModificador(int id)
		{
			return new ModificadorDeBool(id, this.defaultValueDeModificadorAlInstanciar, this);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00019920 File Offset: 0x00017B20
		public bool Or(bool valor)
		{
			ModificadorDeBool.Data data = default(ModificadorDeBool.Data);
			data.valor = valor;
			base.MaximoValorIncluyendo(ref data);
			return data.valor;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0001994C File Offset: 0x00017B4C
		public bool And(bool valor)
		{
			ModificadorDeBool.Data data = default(ModificadorDeBool.Data);
			data.valor = valor;
			base.MinimoValorIncluyendo(ref data);
			return data.valor;
		}

		// Token: 0x040001FC RID: 508
		public bool defaultValueDeModificadorAlInstanciar;
	}
}
