using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200000F RID: 15
	public class SequencerCommandEnojarCara : SequencerCommand
	{
		// Token: 0x0600004E RID: 78 RVA: 0x000065D8 File Offset: 0x000047D8
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					ControlladorDeGestosFacialesEmocionales componentInChildren = componentInParent.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
					if (!(componentInChildren == null))
					{
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float parameterAsFloat2 = base.GetParameterAsFloat(0, 1f);
						float num = base.Sequencer.SubtitleEndTime * parameterAsFloat2;
						SequencerCommandEnojarCara.Gestuar(componentInChildren, parameterAsFloat, num);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00006660 File Offset: 0x00004860
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
		{
			RegistroDeFuncionesDeGestos.Cara.Enojar.Gestuar(fController, weight, duracion);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000666A File Offset: 0x0000486A
		public void Update()
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000666C File Offset: 0x0000486C
		public void OnDestroy()
		{
		}
	}
}
