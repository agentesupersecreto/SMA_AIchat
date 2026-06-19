using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000039 RID: 57
	public class SequencerCommandCambioEmocionEnListenerDirecto : SequencerCommand
	{
		// Token: 0x0600011C RID: 284 RVA: 0x0000AC0C File Offset: 0x00008E0C
		public void Start()
		{
			try
			{
				EmocionesFemeninas componentEnCharacter = base.Sequencer.Listener.GetComponentEnCharacter(false);
				if (componentEnCharacter == null)
				{
					Debug.LogWarning("no se encontraron emociones humanas en " + base.Sequencer.Listener.name);
				}
				else if (componentEnCharacter.GetComponentEnCharacter(false) == null)
				{
					Debug.LogWarning("no se encontro Personalidad en " + base.Sequencer.Listener.name);
				}
				else
				{
					float parameterAsFloat = base.GetParameterAsFloat(0, 0f);
					if (parameterAsFloat != 0f)
					{
						ReaccionHumana reaccionHumana = base.GetParameter(1, "None").ToEnum(ReaccionHumana.None);
						if (reaccionHumana == ReaccionHumana.None)
						{
							Debug.LogWarning("no se reconoce ReaccionHumana " + base.GetParameter(1, "None"));
						}
						else
						{
							this.ChangeValue(componentEnCharacter, reaccionHumana, parameterAsFloat);
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000ACF4 File Offset: 0x00008EF4
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

		// Token: 0x0600011E RID: 286 RVA: 0x0000AD38 File Offset: 0x00008F38
		public void Update()
		{
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000AD3A File Offset: 0x00008F3A
		public void OnDestroy()
		{
		}
	}
}
