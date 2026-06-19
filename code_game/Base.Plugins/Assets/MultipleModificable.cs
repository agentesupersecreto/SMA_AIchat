using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000FA RID: 250
	public abstract class MultipleModificable<T_Mod, T_Val> : IModificable<T_Mod, T_Val>, IModificable, ISerializationCallbackReceiver where T_Mod : class, IValuable<T_Val> where T_Val : struct, IValorModificable<T_Val>
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x00018C34 File Offset: 0x00016E34
		public void OnBeforeSerialize()
		{
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00018C36 File Offset: 0x00016E36
		public void OnAfterDeserialize()
		{
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00018C38 File Offset: 0x00016E38
		public int Count
		{
			get
			{
				return this.m_mods.Count;
			}
		}

		// Token: 0x1700012E RID: 302
		protected T_Mod this[int i]
		{
			get
			{
				return this.m_mods[i];
			}
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00018C54 File Offset: 0x00016E54
		public void SetAllTo(T_Val val)
		{
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				this.m_mods[i].valor = val;
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00018C90 File Offset: 0x00016E90
		public bool TryAddModificador(T_Mod mod)
		{
			if (mod == null)
			{
				return false;
			}
			ISingleOwnerValuable<T_Val> singleOwnerValuable = mod as ISingleOwnerValuable<T_Val>;
			if (singleOwnerValuable != null && singleOwnerValuable.owner != this)
			{
				Debug.LogError("no se puede añadir un modificador de un solo owner");
				return false;
			}
			if (this.m_modificadores.ContainsKey(mod.id))
			{
				return false;
			}
			this.m_modificadores.Add(mod.id, mod);
			this.m_mods.Add(mod);
			return true;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00018D0C File Offset: 0x00016F0C
		public T_Mod AddModificador(string id)
		{
			T_Mod t_Mod;
			try
			{
				t_Mod = this.AddModificador(id.GetHashCode());
			}
			catch (Exception)
			{
				throw;
			}
			return t_Mod;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00018D3C File Offset: 0x00016F3C
		public bool Contiene(T_Mod mod)
		{
			if (mod == null)
			{
				return false;
			}
			ISingleOwnerValuable<T_Val> singleOwnerValuable = mod as ISingleOwnerValuable<T_Val>;
			if (singleOwnerValuable != null && singleOwnerValuable.owner != this)
			{
				Debug.LogError("modificador de un solo owner no pertenece a este modificable");
				this.TryRemoverModificador(mod);
				return false;
			}
			return this.m_modificadores.ContainsKey(mod.id);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00018D95 File Offset: 0x00016F95
		public bool Contiene(object mod)
		{
			return this.Contiene(mod as T_Mod);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00018DA8 File Offset: 0x00016FA8
		public bool TryRemoverModificador(T_Mod mod)
		{
			if (mod == null)
			{
				return false;
			}
			if (!this.m_modificadores.Remove(mod.id))
			{
				return false;
			}
			this.m_mods.Remove(mod);
			return true;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00018DDC File Offset: 0x00016FDC
		public bool TryRemoverModificadorAndSetNull(ref T_Mod mod)
		{
			if (this.TryRemoverModificador(mod))
			{
				mod = default(T_Mod);
				return true;
			}
			return false;
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00018DF6 File Offset: 0x00016FF6
		public bool TryRemoverModificador(object mod)
		{
			return this.TryRemoverModificador(mod as T_Mod);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00018E09 File Offset: 0x00017009
		public bool TryLoadModificador(object mod)
		{
			return this.TryAddModificador(mod as T_Mod);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00018E1C File Offset: 0x0001701C
		public T_Mod AddModificador(int id)
		{
			T_Mod t_Mod2;
			try
			{
				T_Mod t_Mod;
				if (this.m_modificadores.TryGetValue(id, out t_Mod))
				{
					t_Mod2 = t_Mod;
				}
				else
				{
					t_Mod = this.InstanciarModificador(id);
					this.m_modificadores.Add(id, t_Mod);
					this.m_mods.Add(t_Mod);
					t_Mod2 = t_Mod;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return t_Mod2;
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00018E78 File Offset: 0x00017078
		public void ModificarValor(ref T_Val valor)
		{
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Modificar(ref valor2);
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00018EC0 File Offset: 0x000170C0
		public void MaximoValorIncluyendo(ref T_Val valor)
		{
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Max(ref valor2);
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00018F08 File Offset: 0x00017108
		public T_Val? TryAdicionarValorIncluyendo()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			T_Val t_Val = default(T_Val);
			this.AdicionarValorIncluyendo(ref t_Val);
			return new T_Val?(t_Val);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00018F44 File Offset: 0x00017144
		public void AdicionarValorIncluyendo(ref T_Val valor)
		{
			if (this.m_mods.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Adicionar(ref valor2);
			}
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00018F9A File Offset: 0x0001719A
		public void PromediarConValor(ref T_Val valor)
		{
			if (this.m_mods.Count == 0)
			{
				return;
			}
			this.AdicionarValorIncluyendo(ref valor);
			valor.DividorPor((float)(this.m_mods.Count + 1));
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00018FCC File Offset: 0x000171CC
		public void PromediarNormalizadoConValor(ref T_Val valor)
		{
			if (this.m_mods.Count == 0)
			{
				return;
			}
			T_Val t_Val = valor;
			T_Val t_Val2 = valor;
			this.AdicionarValorIncluyendo(ref t_Val2);
			T_Val t_Val3 = default(T_Val);
			for (int i = -1; i < this.m_mods.Count; i++)
			{
				T_Val t_Val4;
				if (i < 0)
				{
					t_Val4 = t_Val;
				}
				else
				{
					t_Val4 = this.m_mods[i].valor;
				}
				T_Val t_Val5 = t_Val4;
				t_Val5.DividorPor(ref t_Val2);
				t_Val4.Modificar(ref t_Val5);
				t_Val3.Adicionar(ref t_Val4);
			}
			valor = t_Val3;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00019074 File Offset: 0x00017274
		public void PromediarSinValor(out T_Val result)
		{
			result = default(T_Val);
			if (this.m_mods.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor = this.m_mods[i].valor;
				result.Adicionar(ref valor);
			}
			result.DividorPor((float)this.m_mods.Count);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000190EC File Offset: 0x000172EC
		public void MinimoValorIncluyendo(ref T_Val valor)
		{
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Min(ref valor2);
			}
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00019134 File Offset: 0x00017334
		public void MaximoValorAbsolutoIncluyendo(ref T_Val valor)
		{
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.MaxAbs(ref valor2);
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0001917C File Offset: 0x0001737C
		public T_Mod ObtenerModificadorNotNull(int id)
		{
			T_Mod t_Mod;
			if (this.m_modificadores.TryGetValue(id, out t_Mod))
			{
				return t_Mod;
			}
			t_Mod = this.AddModificador(id);
			return t_Mod;
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000191A8 File Offset: 0x000173A8
		public T_Mod ObtenerModificadorNotNull(string id)
		{
			int hashCode = id.GetHashCode();
			T_Mod t_Mod;
			if (this.m_modificadores.TryGetValue(hashCode, out t_Mod))
			{
				return t_Mod;
			}
			t_Mod = this.AddModificador(hashCode);
			return t_Mod;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000191D8 File Offset: 0x000173D8
		public T_Mod ObtenerModificadorNotNull(Object ObjID)
		{
			int instanceID = ObjID.GetInstanceID();
			T_Mod t_Mod;
			if (this.m_modificadores.TryGetValue(instanceID, out t_Mod))
			{
				return t_Mod;
			}
			t_Mod = this.AddModificador(instanceID);
			return t_Mod;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00019208 File Offset: 0x00017408
		public void LoadModificador(ref T_Mod mod, Object ObjID)
		{
			if (mod == null)
			{
				mod = this.ObtenerModificadorNotNull(ObjID);
				return;
			}
			if (this.m_modificadores.ContainsKey(mod.id))
			{
				return;
			}
			ISingleOwnerValuable<T_Val> singleOwnerValuable = mod as ISingleOwnerValuable<T_Val>;
			if (singleOwnerValuable != null && singleOwnerValuable.owner != this)
			{
				Debug.LogError("no se puede añadir un modificador de otro owner", ObjID);
				return;
			}
			this.m_modificadores.Add(mod.id, mod);
			this.m_mods.Add(mod);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x000192A1 File Offset: 0x000174A1
		public bool TryRemoverModificador(string id)
		{
			return this.RemoverModificador(id.GetHashCode());
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000192AF File Offset: 0x000174AF
		public void RemoverModificador(string id)
		{
			this.RemoverModificador(id.GetHashCode());
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000192C0 File Offset: 0x000174C0
		public bool RemoverModificador(int id)
		{
			T_Mod t_Mod;
			if (this.m_modificadores.TryGetValue(id, out t_Mod))
			{
				bool flag = this.m_modificadores.Remove(id);
				bool flag2 = this.m_mods.Remove(t_Mod);
				return flag || flag2;
			}
			return false;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000192FC File Offset: 0x000174FC
		public void RemoverModificador(Object ObjID)
		{
			int instanceID = ObjID.GetInstanceID();
			T_Mod t_Mod;
			if (this.m_modificadores.TryGetValue(instanceID, out t_Mod))
			{
				this.m_modificadores.Remove(instanceID);
				this.m_mods.Remove(t_Mod);
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0001933A File Offset: 0x0001753A
		public void RemoverModificador(T_Mod mod)
		{
			if (this.m_modificadores.Remove(mod.id))
			{
				this.m_mods.Remove(mod);
			}
		}

		// Token: 0x06000711 RID: 1809
		protected abstract T_Mod InstanciarModificador(int id);

		// Token: 0x06000712 RID: 1810 RVA: 0x00019364 File Offset: 0x00017564
		public T_Val? TryObtenerMaximoValor()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			T_Val valor = this.m_mods[0].valor;
			if (this.m_mods.Count == 1)
			{
				return new T_Val?(valor);
			}
			for (int i = 1; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Max(ref valor2);
			}
			return new T_Val?(valor);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000193F8 File Offset: 0x000175F8
		public T_Val? TryObtenerMinimoValor()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			T_Val valor = this.m_mods[0].valor;
			if (this.m_mods.Count == 1)
			{
				return new T_Val?(valor);
			}
			for (int i = 1; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Min(ref valor2);
			}
			return new T_Val?(valor);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0001948C File Offset: 0x0001768C
		public T_Val? TryObtenerMaximoValorAbsoluto()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			T_Val valor = this.m_mods[0].valor;
			if (this.m_mods.Count == 1)
			{
				return new T_Val?(valor);
			}
			for (int i = 1; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.MaxAbs(ref valor2);
			}
			return new T_Val?(valor);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00019520 File Offset: 0x00017720
		public T_Val? TryObtenerModificador()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			T_Val valor = this.m_mods[0].valor;
			if (this.m_mods.Count == 1)
			{
				return new T_Val?(valor);
			}
			for (int i = 1; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Modificar(ref valor2);
			}
			return new T_Val?(valor);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x000195B4 File Offset: 0x000177B4
		public T_Val? TryObtenerPromedio()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			T_Val valor = this.m_mods[0].valor;
			if (this.m_mods.Count == 1)
			{
				return new T_Val?(valor);
			}
			for (int i = 1; i < this.m_mods.Count; i++)
			{
				T_Val valor2 = this.m_mods[i].valor;
				valor.Adicionar(ref valor2);
			}
			valor.DividorPor((float)this.m_mods.Count);
			return new T_Val?(valor);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00019660 File Offset: 0x00017860
		public T_Val? TryObtenerPromedioNormalizado()
		{
			if (this.m_mods.Count == 0)
			{
				return null;
			}
			if (this.m_mods.Count == 1)
			{
				return new T_Val?(this.m_mods[0].valor);
			}
			T_Val t_Val = default(T_Val);
			this.AdicionarValorIncluyendo(ref t_Val);
			T_Val t_Val2 = default(T_Val);
			for (int i = 0; i < this.m_mods.Count; i++)
			{
				T_Val valor = this.m_mods[i].valor;
				T_Val t_Val3 = valor;
				t_Val3.DividorPor(ref t_Val);
				valor.Modificar(ref t_Val3);
				t_Val2.Adicionar(ref valor);
			}
			return new T_Val?(t_Val2);
		}

		// Token: 0x040001F3 RID: 499
		private int m_lastCount;

		// Token: 0x040001F4 RID: 500
		private readonly Dictionary<int, T_Mod> m_modificadores = new Dictionary<int, T_Mod>();

		// Token: 0x040001F5 RID: 501
		[SerializeField]
		private List<T_Mod> m_mods = new List<T_Mod>();
	}
}
