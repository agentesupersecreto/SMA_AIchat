using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Randomizacion.Mapas.Singletones;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Randomizacion.Clases
{
	// Token: 0x02000066 RID: 102
	public static class Randomizado
	{
		// Token: 0x060004B6 RID: 1206 RVA: 0x00011130 File Offset: 0x0000F330
		public static void ModificarRandomizadoDeAparienciaV2(IReadOnlyDictionary<string, ModificadoresDeAlterador> apariencia, MapaDeAlteracionesAparienciaFemeninaBase mapaDefault)
		{
			if (!ConfiguracionGlobal.nerfRandomGeneratorDeApariencia)
			{
				return;
			}
			mapaDefault.PrepareAlteradoresDicc();
			MapasDeModificacionDeRandomizadoDeAparienciaFemenina instance = MapaSingleton<MapasDeModificacionDeRandomizadoDeAparienciaFemenina>.instance;
			if (instance.activado)
			{
				for (int i = 0; i < instance.mapas.Count; i++)
				{
					instance.mapas[i].ApplyTo(apariencia, mapaDefault.preparedAlteradoresDicc);
				}
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00011188 File Offset: 0x0000F388
		public static void ModificarRandomizadoDePersonalidadV2(IReadOnlyDictionary<string, ModificadoresDeAlterador> personalidad, MapaDeAlteracionesPersonalidadFemeninaBase mapaDefault)
		{
			if (!ConfiguracionGlobal.nerfRandomGeneratorDePersonalidad)
			{
				return;
			}
			mapaDefault.PrepareAlteradoresDicc();
			MapasDeModificacionDeRandomizadoDePersonalidadFemenina instance = MapaSingleton<MapasDeModificacionDeRandomizadoDePersonalidadFemenina>.instance;
			for (int i = 0; i < instance.mapas.Count; i++)
			{
				instance.mapas[i].ApplyTo(personalidad, mapaDefault.preparedAlteradoresDicc);
			}
		}

		// Token: 0x0200009E RID: 158
		public struct OutMiddleIn
		{
			// Token: 0x0600060A RID: 1546 RVA: 0x00016697 File Offset: 0x00014897
			public OutMiddleIn(float Out, float In)
			{
				this.In = In;
				this.forcedMiddle = -1f;
				this.Out = Out;
			}

			// Token: 0x0600060B RID: 1547 RVA: 0x000166B2 File Offset: 0x000148B2
			public OutMiddleIn(float Out, float forcedMiddle, float In)
			{
				this.In = In;
				this.forcedMiddle = forcedMiddle;
				this.Out = Out;
			}

			// Token: 0x04000313 RID: 787
			public float Out;

			// Token: 0x04000314 RID: 788
			public float forcedMiddle;

			// Token: 0x04000315 RID: 789
			public float In;
		}

		// Token: 0x0200009F RID: 159
		[Serializable]
		public struct ModificadorDataSimple
		{
			// Token: 0x1700024F RID: 591
			// (get) Token: 0x0600060C RID: 1548 RVA: 0x000166CC File Offset: 0x000148CC
			public static Randomizado.ModificadorDataSimple @default
			{
				get
				{
					return new Randomizado.ModificadorDataSimple
					{
						inPowerAbove = 1f,
						outPowerBelow = 1f,
						modificador = 1f,
						clampMin = 0f,
						clampMax = 1f
					};
				}
			}

			// Token: 0x0600060D RID: 1549 RVA: 0x00016720 File Offset: 0x00014920
			public float Modificar(float current, float MinMod, float MaxMod, float defaultValue)
			{
				float num = current.OutInPow01(MinMod, MaxMod, this.inPowerAbove, this.outPowerBelow, defaultValue);
				return Mathf.Clamp(Mathf.Lerp(defaultValue, num, this.modificador), this.clampMin, this.clampMax);
			}

			// Token: 0x04000316 RID: 790
			public float inPowerAbove;

			// Token: 0x04000317 RID: 791
			public float outPowerBelow;

			// Token: 0x04000318 RID: 792
			public float modificador;

			// Token: 0x04000319 RID: 793
			public float clampMin;

			// Token: 0x0400031A RID: 794
			public float clampMax;
		}

		// Token: 0x020000A0 RID: 160
		[Serializable]
		public struct ModificadorDataAvanzado
		{
			// Token: 0x17000250 RID: 592
			// (get) Token: 0x0600060E RID: 1550 RVA: 0x00016764 File Offset: 0x00014964
			public static Randomizado.ModificadorDataAvanzado @default
			{
				get
				{
					return new Randomizado.ModificadorDataAvanzado
					{
						powerA = new Randomizado.OutMiddleIn(0f, 0f),
						powerB = new Randomizado.OutMiddleIn(0f, 0f),
						powerC = new Randomizado.OutMiddleIn(0f, 0f),
						modificador = 1f,
						clampA = new Vector2(-1f, -1f),
						clampB = new Vector2(-1f, -1f),
						clampC = new Vector2(-1f, -1f)
					};
				}
			}

			// Token: 0x0600060F RID: 1551 RVA: 0x0001680C File Offset: 0x00014A0C
			public float Modificar(float current, float MinMod, float MaxMod, float defaultMiddle)
			{
				Vector2? vector;
				switch (this.ClampToUse(current))
				{
				case 1:
					vector = new Vector2?(this.clampA);
					break;
				case 2:
					vector = new Vector2?(this.clampB);
					break;
				case 3:
					vector = new Vector2?(this.clampC);
					break;
				default:
					vector = null;
					break;
				}
				if (vector != null)
				{
					Vector2 value = vector.Value;
					current = MathfExtension.ClampAngle2(current * 360f, value.x * 360f, value.y * 360f) / 360f;
				}
				Randomizado.OutMiddleIn? outMiddleIn;
				switch (this.PowerToUse(current))
				{
				case 1:
					outMiddleIn = new Randomizado.OutMiddleIn?(this.powerA);
					break;
				case 2:
					outMiddleIn = new Randomizado.OutMiddleIn?(this.powerB);
					break;
				case 3:
					outMiddleIn = new Randomizado.OutMiddleIn?(this.powerC);
					break;
				default:
					outMiddleIn = null;
					break;
				}
				if (outMiddleIn != null)
				{
					Randomizado.OutMiddleIn value2 = outMiddleIn.Value;
					if (value2.forcedMiddle >= 0f)
					{
						defaultMiddle = value2.forcedMiddle;
					}
					if (vector != null)
					{
						Vector2 value3 = vector.Value;
						float num = Mathf.Abs(value3.x - value3.y);
						current = current.OutInPow01Clamped(value3.x - num * Random.Range(-0.333f, 0.333f), value3.y + num * Random.Range(-0.333f, 0.333f), value2.In, value2.Out, defaultMiddle);
						current = Mathf.Clamp(current, MinMod, MaxMod);
					}
					else
					{
						current = current.OutInPow01(MinMod, MaxMod, value2.In, value2.Out, defaultMiddle);
					}
					current = Mathf.Lerp(defaultMiddle, current, this.modificador);
				}
				return current;
			}

			// Token: 0x06000610 RID: 1552 RVA: 0x000169D8 File Offset: 0x00014BD8
			private int ClampToUse(float value)
			{
				float num = (this.clampA.x + this.clampA.y) / 2f;
				float num2 = (this.clampB.x + this.clampB.y) / 2f;
				float num3 = (this.clampC.x + this.clampC.y) / 2f;
				float num4 = Mathf.Abs(Mathf.DeltaAngle(num * 360f, value * 360f) / 360f) - Mathf.Abs(this.clampA.x - this.clampA.y);
				float num5 = Mathf.Abs(Mathf.DeltaAngle(num2 * 360f, value * 360f) / 360f) - Mathf.Abs(this.clampB.x - this.clampB.y);
				float num6 = Mathf.Abs(Mathf.DeltaAngle(num3 * 360f, value * 360f) / 360f) - Mathf.Abs(this.clampC.x - this.clampC.y);
				if (num >= 0f && num4 <= num5 && num4 <= num6)
				{
					return 1;
				}
				if (num2 >= 0f && num5 <= num4 && num5 <= num6)
				{
					return 2;
				}
				if (num3 >= 0f && num6 <= num4 && num6 <= num5)
				{
					return 3;
				}
				return 0;
			}

			// Token: 0x06000611 RID: 1553 RVA: 0x00016B30 File Offset: 0x00014D30
			private int PowerToUse(float value)
			{
				bool flag = this.powerA.In > 0f && this.powerA.Out > 0f;
				bool flag2 = this.powerB.In > 0f && this.powerB.Out > 0f;
				bool flag3 = this.powerC.In > 0f && this.powerC.Out > 0f;
				if (flag && value >= this.clampA.x && value <= this.clampA.y)
				{
					return 1;
				}
				if (flag2 && value >= this.clampB.x && value <= this.clampB.y)
				{
					return 2;
				}
				if (flag3 && value >= this.clampC.x && value <= this.clampC.y)
				{
					return 3;
				}
				if (flag)
				{
					return 1;
				}
				if (flag2)
				{
					return 2;
				}
				if (flag3)
				{
					return 3;
				}
				Debug.LogError("Siempre deberia haber un power modificador valido");
				return 0;
			}

			// Token: 0x0400031B RID: 795
			public float modificador;

			// Token: 0x0400031C RID: 796
			public Randomizado.OutMiddleIn powerA;

			// Token: 0x0400031D RID: 797
			public Randomizado.OutMiddleIn powerB;

			// Token: 0x0400031E RID: 798
			public Randomizado.OutMiddleIn powerC;

			// Token: 0x0400031F RID: 799
			public Vector2 clampA;

			// Token: 0x04000320 RID: 800
			public Vector2 clampB;

			// Token: 0x04000321 RID: 801
			public Vector2 clampC;
		}

		// Token: 0x020000A1 RID: 161
		[Serializable]
		public struct DataAvanzada
		{
			// Token: 0x06000612 RID: 1554 RVA: 0x00016C34 File Offset: 0x00014E34
			public DataAvanzada(string alteradorName, int modIndex, float inPowToMiddle, float outPowToMiddle, float modificador = 1f)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.powerA = new Randomizado.OutMiddleIn(outPowToMiddle, inPowToMiddle);
				this.modificador = modificador;
				this.powerB = new Randomizado.OutMiddleIn(0f, 0f);
				this.powerC = new Randomizado.OutMiddleIn(0f, 0f);
				this.clampA = new Vector2(-1f, -1f);
				this.clampB = new Vector2(-1f, -1f);
				this.clampC = new Vector2(-1f, -1f);
			}

			// Token: 0x06000613 RID: 1555 RVA: 0x00016CD0 File Offset: 0x00014ED0
			public DataAvanzada(string alteradorName, int modIndex, float forcedMiddle, float inPowToMiddle, float outPowToMiddle, float modificador)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.powerA = new Randomizado.OutMiddleIn(outPowToMiddle, forcedMiddle, inPowToMiddle);
				this.modificador = modificador;
				this.powerB = new Randomizado.OutMiddleIn(0f, 0f);
				this.powerC = new Randomizado.OutMiddleIn(0f, 0f);
				this.clampA = new Vector2(-1f, -1f);
				this.clampB = new Vector2(-1f, -1f);
				this.clampC = new Vector2(-1f, -1f);
			}

			// Token: 0x06000614 RID: 1556 RVA: 0x00016D6C File Offset: 0x00014F6C
			public DataAvanzada(string alteradorName, int modIndex, Randomizado.OutMiddleIn powerA)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.modificador = 1f;
				this.powerA = powerA;
				this.powerB = new Randomizado.OutMiddleIn(0f, 0f);
				this.powerC = new Randomizado.OutMiddleIn(0f, 0f);
				this.clampA = new Vector2(-1f, -1f);
				this.clampB = new Vector2(-1f, -1f);
				this.clampC = new Vector2(-1f, -1f);
			}

			// Token: 0x06000615 RID: 1557 RVA: 0x00016E04 File Offset: 0x00015004
			public DataAvanzada(string alteradorName, int modIndex, Randomizado.OutMiddleIn powerA, Vector2 clampA)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.modificador = 1f;
				this.powerA = powerA;
				this.powerB = new Randomizado.OutMiddleIn(0f, 0f);
				this.powerC = new Randomizado.OutMiddleIn(0f, 0f);
				this.clampA = clampA;
				this.clampB = new Vector2(-1f, -1f);
				this.clampC = new Vector2(-1f, -1f);
			}

			// Token: 0x06000616 RID: 1558 RVA: 0x00016E90 File Offset: 0x00015090
			public DataAvanzada(string alteradorName, int modIndex, Randomizado.OutMiddleIn powerA, Randomizado.OutMiddleIn powerB, Vector2 clampA, Vector2 clampB)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.modificador = 1f;
				this.powerA = powerA;
				this.powerB = powerB;
				this.powerC = new Randomizado.OutMiddleIn(0f, 0f);
				this.clampA = clampA;
				this.clampB = clampB;
				this.clampC = new Vector2(-1f, -1f);
			}

			// Token: 0x04000322 RID: 802
			public string alteradorName;

			// Token: 0x04000323 RID: 803
			public int modIndex;

			// Token: 0x04000324 RID: 804
			public Randomizado.OutMiddleIn powerA;

			// Token: 0x04000325 RID: 805
			public Randomizado.OutMiddleIn powerB;

			// Token: 0x04000326 RID: 806
			public Randomizado.OutMiddleIn powerC;

			// Token: 0x04000327 RID: 807
			[Range(0f, 1f)]
			public float modificador;

			// Token: 0x04000328 RID: 808
			[Range(0f, 1f)]
			public Vector2 clampA;

			// Token: 0x04000329 RID: 809
			[Range(0f, 1f)]
			public Vector2 clampB;

			// Token: 0x0400032A RID: 810
			[Range(0f, 1f)]
			public Vector2 clampC;
		}

		// Token: 0x020000A2 RID: 162
		[Serializable]
		public struct DataSimple
		{
			// Token: 0x06000617 RID: 1559 RVA: 0x00016F00 File Offset: 0x00015100
			public DataSimple(string alteradorName, int modIndex, float? middleValue, float inPowToMiddle, float outPowToMiddle)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.middleValue = middleValue;
				this.inPowToMiddle = inPowToMiddle;
				this.outPowToMiddle = outPowToMiddle;
				this.modificador = 1f;
				this.clampMin = 0f;
				this.clampMax = 1f;
			}

			// Token: 0x06000618 RID: 1560 RVA: 0x00016F54 File Offset: 0x00015154
			public DataSimple(string alteradorName, int modIndex, float? middleValue, float inPowToMiddle, float outPowToMiddle, float modificador)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.middleValue = middleValue;
				this.inPowToMiddle = inPowToMiddle;
				this.outPowToMiddle = outPowToMiddle;
				this.modificador = Mathf.Clamp01(modificador);
				this.clampMin = 0f;
				this.clampMax = 1f;
			}

			// Token: 0x06000619 RID: 1561 RVA: 0x00016FAC File Offset: 0x000151AC
			public DataSimple(string alteradorName, int modIndex, float? middleValue, float inPowToMiddle, float outPowToMiddle, float modificador, float clampMin, float clampMax)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.middleValue = middleValue;
				this.inPowToMiddle = inPowToMiddle;
				this.outPowToMiddle = outPowToMiddle;
				this.modificador = Mathf.Clamp01(modificador);
				this.clampMin = clampMin;
				this.clampMax = clampMax;
			}

			// Token: 0x0600061A RID: 1562 RVA: 0x00016FFC File Offset: 0x000151FC
			public DataSimple(string alteradorName, int modIndex, float? middleValue, float inPowToMiddle, float outPowToMiddle, float clampMin, float clampMax)
			{
				this.alteradorName = alteradorName;
				this.modIndex = modIndex;
				this.middleValue = middleValue;
				this.inPowToMiddle = inPowToMiddle;
				this.outPowToMiddle = outPowToMiddle;
				this.modificador = 1f;
				this.clampMin = clampMin;
				this.clampMax = clampMax;
			}

			// Token: 0x0400032B RID: 811
			public string alteradorName;

			// Token: 0x0400032C RID: 812
			public int modIndex;

			// Token: 0x0400032D RID: 813
			public float? middleValue;

			// Token: 0x0400032E RID: 814
			public float inPowToMiddle;

			// Token: 0x0400032F RID: 815
			public float outPowToMiddle;

			// Token: 0x04000330 RID: 816
			[Range(0f, 1f)]
			public float modificador;

			// Token: 0x04000331 RID: 817
			[Range(0f, 1f)]
			public float clampMin;

			// Token: 0x04000332 RID: 818
			[Range(0f, 1f)]
			public float clampMax;
		}

		// Token: 0x020000A3 RID: 163
		public abstract class ModificadorBaseAvanzado
		{
			// Token: 0x0600061B RID: 1563 RVA: 0x00017049 File Offset: 0x00015249
			public void SetPowers(float inPower, float outPower)
			{
				this.m_data.powerA.In = inPower;
				this.m_data.powerA.Out = outPower;
			}

			// Token: 0x0600061C RID: 1564 RVA: 0x0001706D File Offset: 0x0001526D
			public void SetPowers(Randomizado.OutMiddleIn powerA, Randomizado.OutMiddleIn powerB, Randomizado.OutMiddleIn powerC)
			{
				this.m_data.powerA = powerA;
				this.m_data.powerB = powerB;
				this.m_data.powerC = powerC;
			}

			// Token: 0x0600061D RID: 1565 RVA: 0x00017093 File Offset: 0x00015293
			public void SetModificador(float mod)
			{
				this.m_data.modificador = Mathf.Clamp01(mod);
			}

			// Token: 0x0600061E RID: 1566 RVA: 0x000170A6 File Offset: 0x000152A6
			public void SetMinMaxClamp(Vector2 clampA, Vector2 clampB, Vector2 clampC)
			{
				this.SetMinMaxClamp(ref this.m_data.clampA, clampA);
				this.SetMinMaxClamp(ref this.m_data.clampB, clampB);
				this.SetMinMaxClamp(ref this.m_data.clampC, clampC);
			}

			// Token: 0x0600061F RID: 1567 RVA: 0x000170DE File Offset: 0x000152DE
			private void SetMinMaxClamp(ref Vector2 rangeTarget, Vector2 rangeUser)
			{
				this.SetMinMaxClamp(ref rangeTarget, rangeUser.x, rangeUser.y);
			}

			// Token: 0x06000620 RID: 1568 RVA: 0x000170F3 File Offset: 0x000152F3
			private void SetMinMaxClamp(ref Vector2 range, float min, float max)
			{
				range.x = min;
				range.y = max;
			}

			// Token: 0x06000621 RID: 1569 RVA: 0x00017103 File Offset: 0x00015303
			private void SetPowers(ref Randomizado.OutMiddleIn target, Randomizado.OutMiddleIn user)
			{
				target = user;
			}

			// Token: 0x06000622 RID: 1570 RVA: 0x0001710C File Offset: 0x0001530C
			public float Modificar(float current, float MinMod, float MaxMod, float defaultMiddle)
			{
				if (MinMod < 0f || MinMod > 1f)
				{
					throw new InvalidOperationException();
				}
				if (MaxMod < 0f || MaxMod > 1f)
				{
					throw new InvalidOperationException();
				}
				if (MinMod >= MaxMod)
				{
					throw new InvalidOperationException();
				}
				this.m_lastValueEntrante = Mathf.Lerp(MinMod, MaxMod, current);
				this.m_lastValueResult = this.m_data.Modificar(current, MinMod, MaxMod, defaultMiddle);
				return this.m_lastValueResult;
			}

			// Token: 0x04000333 RID: 819
			[Header("Data:")]
			[SerializeField]
			private Randomizado.ModificadorDataAvanzado m_data = Randomizado.ModificadorDataAvanzado.@default;

			// Token: 0x04000334 RID: 820
			[ReadOnlyUI]
			[SerializeField]
			private float m_lastValueEntrante;

			// Token: 0x04000335 RID: 821
			[ReadOnlyUI]
			[SerializeField]
			private float m_lastValueResult;
		}

		// Token: 0x020000A4 RID: 164
		public abstract class ModificadorBaseSimple
		{
			// Token: 0x06000624 RID: 1572 RVA: 0x0001718C File Offset: 0x0001538C
			[Obsolete("", true)]
			public void SetDefaultValue(float value)
			{
			}

			// Token: 0x06000625 RID: 1573 RVA: 0x0001718E File Offset: 0x0001538E
			public void SetPowers(float inPower, float outPower)
			{
				this.m_data.inPowerAbove = inPower;
				this.m_data.outPowerBelow = outPower;
			}

			// Token: 0x06000626 RID: 1574 RVA: 0x000171A8 File Offset: 0x000153A8
			public void SetModificador(float mod)
			{
				this.m_data.modificador = Mathf.Clamp01(mod);
			}

			// Token: 0x06000627 RID: 1575 RVA: 0x000171BC File Offset: 0x000153BC
			public void SetMinMaxClamp(float min, float max)
			{
				if (min < 0f || min > 1f)
				{
					throw new InvalidOperationException();
				}
				if (max < 0f || max > 1f)
				{
					throw new InvalidOperationException();
				}
				if (min >= max)
				{
					throw new InvalidOperationException();
				}
				this.m_data.clampMin = min;
				this.m_data.clampMax = max;
			}

			// Token: 0x06000628 RID: 1576 RVA: 0x00017218 File Offset: 0x00015418
			public float Modificar(float current, float MinMod, float MaxMod, float defaultValue)
			{
				if (defaultValue < 0f || defaultValue > 1f)
				{
					throw new InvalidOperationException();
				}
				if (MinMod < 0f || MinMod > 1f)
				{
					throw new InvalidOperationException();
				}
				if (MaxMod < 0f || MaxMod > 1f)
				{
					throw new InvalidOperationException();
				}
				if (MinMod >= MaxMod)
				{
					throw new InvalidOperationException();
				}
				this.m_lastValueEntrante = Mathf.Lerp(MinMod, MaxMod, current);
				this.m_lastValueResult = this.m_data.Modificar(current, MinMod, MaxMod, defaultValue);
				return this.m_lastValueResult;
			}

			// Token: 0x04000336 RID: 822
			[Header("Data:")]
			[SerializeField]
			private Randomizado.ModificadorDataSimple m_data = Randomizado.ModificadorDataSimple.@default;

			// Token: 0x04000337 RID: 823
			[ReadOnlyUI]
			[SerializeField]
			private float m_lastValueEntrante;

			// Token: 0x04000338 RID: 824
			[ReadOnlyUI]
			[SerializeField]
			private float m_lastValueResult;
		}

		// Token: 0x020000A5 RID: 165
		[Serializable]
		public class ModificadorAvanzadoParaNombre : Randomizado.ModificadorBaseAvanzado
		{
			// Token: 0x17000251 RID: 593
			// (get) Token: 0x0600062A RID: 1578 RVA: 0x000172B0 File Offset: 0x000154B0
			public string name
			{
				get
				{
					return this.m_name;
				}
			}

			// Token: 0x0600062B RID: 1579 RVA: 0x000172B8 File Offset: 0x000154B8
			public void SetName(string n)
			{
				this.m_name = n;
			}

			// Token: 0x04000339 RID: 825
			[Header("Para:")]
			[SerializeField]
			private string m_name;
		}

		// Token: 0x020000A6 RID: 166
		[Serializable]
		public class ModificadorSimpleParaNombre : Randomizado.ModificadorBaseSimple
		{
			// Token: 0x17000252 RID: 594
			// (get) Token: 0x0600062D RID: 1581 RVA: 0x000172C9 File Offset: 0x000154C9
			public string name
			{
				get
				{
					return this.m_name;
				}
			}

			// Token: 0x0600062E RID: 1582 RVA: 0x000172D1 File Offset: 0x000154D1
			public void SetName(string n)
			{
				this.m_name = n;
			}

			// Token: 0x0400033A RID: 826
			[Header("Para:")]
			[SerializeField]
			private string m_name;
		}

		// Token: 0x020000A7 RID: 167
		[Serializable]
		public class ModificadorAvanzadoParaNombreIndex : Randomizado.ModificadorAvanzadoParaNombre
		{
			// Token: 0x17000253 RID: 595
			// (get) Token: 0x06000630 RID: 1584 RVA: 0x000172E2 File Offset: 0x000154E2
			public int index
			{
				get
				{
					return this.m_index;
				}
			}

			// Token: 0x06000631 RID: 1585 RVA: 0x000172EA File Offset: 0x000154EA
			public void SetIndex(int i)
			{
				this.m_index = i;
			}

			// Token: 0x0400033B RID: 827
			[SerializeField]
			private int m_index;
		}

		// Token: 0x020000A8 RID: 168
		[Serializable]
		public class ModificadorSimpleParaNombreIndex : Randomizado.ModificadorSimpleParaNombre
		{
			// Token: 0x17000254 RID: 596
			// (get) Token: 0x06000633 RID: 1587 RVA: 0x000172FB File Offset: 0x000154FB
			public int index
			{
				get
				{
					return this.m_index;
				}
			}

			// Token: 0x06000634 RID: 1588 RVA: 0x00017303 File Offset: 0x00015503
			public void SetIndex(int i)
			{
				this.m_index = i;
			}

			// Token: 0x0400033C RID: 828
			[SerializeField]
			private int m_index;
		}
	}
}
