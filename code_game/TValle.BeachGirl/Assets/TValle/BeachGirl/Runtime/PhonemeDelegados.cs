using System;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	public class PhonemeDelegados
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00002F87 File Offset: 0x00001187
		public IPhonemeDelegado A1
		{
			get
			{
				return (IPhonemeDelegado)this.m_A1;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00002F94 File Offset: 0x00001194
		public IPhonemeDelegado A2
		{
			get
			{
				return (IPhonemeDelegado)this.m_A2;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00002FA1 File Offset: 0x000011A1
		public IPhonemeDelegado A3
		{
			get
			{
				return (IPhonemeDelegado)this.m_A3;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00002FAE File Offset: 0x000011AE
		public IPhonemeDelegado B1
		{
			get
			{
				return (IPhonemeDelegado)this.m_B1;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00002FBB File Offset: 0x000011BB
		public IPhonemeDelegado B2
		{
			get
			{
				return (IPhonemeDelegado)this.m_B2;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00002FC8 File Offset: 0x000011C8
		public IPhonemeDelegado B3
		{
			get
			{
				return (IPhonemeDelegado)this.m_B3;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00002FD5 File Offset: 0x000011D5
		public IPhonemeDelegado C1
		{
			get
			{
				return (IPhonemeDelegado)this.m_C1;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00002FE2 File Offset: 0x000011E2
		public IPhonemeDelegado C2
		{
			get
			{
				return (IPhonemeDelegado)this.m_C2;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00002FEF File Offset: 0x000011EF
		public IPhonemeDelegado D1
		{
			get
			{
				return (IPhonemeDelegado)this.m_D1;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00002FFC File Offset: 0x000011FC
		public IPhonemeDelegado D2
		{
			get
			{
				return (IPhonemeDelegado)this.m_D2;
			}
		}

		// Token: 0x040000DA RID: 218
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_A1;

		// Token: 0x040000DB RID: 219
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_A2;

		// Token: 0x040000DC RID: 220
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_A3;

		// Token: 0x040000DD RID: 221
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_B1;

		// Token: 0x040000DE RID: 222
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_B2;

		// Token: 0x040000DF RID: 223
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_B3;

		// Token: 0x040000E0 RID: 224
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_C1;

		// Token: 0x040000E1 RID: 225
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_C2;

		// Token: 0x040000E2 RID: 226
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_D1;

		// Token: 0x040000E3 RID: 227
		[SerializeField]
		[ConstraintType(typeof(IPhonemeDelegado))]
		private Component m_D2;
	}
}
