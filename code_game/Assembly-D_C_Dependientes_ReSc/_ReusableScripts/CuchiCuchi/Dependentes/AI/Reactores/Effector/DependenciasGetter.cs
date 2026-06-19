using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.Effector
{
	// Token: 0x020002D6 RID: 726
	[Serializable]
	public class DependenciasGetter
	{
		// Token: 0x06001275 RID: 4725 RVA: 0x00057B48 File Offset: 0x00055D48
		public void Init(MonoBehaviour mono)
		{
			if (mono == null)
			{
				throw new ArgumentNullException("mono", "mono null reference.");
			}
			Character character;
			this.effectorsController = mono.GetComponentEnCharacter(out character, false);
			this.animator = mono.GetComponentEnCharacter(false);
			this.interactionEffectorController = mono.GetComponentEnCharacter(false);
			this.deteccionDePuntosDeApoyoDePuppet = character.GetComponent<DeteccionDePuntosDeApoyoDePuppet>();
			this.personalidad = character.GetComponentInChildren<Personalidad>();
			this.character = character as AnimatorCharacter;
			if (this.character == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			if (this.animator == null)
			{
				throw new ArgumentNullException("animator", "animator null reference.");
			}
			if (this.effectorsController == null)
			{
				throw new ArgumentNullException("effectorsController", "effectorsController null reference.");
			}
			if (this.interactionEffectorController == null)
			{
				throw new ArgumentNullException("interactionEffectorController", "interactionEffectorController null reference.");
			}
			if (this.deteccionDePuntosDeApoyoDePuppet == null)
			{
				throw new ArgumentNullException("deteccionDePuntosDeApoyoDePuppet", "deteccionDePuntosDeApoyoDePuppet null reference.");
			}
			if (this.personalidad == null)
			{
				throw new ArgumentNullException("personalidad", "personalidad null reference.");
			}
		}

		// Token: 0x04000D7C RID: 3452
		public Animator animator;

		// Token: 0x04000D7D RID: 3453
		public AnimatorCharacter character;

		// Token: 0x04000D7E RID: 3454
		public EffectorsController effectorsController;

		// Token: 0x04000D7F RID: 3455
		public IInteractionController interactionEffectorController;

		// Token: 0x04000D80 RID: 3456
		public DeteccionDePuntosDeApoyoDePuppet deteccionDePuntosDeApoyoDePuppet;

		// Token: 0x04000D81 RID: 3457
		public Personalidad personalidad;
	}
}
