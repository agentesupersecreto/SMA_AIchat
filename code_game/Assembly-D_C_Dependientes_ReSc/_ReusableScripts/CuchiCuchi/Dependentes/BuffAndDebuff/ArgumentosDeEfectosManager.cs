using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002B4 RID: 692
	[ProveedorArgumentoDeEfectosIds("ids")]
	public sealed class ArgumentosDeEfectosManager : Singleton<ArgumentosDeEfectosManager>
	{
		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0005414B File Offset: 0x0005234B
		public static ICollection<string> ids
		{
			get
			{
				return Singleton<ArgumentosDeEfectosManager>.instance.m_dicDeEfectos.Keys;
			}
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0005415C File Offset: 0x0005235C
		protected override void InitData(bool esEditorTime)
		{
			base.InitData(esEditorTime);
			this.m_dicDeEfectos.Clear();
			for (int i = 0; i < this.m_argumentosTipos.Count; i++)
			{
				SerializableType serializableType = this.m_argumentosTipos[i];
				this.m_dicDeEfectos.Add(serializableType.type.Name, serializableType);
			}
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x000541B8 File Offset: 0x000523B8
		public Type GetArgumentoType(string id)
		{
			SerializableType serializableType;
			if (this.m_dicDeEfectos.TryGetValue(id, out serializableType))
			{
				return serializableType.type;
			}
			Debug.LogError("No se encontro typo para argumento: " + id);
			return null;
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x000541F0 File Offset: 0x000523F0
		public bool TryInstantiateArg<T>(string id, out T instance) where T : class
		{
			instance = default(T);
			Type argumentoType = this.GetArgumentoType(id);
			if (argumentoType == null)
			{
				return false;
			}
			instance = Activator.CreateInstance(argumentoType) as T;
			return instance != null;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0005423C File Offset: 0x0005243C
		public void ReCacheEfectos()
		{
			if (!Application.isEditor)
			{
				Debug.LogWarning("No es recomendable llamar esta funcion en build", this);
			}
			this.m_argumentosTipos.Clear();
			foreach (Type type in ArgumentosDeEfectosManager.GetAllDerivedTypes(AppDomain.CurrentDomain, typeof(ArgumentoDeEfecto)))
			{
				this.m_argumentosTipos.Add(type);
			}
			StringSelectorV2Attribute.flagClearCache = true;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x000542A4 File Offset: 0x000524A4
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

		// Token: 0x060011CD RID: 4557 RVA: 0x0005430E File Offset: 0x0005250E
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.ReCacheEfectos();
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0005431C File Offset: 0x0005251C
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Refresh Cache De Efectos",
				playTimeVisible = false
			};
		}

		// Token: 0x04000D0A RID: 3338
		[SerializeField]
		private List<SerializableType> m_argumentosTipos = new List<SerializableType>();

		// Token: 0x04000D0B RID: 3339
		private Dictionary<string, SerializableType> m_dicDeEfectos = new Dictionary<string, SerializableType>();
	}
}
