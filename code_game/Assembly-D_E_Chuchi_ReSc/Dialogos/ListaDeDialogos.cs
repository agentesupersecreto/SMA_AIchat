using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001D1 RID: 465
	public abstract class ListaDeDialogos<T_dialogoInfo> : ListaDeDialogosBase where T_dialogoInfo : DialogoInfo, new()
	{
		// Token: 0x06000B08 RID: 2824 RVA: 0x000327E0 File Offset: 0x000309E0
		public static T_ListaDeDialogosResult UnificarDialogoInfo<T_ListaDeDialogosResult, T_ListaDeDialogos, T_DialogoInfo>(IReadOnlyList<T_DialogoInfo> dialogos) where T_ListaDeDialogosResult : ListaDeDialogos<DialogoInfo> where T_ListaDeDialogos : ListaDeDialogos<T_DialogoInfo> where T_DialogoInfo : DialogoInfo, new()
		{
			T_ListaDeDialogosResult t_ListaDeDialogosResult2;
			try
			{
				T_ListaDeDialogosResult t_ListaDeDialogosResult = ScriptableObject.CreateInstance<T_ListaDeDialogosResult>();
				List<T_DialogoInfo> list = new List<T_DialogoInfo>(dialogos.Count);
				foreach (T_DialogoInfo t_DialogoInfo in dialogos)
				{
					T_DialogoInfo t_DialogoInfo2 = t_DialogoInfo.CloneNoInicializado<T_DialogoInfo>();
					list.Add(t_DialogoInfo2);
				}
				t_ListaDeDialogosResult.m_items = new List<DialogoInfo>(list);
				t_ListaDeDialogosResult.CheckInit();
				t_ListaDeDialogosResult2 = t_ListaDeDialogosResult;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Erro ahead: " + ex.Message);
				throw ex;
			}
			return t_ListaDeDialogosResult2;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00032890 File Offset: 0x00030A90
		public static T_ListaDeDialogosResult UnificarMapasDeDialogoInfo<T_ListaDeDialogosResult, T_ListaDeDialogos, T_DialogoInfo>(IReadOnlyList<T_ListaDeDialogos> mapasDeDialogos) where T_ListaDeDialogosResult : ListaDeDialogos<DialogoInfo> where T_ListaDeDialogos : ListaDeDialogos<T_DialogoInfo> where T_DialogoInfo : DialogoInfo, new()
		{
			T_ListaDeDialogosResult t_ListaDeDialogosResult2;
			try
			{
				T_ListaDeDialogosResult t_ListaDeDialogosResult = ScriptableObject.CreateInstance<T_ListaDeDialogosResult>();
				List<T_DialogoInfo> list = new List<T_DialogoInfo>();
				foreach (T_ListaDeDialogos t_ListaDeDialogos in mapasDeDialogos)
				{
					if (t_ListaDeDialogos.Count != 0)
					{
						foreach (DialogoInfo dialogoInfo in t_ListaDeDialogos.dialogosInfoBase)
						{
							T_DialogoInfo t_DialogoInfo = dialogoInfo.CloneNoInicializado<T_DialogoInfo>();
							list.Add(t_DialogoInfo);
						}
					}
				}
				t_ListaDeDialogosResult.m_items = new List<DialogoInfo>(list);
				t_ListaDeDialogosResult.CheckInit();
				t_ListaDeDialogosResult2 = t_ListaDeDialogosResult;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Erro ahead: " + ex.Message);
				throw ex;
			}
			return t_ListaDeDialogosResult2;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00032984 File Offset: 0x00030B84
		public void Add(IReadOnlyList<T_dialogoInfo> dialogos, bool insert)
		{
			try
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				List<T_dialogoInfo> list;
				if (this.m_items != null)
				{
					list = new List<T_dialogoInfo>(this.m_items);
				}
				else
				{
					list = new List<T_dialogoInfo>();
				}
				foreach (T_dialogoInfo t_dialogoInfo in dialogos)
				{
					T_dialogoInfo t_dialogoInfo2 = t_dialogoInfo.CloneNoInicializado<T_dialogoInfo>();
					if (!insert)
					{
						list.Add(t_dialogoInfo2);
					}
					else
					{
						list.Insert(0, t_dialogoInfo2);
					}
				}
				this.m_items = new List<T_dialogoInfo>(list);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Erro ahead: " + ex.Message, this);
				throw ex;
			}
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00032A40 File Offset: 0x00030C40
		public void Add(IReadOnlyList<ListaDeDialogos<T_dialogoInfo>> mapasDeDialogos, bool insert)
		{
			try
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				List<T_dialogoInfo> list;
				if (this.m_items != null)
				{
					list = new List<T_dialogoInfo>(this.m_items);
				}
				else
				{
					list = new List<T_dialogoInfo>();
				}
				foreach (ListaDeDialogos<T_dialogoInfo> listaDeDialogos in mapasDeDialogos)
				{
					if (listaDeDialogos.Count != 0)
					{
						foreach (DialogoInfo dialogoInfo in listaDeDialogos.dialogosInfoBase)
						{
							T_dialogoInfo t_dialogoInfo = dialogoInfo.CloneNoInicializado<T_dialogoInfo>();
							if (!insert)
							{
								list.Add(t_dialogoInfo);
							}
							else
							{
								list.Insert(0, t_dialogoInfo);
							}
						}
					}
				}
				this.m_items = new List<T_dialogoInfo>(list);
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Erro ahead: " + ex.Message, this);
				throw ex;
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00032B3C File Offset: 0x00030D3C
		public void Add(ListaDeDialogos<T_dialogoInfo> mapa, bool insert)
		{
			try
			{
				if (this.m_init)
				{
					throw new InvalidOperationException();
				}
				if (mapa.Count != 0)
				{
					List<T_dialogoInfo> list;
					if (this.m_items != null)
					{
						list = new List<T_dialogoInfo>(this.m_items);
					}
					else
					{
						list = new List<T_dialogoInfo>();
					}
					foreach (DialogoInfo dialogoInfo in mapa.dialogosInfoBase)
					{
						T_dialogoInfo t_dialogoInfo = dialogoInfo.CloneNoInicializado<T_dialogoInfo>();
						if (!insert)
						{
							list.Add(t_dialogoInfo);
						}
						else
						{
							list.Insert(0, t_dialogoInfo);
						}
					}
					this.m_items = new List<T_dialogoInfo>(list);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Erro ahead: " + ex.Message, this);
				throw ex;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x00032C08 File Offset: 0x00030E08
		public IReadOnlyList<T_dialogoInfo> dialogosInfo
		{
			get
			{
				return this.m_items;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x00032C08 File Offset: 0x00030E08
		public override IReadOnlyList<DialogoInfo> dialogosInfoBase
		{
			get
			{
				return this.m_items;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000B0F RID: 2831 RVA: 0x00032C10 File Offset: 0x00030E10
		public override int Count
		{
			get
			{
				return this.m_items.Count;
			}
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00032C1D File Offset: 0x00030E1D
		public virtual bool IsValid()
		{
			this.CheckInit();
			return this.Count > 0;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00032C30 File Offset: 0x00030E30
		[Obsolete]
		public static T_dialogoInfo ObtenerDeVarios<T_Holder>(IList<T_Holder> holders, DialogoInfo last = null) where T_Holder : ListaDeDialogos<T_dialogoInfo>
		{
			T_dialogoInfo t_dialogoInfo;
			try
			{
				if (holders == null || holders.Count == 0)
				{
					t_dialogoInfo = default(T_dialogoInfo);
					t_dialogoInfo = t_dialogoInfo;
				}
				else
				{
					for (int i = 0; i < holders.Count; i++)
					{
						T_dialogoInfo t_dialogoInfo2 = holders[i].Obtener(last);
						if (t_dialogoInfo2 != null && t_dialogoInfo2 != last)
						{
							ListaDeDialogos<T_dialogoInfo>.TEMP_encontrados.Add(t_dialogoInfo2);
						}
					}
					if (ListaDeDialogos<T_dialogoInfo>.TEMP_encontrados.Count == 0)
					{
						t_dialogoInfo = default(T_dialogoInfo);
					}
					else
					{
						int num = Random.Range(0, ListaDeDialogos<T_dialogoInfo>.TEMP_encontrados.Count);
						t_dialogoInfo = ListaDeDialogos<T_dialogoInfo>.TEMP_encontrados[num];
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				ListaDeDialogos<T_dialogoInfo>.TEMP_encontrados.Clear();
			}
			return t_dialogoInfo;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00032CFC File Offset: 0x00030EFC
		public override DialogoInfo ObtenerDialogo()
		{
			return this.Obtener(null);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00032D0A File Offset: 0x00030F0A
		public override DialogoInfo ObtenerDialogo(DialogoInfo last)
		{
			return this.Obtener(last);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00032D18 File Offset: 0x00030F18
		public T_dialogoInfo ObtenerPrimero()
		{
			T_dialogoInfo t_dialogoInfo;
			try
			{
				this.CheckInit();
				if (this.m_items.Count == 0)
				{
					t_dialogoInfo = default(T_dialogoInfo);
					t_dialogoInfo = t_dialogoInfo;
				}
				else
				{
					t_dialogoInfo = this.m_items[0];
				}
			}
			catch (Exception)
			{
				throw;
			}
			return t_dialogoInfo;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00032D68 File Offset: 0x00030F68
		public T_dialogoInfo Obtener(DialogoInfo last = null)
		{
			T_dialogoInfo t_dialogoInfo;
			try
			{
				this.CheckInit();
				if (this.m_items.Count == 0)
				{
					t_dialogoInfo = default(T_dialogoInfo);
					t_dialogoInfo = t_dialogoInfo;
				}
				else if (this.m_items.Count == 1)
				{
					t_dialogoInfo = this.m_items[0];
				}
				else if (last == null || !this.m_itemsSet.Contains(last))
				{
					T_dialogoInfo t_dialogoInfo2 = ListaDeDialogos<T_dialogoInfo>.InRange(Random.value, true, true, this.m_items);
					if (t_dialogoInfo2 == null)
					{
						throw new ArgumentNullException("result", "result null reference.");
					}
					t_dialogoInfo = t_dialogoInfo2;
				}
				else if (this.m_items.Count == 2)
				{
					if (last.index == 0)
					{
						t_dialogoInfo = this.m_items[last.index + 1];
					}
					else
					{
						t_dialogoInfo = this.m_items[last.index - 1];
					}
				}
				else
				{
					T_dialogoInfo t_dialogoInfo3 = default(T_dialogoInfo);
					float chanceRangeInferior = last.chanceRangeInferior;
					float num = 1f - last.chanceRangeSuperior;
					float num2 = chanceRangeInferior + num;
					if ((chanceRangeInferior / num2).ProcMod(1f))
					{
						t_dialogoInfo3 = ListaDeDialogos<T_dialogoInfo>.InRange(Random.Range(0f, last.chanceRangeInferior), true, false, this.m_items);
						if (t_dialogoInfo3 != null && t_dialogoInfo3 != last)
						{
							return t_dialogoInfo3;
						}
					}
					else
					{
						t_dialogoInfo3 = ListaDeDialogos<T_dialogoInfo>.InRange(Random.Range(last.chanceRangeSuperior, 1f), false, true, this.m_items);
						if (t_dialogoInfo3 != null && t_dialogoInfo3 != last)
						{
							return t_dialogoInfo3;
						}
					}
					if (last.index == 0)
					{
						t_dialogoInfo = this.m_items[last.index + 1];
					}
					else
					{
						t_dialogoInfo = this.m_items[last.index - 1];
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			return t_dialogoInfo;
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00032F28 File Offset: 0x00031128
		private static T_dialogoInfo InRange(float range, bool inferiorInclusive, bool superiorInclusive, IList<T_dialogoInfo> dialogos)
		{
			for (int i = 0; i < dialogos.Count; i++)
			{
				T_dialogoInfo t_dialogoInfo = dialogos[i];
				bool flag = (inferiorInclusive && range >= t_dialogoInfo.chanceRangeInferior) || (!inferiorInclusive && range > t_dialogoInfo.chanceRangeInferior);
				bool flag2 = (superiorInclusive && range <= t_dialogoInfo.chanceRangeSuperior) || (!superiorInclusive && range < t_dialogoInfo.chanceRangeSuperior);
				if (flag && flag2)
				{
					return t_dialogoInfo;
				}
			}
			return default(T_dialogoInfo);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x00032FB0 File Offset: 0x000311B0
		protected void CheckInit()
		{
			try
			{
				if (!this.m_init)
				{
					this.OnInitiating();
					if (Application.isPlaying)
					{
						this.m_init = true;
					}
					float num = 0f;
					for (int i = 0; i < this.m_items.Count; i++)
					{
						this.m_items[i].FixChance();
						this.m_items[i].FixText();
						num += this.m_items[i].chance;
					}
					List<DialogoInfo> list = new List<DialogoInfo>(this.m_items.Count);
					for (int j = 0; j < this.m_items.Count; j++)
					{
						T_dialogoInfo t_dialogoInfo = this.m_items[j];
						t_dialogoInfo.Init(num, j, list);
						list.Add(t_dialogoInfo);
					}
					this.m_itemsSet = new HashSet<T_dialogoInfo>(this.m_items);
					this.OnInitiated();
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Erro ahead: " + ex.Message);
				throw ex;
			}
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnInitiating()
		{
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnInitiated()
		{
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x000330D4 File Offset: 0x000312D4
		protected sealed override void AddDialogoInfo(string text)
		{
			if (Application.isPlaying)
			{
				throw new InvalidOperationException();
			}
			string text2 = text.Trim();
			if (string.IsNullOrEmpty(text2))
			{
				return;
			}
			char c = text2[text2.Length - 1];
			if (c != '.' && char.IsLetterOrDigit(c))
			{
				text2 += ".";
			}
			T_dialogoInfo t_dialogoInfo = new T_dialogoInfo();
			t_dialogoInfo.text = text2;
			if (this.m_items == null)
			{
				this.m_items = new List<T_dialogoInfo>();
			}
			this.m_items.Add(t_dialogoInfo);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x00033157 File Offset: 0x00031357
		public sealed override void ReordenarSegunChance()
		{
			this.m_items.Sort((T_dialogoInfo x, T_dialogoInfo y) => y.chance.CompareTo(x.chance));
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00033184 File Offset: 0x00031384
		public sealed override void AutoGenerar(string auto)
		{
			auto = auto.Trim();
			if (string.IsNullOrEmpty(auto))
			{
				return;
			}
			foreach (string text in auto.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
			{
				this.AddDialogoInfo(text);
			}
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x000331DC File Offset: 0x000313DC
		public sealed override void RemoverRepetidos()
		{
			IEnumerable<T_dialogoInfo> enumerable = from x in this.m_items
				group x by x.text into x
				select x.First<T_dialogoInfo>();
			this.m_items = enumerable.ToList<T_dialogoInfo>();
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00033244 File Offset: 0x00031444
		public sealed override void RemoverVacios()
		{
			foreach (T_dialogoInfo t_dialogoInfo in this.m_items)
			{
				t_dialogoInfo.text = t_dialogoInfo.text.Trim();
			}
			IEnumerable<T_dialogoInfo> enumerable = this.m_items.Where((T_dialogoInfo l) => !string.IsNullOrEmpty(l.text));
			this.m_items = enumerable.ToList<T_dialogoInfo>();
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000332E4 File Offset: 0x000314E4
		public sealed override string InvertAutoGenerar()
		{
			string text = string.Empty;
			foreach (T_dialogoInfo t_dialogoInfo in this.m_items)
			{
				text += t_dialogoInfo.text;
				text += "\n";
			}
			return text;
		}

		// Token: 0x04000908 RID: 2312
		[SerializeField]
		protected List<T_dialogoInfo> m_items;

		// Token: 0x04000909 RID: 2313
		private HashSet<T_dialogoInfo> m_itemsSet;

		// Token: 0x0400090A RID: 2314
		[NonSerialized]
		protected bool m_init;

		// Token: 0x0400090B RID: 2315
		[Obsolete]
		private static List<T_dialogoInfo> TEMP_encontrados = new List<T_dialogoInfo>();
	}
}
