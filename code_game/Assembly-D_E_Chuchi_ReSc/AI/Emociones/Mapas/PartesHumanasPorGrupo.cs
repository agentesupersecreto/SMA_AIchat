using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000463 RID: 1123
	[CreateAssetMenu(fileName = "PartesHumanasPorGrupo", menuName = "Objetos/Emociones/PartesHumanasPorGrupo")]
	public class PartesHumanasPorGrupo : ValorPorGrupoDicc<PartesHumanasPorGrupo.Item, PartesHumanasPorGrupo.Partes>
	{
		// Token: 0x06001860 RID: 6240 RVA: 0x00061454 File Offset: 0x0005F654
		public GrupoQueCompartenValores GetGrupoDeParte(ParteDelCuerpoHumano parte)
		{
			GrupoQueCompartenValores grupoQueCompartenValores;
			if (this.m_grupoDeParteHumana != null && Application.isPlaying && this.m_grupoDeParteHumana.TryGetValue(parte, out grupoQueCompartenValores))
			{
				return grupoQueCompartenValores;
			}
			int count = base.GetCount();
			for (int i = 0; i < count; i++)
			{
				PartesHumanasPorGrupo.Item item = base[i];
				if (Application.isPlaying)
				{
					if (item.valor.partesSet.Contains((int)parte))
					{
						return item.grupo;
					}
				}
				else if (item.valor.partes.Contains(parte))
				{
					return item.grupo;
				}
			}
			return GrupoQueCompartenValores.f;
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x000614DC File Offset: 0x0005F6DC
		public void SetGrupoDeParte(ParteDelCuerpoHumano parte, GrupoQueCompartenValores grupoEnum)
		{
			if (!Application.isPlaying)
			{
				throw new NotSupportedException();
			}
			int count = base.GetCount();
			for (int i = 0; i < count; i++)
			{
				PartesHumanasPorGrupo.Item item = base[i];
				if (item.valor.partesSet.Contains((int)parte))
				{
					item.valor.partesSet.Remove((int)parte);
					item.valor.partes.Remove(parte);
				}
			}
			PartesHumanasPorGrupo.Item item2 = base[grupoEnum];
			item2.valor.partes.Add(parte);
			item2.valor.partesSet.Add((int)parte);
			if (this.m_grupoDeParteHumana != null)
			{
				if (this.m_grupoDeParteHumana.ContainsKey(parte))
				{
					this.m_grupoDeParteHumana[parte] = grupoEnum;
					return;
				}
				this.m_grupoDeParteHumana.Add(parte, grupoEnum);
			}
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0006119A File Offset: 0x0005F39A
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Rectificar y Añadir no presentes a F."
			};
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x000615A4 File Offset: 0x0005F7A4
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			List<PartesHumanasPorGrupo.Item> list = base.ObtenerGrupos().ToList<PartesHumanasPorGrupo.Item>();
			list.ForEach(new Action<PartesHumanasPorGrupo.Item>(this.RemoverRepetidoHandler));
			list.Colisionar(new Action<PartesHumanasPorGrupo.Item, PartesHumanasPorGrupo.Item>(this.RemoverRepetidoHandler2));
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				bool flag = false;
				foreach (KeyValuePair<int, PartesHumanasPorGrupo.Item> keyValuePair in this)
				{
					if (keyValuePair.Value.valor.partes.Contains(parteDelCuerpoHumano))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					base.f.valor.partes.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x000616A0 File Offset: 0x0005F8A0
		private void RemoverRepetidoHandler(PartesHumanasPorGrupo.Item aa)
		{
			aa.valor.partes = aa.valor.partes.Distinct<ParteDelCuerpoHumano>().ToList<ParteDelCuerpoHumano>();
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x000616C4 File Offset: 0x0005F8C4
		private void RemoverRepetidoHandler2(PartesHumanasPorGrupo.Item aa, PartesHumanasPorGrupo.Item bb)
		{
			bb.valor.partes.RemoveAll((ParteDelCuerpoHumano p) => aa.valor.partes.Contains(p));
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x000616FC File Offset: 0x0005F8FC
		protected override void OnDiccIniciado()
		{
			base.OnDiccIniciado();
			if (!Application.isPlaying)
			{
				return;
			}
			this.m_grupoDeParteHumana = new DiccionaryEnum<ParteDelCuerpoHumano, GrupoQueCompartenValores>((ParteDelCuerpoHumano p) => (int)p);
			foreach (KeyValuePair<int, PartesHumanasPorGrupo.Item> keyValuePair in this)
			{
				PartesHumanasPorGrupo.Item value = keyValuePair.Value;
				PartesHumanasPorGrupo.Partes valor = value.valor;
				if (valor.partesSet == null)
				{
					valor.partesSet = new HashSet<int>();
				}
				else
				{
					valor.partesSet.Clear();
				}
				for (int i = 0; i < valor.partes.Count; i++)
				{
					this.m_grupoDeParteHumana.Add(valor.partes[i], value.grupo);
					valor.partesSet.Add((int)valor.partes[i]);
				}
			}
		}

		// Token: 0x040012BD RID: 4797
		[NonSerialized]
		private DiccionaryEnum<ParteDelCuerpoHumano, GrupoQueCompartenValores> m_grupoDeParteHumana;

		// Token: 0x02000464 RID: 1124
		[Serializable]
		public class Item : GrupoValorPar<PartesHumanasPorGrupo.Partes>
		{
		}

		// Token: 0x02000465 RID: 1125
		[Serializable]
		public class Partes
		{
			// Token: 0x040012BE RID: 4798
			[CoolArrayItem]
			public List<ParteDelCuerpoHumano> partes = new List<ParteDelCuerpoHumano>();

			// Token: 0x040012BF RID: 4799
			public HashSet<int> partesSet;
		}
	}
}
