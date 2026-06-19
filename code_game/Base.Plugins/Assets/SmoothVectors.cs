using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000147 RID: 327
	public class SmoothVectors : SmoothItems<Vector3>
	{
		// Token: 0x060009CF RID: 2511 RVA: 0x0001FE9E File Offset: 0x0001E09E
		public SmoothVectors(int capacity)
			: base(capacity)
		{
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0001FEA7 File Offset: 0x0001E0A7
		public override Vector3 suavizado
		{
			get
			{
				if (!base.contieneAlgo)
				{
					throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
				}
				return this.suma / (float)base.length;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0001FED0 File Offset: 0x0001E0D0
		public override Vector3 suma
		{
			get
			{
				Vector3 vector = Vector3.zero;
				int length = base.length;
				for (int i = 0; i < length; i++)
				{
					vector += this.m_dirs[i];
				}
				return vector;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0001FF0C File Offset: 0x0001E10C
		public Vector3 velocidadPromedio
		{
			get
			{
				int siguienteIndex = this.m_siguienteIndex;
				int num = SmoothItems<Vector3>.GoNext(ref siguienteIndex, base.length);
				Vector3 vector = Vector3.zero;
				int num2 = base.length;
				num2--;
				for (int i = num2; i > 0; i--)
				{
					Vector3 vector2 = this.m_dirs[num];
					Vector3 vector3 = this.m_dirs[siguienteIndex];
					vector += vector3 - vector2;
					num = SmoothItems<Vector3>.GoNext(ref siguienteIndex, base.length);
				}
				return vector / (float)num2;
			}
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0001FF94 File Offset: 0x0001E194
		public override Vector3 Suavizado(int maxCantidad)
		{
			if (!base.contieneAlgo)
			{
				throw new InvalidOperationException("no se puede hallar el promedio de ningun vector.");
			}
			int num = Mathf.Min(maxCantidad, base.length);
			int siguienteIndex = this.m_siguienteIndex;
			SmoothItems<Vector3>.GoPrevius(ref siguienteIndex, base.contenidos, base.length);
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < num; i++)
			{
				SmoothItems<Vector3>.GoPrevius(ref siguienteIndex, base.contenidos, base.length);
				try
				{
					vector += this.m_dirs[siguienteIndex];
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return vector / (float)num;
		}
	}
}
