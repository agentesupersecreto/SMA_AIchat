using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000019 RID: 25
	public class SequencerCommandEnojar : SequencerCommand
	{
		// Token: 0x06000081 RID: 129 RVA: 0x00006D04 File Offset: 0x00004F04
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
								SequencerCommandEnojar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, parameterAsFloat2, parameterAsFloat3, num);
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

		// Token: 0x06000082 RID: 130 RVA: 0x00006DEC File Offset: 0x00004FEC
		public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Enojar.Gestuar(female, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00006DF9 File Offset: 0x00004FF9
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Enojar.Gestuar(fController, headController, hombrosController, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006E0A File Offset: 0x0000500A
		public void Update()
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006E0C File Offset: 0x0000500C
		public void OnDestroy()
		{
		}
	}
}
