using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Animations
{
	// Token: 0x02000299 RID: 665
	public static class IFemeninityWeightProducerEXT
	{
		// Token: 0x06000EA0 RID: 3744 RVA: 0x00044C20 File Offset: 0x00042E20
		public static float CalculeFemeninityFrom(this ICharacter character)
		{
			float num;
			try
			{
				character.GetComponentsInChildren<IFemeninityWeightProducer>(IFemeninityWeightProducerEXT.m_TEMP);
				num = IFemeninityWeightProducerEXT.m_TEMP.CalculeFemeninityFrom();
			}
			finally
			{
				IFemeninityWeightProducerEXT.m_TEMP.Clear();
			}
			return num;
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00044C64 File Offset: 0x00042E64
		public static float CalculeFemeninityFrom(this IReadOnlyList<Object> producers)
		{
			if (producers == null || producers.Count == 0)
			{
				return 0f;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 1f;
			int num4 = 0;
			for (int i = 0; i < producers.Count; i++)
			{
				IFemeninityWeightProducer femeninityWeightProducer = producers[i] as IFemeninityWeightProducer;
				if (femeninityWeightProducer != null)
				{
					num4++;
					num += femeninityWeightProducer.prom;
					num2 += femeninityWeightProducer.adding;
					num3 *= femeninityWeightProducer.modding;
				}
			}
			if (num4 == 0)
			{
				return 0f;
			}
			num /= (float)num4;
			return Mathf.Clamp01((num + num2) * num3);
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00044CF8 File Offset: 0x00042EF8
		public static float CalculeFemeninityFrom(this IReadOnlyList<IFemeninityWeightProducer> producers)
		{
			if (producers == null || producers.Count == 0)
			{
				return 0f;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 1f;
			for (int i = 0; i < producers.Count; i++)
			{
				IFemeninityWeightProducer femeninityWeightProducer = producers[i];
				num += femeninityWeightProducer.prom;
				num2 += femeninityWeightProducer.adding;
				num3 *= femeninityWeightProducer.modding;
			}
			num /= (float)producers.Count;
			return Mathf.Clamp01((num + num2) * num3);
		}

		// Token: 0x04000C92 RID: 3218
		private static List<IFemeninityWeightProducer> m_TEMP = new List<IFemeninityWeightProducer>();
	}
}
