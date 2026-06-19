using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000013 RID: 19
	public class SequencerCommandSonrreirCara : SequencerCommand
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00006870 File Offset: 0x00004A70
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
						SequencerCommandSonrreirCara.Gestuar(componentInChildren, parameterAsFloat, num);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000068F8 File Offset: 0x00004AF8
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
		{
			RegistroDeFuncionesDeGestos.Cara.Sonrreir.Gestuar(fController, weight, duracion);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00006902 File Offset: 0x00004B02
		public void Update()
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006904 File Offset: 0x00004B04
		public void OnDestroy()
		{
		}
	}
}
