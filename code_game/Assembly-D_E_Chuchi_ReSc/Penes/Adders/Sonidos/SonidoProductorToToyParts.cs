using System;
using Assets.TValle.BeachGirl.Runtime.Males;
using Assets._ReusableScripts.Sonidos;

namespace Assets._ReusableScripts.CuchiCuchi.Penes.Adders.Sonidos
{
	// Token: 0x02000150 RID: 336
	public class SonidoProductorToToyParts : CustomMonobehaviour
	{
		// Token: 0x06000799 RID: 1945 RVA: 0x00023A4C File Offset: 0x00021C4C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			CharacterToyAdder component = base.GetComponent<CharacterToyAdder>();
			if (component == null)
			{
				throw new ArgumentNullException("adder", "adder null reference.");
			}
			if (!component.wasAdded)
			{
				component.added += this.Adder_added;
				return;
			}
			this.Adder_added(component);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00023AA4 File Offset: 0x00021CA4
		private void Adder_added(BehaviourAdder obj)
		{
			foreach (PenisPart penisPart in (obj as CharacterToyAdder).penis.enumerator)
			{
				SonidoProductor componentNotNull = penisPart.physicBone.GetComponentNotNull<SonidoProductor>();
				componentNotNull.textura = TexturaDeObjetoSonoro.skin;
				componentNotNull.forma = FormaDeObjetoSonoro.macisa;
				componentNotNull.volumenMod = 1f;
				componentNotNull.pitchMod = 1f;
			}
		}
	}
}
