using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000142 RID: 322
	public class SmoothQuaternions : SmoothItems<Quaternion>
	{
		// Token: 0x060009A4 RID: 2468 RVA: 0x0001F91A File Offset: 0x0001DB1A
		public SmoothQuaternions()
		{
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0001F922 File Offset: 0x0001DB22
		public SmoothQuaternions(int capacity)
			: base(capacity)
		{
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x0001F92C File Offset: 0x0001DB2C
		public override Quaternion suavizado
		{
			get
			{
				if (!base.contieneAlgo)
				{
					throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
				}
				int length = base.length;
				Quaternion quaternion = this.m_dirs[0];
				for (int i = 1; i < length; i++)
				{
					float num = 1f / (float)(i + 1);
					quaternion = Quaternion.Slerp(quaternion, this.m_dirs[i], num);
				}
				return quaternion;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x0001F98C File Offset: 0x0001DB8C
		public override Quaternion suma
		{
			get
			{
				if (!base.contieneAlgo)
				{
					throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
				}
				int length = base.length;
				Quaternion quaternion = this.m_dirs[0];
				for (int i = 1; i < length; i++)
				{
					quaternion *= this.m_dirs[i];
				}
				return quaternion;
			}
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0001F9E0 File Offset: 0x0001DBE0
		public override Quaternion Suavizado(int maxCantidad)
		{
			if (!base.contieneAlgo)
			{
				throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
			}
			int num = Mathf.Min(maxCantidad, base.length);
			int siguienteIndex = this.m_siguienteIndex;
			SmoothItems<Quaternion>.GoPrevius(ref siguienteIndex, base.contenidos, base.length);
			Quaternion quaternion = this.m_dirs[siguienteIndex];
			for (int i = 0; i < num; i++)
			{
				SmoothItems<Quaternion>.GoPrevius(ref siguienteIndex, base.contenidos, base.length);
				float num2 = 1f / (float)(i + 2);
				try
				{
					quaternion = Quaternion.Slerp(quaternion, this.m_dirs[siguienteIndex], num2);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return quaternion;
		}
	}
}
