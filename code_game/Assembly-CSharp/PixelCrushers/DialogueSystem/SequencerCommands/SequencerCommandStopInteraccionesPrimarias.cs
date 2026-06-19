using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000029 RID: 41
	public class SequencerCommandStopInteraccionesPrimarias : SequencerCommand
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00008B98 File Offset: 0x00006D98
		public void Start()
		{
			try
			{
				IInteraccionesDeCharacter interaccionesDeCharacter;
				if (base.GetParameterAsBool(0, true))
				{
					interaccionesDeCharacter = base.Sequencer.Speaker.GetComponentEnCharacter(false);
				}
				else
				{
					interaccionesDeCharacter = base.Sequencer.Listener.GetComponentEnCharacter(false);
				}
				if (interaccionesDeCharacter == null)
				{
					Debug.LogWarning("no se encontro InteraccionesBasicasDeFemale");
				}
				else
				{
					foreach (InteraccionDeCharacter interaccionDeCharacter in interaccionesDeCharacter.interaccionesPrimariasBases)
					{
						if (interaccionDeCharacter.instancia.ejecutandose || interaccionDeCharacter.instancia.algunaEstaEjecutandose)
						{
							interaccionDeCharacter.instancia.Detener(false);
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00008C58 File Offset: 0x00006E58
		public void Update()
		{
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00008C5A File Offset: 0x00006E5A
		public void OnDestroy()
		{
		}
	}
}
