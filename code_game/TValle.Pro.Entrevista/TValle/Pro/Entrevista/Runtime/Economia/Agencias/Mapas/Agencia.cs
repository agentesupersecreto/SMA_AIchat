using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas
{
	// Token: 0x020000D4 RID: 212
	[CreateAssetMenu(fileName = "Agencia", menuName = "Objetos/SMA/Agencia")]
	public class Agencia : AplicableScriptable
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0002D37E File Offset: 0x0002B57E
		public bool isValid
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.ID) && !string.IsNullOrWhiteSpace(this.nombre) && !string.IsNullOrWhiteSpace(this.descripcion) && this.RutasSonValidas();
			}
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0002D3B0 File Offset: 0x0002B5B0
		public bool RutasSonValidas()
		{
			try
			{
				for (int i = 0; i < this.requerimientos.Count; i++)
				{
					if (!Agencia.m_TempCheckRutasValidity.Add(this.requerimientos[i].rutaV2))
					{
						Debug.LogError("Ruta: " + this.requerimientos[i].rutaV2 + " ya existe, repetido en requerimientos");
						return false;
					}
				}
			}
			finally
			{
				Agencia.m_TempCheckRutasValidity.Clear();
			}
			try
			{
				for (int j = 0; j < this.antiRequerimientos.Count; j++)
				{
					if (!Agencia.m_TempCheckRutasValidity.Add(this.antiRequerimientos[j].rutaV2))
					{
						Debug.LogError("Ruta: " + this.antiRequerimientos[j].rutaV2 + " ya existe, repetido en anti-requerimientos");
						return false;
					}
				}
			}
			finally
			{
				Agencia.m_TempCheckRutasValidity.Clear();
			}
			try
			{
				for (int k = 0; k < this.bonuses.Count; k++)
				{
					if (!Agencia.m_TempCheckRutasValidity.Add(this.bonuses[k].rutaV2))
					{
						Debug.LogError("Ruta: " + this.bonuses[k].rutaV2 + " ya existe, repetido en bonuses");
						return false;
					}
				}
			}
			finally
			{
				Agencia.m_TempCheckRutasValidity.Clear();
			}
			try
			{
				for (int l = 0; l < this.antiBonuses.Count; l++)
				{
					if (!Agencia.m_TempCheckRutasValidity.Add(this.antiBonuses[l].rutaV2))
					{
						Debug.LogError("Ruta: " + this.antiBonuses[l].rutaV2 + " ya existe, repetido en anti-bonuses");
						return false;
					}
				}
			}
			finally
			{
				Agencia.m_TempCheckRutasValidity.Clear();
			}
			return true;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0002D5AC File Offset: 0x0002B7AC
		private void OnValidate()
		{
			this.incomeConfig.UpdateIncomeDebug();
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0002D5B9 File Offset: 0x0002B7B9
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Print Mensaje Modelo es Aceptada?"
			};
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0002D5D4 File Offset: 0x0002B7D4
		protected override void OnAplicar1()
		{
			if (!Singleton<CurrentTargetChar>.existeEnScena)
			{
				return;
			}
			Character character = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character;
			AgenciasHelper.Respuesta respuesta = null;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias/" + this.ID, true);
			AgenciasHelper.ModeloEsAceptadaPorAgencia(character, this, jsonMemoryNode, ref respuesta);
			Debug.Log(Singleton<OtrasAgencias>.instance.GetMsgModelo(this.ID, character.ID_Unico.ToString(), respuesta) + "\n");
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0002D650 File Offset: 0x0002B850
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Print Mensaje No Asistio"
			};
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0002D66C File Offset: 0x0002B86C
		protected override void OnAplicar2()
		{
			if (!Singleton<CurrentTargetChar>.existeEnScena)
			{
				return;
			}
			Character character = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character;
			Debug.Log(Singleton<OtrasAgencias>.instance.GetMsgModeloNoAsistio(this.ID, character.ID_Unico.ToString()) + "\n");
		}

		// Token: 0x04000476 RID: 1142
		public string ID;

		// Token: 0x04000477 RID: 1143
		public string nombre;

		// Token: 0x04000478 RID: 1144
		public bool blockeada;

		// Token: 0x04000479 RID: 1145
		public Interpretacion.Capacidad risk = Interpretacion.Capacidad.veryLow;

		// Token: 0x0400047A RID: 1146
		[TextArea(5, 10)]
		public string descripcion;

		// Token: 0x0400047B RID: 1147
		[Space]
		public Agencia.IncomeConfig incomeConfig = new Agencia.IncomeConfig();

		// Token: 0x0400047C RID: 1148
		[Space]
		public Agencia.Mensajes mensajes = new Agencia.Mensajes();

		// Token: 0x0400047D RID: 1149
		public Agencia.AI aI = new Agencia.AI();

		// Token: 0x0400047E RID: 1150
		public List<Agencia.Requerimiento> requerimientos = new List<Agencia.Requerimiento>();

		// Token: 0x0400047F RID: 1151
		public List<Agencia.AntiRequerimiento> antiRequerimientos = new List<Agencia.AntiRequerimiento>();

		// Token: 0x04000480 RID: 1152
		public List<Agencia.Bonus> bonuses = new List<Agencia.Bonus>();

		// Token: 0x04000481 RID: 1153
		public List<Agencia.Bonus> antiBonuses = new List<Agencia.Bonus>();

		// Token: 0x04000482 RID: 1154
		private static HashSet<string> m_TempCheckRutasValidity = new HashSet<string>();

		// Token: 0x02000265 RID: 613
		[Serializable]
		public class Mensajes
		{
			// Token: 0x04000B57 RID: 2903
			public Agencia.MensajesDeRequerimientoSingle unLocked;

			// Token: 0x04000B58 RID: 2904
			[Space]
			public Agencia.MensajesDeRequerimiento inicio;

			// Token: 0x04000B59 RID: 2905
			[Space]
			public Agencia.MensajesDeRequerimientoSingle cuerpoModeloNoAsistioEntrevista;

			// Token: 0x04000B5A RID: 2906
			public Agencia.MensajesDeRequerimientoSingle cuerpoSinRequerimientos;

			// Token: 0x04000B5B RID: 2907
			[Space]
			public Agencia.MensajesDeRequerimiento final;
		}

		// Token: 0x02000266 RID: 614
		[Serializable]
		public class Requerimiento : Agencia.RequerimientoBase
		{
			// Token: 0x04000B5C RID: 2908
			public Agencia.MensajesDeRequerimiento mensajesDeRequerimiento = new Agencia.MensajesDeRequerimiento();
		}

		// Token: 0x02000267 RID: 615
		[Serializable]
		public class AntiRequerimiento : Agencia.RequerimientoBase
		{
			// Token: 0x04000B5D RID: 2909
			public Agencia.MensajesDeRequerimientoSingle mensajesDeRequerimiento = new Agencia.MensajesDeRequerimientoSingle();
		}

		// Token: 0x02000268 RID: 616
		[Serializable]
		public class Bonus : Agencia.RequerimientoBase
		{
			// Token: 0x04000B5E RID: 2910
			public Agencia.MensajesDeRequerimientoSingle postMensajesAlDesblokear = new Agencia.MensajesDeRequerimientoSingle();

			// Token: 0x04000B5F RID: 2911
			public Agencia.MensajesDeRequerimientoSingle postMensajesDeBonus = new Agencia.MensajesDeRequerimientoSingle();
		}

		// Token: 0x02000269 RID: 617
		[Serializable]
		public class IncomeConfig
		{
			// Token: 0x170002E0 RID: 736
			// (get) Token: 0x0600112D RID: 4397 RVA: 0x00051374 File Offset: 0x0004F574
			public float defaultIncome
			{
				get
				{
					return 10000f * (Mathf.Clamp(this.incomePercentage, 0f, 100f) / 100f);
				}
			}

			// Token: 0x0600112E RID: 4398 RVA: 0x00051397 File Offset: 0x0004F597
			public void UpdateIncomeDebug()
			{
				this.m_incomeDebug = this.defaultIncome;
			}

			// Token: 0x04000B60 RID: 2912
			[SerializeField]
			[ReadOnlyUI]
			private float m_incomeDebug;

			// Token: 0x04000B61 RID: 2913
			[Range(0f, 100f)]
			public float incomePercentage = 0.1f;

			// Token: 0x04000B62 RID: 2914
			[Range(0f, 1f)]
			public int rewardTier = 1;

			// Token: 0x04000B63 RID: 2915
			[Range(1f, 10f)]
			public float bonusMod = 1.25f;

			// Token: 0x04000B64 RID: 2916
			[Range(0.01f, 1f)]
			public float antiBonusMod = 0.75f;
		}

		// Token: 0x0200026A RID: 618
		[Serializable]
		public class AI
		{
			// Token: 0x04000B65 RID: 2917
			public List<Agencia.AI.Par> equivalentes = new List<Agencia.AI.Par>();

			// Token: 0x020002FF RID: 767
			[Serializable]
			public class Par
			{
				// Token: 0x04000D6A RID: 3434
				public TipoDePersonaje tipoDePersonaje;

				// Token: 0x04000D6B RID: 3435
				public bool TipoDePersonajeEsPlural;

				// Token: 0x04000D6C RID: 3436
				public TipoDeEstimulo tipoDeEstimulo;

				// Token: 0x04000D6D RID: 3437
				public DireccionDeEstimulo direccion;

				// Token: 0x04000D6E RID: 3438
				public string tag;

				// Token: 0x04000D6F RID: 3439
				[Obsolete("reemplazada por lista", true)]
				[NonSerialized]
				public ParteDelCuerpoHumano estimulada;

				// Token: 0x04000D70 RID: 3440
				public ParteQuePuedeEstimular estimulante;

				// Token: 0x04000D71 RID: 3441
				public Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta;

				// Token: 0x04000D72 RID: 3442
				public List<ParteDelCuerpoHumano> estimuladas = new List<ParteDelCuerpoHumano>();
			}
		}

		// Token: 0x0200026B RID: 619
		public abstract class RequerimientoBase
		{
			// Token: 0x170002E1 RID: 737
			// (get) Token: 0x06001131 RID: 4401 RVA: 0x000513E8 File Offset: 0x0004F5E8
			public IReadOnlyList<string> rutaSeparada
			{
				get
				{
					if (this.m_rutaSeparada == null)
					{
						this.m_rutaSeparada = this.rutaV2.Split('.', StringSplitOptions.None);
					}
					return this.m_rutaSeparada;
				}
			}

			// Token: 0x04000B66 RID: 2918
			[NonSerialized]
			private string[] m_rutaSeparada;

			// Token: 0x04000B67 RID: 2919
			[InterpretacionFieldSelector]
			public string rutaV2;

			// Token: 0x04000B68 RID: 2920
			[InterpretacionFieldValueSelector(fieldDeRuta = "rutaV2")]
			public int valorPrimario;

			// Token: 0x04000B69 RID: 2921
			public bool usarValorSegundario;

			// Token: 0x04000B6A RID: 2922
			[InterpretacionFieldValueSelector(fieldDeRuta = "rutaV2")]
			public int valorSegundario;

			// Token: 0x04000B6B RID: 2923
			public bool usarValorTerciario;

			// Token: 0x04000B6C RID: 2924
			[InterpretacionFieldValueSelector(fieldDeRuta = "rutaV2")]
			public int valorTerciario;
		}

		// Token: 0x0200026C RID: 620
		[Serializable]
		public class MensajesDeRequerimiento
		{
			// Token: 0x04000B6D RID: 2925
			[TextArea(2, 5)]
			public string positivo;

			// Token: 0x04000B6E RID: 2926
			[TextArea(2, 5)]
			public string negativo;
		}

		// Token: 0x0200026D RID: 621
		[Serializable]
		public class MensajesDeRequerimientoSingle
		{
			// Token: 0x04000B6F RID: 2927
			[TextArea(2, 5)]
			public string msg;
		}
	}
}
