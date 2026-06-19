using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000021 RID: 33
	public class SequencerCommandAllowPlayerInputsOnEntry : SequencerCommand
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x000079A8 File Offset: 0x00005BA8
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				PauseInputsOnConversation pauseInputsOnConversation;
				if (parameterAsBool)
				{
					pauseInputsOnConversation = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				else
				{
					pauseInputsOnConversation = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (pauseInputsOnConversation == null)
				{
					Debug.LogError("PauseInputsOnConversation no existe en objeto.", (!parameterAsBool) ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					this.m_puedeMoverseEnConversacion = pauseInputsOnConversation.puedeMoverseEnConversacionModificable.ObtenerModificadorNotNull(this);
					this.m_puedeMoverseEnConversacion.valor.valor = true;
					this.esperandoaJugador = true;
				}
			}
			finally
			{
				if (!this.esperandoaJugador)
				{
					base.Stop();
				}
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007A64 File Offset: 0x00005C64
		public void Update()
		{
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00007A66 File Offset: 0x00005C66
		public void OnDestroy()
		{
			ModificadorDeBool puedeMoverseEnConversacion = this.m_puedeMoverseEnConversacion;
			if (puedeMoverseEnConversacion != null)
			{
				puedeMoverseEnConversacion.TryRemoverDeOwner(true);
			}
			this.esperandoaJugador = false;
		}

		// Token: 0x04000084 RID: 132
		[Obsolete("", true)]
		private PauseInputsOnConversation m_playerInputs;

		// Token: 0x04000085 RID: 133
		private ModificadorDeBool m_puedeMoverseEnConversacion;

		// Token: 0x04000086 RID: 134
		private bool esperandoaJugador;
	}
}
