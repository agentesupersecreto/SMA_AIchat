using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.TValle.BeachGirl.Estimulos
{
	// Token: 0x02000019 RID: 25
	public class DictionaryDeEstimulosTactiles : IEnumerable<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>, IEnumerable, IClearable, ICollection<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>, IReadOnlyDictionary<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>, IReadOnlyCollection<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>
	{
		// Token: 0x1700004C RID: 76
		[TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })]
		public ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> this[[TupleElementNames(new string[] { "direccion", "estimulante" })] ValueTuple<DireccionDeEstimulo, ParteQuePuedeEstimular> key]
		{
			[return: TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })]
			get
			{
				return this.m_dicc[new ValueTuple<int, int>((int)key.Item1, (int)key.Item2)];
			}
			[param: TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })]
			set
			{
				this.m_dicc[new ValueTuple<int, int>((int)key.Item1, (int)key.Item2)] = value;
			}
		}

		// Token: 0x1700004D RID: 77
		public ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> this[ValueTuple<int, int> key]
		{
			get
			{
				return this.m_dicc[key];
			}
			set
			{
				this.m_dicc[key] = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00004198 File Offset: 0x00002398
		IEnumerable<ValueTuple<int, int>> IReadOnlyDictionary<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>.Keys
		{
			get
			{
				return this.m_dicc.Keys;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000041A5 File Offset: 0x000023A5
		IEnumerable<ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> IReadOnlyDictionary<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>.Values
		{
			get
			{
				return this.m_dicc.Values;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000041B2 File Offset: 0x000023B2
		public bool ContainsKey(DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante)
		{
			return this.m_dicc.ContainsKey(new ValueTuple<int, int>((int)direccion, (int)estimulante));
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000041C6 File Offset: 0x000023C6
		public bool TryGetValue(DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] out ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> value)
		{
			return this.m_dicc.TryGetValue(new ValueTuple<int, int>((int)direccion, (int)estimulante), out value);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000041DC File Offset: 0x000023DC
		public bool Remove(DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante)
		{
			ValueTuple<int, int> valueTuple = new ValueTuple<int, int>((int)direccion, (int)estimulante);
			ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> valueTuple2;
			return this.m_dicc.TryGetValue(valueTuple, out valueTuple2) && this.m_dicc.Remove(valueTuple);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004210 File Offset: 0x00002410
		public bool ContainsKey(ValueTuple<int, int> key)
		{
			return this.m_dicc.ContainsKey(new ValueTuple<int, int>(key.Item1, key.Item2));
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000422E File Offset: 0x0000242E
		public bool TryGetValue(ValueTuple<int, int> key, out ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> value)
		{
			return this.m_dicc.TryGetValue(new ValueTuple<int, int>(key.Item1, key.Item2), out value);
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000424D File Offset: 0x0000244D
		public int Count
		{
			get
			{
				return this.m_dicc.Count;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000425A File Offset: 0x0000245A
		public bool IsReadOnly
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00004261 File Offset: 0x00002461
		public ICollection<ValueTuple<int, int>> Keys
		{
			get
			{
				return this.m_dicc.Keys;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000426E File Offset: 0x0000246E
		[TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })]
		public ICollection<ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> Values
		{
			[return: TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })]
			get
			{
				return this.m_dicc.Values;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000427B File Offset: 0x0000247B
		public void Add(KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> item)
		{
			((ICollection<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>)this.m_dicc).Add(item);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004289 File Offset: 0x00002489
		public void Add(DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> value)
		{
			this.m_dicc.Add(new ValueTuple<int, int>((int)direccion, (int)estimulante), value);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000429E File Offset: 0x0000249E
		public void Add([TupleElementNames(new string[] { "direccion", "estimulante" })] ValueTuple<int, int> key, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> value)
		{
			this.m_dicc.Add(key, value);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000042AD File Offset: 0x000024AD
		public void Clear()
		{
			this.m_dicc.Clear();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000042BA File Offset: 0x000024BA
		public bool Contains(KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> item)
		{
			return ((ICollection<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>)this.m_dicc).Contains(item);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000042C8 File Offset: 0x000024C8
		public bool Contains([TupleElementNames(new string[] { "direccion", "estimulante", "original", null, "invertido", "estimulanteInvertido" })] KeyValuePair<ValueTuple<DireccionDeEstimulo, ParteQuePuedeEstimular>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> item)
		{
			return this.m_dicc.Contains(new KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>(new ValueTuple<int, int>((int)item.Key.Item1, (int)item.Key.Item2), item.Value));
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000042FE File Offset: 0x000024FE
		public IEnumerator<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>> GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004310 File Offset: 0x00002510
		public bool Remove(KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> item)
		{
			return ((ICollection<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>)this.m_dicc).Remove(item);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000431E File Offset: 0x0000251E
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004330 File Offset: 0x00002530
		IEnumerator<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>> IEnumerable<KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>>.GetEnumerator()
		{
			return this.m_dicc.GetEnumerator();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004342 File Offset: 0x00002542
		public void CopyTo(KeyValuePair<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000075 RID: 117
		[TupleElementNames(new string[] { "direccion", "estimulante", "original", null, "invertido", "estimulanteInvertido" })]
		private Dictionary<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>> m_dicc = new Dictionary<ValueTuple<int, int>, ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>>>();
	}
}
