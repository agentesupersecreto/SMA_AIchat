using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000037 RID: 55
	public class SequencerCommandCambioEmocionDirecto : SequencerCommand
	{
		// Token: 0x06000113 RID: 275 RVA: 0x0000A968 File Offset: 0x00008B68
		public void Start()
		{
			try
			{
				Character character;
				if (base.GetParameterAsBool(0, true))
				{
					character = base.Sequencer.Listener.GetComponentEnRoot(false);
				}
				else
				{
					character = base.Sequencer.Speaker.GetComponentEnRoot(false);
				}
				EmocionesFemeninas componentInChildren = character.GetComponentInChildren<EmocionesFemeninas>();
				if (componentInChildren == null)
				{
					Debug.LogWarning("no se encontraron emociones humanas en " + character.name, character);
				}
				else if (character.GetComponentInChildren<Personalidad>() == null)
				{
					Debug.LogWarning("no se encontro Personalidad en " + character.name, character);
				}
				else
				{
					float parameterAsFloat = base.GetParameterAsFloat(1, 0f);
					if (parameterAsFloat != 0f)
					{
						ReaccionHumana reaccionHumana = base.GetParameter(2, "None").ToEnum(ReaccionHumana.None);
						if (reaccionHumana == ReaccionHumana.None)
						{
							Debug.LogWarning("no se reconoce ReaccionHumana " + base.GetParameter(2, "None"));
						}
						else
						{
							this.ChangeValue(componentInChildren, reaccionHumana, parameterAsFloat);
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000AA64 File Offset: 0x00008C64
		private void ChangeValue(EmocionesFemeninas emos, ReaccionHumana reaccion, float valor)
		{
			if (reaccion == ReaccionHumana.None)
			{
				return;
			}
			if (valor == 0f)
			{
				return;
			}
			Emocion emocion = emos.ObtenerEmocion(reaccion);
			if (emocion == null)
			{
				return;
			}
			if (valor < 0f)
			{
				emocion.ReduceValueNextUpdate(-valor);
				return;
			}
			emocion.IncreaseValueNextUpdate(valor);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000AAA8 File Offset: 0x00008CA8
		public void Update()
		{
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000AAAA File Offset: 0x00008CAA
		public void OnDestroy()
		{
		}
	}
}
