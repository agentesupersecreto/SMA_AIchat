using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000160 RID: 352
	public class ParteDelCuerpoHumanoPrioridadesFixed : IParteDelCuerpoHumanoPrioridadesContexto
	{
		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x000232E1 File Offset: 0x000214E1
		public static ParteDelCuerpoHumanoPrioridadesFixed instanceMasulina
		{
			get
			{
				if (ParteDelCuerpoHumanoPrioridadesFixed.m_instanceMasulina == null)
				{
					ParteDelCuerpoHumanoPrioridadesFixed.m_instanceMasulina = new ParteDelCuerpoHumanoPrioridadesFixed();
					ParteDelCuerpoHumanoPrioridadesFixed.m_instanceMasulina.para = Sexo.masculino;
				}
				return ParteDelCuerpoHumanoPrioridadesFixed.m_instanceMasulina;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000A62 RID: 2658 RVA: 0x00023304 File Offset: 0x00021504
		public static ParteDelCuerpoHumanoPrioridadesFixed instanceFemenina
		{
			get
			{
				if (ParteDelCuerpoHumanoPrioridadesFixed.m_instanceFemenina == null)
				{
					ParteDelCuerpoHumanoPrioridadesFixed.m_instanceFemenina = new ParteDelCuerpoHumanoPrioridadesFixed();
					ParteDelCuerpoHumanoPrioridadesFixed.m_instanceFemenina.para = Sexo.femenino;
				}
				return ParteDelCuerpoHumanoPrioridadesFixed.m_instanceFemenina;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00023327 File Offset: 0x00021527
		public PrioridadDeParteDelCuerpoHumanoContexto contexto
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.@fixed;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000A64 RID: 2660 RVA: 0x0002332A File Offset: 0x0002152A
		// (set) Token: 0x06000A65 RID: 2661 RVA: 0x00023332 File Offset: 0x00021532
		public Sexo para { get; set; }

		// Token: 0x06000A66 RID: 2662 RVA: 0x0002333B File Offset: 0x0002153B
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return list.ObtenerLaDeMayorPrioridadCoitalFixed(this.para);
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x00023349 File Offset: 0x00021549
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return list.ObtenerLaDeMayorPrioridadTactilFixed(this.para);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00023357 File Offset: 0x00021557
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return list.ObtenerLaDeMayorPrioridadVisualFixed(this.para);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00023365 File Offset: 0x00021565
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return list.ObtenerLaDeMenorPrioridadCoitalFixed(this.para);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00023373 File Offset: 0x00021573
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return list.ObtenerLaDeMenorPrioridadTactilFixed(this.para);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x00023381 File Offset: 0x00021581
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return list.ObtenerLaDeMenorPrioridadVisualFixed(this.para);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0002338F File Offset: 0x0002158F
		public float PrioridadCoital(ParteDelCuerpoHumano parte)
		{
			return (float)parte.PrioridadCoitalFixed(this.para);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0002339E File Offset: 0x0002159E
		public float PrioridadTactil(ParteDelCuerpoHumano parte)
		{
			return (float)parte.PrioridadTactilFixed(this.para);
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x000233AD File Offset: 0x000215AD
		public float PrioridadVisual(ParteDelCuerpoHumano parte)
		{
			return (float)parte.PrioridadVisualFixed(this.para);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x000233BC File Offset: 0x000215BC
		public void UpdatePrioridades()
		{
		}

		// Token: 0x0400033C RID: 828
		private static ParteDelCuerpoHumanoPrioridadesFixed m_instanceMasulina;

		// Token: 0x0400033D RID: 829
		private static ParteDelCuerpoHumanoPrioridadesFixed m_instanceFemenina;
	}
}
