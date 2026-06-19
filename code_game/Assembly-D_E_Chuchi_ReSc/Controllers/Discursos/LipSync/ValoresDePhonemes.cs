using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x0200027C RID: 636
	[Serializable]
	public class ValoresDePhonemes
	{
		// Token: 0x06000E22 RID: 3618 RVA: 0x00042B88 File Offset: 0x00040D88
		public ValoresDePhonemes()
		{
			ICollection enumValoresObject = typeof(Phoneme).GetEnumValoresObject();
			this.m_dic = new DiccionaryEnum<Phoneme, ValorDePhoneme>(enumValoresObject.Count, (Phoneme k) => (int)k);
			this.m_lista = new List<ValorDePhoneme>(enumValoresObject.Count);
			foreach (object obj in enumValoresObject)
			{
				Phoneme phoneme = (Phoneme)obj;
				ValorDePhoneme valorDePhoneme = new ValorDePhoneme(phoneme);
				this.m_dic.Add(phoneme, valorDePhoneme);
				this.m_lista.Add(valorDePhoneme);
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x00042C50 File Offset: 0x00040E50
		public IReadOnlyDictionary<int, ValorDePhoneme> dicc
		{
			get
			{
				return this.m_dic;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00042C58 File Offset: 0x00040E58
		public IReadOnlyList<ValorDePhoneme> valores
		{
			get
			{
				return this.m_lista;
			}
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x00042C60 File Offset: 0x00040E60
		public void CopiarSmooth(ValoresDePhonemes source, float deltaTime, float velocidad)
		{
			if (source == null || source == this)
			{
				throw new InvalidOperationException();
			}
			float num = deltaTime * velocidad;
			for (int i = 0; i < source.m_lista.Count; i++)
			{
				ValorDePhoneme valorDePhoneme = source.m_lista[i];
				ValorDePhoneme valorDePhoneme2 = this.m_lista[i];
				valorDePhoneme2.valor = Mathf.MoveTowards(valorDePhoneme2.valor, valorDePhoneme.valor, num);
			}
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x00042CC4 File Offset: 0x00040EC4
		public void NormalizarDesde(ValoresDePhonemes source)
		{
			if (source == null || source == this)
			{
				throw new InvalidOperationException();
			}
			float num = 0f;
			for (int i = 0; i < source.m_lista.Count; i++)
			{
				ValorDePhoneme valorDePhoneme = source.m_lista[i];
				this.m_lista[i].valor = valorDePhoneme.valor;
				num += valorDePhoneme.valor;
			}
			if (num == 0f)
			{
				return;
			}
			for (int j = 0; j < source.m_lista.Count; j++)
			{
				this.m_lista[j].valor /= num;
			}
		}

		// Token: 0x04000C14 RID: 3092
		private DiccionaryEnum<Phoneme, ValorDePhoneme> m_dic;

		// Token: 0x04000C15 RID: 3093
		[SerializeField]
		private List<ValorDePhoneme> m_lista;
	}
}
