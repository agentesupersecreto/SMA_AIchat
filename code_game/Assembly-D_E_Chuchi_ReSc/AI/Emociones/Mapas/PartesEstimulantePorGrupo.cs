using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x0200045E RID: 1118
	[CreateAssetMenu(fileName = "PartesEstimulantePorGrupo", menuName = "Objetos/Emociones/PartesEstimulantePorGrupo")]
	public class PartesEstimulantePorGrupo : ValorPorGrupoDicc<PartesEstimulantePorGrupo.Item, PartesEstimulantePorGrupo.Partes>
	{
		// Token: 0x06001851 RID: 6225 RVA: 0x00061048 File Offset: 0x0005F248
		public GrupoQueCompartenValores GetGrupoDeParte(ParteQuePuedeEstimular parte)
		{
			if (parte == ParteQuePuedeEstimular.None)
			{
				return GrupoQueCompartenValores.f;
			}
			GrupoQueCompartenValores grupoQueCompartenValores;
			if (this.m_grupoDeParteHumana != null && Application.isPlaying && this.m_grupoDeParteHumana.TryGetValue(parte, out grupoQueCompartenValores))
			{
				return grupoQueCompartenValores;
			}
			int count = base.GetCount();
			for (int i = 0; i < count; i++)
			{
				PartesEstimulantePorGrupo.Item item = base[i];
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

		// Token: 0x06001852 RID: 6226 RVA: 0x000610D4 File Offset: 0x0005F2D4
		public void SetGrupoDeParte(ParteQuePuedeEstimular parte, GrupoQueCompartenValores grupoEnum)
		{
			if (!Application.isPlaying)
			{
				throw new NotSupportedException();
			}
			int count = base.GetCount();
			for (int i = 0; i < count; i++)
			{
				PartesEstimulantePorGrupo.Item item = base[i];
				if (item.valor.partesSet.Contains((int)parte))
				{
					item.valor.partesSet.Remove((int)parte);
					item.valor.partes.Remove(parte);
				}
			}
			PartesEstimulantePorGrupo.Item item2 = base[grupoEnum];
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

		// Token: 0x06001853 RID: 6227 RVA: 0x0006119A File Offset: 0x0005F39A
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Rectificar y Añadir no presentes a F."
			};
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x000611B4 File Offset: 0x0005F3B4
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			List<PartesEstimulantePorGrupo.Item> list = base.ObtenerGrupos().ToList<PartesEstimulantePorGrupo.Item>();
			list.ForEach(new Action<PartesEstimulantePorGrupo.Item>(this.RemoverRepetidoHandler));
			list.Colisionar(new Action<PartesEstimulantePorGrupo.Item, PartesEstimulantePorGrupo.Item>(this.RemoverRepetidoHandler2));
			foreach (object obj in typeof(ParteQuePuedeEstimular).GetEnumValoresObject())
			{
				ParteQuePuedeEstimular parteQuePuedeEstimular = (ParteQuePuedeEstimular)obj;
				bool flag = false;
				foreach (KeyValuePair<int, PartesEstimulantePorGrupo.Item> keyValuePair in this)
				{
					if (keyValuePair.Value.valor.partes.Contains(parteQuePuedeEstimular))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					base.f.valor.partes.Add(parteQuePuedeEstimular);
				}
			}
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x000612B0 File Offset: 0x0005F4B0
		private void RemoverRepetidoHandler(PartesEstimulantePorGrupo.Item aa)
		{
			aa.valor.partes = aa.valor.partes.Distinct<ParteQuePuedeEstimular>().ToList<ParteQuePuedeEstimular>();
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x000612D4 File Offset: 0x0005F4D4
		private void RemoverRepetidoHandler2(PartesEstimulantePorGrupo.Item aa, PartesEstimulantePorGrupo.Item bb)
		{
			bb.valor.partes.RemoveAll((ParteQuePuedeEstimular p) => aa.valor.partes.Contains(p));
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x0006130C File Offset: 0x0005F50C
		protected override void OnDiccIniciado()
		{
			base.OnDiccIniciado();
			if (!Application.isPlaying)
			{
				return;
			}
			this.m_grupoDeParteHumana = new DiccionaryEnum<ParteQuePuedeEstimular, GrupoQueCompartenValores>((ParteQuePuedeEstimular p) => (int)p);
			foreach (KeyValuePair<int, PartesEstimulantePorGrupo.Item> keyValuePair in this)
			{
				PartesEstimulantePorGrupo.Item value = keyValuePair.Value;
				PartesEstimulantePorGrupo.Partes valor = value.valor;
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

		// Token: 0x040012B7 RID: 4791
		[NonSerialized]
		private DiccionaryEnum<ParteQuePuedeEstimular, GrupoQueCompartenValores> m_grupoDeParteHumana;

		// Token: 0x0200045F RID: 1119
		[Serializable]
		public class Item : GrupoValorPar<PartesEstimulantePorGrupo.Partes>
		{
		}

		// Token: 0x02000460 RID: 1120
		[Serializable]
		public class Partes
		{
			// Token: 0x040012B8 RID: 4792
			[CoolArrayItem]
			public List<ParteQuePuedeEstimular> partes = new List<ParteQuePuedeEstimular>();

			// Token: 0x040012B9 RID: 4793
			public HashSet<int> partesSet;
		}
	}
}
