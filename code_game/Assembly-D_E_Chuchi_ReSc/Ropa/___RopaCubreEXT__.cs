using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000E5 RID: 229
	public static class ___RopaCubreEXT__
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x00019F44 File Offset: 0x00018144
		public static ParteDelCuerpoHumano ParceToParteDelCuerpoHumano(this RopaCubre cubre)
		{
			if (cubre <= RopaCubre.pies)
			{
				if (cubre <= RopaCubre.canillas)
				{
					if (cubre <= RopaCubre.nalgas)
					{
						switch (cubre)
						{
						case RopaCubre.None:
							throw new NotSupportedException("verificar que RopaCubre no sea none antes de hacer el parce");
						case RopaCubre.pectorales:
							return ParteDelCuerpoHumano.senos;
						case RopaCubre.pezones:
							return ParteDelCuerpoHumano.pezones;
						case RopaCubre.pectorales | RopaCubre.pezones:
						case RopaCubre.pectorales | RopaCubre.labiosVaginales:
						case RopaCubre.pezones | RopaCubre.labiosVaginales:
						case RopaCubre.pectorales | RopaCubre.pezones | RopaCubre.labiosVaginales:
							break;
						case RopaCubre.labiosVaginales:
							return ParteDelCuerpoHumano.labiosVaginales;
						case RopaCubre.vaginaHole:
							return ParteDelCuerpoHumano.vag;
						default:
							if (cubre == RopaCubre.nalgas)
							{
								return ParteDelCuerpoHumano.nalgas;
							}
							break;
						}
					}
					else
					{
						if (cubre == RopaCubre.ano)
						{
							return ParteDelCuerpoHumano.ano;
						}
						if (cubre == RopaCubre.piernas)
						{
							return ParteDelCuerpoHumano.piernas;
						}
						if (cubre == RopaCubre.canillas)
						{
							return ParteDelCuerpoHumano.canillas;
						}
					}
				}
				else if (cubre <= RopaCubre.bocaHole)
				{
					if (cubre == RopaCubre.brazos)
					{
						return ParteDelCuerpoHumano.brazos;
					}
					if (cubre == RopaCubre.anteBrazos)
					{
						return ParteDelCuerpoHumano.anteBrazos;
					}
					if (cubre == RopaCubre.bocaHole)
					{
						return ParteDelCuerpoHumano.bocaInterno;
					}
				}
				else
				{
					if (cubre == RopaCubre.pene)
					{
						return ParteDelCuerpoHumano.pene;
					}
					if (cubre == RopaCubre.testiculos)
					{
						return ParteDelCuerpoHumano.testiculos;
					}
					if (cubre == RopaCubre.pies)
					{
						return ParteDelCuerpoHumano.pies;
					}
				}
			}
			else if (cubre <= RopaCubre.hombros)
			{
				if (cubre <= RopaCubre.vientreBajo)
				{
					if (cubre == RopaCubre.manos)
					{
						return ParteDelCuerpoHumano.manos;
					}
					if (cubre == RopaCubre.vientreBajo)
					{
						return ParteDelCuerpoHumano.vientreBajo;
					}
				}
				else
				{
					if (cubre == RopaCubre.labios)
					{
						return ParteDelCuerpoHumano.labios;
					}
					if (cubre == RopaCubre.ojos)
					{
						return ParteDelCuerpoHumano.ojos;
					}
					if (cubre == RopaCubre.hombros)
					{
						return ParteDelCuerpoHumano.hombros;
					}
				}
			}
			else if (cubre <= RopaCubre.torzo)
			{
				if (cubre == RopaCubre.belly)
				{
					return ParteDelCuerpoHumano.vientre;
				}
				if (cubre == RopaCubre.rostro)
				{
					return ParteDelCuerpoHumano.mejillas;
				}
				if (cubre == RopaCubre.torzo)
				{
					return ParteDelCuerpoHumano.pecho;
				}
			}
			else
			{
				if (cubre == RopaCubre.cuello)
				{
					return ParteDelCuerpoHumano.cuello;
				}
				if (cubre == RopaCubre.espalda)
				{
					return ParteDelCuerpoHumano.espalda;
				}
				if (cubre == RopaCubre.cabeza)
				{
					return ParteDelCuerpoHumano.cabeza;
				}
			}
			throw new ArgumentOutOfRangeException(cubre.ToString());
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0001A104 File Offset: 0x00018304
		public static RopaCubre ListToFlags(this IList<RopaCubre> list)
		{
			RopaCubre ropaCubre = RopaCubre.None;
			for (int i = 0; i < list.Count; i++)
			{
				ropaCubre |= list[i];
			}
			return ropaCubre;
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001A130 File Offset: 0x00018330
		public static RopaCubre ListToFlagsReadOnly(this IReadOnlyList<RopaCubre> list)
		{
			RopaCubre ropaCubre = RopaCubre.None;
			for (int i = 0; i < list.Count; i++)
			{
				ropaCubre |= list[i];
			}
			return ropaCubre;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001A15C File Offset: 0x0001835C
		public static RopaCubre ListToFlags(this ICollection<int> list)
		{
			RopaCubre ropaCubre = RopaCubre.None;
			foreach (int num in list)
			{
				ropaCubre |= (RopaCubre)num;
			}
			return ropaCubre;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0001A1A4 File Offset: 0x000183A4
		public static void FlagsToList(this RopaCubre flags, ICollection<RopaCubre> result)
		{
			foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
			{
				if (((int)flags).HasFlag(num))
				{
					result.Add((RopaCubre)num);
				}
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001A204 File Offset: 0x00018404
		public static void FlagsToList(this RopaCubre flags, ICollection<ParteDelCuerpoHumano> result)
		{
			foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
			{
				if (((int)flags).HasFlag(num))
				{
					result.Add(((RopaCubre)num).ParceToParteDelCuerpoHumano());
				}
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0001A268 File Offset: 0x00018468
		public static void FlagsToCollectionDeParteDelCuerpoHumano(this RopaCubre flags, ICollection<int> result)
		{
			foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
			{
				if (((int)flags).HasFlag(num))
				{
					result.Add((int)((RopaCubre)num).ParceToParteDelCuerpoHumano());
				}
			}
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001A2CC File Offset: 0x000184CC
		public static RopaCubre ObtenerLaDeMenorPrioridad(this RopaCubre flags, Sexo sexo)
		{
			RopaCubre ropaCubre;
			try
			{
				foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
				{
					if (((int)flags).HasFlag(num))
					{
						___RopaCubreEXT__.m_temp.Add(num);
					}
				}
				ropaCubre = ___RopaCubreEXT__.m_temp.ObtenerLaDeMenorPrioridad(sexo);
			}
			finally
			{
				___RopaCubreEXT__.m_temp.Clear();
			}
			return ropaCubre;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001A358 File Offset: 0x00018558
		public static RopaCubre FiltrarFlags(this RopaCubre flags, Sexo sexo)
		{
			if (sexo == Sexo.masculino)
			{
				return flags & ~(RopaCubre.labiosVaginales | RopaCubre.vaginaHole);
			}
			if (sexo != Sexo.femenino)
			{
				throw new ArgumentOutOfRangeException(sexo.ToString());
			}
			return flags & ~(RopaCubre.pene | RopaCubre.testiculos);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0001A384 File Offset: 0x00018584
		public static RopaCubre ObtenerLaDeMayorPrioridad(this RopaCubre flags, Sexo sexo)
		{
			RopaCubre ropaCubre;
			try
			{
				foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
				{
					if (((int)flags).HasFlag(num))
					{
						___RopaCubreEXT__.m_temp.Add(num);
					}
				}
				ropaCubre = ___RopaCubreEXT__.m_temp.ObtenerLaDeMayorPrioridad(sexo);
			}
			finally
			{
				___RopaCubreEXT__.m_temp.Clear();
			}
			return ropaCubre;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0001A410 File Offset: 0x00018610
		public static RopaCubre ObtenerLaDeMayorPrioridad(this ICollection<RopaCubre> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (sexo == Sexo.femenino)
			{
				if (list.Contains(RopaCubre.vaginaHole))
				{
					return RopaCubre.vaginaHole;
				}
				if (list.Contains(RopaCubre.labiosVaginales))
				{
					return RopaCubre.labiosVaginales;
				}
			}
			if (list.Contains(RopaCubre.ano))
			{
				return RopaCubre.ano;
			}
			if (list.Contains(RopaCubre.vientreBajo))
			{
				return RopaCubre.vientreBajo;
			}
			if (sexo == Sexo.masculino)
			{
				if (list.Contains(RopaCubre.testiculos))
				{
					return RopaCubre.testiculos;
				}
				if (list.Contains(RopaCubre.pene))
				{
					return RopaCubre.pene;
				}
			}
			if (list.Contains(RopaCubre.pezones))
			{
				return RopaCubre.pezones;
			}
			if (list.Contains(RopaCubre.pectorales))
			{
				return RopaCubre.pectorales;
			}
			if (list.Contains(RopaCubre.nalgas))
			{
				return RopaCubre.nalgas;
			}
			if (list.Contains(RopaCubre.vientreBajo))
			{
				return RopaCubre.vientreBajo;
			}
			if (list.Contains(RopaCubre.bocaHole))
			{
				return RopaCubre.bocaHole;
			}
			if (list.Contains(RopaCubre.labios))
			{
				return RopaCubre.labios;
			}
			if (list.Contains(RopaCubre.cuello))
			{
				return RopaCubre.cuello;
			}
			if (list.Contains(RopaCubre.ojos))
			{
				return RopaCubre.ojos;
			}
			if (list.Contains(RopaCubre.rostro))
			{
				return RopaCubre.rostro;
			}
			if (list.Contains(RopaCubre.belly))
			{
				return RopaCubre.belly;
			}
			if (list.Contains(RopaCubre.piernas))
			{
				return RopaCubre.piernas;
			}
			if (list.Contains(RopaCubre.hombros))
			{
				return RopaCubre.hombros;
			}
			return list.First<RopaCubre>();
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001A560 File Offset: 0x00018760
		public static RopaCubre ObtenerLaDeMayorPrioridad(this ICollection<int> set, Sexo sexo)
		{
			if (set.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (sexo == Sexo.femenino)
			{
				if (set.Contains(8))
				{
					return RopaCubre.vaginaHole;
				}
				if (set.Contains(4))
				{
					return RopaCubre.labiosVaginales;
				}
			}
			if (set.Contains(32))
			{
				return RopaCubre.ano;
			}
			if (set.Contains(32768))
			{
				return RopaCubre.vientreBajo;
			}
			if (sexo == Sexo.masculino)
			{
				if (set.Contains(4096))
				{
					return RopaCubre.testiculos;
				}
				if (set.Contains(2048))
				{
					return RopaCubre.pene;
				}
			}
			if (set.Contains(2))
			{
				return RopaCubre.pezones;
			}
			if (set.Contains(1))
			{
				return RopaCubre.pectorales;
			}
			if (set.Contains(16))
			{
				return RopaCubre.nalgas;
			}
			if (set.Contains(32768))
			{
				return RopaCubre.vientreBajo;
			}
			if (set.Contains(1024))
			{
				return RopaCubre.bocaHole;
			}
			if (set.Contains(65536))
			{
				return RopaCubre.labios;
			}
			if (set.Contains(4194304))
			{
				return RopaCubre.cuello;
			}
			if (set.Contains(131072))
			{
				return RopaCubre.ojos;
			}
			if (set.Contains(1048576))
			{
				return RopaCubre.rostro;
			}
			if (set.Contains(524288))
			{
				return RopaCubre.belly;
			}
			if (set.Contains(64))
			{
				return RopaCubre.piernas;
			}
			if (set.Contains(262144))
			{
				return RopaCubre.hombros;
			}
			return (RopaCubre)set.First<int>();
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0001A6B0 File Offset: 0x000188B0
		public static RopaCubre ObtenerLaDeMenorPrioridad(this ICollection<int> set, Sexo sexo)
		{
			if (set.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (set.Contains(131072))
			{
				return RopaCubre.ojos;
			}
			if (set.Contains(16777216))
			{
				return RopaCubre.cabeza;
			}
			if (set.Contains(1048576))
			{
				return RopaCubre.rostro;
			}
			if (set.Contains(2097152))
			{
				return RopaCubre.torzo;
			}
			if (set.Contains(8388608))
			{
				return RopaCubre.espalda;
			}
			if (set.Contains(65536))
			{
				return RopaCubre.labios;
			}
			if (set.Contains(1024))
			{
				return RopaCubre.bocaHole;
			}
			if (set.Contains(16384))
			{
				return RopaCubre.manos;
			}
			if (set.Contains(262144))
			{
				return RopaCubre.hombros;
			}
			if (set.Contains(512))
			{
				return RopaCubre.anteBrazos;
			}
			if (set.Contains(128))
			{
				return RopaCubre.canillas;
			}
			if (set.Contains(256))
			{
				return RopaCubre.brazos;
			}
			if (set.Contains(4194304))
			{
				return RopaCubre.cuello;
			}
			if (set.Contains(8192))
			{
				return RopaCubre.pies;
			}
			if (set.Contains(64))
			{
				return RopaCubre.piernas;
			}
			if (set.Contains(524288))
			{
				return RopaCubre.belly;
			}
			if (set.Contains(1))
			{
				return RopaCubre.pectorales;
			}
			if (set.Contains(16))
			{
				return RopaCubre.nalgas;
			}
			if (set.Contains(32768))
			{
				return RopaCubre.vientreBajo;
			}
			if (set.Contains(2))
			{
				return RopaCubre.pezones;
			}
			if (set.Contains(32))
			{
				return RopaCubre.ano;
			}
			if (sexo == Sexo.femenino)
			{
				if (set.Contains(4))
				{
					return RopaCubre.labiosVaginales;
				}
				if (set.Contains(8))
				{
					return RopaCubre.vaginaHole;
				}
			}
			if (sexo == Sexo.masculino)
			{
				if (set.Contains(2048))
				{
					return RopaCubre.pene;
				}
				if (set.Contains(4096))
				{
					return RopaCubre.testiculos;
				}
			}
			return (RopaCubre)set.First<int>();
		}

		// Token: 0x040003BC RID: 956
		private static HashSet<int> m_temp = new HashSet<int>();
	}
}
