using System;

namespace Assets
{
	// Token: 0x02000146 RID: 326
	public abstract class SmoothItems<Titem>
	{
		// Token: 0x060009BC RID: 2492 RVA: 0x0001FCF7 File Offset: 0x0001DEF7
		public SmoothItems(int capacity)
		{
			if (capacity <= 0)
			{
				throw new InvalidOperationException();
			}
			this.m_dirs = new Titem[capacity];
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0001FD15 File Offset: 0x0001DF15
		public SmoothItems()
		{
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x0001FD1D File Offset: 0x0001DF1D
		public int capacity
		{
			get
			{
				return this.m_dirs.Length;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0001FD27 File Offset: 0x0001DF27
		public int contenidos
		{
			get
			{
				return this.m_Contenidos;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0001FD2F File Offset: 0x0001DF2F
		public bool contieneAlgo
		{
			get
			{
				return this.length > 0;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0001FD3A File Offset: 0x0001DF3A
		public bool fulled
		{
			get
			{
				return this.m_fulled;
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x0001FD42 File Offset: 0x0001DF42
		public int length
		{
			get
			{
				if (!this.m_fulled)
				{
					return this.m_Contenidos;
				}
				return this.m_dirs.Length;
			}
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0001FD5B File Offset: 0x0001DF5B
		public void ChangeCapacity(int capacity)
		{
			this.Clear();
			Array.Resize<Titem>(ref this.m_dirs, capacity);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0001FD6F File Offset: 0x0001DF6F
		[Obsolete("no funciona muy bien")]
		public void CopiarDe(SmoothItems<Titem> other)
		{
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0001FD74 File Offset: 0x0001DF74
		protected static int GoNext(ref int siguienteIndex, int capacity)
		{
			bool flag = false;
			return SmoothItems<Titem>.GoNext(ref siguienteIndex, capacity, ref flag);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0001FD8C File Offset: 0x0001DF8C
		protected static int GoNext(ref int siguienteIndex, int capacity, ref bool fulled)
		{
			int num = siguienteIndex;
			siguienteIndex++;
			if (siguienteIndex >= capacity)
			{
				siguienteIndex = 0;
				fulled = true;
			}
			return num;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0001FDA1 File Offset: 0x0001DFA1
		protected static int GoPrevius(ref int siguienteIndex, int contenidos, int length)
		{
			if (length <= 0)
			{
				throw new InvalidOperationException();
			}
			siguienteIndex--;
			if (siguienteIndex < 0)
			{
				siguienteIndex = contenidos - 1;
				if (siguienteIndex < 0)
				{
					throw new InvalidOperationException();
				}
			}
			return siguienteIndex;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0001FDCA File Offset: 0x0001DFCA
		protected int GoPrevius()
		{
			return SmoothItems<Titem>.GoPrevius(ref this.m_siguienteIndex, this.m_Contenidos, this.length);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0001FDE3 File Offset: 0x0001DFE3
		protected int GoNext()
		{
			return SmoothItems<Titem>.GoNext(ref this.m_siguienteIndex, this.m_dirs.Length, ref this.m_fulled);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0001FE00 File Offset: 0x0001E000
		public void Add(Titem item)
		{
			try
			{
				if (!this.m_fulled)
				{
					this.m_Contenidos++;
					if (this.m_Contenidos > this.m_dirs.Length)
					{
						throw new InvalidOperationException();
					}
				}
				int num = this.GoNext();
				this.m_dirs[num] = item;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0001FE64 File Offset: 0x0001E064
		public void Clear()
		{
			this.m_Contenidos = 0;
			this.m_siguienteIndex = 0;
			this.m_fulled = false;
			if (!SmoothItems<Titem>.esValueTypes && this.m_dirs != null)
			{
				Array.Clear(this.m_dirs, 0, this.m_dirs.Length);
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060009CC RID: 2508
		public abstract Titem suma { get; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060009CD RID: 2509
		public abstract Titem suavizado { get; }

		// Token: 0x060009CE RID: 2510
		public abstract Titem Suavizado(int maxCantidad);

		// Token: 0x04000266 RID: 614
		public static readonly bool esValueTypes = typeof(Titem).IsValueType;

		// Token: 0x04000267 RID: 615
		protected Titem[] m_dirs;

		// Token: 0x04000268 RID: 616
		protected int m_siguienteIndex;

		// Token: 0x04000269 RID: 617
		private int m_Contenidos;

		// Token: 0x0400026A RID: 618
		protected bool m_fulled;
	}
}
