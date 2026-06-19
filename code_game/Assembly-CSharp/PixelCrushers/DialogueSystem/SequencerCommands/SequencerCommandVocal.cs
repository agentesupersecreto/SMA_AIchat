using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000040 RID: 64
	public class SequencerCommandVocal : SequencerCommand
	{
		// Token: 0x0600013D RID: 317 RVA: 0x0000B414 File Offset: 0x00009614
		public void Start()
		{
			try
			{
				ControladorDeLipSync componentEnRoot = base.Sequencer.Speaker.GetComponentEnRoot(false);
				if (componentEnRoot == null)
				{
					Debug.LogError("no se encontro ControladorDeLipSync en " + base.Sequencer.Speaker.name, this);
				}
				else
				{
					componentEnRoot.PronunciarForzar(Singleton<DialogueSystemCurrentLine>.instance.currentTextModified);
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000B488 File Offset: 0x00009688
		public void Update()
		{
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000B48A File Offset: 0x0000968A
		public void OnDestroy()
		{
		}
	}
}
