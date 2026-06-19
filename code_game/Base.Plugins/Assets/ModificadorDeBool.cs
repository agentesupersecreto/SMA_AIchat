using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000FD RID: 253
	[Serializable]
	public class ModificadorDeBool : ISingleOwnerValuable<ModificadorDeBool.Data>, IValuable<ModificadorDeBool.Data>
	{
		// Token: 0x06000724 RID: 1828 RVA: 0x00019835 File Offset: 0x00017A35
		void IValuable<ModificadorDeBool.Data>.EditorOverrideKey(int overridingKey)
		{
			if (!Application.isEditor)
			{
				throw new NotSupportedException();
			}
			this.m_id = overridingKey;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0001984C File Offset: 0x00017A4C
		public ModificadorDeBool(int id, bool defaultValue, IModificable ow)
		{
			if (ow == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_id = id;
			this.m_owner = ow;
			this.valor = new ModificadorDeBool.Data
			{
				valor = defaultValue
			};
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00019897 File Offset: 0x00017A97
		public IModificable owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x0001989F File Offset: 0x00017A9F
		public int id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x000198A7 File Offset: 0x00017AA7
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x000198AF File Offset: 0x00017AAF
		ModificadorDeBool.Data IValuable<ModificadorDeBool.Data>.valor
		{
			get
			{
				return this.valor;
			}
			set
			{
				this.valor = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x000198B8 File Offset: 0x00017AB8
		IModificable ISingleOwnerValuable<ModificadorDeBool.Data>.owner
		{
			get
			{
				return this.owner;
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x000198C0 File Offset: 0x00017AC0
		public bool Removido()
		{
			return this.owner == null || this.owner.Contiene(this);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x000198D8 File Offset: 0x00017AD8
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

		// Token: 0x040001F9 RID: 505
		private IModificable m_owner;

		// Token: 0x040001FA RID: 506
		[SerializeField]
		[ReadOnlyUI]
		private int m_id;

		// Token: 0x040001FB RID: 507
		public ModificadorDeBool.Data valor;

		// Token: 0x020001D4 RID: 468
		[Serializable]
		public struct Data : IValorModificable<ModificadorDeBool.Data>
		{
			// Token: 0x06000C7C RID: 3196 RVA: 0x00026D66 File Offset: 0x00024F66
			public void Adicionar(ref ModificadorDeBool.Data other)
			{
				this.valor = this.valor || other.valor;
			}

			// Token: 0x06000C7D RID: 3197 RVA: 0x00026D7F File Offset: 0x00024F7F
			public void DividorPor(float dividendo)
			{
				throw new NotSupportedException();
			}

			// Token: 0x06000C7E RID: 3198 RVA: 0x00026D86 File Offset: 0x00024F86
			public void DividorPor(ref ModificadorDeBool.Data dividendo)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000C7F RID: 3199 RVA: 0x00026D8D File Offset: 0x00024F8D
			public void Max(ref ModificadorDeBool.Data other)
			{
				this.valor = this.valor || other.valor;
			}

			// Token: 0x06000C80 RID: 3200 RVA: 0x00026DA6 File Offset: 0x00024FA6
			public void Min(ref ModificadorDeBool.Data other)
			{
				this.valor = this.valor && other.valor;
			}

			// Token: 0x06000C81 RID: 3201 RVA: 0x00026DBF File Offset: 0x00024FBF
			public void MaxAbs(ref ModificadorDeBool.Data other)
			{
				throw new NotSupportedException();
			}

			// Token: 0x06000C82 RID: 3202 RVA: 0x00026DC6 File Offset: 0x00024FC6
			public void Modificar(ref ModificadorDeBool.Data other)
			{
				this.valor = this.valor || other.valor;
			}

			// Token: 0x04000460 RID: 1120
			public bool valor;
		}
	}
}
