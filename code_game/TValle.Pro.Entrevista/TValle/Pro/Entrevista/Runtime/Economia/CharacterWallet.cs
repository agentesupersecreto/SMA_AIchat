using System;
using System.Collections.Generic;
using System.Globalization;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia
{
	// Token: 0x020000C2 RID: 194
	public class CharacterWallet : SingleControllerDeMemoriaDeCharacter
	{
		// Token: 0x06000759 RID: 1881 RVA: 0x0002985D File Offset: 0x00027A5D
		public static float Leer(string personajeID)
		{
			return MemoriaDeCharacterBase.LeerFloatFromNonVolatil(personajeID, "wallet", "fiat", 0f, null, null, null);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00029877 File Offset: 0x00027A77
		public static void Registrar(string personajeID, float data)
		{
			MemoriaDeCharacterBase.RegistrarToNonVolatil(personajeID, "wallet", "fiat", data, null, null, null);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0002988D File Offset: 0x00027A8D
		public static void Borrar(string personajeID)
		{
			MemoriaDeCharacterBase.BorrarFromNonVolatil(personajeID, "wallet", "fiat", null, null, null);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x000298A4 File Offset: 0x00027AA4
		public static void Change(string characterID, string currencyId, float value, string senderHumanRedableName, DateTime Date)
		{
			float num = MemoriaDeCharacterBase.LeerFloatFromNonVolatil(characterID, "wallet", currencyId, 0f, null, null, null);
			MemoriaDeCharacterBase.RegistrarToNonVolatil(characterID, "wallet", currencyId, num + value, null, null, null);
			IJsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(characterID, "wallet", null, null, "history");
			CharacterWallet.Transacion transacion = new CharacterWallet.Transacion
			{
				senderName = (string.IsNullOrWhiteSpace(senderHumanRedableName) ? "Unknown" : senderHumanRedableName),
				currencySimbol = ((currencyId != "fiat") ? "ND" : "$"),
				date = Date,
				value = value
			};
			CharacterWallet.AddToHistorial(childMemoriaNonVolatil, transacion);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00029940 File Offset: 0x00027B40
		public static void AddToHistorial(IJsonMemoryNode historialMem, CharacterWallet.Transacion transaccion)
		{
			IJsonMemoryNode jsonMemoryNode = historialMem.FindChildNotNull<IJsonMemoryNode>(historialMem.children.Count.ToString(CultureInfo.InvariantCulture));
			jsonMemoryNode.AddData("senderName", transaccion.senderName, true);
			jsonMemoryNode.AddData("currencySimbol", transaccion.currencySimbol, true);
			jsonMemoryNode.AddData("date", transaccion.date.Serialized(), true);
			jsonMemoryNode.AddData("value", transaccion.value, true);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x000299B8 File Offset: 0x00027BB8
		public static void GetHistorial(string characterID, out IReadOnlyList<CharacterWallet.Transacion> transacciones)
		{
			IJsonMemoryNode childMemoriaNonVolatil = MemoriaDeCharacterBase.GetChildMemoriaNonVolatil(characterID, "wallet", null, null, "history");
			List<CharacterWallet.Transacion> list = new List<CharacterWallet.Transacion>();
			CharacterWallet.LoadHistorial(childMemoriaNonVolatil, list);
			transacciones = list;
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x000299E6 File Offset: 0x00027BE6
		protected override string nodeID
		{
			get
			{
				return "wallet";
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x000299ED File Offset: 0x00027BED
		public IReadOnlyList<CharacterWallet.Transacion> historial
		{
			get
			{
				return this.m_historial;
			}
		}

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000761 RID: 1889 RVA: 0x000299F8 File Offset: 0x00027BF8
		// (remove) Token: 0x06000762 RID: 1890 RVA: 0x00029A30 File Offset: 0x00027C30
		public event Action onChanged;

		// Token: 0x06000763 RID: 1891 RVA: 0x00029A68 File Offset: 0x00027C68
		public override void LoadFromMemory()
		{
			this.m_wallet.Clear();
			if (this.m_memoria.data.Count == 0)
			{
				this.m_wallet.Add("fiat", this.cantidadInicial);
			}
			else
			{
				foreach (KeyValuePair<string, string> keyValuePair in this.m_memoria.data)
				{
					this.m_wallet.Add(keyValuePair.Key, this.m_memoria.FindDataFloat(keyValuePair.Key, 0f));
				}
			}
			this.m_historial.Clear();
			CharacterWallet.LoadHistorial(this.m_memoria.FindChildNotNull<IJsonMemoryNode>("history"), this.m_historial);
			if (this.msgChanges)
			{
				foreach (KeyValuePair<string, float> keyValuePair2 in this.m_wallet)
				{
					Singleton<MainCanvas>.instance.MostrartMsg("Account Balance", "Your bank account balance has changed to <b>" + keyValuePair2.Value.ToString("C2") + "</B>", 1f, false, null, new float?((float)15), null);
				}
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00029BC8 File Offset: 0x00027DC8
		private static void LoadHistorial(IJsonMemoryNode hisMem, List<CharacterWallet.Transacion> historial)
		{
			for (int i = 0; i < hisMem.children.Count; i++)
			{
				IJsonMemoryNode jsonMemoryNode = hisMem.FindChild<IJsonMemoryNode>(i.ToString(CultureInfo.InvariantCulture));
				if (jsonMemoryNode != null)
				{
					historial.Add(new CharacterWallet.Transacion
					{
						senderName = jsonMemoryNode.FindData("senderName"),
						currencySimbol = jsonMemoryNode.FindData("currencySimbol"),
						date = jsonMemoryNode.FindData("date"),
						value = jsonMemoryNode.FindDataFloat("value", 0f)
					});
				}
			}
			historial.Sort((CharacterWallet.Transacion h1, CharacterWallet.Transacion h2) => h2.date.dateTime.CompareTo(h1.date.dateTime));
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00029C84 File Offset: 0x00027E84
		public override void SaveToMemory()
		{
			this.m_memoria.ResetMemoria();
			foreach (KeyValuePair<string, float> keyValuePair in this.m_wallet)
			{
				this.m_memoria.AddData(keyValuePair.Key, keyValuePair.Value, true);
			}
			IJsonMemoryNode jsonMemoryNode = this.m_memoria.FindChildNotNull<IJsonMemoryNode>("history");
			jsonMemoryNode.ResetMemoria();
			DateTime dateTime = Singleton<TiempoDeJuego>.instance.tiempoActual.AddDays(-31.0);
			for (int i = 0; i < this.m_historial.Count; i++)
			{
				CharacterWallet.Transacion transacion = this.m_historial[i];
				if (!(transacion.date < dateTime))
				{
					IJsonMemoryNode jsonMemoryNode2 = jsonMemoryNode.FindChildNotNull<IJsonMemoryNode>(i.ToString(CultureInfo.InvariantCulture));
					jsonMemoryNode2.AddData("senderName", transacion.senderName, true);
					jsonMemoryNode2.AddData("currencySimbol", transacion.currencySimbol, true);
					jsonMemoryNode2.AddData("date", transacion.date.Serialized(), true);
					jsonMemoryNode2.AddData("value", transacion.value, true);
				}
			}
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00029DD0 File Offset: 0x00027FD0
		public float Current(string id)
		{
			return CharacterWallet.Current(id, this.m_wallet);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00029DE0 File Offset: 0x00027FE0
		public void Change(string id, float value, string senderHumanRedableName)
		{
			CharacterWallet.Change(id, value, senderHumanRedableName, this.m_wallet, this.m_historial, this);
			if (value != 0f && this.msgChanges)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Account Balance", "Your bank account balance has changed to <b>" + this.m_wallet[id].ToString("C2") + "</B>", 1f, false, null, new float?((float)15), null);
			}
			if (value != 0f)
			{
				Action action = this.onChanged;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00029E7C File Offset: 0x0002807C
		public static float Current(string id, StringKeyFloatValueDictionary wallet)
		{
			float num;
			if (wallet.TryGetValue(id, out num))
			{
				return num;
			}
			return 0f;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00029E9C File Offset: 0x0002809C
		public static void Change(string id, float value, string senderHumanRedableName, StringKeyFloatValueDictionary wallet, List<CharacterWallet.Transacion> historial, Component context)
		{
			if (!wallet.ContainsKey(id))
			{
				wallet.Add(id, 0f);
			}
			float num = wallet[id];
			wallet[id] = num + value;
			historial.Insert(0, new CharacterWallet.Transacion
			{
				senderName = (string.IsNullOrWhiteSpace(senderHumanRedableName) ? "Unknown" : senderHumanRedableName),
				currencySimbol = ((id != "fiat") ? "ND" : "$"),
				date = Singleton<TiempoDeJuego>.instance.tiempoActual,
				value = value
			});
			try
			{
				while (historial.Count > 20)
				{
					historial.RemoveAt(20);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, context);
			}
		}

		// Token: 0x04000435 RID: 1077
		public const string MemID = "wallet";

		// Token: 0x04000436 RID: 1078
		public const string HistorialD = "history";

		// Token: 0x04000437 RID: 1079
		public const string fiat = "fiat";

		// Token: 0x04000438 RID: 1080
		public const string fiatSimbol = "$";

		// Token: 0x04000439 RID: 1081
		[SerializeField]
		private StringKeyFloatValueDictionary m_wallet = new StringKeyFloatValueDictionary();

		// Token: 0x0400043A RID: 1082
		[SerializeField]
		private List<CharacterWallet.Transacion> m_historial = new List<CharacterWallet.Transacion>();

		// Token: 0x0400043B RID: 1083
		public float cantidadInicial = 200f;

		// Token: 0x0400043D RID: 1085
		public bool msgChanges = true;

		// Token: 0x0200024D RID: 589
		[Serializable]
		public class Transacion
		{
			// Token: 0x04000B19 RID: 2841
			public string senderName;

			// Token: 0x04000B1A RID: 2842
			public string currencySimbol;

			// Token: 0x04000B1B RID: 2843
			public UDateTime date;

			// Token: 0x04000B1C RID: 2844
			public float value;
		}
	}
}
