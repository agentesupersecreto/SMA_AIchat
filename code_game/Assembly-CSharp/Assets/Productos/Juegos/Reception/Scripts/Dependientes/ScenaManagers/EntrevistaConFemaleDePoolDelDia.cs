using System;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Tiempo.Runtime.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.Globales;
using InterfaceFields;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000BC RID: 188
	[Obsolete("", true)]
	public sealed class EntrevistaConFemaleDePoolDelDia : ScenaConFemaleCharFromPoolDelDia, IUsadoListener
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x0001514D File Offset: 0x0001334D
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00015154 File Offset: 0x00013354
		public IUsable door
		{
			get
			{
				return this.m_door as IUsable;
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00015164 File Offset: 0x00013364
		protected override void OnAwake()
		{
			base.OnAwake();
			if (this.door == null)
			{
				throw new ArgumentNullException("door", "door null reference.");
			}
			if (this.m_panelDeCalificacion == null)
			{
				throw new ArgumentNullException("m_panelDeCalificacion", "m_panelDeCalificacion null reference.");
			}
			this.m_callback = this.door.gameObject.AddComponent<UsableCallback>();
			this.m_callback.Init(this);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000151CF File Offset: 0x000133CF
		protected override void OnDestroyed()
		{
			base.OnDestroyed();
			if (this.m_callback)
			{
				Object.Destroy(this.m_callback);
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x000151EF File Offset: 0x000133EF
		public override void OnUpdateEvent1()
		{
			base.OnUpdateEvent1();
			this.door.puedeUsarse = this.m_panelDeCalificacion.isBinded;
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0001520D File Offset: 0x0001340D
		public StringKeyFloatValueDictionary flagScoreAparienciaCurrentFemaleV2
		{
			get
			{
				return Singleton<PiscinaDeCampaingActual>.instance.flagScoreAparienciaCurrentFemaleV2;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x00015219 File Offset: 0x00013419
		public StringKeyFloatValueDictionary flagScorePersonalidadCurrentFemaleV2
		{
			get
			{
				return Singleton<PiscinaDeCampaingActual>.instance.flagScorePersonalidadCurrentFemaleV2;
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00015228 File Offset: 0x00013428
		public void CalificarCurrentFemale()
		{
			if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
			{
				Debug.LogError("No se pudo calificar Char: " + base.currentFemaleCharacter.ID_Unico.ToString() + ", por q piscina Campaing no existe", this);
				return;
			}
			Guid id_Unico = base.currentFemaleCharacter.ID_Unico;
			Singleton<PiscinaDeCampaingActual>.instance.SetFemaleRate(id_Unico);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00015284 File Offset: 0x00013484
		public void CurrentFemaleWasInterviewed()
		{
			if (!Singleton<PiscinaDeCampaingActual>.IsInScene)
			{
				Debug.LogError("No se pudo calificar Char: " + base.currentFemaleCharacter.ID_Unico.ToString() + ", por q piscina Campaing no existe", this);
				return;
			}
			Guid id_Unico = base.currentFemaleCharacter.ID_Unico;
			Singleton<PiscinaDeCampaingActual>.instance.SetFemaleAsInterviewed(id_Unico);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x000152DE File Offset: 0x000134DE
		void IUsadoListener.OnUsado(IUsable usado, Transform por)
		{
			if (usado == this.door)
			{
				Debug.Log("saliendo");
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x000152F3 File Offset: 0x000134F3
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			if (this.flagScoreAparienciaCurrentFemaleV2.Count == 0 || this.flagScorePersonalidadCurrentFemaleV2.Count == 0)
			{
				return null;
			}
			return new CustomMonobehaviourBotonConfig
			{
				text = "Calificar",
				editorTimeVisible = false,
				confirmar = true
			};
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0001532F File Offset: 0x0001352F
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			this.CalificarCurrentFemale();
		}

		// Token: 0x040001E3 RID: 483
		[Header("-> Entrevista Calificable Con Female Character <-")]
		[SerializeField]
		[ConstraintType(typeof(IUsable))]
		private Object m_door;

		// Token: 0x040001E4 RID: 484
		[SerializeField]
		private PanelDeEntrevistaCalificacion m_panelDeCalificacion;

		// Token: 0x040001E5 RID: 485
		private UsableCallback m_callback;
	}
}
