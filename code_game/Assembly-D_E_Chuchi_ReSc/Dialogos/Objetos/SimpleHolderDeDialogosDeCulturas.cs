using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos
{
	// Token: 0x020001E0 RID: 480
	public abstract class SimpleHolderDeDialogosDeCulturas<T_dialogos, T_dialogoInfo> : SimpleHolderDeDialogos where T_dialogos : ListaDeDialogos<T_dialogoInfo> where T_dialogoInfo : DialogoInfo, new()
	{
		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000B78 RID: 2936 RVA: 0x00034113 File Offset: 0x00032313
		public override float modDeScore
		{
			get
			{
				return this.m_modDeScore;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x0003411B File Offset: 0x0003231B
		public override int cantidadDeListasDeDialogos
		{
			get
			{
				return this.m_items.Count;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x00034128 File Offset: 0x00032328
		public override int cantidadDeDialogosInfo
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.m_items.Count; i++)
				{
					num += this.m_items[i].Count;
				}
				return num;
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x00034168 File Offset: 0x00032368
		public override bool IsValid()
		{
			this.CheckInit();
			using (List<T_dialogos>.Enumerator enumerator = this.m_items.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsValid())
					{
						return false;
					}
				}
			}
			return this.cantidadDeListasDeDialogos > 0;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x000341D4 File Offset: 0x000323D4
		public override DialogoInfo ObtenerDialogo()
		{
			return this.Obtener(null, null);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x000341F6 File Offset: 0x000323F6
		public override DialogoInfo ObtenerDialogo(Localizacion localizacion, DialogoInfo last)
		{
			return this.Obtener(new Localizacion?(localizacion), last);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0003420C File Offset: 0x0003240C
		public T_dialogoInfo Obtener(Localizacion? localizacion = null, DialogoInfo last = null)
		{
			this.CheckInit();
			if (localizacion == null)
			{
				localizacion = new Localizacion?(Localizacion.US);
			}
			ListaDeDialogos listaDeDialogos;
			if (!this.m_diccDeCulturas2.TryGetValue(localizacion.Value, out listaDeDialogos))
			{
				return default(T_dialogoInfo);
			}
			return listaDeDialogos.Obtener(last) as T_dialogoInfo;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00034264 File Offset: 0x00032464
		protected override void OnDeshabilitado()
		{
			if (!this.m_init)
			{
				return;
			}
			foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair in this.m_diccDeCulturas2)
			{
				if (keyValuePair.Value != null)
				{
					Object.Destroy(keyValuePair.Value);
				}
			}
			this.m_diccDeCulturas2 = null;
			this.m_init = false;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x000342DC File Offset: 0x000324DC
		private void CheckInit()
		{
			if (!this.m_init)
			{
				if (Application.isPlaying)
				{
					this.m_init = true;
				}
				DiccionaryEnum<Localizacion, List<T_dialogos>> diccionaryEnum = new DiccionaryEnum<Localizacion, List<T_dialogos>>((Localizacion x) => (int)x);
				ICollection enumValoresObject = typeof(Localizacion).GetEnumValoresObject();
				foreach (T_dialogos t_dialogos in this.m_items)
				{
					ICollecionDeDialogoInfoLocalizados collecionDeDialogoInfoLocalizados = t_dialogos as ICollecionDeDialogoInfoLocalizados;
					if (collecionDeDialogoInfoLocalizados.paraCulturas == Localizacion.None)
					{
						Debug.LogWarning("mapa de dialogos no es para ninguna cultura.", t_dialogos);
					}
					else if (collecionDeDialogoInfoLocalizados != null)
					{
						foreach (object obj in enumValoresObject)
						{
							Localizacion localizacion = (Localizacion)obj;
							if (collecionDeDialogoInfoLocalizados.ParaCultura(localizacion))
							{
								List<T_dialogos> list;
								if (diccionaryEnum.TryGetValue(localizacion, out list))
								{
									list.Add(t_dialogos);
								}
								else
								{
									diccionaryEnum.Add(localizacion, new List<T_dialogos> { t_dialogos });
								}
							}
						}
					}
				}
				this.m_diccDeCulturas2 = new DiccionaryEnum<Localizacion, ListaDeDialogos>((Localizacion x) => (int)x);
				foreach (KeyValuePair<int, List<T_dialogos>> keyValuePair in diccionaryEnum)
				{
					ListaDeDialogos listaDeDialogos = ListaDeDialogos<DialogoInfo>.UnificarMapasDeDialogoInfo<ListaDeDialogos, T_dialogos, T_dialogoInfo>(keyValuePair.Value);
					Localizacion key = (Localizacion)keyValuePair.Key;
					this.m_diccDeCulturas2.Add(key, listaDeDialogos);
				}
			}
		}

		// Token: 0x04000937 RID: 2359
		[SerializeField]
		private float m_modDeScore = 1f;

		// Token: 0x04000938 RID: 2360
		[SerializeField]
		[CoolArrayItem]
		private List<T_dialogos> m_items;

		// Token: 0x04000939 RID: 2361
		[NonSerialized]
		private bool m_init;

		// Token: 0x0400093A RID: 2362
		private DiccionaryEnum<Localizacion, ListaDeDialogos> m_diccDeCulturas2;
	}
}
