using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000087 RID: 135
	public static class ConnectionTypes
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000103D0 File Offset: 0x0000E5D0
		private static Type NullType
		{
			get
			{
				return typeof(ConnectionTypes);
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x000103DC File Offset: 0x0000E5DC
		public static Type GetType(string typeName, bool createIfNotDeclared)
		{
			TypeData typeData = ConnectionTypes.GetTypeData(typeName, createIfNotDeclared);
			if (typeData == null)
			{
				return ConnectionTypes.NullType;
			}
			return typeData.Type;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00010400 File Offset: 0x0000E600
		public static TypeData GetTypeData(string typeName, bool createIfNotDeclared)
		{
			if (ConnectionTypes.types == null || ConnectionTypes.types.Count == 0)
			{
				NodeEditor.ReInit(false);
			}
			TypeData typeData;
			if (!ConnectionTypes.types.TryGetValue(typeName, out typeData))
			{
				if (createIfNotDeclared)
				{
					Type type = Type.GetType(typeName);
					if (type == null)
					{
						typeData = ConnectionTypes.types.First<KeyValuePair<string, TypeData>>().Value;
						Debug.LogError("No TypeData defined for: " + typeName + " and type could not be found either!");
					}
					else
					{
						typeData = new TypeData(type);
						ConnectionTypes.types.Add(typeName, typeData);
					}
				}
				else
				{
					typeData = ConnectionTypes.types.First<KeyValuePair<string, TypeData>>().Value;
					Debug.LogError("No TypeData defined for: " + typeName + "!");
				}
			}
			return typeData;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000104B0 File Offset: 0x0000E6B0
		public static TypeData GetTypeData(Type type, bool createIfNotDeclared)
		{
			if (ConnectionTypes.types == null || ConnectionTypes.types.Count == 0)
			{
				NodeEditor.ReInit(false);
			}
			TypeData typeData = ConnectionTypes.types.Values.First((TypeData tData) => tData.Type == type);
			if (typeData == null)
			{
				if (createIfNotDeclared)
				{
					typeData = new TypeData(type);
					ConnectionTypes.types.Add(type.FullName, typeData);
				}
				else
				{
					typeData = ConnectionTypes.types.First<KeyValuePair<string, TypeData>>().Value;
					Debug.LogError("No TypeData defined for: " + type.FullName + "!");
				}
			}
			return typeData;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001055C File Offset: 0x0000E75C
		internal static void FetchTypes()
		{
			ConnectionTypes.types = new Dictionary<string, TypeData> { 
			{
				"None",
				new TypeData()
			} };
			foreach (Assembly assembly2 in from assembly in AppDomain.CurrentDomain.GetAssemblies()
				where assembly.FullName.Contains("Assembly")
				select assembly)
			{
				foreach (Type type in new List<Type>(from T in assembly2.GetTypes()
					where T.IsClass && !T.IsAbstract && T.GetInterface(typeof(IConnectionTypeDeclaration).FullName) != null
					select T))
				{
					IConnectionTypeDeclaration connectionTypeDeclaration = assembly2.CreateInstance(type.FullName) as IConnectionTypeDeclaration;
					if (connectionTypeDeclaration == null)
					{
						throw new UnityException("Error with Type Declaration " + type.FullName);
					}
					ConnectionTypes.types.Add(connectionTypeDeclaration.Identifier, new TypeData(connectionTypeDeclaration));
				}
			}
		}

		// Token: 0x040000D3 RID: 211
		private static Dictionary<string, TypeData> types;
	}
}
