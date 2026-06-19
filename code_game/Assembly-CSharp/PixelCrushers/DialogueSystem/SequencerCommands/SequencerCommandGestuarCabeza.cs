using System;
using Assets;
using Assets.Base.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200000D RID: 13
	public class SequencerCommandGestuarCabeza : SequencerCommand
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00006480 File Offset: 0x00004680
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					ControladorDeGestosConCabeza componentInChildren = componentInParent.GetComponentInChildren<ControladorDeGestosConCabeza>();
					if (!(componentInChildren == null))
					{
						TipoDeGestoDeCabeza tipoDeGestoDeCabeza = base.GetParameter(0, "0").ToEnum(TipoDeGestoDeCabeza.placer);
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float parameterAsFloat2 = base.GetParameterAsFloat(2, 1f);
						SequencerCommandGestuarCabeza.Gestuar(componentInChildren, tipoDeGestoDeCabeza, parameterAsFloat, parameterAsFloat2, true);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00006510 File Offset: 0x00004710
		public static void Gestuar(ControladorDeGestosConCabeza fController, TipoDeGestoDeCabeza tipo, float duracion, float amplitudMod, bool duracionEsMod = true)
		{
			RegistroDeFuncionesDeGestos.Cabeza.Gestuar(fController, tipo, duracion, amplitudMod, duracionEsMod);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000651D File Offset: 0x0000471D
		public void Update()
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000651F File Offset: 0x0000471F
		public void OnDestroy()
		{
		}
	}
}
