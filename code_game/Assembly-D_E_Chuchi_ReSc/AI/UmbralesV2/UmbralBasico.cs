using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2
{
	// Token: 0x02000559 RID: 1369
	public class UmbralBasico
	{
		// Token: 0x06002147 RID: 8519 RVA: 0x0007BFB8 File Offset: 0x0007A1B8
		public static UmbralBasico.Estado Calcular(float cambio, RangeValueV2 intervalo, float estimulacionQueGenera, SpotBonuses spotBonuses, float promedioMod = 0.5f, float modPorEncima = 0f, float modPorDebajo = 0f)
		{
			return UmbralBasico.Calcular(cambio, 0f, UmbralBasico.TipoDeCambio.unico, intervalo, estimulacionQueGenera, spotBonuses, promedioMod, modPorEncima, modPorDebajo);
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x0007BFDC File Offset: 0x0007A1DC
		public static UmbralBasico.Estado Calcular(float cambio, UmbralBasico.TipoDeCambio tipoDeCambio, RangeValueV2 intervalo, float estimulacionQueGenera, SpotBonuses spotBonuses, float? deltaTime = null, float promedioMod = 0.5f, float modPorEncima = 0f, float modPorDebajo = 0f)
		{
			float num = deltaTime ?? Time.deltaTime;
			return UmbralBasico.Calcular(cambio, num, tipoDeCambio, intervalo, estimulacionQueGenera, spotBonuses, promedioMod, modPorEncima, modPorDebajo);
		}

		// Token: 0x06002149 RID: 8521 RVA: 0x0007C018 File Offset: 0x0007A218
		public static UmbralBasico.Estado Calcular(float cambio, float deltaTime, UmbralBasico.TipoDeCambio tipoDeCambio, RangeValueV2 intervalo, float estimulacionQueGenera, SpotBonuses spotBonuses, float promedioMod = 0.5f, float modPorEncima = 0f, float modPorDebajo = 0f)
		{
			UmbralBasico.Estado estado2;
			try
			{
				UmbralBasico.Estado estado = new UmbralBasico.Estado(ForcedUpdateId.current);
				if (cambio < 0f)
				{
					cambio = 0f;
				}
				estado.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
				estado.rango = UmbralBasico.RangoEstado.sinEstimulo;
				float num;
				float num2;
				if (intervalo.InRange(cambio))
				{
					num = 1f;
					estado.rango = UmbralBasico.RangoEstado.enRango;
					num2 = intervalo.InverseLerpAlMedio(cambio, promedioMod, 1f, 1f);
					estado.spotScore = UmbralBasico.CalculeSpot(num2, 1f);
					if (intervalo.EnMedio(cambio, promedioMod))
					{
						estado.spotRango = UmbralBasico.RangoEstado.enRango;
					}
					else if (intervalo.PorEncimaDelMedio(cambio, promedioMod))
					{
						estado.spotRango = UmbralBasico.RangoEstado.porEncima;
					}
					else if (intervalo.PorDebajoDelMedio(cambio, promedioMod))
					{
						estado.spotRango = UmbralBasico.RangoEstado.porDebajo;
					}
					else
					{
						estado.spotRango = UmbralBasico.RangoEstado.enRango;
					}
				}
				else if (intervalo.PorEncima(cambio))
				{
					estado.rango = UmbralBasico.RangoEstado.porEncima;
					num2 = modPorEncima;
					float max = intervalo.max;
					if (max == 0f)
					{
						num = 0f;
					}
					else
					{
						num = cambio / max;
					}
				}
				else
				{
					if (!intervalo.PorDebajo(cambio))
					{
						throw new ArgumentOutOfRangeException();
					}
					estado.rango = UmbralBasico.RangoEstado.porDebajo;
					num2 = modPorDebajo;
					float min = intervalo.min;
					if (min == 0f)
					{
						num = 0f;
					}
					else
					{
						num = cambio / min;
					}
				}
				float num3 = 0f;
				estado.offsetMod = num;
				if (num2 > 0f)
				{
					float bonus = spotBonuses.GetBonus(estado.spotScore);
					num3 = num2 * estimulacionQueGenera;
					num3 *= bonus;
					if (tipoDeCambio == UmbralBasico.TipoDeCambio.porSegundo)
					{
						if (deltaTime <= 0f)
						{
							Debug.LogError("Delta time es zero");
						}
						num3 *= deltaTime;
					}
				}
				estado.SetEstimulacionGeneradaEnFrame(num3);
				estado.SetEstimulacionGeneradaTotal(num3);
				estado2 = estado;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Error calculando UmbralBasico");
				throw ex;
			}
			return estado2;
		}

		// Token: 0x0600214A RID: 8522 RVA: 0x00005F51 File Offset: 0x00004151
		protected virtual bool PuedeGenerarEstimulo(float cambio)
		{
			return true;
		}

		// Token: 0x0600214B RID: 8523 RVA: 0x0007C1EC File Offset: 0x0007A3EC
		protected virtual bool ValidarCambio(float cambio)
		{
			return cambio >= 0f && (!ExtendedMonoBehaviour.AlmostEqual(cambio, 0f, 1E-05f) || this.config.zeroIsAValidCambio);
		}

		// Token: 0x0600214C RID: 8524 RVA: 0x0007C21C File Offset: 0x0007A41C
		private static SpotScore CalculeSpot(float modResult, float maxMod)
		{
			if (maxMod == 0f)
			{
				return SpotScore.fuera;
			}
			if (maxMod == modResult)
			{
				return SpotScore.enSpot;
			}
			float num = (1f - modResult / maxMod) * 100f;
			float num2 = 5f;
			if (num <= num2)
			{
				return SpotScore.enSpot;
			}
			float num3 = 10f;
			if (num <= num3)
			{
				return SpotScore.casiEnSpot;
			}
			float num4 = 15f;
			if (num <= num4)
			{
				return SpotScore.cercano;
			}
			return SpotScore.fuera;
		}

		// Token: 0x04001596 RID: 5526
		public RangeValue intervalo;

		// Token: 0x04001597 RID: 5527
		public ValorModificable estimulacionQueGenera;

		// Token: 0x04001598 RID: 5528
		public UmbralBasico.Config config = new UmbralBasico.Config();

		// Token: 0x0200055A RID: 1370
		public enum TipoDeCambio
		{
			// Token: 0x0400159A RID: 5530
			unico,
			// Token: 0x0400159B RID: 5531
			porSegundo
		}

		// Token: 0x0200055B RID: 1371
		[Serializable]
		public struct Estado : IConvinableValue<UmbralBasico.Estado>, IEsConvinableValue<UmbralBasico.Estado>
		{
			// Token: 0x0600214E RID: 8526 RVA: 0x0007C284 File Offset: 0x0007A484
			public Estado(ForcedUpdateId id)
			{
				this.rango = UmbralBasico.RangoEstado.sinEstimulo;
				this.m_estimulacionGeneradaEnFrame = 0f;
				this.m_estimulacionGeneradaTotal = 0f;
				this.m_postModificador = 1f;
				this.updateId = id;
				this.offsetMod = 1f;
				this.spotScore = SpotScore.fuera;
				this.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
			}

			// Token: 0x170008DC RID: 2268
			// (get) Token: 0x0600214F RID: 8527 RVA: 0x0007C2D9 File Offset: 0x0007A4D9
			public bool actualizado
			{
				get
				{
					return this.updateId.IsCurrent();
				}
			}

			// Token: 0x170008DD RID: 2269
			// (get) Token: 0x06002150 RID: 8528 RVA: 0x0007C2E6 File Offset: 0x0007A4E6
			// (set) Token: 0x06002151 RID: 8529 RVA: 0x0007C2EE File Offset: 0x0007A4EE
			public ForcedUpdateId updateId { readonly get; private set; }

			// Token: 0x170008DE RID: 2270
			// (get) Token: 0x06002152 RID: 8530 RVA: 0x0007C2F7 File Offset: 0x0007A4F7
			public float estimulacionGeneradaEnFrame
			{
				get
				{
					return this.m_estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170008DF RID: 2271
			// (get) Token: 0x06002153 RID: 8531 RVA: 0x0007C2FF File Offset: 0x0007A4FF
			public float estimulacionGeneradaTotal
			{
				get
				{
					return this.m_estimulacionGeneradaTotal;
				}
			}

			// Token: 0x170008E0 RID: 2272
			// (get) Token: 0x06002154 RID: 8532 RVA: 0x0007C307 File Offset: 0x0007A507
			public float postModificador
			{
				get
				{
					return this.m_postModificador;
				}
			}

			// Token: 0x06002155 RID: 8533 RVA: 0x0007C30F File Offset: 0x0007A50F
			public void SobreEscribirEstimulacionGeneradaEnFrame(float enFrame, float total, float postMod)
			{
				this.m_postModificador = postMod;
				this.m_estimulacionGeneradaTotal = total;
				this.m_estimulacionGeneradaEnFrame = enFrame;
			}

			// Token: 0x06002156 RID: 8534 RVA: 0x0007C326 File Offset: 0x0007A526
			public void SetEstimulacionGeneradaEnFrame(float nuevoValor)
			{
				this.m_estimulacionGeneradaEnFrame = nuevoValor;
			}

			// Token: 0x06002157 RID: 8535 RVA: 0x0007C32F File Offset: 0x0007A52F
			public void SetEstimulacionGeneradaTotal(float nuevoValor)
			{
				this.m_estimulacionGeneradaTotal = nuevoValor;
			}

			// Token: 0x06002158 RID: 8536 RVA: 0x0007C338 File Offset: 0x0007A538
			public void SetPostModificador(float nuevoValor)
			{
				this.m_postModificador = Mathf.Clamp01(nuevoValor);
			}

			// Token: 0x06002159 RID: 8537 RVA: 0x0007C346 File Offset: 0x0007A546
			public void ModificarGenerado(float mod)
			{
				this.m_estimulacionGeneradaEnFrame *= mod;
				this.m_estimulacionGeneradaTotal *= mod;
			}

			// Token: 0x170008E1 RID: 2273
			// (get) Token: 0x0600215A RID: 8538 RVA: 0x0007C364 File Offset: 0x0007A564
			public float severidadSinPost
			{
				get
				{
					return UmbralBasico.Estado.GetSeveridad(this.m_estimulacionGeneradaEnFrame, this.spotScore);
				}
			}

			// Token: 0x170008E2 RID: 2274
			// (get) Token: 0x0600215B RID: 8539 RVA: 0x0007C377 File Offset: 0x0007A577
			public float severidadConPost
			{
				get
				{
					return UmbralBasico.Estado.GetSeveridad(this.m_estimulacionGeneradaEnFrame * this.m_postModificador, this.spotScore);
				}
			}

			// Token: 0x0600215C RID: 8540 RVA: 0x0007C391 File Offset: 0x0007A591
			public double GetPrioridadSinPost()
			{
				return UmbralBasico.Estado.GetPrioridad(this.m_estimulacionGeneradaEnFrame, this.spotScore, this.rango);
			}

			// Token: 0x0600215D RID: 8541 RVA: 0x0007C3AA File Offset: 0x0007A5AA
			public double GetPrioridadConPost()
			{
				return UmbralBasico.Estado.GetPrioridad(this.m_estimulacionGeneradaEnFrame * this.m_postModificador, this.spotScore, this.rango);
			}

			// Token: 0x0600215E RID: 8542 RVA: 0x0007C3CC File Offset: 0x0007A5CC
			private static float GetSeveridad(float generada, SpotScore spotScore)
			{
				float num = Mathf.Clamp(Time.deltaTime, 0.008333334f, 0.05f);
				generada = Mathf.Clamp(generada, 1E-05f, 100f);
				float num2 = Mathf.Clamp(generada / num, 0f, 11999.999f);
				float num3;
				if (num2 >= 2f)
				{
					num3 = 0.6666667f + Mathf.Lerp(0f, 0.33333334f, Mathf.InverseLerp(2f, 5f, num2).OutPow(2f));
				}
				else if ((double)num2 >= 0.25)
				{
					num3 = 0.33333334f + Mathf.Lerp(0f, 0.33333334f, Mathf.InverseLerp(0.25f, 2f, num2).OutPow(2f));
				}
				else
				{
					num3 = Mathf.Lerp(0f, 0.33333334f, Mathf.InverseLerp(0f, 0.25f, num2).OutPow(2f));
				}
				float num4 = 1f;
				if (spotScore <= SpotScore.enSpot)
				{
					if (spotScore == SpotScore.fuera)
					{
						goto IL_0125;
					}
					if (spotScore == SpotScore.enSpot)
					{
						num4 = 1.3f;
						goto IL_0125;
					}
				}
				else
				{
					if (spotScore == SpotScore.casiEnSpot)
					{
						num4 = 1.2f;
						goto IL_0125;
					}
					if (spotScore == SpotScore.cercano)
					{
						num4 = 1.1f;
						goto IL_0125;
					}
				}
				throw new ArgumentOutOfRangeException(spotScore.ToString());
				IL_0125:
				num3 = num3.OutPow(num4);
				return Mathf.Clamp01(num3);
			}

			// Token: 0x0600215F RID: 8543 RVA: 0x0007C50C File Offset: 0x0007A70C
			private static double GetPrioridad(float generada, SpotScore spotScore, UmbralBasico.RangoEstado rango)
			{
				double num = (double)((generada <= 0f) ? 1E-08f : Mathf.Lerp(1f, 2f, (generada / 100f).InPow(3f)));
				switch (rango)
				{
				case UmbralBasico.RangoEstado.sinEstimulo:
					break;
				case UmbralBasico.RangoEstado.enRango:
					num *= 2.0;
					break;
				case UmbralBasico.RangoEstado.porDebajo:
				case UmbralBasico.RangoEstado.porEncima:
					num *= 1.5;
					break;
				default:
					throw new ArgumentOutOfRangeException(rango.ToString());
				}
				if (spotScore <= SpotScore.enSpot)
				{
					if (spotScore == SpotScore.fuera)
					{
						return num;
					}
					if (spotScore == SpotScore.enSpot)
					{
						return num * 1.149999976158142;
					}
				}
				else
				{
					if (spotScore == SpotScore.casiEnSpot)
					{
						return num * 1.100000023841858;
					}
					if (spotScore == SpotScore.cercano)
					{
						return num * 1.0499999523162842;
					}
				}
				throw new ArgumentOutOfRangeException(spotScore.ToString());
			}

			// Token: 0x06002160 RID: 8544 RVA: 0x0007C5E8 File Offset: 0x0007A7E8
			public string PrintStr()
			{
				return string.Empty + "\n actualizado: " + this.actualizado.ToString() + " EstimulacionGenerada: " + this.m_estimulacionGeneradaEnFrame.ToString("0.0000") + " EstimulacionGeneradaTotal: " + this.m_estimulacionGeneradaTotal.ToString("0.0000") + " E.G/seg: " + (this.estimulacionGeneradaEnFrame / Time.deltaTime).ToString("0.0000") + " rango: " + this.rango.ToString() + " SpotScore: " + this.spotScore.ToString() + " offsetMod: " + this.offsetMod.ToString("0.0000");
			}

			// Token: 0x06002161 RID: 8545 RVA: 0x00005F51 File Offset: 0x00004151
			public bool Convinable(ref UmbralBasico.Estado other)
			{
				return true;
			}

			// Token: 0x06002162 RID: 8546 RVA: 0x0007C6BC File Offset: 0x0007A8BC
			public void Convinar(ref UmbralBasico.Estado other)
			{
				this.updateId = ForcedUpdateId.Create(Mathf.Max(this.updateId.id, other.updateId.id));
				if (other.estimulacionGeneradaEnFrame > 0f)
				{
					return;
				}
				if (this.m_estimulacionGeneradaEnFrame > 0f)
				{
					this.rango = UmbralBasico.RangoEstado.enRango;
					this.offsetMod = 1f;
				}
				else
				{
					this.rango = UmbralBasico.RangoEstado.sinEstimulo;
					this.offsetMod = 0f;
				}
				this.SetEstimulacionGeneradaTotal(this.m_estimulacionGeneradaTotal + other.estimulacionGeneradaEnFrame);
				this.SetEstimulacionGeneradaEnFrame((this.m_estimulacionGeneradaEnFrame + other.estimulacionGeneradaEnFrame) / 2f);
				if (this.spotScore != SpotScore.enSpot)
				{
					SpotScore spotScore = other.spotScore;
					if (spotScore <= SpotScore.enSpot)
					{
						if (spotScore == SpotScore.fuera)
						{
							goto IL_00F9;
						}
						if (spotScore == SpotScore.enSpot)
						{
							this.spotScore = SpotScore.enSpot;
							goto IL_00F9;
						}
					}
					else if (spotScore == SpotScore.casiEnSpot || spotScore == SpotScore.cercano)
					{
						this.spotScore = (SpotScore)Mathf.Min((int)this.spotScore, (int)other.spotScore);
						goto IL_00F9;
					}
					throw new ArgumentOutOfRangeException(other.spotScore.ToString());
				}
				IL_00F9:
				if (this.spotRango != UmbralBasico.RangoEstado.enRango)
				{
					UmbralBasico.RangoEstado rangoEstado = other.spotRango;
					if (rangoEstado != UmbralBasico.RangoEstado.sinEstimulo)
					{
						if (rangoEstado - UmbralBasico.RangoEstado.enRango <= 2)
						{
							this.spotRango = other.spotRango;
							return;
						}
						throw new ArgumentOutOfRangeException(other.spotRango.ToString());
					}
				}
			}

			// Token: 0x0400159D RID: 5533
			public UmbralBasico.RangoEstado rango;

			// Token: 0x0400159E RID: 5534
			[SerializeField]
			private float m_estimulacionGeneradaEnFrame;

			// Token: 0x0400159F RID: 5535
			[SerializeField]
			private float m_estimulacionGeneradaTotal;

			// Token: 0x040015A0 RID: 5536
			[SerializeField]
			private float m_postModificador;

			// Token: 0x040015A1 RID: 5537
			public SpotScore spotScore;

			// Token: 0x040015A2 RID: 5538
			public UmbralBasico.RangoEstado spotRango;

			// Token: 0x040015A3 RID: 5539
			public float offsetMod;
		}

		// Token: 0x0200055C RID: 1372
		[Serializable]
		public class Config
		{
			// Token: 0x040015A4 RID: 5540
			public SpotBonuses spotBonuses = SpotBonuses.@default;

			// Token: 0x040015A5 RID: 5541
			public bool zeroIsAValidCambio = true;

			// Token: 0x040015A6 RID: 5542
			public float minIntervalValue;

			// Token: 0x040015A7 RID: 5543
			public RangeValue intervalo;

			// Token: 0x040015A8 RID: 5544
			public float modPorIntervaloPorEncimaDeRango;

			// Token: 0x040015A9 RID: 5545
			public float modPorIntervaloPorDebajoDeRango;

			// Token: 0x040015AA RID: 5546
			public RangeValueCaculeModConfig rangeValueCaculeModConfig = RangeValueCaculeModConfig.getDefault;
		}

		// Token: 0x0200055D RID: 1373
		public enum RangoEstado
		{
			// Token: 0x040015AC RID: 5548
			sinEstimulo,
			// Token: 0x040015AD RID: 5549
			enRango,
			// Token: 0x040015AE RID: 5550
			porDebajo,
			// Token: 0x040015AF RID: 5551
			porEncima
		}
	}
}
