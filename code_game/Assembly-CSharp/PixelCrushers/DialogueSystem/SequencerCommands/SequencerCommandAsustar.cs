using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000018 RID: 24
	public class SequencerCommandAsustar : SequencerCommand
	{
		// Token: 0x0600007B RID: 123 RVA: 0x00006BF0 File Offset: 0x00004DF0
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
						ControladorDeGestosConCabeza componentInChildren2 = componentInParent.GetComponentInChildren<ControladorDeGestosConCabeza>();
						if (!(componentInChildren2 == null))
						{
							ControladorDeGestosConHombros componentInChildren3 = componentInParent.GetComponentInChildren<ControladorDeGestosConHombros>();
							if (!(componentInChildren3 == null))
							{
								float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
								float parameterAsFloat2 = base.GetParameterAsFloat(2, 0f);
								float parameterAsFloat3 = base.GetParameterAsFloat(3, 0f);
								bool parameterAsBool = base.GetParameterAsBool(4, false);
								float parameterAsFloat4 = base.GetParameterAsFloat(0, 1f);
								float num = (parameterAsBool ? parameterAsFloat4 : (base.Sequencer.SubtitleEndTime * parameterAsFloat4));
								SequencerCommandAsustar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, parameterAsFloat2, parameterAsFloat3, num);
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

		// Token: 0x0600007C RID: 124 RVA: 0x00006CD8 File Offset: 0x00004ED8
		public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Asustar.Gestuar(female, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00006CE5 File Offset: 0x00004EE5
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Asustar.Gestuar(fController, headController, hombrosController, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00006CF6 File Offset: 0x00004EF6
		public void Update()
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006CF8 File Offset: 0x00004EF8
		public void OnDestroy()
		{
		}
	}
}
