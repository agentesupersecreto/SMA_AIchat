using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x0200015F RID: 351
	public class ParteDelCuerpoHumanoPrioridadesOnlyFixed : IParteDelCuerpoHumanoPrioridades
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00022F6D File Offset: 0x0002116D
		public static ParteDelCuerpoHumanoPrioridadesOnlyFixed instanceMasulina
		{
			get
			{
				if (ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceMasulina == null)
				{
					ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceMasulina = new ParteDelCuerpoHumanoPrioridadesOnlyFixed();
					ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceMasulina.para = Sexo.masculino;
				}
				return ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceMasulina;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x00022F90 File Offset: 0x00021190
		public static ParteDelCuerpoHumanoPrioridadesOnlyFixed instanceFemenina
		{
			get
			{
				if (ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceFemenina == null)
				{
					ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceFemenina = new ParteDelCuerpoHumanoPrioridadesOnlyFixed();
					ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceFemenina.para = Sexo.femenino;
				}
				return ParteDelCuerpoHumanoPrioridadesOnlyFixed.m_instanceFemenina;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00022FB3 File Offset: 0x000211B3
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x00022FBB File Offset: 0x000211BB
		public Sexo para { get; set; }

		// Token: 0x06000A55 RID: 2645 RVA: 0x00022FC4 File Offset: 0x000211C4
		public IParteDelCuerpoHumanoPrioridadesContexto ObtenerContexto(PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			Sexo para = this.para;
			if (para == Sexo.masculino)
			{
				return ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			if (para != Sexo.femenino)
			{
				throw new ArgumentOutOfRangeException(this.para.ToString());
			}
			return ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00023008 File Offset: 0x00021208
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.ObtenerLaDeMayorPrioridadCoital(list);
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00023058 File Offset: 0x00021258
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.ObtenerLaDeMayorPrioridadTactil(list);
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x000230A8 File Offset: 0x000212A8
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.ObtenerLaDeMayorPrioridadVisual(list);
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x000230F8 File Offset: 0x000212F8
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.ObtenerLaDeMenorPrioridadCoital(list);
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00023148 File Offset: 0x00021348
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.ObtenerLaDeMenorPrioridadTactil(list);
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00023198 File Offset: 0x00021398
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.ObtenerLaDeMenorPrioridadVisual(list);
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x000231E8 File Offset: 0x000213E8
		public float PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.PrioridadCoital(parte);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00023238 File Offset: 0x00021438
		public float PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.PrioridadTactil(parte);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00023288 File Offset: 0x00021488
		public float PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte)
		{
			Sexo para = this.para;
			ParteDelCuerpoHumanoPrioridadesFixed parteDelCuerpoHumanoPrioridadesFixed;
			if (para != Sexo.masculino)
			{
				if (para != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(this.para.ToString());
				}
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceFemenina;
			}
			else
			{
				parteDelCuerpoHumanoPrioridadesFixed = ParteDelCuerpoHumanoPrioridadesFixed.instanceMasulina;
			}
			return parteDelCuerpoHumanoPrioridadesFixed.PrioridadVisual(parte);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x000232D7 File Offset: 0x000214D7
		public void UpdatePrioridades()
		{
		}

		// Token: 0x04000339 RID: 825
		private static ParteDelCuerpoHumanoPrioridadesOnlyFixed m_instanceMasulina;

		// Token: 0x0400033A RID: 826
		private static ParteDelCuerpoHumanoPrioridadesOnlyFixed m_instanceFemenina;
	}
}
