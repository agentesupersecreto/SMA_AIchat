using System;

namespace Assets
{
	// Token: 0x02000145 RID: 325
	public class SmoothDoubles : SmoothItems<double>
	{
		// Token: 0x060009B4 RID: 2484 RVA: 0x0001FBF5 File Offset: 0x0001DDF5
		public SmoothDoubles(int capacity)
			: base(capacity)
		{
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0001FBFE File Offset: 0x0001DDFE
		public SmoothDoubles(int capacity, double minAbsoluteValue)
			: base(capacity)
		{
			this.minAbsValue = minAbsoluteValue;
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0001FC0E File Offset: 0x0001DE0E
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x0001FC16 File Offset: 0x0001DE16
		public double minAbsValue
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

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0001FC24 File Offset: 0x0001DE24
		public override double suavizado
		{
			get
			{
				if (!base.contieneAlgo)
				{
					throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
				}
				double num = this.suma / (double)base.length;
				if (num != 0.0 && this.m_minAbsValue != 0.0)
				{
					int num2 = ((num < 0.0) ? (-1) : 1);
					if (Math.Abs(num) < this.m_minAbsValue)
					{
						num = this.m_minAbsValue * (double)num2;
					}
				}
				return num;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0001FCA4 File Offset: 0x0001DEA4
		public override double suma
		{
			get
			{
				double num = 0.0;
				int length = base.length;
				for (int i = 0; i < length; i++)
				{
					num += this.m_dirs[i];
				}
				return num;
			}
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0001FCDA File Offset: 0x0001DEDA
		public override double Suavizado(int maxCantidad)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000265 RID: 613
		private double m_minAbsValue;
	}
}
