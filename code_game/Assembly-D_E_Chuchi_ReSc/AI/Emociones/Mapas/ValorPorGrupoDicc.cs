using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000431 RID: 1073
	public abstract class ValorPorGrupoDicc<TGrupo, TValue> : AplicableScriptable, IEnumerable<KeyValuePair<int, TGrupo>>, IEnumerable where TGrupo : GrupoValorPar<TValue>, GrupoSetter, new()
	{
		// Token: 0x060017E3 RID: 6115 RVA: 0x000604E1 File Offset: 0x0005E6E1
		public int GetCount()
		{
			this.InitDicc();
			return this.m_dicc.Count;
		}

		// Token: 0x17000624 RID: 1572
		public TGrupo this[GrupoQueCompartenValores g]
		{
			get
			{
				this.InitDicc();
				TGrupo tgrupo;
				if (g == GrupoQueCompartenValores.None)
				{
					Debug.LogError("Tratando de obtener grupo de GrupoQueCompartenValores, cuando este es None");
					tgrupo = default(TGrupo);
					return tgrupo;
				}
				try
				{
					tgrupo = this.m_dicc[g];
				}
				catch (Exception ex)
				{
					Debug.LogError("Diccionario no se cargo correctamente, no contiene grupo " + g.ToString(), this);
					throw ex;
				}
				return tgrupo;
			}
		}

		// Token: 0x17000625 RID: 1573
		public TGrupo this[int index]
		{
			get
			{
				this.InitDicc();
				return this.m_list[index];
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x060017E6 RID: 6118 RVA: 0x00060574 File Offset: 0x0005E774
		public TGrupo f
		{
			get
			{
				return this.m_f;
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x0006057C File Offset: 0x0005E77C
		public TGrupo e
		{
			get
			{
				return this.m_e;
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x060017E8 RID: 6120 RVA: 0x00060584 File Offset: 0x0005E784
		public TGrupo d
		{
			get
			{
				return this.m_d;
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x0006058C File Offset: 0x0005E78C
		public TGrupo c
		{
			get
			{
				return this.m_c;
			}
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x060017EA RID: 6122 RVA: 0x00060594 File Offset: 0x0005E794
		public TGrupo b
		{
			get
			{
				return this.m_b;
			}
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x060017EB RID: 6123 RVA: 0x0006059C File Offset: 0x0005E79C
		public TGrupo a
		{
			get
			{
				return this.m_a;
			}
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x060017EC RID: 6124 RVA: 0x000605A4 File Offset: 0x0005E7A4
		public TGrupo aPlus
		{
			get
			{
				return this.m_aPlus;
			}
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x000605AC File Offset: 0x0005E7AC
		protected sealed override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Actualizar Items"
			};
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x000605C5 File Offset: 0x0005E7C5
		protected sealed override void OnAplicar1()
		{
			this.ActualizarDatos();
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x000605D0 File Offset: 0x0005E7D0
		public void ActualizarDatos()
		{
			this.m_list = null;
			this.m_dicc = null;
			this.m_f.Set(GrupoQueCompartenValores.f);
			this.m_e.Set(GrupoQueCompartenValores.e);
			this.m_d.Set(GrupoQueCompartenValores.d);
			this.m_c.Set(GrupoQueCompartenValores.c);
			this.m_b.Set(GrupoQueCompartenValores.b);
			this.m_a.Set(GrupoQueCompartenValores.a);
			this.m_aPlus.Set(GrupoQueCompartenValores.aPlus);
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x00060668 File Offset: 0x0005E868
		private void InitDicc()
		{
			if (this.m_dicc != null && this.m_dicc.Count == ValorPorGrupoDicc<TGrupo, TValue>.cantidadDeGrupos)
			{
				return;
			}
			this.OnAplicar1();
			this.m_dicc = new DiccionaryEnum<GrupoQueCompartenValores, TGrupo>((GrupoQueCompartenValores g) => (int)g);
			this.m_dicc.Add(GrupoQueCompartenValores.f, this.f);
			this.m_dicc.Add(GrupoQueCompartenValores.e, this.e);
			this.m_dicc.Add(GrupoQueCompartenValores.d, this.d);
			this.m_dicc.Add(GrupoQueCompartenValores.c, this.c);
			this.m_dicc.Add(GrupoQueCompartenValores.b, this.b);
			this.m_dicc.Add(GrupoQueCompartenValores.a, this.a);
			this.m_dicc.Add(GrupoQueCompartenValores.aPlus, this.aPlus);
			this.m_list = new List<TGrupo>(this.m_dicc.Values);
			this.OnDiccIniciado();
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnDiccIniciado()
		{
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x0006075D File Offset: 0x0005E95D
		public ICollection<TGrupo> ObtenerGrupos()
		{
			this.InitDicc();
			return this.m_dicc.Values;
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x00060770 File Offset: 0x0005E970
		public IEnumerator<KeyValuePair<int, TGrupo>> GetEnumerator()
		{
			this.InitDicc();
			return ((IEnumerable<KeyValuePair<int, TGrupo>>)this.m_dicc).GetEnumerator();
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x00060770 File Offset: 0x0005E970
		IEnumerator IEnumerable.GetEnumerator()
		{
			this.InitDicc();
			return ((IEnumerable<KeyValuePair<int, TGrupo>>)this.m_dicc).GetEnumerator();
		}

		// Token: 0x0400122B RID: 4651
		private static int cantidadDeGrupos = typeof(GrupoQueCompartenValores).GetEnumCount() - 1;

		// Token: 0x0400122C RID: 4652
		private DiccionaryEnum<GrupoQueCompartenValores, TGrupo> m_dicc;

		// Token: 0x0400122D RID: 4653
		[NonSerialized]
		private List<TGrupo> m_list;

		// Token: 0x0400122E RID: 4654
		[SerializeField]
		private TGrupo m_f;

		// Token: 0x0400122F RID: 4655
		[SerializeField]
		private TGrupo m_e;

		// Token: 0x04001230 RID: 4656
		[SerializeField]
		private TGrupo m_d;

		// Token: 0x04001231 RID: 4657
		[SerializeField]
		private TGrupo m_c;

		// Token: 0x04001232 RID: 4658
		[SerializeField]
		private TGrupo m_b;

		// Token: 0x04001233 RID: 4659
		[SerializeField]
		private TGrupo m_a;

		// Token: 0x04001234 RID: 4660
		[SerializeField]
		private TGrupo m_aPlus;
	}
}
