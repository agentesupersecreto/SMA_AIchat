using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Genetica.Globales
{
	// Token: 0x02000004 RID: 4
	public sealed class PiscinasDeNPCs : Singleton<PiscinasDeNPCs>, IEnumerable<PiscinaDeNpcsManager>, IEnumerable
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002AD0 File Offset: 0x00000CD0
		[Obsolete("usar indexer PiscinasDeNPCs[i]", true)]
		public IReadOnlyList<PiscinaDeNpcsManager> managersDePiscinasList
		{
			get
			{
				return this.m_piscinasExistentesList;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002AD8 File Offset: 0x00000CD8
		[Obsolete("usar indexer PiscinasDeNPCs[key]", true)]
		public IReadOnlyDictionary<Guid, PiscinaDeNpcsManager> managersDePiscinas
		{
			get
			{
				return this.m_piscinasExistentes;
			}
		}

		// Token: 0x17000008 RID: 8
		public PiscinaDeNpcsManager this[int i]
		{
			get
			{
				if (this.m_piscinasExistentesList.ContieneIndex(i))
				{
					return this.m_piscinasExistentesList[i];
				}
				return null;
			}
		}

		// Token: 0x17000009 RID: 9
		public PiscinaDeNpcsManager this[Guid key]
		{
			get
			{
				PiscinaDeNpcsManager piscinaDeNpcsManager;
				if (this.m_piscinasExistentes.TryGetValue(key, out piscinaDeNpcsManager))
				{
					return piscinaDeNpcsManager;
				}
				return null;
			}
		}

		// Token: 0x1700000A RID: 10
		public PiscinaDeNpcsManager this[string id]
		{
			get
			{
				Guid guid;
				try
				{
					guid = Guid.Parse(id);
				}
				catch (Exception)
				{
					throw;
				}
				return this[guid];
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002B50 File Offset: 0x00000D50
		IEnumerator<PiscinaDeNpcsManager> IEnumerable<PiscinaDeNpcsManager>.GetEnumerator()
		{
			return this.m_piscinasExistentesList.GetEnumerator();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B62 File Offset: 0x00000D62
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.m_piscinasExistentesList.GetEnumerator();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002B74 File Offset: 0x00000D74
		protected override void Initiating()
		{
			base.Initiating();
			if (this.prefabDePiscina == null)
			{
				throw new ArgumentNullException("prefabDePiscina", "prefabDePiscina null reference.");
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002B9A File Offset: 0x00000D9A
		protected override void InitData(bool esEditorTime)
		{
			if (!esEditorTime)
			{
				this.LoadPiscinas();
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002BA5 File Offset: 0x00000DA5
		public int cantidadEnMemoria
		{
			get
			{
				return GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", true).children.Count;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002BC1 File Offset: 0x00000DC1
		public int cantidadInstanciadas
		{
			get
			{
				return this.m_piscinasExistentes.Count;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002BD0 File Offset: 0x00000DD0
		public void DestruirTodasLasInstancias(bool destroirTambienSuejtos)
		{
			foreach (KeyValuePair<Guid, PiscinaDeNpcsManager> keyValuePair in this.m_piscinasExistentes)
			{
				keyValuePair.Value.DestruirPiscina(destroirTambienSuejtos);
			}
			this.m_piscinasExistentes.Clear();
			this.m_piscinasExistentesList.Clear();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002C40 File Offset: 0x00000E40
		public void ReloadPiscinas(bool destroirTambienSuejtos)
		{
			this.DestruirTodasLasInstancias(destroirTambienSuejtos);
			this.LoadPiscinas();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C50 File Offset: 0x00000E50
		private void LoadPiscinas()
		{
			foreach (IMemoryNode<string, string> memoryNode in GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", true).children)
			{
				Guid guid;
				try
				{
					guid = Guid.Parse(memoryNode.nodeID);
				}
				catch (Exception ex)
				{
					Debug.LogWarning("error ahead: no se pudo convertir id de piscina: " + memoryNode.nodeID + " a guid");
					Debug.LogException(ex, this);
					this.ForzarBorrarMemoriaDePiscina(memoryNode.nodeID);
					continue;
				}
				this.instanciarDesdeMemoria(guid);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002CF8 File Offset: 0x00000EF8
		public PiscinaDeNpcsManager CrearNuevaPiscina(int cantidadDeSujetos, TipoDeRandomizadoParaSujeto? tipoDeRandomizado = null)
		{
			return this.instanciarNuevaYGuardarEnMemoria(cantidadDeSujetos, tipoDeRandomizado);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002D04 File Offset: 0x00000F04
		public PiscinaDeNpcsManager LeerOrCreatePiscina(int cantidadDeSujetos)
		{
			IMemoryNode<string, string> memoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", true).children.FirstOrDefault(delegate(IMemoryNode<string, string> par)
			{
				Guid guid;
				return !string.IsNullOrEmpty(par.nodeID) && Guid.TryParse(par.nodeID, out guid) && !this.m_piscinasExistentes.ContainsKey(guid);
			});
			if (memoryNode != null)
			{
				return this.instanciarDesdeMemoria(Guid.Parse(memoryNode.nodeID));
			}
			return this.instanciarNuevaYGuardarEnMemoria(cantidadDeSujetos, null);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002D60 File Offset: 0x00000F60
		public PiscinaDeNpcsManager ObtenerOrLoadOrCreatePiscina(Guid id, int cantidadDeSujetos)
		{
			PiscinaDeNpcsManager piscinaDeNpcsManager;
			if (this.m_piscinasExistentes.TryGetValue(id, out piscinaDeNpcsManager))
			{
				return piscinaDeNpcsManager;
			}
			if (GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", true).FindChild(id.ToString()) != null)
			{
				return this.instanciarDesdeMemoria(id);
			}
			return this.instanciarNuevaYGuardarEnMemoria(id, cantidadDeSujetos, null);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002DBC File Offset: 0x00000FBC
		public PiscinaDeNpcsManager LoadOrCreatePiscina(string id, int cantidadDeSujetos)
		{
			Guid guid;
			try
			{
				guid = Guid.Parse(id);
			}
			catch (Exception)
			{
				throw;
			}
			return this.ObtenerOrLoadOrCreatePiscina(guid, cantidadDeSujetos);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002DF0 File Offset: 0x00000FF0
		[Obsolete("", true)]
		public PiscinaDeNpcsManager LoadPiscinaNotNull()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002DF7 File Offset: 0x00000FF7
		[Obsolete("", true)]
		public PiscinaDeNpcsManager LoadPiscinaNotNull(string id)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002DFE File Offset: 0x00000FFE
		[Obsolete("", true)]
		public PiscinaDeNpcsManager LoadPiscinaNotNull(Guid id)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002E05 File Offset: 0x00001005
		[Obsolete("", true)]
		public PiscinaDeNpcsManager LoadPiscina(string id)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002E0C File Offset: 0x0000100C
		[Obsolete("", true)]
		public PiscinaDeNpcsManager LoadPiscina(Guid id)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002E14 File Offset: 0x00001014
		public void BorrarCompletamentePiscina(PiscinaDeNpcsManager piscina)
		{
			try
			{
				this.m_piscinasExistentes.Remove(Guid.Parse(piscina.ID));
				this.m_piscinasExistentesList.Remove(piscina);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", false).RemoverChild(piscina.ID);
			Debug.Log("Piscina Borrada En Memoria " + piscina.ID, this);
			piscina.BorrarPiscinaDeMemoria(true);
			piscina.DestruirPiscina(true);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002EA0 File Offset: 0x000010A0
		private void ForzarBorrarMemoriaDePiscina(string piscinaID)
		{
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", false);
			if (jsonMemoryNode != null)
			{
				jsonMemoryNode.RemoverChild(piscinaID);
			}
			MemoriaDePiscinaDeDeSujetosNpcFemenina.BorrarNPCs(piscinaID, false);
			MemoriaDePiscinaDeDeSujetosNpcFemenina.BorrarTodasLasIDsDeNPCs(piscinaID);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002ECC File Offset: 0x000010CC
		[Obsolete("", true)]
		public PiscinaDeNpcsManager InstanciarNuevaPiscina(bool empty)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002ED4 File Offset: 0x000010D4
		private PiscinaDeNpcsManager instanciarNuevaYGuardarEnMemoria(int cantidadDeSujetos, TipoDeRandomizadoParaSujeto? tipoDeRandomizado = null)
		{
			Guid guid;
			do
			{
				guid = Guid.NewGuid();
			}
			while (this.m_piscinasExistentes.ContainsKey(guid));
			return this.instanciarNuevaYGuardarEnMemoria(guid, cantidadDeSujetos, tipoDeRandomizado);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002F00 File Offset: 0x00001100
		private PiscinaDeNpcsManager instanciarNuevaYGuardarEnMemoria(Guid id, int cantidadDeSujetos, TipoDeRandomizadoParaSujeto? tipoDeRandomizado = null)
		{
			if (this.m_piscinasExistentes.ContainsKey(id))
			{
				throw new InvalidOperationException();
			}
			PiscinaDeNpcsManager piscinaDeNpcsManager = Object.Instantiate<PiscinaDeNpcsManager>(this.prefabDePiscina, base.transform);
			string text = id.ToString();
			piscinaDeNpcsManager.Init(new int?(cantidadDeSujetos), text, text, text, tipoDeRandomizado);
			GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep("root/Piscinas/Existentes/").FindChildNotNull(text);
			Debug.Log("Nueva Piscina Escrita En Memoria " + id.ToString(), this);
			this.m_piscinasExistentes.Add(id, piscinaDeNpcsManager);
			this.m_piscinasExistentesList.Add(piscinaDeNpcsManager);
			return piscinaDeNpcsManager;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002FA0 File Offset: 0x000011A0
		private PiscinaDeNpcsManager instanciarDesdeMemoria(Guid id)
		{
			if (this.m_piscinasExistentes.ContainsKey(id))
			{
				throw new InvalidOperationException();
			}
			string text = id.ToString();
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", true).FindChildNotNull(text);
			PiscinaDeNpcsManager piscinaDeNpcsManager = Object.Instantiate<PiscinaDeNpcsManager>(this.prefabDePiscina, base.transform);
			piscinaDeNpcsManager.Init(null, text, text, text, null);
			this.m_piscinasExistentes.Add(id, piscinaDeNpcsManager);
			this.m_piscinasExistentesList.Add(piscinaDeNpcsManager);
			return piscinaDeNpcsManager;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000302D File Offset: 0x0000122D
		[Obsolete("", true)]
		public PiscinaDeNpcsManager ObtenerPiscinaNotNull(string id)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003034 File Offset: 0x00001234
		[Obsolete("", true)]
		public PiscinaDeNpcsManager ObtenerPiscinaNotNull(Guid id)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000303B File Offset: 0x0000123B
		public bool ContieneEnMemoria(Guid id)
		{
			return this.contieneEnMemoria(id.ToString(), new Guid?(id));
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003058 File Offset: 0x00001258
		public bool ContieneEnMemoria(string id)
		{
			return this.contieneEnMemoria(id, null);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003078 File Offset: 0x00001278
		private bool contieneEnMemoria(string id, Guid? ID)
		{
			if (ID == null)
			{
				try
				{
					ID = new Guid?(Guid.Parse(id));
				}
				catch (Exception)
				{
					throw;
				}
			}
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Piscinas/Existentes/", false);
			if (jsonMemoryNode == null)
			{
				return false;
			}
			bool flag = jsonMemoryNode.FindChild(id) != null;
			bool flag2 = this.m_piscinasExistentes.ContainsKey(ID.Value);
			if (flag != flag2)
			{
				Debug.LogWarning("Piscina No existe en manager o en memoria", this);
			}
			return flag;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000030F4 File Offset: 0x000012F4
		public bool EsValida(PiscinaDeNpcsManager piscina)
		{
			Guid guid;
			try
			{
				guid = Guid.Parse(piscina.ID);
			}
			catch (Exception)
			{
				throw;
			}
			return this.m_piscinasExistentes.ContainsKey(guid) && this.EsValida(piscina.ID);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003140 File Offset: 0x00001340
		public bool EsValida(Guid id)
		{
			return this.esValida(id.ToString(), new Guid?(id));
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000315C File Offset: 0x0000135C
		public bool EsValida(string id)
		{
			return this.esValida(id, null);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000317C File Offset: 0x0000137C
		private bool esValida(string id, Guid? ID)
		{
			if (ID == null)
			{
				try
				{
					ID = new Guid?(Guid.Parse(id));
				}
				catch (Exception)
				{
					throw;
				}
			}
			if (!this.contieneEnMemoria(id, ID))
			{
				return false;
			}
			PiscinaDeNpcsManager piscinaDeNpcsManager = this.instanciarDesdeMemoria(ID.Value);
			return piscinaDeNpcsManager != null && piscinaDeNpcsManager.NPCsSonValidos();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000031E0 File Offset: 0x000013E0
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Print Piscinas en Memoria",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000031FC File Offset: 0x000013FC
		public override void Aplicar1()
		{
			base.Aplicar1();
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/Existentes/";
			foreach (IMemoryNode<string, string> memoryNode in GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false).children)
			{
				MonoBehaviour.print("Piscina Existente en memoria: " + memoryNode.nodeID);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000327C File Offset: 0x0000147C
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				text = "InstanciarNuevaPiscina",
				editorTimeVisible = false,
				confirmar = true
			};
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000329C File Offset: 0x0000149C
		public override void Aplicar2()
		{
			base.Aplicar2();
			this.CrearNuevaPiscina(10, null);
		}

		// Token: 0x0400000C RID: 12
		public const string rutaMemPiscinasExistentes = "root/Piscinas/Existentes/";

		// Token: 0x0400000D RID: 13
		public const string KEY_DATANAME = "KEY";

		// Token: 0x0400000E RID: 14
		public PiscinaDeNpcsManager prefabDePiscina;

		// Token: 0x0400000F RID: 15
		[Obsolete("", true)]
		public PiscinasDeNPCs.PiscinaConfig config = new PiscinasDeNPCs.PiscinaConfig();

		// Token: 0x04000010 RID: 16
		private Dictionary<Guid, PiscinaDeNpcsManager> m_piscinasExistentes = new Dictionary<Guid, PiscinaDeNpcsManager>();

		// Token: 0x04000011 RID: 17
		[ReadOnlyUI]
		[SerializeField]
		private List<PiscinaDeNpcsManager> m_piscinasExistentesList = new List<PiscinaDeNpcsManager>();

		// Token: 0x04000012 RID: 18
		[Obsolete("", true)]
		[NonSerialized]
		private bool m_loadingPiscinas;

		// Token: 0x04000013 RID: 19
		[Obsolete("", true)]
		private bool m_flagGuardarNuevasPiscinasEnMemoria = true;

		// Token: 0x02000080 RID: 128
		[Obsolete]
		[Serializable]
		public class PiscinaData
		{
		}

		// Token: 0x02000081 RID: 129
		[Obsolete("", true)]
		[Serializable]
		public class PiscinaConfig
		{
			// Token: 0x1700024E RID: 590
			// (get) Token: 0x060005F4 RID: 1524 RVA: 0x000163A7 File Offset: 0x000145A7
			public int count
			{
				get
				{
					return this.m_count;
				}
			}

			// Token: 0x04000276 RID: 630
			[SerializeField]
			[ReadOnlyUI]
			private int m_count = 10;
		}
	}
}
