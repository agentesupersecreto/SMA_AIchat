using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000436 RID: 1078
	[CreateAssetMenu(fileName = "FloatPorGrupoDicc", menuName = "Objetos/Emociones/FloatPorGrupoDicc")]
	public class FloatPorGrupoDicc : ValorPorGrupoDicc<FloatPorGrupoDicc.Item, float>
	{
		// Token: 0x0600181F RID: 6175 RVA: 0x00060898 File Offset: 0x0005EA98
		public float ObtenerMenorValor(float defaultValue)
		{
			FloatPorGrupoDicc.Item item = this.ObtenerMenor();
			if (item == null)
			{
				return defaultValue;
			}
			if (item.valor <= 0f)
			{
				Debug.LogWarning(string.Concat(new string[]
				{
					base.GetType().Name,
					" con nombre: ",
					base.name,
					" grupo: ",
					item.grupo.ToString(),
					" tiene valor zero o negativo: ",
					item.valor.ToString()
				}), this);
			}
			return item.valor;
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x0006092C File Offset: 0x0005EB2C
		public float ObtenerMayorValor(float defaultValue)
		{
			FloatPorGrupoDicc.Item item = this.ObtenerMayor();
			if (item == null)
			{
				return defaultValue;
			}
			if (item.valor <= 0f)
			{
				Debug.LogWarning(string.Concat(new string[]
				{
					base.GetType().Name,
					" con nombre: ",
					base.name,
					" grupo: ",
					item.grupo.ToString(),
					" tiene valor zero o negativo: ",
					item.valor.ToString()
				}), this);
			}
			return item.valor;
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x000609C0 File Offset: 0x0005EBC0
		public FloatPorGrupoDicc.Item ObtenerMenor()
		{
			int count = base.GetCount();
			FloatPorGrupoDicc.Item item = null;
			for (int i = 0; i < count; i++)
			{
				FloatPorGrupoDicc.Item item2 = base[i];
				if (item == null || item2.valor < item.valor)
				{
					item = item2;
				}
			}
			return item;
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x00060A00 File Offset: 0x0005EC00
		public FloatPorGrupoDicc.Item ObtenerMayor()
		{
			int count = base.GetCount();
			FloatPorGrupoDicc.Item item = null;
			for (int i = 0; i < count; i++)
			{
				FloatPorGrupoDicc.Item item2 = base[i];
				if (item == null || item2.valor > item.valor)
				{
					item = item2;
				}
			}
			return item;
		}

		// Token: 0x02000437 RID: 1079
		[Serializable]
		public class Item : GrupoValorPar<float>
		{
		}
	}
}
