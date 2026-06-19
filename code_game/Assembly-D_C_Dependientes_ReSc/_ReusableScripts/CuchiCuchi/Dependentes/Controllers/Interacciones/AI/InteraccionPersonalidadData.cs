using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Interacciones;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D6 RID: 470
	[RequireComponent(typeof(Interaccion))]
	[RequireComponent(typeof(PoseQueExponePartes))]
	public class InteraccionPersonalidadData : CustomMonobehaviour, IPartesExpuestaDeInteraccion
	{
		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000B20 RID: 2848 RVA: 0x00037054 File Offset: 0x00035254
		[Obsolete("", true)]
		public IReadOnlyList<ParteDelCuerpoHumano> expone
		{
			get
			{
				return this.m_expone;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x00004F84 File Offset: 0x00003184
		[Obsolete("", true)]
		public IReadOnlyCollection<int> exponeSet
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000B22 RID: 2850 RVA: 0x0003705C File Offset: 0x0003525C
		// (set) Token: 0x06000B23 RID: 2851 RVA: 0x00037064 File Offset: 0x00035264
		bool IPartesExpuestaDeInteraccion.usarEspuestasCalculadas
		{
			get
			{
				return this.usarEspuestasCalculadas;
			}
			set
			{
				this.usarEspuestasCalculadas = value;
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00037070 File Offset: 0x00035270
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PoseQueExponePartes = base.GetComponent<PoseQueExponePartes>();
			this.m_interaccion = base.GetComponent<InteraccionPrimariaBase>();
			if (this.m_interaccion.owner == null)
			{
				this.m_interaccion.addedTo += this.M_interaccion_addedTo;
				base.SetInicializable();
				base.SetManualStart();
			}
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x000370CB File Offset: 0x000352CB
		private void M_interaccion_addedTo(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			base.Initialize();
			base.ManualStart();
			this.m_interaccion.addedTo -= this.M_interaccion_addedTo;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x000370F0 File Offset: 0x000352F0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			IInteraccionesDeCharacter owner = this.m_interaccion.owner;
			IRopaManager ropaManager;
			if (owner == null)
			{
				ropaManager = null;
			}
			else
			{
				ICharacter character = owner.character;
				ropaManager = ((character != null) ? character.GetComponentEnRoot<IRopaManager>() : null);
			}
			this.m_ropaManager = ropaManager;
			if (this.m_ropaManager == null)
			{
				throw new ArgumentNullException("m_ropaManager", "m_ropaManager null reference.");
			}
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00037144 File Offset: 0x00035344
		public float ObtenerDificultadDeTipoDePersonalidad(Personalidad.Tipo tipo)
		{
			InteraccionPersonalidadData.ParPerTipoDificultad parPerTipoDificultad = this.m_dificultadSegunTipoDePersonalidadV2.FirstOrDefault((InteraccionPersonalidadData.ParPerTipoDificultad i) => ((int)i.tipo).HasFlag((int)tipo));
			if (parPerTipoDificultad == null)
			{
				return this.m_consentMod;
			}
			return parPerTipoDificultad.consentMod * this.m_consentMod;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0003718D File Offset: 0x0003538D
		public void ReemplazarPartesExponiendo(IReadOnlyList<ParteDelCuerpoHumano> exponiendoNuevas)
		{
			this.m_expone.Clear();
			if (exponiendoNuevas != null)
			{
				this.m_expone.AddRange(exponiendoNuevas);
			}
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x000371AC File Offset: 0x000353AC
		public void ObtenerExponiendoPartes(out IReadOnlyList<ParteDelCuerpoHumano> exponiendo, ParteDelCuerpoHumano? defaultParte = null)
		{
			IReadOnlyCollection<int> readOnlyCollection;
			this.ObtenerExponiendoPartes(out exponiendo, out readOnlyCollection, defaultParte);
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x000371C4 File Offset: 0x000353C4
		public void ObtenerExponiendoPartes(out IReadOnlyList<ParteDelCuerpoHumano> exponiendo, out IReadOnlyCollection<int> exponiendoSet, ParteDelCuerpoHumano? defaultParte = null)
		{
			if (!base.isStared)
			{
				throw new InvalidOperationException();
			}
			this.m_exponeCalculed.Clear();
			this.m_exponeCalculedSet.Clear();
			this.m_ropaManager.TransferirCorregiendoPartesExpuestasSiEstanVestidas(this.m_expone, this.m_exponeCalculed, this.m_exponeCalculedSet);
			if (this.usarEspuestasCalculadas)
			{
				this.m_PoseQueExponePartes.UpdateCurrentExposingPartes();
				this.m_ropaManager.TransferirCorregiendoPartesExpuestasSiEstanVestidas(this.m_PoseQueExponePartes.exponiendoPartes, this.m_exponeCalculed, this.m_exponeCalculedSet);
			}
			exponiendo = this.m_exponeCalculed;
			exponiendoSet = this.m_exponeCalculedSet;
			if (defaultParte != null && this.m_exponeCalculedSet.Count == 0)
			{
				this.m_exponeCalculed.Add(defaultParte.Value);
				this.m_exponeCalculedSet.Add((int)defaultParte.Value);
			}
		}

		// Token: 0x04000865 RID: 2149
		public bool usarEspuestasCalculadas;

		// Token: 0x04000866 RID: 2150
		[SerializeField]
		[Tooltip("Dificultad")]
		private float m_consentMod = 1f;

		// Token: 0x04000867 RID: 2151
		[SerializeField]
		[Tooltip("Dificultad especifica de tipo de personalidad")]
		private List<InteraccionPersonalidadData.ParPerTipoDificultad> m_dificultadSegunTipoDePersonalidadV2 = new List<InteraccionPersonalidadData.ParPerTipoDificultad>
		{
			new InteraccionPersonalidadData.ParPerTipoDificultad
			{
				consentMod = 0.9f,
				tipo = (Personalidad.Tipo.sumiso | Personalidad.Tipo.pervertido | Personalidad.Tipo.exhibicionista)
			},
			new InteraccionPersonalidadData.ParPerTipoDificultad
			{
				consentMod = 1.1f,
				tipo = (Personalidad.Tipo.timido | Personalidad.Tipo.respetuoso | Personalidad.Tipo.grosero)
			}
		};

		// Token: 0x04000868 RID: 2152
		[Header("no modificar en run-time")]
		[SerializeField]
		[CoolArrayItem]
		private List<ParteDelCuerpoHumano> m_expone = new List<ParteDelCuerpoHumano>();

		// Token: 0x04000869 RID: 2153
		[NonSerialized]
		private List<ParteDelCuerpoHumano> m_exponeCalculed = new List<ParteDelCuerpoHumano>();

		// Token: 0x0400086A RID: 2154
		[NonSerialized]
		private HashSet<int> m_exponeCalculedSet = new HashSet<int>();

		// Token: 0x0400086B RID: 2155
		private PoseQueExponePartes m_PoseQueExponePartes;

		// Token: 0x0400086C RID: 2156
		private IRopaManager m_ropaManager;

		// Token: 0x0400086D RID: 2157
		private Interaccion m_interaccion;

		// Token: 0x020001D7 RID: 471
		[Serializable]
		internal class ParPerTipoDificultad
		{
			// Token: 0x0400086E RID: 2158
			public Personalidad.Tipo tipo;

			// Token: 0x0400086F RID: 2159
			[SerializeField]
			[Tooltip("Dificultad")]
			public float consentMod = 1f;
		}
	}
}
