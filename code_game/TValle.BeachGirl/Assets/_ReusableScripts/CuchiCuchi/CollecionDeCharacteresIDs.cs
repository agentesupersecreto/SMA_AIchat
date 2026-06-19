using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000CB RID: 203
	public class CollecionDeCharacteresIDs : Singleton<CollecionDeCharacteresIDs>
	{
		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x000150CC File Offset: 0x000132CC
		public int mainID
		{
			get
			{
				return this.IdDe("MalePlayer");
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x000150DC File Offset: 0x000132DC
		protected override void InitData(bool esEditorTime)
		{
			this.m_dic = new StringKeyIntValueDictionary(StringComparer.OrdinalIgnoreCase);
			foreach (MapaDeCharacteresIDs mapaDeCharacteresIDs in this.m_extraIdsMapas)
			{
				foreach (MapaDeCharacteresIDs.Par par in mapaDeCharacteresIDs.lista)
				{
					if (this.m_dic.ContainsKey(par.nombre))
					{
						Debug.LogWarning("Character repetido (" + par.nombre + ") con id: " + par.ID.ToString(), mapaDeCharacteresIDs);
					}
					this.m_dic.Add(par.nombre, par.ID);
				}
			}
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x000151C4 File Offset: 0x000133C4
		public bool ContieneId(string nombre)
		{
			return this.m_dic.ContainsKey(nombre);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x000151D4 File Offset: 0x000133D4
		public int IdDe(string nombre)
		{
			int num;
			try
			{
				num = this.m_dic[nombre];
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return num;
		}

		// Token: 0x04000401 RID: 1025
		[SerializeField]
		[CoolArrayItem]
		private List<MapaDeCharacteresIDs> m_extraIdsMapas = new List<MapaDeCharacteresIDs>();

		// Token: 0x04000402 RID: 1026
		[SerializeField]
		private StringKeyIntValueDictionary m_dic;
	}
}
