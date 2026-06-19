using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E8 RID: 1000
	[Serializable]
	public struct CambioDePoseData
	{
		// Token: 0x060015D1 RID: 5585 RVA: 0x0005B9C0 File Offset: 0x00059BC0
		public CambioDePoseData(Character PorCharacter, bool UnaSolaVez, int PoseID, Transform Estimulado, bool FueConsentimiento, bool EjecutarAnimacionForzando, bool CambiaPoseActual, bool TryUsarTransicion, float? VelocidadDeCambio, ParteQuePuedeEstimular Estimulante, IReadOnlyList<ParteDelCuerpoHumano> ReferenciaDeExponiendoPartes, IReadOnlyCollection<int> ReferenciaDeExponiendoPartesSet)
		{
			if (PorCharacter == null)
			{
				throw new ArgumentNullException("PorCharacter", "PorCharacter null reference.");
			}
			if (Estimulado == null)
			{
				throw new ArgumentNullException("Estimulado", "Estimulado null reference.");
			}
			if (ReferenciaDeExponiendoPartes.Count == 0)
			{
				throw new InvalidOperationException("ReferenciaDeExponiendoPartes count 0.");
			}
			if (ReferenciaDeExponiendoPartesSet.Count != ReferenciaDeExponiendoPartes.Count)
			{
				Debug.LogError("Cantidad de partes expuestas no es la misma entre Set y Lista");
			}
			if (PoseID == 0)
			{
				throw new InvalidOperationException("Pose id no puede ser zero");
			}
			this.m_referenciaDeExponiendoPartesSet = ReferenciaDeExponiendoPartesSet;
			this.m_referenciaDeExponiendoPartes = ReferenciaDeExponiendoPartes;
			this.m_ejecutarAnimacionForzando = EjecutarAnimacionForzando;
			this.m_fueConsentido_O_Obligado = FueConsentimiento;
			this.m_unaSolaVez = UnaSolaVez;
			this.m_transformEstimulado = Estimulado;
			this.m_por = PorCharacter;
			this.m_poseID = PoseID;
			this.m_cambiaPoseActual = CambiaPoseActual;
			this.m_estimulante = Estimulante;
			this.m_tryUsarTransicion = TryUsarTransicion;
			this.m_CambioConVelocidad = VelocidadDeCambio != null;
			this.m_VelocidadDeCambio = VelocidadDeCambio.GetValueOrDefault();
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x060015D2 RID: 5586 RVA: 0x0005BAAB File Offset: 0x00059CAB
		public bool unaSolaVez
		{
			get
			{
				return this.m_unaSolaVez;
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x060015D3 RID: 5587 RVA: 0x0005BAB3 File Offset: 0x00059CB3
		public ParteQuePuedeEstimular estimulante
		{
			get
			{
				return this.m_estimulante;
			}
		}

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x060015D4 RID: 5588 RVA: 0x0005BABB File Offset: 0x00059CBB
		public Character por
		{
			get
			{
				return this.m_por;
			}
		}

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x060015D5 RID: 5589 RVA: 0x0005BAC3 File Offset: 0x00059CC3
		public int poseID
		{
			get
			{
				return this.m_poseID;
			}
		}

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x060015D6 RID: 5590 RVA: 0x0005BACB File Offset: 0x00059CCB
		public Transform transformEstimulado
		{
			get
			{
				return this.m_transformEstimulado;
			}
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x060015D7 RID: 5591 RVA: 0x0005BAD3 File Offset: 0x00059CD3
		public IReadOnlyCollection<int> referenciaDeExponiendoPartesSet
		{
			get
			{
				return this.m_referenciaDeExponiendoPartesSet;
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x060015D8 RID: 5592 RVA: 0x0005BADB File Offset: 0x00059CDB
		public IReadOnlyList<ParteDelCuerpoHumano> referenciaDeExponiendoPartes
		{
			get
			{
				return this.m_referenciaDeExponiendoPartes;
			}
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x060015D9 RID: 5593 RVA: 0x0005BAE3 File Offset: 0x00059CE3
		public bool ejecutarAnimacionForzando
		{
			get
			{
				return this.m_ejecutarAnimacionForzando;
			}
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x060015DA RID: 5594 RVA: 0x0005BAEB File Offset: 0x00059CEB
		public bool cambioConVelocidad
		{
			get
			{
				return this.m_CambioConVelocidad;
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x060015DB RID: 5595 RVA: 0x0005BAF3 File Offset: 0x00059CF3
		public float velocidadDeCambio
		{
			get
			{
				return this.m_VelocidadDeCambio;
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x0005BAFB File Offset: 0x00059CFB
		public bool fueConsentido
		{
			get
			{
				return this.m_fueConsentido_O_Obligado;
			}
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x060015DD RID: 5597 RVA: 0x0005BB03 File Offset: 0x00059D03
		public bool cambiaPoseActual
		{
			get
			{
				return this.m_cambiaPoseActual;
			}
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x060015DE RID: 5598 RVA: 0x0005BB0B File Offset: 0x00059D0B
		public bool tryUsarTransicion
		{
			get
			{
				return this.m_tryUsarTransicion;
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x060015DF RID: 5599 RVA: 0x0005BB13 File Offset: 0x00059D13
		public bool ExponiendoPartesEsValido
		{
			get
			{
				return this.m_referenciaDeExponiendoPartesSet != null && this.m_referenciaDeExponiendoPartes != null && this.m_referenciaDeExponiendoPartesSet.Count > 0 && this.m_referenciaDeExponiendoPartes.Count > 0;
			}
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x0005BB44 File Offset: 0x00059D44
		public static bool TryObtenerCharacter(Object por, out Character result)
		{
			Character character = por as Character;
			if (character != null)
			{
				result = character;
				return true;
			}
			result = por.GetComponentEnRoot(false);
			if (result != null)
			{
				return true;
			}
			Debug.LogWarning(por.GetType().Name + " no es compatible para añadir a EstimuledBy", por);
			result = null;
			return false;
		}

		// Token: 0x04001161 RID: 4449
		[ReadOnlyUI]
		[SerializeField]
		private bool m_ejecutarAnimacionForzando;

		// Token: 0x04001162 RID: 4450
		[ReadOnlyUI]
		[SerializeField]
		private bool m_unaSolaVez;

		// Token: 0x04001163 RID: 4451
		[ReadOnlyUI]
		[SerializeField]
		private bool m_fueConsentido_O_Obligado;

		// Token: 0x04001164 RID: 4452
		[ReadOnlyUI]
		[SerializeField]
		private bool m_cambiaPoseActual;

		// Token: 0x04001165 RID: 4453
		[ReadOnlyUI]
		[SerializeField]
		private bool m_tryUsarTransicion;

		// Token: 0x04001166 RID: 4454
		[ReadOnlyUI]
		[SerializeField]
		private ParteQuePuedeEstimular m_estimulante;

		// Token: 0x04001167 RID: 4455
		[ReadOnlyUI]
		[SerializeField]
		private bool m_CambioConVelocidad;

		// Token: 0x04001168 RID: 4456
		[ReadOnlyUI]
		[SerializeField]
		private float m_VelocidadDeCambio;

		// Token: 0x04001169 RID: 4457
		[NonSerialized]
		private IReadOnlyList<ParteDelCuerpoHumano> m_referenciaDeExponiendoPartes;

		// Token: 0x0400116A RID: 4458
		[NonSerialized]
		private IReadOnlyCollection<int> m_referenciaDeExponiendoPartesSet;

		// Token: 0x0400116B RID: 4459
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_transformEstimulado;

		// Token: 0x0400116C RID: 4460
		[ReadOnlyUI]
		[SerializeField]
		private Character m_por;

		// Token: 0x0400116D RID: 4461
		[ReadOnlyUI]
		[SerializeField]
		private int m_poseID;
	}
}
