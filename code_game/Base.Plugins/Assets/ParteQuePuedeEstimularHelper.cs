using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200015B RID: 347
	public static class ParteQuePuedeEstimularHelper
	{
		// Token: 0x06000A29 RID: 2601 RVA: 0x000227E4 File Offset: 0x000209E4
		static ParteQuePuedeEstimularHelper()
		{
			List<ParteQuePuedeEstimular> list = new List<ParteQuePuedeEstimular>(typeof(ParteQuePuedeEstimular).GetEnumValoresObject().Cast<ParteQuePuedeEstimular>());
			list.Sort((ParteQuePuedeEstimular a, ParteQuePuedeEstimular b) => b.Prioridad().CompareTo(a.Prioridad()));
			list.Remove(ParteQuePuedeEstimular.None);
			ParteQuePuedeEstimularHelper.partesQPuedenEstimularPorPrioridadDESC = list.ToArray();
			ParteQuePuedeEstimularHelper.partesQPuedenPenetrarPorPrioridadDESC = new List<ParteQuePuedeEstimular>
			{
				ParteQuePuedeEstimular.pene,
				ParteQuePuedeEstimular.propSexToy,
				ParteQuePuedeEstimular.lengua,
				ParteQuePuedeEstimular.dedo
			}.ToArray();
			List<ParteQuePuedeEstimular> list2 = new List<ParteQuePuedeEstimular>();
			list2.Add(ParteQuePuedeEstimular.ojos);
			list2.Add(ParteQuePuedeEstimular.propSexToy);
			ParteQuePuedeEstimularHelper.puedenVer = list2;
			ParteQuePuedeEstimularHelper.puedenVerSet = new HashSet<int>(list2.Select((ParteQuePuedeEstimular p) => (int)p));
			List<ParteQuePuedeEstimular> list3 = new List<ParteQuePuedeEstimular>();
			list3.Add(ParteQuePuedeEstimular.torzo);
			list3.Add(ParteQuePuedeEstimular.piernas);
			list3.Add(ParteQuePuedeEstimular.manos);
			list3.Add(ParteQuePuedeEstimular.dedo);
			list3.Add(ParteQuePuedeEstimular.boca);
			list3.Add(ParteQuePuedeEstimular.lengua);
			list3.Add(ParteQuePuedeEstimular.propSexToy);
			list3.Add(ParteQuePuedeEstimular.pene);
			list3.Add(ParteQuePuedeEstimular.semen);
			ParteQuePuedeEstimularHelper.puedenTocar = list3;
			ParteQuePuedeEstimularHelper.puedenTocarSet = new HashSet<int>(list3.Select((ParteQuePuedeEstimular p) => (int)p));
			List<ParteQuePuedeEstimular> list4 = new List<ParteQuePuedeEstimular>();
			list4.Add(ParteQuePuedeEstimular.manos);
			list4.Add(ParteQuePuedeEstimular.dedo);
			list4.Add(ParteQuePuedeEstimular.boca);
			list4.Add(ParteQuePuedeEstimular.lengua);
			list4.Add(ParteQuePuedeEstimular.propSexToy);
			list4.Add(ParteQuePuedeEstimular.pene);
			list4.Add(ParteQuePuedeEstimular.semen);
			ParteQuePuedeEstimularHelper.puedenTocarSexualmente = list4;
			ParteQuePuedeEstimularHelper.puedenTocarSexualmenteSet = new HashSet<int>(list4.Select((ParteQuePuedeEstimular p) => (int)p));
			ParteQuePuedeEstimularHelper.puedenDesvestir = new List<ParteQuePuedeEstimular>
			{
				ParteQuePuedeEstimular.boca,
				ParteQuePuedeEstimular.manos
			};
			List<ParteQuePuedeEstimular> list5 = new List<ParteQuePuedeEstimular>();
			list5.Add(ParteQuePuedeEstimular.dedo);
			list5.Add(ParteQuePuedeEstimular.lengua);
			list5.Add(ParteQuePuedeEstimular.pene);
			list5.Add(ParteQuePuedeEstimular.propSexToy);
			ParteQuePuedeEstimularHelper.puedenPenetrar = list5;
			ParteQuePuedeEstimularHelper.puedenPenetrarSet = new HashSet<int>(list5.Select((ParteQuePuedeEstimular p) => (int)p));
			List<ParteQuePuedeEstimular> list6 = new List<ParteQuePuedeEstimular>();
			list6.Add(ParteQuePuedeEstimular.dedo);
			ParteQuePuedeEstimularHelper.puedenPenetrarConfiable = list6;
			ParteQuePuedeEstimularHelper.puedenPenetrarConfiableSet = new HashSet<int>(list6.Select((ParteQuePuedeEstimular p) => (int)p));
			List<ParteQuePuedeEstimular> list7 = new List<ParteQuePuedeEstimular>();
			list7.Add(ParteQuePuedeEstimular.torzo);
			list7.Add(ParteQuePuedeEstimular.piernas);
			ParteQuePuedeEstimularHelper.puedenQueHacenHumping = list7;
			ParteQuePuedeEstimularHelper.puedenQueHacenHumpingSet = new HashSet<int>(list7.Select((ParteQuePuedeEstimular p) => (int)p));
			List<ParteQuePuedeEstimular> list8 = new List<ParteQuePuedeEstimular>();
			list8.Add(ParteQuePuedeEstimular.manos);
			ParteQuePuedeEstimularHelper.puedenManipular = list8;
			ParteQuePuedeEstimularHelper.puedenManipularSet = new HashSet<int>(list8.Select((ParteQuePuedeEstimular p) => (int)p));
			List<ParteQuePuedeEstimular> list9 = new List<ParteQuePuedeEstimular>();
			list9.Add(ParteQuePuedeEstimular.boca);
			ParteQuePuedeEstimularHelper.puedenComunicar = list9;
			ParteQuePuedeEstimularHelper.puedenComunicarSet = new HashSet<int>(list9.Select((ParteQuePuedeEstimular p) => (int)p));
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00022AC0 File Offset: 0x00020CC0
		public static ParteDelCuerpoHumano Switch(this ParteQuePuedeEstimular parteEstimulante)
		{
			if (parteEstimulante <= ParteQuePuedeEstimular.torzo)
			{
				if (parteEstimulante <= ParteQuePuedeEstimular.pene)
				{
					switch (parteEstimulante)
					{
					case ParteQuePuedeEstimular.noEspecificada:
						break;
					case ParteQuePuedeEstimular.piernas:
						return ParteDelCuerpoHumano.piernas;
					case (ParteQuePuedeEstimular)3:
						goto IL_0085;
					case ParteQuePuedeEstimular.manos:
						goto IL_006D;
					default:
						if (parteEstimulante != ParteQuePuedeEstimular.pene)
						{
							goto IL_0085;
						}
						goto IL_0072;
					}
				}
				else
				{
					if (parteEstimulante == ParteQuePuedeEstimular.propSexToy)
					{
						goto IL_006D;
					}
					if (parteEstimulante != ParteQuePuedeEstimular.torzo)
					{
						goto IL_0085;
					}
				}
				return ParteDelCuerpoHumano.pecho;
			}
			if (parteEstimulante <= ParteQuePuedeEstimular.boca)
			{
				if (parteEstimulante == ParteQuePuedeEstimular.lengua)
				{
					return ParteDelCuerpoHumano.lengua;
				}
				if (parteEstimulante != ParteQuePuedeEstimular.boca)
				{
					goto IL_0085;
				}
				return ParteDelCuerpoHumano.labios;
			}
			else
			{
				if (parteEstimulante == ParteQuePuedeEstimular.ojos)
				{
					return ParteDelCuerpoHumano.ojos;
				}
				if (parteEstimulante == ParteQuePuedeEstimular.semen)
				{
					goto IL_0072;
				}
				if (parteEstimulante != ParteQuePuedeEstimular.dedo)
				{
					goto IL_0085;
				}
			}
			IL_006D:
			return ParteDelCuerpoHumano.manos;
			IL_0072:
			return ParteDelCuerpoHumano.pene;
			IL_0085:
			throw new ArgumentOutOfRangeException(parteEstimulante.ToString());
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00022B68 File Offset: 0x00020D68
		public static ParteQuePuedeEstimular ParteQuePuedeEstimularDeTransform(this ICharacter character, Transform obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj", "obj null reference.");
			}
			if (!character.ObjetoMePertenece(obj))
			{
				return ParteQuePuedeEstimular.None;
			}
			if (character.trasnformParaComunicarse != null && obj.IsChildOf(character.trasnformParaComunicarse))
			{
				return ParteQuePuedeEstimular.boca;
			}
			if (character.ObjetoEsMiPene(obj))
			{
				return ParteQuePuedeEstimular.pene;
			}
			if (character.ObjetoEsMiDedo(obj))
			{
				return ParteQuePuedeEstimular.dedo;
			}
			if (character.ObjetoEsMiMano(obj) || character.ObjetoEsMiAnteBrazo(obj))
			{
				return ParteQuePuedeEstimular.manos;
			}
			if (character.ObjetoEsMiTorzo(obj))
			{
				return ParteQuePuedeEstimular.torzo;
			}
			if (character.ObjetoEsMiPierna(obj))
			{
				return ParteQuePuedeEstimular.piernas;
			}
			if (character.ObjetoEsProp(obj))
			{
				return ParteQuePuedeEstimular.propSexToy;
			}
			if (Application.isEditor || Debug.isDebugBuild)
			{
				Debug.LogWarning("Objecto: " + obj.name + ", no es especifico", (Component)character);
			}
			return ParteQuePuedeEstimular.noEspecificada;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00022C3B File Offset: 0x00020E3B
		public static bool EsManipuladorParte(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenManipularSet.Contains((int)parte);
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00022C48 File Offset: 0x00020E48
		public static bool EsConmunicadorParte(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenComunicarSet.Contains((int)parte);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00022C55 File Offset: 0x00020E55
		public static bool EsHumpingParte(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenQueHacenHumpingSet.Contains((int)parte);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00022C62 File Offset: 0x00020E62
		public static bool EsPenetrador(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenPenetrarSet.Contains((int)parte);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00022C6F File Offset: 0x00020E6F
		public static bool PuedePenetrar(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenPenetrarSet.Contains((int)parte);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00022C7C File Offset: 0x00020E7C
		public static bool PuedeTocar(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenTocarSet.Contains((int)parte);
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00022C89 File Offset: 0x00020E89
		public static bool PuedeVer(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenVerSet.Contains((int)parte);
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00022C96 File Offset: 0x00020E96
		public static bool EsPenetradorConfiable(this ParteQuePuedeEstimular parte)
		{
			return ParteQuePuedeEstimularHelper.puedenPenetrarConfiableSet.Contains((int)parte);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00022CA4 File Offset: 0x00020EA4
		public static bool EsPrivada(this ParteQuePuedeEstimular parte)
		{
			if (parte <= ParteQuePuedeEstimular.lengua)
			{
				if (parte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (parte)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
					case ParteQuePuedeEstimular.piernas:
					case ParteQuePuedeEstimular.manos:
						return false;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0077;
					case ParteQuePuedeEstimular.pene:
						break;
					default:
						if (parte != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0077;
						}
						break;
					}
				}
				else
				{
					if (parte == ParteQuePuedeEstimular.torzo)
					{
						return false;
					}
					if (parte != ParteQuePuedeEstimular.lengua)
					{
						goto IL_0077;
					}
				}
			}
			else if (parte <= ParteQuePuedeEstimular.ojos)
			{
				if (parte != ParteQuePuedeEstimular.boca && parte != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0077;
				}
				return false;
			}
			else if (parte != ParteQuePuedeEstimular.semen)
			{
				if (parte != ParteQuePuedeEstimular.dedo)
				{
					goto IL_0077;
				}
				return false;
			}
			return true;
			IL_0077:
			throw new ArgumentOutOfRangeException(parte.ToString());
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00022D3C File Offset: 0x00020F3C
		public static double PrioridadManipulativa(this ParteQuePuedeEstimular p)
		{
			if (p <= ParteQuePuedeEstimular.lengua)
			{
				if (p <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (p)
					{
					case ParteQuePuedeEstimular.None:
						return 0.0;
					case ParteQuePuedeEstimular.noEspecificada:
						return 1.0;
					case ParteQuePuedeEstimular.piernas:
						return 16.0;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						break;
					case ParteQuePuedeEstimular.manos:
						return 50.0;
					case ParteQuePuedeEstimular.pene:
						return 60.0;
					default:
						if (p == ParteQuePuedeEstimular.propSexToy)
						{
							return 65.0;
						}
						break;
					}
				}
				else
				{
					if (p == ParteQuePuedeEstimular.torzo)
					{
						return 12.0;
					}
					if (p == ParteQuePuedeEstimular.lengua)
					{
						return 8.0;
					}
				}
			}
			else if (p <= ParteQuePuedeEstimular.ojos)
			{
				if (p == ParteQuePuedeEstimular.boca)
				{
					return 4.0;
				}
				if (p == ParteQuePuedeEstimular.ojos)
				{
					return 2.0;
				}
			}
			else
			{
				if (p == ParteQuePuedeEstimular.semen)
				{
					return 100.0;
				}
				if (p == ParteQuePuedeEstimular.dedo)
				{
					return 55.0;
				}
			}
			throw new ArgumentOutOfRangeException(p.ToString());
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00022E54 File Offset: 0x00021054
		public static double Prioridad(this ParteQuePuedeEstimular p)
		{
			if (p <= ParteQuePuedeEstimular.lengua)
			{
				if (p <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (p)
					{
					case ParteQuePuedeEstimular.None:
						return 0.0;
					case ParteQuePuedeEstimular.noEspecificada:
						return 1.0;
					case ParteQuePuedeEstimular.piernas:
						return 4.0;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						break;
					case ParteQuePuedeEstimular.manos:
						return 25.0;
					case ParteQuePuedeEstimular.pene:
						return 50.0;
					default:
						if (p == ParteQuePuedeEstimular.propSexToy)
						{
							return 30.0;
						}
						break;
					}
				}
				else
				{
					if (p == ParteQuePuedeEstimular.torzo)
					{
						return 8.0;
					}
					if (p == ParteQuePuedeEstimular.lengua)
					{
						return 45.0;
					}
				}
			}
			else if (p <= ParteQuePuedeEstimular.ojos)
			{
				if (p == ParteQuePuedeEstimular.boca)
				{
					return 40.0;
				}
				if (p == ParteQuePuedeEstimular.ojos)
				{
					return 2.0;
				}
			}
			else
			{
				if (p == ParteQuePuedeEstimular.semen)
				{
					return 100.0;
				}
				if (p == ParteQuePuedeEstimular.dedo)
				{
					return 35.0;
				}
			}
			throw new ArgumentOutOfRangeException(p.ToString());
		}

		// Token: 0x04000321 RID: 801
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenComunicar;

		// Token: 0x04000322 RID: 802
		public static readonly IReadOnlyCollection<int> puedenComunicarSet;

		// Token: 0x04000323 RID: 803
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenManipular;

		// Token: 0x04000324 RID: 804
		public static readonly IReadOnlyCollection<int> puedenManipularSet;

		// Token: 0x04000325 RID: 805
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenQueHacenHumping;

		// Token: 0x04000326 RID: 806
		public static readonly IReadOnlyCollection<int> puedenQueHacenHumpingSet;

		// Token: 0x04000327 RID: 807
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> partesQPuedenEstimularPorPrioridadDESC;

		// Token: 0x04000328 RID: 808
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> partesQPuedenPenetrarPorPrioridadDESC;

		// Token: 0x04000329 RID: 809
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenVer;

		// Token: 0x0400032A RID: 810
		public static readonly IReadOnlyCollection<int> puedenVerSet;

		// Token: 0x0400032B RID: 811
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenDesvestir;

		// Token: 0x0400032C RID: 812
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenTocar;

		// Token: 0x0400032D RID: 813
		public static readonly IReadOnlyCollection<int> puedenTocarSet;

		// Token: 0x0400032E RID: 814
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenTocarSexualmente;

		// Token: 0x0400032F RID: 815
		public static readonly IReadOnlyCollection<int> puedenTocarSexualmenteSet;

		// Token: 0x04000330 RID: 816
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenPenetrar;

		// Token: 0x04000331 RID: 817
		public static readonly IReadOnlyCollection<int> puedenPenetrarSet;

		// Token: 0x04000332 RID: 818
		public static readonly IReadOnlyList<ParteQuePuedeEstimular> puedenPenetrarConfiable;

		// Token: 0x04000333 RID: 819
		public static readonly IReadOnlyCollection<int> puedenPenetrarConfiableSet;
	}
}
