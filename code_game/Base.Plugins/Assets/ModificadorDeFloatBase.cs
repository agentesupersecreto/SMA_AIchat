using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000FB RID: 251
	public abstract class ModificadorDeFloatBase : IValuable<ModificadorDeFloatBase.Data>
	{
		// Token: 0x06000719 RID: 1817 RVA: 0x00019749 File Offset: 0x00017949
		void IValuable<ModificadorDeFloatBase.Data>.EditorOverrideKey(int overridingKey)
		{
			if (!Application.isEditor)
			{
				throw new NotSupportedException();
			}
			this.m_id = overridingKey;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00019760 File Offset: 0x00017960
		public ModificadorDeFloatBase(int id, float defaultValue)
		{
			this.m_id = id;
			this.valor = new ModificadorDeFloatBase.Data
			{
				valor = defaultValue
			};
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00019791 File Offset: 0x00017991
		public int id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00019799 File Offset: 0x00017999
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x000197A1 File Offset: 0x000179A1
		ModificadorDeFloatBase.Data IValuable<ModificadorDeFloatBase.Data>.valor
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

		// Token: 0x040001F6 RID: 502
		[ReadOnlyUI]
		[SerializeField]
		private int m_id;

		// Token: 0x040001F7 RID: 503
		public ModificadorDeFloatBase.Data valor;

		// Token: 0x020001D3 RID: 467
		[Serializable]
		public struct Data : IValorModificable<ModificadorDeFloatBase.Data>
		{
			// Token: 0x06000C75 RID: 3189 RVA: 0x00026CBF File Offset: 0x00024EBF
			public void Adicionar(ref ModificadorDeFloatBase.Data other)
			{
				this.valor += other.valor;
			}

			// Token: 0x06000C76 RID: 3190 RVA: 0x00026CD4 File Offset: 0x00024ED4
			public void DividorPor(float dividendo)
			{
				this.valor /= dividendo;
			}

			// Token: 0x06000C77 RID: 3191 RVA: 0x00026CE4 File Offset: 0x00024EE4
			public void DividorPor(ref ModificadorDeFloatBase.Data dividendo)
			{
				this.valor /= dividendo.valor;
			}

			// Token: 0x06000C78 RID: 3192 RVA: 0x00026CF9 File Offset: 0x00024EF9
			public void Max(ref ModificadorDeFloatBase.Data other)
			{
				this.valor = Mathf.Max(this.valor, other.valor);
			}

			// Token: 0x06000C79 RID: 3193 RVA: 0x00026D12 File Offset: 0x00024F12
			public void Min(ref ModificadorDeFloatBase.Data other)
			{
				this.valor = Mathf.Min(this.valor, other.valor);
			}

			// Token: 0x06000C7A RID: 3194 RVA: 0x00026D2B File Offset: 0x00024F2B
			public void MaxAbs(ref ModificadorDeFloatBase.Data other)
			{
				if (Mathf.Abs(this.valor) < Mathf.Abs(other.valor))
				{
					this.valor = other.valor;
				}
			}

			// Token: 0x06000C7B RID: 3195 RVA: 0x00026D51 File Offset: 0x00024F51
			public void Modificar(ref ModificadorDeFloatBase.Data other)
			{
				this.valor *= other.valor;
			}

			// Token: 0x0400045F RID: 1119
			public float valor;
		}
	}
}
