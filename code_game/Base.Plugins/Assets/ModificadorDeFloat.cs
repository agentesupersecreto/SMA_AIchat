using System;

namespace Assets
{
	// Token: 0x020000FC RID: 252
	[Serializable]
	public class ModificadorDeFloat : ModificadorDeFloatBase, ISingleOwnerValuable<ModificadorDeFloatBase.Data>, IValuable<ModificadorDeFloatBase.Data>
	{
		// Token: 0x0600071E RID: 1822 RVA: 0x000197AA File Offset: 0x000179AA
		public ModificadorDeFloat(int id, float defaultValue, IModificable ow)
			: base(id, defaultValue)
		{
			if (ow == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_owner = ow;
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x000197CE File Offset: 0x000179CE
		public IModificable owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x000197D6 File Offset: 0x000179D6
		IModificable ISingleOwnerValuable<ModificadorDeFloatBase.Data>.owner
		{
			get
			{
				return this.owner;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x000197DE File Offset: 0x000179DE
		public bool Removido()
		{
			return this.owner == null || this.owner.Contiene(this);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x000197F6 File Offset: 0x000179F6
		public bool TryRemoverDeOwner(bool limpiarOwner = true)
		{
			if (this.owner == null)
			{
				return true;
			}
			if (this.owner.TryRemoverModificador(this))
			{
				if (limpiarOwner)
				{
					this.m_owner = null;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0001981D File Offset: 0x00017A1D
		public bool TryLoadToOwner()
		{
			return this.owner != null && this.owner.TryLoadModificador(this);
		}

		// Token: 0x040001F8 RID: 504
		private IModificable m_owner;
	}
}
