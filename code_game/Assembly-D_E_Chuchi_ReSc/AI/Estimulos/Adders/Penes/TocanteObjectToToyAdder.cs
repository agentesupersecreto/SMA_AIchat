using System;
using Assets.TValle.BeachGirl.Runtime.Males;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.Adders.Penes
{
	// Token: 0x020003FF RID: 1023
	public class TocanteObjectToToyAdder : CustomMonobehaviour
	{
		// Token: 0x0600165B RID: 5723 RVA: 0x0005CCE4 File Offset: 0x0005AEE4
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

		// Token: 0x0600165C RID: 5724 RVA: 0x0005CD3C File Offset: 0x0005AF3C
		private void Adder_added(BehaviourAdder obj)
		{
			foreach (PenisPart penisPart in (obj as CharacterToyAdder).penis.enumerator)
			{
				penisPart.physicBone.GetComponentNotNull<TocanteObjeto>();
			}
		}
	}
}
