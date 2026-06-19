using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
public static class EXT__FloatEXT
{
	// Token: 0x06000198 RID: 408 RVA: 0x00009544 File Offset: 0x00007744
	public static float ToEuler(this float angle)
	{
		return angle % 360f;
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00009550 File Offset: 0x00007750
	public static float ToAngle(this float angle)
	{
		float num = angle % 360f;
		if (num < 0f)
		{
			num = 360f + num;
		}
		return num;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00009578 File Offset: 0x00007778
	public static float ToDirectionAngle(this float angle)
	{
		float num = angle.ToAngle();
		if (num > 180f)
		{
			num = 180f - (num - 180f);
		}
		return num;
	}

	// Token: 0x0600019B RID: 411 RVA: 0x000095A4 File Offset: 0x000077A4
	public static float ToRectAngle(this float angle)
	{
		float num = angle.ToDirectionAngle();
		if (num > 90f)
		{
			num = 90f - (num - 90f);
		}
		return num;
	}

	// Token: 0x0600019C RID: 412 RVA: 0x000095D0 File Offset: 0x000077D0
	public static float ToAnglePolarizado(this float angle)
	{
		float num = angle % 360f;
		if (num > 180f)
		{
			num -= 360f;
		}
		if (num < -180f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00009608 File Offset: 0x00007808
	public static float ToWeight(this float value)
	{
		float num = value % 1f;
		if (num != 0f)
		{
			if (num < 0f)
			{
				num += 1f;
			}
			return num;
		}
		if (value == 0f)
		{
			return 0f;
		}
		return 1f;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x0000964C File Offset: 0x0000784C
	public static bool ProcPorSegundoV2(this float probabilidadPorSegundo, ref float m_lastTickChance, ref float m_lastProcTimeChance, float cooldown = 0f, float mod = 1f)
	{
		float num = Mathf.Clamp(probabilidadPorSegundo * mod, 0f, 100f);
		m_lastTickChance = num;
		if (num >= 100f)
		{
			return true;
		}
		float num2 = Time.time - m_lastProcTimeChance;
		float num3 = ((cooldown < 1f) ? cooldown : 1f);
		if (Mathf.Clamp(num2, 0f, num3) == num3)
		{
			m_lastTickChance = num * num3;
			m_lastProcTimeChance = Time.time;
		}
		else
		{
			m_lastTickChance *= Time.deltaTime;
		}
		if (m_lastTickChance >= 100f)
		{
			return true;
		}
		if (m_lastTickChance <= 0f)
		{
			return false;
		}
		float num4 = global::UnityEngine.Random.value * 100f;
		bool flag = m_lastTickChance > num4;
		if (flag)
		{
			m_lastProcTimeChance = Time.time;
		}
		return flag;
	}

	// Token: 0x0600019F RID: 415 RVA: 0x000096EC File Offset: 0x000078EC
	public static bool ProcPorSegundo(this float probabilidadPorSegundo, float mod = 1f)
	{
		float num = Mathf.Clamp(probabilidadPorSegundo * mod, 0f, 100f);
		float num2 = num * Time.deltaTime;
		num2 = Mathf.Lerp(num2, num, num / 100f);
		return num2 >= 100f || (num2 > 0f && num2 > global::UnityEngine.Random.value * 100f);
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00009748 File Offset: 0x00007948
	public static bool ProcMod(this float modificador, float mod = 1f)
	{
		float num = Mathf.Clamp01(modificador * mod);
		return num >= 1f || (num > 0f && num > global::UnityEngine.Random.value);
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0000977C File Offset: 0x0000797C
	public static bool ProcPorcentaje(this float procentaje, float mod = 1f)
	{
		float num = Mathf.Clamp(procentaje * mod, 0f, 100f);
		return num >= 100f || (num > 0f && num > global::UnityEngine.Random.value * 100f);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x000097C0 File Offset: 0x000079C0
	public static float Random(this float valor, float rangeMod)
	{
		if (valor == 0f)
		{
			return 0f;
		}
		rangeMod = Mathf.Clamp01(rangeMod);
		if (rangeMod == 0f)
		{
			return valor;
		}
		float num = Mathf.Abs(valor * rangeMod);
		float num2 = global::UnityEngine.Random.Range(-num, num);
		return valor + num2;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00009802 File Offset: 0x00007A02
	public static float Inverse01(this float valord)
	{
		return 1f - Mathf.Clamp01(valord);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00009810 File Offset: 0x00007A10
	public static float Random01Range(this float valor, float rangeMod)
	{
		rangeMod = Mathf.Clamp01(rangeMod);
		valor = Mathf.Clamp01(valor);
		if (rangeMod == 0f)
		{
			return valor;
		}
		float num = valor - rangeMod;
		float num2 = valor + rangeMod;
		return Mathf.Clamp01(global::UnityEngine.Random.Range(num, num2));
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0000984C File Offset: 0x00007A4C
	public static float Random01Lerp(this float valor, float rangeMod)
	{
		rangeMod = Mathf.Clamp01(rangeMod);
		valor = Mathf.Clamp01(valor);
		if (rangeMod == 0f)
		{
			return valor;
		}
		float num = Mathf.Lerp(valor, 0f, rangeMod);
		float num2 = Mathf.Lerp(valor, 1f, rangeMod);
		return global::UnityEngine.Random.Range(num, num2);
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00009892 File Offset: 0x00007A92
	public static float Random360(this float angle, float angleRange)
	{
		angleRange = angleRange.ToAngle();
		angle = angle.ToAngle();
		if (angleRange == 0f)
		{
			return angle;
		}
		return global::UnityEngine.Random.Range(angle - angleRange, angle + angleRange).ToAngle();
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x000098C0 File Offset: 0x00007AC0
	public static double Random(this double valor, float rangeMod)
	{
		if (valor == 0.0)
		{
			return 0.0;
		}
		rangeMod = Mathf.Clamp01(rangeMod);
		if (rangeMod == 0f)
		{
			return valor;
		}
		float num = (float)Math.Abs(valor * (double)rangeMod);
		float num2 = global::UnityEngine.Random.Range(-num, num);
		return valor + (double)num2;
	}
}
