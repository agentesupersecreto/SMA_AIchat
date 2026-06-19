using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000469 RID: 1129
	public static class ConsensualTree
	{
		// Token: 0x06001885 RID: 6277 RVA: 0x00061E90 File Offset: 0x00060090
		public static IReadOnlyList<ConsensualTree.Data> OverridesInverted(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> valueTuple = new ConsensualTree.Data
			{
				tipoDeEstimulo = tipoDeEstimulo,
				direccion = direccion,
				parteEstimulada = parteEstimulada,
				parteEstimulante = parteEstimulante,
				tag = tag
			}.ToKey();
			List<ConsensualTree.Data> list;
			if (!ConsensualTree.m_overridesInvertedMem.TryGetValue(valueTuple, out list))
			{
				list = ConsensualTree.OverridesInvertedSet(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, tag).ToList<ConsensualTree.Data>();
				list.Sort((ConsensualTree.Data x, ConsensualTree.Data y) => y.Getpriorida().CompareTo(x.Getpriorida()));
				ConsensualTree.m_overridesInvertedMem.Add(valueTuple, list);
			}
			return list;
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00061F2C File Offset: 0x0006012C
		public static IReadOnlyCollection<ConsensualTree.Data> OverridesInvertedSet(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> valueTuple = new ConsensualTree.Data
			{
				tipoDeEstimulo = tipoDeEstimulo,
				direccion = direccion,
				parteEstimulada = parteEstimulada,
				parteEstimulante = parteEstimulante,
				tag = tag
			}.ToKey();
			HashSet<ConsensualTree.Data> hashSet;
			if (!ConsensualTree.m_overridesInvertedSetMem.TryGetValue(valueTuple, out hashSet))
			{
				hashSet = new HashSet<ConsensualTree.Data>();
				ConsensualTree.m_overridesInvertedSetMem.Add(valueTuple, hashSet);
				ConsensualTree.OverridesInverted(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, tag, hashSet);
			}
			return hashSet;
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x00061FA2 File Offset: 0x000601A2
		public static void OverridesInverted(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				ConsensualTree.OverridesInvertedRecibidas(tipoDeEstimulo, parteEstimulada, parteEstimulante, tag, resultado);
				return;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			ConsensualTree.OverridesInvertedDadas(tipoDeEstimulo, parteEstimulada, parteEstimulante, tag, resultado);
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00061FDC File Offset: 0x000601DC
		private static void OverridesInvertedDadas(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.None:
				Debug.LogWarning("tipo de TipoDeEstimulo es None");
				return;
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return;
			case TipoDeEstimulo.visual:
				ConsensualTree.OverrideInvertedDadasGenericVisual(parteEstimulada, parteEstimulante, tag, false, resultado);
				return;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x0006205C File Offset: 0x0006025C
		private static void OverridesInvertedRecibidas(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			ConsensualTree.OverrideInvertedRecibidaGeneric(tipoDeEstimulo, parteEstimulada, parteEstimulante, tag, false, resultado);
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.None:
				Debug.LogWarning("tipo de TipoDeEstimulo es None");
				return;
			case TipoDeEstimulo.tactil:
				ConsensualTree.OverrideInvertedTactilRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				if (ParteQuePuedeEstimularHelper.puedenPenetrarSet.Contains((int)parteEstimulante))
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.tactil, parteEstimulada, ParteQuePuedeEstimular.manos, tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			case TipoDeEstimulo.visual:
				ConsensualTree.OverrideInvertedVisualRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.coital:
			{
				ConsensualTree.OverrideInvertedCoitalRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				for (int i = 0; i < ParteQuePuedeEstimularHelper.puedenManipular.Count; i++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.manipulandoBone, parteEstimulada, ParteQuePuedeEstimularHelper.puedenManipular[i], tag, true, resultado);
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.desvestidura, parteEstimulada, ParteQuePuedeEstimularHelper.puedenManipular[i], tag, true, resultado);
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.ejecucionDePose, parteEstimulada, ParteQuePuedeEstimularHelper.puedenManipular[i], tag, true, resultado);
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.tactil, parteEstimulada, ParteQuePuedeEstimularHelper.puedenManipular[i], tag, true, resultado);
				}
				for (int j = 0; j < ParteQuePuedeEstimularHelper.puedenComunicar.Count; j++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.guiandoBone, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[j], tag, true, resultado);
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.peticionDesvestidura, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[j], tag, true, resultado);
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.peticionEjecucionDePose, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[j], tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.tactil, parteEstimulada, parteEstimulante, tag, true, resultado);
				for (int k = 0; k < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; k++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.tactil, parteEstimulada, ParteQuePuedeEstimularHelper.puedenQueHacenHumping[k], tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			}
			case TipoDeEstimulo.desvestidura:
			{
				ConsensualTree.OverrideInvertedDesvestiduraForzadaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				for (int l = 0; l < ParteQuePuedeEstimularHelper.puedenComunicar.Count; l++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.peticionDesvestidura, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[l], tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			}
			case TipoDeEstimulo.peticionDesvestidura:
			{
				ConsensualTree.OverrideInvertedDesvestiduraPedidaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				for (int m = 0; m < ParteQuePuedeEstimularHelper.puedenComunicar.Count; m++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.peticionEjecucionDePose, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[m], tag, true, resultado);
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.guiandoBone, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[m], tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			}
			case TipoDeEstimulo.ejecucionDePose:
			{
				for (int n = 0; n < ParteQuePuedeEstimularHelper.puedenComunicar.Count; n++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.peticionEjecucionDePose, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[n], tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			}
			case TipoDeEstimulo.peticionEjecucionDePose:
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			case TipoDeEstimulo.guiandoBone:
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			case TipoDeEstimulo.manipulandoBone:
			{
				for (int num = 0; num < ParteQuePuedeEstimularHelper.puedenManipular.Count; num++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.tactil, parteEstimulada, ParteQuePuedeEstimularHelper.puedenManipular[num], tag, true, resultado);
				}
				for (int num2 = 0; num2 < ParteQuePuedeEstimularHelper.puedenComunicar.Count; num2++)
				{
					ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.guiandoBone, parteEstimulada, ParteQuePuedeEstimularHelper.puedenComunicar[num2], tag, true, resultado);
				}
				ConsensualTree.OverrideInvertedRecibidaGeneric(TipoDeEstimulo.visual, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, true, resultado);
				return;
			}
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x000623BC File Offset: 0x000605BC
		private static void OverrideInvertedDesvestiduraForzadaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (ParteDelCuerpoHumanoHelper.partesDeInteraccionAnalSet.Contains((int)parteEstimulada) || ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginalSet.Contains((int)parteEstimulada))
			{
				for (int i = 0; i < ParteDelCuerpoHumanoHelper.partesDeTrasero.Count; i++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumanoHelper.partesDeTrasero[i];
					for (int j = 0; j < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; j++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimularHelper.puedenDesvestir[j];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
					}
					for (int k = 0; k < ParteQuePuedeEstimularHelper.puedenVer.Count; k++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular2 = ParteQuePuedeEstimularHelper.puedenVer[k];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular2, null, resultado);
					}
				}
				for (int l = 0; l < ParteDelCuerpoHumanoHelper.partesDeEntrepierna.Count; l++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano2 = ParteDelCuerpoHumanoHelper.partesDeEntrepierna[l];
					for (int m = 0; m < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; m++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular3 = ParteQuePuedeEstimularHelper.puedenDesvestir[m];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular3, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular3, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular3, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular3, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular3, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular3, null, resultado);
					}
					for (int n = 0; n < ParteQuePuedeEstimularHelper.puedenVer.Count; n++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular4 = ParteQuePuedeEstimularHelper.puedenVer[n];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular4, null, resultado);
					}
				}
				return;
			}
			if ((ParteDelCuerpoHumanoHelper.partesDeTraseroSet.Contains((int)parteEstimulada) || ParteDelCuerpoHumanoHelper.partesDeEntrepiernaSet.Contains((int)parteEstimulada)) && !parteEstimulada.EsMuyPrivadaSocialmenteVisual())
			{
				for (int num = 0; num < ParteDelCuerpoHumanoHelper.partesDeTrasero.Count; num++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano3 = ParteDelCuerpoHumanoHelper.partesDeTrasero[num];
					if (!parteDelCuerpoHumano3.EsMuyPrivadaSocialmenteVisual())
					{
						for (int num2 = 0; num2 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num2++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular5 = ParteQuePuedeEstimularHelper.puedenDesvestir[num2];
							ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular5, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular5, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular5, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular5, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular5, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular5, null, resultado);
						}
						for (int num3 = 0; num3 < ParteQuePuedeEstimularHelper.puedenVer.Count; num3++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular6 = ParteQuePuedeEstimularHelper.puedenVer[num3];
							ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular6, null, resultado);
						}
					}
				}
				for (int num4 = 0; num4 < ParteDelCuerpoHumanoHelper.partesDeEntrepierna.Count; num4++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano4 = ParteDelCuerpoHumanoHelper.partesDeEntrepierna[num4];
					if (!parteDelCuerpoHumano4.EsMuyPrivadaSocialmenteVisual())
					{
						for (int num5 = 0; num5 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num5++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular7 = ParteQuePuedeEstimularHelper.puedenDesvestir[num5];
							ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular7, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular7, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular7, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular7, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular7, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular7, null, resultado);
						}
						for (int num6 = 0; num6 < ParteQuePuedeEstimularHelper.puedenVer.Count; num6++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular8 = ParteQuePuedeEstimularHelper.puedenVer[num6];
							ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular8, null, resultado);
						}
					}
				}
				return;
			}
			if (ParteDelCuerpoHumanoHelper.partesDeInteraccionSenosSet.Contains((int)parteEstimulada) && parteEstimulada.EsMuyPrivadaSocialmenteVisual())
			{
				for (int num7 = 0; num7 < ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos.Count; num7++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano5 = ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos[num7];
					for (int num8 = 0; num8 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num8++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular9 = ParteQuePuedeEstimularHelper.puedenDesvestir[num8];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular9, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular9, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular9, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular9, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular9, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular9, null, resultado);
					}
					for (int num9 = 0; num9 < ParteQuePuedeEstimularHelper.puedenVer.Count; num9++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular10 = ParteQuePuedeEstimularHelper.puedenVer[num9];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular10, null, resultado);
					}
				}
				return;
			}
			if (ParteDelCuerpoHumanoHelper.partesDeInteraccionSenosSet.Contains((int)parteEstimulada) && !parteEstimulada.EsMuyPrivadaSocialmenteVisual())
			{
				for (int num10 = 0; num10 < ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos.Count; num10++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano6 = ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos[num10];
					if (!parteEstimulada.EsMuyPrivadaSocialmenteVisual())
					{
						for (int num11 = 0; num11 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num11++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular11 = ParteQuePuedeEstimularHelper.puedenDesvestir[num11];
							ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular11, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular11, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular11, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular11, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular11, null, resultado);
							ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular11, null, resultado);
						}
						for (int num12 = 0; num12 < ParteQuePuedeEstimularHelper.puedenVer.Count; num12++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular12 = ParteQuePuedeEstimularHelper.puedenVer[num12];
							ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular12, null, resultado);
						}
					}
				}
				return;
			}
			if (ParteDelCuerpoHumanoHelper.partesDeFacialSet.Contains((int)parteEstimulada))
			{
				for (int num13 = 0; num13 < ParteDelCuerpoHumanoHelper.partesDeFacial.Count; num13++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano7 = ParteDelCuerpoHumanoHelper.partesDeFacial[num13];
					for (int num14 = 0; num14 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num14++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular13 = ParteQuePuedeEstimularHelper.puedenDesvestir[num14];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular13, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular13, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular13, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular13, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular13, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular13, null, resultado);
					}
					for (int num15 = 0; num15 < ParteQuePuedeEstimularHelper.puedenVer.Count; num15++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular14 = ParteQuePuedeEstimularHelper.puedenVer[num15];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular14, null, resultado);
					}
				}
				return;
			}
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00062A67 File Offset: 0x00060C67
		private static void OverrideInvertedDesvestiduraPedidaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (parteEstimulante != ParteQuePuedeEstimular.boca)
			{
				Debug.LogError("OverrideInvertedDesvestiduraPedidaRecibida aun no es compatible con parte: " + parteEstimulante.ToString());
				return;
			}
			ConsensualTree.OverrideInvertedDesvestiduraForzadaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x00062A98 File Offset: 0x00060C98
		private static void OverrideInvertedCoitalRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (parteEstimulada == ParteDelCuerpoHumano.bocaInterno)
			{
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteEstimulada, parteEstimulante, null, resultado);
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, ParteDelCuerpoHumano.ojos, ParteQuePuedeEstimular.pene, null, resultado);
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, ParteDelCuerpoHumano.ojos, ParteQuePuedeEstimular.semen, null, resultado);
				for (int i = 0; i < ParteDelCuerpoHumanoHelper.partesDeFacial.Count; i++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumanoHelper.partesDeFacial[i];
					for (int j = 0; j < ParteQuePuedeEstimularHelper.puedenVer.Count; j++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimularHelper.puedenVer[j];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, null, resultado);
					}
					if (parteDelCuerpoHumano != ParteDelCuerpoHumano.globosOculares)
					{
						for (int k = 0; k < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; k++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular2 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[k];
							ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular2, null, resultado);
						}
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteEstimulante, null, resultado);
						for (int l = 0; l < ParteQuePuedeEstimularHelper.puedenManipular.Count; l++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular3 = ParteQuePuedeEstimularHelper.puedenManipular[l];
							ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular3, null, resultado);
						}
					}
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.semen, null, resultado);
					for (int m = 0; m < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; m++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular4 = ParteQuePuedeEstimularHelper.puedenDesvestir[m];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular4, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular4, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular4, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular4, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular4, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular4, null, resultado);
					}
				}
				for (int n = 0; n < ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Count; n++)
				{
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero[n], ParteQuePuedeEstimular.semen, null, resultado);
				}
				for (int num = 0; num < ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero.Count; num++)
				{
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero[num], ParteQuePuedeEstimular.semen, null, resultado);
				}
				for (int num2 = 0; num2 < ParteDelCuerpoHumanoHelper.partesDeBrazos.Count; num2++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano2 = ParteDelCuerpoHumanoHelper.partesDeBrazos[num2];
					for (int num3 = 0; num3 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num3++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular5 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num3];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular5, null, resultado);
					}
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteEstimulante, null, resultado);
					for (int num4 = 0; num4 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num4++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular6 = ParteQuePuedeEstimularHelper.puedenDesvestir[num4];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular6, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular6, null, resultado);
					}
				}
				for (int num5 = 0; num5 < ParteDelCuerpoHumanoHelper.partesDePiernas.Count; num5++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano3 = ParteDelCuerpoHumanoHelper.partesDePiernas[num5];
					for (int num6 = 0; num6 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num6++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular7 = ParteQuePuedeEstimularHelper.puedenDesvestir[num6];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular7, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular7, null, resultado);
					}
					for (int num7 = 0; num7 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num7++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular8 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num7];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano3, parteQuePuedeEstimular8, null, resultado);
					}
				}
				for (int num8 = 0; num8 < ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Count; num8++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano4 = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero[num8];
					for (int num9 = 0; num9 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num9++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular9 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num9];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular9, null, resultado);
					}
					for (int num10 = 0; num10 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num10++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular10 = ParteQuePuedeEstimularHelper.puedenDesvestir[num10];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular10, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano4, parteQuePuedeEstimular10, null, resultado);
					}
				}
				for (int num11 = 0; num11 < ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero.Count; num11++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano5 = ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero[num11];
					for (int num12 = 0; num12 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num12++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular11 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num12];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular11, null, resultado);
					}
					for (int num13 = 0; num13 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num13++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular12 = ParteQuePuedeEstimularHelper.puedenDesvestir[num13];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular12, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano5, parteQuePuedeEstimular12, null, resultado);
					}
				}
				for (int num14 = 0; num14 < ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos.Count; num14++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano6 = ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos[num14];
					for (int num15 = 0; num15 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num15++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular13 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num15];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular13, null, resultado);
					}
					for (int num16 = 0; num16 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num16++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular14 = ParteQuePuedeEstimularHelper.puedenDesvestir[num16];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular14, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano6, parteQuePuedeEstimular14, null, resultado);
					}
				}
				return;
			}
			if (parteEstimulada - ParteDelCuerpoHumano.ano <= 1)
			{
				bool flag = parteEstimulada == ParteDelCuerpoHumano.ano;
				bool flag2 = parteEstimulada == ParteDelCuerpoHumano.vag;
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteEstimulada, parteEstimulante, null, resultado);
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, ParteDelCuerpoHumano.ojos, ParteQuePuedeEstimular.pene, null, resultado);
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, ParteDelCuerpoHumano.ojos, ParteQuePuedeEstimular.semen, null, resultado);
				for (int num17 = 0; num17 < ParteDelCuerpoHumanoHelper.partesDeEntrepierna.Count; num17++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano7 = ParteDelCuerpoHumanoHelper.partesDeEntrepierna[num17];
					bool flag3 = ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginalSet.Contains((int)parteDelCuerpoHumano7);
					bool flag4 = parteDelCuerpoHumano7.PuedeSerPenetrada();
					for (int num18 = 0; num18 < ParteQuePuedeEstimularHelper.puedenVer.Count; num18++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular15 = ParteQuePuedeEstimularHelper.puedenVer[num18];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular15, null, resultado);
					}
					for (int num19 = 0; num19 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num19++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular16 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num19];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular16, null, resultado);
					}
					if (flag2 || !flag3)
					{
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteEstimulante, null, resultado);
						for (int num20 = 0; num20 < ParteQuePuedeEstimularHelper.puedenManipular.Count; num20++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular17 = ParteQuePuedeEstimularHelper.puedenManipular[num20];
							ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular17, null, resultado);
						}
					}
					if (!flag4)
					{
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, ParteQuePuedeEstimular.semen, null, resultado);
					}
					else if (flag2)
					{
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, ParteQuePuedeEstimular.semen, null, resultado);
					}
					for (int num21 = 0; num21 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num21++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular18 = ParteQuePuedeEstimularHelper.puedenDesvestir[num21];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular18, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular18, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular18, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular18, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular18, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano7, parteQuePuedeEstimular18, null, resultado);
					}
				}
				for (int num22 = 0; num22 < ParteDelCuerpoHumanoHelper.partesDeTrasero.Count; num22++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano8 = ParteDelCuerpoHumanoHelper.partesDeTrasero[num22];
					bool flag5 = ParteDelCuerpoHumanoHelper.partesDeInteraccionAnalSet.Contains((int)parteDelCuerpoHumano8);
					bool flag6 = parteDelCuerpoHumano8.PuedeSerPenetrada();
					for (int num23 = 0; num23 < ParteQuePuedeEstimularHelper.puedenVer.Count; num23++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular19 = ParteQuePuedeEstimularHelper.puedenVer[num23];
						ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular19, null, resultado);
					}
					for (int num24 = 0; num24 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num24++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular20 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num24];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular20, null, resultado);
					}
					if (flag || !flag5)
					{
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteEstimulante, null, resultado);
						for (int num25 = 0; num25 < ParteQuePuedeEstimularHelper.puedenManipular.Count; num25++)
						{
							ParteQuePuedeEstimular parteQuePuedeEstimular21 = ParteQuePuedeEstimularHelper.puedenManipular[num25];
							ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular21, null, resultado);
						}
					}
					if (!flag6)
					{
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, ParteQuePuedeEstimular.semen, null, resultado);
					}
					else if (flag)
					{
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, ParteQuePuedeEstimular.semen, null, resultado);
					}
					for (int num26 = 0; num26 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num26++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular22 = ParteQuePuedeEstimularHelper.puedenDesvestir[num26];
						ConsensualTree.Add(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular22, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular22, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular22, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular22, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.ejecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular22, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano8, parteQuePuedeEstimular22, null, resultado);
					}
				}
				for (int num27 = 0; num27 < ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Count; num27++)
				{
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero[num27], ParteQuePuedeEstimular.semen, null, resultado);
				}
				for (int num28 = 0; num28 < ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero.Count; num28++)
				{
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero[num28], ParteQuePuedeEstimular.semen, null, resultado);
				}
				for (int num29 = 0; num29 < ParteDelCuerpoHumanoHelper.partesDeBrazos.Count; num29++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano9 = ParteDelCuerpoHumanoHelper.partesDeBrazos[num29];
					for (int num30 = 0; num30 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num30++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular23 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num30];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano9, parteQuePuedeEstimular23, null, resultado);
					}
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano9, parteEstimulante, null, resultado);
					for (int num31 = 0; num31 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num31++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular24 = ParteQuePuedeEstimularHelper.puedenDesvestir[num31];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano9, parteQuePuedeEstimular24, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano9, parteQuePuedeEstimular24, null, resultado);
					}
				}
				for (int num32 = 0; num32 < ParteDelCuerpoHumanoHelper.partesDePiernas.Count; num32++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano10 = ParteDelCuerpoHumanoHelper.partesDePiernas[num32];
					for (int num33 = 0; num33 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num33++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular25 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num33];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano10, parteQuePuedeEstimular25, null, resultado);
					}
					for (int num34 = 0; num34 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num34++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular26 = ParteQuePuedeEstimularHelper.puedenDesvestir[num34];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano10, parteQuePuedeEstimular26, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano10, parteQuePuedeEstimular26, null, resultado);
					}
				}
				for (int num35 = 0; num35 < ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Count; num35++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano11 = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero[num35];
					for (int num36 = 0; num36 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num36++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular27 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num36];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano11, parteQuePuedeEstimular27, null, resultado);
					}
					for (int num37 = 0; num37 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num37++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular28 = ParteQuePuedeEstimularHelper.puedenDesvestir[num37];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano11, parteQuePuedeEstimular28, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano11, parteQuePuedeEstimular28, null, resultado);
					}
				}
				for (int num38 = 0; num38 < ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero.Count; num38++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano12 = ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero[num38];
					for (int num39 = 0; num39 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num39++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular29 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num39];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano12, parteQuePuedeEstimular29, null, resultado);
					}
					for (int num40 = 0; num40 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num40++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular30 = ParteQuePuedeEstimularHelper.puedenDesvestir[num40];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano12, parteQuePuedeEstimular30, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano12, parteQuePuedeEstimular30, null, resultado);
					}
				}
				for (int num41 = 0; num41 < ParteDelCuerpoHumanoHelper.partesDeFacial.Count; num41++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano13 = ParteDelCuerpoHumanoHelper.partesDeFacial[num41];
					for (int num42 = 0; num42 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num42++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular31 = ParteQuePuedeEstimularHelper.puedenDesvestir[num42];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano13, parteQuePuedeEstimular31, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano13, parteQuePuedeEstimular31, null, resultado);
					}
				}
				for (int num43 = 0; num43 < ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos.Count; num43++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano14 = ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos[num43];
					for (int num44 = 0; num44 < ParteQuePuedeEstimularHelper.puedenQueHacenHumping.Count; num44++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular32 = ParteQuePuedeEstimularHelper.puedenQueHacenHumping[num44];
						ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano14, parteQuePuedeEstimular32, null, resultado);
					}
					for (int num45 = 0; num45 < ParteQuePuedeEstimularHelper.puedenDesvestir.Count; num45++)
					{
						ParteQuePuedeEstimular parteQuePuedeEstimular33 = ParteQuePuedeEstimularHelper.puedenDesvestir[num45];
						ConsensualTree.Add(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, parteDelCuerpoHumano14, parteQuePuedeEstimular33, null, resultado);
						ConsensualTree.Add(TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, parteDelCuerpoHumano14, parteQuePuedeEstimular33, null, resultado);
					}
				}
				return;
			}
			Debug.LogError("OverrideInvertedCoitalRecibida aun no es compatible con parte: " + parteEstimulada.ToString());
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x0006376C File Offset: 0x0006196C
		private static void OverrideInvertedVisualRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (!ParteQuePuedeEstimularHelper.puedenVerSet.Contains((int)parteEstimulante))
			{
				Debug.LogException(new NotSupportedException(parteEstimulante.ToString()));
				return;
			}
			if (parteEstimulante == ParteQuePuedeEstimular.propSexToy)
			{
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteEstimulada, ParteQuePuedeEstimular.ojos, tag, resultado);
				return;
			}
			if (parteEstimulante != ParteQuePuedeEstimular.ojos)
			{
				throw new ArgumentOutOfRangeException(parteEstimulante.ToString());
			}
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x000637D0 File Offset: 0x000619D0
		private static void OverrideInvertedTactilRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (parteEstimulante != ParteQuePuedeEstimular.propSexToy)
			{
				if (parteEstimulante != ParteQuePuedeEstimular.semen)
				{
					if (parteEstimulante == ParteQuePuedeEstimular.dedo)
					{
						goto IL_0015;
					}
				}
				else
				{
					ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteEstimulada, ParteQuePuedeEstimular.pene, tag, resultado);
				}
				return;
			}
			IL_0015:
			ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteEstimulada, ParteQuePuedeEstimular.manos, tag, resultado);
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x00063800 File Offset: 0x00061A00
		private static void OverrideDadasGenericVisual(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, bool addSelf, ICollection<ConsensualTree.Data> resultado)
		{
			if (addSelf)
			{
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, parteEstimulante, null, resultado);
			}
			if (parteEstimulante <= ParteQuePuedeEstimular.ojos)
			{
				if (parteEstimulante == ParteQuePuedeEstimular.pene)
				{
					return;
				}
				if (parteEstimulante == ParteQuePuedeEstimular.ojos)
				{
					ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.pene, null, resultado);
					ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.semen, null, resultado);
					ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.dedo, null, resultado);
					return;
				}
			}
			else
			{
				if (parteEstimulante == ParteQuePuedeEstimular.semen)
				{
					ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.pene, null, resultado);
					return;
				}
				if (parteEstimulante == ParteQuePuedeEstimular.dedo)
				{
					ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.pene, null, resultado);
					return;
				}
			}
			throw new ArgumentOutOfRangeException(parteEstimulante.ToString());
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x000638A0 File Offset: 0x00061AA0
		private static void OverrideInvertedDadasGenericVisual(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, bool addSelf, ICollection<ConsensualTree.Data> resultado)
		{
			if (addSelf)
			{
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, parteEstimulante, null, resultado);
			}
			if (parteEstimulante == ParteQuePuedeEstimular.pene)
			{
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.ojos, null, resultado);
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.semen, null, resultado);
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.dedo, null, resultado);
				return;
			}
			if (parteEstimulante == ParteQuePuedeEstimular.semen)
			{
				ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.ojos, null, resultado);
				return;
			}
			if (parteEstimulante != ParteQuePuedeEstimular.dedo)
			{
				return;
			}
			ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, ParteQuePuedeEstimular.ojos, null, resultado);
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x00063924 File Offset: 0x00061B24
		private static void OverrideRecibidaGeneric(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, bool addSelf, ICollection<ConsensualTree.Data> resultado)
		{
			if (addSelf)
			{
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, parteEstimulada, parteEstimulante, null, resultado);
			}
			if (!parteEstimulada.EsHole())
			{
				if (ParteDelCuerpoHumanoHelper.partesDeFacialSet.Contains((int)parteEstimulada))
				{
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, parteEstimulante, null, resultado);
				}
				if (ParteDelCuerpoHumanoHelper.partesDeTraseroSet.Contains((int)parteEstimulada))
				{
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, parteEstimulante, null, resultado);
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, parteEstimulante, null, resultado);
				}
				if (ParteDelCuerpoHumanoHelper.partesDeEntrepiernaSet.Contains((int)parteEstimulada))
				{
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, parteEstimulante, null, resultado);
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, parteEstimulante, null, resultado);
				}
			}
			switch (parteEstimulada)
			{
			case ParteDelCuerpoHumano.pecho:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.axilas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cuello, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.espalda:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cuello, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.abdomen:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.hombligo, parteEstimulante, null, resultado);
				break;
			case ParteDelCuerpoHumano.cintura:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.caderas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.cabeza:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cuello, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
				break;
			case ParteDelCuerpoHumano.mandibula:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labios, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cuello, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.labios:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.lengua, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.bocaInterno:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.lengua, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.nariz:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labios, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.mejillas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labios, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.hombros:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.axilas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cuello, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.brazos:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.axilas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.anteBrazos:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.manos, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.brazos, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.senos:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.pezones, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.coxis:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.vientre:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.nalgas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.perineo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.vientreBajo:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.clitoris, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labiosVaginales, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.perineo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.labiosVaginales:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.clitoris, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.perineo:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labiosVaginales, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.piernas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.perineo, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.rodillas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.piernas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.canillas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.pies, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.piernas, parteEstimulante, null, resultado);
				return;
			default:
				return;
			}
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x00063C30 File Offset: 0x00061E30
		private static void OverrideInvertedRecibidaGeneric(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, bool addSelf, ICollection<ConsensualTree.Data> resultado)
		{
			if (addSelf)
			{
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, parteEstimulada, parteEstimulante, null, resultado);
			}
			switch (parteEstimulada)
			{
			case ParteDelCuerpoHumano.cuello:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.espalda, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.hombros, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cabeza, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.pecho, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.mandibula, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
				return;
			case ParteDelCuerpoHumano.labios:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nariz, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.mejillas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.mandibula, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.bocaInterno:
			{
				for (int i = 0; i < ParteDelCuerpoHumanoHelper.partesDeFacial.Count; i++)
				{
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeFacial[i], parteEstimulante, null, resultado);
				}
				return;
			}
			case ParteDelCuerpoHumano.axilas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.hombros, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.brazos, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.pecho, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.brazos:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.anteBrazos, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.manos:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.anteBrazos, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.senos:
				break;
			case ParteDelCuerpoHumano.pezones:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, parteEstimulante, null, resultado);
				break;
			case ParteDelCuerpoHumano.nalgas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.caderas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.piernas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.coxis, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.cintura, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.vientreBajo:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.caderas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientre, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.piernas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.labiosVaginales:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.perineo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.clitoris:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labiosVaginales, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.perineo:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.piernas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.ano:
			{
				for (int j = 0; j < ParteDelCuerpoHumanoHelper.partesDeTrasero.Count; j++)
				{
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeTrasero[j], parteEstimulante, null, resultado);
				}
				return;
			}
			case ParteDelCuerpoHumano.vag:
			{
				for (int k = 0; k < ParteDelCuerpoHumanoHelper.partesDeEntrepierna.Count; k++)
				{
					ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumanoHelper.partesDeEntrepierna[k], parteEstimulante, null, resultado);
				}
				return;
			}
			case ParteDelCuerpoHumano.hombligo:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.abdomen, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.piernas:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.canillas, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.rodillas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.pies:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.canillas, parteEstimulante, null, resultado);
				return;
			case ParteDelCuerpoHumano.lengua:
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labios, parteEstimulante, null, resultado);
				ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, parteEstimulante, null, resultado);
				return;
			default:
				return;
			}
			ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.pecho, parteEstimulante, null, resultado);
			ConsensualTree.Add(tipoDeEstimulo, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.espalda, parteEstimulante, null, resultado);
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00063F38 File Offset: 0x00062138
		public static IReadOnlyList<ConsensualTree.Data> Overrides(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> valueTuple = new ConsensualTree.Data
			{
				tipoDeEstimulo = tipoDeEstimulo,
				direccion = direccion,
				parteEstimulada = parteEstimulada,
				parteEstimulante = parteEstimulante,
				tag = tag
			}.ToKey();
			List<ConsensualTree.Data> list;
			if (!ConsensualTree.m_overridesMem.TryGetValue(valueTuple, out list))
			{
				list = ConsensualTree.OverridesSet(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, tag).ToList<ConsensualTree.Data>();
				list.Sort((ConsensualTree.Data x, ConsensualTree.Data y) => y.Getpriorida().CompareTo(x.Getpriorida()));
				ConsensualTree.m_overridesMem.Add(valueTuple, list);
			}
			return list;
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x00063FD4 File Offset: 0x000621D4
		public static IReadOnlyCollection<ConsensualTree.Data> OverridesSet(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> valueTuple = new ConsensualTree.Data
			{
				tipoDeEstimulo = tipoDeEstimulo,
				direccion = direccion,
				parteEstimulada = parteEstimulada,
				parteEstimulante = parteEstimulante,
				tag = tag
			}.ToKey();
			HashSet<ConsensualTree.Data> hashSet;
			if (!ConsensualTree.m_overridesSetMem.TryGetValue(valueTuple, out hashSet))
			{
				hashSet = new HashSet<ConsensualTree.Data>();
				ConsensualTree.m_overridesSetMem.Add(valueTuple, hashSet);
				ConsensualTree.Overrides(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, tag, hashSet);
			}
			return hashSet;
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x0006404A File Offset: 0x0006224A
		public static void Overrides(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				ConsensualTree.OverridesRecibidas(tipoDeEstimulo, parteEstimulada, parteEstimulante, tag, resultado);
				return;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			ConsensualTree.OverridesDadas(tipoDeEstimulo, parteEstimulada, parteEstimulante, tag, resultado);
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x00064084 File Offset: 0x00062284
		private static void OverridesDadas(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.None:
				Debug.LogWarning("tipo de TipoDeEstimulo es None");
				return;
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.coital:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return;
			case TipoDeEstimulo.visual:
				ConsensualTree.OverrideVisualDada(parteEstimulada, parteEstimulante, tag, resultado);
				ConsensualTree.OverrideDadasGenericVisual(parteEstimulada, parteEstimulante, tag, false, resultado);
				return;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x0006410D File Offset: 0x0006230D
		private static void OverrideVisualDada(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (parteEstimulante.EsPenetrador())
			{
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, parteEstimulante, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, parteEstimulante, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, parteEstimulante, tag, resultado);
			}
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x0006413C File Offset: 0x0006233C
		private static void OverridesRecibidas(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			ConsensualTree.OverrideRecibidaGeneric(tipoDeEstimulo, parteEstimulada, parteEstimulante, tag, false, resultado);
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.None:
				Debug.LogWarning("tipo de TipoDeEstimulo es None");
				return;
			case TipoDeEstimulo.tactil:
				ConsensualTree.OverrideTactilRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.visual:
				ConsensualTree.OverrideVisualRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.coital:
				ConsensualTree.OverrideCoitalRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.desvestidura:
				ConsensualTree.OverrideDesvestiduraForzadaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.peticionDesvestidura:
				ConsensualTree.OverrideDesvestiduraPedidaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.ejecucionDePose:
				ConsensualTree.OverridePoseForzadaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.peticionEjecucionDePose:
				ConsensualTree.OverridePosePedidaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.guiandoBone:
				ConsensualTree.OverrideBonePedidaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			case TipoDeEstimulo.manipulandoBone:
				ConsensualTree.OverrideBoneForzadaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				return;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00064220 File Offset: 0x00062420
		private static void OverrideVisualRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			TipoDeEstimuloVisual tipoDeEstimuloVisual = parteEstimulante.ObtenerTipoDeEstimuloVisual();
			switch (tipoDeEstimuloVisual)
			{
			case TipoDeEstimuloVisual.None:
				Debug.LogWarning("tipo de TipoDeEstimuloVisual es None");
				break;
			case TipoDeEstimuloVisual.normal:
				break;
			case TipoDeEstimuloVisual.fotografiada:
				return;
			default:
				throw new ArgumentOutOfRangeException(tipoDeEstimuloVisual.ToString());
			}
			for (int i = 0; i < ParteQuePuedeEstimularHelper.puedenTocar.Count; i++)
			{
				ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimularHelper.puedenTocar[i];
				ConsensualTree.OverrideTactilRecibida(parteEstimulada, parteQuePuedeEstimular, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteEstimulada, parteQuePuedeEstimular, tag, resultado);
			}
			ConsensualTree.Add(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteEstimulada, ParteQuePuedeEstimular.propSexToy, tag, resultado);
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x000642A8 File Offset: 0x000624A8
		private static void OverrideTactilRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (tag == "golpe")
			{
				Debug.LogWarning("por ahora los golpes NO son consentidos");
				return;
			}
			if (parteEstimulante.EsPenetrador())
			{
				if (parteEstimulada.PuedeSerPenetrada())
				{
					ConsensualTree.OverrideCoitalRecibida(parteEstimulada, parteEstimulante, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteEstimulada, parteEstimulante, tag, resultado);
				}
				if (parteEstimulada.EsTrasero())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, parteEstimulante, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, parteEstimulante, tag, resultado);
				}
				if (parteEstimulada.EsEntrepierna())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, parteEstimulante, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, parteEstimulante, tag, resultado);
				}
				if (parteEstimulada.EsAproximadoOral())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.bocaInterno, parteEstimulante, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, parteEstimulante, tag, resultado);
				}
			}
			if (parteEstimulante.EsHumpingParte())
			{
				if (parteEstimulada.EsTrasero() || parteEstimulada.EsEntrepierna())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
				}
				if (parteEstimulada.EsAproximadoOral())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, tag, resultado);
				}
			}
			if (parteEstimulante.EsManipuladorParte())
			{
				ConsensualTree.OverrideBoneForzadaRecibida(parteEstimulada, parteEstimulante, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.manipulandoBone, DireccionDeEstimulo.recibida, parteEstimulada, parteEstimulante, tag, resultado);
				if (parteEstimulada.EsTrasero())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.dedo, tag, resultado);
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.propSexToy, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.dedo, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.propSexToy, tag, resultado);
				}
				if (parteEstimulada.EsEntrepierna())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.dedo, tag, resultado);
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.propSexToy, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.dedo, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.propSexToy, tag, resultado);
				}
				if (parteEstimulada.EsAproximadoOral())
				{
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.dedo, tag, resultado);
					ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.propSexToy, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.dedo, tag, resultado);
					ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.propSexToy, tag, resultado);
				}
			}
			if (parteEstimulante == ParteQuePuedeEstimular.semen && (parteEstimulada.EsTrozoDelantero() || parteEstimulada.EsTrozoTrasero()))
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
			}
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00003B39 File Offset: 0x00001D39
		private static void OverrideCoitalRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x000644CC File Offset: 0x000626CC
		private static void OverrideDesvestiduraForzadaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (parteEstimulada.EsTrasero())
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
			}
			if (parteEstimulada.EsEntrepierna())
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
			}
			if (parteEstimulada.EsAproximadoOral())
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, tag, resultado);
			}
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00003B39 File Offset: 0x00001D39
		private static void OverrideDesvestiduraPedidaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00064534 File Offset: 0x00062734
		private static void OverridePoseForzadaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (parteEstimulada.EsTrasero())
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, tag, resultado);
			}
			if (parteEstimulada.EsEntrepierna())
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, tag, resultado);
			}
			if (parteEstimulada.EsAproximadoOral())
			{
				ConsensualTree.OverrideCoitalRecibida(ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, tag, resultado);
				ConsensualTree.Add(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, tag, resultado);
			}
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00003B39 File Offset: 0x00001D39
		private static void OverridePosePedidaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00003B39 File Offset: 0x00001D39
		private static void OverrideBoneForzadaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00003B39 File Offset: 0x00001D39
		private static void OverrideBonePedidaRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x0006459C File Offset: 0x0006279C
		private static bool InteraccionEsValida(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				switch (tipoDeEstimulo)
				{
				case TipoDeEstimulo.tactil:
					return parteEstimulante.PuedeTocar();
				case TipoDeEstimulo.visual:
					return parteEstimulante.PuedeVer();
				case TipoDeEstimulo.coital:
					return parteEstimulante.EsPenetrador() && parteEstimulada.EsHole();
				case TipoDeEstimulo.desvestidura:
				case TipoDeEstimulo.peticionDesvestidura:
				case TipoDeEstimulo.ejecucionDePose:
				case TipoDeEstimulo.peticionEjecucionDePose:
					return parteEstimulante.EsManipuladorParte() || parteEstimulante.EsConmunicadorParte();
				case TipoDeEstimulo.guiandoBone:
				case TipoDeEstimulo.manipulandoBone:
					return (parteEstimulante.EsManipuladorParte() || parteEstimulante.EsConmunicadorParte()) && parteEstimulada.EsSkeleto();
				}
				throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			if (tipoDeEstimulo == TipoDeEstimulo.visual)
			{
				return parteEstimulada == ParteDelCuerpoHumano.ojos;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x0006468C File Offset: 0x0006288C
		private static void Add(TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular parteEstimulante, string tag, ICollection<ConsensualTree.Data> resultado)
		{
			if (ConsensualTree.InteraccionEsValida(tipoDeEstimulo, direccion, parteEstimulada, parteEstimulante, tag))
			{
				resultado.Add(new ConsensualTree.Data
				{
					tipoDeEstimulo = tipoDeEstimulo,
					direccion = direccion,
					parteEstimulada = parteEstimulada,
					parteEstimulante = parteEstimulante,
					tag = tag
				});
			}
		}

		// Token: 0x040012C6 RID: 4806
		private static readonly Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, List<ConsensualTree.Data>> m_overridesMem = new Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, List<ConsensualTree.Data>>();

		// Token: 0x040012C7 RID: 4807
		private static readonly Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, HashSet<ConsensualTree.Data>> m_overridesSetMem = new Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, HashSet<ConsensualTree.Data>>();

		// Token: 0x040012C8 RID: 4808
		private static readonly Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, List<ConsensualTree.Data>> m_overridesInvertedMem = new Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, List<ConsensualTree.Data>>();

		// Token: 0x040012C9 RID: 4809
		private static readonly Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, HashSet<ConsensualTree.Data>> m_overridesInvertedSetMem = new Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>, HashSet<ConsensualTree.Data>>();

		// Token: 0x0200046A RID: 1130
		[Serializable]
		public struct Data : IEquatable<ConsensualTree.Data>
		{
			// Token: 0x060018A5 RID: 6309 RVA: 0x00064709 File Offset: 0x00062909
			public ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> ToKey()
			{
				return new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>(this.tipoDeEstimulo, this.direccion, this.parteEstimulada, this.parteEstimulante, this.tag);
			}

			// Token: 0x060018A6 RID: 6310 RVA: 0x00064730 File Offset: 0x00062930
			public double Getpriorida()
			{
				double num = (double)this.tipoDeEstimulo.Prioridad();
				switch (this.tipoDeEstimulo)
				{
				case TipoDeEstimulo.tactil:
					num *= this.parteEstimulante.Prioridad();
					return num * (double)this.parteEstimulada.PrioridadTactilFixed(Sexo.femenino);
				case TipoDeEstimulo.visual:
				case TipoDeEstimulo.peticionDesvestidura:
				case TipoDeEstimulo.peticionEjecucionDePose:
				case TipoDeEstimulo.guiandoBone:
					num *= this.parteEstimulante.Prioridad();
					return num * (double)this.parteEstimulada.PrioridadVisualFixed(Sexo.femenino);
				case TipoDeEstimulo.coital:
					num *= this.parteEstimulante.Prioridad();
					return num * (double)this.parteEstimulada.PrioridadCoitalFixed(Sexo.femenino);
				case TipoDeEstimulo.desvestidura:
				case TipoDeEstimulo.ejecucionDePose:
				case TipoDeEstimulo.manipulandoBone:
					num *= this.parteEstimulante.PrioridadManipulativa();
					return num * (double)this.parteEstimulada.PrioridadTactilFixed(Sexo.femenino);
				}
				throw new ArgumentOutOfRangeException(this.tipoDeEstimulo.ToString());
			}

			// Token: 0x060018A7 RID: 6311 RVA: 0x00064834 File Offset: 0x00062A34
			public static ConsensualTree.Data FromKey(ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string> key)
			{
				return new ConsensualTree.Data
				{
					tipoDeEstimulo = key.Item1,
					direccion = key.Item2,
					parteEstimulada = key.Item3,
					parteEstimulante = key.Item4,
					tag = key.Item5
				};
			}

			// Token: 0x060018A8 RID: 6312 RVA: 0x0006488C File Offset: 0x00062A8C
			public override bool Equals(object obj)
			{
				if (obj is ConsensualTree.Data)
				{
					ConsensualTree.Data data = (ConsensualTree.Data)obj;
					return this.Equals(data);
				}
				return false;
			}

			// Token: 0x060018A9 RID: 6313 RVA: 0x000648B4 File Offset: 0x00062AB4
			public bool Equals(ConsensualTree.Data p)
			{
				return this.tipoDeEstimulo == p.tipoDeEstimulo && this.direccion == p.direccion && this.parteEstimulada == p.parteEstimulada && this.parteEstimulante == p.parteEstimulante && (this.tag == p.tag || (string.IsNullOrEmpty(this.tag) && string.IsNullOrEmpty(p.tag)));
			}

			// Token: 0x060018AA RID: 6314 RVA: 0x0006492C File Offset: 0x00062B2C
			public override int GetHashCode()
			{
				return new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, string>(this.tipoDeEstimulo, this.direccion, this.parteEstimulada, this.parteEstimulante, (this.tag == null) ? string.Empty : this.tag).GetHashCode();
			}

			// Token: 0x060018AB RID: 6315 RVA: 0x00064979 File Offset: 0x00062B79
			public static bool operator ==(ConsensualTree.Data lhs, ConsensualTree.Data rhs)
			{
				return lhs.Equals(rhs);
			}

			// Token: 0x060018AC RID: 6316 RVA: 0x00064983 File Offset: 0x00062B83
			public static bool operator !=(ConsensualTree.Data lhs, ConsensualTree.Data rhs)
			{
				return !(lhs == rhs);
			}

			// Token: 0x040012CA RID: 4810
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x040012CB RID: 4811
			public DireccionDeEstimulo direccion;

			// Token: 0x040012CC RID: 4812
			public ParteDelCuerpoHumano parteEstimulada;

			// Token: 0x040012CD RID: 4813
			public ParteQuePuedeEstimular parteEstimulante;

			// Token: 0x040012CE RID: 4814
			public string tag;
		}
	}
}
