using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000FA RID: 250
	public sealed class GeneradorDeConjuntosDeRopaAleatoriosFemeninos : Singleton<GeneradorDeConjuntosDeRopaAleatoriosFemeninos>
	{
		// Token: 0x06000639 RID: 1593 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void InitData(bool esEditorTime)
		{
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001D2FA File Offset: 0x0001B4FA
		public static GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor ObtenerTipoAleatoriamente()
		{
			return (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor)typeof(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor).GetEnumRandomIgnoranzoPrimero();
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001D310 File Offset: 0x0001B510
		public static Color ObtenerColor(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipo, MapaDeRopa.TipoDePrenda tipoDePrenda, Color? @base)
		{
			if (@base == null)
			{
				@base = new Color?(Color.white);
			}
			switch (tipo)
			{
			case GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.None:
			case GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.neutral:
				switch (tipoDePrenda)
				{
				case MapaDeRopa.TipoDePrenda.None:
					return Color.white;
				case MapaDeRopa.TipoDePrenda.underwearInferior:
				case MapaDeRopa.TipoDePrenda.underwearSuperior:
				case MapaDeRopa.TipoDePrenda.socks:
				case MapaDeRopa.TipoDePrenda.gloves:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaInterior.Count == 0)
					{
						return Color.white;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaInterior.RandomItem<Color>();
				case MapaDeRopa.TipoDePrenda.inferior:
				case MapaDeRopa.TipoDePrenda.superior:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaNormal.Count == 0)
					{
						return Color.white;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaNormal.RandomItem<Color>();
				case MapaDeRopa.TipoDePrenda.shoes:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaZapatos.Count == 0)
					{
						return Color.white;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaZapatos.RandomItem<Color>();
				case MapaDeRopa.TipoDePrenda.superiorExterior:
				case MapaDeRopa.TipoDePrenda.hat:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaExterior.Count == 0)
					{
						return Color.white;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaExterior.RandomItem<Color>();
				case MapaDeRopa.TipoDePrenda.swimsuit:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaInterior.Count == 0)
					{
						return Color.white;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaInterior.RandomItem<Color>();
				case MapaDeRopa.TipoDePrenda.accessories:
				case MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories:
				case MapaDeRopa.TipoDePrenda.underwearInferiorAccessories:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaAccesorios.Count == 0)
					{
						return Color.black;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaAccesorios.RandomItem<Color>();
				case MapaDeRopa.TipoDePrenda.glases:
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaGlases.Count == 0)
					{
						return Color.black;
					}
					return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.coloresNeutralesParaGlases.RandomItem<Color>();
				default:
					throw new ArgumentOutOfRangeException(tipoDePrenda.ToString());
				}
				break;
			case GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.igual:
				return @base.Value;
			case GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.bajoCambioDeContraste:
			{
				float num;
				float num2;
				float num3;
				Color.RGBToHSV(@base.Value, out num, out num2, out num3);
				num = Mathf.InverseLerp(0f, 360f, Mathf.Lerp(0f, 360f, num).Random360(20f));
				num2 = num2.Random01Lerp(0.333f);
				num3 = num3.Random01Lerp(0.333f);
				return Color.HSVToRGB(num, num2, num3);
			}
			case GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.altoCambioDeContraste:
			{
				float num4;
				float num5;
				float num6;
				Color.RGBToHSV(@base.Value, out num4, out num5, out num6);
				num4 = Mathf.InverseLerp(0f, 360f, Mathf.Lerp(0f, 360f, num4).Random360(45f));
				num5 = num5.Random01Lerp(0.75f);
				num6 = num6.Random01Lerp(0.75f);
				return Color.HSVToRGB(num4, num5, num6);
			}
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001D558 File Offset: 0x0001B758
		public static void Colores(out Color superior, out Color inferior, out Color interioresSuperior, out Color interioresInferior, out Color exteriores, out Color medias, out Color zapatos, out Color glases, out Color accessorios)
		{
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor2 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			if (tipoDeColor2 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.altoCambioDeContraste)
			{
				tipoDeColor2 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.bajoCambioDeContraste;
			}
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor3 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor4 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			if (tipoDeColor4 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.altoCambioDeContraste)
			{
				tipoDeColor4 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.bajoCambioDeContraste;
			}
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor5 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor6 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor7 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			if (tipoDeColor7 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.igual || tipoDeColor7 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.bajoCambioDeContraste)
			{
				tipoDeColor7 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.altoCambioDeContraste;
			}
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor8 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			if (tipoDeColor8 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.igual || tipoDeColor8 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.bajoCambioDeContraste)
			{
				tipoDeColor8 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.altoCambioDeContraste;
			}
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor tipoDeColor9 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerTipoAleatoriamente();
			if (tipoDeColor9 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.igual || tipoDeColor9 == GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.bajoCambioDeContraste)
			{
				tipoDeColor9 = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeColor.altoCambioDeContraste;
			}
			Color color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
			inferior = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor, MapaDeRopa.TipoDePrenda.inferior, new Color?(color)));
			superior = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor2, MapaDeRopa.TipoDePrenda.superior, new Color?(inferior)));
			interioresInferior = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.underwearHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor3, MapaDeRopa.TipoDePrenda.underwearInferior, new Color?(color)));
			interioresSuperior = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.underwearHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor4, MapaDeRopa.TipoDePrenda.underwearSuperior, new Color?(interioresInferior)));
			exteriores = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor5, MapaDeRopa.TipoDePrenda.superiorExterior, new Color?(color)));
			zapatos = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor6, MapaDeRopa.TipoDePrenda.shoes, new Color?(color)));
			medias = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor7, MapaDeRopa.TipoDePrenda.socks, new Color?(color)));
			glases = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor8, MapaDeRopa.TipoDePrenda.glases, new Color?(color)));
			accessorios = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.clothingHueConstraint.Apply(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerColor(tipoDeColor9, MapaDeRopa.TipoDePrenda.accessories, new Color?(color)));
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0001D77E File Offset: 0x0001B97E
		public void GenerarRandom(List<Pieza> resultado, bool incluirShoes, ItemQuality lookingFor, float lookingForPrecisionPercentage)
		{
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.GenerarRandom(Sexo.femenino, this.m_TiposDePrendaDeConjunto, resultado, incluirShoes, lookingFor, lookingForPrecisionPercentage);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0001D794 File Offset: 0x0001B994
		public static void GenerarRandom(Sexo paraSexo, DiccionaryEnum<GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto, List<MapaDeRopa.TipoDePrenda>> tiposDePrendaDeConjunto, List<Pieza> resultado, bool incluirShoes, ItemQuality lookingFor, float lookingForPrecisionPercentage)
		{
			try
			{
				KeyValuePair<int, List<MapaDeRopa.TipoDePrenda>> keyValuePair = tiposDePrendaDeConjunto.ElementAt(tiposDePrendaDeConjunto.RandomIndexConPreferenciaAlPrimero(90f, -1));
				Color color;
				Color color2;
				Color color3;
				Color color4;
				Color color5;
				Color color6;
				Color color7;
				Color color8;
				Color color9;
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.Colores(out color, out color2, out color3, out color4, out color5, out color6, out color7, out color8, out color9);
				resultado.Clear();
				bool flag = true;
				foreach (MapaDeRopa.TipoDePrenda tipoDePrenda in keyValuePair.Value)
				{
					if (tipoDePrenda != MapaDeRopa.TipoDePrenda.shoes || incluirShoes)
					{
						int num = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.CantiadadDePrendasPorTipoDePrenda(tipoDePrenda);
						num = Random.Range(1, num + 1);
						for (int i = 0; i < num; i++)
						{
							try
							{
								MapaDeRopa.RopaData ropaData;
								string text;
								if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerMaterialIDParaTipoDePrendaV2(paraSexo, tipoDePrenda, GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_piezasAddedID, out ropaData, ref GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_materialsDataTemp, out text, lookingFor, lookingForPrecisionPercentage))
								{
									if (!GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_piezasAddedID.Contains(text))
									{
										bool flag2 = flag;
										bool? flag3;
										if (ropaData == null)
										{
											flag3 = null;
										}
										else
										{
											MapaDeRopa.RopaData.ShoesConfig shoesConfig = ropaData.shoesConfig;
											flag3 = ((shoesConfig != null) ? new bool?(shoesConfig.puedeTenerMedias) : null);
										}
										bool? flag4 = flag3;
										flag = flag2 & flag4.GetValueOrDefault(true);
										if (tipoDePrenda != MapaDeRopa.TipoDePrenda.socks || flag)
										{
											Pieza pieza = new Pieza
											{
												ropaIDString = text,
												materiales = new List<SlotDeMaterialDeRopa>()
											};
											for (int j = 0; j < GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_materialsDataTemp.Count; j++)
											{
												MaterialParaRopaData materialParaRopaData = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_materialsDataTemp[j];
												Color color10;
												if (!materialParaRopaData.puedeTenerCustomColor)
												{
													color10 = Color.white;
												}
												else
												{
													switch (tipoDePrenda)
													{
													case MapaDeRopa.TipoDePrenda.None:
														color10 = Color.white;
														break;
													case MapaDeRopa.TipoDePrenda.underwearInferior:
														color10 = color4;
														break;
													case MapaDeRopa.TipoDePrenda.underwearSuperior:
														color10 = color3;
														break;
													case MapaDeRopa.TipoDePrenda.inferior:
														color10 = color2;
														break;
													case MapaDeRopa.TipoDePrenda.superior:
														color10 = color;
														break;
													case MapaDeRopa.TipoDePrenda.shoes:
														color10 = color7;
														break;
													case MapaDeRopa.TipoDePrenda.superiorExterior:
													case MapaDeRopa.TipoDePrenda.hat:
														color10 = color5;
														break;
													case MapaDeRopa.TipoDePrenda.swimsuit:
														color10 = color4;
														break;
													case MapaDeRopa.TipoDePrenda.socks:
													case MapaDeRopa.TipoDePrenda.gloves:
														color10 = color6;
														break;
													case MapaDeRopa.TipoDePrenda.accessories:
													case MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories:
													case MapaDeRopa.TipoDePrenda.underwearInferiorAccessories:
														color10 = color9;
														break;
													case MapaDeRopa.TipoDePrenda.glases:
														color10 = color8;
														break;
													default:
														throw new ArgumentOutOfRangeException(tipoDePrenda.ToString());
													}
												}
												if (materialParaRopaData.esTransparente)
												{
													color10.a = Random.Range(0.8f, 1f);
												}
												pieza.materiales.Add(new SlotDeMaterialDeRopa(materialParaRopaData.stringId)
												{
													añadirUnaCopia = true,
													materialSlot = j,
													color = color10
												});
											}
											GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_piezasAddedID.Add(pieza.ropaIDString);
											resultado.Add(pieza);
										}
									}
								}
							}
							finally
							{
								GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_materialsDataTemp.Clear();
							}
						}
					}
				}
			}
			finally
			{
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_piezasAddedID.Clear();
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0001DA88 File Offset: 0x0001BC88
		public static Pieza GenerarPiezaDeRopa(string prendaID, List<MaterialParaRopaData> materialsData)
		{
			Pieza pieza = new Pieza
			{
				ropaIDString = prendaID,
				materiales = new List<SlotDeMaterialDeRopa>()
			};
			for (int i = 0; i < materialsData.Count; i++)
			{
				MaterialParaRopaData materialParaRopaData = materialsData[i];
				Color color;
				if (!materialParaRopaData.puedeTenerCustomColor)
				{
					color = Color.white;
				}
				else
				{
					color = Random.ColorHSV();
					color.a = 1f;
				}
				if (materialParaRopaData.esTransparente)
				{
					color.a = Random.Range(0.8f, 1f);
				}
				pieza.materiales.Add(new SlotDeMaterialDeRopa(materialParaRopaData.stringId)
				{
					añadirUnaCopia = true,
					materialSlot = i,
					color = color
				});
			}
			return pieza;
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0001DB34 File Offset: 0x0001BD34
		public static int CantiadadDePrendasPorTipoDePrenda(MapaDeRopa.TipoDePrenda tipo)
		{
			switch (tipo)
			{
			case MapaDeRopa.TipoDePrenda.None:
			case MapaDeRopa.TipoDePrenda.underwearInferior:
			case MapaDeRopa.TipoDePrenda.underwearSuperior:
			case MapaDeRopa.TipoDePrenda.inferior:
			case MapaDeRopa.TipoDePrenda.superior:
			case MapaDeRopa.TipoDePrenda.shoes:
			case MapaDeRopa.TipoDePrenda.superiorExterior:
			case MapaDeRopa.TipoDePrenda.swimsuit:
			case MapaDeRopa.TipoDePrenda.glases:
				return 1;
			case MapaDeRopa.TipoDePrenda.socks:
			case MapaDeRopa.TipoDePrenda.gloves:
			case MapaDeRopa.TipoDePrenda.hat:
				return 1;
			case MapaDeRopa.TipoDePrenda.accessories:
				return 5;
			case MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories:
			case MapaDeRopa.TipoDePrenda.underwearInferiorAccessories:
				return 5;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0001DBA0 File Offset: 0x0001BDA0
		[Obsolete("", true)]
		public static IRopaParaAvatar ObtenerMapa()
		{
			IRopaParaAvatar ropaParaAvatar;
			if (AsyncSingleton<RopaParaAvatarUnificado>.IsInScene)
			{
				ropaParaAvatar = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			}
			else
			{
				ropaParaAvatar = null;
			}
			return ropaParaAvatar;
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00004252 File Offset: 0x00002452
		public int RenderQueueAdicionDeTipoDePrenda(MapaDeRopa.TipoDePrenda tipo)
		{
			return 0;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001DBC0 File Offset: 0x0001BDC0
		public static bool ObtenerMaterialIDParaTipoDePrendaV2(Sexo paraSexo, MapaDeRopa.TipoDePrenda tipo, IReadOnlyCollection<string> piesasAdded, out MapaDeRopa.RopaData prendaData, ref List<MaterialParaRopaData> materialsData, out string prendaID, ItemQuality lookingFor, float lookingForPrecisionPercentage)
		{
			bool flag;
			try
			{
				RopaParaAvatarUnificado mapaDeRopaData = AsyncSingleton<RopaParaAvatarUnificado>.instance;
				IReadOnlyList<MapaDeRopa.RopaData> readOnlyList = mapaDeRopaData.prendasPorTipo[tipo];
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDePiezasemp.AddRange(from p in readOnlyList
					where p.paraSexo == paraSexo && mapaDeRopaData.PiezaEsMainPrenda(p.stringId) && !piesasAdded.Contains(p.stringId)
					select p into m
					group m by Mathf.Abs(m.itemQuality - lookingFor));
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDePiezasemp.Shuffle<IGrouping<int, MapaDeRopa.RopaData>>();
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDePiezasemp.Sort((IGrouping<int, MapaDeRopa.RopaData> g1, IGrouping<int, MapaDeRopa.RopaData> g2) => g1.Key.CompareTo(g2.Key));
				for (int i = 0; i < GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDePiezasemp.Count; i++)
				{
					foreach (MapaDeRopa.RopaData ropaData in GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDePiezasemp[i])
					{
						if (ropaData.probabilidadConfig.chance.ProcPorcentaje(1f))
						{
							GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_IDsTemp.Add(ropaData.stringId);
						}
					}
				}
				if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_IDsTemp.Count == 0)
				{
					if (readOnlyList.Count > 0 && tipo.EsEsencial(paraSexo))
					{
						MapaDeRopa.RopaData ropaData2 = readOnlyList.RandomItemReadOnly<MapaDeRopa.RopaData>();
						if (ropaData2 != null)
						{
							GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_IDsTemp.Add(ropaData2.stringId);
						}
					}
					if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_IDsTemp.Count == 0)
					{
						prendaID = null;
						prendaData = null;
						return false;
					}
				}
				prendaID = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_IDsTemp.RandomItemConPreferenciaAlPrimeroNoChaceMod(lookingForPrecisionPercentage, -1);
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerMaterialesParaPrenda(prendaID, out prendaData, ref materialsData, lookingFor, lookingForPrecisionPercentage);
				flag = true;
			}
			finally
			{
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDePiezasemp.Clear();
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_IDsTemp.Clear();
			}
			return flag;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001DDC0 File Offset: 0x0001BFC0
		public static void ObtenerMaterialesParaPrenda(string prendaID, out MapaDeRopa.RopaData prendaData, ref List<MaterialParaRopaData> materialsData, ItemQuality lookingFor, float lookingForPrecisionPercentage)
		{
			if (materialsData == null)
			{
				materialsData = new List<MaterialParaRopaData>();
			}
			if (materialsData.Count > 0)
			{
				materialsData.Clear();
			}
			try
			{
				RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
				prendaData = instance.ObtenerData(prendaID);
				string text = (string.IsNullOrWhiteSpace(prendaData.idParaMaterialesString) ? prendaID : prendaData.idParaMaterialesString);
				IReadOnlyList<MaterialParaRopaData> readOnlyList;
				if (AsyncSingleton<MaterialesParaRopa>.instance.materialesDePrenda.TryGetValue(text, out readOnlyList))
				{
					GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatTemp.AddRange(readOnlyList);
				}
				if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatTemp.Count > 0)
				{
					GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatTemp.Shuffle<MaterialParaRopaData>();
					int num = Mathf.Clamp(prendaData.cantidadDeMateriales, 0, 100);
					Func<MaterialParaRopaData, int> <>9__0;
					for (int i = 0; i < num; i++)
					{
						try
						{
							foreach (MaterialParaRopaData materialParaRopaData in GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatTemp)
							{
								if (materialParaRopaData.indexes.Contains(i))
								{
									GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp.Add(materialParaRopaData);
								}
							}
							if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp.Count == 0)
							{
								materialsData.Add(null);
							}
							else if (GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp.Count == 1)
							{
								materialsData.Add(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp[0]);
							}
							else
							{
								List<IGrouping<int, MaterialParaRopaData>> gruposDeMaterialesTemp = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDeMaterialesTemp;
								IEnumerable<MaterialParaRopaData> matDeIndexTemp = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp;
								Func<MaterialParaRopaData, int> func;
								if ((func = <>9__0) == null)
								{
									func = (<>9__0 = (MaterialParaRopaData m) => Mathf.Abs(m.itemQuality - lookingFor));
								}
								gruposDeMaterialesTemp.AddRange(matDeIndexTemp.GroupBy(func));
								GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDeMaterialesTemp.Sort((IGrouping<int, MaterialParaRopaData> g1, IGrouping<int, MaterialParaRopaData> g2) => g1.Key.CompareTo(g2.Key));
								bool flag = false;
								int num2 = 10;
								while (!flag && num2 > 0)
								{
									num2--;
									foreach (MaterialParaRopaData materialParaRopaData2 in GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDeMaterialesTemp.RandomItemConPreferenciaAlPrimeroNoChaceMod(lookingForPrecisionPercentage, -1))
									{
										if (materialParaRopaData2.chanceMaterial.ProcPorcentaje(1f))
										{
											flag = true;
											materialsData.Add(materialParaRopaData2);
											break;
										}
									}
								}
								if (!flag && GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp.Count > 0)
								{
									materialsData.Add(GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp.RandomItem<MaterialParaRopaData>());
								}
							}
						}
						finally
						{
							GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_gruposDeMaterialesTemp.Clear();
							GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatDeIndexTemp.Clear();
						}
					}
				}
			}
			finally
			{
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.m_MatTemp.Clear();
			}
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001E084 File Offset: 0x0001C284
		[Obsolete("", true)]
		public void LoadMaterialesParaPrenda(string prendaID, List<MaterialParaRopaData> resultado)
		{
			RopaParaAvatarBase<RopaParaAvatarUnificado> instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			MaterialesParaRopa instance2 = AsyncSingleton<MaterialesParaRopa>.instance;
			if (instance.Contiene(prendaID))
			{
				for (int i = 0; i < instance2.dataDeMateriales.Count; i++)
				{
					MaterialParaRopaData materialParaRopaData = instance2.dataDeMateriales[i];
					if (materialParaRopaData.EsParaRopaId(prendaID))
					{
						resultado.Add(materialParaRopaData);
					}
				}
			}
		}

		// Token: 0x04000420 RID: 1056
		public static readonly List<Color> coloresNeutralesParaZapatos = new List<Color>
		{
			Color.white,
			Color.black
		};

		// Token: 0x04000421 RID: 1057
		public static readonly List<Color> coloresNeutralesParaInterior = new List<Color>
		{
			Color.white,
			Color.black
		};

		// Token: 0x04000422 RID: 1058
		public static readonly List<Color> coloresNeutralesParaNormal = new List<Color>
		{
			Color.white,
			Color.black
		};

		// Token: 0x04000423 RID: 1059
		public static readonly List<Color> coloresNeutralesParaExterior = new List<Color>
		{
			Color.white,
			Color.black
		};

		// Token: 0x04000424 RID: 1060
		public static readonly List<Color> coloresNeutralesParaGlases = new List<Color>
		{
			Color.black,
			Color.red,
			Color.Lerp(Color.red, Color.white, 0.5f)
		};

		// Token: 0x04000425 RID: 1061
		public static readonly List<Color> coloresNeutralesParaAccesorios = new List<Color>
		{
			Color.black,
			Color.white,
			Color.red,
			Color.Lerp(Color.red, Color.white, 0.5f),
			Color.Lerp(Color.blue, Color.white, 0.5f)
		};

		// Token: 0x04000426 RID: 1062
		[Obsolete("", true)]
		private DiccionaryEnumLong<MapaDeRopa.TipoDePrenda, HashSetList<string>> m_IDsDePrendasDeTipoDePrenda;

		// Token: 0x04000427 RID: 1063
		[NonSerialized]
		private DiccionaryEnum<GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto, List<MapaDeRopa.TipoDePrenda>> m_TiposDePrendaDeConjunto = new DiccionaryEnum<GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto, List<MapaDeRopa.TipoDePrenda>>((GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto x) => (int)x)
		{
			{
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto.normal,
				new List<MapaDeRopa.TipoDePrenda>
				{
					MapaDeRopa.TipoDePrenda.inferior,
					MapaDeRopa.TipoDePrenda.shoes,
					MapaDeRopa.TipoDePrenda.superior,
					MapaDeRopa.TipoDePrenda.underwearInferior,
					MapaDeRopa.TipoDePrenda.underwearSuperior,
					MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories,
					MapaDeRopa.TipoDePrenda.underwearInferiorAccessories,
					MapaDeRopa.TipoDePrenda.glases,
					MapaDeRopa.TipoDePrenda.accessories,
					MapaDeRopa.TipoDePrenda.gloves,
					MapaDeRopa.TipoDePrenda.hat,
					MapaDeRopa.TipoDePrenda.socks
				}
			},
			{
				GeneradorDeConjuntosDeRopaAleatoriosFemeninos.TipoDeConjunto.soloVestidoDeBanoEInferior,
				new List<MapaDeRopa.TipoDePrenda>
				{
					MapaDeRopa.TipoDePrenda.inferior,
					MapaDeRopa.TipoDePrenda.shoes,
					MapaDeRopa.TipoDePrenda.swimsuit,
					MapaDeRopa.TipoDePrenda.glases,
					MapaDeRopa.TipoDePrenda.accessories,
					MapaDeRopa.TipoDePrenda.underwearSuperiorAccessories,
					MapaDeRopa.TipoDePrenda.underwearInferiorAccessories,
					MapaDeRopa.TipoDePrenda.gloves,
					MapaDeRopa.TipoDePrenda.hat,
					MapaDeRopa.TipoDePrenda.socks
				}
			}
		};

		// Token: 0x04000428 RID: 1064
		private static List<MaterialParaRopaData> m_materialsDataTemp = new List<MaterialParaRopaData>();

		// Token: 0x04000429 RID: 1065
		private static HashSet<string> m_piezasAddedID = new HashSet<string>();

		// Token: 0x0400042A RID: 1066
		private static List<string> m_IDsTemp = new List<string>();

		// Token: 0x0400042B RID: 1067
		private static List<IGrouping<int, MapaDeRopa.RopaData>> m_gruposDePiezasemp = new List<IGrouping<int, MapaDeRopa.RopaData>>();

		// Token: 0x0400042C RID: 1068
		private static List<MaterialParaRopaData> m_MatTemp = new List<MaterialParaRopaData>();

		// Token: 0x0400042D RID: 1069
		private static List<MaterialParaRopaData> m_MatDeIndexTemp = new List<MaterialParaRopaData>();

		// Token: 0x0400042E RID: 1070
		private static List<IGrouping<int, MaterialParaRopaData>> m_gruposDeMaterialesTemp = new List<IGrouping<int, MaterialParaRopaData>>();

		// Token: 0x020000FB RID: 251
		public abstract class BaseRopaIDsDeTipoDePrenda
		{
			// Token: 0x06000648 RID: 1608
			public abstract List<int> Obtener();

			// Token: 0x0400042F RID: 1071
			public MapaDeRopa.TipoDePrenda tipoDePrenda;
		}

		// Token: 0x020000FC RID: 252
		[Serializable]
		public class RopaPreSetIDsDeTipoDePrenda : GeneradorDeConjuntosDeRopaAleatoriosFemeninos.BaseRopaIDsDeTipoDePrenda
		{
			// Token: 0x0600064A RID: 1610 RVA: 0x0001E340 File Offset: 0x0001C540
			public override List<int> Obtener()
			{
				List<int> list = new List<int>(this.ropaPreSetId.Count);
				for (int i = 0; i < this.ropaPreSetId.Count; i++)
				{
					list.Add((int)this.ropaPreSetId[i]);
				}
				return list;
			}

			// Token: 0x04000430 RID: 1072
			public List<MapaDeRopa.RopaPreSetId> ropaPreSetId;
		}

		// Token: 0x020000FD RID: 253
		public enum TipoDeColor
		{
			// Token: 0x04000432 RID: 1074
			None,
			// Token: 0x04000433 RID: 1075
			neutral,
			// Token: 0x04000434 RID: 1076
			igual,
			// Token: 0x04000435 RID: 1077
			bajoCambioDeContraste,
			// Token: 0x04000436 RID: 1078
			altoCambioDeContraste
		}

		// Token: 0x020000FE RID: 254
		public enum TipoDeConjunto
		{
			// Token: 0x04000438 RID: 1080
			normal,
			// Token: 0x04000439 RID: 1081
			normalConExterior,
			// Token: 0x0400043A RID: 1082
			soloRopaInterior,
			// Token: 0x0400043B RID: 1083
			soloVestidoDeBano,
			// Token: 0x0400043C RID: 1084
			soloVestidoDeBanoEInferior
		}
	}
}
