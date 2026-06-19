using System;
using Assets;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000020 RID: 32
	public class SequencerCommandGoTo : SequencerCommand
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x0000783C File Offset: 0x00005A3C
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				Character character;
				if (parameterAsBool)
				{
					character = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				else
				{
					character = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (character == null)
				{
					Debug.LogError("Character no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					string parameter = base.GetParameter(1, null);
					bool parameterAsBool2 = base.GetParameterAsBool(2, false);
					GoToScenaManager instance = Singleton<GoToScenaManager>.instance;
					if (instance == null)
					{
						Debug.LogError("GoToScenaManager no existe.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
					}
					else
					{
						GoToScenaManager.GoTo goTo = instance.Obtener(parameter);
						if (goTo == null)
						{
							Debug.LogError("no existe GoTo con key " + parameter, parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
						}
						else
						{
							ICharacterNavegable componentEnRoot = character.GetComponentEnRoot<ICharacterNavegable>();
							if (Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.useLegacyGoTo || componentEnRoot == null)
							{
								instance.Apply(character, parameterAsBool2, goTo);
							}
							else
							{
								instance.NavTo(componentEnRoot, parameterAsBool2, goTo, 1f, 1f, false);
							}
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000799C File Offset: 0x00005B9C
		public void Update()
		{
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000799E File Offset: 0x00005B9E
		public void OnDestroy()
		{
		}
	}
}
