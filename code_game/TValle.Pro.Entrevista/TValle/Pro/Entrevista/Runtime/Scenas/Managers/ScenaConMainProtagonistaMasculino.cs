using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales;
using RootMotion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Scenas.Managers
{
	// Token: 0x02000084 RID: 132
	public class ScenaConMainProtagonistaMasculino : ScenaManager<ScenaConMainProtagonistaMasculino>, IInicializable
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0001E6E7 File Offset: 0x0001C8E7
		public MaleChar character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0001E6F0 File Offset: 0x0001C8F0
		protected override void OnAwake()
		{
			base.OnAwake();
			if (this.m_character.isAwaken)
			{
				Debug.LogError("no se puede definir la posicion por defecto de jugador principal si este ya ha sido Awake, usar el SceneConfigInitializer para llamar este awake antes q el awake del character");
				return;
			}
			GoToScenaManager.GoTo goTo = Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<GoToScenaManager>.instance.Obtener("MainOriginal_GoTo");
			Transform transform = ((goTo != null) ? goTo.transform : null);
			if (transform == null)
			{
				Debug.LogError("No se encontro main player default position");
			}
			else
			{
				this.m_character.transform.root.position = transform.position;
			}
			this.m_character.stared += this.M_character_stared;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001E780 File Offset: 0x0001C980
		protected override void OnSceneCargada(LoadSceneMode arg1)
		{
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_character.Bind(Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<ConfiguracionGeneralUsuario>.instance.playerName, Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<ConfiguracionGeneralUsuario>.instance.playerName, string.Empty, Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid());
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001E7DE File Offset: 0x0001C9DE
		private void M_character_stared(object sender)
		{
			base.StartCoroutine(this.WaitForStartsRutine());
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001E7ED File Offset: 0x0001C9ED
		private IEnumerator WaitForStartsRutine()
		{
			yield return null;
			Penetrador[] penetrators = this.m_character.GetComponentsInChildren<Penetrador>(true);
			bool allStared = false;
			for (;;)
			{
				MaleChar character = this.m_character;
				if (!(((character != null) ? character.transform : null) != null) || allStared)
				{
					break;
				}
				foreach (Penetrador penetrador in penetrators)
				{
					allStared = ((penetrador != null) ? new bool?(penetrador.isStared) : null).GetValueOrDefault(true);
					if (!allStared)
					{
						break;
					}
				}
				yield return null;
			}
			SolverManager[] solvers = this.m_character.GetComponentsInChildren<SolverManager>(false);
			allStared = false;
			for (;;)
			{
				MaleChar character2 = this.m_character;
				if (!(((character2 != null) ? character2.transform : null) != null) || allStared)
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

		// Token: 0x06000553 RID: 1363 RVA: 0x0001E7FC File Offset: 0x0001C9FC
		private void SetRotation()
		{
			GoToScenaManager.GoTo goTo = Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<GoToScenaManager>.instance.Obtener("MainOriginal_GoTo");
			Transform transform = ((goTo != null) ? goTo.transform : null);
			this.m_character.SetPositionAndRotation(transform);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001E831 File Offset: 0x0001CA31
		protected override void OnSceneDescargada()
		{
		}

		// Token: 0x0400032B RID: 811
		[SerializeField]
		private MaleChar m_character;
	}
}
