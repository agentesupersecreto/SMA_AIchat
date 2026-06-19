using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using InterfaceFields;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Genetica.Globales
{
	// Token: 0x02000003 RID: 3
	[Obsolete("Now on, ther will be only a single pool", true)]
	public class NPCsFinalesEsperandoPiscina : Singleton<NPCsFinalesEsperandoPiscina>, IPiscinaManagerDeSujetosBase<ISujetoIdentificableNpc>, IPiscinaManagerBase
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C3 File Offset: 0x000002C3
		public string ID
		{
			get
			{
				return "NPCsFinalesEsperandoPiscina";
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020CA File Offset: 0x000002CA
		public int count
		{
			get
			{
				return this.memoria.Count;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020D7 File Offset: 0x000002D7
		protected ISujetosNpcMemoriaDePiscina<ISujetoIdentificableNpc> memoria
		{
			get
			{
				return (ISujetosNpcMemoriaDePiscina<ISujetoIdentificableNpc>)this.m_memoriaDePiscina;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000006 RID: 6 RVA: 0x000020E4 File Offset: 0x000002E4
		// (remove) Token: 0x06000007 RID: 7 RVA: 0x0000211C File Offset: 0x0000031C
		[Obsolete("ahora se hace dequee a solo un sujeto")]
		public event Action<NPCsFinalesEsperandoPiscina, IReadOnlyList<ISujetoIdentificableNpc>, int> dequeuedOLD;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002151 File Offset: 0x00000351
		private ISujetoNpcProductor<ISujetoIdentificableNpc> productor
		{
			get
			{
				return this.m_productor as ISujetoNpcProductor<ISujetoIdentificableNpc>;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000215E File Offset: 0x0000035E
		private ISujetosNpcMemoria<ISujetoIdentificableNpc> memoriaDeSujetos
		{
			get
			{
				return this.m_memoriaDeSujetos as ISujetosNpcMemoria<ISujetoIdentificableNpc>;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000216B File Offset: 0x0000036B
		public int GetNivel()
		{
			return this.memoria.GetNivel(0);
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600000B RID: 11 RVA: 0x0000217C File Offset: 0x0000037C
		// (remove) Token: 0x0600000C RID: 12 RVA: 0x000021B4 File Offset: 0x000003B4
		public event NPCsFinalesEsperandoPiscina.CanLevelUpHandler canDoALevelUp;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600000D RID: 13 RVA: 0x000021EC File Offset: 0x000003EC
		// (remove) Token: 0x0600000E RID: 14 RVA: 0x00002224 File Offset: 0x00000424
		public event Action poolLeveledUp;

		// Token: 0x0600000F RID: 15 RVA: 0x00002259 File Offset: 0x00000459
		public void ObtenerNPCsIDs(List<string> resultado)
		{
			this.memoria.LeerSujetoIDsEnMemoria(resultado);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002267 File Offset: 0x00000467
		public int ObtenerCount()
		{
			return this.memoria.Count;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002274 File Offset: 0x00000474
		public bool Contiene(ISujetoIdentificableNpc npc)
		{
			string text = npc.NpcID.ToString();
			return this.memoria.Contiene(text);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022A4 File Offset: 0x000004A4
		[Obsolete("solo puede haber un sujeto por piscina id", true)]
		public void Enqueue(IReadOnlyList<ISujetoIdentificableNpc> sujetos, string fromPiscinaID, bool destruirInstanciasAlTerminar)
		{
			for (int i = 0; i < sujetos.Count; i++)
			{
				ISujetoIdentificableNpc sujetoIdentificableNpc = sujetos[i];
				this.Enqueue(sujetoIdentificableNpc, fromPiscinaID, destruirInstanciasAlTerminar);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022D4 File Offset: 0x000004D4
		public void Enqueue(ISujetoIdentificableNpc sujeto, string fromPiscinaID, bool destruirInstanciasAlTerminar)
		{
			try
			{
				while (this.Dequeue(fromPiscinaID) != null)
				{
				}
			}
			catch (Exception)
			{
				throw;
			}
			try
			{
				if (string.IsNullOrWhiteSpace(fromPiscinaID))
				{
					throw new NotSupportedException();
				}
				if (sujeto == null)
				{
					Debug.LogWarning("No se pudo añadir sujeto a " + base.GetType().Name + ". sujeto es nullo", this);
				}
				else if (sujeto as Object == null)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"No se pudo añadir sujeto: ",
						sujeto.NpcID.ToString(),
						" a ",
						base.GetType().Name,
						". sujeto no es unity.object"
					}), this);
				}
				else
				{
					string text = sujeto.NpcID.ToString();
					if (this.memoria.Contiene(text))
					{
						Debug.LogWarning("Esperando Npc ya contiene Npc: " + text, this);
					}
					else
					{
						if (!this.memoriaDeSujetos.EsValido(text))
						{
							this.memoriaDeSujetos.EscribirSujetoEnMemoria(text, sujeto);
							if (!this.memoriaDeSujetos.EsValido(text))
							{
								Debug.LogError("Esperando Npc , no puede añadir Npc: " + text + ". es invalido", this);
								this.memoriaDeSujetos.BorrarSujetoDeLaMemoria(text, false);
								return;
							}
						}
						sujeto.dataContainer.AddData("NPCsFinalesDePiscina", fromPiscinaID, true);
						this.memoria.PonerEnMemoriaDePiscina(sujeto);
						this.memoriaDeSujetos.Escribir_DATA_DeNpcAMemoria(sujeto.NpcID.ToString(), sujeto);
						this.LevelUp();
					}
				}
			}
			finally
			{
				if (destruirInstanciasAlTerminar)
				{
					sujeto.Destruir();
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002494 File Offset: 0x00000694
		public void LevelUp()
		{
			bool flag = true;
			NPCsFinalesEsperandoPiscina.CanLevelUpHandler canLevelUpHandler = this.canDoALevelUp;
			if (canLevelUpHandler != null)
			{
				canLevelUpHandler(ref flag, this);
			}
			if (flag)
			{
				this.memoria.AddNivel(1);
				Action action = this.poolLeveledUp;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000024D8 File Offset: 0x000006D8
		public ISujetoIdentificableNpc Peek(string fromPiscinaID)
		{
			List<string> list = new List<string>();
			this.memoria.LeerSujetoIDsEnMemoria(list);
			ISujetoIdentificableNpc sujetoIdentificableNpc = null;
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i];
				if (this.memoriaDeSujetos.LeerData(text, "NPCsFinalesDePiscina") == fromPiscinaID)
				{
					if (!this.memoriaDeSujetos.EsValido(text))
					{
						Debug.LogError("Esperando Npc , contiene Npc invalido: " + text + ". se borrara de la memoria", this);
						this.memoria.QuitarDeMemoriaDePiscina(text);
					}
					else
					{
						try
						{
							sujetoIdentificableNpc = this.memoria.LeerSujetoEnMemoria(text);
						}
						catch (Exception ex)
						{
							Debug.LogError("Error reading Npc " + text + " from memory", this);
							throw ex;
						}
					}
				}
			}
			if (sujetoIdentificableNpc == null)
			{
				return null;
			}
			Debug.Log("Se encontro Npc finalista de evento id: " + fromPiscinaID + ". sujeto: " + sujetoIdentificableNpc.NpcID.ToString(), this);
			return sujetoIdentificableNpc;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000025C8 File Offset: 0x000007C8
		public ISujetoIdentificableNpc Dequeue(string fromPiscinaID)
		{
			ISujetoIdentificableNpc sujetoIdentificableNpc = this.Peek(fromPiscinaID);
			if (sujetoIdentificableNpc == null)
			{
				return null;
			}
			this.memoria.QuitarDeMemoriaDePiscina(sujetoIdentificableNpc.NpcID.ToString());
			return sujetoIdentificableNpc;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002604 File Offset: 0x00000804
		[Obsolete("ya no se necesita hacer Dequeue en lista", true)]
		public void Dequeue(IList<ISujetoIdentificableNpc> result, int count)
		{
			int num = this.ObtenerCount();
			if (count > num)
			{
				throw new InvalidOperationException();
			}
			List<string> list = new List<string>();
			this.memoria.LeerSujetoIDsEnMemoria(list);
			list.Shuffle<string>();
			int num2 = count;
			List<ISujetoIdentificableNpc> list2 = new List<ISujetoIdentificableNpc>(count);
			for (int i = 0; i < num2; i++)
			{
				string text = list[i];
				if (!this.memoriaDeSujetos.EsValido(text))
				{
					Debug.LogError("Esperando Npc , contiene Npc invalido: " + text + ". se borrara de la memoria", this);
					this.memoria.QuitarDeMemoriaDePiscina(text);
					num2 = Mathf.Min(num, num2 + 1);
				}
				else
				{
					string text2 = list[i];
					ISujetoIdentificableNpc sujetoIdentificableNpc;
					try
					{
						sujetoIdentificableNpc = this.memoria.LeerSujetoEnMemoria(text2);
					}
					catch (Exception ex)
					{
						Debug.LogError("Error reading Npc " + text2 + " from memory", this);
						throw ex;
					}
					if (string.IsNullOrWhiteSpace(sujetoIdentificableNpc.dataContainer.FindData("NPCsFinalesDePiscina")))
					{
						Debug.LogError("Finalista: " + sujetoIdentificableNpc.NpcID.ToString() + " no tiene data de piscina finalista de", this);
					}
					list2.Add(sujetoIdentificableNpc);
				}
			}
			if (list2.Count < count)
			{
				while (list2.Count < count)
				{
					Debug.LogError("Creando NPC desde finaliztas, esto No deberia ocurrir", this);
					list2.Add(this.productor.ProducirSujetoNpc(false));
				}
			}
			this.memoria.QuitarDeMemoriaDePiscina(list2);
			for (int j = 0; j < list2.Count; j++)
			{
				result.Add(list2[j]);
			}
			bool flag = true;
			NPCsFinalesEsperandoPiscina.CanLevelUpHandler canLevelUpHandler = this.canDoALevelUp;
			if (canLevelUpHandler != null)
			{
				canLevelUpHandler(ref flag, this);
			}
			if (flag)
			{
				this.memoria.AddNivel(1);
			}
			Action<NPCsFinalesEsperandoPiscina, IReadOnlyList<ISujetoIdentificableNpc>, int> action = this.dequeuedOLD;
			if (action == null)
			{
				return;
			}
			action(this, result as IReadOnlyList<ISujetoIdentificableNpc>, count);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000027D0 File Offset: 0x000009D0
		public void ObtenerTodosLosSujetos(IList<ISujetoIdentificableNpc> sujetosResultado)
		{
			Debug.LogWarning("Metodo Costoso, no usar", this);
			this.memoria.LeerSujetosEnMemoria(sujetosResultado, int.MaxValue);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000027F0 File Offset: 0x000009F0
		public ISujetoIdentificableNpc ObtenerSujeto(Guid sujetoID)
		{
			Debug.LogWarning("Metodo Costoso, no usar", this);
			List<ISujetoIdentificableNpc> list = new List<ISujetoIdentificableNpc>();
			this.ObtenerTodosLosSujetos(list);
			for (int i = 0; i < list.Count; i++)
			{
				ISujetoIdentificableNpc sujetoIdentificableNpc = list[i];
				if (sujetoIdentificableNpc != null && sujetoIdentificableNpc.NpcID == sujetoID)
				{
					return sujetoIdentificableNpc;
				}
			}
			return null;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002844 File Offset: 0x00000A44
		protected override void Initiating()
		{
			base.Initiating();
			if (this.m_productor == null)
			{
				this.m_productor = base.GetComponent<ISujetoNpcProductor<ISujetoIdentificableNpc>>() as Object;
				if (this.m_productor == null)
				{
					throw new ArgumentNullException("m_productor", "m_productor null reference.");
				}
			}
			if (this.m_memoriaDeSujetos == null)
			{
				this.m_memoriaDeSujetos = base.GetComponent<ISujetosNpcMemoria<ISujetoIdentificableNpc>>() as Object;
				if (this.m_memoriaDeSujetos == null)
				{
					throw new ArgumentNullException("m_memoriaDeSujetos", "m_memoriaDeSujetos null reference.");
				}
			}
			if (this.m_memoriaDePiscina == null)
			{
				this.m_memoriaDePiscina = base.GetComponent<ISujetosNpcMemoriaDePiscina<ISujetoIdentificableNpc>>() as Object;
				if (this.m_memoriaDePiscina == null)
				{
					throw new ArgumentNullException("m_memoriaDePiscina", "m_memoriaDePiscina null reference.");
				}
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000290E File Offset: 0x00000B0E
		protected override void InitData(bool esEditorTime)
		{
			if (!esEditorTime)
			{
				this.memoria.Init();
				this.productor.Init();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000292C File Offset: 0x00000B2C
		public bool Diferentes()
		{
			if (this.count == 0)
			{
				throw new NotSupportedException();
			}
			bool flag = false;
			List<string> list = new List<string>();
			this.ObtenerNPCsIDs(list);
			list.CheckColisionASC(NPCsFinalesEsperandoPiscina.isCollisionDelegate, NPCsFinalesEsperandoPiscina.onCollisionDelegate, ref flag);
			return !flag;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000296C File Offset: 0x00000B6C
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				editorTimeVisible = false,
				text = "Visualizar Sujetos Esperando"
			};
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002988 File Offset: 0x00000B88
		public override void Aplicar1()
		{
			base.Aplicar1();
			List<ISujetoIdentificableNpc> list = this.memoria.LeerSujetosEnMemoria(int.MaxValue);
			this.m_sujetosDebug = list.Cast<Object>().ToList<Object>();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000029BD File Offset: 0x00000BBD
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				editorTimeVisible = false,
				text = "Dejar de Visualizar Sujetos Esperando"
			};
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000029D6 File Offset: 0x00000BD6
		public override void Aplicar2()
		{
			base.Aplicar2();
			this.m_sujetosDebug.ForEach(delegate(Object t)
			{
				((ISujetoIdentificableNpc)t).Destruir();
			});
			this.m_sujetosDebug.Clear();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002A13 File Offset: 0x00000C13
		public override SingletonEditorBotones Boton3()
		{
			return new SingletonEditorBotones
			{
				confirmar = true,
				text = "Inyectar Aleatorio",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002A34 File Offset: 0x00000C34
		public override void Aplicar3()
		{
			base.Aplicar3();
			ISujetoIdentificableNpc sujetoIdentificableNpc = this.productor.ProducirSujetoNpc(false);
			this.memoriaDeSujetos.EscribirSujetoEnMemoria(sujetoIdentificableNpc.NpcID.ToString(), sujetoIdentificableNpc);
			this.Enqueue(sujetoIdentificableNpc, typeof(DayOfWeek).GetEnumRandom().ToString(), true);
		}

		// Token: 0x04000001 RID: 1
		public const string piscinaID = "NPCsFinalesEsperandoPiscina";

		// Token: 0x04000002 RID: 2
		public const string finalistaDePiscinaID = "NPCsFinalesDePiscina";

		// Token: 0x04000003 RID: 3
		[SerializeField]
		[ConstraintType(typeof(ISujetosNpcMemoriaDePiscina<ISujetoIdentificableNpc>), true)]
		private Object m_memoriaDePiscina;

		// Token: 0x04000005 RID: 5
		[ConstraintType(typeof(ISujetoNpcProductor<ISujetoIdentificableNpc>), true)]
		[SerializeField]
		private Object m_productor;

		// Token: 0x04000006 RID: 6
		[ConstraintType(typeof(ISujetosNpcMemoria<ISujetoIdentificableNpc>), true)]
		[SerializeField]
		private Object m_memoriaDeSujetos;

		// Token: 0x04000007 RID: 7
		[ConstraintType(typeof(ISujetoIdentificableNpc), true)]
		[SerializeField]
		private List<Object> m_sujetosDebug = new List<Object>();

		// Token: 0x0400000A RID: 10
		private static readonly Func<string, string, bool> isCollisionDelegate = (string a, string b) => a == b;

		// Token: 0x0400000B RID: 11
		private static readonly ListColisionesEXT.OnListCollisionHandler<string, bool> onCollisionDelegate = delegate(string a, string b, ref bool r)
		{
			r = true;
		};

		// Token: 0x0200007E RID: 126
		// (Invoke) Token: 0x060005EB RID: 1515
		public delegate void CanLevelUpHandler(ref bool canlevelUp, NPCsFinalesEsperandoPiscina sender);
	}
}
