using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000012 RID: 18
	public class SequencerCommandLamentarCara : SequencerCommand
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000067D0 File Offset: 0x000049D0
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
						SequencerCommandLamentarCara.Gestuar(componentInChildren, parameterAsFloat, num);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00006858 File Offset: 0x00004A58
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
		{
			RegistroDeFuncionesDeGestos.Cara.Lamentar.Gestuar(fController, weight, duracion);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006862 File Offset: 0x00004A62
		public void Update()
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006864 File Offset: 0x00004A64
		public void OnDestroy()
		{
		}
	}
}
