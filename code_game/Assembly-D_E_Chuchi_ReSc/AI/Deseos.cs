using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200033C RID: 828
	public class Deseos : AplicableCustomMonobehaviour
	{
		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x0004C39A File Offset: 0x0004A59A
		public Deseos.Modificables modificablesGains
		{
			get
			{
				return this.m_modificablesGains;
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x060011C6 RID: 4550 RVA: 0x0004C3A2 File Offset: 0x0004A5A2
		public Deseos.Modificables modificablesPercentage
		{
			get
			{
				return this.m_modificablesPercentage;
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0004C3AA File Offset: 0x0004A5AA
		public Deseos.Sumables sumablePercentage
		{
			get
			{
				return this.m_sumablePercentage;
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x060011C8 RID: 4552 RVA: 0x0004C3B2 File Offset: 0x0004A5B2
		public Deseos.MaxValues valoresMaximosSumablePercentage
		{
			get
			{
				return this.m_valoresMaximosSumablePercentage;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x060011C9 RID: 4553 RVA: 0x0004C3BA File Offset: 0x0004A5BA
		public Deseos.Modificables valoresMaximosModificablePercentage
		{
			get
			{
				return this.m_valoresMaximosModificablePercentage;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x060011CA RID: 4554 RVA: 0x0004C3C2 File Offset: 0x0004A5C2
		public Deseos.Valores valores
		{
			get
			{
				return this.m_valores;
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x060011CB RID: 4555 RVA: 0x0004C3CA File Offset: 0x0004A5CA
		public Deseos.DeseoThresholdsPositivos thresholdsPositivos
		{
			get
			{
				return this.m_thresholdsPositivos;
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x060011CC RID: 4556 RVA: 0x0004C3D2 File Offset: 0x0004A5D2
		public Deseos.DeseoThresholdsNegativo thresholdsNegativo
		{
			get
			{
				return this.m_thresholdsNegativo;
			}
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0004C3DC File Offset: 0x0004A5DC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_thresholdsPositivos.Init(this);
			this.m_thresholdsNegativo.Init(this);
			this.m_valores.Init(this);
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0004C440 File Offset: 0x0004A640
		public bool RegistrarEstimulo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(false);
			if (calculo.EsOrgasmo())
			{
				float num;
				switch (this.m_Personalidad.GetTraitScore(TraitHumano.deseosResiliance))
				{
				case HumanTraitScore.normal:
					num = 6f;
					break;
				case HumanTraitScore.alto:
					num = 12f;
					break;
				case HumanTraitScore.muyAlto:
					num = 24f;
					break;
				case HumanTraitScore.bajo:
					num = 3f;
					break;
				case HumanTraitScore.muyBajo:
					num = 0f;
					break;
				default:
					throw new ArgumentOutOfRangeException(this.m_Personalidad.GetTraitScore(TraitHumano.deseosResiliance).ToString());
				}
				switch (parteDelCuerpoHumano)
				{
				case ParteDelCuerpoHumano.pecho:
				case ParteDelCuerpoHumano.senos:
				case ParteDelCuerpoHumano.pezones:
					this.m_addingValores.senos -= num;
					break;
				case ParteDelCuerpoHumano.espalda:
				case ParteDelCuerpoHumano.abdomen:
				case ParteDelCuerpoHumano.cintura:
				case ParteDelCuerpoHumano.cuello:
				case ParteDelCuerpoHumano.hombros:
				case ParteDelCuerpoHumano.axilas:
				case ParteDelCuerpoHumano.brazos:
				case ParteDelCuerpoHumano.anteBrazos:
				case ParteDelCuerpoHumano.manos:
				case ParteDelCuerpoHumano.hombligo:
				case ParteDelCuerpoHumano.rodillas:
				case ParteDelCuerpoHumano.canillas:
				case ParteDelCuerpoHumano.pies:
					return false;
				case ParteDelCuerpoHumano.caderas:
				case ParteDelCuerpoHumano.coxis:
				case ParteDelCuerpoHumano.nalgas:
				case ParteDelCuerpoHumano.ano:
				case ParteDelCuerpoHumano.piernas:
					this.m_addingValores.trasero -= num;
					break;
				case ParteDelCuerpoHumano.cabeza:
				case ParteDelCuerpoHumano.mandibula:
				case ParteDelCuerpoHumano.labios:
				case ParteDelCuerpoHumano.bocaInterno:
				case ParteDelCuerpoHumano.nariz:
				case ParteDelCuerpoHumano.mejillas:
				case ParteDelCuerpoHumano.ojos:
				case ParteDelCuerpoHumano.globosOculares:
				case ParteDelCuerpoHumano.cejas:
				case ParteDelCuerpoHumano.cienes:
				case ParteDelCuerpoHumano.frente:
				case ParteDelCuerpoHumano.lengua:
				case ParteDelCuerpoHumano.orejas:
					this.m_addingValores.labios -= num;
					break;
				case ParteDelCuerpoHumano.vientre:
				case ParteDelCuerpoHumano.vientreBajo:
				case ParteDelCuerpoHumano.labiosVaginales:
				case ParteDelCuerpoHumano.clitoris:
				case ParteDelCuerpoHumano.vag:
				case ParteDelCuerpoHumano.pene:
				case ParteDelCuerpoHumano.testiculos:
					this.m_addingValores.entrepierna -= num;
					break;
				case ParteDelCuerpoHumano.perineo:
					this.m_addingValores.entrepierna -= num;
					this.m_addingValores.trasero -= num;
					break;
				default:
					throw new ArgumentOutOfRangeException(parteDelCuerpoHumano.ToString());
				}
				this.m_addingValores.ClampAll(-100f, 100f);
				return true;
			}
			bool flag = false;
			switch (parteDelCuerpoHumano)
			{
			case ParteDelCuerpoHumano.pecho:
				this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * 100f * Time.deltaTime * this.deseoGananciaTerciario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
				flag = true;
				break;
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.piernas:
			{
				float num2 = (this.m_devConfig.unidadDeAumentoEntrepierna + this.m_devConfig.unidadDeAumentoTrasero) / 2f * 100f * Time.deltaTime * this.deseoGananciaTerciario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
				this.AumentarDeseoNalgas(num2, true, 0.05f);
				this.AumentarDeseoEntrepierna(num2, true, 0.05f);
				break;
			}
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.orejas:
				this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * 100f * Time.deltaTime * this.deseoGananciaTerciario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
				this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * 100f * Time.deltaTime * this.deseoGananciaSegundario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.lengua:
				this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.senos:
				this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * 100f * Time.deltaTime * this.deseoGananciaSegundario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.pezones:
				this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.nalgas:
				this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * 100f * Time.deltaTime * this.deseoGananciaSegundario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.vientre:
				this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * 100f * Time.deltaTime * this.deseoGananciaTerciario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.vientreBajo:
				this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * 100f * Time.deltaTime * this.deseoGananciaSegundario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.vag:
				this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.perineo:
			{
				float num3 = (this.m_devConfig.unidadDeAumentoEntrepierna + this.m_devConfig.unidadDeAumentoTrasero) / 2f * 100f * Time.deltaTime * this.deseoGananciaSegundario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
				this.AumentarDeseoNalgas(num3, true, 0.05f);
				this.AumentarDeseoEntrepierna(num3, true, 0.05f);
				break;
			}
			case ParteDelCuerpoHumano.ano:
				this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo), true, 0.05f);
				break;
			case ParteDelCuerpoHumano.pene:
			{
				float num4 = 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
				this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * num4, true, 0.05f);
				this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * num4, true, 0.05f);
				this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * num4, true, 0.05f);
				this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * num4, true, 0.05f);
				break;
			}
			case ParteDelCuerpoHumano.testiculos:
			{
				float num5 = 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
				this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * num5, true, 0.05f);
				this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * num5, true, 0.05f);
				this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * num5, true, 0.05f);
				this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * num5, true, 0.05f);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(parteDelCuerpoHumano.ToString());
			}
			if (calculo.EstimuloInvertidoEsValido())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = calculo.PartePrincipalEstimulada(true);
				switch (parteDelCuerpoHumano2)
				{
				case ParteDelCuerpoHumano.pecho:
				case ParteDelCuerpoHumano.espalda:
				case ParteDelCuerpoHumano.labios:
				case ParteDelCuerpoHumano.bocaInterno:
				case ParteDelCuerpoHumano.hombros:
				case ParteDelCuerpoHumano.brazos:
				case ParteDelCuerpoHumano.manos:
				case ParteDelCuerpoHumano.vientre:
				{
					float num6 = 100f * Time.deltaTime * this.deseoGananciaSegundario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
					this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * num6, true, 0.05f);
					this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * num6, true, 0.05f);
					this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * num6, true, 0.05f);
					this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * num6, true, 0.05f);
					break;
				}
				case ParteDelCuerpoHumano.abdomen:
				case ParteDelCuerpoHumano.mandibula:
				case ParteDelCuerpoHumano.anteBrazos:
				case ParteDelCuerpoHumano.nalgas:
				case ParteDelCuerpoHumano.piernas:
				case ParteDelCuerpoHumano.canillas:
				case ParteDelCuerpoHumano.lengua:
				{
					float num7 = 100f * Time.deltaTime * this.deseoGananciaTerciario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
					this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * num7, true, 0.05f);
					this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * num7, true, 0.05f);
					this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * num7, true, 0.05f);
					this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * num7, true, 0.05f);
					break;
				}
				case ParteDelCuerpoHumano.cintura:
				case ParteDelCuerpoHumano.caderas:
				case ParteDelCuerpoHumano.cabeza:
				case ParteDelCuerpoHumano.cuello:
				case ParteDelCuerpoHumano.nariz:
				case ParteDelCuerpoHumano.mejillas:
				case ParteDelCuerpoHumano.ojos:
				case ParteDelCuerpoHumano.globosOculares:
				case ParteDelCuerpoHumano.cejas:
				case ParteDelCuerpoHumano.cienes:
				case ParteDelCuerpoHumano.frente:
				case ParteDelCuerpoHumano.axilas:
				case ParteDelCuerpoHumano.senos:
				case ParteDelCuerpoHumano.pezones:
				case ParteDelCuerpoHumano.coxis:
				case ParteDelCuerpoHumano.labiosVaginales:
				case ParteDelCuerpoHumano.clitoris:
				case ParteDelCuerpoHumano.perineo:
				case ParteDelCuerpoHumano.ano:
				case ParteDelCuerpoHumano.vag:
				case ParteDelCuerpoHumano.hombligo:
				case ParteDelCuerpoHumano.rodillas:
				case ParteDelCuerpoHumano.pies:
				case ParteDelCuerpoHumano.orejas:
					flag |= true;
					break;
				case ParteDelCuerpoHumano.vientreBajo:
				case ParteDelCuerpoHumano.pene:
				case ParteDelCuerpoHumano.testiculos:
				{
					float num8 = 100f * Time.deltaTime * this.deseoGananciaPrimario * this.ModPorEmocion(calculo) * this.ModPorTipoDeInteraccion(calculo);
					this.AumentarDeseoLabios(this.m_devConfig.unidadDeAumentoLabios * num8, true, 0.05f);
					this.AumentarDeseoSenos(this.m_devConfig.unidadDeAumentoSenos * num8, true, 0.05f);
					this.AumentarDeseoNalgas(this.m_devConfig.unidadDeAumentoTrasero * num8, true, 0.05f);
					this.AumentarDeseoEntrepierna(this.m_devConfig.unidadDeAumentoEntrepierna * num8, true, 0.05f);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException(parteDelCuerpoHumano2.ToString());
				}
			}
			if (flag)
			{
				return false;
			}
			this.m_addingValores.ClampAll(-250f, 250f);
			this.m_addingMaxValores.ClampAll(-500f, 500f);
			return true;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x0004CE54 File Offset: 0x0004B054
		public void AumentarDeseoLabios(float amount, bool modificar = true, float addingMaxValorMod = 0.05f)
		{
			float num = (modificar ? this.GetGainDeLabios() : 1f);
			this.m_addingValores.labios = Mathf.Clamp(this.m_addingValores.labios + amount * num, float.MinValue, float.MaxValue);
			this.m_addingMaxValores.labios = Mathf.Clamp(this.m_addingMaxValores.labios + amount * num * addingMaxValorMod, float.MinValue, float.MaxValue);
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0004CEC8 File Offset: 0x0004B0C8
		public float GetGainDeLabios()
		{
			MapaDeDeseos.AumentosMod initialAumentoMods = this.m_Personalidad.currentPersonalidad.deseos.initialAumentoMods;
			return this.m_modificablesGains.labios.ModificarValor(initialAumentoMods.labios);
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x0004CF04 File Offset: 0x0004B104
		public void AumentarDeseoSenos(float amount, bool modificar = true, float addingMaxValorMod = 0.05f)
		{
			float num = (modificar ? this.GetGainDeSenos() : 1f);
			this.m_addingValores.senos = Mathf.Clamp(this.m_addingValores.senos + amount * num, float.MinValue, float.MaxValue);
			this.m_addingMaxValores.senos = Mathf.Clamp(this.m_addingMaxValores.senos + amount * num * addingMaxValorMod, float.MinValue, float.MaxValue);
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x0004CF78 File Offset: 0x0004B178
		public float GetGainDeSenos()
		{
			MapaDeDeseos.AumentosMod initialAumentoMods = this.m_Personalidad.currentPersonalidad.deseos.initialAumentoMods;
			return this.m_modificablesGains.senos.ModificarValor(initialAumentoMods.senos);
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0004CFB4 File Offset: 0x0004B1B4
		public void AumentarDeseoNalgas(float amount, bool modificar = true, float addingMaxValorMod = 0.05f)
		{
			float num = (modificar ? this.GetGainDeNalgas() : 1f);
			this.m_addingValores.trasero = Mathf.Clamp(this.m_addingValores.trasero + amount * num, float.MinValue, float.MaxValue);
			this.m_addingMaxValores.trasero = Mathf.Clamp(this.m_addingMaxValores.trasero + amount * num * addingMaxValorMod, float.MinValue, float.MaxValue);
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x0004D028 File Offset: 0x0004B228
		public float GetGainDeNalgas()
		{
			MapaDeDeseos.AumentosMod initialAumentoMods = this.m_Personalidad.currentPersonalidad.deseos.initialAumentoMods;
			return this.m_modificablesGains.trasero.ModificarValor(initialAumentoMods.trasero);
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x0004D064 File Offset: 0x0004B264
		public void AumentarDeseoEntrepierna(float amount, bool modificar = true, float addingMaxValorMod = 0.05f)
		{
			float num = (modificar ? this.GetGainDeEntrepierna() : 1f);
			this.m_addingValores.entrepierna = Mathf.Clamp(this.m_addingValores.entrepierna + amount * num, float.MinValue, float.MaxValue);
			this.m_addingMaxValores.entrepierna = Mathf.Clamp(this.m_addingMaxValores.entrepierna + amount * num * addingMaxValorMod, float.MinValue, float.MaxValue);
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0004D0D8 File Offset: 0x0004B2D8
		public float GetGainDeEntrepierna()
		{
			MapaDeDeseos.AumentosMod initialAumentoMods = this.m_Personalidad.currentPersonalidad.deseos.initialAumentoMods;
			return this.m_modificablesGains.entrepierna.ModificarValor(initialAumentoMods.entrepierna);
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0004D114 File Offset: 0x0004B314
		public void ResetDeseos()
		{
			this.m_addingValores.entrepierna = (this.m_addingValores.trasero = (this.m_addingValores.senos = (this.m_addingValores.labios = 0f)));
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0004D15C File Offset: 0x0004B35C
		private float ModPorEmocion(ICalculoDeEstimulo calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			float num;
			if (reaccion.EsPositiva())
			{
				num = this.deseoGananciaPositvos;
			}
			else
			{
				num = this.deseoGananciaNegativos;
			}
			if (reaccion == ReaccionHumana.dolor)
			{
				return num * this.m_devConfig.modPorDolorV2;
			}
			if (reaccion == ReaccionHumana.rabia)
			{
				return num * this.m_devConfig.modPorRabiaV2;
			}
			if (reaccion != ReaccionHumana.placer)
			{
				return num * this.m_devConfig.modPorOtherEmocionV2;
			}
			return num * this.m_devConfig.modPorPlacer;
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x0004D1D4 File Offset: 0x0004B3D4
		private float ModPorTipoDeInteraccion(ICalculoDeInteracionEstimulante calculo)
		{
			TipoDeEstimulo tipoDeEstimulo = calculo.estimuloBasico.tipoDeEstimulo;
			MapaDeDeseos.SensibilidadesPorTiposDeInteraccion initialSensibilidades = this.m_Personalidad.currentPersonalidad.deseos.initialSensibilidades;
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.agarrante:
			case TipoDeEstimulo.empujante:
			case TipoDeEstimulo.manipulandoBone:
				return initialSensibilidades.tactiles;
			case TipoDeEstimulo.auditiva:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				return initialSensibilidades.verbales;
			case TipoDeEstimulo.visual:
				return initialSensibilidades.visuales;
			case TipoDeEstimulo.coital:
				return initialSensibilidades.coitales;
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.ejecucionDePose:
				return initialSensibilidades.exposicion;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x0004D280 File Offset: 0x0004B480
		public float deseoGananciaPrimario
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.deseoGananciaPrimario);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.1111f;
				case HumanTraitScore.muyAlto:
					return 1.25f;
				case HumanTraitScore.bajo:
					return 0.9f;
				case HumanTraitScore.muyBajo:
					return 0.8f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x060011DB RID: 4571 RVA: 0x0004D2E8 File Offset: 0x0004B4E8
		public float deseoGananciaSegundario
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.deseoGananciaSegundario);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.5f;
				case HumanTraitScore.alto:
					return 0.75f;
				case HumanTraitScore.muyAlto:
					return 1f;
				case HumanTraitScore.bajo:
					return 0.3333f;
				case HumanTraitScore.muyBajo:
					return 0.25f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x060011DC RID: 4572 RVA: 0x0004D350 File Offset: 0x0004B550
		public float deseoGananciaTerciario
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.deseoGananciaTerciario);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.25f;
				case HumanTraitScore.alto:
					return 0.375f;
				case HumanTraitScore.muyAlto:
					return 0.5f;
				case HumanTraitScore.bajo:
					return 0.16666f;
				case HumanTraitScore.muyBajo:
					return 0.125f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x060011DD RID: 4573 RVA: 0x0004D3B8 File Offset: 0x0004B5B8
		public float deseoGananciaPositvos
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.deseoGananciaPorEstimulosPositivos);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.5f;
				case HumanTraitScore.muyAlto:
					return 2f;
				case HumanTraitScore.bajo:
					return 0.666f;
				case HumanTraitScore.muyBajo:
					return 0.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x060011DE RID: 4574 RVA: 0x0004D420 File Offset: 0x0004B620
		public float deseoGananciaNegativos
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.deseoGananciaPorEstimulosNegativos);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return -0.333f;
				case HumanTraitScore.alto:
					return -0.0001f;
				case HumanTraitScore.muyAlto:
					return 0.1f;
				case HumanTraitScore.bajo:
					return -0.666f;
				case HumanTraitScore.muyBajo:
					return -1f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x0004D487 File Offset: 0x0004B687
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			float entrepiernaPercentage = this.valores.entrepiernaPercentage;
			float traseroPercentage = this.valores.traseroPercentage;
			float labiosPercentage = this.valores.labiosPercentage;
			float senosPercentage = this.valores.senosPercentage;
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x0004D4BF File Offset: 0x0004B6BF
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Simular Pedir Valores",
				editorTimeVisible = false
			};
		}

		// Token: 0x04000EF2 RID: 3826
		private Personalidad m_Personalidad;

		// Token: 0x04000EF3 RID: 3827
		[SerializeField]
		private Deseos.Config m_devConfig = new Deseos.Config();

		// Token: 0x04000EF4 RID: 3828
		[SerializeField]
		private Deseos.Modificables m_modificablesGains = new Deseos.Modificables();

		// Token: 0x04000EF5 RID: 3829
		[SerializeField]
		private Deseos.Sumables m_sumablePercentage = new Deseos.Sumables();

		// Token: 0x04000EF6 RID: 3830
		[SerializeField]
		private Deseos.Modificables m_modificablesPercentage = new Deseos.Modificables();

		// Token: 0x04000EF7 RID: 3831
		[SerializeField]
		private Deseos.MaxValues m_valoresMaximosSumablePercentage = new Deseos.MaxValues();

		// Token: 0x04000EF8 RID: 3832
		[SerializeField]
		private Deseos.Modificables m_valoresMaximosModificablePercentage = new Deseos.Modificables();

		// Token: 0x04000EF9 RID: 3833
		[SerializeField]
		private MapaDeDeseos.ValoresFloat m_addingValores = new MapaDeDeseos.ValoresFloat();

		// Token: 0x04000EFA RID: 3834
		[SerializeField]
		private MapaDeDeseos.ValoresFloat m_addingMaxValores = new MapaDeDeseos.ValoresFloat();

		// Token: 0x04000EFB RID: 3835
		[SerializeField]
		private Deseos.Valores m_valores = new Deseos.Valores();

		// Token: 0x04000EFC RID: 3836
		[SerializeField]
		private Deseos.DeseoThresholdsPositivos m_thresholdsPositivos = new Deseos.DeseoThresholdsPositivos();

		// Token: 0x04000EFD RID: 3837
		[SerializeField]
		private Deseos.DeseoThresholdsNegativo m_thresholdsNegativo = new Deseos.DeseoThresholdsNegativo();

		// Token: 0x0200033D RID: 829
		[Serializable]
		public class Modificadores
		{
			// Token: 0x060011E2 RID: 4578 RVA: 0x0004D564 File Offset: 0x0004B764
			public void Init(Deseos owner)
			{
				this.m_owner = owner;
			}

			// Token: 0x04000EFE RID: 3838
			private Deseos m_owner;
		}

		// Token: 0x0200033E RID: 830
		[Serializable]
		public class Valores
		{
			// Token: 0x060011E4 RID: 4580 RVA: 0x0004D56D File Offset: 0x0004B76D
			public void Init(Deseos owner)
			{
				this.m_owner = owner;
			}

			// Token: 0x1700044C RID: 1100
			// (get) Token: 0x060011E5 RID: 4581 RVA: 0x0004D578 File Offset: 0x0004B778
			public float labiosModBySexThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.labios.deseoParaRechazarSex, 0f, this.m_owner.thresholdsPositivos.labios.deseoParaSex, this.labiosPercentage));
				}
			}

			// Token: 0x1700044D RID: 1101
			// (get) Token: 0x060011E6 RID: 4582 RVA: 0x0004D5D0 File Offset: 0x0004B7D0
			public float senosModBySexThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.senos.deseoParaRechazarSex, 0f, this.m_owner.thresholdsPositivos.senos.deseoParaSex, this.senosPercentage));
				}
			}

			// Token: 0x1700044E RID: 1102
			// (get) Token: 0x060011E7 RID: 4583 RVA: 0x0004D628 File Offset: 0x0004B828
			public float entrepiernaModBySexThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.entrepierna.deseoParaRechazarSex, 0f, this.m_owner.thresholdsPositivos.entrepierna.deseoParaSex, this.entrepiernaPercentage));
				}
			}

			// Token: 0x1700044F RID: 1103
			// (get) Token: 0x060011E8 RID: 4584 RVA: 0x0004D680 File Offset: 0x0004B880
			public float traseroModBySexThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.trasero.deseoParaRechazarSex, 0f, this.m_owner.thresholdsPositivos.trasero.deseoParaSex, this.traseroPercentage));
				}
			}

			// Token: 0x17000450 RID: 1104
			// (get) Token: 0x060011E9 RID: 4585 RVA: 0x0004D6D8 File Offset: 0x0004B8D8
			public float labiosModByTeasingThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.labios.deseoParaRechazarTeasing, 0f, this.m_owner.thresholdsPositivos.labios.deseoParaTeasing, this.labiosPercentage));
				}
			}

			// Token: 0x17000451 RID: 1105
			// (get) Token: 0x060011EA RID: 4586 RVA: 0x0004D730 File Offset: 0x0004B930
			public float senosModByTeasingThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.senos.deseoParaRechazarTeasing, 0f, this.m_owner.thresholdsPositivos.senos.deseoParaTeasing, this.senosPercentage));
				}
			}

			// Token: 0x17000452 RID: 1106
			// (get) Token: 0x060011EB RID: 4587 RVA: 0x0004D788 File Offset: 0x0004B988
			public float entrepiernaModByTeasingThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.entrepierna.deseoParaRechazarTeasing, 0f, this.m_owner.thresholdsPositivos.entrepierna.deseoParaTeasing, this.entrepiernaPercentage));
				}
			}

			// Token: 0x17000453 RID: 1107
			// (get) Token: 0x060011EC RID: 4588 RVA: 0x0004D7E0 File Offset: 0x0004B9E0
			public float traseroModByTeasingThresholds
			{
				get
				{
					return Mathf.Lerp(-1f, 1f, MathfExtension.InverseLerpConMedio(this.m_owner.thresholdsNegativo.trasero.deseoParaRechazarTeasing, 0f, this.m_owner.thresholdsPositivos.trasero.deseoParaTeasing, this.traseroPercentage));
				}
			}

			// Token: 0x17000454 RID: 1108
			// (get) Token: 0x060011ED RID: 4589 RVA: 0x0004D836 File Offset: 0x0004BA36
			public float labiosMod
			{
				get
				{
					return this.labiosPercentage / 100f;
				}
			}

			// Token: 0x17000455 RID: 1109
			// (get) Token: 0x060011EE RID: 4590 RVA: 0x0004D844 File Offset: 0x0004BA44
			public float senosMod
			{
				get
				{
					return this.senosPercentage / 100f;
				}
			}

			// Token: 0x17000456 RID: 1110
			// (get) Token: 0x060011EF RID: 4591 RVA: 0x0004D852 File Offset: 0x0004BA52
			public float entrepiernaMod
			{
				get
				{
					return this.entrepiernaPercentage / 100f;
				}
			}

			// Token: 0x17000457 RID: 1111
			// (get) Token: 0x060011F0 RID: 4592 RVA: 0x0004D860 File Offset: 0x0004BA60
			public float traseroMod
			{
				get
				{
					return this.traseroPercentage / 100f;
				}
			}

			// Token: 0x17000458 RID: 1112
			// (get) Token: 0x060011F1 RID: 4593 RVA: 0x0004D870 File Offset: 0x0004BA70
			public float labiosPercentage
			{
				get
				{
					if (this.m_updateID_labios.IsCurrent())
					{
						return this.m_labios;
					}
					this.m_updateID_labios = ForcedUpdateId.current;
					this.m_labios = Deseos.Valores.GetDeseoPercentage(this.m_owner.m_sumablePercentage.labios, this.m_owner.m_modificablesPercentage.labios, this.m_owner.m_valoresMaximosSumablePercentage.labios, this.m_owner.m_valoresMaximosModificablePercentage.labios, this.m_owner.m_Personalidad.currentPersonalidad.deseos.valoresIniciales.labios, this.m_owner.m_addingValores.labios, this.m_owner.m_addingMaxValores.labios, this.m_owner.m_Personalidad.currentPersonalidad.deseos.maximosIniciales.labios);
					return this.m_labios;
				}
			}

			// Token: 0x17000459 RID: 1113
			// (get) Token: 0x060011F2 RID: 4594 RVA: 0x0004D94C File Offset: 0x0004BB4C
			public float senosPercentage
			{
				get
				{
					if (this.m_updateID_senos.IsCurrent())
					{
						return this.m_senos;
					}
					this.m_updateID_senos = ForcedUpdateId.current;
					this.m_senos = Deseos.Valores.GetDeseoPercentage(this.m_owner.m_sumablePercentage.senos, this.m_owner.m_modificablesPercentage.senos, this.m_owner.m_valoresMaximosSumablePercentage.senos, this.m_owner.m_valoresMaximosModificablePercentage.senos, this.m_owner.m_Personalidad.currentPersonalidad.deseos.valoresIniciales.senos, this.m_owner.m_addingValores.senos, this.m_owner.m_addingMaxValores.senos, this.m_owner.m_Personalidad.currentPersonalidad.deseos.maximosIniciales.senos);
					return this.m_senos;
				}
			}

			// Token: 0x1700045A RID: 1114
			// (get) Token: 0x060011F3 RID: 4595 RVA: 0x0004DA28 File Offset: 0x0004BC28
			public float entrepiernaPercentage
			{
				get
				{
					if (this.m_updateID_entrepierna.IsCurrent())
					{
						return this.m_entrepierna;
					}
					this.m_updateID_entrepierna = ForcedUpdateId.current;
					this.m_entrepierna = Deseos.Valores.GetDeseoPercentage(this.m_owner.m_sumablePercentage.entrepierna, this.m_owner.m_modificablesPercentage.entrepierna, this.m_owner.m_valoresMaximosSumablePercentage.entrepierna, this.m_owner.m_valoresMaximosModificablePercentage.entrepierna, this.m_owner.m_Personalidad.currentPersonalidad.deseos.valoresIniciales.entrepierna, this.m_owner.m_addingValores.entrepierna, this.m_owner.m_addingMaxValores.entrepierna, this.m_owner.m_Personalidad.currentPersonalidad.deseos.maximosIniciales.entrepierna);
					return this.m_entrepierna;
				}
			}

			// Token: 0x1700045B RID: 1115
			// (get) Token: 0x060011F4 RID: 4596 RVA: 0x0004DB04 File Offset: 0x0004BD04
			public float traseroPercentage
			{
				get
				{
					if (this.m_updateID_trasero.IsCurrent())
					{
						return this.m_trasero;
					}
					this.m_updateID_trasero = ForcedUpdateId.current;
					this.m_trasero = Deseos.Valores.GetDeseoPercentage(this.m_owner.m_sumablePercentage.trasero, this.m_owner.m_modificablesPercentage.trasero, this.m_owner.m_valoresMaximosSumablePercentage.trasero, this.m_owner.m_valoresMaximosModificablePercentage.trasero, this.m_owner.m_Personalidad.currentPersonalidad.deseos.valoresIniciales.trasero, this.m_owner.m_addingValores.trasero, this.m_owner.m_addingMaxValores.trasero, this.m_owner.m_Personalidad.currentPersonalidad.deseos.maximosIniciales.trasero);
					return this.m_trasero;
				}
			}

			// Token: 0x060011F5 RID: 4597 RVA: 0x0004DBE0 File Offset: 0x0004BDE0
			private static float GetDeseoPercentage(ModificableDeFloat sumador, ModificableDeFloat modificador, ModificableDeFloat maxValoresSumador, ModificableDeFloat maxValoresModificador, float valorInicial, float valorAdded, float maximoValorAdded, float maximoInicial)
			{
				float num = maxValoresSumador.AdicinarValorIncluyendo(maximoInicial + maximoValorAdded);
				num = maxValoresModificador.ModificarValor(num);
				return Mathf.Clamp(modificador.ModificarValor(sumador.AdicinarValorIncluyendo(valorInicial + valorAdded)), -100f, num);
			}

			// Token: 0x04000EFF RID: 3839
			private Deseos m_owner;

			// Token: 0x04000F00 RID: 3840
			private ForcedUpdateId m_updateID_labios;

			// Token: 0x04000F01 RID: 3841
			private ForcedUpdateId m_updateID_senos;

			// Token: 0x04000F02 RID: 3842
			private ForcedUpdateId m_updateID_entrepierna;

			// Token: 0x04000F03 RID: 3843
			private ForcedUpdateId m_updateID_trasero;

			// Token: 0x04000F04 RID: 3844
			[SerializeField]
			[ReadOnlyUI]
			private float m_labios;

			// Token: 0x04000F05 RID: 3845
			[SerializeField]
			[ReadOnlyUI]
			private float m_senos;

			// Token: 0x04000F06 RID: 3846
			[SerializeField]
			[ReadOnlyUI]
			private float m_entrepierna;

			// Token: 0x04000F07 RID: 3847
			[SerializeField]
			[ReadOnlyUI]
			private float m_trasero;
		}

		// Token: 0x0200033F RID: 831
		[Serializable]
		public abstract class DeseoThresholds<T_Threshold>
		{
			// Token: 0x060011F7 RID: 4599 RVA: 0x0004DC1D File Offset: 0x0004BE1D
			public void Init(Deseos owner)
			{
				this.m_owner = owner;
			}

			// Token: 0x04000F08 RID: 3848
			protected Deseos m_owner;

			// Token: 0x04000F09 RID: 3849
			protected ForcedUpdateId m_updateID_Thresholds_labios;

			// Token: 0x04000F0A RID: 3850
			protected ForcedUpdateId m_updateID_Thresholds_senos;

			// Token: 0x04000F0B RID: 3851
			protected ForcedUpdateId m_updateID_Thresholds_entrepierna;

			// Token: 0x04000F0C RID: 3852
			protected ForcedUpdateId m_updateID_Thresholds_trasero;

			// Token: 0x04000F0D RID: 3853
			[SerializeField]
			[ReadOnlyUI]
			protected T_Threshold m_labiosThreshold;

			// Token: 0x04000F0E RID: 3854
			[SerializeField]
			[ReadOnlyUI]
			protected T_Threshold m_senosThreshold;

			// Token: 0x04000F0F RID: 3855
			[SerializeField]
			[ReadOnlyUI]
			protected T_Threshold m_entrepiernaThreshold;

			// Token: 0x04000F10 RID: 3856
			[SerializeField]
			[ReadOnlyUI]
			protected T_Threshold m_traseroThreshold;
		}

		// Token: 0x02000340 RID: 832
		[Serializable]
		public class DeseoThresholdsPositivos : Deseos.DeseoThresholds<Deseos.ThresholdPositivo>
		{
			// Token: 0x1700045C RID: 1116
			// (get) Token: 0x060011F9 RID: 4601 RVA: 0x0004DC28 File Offset: 0x0004BE28
			public Deseos.ThresholdPositivo labios
			{
				get
				{
					if (this.m_updateID_Thresholds_labios.IsCurrent())
					{
						return this.m_labiosThreshold;
					}
					this.m_updateID_Thresholds_labios = ForcedUpdateId.current;
					this.m_labiosThreshold = Deseos.ThresholdPositivo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaChupar));
					return this.m_labiosThreshold;
				}
			}

			// Token: 0x1700045D RID: 1117
			// (get) Token: 0x060011FA RID: 4602 RVA: 0x0004DC78 File Offset: 0x0004BE78
			public Deseos.ThresholdPositivo senos
			{
				get
				{
					if (this.m_updateID_Thresholds_senos.IsCurrent())
					{
						return this.m_senosThreshold;
					}
					this.m_updateID_Thresholds_senos = ForcedUpdateId.current;
					this.m_senosThreshold = Deseos.ThresholdPositivo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaChupar));
					return this.m_senosThreshold;
				}
			}

			// Token: 0x1700045E RID: 1118
			// (get) Token: 0x060011FB RID: 4603 RVA: 0x0004DCC8 File Offset: 0x0004BEC8
			public Deseos.ThresholdPositivo entrepierna
			{
				get
				{
					if (this.m_updateID_Thresholds_entrepierna.IsCurrent())
					{
						return this.m_entrepiernaThreshold;
					}
					this.m_updateID_Thresholds_entrepierna = ForcedUpdateId.current;
					this.m_entrepiernaThreshold = Deseos.ThresholdPositivo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaHacerEjercicio));
					return this.m_entrepiernaThreshold;
				}
			}

			// Token: 0x1700045F RID: 1119
			// (get) Token: 0x060011FC RID: 4604 RVA: 0x0004DD18 File Offset: 0x0004BF18
			public Deseos.ThresholdPositivo trasero
			{
				get
				{
					if (this.m_updateID_Thresholds_trasero.IsCurrent())
					{
						return this.m_traseroThreshold;
					}
					this.m_updateID_Thresholds_trasero = ForcedUpdateId.current;
					this.m_traseroThreshold = Deseos.ThresholdPositivo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaHacerEjercicioNoNatural));
					return this.m_traseroThreshold;
				}
			}
		}

		// Token: 0x02000341 RID: 833
		[Serializable]
		public class DeseoThresholdsNegativo : Deseos.DeseoThresholds<Deseos.ThresholdNegativo>
		{
			// Token: 0x17000460 RID: 1120
			// (get) Token: 0x060011FE RID: 4606 RVA: 0x0004DD70 File Offset: 0x0004BF70
			public Deseos.ThresholdNegativo labios
			{
				get
				{
					if (this.m_updateID_Thresholds_labios.IsCurrent())
					{
						return this.m_labiosThreshold;
					}
					this.m_updateID_Thresholds_labios = ForcedUpdateId.current;
					this.m_labiosThreshold = Deseos.ThresholdNegativo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaChupar));
					return this.m_labiosThreshold;
				}
			}

			// Token: 0x17000461 RID: 1121
			// (get) Token: 0x060011FF RID: 4607 RVA: 0x0004DDC0 File Offset: 0x0004BFC0
			public Deseos.ThresholdNegativo senos
			{
				get
				{
					if (this.m_updateID_Thresholds_senos.IsCurrent())
					{
						return this.m_senosThreshold;
					}
					this.m_updateID_Thresholds_senos = ForcedUpdateId.current;
					this.m_senosThreshold = Deseos.ThresholdNegativo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaChupar));
					return this.m_senosThreshold;
				}
			}

			// Token: 0x17000462 RID: 1122
			// (get) Token: 0x06001200 RID: 4608 RVA: 0x0004DE10 File Offset: 0x0004C010
			public Deseos.ThresholdNegativo entrepierna
			{
				get
				{
					if (this.m_updateID_Thresholds_entrepierna.IsCurrent())
					{
						return this.m_entrepiernaThreshold;
					}
					this.m_updateID_Thresholds_entrepierna = ForcedUpdateId.current;
					this.m_entrepiernaThreshold = Deseos.ThresholdNegativo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaHacerEjercicio));
					return this.m_entrepiernaThreshold;
				}
			}

			// Token: 0x17000463 RID: 1123
			// (get) Token: 0x06001201 RID: 4609 RVA: 0x0004DE60 File Offset: 0x0004C060
			public Deseos.ThresholdNegativo trasero
			{
				get
				{
					if (this.m_updateID_Thresholds_trasero.IsCurrent())
					{
						return this.m_traseroThreshold;
					}
					this.m_updateID_Thresholds_trasero = ForcedUpdateId.current;
					this.m_traseroThreshold = Deseos.ThresholdNegativo.Producir(this.m_owner.m_Personalidad.GetTraitScore(TraitHumano.leGustaHacerEjercicioNoNatural));
					return this.m_traseroThreshold;
				}
			}
		}

		// Token: 0x02000342 RID: 834
		[Serializable]
		public class Config
		{
			// Token: 0x04000F11 RID: 3857
			[Tooltip("De zero a uno, osea q se multiplca por 100 al subir deseos")]
			public float unidadDeAumentoLabios = 0.003333333f;

			// Token: 0x04000F12 RID: 3858
			[Tooltip("De zero a uno, osea q se multiplca por 100 al subir deseos")]
			public float unidadDeAumentoSenos = 0.0029999996f;

			// Token: 0x04000F13 RID: 3859
			[Tooltip("De zero a uno, osea q se multiplca por 100 al subir deseos")]
			public float unidadDeAumentoEntrepierna = 0.0026666664f;

			// Token: 0x04000F14 RID: 3860
			[Tooltip("De zero a uno, osea q se multiplca por 100 al subir deseos")]
			public float unidadDeAumentoTrasero = 0.002333333f;

			// Token: 0x04000F15 RID: 3861
			public float modPorPlacer = 1f;

			// Token: 0x04000F16 RID: 3862
			public float modPorDolorV2 = 0.75f;

			// Token: 0x04000F17 RID: 3863
			public float modPorRabiaV2 = 0.5f;

			// Token: 0x04000F18 RID: 3864
			public float modPorOtherEmocionV2 = 0.25f;
		}

		// Token: 0x02000343 RID: 835
		[Serializable]
		public class Sumables : MapaDeDeseos.Valores<ModificableDeFloat>
		{
			// Token: 0x06001204 RID: 4612 RVA: 0x0004DF24 File Offset: 0x0004C124
			public Sumables()
			{
				this.entrepierna = new ModificableDeFloat(0f);
				this.trasero = new ModificableDeFloat(0f);
				this.senos = new ModificableDeFloat(0f);
				this.labios = new ModificableDeFloat(0f);
			}
		}

		// Token: 0x02000344 RID: 836
		[Serializable]
		public class Modificables : MapaDeDeseos.Valores<ModificableDeFloat>
		{
			// Token: 0x06001205 RID: 4613 RVA: 0x0004DF78 File Offset: 0x0004C178
			public Modificables()
			{
				this.entrepierna = new ModificableDeFloat(1f);
				this.trasero = new ModificableDeFloat(1f);
				this.senos = new ModificableDeFloat(1f);
				this.labios = new ModificableDeFloat(1f);
			}
		}

		// Token: 0x02000345 RID: 837
		[Serializable]
		public class MaxValues : MapaDeDeseos.Valores<ModificableDeFloat>
		{
			// Token: 0x06001206 RID: 4614 RVA: 0x0004DFCC File Offset: 0x0004C1CC
			public MaxValues()
			{
				this.entrepierna = new ModificableDeFloat(0f);
				this.trasero = new ModificableDeFloat(0f);
				this.senos = new ModificableDeFloat(0f);
				this.labios = new ModificableDeFloat(0f);
			}
		}

		// Token: 0x02000346 RID: 838
		[Serializable]
		public struct ThresholdPositivo
		{
			// Token: 0x06001207 RID: 4615 RVA: 0x0004E020 File Offset: 0x0004C220
			public static Deseos.ThresholdPositivo Producir(HumanTraitScore trait)
			{
				switch (trait)
				{
				case HumanTraitScore.normal:
					return Deseos.ThresholdPositivo.normal;
				case HumanTraitScore.alto:
					return Deseos.ThresholdPositivo.alto;
				case HumanTraitScore.muyAlto:
					return Deseos.ThresholdPositivo.muyAlto;
				case HumanTraitScore.bajo:
					return Deseos.ThresholdPositivo.bajo;
				case HumanTraitScore.muyBajo:
					return Deseos.ThresholdPositivo.muyBajo;
				default:
					throw new ArgumentOutOfRangeException(trait.ToString());
				}
			}

			// Token: 0x04000F19 RID: 3865
			private static Deseos.ThresholdPositivo muyAlto = new Deseos.ThresholdPositivo
			{
				deseoParaTeasing = 20f,
				deseoParaSex = 60f
			};

			// Token: 0x04000F1A RID: 3866
			private static Deseos.ThresholdPositivo alto = new Deseos.ThresholdPositivo
			{
				deseoParaTeasing = 30f,
				deseoParaSex = 70f
			};

			// Token: 0x04000F1B RID: 3867
			private static Deseos.ThresholdPositivo normal = new Deseos.ThresholdPositivo
			{
				deseoParaTeasing = 40f,
				deseoParaSex = 80f
			};

			// Token: 0x04000F1C RID: 3868
			private static Deseos.ThresholdPositivo bajo = new Deseos.ThresholdPositivo
			{
				deseoParaTeasing = 50f,
				deseoParaSex = 90f
			};

			// Token: 0x04000F1D RID: 3869
			private static Deseos.ThresholdPositivo muyBajo = new Deseos.ThresholdPositivo
			{
				deseoParaTeasing = 60f,
				deseoParaSex = 100f
			};

			// Token: 0x04000F1E RID: 3870
			public float deseoParaTeasing;

			// Token: 0x04000F1F RID: 3871
			public float deseoParaSex;
		}

		// Token: 0x02000347 RID: 839
		[Serializable]
		public struct ThresholdNegativo
		{
			// Token: 0x06001209 RID: 4617 RVA: 0x0004E148 File Offset: 0x0004C348
			public static Deseos.ThresholdNegativo Producir(HumanTraitScore trait)
			{
				switch (trait)
				{
				case HumanTraitScore.normal:
					return Deseos.ThresholdNegativo.normal;
				case HumanTraitScore.alto:
					return Deseos.ThresholdNegativo.alto;
				case HumanTraitScore.muyAlto:
					return Deseos.ThresholdNegativo.muyAlto;
				case HumanTraitScore.bajo:
					return Deseos.ThresholdNegativo.bajo;
				case HumanTraitScore.muyBajo:
					return Deseos.ThresholdNegativo.muyBajo;
				default:
					throw new ArgumentOutOfRangeException(trait.ToString());
				}
			}

			// Token: 0x04000F20 RID: 3872
			private static Deseos.ThresholdNegativo muyAlto = new Deseos.ThresholdNegativo
			{
				deseoParaRechazarTeasing = -100f,
				deseoParaRechazarSex = -60f
			};

			// Token: 0x04000F21 RID: 3873
			private static Deseos.ThresholdNegativo alto = new Deseos.ThresholdNegativo
			{
				deseoParaRechazarTeasing = -90f,
				deseoParaRechazarSex = -50f
			};

			// Token: 0x04000F22 RID: 3874
			private static Deseos.ThresholdNegativo normal = new Deseos.ThresholdNegativo
			{
				deseoParaRechazarTeasing = -80f,
				deseoParaRechazarSex = -40f
			};

			// Token: 0x04000F23 RID: 3875
			private static Deseos.ThresholdNegativo bajo = new Deseos.ThresholdNegativo
			{
				deseoParaRechazarTeasing = -70f,
				deseoParaRechazarSex = -30f
			};

			// Token: 0x04000F24 RID: 3876
			private static Deseos.ThresholdNegativo muyBajo = new Deseos.ThresholdNegativo
			{
				deseoParaRechazarTeasing = -60f,
				deseoParaRechazarSex = -20f
			};

			// Token: 0x04000F25 RID: 3877
			public float deseoParaRechazarTeasing;

			// Token: 0x04000F26 RID: 3878
			public float deseoParaRechazarSex;
		}
	}
}
