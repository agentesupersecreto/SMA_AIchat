using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000010 RID: 16
	public class SequencerCommandExagerarGestos : SequencerCommand
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00006678 File Offset: 0x00004878
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
						float parameterAsFloat = base.GetParameterAsFloat(0, 1f);
						float num = base.Sequencer.SubtitleEndTime * parameterAsFloat;
						SequencerCommandExagerarGestos.Exagerar(componentInChildren, num);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000066F0 File Offset: 0x000048F0
		public static void Exagerar(ControlladorDeGestosFacialesEmocionales fController, float duracion)
		{
			RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, duracion);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000066F9 File Offset: 0x000048F9
		public void Update()
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000066FB File Offset: 0x000048FB
		public void OnDestroy()
		{
		}
	}
}
