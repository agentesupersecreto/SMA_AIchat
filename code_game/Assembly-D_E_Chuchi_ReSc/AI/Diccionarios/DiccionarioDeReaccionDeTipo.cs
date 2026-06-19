using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Diccionarios
{
	// Token: 0x02000377 RID: 887
	[Obsolete]
	[CreateAssetMenu(fileName = "DiccionarioDeReaccionDeTipo", menuName = "Objetos/Diccionarios/Diccionario De Reaccion De Tipo")]
	public class DiccionarioDeReaccionDeTipo : DiccionarioDeReaccionBase<DiccionarioDeReaccionDeTipo.LineaDeTexto>
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06001345 RID: 4933 RVA: 0x0005344D File Offset: 0x0005164D
		// (set) Token: 0x06001346 RID: 4934 RVA: 0x00053455 File Offset: 0x00051655
		public override List<DiccionarioDeReaccionDeTipo.LineaDeTexto> lineasDeTexto
		{
			get
			{
				return this.lineas;
			}
			protected set
			{
				this.lineas = value;
			}
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x0005345E File Offset: 0x0005165E
		protected override DiccionarioDeReaccionDeTipo.LineaDeTexto ObtenerNuevaInstancia(string text)
		{
			return new DiccionarioDeReaccionDeTipo.LineaDeTexto(text);
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x00053468 File Offset: 0x00051668
		[Obsolete]
		public static bool Contiene(List<DiccionarioDeReaccionDeTipo> diccs, EstimuloTipo tipo1, EstimuloTipo2 tipo2, PartesHumanasParaAi parte)
		{
			for (int i = 0; i < diccs.Count; i++)
			{
				if (diccs[i].Contiene(tipo1, tipo2, parte))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x0005349C File Offset: 0x0005169C
		[Obsolete]
		public static string Obtener(List<DiccionarioDeReaccionDeTipo> diccs, EstimuloTipo tipo1, EstimuloTipo2 tipo2, PartesHumanasParaAi parte)
		{
			DiccionarioDeReaccionDeTipo.LineaDeTexto lineaDeTexto = null;
			float minValue = float.MinValue;
			for (int i = 0; i < diccs.Count; i++)
			{
				DiccionarioDeReaccionDeTipo.Obtener(diccs[i], tipo1, tipo2, ref lineaDeTexto, ref minValue, parte);
			}
			if (lineaDeTexto == null)
			{
				return null;
			}
			return lineaDeTexto.texto;
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x000534E0 File Offset: 0x000516E0
		[Obsolete]
		public string Obtener(EstimuloTipo tipo1, EstimuloTipo2 tipo2, PartesHumanasParaAi parte)
		{
			DiccionarioDeReaccionDeTipo.LineaDeTexto lineaDeTexto = null;
			float minValue = float.MinValue;
			DiccionarioDeReaccionDeTipo.Obtener(this, tipo1, tipo2, ref lineaDeTexto, ref minValue, parte);
			if (lineaDeTexto == null)
			{
				return null;
			}
			return lineaDeTexto.texto;
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x00053510 File Offset: 0x00051710
		private static void Obtener(DiccionarioDeReaccionDeTipo dic, EstimuloTipo tipo1, EstimuloTipo2 tipo2, ref DiccionarioDeReaccionDeTipo.LineaDeTexto max, ref float maxScore, PartesHumanasParaAi parte)
		{
			if (!dic.Contiene(tipo1, tipo2, parte))
			{
				return;
			}
			for (int i = 0; i < dic.lineas.Count; i++)
			{
				DiccionarioDeReaccionDeTipo.LineaDeTexto lineaDeTexto = dic.lineas[i];
				if (((int)lineaDeTexto.flags1).HasFlag((int)tipo1) && ((int)lineaDeTexto.flags2).HasFlag((int)tipo2) && (!lineaDeTexto.partFilter.use || lineaDeTexto.partFilter.partes.Count <= 0 || lineaDeTexto.partFilter.partes.Contains(parte)))
				{
					float num = lineaDeTexto.Score();
					if (num > maxScore)
					{
						maxScore = num;
						max = lineaDeTexto;
					}
				}
			}
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x000535B4 File Offset: 0x000517B4
		[Obsolete]
		private static void InitFlags2(ref HashSet<DiccionarioDeReaccionDeTipo.Tuple2> flagsQueContiene, List<DiccionarioDeReaccionDeTipo.LineaDeTexto> lineas)
		{
			if (flagsQueContiene == null)
			{
				flagsQueContiene = new HashSet<DiccionarioDeReaccionDeTipo.Tuple2>();
				Array enumValores = typeof(EstimuloTipo).GetEnumValores();
				Array enumValores2 = typeof(EstimuloTipo2).GetEnumValores();
				foreach (DiccionarioDeReaccionDeTipo.LineaDeTexto lineaDeTexto in lineas)
				{
					if (lineaDeTexto.partFilter.use && lineaDeTexto.partFilter.partes.Count != 0)
					{
						foreach (object obj in enumValores)
						{
							EstimuloTipo estimuloTipo = (EstimuloTipo)obj;
							if (((int)lineaDeTexto.flags1).HasFlag((int)estimuloTipo))
							{
								foreach (object obj2 in enumValores2)
								{
									EstimuloTipo2 estimuloTipo2 = (EstimuloTipo2)obj2;
									if (((int)lineaDeTexto.flags2).HasFlag((int)estimuloTipo2))
									{
										foreach (PartesHumanasParaAi partesHumanasParaAi in lineaDeTexto.partFilter.partes)
										{
											DiccionarioDeReaccionDeTipo.Tuple2 tuple = default(DiccionarioDeReaccionDeTipo.Tuple2);
											tuple.flags1 = (int)estimuloTipo;
											tuple.flags2 = (int)estimuloTipo2;
											tuple.flags3 = (int)partesHumanasParaAi;
											flagsQueContiene.Add(tuple);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x000537A8 File Offset: 0x000519A8
		[Obsolete]
		private static void InitFlags1(ref HashSet<DiccionarioDeReaccionDeTipo.Tuple> flagsQueContiene, List<DiccionarioDeReaccionDeTipo.LineaDeTexto> lineas)
		{
			if (flagsQueContiene == null)
			{
				flagsQueContiene = new HashSet<DiccionarioDeReaccionDeTipo.Tuple>();
				Array enumValores = typeof(EstimuloTipo).GetEnumValores();
				Array enumValores2 = typeof(EstimuloTipo2).GetEnumValores();
				foreach (DiccionarioDeReaccionDeTipo.LineaDeTexto lineaDeTexto in lineas)
				{
					if (!lineaDeTexto.partFilter.use)
					{
						foreach (object obj in enumValores)
						{
							EstimuloTipo estimuloTipo = (EstimuloTipo)obj;
							if (((int)lineaDeTexto.flags1).HasFlag((int)estimuloTipo))
							{
								foreach (object obj2 in enumValores2)
								{
									EstimuloTipo2 estimuloTipo2 = (EstimuloTipo2)obj2;
									if (((int)lineaDeTexto.flags2).HasFlag((int)estimuloTipo2))
									{
										DiccionarioDeReaccionDeTipo.Tuple tuple = default(DiccionarioDeReaccionDeTipo.Tuple);
										tuple.flags1 = (int)estimuloTipo;
										tuple.flags2 = (int)estimuloTipo2;
										flagsQueContiene.Add(tuple);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x00053904 File Offset: 0x00051B04
		[Obsolete]
		public bool Contiene(EstimuloTipo tipo1, EstimuloTipo2 tipo2, PartesHumanasParaAi parte)
		{
			DiccionarioDeReaccionDeTipo.InitFlags1(ref this.flagsQueContiene, this.lineas);
			DiccionarioDeReaccionDeTipo.Tuple tuple = default(DiccionarioDeReaccionDeTipo.Tuple);
			tuple.flags1 = (int)tipo1;
			tuple.flags2 = (int)tipo2;
			if (this.flagsQueContiene.Contains(tuple))
			{
				return true;
			}
			DiccionarioDeReaccionDeTipo.InitFlags2(ref this.flagsQueContiene2, this.lineas);
			DiccionarioDeReaccionDeTipo.Tuple2 tuple2 = default(DiccionarioDeReaccionDeTipo.Tuple2);
			tuple2.flags1 = (int)tipo1;
			tuple2.flags2 = (int)tipo2;
			tuple2.flags3 = (int)parte;
			return this.flagsQueContiene2.Contains(tuple2);
		}

		// Token: 0x04001011 RID: 4113
		[NonSerialized]
		protected HashSet<DiccionarioDeReaccionDeTipo.Tuple> flagsQueContiene;

		// Token: 0x04001012 RID: 4114
		[NonSerialized]
		protected HashSet<DiccionarioDeReaccionDeTipo.Tuple2> flagsQueContiene2;

		// Token: 0x04001013 RID: 4115
		[CoolArrayItem]
		public List<DiccionarioDeReaccionDeTipo.LineaDeTexto> lineas;

		// Token: 0x02000378 RID: 888
		[Obsolete]
		[Serializable]
		public class LineaDeTexto : DiccionarioDeReaccionBase.LineaDeTextoBase
		{
			// Token: 0x06001350 RID: 4944 RVA: 0x00053994 File Offset: 0x00051B94
			public LineaDeTexto(string text)
				: base(text)
			{
			}

			// Token: 0x04001014 RID: 4116
			public EstimuloTipo flags1;

			// Token: 0x04001015 RID: 4117
			public EstimuloTipo2 flags2;

			// Token: 0x04001016 RID: 4118
			public DiccionarioDeReaccionDeTipo.LineaDeTexto.PartFilter partFilter = new DiccionarioDeReaccionDeTipo.LineaDeTexto.PartFilter();

			// Token: 0x02000379 RID: 889
			[Serializable]
			public class PartFilter
			{
				// Token: 0x04001017 RID: 4119
				public bool use;

				// Token: 0x04001018 RID: 4120
				public List<PartesHumanasParaAi> partes = new List<PartesHumanasParaAi>();
			}
		}

		// Token: 0x0200037A RID: 890
		public struct Tuple
		{
			// Token: 0x06001352 RID: 4946 RVA: 0x000539BB File Offset: 0x00051BBB
			public override bool Equals(object obj)
			{
				return obj is DiccionarioDeReaccionDeTipo.Tuple && this == (DiccionarioDeReaccionDeTipo.Tuple)obj;
			}

			// Token: 0x06001353 RID: 4947 RVA: 0x000539D8 File Offset: 0x00051BD8
			public override int GetHashCode()
			{
				return this.flags1.GetHashCode() ^ this.flags2.GetHashCode();
			}

			// Token: 0x06001354 RID: 4948 RVA: 0x000539F1 File Offset: 0x00051BF1
			public static bool operator ==(DiccionarioDeReaccionDeTipo.Tuple x, DiccionarioDeReaccionDeTipo.Tuple y)
			{
				return x.flags1 == y.flags1 && x.flags2 == y.flags2;
			}

			// Token: 0x06001355 RID: 4949 RVA: 0x00053A11 File Offset: 0x00051C11
			public static bool operator !=(DiccionarioDeReaccionDeTipo.Tuple x, DiccionarioDeReaccionDeTipo.Tuple y)
			{
				return !(x == y);
			}

			// Token: 0x04001019 RID: 4121
			public int flags1;

			// Token: 0x0400101A RID: 4122
			public int flags2;
		}

		// Token: 0x0200037B RID: 891
		public struct Tuple2
		{
			// Token: 0x06001356 RID: 4950 RVA: 0x00053A1D File Offset: 0x00051C1D
			public override bool Equals(object obj)
			{
				return obj is DiccionarioDeReaccionDeTipo.Tuple2 && this == (DiccionarioDeReaccionDeTipo.Tuple2)obj;
			}

			// Token: 0x06001357 RID: 4951 RVA: 0x00053A3A File Offset: 0x00051C3A
			public override int GetHashCode()
			{
				return this.flags1.GetHashCode() ^ this.flags2.GetHashCode() ^ this.flags3.GetHashCode();
			}

			// Token: 0x06001358 RID: 4952 RVA: 0x00053A5F File Offset: 0x00051C5F
			public static bool operator ==(DiccionarioDeReaccionDeTipo.Tuple2 x, DiccionarioDeReaccionDeTipo.Tuple2 y)
			{
				return x.flags1 == y.flags1 && x.flags2 == y.flags2 && x.flags3 == y.flags3;
			}

			// Token: 0x06001359 RID: 4953 RVA: 0x00053A8D File Offset: 0x00051C8D
			public static bool operator !=(DiccionarioDeReaccionDeTipo.Tuple2 x, DiccionarioDeReaccionDeTipo.Tuple2 y)
			{
				return !(x == y);
			}

			// Token: 0x0400101B RID: 4123
			public int flags1;

			// Token: 0x0400101C RID: 4124
			public int flags2;

			// Token: 0x0400101D RID: 4125
			public int flags3;
		}
	}
}
