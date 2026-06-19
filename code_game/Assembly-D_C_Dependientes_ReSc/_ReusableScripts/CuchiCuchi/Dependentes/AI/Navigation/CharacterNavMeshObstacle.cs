using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Navigation
{
	// Token: 0x02000377 RID: 887
	[RequireComponent(typeof(NavMeshObstacle))]
	public class CharacterNavMeshObstacle : CustomMonobehaviour
	{
		// Token: 0x0600160C RID: 5644 RVA: 0x0006961C File Offset: 0x0006781C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			this.m_NavMeshObstacle = base.GetComponent<NavMeshObstacle>();
			this.m_defRadius = this.m_NavMeshObstacle.radius;
			this.m_updateRutina = new CoroutineCapsule(this.Rutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x0006967E File Offset: 0x0006787E
		private IEnumerator Rutine()
		{
			WaitForSeconds w = new WaitForSeconds(2f);
			for (;;)
			{
				yield return w;
				float estatura = this.m_Character.estatura;
				float escala = this.m_Character.escala;
				this.m_NavMeshObstacle.radius = this.m_defRadius * escala;
				this.m_NavMeshObstacle.center = new Vector3(0f, estatura * 0.5f, 0f);
				this.m_NavMeshObstacle.height = estatura;
			}
			yield break;
		}

		// Token: 0x04000FE8 RID: 4072
		private NavMeshObstacle m_NavMeshObstacle;

		// Token: 0x04000FE9 RID: 4073
		private CoroutineCapsule m_updateRutina;

		// Token: 0x04000FEA RID: 4074
		private float m_defRadius;

		// Token: 0x04000FEB RID: 4075
		private ICharacter m_Character;
	}
}
