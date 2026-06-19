using System;

namespace com.ootii.Collections
{
	// Token: 0x02000066 RID: 102
	public sealed class ObjectPool<T> where T : new()
	{
		// Token: 0x060004A6 RID: 1190 RVA: 0x0001BC40 File Offset: 0x00019E40
		public ObjectPool(int rSize)
		{
			this.Resize(rSize, false);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0001BC58 File Offset: 0x00019E58
		public ObjectPool(int rSize, int rGrowSize)
		{
			this.mGrowSize = rGrowSize;
			this.Resize(rSize, false);
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0001BC77 File Offset: 0x00019E77
		public int Length
		{
			get
			{
				return this.mPool.Length;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0001BC81 File Offset: 0x00019E81
		public int Available
		{
			get
			{
				return this.mPool.Length - this.mNextIndex;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0001BC92 File Offset: 0x00019E92
		public int Allocated
		{
			get
			{
				return this.mNextIndex;
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0001BC9C File Offset: 0x00019E9C
		public T Allocate()
		{
			T t = default(T);
			if (this.mNextIndex >= this.mPool.Length)
			{
				if (this.mGrowSize <= 0)
				{
					return t;
				}
				this.Resize(this.mPool.Length + this.mGrowSize, true);
			}
			if (this.mNextIndex >= 0 && this.mNextIndex < this.mPool.Length)
			{
				t = this.mPool[this.mNextIndex];
				this.mNextIndex++;
			}
			return t;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0001BD1E File Offset: 0x00019F1E
		public void Release(T rInstance)
		{
			if (this.mNextIndex > 0)
			{
				this.mNextIndex--;
				this.mPool[this.mNextIndex] = rInstance;
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0001BD4C File Offset: 0x00019F4C
		public void Reset()
		{
			int num = this.mGrowSize;
			if (this.mPool != null)
			{
				num = this.mPool.Length;
			}
			this.Resize(num, false);
			this.mNextIndex = 0;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001BD80 File Offset: 0x00019F80
		public void Resize(int rSize, bool rCopyExisting)
		{
			lock (this)
			{
				int num = 0;
				T[] array = new T[rSize];
				if (this.mPool != null && rCopyExisting)
				{
					num = this.mPool.Length;
					Array.Copy(this.mPool, array, Math.Min(num, rSize));
				}
				for (int i = num; i < rSize; i++)
				{
					array[i] = new T();
				}
				this.mPool = array;
			}
		}

		// Token: 0x04000250 RID: 592
		private int mGrowSize = 20;

		// Token: 0x04000251 RID: 593
		private T[] mPool;

		// Token: 0x04000252 RID: 594
		private int mNextIndex;
	}
}
