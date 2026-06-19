using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002B5 RID: 693
	[ProveedorEfectosIds("ids")]
	public sealed class EfectosManager : Singleton<EfectosManager>
	{
		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x060011D0 RID: 4560 RVA: 0x00054353 File Offset: 0x00052553
		public static ICollection<string> ids
		{
			get
			{
				return Singleton<EfectosManager>.instance.m_dicDeEfectos.Keys;
			}
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x00054364 File Offset: 0x00052564
		protected override void InitData(bool esEditorTime)
		{
			base.InitData(esEditorTime);
			this.m_dicDeEfectos.Clear();
			for (int i = 0; i < this.m_efectos.Count; i++)
			{
				Efecto efecto = this.m_efectos[i];
				this.m_dicDeEfectos.Add(efecto.id, efecto);
			}
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x000543B8 File Offset: 0x000525B8
		public Efecto GetEfecto(string id)
		{
			Efecto efecto;
			if (this.m_dicDeEfectos.TryGetValue(id, out efecto))
			{
				return efecto;
			}
			Debug.LogError("No se encontro instancia para efeto: " + id);
			return null;
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x000543E8 File Offset: 0x000525E8
		public void ReCacheEfectos()
		{
			if (!Application.isEditor)
			{
				Debug.LogWarning("No es recomendable llamar esta funcion en build", this);
			}
			this.m_efectos.Clear();
			Type[] allDerivedTypes = EfectosManager.GetAllDerivedTypes(AppDomain.CurrentDomain, typeof(Efecto));
			for (int i = 0; i < allDerivedTypes.Length; i++)
			{
				object obj = Activator.CreateInstance(allDerivedTypes[i]);
				this.m_efectos.Add((Efecto)obj);
			}
			StringSelectorV2Attribute.flagClearCache = true;
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x00054458 File Offset: 0x00052658
		private static Type[] GetAllDerivedTypes(AppDomain aAppDomain, Type aType)
		{
			List<Type> list = new List<Type>();
			Assembly[] assemblies = aAppDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				foreach (Type type in assemblies[i].GetTypes())
				{
					if (!type.IsAbstract && type.IsSubclassOf(aType))
					{
						list.Add(type);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x000544C2 File Offset: 0x000526C2
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.ReCacheEfectos();
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x0005431C File Offset: 0x0005251C
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Refresh Cache De Efectos",
				playTimeVisible = false
			};
		}

		// Token: 0x04000D0C RID: 3340
		[SerializeReference]
		private List<Efecto> m_efectos = new List<Efecto>();

		// Token: 0x04000D0D RID: 3341
		private Dictionary<string, Efecto> m_dicDeEfectos = new Dictionary<string, Efecto>();
	}
}
