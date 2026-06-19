using System;
using System.Collections.Generic;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Prioridades
{
	// Token: 0x020003CD RID: 973
	public class PrioridadesDePartesDelCuerpoHumano : CustomMonobehaviour, IParteDelCuerpoHumanoPrioridades
	{
		// Token: 0x060014FA RID: 5370 RVA: 0x00059890 File Offset: 0x00057A90
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridad(IReadOnlyList<ParteDelCuerpoHumano> list, IReadOnlyDictionary<int, float> prioridades)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			float num = prioridades[(int)parteDelCuerpoHumano];
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				float num2 = prioridades[(int)parteDelCuerpoHumano2];
				if (num2 < num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x000598E0 File Offset: 0x00057AE0
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridad(IReadOnlyList<ParteDelCuerpoHumano> list, IReadOnlyDictionary<int, float> prioridades)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			float num = prioridades[(int)parteDelCuerpoHumano];
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				float num2 = prioridades[(int)parteDelCuerpoHumano2];
				if (num2 > num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x00059930 File Offset: 0x00057B30
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridad(IReadOnlyList<ParteDelCuerpoHumano> list, Func<ParteDelCuerpoHumano, float> prioridadGetter)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			float num = prioridadGetter(parteDelCuerpoHumano);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				float num2 = prioridadGetter(parteDelCuerpoHumano2);
				if (num2 < num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x00059980 File Offset: 0x00057B80
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridad(IReadOnlyList<ParteDelCuerpoHumano> list, Func<ParteDelCuerpoHumano, float> prioridadGetter)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			float num = prioridadGetter(parteDelCuerpoHumano);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				float num2 = prioridadGetter(parteDelCuerpoHumano2);
				if (num2 > num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060014FE RID: 5374 RVA: 0x000599CF File Offset: 0x00057BCF
		private IParteDelCuerpoHumanoPrioridadesContexto erogeno
		{
			get
			{
				return this.m_erogeno as IParteDelCuerpoHumanoPrioridadesContexto;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060014FF RID: 5375 RVA: 0x000599DC File Offset: 0x00057BDC
		private IParteDelCuerpoHumanoPrioridadesContexto sensible
		{
			get
			{
				return this.m_sensible as IParteDelCuerpoHumanoPrioridadesContexto;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06001500 RID: 5376 RVA: 0x000599E9 File Offset: 0x00057BE9
		private IParteDelCuerpoHumanoPrioridadesContexto privado
		{
			get
			{
				return this.m_privado as IParteDelCuerpoHumanoPrioridadesContexto;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06001501 RID: 5377 RVA: 0x000599F6 File Offset: 0x00057BF6
		// (set) Token: 0x06001502 RID: 5378 RVA: 0x000599FE File Offset: 0x00057BFE
		public Sexo para { get; set; }

		// Token: 0x06001503 RID: 5379 RVA: 0x00059A08 File Offset: 0x00057C08
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.erogeno == null)
			{
				throw new ArgumentNullException("erogeno", "erogeno null reference.");
			}
			if (this.sensible == null)
			{
				throw new ArgumentNullException("sensible", "sensible null reference.");
			}
			if (this.privado == null)
			{
				throw new ArgumentNullException("privado", "privado null reference.");
			}
			this.para = this.GetComponentEnRoot(false).sexo;
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x00059A75 File Offset: 0x00057C75
		public void UpdatePrioridades()
		{
			this.erogeno.UpdatePrioridades();
			this.sensible.UpdatePrioridades();
			this.privado.UpdatePrioridades();
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x00059A98 File Offset: 0x00057C98
		public IParteDelCuerpoHumanoPrioridadesContexto ObtenerContexto(PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			switch (contexto)
			{
			case PrioridadDeParteDelCuerpoHumanoContexto.@fixed:
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
			case PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor:
				return this.erogeno;
			case PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor:
				return this.sensible;
			case PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor:
				return this.privado;
			default:
				throw new ArgumentOutOfRangeException(contexto.ToString());
			}
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x00059B1B File Offset: 0x00057D1B
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return this.ObtenerContexto(contexto).ObtenerLaDeMayorPrioridadVisual(list);
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x00059B2A File Offset: 0x00057D2A
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return this.ObtenerContexto(contexto).ObtenerLaDeMenorPrioridadVisual(list);
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x00059B39 File Offset: 0x00057D39
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return this.ObtenerContexto(contexto).ObtenerLaDeMayorPrioridadTactil(list);
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x00059B48 File Offset: 0x00057D48
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return this.ObtenerContexto(contexto).ObtenerLaDeMenorPrioridadTactil(list);
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x00059B57 File Offset: 0x00057D57
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return this.ObtenerContexto(contexto).ObtenerLaDeMayorPrioridadCoital(list);
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x00059B66 File Offset: 0x00057D66
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, IReadOnlyList<ParteDelCuerpoHumano> list = null)
		{
			return this.ObtenerContexto(contexto).ObtenerLaDeMenorPrioridadCoital(list);
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x00059B75 File Offset: 0x00057D75
		public float PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte)
		{
			return this.ObtenerContexto(contexto).PrioridadVisual(parte);
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x00059B84 File Offset: 0x00057D84
		public float PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte)
		{
			return this.ObtenerContexto(contexto).PrioridadTactil(parte);
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x00059B93 File Offset: 0x00057D93
		public float PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto contexto, ParteDelCuerpoHumano parte)
		{
			return this.ObtenerContexto(contexto).PrioridadCoital(parte);
		}

		// Token: 0x04001105 RID: 4357
		[ConstraintType(typeof(IParteDelCuerpoHumanoPrioridadesContexto), true)]
		[SerializeField]
		private Object m_erogeno;

		// Token: 0x04001106 RID: 4358
		[ConstraintType(typeof(IParteDelCuerpoHumanoPrioridadesContexto), true)]
		[SerializeField]
		private Object m_sensible;

		// Token: 0x04001108 RID: 4360
		[ConstraintType(typeof(IParteDelCuerpoHumanoPrioridadesContexto), true)]
		[SerializeField]
		private Object m_privado;
	}
}
