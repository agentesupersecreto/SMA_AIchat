using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scenas
{
	// Token: 0x020000CA RID: 202
	public class ReportadorAInteraccionesEnScena : CustomMonobehaviour, IReactorRegistrador
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x000140B0 File Offset: 0x000122B0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_own = this.GetComponentEnRoot(false);
			this.m_ownSceneCharacter = this.GetComponentEnRoot(false);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x000140D4 File Offset: 0x000122D4
		public void Registrar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame)
		{
			if (!Singleton<InteraccionesEnScena>.IsInScene)
			{
				return;
			}
			InteraccionesEnScena instance = Singleton<InteraccionesEnScena>.instance;
			if (!instance.isRecording)
			{
				return;
			}
			for (int i = 0; i < resultadosEnFrame.Count; i++)
			{
				ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto = resultadosEnFrame[i] as ICalculoDeEstimuloCompleto;
				if (calculoDeEstimuloCompleto != null)
				{
					ICharacterUnico character = calculoDeEstimuloCompleto.GetCharacter();
					if (character == null)
					{
						Debug.LogError("No se pudo indentificar el owner del objeto");
					}
					else if (!(character as Object == null))
					{
						SceneCharacter component = character.GetComponent<SceneCharacter>();
						instance.Registrar(character, component, this.m_own, this.m_ownSceneCharacter, calculoDeEstimuloCompleto);
					}
				}
			}
		}

		// Token: 0x04000355 RID: 853
		private ICharacterUnico m_own;

		// Token: 0x04000356 RID: 854
		private SceneCharacter m_ownSceneCharacter;
	}
}
