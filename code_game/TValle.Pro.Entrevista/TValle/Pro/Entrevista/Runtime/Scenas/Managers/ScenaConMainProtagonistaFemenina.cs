using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales;
using RootMotion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Scenas.Managers
{
	// Token: 0x02000083 RID: 131
	public class ScenaConMainProtagonistaFemenina : ScenaManager<ScenaConMainProtagonistaFemenina>, IInicializable
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0001E5D4 File Offset: 0x0001C7D4
		public FemaleChar character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001E5DC File Offset: 0x0001C7DC
		protected override void OnAwake()
		{
			base.OnAwake();
			if (this.m_character.isAwaken)
			{
				Debug.LogError("no se puede definir la posicion por defecto de female char principal si este ya ha sido Awake, usar el SceneConfigInitializer para llamar este awake antes q el awake del character");
				return;
			}
			GoToScenaManager.GoTo goTo = Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<GoToScenaManager>.instance.Obtener("Original_GoTo");
			Transform transform = ((goTo != null) ? goTo.transform : null);
			if (transform == null)
			{
				Debug.LogError("No se encontro main non player default position");
			}
			else
			{
				this.m_character.transform.root.position = transform.position;
			}
			this.m_character.stared += this.M_character_stared;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001E66A File Offset: 0x0001C86A
		protected override void OnSceneCargada(LoadSceneMode arg1)
		{
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001E68A File Offset: 0x0001C88A
		private void M_character_stared(object sender)
		{
			base.StartCoroutine(this.WaitForStartsRutine());
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001E699 File Offset: 0x0001C899
		private IEnumerator WaitForStartsRutine()
		{
			yield return null;
			SolverManager[] solvers = this.m_character.GetComponentsInChildren<SolverManager>(false);
			bool allStared = false;
			for (;;)
			{
				FemaleChar character = this.m_character;
				if (!(((character != null) ? character.transform : null) != null) || allStared)
				{
					break;
				}
				foreach (SolverManager solverManager in solvers)
				{
					allStared = ((solverManager != null) ? new bool?(solverManager.esSolverIniciado) : null).GetValueOrDefault(true);
					if (!allStared)
					{
						break;
					}
				}
				yield return null;
			}
			yield return new WaitForSeconds(0.1f);
			this.SetRotation();
			yield break;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0001E6A8 File Offset: 0x0001C8A8
		private void SetRotation()
		{
			GoToScenaManager.GoTo goTo = Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<GoToScenaManager>.instance.Obtener("Original_GoTo");
			Transform transform = ((goTo != null) ? goTo.transform : null);
			this.m_character.SetPositionAndRotation(transform);
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001E6DD File Offset: 0x0001C8DD
		protected override void OnSceneDescargada()
		{
		}

		// Token: 0x0400032A RID: 810
		[SerializeField]
		private FemaleChar m_character;
	}
}
