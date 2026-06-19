using System;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.Globales;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200003C RID: 60
	public class SequencerCommandMoverListenerA : SequencerCommand
	{
		// Token: 0x06000129 RID: 297 RVA: 0x0000B000 File Offset: 0x00009200
		public void Start()
		{
			try
			{
				Character componentInParent = base.Sequencer.Listener.GetComponentInParent<Character>();
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

		// Token: 0x0600012A RID: 298 RVA: 0x0000B0BC File Offset: 0x000092BC
		public void Update()
		{
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000B0BE File Offset: 0x000092BE
		public void OnDestroy()
		{
		}
	}
}
