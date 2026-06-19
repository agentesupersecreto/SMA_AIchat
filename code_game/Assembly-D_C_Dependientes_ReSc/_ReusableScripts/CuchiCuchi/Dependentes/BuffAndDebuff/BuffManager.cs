using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002BD RID: 701
	[ProveedorBuffIds("ids")]
	public sealed class BuffManager : Singleton<BuffManager>
	{
		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06001209 RID: 4617 RVA: 0x00054F23 File Offset: 0x00053123
		public static ICollection<string> ids
		{
			get
			{
				return Singleton<BuffManager>.instance.m_dicDeBuff.Keys;
			}
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x00054F34 File Offset: 0x00053134
		protected override void InitData(bool esEditorTime)
		{
			base.InitData(esEditorTime);
			this.m_dicDeBuff.Clear();
			for (int i = 0; i < this.m_buff.Count; i++)
			{
				BuffMap buffMap = this.m_buff[i];
				this.m_dicDeBuff.Add(buffMap.id, buffMap);
			}
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x00054F88 File Offset: 0x00053188
		public BuffMap GetMap(string id)
		{
			BuffMap buffMap2;
			try
			{
				BuffMap buffMap;
				if (this.m_dicDeBuff.TryGetValue(id, out buffMap))
				{
					buffMap2 = buffMap;
				}
				else
				{
					Debug.LogError("No se encontro mapa para buff: " + id);
					buffMap2 = null;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return buffMap2;
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x00054FD0 File Offset: 0x000531D0
		public void ReCacheBuff()
		{
			if (!Application.isEditor)
			{
				Debug.LogError("No es puede llamar esta funcion en build", this);
				return;
			}
			StringSelectorV2Attribute.flagClearCache = true;
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x00054FEB File Offset: 0x000531EB
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.ReCacheBuff();
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x00054FF9 File Offset: 0x000531F9
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Refresh Cache De Buff",
				playTimeVisible = false
			};
		}

		// Token: 0x04000D25 RID: 3365
		[SerializeField]
		private List<BuffMap> m_buff = new List<BuffMap>();

		// Token: 0x04000D26 RID: 3366
		private Dictionary<string, BuffMap> m_dicDeBuff = new Dictionary<string, BuffMap>();
	}
}
