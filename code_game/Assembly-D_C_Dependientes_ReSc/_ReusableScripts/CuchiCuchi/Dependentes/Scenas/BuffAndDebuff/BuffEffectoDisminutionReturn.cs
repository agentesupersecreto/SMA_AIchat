using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x0200008F RID: 143
	public class BuffEffectoDisminutionReturn
	{
		// Token: 0x06000309 RID: 777 RVA: 0x00013821 File Offset: 0x00011A21
		public static float Mul(float mod, float minMod, float maxMod, float power)
		{
			return MathfExtension.DiminishingReturnMul(mod, minMod, maxMod, power);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0001382C File Offset: 0x00011A2C
		public static float Add(float value, float minValue, float maxValue, float power)
		{
			return MathfExtension.DiminishingReturnAdd(value, minValue, maxValue, power);
		}
	}
}
