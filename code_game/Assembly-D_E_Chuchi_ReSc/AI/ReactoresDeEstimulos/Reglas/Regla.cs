using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas
{
	// Token: 0x020003B6 RID: 950
	[Serializable]
	public class Regla : ICheckeadorDeCalculo, IEditorCheckeadorDeCalculo
	{
		// Token: 0x060014C0 RID: 5312 RVA: 0x00058F4C File Offset: 0x0005714C
		public bool Check(ICalculoDeEstimulo calculo)
		{
			bool flag = Regla.Check(this.invertida, this.tipo, this.items, calculo);
			this.lastResult = (flag ? 1 : (-1));
			return flag;
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x00058F80 File Offset: 0x00057180
		public static bool Check(bool invertida, Regla.Tipo tipo, IReadOnlyList<ICheckeadorDeCalculo> items, ICalculoDeEstimulo calculo)
		{
			bool flag;
			if (items != null && items.Count > 0)
			{
				if (items.Count == 1)
				{
					ICheckeadorDeCalculo checkeadorDeCalculo = items[0];
					flag = ((checkeadorDeCalculo != null) ? new bool?(checkeadorDeCalculo.Check(calculo)) : null).GetValueOrDefault(true);
				}
				else if (tipo != Regla.Tipo.and)
				{
					if (tipo != Regla.Tipo.or)
					{
						throw new ArgumentOutOfRangeException(tipo.ToString());
					}
					flag = false;
					for (int i = 0; i < items.Count; i++)
					{
						ICheckeadorDeCalculo checkeadorDeCalculo2 = items[i];
						if (((checkeadorDeCalculo2 != null) ? new bool?(checkeadorDeCalculo2.Check(calculo)) : null).GetValueOrDefault(false))
						{
							flag = true;
							break;
						}
					}
				}
				else
				{
					flag = true;
					for (int j = 0; j < items.Count; j++)
					{
						ICheckeadorDeCalculo checkeadorDeCalculo3 = items[j];
						if (!((checkeadorDeCalculo3 != null) ? new bool?(checkeadorDeCalculo3.Check(calculo)) : null).GetValueOrDefault(true))
						{
							flag = false;
							break;
						}
					}
				}
			}
			else
			{
				flag = true;
			}
			if (invertida)
			{
				return !flag;
			}
			return flag;
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0005908C File Offset: 0x0005728C
		void IEditorCheckeadorDeCalculo.BeforeChecking()
		{
			this.lastResult = 0;
		}

		// Token: 0x040010E9 RID: 4329
		public bool invertida;

		// Token: 0x040010EA RID: 4330
		public Regla.Tipo tipo;

		// Token: 0x040010EB RID: 4331
		[SerializeReference]
		public List<ReglaItem> items = new List<ReglaItem>();

		// Token: 0x040010EC RID: 4332
		public int lastResult;

		// Token: 0x020003B7 RID: 951
		public enum Tipo
		{
			// Token: 0x040010EE RID: 4334
			and,
			// Token: 0x040010EF RID: 4335
			or
		}
	}
}
