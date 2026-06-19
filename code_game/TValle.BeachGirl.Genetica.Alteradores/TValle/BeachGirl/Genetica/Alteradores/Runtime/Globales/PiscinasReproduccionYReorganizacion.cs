using System;
using System.Collections.Generic;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Genetica.NPCs;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Globales
{
	// Token: 0x0200005C RID: 92
	public class PiscinasReproduccionYReorganizacion : Singleton<PiscinasReproduccionYReorganizacion>
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600044E RID: 1102 RVA: 0x0001004C File Offset: 0x0000E24C
		// (remove) Token: 0x0600044F RID: 1103 RVA: 0x00010084 File Offset: 0x0000E284
		public event Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager> reproducing;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000450 RID: 1104 RVA: 0x000100BC File Offset: 0x0000E2BC
		// (remove) Token: 0x06000451 RID: 1105 RVA: 0x000100F4 File Offset: 0x0000E2F4
		public event Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager> reproduced;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000452 RID: 1106 RVA: 0x0001012C File Offset: 0x0000E32C
		// (remove) Token: 0x06000453 RID: 1107 RVA: 0x00010164 File Offset: 0x0000E364
		public event Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager> culminando;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000454 RID: 1108 RVA: 0x0001019C File Offset: 0x0000E39C
		// (remove) Token: 0x06000455 RID: 1109 RVA: 0x000101D4 File Offset: 0x0000E3D4
		public event Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager, IReadOnlyList<ISujetoIdentificableNpc>> culminada;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000456 RID: 1110 RVA: 0x0001020C File Offset: 0x0000E40C
		// (remove) Token: 0x06000457 RID: 1111 RVA: 0x00010244 File Offset: 0x0000E444
		[Obsolete("ya no se usan super piscinas", true)]
		public event Action<PiscinasReproduccionYReorganizacion> evolving;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000458 RID: 1112 RVA: 0x0001027C File Offset: 0x0000E47C
		// (remove) Token: 0x06000459 RID: 1113 RVA: 0x000102B4 File Offset: 0x0000E4B4
		[Obsolete("ya no se usan super piscinas", true)]
		public event Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager, IReadOnlyList<ISujetoIdentificableNpc>> evolved;

		// Token: 0x0600045A RID: 1114 RVA: 0x000102EC File Offset: 0x0000E4EC
		public void CheckReproduccionYReorganizacion(Func<string, string> piscinaID_A_piscinaKey)
		{
			Debug.Log("****CheckReproduccionYReorganizacion()", this);
			try
			{
				Debug.Log("-Checking Pools", this);
				foreach (PiscinaDeNpcsManager piscinaDeNpcsManager in ((IEnumerable<PiscinaDeNpcsManager>)Singleton<PiscinasDeNPCs>.instance))
				{
					Debug.Log("  ->" + piscinaDeNpcsManager.name, this);
					if (piscinaDeNpcsManager.SujetosHanSidoRated())
					{
						Debug.Log("        ALL HEAD GROUPDS INTERVIEWED.", this);
						Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager> action = this.reproducing;
						if (action != null)
						{
							action(this, piscinaDeNpcsManager);
						}
						if (this.AllowReproduction)
						{
							Debug.Log("        REPRODUCING.", this);
							piscinaDeNpcsManager.Reproducir();
							Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager> action2 = this.reproduced;
							if (action2 != null)
							{
								action2(this, piscinaDeNpcsManager);
							}
							Debug.Log("        REPRODUCED.", this);
						}
						else
						{
							Debug.Log("        Reproduction is not alowed.", this);
						}
					}
					int num = 1;
					num = Mathf.Max(1, num);
					if (piscinaDeNpcsManager.gruposCount <= num)
					{
						Debug.Log("        THIS POOL IS OVER.(max groupds count: " + num.ToString() + ")", this);
						Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager> action3 = this.culminando;
						if (action3 != null)
						{
							action3(this, piscinaDeNpcsManager);
						}
						if (this.AllowCulmination)
						{
							List<ISujetoIdentificableNpc> list = new List<ISujetoIdentificableNpc>(piscinaDeNpcsManager.gruposCount);
							piscinaDeNpcsManager.LoadSujetosPrincipalesDeGruposPorApariencia(list);
							piscinaDeNpcsManager.memoriaDePiscina.QuitarDeMemoriaDePiscina(list);
							Debug.Log("        sending evolved NPCs to Queue", this);
							Action<PiscinasReproduccionYReorganizacion, PiscinaDeNpcsManager, IReadOnlyList<ISujetoIdentificableNpc>> action4 = this.culminada;
							if (action4 != null)
							{
								action4(this, piscinaDeNpcsManager, list);
							}
							list.ForEach(delegate(ISujetoIdentificableNpc s)
							{
								s.Destruir();
							});
							this.m_piscinasABorrar_TEMP.Add(piscinaDeNpcsManager);
							Debug.Log("        THIS POOL IS BEING DESTROYING.", this);
						}
						else
						{
							Debug.Log("        Culmination is not alowed.", this);
						}
					}
				}
				Debug.Log("-Destroying Pools", this);
				foreach (PiscinaDeNpcsManager piscinaDeNpcsManager2 in this.m_piscinasABorrar_TEMP)
				{
					Debug.Log("    " + piscinaDeNpcsManager2.name, this);
					Singleton<PiscinasDeNPCs>.instance.BorrarCompletamentePiscina(piscinaDeNpcsManager2);
					Debug.Log("        THIS POOL IS DESTROYED.", this);
				}
				Debug.Log("-Checking evolved NPCs Queue", this);
				Action<PiscinasReproduccionYReorganizacion> action5 = this.evolving;
				if (action5 != null)
				{
					action5(this);
				}
				if (this.AllowEvolvedPools)
				{
					throw new NotSupportedException("ya no se crea una super piscina, ahora se reusan los grupos finalistas para hacer retro alimentacion");
				}
				Debug.Log("    EvolvedPools is not alowed.", this);
			}
			catch (Exception ex)
			{
				Debug.LogError("ERROR: CheckReproduccionYReorganizacion()", this);
				throw ex;
			}
			finally
			{
				this.m_piscinasABorrar_TEMP.Clear();
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000105B4 File Offset: 0x0000E7B4
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				confirmar = true,
				text = "Reproducir/Reorganizar",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x000105D4 File Offset: 0x0000E7D4
		public override void Aplicar2()
		{
			base.Aplicar2();
			this.CheckReproduccionYReorganizacion(null);
		}

		// Token: 0x040001EC RID: 492
		public bool AllowReproduction = true;

		// Token: 0x040001ED RID: 493
		public bool AllowCulmination = true;

		// Token: 0x040001EE RID: 494
		[NonSerialized]
		public readonly bool AllowEvolvedPools;

		// Token: 0x040001EF RID: 495
		private List<PiscinaDeNpcsManager> m_piscinasABorrar_TEMP = new List<PiscinaDeNpcsManager>();
	}
}
