using System;
using System.Globalization;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Memorias
{
	// Token: 0x0200000C RID: 12
	[MemoriaRelatedBehaviour]
	public abstract class MemoriaDeCharacterBase : AplicableBehaviour
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000038A3 File Offset: 0x00001AA3
		public static string defaultRuta
		{
			get
			{
				return "root/NPC/";
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000038AA File Offset: 0x00001AAA
		public static string GetRutaCompleta(string defaultRuta, string characterID, string selfMemKeyName)
		{
			return defaultRuta + characterID + "/Memorias" + (string.IsNullOrWhiteSpace(selfMemKeyName) ? string.Empty : ("/" + selfMemKeyName));
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000038D2 File Offset: 0x00001AD2
		public static IJsonMemoryNode GetPermanentMemoria(string rutaCompleta)
		{
			return GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(rutaCompleta, true);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600005A RID: 90 RVA: 0x000038E0 File Offset: 0x00001AE0
		public IJsonMemoryNodeReadOnly memoriaReadOnly
		{
			get
			{
				return this.m_memoria;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000038E8 File Offset: 0x00001AE8
		public string ID
		{
			get
			{
				return this.m_Character.ID_Unico.ToString();
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000390E File Offset: 0x00001B0E
		public string ruta
		{
			get
			{
				return MemoriaDeCharacterBase.defaultRuta;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005D RID: 93
		public abstract string selfMemKeyName { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005E RID: 94
		public abstract bool permanente { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003915 File Offset: 0x00001B15
		public Character owner
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000060 RID: 96 RVA: 0x00003920 File Offset: 0x00001B20
		// (remove) Token: 0x06000061 RID: 97 RVA: 0x00003958 File Offset: 0x00001B58
		public event Action<MemoriaDeCharacterBase> loaded;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000062 RID: 98 RVA: 0x00003990 File Offset: 0x00001B90
		// (remove) Token: 0x06000063 RID: 99 RVA: 0x000039C8 File Offset: 0x00001BC8
		public event Action<MemoriaDeCharacterBase> saving;

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000039FD File Offset: 0x00001BFD
		[Obsolete("", true)]
		protected string rutaCompleta
		{
			get
			{
				return this.ruta + this.ID + "/Memorias" + (string.IsNullOrWhiteSpace(this.selfMemKeyName) ? string.Empty : ("/" + this.selfMemKeyName));
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003A39 File Offset: 0x00001C39
		protected string GenerarRutaCompleta()
		{
			return MemoriaDeCharacterBase.GetRutaCompleta(this.ruta, this.ID, this.selfMemKeyName);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003A54 File Offset: 0x00001C54
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			Character character = this.m_Character;
			if (character == null)
			{
				throw new ArgumentNullException("memChar", "memChar null reference.");
			}
			this.m_Character.charMemoryOnLoad += this.M_Character_memoryOnLoad;
			((ICharacterGuardableToMemory)character).memoryOnLoad += this.MemChar_memoryOnLoad;
			((ICharacterGuardableToMemory)character).memoryOnSave += this.MemChar_memoryOnSave;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003AE8 File Offset: 0x00001CE8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ICharacterGuardableToMemory character = this.m_Character;
			if (character != null)
			{
				character.memoryOnSave -= this.MemChar_memoryOnSave;
				character.memoryOnLoad -= this.MemChar_memoryOnLoad;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003B2C File Offset: 0x00001D2C
		private void M_Character_memoryOnLoad(Character obj)
		{
			if (this.m_memoria != null)
			{
				return;
			}
			if (this.permanente)
			{
				this.m_memoria = (JsonMemoryNode)MemoriaDeCharacterBase.GetPermanentMemoria(this.GenerarRutaCompleta());
			}
			else
			{
				this.m_memoria = (JsonMemoryNode)new MemoriaJsonGenerica().root;
			}
			this.OnLoadMemory(this.m_memoria);
			Action<MemoriaDeCharacterBase> action = this.loaded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003B94 File Offset: 0x00001D94
		private void MemChar_memoryOnLoad(object fromMemory, ICharacterGuardableToMemory character)
		{
			if (this.m_memoria != null)
			{
				return;
			}
			IMemoria memoria = fromMemory as IMemoria;
			if (memoria == null)
			{
				return;
			}
			if (this.permanente)
			{
				this.m_memoria = (JsonMemoryNode)memoria.LeerDeep(this.GenerarRutaCompleta(), true);
			}
			else
			{
				this.m_memoria = (JsonMemoryNode)new MemoriaJsonGenerica().root;
			}
			this.OnLoadMemory(this.m_memoria);
			Action<MemoriaDeCharacterBase> action = this.loaded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003C0C File Offset: 0x00001E0C
		private void MemChar_memoryOnSave(object toMemory, ICharacterGuardableToMemory character)
		{
			if (!this.permanente)
			{
				return;
			}
			JsonMemoryNode memoria = this.m_memoria;
			JsonMemoryNode jsonMemoryNode = null;
			IMemoria memoria2 = toMemory as IMemoria;
			if (memoria2 != null)
			{
				jsonMemoryNode = (JsonMemoryNode)memoria2.LeerDeep(this.GenerarRutaCompleta(), true);
			}
			if (memoria == jsonMemoryNode)
			{
				jsonMemoryNode = null;
			}
			bool flag = false;
			if (memoria != null)
			{
				this.OnSavingMemory(memoria);
				flag = true;
			}
			if (jsonMemoryNode != null)
			{
				this.OnSavingMemory(jsonMemoryNode);
				flag = true;
			}
			if (flag)
			{
				Action<MemoriaDeCharacterBase> action = this.saving;
				if (action == null)
				{
					return;
				}
				action(this);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003C7C File Offset: 0x00001E7C
		public static bool PersonajeExiste(IMemoria memoria, string charID)
		{
			if (memoria == null)
			{
				throw new ArgumentNullException("memoria", "memoria null reference.");
			}
			if (string.IsNullOrEmpty(charID))
			{
				return false;
			}
			string text = MemoriaDeCharacterBase.defaultRuta + charID;
			return memoria.LeerDeep(text, false) != null;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003CBD File Offset: 0x00001EBD
		public static bool PersonajeExisteAndLog(IMemoria memoria, string nodeId, string charID)
		{
			if (!MemoriaDeCharacterBase.PersonajeExiste(memoria, charID))
			{
				Debug.Log(string.Concat(new string[] { "character ", charID, " no longer exists, memory ", nodeId, " referring to this character was erased" }));
				return false;
			}
			return true;
		}

		// Token: 0x0600006D RID: 109
		protected abstract void OnLoadMemory(JsonMemoryNode fromMemory);

		// Token: 0x0600006E RID: 110
		protected abstract void OnSavingMemory(JsonMemoryNode toMemory);

		// Token: 0x0600006F RID: 111 RVA: 0x00003CFB File Offset: 0x00001EFB
		public static JsonMemoryNode GetMemoriaNonVolatil(string personajeID, string ruta)
		{
			if (ruta == null)
			{
				ruta = MemoriaDeCharacterBase.defaultRuta;
			}
			return (JsonMemoryNode)GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(ruta + personajeID + "/Memorias", true);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003D24 File Offset: 0x00001F24
		public static JsonMemoryNode GetChildMemoriaNonVolatil(string personajeID, string childKeyName, string ruta, string preRuta, string postRuta)
		{
			if (ruta == null)
			{
				ruta = MemoriaDeCharacterBase.defaultRuta;
			}
			if (string.IsNullOrWhiteSpace(postRuta) && string.IsNullOrWhiteSpace(preRuta))
			{
				return (JsonMemoryNode)GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(ruta + personajeID + "/Memorias/" + childKeyName, true);
			}
			if (string.IsNullOrWhiteSpace(postRuta))
			{
				return (JsonMemoryNode)GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(string.Concat(new string[] { ruta, personajeID, "/Memorias/", preRuta, "/", childKeyName }), true);
			}
			if (string.IsNullOrWhiteSpace(preRuta))
			{
				return (JsonMemoryNode)GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(string.Concat(new string[] { ruta, personajeID, "/Memorias/", childKeyName, "/", postRuta }), true);
			}
			return (JsonMemoryNode)GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(string.Concat(new string[] { ruta, personajeID, "/Memorias/", preRuta, "/", childKeyName, "/", postRuta }), true);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003E3C File Offset: 0x0000203C
		public static void BorrarFromNonVolatil(string personajeID, string childKey, string dataKey, string ruta = null, string preRuta = null, string postRuta = null)
		{
			JsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta);
			if (childMemoriaNonVolatil.FindData(dataKey) == null)
			{
				return;
			}
			childMemoriaNonVolatil.RemoverData(dataKey);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003E68 File Offset: 0x00002068
		public static void BorrarChildFromNonVolatil(string personajeID, string childKey, string ruta = null)
		{
			JsonMemoryNode memoriaNonVolatil = MemoriaDeCharacterBase.GetMemoriaNonVolatil(personajeID, ruta);
			JsonMemoryNode jsonMemoryNode = memoriaNonVolatil.FindChild(childKey);
			if (jsonMemoryNode == null)
			{
				return;
			}
			memoriaNonVolatil.RemoverChild(jsonMemoryNode);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003E91 File Offset: 0x00002091
		public static void RegistrarToNonVolatil(string personajeID, string childKey, string dataKey, string data, string ruta = null, string preRuta = null, string postRuta = null)
		{
			MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta).AddData(dataKey, data, true);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003EA8 File Offset: 0x000020A8
		public static void RegistrarToNonVolatil(string personajeID, string childKey, string dataKey, float data, string ruta = null, string preRuta = null, string postRuta = null)
		{
			MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta).AddData(dataKey, data, true);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003EBF File Offset: 0x000020BF
		public static void RegistrarToNonVolatil(string personajeID, string childKey, string dataKey, int data, string ruta = null, string preRuta = null, string postRuta = null)
		{
			MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta).AddData(dataKey, data, true);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003ED6 File Offset: 0x000020D6
		public static void RegistrarToNonVolatil(string personajeID, string childKey, string dataKey, bool data, string ruta = null, string preRuta = null, string postRuta = null)
		{
			MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta).AddData(dataKey, data, true);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003EF0 File Offset: 0x000020F0
		public static string LeerFromNonVolatil(string personajeID, string childKey, string dataKey, string ruta = null, string preRuta = null, string postRuta = null)
		{
			JsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta);
			if (childMemoriaNonVolatil == null)
			{
				return null;
			}
			return childMemoriaNonVolatil.FindData(dataKey);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003F18 File Offset: 0x00002118
		public static float LeerFloatFromNonVolatil(string personajeID, string childKey, string dataKey, float defaultValue, string ruta = null, string preRuta = null, string postRuta = null)
		{
			JsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta);
			if (childMemoriaNonVolatil == null)
			{
				return defaultValue;
			}
			return childMemoriaNonVolatil.FindDataFloat(dataKey, defaultValue);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003F40 File Offset: 0x00002140
		public static int LeerIntFromNonVolatil(string personajeID, string childKey, string dataKey, int defaultValue, string ruta = null, string preRuta = null, string postRuta = null)
		{
			JsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta);
			if (childMemoriaNonVolatil == null)
			{
				return defaultValue;
			}
			return childMemoriaNonVolatil.FindDataInt(dataKey, defaultValue);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003F68 File Offset: 0x00002168
		public static bool LeerBooleanFromNonVolatil(string personajeID, string childKey, string dataKey, bool defaultValue, string ruta = null, string preRuta = null, string postRuta = null)
		{
			JsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(personajeID, childKey, ruta, preRuta, postRuta);
			if (childMemoriaNonVolatil == null)
			{
				return defaultValue;
			}
			return childMemoriaNonVolatil.FindDataBool(dataKey, defaultValue);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003F90 File Offset: 0x00002190
		public static void Borrar(MemoriaDeCharacterBase memoria, string childKey, string dataKey)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChildNotNull(childKey);
			if (jsonMemoryNode.FindData(dataKey) == null)
			{
				return;
			}
			jsonMemoryNode.RemoverData(dataKey);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003FBC File Offset: 0x000021BC
		public static void Registrar(MemoriaDeCharacterBase memoria, string childKey, string dataKey, string data)
		{
			memoria.m_memoria.FindChildNotNull(childKey).AddData(dataKey, data, true);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003FD2 File Offset: 0x000021D2
		public static void Registrar(MemoriaDeCharacterBase memoria, string childKey, string dataKey, float data)
		{
			memoria.m_memoria.FindChildNotNull(childKey).AddData(dataKey, data, true);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003FE8 File Offset: 0x000021E8
		public static void Registrar(MemoriaDeCharacterBase memoria, string childKey, string dataKey, int data)
		{
			memoria.m_memoria.FindChildNotNull(childKey).AddData(dataKey, data, true);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003FFE File Offset: 0x000021FE
		public static void Registrar(MemoriaDeCharacterBase memoria, string childKey, string dataKey, bool data)
		{
			memoria.m_memoria.FindChildNotNull(childKey).AddData(dataKey, data, true);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004014 File Offset: 0x00002214
		public static string Leer(MemoriaDeCharacterBase memoria, string childKey, string dataKey)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChild(childKey);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			return jsonMemoryNode.FindData(dataKey);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000403C File Offset: 0x0000223C
		public static float LeerFloat(MemoriaDeCharacterBase memoria, string childKey, string dataKey, float defaultValue)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChild(childKey);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataFloat(dataKey, defaultValue);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004064 File Offset: 0x00002264
		public static int LeerInt(MemoriaDeCharacterBase memoria, string childKey, string dataKey, int defaultValue)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChild(childKey);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataInt(dataKey, defaultValue);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000408C File Offset: 0x0000228C
		public static bool LeerBoolean(MemoriaDeCharacterBase memoria, string childKey, string dataKey, bool defaultValue)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChild(childKey);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataBool(dataKey, defaultValue);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000040B3 File Offset: 0x000022B3
		private static void Leer(string nodeId, ref IJsonMemoryNode node, bool crear = false)
		{
			if (nodeId == null || node == null)
			{
				throw new NotSupportedException();
			}
			if (string.Empty == nodeId)
			{
				return;
			}
			if (!crear)
			{
				node = (IJsonMemoryNode)node.FindChild(nodeId);
				return;
			}
			node = (IJsonMemoryNode)node.FindChildNotNull(nodeId);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000040F4 File Offset: 0x000022F4
		public static IJsonMemoryNode LeerDeep(MemoriaDeCharacterBase memoria, string nodeRuta, bool crear = false)
		{
			IJsonMemoryNode memoria2 = memoria.m_memoria;
			if (string.IsNullOrWhiteSpace(nodeRuta))
			{
				return memoria2;
			}
			string[] array = nodeRuta.Split('/', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if ((i != 0 || !(text == "root") || !(memoria2.nodeID == text)) && !string.IsNullOrEmpty(text))
				{
					MemoriaDeCharacterBase.Leer(text, ref memoria2, crear);
					if (memoria2 == null)
					{
						return null;
					}
				}
			}
			return memoria2;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004164 File Offset: 0x00002364
		public static string LeerDeep(MemoriaDeCharacterBase memoria, string ruta, string dataKey)
		{
			IJsonMemoryNode jsonMemoryNode = MemoriaDeCharacterBase.LeerDeep(memoria, ruta, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			return jsonMemoryNode.FindData(dataKey);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004188 File Offset: 0x00002388
		public static float LeerDeepFloat(MemoriaDeCharacterBase memoria, string ruta, string dataKey, float defaultValue)
		{
			IJsonMemoryNode jsonMemoryNode = MemoriaDeCharacterBase.LeerDeep(memoria, ruta, false);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataFloat(dataKey, defaultValue);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000041AC File Offset: 0x000023AC
		public static int LeerDeepInt(MemoriaDeCharacterBase memoria, string ruta, string dataKey, int defaultValue)
		{
			IJsonMemoryNode jsonMemoryNode = MemoriaDeCharacterBase.LeerDeep(memoria, ruta, false);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataInt(dataKey, defaultValue);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000041D0 File Offset: 0x000023D0
		public static bool LeerDeepBoolean(MemoriaDeCharacterBase memoria, string ruta, string dataKey, bool defaultValue)
		{
			IJsonMemoryNode jsonMemoryNode = MemoriaDeCharacterBase.LeerDeep(memoria, ruta, false);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataBool(dataKey, defaultValue);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000041F3 File Offset: 0x000023F3
		public static void RegistrarDeep(MemoriaDeCharacterBase memoria, string ruta, string dataKey, string data)
		{
			MemoriaDeCharacterBase.LeerDeep(memoria, ruta, true).AddData(dataKey, data, true);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004205 File Offset: 0x00002405
		public static void RegistrarDeep(MemoriaDeCharacterBase memoria, string ruta, string dataKey, float data)
		{
			MemoriaDeCharacterBase.LeerDeep(memoria, ruta, true).AddData(dataKey, data, true);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004217 File Offset: 0x00002417
		public static void RegistrarDeep(MemoriaDeCharacterBase memoria, string ruta, string dataKey, int data)
		{
			MemoriaDeCharacterBase.LeerDeep(memoria, ruta, true).AddData(dataKey, data, true);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004229 File Offset: 0x00002429
		public static void RegistrarDeep(MemoriaDeCharacterBase memoria, string ruta, string dataKey, bool data)
		{
			MemoriaDeCharacterBase.LeerDeep(memoria, ruta, true).AddData(dataKey, data, true);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000423C File Offset: 0x0000243C
		public static void RegistrarCantidadPlus(MemoriaDeCharacterBase memoria, string childKey, string dataKey)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChildNotNull(childKey);
			string text = jsonMemoryNode.FindData(dataKey);
			if (text == null)
			{
				jsonMemoryNode.AddData(dataKey, 1, true);
				return;
			}
			jsonMemoryNode.AddData(dataKey, Convert.ToInt32(text, CultureInfo.InvariantCulture) + 1, true);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004280 File Offset: 0x00002480
		public static void RegistrarCantidadPlus(MemoriaDeCharacterBase memoria, string childKey, string dataKey, int cantidadAdd)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChildNotNull(childKey);
			string text = jsonMemoryNode.FindData(dataKey);
			if (text == null)
			{
				jsonMemoryNode.AddData(dataKey, cantidadAdd, true);
				return;
			}
			jsonMemoryNode.AddData(dataKey, Convert.ToInt32(text, CultureInfo.InvariantCulture) + cantidadAdd, true);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000042C4 File Offset: 0x000024C4
		public static bool CantidadFueRegistrada(MemoriaDeCharacterBase memoria, string childKey, string dataKey)
		{
			return MemoriaDeCharacterBase.CantidadRegistrada(memoria, childKey, dataKey) > 0;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000042D4 File Offset: 0x000024D4
		public static int CantidadRegistrada(MemoriaDeCharacterBase memoria, string childKey, string dataKey)
		{
			JsonMemoryNode jsonMemoryNode = memoria.m_memoria.FindChild(childKey);
			if (jsonMemoryNode == null)
			{
				return 0;
			}
			string text = jsonMemoryNode.FindData(dataKey);
			if (text == null)
			{
				return 0;
			}
			return Convert.ToInt32(text);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004306 File Offset: 0x00002506
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Borrar Todo",
				editorTimeVisible = false,
				confirmar = true
			};
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004326 File Offset: 0x00002526
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.m_memoria.RemoverChildAll();
			this.m_memoria.RemoverDataAll();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004344 File Offset: 0x00002544
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Ver Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000435D File Offset: 0x0000255D
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.m_memoriaEditorDebug = JsonUtility.ToJson(this.m_memoria, true);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004377 File Offset: 0x00002577
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Simular Save Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004390 File Offset: 0x00002590
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			JsonMemoryNode jsonMemoryNode = (JsonMemoryNode)MemoriaDeCharacterBase.GetPermanentMemoria(this.GenerarRutaCompleta());
			this.OnSavingMemory(jsonMemoryNode);
			this.m_memoriaEditorDebug = JsonUtility.ToJson(jsonMemoryNode, true);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000043C8 File Offset: 0x000025C8
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Simular Load Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000043E4 File Offset: 0x000025E4
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			JsonMemoryNode jsonMemoryNode = (JsonMemoryNode)MemoriaDeCharacterBase.GetPermanentMemoria(this.GenerarRutaCompleta());
			this.OnLoadMemory(jsonMemoryNode);
			this.m_memoriaEditorDebug = JsonUtility.ToJson(jsonMemoryNode, true);
		}

		// Token: 0x0400001B RID: 27
		[NonSerialized]
		private JsonMemoryNode m_memoria;

		// Token: 0x0400001C RID: 28
		protected Character m_Character;

		// Token: 0x0400001F RID: 31
		[SerializeField]
		[TextArea]
		private string m_memoriaEditorDebug;
	}
}
