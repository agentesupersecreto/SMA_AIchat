using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E1 RID: 737
	public static class ICalculadorDeEstimuloCoitalEXT
	{
		// Token: 0x06001064 RID: 4196 RVA: 0x000492D0 File Offset: 0x000474D0
		public static void GetEstado(this ICalculoDeEstimuloCoital calculo, int index, out UmbralBasico.Estado estado)
		{
			if (calculo.vaginal != null && calculo.anal != null && calculo.facial != null)
			{
				ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.vaginal, calculo.anal, calculo.facial, index, out estado);
			}
			else
			{
				if (calculo.vaginal == null && calculo.anal == null && calculo.facial == null)
				{
					estado = default(UmbralBasico.Estado);
					return;
				}
				if (calculo.vaginal == null && calculo.anal != null && calculo.facial != null)
				{
					ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.anal, calculo.facial, index, out estado);
				}
				else if (calculo.vaginal != null && calculo.anal == null && calculo.facial != null)
				{
					ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.vaginal, calculo.facial, index, out estado);
				}
				else if (calculo.vaginal != null && calculo.anal != null && calculo.facial == null)
				{
					ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.vaginal, calculo.anal, index, out estado);
				}
				else if (calculo.vaginal == null && calculo.anal == null && calculo.facial != null)
				{
					ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.facial, index, out estado);
				}
				else if (calculo.vaginal == null && calculo.anal != null && calculo.facial == null)
				{
					ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.anal, index, out estado);
				}
				else if (calculo.vaginal != null && calculo.anal == null && calculo.facial == null)
				{
					ICalculadorDeEstimuloCoitalEXT.GetEstadoReference(calculo.vaginal, index, out estado);
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x00049438 File Offset: 0x00047638
		public static void SetEstado(this ICalculoDeEstimuloCoital calculo, int index, ref UmbralBasico.Estado estado)
		{
			if (calculo.vaginal != null && calculo.anal != null && calculo.facial != null)
			{
				ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.vaginal, calculo.anal, calculo.facial, index, ref estado);
			}
			else
			{
				if (calculo.vaginal == null && calculo.anal == null && calculo.facial == null)
				{
					return;
				}
				if (calculo.vaginal == null && calculo.anal != null && calculo.facial != null)
				{
					ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.anal, calculo.facial, index, ref estado);
				}
				else if (calculo.vaginal != null && calculo.anal == null && calculo.facial != null)
				{
					ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.vaginal, calculo.facial, index, ref estado);
				}
				else if (calculo.vaginal != null && calculo.anal != null && calculo.facial == null)
				{
					ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.vaginal, calculo.anal, index, ref estado);
				}
				else if (calculo.vaginal == null && calculo.anal == null && calculo.facial != null)
				{
					ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.facial, index, ref estado);
				}
				else if (calculo.vaginal == null && calculo.anal != null && calculo.facial == null)
				{
					ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.anal, index, ref estado);
				}
				else if (calculo.vaginal != null && calculo.anal == null && calculo.facial == null)
				{
					ICalculadorDeEstimuloCoitalEXT.SetEstadoReference(calculo.vaginal, index, ref estado);
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0004959C File Offset: 0x0004779C
		private static void GetEstadoReference(ICalculoDeEstimuloCoitalHole primero, ICalculoDeEstimuloCoitalHole segundo, ICalculoDeEstimuloCoitalHole tercero, int index, out UmbralBasico.Estado estado)
		{
			if (index >= primero.cantidadDeEstados + segundo.cantidadDeEstados)
			{
				tercero.GetEstadoCopia(index - (primero.cantidadDeEstados + segundo.cantidadDeEstados), out estado);
				return;
			}
			if (index >= primero.cantidadDeEstados)
			{
				segundo.GetEstadoCopia(index - primero.cantidadDeEstados, out estado);
				return;
			}
			primero.GetEstadoCopia(index, out estado);
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x000495F4 File Offset: 0x000477F4
		private static void GetEstadoReference(ICalculoDeEstimuloCoitalHole primero, ICalculoDeEstimuloCoitalHole segundo, int index, out UmbralBasico.Estado estado)
		{
			if (index >= primero.cantidadDeEstados)
			{
				segundo.GetEstadoCopia(index - primero.cantidadDeEstados, out estado);
				return;
			}
			primero.GetEstadoCopia(index, out estado);
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00049617 File Offset: 0x00047817
		private static void GetEstadoReference(ICalculoDeEstimuloCoitalHole primero, int index, out UmbralBasico.Estado estado)
		{
			primero.GetEstadoCopia(index, out estado);
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x00049624 File Offset: 0x00047824
		private static void SetEstadoReference(ICalculoDeEstimuloCoitalHole primero, ICalculoDeEstimuloCoitalHole segundo, ICalculoDeEstimuloCoitalHole tercero, int index, ref UmbralBasico.Estado estado)
		{
			if (index >= primero.cantidadDeEstados + segundo.cantidadDeEstados)
			{
				tercero.SobreEscribirEstado(index - (primero.cantidadDeEstados + segundo.cantidadDeEstados), ref estado);
				return;
			}
			if (index >= primero.cantidadDeEstados)
			{
				segundo.SobreEscribirEstado(index - primero.cantidadDeEstados, ref estado);
				return;
			}
			primero.SobreEscribirEstado(index, ref estado);
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x0004967C File Offset: 0x0004787C
		private static void SetEstadoReference(ICalculoDeEstimuloCoitalHole primero, ICalculoDeEstimuloCoitalHole segundo, int index, ref UmbralBasico.Estado estado)
		{
			if (index >= primero.cantidadDeEstados)
			{
				segundo.SobreEscribirEstado(index - primero.cantidadDeEstados, ref estado);
				return;
			}
			primero.SobreEscribirEstado(index, ref estado);
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x0004969F File Offset: 0x0004789F
		private static void SetEstadoReference(ICalculoDeEstimuloCoitalHole primero, int index, ref UmbralBasico.Estado estado)
		{
			primero.SobreEscribirEstado(index, ref estado);
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x000496AC File Offset: 0x000478AC
		[Obsolete("", true)]
		public static ICalculoDeEstimuloCoitalHole GetMasFuerte(this ICalculadorDeEstimuloCoital calculador)
		{
			ICalculoDeEstimuloCoital calculos = calculador.GetCalculos();
			if (calculos == null)
			{
				return null;
			}
			float? mas = ICalculadorDeEstimuloCoitalEXT.GetMas(calculos.anal);
			float? mas2 = ICalculadorDeEstimuloCoitalEXT.GetMas(calculos.vaginal);
			float? mas3 = ICalculadorDeEstimuloCoitalEXT.GetMas(calculos.facial);
			if (ICalculadorDeEstimuloCoitalEXT.MayorQue(mas, mas2) && ICalculadorDeEstimuloCoitalEXT.MayorQue(mas, mas3))
			{
				return calculos.anal;
			}
			if (ICalculadorDeEstimuloCoitalEXT.MayorQue(mas2, mas3) && ICalculadorDeEstimuloCoitalEXT.MayorQue(mas2, mas))
			{
				return calculos.vaginal;
			}
			if (ICalculadorDeEstimuloCoitalEXT.MayorQue(mas3, mas) && ICalculadorDeEstimuloCoitalEXT.MayorQue(mas3, mas2))
			{
				return calculos.facial;
			}
			throw new ArgumentOutOfRangeException("?????");
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x00049740 File Offset: 0x00047940
		[Obsolete("deben almacenarse tdas los calculos a la vez, osea, oral, vag, anal y sus sub estados, profundidad, anchura, etc, si no la meoria ni interacciones en scena funciona bien", true)]
		public static void GetMasFuerte(this ICalculadorDeEstimuloCoital calculador, out ICalculoDeEstimuloCoitalHole masFuerte, List<ICalculoDeEstimuloCoitalHole> masFuerteAlMasDebil)
		{
			try
			{
				masFuerteAlMasDebil.Clear();
				ICalculoDeEstimuloCoital calculos = calculador.GetCalculos();
				if (calculos == null)
				{
					masFuerte = null;
				}
				else
				{
					float? mas = ICalculadorDeEstimuloCoitalEXT.GetMas(calculos.anal);
					float? mas2 = ICalculadorDeEstimuloCoitalEXT.GetMas(calculos.vaginal);
					float? mas3 = ICalculadorDeEstimuloCoitalEXT.GetMas(calculos.facial);
					if (mas != null)
					{
						masFuerteAlMasDebil.Add(calculos.anal);
						ICalculadorDeEstimuloCoitalEXT.m_Comparer.puntanjes.Add(calculos.anal, mas.Value);
					}
					if (mas2 != null)
					{
						masFuerteAlMasDebil.Add(calculos.vaginal);
						ICalculadorDeEstimuloCoitalEXT.m_Comparer.puntanjes.Add(calculos.vaginal, mas2.Value);
					}
					if (mas3 != null)
					{
						masFuerteAlMasDebil.Add(calculos.facial);
						ICalculadorDeEstimuloCoitalEXT.m_Comparer.puntanjes.Add(calculos.facial, mas3.Value);
					}
					masFuerteAlMasDebil.Sort(ICalculadorDeEstimuloCoitalEXT.m_Comparer);
					if (masFuerteAlMasDebil.Count > 0)
					{
						masFuerte = masFuerteAlMasDebil[0];
					}
					else
					{
						masFuerte = null;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				ICalculadorDeEstimuloCoitalEXT.m_Comparer.puntanjes.Clear();
			}
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x00049870 File Offset: 0x00047A70
		[Obsolete("deben almacenarse tdas los calculos a la vez, osea, oral, vag, anal y sus sub estados, profundidad, anchura, etc, si no la meoria ni interacciones en scena funciona bien", true)]
		private static float? GetMas(ICalculoDeEstimuloCoitalHole calc)
		{
			if (calc == null)
			{
				return null;
			}
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			calc.GetMasFuerte(out estado);
			return new float?(estado.estimulacionGeneradaEnFrame);
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x000498A6 File Offset: 0x00047AA6
		private static bool MayorQue(float? a, float? b)
		{
			return a != null && (b == null || a.Value >= b.Value);
		}

		// Token: 0x04000D7A RID: 3450
		private static ICalculadorDeEstimuloCoitalEXT.Comparer m_Comparer = new ICalculadorDeEstimuloCoitalEXT.Comparer();

		// Token: 0x020002E2 RID: 738
		private class Comparer : IComparer<ICalculoDeEstimuloCoitalHole>
		{
			// Token: 0x06001071 RID: 4209 RVA: 0x000498E0 File Offset: 0x00047AE0
			public int Compare(ICalculoDeEstimuloCoitalHole x, ICalculoDeEstimuloCoitalHole y)
			{
				float num = this.puntanjes[x];
				float num2 = this.puntanjes[y];
				return -1 * num.CompareTo(num2);
			}

			// Token: 0x04000D7B RID: 3451
			public Dictionary<ICalculoDeEstimuloCoitalHole, float> puntanjes = new Dictionary<ICalculoDeEstimuloCoitalHole, float>();
		}
	}
}
