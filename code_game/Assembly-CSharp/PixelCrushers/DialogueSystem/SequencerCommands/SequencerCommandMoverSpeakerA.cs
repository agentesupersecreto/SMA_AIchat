using System;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200003D RID: 61
	public class SequencerCommandMoverSpeakerA : SequencerCommand
	{
		// Token: 0x0600012D RID: 301 RVA: 0x0000B0C8 File Offset: 0x000092C8
		public void Start()
		{
			try
			{
				Character componentInParent = base.Sequencer.Speaker.GetComponentInParent<Character>();
				if (componentInParent == null)
				{
					throw new ArgumentNullException("character", "character null reference.");
				}
				int id = base.GetParameterAsInt(0, 0);
				ScenaCharacteresManager scenaCharacteresManager = SceneSingletonV2<ScenaCharacteresManager>.Instance(componentInParent.gameObject.scene);
				if (scenaCharacteresManager == null)
				{
					throw new ArgumentNullException("manager", "manager null reference.");
				}
				ScenaCharacteresManager.TransformRegistrado transformRegistrado = scenaCharacteresManager.transformRegistrados.FirstOrDefault((ScenaCharacteresManager.TransformRegistrado t) => t.id == id);
				if (transformRegistrado == null)
				{
					throw new ArgumentNullException("trans", "trans null reference.");
				}
				transformRegistrado.Aplicar(componentInParent);
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000B184 File Offset: 0x00009384
		public void Update()
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000B186 File Offset: 0x00009386
		public void OnDestroy()
		{
		}
	}
}
