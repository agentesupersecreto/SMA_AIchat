using System;

namespace Assets
{
	// Token: 0x02000144 RID: 324
	public class SmoothFloats : SmoothItems<float>
	{
		// Token: 0x060009AD RID: 2477 RVA: 0x0001FB1A File Offset: 0x0001DD1A
		public SmoothFloats(int capacity)
			: base(capacity)
		{
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0001FB23 File Offset: 0x0001DD23
		public SmoothFloats(int capacity, float minAbsoluteValue)
			: base(capacity)
		{
			this.minAbsValue = minAbsoluteValue;
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0001FB33 File Offset: 0x0001DD33
		// (set) Token: 0x060009B0 RID: 2480 RVA: 0x0001FB3B File Offset: 0x0001DD3B
		public float minAbsValue
		{
			get
			{
				return this.m_minAbsValue;
			}
			set
			{
				this.m_minAbsValue = Math.Abs(value);
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0001FB4C File Offset: 0x0001DD4C
		public override float suavizado
		{
			get
			{
				if (!base.contieneAlgo)
				{
					throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
				}
				float num = this.suma / (float)base.length;
				if (num != 0f && this.m_minAbsValue != 0f)
				{
					int num2 = ((num < 0f) ? (-1) : 1);
					if (Math.Abs(num) < this.m_minAbsValue)
					{
						num = this.m_minAbsValue * (float)num2;
					}
				}
				return num;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0001FBBC File Offset: 0x0001DDBC
		public override float suma
		{
			get
			{
				float num = 0f;
				int length = base.length;
				for (int i = 0; i < length; i++)
				{
					num += this.m_dirs[i];
				}
				return num;
			}
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0001FBEE File Offset: 0x0001DDEE
		public override float Suavizado(int maxCantidad)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000264 RID: 612
		private float m_minAbsValue;
	}
}
